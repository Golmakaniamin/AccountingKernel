using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Common;
using System.Transactions;
using System.Windows.Data;
using System.Collections;
using Data;

namespace AccountingKernel.Forms.Bills.PurchaseInvoice
{
    /// <summary>
    /// Interaction logic for Document.xaml
    /// </summary>
    public partial class FrmPurchaseInvoice : Window
    {
        Class.UI.TextHandeler c = new Class.UI.TextHandeler();

        private Common.Enum.FormMode _forMode;

        public Common.Enum.FormMode FormMode
        {
            get
            {
                return _forMode;
            }
            set
            {
                _forMode = value;
            }
        }

        public bool IsRegistered;

        private Guid? _storeOrderId;

        public Guid? StoreOrderId
        {
            get
            {
                if (_storeOrderId == null)
                {
                    _storeOrderId = new Guid();
                }
                return _storeOrderId;
            }
            set
            {
                _storeOrderId = value;
            }
        }

        public Guid StoreOperationId;

        public FrmPurchaseInvoice()
        {
            try
            {
                NormalConstructor();


            }
            catch
            {

                throw;
            }

        }

        public FrmPurchaseInvoice(Common.Enum.FormMode formMode, Guid storeOperation)
        {
            try
            {
                this.StoreOperationId = storeOperation;
                this.FormMode = formMode;

                NormalConstructor();

            }
            catch
            {

                throw;
            }

        }

        public FrmPurchaseInvoice(Common.Enum.FormMode formMode, Guid storeOrderId, Guid storeOperationId)
        {
            try
            {
                this.StoreOrderId = storeOrderId;
                this.StoreOperationId = storeOperationId;

                NormalConstructor();

                this.FormMode = formMode;
                var storeOrder = Business.GetStoreOrderBusiness().GetById(StoreOrderId.ToGUID());
                var storeOrderDetails = Business.GetStoreOrderDetailBusiness().GetByStoreOrderId(storeOrder.Id).ToList();

                SetDataGrid();

                SetHeader(storeOrder);

                SetFooter(storeOrder, storeOrderDetails);
            }
            catch
            {

                throw;
            }

        }

        private void SetHeader(StoreOrder storeOrder)
        {
            try
            {
                txtBillNum.Text = storeOrder.OId;
                txtOwnerBillNum.Text = storeOrder.OOwnerId.ToInt().ToString();
                dtpIssueDate.Text = storeOrder.ODate;
                if (storeOrder.IdCompany.HasValue)
                    txtCompany.Text = Business.GetComBusiness().GetById(storeOrder.IdCompany.Value).CName;
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// sets store order detail data grid 
        /// </summary>
        private void SetDataGrid()
        {
            try
            {
                var units = Business.GetBaseInfoBusiness().GetByType(Constants.BaseInfoType.Units);
                var storeOrders = Business.GetStoreOrderBusiness().GetAll();
                var commodities = Business.GetGoodiesBusiness().GetAll();

                var storeOrderId = this.StoreOrderId.ToGUID();
                var storeDetails = Business.GetStoreOrderDetailBusiness().GetByStoreOrderId(storeOrderId).Join(
                    commodities, o => o.IdCommodity, i => i.ID, (o, i) => new
                    {
                        StoreDetail = o,
                        Commodity = i
                    }).ToList();

                DataGrid.ItemsSource = storeDetails.Select(r => new
                    {
                        Id = r.StoreDetail.Id,
                        CommodityCode = r.Commodity.CID1,
                        CommodityName = r.Commodity.CName,
                        Count = r.StoreDetail.ODCount,
                        Unit = units.Find(t => t.Id == r.StoreDetail.ODCountingUnit).AssignName,
                        UnitPrice = r.StoreDetail.ODMoney / r.StoreDetail.ODCount,
                    }).ToList();



            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// commodity selection event click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectCommodity_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var frmShow = new Goodies.FrmShow();
                frmShow.ShowDialog();

                var goodyId = frmShow.Result;

                if (goodyId != Guid.Empty)
                    txtCommodityCode.Text = Business.GetGoodiesBusiness().GetById(goodyId).CName;
                else
                    txtCommodityCode.Text = string.Empty;


                SetUnitCountComboBox(goodyId);

            }
            catch (Exception ex)
            {

                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);

            }
        }

        private void btnSelectCompany_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var frmCompanies = new Company.frmCompanies(Common.Constants.CustomerType.Seller);
                frmCompanies.ShowDialog();

                var companyId = frmCompanies.Result;
                if (companyId != Guid.Empty)
                    txtCompany.Text = Business.GetComBusiness().GetById(companyId).CName;
                else
                    txtCompany.Text = string.Empty;
            }
            catch (Exception ex)
            {

                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);

            }
        }

        private void SetUnitCountComboBox(Guid commodityId)
        {
            try
            {
                var commodity = Business.GetGoodiesBusiness().GetById(commodityId);
                var commodityConvertCountingUnits = Business.GetGoodyConvertCountingUnitBusiness().GetByGoodyId(commodityId).ToList();
                var unitIds = commodityConvertCountingUnits.Where(r => r.CCCUIDBaseInfo1.HasValue).Select(r => r.CCCUIDBaseInfo1.Value).
                    Union(commodityConvertCountingUnits.Where(r => r.CCCUIDBaseInfo2.HasValue).Select(r => r.CCCUIDBaseInfo2.Value)).ToList();
                if (commodity.CBaseCountingUnit.HasValue)
                    unitIds.Add(commodity.CBaseCountingUnit.Value);
                cmbUnitCount.ItemsSource = Business.GetBaseInfoBusiness().GetByIds(unitIds).ToList();
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// register store order detail
        /// </summary>
        private StoreOrderDetail RegisterStoreDetail(StoreOrder storeOrder)
        {
            try
            {
                var commodity = Business.GetGoodiesBusiness().GetByName(txtCommodityCode.Text);
                if (commodity == null)
                    throw new Exception(Localize.ex_commodity_not_found);
                var storeOrderDetailBusiness = Business.GetStoreOrderDetailBusiness();

                var storeOrderDetail = Business.GetStoreOrderDetailBusiness().GetByCommodity(storeOrder, commodity.ID, cmbUnitCount.SelectedValue.ToGUID());
                if (storeOrderDetail == null)
                    storeOrderDetail = new StoreOrderDetail();

                var company = Business.GetComBusiness().GetByName(txtCompany.Text.Trim());

                storeOrderDetail.IdStoreOrder = storeOrder.Id;
                storeOrderDetail.IdCommodity = commodity.ID;
                storeOrderDetail.IdStoreS = StoreOperationId;
                storeOrderDetail.ODCountingUnit = cmbUnitCount.SelectedValue.ToGUID();
                storeOrderDetail.ODCount = storeOrderDetail.ORemained = txtCount.Text.ToInt();
                storeOrderDetail.ODMoney = txtUnitPrice.Text.ToDecimal() * txtCount.Text.ToInt();
                storeOrderDetail.ODDiscount = txtDicountPrice.Text.ToDecimal();
                storeOrderDetail.ODDescription = txtBillDescription.Text;

                Business.GetStoreOrderDetailBusiness().Save(storeOrderDetail);

                return storeOrderDetail;
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// regitser store order
        /// </summary>
        public StoreOrder RegisterStoreOrder()
        {
            try
            {
                var storeOrder = Business.GetStoreOrderBusiness().GetById(StoreOrderId.ToGUID());

                if (storeOrder == null)
                    storeOrder = new StoreOrder();

                var company = Business.GetComBusiness().GetByName(txtCompany.Text);
                if (company == null)
                    //رخداد خطا
                    throw new Exception(Localize.ex_company_not_found);

                storeOrder.OId = txtBillNum.Text.Trim().Length == 0 ? Business.GetStoreOrderBusiness().GetLastEditedOId(this.StoreOperationId) : txtBillNum.Text;

                storeOrder.OOwnerId = txtOwnerBillNum.Text.Trim().ToInt();
                storeOrder.ODate = dtpIssueDate.Text;
                storeOrder.IdCompany = company.Id;
                storeOrder.OReverse = false;
                storeOrder.ODelete = false;
                storeOrder.IdStoreOperation = this.StoreOperationId;
                Business.GetStoreOrderBusiness().Save(storeOrder);

                StoreOrderId = storeOrder.Id;
                // this code is used for cases that txtBillNum.Text is empty
                txtBillNum.Text = storeOrder.OId.ToString();
                return storeOrder;

            }
            catch
            {

                throw;
            }
        }

        private StoreOrder SaveForSaleInvoice(StoreOrder storeOrder)
        {
            try
            {
                var storeDetailsBusiness = Business.GetStoreOrderDetailBusiness();
                var storeOrderBusiness = Business.GetStoreOrderBusiness();

                var storeDetails = storeDetailsBusiness.GetByStoreOrderId(storeOrder.Id);
                var saleStoreOrder = storeOrderBusiness.Clone(storeOrder);
                saleStoreOrder.IdStoreOperation = Constants.StoreOperation.SaleInvoice;
                storeOrderBusiness.Save(saleStoreOrder);

                foreach (var item in storeDetails)
                {
                    var saleStoreDetail = new StoreOrderDetail();
                    saleStoreDetail = storeDetailsBusiness.Clone(item);
                    saleStoreDetail.IdStoreOrder = saleStoreDetail.Id;
                    storeDetailsBusiness.Save(saleStoreDetail);
                }

                return saleStoreOrder;

            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// store detail order selected cell changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                Guid id = (DataGrid.SelectedValue as dynamic).Id;
                var storeOrderDetail = Business.GetStoreOrderDetailBusiness().GetById(id);
                var goodies = Business.GetGoodiesBusiness().GetById(storeOrderDetail.IdCommodity);

                SetUnitCountComboBox(storeOrderDetail.IdCommodity);

                txtCommodityCode.Text = goodies.CName;
                cmbUnitCount.SelectedValue = storeOrderDetail.ODCountingUnit;
                txtCount.Text = storeOrderDetail.ODCount.ToString();
                txtUnitPrice.Text = (storeOrderDetail.ODMoney / storeOrderDetail.ODCount).ToString(Localize.DoubleMaskType);
                txtDicountPrice.Text = storeOrderDetail.ODDiscount.ToString(Localize.DoubleMaskType);
                txtBillDescription.Text = storeOrderDetail.ODDescription;


            }
            catch
            {

                throw;
            }
        }

        private void btnRegisterCommodity_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var errorMessage = string.Empty;

                if (!ValidateForm(out errorMessage))
                    throw new Exception(errorMessage);

                var storeOrder = new StoreOrder();

                var storeOrderDetails = new List<StoreOrderDetail>();

                using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
                {
                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted,
                    Timeout = new TimeSpan(2, 0, 0)
                }))
                {
                    storeOrder = RegisterStoreOrder();

                    RegisterStoreDetail(storeOrder);

                    storeOrderDetails = Business.GetStoreOrderDetailBusiness().GetByStoreOrderId(storeOrder.Id).ToList();

                    SetTotalInformations(storeOrder, storeOrderDetails);

                    scope.Complete();
                }

                SetFooter(storeOrder, storeOrderDetails);

                SetDataGrid();

                this.StoreOrderId = storeOrder.Id;
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private bool ValidateForm(out string errorMessage)
        {
            try
            {
                errorMessage = string.Empty;

                if (txtBillNum.Text.Trim().Length == 0)
                    errorMessage += Localize.ex_no_bill_num;

                if (txtOwnerBillNum.Text.Trim().Length == 0)
                    errorMessage += Localize.ex_no_owner_num;

                if (Business.GetComBusiness().GetByName(txtCompany.Text) == null)
                    errorMessage += Localize.ex_no_company_seletced + Environment.NewLine;

                if (Business.GetGoodiesBusiness().GetByName(txtCommodityCode.Text) == null)
                    errorMessage += Localize.ex_no_commodity_seletced + Environment.NewLine;

                if (cmbUnitCount.SelectedIndex < 0)
                    errorMessage += Localize.ex_no_unitcount_seletced + Environment.NewLine;

                if (txtCount.Text.ToInt() <= 0)
                    errorMessage += Localize.ex_invalid_commodity_count + Environment.NewLine;

                if (txtUnitPrice.Text.Trim().Length == 0)
                    errorMessage += Localize.ex_no_price;

                var company = Business.GetComBusiness().GetByName(txtCompany.Text);

                if (company != null && Business.GetStoreOrderBusiness().IsCodeExist(company, Common.Constants.StoreOperation.PurchaseInvoice, txtBillNum.Text, StoreOrderId.Value))
                    errorMessage += Localize.ex_duplicated_code;

                return errorMessage == string.Empty;
            }
            catch
            {

                throw;
            }
        }

        private void SetTotalInformations(StoreOrder storeOrder, List<StoreOrderDetail> storeOrderDetails)
        {
            try
            {
                var sumDetails = storeOrderDetails.Sum(r => r.ODMoney);
                storeOrder.OMunicipalTax = sumDetails * txtTotalMunicipalTax.Text.ToDecimal() / (decimal)100;
                storeOrder.OTax = sumDetails * txtTotalTax.Text.ToDecimal() / (decimal)100;

                storeOrder.OSumMoney = sumDetails + storeOrder.OMunicipalTax + storeOrder.OTax -
                    (storeOrderDetails.Sum(r => r.ODDiscount) + txtDicountPrice.Text.ToDecimal()) * sumDetails / (decimal)100;
                storeOrder.ODiscount = txtTotalDiscount.Text.ToDecimal();

                Business.GetStoreOrderBusiness().Save(storeOrder);

            }
            catch
            {

                throw;
            }
        }

        private void SetTotalInformationsForControls()
        {
            try
            {
                var storeOrderDetails = Business.GetStoreOrderDetailBusiness().GetByStoreOrderId(this.StoreOrderId.Value).ToList();

                var sumDetails = storeOrderDetails.Sum(r => r.ODMoney);
                var oMunicipalTax = sumDetails * txtTotalMunicipalTax.Text.ToDecimal() / (decimal)100;
                var oTax = sumDetails * txtTotalTax.Text.ToDecimal() / (decimal)100;

                txtTotalPrice.Text = (sumDetails + oMunicipalTax + oTax -
                    (storeOrderDetails.Sum(r => r.ODDiscount) + txtTotalDiscount.Text.ToDecimal()) * sumDetails / (decimal)100).ToString(Localize.DoubleMaskType);

            }
            catch
            {

                throw;
            }
        }

        private void Tax_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                SetTotalInformationsForControls();
            }
            catch
            {

                throw;
            }
        }

        private void SetFooter(StoreOrder storeOrder, List<StoreOrderDetail> storeOrderDetails)
        {
            try
            {
                var sumDetails = storeOrderDetails.Sum(r => r.ODMoney.ToDecimal());

                txtTotalMunicipalTax.Text = sumDetails == 0 ? "0" : (storeOrder.OMunicipalTax.ToDecimal() * (decimal)100 / sumDetails).ToString(Localize.DoubleMaskType);
                txtTotalTax.Text = sumDetails == 0 ? "0" : (storeOrder.OTax.ToDecimal() * (decimal)100 / sumDetails).ToString(Localize.DoubleMaskType);
                txtTotalDiscount.Text = storeOrder.ODiscount.ToString(Localize.DoubleMaskType);
                txtTotalPrice.Text = storeOrder.OSumMoney.ToString(Localize.DoubleMaskType);
                var storeOrderDetailIds = Business.GetStoreOrderDetailBusiness().GetByStoreOrderId(storeOrder.Id).Select(r => r.Id).ToList();
                var stores = Business.GetStoreSBusiness().GetByStoreOrderDetailIds(storeOrderDetailIds);
                if (stores.Any())
                {
                    cmbStoreS.SelectedValue = stores.First().Sname;
                    cmbStoreS.IsEnabled = false;
                }
            }
            catch
            {

                throw;
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var errorMessage = string.Empty;
                if (cmbStoreS.SelectedIndex < 0)
                    throw new Exception(Localize.ex_no_stroes_selected);


                var commodity = Business.GetGoodiesBusiness().GetByName(txtCommodityCode.Text);

                var company = Business.GetComBusiness().GetByName(txtCompany.Text);

                if (Business.GetStoreOrderBusiness().IsCodeExist(company, Common.Constants.StoreOperation.PurchaseInvoice, txtBillNum.Text, StoreOrderId.Value))
                    throw new Exception(Localize.ex_duplicated_code);


                using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
                {
                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted,
                    Timeout = new TimeSpan(2, 0, 0)
                }))
                {
                    var storeOrder= RegisterStoreOrder();
                    this.StoreOrderId = storeOrder.Id;

                    this.SetStores(this.StoreOrderId.Value);

                    Business.GetAccountingDocumentBusiness().SaveAutomaticDocumentForPurchaseInvoice(storeOrder);

                    scope.Complete();
                }

                IsRegistered = true;
                this.Close();

            }
            catch (Exception ex)
            {

                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);

            }
        }

        private void SetStores(Guid storeOrderId)
        {
            try
            {
                switch (this.FormMode)
                {
                    case Common.Enum.FormMode.New:
                        SetStoresForNew(storeOrderId);
                        break;
                    case Common.Enum.FormMode.Edit:
                        SetStoresForEdit(storeOrderId);
                        break;
                    default:
                        break;
                }


            }
            catch
            {

                throw;
            }
        }

        private void SetStoresForEdit(Guid storeOrderId)
        {
            try
            {

                using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
                {
                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted,
                    Timeout = new TimeSpan(2, 0, 0)
                }))
                {
                    var storeDetails = Business.GetStoreOrderDetailBusiness().GetByStoreOrderId(storeOrderId).ToList();
                    var currentStores = Business.GetStoreSBusiness().GetByStoreOrderDetailIds(storeDetails.Select(r => r.Id).ToList());
                    var stores = new List<Data.Store>();
                    foreach (var item in storeDetails)
                    {
                        var currentStore = currentStores.Find(r => r.IdStoreOrderDetail == item.Id);
                        var previousStore = Business.GetStoreSBusiness().GetLastForCommodity(item.IdCommodity);
                        var remained = 0;
                        if (previousStore != null)
                            remained = previousStore.SRemained.ToInt();

                        var commodity = Business.GetGoodiesBusiness().GetById(item.IdCommodity);

                        var coef = Business.GetGoodyConvertCountingUnitBusiness().FindCoefficient(item.IdCommodity, commodity.CBaseCountingUnit.ToGUID(), item.ODCountingUnit);
                        stores.Add(new Data.Store()
                        {
                            IdStoreOrderDetail = item.Id,
                            RegDate = currentStore == null ? DateTime.Now : currentStore.RegDate,
                            EditDate = DateTime.Now,
                            SCount = item.ODCount,
                            SRemained = remained - currentStore.SCount + (item.ODCount * coef).ToInt(),
                            Sname = cmbStoreS.SelectedValue.ToGUID(),
                            IdStoreOperation = Common.Constants.StoreOperation.PurchaseInvoice,
                            IdCommodity = item.IdCommodity
                        });

                    }

                    Business.GetStoreSBusiness().Insert(stores);

                    Business.GetStoreSBusiness().Delete(currentStores);

                    scope.Complete();
                }
            }
            catch
            {

                throw;
            }
        }

        private void SetStoresForNew(Guid storeOrderId)
        {
            try
            {

                using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
                {
                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted,
                    Timeout = new TimeSpan(2, 0, 0)
                }))
                {
                    var storeDetails = Business.GetStoreOrderDetailBusiness().GetByStoreOrderId(storeOrderId).ToList();
                    var stores = new List<Data.Store>();
                    foreach (var item in storeDetails)
                    {
                        var previousStore = Business.GetStoreSBusiness().GetLastForCommodity(item.IdCommodity);
                        var remained = 0;
                        if (previousStore != null)
                            remained = previousStore.SRemained.ToInt();

                        var commodity = Business.GetGoodiesBusiness().GetById(item.IdCommodity);

                        var coef = Business.GetGoodyConvertCountingUnitBusiness().FindCoefficient(item.IdCommodity, commodity.CBaseCountingUnit.ToGUID(), item.ODCountingUnit);

                        stores.Add(new Data.Store()
                        {
                            IdStoreOrderDetail = item.Id,
                            RegDate = DateTime.Now,
                            SCount = item.ODCount,
                            SRemained = remained + (item.ODCount * coef).ToInt(),
                            Sname = cmbStoreS.SelectedValue.ToGUID(),
                            IdStoreOperation = Common.Constants.StoreOperation.PurchaseInvoice,
                            IdCommodity = item.IdCommodity
                        });

                    }

                    Business.GetStoreSBusiness().Insert(stores);

                    scope.Complete();
                }
            }
            catch
            {

                throw;
            }
        }

        private void NormalConstructor()
        {
            try
            {
                InitializeComponent();
                Business.GetComBusiness().GetByCType(Common.Constants.CustomerType.Seller).ToList().ForEach(r =>
                    txtCompany.AddItem(new WPFAutoCompleteTextbox.AutoCompleteEntry(r.CName, r.CName)));

                cmbStoreS.ItemsSource = Business.GetBaseInfoBusiness().GetByType(Common.Constants.BaseInfoType.StoreSType);
                cmbBase.ItemsSource = Business.GetBaseInfoBusiness().GetByType(Common.Constants.BaseInfoType.PurchaseInvoiceBase);
                txtBillNum.Text = Business.GetStoreOrderBusiness().GetLastEditedOId(this.StoreOperationId);
                chbBase_Checked();
                setTaxDefault();

            }
            catch
            {

                throw;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (FormMode == Common.Enum.FormMode.New && !IsRegistered.ToBoolean() && StoreOrderId.HasValue)
                    Business.GetStoreOrderBusiness().PhysicalDeleting(StoreOrderId.Value);
            }
            catch
            {

                throw;
            }
        }

        private void btnSelectBase_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Guid? baseStoreOrderId;

                if (cmbBase.SelectedValue.ToGUID() == Common.Constants.PurchaseInvoiceBase.BuyRequest)
                    throw new NotImplementedException();
                else
                {
                    var frmSaleInvoiceManagement = new Bills.WarehouseReceipts.FrmReceiptManagment();
                    frmSaleInvoiceManagement.ShowDialog();
                    baseStoreOrderId = frmSaleInvoiceManagement.StoreOrderId;
                }
                var storeOrderDetailBusiness = Business.GetStoreOrderDetailBusiness();


                if (baseStoreOrderId.HasValue)
                {
                    var baseStoreOrder = Business.GetStoreOrderBusiness().GetById(baseStoreOrderId.Value);
                    txtBase.Text = Business.GetStoreOrderBusiness().GetById(baseStoreOrderId.Value).OId;

                    var company = Business.GetComBusiness().GetById(baseStoreOrder.IdCompany.Value);
                    txtCompany.Text = company.CName;


                    using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
                    {
                        IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted,
                        Timeout = new TimeSpan(2, 0, 0)
                    }))
                    {
                        if (StoreOrderId == Guid.Empty)
                            this.StoreOrderId = RegisterStoreOrder().Id;
                        else
                            storeOrderDetailBusiness.DeleteByStoreOrderId(StoreOrderId.Value);
                        var storeOrderDetails = storeOrderDetailBusiness.GetByStoreOrderId(baseStoreOrderId.Value).ToList();

                        var returnOfSaleDetails = new List<Data.StoreOrderDetail>();
                        foreach (var item in storeOrderDetails)
                        {
                            var newItem = storeOrderDetailBusiness.Clone(item);
                            newItem.IdStoreOrder = StoreOrderId.Value;
                            newItem.IdStoreS = Guid.Empty;
                            returnOfSaleDetails.Add(newItem);
                        }
                        storeOrderDetailBusiness.Insert(returnOfSaleDetails);


                        scope.Complete();
                    }
                }

                SetDataGrid();

            }
            catch (Exception ex)
            {

                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);

            }
        }

        private void chbBase_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                chbBase_Checked();
            }
            catch
            {

                throw;
            }
        }

        private void chbBase_Checked()
        {
            try
            {
                cmbBase.IsEnabled = chbBase.IsChecked.ToBoolean();
                txtCompany.IsEnabled = !chbBase.IsChecked.ToBoolean();
                btnSelectBase.IsEnabled = !chbBase.IsChecked.ToBoolean();
                cmbBaseChanged();
            }
            catch
            {

                throw;
            }
        }

        private void cmbBase_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                cmbBaseChanged();
            }
            catch
            {

                throw;
            }
        }

        private void cmbBaseChanged()
        {
            try
            {
                btnSelectBase.IsEnabled = txtBase.IsEnabled = cmbBase.SelectedValue != null;
                Business.GetStoreOrderBusiness().GetByStoreOperation(cmbBase.SelectedValue.ToGUID()).Where(r => r.OId != null).
                    Select(r => r.OId).Distinct().ToList().ForEach(r =>
                    txtBase.AddItem(new WPFAutoCompleteTextbox.AutoCompleteEntry(r, r)));


            }
            catch
            {

                throw;
            }
        }

        private void txtOwnerBillNum_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtOwnerBillNum_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }

        private void txtUnitPrice_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                var totalPrice = txtCount.Text.ToDouble() * txtUnitPrice.Text.ToDouble();
                txtTotalRowPrice.Text = ((((double)100 - txtDicountPrice.Text.ToDouble()) / (double)100) * totalPrice).ToString(Localize.DoubleMaskType);
            }
            catch
            {

                throw;
            }
        }

        private void dtpIssueDate_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                setTaxDefault();
            }
            catch
            {

                throw;
            }
        }

        private void setTaxDefault()
        {
            try
            {
                if (dtpIssueDate.Text == null)
                    return;
                var soTaxes = Business.GetSOTaxBusiness().GetViewByCorporationId(MainWindow.CorposrationId).ToList();
                var fYear = Business.GetFinancialMainYearBusiness().GetByYear(dtpIssueDate.Text, MainWindow.CorposrationId);
                if (fYear == null)
                    return;

                var municipalTax = soTaxes.FirstOrDefault(r => r.IdFinancialMainYear == fYear.ID && r.IdBaseinfo == Common.Constants.Tax.MunicipalTax);
                var vatTax = soTaxes.FirstOrDefault(r => r.IdFinancialMainYear == fYear.ID && r.IdBaseinfo == Common.Constants.Tax.VAT);

                if (municipalTax != null)
                    txtTotalMunicipalTax.Text = municipalTax.Percent.ToString();

                if (vatTax != null)
                    txtTotalTax.Text = vatTax.Percent.ToString();


            }
            catch
            {

                throw;
            }
        }

        private void txtTotalRowPrice_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            c.AddZero(sender,e);
            c.CheckIsNumeric(e);
        }

        private void txtCount_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }

        private void txtUnitPrice_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
            c.AddZero(sender, e);
        }

        private void txtUnitPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            c.SepratTextBox(sender, e);
        }

        private void txtTotalPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            c.SepratTextBox(sender, e);
        }

        private void txtCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            c.SepratTextBox(sender, e);
        }

        private void txtTotalRowPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            c.SepratTextBox(sender, e);
        }

        private void txtTotalMunicipalTax_TextChanged(object sender, TextChangedEventArgs e)
        {
            c.SepratTextBox(sender, e);
        }

        private void txtTotalTax_TextChanged(object sender, TextChangedEventArgs e)
        {
            c.SepratTextBox(sender, e);
        }

    }
}
