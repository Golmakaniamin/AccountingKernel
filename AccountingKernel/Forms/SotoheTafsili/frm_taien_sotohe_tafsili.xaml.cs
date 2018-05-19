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

 
    public class get_set_moien_id_tafsili
    {
        public static string moien_id_;

    }
       
    /// <summary>
    /// Interaction logic for frm_taien_sotohe_tafsili.xaml
    /// </summary>
    public partial class frm_taien_sotohe_tafsili : Window
    {
        public frm_taien_sotohe_tafsili()
        {
            InitializeComponent();
        }
        Guid ID;
        Guid get_id;
        Guid get_moien_id;
        AccountingKernelEntities10 ak = new AccountingKernelEntities10();
        //  Guid get_id = Guid.Parse(AccountingKernel.Class.Variable.Variables.idAccountingMoien);
        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        { 
            // load 
          //  LoadAccountingTafsilLevelsDetailToGrid();

      
            Guid get_id = Guid.Parse(AccountingKernel.Class.Variable.Variables.idAccountingMoien);
            get_moien_id = Guid.Parse(AccountingKernel.Class.Variable.Variables.idAccountingMoien); 
            List<AccountingMoeinDetail> get_data_from_amd = ak.AccountingMoeinDetails.Where(i => i.IdAccountingMoein == get_id).ToList();
            //List<AccountingMoein> get_code_moien = ak.AccountingMoeins.Where(i => i.MIdMoein == get_id).ToList();
            add_data_to_comboBox();
            foreach (var item in get_data_from_amd)
            {
                if (item.IdCodeTitle == Common.Constants.CodeTitle.Goruh)
                {
                    lbl_onvaneGrouh.Content = item.MDName;
                    lbl_codeMoien.Content = item.IdIn;
                }
                if (item.IdCodeTitle == Common.Constants.CodeTitle.Kol)
                {
                    lbl_onvaneKol.Content = item.MDName;
                    lbl_codeMoien.Content += item.IdIn;
                }
                if (item.IdCodeTitle == Common.Constants.CodeTitle.Moein)
                {
                    lbl_onvaneMoien.Content = item.MDName;
                    lbl_codeMoien.Content += item.IdIn;
                }

                // lbl_codeMoien.Content = get_code_moien[0].MIdMoein;
            }

            ///////////////////////////////////

            //  grid_AccountiTafsilLevels.ItemsSource = ak.AccountingTafsilLevels.ToList().Where(i => i.IdAccountingMoein == get_id).ToList();

            //////////////////////////////////

        }

        private void add_data_to_comboBox()
        {
            List<string> data = new List<string>();
            data.Add("انتخاب کنید");
            data.Add("تفصیل 1");
            data.Add("تفصیل 2");
            data.Add("تفصیل 3");

            cmb_sotoheTafsili.ItemsSource = data;
            cmb_sotoheTafsili.SelectedIndex = 0;
        }

        private void btn_fehresteGrouhayeTafsili_Click(object sender, RoutedEventArgs e)
        {
            if (cmb_sotoheTafsili.SelectedIndex != 0)
            {
                Class.Variable.Variables.AccountingTafsilLevels = cmb_sotoheTafsili.SelectedItem.ToString();
                frm_fehreste_grouhe_tafsili fgt = new frm_fehreste_grouhe_tafsili();
                fgt.ShowDialog();
                fillDataToGrid();
               // LoadAccountingTafsilLevelsDetailToGrid();
            }
            else
            {
                MessageBox.Show("لطفا یک سطح تفصیلی انتخاب کنید");
            }
        }

        private void LoadAccountingTafsilLevelsDetailToGrid(string q = "")
        {
            Guid get_id = Guid.Parse(AccountingKernel.Class.Variable.Variables.idAccountingMoien);
            // grid_AccountiTafsilLevels.ItemsSource = ak.AccountingTafsilLevels.ToList().Where(i => i.IdAccountingMoein == get_id).ToList();

            var accountingMoeinTafsilLevels = Business.GetAccountingMoeinTafsilLevelBusiness().GetAll();
            var accountingTafsillevelsDetails = Business.GetAccountingTafsilLevelDetailBusiness().GetAll().Join(accountingMoeinTafsilLevels, o => o.IdAccountingTafsilLevels,
                i => i.IdAccountingTafsilLevels,
                (o, i) => new
                {
                    AccountingTafsillevelsDetails = o,
                    AccountingMoeinTafsilLevels = i
                });

            var accountingMoein = Business.GetAccountingMoeinBusiness().GetAll().Join(accountingTafsillevelsDetails,
                o => o.Id, i => i.AccountingMoeinTafsilLevels.IdAccountingMoein, (o, i) => new
                {
                    AccountingMoein = o,
                    AccountingTafsillevelsDetails = i
                });


            //grid_AccountiTafsilLevels.ItemsSource = accountingMoein.Select(r => new { Moein = r.AccountingMoein.MName r.AccountingMoein.MIdGroup}   ).ToList();
            grid_AccountiTafsilLevels.ItemsSource = accountingMoein.Select(r => new
            {
                tafsil =
                    r.AccountingTafsillevelsDetails.AccountingTafsillevelsDetails.ATLName,
                r.AccountingTafsillevelsDetails.AccountingTafsillevelsDetails.ATLNameEn,

            }).ToList();
        }

        private void cmb_sotoheTafsili_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fillDataToGrid();
        }

        private void fillDataToGrid()
        {
            if (cmb_sotoheTafsili.SelectedIndex == 0)
            {

                var query = from amtld in ak.AccountingTafsillevelsDetails
                            join amtl in ak.AccountingMoeinTafsilLevels on amtld.IdAccountingTafsilLevels
                            equals amtl.IdAccountingTafsilLevels
                            select new
                            {
                                amtld.ATLName,
                                amtl.IdTafsilGroup,
                                amtld.IdAccountingTafsilLevels,
                                amtld.CodeTitle,
                                amtld.IdCodeTitle,
                                amtl.IdAccountingMoein,
                                amtl.ID
                            };

                var query2 = from q in query
                             join c in ak.CodeTitles on q.IdTafsilGroup equals c.Id
                             select new
                             {
                                 q.ATLName,
                                 q.IdTafsilGroup,
                                 q.IdAccountingTafsilLevels,
                                 c.CodeName,
                                 q.IdCodeTitle,
                                 q.IdAccountingMoein,
                                 q.ID
                             };


                grid_AccountiTafsilLevels.ItemsSource = query2.Where(j => j.IdCodeTitle ==
                    Common.Constants.CodeTitle.GoruheTafsili).Where(s => s.IdAccountingMoein == get_moien_id).ToList();
            }

            if (cmb_sotoheTafsili.SelectedIndex == 1)
            {

                var query = from amtld in ak.AccountingTafsillevelsDetails
                            join amtl in ak.AccountingMoeinTafsilLevels on amtld.IdAccountingTafsilLevels
                            equals amtl.IdAccountingTafsilLevels
                            select new
                            {
                                amtld.ATLName,
                                amtl.IdTafsilGroup,
                                amtld.IdAccountingTafsilLevels,
                                amtld.CodeTitle,
                                amtld.IdCodeTitle,
                                amtl.IdAccountingMoein,
                                amtl.ID
                            };

                var query2 = from q in query
                             join c in ak.CodeTitles on q.IdTafsilGroup equals c.Id
                             select new
                             {
                                 q.ATLName,
                                 q.IdTafsilGroup,
                                 q.IdAccountingTafsilLevels,
                                 c.CodeName,
                                 q.IdCodeTitle,
                                 q.IdAccountingMoein,
                                 q.ID
                             };


                grid_AccountiTafsilLevels.ItemsSource = query2.Where(j => j.IdCodeTitle ==
                    Common.Constants.CodeTitle.GoruheTafsili).Where(l => l.IdTafsilGroup ==
                        Common.Constants.CodeTitle.Tafsil1).Where(s => s.IdAccountingMoein == get_moien_id).ToList();

            }

            if (cmb_sotoheTafsili.SelectedIndex == 2)
            {

                var query = from amtld in ak.AccountingTafsillevelsDetails
                            join amtl in ak.AccountingMoeinTafsilLevels on amtld.IdAccountingTafsilLevels
                            equals amtl.IdAccountingTafsilLevels
                            select new
                            {
                                amtld.ATLName,
                                amtl.IdTafsilGroup,
                                amtld.IdAccountingTafsilLevels,
                                amtld.CodeTitle,
                                amtld.IdCodeTitle,
                                amtl.IdAccountingMoein,
                                amtl.ID

                            };

                var query2 = from q in query
                             join c in ak.CodeTitles on q.IdTafsilGroup equals c.Id
                             select new
                             {
                                 q.ATLName,
                                 q.IdTafsilGroup,
                                 q.IdAccountingTafsilLevels,
                                 c.CodeName,
                                 q.IdCodeTitle,
                                 q.IdAccountingMoein,
                                 q.ID
                             };


                grid_AccountiTafsilLevels.ItemsSource = query2.Where(j => j.IdCodeTitle ==
              Common.Constants.CodeTitle.GoruheTafsili).Where(l => l.IdTafsilGroup ==
                  Common.Constants.CodeTitle.Tafsil2).Where(s => s.IdAccountingMoein == get_moien_id).ToList();

            }


            if (cmb_sotoheTafsili.SelectedIndex == 3)
            {

                var query = from amtld in ak.AccountingTafsillevelsDetails
                            join amtl in ak.AccountingMoeinTafsilLevels on amtld.IdAccountingTafsilLevels
                            equals amtl.IdAccountingTafsilLevels
                            select new
                            {
                                amtld.ATLName,
                                amtl.IdTafsilGroup,
                                amtld.IdAccountingTafsilLevels,
                                amtld.CodeTitle,
                                amtld.IdCodeTitle,
                                amtl.IdAccountingMoein,
                                amtl.ID
                            };

                var query2 = from q in query
                             join c in ak.CodeTitles on q.IdTafsilGroup equals c.Id
                             select new
                             {
                                 q.ATLName,
                                 q.IdTafsilGroup,
                                 q.IdAccountingTafsilLevels,
                                 c.CodeName,
                                 q.IdCodeTitle,
                                 q.IdAccountingMoein,
                                 q.ID
                             };

                grid_AccountiTafsilLevels.ItemsSource = query2.Where(j => j.IdCodeTitle ==
              Common.Constants.CodeTitle.GoruheTafsili).Where(l => l.IdTafsilGroup ==
                  Common.Constants.CodeTitle.Tafsil3).Where(s => s.IdAccountingMoein == get_moien_id).ToList();
            }
        }

        private void mnu_reg_Click_1(object sender, RoutedEventArgs e)
        {
            if (ID != Guid.Empty)
            {
                MessageBoxResult m = MessageBox.Show("آیا مایل به حذف رکورد میباشید" + Environment.NewLine + "", "حذف رکورد", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (m == MessageBoxResult.Yes)
                {

                    var a = ak.AccountingMoeinTafsilLevels.Where(i => i.ID == ID).First();
                    ak.AccountingMoeinTafsilLevels.Remove(a);
                    int r = ak.SaveChanges();
                    if (r == 1)
                    {
                        MessageBox.Show("حذف شد");
                        fillDataToGrid();
                        
                    }
                }
            }
            else
            {
                MessageBox.Show("مقداری جهت حذف یافت نشده است", "حذف رکورد", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        
        private void grid_AccountiTafsilLevels_SelectedCellsChanged_1(object sender, SelectedCellsChangedEventArgs e)
        {
          /*  
            try
            {
                AccountingTafsillevelsDetail at = (AccountingTafsillevelsDetail)grid_AccountiTafsilLevels.SelectedItem;
                ID = (Guid)at.IdAccountingTafsilLevels;
            }
            catch { } 
           */
            string g = "";
            try
            {
                g = grid_AccountiTafsilLevels.SelectedItem.ToString();
             //   MessageBox.Show(g);
            string get_final_str = "";
            for (int i = 0; i <= g.Length - 3; i++)
            {
                if (g.Substring(i, 24) == "IdAccountingTafsilLevels")
                {
                    get_final_str = g.Substring(i + 27, 36);
                    break;
                }
            }
           get_id = Guid.Parse(get_final_str);
            }
            catch { }
           /////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////
            string g2 = "";
            try
            {
                g2 = grid_AccountiTafsilLevels.SelectedItem.ToString();
                
                string get_final_str2 = "";
                for (int i = 0; i <= g2.Length - 3; i++)
                {
                    if (g2.Substring(i, 2) == "ID")
                    {
                        get_final_str2 = g2.Substring(i + 5, 36);
                        break;
                    }
                }
                ID = Guid.Parse(get_final_str2);            
            }
           catch { }
           
        }

        private void grid_AccountiTafsilLevels_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
