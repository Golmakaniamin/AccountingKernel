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
    /// Interaction logic for PayrollSalaryFactor.xaml
    /// </summary>
    public partial class PayrollSalaryFactor : Window
    {
        List<Data.PayrollSalaryFactor> _PayrollSalaryFactor = null;
        public PayrollSalaryFactor()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            grdSalary.ItemsSource = null;
            if (FormIsValid())
            {
                var _entity = new Data.PayrollSalaryFactor();
                _entity.PrSDescription = txtName.Text;
                _entity.PrSContent = txtFurmol.Text;

                _PayrollSalaryFactor.Add(_entity);
            }
            grdSalary.ItemsSource = _PayrollSalaryFactor;
        }

        //TODO : form is not validating
        private bool FormIsValid()
        {
            return true;
        }

        private void btnCommit_Click(object sender, RoutedEventArgs e)
        {
            if(_PayrollSalaryFactor != null)
            {
                Business.GetPayrollSalaryFactorBusiness().Save(_PayrollSalaryFactor);
                MessageBox.Show("ثبت با موفقیت انجام شد");
            }
        }
    }
}
