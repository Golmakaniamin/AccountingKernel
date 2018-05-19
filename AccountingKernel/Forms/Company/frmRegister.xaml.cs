using Common;
using System;
using System.Collections.Generic;
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

namespace AccountingKernel.Forms.Company
{
    /// <summary>
    /// Interaction logic for frmRegister.xaml
    /// </summary>
    public partial class frmRegister : Window
    {
        private string CompanyCode;
        private string CompanyName;
        private Guid CompanyParentID;

        Class.UI.TextHandeler c = new Class.UI.TextHandeler();

        private Guid CompanyId;
        private int MainLen;
        private int SubsidiaryLen;
        private int CompanyTypeLen;

        public frmRegister()
        {
            try
            {
                InitializeComponent();

                NormalConstructor();
            }
            catch
            {

                throw;
            }
        }

        public frmRegister(Guid companyId)
        {
            try
            {
                InitializeComponent();

                NormalConstructor();

                this.CompanyId = companyId;

                var company = Business.GetComBusiness().GetById(companyId);
                if (company == null)
                    return;

                cmbCPriceType.SelectedValue = company.CPriceType;
                cmbCType.SelectedValue = company.CType;
                txtLastName.Text = company.CName;
                txtCNameEn.Text = company.CNameEn;
                txtNationalCode.Text = company.CNationalCode;
                txtZipCode.Text = company.CPostalCode;
                txtAddress.Text = company.CAddress;
                txtPhone.Text = company.CTell;
                txtCellPhone.Text = company.CMobile;

                cmbCPersonType.SelectedValue = company.CPersonType.ToGUID();

                txtEconomyCode.Text = company.CEconomyCode;
                txtLegalCRegistrationNo.Text = company.CRegisterNo.ToString();

                txtLegalCRegistrationNo.Text = company.CRegisterNo.ToString();
                txtLegalCRegistrationNo.Text = company.CRegisterNo.HasValue ? company.CRegisterNo.Value.ToString() : null;

            }
            catch
            {

                throw;
            }
        }

        private void btnGetGroup_Click(object sender, RoutedEventArgs e)
        {
            CompanyStructureDefine company = new CompanyStructureDefine();
            company.ShowDialog();
            if (company.Code == null)
                return;

            CompanyCode = company.Code;
            CompanyName = company.Name;

            CompanyParentID = company.ID;

            lblGetGroup.Content = CompanyName;
            txtCDIDInF.Text = CompanyCode.Substring(0, MainLen + SubsidiaryLen);
            txtCDIDInS.Text = CompanyCode.Substring(MainLen + SubsidiaryLen, CompanyTypeLen);
        }

        private void NormalConstructor()
        {
            try
            {
                cmbCPersonType.ItemsSource = Business.GetBaseInfoBusiness().GetByType(Common.Constants.BaseInfoType.Personality);
                cmbCType.ItemsSource = Business.GetBaseInfoBusiness().GetByType(Common.Constants.BaseInfoType.CustomerType);
                cmbCPriceType.ItemsSource = Business.GetBaseInfoBusiness().GetByType(Common.Constants.BaseInfoType.CustomerPriceType);

                MainLen = (int)Business.GetCodeTitleBusiness().GetById(Constants.CodeTitle.CompanyMainGroup).CodeLen;
                SubsidiaryLen = (int)Business.GetCodeTitleBusiness().GetById(Constants.CodeTitle.CompanySubsidiaryGroup).CodeLen;
                CompanyTypeLen = (int)Business.GetCodeTitleBusiness().GetById(Constants.CodeTitle.CompanyType).CodeLen;
                txtCDIDInS.MaxLength = CompanyTypeLen;

                SetControls();
            }
            catch
            {

                throw;
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            var com = new Data.Com();

            if (CompanyId != Guid.Empty)
                com = Business.GetComBusiness().GetById(CompanyId);
            if (FormIsValid() && CompanyCode != null)
            {
                commitchange(com);
            }
        }

        //TODO: Form is not validate
        private bool FormIsValid()
        {
            return true;
        }

        private void commitchange(Data.Com company)
        {
            company.CPriceType = cmbCPriceType.SelectedValue.ToGUID();
            company.CPersonType = cmbCPersonType.SelectedValue.ToGUID();
            company.CType = cmbCType.SelectedValue.ToGUID();
            company.CName = txtLastName.Text;
            company.CNameEn = txtCNameEn.Text;
            company.CNationalCode = txtNationalCode.Text;
            company.CPostalCode = txtZipCode.Text.ToString();
            company.CAddress = txtAddress.Text;
            company.CTell = txtPhone.Text;
            company.CMobile = txtCellPhone.Text;
            company.CRegisterNo = txtLegalCRegistrationNo.Text.ToNullableInt();

            Data.CompanyStructureDefine _companyDefine =
                Business.GetCompanyStructureDefineBusiness().GetStructure(Constants.CodeTitle.CompanyType, txtLastName.Text, CompanyParentID, CompanyCode);

            string s = Business.GetCompanyStructureDefineBusiness().GetMaxCode(CompanyCode).Select(r => r.Code).FirstOrDefault();

            _companyDefine.Type = Constants.CodeTitle.CompanyType;

            using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
            {
                IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted,
                Timeout = new TimeSpan(2, 0, 0)
            }))
            {
                Business.GetCompanyStructureDefineBusiness().SaveByID(_companyDefine);
                company.CompanyStructureDefineId = _companyDefine.ID;
                Business.GetComBusiness().Save(company);
                scope.Complete();
            }

            this.Close();
        }

        private void cmbCPersonType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                SetControls();
            }
            catch
            {

                throw;
            }
        }

        private void SetControls()
        {
            try
            {
                txtLegalCRegistrationNo.IsEnabled = cmbCPersonType.SelectedValue.ToGUID() == Common.Constants.Personality.LegalCompanyType;
            }
            catch
            {

                throw;
            }
        }

        private void txtCNameEn_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.JustEnglish(e);
        }

        private void txtLastName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.JustPersian(e);
        }

        private void txtLegalCRegistrationNo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }

        private void txtNationalCode_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.chequeSerial(e);
        }

        private void txtCellPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }

        private void txtEconomyCode_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }

        private void txtZipCode_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.chequeSerial(e);
        }

        private void txtPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }

        private void txtAddress_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.JustPersian(e);
        }

        private void txtCDIDInS_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }
    }
}
