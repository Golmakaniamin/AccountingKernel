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

namespace AccountingKernel.Forms.tankhah
{
    /// <summary>
    /// Interaction logic for frm_entekhabe_personnel_.xaml
    /// </summary>
    public partial class frm_entekhabe_personnel_ : Window
    {
        public frm_entekhabe_personnel_()
        {
            InitializeComponent();
        }

        AccountingKernelEntities10 ak = new AccountingKernelEntities10();
        string ID = "";
        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            
        }

        private void grid_personnel_Loaded(object sender, RoutedEventArgs e)
        {
            grid_personnel.ItemsSource = ak.PayrollPersons.ToList();
           
        }

        private void grid_personnel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var am = (PayrollPerson)grid_personnel.SelectedItem;
                ID = am.id.ToString();
                pass_data.ID = ID;
            }
            catch { }
        }

        private void btn_select_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
