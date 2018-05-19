using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using AccountingKernel.Common;
using System.Transactions;
using System.Windows.Data;
using System.Collections;

namespace AccountingKernel.Forms.Bill
{
    /// <summary>
    /// Interaction logic for Document.xaml
    /// </summary>
    public partial class frmPreInvoice : Window
    {

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

        public Constants.StoreOperation StoreOperation;

        public frmPreInvoice()
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

        public frmPreInvoice(Guid storeOrderId, Constants.StoreOperation storeOperation)
        {
            try
            {
                this.StoreOrderId = storeOrderId;
                this.StoreOperation = storeOperation;

                NormalConstructor();

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
                    txtCompany.Text = Business.GetCompanyBusiness().GetById(storeOrder.IdCompany.Value).CName;
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
                var commodoties = Business.GetCommodityBusiness().GetAll();
                var t = Business.GetStoreOrderDetailBusiness().GetByStoreOrderId(this.StoreOrderId).Join(
                    commodoties, o => o.IdCommodity, i => i.ID, (o, i) => new
                    {
                        Id = o.Id,
                        DiscountPrice = o.ODDiscount,
                        UnitPrice = o.ODMoney / o.ODCount,
                        Count = o.ODCount,
                        CommodityName = i.CName,
                        CommodityCode = i.CID1
                    }).ToList();
                DataGrid.ItemsSource = t;

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
                var showCommodityFrom = new Goods.frmShowCommodity();
                showCommodityFrom.ShowDialog();

                var commodityId = showCommodityFrom.Result;
                if (commodityId != Guid.Empty)
                    txtCommodityCode.Text = Business.GetCommodityBusiness().GetById(commodityId).CName;
                else
                    txtCommodityCode.Text = string.Empty;


                SetUnitCountComboBox();

                txtUnitPrice.Text = SetPrice().ToString();
            }
            catch
            {

                throw;
            }
        }

        private void SetUnitCountComboBox()
        {
            try
            {
                cmbUnitCount.ItemsSource = Business.GetBaseInfoBusiness().GetByType(Constants.BaseInfoType.Units);
            }
            catch
            {

                throw;
            }
        }

        private decimal SetPrice()
        {
            try
            {
                var commodity = Business.GetCommodityBusiness().GetByName(txtCommodityCode.Text.Trim());
                var company = Business.GetCompanyBusiness().GetByName(txtCompany.Text.Trim());
                if (commodity == null || !company.CType.HasValue || company == null)
                    return 0;

                var priceList = Business.GetPriceListBusiness().GetByCommodityIdCompanyTypeId(company.CType.Value, commodity.ID);
                if (priceList != null && priceList.PLPrice.HasValue)
                    return priceList.PLPrice.ToDecimal();
                return 0;
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
                var commodity = Business.GetCommodityBusiness().GetByName(txtCommodityCode.Text);
                if (commodity == null)
                    throw new Exception(Localize.ex_commodity_not_found);
                var storeOrderDetailBusiness = Business.GetStoreOrderDetailBusiness();

                var storeOrderDetail = Business.GetStoreOrderDetailBusiness().GetByCommodity(commodity.ID, cmbUnitCount.SelectedValue.ToGUID());
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
                else if (storeOrder.IdStoreOperation == Constants.StoreOperation.PreInvoice.ToInt()
                    && StoreOperation == Constants.StoreOperation.SaleInvoice)
                    storeOrder = SaveForSaleInvoice(storeOrder);

                var company = Business.GetCompanyBusiness().GetByName(txtCompany.Text);
                if (company == null)
                    //رخداد خطا
                    throw new Exception(Localize.ex_company_not_found);

                storeOrder.OId = txtBillNum.Text == string.Empty ? (Business.GetStoreOrderBusiness().GetMaxOId() + 1).ToString() : txtBillNum.Text;
                storeOrder.ODate = dtpIssueDate.Text;
                storeOrder.IdCompany = company.Id;
                storeOrder.OReverse = false;
                storeOrder.ODelete = false;
                storeOrder.IdStoreOperation = this.StoreOperation.ToInt();
                Business.GetStoreOrderBusiness().Save(storeOrder);

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
                saleStoreOrder.IdStoreOperation = Constants.StoreOperation.SaleInvoice.ToInt();
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

                var company = Business.GetCompanyBusiness().GetByName(txtCompany.Text);
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
                var commodityDetail = Business.GetCommodityDetailBusiness().GetByCodeTitle(storeOrderDetail.IdCommodity, Constants.CodeTitle.CommodityTitle);

                SetUnitCountComboBox();

                txtCommodityCode.Text = commodityDetail.CDName;
                cmbUnitCount.SelectedValue = storeOrderDetail.ODCountingUnit;
                txtCount.Text = storeOrderDetail.ODCount.ToString();
                txtUnitPrice.Text = SetPrice().ToString();
                txtDicountPrice.Text = storeOrderDetail.ODDiscount.ToString();
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
                    storeOrderDetails.Sum(r => r.ODDiscount) * sumDetails / (decimal)100 - txtDicountPrice.Text.ToDecimal();
                storeOrder.ODiscount = txtTotalDiscount.Text.ToDecimal();

                Business.GetStoreOrderBusiness().Save(storeOrder);

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

                txtTotalMunicipalTax.Text = sumDetails == 0 ? "0" : (storeOrder.OMunicipalTax.ToDecimal() * (decimal)100 / sumDetails).ToString();
                txtTotalTax.Text = sumDetails == 0 ? "0" : (storeOrder.OTax.ToDecimal() * (decimal)100 / sumDetails).ToString();
                txtTotalDiscount.Text = storeOrder.ODiscount.ToDecimal().ToString();
                txtTotalPrice.Text = storeOrder.OSumMoney.ToDecimal().ToString();
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
                    this.StoreOrderId = RegisterStoreOrder().Id;


                    scope.Complete();
                }

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

                var frmBillOperative = new Bill.frmBillOperative(storeOrderDetail.IdStoreOrder, storeOrderDetail.Id, true);
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

                var frmBillOperative = new Bill.frmBillOperative(storeOrderDetail.IdStoreOrder, storeOrderDetail.Id, false);
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
                Business.GetCompanyBusiness().GetAll().ToList().ForEach(r =>
                    txtCompany.AddItem(new WPFAutoCompleteTextbox.AutoCompleteEntry(r.CName, r.CName)));

                switch ((Constants.StoreOperation)StoreOperation)
                {
                    case Constants.StoreOperation.BuyingRequest:
                        break;
                    case Constants.StoreOperation.PurchaseInvoice:
                        break;
                    case Constants.StoreOperation.ReturnOfBuying:
                        break;
                    case Constants.StoreOperation.PreInvoice:
                        lblHeader.Content = Localize.RegisterPreInvoice;
                        break;
                    case Constants.StoreOperation.SaleInvoice:
                        lblHeader.Content = Localize.RegisterSaleInvoice;
                        break;
                    case Constants.StoreOperation.ReturnOfSale:
                        break;
                    case Constants.StoreOperation.WarehouseReceipts:
                        break;
                    case Constants.StoreOperation.Order:
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

    }
}
