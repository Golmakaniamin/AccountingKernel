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

namespace AccountingKernel.Forms.MmoienCode
{
    /// <summary>
    /// Interaction logic for MoeinStructureDefineChild.xaml
    /// </summary>
    public partial class MoeinStructureDefineChild : Window
    {
        //private Data.AccountingMoeinStructureDefine _entity = new Data.AccountingMoeinStructureDefine();

        private string PrimeryCode;
        private string SecondaryCode;
        private string PrimeryName;
        private string PrimeryLatinName;
        private string SecondaryLatinName;
        private string SecondaryName;
        private Guid Goruh = Constants.CodeTitle.Goruh;
        private Guid Kol = Constants.CodeTitle.Kol;

        public readonly int GoruhLen = (int)Business.GetCodeTitleBusiness().GetById(Common.Constants.CodeTitle.Goruh).CodeLen;
        public readonly int KolLen = (int)Business.GetCodeTitleBusiness().GetById(Common.Constants.CodeTitle.Kol).CodeLen;

        private Data.AccountingMoeinStructureDefine _editedItem = null;
        private Data.AccountingMoeinStructureDefine _entityPrimery = null;
        public Data.AccountingMoeinStructureDefine _entitySecondery = null;
        public Data.AccountingMoeinStructureDefine EditedItem { get { return _editedItem; } }
        public Data.AccountingMoeinStructureDefine EntityPrimery { get { return _entityPrimery; } }
        public Data.AccountingMoeinStructureDefine EntitySecondery { get { return _entitySecondery; } }

        public MoeinStructureDefineChild()
        {
            InitializeComponent();

            txtPrimeryGroupCode.MaxLen = GoruhLen;
            txtSecenderyGroupCode.MaxLength = KolLen;
            txtPrimeryGroupCode.Text = Business.GetMoeinStructureDefineBusiness().GetDefualtCode(Goruh, null);

            Auto();
        }

        public MoeinStructureDefineChild(Data.AccountingMoeinStructureDefine Item)
        {
            InitializeComponent();

            txtPrimeryGroupCode.MaxLen = GoruhLen;
            txtSecenderyGroupCode.MaxLength = KolLen;

            if (Item != null)
                this._editedItem = Item;
        }

        private void Auto()
        {
            var codes = Business.GetMoeinStructureDefineBusiness().GetAll().Where(r => r.Parent_ID.Equals(null)).Select(r => r.Code.Substring(0, GoruhLen));
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
            PrimeryLatinName = txtPrimeryGroupLatinName.Text;

            SecondaryCode = string.Format("{0}{1}", PrimeryCode, txtSecenderyGroupCode.Text);
            SecondaryName = txtSecenderyGroupName.Text;
            SecondaryLatinName = txtSecenderyGroupLatinName.Text;

            try
            {
                if (string.IsNullOrEmpty(txtPrimeryGroupCode.Text) || txtPrimeryGroupCode.Text.Length < GoruhLen)
                    throw new Exception(Localize.nullCode);

                if (string.IsNullOrEmpty(PrimeryName))
                    throw new Exception(Localize.nullName);

                if (string.IsNullOrEmpty(txtSecenderyGroupCode.Text) == false && string.IsNullOrEmpty(txtSecenderyGroupName.Text))
                    throw new Exception(Localize.nullName);

                if (string.IsNullOrEmpty(txtSecenderyGroupCode.Text) && string.IsNullOrEmpty(txtSecenderyGroupName.Text) == false)
                    throw new Exception(Localize.nullName);

                if (txtSecenderyGroupCode.Text.Length > 0 && txtSecenderyGroupCode.Text.Length < KolLen)
                    throw new Exception(Localize.nullCode);

                if (_editedItem != null && _editedItem.Type == Goruh)
                {
                    _editedItem.Code = PrimeryCode;
                    _editedItem.Name = PrimeryName;
                    _editedItem.Latin_Name = PrimeryLatinName;
                    Business.GetMoeinStructureDefineBusiness().SaveWithID(_editedItem);
                    this.Close();
                    return;
                }

                if (_editedItem != null && _editedItem.Type == Kol)
                {
                    if (FormIsValid(txtSecenderyGroupCode.Text))
                    {
                        _editedItem.Code = SecondaryCode;
                        _editedItem.Name = SecondaryName;
                        _editedItem.Latin_Name = SecondaryLatinName;
                        Business.GetMoeinStructureDefineBusiness().SaveWithID(_editedItem);
                        this.Close();
                        return;
                    }
                    else
                        return;
                }

                if (FormIsValid(txtSecenderyGroupCode.Text) && FormIsValid(txtSecenderyGroupName.Text))
                {
                    Guid ParentID = Guid.Empty;
                    var record = Business.GetMoeinStructureDefineBusiness().GetRecord(PrimeryCode, Goruh);
                    if (record == null)
                    {
                        _entityPrimery = Business.GetMoeinStructureDefineBusiness().GetStructure(Goruh, PrimeryName, PrimeryLatinName, null, PrimeryCode);
                        ParentID = _entityPrimery.ID;
                        Business.GetMoeinStructureDefineBusiness().SaveWithID(_entityPrimery);
                    }
                    else
                        ParentID = record.ID;

                    if (string.IsNullOrEmpty(txtSecenderyGroupCode.Text) == false && string.IsNullOrEmpty(txtSecenderyGroupName.Text) == false)
                    {
                        record = Business.GetMoeinStructureDefineBusiness().GetRecord(SecondaryCode, Kol);
                        if (record == null)
                        {
                            _entitySecondery = Business.GetMoeinStructureDefineBusiness().GetStructure(Kol, SecondaryName, SecondaryLatinName, ParentID, SecondaryCode);
                            Business.GetMoeinStructureDefineBusiness().SaveWithID(_entitySecondery);
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

        private bool FormIsValid(string Code)
        {
            if (string.IsNullOrEmpty(Code) == false && Code.Length < KolLen)
            {
                MessageBox.Show("طول نمیتواند کمتر از حد تعیین شده باشد");
                return false;
            }

            return true;
        }

        private void txtPrimeryGroupCode_LostFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as WPFAutoCompleteTextbox.AutoCompleteTextBox;
            try
            {
                var psds = Business.GetMoeinStructureDefineBusiness().GetRecord(textBox.Text, Goruh);
                if (psds != null)
                {
                    txtPrimeryGroupName.Text = psds.Name;
                    txtPrimeryGroupLatinName.Text = psds.Latin_Name;
                    CallPrimeryLostFocus();
                }
                return;
            }
            catch
            {

            }
        }

        private void txtPrimeryGroupName_LostFocus(object sender, RoutedEventArgs e)
        {
            Data.AccountingMoeinStructureDefine Parent =
                Business.GetMoeinStructureDefineBusiness().GetRecord(txtPrimeryGroupCode.Text, Goruh);

            if (Parent == null)
                txtSecenderyGroupCode.Text = Business.GetMoeinStructureDefineBusiness().GetDefualtCode(Kol, null);
            else
            {
                string code = Business.GetMoeinStructureDefineBusiness().GetDefualtCode(Kol, Parent.ID);
                if (code.Length > KolLen)
                    txtSecenderyGroupCode.Text = code.Substring(GoruhLen, KolLen);
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

