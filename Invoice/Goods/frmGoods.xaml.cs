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
    public partial class frmGoods : Window
    {
        public frmGoods()
        {
            try
            {
                InitializeComponent();

                SetDataGrid();

            }
            catch
            {

                throw;
            }

        }

        private void SetDataGrid()
        {
            try
            {
                var commodityDetailBusiness = Business.GetCommodityDetailBusiness();
                var commodityBusiness = Business.GetCommodityBusiness();
                var codeTitelBusiness = Business.GetCodeTitleBusiness();

                var commodities = commodityBusiness.GetAll();

                var mainGroups = commodityDetailBusiness.GetMainGroups(commodities.Select(r => r.ID).ToList());
                var commoditiesJMaingroups = commodities.Join(mainGroups,
                    o => o.ID,
                    i => i.IDCommodity,
                    (o, i) => new { Commodity = o, MainGroup = i }
                    );

                var subsidiaryGroups = commodityDetailBusiness.GetSubsidiaryGroup(commodities.Select(r => r.ID).ToList());
                var commoditiesjMainSubsidiary = commoditiesJMaingroups.Join(subsidiaryGroups,
                    o => o.Commodity.ID,
                    i => i.IDCommodity,
                    (o, i) => new { CommodityJMainGroup = o, SubsidiaryGroup = i }
                    );

                var commodityTitles = commodityDetailBusiness.GetCommodityTitle(commodities.Select(r => r.ID).ToList());
                var commoditiesjAll = commoditiesjMainSubsidiary.Join(commodityTitles,
                    o => o.CommodityJMainGroup.Commodity.ID,
                    i => i.IDCommodity,
                    (o, i) => new { commoditiesjMainSubsidiary = o, commodityTitle = i }
                    );


                if (txtSearch.Text != string.Empty)
                    commoditiesjAll = commoditiesjAll.Where(r =>
                        r.commodityTitle.CDName.Contains(txtSearch.Text) ||
                        r.commodityTitle.CDIDIn.Contains(txtSearch.Text) ||
                        r.commoditiesjMainSubsidiary.CommodityJMainGroup.MainGroup.CDName.Contains(txtSearch.Text) ||
                        r.commoditiesjMainSubsidiary.SubsidiaryGroup.CDName.Contains(txtSearch.Text));

                DataGrid.ItemsSource = commoditiesjAll.Select(r => new
                    {
                        Id = r.commoditiesjMainSubsidiary.CommodityJMainGroup.Commodity.ID,
                        SubsidiaryGroup = r.commoditiesjMainSubsidiary.SubsidiaryGroup.CDName,
                        MainGroup = r.commoditiesjMainSubsidiary.CommodityJMainGroup.MainGroup.CDName,
                        GoodTitle = r.commodityTitle.CDName,
                        GoodCode = r.commodityTitle.CDIDIn
                    }).ToList();


            }
            catch
            {

                throw;
            }
        }

        private void MenuItem_Register(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                var frmRegisterGoods = new frmRegisterGoods();
                frmRegisterGoods.ShowDialog();
                SetDataGrid();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void MenuItem_Edit(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                if (DataGrid.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);

                Guid id;
                id = (DataGrid.SelectedValue as dynamic).Id;
                var frmRegisterGoods = new frmRegisterGoods(id);
                frmRegisterGoods.ShowDialog();
                SetDataGrid();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }

        }

        private void MenuItem_UnitCount(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                if (DataGrid.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);

                var frmUnitCount = new frmUnitCount((DataGrid.SelectedValue as dynamic).Id);
                frmUnitCount.ShowDialog();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void MenuItem_PriceList(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                if (DataGrid.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);

                Guid id;
                id = (DataGrid.SelectedValue as dynamic).Id;
                var frmPriceList = new frmPriceList(id);
                frmPriceList.ShowDialog();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }

        }

        private void MenuItem_Delete(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                if (DataGrid.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);

                var msgResult = MessageBox.Show(Localize.DeleteRecordMessage, Localize.DeleteRecordCaption, MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                if (msgResult != MessageBoxResult.Yes)
                    return;

                Guid id = (DataGrid.SelectedValue as dynamic).Id;

                var commodityBusiness = Business.GetCommodityBusiness();
                var commodityDetailBusiness = Business.GetCommodityDetailBusiness();
                var commodity = commodityBusiness.GetById(id);
                var commodityDetail = commodityDetailBusiness.GetByCommodityId(commodity.ID);
                commodityBusiness.Delete(commodity);
                commodityDetailBusiness.Delete(commodityDetail);

                SetDataGrid();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }

        }

        private void txtSearch_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            try
            {
                SetDataGrid();
            }
            catch
            {

                throw;
            }
        }

    }
}
