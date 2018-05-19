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
    public partial class FrmRegisterAssetGoods : Window
    {
        Class.UI.TextHandeler c = new Class.UI.TextHandeler();
        public Guid? AssetGoodId;

        public FrmRegisterAssetGoods()
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

        public FrmRegisterAssetGoods(Guid assetGoodId)
        {
            try
            {
                AssetGoodId = assetGoodId;
                NormalConstructor();

                var assetGoodsBusiness = Business.GetAssetGoodsBusiness();
                var entity = assetGoodsBusiness.GetById(assetGoodId);

                txtAssetGroupTitle.Text = entity.name;

                var assetGoodCodeTitle = Business.GetCodeTitleBusiness().GetById(Common.Constants.CodeTitle.AssetGoodTitle);
                txtSubsidiaryGroup.Text = entity.code.Substring(0, entity.code.Length - assetGoodCodeTitle.CodeLen.ToInt());
                txtAssetGroupCode.Text = entity.code.Substring(entity.code.Length - assetGoodCodeTitle.CodeLen.ToInt(), assetGoodCodeTitle.CodeLen.ToInt());

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

                Business.GetAssetGoodsBusiness().GetByCodeTitleId(Common.Constants.CodeTitle.AssetGoodSubsidiaryGroup).ToList().ForEach(r =>
                txtSubsidiaryGroup.AddItem(new WPFAutoCompleteTextbox.AutoCompleteEntry(r.code, r.code)));
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
                var frmAssetGoodGroup = new FrmAssetGoodGroup();
                frmAssetGoodGroup.ShowDialog();
                var assetGood = Business.GetAssetGoodsBusiness().GetById(frmAssetGoodGroup.AssetGoodId.ToGUID());
                if (assetGood != null)
                {
                    txtSubsidiaryGroup.Text = assetGood.code;
                    txtSubsidiaryGroup_LostFocus();
                }
                else
                    txtSubsidiaryGroup.Text = string.Empty;
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var assetGoodsBusiness = Business.GetAssetGoodsBusiness();
                var parent = assetGoodsBusiness.GetByCode(txtSubsidiaryGroup.Text);
                if (parent == null)
                    throw new Exception(Localize.ex_subsidiarygroup_not_found);

                var entity = assetGoodsBusiness.GetById(AssetGoodId.ToGUID());
                if (entity == null)
                    entity = new Data.AssetGood();

                entity.name = txtAssetGroupTitle.Text;
                entity.code = txtSubsidiaryGroup.Text + txtAssetGroupCode.Text;
                entity.parentId = parent.ID;
                entity.codetitleId = Common.Constants.CodeTitle.AssetGoodTitle;

                assetGoodsBusiness.Save(entity, parent.uniquepath);
                this.Close();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void txtSubsidiaryGroup_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                txtSubsidiaryGroup_LostFocus();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void txtSubsidiaryGroup_LostFocus()
        {
            try
            {
                txtAssetGroupCode.Text = Business.GetAssetGoodsBusiness().GetNewCode(Common.Constants.CodeTitle.AssetGoodTitle, txtAssetGroupCode.Text);
            }
            catch
            {

                throw;
            }
        }

  

        private void txtAssetGroupCode_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }

    }
}
