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
    /// Interaction logic for frm_getp.xaml
    /// </summary>
    public partial class frm_getp : Window
    {
        string ID = "";

        public frm_getp()
        {
            InitializeComponent();
        }
        AccountingKernelEntities10 ak = new AccountingKernelEntities10();
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (ID != "")
            {
                pass_data.get_id = ID;
                this.Hide();
            }
            else
            {
                MessageBox.Show("لطفا پرسنل را انتخاب کنید");
            }
        }
        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            grd_p.ItemsSource = ak.PayrollPersons.ToList();
        }

        private void grd_p_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var p = (PayrollPerson)grd_p.SelectedItem;
                ID = p.id.ToString();
            }
            catch
            {
            }
        }
    }
}
