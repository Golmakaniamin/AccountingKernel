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


namespace AccountingKernel
{
    /// <summary>
    /// Interaction logic for PersonStructureDefineSubmit.xaml
    /// </summary>
    public partial class PersonStructureDefineChild : Window
    {
        //private Data.PersonStructureDefine _entity = new Data.PersonStructureDefine();
        //private bool IsValid = true;
        //private Guid ParentID = Guid.Empty;

        //public readonly int codeTitleLen = (int)Business.GetCodeTitleBusiness().GetById(Common.Constants.CodeTitle.PersonPrimeryGroup).CodeLen;
        //public readonly int codeTitleLenKol = (int)Business.GetCodeTitleBusiness().GetById(Common.Constants.CodeTitle.PersonSecendryGroup).CodeLen;

        //private Data.PersonStructureDefine _editedItem = null;
        //private Data.PersonStructureDefine _entityPrimery = null;
        //public Data.PersonStructureDefine _entitySecondery = null;

        //public Data.PersonStructureDefine EditedItem { get { return _editedItem; } }
        //public Data.PersonStructureDefine EntityPrimery { get { return _entityPrimery; } }
        //public Data.PersonStructureDefine EntitySecondery { get { return _entitySecondery; } }

        //public PersonStructureDefineChild()
        //{
        //    InitializeComponent();

        //    txtPrimeryGroupCode.MaxLen = codeTitleLen;
        //    txtSecenderyGroupCode.MaxLength = codeTitleLenKol;

        //    string DefaultCode = Business.GetPersonStructureDefineChildBusiness().GetDefualtCode(Common.Constants.CodeTitle.PersonPrimeryGroup, Guid.Empty);
        //    txtPrimeryGroupCode.Text = Business.GetPersonStructureDefineChildBusiness().GetCode(Constants.CodeTitle.PersonPrimeryGroup,)
        //        //.GetCode(null, , DefaultCode);
        //    Auto();
        //}

        //public PersonStructureDefineChild(Data.PersonStructureDefine Item)
        //{
        //    InitializeComponent();

        //    txtPrimeryGroupCode.MaxLen = codeTitleLen;
        //    txtSecenderyGroupCode.MaxLength = codeTitleLenKol;

        //    if (Item != null)
        //        this._editedItem = Item;
        //}

        //private void Auto()
        //{
        //    var codes = Business.GetPersonStructureDefineChildBusiness().GetAll().Where(r => r.Parent_ID == null).Select(r => r.Code.Substring(0, codeTitleLen));

        //    foreach (var item in codes)
        //        txtPrimeryGroupCode.AddItem(new WPFAutoCompleteTextbox.AutoCompleteEntry(item, item));
        //}

        //private void btnSubmit_Click(object sender, RoutedEventArgs e)
        //{
        //    if (_editedItem != null && _editedItem.Type == Constants.CodeTitle.PersonPrimeryGroup)
        //    {
        //        if (txtPrimeryGroupCode.IsEnabled)
        //            _editedItem.Code = txtPrimeryGroupCode.Text;
        //        _editedItem.Name = txtPrimeryGroupName.Text;
        //        Business.GetPersonStructureDefineChildBusiness().SaveWithID(_editedItem);
        //    }

        //    if (_editedItem != null && _editedItem.Type == Constants.CodeTitle.PersonSecendryGroup)
        //    {
        //        if (txtSecenderyGroupCode.IsEnabled)
        //        {
        //            var parentCode = _editedItem.Code.Substring(0, codeTitleLen);
        //            _editedItem.Code = string.Format("{0}{1}", parentCode, txtSecenderyGroupCode.Text);
        //        }
        //        _editedItem.Name = txtSecenderyGroupName.Text;
        //        Business.GetPersonStructureDefineChildBusiness().SaveWithID(_editedItem);
        //    }

        //    if (FormIsValid() && IsValid && _editedItem == null)
        //    {
        //        var record = Business.GetPersonStructureDefineChildBusiness().GetRecord(txtPrimeryGroupCode.Text, Constants.CodeTitle.PersonPrimeryGroup);
        //        if (record == null)
        //        {
        //            string Name = txtPrimeryGroupName.Text;

        //            _entityPrimery =
        //                Business.GetPersonStructureDefineChildBusiness().
        //                GetStructure(Constants.CodeTitle.PersonPrimeryGroup, Name, Guid.Empty, txtPrimeryGroupCode.Text);
        //            ParentID = _entityPrimery.ID;
        //            Business.GetPersonStructureDefineChildBusiness().SaveWithID(_entityPrimery);
        //        }
        //        else
        //            ParentID = record.ID;

        //        record = Business.GetPersonStructureDefineChildBusiness().GetRecord(txtSecenderyGroupCode.Text, Constants.CodeTitle.PersonSecendryGroup);
        //        if (record == null)
        //        {
        //            string Code = string.Format("{0}{1}", txtPrimeryGroupCode.Text, txtSecenderyGroupCode.Text);
        //            _entitySecondery =
        //                Business.GetPersonStructureDefineChildBusiness().GetStructure(Constants.CodeTitle.PersonSecendryGroup, txtSecenderyGroupName.Text, ParentID, Code);
        //            Business.GetPersonStructureDefineChildBusiness().SaveWithID(_entitySecondery);
        //        }
        //    }
        //    this.Close();
        //}

        ////TODO : Form is not validationg
        //private bool FormIsValid()
        //{
        //    return true;
        //}

        //public void DisableEvent()
        //{
        //    txtPrimeryGroupName.LostFocus -= txtPrimeryGroupName_LostFocus;
        //}

        //private void txtPrimeryGroupName_LostFocus(object sender, RoutedEventArgs e)
        //{
        //    var Item = Business.GetPersonStructureDefineChildBusiness().GetStartWithCode(txtPrimeryGroupCode.Text)
        //        .Where(r => r.Type == Constants.CodeTitle.PersonPrimeryGroup).FirstOrDefault();

        //    Data.PersonStructureDefine Parent = null;
        //    if (Item != null)
        //        Parent = Business.GetPersonStructureDefineChildBusiness().GetParentID(Item);
        //    string DefaultCode;

        //    if (Parent == null)
        //    {
        //        DefaultCode = Business.GetPersonStructureDefineChildBusiness().GetDefualtCode(Common.Constants.CodeTitle.PersonSecendryGroup, Guid.Empty);
        //        txtSecenderyGroupCode.Text = Business.GetPersonStructureDefineChildBusiness().GetCode(null, Constants.CodeTitle.PersonSecendryGroup, DefaultCode);
        //    }
        //    else
        //    {
        //        DefaultCode = Business.GetPersonStructureDefineChildBusiness().GetDefualtCode(Common.Constants.CodeTitle.PersonSecendryGroup, Parent.ID);
        //        txtSecenderyGroupCode.Text = Business.GetPersonStructureDefineChildBusiness().GetCode(null, Constants.CodeTitle.PersonSecendryGroup, DefaultCode).Substring(codeTitleLen);
        //    }
        //}

        //private void txtSecenderyGroupCode_LostFocus(object sender, RoutedEventArgs e)
        //{
        //    var txtSender = sender as TextBox;
        //    if (txtSender.Text.Length < codeTitleLenKol)
        //    {
        //        IsValid = false;
        //        MessageBox.Show("طول نمیتواند کمتر از حد معمول باشد");
        //    }
        //    if (txtSender.Text.Length == codeTitleLenKol)
        //        IsValid = true;
        //}
        //internal void CallPrimeryLostFocus()
        //{
        //    txtPrimeryGroupName_LostFocus(txtPrimeryGroupCode, new RoutedEventArgs());
        //}

        //private void txtPrimeryGroupCode_LostFocus(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        var psds = Business.GetPersonStructureDefineBusiness().GetStartWithCode(txtPrimeryGroupCode.Text).
        //            Where(r => r.Type == Constants.CodeTitle.PersonPrimeryGroup).FirstOrDefault();
        //        if (psds != null)
        //            txtPrimeryGroupName.Text = psds.Name;
        //        return;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}
        private void txtSecenderyGroupCode_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void txtPrimeryGroupName_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void txtPrimeryGroupCode_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void NumericTextBoxValidation(object sender, TextCompositionEventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}