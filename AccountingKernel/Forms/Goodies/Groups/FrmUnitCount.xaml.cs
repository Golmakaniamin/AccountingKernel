using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Common;
using System.Transactions;
using System.Data;
using Data;
using Stimulsoft.Report;

namespace AccountingKernel.Forms.Goodies
{
    /// <summary
    /// Interaction logic for Document.xaml
    /// </summary
    public partial class FrmUnitCount : Window
    {
        string[,] ss;
        int cc;

        public class test
        {
            public Guid? Id { get; set; }
            public bool IsAllocated { set; get; }
            public Guid? SecondUnitId { get; set; }
            public int? Count2 { get; set; }
            public string UnitName { get; set; }
        }


        public enum DataGridCellIndices
        {
            Id = 0,
            Checkbox = 1,
            SecondUnitComboBox = 2,
            SecondUnitCountTextBox = 3
        }

        public Guid GoodyId { set; get; }

        public FrmUnitCount()
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

        public FrmUnitCount(Guid goodyId)
        {
            try
            {
                InitializeComponent();

                this.GoodyId = goodyId;

                var goody = Business.GetGoodiesBusiness().GetById(goodyId);
                if (!goody.CBaseCountingUnit.HasValue)
                    throw new Exception(Localize.ex_no_base_count_unit);
                txtTitle.Content = goody.CName;
                txtCode.Content = goody.CID1;

                SetDataGrid();

            }
            catch
            {

                throw;
            }
        }

        private void SetDataGrid()
        {

            var goody = Business.GetGoodiesBusiness().GetById(GoodyId);
            var units = Business.GetBaseInfoBusiness().GetByType(Constants.BaseInfoType.Units);
            var baseUnit = units.Find(r => r.Id == goody.CBaseCountingUnit);
            if (baseUnit != null)
                units.Remove(baseUnit);

            var goodyConvertCountingUnits = Business.GetGoodyConvertCountingUnitBusiness().GetByGoodyId(GoodyId);

            cmbSecondUnit.ItemsSource = units;
            cmbSecondUnit.DisplayMemberPath = "AssignName";
            cmbSecondUnit.SelectedValuePath = "Id";
            var items = new List<test>();

            foreach (var item in units)
            {
                var goodyConvertCountingUnit = goodyConvertCountingUnits.Find(r => r.CCCUIDBaseInfo2 == item.Id);
                if (goodyConvertCountingUnit != null)
                {
                    items.Add(new test
                    {
                        Id = goodyConvertCountingUnit.ID,
                        IsAllocated = true,
                        SecondUnitId = goodyConvertCountingUnit.CCCUIDBaseInfo2,
                        Count2 = goodyConvertCountingUnit.CCCUCount2,
                        UnitName = units.Find(r => r.Id == goodyConvertCountingUnit.CCCUIDBaseInfo2).AssignName
                    });
                }
                else
                {
                    items.Add(new test
                    {
                        Id = null,
                        IsAllocated = false,
                        SecondUnitId = null,
                        Count2 = null,
                        UnitName = string.Empty
                    });
                }
            }

            if (txtSearch.Text != string.Empty)
            {
                items = items.FindAll(r => r.UnitName.Contains(txtSearch.Text) || r.Count2.ToString().Contains(txtSearch.Text));
            }
            grdUnitCount.ItemsSource = items.OrderByDescending(r => r.IsAllocated).ThenBy(r => r.Count2).ToList();

            var v = items.OrderByDescending(r => r.IsAllocated).ThenBy(r => r.Count2).ToList();
            cc = v.Count();
            ss = new string[cc, 2];
            int ii = 0;
            foreach (var item in v)
            {
                string V_F = item.SecondUnitId.ToString();
                string MEGH = item.Count2.ToString();

                ss[ii, 0] = V_F;
                ss[ii, 1] = MEGH;

                ii++;
            }

        }

        private void set_to_excell(string[,] a, int rowC)
        {
            ExcelImpExp.ExportToExcel exp = new ExcelImpExp.ExportToExcel();
            var table = new System.Data.DataTable();


            table = exp.get_dataGridColumnNames(grdUnitCount);

            for (int i = 0; i <= rowC - 1; i++)
            {
                var row = table.NewRow();
                /*
                row[this.grid_asnad.Columns[i + 1].Header.ToString()] = int.Parse(a[i, 0].ToString());
                row[this.grid_asnad.Columns[i + 1].Header.ToString()] = a[i, 1];
                row[this.grid_asnad.Columns[i + 1].Header.ToString()] = a[i, 2];
                row[this.grid_asnad.Columns[i + 1].Header.ToString()] = a[i, 3];
               */

                for (int j = 0; j <= 1; j++)
                {
                    //if (j == 0)
                    //    row[this.grdUnitCount.Columns[j + 1].Header.ToString()] = int.Parse(a[i, j].ToString());
                    //else
                        row[this.grdUnitCount.Columns[j + 1].Header.ToString()] = a[i, j];
                }

                table.Rows.Add(row);
            }


            DataSet ds = new DataSet("New_DataSet");
            ds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;
            ds.Tables.Add(table);
            exp.showStuff(ds);

        }

        private bool ValidateForm(Data.Goody goody, int secondUnitCount, out string errorMessage)
        {
            try
            {
                errorMessage = string.Empty;
                if (!goody.CBaseCountingUnit.HasValue)
                    errorMessage += Localize.ex_no_base_count_unit + Environment.NewLine;

                if (secondUnitCount <= 0)
                    errorMessage = Localize.ex_invalid_unit_count_value + Environment.NewLine;

                return errorMessage == string.Empty;
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
                if (grdUnitCount.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);

                var msgResult = MessageBox.Show(Localize.DeleteRecordMessage, Localize.DeleteRecordCaption, MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (msgResult != MessageBoxResult.Yes)
                    return;

                var commodityConvertCountingUnit = Business.GetGoodyConvertCountingUnitBusiness().GetById((grdUnitCount.SelectedValue as dynamic).Id);

                Business.GetGoodyConvertCountingUnitBusiness().Delete(commodityConvertCountingUnit);
                SetDataGrid();
            }
            catch (Exception ex)
            {

                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var goody = Business.GetGoodiesBusiness().GetById(GoodyId);

                var firstUnitId = goody.CBaseCountingUnit.Value;
                var firstUnitCount = 1;

                var goodyConvertCountingUnitBusiness = Business.GetGoodyConvertCountingUnitBusiness();

                for (int i = 0; i < this.grdUnitCount.Items.Count; i++)
                {
                    var item = (test)this.grdUnitCount.Items[i];
                    var secondUnitId = item.SecondUnitId.ToGUID();
                    var secondUnitCount = item.Count2;
                    if (secondUnitId == Guid.Empty || !secondUnitCount.HasValue)
                        return;

                    var errorMessage = string.Empty;
                    if (!ValidateForm(goody, secondUnitCount.Value, out errorMessage))
                        throw new Exception(errorMessage);

                    var goodyConvertCountingUnit = goodyConvertCountingUnitBusiness.GetByGoodyId(GoodyId, firstUnitId, secondUnitId);

                    if (goodyConvertCountingUnit == null)
                        goodyConvertCountingUnit = new GoodyConvertCountingUnit();

                    goodyConvertCountingUnit.IDCommodity = GoodyId;
                    goodyConvertCountingUnit.CCCUIDBaseInfo1 = firstUnitId;
                    goodyConvertCountingUnit.CCCUCount1 = firstUnitCount;
                    goodyConvertCountingUnit.CCCUIDBaseInfo2 = secondUnitId;
                    goodyConvertCountingUnit.CCCUCount2 = secondUnitCount.Value;
                    goodyConvertCountingUnitBusiness.Save(goodyConvertCountingUnit);

                }

                SetDataGrid();

            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void txtCode_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {

            Class.UI.TextHandeler c = new Class.UI.TextHandeler();
            c.CheckIsNumeric(e);
        }

        private void BtnExel_Click(object sender, RoutedEventArgs e)
        {

            set_to_excell(ss, cc);
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (grdUnitCount.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);

                var msgResult = MessageBox.Show(Localize.DeleteRecordMessage, Localize.DeleteRecordCaption, MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (msgResult != MessageBoxResult.Yes)
                    return;

                var commodityConvertCountingUnit = Business.GetGoodyConvertCountingUnitBusiness().GetById((grdUnitCount.SelectedValue as dynamic).Id);

                Business.GetGoodyConvertCountingUnitBusiness().Delete(commodityConvertCountingUnit);
                SetDataGrid();
            }
            catch (Exception ex)
            {

                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            var goody = Business.GetGoodiesBusiness().GetById(GoodyId);
            var units = Business.GetBaseInfoBusiness().GetByType(Constants.BaseInfoType.Units);
            var baseUnit = units.Find(r => r.Id == goody.CBaseCountingUnit);
            if (baseUnit != null)
                units.Remove(baseUnit);

            var goodyConvertCountingUnits = Business.GetGoodyConvertCountingUnitBusiness().GetByGoodyId(GoodyId);

            cmbSecondUnit.ItemsSource = units;
            cmbSecondUnit.DisplayMemberPath = "AssignName";
            cmbSecondUnit.SelectedValuePath = "Id";
            var items = new List<test>();

            foreach (var item in units)
            {
                var goodyConvertCountingUnit = goodyConvertCountingUnits.Find(r => r.CCCUIDBaseInfo2 == item.Id);
                if (goodyConvertCountingUnit != null)
                {
                    items.Add(new test
                    {
                        Id = goodyConvertCountingUnit.ID,
                        IsAllocated = true,
                        SecondUnitId = goodyConvertCountingUnit.CCCUIDBaseInfo2,
                        Count2 = goodyConvertCountingUnit.CCCUCount2,
                        UnitName = units.Find(r => r.Id == goodyConvertCountingUnit.CCCUIDBaseInfo2).AssignName
                    });
                }
                else
                {
                    items.Add(new test
                    {
                        Id = null,
                        IsAllocated = false,
                        SecondUnitId = null,
                        Count2 = null,
                        UnitName = string.Empty
                    });
                }
            }

            if (txtSearch.Text != string.Empty)
            {
                items = items.FindAll(r => r.UnitName.Contains(txtSearch.Text) || r.Count2.ToString().Contains(txtSearch.Text));
            }
            grdUnitCount.ItemsSource = items.OrderByDescending(r => r.IsAllocated).ThenBy(r => r.Count2).ToList();
            var v = items.OrderByDescending(r => r.IsAllocated).ThenBy(r => r.Count2).ToList();

            StiReport report = new StiReport();

            report.Load(@"D:\New folder (2)\accountingKernel\AccountingKernel\Debug_AccountingKernel\Report\FrmUnitCount.mrt");

            report.RegData("v", v);

            report.Show();
        }

    }
}
