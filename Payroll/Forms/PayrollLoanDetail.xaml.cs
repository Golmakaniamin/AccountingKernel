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
    public partial class PayrollLoanDetail : Window
    {
        AccountingKernel.Class.UI.TextHandeler c = new AccountingKernel.Class.UI.TextHandeler();
        private List<Data.PayrollLoanDetail> _PayrollLoanDetail = null;
        
        private Guid _personid;

        public PayrollLoanDetail()
        {
            InitializeComponent();
        }

        public PayrollLoanDetail(Guid personid)
        {
            InitializeComponent();
            _personid=personid;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            _PayrollLoanDetail = new List<Data.PayrollLoanDetail>();

            int _qty = 0;
            string Pdate = pdcFirstLoan.Text;
            int repayment = 0;

            try
            {
                _qty = int.Parse(txtPaymentQTY.Text);
                repayment = int.Parse(txtRePayment.Text);
            }
            catch (FormatException)
            {
                throw;
            }

            if (FormIsValid())
            {
                Data.PayrollLoanDetail entity = null;

                for (int i = 0; i < _qty; i++)
                {
                    entity = new Data.PayrollLoanDetail();
                    if (i == 0)
                    {
                        entity.PrLPrice = decimal.Parse(txtRePaymentNotEqual.Text);
                        entity.PrLDate = Pdate;
                    }
                    else
                    {
                        entity.PrLPrice = decimal.Parse(txtRePaymentEqual.Text);
                        entity.PrLDate = pdcFirstLoan.PlusMount(ref Pdate, repayment).ToString().ToNormalDate();
                    }
                    entity.PrLDateMiladi = entity.PrLDate.ToDate();
                    entity.IDPayrollLoan=_personid;
                    _PayrollLoanDetail.Add(entity);
                }
            }

            grdLoan.ItemsSource = _PayrollLoanDetail;
        }

        //TODO : form is not validating
        private bool FormIsValid()
        {
            return true;
        }

        private void grdLoan_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (_PayrollLoanDetail.Count > 0)
            {
                Business.GetPayrollLoanDetailBusiness().Save(_PayrollLoanDetail);
                MessageBox.Show("ثبت با موفقیت انجام شد");
            }
        }

        private void txtRePayment_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox s = sender as TextBox;
            if (string.IsNullOrEmpty(s.Text) == false && int.Parse(s.Text) > 12)
            {
                MessageBox.Show("میان بازپرداخت نمیتواند بیشتر از سال شود");
                s.Text = string.Empty;
            }
        }

        private void txtIsNumeric_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }
    }
}
