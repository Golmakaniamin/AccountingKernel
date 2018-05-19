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

namespace AccountingKernel.Forms.user_personel
{
    /// <summary>
    /// Interaction logic for frm_user.xaml
    /// </summary>
    public partial class frm_user : Window
    {
        public frm_user()
        {
            InitializeComponent();
        }

        private void mnu_reg_Click_1(object sender, RoutedEventArgs e)
        {
            new frm_tarifeUser().ShowDialog();
        }

        private void mnu_edit_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void mnu_rem_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            new frm_tarifeUser().ShowDialog();
        }
    }
}
