using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Common;
using System.Transactions;
using System.Windows.Data;

namespace AccountingKernel.Forms.AssetGoods
{
    /// <summary>
    /// Interaction logic for Document.xaml
    /// </summary>
    public partial class FrmRegisterAssetGoodGroup : Window
    {
        Class.UI.TextHandeler c = new Class.UI.TextHandeler();
        public Guid? SubsidiaryAssetGoodGroupId, MainAssetGoodGroupId;

        public FrmRegisterAssetGoodGroup()
        {
            try
            {
                NormalConstructor();
                txtMainGroupCode.Text = Business.GetAssetGoodsBusiness().GetNewCode(Common.Constants.CodeTitle.AssetGoodMianGroup, string.Empty);
                MainGroupLostFocus();

            }
            catch
            {

                throw;
            }

        }

        public FrmRegisterAssetGoodGroup(Guid entityId)
        {
            try
            {
                NormalConstructor();

                var assetGoodsBusiness = Business.GetAssetGoodsBusiness();
                var entity = assetGoodsBusiness.GetById(entityId);
                if (entity.codetitleId == Common.Constants.CodeTitle.AssetGoodMianGroup)
                    MainAssetGoodGroupId = entityId;
                else
                {
                    MainAssetGoodGroupId = entity.parentId;
                    SubsidiaryAssetGoodGroupId = entity.ID;
                }

                //SubsidiaryAssetGoodGroupId = subsidiaryAssetGoodGroupId;

                var codeTitles = Business.GetCodeTitleBusiness().GetAll().ToList();
                var mainCodeTitle = codeTitles.Find(r => r.Id == Common.Constants.CodeTitle.AssetGoodMianGroup);
                var subsidiaryCodeTitle = codeTitles.Find(r => r.Id == Common.Constants.CodeTitle.AssetGoodSubsidiaryGroup);

                if (SubsidiaryAssetGoodGroupId.HasValue)
                {
                    var assetGoodSubsidiaryGroup = assetGoodsBusiness.GetById(SubsidiaryAssetGoodGroupId.Value);
                    txtSubsidiaryGroupCode.IsEnabled = !Business.GetAssetBusiness().GetByAssetGoodId(SubsidiaryAssetGoodGroupId.Value).Any();
                    txtSubsidiaryGroupCode.Text = assetGoodSubsidiaryGroup.code.Substring(mainCodeTitle.CodeLen.ToInt()).Calibrate('0', subsidiaryCodeTitle.CodeLen.ToInt());
                    txtSubsidiaryGroupTitle.Text = assetGoodSubsidiaryGroup.name;
                }

                var assetGoodMainGroup = assetGoodsBusiness.GetById(MainAssetGoodGroupId.Value);
                txtMainGroupCode.IsEnabled = !Business.GetAssetGoodsBusiness().GetByParentId(assetGoodMainGroup.ID).Any();
                txtMainGroupCode.Text = assetGoodMainGroup.code.Calibrate('0', mainCodeTitle.CodeLen.ToInt());
                txtMainGroupTitle.Text = assetGoodMainGroup.name;

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

            }
            catch
            {

                throw;
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMainGroupCode.Text.Trim().Length == 0)
                    throw new Exception(Localize.ex_no_main_group_code);

                if (txtMainGroupTitle.Text.Trim().Length == 0)
                    throw new Exception(Localize.ex_no_main_group_title);

                if (txtSubsidiaryGroupCode.Text.Trim().Length != 0 && txtSubsidiaryGroupTitle.Text.Trim().Length == 0)
                    throw new Exception(Localize.ex_no_subsidiary_group_title);

                if (txtSubsidiaryGroupCode.Text.Trim().Length == 0 && txtSubsidiaryGroupTitle.Text.Trim().Length != 0)
                    throw new Exception(Localize.ex_no_subsidiary_group_code);

                var assetGoodsBusiness = Business.GetAssetGoodsBusiness();

                Data.AssetGood mainGroup, subsidiaryGroup = null;

                if (MainAssetGoodGroupId.HasValue && SubsidiaryAssetGoodGroupId.HasValue)
                {
                    subsidiaryGroup = assetGoodsBusiness.GetById(SubsidiaryAssetGoodGroupId.Value);
                    mainGroup = assetGoodsBusiness.GetById(subsidiaryGroup.parentId.Value);
                }
                else if (MainAssetGoodGroupId.HasValue)
                {
                    mainGroup = assetGoodsBusiness.GetById(MainAssetGoodGroupId.Value);
                }
                else
                {
                    mainGroup = assetGoodsBusiness.GetByCode(txtMainGroupCode.Text);
                    if (mainGroup == null)
                        mainGroup = new Data.AssetGood();

                    subsidiaryGroup = assetGoodsBusiness.GetByCode(txtMainGroupCode.Text + txtSubsidiaryGroupCode.Text);
                    if (subsidiaryGroup == null)
                        subsidiaryGroup = new Data.AssetGood();
                    else
                        throw new Exception(Localize.ex_duplicated_subsidiary_group_code);
                }


                mainGroup.code = txtMainGroupCode.Text;
                mainGroup.name = txtMainGroupTitle.Text;
                mainGroup.codetitleId = Common.Constants.CodeTitle.AssetGoodMianGroup;


                if (subsidiaryGroup != null)
                {
                    subsidiaryGroup.code = txtMainGroupCode.Text + txtSubsidiaryGroupCode.Text;
                    subsidiaryGroup.name = txtSubsidiaryGroupTitle.Text;
                    subsidiaryGroup.codetitleId = Common.Constants.CodeTitle.AssetGoodSubsidiaryGroup;
                    if (assetGoodsBusiness.IsNameExist(subsidiaryGroup))
                        throw new Exception(Localize.ex_duplicated_subsidiary_group_name);
                }

                if (assetGoodsBusiness.IsNameExist(mainGroup))
                    throw new Exception(Localize.ex_duplicated_main_group_name);

                using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
                {
                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted,
                    Timeout = new TimeSpan(2, 0, 0)
                }))
                {
                    assetGoodsBusiness.Save(mainGroup, string.Empty);

                    if (subsidiaryGroup != null && txtSubsidiaryGroupTitle.Text != string.Empty && txtSubsidiaryGroupCode.Text != string.Empty)
                    {
                        subsidiaryGroup.parentId = mainGroup.ID;
                        assetGoodsBusiness.Save(subsidiaryGroup, mainGroup.uniquepath);
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

        private void txtMainGroupCode_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                MainGroupLostFocus();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }

        }

        private void MainGroupLostFocus()
        {
            try
            {
                var assetGoodsBusiness = Business.GetAssetGoodsBusiness();

                var codeTitle = Business.GetCodeTitleBusiness().GetById(Common.Constants.CodeTitle.AssetGoodMianGroup);

                txtMainGroupCode.Text = txtMainGroupCode.Text.Calibrate('0', codeTitle.CodeLen.ToInt());

                var entity = assetGoodsBusiness.GetByCode(txtMainGroupCode.Text);
                if (entity != null)
                    txtMainGroupTitle.Text = entity.name;
                else
                    txtMainGroupTitle.Text = string.Empty;

                txtSubsidiaryGroupCode.Text = assetGoodsBusiness.GetNewCode(Common.Constants.CodeTitle.AssetGoodSubsidiaryGroup, txtMainGroupCode.Text);

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
                var assetGoodsBusiness = Business.GetAssetGoodsBusiness();

                var codeTitle = Business.GetCodeTitleBusiness().GetById(Common.Constants.CodeTitle.AssetGoodSubsidiaryGroup);

                var entity = assetGoodsBusiness.GetByCode(txtMainGroupCode.Text + txtSubsidiaryGroupCode.Text);
                if (entity != null)
                    txtSubsidiaryGroupTitle.Text = entity.name;
                else
                    txtSubsidiaryGroupTitle.Text = string.Empty;


            }
            catch
            {

                throw;
            }
        }

        private void txtSubsidiaryGroupCode_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            c.AddZero(sender, e);
            c.CheckIsNumeric(e);
        }

        private void txtMainGroupCode_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }

    }
}
