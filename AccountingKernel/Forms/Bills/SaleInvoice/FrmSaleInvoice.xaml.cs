﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Common;
using System.Transactions;
using System.Windows.Data;
using System.Collections;
using Data;

namespace AccountingKernel.Forms.Bills.SaleInvoice
{
    /// <summary>
    /// Interaction logic for Document.xaml
    /// </summary>
    public partial class FrmSaleInvoice : Window
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

        public Guid StoreOperationId;

        public FrmSaleInvoice()
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

        public FrmSaleInvoice(Common.Enum.FormMode formMode, Guid? storeOrderId, Guid storeOperationId)
        {
            try
            {
                this.StoreOperationId = storeOperationId;
                this.FormMode = formMode;
                NormalConstructor();


                if (!storeOrderId.HasValue)
                    return;

                this.StoreOrderId = storeOrderId.Value;

                var storeOrder = Business.GetStoreOrderBusiness().GetById(StoreOrderId);
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
                var commodoties = Business.GetGoodiesBusiness().GetAll();
                var t = Business.GetStoreOrderDetailBusiness().GetByStoreOrderId(this.StoreOrderId).Join(
                    commodoties, o => o.IdCommodity, i => i.ID, (o, i) => new { o, i }).ToList();

                var operatives = Business.GetStoreOperativeBusiness().GetByStoreOrderId(this.StoreOrderId).GroupBy(r => r.IdStoreDetail).Select(r => new
                {
                    DetailId = r.Key,
                    Sum = r.Sum(m => m.SPrice)
                }).ToList();



                DataGrid.ItemsSource = t.Select(r => new
                {
                    Id = r.o.Id,
                    DiscountPrice = r.o.ODDiscount,
                    Unit = units.Find(u => u.Id == r.o.ODCountingUnit).AssignName,
                    Count = r.o.ODCount,
                    CommodityName = r.i.CName,
                    CommodityCode = r.i.CID1,
                    UnitPrice = (r.o.ODMoney / r.o.ODCount).ToString(Localize.DoubleMaskType),
                    PriceSum = r.o.ODMoney.ToString(Localize.DoubleMaskType),
                    EffectiveSum = operatives.FirstOrDefault(m => m.DetailId == r.o.Id) == null ? "0" :
                                        operatives.First(m => m.DetailId == r.o.Id).Sum.ToString(Localize.DoubleMaskType),
                    TotalPrice = ((r.o.ODMoney + (operatives.FirstOrDefault(m => m.DetailId == r.o.Id) == null ? 0 :
                                            operatives.Find(m => m.DetailId == r.o.Id).Sum)).ToString(Localize.DoubleMaskType))

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
                Data.Goody goody = null;
                if (goodyId == Guid.Empty)
                {
                    txtCommodityCode.Text = string.Empty;
                    return;
                }
                goody = Business.GetGoodiesBusiness().GetById(goodyId);
                txtCommodityCode.Text = goody.CName;


                SetUnitCountComboBox(goodyId);
                var company = Business.GetComBusiness().GetByName(txtCompany.Text.Trim());

                txtUnitPrice.Text = Business.GetGoodiesBusiness().SetPrice(cmbUnitCount.SelectedValue.ToGUID(), goody, company).ToString(Localize.DoubleMaskType);
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

                storeOrderDetail.IdStoreOrder = storeOrder.Id;
                storeOrderDetail.IdCommodity = commodity.ID;
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
                var storeOrder = Business.GetStoreOrderBusiness().GetById(StoreOrderId);

                if (storeOrder == null)
                    storeOrder = new StoreOrder();

                var company = Business.GetComBusiness().GetByName(txtCompany.Text);
                if (company == null)
                    //رخداد خطا
                    throw new Exception(Localize.ex_company_not_found);

                storeOrder.OId = storeOrder.OId.IsNullOrEmpty() ? Business.GetStoreOrderBusiness().GetLastEditedOId(this.StoreOperationId) : storeOrder.OId;
                storeOrder.ODate = dtpIssueDate.Text;
                storeOrder.IdCompany = company.Id;
                storeOrder.OReverse = false;
                storeOrder.ODelete = false;
                storeOrder.IdStoreOperation = this.StoreOperationId;
                Business.GetStoreOrderBusiness().Save(storeOrder);

                StoreOrderId = storeOrder.Id;
                return storeOrder;

            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// finds storeorder by oid, odate and company
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtHeaders_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                //StoreOrderId = Guid.Empty;

                if (dtpIssueDate.Text == string.Empty || txtCompany.Text.Trim() == string.Empty)
                    return;

                var company = Business.GetComBusiness().GetByName(txtCompany.Text);
                if (company != null)
                {
                    var storeOrder = Business.GetStoreOrderBusiness().GetAll().Where(r => r.OId == txtBillNum.Text && r.ODate == dtpIssueDate.Text && r.IdCompany == company.Id).FirstOrDefault();
                    if (storeOrder != null)
                    {
                        StoreOrderId = storeOrder.Id;
                        txtTotalDiscount.Text = storeOrder.ODiscount.HasValue ? storeOrder.ODiscount.ToString() : string.Empty;
                        txtTotalPrice.Text = storeOrder.OSumMoney.HasValue ? storeOrder.OSumMoney.ToString() : string.Empty;
                        txtTotalTax.Text = storeOrder.OTax.HasValue ? storeOrder.OTax.ToString() : string.Empty;
                        txtTotalMunicipalTax.Text = storeOrder.OMunicipalTax.HasValue ? storeOrder.OMunicipalTax.ToString() : string.Empty;
                        txtStoreDescription.Text = storeOrder.ODescription;
                    }
                }

                this.SetDataGrid();
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
                var commodityDetail = Business.GetGoodiesBusiness().GetById(storeOrderDetail.IdCommodity);

                SetUnitCountComboBox(storeOrderDetail.IdCommodity);

                txtCommodityCode.Text = commodityDetail.CName;
                cmbUnitCount.SelectedValue = storeOrderDetail.ODCountingUnit;
                txtCount.Text = storeOrderDetail.ODCount.ToString();

                var commodity = Business.GetGoodiesBusiness().GetByName(txtCommodityCode.Text);
                var company = Business.GetComBusiness().GetByName(txtCompany.Text.Trim());
                if (FormMode == Common.Enum.FormMode.New)
                    txtUnitPrice.Text = Business.GetGoodiesBusiness().SetPrice(cmbUnitCount.SelectedValue.ToGUID(), commodity, company).ToString(Localize.DoubleMaskType);
                else
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

                txtBillNum.Text = storeOrder.OId;

                SetFooter(storeOrder, storeOrderDetails);

                SetDataGrid();

                this.StoreOrderId = storeOrder.Id;
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
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
                var storeOrderDetails = Business.GetStoreOrderDetailBusiness().GetByStoreOrderId(this.StoreOrderId).ToList();

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
                var effectiveSum = Business.GetStoreOperativeBusiness().GetByStoreOrderId(this.StoreOrderId).ToList().Sum(r => r.SPrice.ToDecimal());

                txtTotalFactorPrice.Text = storeOrder.OSumMoney.ToString(Localize.DoubleMaskType);
                txtEffectiveSum.Text = effectiveSum.ToString(Localize.DoubleMaskType);

                txtTotalMunicipalTax.Text = sumDetails == 0 ? "0" : (storeOrder.OMunicipalTax.ToDecimal() * (decimal)100 / sumDetails).ToString(Localize.DoubleMaskType);
                txtTotalTax.Text = sumDetails == 0 ? "0" : (storeOrder.OTax.ToDecimal() * (decimal)100 / sumDetails).ToString(Localize.DoubleMaskType);
                txtTotalDiscount.Text = storeOrder.ODiscount.ToString(Localize.DoubleMaskType);
                txtTotalPrice.Text = (sumDetails + effectiveSum - storeOrder.ODiscount).ToString(Localize.DoubleMaskType);
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

                using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
                {
                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted,
                    Timeout = new TimeSpan(2, 0, 0)
                }))
                {
                    var storeOrder = RegisterStoreOrder();
                    this.StoreOrderId = storeOrder.Id;


                    Business.GetAccountingDocumentBusiness().SaveAutomaticDocumentForSaleInvoice(storeOrder);

                    scope.Complete();
                }

                IsRegistered = true;
                this.Close();
            }
            catch
            {

                throw;
            }
        }

        private void MenuItem_EffectiveOperative(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                if (DataGrid.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);

                var storeOrderDetail = Business.GetStoreOrderDetailBusiness().GetById((DataGrid.SelectedValue as dynamic).Id);

                var frmBillOperative = new Bills.PreSaleInvoice.FrmBillOperative(storeOrderDetail.IdStoreOrder, storeOrderDetail.Id, true);
                frmBillOperative.Title = Localize.StoreDetailEffectiveOperative;
                frmBillOperative.ShowDialog();
                SetDataGrid();

            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }

        }

        private void MenuItem_InEffectiveOperative(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                if (DataGrid.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);

                var storeOrderDetail = Business.GetStoreOrderDetailBusiness().GetById((DataGrid.SelectedValue as dynamic).Id);

                var frmBillOperative = new Bills.PreSaleInvoice.FrmBillOperative(storeOrderDetail.IdStoreOrder, storeOrderDetail.Id, false);
                frmBillOperative.Title = Localize.StoreDetailInEffectiveOperative;
                frmBillOperative.ShowDialog();
                SetDataGrid();

            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }

        }

        private void NormalConstructor()
        {
            try
            {
                InitializeComponent();

                var saleFactorCodeTitle = Business.GetCodeTitleBusiness().GetById(Common.Constants.CodeTitle.SaleFactor);
                txtBillNum.MaxLength = saleFactorCodeTitle.CodeLen.ToInt();


                txtCompany.ClearItems();
                Business.GetComBusiness().GetByCType(Common.Constants.CustomerType.Seller).ToList().ForEach(r =>
                    txtCompany.AddItem(new WPFAutoCompleteTextbox.AutoCompleteEntry(r.CName, r.CName)));

                cmbBase.ItemsSource = Business.GetBaseInfoBusiness().GetByType(Common.Constants.BaseInfoType.SaleInvoiceBase);
                chbBase_Checked();

                txtBillNum.Text = Business.GetStoreOrderBusiness().GetLastEditedOId(this.StoreOperationId);

                setTaxDefault();
            }
            catch
            {

                throw;
            }
        }

        private void cmbUnitCount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var commodity = Business.GetGoodiesBusiness().GetByName(txtCommodityCode.Text);
                var company = Business.GetComBusiness().GetByName(txtCompany.Text.Trim());
                if (cmbUnitCount.SelectedValue != null)
                    txtUnitPrice.Text = Business.GetGoodiesBusiness().SetPrice(cmbUnitCount.SelectedValue.ToGUID(), commodity, company).ToString(Localize.DoubleMaskType);
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
                Guid? baseStoreOrderId = null;

                if (cmbBase.SelectedValue.ToGUID() == Common.Constants.SaleInvoiceBase.PreInvoice)
                {
                    var frmPurchaseInvoiceManagement = new Bills.PurchaseInvoice.FrmPurchaseInvoiceManagement();
                    frmPurchaseInvoiceManagement.ShowDialog();

                    if (frmPurchaseInvoiceManagement.StoreOrderId.HasValue)
                        baseStoreOrderId = frmPurchaseInvoiceManagement.StoreOrderId.Value;
                }
                else if (cmbBase.SelectedValue.ToGUID() == Common.Constants.SaleInvoiceBase.WareHouseReceipt)
                {
                    var frmReceiptManagment = new Bills.WarehouseReceipts.FrmReceiptManagment();
                    frmReceiptManagment.ShowDialog();

                    if (frmReceiptManagment.StoreOrderId.HasValue)
                        baseStoreOrderId = frmReceiptManagment.StoreOrderId.Value;
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
                            this.StoreOrderId = RegisterStoreOrder(company).Id;
                        else
                            storeOrderDetailBusiness.DeleteByStoreOrderId(StoreOrderId);
                        var storeOrderDetails = storeOrderDetailBusiness.GetByStoreOrderId(baseStoreOrderId.Value).ToList();

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

        private void txtUnitPrice_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {

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

        private void txtUnitPrice_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
            c.AddZero(sender, e);
        }

        private void txtBillNum_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }

        private void txtBillNum_TextChanged(object sender, TextChangedEventArgs e)
        {
            c.SepratTextBox(sender, e);
        }

        private void txtUnitPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            c.SepratTextBox(sender, e);
        }

        private void txtTotalFactorPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            c.SepratTextBox(sender, e);
        }

        private void txtEffectiveSum_TextChanged(object sender, TextChangedEventArgs e)
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

        private void txtTotalMunicipalTax_TextChanged(object sender, TextChangedEventArgs e)
        {
            c.SepratTextBox(sender, e);
        }

        private void txtTotalTax_TextChanged(object sender, TextChangedEventArgs e)
        {
            c.SepratTextBox(sender, e);
        }

        private void txtTotalDiscount_TextChanged(object sender, TextChangedEventArgs e)
        {
            c.SepratTextBox(sender, e);
        }

        private void txtTotalPrice_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }

        private void txtTotalFactorPrice_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }

        private void txtEffectiveSum_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }

        private void btnSelectCompany_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var frmCompanies = new AccountingKernel.Forms.Company.frmCompanies(Common.Constants.CustomerType.Seller);
                frmCompanies.ShowDialog();
                var companyId = frmCompanies.Result;
                if (companyId != Guid.Empty)
                    txtCompany.Text = Business.GetComBusiness().GetById(companyId).CName;
                else
                    txtCompany.Text = string.Empty;

            }
            catch
            {

                throw;
            }
        }

        private void txtDicountPrice_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }

        private void txtCount_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }

    }
}