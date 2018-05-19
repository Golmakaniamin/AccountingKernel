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
    /// Interaction logic for frm_namayesheSaleMaly.xaml
    /// </summary>
    public partial class frm_namayesheSaleMaly : Window
    {
        public frm_namayesheSaleMaly()
        {
            InitializeComponent();
        }

        AccountingKernelEntities10 ak = new AccountingKernelEntities10();

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            Guid g = Guid.Parse(pass_data.get_id_for_namayeshesSaleMaly);
            grd_saleMaly.ItemsSource = ak.Financialyears.Where(i => i.IDCorporation == g).Select(r => new
            {
                IDCorporation = r.IDCorporation,
                FYear = r.FYyear,
            }).Distinct().ToList();

            grd_saleMaly.Columns[0].Visibility = System.Windows.Visibility.Hidden;
        }
        private void grd_saleMaly_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            new frm_namyesheMah().ShowDialog();
        }

        private void grd_saleMaly_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Guid get_IDcorporation;
            get_IDcorporation = (grd_saleMaly.SelectedItem as dynamic).IDCorporation;
            int get_year;
            get_year = (grd_saleMaly.SelectedItem as dynamic).FYear;
            pass_data.get_id_for_namayesheFormha = get_IDcorporation.ToString();
            pass_data.get_year_for_mounth = get_year.ToString();
            
        }

        private void MenuItem_Register(object sender, MouseButtonEventArgs e)
        {

        }

        private void MenuItem_Edit(object sender, MouseButtonEventArgs e)
        {

        }

        private void MenuItem_Delete(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
