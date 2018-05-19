using System;
using System.Collections.Generic;
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
using Common;
using System.Data;
using Stimulsoft.Report;

namespace AccountingKernel.Forms.KazaneDari
{
    /// <summary>
    /// Interaction logic for frm_list_daryaft.xaml
    /// </summary>
    public partial class frm_list_daryaft : Window
    {
        string[,] ss;
        int cc; 

        public frm_list_daryaft()
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

                var search = Business.GetTreasuryBusiness().GetByType(Common.Constants.TreasuryType.Recive);

                if (!txt_search.Text.Trim().IsNullOrEmpty())
                    search = search.Where(i => i.TDate.Contains(txt_search.Text) || i.TNO.Contains(txt_search.Text));

               var vv = search.ToList().Select(
                     r => new
                     {
                         r.ID,
                         r.TDate,
                         r.TNO,
                         TPrice = r.TPrice.ToDouble().ToString(Localize.DoubleMaskType)
                     });
                
                this.grdRecive.ItemsSource = vv;  
                var v = search.ToList();
                cc = v.Count();
                ss = new string[cc, 3];
                int ii = 0;
                foreach (var item in vv)
                {
                    string Code = item.TNO;
                    string Ta = item.TDate;
                    string Mablagh = item.TPrice;

                    ss[ii, 0] = Code;
                    ss[ii, 1] = Ta;
                    ss[ii, 2] = Mablagh;
                 
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


            table = exp.get_dataGridColumnNames(grdRecive);

            for (int i = 0; i <= rowC - 1; i++)
            {
                var row = table.NewRow();
                /*
                row[this.grid_asnad.Columns[i + 1].Header.ToString()] = int.Parse(a[i, 0].ToString());
                row[this.grid_asnad.Columns[i + 1].Header.ToString()] = a[i, 1];
                row[this.grid_asnad.Columns[i + 1].Header.ToString()] = a[i, 2];
                row[this.grid_asnad.Columns[i + 1].Header.ToString()] = a[i, 3];
               */

                for (int j = 0; j <=2; j++)
                {
                    if (j == 0)
                        row[this.grdRecive.Columns[j + 1].Header.ToString()] = int.Parse(a[i, j].ToString());
                    else
                        row[this.grdRecive.Columns[j + 1].Header.ToString()] = a[i, j];
                }

                table.Rows.Add(row);
            }


            DataSet ds = new DataSet("New_DataSet");
            ds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;
            ds.Tables.Add(table);
            exp.showStuff(ds);

        }
        private void mnu_reg_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                frm_tarife_daryaft frmTd = new frm_tarife_daryaft();
                frmTd.ShowDialog();
                SetDataGrid();
            }
            catch
            {

                throw;
            }
        }

        private void mnu_rem_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (grdRecive.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);

                Guid id = (grdRecive.SelectedValue as dynamic).ID;
                Business.GetTreasuryBusiness().Delete(Business.GetTreasuryBusiness().GetById(id));
                SetDataGrid();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }

        }

        private void mnu_edit_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (grdRecive.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);

                Guid id = (grdRecive.SelectedValue as dynamic).ID;
                var frm_tarife_daryaft = new frm_tarife_daryaft(id);
                frm_tarife_daryaft.ShowDialog();
                SetDataGrid();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }

        }

        private void txt_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetDataGrid();
        }

        private void BtnExel_Click(object sender, RoutedEventArgs e)
        {
            set_to_excell(ss, cc);
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            var search = Business.GetTreasuryBusiness().GetByType(Common.Constants.TreasuryType.Recive);

            if (!txt_search.Text.Trim().IsNullOrEmpty())
                search = search.Where(i => i.TDate.Contains(txt_search.Text) || i.TNO.Contains(txt_search.Text));

            var vv = search.ToList().Select(
                  r => new
                  {
                      r.ID,
                      r.TDate,
                      r.TNO,
                      TPrice = r.TPrice.ToDouble().ToString(Localize.DoubleMaskType)
                  });

            StiReport report = new StiReport();

            report.Load(@".\\Report\\Bursary\\frm_list_daryaft.mrt");

            report.RegData("vv", vv);

            report.Show();

        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                frm_tarife_daryaft frmTd = new frm_tarife_daryaft();
                frmTd.ShowDialog();
                SetDataGrid();
            }
            catch
            {

                throw;
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (grdRecive.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);

                Guid id = (grdRecive.SelectedValue as dynamic).ID;
                var frm_tarife_daryaft = new frm_tarife_daryaft(id);
                frm_tarife_daryaft.ShowDialog();
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
                if (grdRecive.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);

                Guid id = (grdRecive.SelectedValue as dynamic).ID;
                Business.GetTreasuryBusiness().Delete(Business.GetTreasuryBusiness().GetById(id));
                SetDataGrid();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }
    }
}
