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

namespace AccountingKernel.Forms.saleMaly
{
    /// <summary>
    /// Interaction logic for frm_saleMaly.xaml
    /// </summary>
    public partial class frm_saleMaly : Window
    {
        public frm_saleMaly()
        {
            InitializeComponent();
        }
        AccountingKernelEntities10 ak = new AccountingKernelEntities10();
        private void MenuItem_Register(object sender, MouseButtonEventArgs e)
        {
            new frm_tarifeSaleMaly().ShowDialog();
            grd_grouh.ItemsSource = ak.Financialyears.ToList();
        }

        private void MenuItem_Edit(object sender, MouseButtonEventArgs e)
        {

        }

        private void MenuItem_Delete(object sender, MouseButtonEventArgs e)
        {

        }

        private void Window_Initialized_1(object sender, EventArgs e)
        {
            grd_grouh.ItemsSource = ak.Financialyears.ToList();
        }

        private void initialize(object sender, EventArgs e)
        {
            MessageBox.Show("");
        }

        private void mouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
         //   MessageBox.Show("dc");
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            new frm_tarifeSaleMaly().ShowDialog();
            grd_grouh.ItemsSource = ak.Financialyears.ToList();
        }
    }
}
