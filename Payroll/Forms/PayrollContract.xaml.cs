using Common;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for PayrollContract.xaml
    /// </summary>
    public partial class PayrollContract : Window
    {
        AccountingKernel.Class.UI.TextHandeler c = new AccountingKernel.Class.UI.TextHandeler();

        private Guid _personID;

        private List<Class.Variable.PayrollContarctSentences> grdSentenceItemsSoruce;
        private bool IsEdited;

        public PayrollContract()
        {
            InitializeComponent();
            FormLoad();
        }

        public PayrollContract(Guid personid)
        {
            InitializeComponent();
            _personID = personid;
            FormLoad();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FormLoad();
        }

        private void FormLoad()
        {
            var baseInfos = Business.GetBaseInfoBusiness().GetAll().Select(r => new { Id = r.Id, Name = r.AssignName, PId = r.PID }).ToList();
            var payrolltaxCodeenum = Business.GetPayrollTaxCodeBusiness().GetAll().Select(r => new { MId = r.MCode, Id = r.SCode, Name = r.SDesc }).OrderBy(r => r.MId).ToList();

            cmbReceiveSalaryType.ItemsSource = baseInfos.FindAll(r => r.PId == Constants.BaseInfoType.ReceiveSalaryType);
            cmbInsuranceType.ItemsSource = payrolltaxCodeenum.FindAll(r => r.MId == (int)PayrollTaxCodeEnum.InsuranceType);
            cmbSentenceType.ItemsSource = payrolltaxCodeenum.FindAll(r => r.MId == (int)PayrollTaxCodeEnum.EmploymentType);

            var _result = Business.GetPayrollContractBusiness().GetByPersonID(_personID);

            GridSentenceLoad();

            if (_result != null)
            {
                txtSentenceNumber.Text = _result.PrCContractNumber;
                pdcSentenceRegisterTime.Text = _result.PrcDateContractRegister;
                pdcSentenceStartTime.Text = _result.PrcDateContractStart;
                pdcEmploymentTime.Text = _result.PrcDateContractEmployment;
                pdcSentenceEndTime.Text = _result.PrcDateContractEnd;
                pdcSentenceExpireTime.Text = _result.PrcDateContractExpire;
                cmbSentenceType.SelectedValue = _result.PrcContractType;

                txtBankName.Text = _result.PrCBankName;
                txtBankBranch.Text = _result.PrCBranchName;
                txtCardNumber.Text = _result.PrCBranchCartNumber;
                txtAccountNumber.Text = _result.PrCAccountNumber;

                cmbInsuranceType.SelectedValue = _result.PrcInsuranceType;
                txtInsuranceNumber.Text = _result.PrcInsuranceNumber;
                cmbReceiveSalaryType.SelectedValue = _result.PrcSalaryType;
                txtAmount.Text = _result.PrcSalary;
            }
        }

        private void GridSentenceLoad()
        {
            grdSentenceItemsSoruce = Business.GetPayrollContractBusiness().GetItems(_personID).ToList();

            grdSentenceList.ItemsSource = grdSentenceItemsSoruce;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (IsEdited == true)
            {
                List<Data.PayrollPersonSentence> payrollPersonSentence = new List<Data.PayrollPersonSentence>();
                foreach (var item in grdSentenceItemsSoruce)
                {
                    var entity = Business.GetPayrollPersonSentencesBusiness().GetByID(item.ID);
                    entity.IDPayrollPerson = _personID;
                    entity.IDPayrollSentences = item.PayrollSentencesID;
                    entity.PrPSMoney = item.Money;
                    payrollPersonSentence.Add(entity);
                }
                Business.GetPayrollPersonSentencesBusiness().Save(payrollPersonSentence);
                IsEdited = false;
            }

            if (FormIsValid())
            {
                var _PayrollContract = new Data.PayrollContract();
                if (_personID != Guid.Empty)
                    _PayrollContract = Business.GetPayrollContractBusiness().GetById(_personID);
                commitchange(_PayrollContract);
            }
        }

        private void commitchange(Data.PayrollContract _result)
        {
            _result.PrCContractNumber = txtSentenceNumber.Text;
            _result.PrcDateContractRegister = pdcSentenceRegisterTime.Text;
            _result.PrcDateContractStart = pdcSentenceStartTime.Text;
            _result.PrcDateContractEmployment = pdcEmploymentTime.Text;
            _result.PrcDateContractEnd = pdcSentenceEndTime.Text;
            _result.PrcDateContractExpire = pdcSentenceExpireTime.Text;
            _result.PrcContractType = cmbSentenceType.SelectedValue.ToInt();

            _result.PrCBankName = txtBankName.Text;
            _result.PrCBranchName = txtBankBranch.Text;
            _result.PrCBranchCartNumber = txtCardNumber.Text;
            _result.PrCAccountNumber = txtAccountNumber.Text;

            _result.PrcInsuranceType = cmbInsuranceType.SelectedValue.ToInt();
            _result.PrcInsuranceNumber = txtInsuranceNumber.Text;
            _result.PrcSalaryType = cmbReceiveSalaryType.SelectedValue.ToGUID();
            _result.PrcSalary = txtAmount.Text;

            Business.GetPayrollContractBusiness().Save(_result);
            this.Close();
        }

        // TODO: form is not check validation bussines

        private bool FormIsValid()
        {
            return true;
        }


        private void txtAmount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.AddZero(sender, e);
            c.CheckIsNumeric(e);
        }
        
        private void txtIsNumeric_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }

        private void grdSentenceList_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
                IsEdited = true;
        }

        private void btnSentenceList_Click(object sender, RoutedEventArgs e)
        {
            List<Guid?> SentencesID = Business.GetPayrollPersonSentencesBusiness().GetByPersonID(_personID).Select(r => r.IDPayrollSentences).ToList();
            new PayrollSentencesSubmit(true, _personID, SentencesID).ShowDialog();
            GridSentenceLoad();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var DeletedItem = Business.GetPayrollPersonSentencesBusiness().GetByID((grdSentenceList.SelectedItem as dynamic).ID);
            Business.GetPayrollPersonSentencesBusiness().Delete(DeletedItem);
            GridSentenceLoad();
        }
    }
}
