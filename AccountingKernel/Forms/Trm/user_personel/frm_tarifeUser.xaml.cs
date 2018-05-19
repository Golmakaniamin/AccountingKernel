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
    /// Interaction logic for frm_tarifeUser.xaml
    /// </summary>
    public partial class frm_tarifeUser : Window
    {
        Guid g = Guid.NewGuid();

        public frm_tarifeUser()
        {
            InitializeComponent();
        }

        AccountingKernelEntities10 ak = new AccountingKernelEntities10();

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (txt_username.Text != "" && txt_pass.Password != "" && txt_repass.Password != "" &&
                txt_repass.Password == txt_repass.Password)
            {

                User u = new User();
                u.ID = Guid.NewGuid();
                u.username = txt_username.Text;
                u.password = txt_pass.Password;
                u.perID = g;
                ak.Users.Add(u);
                ak.SaveChanges();
            }
            else
            {
                MessageBox.Show("شما ملزوم به وارد کردن اطلاعات میباشید");
            }

        }

        private void btn_entekhabePersonnel_Click(object sender, RoutedEventArgs e)
        {
            new frm_getp().ShowDialog();
            g = Guid.Parse(pass_data.get_id);
            pass_data.get_id = "";
            var p = ak.PayrollPersons.First(i => i.id == g);
            txt_personnelNameFamily.Text = p.PFristName + " " + p.PLastName;

        }
    }
}
