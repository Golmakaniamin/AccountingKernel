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
using Common;

namespace AccountingKernel
{
    /// <summary>
    /// Interaction logic for LoanDetail.xaml
    /// </summary>
    public partial class PayrollAddLoan : Window
    {
        Class.UI.TextHandeler c = new Class.UI.TextHandeler();
        List<Data.PayrollLoan> _payrollLoan = new List<Data.PayrollLoan>();
        private Guid _personid;

        public PayrollAddLoan()
        {
            InitializeComponent();
        }

        public PayrollAddLoan(Guid personid)
        {
            InitializeComponent();
            _personid = personid;
        }

        private void btnNewLoan_Click(object sender, RoutedEventArgs e)
        {
            grdLoan.ItemsSource = null;
            Data.PayrollLoan _entity = null;
            if (FormIsValid())
            {
                _entity = new Data.PayrollLoan();
                _entity.IDPayrollPerson = _personid;
                _entity.PrLID = txtLoanCode.Text;
                _entity.PrLDDate = pdcPaymentDate.Text;
                _entity.PrLDDateMiladi = _entity.PrLDDate.ToDate();
                _entity.PrLDPrice = decimal.Parse(txtLoanPrice.Text);
                _payrollLoan.Add(_entity);
                grdLoan.ItemsSource = _payrollLoan;
            }
        }

        //TODO : Form is not validate
        private bool FormIsValid()
        {
            return true;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (_payrollLoan.Count > 0)
            {
                Business.GetPayrollLoanBusiness().Save(_payrollLoan);
                this.Close();
            }
        }

        private void GridLoanDetail_Click(object sender, RoutedEventArgs e)
        {
            new PayrollLoanDetail(_personid).Show();
        }

        private void txtLoanPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
            c.AddZero(sender, e);
        }
    }
}
