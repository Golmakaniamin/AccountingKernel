using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Common;
using System.Transactions;
using Data;

namespace AccountingKernel.Forms.Company
{
    /// <summary>
    /// Interaction logic for Document.xaml
    /// </summary>
    public partial class frmEditGroups : Window
    {
        //public CompanyDetail companyDetail;
        //Class.UI.TextHandeler c = new Class.UI.TextHandeler();
        //public frmEditGroups()
        //{
        //    try
        //    {
        //        InitializeComponent();

        //    }
        //    catch
        //    {

        //        throw;
        //    }

        //}

        //public frmEditGroups(CompanyDetail companyDetail)
        //{
        //    try
        //    {
        //        InitializeComponent();
        //        this.companyDetail = companyDetail;
        //        txtName.Text = companyDetail.CDName;

        //        var prefix = SetPrefix();

        //        txtCode.Text = companyDetail.CDIDIn.Remove(0, prefix.Length);
        //    }
        //    catch
        //    {

        //        throw;
        //    }

        //}

        //private string SetPrefix()
        //{
        //    try
        //    {
        //        var prefixCode = string.Empty;
        //        if (companyDetail.IDCodeTitle == Common.Constants.CodeTitle.CompanySubsidiaryGroup)
        //        {
        //            var codeTitle = Business.GetCodeTitleBusiness().GetById(Common.Constants.CodeTitle.CompanyMainGroup);
        //            prefixCode = companyDetail.CDIDIn.Substring(0, codeTitle.CodeLen.Value);
        //        }

        //        return prefixCode;
        //    }
        //    catch
        //    {

        //        throw;
        //    }
        //}

        //private void btnRegister_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        var codeTitle = Business.GetCodeTitleBusiness().GetById(companyDetail.IDCodeTitle.Value);
        //        var prefixCode = SetPrefix();

        //        var entities = Business.GetCompanyDetailBusiness().GetByPrefix(prefixCode).Where(r => r.CDName == companyDetail.CDName).ToList();
        //        if (companyDetail.CDName != txtName.Text && Business.GetCompanyDetailBusiness().GetByName(txtName.Text, companyDetail.IDCodeTitle.Value).Any())
        //            throw new Exception(Localize.ex_duplicate_name);

        //        var code = txtCode.Text.Trim();
        //        if (codeTitle.CodeLen != code.Length)
        //            throw new Exception(Localize.ex_invalid_code_length);

        //        if (companyDetail.CDName != txtName.Text &&
        //            Business.GetCompanyDetailBusiness().GetByCode(prefixCode + code, companyDetail.IDCodeTitle.Value).Where(r => r.CDName == txtName.Text).Any())
        //            throw new Exception(Localize.ex_duplicate_code);


        //        entities.FindAll(r => r.IDCodeTitle == companyDetail.IDCodeTitle).ForEach(r =>
        //        {
        //            r.CDName = txtName.Text;
        //        });

        //        entities.ForEach(r =>
        //        {
        //            r.CDIDIn = prefixCode + code;
        //        });

        //        Business.GetCompanyDetailBusiness().Save(entities);

        //        this.Close();

        //    }
        //    catch
        //    {

        //        throw;
        //    }
        //}

        //private void txtCode_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        //{

            
        //    c.CheckIsNumeric(e);
        //}

        //private void txtName_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        //{
        //    c.JustPersian(e);
        //}


    }
}
