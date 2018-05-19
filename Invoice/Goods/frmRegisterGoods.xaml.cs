using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Common;
using System.Transactions;
using Data;

namespace AccountingKernel.Forms.Goods
{
    /// <summary>
    /// Interaction logic for Document.xaml
    /// </summary>
    public partial class frmRegisterGoods : Window
    {
        public Guid? CommodityId { get; set; }

        public frmRegisterGoods()
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

        public frmRegisterGoods(Guid commodityid)
        {
            try
            {
                InitializeComponent();

                this.CommodityId = commodityid;
                var commodityBusiness = Business.GetCommodityBusiness();
                var commodityDetailBusiness = Business.GetCommodityDetailBusiness();
                var commodity = commodityBusiness.GetById(commodityid);

                if (commodity != null)
                {
                    txtGoodTitle.Text = commodity.CName;
                    txtCOrderPoint.Text = commodity.COrderPoint.ToString();
                    txtCOrderMax.Text = commodity.COrderMax.ToString();
                    txtCOrderMin.Text = commodity.COrderMin.ToString();
                    txtCPointCritical.Text = commodity.CPointCritical.ToString();
                    txtCInventoryMax.Text = commodity.CInventoryMax.ToString();
                }

                txtMainGroup.Text = commodityDetailBusiness.GetMainGroups(new List<Guid>() { commodity.ID }).First().CDName;
                txtSubsidiaryGroup.Text = commodityDetailBusiness.GetSubsidiaryGroup(new List<Guid>() { commodity.ID }).First().CDName;
                txtGoodCode.Text = commodityDetailBusiness.GetByCodeTitle(commodity.ID, Constants.CodeTitle.CommodityTitle).CDIDIn;

            }
            catch
            {

                throw;
            }
        }

        private void btnRegister_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
                {
                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted,
                    Timeout = new TimeSpan(2, 0, 0)
                }))
                {
                    var commodity = new Commodity();
                    var commodityBusiness = Business.GetCommodityBusiness();
                    var commodityDetailBusiness = Business.GetCommodityDetailBusiness();
                    if (CommodityId.HasValue)
                        commodity = commodityBusiness.GetById(CommodityId.Value);

                    commodity.CName = txtGoodTitle.Text;
                    commodity.COrderPoint = txtCOrderPoint.Text.ToNullableInt();
                    commodity.COrderMax = txtCOrderMax.Text.ToNullableInt();
                    commodity.COrderMin = txtCOrderMin.Text.ToNullableInt();
                    commodity.CPointCritical = txtCPointCritical.Text.ToNullableInt();
                    commodity.CInventoryMax = txtCInventoryMax.Text.ToNullableInt();
                    commodityBusiness.Save(commodity);
                    this.CommodityId = commodity.ID;

                    var mainGroup = commodityDetailBusiness.GetByName(txtMainGroup.Text, Constants.CodeTitle.CommodityMainGroup.ToGUID());
                    if (mainGroup == null)
                    {
                        mainGroup = new CommodityDetail
                        {
                            IDCommodity = commodity.ID,
                            IDCodeTitle = Constants.CodeTitle.CommodityMainGroup,
                            CDName = txtMainGroup.Text,
                            CDIDIn = Business.GetCommodityDetailBusiness().GetNewCode(Constants.CodeTitle.CommodityMainGroup, string.Empty, txtMainGroup.Text)
                        };

                    }
                    else if (mainGroup.IDCommodity == commodity.ID)
                        mainGroup.CDName = txtMainGroup.Text;

                    else
                    {
                        var newMainGroup = new CommodityDetail
                        {
                            IDCommodity = commodity.ID,
                            IDCodeTitle = Constants.CodeTitle.CommodityMainGroup,
                            CDName = txtMainGroup.Text,
                            CDIDIn = mainGroup.CDIDIn
                        };

                        mainGroup = newMainGroup;
                    }

                    commodityDetailBusiness.Save(mainGroup);

                    var subsidiaryGroup = commodityDetailBusiness.GetByName(txtSubsidiaryGroup.Text, Constants.CodeTitle.CommoditySubsidiaryGroup.ToGUID());
                    if (subsidiaryGroup == null)
                    {
                        subsidiaryGroup = new CommodityDetail()
                        {
                            IDCodeTitle = Constants.CodeTitle.CommoditySubsidiaryGroup,
                            IDCommodity = commodity.ID,
                            CDName = txtSubsidiaryGroup.Text,
                            CDIDIn = Business.GetCommodityDetailBusiness().GetNewCode(Constants.CodeTitle.CommoditySubsidiaryGroup, mainGroup.CDIDIn, txtSubsidiaryGroup.Text)
                        };
                    }
                    else if (subsidiaryGroup.IDCommodity == commodity.ID)
                        subsidiaryGroup.CDName = txtSubsidiaryGroup.Text;
                    else
                    {
                        var newSubsidiaryGroup = new CommodityDetail
                        {
                            IDCommodity = commodity.ID,
                            IDCodeTitle = Constants.CodeTitle.CommoditySubsidiaryGroup,
                            CDName = txtSubsidiaryGroup.Text,
                            CDIDIn = subsidiaryGroup.CDIDIn
                        };

                        subsidiaryGroup = newSubsidiaryGroup;
                    }

                    commodityDetailBusiness.Save(subsidiaryGroup);

                    var commodityDetail = commodityDetailBusiness.GetByName(txtGoodTitle.Text, Constants.CodeTitle.CommodityTitle.ToGUID());
                    if (commodityDetail == null)
                    {
                        commodityDetail = new CommodityDetail()
                        {
                            IDCodeTitle = Constants.CodeTitle.CommodityTitle,
                            IDCommodity = commodity.ID,
                            CDName = txtGoodTitle.Text,
                            CDIDIn = Business.GetCommodityDetailBusiness().GetNewCode(Constants.CodeTitle.CommodityTitle, subsidiaryGroup.CDIDIn, txtGoodTitle.Text)
                        };
                    }
                    else if (commodityDetail.IDCommodity == commodity.ID)
                        commodityDetail.CDName = txtGoodTitle.Text;
                    else
                    {
                        var newCommodityDetail = new CommodityDetail
                        {
                            IDCommodity = commodity.ID,
                            IDCodeTitle = Constants.CodeTitle.CommodityTitle,
                            CDName = txtGoodTitle.Text,
                            CDIDIn = commodityDetail.CDIDIn
                        };

                        commodityDetail = newCommodityDetail;
                    }
                    commodityDetailBusiness.Save(commodityDetail);

                    scope.Complete();
                }

                this.Close();

            }
            catch
            {

                throw;
            }
        }

    }
}
