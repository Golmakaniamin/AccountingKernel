using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Common;
using System.Transactions;

namespace AccountingKernel.Forms.Goods
{
    /// <summary>
    /// Interaction logic for Document.xaml
    /// </summary>
    public partial class frmPriceList : Window
    {
        private Guid CommodityId;

        public frmPriceList()
        {
            try
            {
                InitializeComponent();

            }
            catch
            {

                throw;
            }

        }

        public frmPriceList(Guid commodityId)
        {
            try
            {
                InitializeComponent();

                this.CommodityId = commodityId;

                var commodity = Business.GetCommodityBusiness().GetById(commodityId);
                var commodityDetail = Business.GetCommodityDetailBusiness().GetByCodeTitle(commodityId, Constants.CodeTitle.CommodityTitle);
                lblHeaderCommodityCodeValue.Content = commodityDetail.CDIDIn;
                lblHeaderCommodityTitleValue.Content = commodity.CName;

                cmbCType.ItemsSource = cmbCType.ItemsSource = Business.GetBaseInfoBusiness().GetByType(Constants.BaseInfoType.CustomerType);

                PriceListGridDataBind();

            }
            catch
            {

                throw;
            }
        }

        private void PriceListGridDataBind()
        {
            try
            {
                grdPriceLists.ItemsSource = Business.GetPriceListBusiness().GetByCommodityId(CommodityId).ToList().
                                            Join(Business.GetBaseInfoBusiness().GetByType(Constants.BaseInfoType.CustomerType),
                                            o => o.IDBaseInfo, i => i.Id, (o, i) => new { PriceList = o, BaseInfo = i }).
                                            Select(r => new { r.BaseInfo.Explain, r.PriceList.PLPrice }).ToList();

            }
            catch
            {

                throw;
            }
        }

        private void txtPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {

            }
            catch
            {

                throw;
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Save(cmbCType.SelectedValue.ToGUID());
                PriceListGridDataBind();
                ClearForm();
            }
            catch
            {

                throw;
            }
        }

        private void ClearForm()
        {
            try
            {
                txtPrice.Clear();
                cmbCType.SelectedIndex = -1;
            }
            catch 
            {
                
                throw;
            }
        }

        private void Save(Guid companyTypeId)
        {
            try
            {
                var priceListBusiness = Business.GetPriceListBusiness();

                var priceList = priceListBusiness.GetByCommodityIdCompanyTypeId(companyTypeId, CommodityId);

                if (priceList == null)
                    priceList = new Data.PriceList();

                priceList.IDBaseInfo = companyTypeId;
                priceList.IDCommodity = CommodityId;
                priceList.PLPrice = txtPrice.Text.ToDecimal();

                priceListBusiness.Save(priceList);

            }
            catch
            {

                throw;
            }
        }


    }
}
