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
    /// Interaction logic for frm_get_shomare_hesab.xaml
    /// </summary>
    public partial class frm_get_shomare_hesab : Window
    {
        public frm_get_shomare_hesab()
        {
            InitializeComponent();
        }
        
        AccountingKernelEntities10 ak = new AccountingKernelEntities10();
        string ID;

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(pass_data.b_name);
            grd_fund.ItemsSource = ak.Funds.Where(i => i.FBank == pass_data.b_name).ToList();
        }

        private void grd_fund_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                Fund f = (Fund)grd_fund.SelectedItem;
                ID = f.ID.ToString();
                pass_data.sh_hesab = f.FAccountnumber; 
            }
            catch { }

        }

        private void btn_select_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
