using Common;
using Data;
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
    /// Interaction logic for PayrollMPJ.xaml
    /// </summary>
    public partial class PayrollMPJ : Window
    {
        //AccountingKernel.Class.UI.TextHandeler c = new AccountingKernel.Class.UI.TextHandeler();
        Class.UI.TextHandeler c = new Class.UI.TextHandeler();
        List<Data.PayrollImprest> _payrollImprest = new List<Data.PayrollImprest>();

        private Guid _personid;
        private Guid _financialyear;
        private Guid _sentencesid;

        public PayrollMPJ()
        {
            InitializeComponent();
            FormLoad();
        }

        public PayrollMPJ(Guid personid, Guid financialyear)
        {
            InitializeComponent();
            _personid = personid;
            _financialyear = financialyear;
            FormLoad();
        }

        private void FormLoad()
        {

            cmbType.ItemsSource =
                Business.GetPayrollSentencesBusiness().GetSentenceByUserId(_personid).Select(r => new
                {
                    id = r.ID,
                    Name = r.PrSDescription
                }).ToList();

            cmbType.SelectedIndex = 0;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FormLoad();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            grdMPJ.ItemsSource = null;
            Data.PayrollImprest _entiry = null;

            if (FormIsValid())
            {
                _entiry = new Data.PayrollImprest();

                _entiry.IDFinancialyear = _financialyear;
                _entiry.IDPayrollPerson = _personid;
                _entiry.IDPayrollSentences = cmbType.SelectedValue.ToGUID();
                //SelectedValuePath="{Binding Id}
                _entiry.PrIDate = pdcDate.Text;
                _entiry.PrIPrice = decimal.Parse(txtPrice.Text);

                _payrollImprest.Add(_entiry);

                Grid_combo_Type.ItemsSource = cmbType.ItemsSource;
            }
            grdMPJ.ItemsSource = _payrollImprest;

        }

        //TODO : form is not validate
        private bool FormIsValid()
        {
            return true;
        }

        private void btnCommit_Click(object sender, RoutedEventArgs e)
        {
            if (_payrollImprest != null)
            {
                Business.GetPayrollMPJBusiness().Save(_payrollImprest);
                MessageBox.Show("ثبت با موفقیت انجام شد");
            }
        }

        private void txtPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void txtPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
            c.AddZero(sender,e);
        }
    }
}
