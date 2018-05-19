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
using Common;

namespace AccountingKernel.Forms.tankhah
{
    /// <summary>
    /// Interaction logic for frm_editTankhah.xaml
    /// </summary>
    public partial class frm_editTankhah : Window
    {
        Class.UI.TextHandeler c = new Class.UI.TextHandeler();
        public frm_editTankhah()
        {
            InitializeComponent();
        }

        AccountingKernelEntities10 ak = new AccountingKernelEntities10();
        Guid get_id_for_cap_det = Guid.NewGuid();

        private void btn_sabt_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void btn_sabt2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_selectPersonnel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
          // load from 

            Guid g = pass_data.get_id_for_edit;
            var v = ak.Capitals.Where(i => i.ID == g).FirstOrDefault();

            // load capital data to Fields 

            pic_date.Text = v.CDate;
            txt_shomare.Text = v.CNO;
            txt_code_personnel.Text = ak.PayrollPersons.Where(b => b.id == v.CPerson).First().PPerson_Code;


            // load capital details Fields

            /* var c = ak.CapitalDetails.Where(i => i.IDCapital == g).FirstOrDefault();
            pic_tarikhe_hazine.Text = c.CDDate;
            txt_tozihat.Text = c.CDDescription;
            txtprice.Text = c.CDPrice + ""; */

            var c = ak.CapitalDetails.Where(i => i.IDCapital == g).ToList();
            grid_tankhah.ItemsSource = c;

            
           
        }

        private void grd_selectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                CapitalDetail cp = (CapitalDetail)grid_tankhah.SelectedItem;

                get_id_for_cap_det = cp.ID; // get ID

                pic_tarikhe_hazine.Text = cp.CDDate;
                txt_tozihat.Text = cp.CDDescription;
                txtprice.Text = cp.CDPrice + "";

       
            }
            catch { }


            
        }
        

        

        private void txt_shomare_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

            
            c.CheckIsNumeric(e);
        }

        private void txtprice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            
        }

        private void txtprice_TextChanged(object sender, TextChangedEventArgs e)
        {
            c.SepratTextBox(sender, e);
        }

        private void txt_tozihat_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.JustPersian(e);
        }
  }
}
