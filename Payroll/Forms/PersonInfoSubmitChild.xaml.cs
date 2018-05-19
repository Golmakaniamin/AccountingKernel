using Common;
using Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
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
    /// Interaction logic for PersonInfo.xaml
    /// </summary>
    public partial class PersonInfoSubmitChild : Window
    {
        AccountingKernel.Class.UI.TextHandeler c = new AccountingKernel.Class.UI.TextHandeler();
        public Guid entityId;

        private Guid PersonParentID;
        private string PersonCode;
        private string PersonName;
        private int? len;
        private int SecenderyLen;
        private int PrimeryLen;
        private int PersonLen;

        public PersonInfoSubmitChild(Data.PayrollPerson MyData)
        {
            InitializeComponent();
            FormLoad(MyData);
        }

        public PersonInfoSubmitChild()
        {
            InitializeComponent();
            FormLoad(null);
        }

        private void FormLoad(Data.PayrollPerson myData)
        {
            try
            {
                PrimeryLen = (int)Business.GetCodeTitleBusiness().GetById(Constants.CodeTitle.PersonPrimeryGroup).CodeLen;
                SecenderyLen = (int)Business.GetCodeTitleBusiness().GetById(Constants.CodeTitle.PersonSecendryGroup).CodeLen;
                PersonLen = (int)Business.GetCodeTitleBusiness().GetById(Constants.CodeTitle.PersonIDGroup).CodeLen;

                txtCodeS.MaxLength = PersonLen;

                var baseInfos = Business.GetBaseInfoBusiness().GetAll().Select(r => new { Id = r.Id, Name = r.AssignName, PId = r.PID }).ToList();
                var payrolltaxCodeenum = Business.GetPayrollTaxCodeBusiness().GetAll().Select(r => new { MId = r.MCode, Id = r.SCode, Name = r.SDesc }).OrderBy(r => r.MId).ToList();
                var payrollInsuranceCodeenum = Business.GetPayrollInsuranceCodeBusiness().GetAll().Select(r => new { MId = r.MCode, Id = r.SCode, Name = r.SDesc }).OrderBy(r => r.MId).ToList();

                cmbGender.ItemsSource = baseInfos.FindAll(r => r.PId == Constants.BaseInfoType.Gender);
                cmbMarriageState.ItemsSource = baseInfos.FindAll(r => r.PId == Constants.BaseInfoType.MarriageState);
                cmbProofTax.ItemsSource = payrolltaxCodeenum.FindAll(r => r.MId == (int)PayrollTaxCodeEnum.Education);
                cmbJobTax.ItemsSource = payrolltaxCodeenum.FindAll(r => r.MId == (int)PayrollTaxCodeEnum.Job);
                cmbSeriesTax.ItemsSource = payrolltaxCodeenum.FindAll(r => r.MId == (int)PayrollTaxCodeEnum.SHSHSeries);
                cmbHouseStateTax.ItemsSource = payrolltaxCodeenum.FindAll(r => r.MId == (int)PayrollTaxCodeEnum.HouseState);
                cmbNationalityTax.ItemsSource = payrolltaxCodeenum.FindAll(r => r.MId == (int)PayrollTaxCodeEnum.Nationality);
                cmbCountryTax.ItemsSource = payrolltaxCodeenum.FindAll(r => r.MId == (int)PayrollTaxCodeEnum.Country);
                cmbMilitaryTax.ItemsSource = baseInfos.FindAll(r => r.PId == Constants.BaseInfoType.MilitaryStatus);
                cmbJobCategoriesTax.ItemsSource = payrolltaxCodeenum.FindAll(r => r.MId == (int)PayrollTaxCodeEnum.JobCategories);
                cmbCarStateTax.ItemsSource = payrolltaxCodeenum.FindAll(r => r.MId == (int)PayrollTaxCodeEnum.CarState);
                cmbFieldOfStudyInsurance.ItemsSource = payrollInsuranceCodeenum.FindAll(r => r.MId == (int)PayrollInsuranceCodeEnum.FieldOfStudy);
                cmbNationalityInsurance.ItemsSource = payrollInsuranceCodeenum.FindAll(r => r.MId == (int)PayrollInsuranceCodeEnum.Nationality);
                cmbEducationInsurance.ItemsSource = payrollInsuranceCodeenum.FindAll(r => r.MId == (int)PayrollInsuranceCodeEnum.Education);
                cmbJobsInsurance.ItemsSource = payrollInsuranceCodeenum.FindAll(r => r.MId == (int)PayrollInsuranceCodeEnum.Jobs);
                cmbPlaceOfIssue.ItemsSource = payrollInsuranceCodeenum.FindAll(r => r.MId == (int)PayrollInsuranceCodeEnum.PlaceOfIssue);
                cmbCountryInsurance.ItemsSource = payrollInsuranceCodeenum.FindAll(r => r.MId == (int)PayrollInsuranceCodeEnum.Country);
                cmbExemptionTax.ItemsSource = Business.GetLoanTaxBusiness().GetAll().Select(r => new { Name = r.name_moafiat, Id = r.kod_moafiat }).ToList();
                cmbLoanInsurance.ItemsSource = Business.GetLoanInsuranceBusiness().GetAll().Select(r => new { Name = r.name_moafiat, Id = r.kod_moafiat }).ToList();
                if (myData == null)
                    return;

                entityId = myData.id;
                txtCodeF.Text = myData.PPerson_Code.Substring(0, 6);
                txtFirstName.Text = myData.PFristName;
                txtLastName.Text = myData.PLastName;
                txtFather.Text = myData.PFather;

                cmbGender.SelectedValue = myData.PSex;

                txtNationalCode.Text = myData.PIdNational;
                txtSHSH.Text = myData.PSHSH;

                cmbMarriageState.SelectedValue = myData.PMarriage;

                txtQTY.Text = myData.PNumberChild.ToString();
                txtTelWork.Text = myData.PPhoneWork;
                txtTelHome.Text = myData.PPhoneHome;
                txtMobile.Text = myData.PMobile;
                txtPostalCode.Text = myData.PIdPostal;
                pdcBirthDay.Text = myData.PBrithDate;
                txtAddress.Text = myData.PAddress;
                txtTelWork.Text = myData.PDescription;
                //imgPerson.StreamSource =myData.PImage;

                ////imgPerson.Source = myData.PImage
                ////pic
                //FileStream fs = new FileStream(myData.PImage);
                ////byte[] data = new byte[fs.Length];
                ////fs.Read(data, 0, System.Convert.ToInt32(fs.Length));
                ////fs.Close();

                cmbProofTax.SelectedValue = myData.Tax_madrak;
                txtProofTax.Text = myData.Tax_madrak == null ? string.Empty : myData.Tax_madrak.Value.ToString();

                cmbJobTax.SelectedValue = myData.Tax_onvanShoghl;
                txtJobTax.Text = myData.Tax_onvanShoghl == null ? string.Empty : myData.Tax_onvanShoghl.Value.ToString();

                cmbSeriesTax.SelectedValue = myData.Tax_serishenasnameh;
                txtSeriesTax.Text = myData.Tax_serishenasnameh == null ? string.Empty : myData.Tax_serishenasnameh.Value.ToString();

                cmbHouseStateTax.SelectedValue = myData.Tax_vazmaskan;
                txtHouseStateTax.Text = myData.Tax_vazmaskan == null ? string.Empty : myData.Tax_vazmaskan.Value.ToString();

                cmbNationalityTax.SelectedValue = myData.Tax_meliat;
                txtNationalityTax.Text = myData.Tax_meliat == null ? string.Empty : myData.Tax_meliat.Value.ToString();

                cmbCountryTax.SelectedValue = myData.Tax_namekeshvar;
                txtCountryTax.Text = myData.Tax_namekeshvar == null ? string.Empty : myData.Tax_namekeshvar.Value.ToString();

                cmbMilitaryTax.SelectedValue = myData.Tax_nezamvazifeh;

                cmbJobCategoriesTax.SelectedValue = myData.Tax_rasteshoghli;
                txtJobCategoriesTax.Text = myData.Tax_rasteshoghli == null ? string.Empty : myData.Tax_rasteshoghli.Value.ToString();

                cmbExemptionTax.SelectedValue = myData.code_moafiat_maliat;
                txtExemptionTax.Text = myData.code_moafiat_maliat == null ? string.Empty : myData.code_moafiat_maliat.Value.ToString();

                cmbCarStateTax.SelectedValue = myData.Tax_vazmashin;
                txtCarStateTax.Text = myData.Tax_vazmashin == null ? string.Empty : myData.Tax_vazmashin.Value.ToString();

                cmbLoanInsurance.SelectedValue = myData.code_moafiat_bimeh;
                txtLoanInsurance.Text = myData.code_moafiat_bimeh == null ? string.Empty : myData.code_moafiat_bimeh.ToString();

                cmbCountryInsurance.SelectedValue = myData.Insurance_keshvar;
                txtCountryInsurance.Text = myData.Insurance_keshvar == null ? string.Empty : myData.Insurance_keshvar.Value.ToString();

                cmbPlaceOfIssue.SelectedValue = myData.Insurance_shahr;
                txtPlaceOfIssue.Text = myData.Insurance_shahr == null ? string.Empty : myData.Insurance_shahr.Value.ToString();

                cmbJobsInsurance.SelectedValue = myData.Insurance_mashagel;
                txtJobsInsurance.Text = myData.Insurance_mashagel == null ? string.Empty : myData.Insurance_mashagel;

                cmbEducationInsurance.SelectedValue = myData.Insurance_tahsilat;
                txtEducationInsurance.Text = myData.Insurance_tahsilat == null ? string.Empty : myData.Insurance_tahsilat.ToString();

                cmbFieldOfStudyInsurance.SelectedValue = myData.Insurance_reshteh;
                txtFieldOfStudyInsurance.Text = myData.Insurance_reshteh == null ? string.Empty : myData.Insurance_reshteh.ToString();

                cmbNationalityInsurance.SelectedValue = myData.Insurance_meliat;
                txtNationalityInsurance.Text = myData.Insurance_meliat == null ? string.Empty : myData.Insurance_meliat.ToString();
            }
            catch
            {

                throw;
            }

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox s = sender as ComboBox;
            if (s.SelectedValue != null)
            {
                string txtName = string.Format("txt{0}", s.Name.Substring(3));
                TextBox myTextBlock = (TextBox)this.FindName(txtName);
                myTextBlock.Text = s.SelectedValue.ToString();
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                TextBox t = sender as TextBox;
                if (t.Text.IsNullOrEmpty())
                    return;

                string cmbName = string.Format("cmb{0}", t.Name.Substring(3));
                ComboBox myComboBox = (ComboBox)this.FindName(cmbName);
                myComboBox.SelectedValue = t.Text;
                t.Text = t.Text;
            }
            catch
            {

                throw;
            }

        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            var _payrollPerson = new Data.PayrollPerson();
            if (entityId != Guid.Empty)
                _payrollPerson = Business.GetPayrollPersonBusiness().GetById(entityId);

            if (FormIsValid() && PersonCode != null)
            {
                commitchange(_payrollPerson);
            }
        }

        private void commitchange(PayrollPerson payrollPerson)
        {


            payrollPerson.PFristName = txtFirstName.Text;
            payrollPerson.PLastName = txtLastName.Text;
            payrollPerson.PFather = txtFather.Text;
            payrollPerson.PSex = cmbGender.SelectedValue.ToGUID();
            payrollPerson.PIdNational = txtNationalCode.Text;
            payrollPerson.PSHSH = txtSHSH.Text;
            payrollPerson.PMarriage = cmbMarriageState.SelectedValue.ToGUID();
            payrollPerson.PNumberChild = txtQTY.Text.ToInt();
            payrollPerson.PPhoneWork = txtTelWork.Text;
            payrollPerson.PPhoneHome = txtTelHome.Text;
            payrollPerson.PMobile = txtMobile.Text;
            payrollPerson.PIdPostal = txtPostalCode.Text;
            payrollPerson.PBrithDate = pdcBirthDay.Text;
            payrollPerson.PAddress = txtAddress.Text;
            payrollPerson.PDescription = txtDesc.Text;
            payrollPerson.Tax_madrak = (int)cmbProofTax.SelectedValue;
            payrollPerson.Tax_onvanShoghl = (int)cmbJobTax.SelectedValue;
            payrollPerson.Tax_serishenasnameh = (int)cmbSeriesTax.SelectedValue;
            payrollPerson.Tax_vazmaskan = (int)cmbHouseStateTax.SelectedValue;
            payrollPerson.Tax_meliat = (int)cmbNationalityTax.SelectedValue;
            payrollPerson.Tax_namekeshvar = (int)cmbCountryTax.SelectedValue;
            payrollPerson.Tax_nezamvazifeh = cmbMilitaryTax.SelectedValue.ToGUID();
            payrollPerson.Tax_rasteshoghli = (int)cmbJobCategoriesTax.SelectedValue;
            payrollPerson.Tax_vazmashin = (int)cmbCarStateTax.SelectedValue;
            payrollPerson.code_moafiat_maliat = (int)cmbLoanInsurance.SelectedValue;
            payrollPerson.Insurance_keshvar = (int)cmbCountryInsurance.SelectedValue;
            payrollPerson.Insurance_shahr = (int)cmbPlaceOfIssue.SelectedValue;
            payrollPerson.Insurance_mashagel = cmbJobsInsurance.SelectedValue.ToString();
            payrollPerson.Insurance_tahsilat = (int)cmbEducationInsurance.SelectedValue;
            payrollPerson.Insurance_reshteh = (int)cmbFieldOfStudyInsurance.SelectedValue;
            payrollPerson.Insurance_meliat = cmbNationalityInsurance.SelectedValue.ToString();
            payrollPerson.code_moafiat_bimeh = (int)cmbExemptionTax.SelectedValue;
            payrollPerson.PPerson_Code = string.Format("{0}{1}", txtCodeF.Text, txtCodeS.Text);
            string pname = string.Format("{0} {1}", txtFirstName.Text, txtLastName.Text);
            Data.PersonStructureDefine _personDefine =
                Business.GetPersonStructureDefineChildBusiness().GetStructure(Constants.CodeTitle.PersonIDGroup, pname, PersonParentID, payrollPerson.PPerson_Code);

            payrollPerson.PPerson_Code = _personDefine.Code;

            int Primerycodelen = (int)Business.GetCodeTitleBusiness().GetById(Constants.CodeTitle.PersonPrimeryGroup).CodeLen;
            int Secendarycodelen = (int)Business.GetCodeTitleBusiness().GetById(Constants.CodeTitle.PersonPrimeryGroup).CodeLen;
            string s = Business.GetPersonStructureDefineBusiness().GetMaxCode(PersonCode).Select(r => r.Code).FirstOrDefault();

            _personDefine.Type = Constants.CodeTitle.PersonIDGroup;

            using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
            {
                IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted,
                Timeout = new TimeSpan(2, 0, 0)
            }))
            {
                Business.GetPersonStructureDefineChildBusiness().SaveWithID(_personDefine);
                payrollPerson.PersonStructerID = _personDefine.ID;
                Business.GetPayrollPersonBusiness().Save(payrollPerson);
                Business.GetPayrollPersonWorkDoneBusiness().Save(new PayrollPersonWorkDone() { IDPayrollPerson = payrollPerson.id });
                scope.Complete();
            }

            this.Close();
        }

        // TODO: form is not check validation bussines
        private bool FormIsValid()
        {
            return true;
        }

        private void btnGetGroup_Click(object sender, RoutedEventArgs e)
        {
            PersonGroupChoose person = new PersonGroupChoose();
            person.ShowDialog();
            if (person.Code == null)
                return;
            PersonCode = person.Code;
            PersonName = person.Name;

            PersonParentID = person.ID;

            lblPersonGroup.Content = PersonName;
            txtCodeF.Text = PersonCode.Substring(0, PrimeryLen + SecenderyLen);
            txtCodeS.Text = PersonCode.Substring(PrimeryLen + SecenderyLen, PersonLen);
        }

        private void txtCode_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsAccountNumber(e);
        }

        private void txtFirstName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.JustPersian(e);
        }

        private void txtLastName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.JustPersian(e);
        }

        private void txtFather_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.JustPersian(e);
        }

        private void txtQTY_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }

        private void txtNationalCode_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }

        private void txtSHSH_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }

        private void txtMobile_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }

        private void txtTelHome_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }

        private void txtTelWork_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }

        private void txtAddress_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.JustPersian(e);
        }

        private void txtPostalCode_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.chequeSerial(e);
        }

        private void txtDesc_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.JustPersian(e);
        }

        private void txtProofTax_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }

        private void txtJobTax_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }

        private void txtSeriesTax_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }

        private void txtHouseStateTax_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }

        private void txtNationalityTax_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }

        private void txtCountryTax_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }

        private void txtJobCategoriesTax_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }

        private void txtExemptionTax_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }

        private void txtCarStateTax_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }

        private void txtLoanInsurance_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }

        private void txtCountryInsurance_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }

        private void txtPlaceOfIssue_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }

        private void txtJobsInsurance_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }

        private void txtEducationInsurance_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }

        private void txtFieldOfStudyInsurance_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }

        private void txtNationalityInsurance_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }
    }
}
