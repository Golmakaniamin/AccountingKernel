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
using Common;

namespace AccountingKernel.Forms.Company
{
    /// <summary>
    /// Interaction logic for frmRegisterCompanies.xaml
    /// </summary>
    public partial class frmRegisterCompanies : Window
    {
        Class.UI.TextHandeler c = new Class.UI.TextHandeler();
        Guid? CompanyId;

        public frmRegisterCompanies()
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

        public frmRegisterCompanies(Guid companyId)
        {
            try
            {
                InitializeComponent();

                NormalConstructor();

                this.CompanyId = companyId;
                var companyBusiness = Business.GetCompanyBusiness();
                var companyDetailBusiness = Business.GetCompanyDetailBusiness();
                var company = companyBusiness.GetById(companyId);
                if (company == null)
                    return;

                var companyMainGroup = companyDetailBusiness.GetByCompanyId(companyId, Constants.CodeTitle.CompanyMainGroup).First();
                var companySubsidiaryGroup = companyDetailBusiness.GetByCompanyId(companyId, Constants.CodeTitle.CompanySubsidiaryGroup).First();
                var companyType = companyDetailBusiness.GetByCompanyId(companyId, Constants.CodeTitle.CompanyType).First();

                txtMainGroup.Text = companyMainGroup == null ? string.Empty : companyMainGroup.CDName;
                txtSubsidiaryGroup.Text = companySubsidiaryGroup == null ? string.Empty : companySubsidiaryGroup.CDName;

                cmbCPriceType.SelectedValue = company.CPriceType;
                cmbCType.SelectedValue = company.CType;
                txtLastName.Text = company.CName;
                txtCNameEn.Text = company.CNameEn;
                txtNationalCode.Text = company.CNationalCode;
                txtZipCode.Text = company.CPostalCode;
                txtAddress.Text = company.CAddress;
                txtPhone.Text = company.CTell;
                txtCellPhone.Text = company.CMobile;

                txtMainGroupCode.Text = companyMainGroup.CDIDIn;
                txtSubsidiaryGroupCode.Text = companySubsidiaryGroup.CDIDIn.Remove(0, companyMainGroup.CDIDIn.Length);
                txtCDIDIn.Text = companyType.CDIDIn.Remove(0, companySubsidiaryGroup.CDIDIn.Length);

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

        private void NormalConstructor()
        {
            try
            {
                var mainGrpups = Business.GetCompanyDetailBusiness().GetByCodeTitleId(Common.Constants.CodeTitle.CompanyMainGroup).ToList();
                mainGrpups.Select(r => r.CDName).Distinct().ToList().ForEach(r => txtMainGroup.AddItem(new WPFAutoCompleteTextbox.AutoCompleteEntry(r, r)));
                mainGrpups.Select(r => r.CDIDIn).Distinct().ToList().ForEach(r => txtMainGroupCode.AddItem(new WPFAutoCompleteTextbox.AutoCompleteEntry(r, r)));

                cmbCPersonType.ItemsSource = Business.GetBaseInfoBusiness().GetByType(Common.Constants.BaseInfoType.Personality);
                cmbCType.ItemsSource = Business.GetBaseInfoBusiness().GetByType(Common.Constants.BaseInfoType.CustomerType);
                cmbCPriceType.ItemsSource = Business.GetBaseInfoBusiness().GetByType(Common.Constants.BaseInfoType.CustomerPriceType);
                SetControls();
            }
            catch
            {

                throw;
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var companyBusiness = Business.GetCompanyBusiness();
                var companyDetailBusiness = Business.GetCompanyDetailBusiness();

                using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
                {
                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted,
                    Timeout = new TimeSpan(2, 0, 0)
                }))
                {
                    var company = new Data.Company();

                    if (this.CompanyId.HasValue)
                        company = companyBusiness.GetById(this.CompanyId.Value);


                    var comapnyMainGroupName = string.Empty;
                    var companySubsidiaryGroupName = string.Empty;

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
                    comapnyMainGroupName = txtMainGroup.Text;
                    companySubsidiaryGroupName = txtSubsidiaryGroup.Text;

                    company.CRegisterNo = txtLegalCRegistrationNo.Text.ToNullableInt();

                    companyBusiness.Save(company);
                    this.CompanyId = company.Id;

                    var companyMainGroup = companyDetailBusiness.GetByCompanyId(CompanyId, Constants.CodeTitle.CompanyMainGroup).FirstOrDefault();

                    if (companyMainGroup == null)
                    {
                        companyMainGroup = new Data.CompanyDetail()
                            {
                                CDName = comapnyMainGroupName,
                                CDIDIn = txtMainGroupCode.Text,
                                IDCodeTitle = Common.Constants.CodeTitle.CompanyMainGroup,
                                IDCompany = CompanyId
                            };

                        Business.GetCompanyDetailBusiness().Save(companyMainGroup);
                    }

                    var companySubsidiaryGroup = companyDetailBusiness.GetByCompanyId(CompanyId, Constants.CodeTitle.CompanySubsidiaryGroup).FirstOrDefault();

                    if (companySubsidiaryGroup == null)
                    {
                        companySubsidiaryGroup = new Data.CompanyDetail()
                        {
                            CDName = companySubsidiaryGroupName,
                            CDIDIn = txtMainGroupCode.Text + txtSubsidiaryGroupCode.Text,
                            IDCodeTitle = Common.Constants.CodeTitle.CompanySubsidiaryGroup,
                            IDCompany = this.CompanyId,
                        };
                        Business.GetCompanyDetailBusiness().Save(companySubsidiaryGroup);
                    }

                    var companyType = companyDetailBusiness.GetByCompanyId(companySubsidiaryGroup.Id, Constants.CodeTitle.CompanyType).FirstOrDefault();

                    if (companyType == null)
                    {
                        companyType = new Data.CompanyDetail()
                        {
                            CDName = txtLastName.Text,
                            CDIDIn = txtMainGroupCode.Text + txtSubsidiaryGroupCode.Text + txtCDIDIn.Text,
                            IDCodeTitle = Common.Constants.CodeTitle.CompanyType,
                            IDCompany = this.CompanyId,
                        };
                        Business.GetCompanyDetailBusiness().Save(companyType);
                    }

                    scope.Complete();
                }

                this.Close();

            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void txtMainGroup_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {

                var mainGroup = Business.GetCompanyDetailBusiness().GetByName(txtMainGroup.Text, Common.Constants.CodeTitle.CompanyMainGroup).FirstOrDefault();
                if (mainGroup == null)
                {
                    txtMainGroupCode.Text = Business.GetCompanyDetailBusiness().GetNewCode(Common.Constants.CodeTitle.CompanyMainGroup, string.Empty);
                    btnSaveMainGroup.IsEnabled = false;
                    return;
                }

                btnSaveMainGroup.IsEnabled = true;

                txtMainGroupCode.Text = mainGroup.CDIDIn;

                SetTXTSubsidiaryGroupCode(mainGroup);
            }
            catch
            {

                throw;
            }
        }

        private void txtMainGroupCode_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                var mainGroup = Business.GetCompanyDetailBusiness().GetByCode(txtMainGroupCode.Text, Common.Constants.CodeTitle.CompanyMainGroup).FirstOrDefault();
                if (mainGroup == null)
                {
                    btnSaveMainGroup.IsEnabled = false;
                    return;
                }

                btnSaveMainGroup.IsEnabled = true;

                txtMainGroup.Text = mainGroup.CDName;
                var subsidiaryGroups = Business.GetCompanyDetailBusiness().GetByCodeTitleId(Common.Constants.CodeTitle.CompanySubsidiaryGroup).ToList();

                subsidiaryGroups.Select(r => r.CDName).Distinct().ToList().ForEach(r => txtSubsidiaryGroup.AddItem(new WPFAutoCompleteTextbox.AutoCompleteEntry(r, r)));
                subsidiaryGroups.Select(r => r.CDIDIn).Distinct().ToList().ForEach(r => txtSubsidiaryGroupCode.AddItem(new WPFAutoCompleteTextbox.AutoCompleteEntry(r, r)));

            }
            catch
            {

                throw;
            }
        }

        private void txtSubsidiaryGroupCode_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {

                var subsidiaryGroup = Business.GetCompanyDetailBusiness().GetByCode(txtSubsidiaryGroupCode.Text, Common.Constants.CodeTitle.CompanySubsidiaryGroup).FirstOrDefault();
                if (subsidiaryGroup == null)
                {
                    btnSaveSubsidiaryGroup.IsEnabled = false;
                    return;
                }

                btnSaveSubsidiaryGroup.IsEnabled = true;

                txtSubsidiaryGroup.Text = subsidiaryGroup.CDName;

            }
            catch
            {

                throw;
            }
        }

        private void txtSubsidiaryGroup_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                var companyDetailBusiness = Business.GetCompanyDetailBusiness();
                var subsidiaryGroup = companyDetailBusiness.GetByName(txtSubsidiaryGroup.Text, Common.Constants.CodeTitle.CompanySubsidiaryGroup).FirstOrDefault();
                if (subsidiaryGroup == null)
                {
                    txtSubsidiaryGroupCode.Text = companyDetailBusiness.GetNewCode(Common.Constants.CodeTitle.CompanySubsidiaryGroup, txtMainGroupCode.Text);
                    btnSaveSubsidiaryGroup.IsEnabled = false;
                    return;
                }

                btnSaveSubsidiaryGroup.IsEnabled = true;

                txtSubsidiaryGroupCode.Text = subsidiaryGroup.CDIDIn.Remove(0, txtMainGroupCode.Text.Length);

            }
            catch
            {

                throw;
            }
        }

        private void btnSaveMainGroup_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var mainGroup = Business.GetCompanyDetailBusiness().GetByCode(txtMainGroupCode.Text, Common.Constants.CodeTitle.CompanyMainGroup).FirstOrDefault();
                if (mainGroup == null)
                    return;

                //var frmEditGroups = new frmEditGroups(mainGroup);
                //frmEditGroups.ShowDialog();
                //SetTXTSubsidiaryGroupCode(mainGroup);
                //txtMainGroupCode.Text = frmEditGroups.companyDetail.CDIDIn;
                //txtMainGroup.Text = frmEditGroups.companyDetail.CDName;
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void btnSaveSubsidiaryGroup_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var subsidiaryGroup = Business.GetCompanyDetailBusiness().GetByCode(txtSubsidiaryGroupCode.Text, Common.Constants.CodeTitle.CompanySubsidiaryGroup).FirstOrDefault();
                if (subsidiaryGroup == null)
                    return;

                //var frmEditGroups = new frmEditGroups(subsidiaryGroup);
                //frmEditGroups.ShowDialog();
                //txtSubsidiaryGroupCode.Text = frmEditGroups.companyDetail.CDIDIn;
                //txtSubsidiaryGroup.Text = frmEditGroups.companyDetail.CDName;

            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void SetTXTSubsidiaryGroupCode(Data.CompanyDetail companyDetail)
        {
            try
            {

                var subsidiaryGroups = Business.GetCompanyDetailBusiness().GetByCodeTitleId(Common.Constants.CodeTitle.CompanyMainGroup).
                    Where(r => r.CDIDIn.StartsWith(companyDetail.CDIDIn)).ToList();

                subsidiaryGroups.Select(r => r.CDName).Distinct().ToList().ForEach(r => txtSubsidiaryGroup.AddItem(new WPFAutoCompleteTextbox.AutoCompleteEntry(r, r)));
                subsidiaryGroups.Select(r => r.CDIDIn).Distinct().ToList().ForEach(r => txtSubsidiaryGroupCode.AddItem(new WPFAutoCompleteTextbox.AutoCompleteEntry(r, r)));
            }
            catch
            {

                throw;
            }
        }

        private void txtRealCDIDIn_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {


            c.CheckIsNumeric(e);
        }

        private void txtMainGroupCode_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {


            c.CheckIsNumeric(e);
        }

        private void txtSubsidiaryGroupCode_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {


            c.CheckIsNumeric(e);
        }

        private void txtLastName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.JustPersian(e);
        }

        private void txtAddress_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.JustPersian(e);
        }

        private void txtLegalAddress_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.JustPersian(e);
        }

        private void txtLastName_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {

                var companyDetailBusiness = Business.GetCompanyDetailBusiness();
                var company = companyDetailBusiness.GetByName(txtLastName.Text, Common.Constants.CodeTitle.CompanyType).FirstOrDefault();
                if (company == null)
                    txtCDIDIn.Text = companyDetailBusiness.GetNewCode(Common.Constants.CodeTitle.CompanyType, txtMainGroupCode.Text + txtSubsidiaryGroupCode.Text);
                else
                    txtCDIDIn.Text = company.CDIDIn;

                txtCDIDIn.Text = txtCDIDIn.Text.Remove(0, txtMainGroupCode.Text.Length + txtSubsidiaryGroupCode.Text.Length);

            }
            catch
            {

                throw;
            }
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

        private void txtCellPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }

        private void txtPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }

        private void txtZipCode_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.chequeSerial(e);
        }



    }
}
