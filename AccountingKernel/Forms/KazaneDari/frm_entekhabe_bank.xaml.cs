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
    /// Interaction logic for frm_entekhabe_bank.xaml
    /// </summary>
    /// 
    
    public partial class frm_entekhabe_bank : Window
    {
        AccountingKernelEntities10 ak = new AccountingKernelEntities10();

        public frm_entekhabe_bank()
        {
            InitializeComponent();
        }

        string ID = "";

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            
            grd_fund.ItemsSource = ak.Funds.ToList();

            if (pass_data.get_fund == "1")
            {
                grd_fund.ItemsSource = ak.Funds.Where(i => i.FType == Common.Constants.BaseInfoType.sandogh).ToList();
            }
            if (pass_data.get_bank == "1")
            {
                grd_fund.ItemsSource = ak.Funds.Where(i => i.FType == Common.Constants.BaseInfoType.Bank).ToList();
            }
    
        }

        private void btn_select_Click(object sender, RoutedEventArgs e)
        {
            Class.Variable.Variables.idFunds = ID;
            this.Hide();
        }

        private void grd_fund_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Fund f = (Fund)grd_fund.SelectedItem;
                ID = f.ID.ToString();
            }
            catch { }
        }
    }
}
