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
using Data;

namespace AccountingKernel.ImportFromExcel
{
    class ImportFromExcelSG
    {
         Guid code_grouhe_asli = Guid.Parse("6AA60230-EFA2-4C80-B115-A286E3F501C7");
         Guid code_grouhe_fari = Guid.Parse("6CF8AD93-7909-4A64-8B43-C91AD8415B42");
         Guid code_kala = Guid.Parse("6b2468f0-07a3-4437-b104-3b3153b1d7cb");

        AccountingKernelEntities10 ak = new AccountingKernelEntities10();
        //string get_glob_files = "";
        Excel1.Application xlApp;
        Excel1.Workbook xlWorkBook;
        Excel1.Worksheet xlWorkSheet;
        Excel1.Range range;
        //string[,] array_f_excel;

        public ImportFromExcelSG()
        {
            
        }

         public void add_to_table_GoodiesGroup()
         {
             string[] excel_col_names = { "گروه اصلی", "گروه فرعی", "کالا", "کد گروه اصلی", "کد گروه فرعی", "کد کالا" };
             // barresi vojode grouhe asli va grouhe fari dar excel  
             string[] gcn = getExcelColumns().Split(',');
             int item_count = 0;
             int col_count = 6;
             string[] get_content = new string[col_count];
             foreach (var item in gcn)
             {
                 if (item == "گروه اصلی" || item == "گروه فرعی" || item == "کالا" || item == "کد گروه اصلی" || item == "کد گروه فرعی" || item == "کد کالا" )  //check kardane sar sotonha dar excel
                 {
                     item_count++;
                 }
             }

             // barresi vojode grouhe asli va grouhe fari excel dar DataBase
             //string g = (string)(range.Cells[1, 2] as Excel1.Range).Value2.ToString();
             //MessageBox.Show(range.Rows.Count.ToString()); 
             // make log array

             string [] log_array = new string[range.Rows.Count - 1];

             for (int handle_rows_idx = 2, log_array_idx = 0; handle_rows_idx <= range.Rows.Count; handle_rows_idx++, log_array_idx++)
             {
                 if (item_count == col_count)
                 {
                     //check for grouh asli 
                     // check excel col validation 
                     //..
                     //..
                     //..
                     //..
                     for (int handle_i = 0, j = 0; handle_i <= col_count - 1; handle_i++)
                     {
                         for (int i = 1; i <= col_count; i++)
                         {
                             string get_header = (string)(range.Cells[1, i] as Excel1.Range).Value2.ToString();
                             if (get_header == excel_col_names[handle_i])
                             {
                                 switch (get_header)
                                 {
                                     case "گروه اصلی":
                                         get_content[0] = get_content[j] = (string)(range.Cells[handle_rows_idx, i] as Excel1.Range).Value2.ToString();
                                         break;
                                     case "گروه فرعی":
                                         get_content[1] = get_content[j] = (string)(range.Cells[handle_rows_idx, i] as Excel1.Range).Value2.ToString();
                                         break;
                                     case "کالا":
                                         get_content[2] = get_content[j] = (string)(range.Cells[handle_rows_idx, i] as Excel1.Range).Value2.ToString();
                                         break;
                                     case "کد گروه اصلی":
                                         get_content[3] = get_content[j] = (string)(range.Cells[handle_rows_idx, i] as Excel1.Range).Value2.ToString();
                                         break;
                                     case "کد گروه فرعی":
                                         get_content[4] = get_content[j] = (string)(range.Cells[handle_rows_idx, i] as Excel1.Range).Value2.ToString();
                                         break;
                                     case "کد کالا":
                                         get_content[5] = get_content[j] = (string)(range.Cells[handle_rows_idx, i] as Excel1.Range).Value2.ToString();
                                         break;
                                 }

                                 j++;
                                 break;
                             }
                         }
                     }
                     // check names in data base 

                     string get_grouhe_asli_unique_path;
                     string get_grouhe_fari_unique_path;

                     string ga = get_content[0]; // grouhe asli
                     string gf = get_content[1]; // grouhe fari
                     //
                     // 1 - groh asli ...
                     bool grouhe_asli_exist = ak.GoodiesGroups.Any(i => i.CName == ga && i.CodeTitleId == code_grouhe_asli);

                     // gereftane grohefari marbootbe grouhe asli 
                     
                     // LOG ...
                     log_array[log_array_idx] = get_content[0] + "," + get_content[1] + "," + get_content[2];

                     //
                     if (grouhe_asli_exist)
                     {
                         get_grouhe_asli_unique_path = ak.GoodiesGroups.FirstOrDefault(i => i.CName == ga && i.CodeTitleId == code_grouhe_asli
                            ).ID.ToString(); // gereftane code grouhe asli
                         //
                         bool grouhe_fari_marbot_be_asli = ak.GoodiesGroups.Any(i => i.CName == gf && i.CodeTitleId ==
                             code_grouhe_fari &&
                             i.uniquepath.Contains(get_grouhe_asli_unique_path)  // grouh haye fari
                             );

                         if (grouhe_fari_marbot_be_asli)
                         {

                             var get_all_grohe_fari_marbot_be_1_grouhe_asli = ak.GoodiesGroups.Where(/*i => i.CName == gf &&*/i => i.CodeTitleId ==
                                 code_grouhe_fari &&
                                 i.uniquepath.Contains(get_grouhe_asli_unique_path)  // hame grouhaye fari asli
                                 ).ToList();

                             bool is_gouhe_fari_grouhe_asli_exist = false;

                             foreach (var get_grouhe_fari in get_all_grohe_fari_marbot_be_1_grouhe_asli)
                             {
                                 if (get_grouhe_fari.CName == gf) // grouhe fari peyda shod 
                                 {
                                     is_gouhe_fari_grouhe_asli_exist = true;
                                     // gereftane grouhe_fari_unique path
                                     get_grouhe_fari_unique_path = ak.GoodiesGroups.FirstOrDefault(i => i.CName == gf && i.CodeTitleId ==
                                     code_grouhe_fari && i.uniquepath.Contains(get_grouhe_asli_unique_path)).uniquepath;
                                     // id grouhe fari
                                     Guid id_grouh_fari = ak.GoodiesGroups.FirstOrDefault(i => i.CName == gf && i.CodeTitleId ==
                                     code_grouhe_fari && i.uniquepath.Contains(get_grouhe_asli_unique_path)).ID;
                                     // MessageBox.Show(get_grouhe_fari_unique_path);
                                     // unique pathe grouhe fari 

                                     // check for code kala 

                                     // gereftane kalahaye marboot be grohe asli va fari 

                                     // get all kala 

                                     var get__kala = ak.GoodiesGroups.Where(i => i.CodeTitleId == code_kala &&
                                         i.uniquepath.StartsWith(get_grouhe_fari_unique_path));

                                     bool kala_exist = false;
                                     foreach (var item_ in get__kala)
                                     {
                                         if ("0" + get_content[5] == item_.Code)
                                         {
                                             kala_exist = true;
                                         }
                                     }

                                     if (kala_exist == false)
                                     {
                                         Guid gfid = Guid.NewGuid();
                                         GoodiesGroup gg = new GoodiesGroup();

                                         gg.ID = gfid;
                                         gg.Code = "0" + get_content[5];
                                         gg.CName = get_content[2];
                                         gg.ParentId = id_grouh_fari;
                                         gg.uniquepath = get_grouhe_fari_unique_path + "#" + gfid;
                                         gg.CodeTitleId = code_kala;

                                         ak.GoodiesGroups.Add(gg);

                                         int i = ak.SaveChanges();

                                         if (i == 1)
                                         {
                                           //  MessageBox.Show("با موفقیت ثبت شد");
                                             log_array[log_array_idx] += "," + "کالا  ثبت گردید";
                                         }
                                         break;

                                     }
                                     else
                                     {
                                       //  MessageBox.Show("کالای مورد نظر وجود دارد");
                                         log_array[log_array_idx] += "," +  "کالا قبلا ثبت گردیده است";
                                         break;
                                     }


                                 } // if

                             } // foreach

                         } // if
                         else
                         {
                             log_array[log_array_idx] += "," +"گروه فرعی وجود ندارد";
                         }

                     } // if
                     else
                     {
                         log_array[log_array_idx] += ","+"گروه اصلی وجود ندارد";
                     }

                     // 2 - groh fari
                     bool grouhe_fari_exist = ak.GoodiesGroups.Any(i => i.CName == gf && i.CodeTitleId == code_grouhe_fari);

                 } // if
                 else { /* file has error */ }

             } // for 
             

             frm_MessageLog frm_messageLog = new frm_MessageLog(log_array);
             frm_messageLog.WindowStartupLocation = WindowStartupLocation.CenterScreen;
             frm_messageLog.ShowDialog();
         }

         public string getExcelColumns()
         {
             
             Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
             dlg.FileName = ""; // Default file name
             dlg.DefaultExt = ".xls"; // Default file extension
             dlg.Filter = "Text documents (.xls)|*.xls| Excel Document 2007 ~ 2013 (.xlsx)|*.xlsx"; // Filter files by extension
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

         public bool check_for_grouh_name_exist(string grouh__name) // finding that main group and sun grouh is exist .....
         {

             string[] get_ex_col_names = getExcelColumns().Split(',');

             foreach (var item in get_ex_col_names)
             {
                 if (item.Trim() == grouh__name.Trim())
                 {
                     return true;
                 }
             }

             return false;
         }

   


    }
}
