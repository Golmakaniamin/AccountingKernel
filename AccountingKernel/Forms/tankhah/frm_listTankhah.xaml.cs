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
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using Stimulsoft.Report;

namespace AccountingKernel.Forms.tankhah
{
    /// <summary>
    /// Interaction logic for frm_listTankhah.xaml
    /// </summary>
    public partial class frm_listTankhah : System.Windows.Window
    {
        Guid get_id = Guid.NewGuid();
           
        public frm_listTankhah()
        {
            InitializeComponent();
        }
        AccountingKernelEntities10 ak = new AccountingKernelEntities10();
        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

            List<Capital> LC = ak.Capitals.Where(i => i.CDate.Contains(txt_search.Text) || i.CNO.Contains(txt_search.Text)).ToList();
            grd_tankhah.ItemsSource = LC;
        }

        private void mnu_reg_Click_1(object sender, RoutedEventArgs e)
        {
            frm_add_tankhah frmat = new frm_add_tankhah();
            frmat.ShowDialog();

            if (pass_data.is_reg == 0)
            {
               
                var k = ak.Capitals.FirstOrDefault(i => i.ID == pass_data.id_capital);
                ak.Capitals.Remove(k);
                int ii = ak.SaveChanges();

                if (ii == 1)
                {
                    grd_tankhah.ItemsSource = ak.Capitals.ToList();
                }

                pass_data.is_reg = 0;

            }
            pass_data.is_reg = 0;
            grd_tankhah.ItemsSource = ak.Capitals.ToList();
            
            get_id = Guid.Empty;
        }

        private void mnu_edit_Click_1(object sender, RoutedEventArgs e)
        {
            // edit 
            if (get_id != Guid.Empty)
            {
                pass_data.get_id_for_edit = get_id;
                new frm_editTankhah().ShowDialog();
                pass_data.get_id_for_edit = Guid.Empty;
                get_id = Guid.Empty;
            }
            else
            {
                MessageBox.Show("مقداری جهت ویرایش یافت نشد");
            }
        }

        private void mnu_rem_Click_1(object sender, RoutedEventArgs e)
        {
            int a = 0;
            int c = 0;
            int a2 = 0;
            Capital cap = ak.Capitals.FirstOrDefault(i => i.ID == get_id);
            List<CapitalDetail> b = ak.CapitalDetails.Where(i => i.IDCapital == get_id).ToList();

            if (cap != null)
            {
                MessageBoxResult m = MessageBox.Show("آیا مایل به حذف میباشید", "حذف", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (m == MessageBoxResult.Yes)
                {
                    c = b.Count;

                    foreach (var item in b)
                    {
                        ak.CapitalDetails.Remove(item);
                        a += ak.SaveChanges();

                    }
                    ak.Capitals.Remove(cap);
                    a2 = ak.SaveChanges();

                    if (a == c && a2 == 1)
                    {
                        grd_tankhah.ItemsSource = ak.Capitals.ToList();
                        get_id = Guid.Empty;
                    }
                }
            }
            else
            {
                MessageBox.Show("مقداری جهت حذف یافت نشد");
            }
        }
        private void Window_Initialized_1(object sender, EventArgs e)
        {
            grd_tankhah.ItemsSource = ak.Capitals.ToList();
        }

        private void grd_tankhah_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Capital c = (Capital)grd_tankhah.SelectedItem;
                get_id = c.ID;
            }
            catch { }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            // get column name from grid

            string[] get_col = new string[grd_tankhah.Columns.Count];

            for (int i = 0; i <= grd_tankhah.Columns.Count - 1; i++)
            {

                get_col[i] = grd_tankhah.Columns[i].Header.ToString();

            }

            new Behaviours.importFromExcel(get_col).ShowDialog();
        }

        /// <summary>
        /// /// تابع حذف شیی
        /// </summary>
        /// <param name="obj"></param>
        private void releaseObject(object obj)
        {

            try
            {

                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);

                obj = null;

            }

            catch (Exception ex)
            {

                obj = null;

                MessageBox.Show("Unable to release the Object " + ex.ToString());

            }

            finally
            {

                GC.Collect();

            }

        }

  

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            frm_add_tankhah frmat = new frm_add_tankhah();
            frmat.ShowDialog();

            if (pass_data.is_reg == 0)
            {

                var k = ak.Capitals.FirstOrDefault(i => i.ID == pass_data.id_capital);
                ak.Capitals.Remove(k);
                int ii = ak.SaveChanges();

                if (ii == 1)
                {
                    grd_tankhah.ItemsSource = ak.Capitals.ToList();
                }

                pass_data.is_reg = 0;

            }
            pass_data.is_reg = 0;
            grd_tankhah.ItemsSource = ak.Capitals.ToList();

            get_id = Guid.Empty;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            // edit 
            if (get_id != Guid.Empty)
            {
                pass_data.get_id_for_edit = get_id;
                new frm_editTankhah().ShowDialog();
                pass_data.get_id_for_edit = Guid.Empty;
                get_id = Guid.Empty;
            }
            else
            {
                MessageBox.Show("مقداری جهت ویرایش یافت نشد");
            }
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            int a = 0;
            int c = 0;
            int a2 = 0;
            Capital cap = ak.Capitals.FirstOrDefault(i => i.ID == get_id);
            List<CapitalDetail> b = ak.CapitalDetails.Where(i => i.IDCapital == get_id).ToList();

            if (cap != null)
            {
                MessageBoxResult m = MessageBox.Show("آیا مایل به حذف میباشید", "حذف", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (m == MessageBoxResult.Yes)
                {
                    c = b.Count;

                    foreach (var item in b)
                    {
                        ak.CapitalDetails.Remove(item);
                        a += ak.SaveChanges();

                    }
                    ak.Capitals.Remove(cap);
                    a2 = ak.SaveChanges();

                    if (a == c && a2 == 1)
                    {
                        grd_tankhah.ItemsSource = ak.Capitals.ToList();
                        get_id = Guid.Empty;
                    }
                }
            }
            else
            {
                MessageBox.Show("مقداری جهت حذف یافت نشد");
            }
        }

        private void BtnExel_Click(object sender, RoutedEventArgs e)
        {
            var entities = ak.Capitals.ToList();
            var table = new System.Data.DataTable();
            table.Columns.Add("شماره", typeof(int));
            table.Columns.Add("تاریخ", typeof(string));
            table.Columns.Add("مبلغ", typeof(string));
            foreach (var entity in entities)
            {
                var row = table.NewRow();
                row["شماره"] = entity.CNO;
                row["تاریخ"] = entity.CDate;
                row["مبلغ"] = entity.CTotalPrice;
                table.Rows.Add(row);
            }

            //// -------

            DataSet ds = new DataSet("New_DataSet");
            ds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;
            ds.Tables.Add(table);


            //// baz kardane dialoge save 
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = ""; // Default file name
            dlg.DefaultExt = ".xls"; // Default file extension
            dlg.Filter = "Text documents (.xls)|*.xls"; // Filter files by extension
            Nullable<bool> result = dlg.ShowDialog();
            string filename = "";
            if (result == true)
            {
                filename = dlg.FileName;
                //ExcelLibrary.DataSetHelper.CreateWorkbook(filename, ds);
                // Step 2: Create the Excel .xlsx file
                try
                {
                    bool b = CreateExcelFile.CreateExcelDocument(ds, filename);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Couldn't create Excel file.\r\nException: " + ex.Message);
                    return;
                }
            }
            //// ---------
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
           List<Capital> LC=ak.Capitals.ToList();
            if (txt_search.Text.Trim().Length>0)
            {
               LC = ak.Capitals.Where(i => i.CDate.Contains(txt_search.Text) || i.CNO.Contains(txt_search.Text)).ToList();
            }
            else
           
                LC = ak.Capitals.ToList();
             
            StiReport report = new StiReport();

            report.Load(@"D:\New folder (2)\accountingKernel\AccountingKernel\Debug_AccountingKernel\Report\frm_listTankhah.mrt");

            report.RegData("LC", LC);

            report.Show();

        } 
    }
}
