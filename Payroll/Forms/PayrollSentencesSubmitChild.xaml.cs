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
using System.Data.Entity;
using Common;

namespace AccountingKernel
{
    /// <summary>
    /// Interaction logic for PayrollSentencesSubmitChild.xaml
    /// </summary>
    public partial class PayrollSentencesSubmitChild : Window
    {
        Class.UI.TextHandeler c = new Class.UI.TextHandeler();

        public Guid entityId;

        public PayrollSentencesSubmitChild(PayrollSentence myData)
        {
            InitializeComponent();

            FormLoad(myData);
        }

        private void FormLoad(Data.PayrollSentence _entity)
        {

            cmbBenefitType.ItemsSource = Business.GetBaseInfoBusiness().GetByType(Constants.BaseInfoType.BenefitAndDeductions).Select(r => new
                {
                    Id = r.Id,
                    Name = r.AssignName
                }).ToList();

            cmbType.ItemsSource = Business.GetBaseInfoBusiness().GetByType(Constants.BaseInfoType.Type).Select(r => new
            {
                Id = r.Id,
                Name = r.AssignName
            }).ToList();

            if (_entity != null)
            {
                entityId = _entity.ID;
                cmbBenefitType.SelectedValue = _entity.PrSType.Value;
                txtTitle.Text = _entity.PrSDescription;
                txtPrice.Text = _entity.PrSMoney.ToString();
                chbInsurance.IsChecked = _entity.PrSIsInsurance;
                chbTaxation.IsChecked = _entity.PrSIsTax;
                txtMasterInsurance.Text = _entity.PrSInsuranceEmployer;
                txtUnemploymentInsurance.Text = _entity.PrSInsuranceUnemployment;
                txtEmployeeInsurance.Text = _entity.PrSInsuranceEmployee;
                cmbType.SelectedValue = _entity.PrSOType.Value;
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            var _PayrollSentence = new PayrollSentence();
            if (entityId != Guid.Empty)
                _PayrollSentence = Business.GetPayrollSentencesBusiness().GetById(entityId);

            if (FormIsValid())
            {
                commitchange(_PayrollSentence);
            }

        }

        private void commitchange(PayrollSentence payrollSentence)
        {
            payrollSentence.PrSType = cmbBenefitType.SelectedValue.ToGUID();
            payrollSentence.PrSOType = cmbType.SelectedValue.ToGUID();
            payrollSentence.PrSDescription = txtTitle.Text;
            payrollSentence.PrSMoney = txtPrice.Text.ToDecimal();
            payrollSentence.PrSIsInsurance = chbInsurance.IsChecked;
            payrollSentence.PrSIsTax = chbTaxation.IsChecked;
            payrollSentence.PrSInsuranceEmployer = txtMasterInsurance.Text;
            payrollSentence.PrSInsuranceUnemployment = txtUnemploymentInsurance.Text;
            payrollSentence.PrSInsuranceEmployee = txtEmployeeInsurance.Text;

            Business.GetPayrollSentencesBusiness().Save(payrollSentence);
            this.Close();
        }

        // TODO: form is not check validation bussines
        private bool FormIsValid()
        {
            return string.IsNullOrEmpty(cmbBenefitType.Text) == false &&
                string.IsNullOrEmpty(cmbType.Text) == false &&
                string.IsNullOrEmpty(txtTitle.Text) == false &&
                string.IsNullOrEmpty(txtPrice.Text) == false;
        }

        private void txtPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
            c.AddZero(sender, e);
        }

        private void txtPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            c.SepratTextBox(sender, e);
        }

        private void txtAccountingCode_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }
    }
}
