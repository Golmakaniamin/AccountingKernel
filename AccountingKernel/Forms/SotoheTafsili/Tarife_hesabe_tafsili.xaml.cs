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

namespace AccountingKernel.Forms.SotoheTafsili
{
    /// <summary>
    /// Interaction logic for Tarife_hesabe_tafsili.xaml
    /// </summary>
    public partial class Tarife_hesabe_tafsili : Window
    {
        private string PrimeryCode;
        private string SecondaryCode;
        private string PrimeryName;
        private string PrimeryLatinName;
        private string SecondaryLatinName;
        private string SecondaryName;
        private Guid TafsilGroup = Constants.CodeTitle.TafsilGroup;
        private Guid AccountGroup = Constants.CodeTitle.AccountGroup;

        public readonly int codeTitleLen = (int)Business.GetCodeTitleBusiness().GetById(Constants.CodeTitle.TafsilGroup).CodeLen;
        public readonly int codeTitleLenChild = (int)Business.GetCodeTitleBusiness().GetById(Common.Constants.CodeTitle.AccountGroup).CodeLen;

        private Data.AccountingTafsilStructureDefine _editedItem = null;
        private Data.AccountingTafsilStructureDefine _entityPrimery = null;
        public Data.AccountingTafsilStructureDefine _entitySecondery = null;
        public Data.AccountingTafsilStructureDefine EditedItem { get { return _editedItem; } }
        public Data.AccountingTafsilStructureDefine EntityPrimery { get { return _entityPrimery; } }
        public Data.AccountingTafsilStructureDefine EntitySecondery { get { return _entitySecondery; } }

        public Tarife_hesabe_tafsili()
        {
            InitializeComponent();
            txtPrimeryGroupCode.MaxLen = codeTitleLen;
            txtSecenderyGroupCode.MaxLength = codeTitleLenChild;
            txtPrimeryGroupCode.Text = Business.GetTafsilStructureDefineBusiness().GetDefualtCode(TafsilGroup, null);

            Auto();
        }

        public Tarife_hesabe_tafsili(Data.AccountingTafsilStructureDefine Item)
        {
            InitializeComponent();

            txtPrimeryGroupCode.MaxLen = codeTitleLen;
            txtSecenderyGroupCode.MaxLength = codeTitleLenChild;

            if (Item != null)
                this._editedItem = Item;
        }

        private void Auto()
        {
            var codes = Business.GetTafsilStructureDefineBusiness().GetAll().Where(r => r.Parent_ID.Equals(null)).Select(r => r.Code.Substring(0, codeTitleLen));
            foreach (var item in codes)
                txtPrimeryGroupCode.AddItem(new WPFAutoCompleteTextbox.AutoCompleteEntry(item, item));
        }

        public void DisableEvent()
        {
            txtPrimeryGroupName.LostFocus -= txtPrimeryGroupName_LostFocus;
        }

        internal void CallPrimeryLostFocus()
        {
            txtPrimeryGroupName_LostFocus(txtPrimeryGroupCode, new RoutedEventArgs());
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            PrimeryCode = txtPrimeryGroupCode.Text;
            PrimeryName = txtPrimeryGroupName.Text;


            SecondaryCode = string.Format("{0}{1}", PrimeryCode, txtSecenderyGroupCode.Text);
            SecondaryName = txtSecenderyGroupName.Text;


            try
            {
                if (string.IsNullOrEmpty(txtPrimeryGroupCode.Text) || txtPrimeryGroupCode.Text.Length < codeTitleLen)
                    throw new Exception(Localize.nullCode);

                if (string.IsNullOrEmpty(PrimeryName))
                    throw new Exception(Localize.nullName);

                if (string.IsNullOrEmpty(txtSecenderyGroupCode.Text) == false && string.IsNullOrEmpty(txtSecenderyGroupName.Text))
                    throw new Exception(Localize.nullName);

                if (string.IsNullOrEmpty(txtSecenderyGroupCode.Text) && string.IsNullOrEmpty(txtSecenderyGroupName.Text) == false)
                    throw new Exception(Localize.nullName);

                if (txtSecenderyGroupCode.Text.Length > 0 && txtSecenderyGroupCode.Text.Length < codeTitleLenChild)
                    throw new Exception(Localize.nullCode);

                if (_editedItem != null && _editedItem.Type == TafsilGroup)
                {
                    _editedItem.Code = PrimeryCode;
                    _editedItem.Name = PrimeryName;
                    _editedItem.Latin_Name = PrimeryLatinName;
                    Business.GetTafsilStructureDefineBusiness().SaveWithID(_editedItem);
                    this.Close();
                    return;
                }

                if (_editedItem != null && _editedItem.Type == AccountGroup)
                {
                    if (FormIsValid(txtSecenderyGroupCode.Text))
                    {
                        _editedItem.Code = SecondaryCode;
                        _editedItem.Name = SecondaryName;
                        _editedItem.Latin_Name = SecondaryLatinName;
                        Business.GetTafsilStructureDefineBusiness().SaveWithID(_editedItem);
                        this.Close();
                        return;
                    }
                    else
                        return;
                }

                if (FormIsValid(txtSecenderyGroupCode.Text) && FormIsValid(txtSecenderyGroupName.Text))
                {
                    Guid ParentID = Guid.Empty;
                    var record = Business.GetTafsilStructureDefineBusiness().GetRecord(PrimeryCode, TafsilGroup);
                    if (record == null)
                    {
                        _entityPrimery = Business.GetTafsilStructureDefineBusiness().GetStructure(TafsilGroup, PrimeryName, PrimeryLatinName, null, PrimeryCode);
                        ParentID = _entityPrimery.ID;
                        Business.GetTafsilStructureDefineBusiness().SaveWithID(_entityPrimery);
                    }
                    else
                        ParentID = record.ID;

                    if (string.IsNullOrEmpty(txtSecenderyGroupCode.Text) == false && string.IsNullOrEmpty(txtSecenderyGroupName.Text) == false)
                    {
                        record = Business.GetTafsilStructureDefineBusiness().GetRecord(SecondaryCode, AccountGroup);
                        if (record == null)
                        {
                            _entitySecondery = Business.GetTafsilStructureDefineBusiness().GetStructure(AccountGroup, SecondaryName, SecondaryLatinName, ParentID, SecondaryCode);
                            Business.GetTafsilStructureDefineBusiness().SaveWithID(_entitySecondery);
                        }
                        else
                            throw new Exception(Localize.DoubleCode);
                    }
                    this.Close();
                }
            }
            catch (Exception s)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(s);
            }
            return;

        }

        //private void btnSubmit_Click(object sender, RoutedEventArgs e)
        //{
        //    PrimeryCode = txtPrimeryGroupCode.Text;
        //    PrimeryName = txtPrimeryGroupName.Text;

        //    SecondaryCode = string.Format("{0}{1}", PrimeryCode, txtSecenderyGroupCode.Text);
        //    SecondaryName = txtSecenderyGroupName.Text;


        //    if (string.IsNullOrEmpty(PrimeryName))
        //        return;
        //    if (string.IsNullOrEmpty(txtSecenderyGroupCode.Text) == false && string.IsNullOrEmpty(txtSecenderyGroupName.Text))
        //        return;
        //    if (string.IsNullOrEmpty(txtSecenderyGroupCode.Text) && string.IsNullOrEmpty(txtSecenderyGroupName.Text) == false)
        //        return;

        //    if (_editedItem != null && _editedItem.Type == TafsilGroup)
        //    {
        //        _editedItem.Code = PrimeryCode;
        //        _editedItem.Name = PrimeryName;
        //        _editedItem.Latin_Name = PrimeryLatinName;
        //        Business.GetTafsilStructureDefineBusiness().SaveWithID(_editedItem);
        //        this.Close();
        //        return;
        //    }

        //    if (_editedItem != null && _editedItem.Type == AccountGroup)
        //    {
        //        if (FormIsValid(txtSecenderyGroupCode.Text))
        //        {
        //            _editedItem.Code = SecondaryCode;
        //            _editedItem.Name = SecondaryName;
        //            _editedItem.Latin_Name = SecondaryLatinName;
        //            Business.GetTafsilStructureDefineBusiness().SaveWithID(_editedItem);
        //            this.Close();
        //            return;
        //        }
        //        else return;

        //    }           

        //    if (FormIsValid(txtSecenderyGroupCode.Text) && FormIsValid(txtSecenderyGroupName.Text))
        //    {
        //        Guid ParentID = Guid.Empty;
        //        var record = Business.GetTafsilStructureDefineBusiness().GetRecord(PrimeryCode, TafsilGroup);
        //        if (record == null)
        //        {
        //            _entityPrimery = Business.GetTafsilStructureDefineBusiness().GetStructure(TafsilGroup, PrimeryName, PrimeryLatinName, null, PrimeryCode);
        //            ParentID = _entityPrimery.ID;
        //            Business.GetTafsilStructureDefineBusiness().SaveWithID(_entityPrimery);
        //        }
        //        else
        //            ParentID = record.ID;

        //        if (string.IsNullOrEmpty(txtSecenderyGroupCode.Text) == false && string.IsNullOrEmpty(txtSecenderyGroupName.Text) == false)
        //        {
        //            record = Business.GetTafsilStructureDefineBusiness().GetRecord(SecondaryCode, AccountGroup);
        //            if (record == null)
        //            {
        //                _entitySecondery = Business.GetTafsilStructureDefineBusiness().GetStructure(AccountGroup, SecondaryName, SecondaryLatinName, ParentID, SecondaryCode);
        //                Business.GetTafsilStructureDefineBusiness().SaveWithID(_entitySecondery);
        //            }
        //            else
        //                MessageBox.Show("کد کل تکراری است");
        //        }
        //        this.Close();
        //        return;
        //    }
        //}

        private bool FormIsValid(string Code)
        {
            if (string.IsNullOrEmpty(Code) == false && Code.Length < codeTitleLenChild)
            {
                MessageBox.Show("طول نمیتواند کمتر از حد تعیین شده باشد");
                return false;
            }

            return true;
        }

        private void txtPrimeryGroupCode_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                var psds = Business.GetTafsilStructureDefineBusiness().GetRecord(txtPrimeryGroupCode.Text, TafsilGroup);
                if (psds != null)
                {
                    txtPrimeryGroupName.Text = psds.Name;
                    CallPrimeryLostFocus();
                }
                return;
            }
            catch
            {
                throw;
            }
        }

        private void txtPrimeryGroupName_LostFocus(object sender, RoutedEventArgs e)
        {
            Data.AccountingTafsilStructureDefine Parent =
                Business.GetTafsilStructureDefineBusiness().GetRecord(txtPrimeryGroupCode.Text, TafsilGroup);

            if (Parent == null)
                txtSecenderyGroupCode.Text = Business.GetTafsilStructureDefineBusiness().GetDefualtCode(AccountGroup, null);
            else
            {
                string code = Business.GetTafsilStructureDefineBusiness().GetDefualtCode(AccountGroup, Parent.ID);
                if (code.Length > codeTitleLenChild)
                    txtSecenderyGroupCode.Text = code.Substring(codeTitleLen, codeTitleLenChild);
                else txtSecenderyGroupCode.Text = code;
            }
        }

        private void NumericTextBoxValidation(object sender, TextCompositionEventArgs e)
        {
            Class.UI.TextHandeler c = new Class.UI.TextHandeler();
            c.CheckIsNumeric(e);
        }

        private void txtJustPersian(object sender, TextCompositionEventArgs e)
        {
            AccountingKernel.Class.UI.TextHandeler c = new AccountingKernel.Class.UI.TextHandeler();
            c.JustPersian(e);
        }
    }
}
