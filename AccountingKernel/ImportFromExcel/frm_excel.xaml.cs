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
using Excel1 = Microsoft.Office.Interop.Excel; 

namespace AccountingKernel.ImportFromExcel
{
    public class ExcellGridRow
    {
        public string MainGridCols { get; set; }
        public string ExcellCol { get; set; }
    }

    public class ItemList : List<string>
    {
        public static string get_Excell_columns;

        public ItemList()
        {

            string[] get_string = get_Excell_columns.Split(',');

            foreach (var item in get_string)
            {
                this.Add(item);
            }

        }
    }


    /// <summary>
    /// Interaction logic for frm_excel.xaml
    /// </summary>
    public partial class frm_excel : Window
    {
        public frm_excel()
        {
            InitializeComponent();
        }

        string[] get_grid_header_names;
        public frm_excel(DataGrid dg)
        {
            InitializeComponent();

            get_grid_header_names = new string[dg.Columns.Count];

            for (int i = 0; i <= dg.Columns.Count - 1; i++)
            {
                get_grid_header_names[i] = dg.Columns[i].Header.ToString();

            }
        }

        public frm_excel(string[] columns_name)
        {
            InitializeComponent();

            get_grid_header_names = new string[columns_name.Length];
            for (int i = 0; i <= columns_name.Length - 1; i++)
            {
                get_grid_header_names[i] = columns_name[i];
            }

        }


        // variables 

        AccountingKernelEntities ak = new AccountingKernelEntities();
        string get_glob_files = "";
        Excel1.Application xlApp;
        Excel1.Workbook xlWorkBook;
        Excel1.Worksheet xlWorkSheet;
        Excel1.Range range;
        string[,] array_f_excel;

        private void btn_get_data_Click(object sender, RoutedEventArgs e)
        {
               
                ItemList.get_Excell_columns = getExcelColumns();
                if (ItemList.get_Excell_columns != "")
                {
                    List<ExcellGridRow> ticketList = new List<ExcellGridRow>();
                    ExcellGridRow[] ti = new ExcellGridRow[get_grid_header_names.Length];
                    for (int i = 0; i <= get_grid_header_names.Length - 1; i++)
                    {
                        ti[i] = new ExcellGridRow();
                        ti[i].ExcellCol = "انتخاب کنید";
                        // ti[i].MainGridCols = "Item " + (i + 1).ToString();
                        ti[i].MainGridCols = get_grid_header_names[i];

                        ticketList.Add(ti[i]);
                    }

                    grd_excel.ItemsSource = ticketList;
                }
        }


        private string getExcelColumns()
        {
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
            //get_glob_files = filename;
            if (filename != "")
            {
                string str;
                int cCnt = 0;
                xlApp = new Excel1.Application();
            

                xlWorkBook = xlApp.Workbooks.Open(filename, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                xlWorkSheet = (Excel1.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                range = xlWorkSheet.UsedRange;

                string get_column_mames = "";

                for (cCnt = 1; cCnt <= range.Columns.Count; cCnt++)
                {
                    str = (string)(range.Cells[1, cCnt] as Excel1.Range).Value2.ToString();
                    get_column_mames += str + ",";
                }


                return get_column_mames;
            }
            else
            {
                return String.Empty;
            }

     
        }

        private void btn_rev_data_Click(object sender, RoutedEventArgs e)
        {

            if (range != null)
            {
                string str = "";
                int num_dataGrid_col = get_grid_header_names.Length;
                int num_excel_row = range.Rows.Count - 1;

                int c = 1;
                // int c = 0;
                /*string[,]*/
                array_f_excel = new string[num_excel_row + 1, num_dataGrid_col];
                //array_f_excel = new string[num_excel_row, num_dataGrid_col];
                // all valuae must be selected
                /////////////////////////////////////////////////////
                // check all row for has valid selection
                bool check_all_row = true;
                for (int cac = 0; cac <= /*range.Rows.Count - 2*/ get_grid_header_names.Length - 1; cac++)
                {
                    DataGridRow row = this.grd_excel.ItemContainerGenerator.ContainerFromIndex(cac) as DataGridRow;
                    ExcellGridRow v = row.Item as ExcellGridRow;

                    if (v.ExcellCol == "انتخاب کنید")
                    {
                        check_all_row = false;
                    }

                }
                ////////////////////////////////////////////////////
                bool check_all_row_for_dublication = true;
                for (int card = 0; card <= /*range.Rows.Count - 2*/ get_grid_header_names.Length - 1; card++)
                {
                    DataGridRow row = this.grd_excel.ItemContainerGenerator.ContainerFromIndex(card) as DataGridRow;
                    ExcellGridRow v = row.Item as ExcellGridRow;

                    for (int ci = 0; ci <= /*range.Rows.Count - 2*/ get_grid_header_names.Length - 1; ci++)
                    {

                        DataGridRow row_i = this.grd_excel.ItemContainerGenerator.ContainerFromIndex(ci) as DataGridRow;
                        ExcellGridRow v_i = row_i.Item as ExcellGridRow;


                        if (ci != card)
                        {
                            if (v.ExcellCol == v_i.ExcellCol)
                            {
                                check_all_row_for_dublication = false;
                            }
                        }

                    }

                }
                /////////////////////////////////////////////////////

                if (check_all_row == false)
                {
                    MessageBox.Show("لطفا تمام موارد را انتخاب نمایید");
                }

                if (check_all_row_for_dublication == false)
                {
                    MessageBox.Show("موارد تکراری قابل قبول نمیباشد");
                }

                /// در صورت وارد شدن مقادیر


                if (check_all_row && check_all_row_for_dublication)
                {
                    for (int i = 0; i <= get_grid_header_names.Length - 1; i++)
                    {
                        DataGridRow row = this.grd_excel.ItemContainerGenerator.ContainerFromIndex(i) as DataGridRow;
                        ExcellGridRow v = row.Item as ExcellGridRow;

                        for (int cCnt = 1; cCnt <= range.Columns.Count; cCnt++)
                        {
                            str = (string)(range.Cells[1, cCnt] as Excel1.Range).Value2.ToString();

                            if (v.ExcellCol == str)
                            {
                                ////  get col data and set to array 
                                for (int r = 2; r <= range.Rows.Count; r++)
                                {
                                    array_f_excel[0, i] = str;


                                    if ((range.Cells[r, cCnt] as Excel1.Range).Value2 != null)
                                    {
                                        array_f_excel[c, i] = (string)(range.Cells[r, cCnt] as Excel1.Range).Value2.ToString();
                                        c++;
                                    }
                                    else
                                    {
                                        MessageBox.Show("");
                                    }
                                }
                                c = 1;
                                break;
                            }
                        }

                    }

                    this.Hide();
                }
                // return array
            }
            else
            {

                MessageBox.Show("فایلی انتخاب نشده است");
            }
        }

        public string[,] get_data_array()
        {
            return array_f_excel;
        }


        public string get_data_by_name_index(string name , int pos)
        {
            // search cols 

            for (int i = 0; i <= array_f_excel.GetLength(1) - 1; i++)
            {
                if (array_f_excel[0, i] == name)
                {
                    return array_f_excel[pos, i];
                }
            }

            return String.Empty;
        }
        private void grd_excel_AutoGeneratedColumns(object sender, EventArgs e)
        {

        }
    }

    }

