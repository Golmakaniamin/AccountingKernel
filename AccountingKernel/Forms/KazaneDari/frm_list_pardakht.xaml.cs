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
    /// Interaction logic for frm_list_pardakht.xaml
    /// </summary>
    public partial class frm_list_pardakht : Window
    {
        string[,] ss;
        int cc; 

        public frm_list_pardakht()
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

        private void mnu_reg_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                var td = new frm_tarife_pardakht();
                td.ShowDialog();
                SetDataGrid();
            }
            catch
            {

                throw;
            }
        }

        private void mnu_edit_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (grdpardakht.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);

                Guid id = (grdpardakht.SelectedValue as dynamic).ID;
                var frm_tarife_daryaft = new frm_tarife_pardakht(id);
                frm_tarife_daryaft.ShowDialog();
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
                if (grdpardakht.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);

                Guid id= (grdpardakht.SelectedValue as dynamic).ID;
                Business.GetTreasuryBusiness().Delete(Business.GetTreasuryBusiness().GetById(id));
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
                if (txt_search.Text.Length>0)
                {
                    grdpardakht.ItemsSource = Business.GetTreasuryBusiness().GetByType(Common.Constants.TreasuryType.Payment).ToList().Select(
                    r => new
                    {
                        r.ID,
                        r.TDate,
                        r.TNO,
                        TPrice = r.TPrice.ToDouble().ToString(Localize.DoubleMaskType)
                    }).Where(i => i.TDate.Contains(txt_search.Text) || i.TNO.Contains(txt_search.Text) || i.TPrice.Contains(txt_search.Text)); 
                }
                else
                {
                    grdpardakht.ItemsSource = Business.GetTreasuryBusiness().GetByType(Common.Constants.TreasuryType.Payment).ToList().Select(
                   r => new
                   {
                       r.ID,
                       r.TDate,
                       r.TNO,
                       TPrice = r.TPrice.ToDouble().ToString(Localize.DoubleMaskType)
                   });

                }
               
             
                var v = Business.GetTreasuryBusiness().GetByType(Common.Constants.TreasuryType.Payment).ToList();
                cc = v.Count();
                ss = new string[cc,3];
                int ii = 0;
                foreach (var item in v)
                {
                    string Code = item.TNO;
                    string Ta = item.TDate;
                    string Mablagh = item.TPrice.ToString();

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


            table = exp.get_dataGridColumnNames(grdpardakht);

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
                    if (j == 0)
                        row[this.grdpardakht.Columns[j + 1].Header.ToString()] = int.Parse(a[i, j].ToString());
                    else
                        row[this.grdpardakht.Columns[j + 1].Header.ToString()] = a[i, j];
                }

                table.Rows.Add(row);
            }


            DataSet ds = new DataSet("New_DataSet");
            ds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;
            ds.Tables.Add(table);
            exp.showStuff(ds);

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

            if (txt_search.Text.Trim().Length > 0)
            {
                var v = Business.GetTreasuryBusiness().GetByType(Common.Constants.TreasuryType.Payment).ToList().Select(
                r => new
                {
                    r.ID,
                    r.TDate,
                    r.TNO,
                    TPrice = r.TPrice.ToDouble().ToString(Localize.DoubleMaskType)
                }).Where(i => i.TDate.Contains(txt_search.Text) || i.TNO.Contains(txt_search.Text) || i.TPrice.Contains(txt_search.Text));

                StiReport report = new StiReport();
                report.Load(@".\\Report\\Bursary\\frm_list_pardakht.mrt");
                report.RegData("v", v);
                report.Show();
            }
            else
            {
                var v = Business.GetTreasuryBusiness().GetByType(Common.Constants.TreasuryType.Payment).ToList().Select(
               r => new
               {
                   r.ID,
                   r.TDate,
                   r.TNO,
                   TPrice = r.TPrice.ToDouble().ToString(Localize.DoubleMaskType)
               });
                StiReport report = new StiReport();
                report.Load(@".\\Report\\Bursary\\frm_list_pardakht.mrt");
                report.RegData("v", v);
                report.Show();
            }
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var td = new frm_tarife_pardakht();
                td.ShowDialog();
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
                if (grdpardakht.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);

                Guid id = (grdpardakht.SelectedValue as dynamic).ID;
                var frm_tarife_daryaft = new frm_tarife_pardakht(id);
                frm_tarife_daryaft.ShowDialog();
                SetDataGrid();
            }
            catch
            {

                throw;
            }
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (grdpardakht.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);

                Guid id = (grdpardakht.SelectedValue as dynamic).ID;
                Business.GetTreasuryBusiness().Delete(Business.GetTreasuryBusiness().GetById(id));
                SetDataGrid();
            }
            catch
            {

                throw;
            }
        }

    }
}
