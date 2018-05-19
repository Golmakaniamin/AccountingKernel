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

namespace AccountingKernel.Forms.Login
{
    /// <summary>
    /// Interaction logic for FrmLogin1.xaml
    /// </summary>
    public partial class FrmLogin : Window
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void FrmLoginN_Loaded(object sender, RoutedEventArgs e)
        {
            Amin2.Content = new AccountingKernel.Forms.Login.AbouteBox().Content;
        }
    }
}
