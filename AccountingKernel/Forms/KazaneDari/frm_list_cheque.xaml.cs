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
using System.Data;
using Stimulsoft.Report;

namespace AccountingKernel.Forms.KazaneDari
{
    /// <summary>
    /// Interaction logic for frm_list_cheque.xaml
    /// </summary>
    public partial class frm_list_cheque : Window
    {
        string[,] ss;
        int cc; 

        public frm_list_cheque()
        {
            InitializeComponent();
        }

        AccountingKernelEntities10 ak = new AccountingKernelEntities10();
        string ID = "";
        private void mnu_reg_Click_1(object sender, RoutedEventArgs e)
        {
            frm_tarife_cheque tc = new frm_tarife_cheque();
            tc.ShowDialog();
            grid_cheque.ItemsSource = ak.Checks.ToList();
        }

        private void mnu_edit_Click_1(object sender, RoutedEventArgs e)
        {
            frm_cheque_edit frmCheckEdit = new frm_cheque_edit();

            if (ID != "")
            {
                //get_set_moien_id.moien_id_ = ID;
                pass_data._ID_ = ID;
                frmCheckEdit.ShowDialog();
                this.InvalidateVisual();


             /*   ListCollectionView Set_All_User = new ListCollectionView(Business.GetAccountingMoeinBusiness().GetAll().ToList());
                Set_All_User.GroupDescriptions.Add(new PropertyGroupDescription("MIdGroup"));*/
                //grd_moien.ItemsSource = Set_All_User;


            }
            else
            {
                MessageBox.Show("مقداری جهت ویرایش یافت نشده است", "خطا", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void mnu_rem_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBoxResult m = MessageBox.Show("آیا مایل به حذف رکورد میباشید" + Environment.NewLine + "", "حذف رکورد", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (m == MessageBoxResult.Yes)
            {
                if (ID != "")
                {
                    Guid g = Guid.Parse(ID);

                    var lst = ak.Checks.Where(i => i.ID == g).FirstOrDefault();
                    var get_from_chP = ak.CheckProcesses.Where(i => i.IDCheck == lst.ID).FirstOrDefault();

                    ak.Checks.Remove(lst);
                    int r = ak.SaveChanges();

                    ak.CheckProcesses.Remove(get_from_chP);
                    r += ak.SaveChanges();


                    if (r > 1)
                    {
                        grid_cheque.ItemsSource = ak.Checks.ToList();
                    }
                    ID = "";
                }

            }
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
           
        }

        private void grid_cheque_Initialized(object sender, EventArgs e)
        {
            grid_cheque.ItemsSource = ak.Checks.ToList();

            var v = ak.Checks.ToList();
                cc = v.Count();
                ss = new string[cc,6];
                int ii = 0;
                foreach (var item in v)
                {
                    string Sh_Ch = item.CNO;
                    string Sh_H = item.CAccountnumber;
                    string Mablagh = item.CPrice.ToString();
                    string Babat = item.CDescription;
                    string Ta = item.CDate;
                    string N_S_Ch = item.CName;

                    ss[ii, 0] = Sh_Ch;
                    ss[ii, 1] = Sh_H;
                    ss[ii, 2] = Mablagh;
                    ss[ii, 3] = Babat;
                    ss[ii, 4] = Ta;
                    ss[ii, 5] = N_S_Ch;
                    ii++;
                }            
       
        }
           private void set_to_excell(string[,] a, int rowC)
        {
            ExcelImpExp.ExportToExcel exp = new ExcelImpExp.ExportToExcel();
            var table = new System.Data.DataTable();


            table = exp.get_dataGridColumnNames(grid_cheque);

            for (int i = 0; i <= rowC - 1; i++)
            {
                var row = table.NewRow();
                /*
                row[this.grid_asnad.Columns[i + 1].Header.ToString()] = int.Parse(a[i, 0].ToString());
                row[this.grid_asnad.Columns[i + 1].Header.ToString()] = a[i, 1];
                row[this.grid_asnad.Columns[i + 1].Header.ToString()] = a[i, 2];
                row[this.grid_asnad.Columns[i + 1].Header.ToString()] = a[i, 3];
               */

                for (int j = 0; j <=5; j++)
                {
                    if (j == 0)
                        row[this.grid_cheque.Columns[j + 1].Header.ToString()] = int.Parse(a[i, j].ToString());
                    else
                        row[this.grid_cheque.Columns[j ].Header.ToString()] = a[i, j];
                }

                table.Rows.Add(row);
            }


            DataSet ds = new DataSet("New_DataSet");
            ds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;
            ds.Tables.Add(table);
            exp.showStuff(ds);

        }
        private void grid_cheque_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

                Check am = (Check)grid_cheque.SelectedItem;
                ID = am.ID.ToString();
            }
            catch { }
        }

        private void txt_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_search.Text.Length > 0)
            {
                List<Check> LC = ak.Checks.Where(i => i.CDate.Contains(txt_search.Text) || i.CNO.Contains(txt_search.Text) || i.CDescription.Contains(txt_search.Text)).ToList();
                grid_cheque.ItemsSource = LC;
            }
            else 
            {
                grid_cheque.ItemsSource = ak.Checks.ToList();
                
            }
        }

        private void BtnExel_Click(object sender, RoutedEventArgs e)
        {
            set_to_excell(ss, cc);
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            StiReport report = new StiReport();

            IQueryable<Check> t = ak.Checks;

            var iqCheck = t;

            if (txt_search.Text.Trim().Length > 0)
            {
                iqCheck = ak.Checks.Where(i => i.CDate.Contains(txt_search.Text) || i.CNO.Contains(txt_search.Text) || i.CDescription.Contains(txt_search.Text));
            }
           // iqBasedInfo = iqBasedInfo.Where(i => i.PID == this.BaseInfoTypeId);

            report.Load(@"D:\New folder (2)\accountingKernel\AccountingKernel\Debug_AccountingKernel\Report\frm_list_cheque.mrt");

            report.RegData("iqCheck_", iqCheck);

            report.Show();
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            frm_tarife_cheque tc = new frm_tarife_cheque();
            tc.ShowDialog();
            grid_cheque.ItemsSource = ak.Checks.ToList();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            frm_cheque_edit frmCheckEdit = new frm_cheque_edit();

            if (ID != "")
            {
                //get_set_moien_id.moien_id_ = ID;
                pass_data._ID_ = ID;
                frmCheckEdit.ShowDialog();
                this.InvalidateVisual();


                /*   ListCollectionView Set_All_User = new ListCollectionView(Business.GetAccountingMoeinBusiness().GetAll().ToList());
                   Set_All_User.GroupDescriptions.Add(new PropertyGroupDescription("MIdGroup"));*/
                //grd_moien.ItemsSource = Set_All_User;


            }
            else
            {
                MessageBox.Show("مقداری جهت ویرایش یافت نشده است", "خطا", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult m = MessageBox.Show("آیا مایل به حذف رکورد میباشید" + Environment.NewLine + "", "حذف رکورد", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (m == MessageBoxResult.Yes)
            {
                if (ID != "")
                {
                    Guid g = Guid.Parse(ID);

                    var lst = ak.Checks.Where(i => i.ID == g).FirstOrDefault();
                    var get_from_chP = ak.CheckProcesses.Where(i => i.IDCheck == lst.ID).FirstOrDefault();

                    ak.Checks.Remove(lst);
                    int r = ak.SaveChanges();

                    ak.CheckProcesses.Remove(get_from_chP);
                    r += ak.SaveChanges();


                    if (r > 1)
                    {
                        grid_cheque.ItemsSource = ak.Checks.ToList();
                    }
                    ID = "";
                }

            }
        }

        private void btn_Geteport_Click(object sender, RoutedEventArgs e)
        {
            string col_names = "";
            
            for (int i = 0; i <= grid_cheque.Columns.Count - 1; i++)
            {
                col_names += "," + grid_cheque.Columns[i].Header.ToString();
            }

            string[] arr_column_names = col_names.Split(',');

            var v = ak.Checks.ToList();

            IQueryable a = v.AsQueryable();


            Report.frm_report frm_rep = new Report.frm_report(a);
 
            frm_rep.Show();
             

        }

    }
}
