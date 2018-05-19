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
    /// Interaction logic for frm_login.xaml
    /// </summary>
    /// 
     

    public partial class frm_login : Window
    {

        AccountingKernelEntities ak = new AccountingKernelEntities();

        public frm_login()
        {
            InitializeComponent();
        }


        private void btn_login_Click(object sender, RoutedEventArgs e)
        {

        }


        public int VerifyPassword(string username , string password)
        {         
           /* var myUser = db.Users
                .FirstOrDefault(u => u.Username == user.Username
                             && u.Password == user.Password);

            if (myUser != null)    //User was found
            {
               // معتبر
            }
            else    //User was not found
            {
                //معتبر نیست
            }*/


            return 1;
        }

    }
}
