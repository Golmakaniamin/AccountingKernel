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
using Data;
using Common;
using System.Data;
using Stimulsoft.Report;

namespace AccountingKernel.Forms.baseInfo
{
    /// <summary>
    /// Interaction logic for frm_list_bank.xaml
    /// </summary>
    public partial class frm_list_bank : Window
    {
        string[,] ss;
        int cc; 
        AccountingKernelEntities10 ak = new AccountingKernelEntities10();

        public frm_list_bank()
        {
            InitializeComponent();
            SetDataGrid();
        }

        private void SetDataGrid()
        {
            grid_listeBank.ItemsSource = Business.GetFundsBusiness().GetByFType(Common.Constants.BankType.Bank).ToList();
        }

        string ID = "";
        private void mnu_reg_Click_1(object sender, RoutedEventArgs e)
        {
            frm_tarife_bank tb = new frm_tarife_bank();
            tb.ShowDialog();
            SetDataGrid();
        }

        private void mnu_edit_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (grid_listeBank.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);

                var frmeb = new frm_tarife_bank((grid_listeBank.SelectedValue as dynamic).ID);

                frmeb.ShowDialog();
                this.InvalidateVisual();

                SetDataGrid();


            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void mnu_rem_Click_1(object sender, RoutedEventArgs e)
        {
            if (ID != "")
            {
                MessageBoxResult m = MessageBox.Show("آیا مایل به حذف رکورد میباشید" + Environment.NewLine + "", "حذف رکورد", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (m == MessageBoxResult.Yes)
                {

                    Guid selectedID = Guid.Parse(ID);


                    var v = ak.Funds.Where(i => i.ID == selectedID).FirstOrDefault();
                    ak.Funds.Remove(v);
                    ak.SaveChanges();

                    SetDataGrid();
                    ID = "";
                }
            }
            else
            {
                MessageBox.Show("مقداری جهت حذف یافت نشده است", "حذف رکورد", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void mnu_cheque_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (grid_listeBank.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);

                var frmChequeDecleration = new FrmChequeDecleration((grid_listeBank.SelectedValue as dynamic).ID);
                frmChequeDecleration.ShowDialog();
                SetDataGrid();

            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }


        private void Window_Initialized_1(object sender, EventArgs e)
        {
            SetDataGrid();
            var v = Business.GetFundsBusiness().GetByFType(Common.Constants.BankType.Bank).ToList();
            cc = v.Count();
            ss = new string[cc, 5];
            int ii = 0;
            foreach (var item in v)
            {
                string N_S_H = item.FName;
                string Bank = item.FBank;
                string Sh = item.Fbranch;
                string Neshani = item.FAddress;
                string Mojudi = item.Fprice.ToString();


                ss[ii, 0] = N_S_H;
                ss[ii, 1] = Bank;
                ss[ii, 2] = Sh;
                ss[ii, 3] = Neshani;
                ss[ii, 4] = Mojudi;
               
                ii++;
            }         
        }
private void set_to_excell(string[,] a, int rowC)
        {
            ExcelImpExp.ExportToExcel exp = new ExcelImpExp.ExportToExcel();
            var table = new System.Data.DataTable();


            table = exp.get_dataGridColumnNames(grid_listeBank);

            for (int i = 0; i <= rowC - 1; i++)
            {
                var row = table.NewRow();
                /*
                row[this.grid_asnad.Columns[i + 1].Header.ToString()] = int.Parse(a[i, 0].ToString());
                row[this.grid_asnad.Columns[i + 1].Header.ToString()] = a[i, 1];
                row[this.grid_asnad.Columns[i + 1].Header.ToString()] = a[i, 2];
                row[this.grid_asnad.Columns[i + 1].Header.ToString()] = a[i, 3];
               */

                for (int j = 0; j <= 4; j++)
                {
                    //if (j == 0)
                    //    row[this.grid_listeBank.Columns[j + 1].Header.ToString()] = int.Parse(a[i, j].ToString());
                    //else
                        row[this.grid_listeBank.Columns[j + 1].Header.ToString()] = a[i, j];
                }

                table.Rows.Add(row);
            }


            DataSet ds = new DataSet("New_DataSet");
            ds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;
            ds.Tables.Add(table);
            exp.showStuff(ds);

        }


        private void grid_listeBank_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Fund am = (Fund)grid_listeBank.SelectedItem;
                ID = am.ID.ToString();
            }
            catch { }
        }

        private void grid_listeBank_InitializingNewItem(object sender, InitializingNewItemEventArgs e)
        {

        }

        private void grid_listeBank_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
           
            try
            {
                var iqFund = Business.GetFundsBusiness().GetAll();

                if (txtSearch.Text.Trim().Length > 0)
                    iqFund = iqFund.Where(r => r.FBank.Contains(txtSearch.Text));

                grid_listeBank.ItemsSource = iqFund.Where(i => i.FType == Common.Constants.BankType.Bank).ToList();

                var v = iqFund.ToList();
                cc = v.Count();
                ss = new string[cc, 1];
                int ii = 0;
                foreach (var item in v)
                {
                    string Name = item.FBank;


                    ss[ii, 0] = Name;

                    ii++;
                }



            }
            catch
            {

                throw;
            }
        }

        private void BtnExel_Click(object sender, RoutedEventArgs e)
        {

            set_to_excell(ss, cc);
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
             StiReport report = new StiReport();

             IQueryable<Fund> t = ak.Funds;

             var iqFund = t;

            if (txtSearch.Text.Trim().Length > 0)
                iqFund = iqFund.Where(r => r.FBank.Contains(txtSearch.Text));

                iqFund = iqFund.Where(i => i.FType == Common.Constants.BankType.Bank);

                report.Load(@"D:\New folder (2)\accountingKernel\AccountingKernel\Debug_AccountingKernel\Report\frm_list_bank.mrt");

                report.RegData("iqFund", iqFund);

                report.Show();

        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            frm_tarife_bank tb = new frm_tarife_bank();
            tb.ShowDialog();
            SetDataGrid();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (grid_listeBank.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);

                var frmeb = new frm_tarife_bank((grid_listeBank.SelectedValue as dynamic).ID);

                frmeb.ShowDialog();
                this.InvalidateVisual();

                SetDataGrid();


            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            if (ID != "")
            {
                MessageBoxResult m = MessageBox.Show("آیا مایل به حذف رکورد میباشید" + Environment.NewLine + "", "حذف رکورد", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (m == MessageBoxResult.Yes)
                {

                    Guid selectedID = Guid.Parse(ID);


                    var v = ak.Funds.Where(i => i.ID == selectedID).FirstOrDefault();
                    ak.Funds.Remove(v);
                    ak.SaveChanges();

                    SetDataGrid();
                    ID = "";
                }
            }
            else
            {
                MessageBox.Show("مقداری جهت حذف یافت نشده است", "حذف رکورد", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
