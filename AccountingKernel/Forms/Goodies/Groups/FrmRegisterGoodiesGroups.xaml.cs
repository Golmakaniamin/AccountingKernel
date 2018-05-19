using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Common;
using System.Transactions;
using System.Windows.Data;

namespace AccountingKernel.Forms.Goodies.Groups
{
    /// <summary>
    /// Interaction logic for Document.xaml
    /// </summary>
    public partial class FrmRegisterGoodiesGroups : Window
    {
        Class.UI.TextHandeler c = new Class.UI.TextHandeler();
        public Guid? MainGroupId, SubsidiaryGroupId;

        public FrmRegisterGoodiesGroups()
        {
            try
            {
                NormalConstructor();

            }
            catch
            {

                throw;
            }

        }

        public FrmRegisterGoodiesGroups(Guid id, bool isMain)
        {
            try
            {
                var goodiesGroupBusiness = Business.GetGoodiesGroupBusiness();
                if (isMain)
                {
                    this.MainGroupId = id;

                }
                else
                {
                    this.SubsidiaryGroupId = id;
                    this.MainGroupId = goodiesGroupBusiness.GetById(id).ParentId.Value;
                }

                var mainGroup = goodiesGroupBusiness.GetById(MainGroupId.Value);

                NormalConstructor();

                txtMainGroupTitle.IsEnabled = isMain;
                txtMainGroupCode.IsEnabled = isMain;
                txtSubsidiaryGroupTitle.IsEnabled = !isMain;
                txtSubsidiaryGroupCode.IsEnabled = !isMain;

                txtMainGroupTitle.Text = mainGroup.CName;
                txtMainGroupCode.Text = mainGroup.Code;

                if (SubsidiaryGroupId.HasValue)
                {
                    var entity = goodiesGroupBusiness.GetById(SubsidiaryGroupId.Value);
                    txtSubsidiaryGroupTitle.Text = entity.CName;
                    txtSubsidiaryGroupCode.Text = entity.Code.Substring(mainGroup.Code.Length);
                }


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
                InitializeComponent();

                Business.GetGoodiesGroupBusiness().GetByCodeTitleId(Common.Constants.CodeTitle.CommodityMainGroup).ToList().ForEach(r =>
                {
                    txtMainGroupCode.AddItem(new WPFAutoCompleteTextbox.AutoCompleteEntry(r.Code, r.Code));
                    txtMainGroupTitle.AddItem(new WPFAutoCompleteTextbox.AutoCompleteEntry(r.CName, r.CName));
                });
            }
            catch
            {

                throw;
            }
        }

        private void btnSelectGroup_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //var frmGoodiesGroups = new FrmGoodiesGroups();
                //frmGoodiesGroups.ShowDialog();
                //var assetGood = Business.GetGoodiesGroupBusiness().GetById(frmGoodiesGroups.GoodiesGroupId.ToGUID());
                //if (assetGood != null)
                //{
                //    txtSubsidiaryGroup.Text = assetGood.Code;
                //    txtSubsidiaryGroup_LostFocus();
                //}
                //else
                //    txtSubsidiaryGroup.Text = string.Empty;
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                var goodiesGroupBusiness = Business.GetGoodiesGroupBusiness();

                if (txtMainGroupCode.Text.Trim().Length == 0)
                    throw new Exception(Localize.ex_no_main_group_code);

                if (txtMainGroupTitle.Text.Trim().Length == 0)
                    throw new Exception(Localize.ex_no_main_group_title);

                if (txtSubsidiaryGroupCode.Text.Trim().Length != 0 && txtSubsidiaryGroupTitle.Text.Trim().Length == 0)
                    throw new Exception(Localize.ex_no_subsidiary_group_title);

                if (txtSubsidiaryGroupCode.Text.Trim().Length == 0 && txtSubsidiaryGroupTitle.Text.Trim().Length != 0)
                    throw new Exception(Localize.ex_no_subsidiary_group_code);


                Data.GoodiesGroup mainGroup, subsidiaryGroup = null;

                if (MainGroupId.HasValue && SubsidiaryGroupId.HasValue)
                {
                    subsidiaryGroup = goodiesGroupBusiness.GetById(SubsidiaryGroupId.Value);
                    mainGroup = goodiesGroupBusiness.GetById(subsidiaryGroup.ParentId.Value);
                }
                else if (MainGroupId.HasValue)
                {
                    mainGroup = goodiesGroupBusiness.GetById(MainGroupId.Value);
                }
                else
                {
                    mainGroup = goodiesGroupBusiness.GetByCode(txtMainGroupCode.Text);
                    if (mainGroup == null)
                        mainGroup = new Data.GoodiesGroup();

                    subsidiaryGroup = goodiesGroupBusiness.GetByCode(txtMainGroupCode.Text + txtSubsidiaryGroupCode.Text);
                    if (subsidiaryGroup == null)
                        subsidiaryGroup = new Data.GoodiesGroup();
                    else
                        throw new Exception(Localize.ex_duplicated_subsidiary_group_code);
                }


                mainGroup.Code = txtMainGroupCode.Text;
                mainGroup.CName = txtMainGroupTitle.Text;
                mainGroup.CodeTitleId = Common.Constants.CodeTitle.CommodityMainGroup;


                if (subsidiaryGroup != null)
                {
                    subsidiaryGroup.Code = txtMainGroupCode.Text + txtSubsidiaryGroupCode.Text;
                    subsidiaryGroup.CName = txtSubsidiaryGroupTitle.Text;
                    subsidiaryGroup.CodeTitleId = Common.Constants.CodeTitle.CommoditySubsidiaryGroup;
                    if (goodiesGroupBusiness.IsNameExist(subsidiaryGroup))
                        throw new Exception(Localize.ex_duplicated_subsidiary_group_name);
                }

                if (goodiesGroupBusiness.IsNameExist(mainGroup))
                    throw new Exception(Localize.ex_duplicated_main_group_name);

                using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
                {
                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted,
                    Timeout = new TimeSpan(2, 0, 0)
                }))
                {
                    goodiesGroupBusiness.Save(mainGroup, string.Empty);

                    if (subsidiaryGroup != null && txtSubsidiaryGroupTitle.Text != string.Empty && txtSubsidiaryGroupCode.Text != string.Empty)
                    {
                        subsidiaryGroup.ParentId = mainGroup.ID;
                        goodiesGroupBusiness.Save(subsidiaryGroup, mainGroup.uniquepath);
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

        private void txtAssetGroupCode_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }

        private void txtMainGroupTitle_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                var mainGroup = Business.GetGoodiesGroupBusiness().GetByName(txtMainGroupTitle.Text, Common.Constants.CodeTitle.CommodityMainGroup);
                txtSubsidiaryGroupCode.ClearItems();
                txtSubsidiaryGroupTitle.ClearItems();

                if (mainGroup != null)
                {
                    foreach (var item in Business.GetGoodiesGroupBusiness().GetByParentId(mainGroup.ID).ToList())
                        txtSubsidiaryGroupCode.AddItem(new WPFAutoCompleteTextbox.AutoCompleteEntry(item.Code, item.Code));
                    txtMainGroupCode.Text = mainGroup.Code;

                }
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
                var mainGroup = Business.GetGoodiesGroupBusiness().GetByCode(txtMainGroupCode.Text, Common.Constants.CodeTitle.CommodityMainGroup);
                txtSubsidiaryGroupCode.ClearItems();
                txtSubsidiaryGroupTitle.ClearItems();

                if (mainGroup != null)
                {
                    foreach (var item in Business.GetGoodiesGroupBusiness().GetByParentId(mainGroup.ID).ToList())
                    {
                        txtSubsidiaryGroupCode.AddItem(new WPFAutoCompleteTextbox.AutoCompleteEntry(item.Code, item.Code));
                        txtSubsidiaryGroupTitle.AddItem(new WPFAutoCompleteTextbox.AutoCompleteEntry(item.CName, item.CName));
                    }
                    txtMainGroupTitle.Text = mainGroup.CName;

                }
            }
            catch
            {

                throw;
            }
        }

        private void txtSubsidiaryGroupTitle_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                var subsidiaryGroup = Business.GetGoodiesGroupBusiness().GetByName(txtSubsidiaryGroupTitle.Text, Common.Constants.CodeTitle.CommoditySubsidiaryGroup);
                if (subsidiaryGroup == null)
                    txtSubsidiaryGroupCode.Text = Business.GetGoodiesGroupBusiness().GetNewCode(Common.Constants.CodeTitle.CommoditySubsidiaryGroup, txtMainGroupCode.Text);
                else
                {
                    var mainGroup = Business.GetGoodiesGroupBusiness().GetByName(txtMainGroupTitle.Text, Common.Constants.CodeTitle.CommodityMainGroup);
                    if (mainGroup == null)
                        return;

                    txtSubsidiaryGroupCode.Text = subsidiaryGroup.Code.Substring(mainGroup.Code.Length);
                }

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
                var subsidiaryGroup = Business.GetGoodiesGroupBusiness().GetByCode(txtSubsidiaryGroupCode.Text, Common.Constants.CodeTitle.CommoditySubsidiaryGroup);
                if (subsidiaryGroup == null)
                    txtSubsidiaryGroupCode.Text = Business.GetGoodiesGroupBusiness().GetNewCode(Common.Constants.CodeTitle.CommoditySubsidiaryGroup, txtMainGroupCode.Text);
                else
                {
                    var mainGroup = Business.GetGoodiesGroupBusiness().GetByName(txtMainGroupTitle.Text, Common.Constants.CodeTitle.CommodityMainGroup);
                    if (mainGroup == null)
                        return;

                    txtSubsidiaryGroupTitle.Text = subsidiaryGroup.CName;
                }

            }
            catch
            {

                throw;
            }
        }

    }
}
