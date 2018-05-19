using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Stimulsoft.Report;

namespace AccountingKernel.Forms.Sandogh
{
    /// <summary>
    /// Interaction logic for frm_sandogh.xaml
    /// </summary>
    public partial class frm_sandogh : Window
    {
        string[,] ss;
        int cc; 

        public frm_sandogh()
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

        private void MenuItem_Register(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                var frm_Register_Sandogh = new Frm_Register_Sandogh();
                frm_Register_Sandogh.ShowDialog();
                SetDataGrid();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }

        }

        private void SetDataGrid()
        {
            try
            {
                if (txt_search.Text.Trim().Length > 0)
                    grid_sandogh.ItemsSource = Business.GetFundsBusiness().GetByFType(Common.Constants.BankType.Sandogh).Where(
                        i => i.FName.Contains(txt_search.Text) ).ToList();


                else

                    grid_sandogh.ItemsSource = Business.GetFundsBusiness().GetByFType(Common.Constants.BankType.Sandogh).ToList();
         
             
                var v = Business.GetFundsBusiness().GetByFType(Common.Constants.BankType.Sandogh).ToList();
                cc = v.Count();
                ss = new string[cc, 2];
                int ii = 0;
                foreach (var item in v)
                {
                    string Na = item.FName;
                    string Mab = item.Fprice.ToString();

                    ss[ii, 0] = Na;
                    ss[ii, 1] = Mab;
               
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


            table = exp.get_dataGridColumnNames(grid_sandogh);

            for (int i = 0; i <= rowC - 1; i++)
            {
                var row = table.NewRow();
                /*
                row[this.grid_asnad.Columns[i + 1].Header.ToString()] = int.Parse(a[i, 0].ToString());
                row[this.grid_asnad.Columns[i + 1].Header.ToString()] = a[i, 1];
                row[this.grid_asnad.Columns[i + 1].Header.ToString()] = a[i, 2];
                row[this.grid_asnad.Columns[i + 1].Header.ToString()] = a[i, 3];
               */

                for (int j = 0; j <=1; j++)
                {
                    //if (j == 0)
                    //    row[this.grid_sandogh.Columns[j + 1].Header.ToString()] = int.Parse(a[i, j].ToString());
                    //else
                        row[this.grid_sandogh.Columns[j + 1].Header.ToString()] = a[i, j];
                }

                table.Rows.Add(row);
            }


            DataSet ds = new DataSet("New_DataSet");
            ds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;
            ds.Tables.Add(table);
            exp.showStuff(ds);

        }

        private void MenuItem_Edit(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                if (grid_sandogh.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);
                var frmRegisterBaseInfo = new Frm_Register_Sandogh((grid_sandogh.SelectedValue as dynamic).ID);
                frmRegisterBaseInfo.ShowDialog();
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
                var frm_Register_Sandogh = new Frm_Register_Sandogh();
                frm_Register_Sandogh.ShowDialog();
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
                if (grid_sandogh.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);
                var frmRegisterBaseInfo = new Frm_Register_Sandogh((grid_sandogh.SelectedValue as dynamic).ID);
                frmRegisterBaseInfo.ShowDialog();
                SetDataGrid();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            var v=Business.GetFundsBusiness().GetByFType(Common.Constants.BankType.Sandogh).ToList();
            if (txt_search.Text.Trim().Length > 0)
            {
                 v = Business.GetFundsBusiness().GetByFType(Common.Constants.BankType.Sandogh).Where(i => i.FName.Contains(txt_search.Text)).ToList();
            }
            else
                grid_sandogh.ItemsSource = Business.GetFundsBusiness().GetByFType(Common.Constants.BankType.Sandogh).ToList();

                   
            StiReport report = new StiReport();

            report.Load(@".\\Report\\Basic_Information\\frm_sandogh.mrt");
            report.RegData("v", v);
            report.Show();
        }

        private void txt_search_KeyUp(object sender, KeyEventArgs e)
        {
            SetDataGrid();
        }

    }
}
