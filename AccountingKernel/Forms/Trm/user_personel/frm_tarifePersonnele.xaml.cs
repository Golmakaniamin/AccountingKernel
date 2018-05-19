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
    /// Interaction logic for frm_tarifePersonnele.xaml
    /// </summary>
    public partial class frm_tarifePersonnele : Window
    {
        Class.UI.TextHandeler c = new Class.UI.TextHandeler();
        AccountingKernelEntities10 ak = new AccountingKernelEntities10();

        public frm_tarifePersonnele()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (txt_code.Text != "" && txt_family.Text != "" && txt_name.Text != "")
            {
                // che for personnel code exist
                //Younesi Change Pid to PPerson_Code
                if (ak.PayrollPersons.Any(o => o.PPerson_Code == txt_code.Text.Trim()))
                {
                    MessageBox.Show("کد پرسنلی وجود دارد");
                }
                else
                {
                    var p = new PayrollPerson();
                    p.PFristName = txt_name.Text;
                    p.PLastName = txt_family.Text;
                    p.PPerson_Code = txt_code.Text;
                    p.id = Guid.NewGuid();

                    ak.PayrollPersons.Add(p);
                    int r = ak.SaveChanges();
                    if (r == 1)
                    {
                        MessageBox.Show("پرسنل جدید با موفقیت ثبت شد");
                        this.Hide();
                    }
                }
            }
        }

        private void txt_code_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            
            
            c.CheckIsNumeric(e);
        }

        private void txt_name_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.JustPersian(e);
        }

        private void txt_family_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.JustPersian(e);
        }
    }
}
