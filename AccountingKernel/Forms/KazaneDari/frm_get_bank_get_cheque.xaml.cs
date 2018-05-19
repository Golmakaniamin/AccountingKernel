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

namespace AccountingKernel.Forms.KazaneDari
{
    /// <summary>
    /// Interaction logic for frm_get_bank_get_cheque.xaml
    /// </summary>
    public partial class frm_get_bank_get_cheque : Window
    {
        public frm_get_bank_get_cheque()
        {
            InitializeComponent();
        }

        AccountingKernelEntities10 ak = new AccountingKernelEntities10();
        int levels = 0;

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            grd_bank_check.ItemsSource = ak.Funds.ToList();
        }

        private void grd_bank_check_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender != null)
            {
                DataGrid grid = sender as DataGrid;
                if (grid != null && grid.SelectedItems != null && grid.SelectedItems.Count == 1)
                {
                    try
                    {
                        Fund f = (Fund)grd_bank_check.SelectedItem;
                        Guid ID = f.ID;
                        // List<Check> ck = ak.Checks.Where(i => i.CBank == ID).ToList();
                        //   var j = from q1 in  
                        //   grd_bank_check.ItemsSource = ck.ToList();

                        var query = from cp in ak.CheckProcesses
                                    join c in ak.Checks on cp.IDCheck equals c.ID
                                    where cp.CPType == Guid.Empty /*|| cp.CPType != 
                                    Common.Constants.BaseInfoType.vosole_cheque*/
                                    select new
                                    {
                                        c.ID,
                                        c.CNO,
                                        c.CAccountnumber,
                                        c.CPrice,
                                        c.CDescription,
                                        c.CDate,
                                        c.CName,
                                        c.CBank
                                     
                                    };
                        query = query.Where(x => x.CBank == ID);
                        grd_bank_check.ItemsSource = query.ToList();


                        levels = 1;
                    }
                    catch
                    {
               
                    }
                   
                  
                }
            }
        }

        private void grd_bank_check_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (levels == 0)
                {
                    Fund f = (Fund)grd_bank_check.SelectedItem;
                    string name_bank = f.FBank;
                    //MessageBox.Show(name_bank);
                    Forms.KazaneDari.pass_data.get_bank_selected = name_bank;
                   /* string g = grd_bank_check.SelectedItem.ToString();
                    string get_final_str = "";
                    for (int i = 0; i <= g.Length - 7; i++)
                    {
                        if (g.Substring(i, 7) == "FBankNO")
                        {
                            get_final_str = g.Substring(i + 5, 36);
                        }
                    }

                    MessageBox.Show("get bank -> " + g); */
                }
                if (levels == 1)
                {
                   /* Check f = (Check)grd_bank_check.SelectedItem;
                    string ID_cheque = f.CNO;
                    lbl_ch_code.Content = ID_cheque;
                    pass_data.ch_id = ID_cheque;*/
                    string g = grd_bank_check.SelectedItem.ToString();
                    string get_final_str = "";
                    for (int i = 0; i <= g.Length - 3; i++)
                    {
                        if (g.Substring(i, 3) == "CNO")
                        {
                            
                            //get_final_str = g.Substring(i + 7, 36);
                            for (int j = i + 6; j <= 100; j++)
                            {
                                if (char.IsDigit(g.Substring(j, 1), 0) == true)
                                {
                                    get_final_str += g.Substring(j, 1);
                                }
                                else
                                {
                                    break;
                                }
                            }

                        }
                    }

                    string ID_cheque = get_final_str;
                    lbl_ch_code.Content = ID_cheque;
                    pass_data.ch_id = ID_cheque;
                }

            }
            catch { }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
