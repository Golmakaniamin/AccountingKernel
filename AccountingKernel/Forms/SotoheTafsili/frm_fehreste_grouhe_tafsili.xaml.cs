using Data;
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

namespace AccountingKernel.Forms.SotoheTafsili
{
    /// <summary>
    /// Interaction logic for frm_fehreste_grouhe_tafsili.xaml
    /// </summary>
    /// 
    public class amtd
    {
        public string IdAccountingMoein { set; get; }
 
    }
    public partial class frm_fehreste_grouhe_tafsili : Window
    {
        AccountingKernelEntities10 ak = new AccountingKernelEntities10();
        //string ID = "";
        //string ID_code_title = "";
        //string ID_accounting_tafsil_levels = "";
        //string grouh_name = "";
        public frm_fehreste_grouhe_tafsili()
        {
            InitializeComponent();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

        }

        private void btn_sabteTafsili_Click(object sender, RoutedEventArgs e)
        {

               Guid get =  Guid.Parse( Class.Variable.Variables.idAccountingMoien );


               var v = ak.AccountingMoeinTafsilLevels.Where(i => i.IdAccountingMoein == get).ToList();
               bool can_process = true;
               for (int i = 0; i < grd_tafsil.Items.Count; i++)
               {
                   grd_tafsil.SelectedIndex = i;

                   CheckBox Check = this.grd_tafsil.Columns[0].GetCellContent(grd_tafsil.SelectedItem) as CheckBox;

                   if (Check != null && Check.IsChecked == true)
                   {
                       AccountingTafsillevelsDetail f = grd_tafsil.Items[i] as AccountingTafsillevelsDetail;
                       foreach (var item in v)
                       {
                           if (f.IdAccountingTafsilLevels == item.IdAccountingTafsilLevels)
                           {
                               can_process = false;
                           }
                       }
                   }
               }

            // check for all checkes 
            if (can_process)
            {
                int count_checkBox = 0;

                bool even_once = false;
                for (int i = 0; i < grd_tafsil.Items.Count; i++)
                {
                    grd_tafsil.SelectedIndex = i;
                    CheckBox Check = this.grd_tafsil.Columns[0].GetCellContent(grd_tafsil.SelectedItem) as CheckBox;
                    if (Check != null && Check.IsChecked == true)
                    {
                        even_once = true;
                        count_checkBox++;
                    }
                }

                if (even_once == false)
                {
                    MessageBox.Show("انتخاب یک گزینه الزامی میباشد");

                }
                //

                else
                {

                    List<CodeTitle> ct = ak.CodeTitles.Where(i => i.CodeName == Class.Variable.Variables.AccountingTafsilLevels).ToList();
                    Guid code_title = ct[0].Id;
                    //////////////////////////////////////////
                    Guid a = Guid.Parse(Class.Variable.Variables.idAccountingMoien);
                    // Guid idmatl = Guid.Parse(ID_accounting_tafsil_levels);
                    AccountingMoeinTafsilLevel amtl_ = new AccountingMoeinTafsilLevel();
                    // 
                    int r = 0;
                    Guid get_idAccountingTaf = Guid.Empty;

                    for (int i = 0; i < grd_tafsil.Items.Count; i++)
                    {
                        grd_tafsil.SelectedIndex = i;

                        CheckBox Check = this.grd_tafsil.Columns[0].GetCellContent(grd_tafsil.SelectedItem) as CheckBox;

                        if (Check != null && Check.IsChecked == true)
                        {
                            AccountingTafsillevelsDetail f = grd_tafsil.Items[i] as AccountingTafsillevelsDetail;
                            get_idAccountingTaf = (Guid)f.IdAccountingTafsilLevels;

                            amtl_ = new AccountingMoeinTafsilLevel();

                            amtl_.ID = Guid.NewGuid(); // sss
                            amtl_.IdAccountingMoein = a; /// sss
                            amtl_.IdTafsilGroup = code_title; // sss

                            amtl_.IdAccountingTafsilLevels = get_idAccountingTaf;

                            ak.AccountingMoeinTafsilLevels.Add(amtl_);

                            r += ak.SaveChanges();

                            if (r == count_checkBox)
                            {
                                MessageBox.Show("باموفقیت ثبت گردید");
                                this.Hide();
                            }
                        }
                    }

                }

            }
            else
            {
                MessageBox.Show("یکی از موارد در گروه دیگر ثبت گردیده است");
            }
        }

        private void grd_tafsil_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           // try
           // {
               // AccountingTafsillevelsDetail am = (AccountingTafsillevelsDetail)grd_tafsil.SelectedItem;
               // ID = am.Id.ToString();
               // ID_code_title = am.IdCodeTitle.ToString();
               // ID_accounting_tafsil_levels = am.IdAccountingTafsilLevels.ToString();
                //grouh_name = am.ATLName;
           // }
           // catch {  }
        }


        private string get_id_in(string ID_accounting_tafsil_levels)
        {
            Guid GGID_accounting_tafsil_levels;
            GGID_accounting_tafsil_levels = Guid.Parse(ID_accounting_tafsil_levels);
            List<AccountingTafsillevelsDetail> get_grouh_tafsil = ak.AccountingTafsillevelsDetails.Where(i => i.IdAccountingTafsilLevels ==
                GGID_accounting_tafsil_levels).ToList();

            string make_id_in = "";

            if (get_grouh_tafsil[0].IdCodeTitle == Common.Constants.CodeTitle.GoruheTafsili) 
            {
                make_id_in = get_grouh_tafsil[0].IdIn;
                make_id_in += get_grouh_tafsil[1].IdIn;
            }

            if (get_grouh_tafsil[1].IdCodeTitle ==  Common.Constants.CodeTitle.GoruheTafsili)
            {
                make_id_in = get_grouh_tafsil[1].IdIn;
                make_id_in += get_grouh_tafsil[0].IdIn;

            }


            return make_id_in;
        }


        private int get_tafsil_grouh()
        {
            List<CodeTitle> ct = ak.CodeTitles.Where(i => i.CodeName == "حساب تفصیلی").ToList();

            return (int)ct[0].CodeGroup;

        }

        private void Window_Loaded_2(object sender, RoutedEventArgs e)
        {
            string str_tafsil_name = Class.Variable.Variables.AccountingTafsilLevels;
            var n = ak.CodeTitles.Where(i => i.CodeName == str_tafsil_name).First();

            Guid g_tafsil = n.Id;

            Guid gg = Common.Constants.CodeTitle.GoruheTafsili;


          Guid IDaccountingMoien = Guid.Parse( Class.Variable.Variables.idAccountingMoien);
            //g_tafsil

          var get_all_atld = ak.AccountingTafsillevelsDetails.ToList();
          var get_all_atld_t = ak.AccountingTafsillevelsDetails.ToList();

          var s_IdAccountingtafsilLevels = ak.AccountingMoeinTafsilLevels.Where(i => i.IdTafsilGroup ==
         g_tafsil && i.IdAccountingMoein == IDaccountingMoien).ToList();


          foreach (var item in get_all_atld)
          {
              foreach (var item_ in s_IdAccountingtafsilLevels)
              {
                  if (item.IdAccountingTafsilLevels == item_.IdAccountingTafsilLevels)
                  {
                      get_all_atld_t.Remove(item);
                  }
              }
          }


        /*  grd_tafsil.ItemsSource = get_all_atld_t.Where(i => i.IdCodeTitle == Common.
              Constants.CodeTitle.GoruheTafsili);*/
            Guid get =  Guid.Parse( Class.Variable.Variables.idAccountingMoien );
            Guid gogo = Guid.Empty;

            try
            {
                var vv = ak.AccountingMoeinTafsilLevels.Where(i => i.IdAccountingMoein == get).First();
                gogo = (Guid)vv.IdAccountingTafsilLevels;
            }
            catch { }


          grd_tafsil.ItemsSource = get_all_atld_t.Where(i => i.IdCodeTitle == Common.
          Constants.CodeTitle.GoruheTafsili && i.IdAccountingTafsilLevels != gogo).ToList();

     

          /*  for (int i = 0; i <= grd_tafsil.Items.Count; i++)
            {

                AccountingTafsillevelsDetail am = (AccountingTafsillevelsDetail)grd_tafsil.Items[i];

                 grd_tafsil

            }      */      

            grd_tafsil.Columns[1].Visibility = System.Windows.Visibility.Hidden;
           /* grd_tafsil.Columns[4].Visibility = System.Windows.Visibility.Hidden;
            grd_tafsil.Columns[5].Visibility = System.Windows.Visibility.Hidden;
            grd_tafsil.Columns[6].Visibility = System.Windows.Visibility.Hidden;
            grd_tafsil.Columns[1].Visibility = System.Windows.Visibility.Hidden;
            grd_tafsil.Columns[2].Visibility = System.Windows.Visibility.Hidden;
            grd_tafsil.Columns[7].Visibility = System.Windows.Visibility.Hidden;
            grd_tafsil.Columns[0].Visibility = System.Windows.Visibility.Hidden;*/
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
    
        }

        private void grd_tafsil_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
           // e.Cancel = true;
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


    }
}
