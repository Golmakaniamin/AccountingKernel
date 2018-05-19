using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Common;
using System.Transactions;

namespace AccountingKernel.Forms.Goodies
{
    /// <summary>
    /// Interaction logic for Document.xaml
    /// </summary>
    public partial class FrmPriceList : Window
    {
        private class DataGridData
        {
            public Guid Id { set; get; }
            public bool IsAllocated { set; get; }
            public Guid CustomerTypeId { get; set; }
            public string CustomerTypeName { get; set; }
            public string Value { get; set; }

        }

        private enum DataGridCellIndices
        {
            Id = 0,
            Checkbox = 1,
            CustomerTypeName = 2,
            Value = 3
        }

        private Guid GoodyId;

        public FrmPriceList()
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

        public FrmPriceList(Guid goodyId)
        {
            try
            {
                InitializeComponent();

                this.GoodyId = goodyId;

                var goody = Business.GetGoodiesBusiness().GetById(goodyId);
                lblHeaderCommodityCodeValue.Content = goody.CID1;
                lblHeaderCommodityTitleValue.Content = goody.CName;

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
                var customerPriceTypes = Business.GetBaseInfoBusiness().GetByType(Common.Constants.BaseInfoType.CustomerPriceType);

                cmbCustomerType.ItemsSource = customerPriceTypes.Select(r => new { CustomerTypeId = r.Id, CustomerTypeName = r.AssignName }).ToList();
                cmbCustomerType.DisplayMemberPath = "CustomerTypeName";
                cmbCustomerType.SelectedValuePath = "CustomerTypeId";

                var priceLists = Business.GetGoodyPriceListBusiness().GetByGoodyId(GoodyId).ToList();

                var items = new List<DataGridData>();
                foreach (var customerPriceType in customerPriceTypes)
                {
                    var currentEntity = priceLists.Find(r => r.IDBaseInfo == customerPriceType.Id);
                    if (currentEntity != null)
                        items.Add(new DataGridData
                        {
                            Id = currentEntity.Id,
                            IsAllocated = true,
                            CustomerTypeId = customerPriceType.Id,
                            CustomerTypeName = customerPriceType.AssignName,
                            Value = currentEntity.PLPrice.ToDecimal().ToString(Localize.DoubleMaskType)
                        });
                    else
                        items.Add(new DataGridData
                        {
                            Id = Guid.Empty,
                            IsAllocated = false
                        });
                }


                grdPriceLists.ItemsSource = items.OrderByDescending(r => r.IsAllocated).ThenBy(r => r.CustomerTypeName).ToList();
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

        private void Save(Guid companyPriceTypeId, string value)
        {
            try
            {
                var goodyPriceListBusiness = Business.GetGoodyPriceListBusiness();

                var priceList = goodyPriceListBusiness.GetByGoodyIdCompanyPriceTypeId(companyPriceTypeId, GoodyId);

                if (priceList == null)
                    priceList = new Data.GoodyPriceList();

                priceList.IDBaseInfo = companyPriceTypeId;
                priceList.IDGoody = GoodyId;
                priceList.PLPrice = value.ToDecimal();

                goodyPriceListBusiness.Save(priceList);

            }
            catch
            {

                throw;
            }
        }

        private void MenuItem_DeleteClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                if (grdPriceLists.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);

                var msgResult = MessageBox.Show(Localize.DeleteRecordMessage, Localize.DeleteRecordCaption, MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (msgResult != MessageBoxResult.Yes)
                    return;

                var priceList = Business.GetGoodyPriceListBusiness().GetById((grdPriceLists.SelectedValue as dynamic).Id);

                Business.GetGoodyPriceListBusiness().Delete(priceList);
                SetDataGrid();
            }
            catch (Exception ex)
            {

                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                for (int i = 0; i < grdPriceLists.Items.Count - 1; i++)
                {
                    var item = (DataGridData)grdPriceLists.Items[i];

                    if (item.CustomerTypeId.ToGUID() == Guid.Empty || item.Value == null)
                        continue;
                    Save(item.CustomerTypeId, item.Value);

                }

                SetDataGrid();
            }
            catch
            {

                throw;
            }
        }

        private void lblHeaderCommodityCodeValue_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Class.UI.TextHandeler c = new Class.UI.TextHandeler();
            c.CheckIsNumeric(e);
        }

        private void lblHeaderCommodityCode_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {

        }

    }
}
