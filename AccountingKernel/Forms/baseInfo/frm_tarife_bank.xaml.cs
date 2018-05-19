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

namespace AccountingKernel.Forms.baseInfo
{
    /// <summary>
    /// Interaction logic for frm_tarife_bank.xaml
    /// </summary>
    public partial class frm_tarife_bank : Window
    {
        Class.UI.TextHandeler c = new Class.UI.TextHandeler();
        Guid EntityId;
        public frm_tarife_bank()
        {
            try
            {
                InitializeComponent();
                addSuggestionToTextBoxGrouh();

            }
            catch
            {

                throw;
            }
        }

        public frm_tarife_bank(Guid entityId)
        {
            try
            {
                InitializeComponent();
                addSuggestionToTextBoxGrouh();

                EntityId = entityId;
                
                var entity = Business.GetFundsBusiness().GetById(EntityId);
                txt_nameBank.Text = entity.FBank;
                txt_codeBank.Text = entity.FBankNO;
                txt_name_shobe.Text = entity.Fbranch;
                txt_code_shobe.Text = entity.FbranchNO;
                txt_shomare_hwsab.Text = entity.FAccountnumber;
                txt_FName.Text = entity.FName;

            }
            catch
            {

                throw;
            }
        }


        private void frm_sabt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!ValidateData())
                    return;

                if (txt_code_shobe.Text == "" || txt_codeBank.Text == "" || txt_name_shobe.Text == ""
                    || txt_nameBank.Text == "" || txt_shomare_hwsab.Text == "")
                    throw new Exception(Localize.ex_all_item_mandatory);

                var f = Business.GetFundsBusiness().GetById(EntityId);
                if (f == null)
                    f = new Fund();

                f.FBank = txt_nameBank.Text;
                f.FBankNO = txt_codeBank.Text;
                f.Fbranch = txt_name_shobe.Text;
                f.FbranchNO = txt_code_shobe.Text;
                f.FName = txt_FName.Text;
                f.FAccountnumber = txt_shomare_hwsab.Text;
                f.FType = Common.Constants.BaseInfoType.Bank;


                Business.GetFundsBusiness().Save(f);
                MessageBox.Show("با موفقیت ثبت شد");
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
               // throw;
            }
        }

        private void txt_codeBank_LostFocus_1(object sender, RoutedEventArgs e)
        {

            try
            {
                var v = Business.GetFundsBusiness().GetByFBankNO(txt_codeBank.Text);
                if (v != null)
                    txt_nameBank.Text = v.FBank;
            }
            catch { throw; }

        }

        private void txt_nameBank_LostFocus_1(object sender, RoutedEventArgs e)
        {

            try
            {
                var v = Business.GetFundsBusiness().GetByFBank(txt_nameBank.Text.Trim());
                if (v.Any())
                {
                    txt_codeBank.Text = v.First().FBankNO;
                }
                else
                {
                    txt_codeBank.Text = Business.GetFundsBusiness().GetNewCode();
                }
            }
            catch
            {
                throw;
            }
        }

        private void txt_code_shobe_LostFocus_1(object sender, RoutedEventArgs e)
        {

        }

        private void txt_name_shobe_LostFocus_1(object sender, RoutedEventArgs e)
        {

        }

        private void txt_code_shobe_LostFocus_2(object sender, RoutedEventArgs e)
        {

        }

        private void txt_name_shobe_LostFocus_2(object sender, RoutedEventArgs e)
        {

        }

        private void addSuggestionToTextBoxGrouh()
        {
            List<Fund> get_all_fund = Business.GetFundsBusiness().GetAll().OrderBy(i => i.ID).ToList();

            foreach (var item in get_all_fund)
            {
                txt_nameBank.AddItem(new WPFAutoCompleteTextbox.AutoCompleteEntry(item.FBank, item.FBank));
                txt_codeBank.AddItem(new WPFAutoCompleteTextbox.AutoCompleteEntry(item.FBankNO, item.FBankNO));

            }

            foreach (var item in get_all_fund)
            {
                txt_code_shobe.AddItem(new WPFAutoCompleteTextbox.AutoCompleteEntry(item.FbranchNO, item.FbranchNO));
                txt_name_shobe.AddItem(new WPFAutoCompleteTextbox.AutoCompleteEntry(item.Fbranch, item.Fbranch));

            }
        }

        private bool ValidateData()
        {
            //var c_bank_code_name = ak.Funds.Any(i => i.FBankNO == txt_codeBank.Text && i.FBank == txt_nameBank.Text);
            //// var c_bank_name = ak.Funds.Any(i => i.FBank == txt_nameBank.Text && );
            //if (c_bank_code_name == true)
            //{
            //    MessageBox.Show(" نام بانک و کد بانک هماهنگی ندارند ");

            //}

            var c_bank_name = Business.GetFundsBusiness().GetByFBank(txt_nameBank.Text).Any(r => r.ID != EntityId);
            var c_bank_code = Business.GetFundsBusiness().GetAll().Any(j => j.FBankNO == txt_codeBank.Text && j.ID != EntityId);

            if (c_bank_code == false && c_bank_name == false)
            {
                return true;
            }

            if (c_bank_code == true && c_bank_name == false)
            {
                MessageBox.Show("کد بانک در سیستم وجود دارد");
                return false;
            }
            if (c_bank_code == false && c_bank_name == true)
            {
                MessageBox.Show("نام بانک در سیستم وجود دارد");
                return false;
            }

            if (c_bank_code == true && c_bank_name == true)
            {
                var get_id_c_bank_name = Business.GetFundsBusiness().GetByFBank(txt_nameBank.Text).First();
                var get_id_c_banek_code = Business.GetFundsBusiness().GetByFBankNO(txt_codeBank.Text);

                if (get_id_c_banek_code != get_id_c_bank_name)
                {
                    MessageBox.Show("هماهنگی بین کدهای وارد شده وجود ندارد");
                    return false;
                }

                if (get_id_c_banek_code == get_id_c_bank_name)
                {
                    string get_accountNumber = get_id_c_banek_code.FAccountnumber;
                    if (get_accountNumber != txt_shomare_hwsab.Text.Trim())
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("شماره حساب در بانک جاری وجود دارد");
                        return false;
                    }
                }

                return true;
            }




            return true;
        }

        private void txt_codeBank_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }

        private void txt_shomare_hwsab_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {


            c.CheckIsAccountNumber(e);
        }

        private void AutoCompleteTextBox_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }

        private void AutoCompleteTextBox_PreviewTextInput_2(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }

        private void txt_nameBank_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.JustPersian(e);
        }

        private void txt_nameBank_LostFocus_2(object sender, RoutedEventArgs e)
        {
        }

        private void txt_FName_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        {
            c.JustPersian(e);
        }

    }
}
