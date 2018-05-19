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

namespace AccountingKernel
{
    /// <summary>
    /// Interaction logic for LoanTax.xaml
    /// </summary>
    public partial class LoanTax : Window
    {
        public LoanTax()
        {
            InitializeComponent();
            FormLoad();

        }

        private void FormLoad()
        {
            grdLoanTax.ItemsSource = Business.GetLoanTaxBusiness().GetAll();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FormLoad();
        }
    }
}
