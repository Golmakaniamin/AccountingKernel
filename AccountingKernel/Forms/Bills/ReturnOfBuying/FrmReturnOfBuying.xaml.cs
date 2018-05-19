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

namespace AccountingKernel.Forms.Bills.ReturnOfBuying
{
    /// <summary>
    /// Interaction logic for Document.xaml
    /// </summary>
    public partial class FrmReturnOfBuying : Window
    {
        Class.UI.TextHandeler c = new Class.UI.TextHandeler();
        public Common.Enum.FormMode FormMode { get; set; }
        public bool IsRegistered;

        private Guid _storeOrderId;

        public Guid StoreOrderId
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


        private Guid _storeDetailId;

        public Guid StoreDetailId
        {
            get
            {
                return _storeDetailId;
            }
            set
            {
                _storeDetailId = value;
            }
        }

        public Guid StoreOperationId;

        public FrmReturnOfBuying()
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

        public FrmReturnOfBuying(Common.Enum.FormMode formMode, Guid storeOpertion, Guid? storeOrderId)
        {
            try
            {
                this.StoreOrderId = storeOrderId.ToGUID();
                this.FormMode = formMode;
                this.StoreOperationId = storeOpertion;

                NormalConstructor();
                SetDataGrid();

                var storeOrder = Business.GetStoreOrderBusiness().GetById(StoreOrderId);
                if (storeOrder != null)
                {
                    var storeOrderDetails = Business.GetStoreOrderDetailBusiness().GetByStoreOrderId(storeOrder.Id).ToList();

                    SetHeader(storeOrder);

                    SetFooter(storeOrder, storeOrderDetails);
                }

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
                var commodoties = Business.GetGoodiesBusiness().GetAll();
                var t = Business.GetStoreOrderDetailBusiness().GetByStoreOrderId(this.StoreOrderId).Join(
                    commodoties, o => o.IdCommodity, i => i.ID, (o, i) => new { o, i }).ToList();


                DataGrid.ItemsSource = t.Select(r => new
                {
                    Id = r.o.Id,
                    DiscountPrice = r.o.ODDiscount,
                    UnitPrice = (r.o.ODMoney / r.o.ODCount).ToString(Localize.DoubleMaskType),
                    Count = r.o.ODCount,
                    CommodityName = r.i.CName,
                    CommodityCode = r.i.CID1
                }).ToList();

            }
            catch
            {

                throw;
            }
        }

        private void SetUnitCountComboBox(Guid commodityId)
        {
            try
            {
                var commodityConvertCountingUnits = Business.GetGoodyConvertCountingUnitBusiness().GetByGoodyId(commodityId).ToList();
                var unitIds = commodityConvertCountingUnits.Where(r => r.CCCUIDBaseInfo1.HasValue).Select(r => r.CCCUIDBaseInfo1.Value).
                    Union(commodityConvertCountingUnits.Where(r => r.CCCUIDBaseInfo2.HasValue).Select(r => r.CCCUIDBaseInfo2.Value)).ToList();
                cmbUnitCount.ItemsSource = Business.GetBaseInfoBusiness().GetByIds(unitIds).ToList();
                cmbUnitCount.SelectedValue = Business.GetGoodiesBusiness().GetById(commodityId).CBaseCountingUnit;
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
                //var sumDetails = storeOrderDetails.Sum(r => r.ODMoney.ToDecimal());

                //txtTotalMunicipalTax.Text = sumDetails == 0 ? "0" : (storeOrder.OMunicipalTax.ToDecimal() * (decimal)100 / sumDetails).ToString(Localize.DoubleMaskType);
                //txtTotalTax.Text = sumDetails == 0 ? "0" : (storeOrder.OTax.ToDecimal() * (decimal)100 / sumDetails).ToString(Localize.DoubleMaskType);
                //txtTotalDiscount.Text = storeOrder.ODiscount.ToDecimal().ToString();
                //txtTotalPrice.Text = storeOrder.OSumMoney.ToDecimal().ToString();
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
                var storeDetails = Business.GetStoreOrderDetailBusiness().GetByStoreOrderId(StoreOrderId).ToList();
                if (!storeDetails.Any())
                    throw new Exception(Localize.ex_no_commodity_inserted);

                var company = Business.GetComBusiness().GetByName(txtCompany.Text);
                if (company == null)
                    //رخداد خطا
                    throw new Exception(Localize.ex_company_not_found);

                using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
                {
                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted,
                    Timeout = new TimeSpan(2, 0, 0)
                }))
                {
                    var storeOrder = RegisterStoreOrder(company);
                    this.StoreOrderId = storeOrder.Id;

                    Business.GetAccountingDocumentBusiness().SaveAutomaticDocumentForSaleReturnInvoice(storeOrder);

                    scope.Complete();
                }

                this.IsRegistered = true;
                this.Close();
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

                txtCompany.ClearItems();
                Business.GetComBusiness().GetByCType(Common.Constants.CustomerType.Buyer).ToList().ForEach(r =>
                    txtCompany.AddItem(new WPFAutoCompleteTextbox.AutoCompleteEntry(r.CName, r.CName)));

                txtCommodity.ClearItems();
                Business.GetGoodiesBusiness().GetAll().ToList().ForEach(r =>
                {
                    txtCommodity.AddItem(new WPFAutoCompleteTextbox.AutoCompleteEntry(r.CName, r.CName));
                        txtCommodity.AddItem(new WPFAutoCompleteTextbox.AutoCompleteEntry(r.CID1, r.CID1));
                });

                cmbBase.ItemsSource = Business.GetBaseInfoBusiness().GetByType(Common.Constants.BaseInfoType.ReturnOfBuyingBase);

                chbBase_Checked();

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

                var commodity = Business.GetGoodiesBusiness().GetByName(txtCommodity.Text);
                if (commodity == null)
                    throw new Exception(Localize.ex_no_commodity_seletced);

                if (cmbUnitCount.SelectedIndex < 0)
                    throw new Exception(Localize.ex_no_unitcount_seletced);

                if (txtCount.Text.ToInt() == 0)
                    throw new Exception(Localize.ex_invalid_count);

                if (StoreOperationId == Guid.Empty)
                    throw new Exception(Localize.ex_invalid_data);

                var company = Business.GetComBusiness().GetByName(txtCompany.Text);
                if (company == null)
                    //رخداد خطا
                    throw new Exception(Localize.ex_company_not_found);

                var priceList = Business.GetPriceListBusiness().GetByCommodityIdCompanyPriceTypeId(company.CPriceType.ToGUID(), commodity.ID);
                if (priceList == null)
                    throw new Exception(Localize.ex_no_price);

                using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
                {
                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted,
                    Timeout = new TimeSpan(2, 0, 0)
                }))
                {
                    var storeOrder = RegisterStoreOrder(company);

                    RegisterStoreDetail(storeOrder, priceList);

                    this.StoreOrderId = storeOrder.Id;

                    //this.SetStores(storeOrder, repository, commodity, company, priceList);

                    scope.Complete();
                }

                SetDataGrid();

            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        public StoreOrder RegisterStoreOrder(Data.Com company)
        {
            try
            {
                var storeOrder = Business.GetStoreOrderBusiness().GetById(StoreOrderId.ToGUID());

                if (storeOrder == null)
                    storeOrder = new StoreOrder();

                storeOrder.OId = storeOrder.OId.IsNullOrEmpty() ? Business.GetStoreOrderBusiness().GetLastEditedOId(this.StoreOperationId) : storeOrder.OId;
                storeOrder.ODate = dtpIssueDate.Text;
                storeOrder.IdCompany = company.Id;
                storeOrder.OReverse = false;
                storeOrder.ODelete = false;
                storeOrder.IdStoreOperation = this.StoreOperationId;
                Business.GetStoreOrderBusiness().Save(storeOrder);

                return storeOrder;

            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// register store order detail
        /// </summary>
        private StoreOrderDetail RegisterStoreDetail(StoreOrder storeOrder, Data.PriceList priceList)
        {
            try
            {
                var commodity = Business.GetGoodiesBusiness().GetByName(txtCommodity.Text);
                if (commodity == null)
                    throw new Exception(Localize.ex_commodity_not_found);
                var storeOrderDetailBusiness = Business.GetStoreOrderDetailBusiness();

                var storeOrderDetail = Business.GetStoreOrderDetailBusiness().GetByCommodity(storeOrder, commodity.ID, cmbUnitCount.SelectedValue.ToGUID());
                if (storeOrderDetail == null)
                    storeOrderDetail = new StoreOrderDetail();

                var company = Business.GetComBusiness().GetByName(txtCompany.Text.Trim());

                storeOrderDetail.IdStoreOrder = storeOrder.Id;
                storeOrderDetail.IdCommodity = commodity.ID;
                storeOrderDetail.ODCountingUnit = cmbUnitCount.SelectedValue.ToGUID();
                storeOrderDetail.ODCount = storeOrderDetail.ORemained = txtCount.Text.ToInt();
                storeOrderDetail.ODMoney = priceList.PLPrice * txtCount.Text.ToInt();
                //storeOrderDetail.ODDiscount = txtDicountPrice.Text.ToDecimal();
                storeOrderDetail.ODDescription = txtComment.Text;

                Business.GetStoreOrderDetailBusiness().Save(storeOrderDetail);

                return storeOrderDetail;
            }
            catch
            {

                throw;
            }
        }

        private void DataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                if (DataGrid.SelectedValue == null)
                    return;

                Guid id = (DataGrid.SelectedValue as dynamic).Id;
                var storeOrderDetail = Business.GetStoreOrderDetailBusiness().GetById(id);
                var goody = Business.GetGoodiesBusiness().GetById(storeOrderDetail.IdCommodity);

                SetUnitCountComboBox(storeOrderDetail.IdCommodity);

                txtCommodity.Text = goody.CName;
                cmbUnitCount.SelectedValue = storeOrderDetail.ODCountingUnit;
                txtCount.Text = storeOrderDetail.ODCount.ToString();

                var commodity = Business.GetGoodiesBusiness().GetByName(txtCommodity.Text);
                var company = Business.GetComBusiness().GetByName(txtCompany.Text.Trim());
                cmbUnitCount.SelectedValue = Business.GetGoodiesBusiness().SetPrice(cmbUnitCount.SelectedValue.ToGUID(), commodity, company);
                txtComment.Text = storeOrderDetail.ODDescription;


            }
            catch
            {

                throw;
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
                cmbBaseChanged();
            }
            catch
            {

                throw;
            }
        }

        private void txtCommodity_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                var commodity = Business.GetGoodiesBusiness().GetByName(txtCommodity.Text);
                if (commodity == null)
                    return;

                SetUnitCountComboBox(commodity.ID);

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
                var frmPurchaseInvoiceManagement = new Bills.PurchaseInvoice.FrmPurchaseInvoiceManagement();
                frmPurchaseInvoiceManagement.ShowDialog();

                var storeOrderDetailBusiness = Business.GetStoreOrderDetailBusiness();


                if (frmPurchaseInvoiceManagement.StoreOrderId.HasValue)
                {
                    var baseStoreOrderId = frmPurchaseInvoiceManagement.StoreOrderId.Value;
                    var baseStoreOrder = Business.GetStoreOrderBusiness().GetById(baseStoreOrderId);
                    txtBase.Text = Business.GetStoreOrderBusiness().GetById(baseStoreOrderId).OId;

                    var company = Business.GetComBusiness().GetById(baseStoreOrder.IdCompany.Value);
                    txtCompany.Text = company.CName;


                    using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
                    {
                        IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted,
                        Timeout = new TimeSpan(2, 0, 0)
                    }))
                    {
                        if (StoreOrderId == Guid.Empty)
                            this.StoreOrderId = RegisterStoreOrder(company).Id;
                        else
                            storeOrderDetailBusiness.DeleteByStoreOrderId(StoreOrderId);
                        var storeOrderDetails = storeOrderDetailBusiness.GetByStoreOrderId(baseStoreOrderId).ToList();

                        var returnOfSaleDetails = new List<Data.StoreOrderDetail>();
                        foreach (var item in storeOrderDetails)
                        {
                            var newItem = storeOrderDetailBusiness.Clone(item);
                            newItem.IdStoreOrder = StoreOrderId;
                            newItem.IdStoreS = Guid.Empty;
                            returnOfSaleDetails.Add(newItem);
                        }
                        storeOrderDetailBusiness.Insert(returnOfSaleDetails);


                        scope.Complete();
                    }
                }

                SetDataGrid();

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

        private void txtBase_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
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
                if (FormMode == Common.Enum.FormMode.New && !IsRegistered.ToBoolean())
                    Business.GetStoreOrderBusiness().PhysicalDeleting(StoreOrderId);
            }
            catch
            {

                throw;
            }
        }

        private void btnSelectCommodity_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var frmShow = new Goodies.FrmShow();
                frmShow.ShowDialog();

                var goodyId = frmShow.Result;
                Data.Goody goody = null;
                if (goodyId != Guid.Empty)
                {
                    goody = Business.GetGoodiesBusiness().GetById(goodyId);
                    txtCommodity.Text = goody.CName;
                }
                else
                    txtCommodity.Text = string.Empty;


                SetUnitCountComboBox(goodyId);
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void MenuItem_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                if (DataGrid.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);

                var id = (DataGrid.SelectedValue as dynamic).Id;

                Business.GetStoreOrderBusiness().Delete(Business.GetStoreOrderBusiness().GetById(id));

                SetDataGrid();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void txtCount_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }

        private void txtCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            c.SepratTextBox(sender, e);
        }

    }
}
