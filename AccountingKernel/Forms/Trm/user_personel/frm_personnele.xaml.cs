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

namespace AccountingKernel.Forms.user_personel
{
    /// <summary>
    /// Interaction logic for frm_personnele.xaml
    /// </summary>
    public partial class frm_personnele : Window
    {
        AccountingKernelEntities10 ak = new AccountingKernelEntities10();

        public frm_personnele()
        {
            InitializeComponent();
        }

        private void mnu_reg_Click_1(object sender, RoutedEventArgs e)
        {
            new frm_tarifePersonnele().ShowDialog();

            grid_personnel.ItemsSource = ak.PayrollPersons.ToList();
        }

        private void mnu_edit_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void mnu_rem_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Initialized_1(object sender, EventArgs e)
        {
            grid_personnel.ItemsSource = ak.PayrollPersons.ToList();
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            new frm_tarifePersonnele().ShowDialog();

            grid_personnel.ItemsSource = ak.PayrollPersons.ToList();
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnExel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
