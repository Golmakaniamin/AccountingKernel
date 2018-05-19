
using Common;
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

namespace AccountingKernel.Forms.Company
{
    /// <summary>
    /// Interaction logic for frmCoRegister.xaml
    /// </summary>
    public partial class frmCoRegister : Window
    {

        //Constants.CodeTitle.CompanyMainGroup //asli
        //Constants.CodeTitle.CompanySubsidiaryGroup //faree
        //Constants.CodeTitle.CompanyType 

        Data.CompanyStructureDefine _entity = new Data.CompanyStructureDefine();

        private Data.CompanyStructureDefine _EditedItem;
        private Guid ParentID = new Guid();

        public frmCoRegister()
        {
            InitializeComponent();
            Auto();
        }

        private void Auto()
        {
            int codeTitleLen = (int)Business.GetCodeTitleBusiness().GetById(Common.Constants.CodeTitle.CompanyMainGroup).CodeLen;

            var codes = Business.GetCompanyStructureDefineBusiness().GetAll().Where(r => r.Parent_ID == null).Select(r => r.Code.Substring(0, codeTitleLen));

            foreach (var item in codes)
                txtPrimeryGroupCode.AddItem(new WPFAutoCompleteTextbox.AutoCompleteEntry(item, item));
        }

        public frmCoRegister(Data.CompanyStructureDefine EditedItem)
        {
            InitializeComponent();
            Auto();
            if (EditedItem != null)
            {
                this._EditedItem = EditedItem;
                txtPrimeryGroupCode.IsEnabled = false;
                txtPrimeryGroupName.IsEnabled = false;
                if (Business.GetCompanyStructureDefineBusiness().HaveChildren(EditedItem.ID) == false)
                    txtSecenderyGroupCode.Text = _EditedItem.Code;
                else
                    txtSecenderyGroupCode.IsEnabled = false;

                txtSecenderyGroupName.Text = _EditedItem.Name;

                _entity = _EditedItem;
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (FormIsValid())
            {
                if (txtPrimeryGroupCode.IsEnabled)
                {
                    //ParentID = Business.GetCompanyStructureDefineBusiness().GetRecord(txtPrimeryGroupCode.Text, Constants.CodeTitle.CompanyMainGroup).ID;
                    var s = Business.GetCompanyStructureDefineBusiness().GetRecord(txtPrimeryGroupCode.Text, Constants.CodeTitle.CompanyMainGroup);
                    if (s == null)
                    {
                        string Name = txtPrimeryGroupName.Text;

                        Data.CompanyStructureDefine _entityPrimery =
                            Business.GetCompanyStructureDefineBusiness().GetStructure(Constants.CodeTitle.CompanyMainGroup, Name, null, txtPrimeryGroupCode.Text);

                        Business.GetCompanyStructureDefineBusiness().SaveByID(_entityPrimery);
                        ParentID = _entity.ID;
                    }
                    else
                        ParentID = s.ID;
                }

                if (txtSecenderyGroupCode.Text.IsNullOrEmpty() == false)
                {
                    if (_entity.ID == Guid.Empty)
                    {
                        string Name = string.Format("{0} {1}", txtPrimeryGroupName.Text, txtSecenderyGroupName.Text);
                        string Code = string.Format("{0}{1}", txtPrimeryGroupCode.Text, txtSecenderyGroupCode.Text);
                        _entity = Business.GetCompanyStructureDefineBusiness().
                        GetStructure(Constants.CodeTitle.CompanySubsidiaryGroup, Name, ParentID, Code);
                    }
                    else
                    {
                        _EditedItem.Code = txtSecenderyGroupCode.Text;
                        if (txtSecenderyGroupName.Text.IsNullOrEmpty() == false)
                            _EditedItem.Name = txtSecenderyGroupName.Text;

                        _entity = _EditedItem;
                    }
                    Business.GetCompanyStructureDefineBusiness().SaveByID(_entity);
                }
                this.Close();
            }
        }

        //TODO : Form is not validationg
        private bool FormIsValid()
        {
            return true;
        }

        private void txtPrimeryGroupCode_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                var psds = Business.GetCompanyStructureDefineBusiness().GetStartWithCode(txtPrimeryGroupCode.Text).
                    Where(r => r.Type == Constants.CodeTitle.CompanyMainGroup).FirstOrDefault();
                if (psds != null)
                    txtPrimeryGroupName.Text = psds.Name;
                return;
            }
            catch
            {
                throw;
            }
        }
    }
}
