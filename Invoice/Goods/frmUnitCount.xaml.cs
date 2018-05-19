using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Common;
using System.Transactions;
using System.Data;
using Data;

namespace AccountingKernel.Forms.Goods
{
    /// <summary
    /// Interaction logic for Document.xaml
    /// </summary
    public partial class frmUnitCount : Window
    {

        public class test
        {
            public bool IsAllocated { set; get; }
            public Guid FirstUnitId  { get; set; }
            public Guid? SecondUnitId  { get; set; }
            public int? Count2  { get; set; }
        }


        public enum DataGridCellIndices
        {
            Checkbox = 0,
            FirstUnitComboBox = 1,
            SecondUnitComboBox = 2,
            SecondUnitCountTextBox = 3
        }

        public Guid CommodityId{set; get;}

        public frmUnitCount()
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

        public frmUnitCount(Guid CommodityId)
        {
            try
            {
                InitializeComponent();

                this.CommodityId = CommodityId;

                var commodity = Business.GetCommodityBusiness().GetById(CommodityId);
                var commodityDetail = Business.GetCommodityDetailBusiness().GetByCodeTitle(CommodityId, Constants.CodeTitle.CommodityTitle);
                txtTitle.Text = commodity.CName;
                txtCode.Text = commodityDetail.CDIDIn;

                SetDataGrid();

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
            }
            catch
            {

                // throw;
            }
        }

        private void SetDataGrid()
        {

            var units = Business.GetBaseInfoBusiness().GetByType(Constants.BaseInfoType.Units);
            var commodityConvertCountingUnits = Business.GetCommodityConvertCountingUnitBusiness().GetByCommodityId(CommodityId);

            cmbFirstUnit1.ItemsSource = units;
            cmbFirstUnit1.DisplayMemberPath = "AssignName";
            cmbFirstUnit1.SelectedValuePath = "Id";

            cmbSecondUnit1.ItemsSource = units;
            cmbSecondUnit1.DisplayMemberPath = "AssignName";
            cmbSecondUnit1.SelectedValuePath = "Id";
            var items = new List<test>();

            foreach (var item in units)
            {
                var commodityConvertCountingUnit = commodityConvertCountingUnits.Find(r => r.CCCUIDBaseInfo1 == item.Id);
                if (commodityConvertCountingUnit != null)
                {
                    items.Add(new test
                    {
                        IsAllocated= true,
                        FirstUnitId = item.Id,
                        SecondUnitId = commodityConvertCountingUnit.CCCUIDBaseInfo2,
                        Count2 = commodityConvertCountingUnit.CCCUCount2,
                    });
                }
                else
                {
                    items.Add(new test
                    {
                        IsAllocated = false,
                        FirstUnitId = item.Id,
                        SecondUnitId = null,
                        Count2 = null,

                    });
                }
            }

            grdUnitCount.ItemsSource = items;
        }

        public bool Show(Guid CommodityId)
        {
            try
            {

                var commodity = Business.GetCommodityBusiness().GetById(CommodityId);
                var commodityDetail = Business.GetCommodityDetailBusiness().GetByCommodityId(CommodityId);

                SetDataGrid();

                this.ShowDialog();
                return true;
            }
            catch
            {

                // throw;
                return false;
            }
        }

        private void DataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            try
            {
                var isChecked = (this.grdUnitCount.Columns[DataGridCellIndices.Checkbox.ToInt()].GetCellContent(e.Row) as System.Windows.Controls.CheckBox).IsChecked.ToBoolean();

                var firstUnitId = (this.grdUnitCount.Columns[DataGridCellIndices.FirstUnitComboBox.ToInt()].GetCellContent(e.Row) as System.Windows.Controls.ComboBox).SelectedValue.ToGUID();
                var firstUnitCount = 1;

                var secondUnitId = (this.grdUnitCount.Columns[DataGridCellIndices.SecondUnitComboBox.ToInt()].GetCellContent(e.Row) as System.Windows.Controls.ComboBox).SelectedValue.ToGUID();
                var secondUnitCount = (this.grdUnitCount.Columns[DataGridCellIndices.SecondUnitCountTextBox.ToInt()].GetCellContent(e.Row) as System.Windows.Controls.TextBlock).Text.ToInt();

                var commodityConvertCountingUnitBusiness = Business.GetCommodityConvertCountingUnitBusiness();
                var commodityConvertCountingUnit = commodityConvertCountingUnitBusiness.GetByCommodityId(CommodityId, firstUnitId);

                if (isChecked)
                {
                    if (commodityConvertCountingUnit == null)
                        commodityConvertCountingUnit = new CommodityConvertCountingUnit();

                    commodityConvertCountingUnit.IDCommodity = CommodityId;
                    commodityConvertCountingUnit.CCCUIDBaseInfo1 = firstUnitId;
                    commodityConvertCountingUnit.CCCUCount1 = firstUnitCount;
                    commodityConvertCountingUnit.CCCUIDBaseInfo2 = secondUnitId;
                    commodityConvertCountingUnit.CCCUCount2 = secondUnitCount;

                    commodityConvertCountingUnitBusiness.Save(commodityConvertCountingUnit);
                }
                else
                {
                    commodityConvertCountingUnitBusiness.Delete(commodityConvertCountingUnit);

                }
            }
            catch
            {
                throw;
            }
        }

    }
}
