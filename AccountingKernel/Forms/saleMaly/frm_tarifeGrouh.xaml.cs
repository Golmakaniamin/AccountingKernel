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
using Data;
using Common;

namespace AccountingKernel.Forms.saleMaly
{
    /// <summary>
    /// Interaction logic for frm_tarifeGrouh.xaml
    /// </summary>
    public partial class frm_tarifeGrouh : Window
    {
        Class.UI.TextHandeler c = new Class.UI.TextHandeler();
        Guid EntityId;

        public frm_tarifeGrouh()
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

        public frm_tarifeGrouh(Guid entityId)
        {
            try
            {
                InitializeComponent();
                NormalConstructor();
                EntityId = entityId;

                var entity = Business.GetCorporartionBusiness().GetById(entityId);

                txtGroupName.Text = entity.Groupname;
                txtCorporationName.Text = entity.CorporationName;
                txtMahaleSabt.Text = entity.mahale_sabt;
                txtCorporationType.Text = entity.CorporationType;
                txtPhone.Text = entity.phone;
                txtSabt.Text = entity.sabt;
                txtIdPosti.Text = entity.idposti;
                txtAddress.Text = entity.address;
                txtKodKargah.Text = entity.kod_kargah;
                txtRadifPeyman.Text = entity.radif_peyman;
                txtNameShobeBime.Text = entity.nameshobe_bime;
                txtNameKargah.Text = entity.name_kargah;
                txtKodShemely.Text = entity.kod_shemely;
                txtNerkhBime.Text = entity.nerkhe_bime;
                txtShParvande.Text = entity.sh_parvande;
                txtkodshobe.Text = entity.kod_shobe;
                txtnoeasliepardakhtkonande.Text = entity.noeasliepardakhtkonande;
                txtnoefareiepardakhtkonande.Text = entity.noefareiepardakhtkonande;
                txtname_shobe.Text = entity.name_shobe;
                cmbCalculationType.Text = entity.nahve_maliyat;
                txtpardakht_name.Text = entity.pardakht_name;
                txtpardakht_family.Text = entity.pardakht_family;
                txtpardakht_codemelli.Text = entity.pardakht_codemelli;
                txtkod_egtesady.Text = entity.kod_egtesady;
                cmbPaymentType.Text = entity.nahve_pardakht;
                txtemza1_name.Text = entity.emza1_name;
                txtemza1_family.Text = entity.emza1_family;
                txtemza1_codemelli.Text = entity.emza1_codemelli;
                txtemza1_semat.Text = entity.emza1_semat;
                txtkod_TFN.Text = entity.kod_TFN;
                txtkod_TIN.Text = entity.kod_TIN;

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
                cmbCalculationType.ItemsSource = Business.GetPayrollTaxCodeBusiness().GetByMCode(Common.PayrollTaxCodeEnum.TaxCalculationType).ToList();
                cmbPaymentType.ItemsSource = Business.GetPayrollTaxCodeBusiness().GetByMCode(Common.PayrollTaxCodeEnum.PaymentType).ToList();
            }
            catch
            {

                throw;
            }
        }

        AccountingKernelEntities10 ak = new AccountingKernelEntities10();

        private void txt_shomareSabt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }

        private void txt_onvaneGrouh_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.JustPersian(e);
        }

        private void txt_onvaneSherkat_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.JustPersian(e);
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.ValidateData();
                var entity = Business.GetCorporartionBusiness().GetById(EntityId);
                if (entity == null)
                    entity = new corporation();

                entity.Groupname = txtGroupName.Text;
                entity.CorporationName = txtCorporationName.Text;
                entity.mahale_sabt = txtMahaleSabt.Text;
                entity.CorporationType = txtCorporationType.Text;
                entity.phone = txtPhone.Text;
                entity.sabt = txtSabt.Text;
                entity.idposti = txtIdPosti.Text;
                entity.address = txtAddress.Text;
                entity.kod_kargah = txtKodKargah.Text;
                entity.radif_peyman = txtRadifPeyman.Text;
                entity.nameshobe_bime = txtNameShobeBime.Text;
                entity.name_kargah = txtNameKargah.Text;
                entity.kod_shemely = txtKodShemely.Text;
                entity.nerkhe_bime = txtNerkhBime.Text;
                entity.sh_parvande = txtShParvande.Text;
                entity.kod_shobe = txtkodshobe.Text;
                entity.noeasliepardakhtkonande = txtnoeasliepardakhtkonande.Text;
                entity.noefareiepardakhtkonande = txtnoefareiepardakhtkonande.Text;
                entity.name_shobe = txtname_shobe.Text;
                entity.nahve_maliyat = cmbCalculationType.Text;
                entity.pardakht_name = txtpardakht_name.Text;
                entity.pardakht_family = txtpardakht_family.Text;
                entity.pardakht_codemelli = txtpardakht_codemelli.Text;
                entity.kod_egtesady = txtkod_egtesady.Text;
                entity.nahve_pardakht = cmbPaymentType.Text;
                entity.emza1_name = txtemza1_name.Text;
                entity.emza1_family = txtemza1_family.Text;
                entity.emza1_codemelli = txtemza1_codemelli.Text;
                entity.emza1_semat = txtemza1_semat.Text;
                entity.kod_TFN = txtkod_TFN.Text;
                entity.kod_TIN = txtkod_TIN.Text;

                Business.GetCorporartionBusiness().Save(entity);
                this.Close();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void ValidateData()
        {
            try
            {
                if (txtCorporationName.Text.Trim().Length == 0)
                    throw new Exception(Localize.ex_invalid_name);

            }
            catch
            {

                throw;
            }
        }

        private void txtPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }

        private void txtSabt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }

        private void txtIdPosti_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.chequeSerial(e);
        }

        private void txtAddress_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.JustPersian(e);
        }

        private void txtKodKargah_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.chequeSerial(e);
        }

        private void txtNameShobeBime_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.JustPersian(e);
        }

        private void txtNameKargah_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.JustPersian(e);
        }

        private void txtKodShemely_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.chequeSerial(e);
        }

        private void txtNerkhBime_TextChanged(object sender, TextChangedEventArgs e)
        {
            c.SepratTextBox(sender,e);
        }

        private void txtNerkhBime_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
            c.AddZero(sender,e);
        }

        private void txtShParvande_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }

        private void txtpardakht_name_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.JustPersian(e);
        }

        private void txtemza1_name_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.JustPersian(e);
        }

        private void txtkodshobe_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.chequeSerial(e);
        }

        private void txtpardakht_family_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.JustPersian(e);
        }

        private void txtemza1_family_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.JustPersian(e);
        }

        private void txtpardakht_codemelli_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }

        private void txtemza1_codemelli_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }

        private void txtkod_egtesady_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }

        private void txtemza1_semat_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.JustPersian(e);
        }

        private void txtname_shobe_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.JustPersian(e);
        }
    }
}
