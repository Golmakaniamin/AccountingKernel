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
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data;
using System.Collections.ObjectModel;
namespace AccountingKernel.Behaviours
{
    /// <summary>
    /// Interaction logic for importFromExcel.xaml
    /// </summary>
    /// 
    public class TicketInfo
    {
      /*  public string Subject { get; set; }*/
        public string Status { get; set; }
    }
    public class StatusList : List<string>
    {
      public static string ss;
        public StatusList()
        {

            string[] get_all = ss.Split(',');

            foreach (var item in get_all)
            {
                this.Add(item);    
            }

            
        }
    }




    public partial class importFromExcel : System.Windows.Window
    {

        public List<string> comboboxItemsSource { get; set; }
        string[] _col_names;
   
        public importFromExcel(string[] col_mames)
        {
            
            _col_names = col_mames;

            Array.Copy(col_mames, _col_names, col_mames.Length);



            InitializeComponent();


    
        }

        public importFromExcel()
        {

            InitializeComponent();
   
        }

        private void btn_SelectFile_Click(object sender, RoutedEventArgs e)
        {

            // invisible all columns 
            for (int i = 0; i <= grd_t.Columns.Count - 1; i++)
            {
                grd_t.Columns[i].Visibility = System.Windows.Visibility.Hidden;
            }
            // --


            System.Data.DataTable dt = new System.Data.DataTable();

            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;

            string str;

            // baz kardane kadre opne jahate entekhabe file excel
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = ""; // Default file name
            dlg.DefaultExt = ".xls"; // Default file extension
            dlg.Filter = "Text documents (.xls)|*.xls| Excel Document 2007-2013 (.xlsx)|*.xlsx"; // Filter files by extension
            Nullable<bool> result = dlg.ShowDialog();
            string filename = "";
            if (result == true)
            {
                filename = dlg.FileName;

            }
            // ----------

            xlWorkBook = xlApp.Workbooks.Open(filename, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            range = xlWorkSheet.UsedRange;

            string[] get_header_xls = new string[range.Columns.Count];
            string[] get_header_grd = new string[grd_t.Columns.Count];

            for (int j = 0; j <= range.Columns.Count - 1; j++)
            {
                get_header_xls[j] = (range.Cells[1, j + 1] as Excel.Range).Value2 + "";
            }

            for (int p = 0; p <= grd_t.Columns.Count - 1; p++)
            {
                get_header_grd[p] = grd_t.Columns[p].Header.ToString();
            }

            grd_t.AutoGenerateColumns = true;


            dt.Clear();
            int hh = 1;
            DataRow dr = dt.NewRow();
            grd_t.AutoGenerateColumns = false;
            int cc = 0;
            int count_c = 0;
            bool has_column = false;
            /////////////// namayeshe sotonhaye Excel darone GRID
            string get_ = "";
            for (int tt = 1; tt <= range.Rows.Count; tt++)
            {
                for (cc = 1; cc <= range.Columns.Count; cc++)
                {
                    //str = (range.Cells[1, cc] as Excel.Range).Value2.ToString();

                   // for (int i = 0; i <= grd_t.Columns.Count - 1; i++)
                  //  {
                       // if (str.Trim() == grd_t.Columns[i].Header.ToString().Trim())
                       // {
                   
                          //  count_c = 0;
                            // string get_ = "";
                            get_ = (range.Cells[1, cc] as Excel.Range).Value2.ToString();
                            if (tt == 1)
                            {
                                dt.Columns.Add(get_);
                            }
                            else
                            {
                                dr[get_] = (range.Cells[tt, cc] as Excel.Range).Value2.ToString();
                            }
                           // break;
                       // }
                        /*else
                        {
                            count_c++;
                            if (count_c == grd_t.Columns.Count)
                            {
                                if (tt == 1)
                                {
                                    MessageBoxResult mdr = MessageBox.Show(" ستون " + " ' " + str + " ' " + "  در جدول یافت نشد آیا مایل به اضافه شدن ستون میباشید ؟", "", MessageBoxButton.YesNo);
                                    if (mdr == MessageBoxResult.Yes)
                                    {
                                        dt.Columns.Add(str);
                                        has_column = true;
                                    }

                                    count_c = 0;
                                }
                                else if (has_column == true)
                                { dr[str] = (range.Cells[tt, cc] as Excel.Range).Value2.ToString(); }

                            }
                        }*/

                   // }

                  //  hh++;
       
                }

                dr = dt.NewRow();
                dt.Rows.Add(dr);
            }


            // get excel col
            // string[] exCol = new string[range.Columns.Count];

            string exCol = "";
            for (int j = 0; j <= range.Columns.Count - 1; j++)
            {
                exCol  += (range.Cells[1, j + 1] as Excel.Range).Value2 + ",";
            }

            //// ----
            grd_t.AutoGenerateColumns = true;
            xlWorkBook.Close(true, null, null);
            xlApp.Quit();
            
            //  تابع حذف شیی
            /* ------------------------------------------------------------- */

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
            grd_t.ItemsSource = dt.DefaultView;

            
            
            
            StatusList.ss = exCol;
    


            List<TicketInfo> tl = new List<TicketInfo>();
            foreach (var item in _col_names)
            {
                TicketInfo t = new TicketInfo {  Status = item };
               
                
                tl.Add(t);
                
            }
            grd_m.ItemsSource = tl;
            grd_m.CanUserAddRows = false;

            //System.Data.DataTable dt1 = new System.Data.DataTable();

            //dt1.Columns.Add("فیلدهای جدول", typeof(string));

            

            //foreach (var item in _col_names)
            //{
            //    var row = dt1.NewRow();

            //    row["فیلدهای جدول"] = item;
            //    dt1.Rows.Add(row);
                
            //}


            //grd_colNames.ItemsSource = dt1.DefaultView;
            


        }
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
    


        }
    }
}
 