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
    /// Interaction logic for frm_namyesheMah.xaml
    /// </summary>
    public partial class frm_namyesheMah : Window
    {
        public frm_namyesheMah()
        {
            InitializeComponent();
        }

        AccountingKernelEntities10 ak = new AccountingKernelEntities10();

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            Guid g = Guid.Parse(pass_data.get_id_for_namayesheFormha);
            int year = int.Parse(pass_data.get_year_for_mounth);
            

            List<Financialyear> f = ak.Financialyears.Where(i => i.IDCorporation == g &&
                i.FYyear == year).ToList().OrderBy(i => i.piroity).ToList();

            grd_mounth.ItemsSource = f;
        }
    }
}
