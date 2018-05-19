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

namespace AccountingKernel.Forms.Bills.Order
{
    /// <summary>
    /// Interaction logic for Document.xaml
    /// </summary>
    public partial class FrmOrder : Window
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

        public FrmOrder()
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

        public FrmOrder(Common.Enum.FormMode formMode, Guid storeOpertion, Guid? storeOrderId)
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
                    DiscountPrice = r.o.ODDiscount.ToString(Localize.DoubleMaskType),
                    UnitPrice = ((double)(r.o.ODMoney / r.o.ODCount)).ToString(Localize.DoubleMaskType),
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

        private void SetUnitCountComboBox(Guid goodyId)
        {
            try
            {
                var commodityConvertCountingUnits = Business.GetGoodyConvertCountingUnitBusiness().GetByGoodyId(goodyId).ToList();
                var unitIds = commodityConvertCountingUnits.Where(r => r.CCCUIDBaseInfo1.HasValue).Select(r => r.CCCUIDBaseInfo1.Value).
                    Union(commodityConvertCountingUnits.Where(r => r.CCCUIDBaseInfo2.HasValue).Select(r => r.CCCUIDBaseInfo2.Value)).ToList();
                cmbUnitCount.ItemsSource = Business.GetBaseInfoBusiness().GetByIds(unitIds).ToList();
                cmbUnitCount.SelectedValue = Business.GetGoodiesBusiness().GetById(goodyId).CBaseCountingUnit;
            }
            catch
            {

                throw;
            }
        }

        ///// <summary>
        ///// register store order detail
        ///// </summary>
        //private StoreOrderDetail RegisterStoreDetail(StoreOrder storeOrder)
        //{
        //    try
        //    {
        //        //var commodity = Business.GetCommodityBusiness().GetByName(txtCommodityCode.Text);
        //        //if (commodity == null)
        //        //    throw new Exception(Localize.ex_commodity_not_found);
        //        //var storeOrderDetailBusiness = Business.GetStoreOrderDetailBusiness();

        //        //var storeOrderDetail = Business.GetStoreOrderDetailBusiness().GetByCommodity(commodity.ID, cmbUnitCount.SelectedValue.ToGUID());
        //        //if (storeOrderDetail == null)
        //        //    storeOrderDetail = new StoreOrderDetail();

        //        //storeOrderDetail.IdStoreOrder = storeOrder.Id;
        //        //storeOrderDetail.IdCommodity = commodity.ID;
        //        //storeOrderDetail.ODCountingUnit = cmbUnitCount.SelectedValue.ToGUID();
        //        //storeOrderDetail.ODCount = storeOrderDetail.ORemained = txtCount.Text.ToInt();
        //        //storeOrderDetail.ODMoney = txtUnitPrice.Text.ToDecimal() * txtCount.Text.ToInt();
        //        //storeOrderDetail.ODDiscount = txtDicountPrice.Text.ToDecimal();
        //        //storeOrderDetail.ODDescription = txtBillDescription.Text;

        //        //Business.GetStoreOrderDetailBusiness().Save(storeOrderDetail);

        //        //return storeOrderDetail;
        //    }
        //    catch
        //    {

        //        throw;
        //    }
        //}

        ///// <summary>
        ///// regitser store order
        ///// </summary>
        //public StoreOrder RegisterStoreOrder()
        //{
        //    try
        //    {
        //        var storeOrder = Business.GetStoreOrderBusiness().GetById(StoreOrderId);

        //        if (storeOrder == null)
        //            storeOrder = new StoreOrder();
        //        else if (storeOrder.IdStoreOperation == Constants.StoreOperation.PreInvoice
        //            && StoreOperationId == Constants.StoreOperation.SaleInvoice)
        //            storeOrder = SaveForSaleInvoice(storeOrder);

        //        var company = Business.GetCompanyBusiness().GetByName(txtCompany.Text);
        //        if (company == null)
        //            //رخداد خطا
        //            throw new Exception(Localize.ex_company_not_found);

        //        storeOrder.OId = txtBillNum.Text == string.Empty ? (Business.GetStoreOrderBusiness().GetMaxOId() + 1).ToString() : txtBillNum.Text;
        //        storeOrder.ODate = dtpIssueDate.Text;
        //        storeOrder.IdCompany = company.Id;
        //        storeOrder.OReverse = false;
        //        storeOrder.ODelete = false;
        //        storeOrder.IdStoreOperation = this.StoreOperationId;
        //        Business.GetStoreOrderBusiness().Save(storeOrder);

        //        return storeOrder;

        //    }
        //    catch
        //    {

        //        throw;
        //    }
        //}

        //private StoreOrder SaveForSaleInvoice(StoreOrder storeOrder)
        //{
        //    try
        //    {
        //        var storeDetailsBusiness = Business.GetStoreOrderDetailBusiness();
        //        var storeOrderBusiness = Business.GetStoreOrderBusiness();

        //        var storeDetails = storeDetailsBusiness.GetByStoreOrderId(storeOrder.Id);
        //        var saleStoreOrder = storeOrderBusiness.Clone(storeOrder);
        //        saleStoreOrder.IdStoreOperation = Constants.StoreOperation.SaleInvoice;
        //        storeOrderBusiness.Save(saleStoreOrder);

        //        foreach (var item in storeDetails)
        //        {
        //            var saleStoreDetail = new StoreOrderDetail();
        //            saleStoreDetail = storeDetailsBusiness.Clone(item);
        //            saleStoreDetail.IdStoreOrder = saleStoreDetail.Id;
        //            storeDetailsBusiness.Save(saleStoreDetail);
        //        }

        //        return saleStoreOrder;

        //    }
        //    catch
        //    {

        //        throw;
        //    }
        //}

        ///// <summary>
        ///// finds storeorder by oid, odate and company
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void txtHeaders_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    try
        //    {
        //        //StoreOrderId = Guid.Empty;

        //        if (dtpIssueDate.Text == string.Empty || txtCompany.Text.Trim() == string.Empty)
        //            return;

        //        var company = Business.GetCompanyBusiness().GetByName(txtCompany.Text);
        //        if (company != null)
        //        {
        //            var storeOrder = Business.GetStoreOrderBusiness().GetAll().Where(r => r.OId == txtBillNum.Text && r.ODate == dtpIssueDate.Text && r.IdCompany == company.Id).FirstOrDefault();
        //            if (storeOrder != null)
        //            {
        //                StoreOrderId = storeOrder.Id;
        //                txtTotalDiscount.Text = storeOrder.ODiscount.HasValue ? storeOrder.ODiscount.ToString() : string.Empty;
        //                txtTotalPrice.Text = storeOrder.OSumMoney.HasValue ? storeOrder.OSumMoney.ToString() : string.Empty;
        //                txtTotalTax.Text = storeOrder.OTax.HasValue ? storeOrder.OTax.ToString() : string.Empty;
        //                txtTotalMunicipalTax.Text = storeOrder.OMunicipalTax.HasValue ? storeOrder.OMunicipalTax.ToString() : string.Empty;
        //                txtStoreDescription.Text = storeOrder.ODescription;
        //            }
        //        }

        //        this.SetDataGrid();
        //    }
        //    catch
        //    {

        //        throw;
        //    }
        //}

        ///// <summary>
        ///// store detail order selected cell changed
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void DataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        //{
        //    try
        //    {
        //        Guid id = (DataGrid.SelectedValue as dynamic).Id;
        //        var storeOrderDetail = Business.GetStoreOrderDetailBusiness().GetById(id);
        //        var commodityDetail = Business.GetCommodityDetailBusiness().GetByCodeTitle(storeOrderDetail.IdCommodity, Constants.CodeTitle.CommodityTitle);

        //        SetUnitCountComboBox(storeOrderDetail.IdCommodity);

        //        txtCommodityCode.Text = commodityDetail.CDName;
        //        cmbUnitCount.SelectedValue = storeOrderDetail.ODCountingUnit;
        //        txtCount.Text = storeOrderDetail.ODCount.ToString();

        //        var commodity = Business.GetCommodityBusiness().GetByName(txtCommodityCode.Text);
        //        var company = Business.GetCompanyBusiness().GetByName(txtCompany.Text.Trim());
        //        txtUnitPrice.Text = Business.GetCommodityBusiness().SetPrice(cmbUnitCount.SelectedValue.ToGUID(), commodity, company).ToString();
        //        txtDicountPrice.Text = storeOrderDetail.ODDiscount.ToString(Localize.DoubleMaskType);
        //        txtBillDescription.Text = storeOrderDetail.ODDescription;


        //    }
        //    catch
        //    {

        //        throw;
        //    }
        //}

        //private void btnRegisterCommodity_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        var storeOrder = new StoreOrder();

        //        var storeOrderDetails = new List<StoreOrderDetail>();

        //        using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
        //        {
        //            IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted,
        //            Timeout = new TimeSpan(2, 0, 0)
        //        }))
        //        {
        //            storeOrder = RegisterStoreOrder();

        //            RegisterStoreDetail(storeOrder);

        //            storeOrderDetails = Business.GetStoreOrderDetailBusiness().GetByStoreOrderId(storeOrder.Id).ToList();

        //            SetTotalInformations(storeOrder, storeOrderDetails);

        //            scope.Complete();
        //        }

        //        SetFooter(storeOrder, storeOrderDetails);

        //        SetDataGrid();

        //        this.StoreOrderId = storeOrder.Id;
        //    }
        //    catch (Exception ex)
        //    {
        //        AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
        //    }
        //}

        //private void SetTotalInformations(StoreOrder storeOrder, List<StoreOrderDetail> storeOrderDetails)
        //{
        //    try
        //    {
        //        var sumDetails = storeOrderDetails.Sum(r => r.ODMoney);
        //        storeOrder.OMunicipalTax = sumDetails * txtTotalMunicipalTax.Text.ToDecimal() / (decimal)100;
        //        storeOrder.OTax = sumDetails * txtTotalTax.Text.ToDecimal() / (decimal)100;

        //        storeOrder.OSumMoney = sumDetails + storeOrder.OMunicipalTax + storeOrder.OTax -
        //            storeOrderDetails.Sum(r => r.ODDiscount) * sumDetails / (decimal)100 - txtDicountPrice.Text.ToDecimal();
        //        storeOrder.ODiscount = txtTotalDiscount.Text.ToDecimal();

        //        Business.GetStoreOrderBusiness().Save(storeOrder);

        //    }
        //    catch
        //    {

        //        throw;
        //    }
        //}

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
                if (company == null && StoreOperationId == Common.Constants.StoreOperation.Order)
                    //رخداد خطا
                    throw new Exception(Localize.ex_company_not_found);

                var commodity = Business.GetGoodiesBusiness().GetByName(txtCommodity.Text);
                if (commodity == null)
                    throw new Exception(Localize.ex_no_commodity_seletced);

                var repository = Business.GetBaseInfoBusiness().GetByAssginName(txtRepository.Text, Common.Constants.BaseInfoType.Repository);
                if (repository == null)
                    throw new Exception(Localize.ex_no_repository_selected);

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
                    this.StoreOrderId = storeOrder.Id;

                    SetStores(storeOrder, repository, commodity, company, priceList);

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

        private void NormalConstructor()
        {
            try
            {
                InitializeComponent();

                txtRepository.ClearItems();
                Business.GetBaseInfoBusiness().GetByType(Common.Constants.BaseInfoType.Repository).ToList().ForEach(r =>
                    txtRepository.AddItem(new WPFAutoCompleteTextbox.AutoCompleteEntry(r.AssignName, r.AssignName)));

                txtCompany.ClearItems();
                Business.GetComBusiness().GetByCType(Common.Constants.CustomerType.Buyer).ToList().ForEach(r =>
                    txtCompany.AddItem(new WPFAutoCompleteTextbox.AutoCompleteEntry(r.CName, r.CName)));

                txtCommodity.ClearItems();
                Business.GetGoodiesBusiness().GetAll().ToList().ForEach(r =>
                {
                    txtCommodity.AddItem(new WPFAutoCompleteTextbox.AutoCompleteEntry(r.CName, r.CName));
                        txtCommodity.AddItem(new WPFAutoCompleteTextbox.AutoCompleteEntry(r.CID1, r.CID1));
                });

                cmbOrderType.ItemsSource = Business.GetBaseInfoBusiness().GetByType(Common.Constants.BaseInfoType.OrderType);
                cmbBase.ItemsSource = Business.GetBaseInfoBusiness().GetByType(Common.Constants.BaseInfoType.OrderBase);

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
                var repository = Business.GetBaseInfoBusiness().GetByAssginName(txtRepository.Text, Common.Constants.BaseInfoType.Repository);
                if (repository == null)
                    throw new Exception(Localize.ex_no_stroes_selected);

                var commodity = Business.GetGoodiesBusiness().GetByName(txtCommodity.Text);
                if (commodity == null)
                    throw new Exception(Localize.ex_no_commodity_seletced);

                if (cmbUnitCount.SelectedIndex < 0)
                    throw new Exception(Localize.ex_no_unitcount_seletced);

                if (StoreOperationId == Guid.Empty)
                    throw new Exception(Localize.ex_invalid_data);

                var company = Business.GetComBusiness().GetByName(txtCompany.Text);
                if (company == null && StoreOperationId == Common.Constants.StoreOperation.Order)
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
                if (StoreOperationId == Common.Constants.StoreOperation.WarehouseReceipts)
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

        private void DataGrid_SelectedCellsChanged_1(object sender, SelectedCellsChangedEventArgs e)
        {

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
                txtCommodity.IsEnabled = !chbBase.IsChecked.ToBoolean();
                cmbUnitCount.IsEnabled = !chbBase.IsChecked.ToBoolean();
                txtCount.IsEnabled = !chbBase.IsChecked.ToBoolean();
                btnSelectBase.IsEnabled = chbBase.IsChecked.ToBoolean();
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
                Guid? baseStoreOrderId = null;
                if (cmbBase.SelectedValue.ToGUID() == Common.Constants.OrderBase.SaleFactor)
                {
                    var frmOrderManagment = new FrmOrderManagment();
                    frmOrderManagment.ShowDialog();
                    if (frmOrderManagment.StoreOrderId.HasValue)
                        baseStoreOrderId = frmOrderManagment.StoreOrderId.Value;
                }
                else if (cmbBase.SelectedValue.ToGUID() == Common.Constants.OrderBase.ReturnOfBuyingFactor)
                {
                    var frmReturnOfBuyingManagment = new Bills.ReturnOfBuying.FrmReturnOfBuyingManagment();
                    frmReturnOfBuyingManagment.ShowDialog();
                    if (frmReturnOfBuyingManagment.StoreOrderId.HasValue)
                        baseStoreOrderId = frmReturnOfBuyingManagment.StoreOrderId.Value;
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
                txtBase.IsEnabled = true;
                if (cmbBase.SelectedValue.ToGUID() == Common.Constants.OrderBase.ReturnOfBuyingFactor)
                {
                    Business.GetStoreOrderBusiness().GetByStoreOperation(Common.Constants.StoreOperation.ReturnOfBuying).Where(r => r.OId != null).
                        Select(r => r.OId).Distinct().ToList().ForEach(r =>
                        txtBase.AddItem(new WPFAutoCompleteTextbox.AutoCompleteEntry(r, r)));
                }
                else if (cmbBase.SelectedValue.ToGUID() == Common.Constants.OrderBase.SaleFactor)
                {
                    Business.GetStoreOrderBusiness().GetByStoreOperation(Common.Constants.StoreOperation.SaleInvoice).ToList().ForEach(r =>
                        txtBase.AddItem(new WPFAutoCompleteTextbox.AutoCompleteEntry(r.OId, r.OId)));
                }
                else
                    txtBase.IsEnabled = false;


            }
            catch
            {

                throw;
            }
        }

        private void SetStores(Data.StoreOrder storeOrder, Data.BaseInfo repository, Data.Goody goody, Data.Com company, Data.PriceList priceList)
        {
            try
            {
                switch (this.FormMode)
                {
                    case Common.Enum.FormMode.New:
                        SetStoresForNew(storeOrder, repository, goody, company, priceList);
                        break;
                    case Common.Enum.FormMode.Edit:
                        SetStoresForEdit(storeOrder, repository, goody, company, priceList);
                        break;
                    default:
                        break;
                }

                if (storeOrder.OId == null)
                {
                    storeOrder.OId = Business.GetStoreOrderBusiness().GetMaxOIdByRepository(repository);
                    Business.GetStoreOrderBusiness().SubmitChanges();
                }
            }
            catch
            {

                throw;
            }
        }

        private void SetStoresForEdit(Data.StoreOrder storeOrder, Data.BaseInfo repository, Data.Goody goody, Data.Com company, Data.PriceList priceList)
        {
            try
            {

                using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
                {
                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted,
                    Timeout = new TimeSpan(2, 0, 0)
                }))
                {
                    var storeDetails = Business.GetStoreOrderDetailBusiness().GetByStoreOrderId(storeOrder.Id).ToList();
                    var currentStores = Business.GetStoreSBusiness().GetByStoreOrderDetailIds(storeDetails.Select(r => r.Id).ToList());
                    var stores = new List<Data.Store>();
                    foreach (var item in storeDetails)
                    {
                        var currentStore = currentStores.Find(r => r.IdStoreOrderDetail == item.Id);
                        var previousStore = Business.GetStoreSBusiness().GetLastForCommodity(item.IdCommodity);
                        var remained = 0;
                        if (previousStore != null)
                            remained = previousStore.SRemained.ToInt();


                        var coef = Business.GetGoodyConvertCountingUnitBusiness().FindCoefficient(item.IdCommodity, goody.CBaseCountingUnit.ToGUID(), item.ODCountingUnit);
                        var store = new Data.Store()
                        {
                            IdStoreOrderDetail = item.Id,
                            RegDate = currentStore == null ? DateTime.Now : currentStore.RegDate,
                            EditDate = DateTime.Now,
                            SCount = item.ODCount,
                            SRemained = remained + currentStore.SCount - (item.ODCount * coef).ToInt(),
                            Sname = repository.Id,
                            IdStoreOperation = Common.Constants.StoreOperation.PurchaseInvoice,
                            IdCommodity = item.IdCommodity
                        };

                        Business.GetStoreSBusiness().Insert(store);
                        item.IdStoreS = store.Id;

                    }

                    Business.GetStoreOrderDetailBusiness().SubmitChanges();

                    Business.GetStoreSBusiness().Delete(currentStores);


                    scope.Complete();
                }
            }
            catch
            {

                throw;
            }
        }

        private void SetStoresForNew(Data.StoreOrder storeOrder, Data.BaseInfo repository, Data.Goody goody, Data.Com company, Data.PriceList priceList)
        {
            try
            {
                var coef = Business.GetGoodyConvertCountingUnitBusiness().FindCoefficient(goody.ID, goody.CBaseCountingUnit.ToGUID(), cmbUnitCount.SelectedValue.ToGUID());

                using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
                {
                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted,
                    Timeout = new TimeSpan(2, 0, 0)
                }))
                {
                    var storeDetails = Business.GetStoreOrderDetailBusiness().GetByStoreOrderId(StoreOrderId).ToList();
                    var stores = new List<Data.Store>();
                    foreach (var item in storeDetails)
                    {
                        var previousStore = Business.GetStoreSBusiness().GetLastForCommodity(item.IdCommodity);
                        var remained = 0;
                        if (previousStore != null)
                            remained = previousStore.SRemained.ToInt();

                        var store = new Data.Store()
                        {
                            IdStoreOrderDetail = item.Id,
                            RegDate = DateTime.Now,
                            SCount = item.ODCount,
                            SRemained = remained - (item.ODCount * coef).ToInt(),
                            Sname = repository.Id,
                            IdStoreOperation = Common.Constants.StoreOperation.Order,
                            IdCommodity = item.IdCommodity
                        };
                        Business.GetStoreSBusiness().Insert(store);

                        item.IdStoreS = store.Id;

                    }

                    Business.GetStoreOrderDetailBusiness().SubmitChanges();

                    scope.Complete();
                }
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

        private void txtRepository_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            c.JustPersian(e);
        }

        private void txtCompany_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            c.JustPersian(e);
        }

        private void txtComment_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            c.JustPersian(e);
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
