using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Common;
using System.Transactions;
using AccountingKernel.Forms.Base;
using System.Data;
using Stimulsoft.Report;

namespace AccountingKernel.Forms.Operatives
{
    /// <summary>
    /// Interaction logic for Document.xaml
    /// </summary>
    public partial class frmOperativeMangement : Window
    {
        string[,] ss;
        int cc;

        public frmOperativeMangement()
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
                var operativeBusiness = Business.GetOperativeBusiness();

                var iqoperative = operativeBusiness.GetAll();
                if (txtSearch.Text != string.Empty)
                    iqoperative = iqoperative.Where(r => r.OName.Contains(txtSearch.Text));

                var calculationMethods = Business.GetBaseInfoBusiness().GetByType(Constants.BaseInfoType.CalculationMethod);
                var operativeTypes = Business.GetBaseInfoBusiness().GetByType(Constants.BaseInfoType.OperativeType);


                var vv = iqoperative.ToList().Select(r => new
                    {
                        Id = r.Id,
                        CalculationMethod = calculationMethods.Find(t => t.Id == r.OCalculationMethod).AssignName,
                        OperativeType = operativeTypes.Find(t => t.Id == r.OType).AssignName,
                        OperativeName = r.OName,
                    }).ToList();
                this.DataGrid.ItemsSource = vv;
                var v = iqoperative.ToList();
                cc = v.Count();
                ss = new string[cc, 3];
                int ii = 0;
                foreach (var item in vv)
                {
                    string R_M = item.CalculationMethod;
                    string N_A = item.OperativeType;
                    string Name_A = item.OperativeName;

                    ss[ii, 0] = R_M;
                    ss[ii, 1] = N_A;
                    ss[ii, 2] = Name_A;

                    ii++;
                }

            }
            catch
            {

                throw;
            }
        }

        private void set_to_excell(string[,] a, int rowC)
        {
            ExcelImpExp.ExportToExcel exp = new ExcelImpExp.ExportToExcel();
            var table = new System.Data.DataTable();


            table = exp.get_dataGridColumnNames(DataGrid);

            for (int i = 0; i <= rowC - 1; i++)
            {
                var row = table.NewRow();
                /*
                row[this.grid_asnad.Columns[i + 1].Header.ToString()] = int.Parse(a[i, 0].ToString());
                row[this.grid_asnad.Columns[i + 1].Header.ToString()] = a[i, 1];
                row[this.grid_asnad.Columns[i + 1].Header.ToString()] = a[i, 2];
                row[this.grid_asnad.Columns[i + 1].Header.ToString()] = a[i, 3];
               */

                for (int j = 0; j <= 2; j++)
                {
                    //if (j == 0)
                    //    row[this.DataGrid.Columns[j + 1].Header.ToString()] = int.Parse(a[i, j].ToString());
                    //else
                    row[this.DataGrid.Columns[j + 1].Header.ToString()] = a[i, j];
                }

                table.Rows.Add(row);
            }


            DataSet ds = new DataSet("New_DataSet");
            ds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;
            ds.Tables.Add(table);
            exp.showStuff(ds);

        }
        private void MenuItem_Register(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                var frmOperative = new Operatives.frmOperative();
                frmOperative.ShowDialog();
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

                var frmOperative = new Operatives.frmOperative(id);
                frmOperative.ShowDialog();
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

                Guid id;
                id = (DataGrid.SelectedValue as dynamic).Id;

                //var frmUnitCount = new Goods.frmUnitCount();
                //frmUnitCount.CommodityId = id;
                //frmUnitCount.ShowDialog();
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
                new Goodies.FrmPriceList(id).ShowDialog();
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

                var msgResult = MessageBox.Show(Localize.DeleteRecordMessage, Localize.DeleteRecordCaption, MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (msgResult != MessageBoxResult.Yes)
                    return;

                Guid id = (DataGrid.SelectedValue as dynamic).Id;

                var operativeBusiness = Business.GetOperativeBusiness();

                operativeBusiness.Delete(operativeBusiness.GetById(id));

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
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void BtnExel_Click(object sender, RoutedEventArgs e)
        {

            set_to_excell(ss, cc);
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var frmOperative = new Operatives.frmOperative();
                frmOperative.ShowDialog();
                SetDataGrid();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DataGrid.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);

                Guid id;
                id = (DataGrid.SelectedValue as dynamic).Id;

                var frmOperative = new Operatives.frmOperative(id);
                frmOperative.ShowDialog();
                SetDataGrid();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DataGrid.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);

                var msgResult = MessageBox.Show(Localize.DeleteRecordMessage, Localize.DeleteRecordCaption, MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (msgResult != MessageBoxResult.Yes)
                    return;

                Guid id = (DataGrid.SelectedValue as dynamic).Id;

                var operativeBusiness = Business.GetOperativeBusiness();

                operativeBusiness.Delete(operativeBusiness.GetById(id));

                SetDataGrid();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            var operativeBusiness = Business.GetOperativeBusiness();

            var iqoperative = operativeBusiness.GetAll();
            if (txtSearch.Text != string.Empty)
                iqoperative = iqoperative.Where(r => r.OName.Contains(txtSearch.Text));

            var calculationMethods = Business.GetBaseInfoBusiness().GetByType(Constants.BaseInfoType.CalculationMethod);
            var operativeTypes = Business.GetBaseInfoBusiness().GetByType(Constants.BaseInfoType.OperativeType);


            var vv = iqoperative.ToList().Select(r => new
            {
                Id = r.Id,
                CalculationMethod = calculationMethods.Find(t => t.Id == r.OCalculationMethod).AssignName,
                OperativeType = operativeTypes.Find(t => t.Id == r.OType).AssignName,
                OperativeName = r.OName,
            }).ToList();

            StiReport report = new StiReport();

            report.Load(@".\\Report\\Basic_Information\\frmOperativeMangement.mrt");

            report.RegData("vv", vv);

            report.Show();
        }

    }
}
