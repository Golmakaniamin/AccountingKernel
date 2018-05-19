using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Common;
using System.Transactions;
using System.Windows.Data;

namespace AccountingKernel.Forms.Asset
{
    /// <summary>
    /// Interaction logic for Document.xaml
    /// </summary>
    public partial class FrmRegisterAsset : Window
    {
        Class.UI.TextHandeler c = new Class.UI.TextHandeler();
        public Guid? AssetId;

        public FrmRegisterAsset()
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

        public FrmRegisterAsset(Guid assetId)
        {
            try
            {
                AssetId = assetId;
                NormalConstructor();
                var asset = Business.GetAssetBusiness().GetById(assetId);

                txtPerson.Text = Business.GetPayrollPersonBusiness().GetById(asset.Idperson.Value).PPerson_Code;
                txtAssetGoods.Text = Business.GetAssetGoodsBusiness().GetById(asset.Idassetgoods.Value).code;
                dtpAsset.Text= asset.assetdate ;
                txtAsset_No.Text=asset.asset_No ;
                txtAmortizationRate.Text= asset.amortization_Rate.ToString();
                cmbAmortizationMethod.SelectedValue= asset.amortization_Method;
                txtDecay.Text= asset.decay_value.ToString();
                txtPrice.Text= asset.Price.ToString();
                txtAsset_number.Text= asset.asset_number.ToString();

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

                Business.GetPayrollPersonBusiness().GetAll().ToList().ForEach(r =>
                {
                    txtPerson.AddItem(new WPFAutoCompleteTextbox.AutoCompleteEntry(r.PPerson_Code, r.PPerson_Code));
                });

                Business.GetAssetGoodsBusiness().GetByCodeTitleId(Common.Constants.CodeTitle.AssetGoodTitle).ToList().ForEach(r =>
                {
                    txtAssetGoods.AddItem(new WPFAutoCompleteTextbox.AutoCompleteEntry(r.code, r.code));
                });

                cmbAmortizationMethod.ItemsSource = Business.GetBaseInfoBusiness().GetByType(Common.Constants.BaseInfoType.AmortizationMethod);

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
                var person = Business.GetPayrollPersonBusiness().GetByPPerson_Code(txtPerson.Text);
                if (person == null)
                    throw new Exception(Localize.ex_person_not_found);

                var assetGood = Business.GetAssetGoodsBusiness().GetByCode(txtAssetGoods.Text);
                if (assetGood == null)
                    throw new Exception(Localize.ex_assetgood_not_found);

                if (txtAmortizationRate.Text == string.Empty)
                    throw new Exception(Localize.ex_empty_amortizationrate);

                if (cmbAmortizationMethod.SelectedIndex == -1)
                    throw new Exception(Localize.ex_amortizationmethod_not_selected);

                if (txtDecay.Text == string.Empty)
                    throw new Exception(Localize.ex_empty_decay);

                if (txtPrice.Text == string.Empty)
                    throw new Exception(Localize.ex_empty_price);

                if (txtAsset_No.Text == string.Empty)
                    throw new Exception(Localize.ex_empty_assetno);

                if (txtAsset_number.Text == string.Empty)
                    throw new Exception(Localize.ex_empty_assetnumber);

                var asset = new Data.Asset();
                if (AssetId.HasValue)
                    asset = Business.GetAssetBusiness().GetById(AssetId.Value);

                asset.Idperson = person.id;
                asset.Idassetgoods = assetGood.ID;
                asset.assetdate = dtpAsset.Text;
                asset.asset_No = txtAsset_No.Text;
                asset.amortization_Rate = txtAmortizationRate.Text.ToDecimal();
                asset.amortization_Method = cmbAmortizationMethod.SelectedValue.ToGUID();
                asset.decay_value = txtDecay.Text.ToDecimal();
                asset.Price = txtPrice.Text.ToDecimal();
                asset.asset_number = txtAsset_number.Text.ToInt();
                Business.GetAssetBusiness().Save(asset);
                this.Close();
            }
            catch
            {

                throw;
            }
        }

        private void btnSelectPerson_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var frmPersonInfo = new PersonInfoSubmit();
                frmPersonInfo.ShowDialog();

                var person = Business.GetPayrollPersonBusiness().GetById(frmPersonInfo.PersonId);

                txtPerson.Text = person == null ? string.Empty : person.PPerson_Code;

            }
            catch
            {

                throw;
            }
        }

        private void btnSelectAssetGood_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var frmAssetGoods = new AccountingKernel.Forms.AssetGoods.FrmAssetGoods();
                frmAssetGoods.ShowDialog();
                if (frmAssetGoods.AssetGoodId.HasValue)
                    txtAssetGoods.Text = Business.GetAssetGoodsBusiness().GetById(frmAssetGoods.AssetGoodId.Value).code;
            }
            catch
            {

                throw;
            }
        }

        private void txtAmortizationRate_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
            c.AddZero(sender,e);
        }

        private void txtAmortizationRate_TextChanged(object sender, TextChangedEventArgs e)
        {
            c.SepratTextBox(sender, e);
        }

        private void txtDecay_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
            c.AddZero(sender, e);
        }

        private void txtDecay_TextChanged(object sender, TextChangedEventArgs e)
        {
            c.SepratTextBox(sender, e);
        }

        private void txtPrice_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
            c.AddZero(sender, e);
        }

        private void txtPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            c.SepratTextBox(sender, e);
        }

        private void txtAsset_number_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }
    }
}
