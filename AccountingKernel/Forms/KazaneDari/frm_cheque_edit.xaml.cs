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


namespace AccountingKernel.Forms.KazaneDari
{
    /// <summary>
    /// Interaction logic for frm_cheque_edit.xaml
    /// </summary>
    public partial class frm_cheque_edit : Window
    {
        Class.UI.TextHandeler txt_filter = new Class.UI.TextHandeler();

        public frm_cheque_edit()
        {
            InitializeComponent();
        }
        
        AccountingKernelEntities10 ak = new AccountingKernelEntities10();
        Guid gg;
        string code_bank;
        string shomare_bank;
        string bank_name;

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

            List<BaseInfo> bi = ak.BaseInfoes.Where(i => i.PID == Common.Constants.BaseInfoType.amaliateCheque).ToList();

            for (int i = 0; i <= bi.Count - 1; i++)
            {
                cmb_noeCheque.Items.Add(bi[i].AssignName);
            }

            gg = Guid.Parse(pass_data._ID_);
            List<Check> c = ak.Checks.Where(i => i.ID == gg).ToList();
            Guid g2 = c[0].ID;
            List<CheckProcess> ch = ak.CheckProcesses.Where(b => b.IDCheck == g2).ToList();
            Guid g_cbank = (Guid)c[0].CBank;
            List<Fund> f = ak.Funds.Where(i => i.ID == g_cbank).ToList();


            txt_codeBank.Text = f[0].FBankNO;
            txt_mablagheCheque.Text = c[0].CPrice.ToString();
            txt_nameBank.Text = f[0].FBank;
            txt_serialeCheque.Text = ch[0].CSerial;
            txt_sharheCheck.Text = c[0].CDescription;
            txt_shomareCheque.Text = c[0].CNO;
            pic_datePicker.Text = c[0].CDate;

            Guid get_noe_cheque = (Guid)ch[0].CPType;

            int s = get_noe_cheque_for_combo(get_noe_cheque);

            cmb_noeCheque.SelectedIndex = s - 1;
           


        }

        private void btn_sabt_Click(object sender, RoutedEventArgs e)
        {
                      string get_cmb_item = "";
                    Guid id_noe_chequ = Guid.Empty;
                    if (cmb_noeCheque.SelectedItem != null)
                    {
                        get_cmb_item = cmb_noeCheque.SelectedItem.ToString();
                        List<BaseInfo> bi = ak.BaseInfoes.Where(i => i.AssignName == get_cmb_item).ToList();
                        id_noe_chequ = bi[0].Id;
                    }

            if (txt_mablagheCheque.Text != "" && txt_nameBank.Text != "" && txt_serialeCheque.Text != ""
            && txt_sharheCheck.Text != "" && txt_shomareCheque.Text != "" && pic_datePicker.Text != ""
             && txt_codeBank.Text != "" /*&& code_bank_id != Guid.Empty*/)
            {

                ////

                bool is_exist = false;
                string get_cheque_code = txt_shomareCheque.Text;
                string get_bank_code_ = txt_codeBank.Text;
                var get_ = ak.Funds.Where(i => i.FBankNO == get_bank_code_).FirstOrDefault();
                if (get_ != null)
                {
                    Guid get_bank_code = (Guid)get_.ID;
                    List<Check> get_all_code_in_bank = ak.Checks.Where(i => i.CBank == get_bank_code).ToList();
                    for (int i = 0; i <= get_all_code_in_bank.Count - 1; i++)
                    {
                        if (get_cheque_code == get_all_code_in_bank[i].CNO)
                        {
                            is_exist = true;
                        }
                    }
                }

                ////
                if (is_exist == false)
                {

                    var get_check = ak.Checks.First(i => i.ID == gg);
                    var get_check_process = ak.CheckProcesses.First(j => j.IDCheck == gg);
                    var get_id_bank = ak.Funds.First(k => k.ID == get_check.CBank);

                    get_check.CDescription = txt_sharheCheck.Text;
                    get_check.CPrice = decimal.Parse(txt_mablagheCheque.Text);
                    get_check.CNO = txt_shomareCheque.Text;
                    get_check.CDate = pic_datePicker.Text;
                    get_check.CBank = get_id_bank.ID;


                    int o = ak.SaveChanges();

                    get_check_process.CSerial = txt_serialeCheque.Text;
                    get_check_process.CPType = id_noe_chequ;

                    o += ak.SaveChanges();

                    if (o > 0)
                    {
                        MessageBox.Show("مقادیر به روز رسانی شد");
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("کد چک در بانک وجود دارد");
                }
            }
            else
            {
                MessageBox.Show("تمامی مقادیر جهت ویرایش الزامی میباشد");
            }
        }

        private void btn_entekhabeCodeBank_Click(object sender, RoutedEventArgs e)
        {
            
            // check bank

            var bc = ak.Funds.ToList();
            if (bc.Count != 0)
            {
                frm_entekhabe_bank eb = new frm_entekhabe_bank();
                eb.ShowDialog();


                code_bank = Class.Variable.Variables.idFunds;
                Guid gg = Guid.Parse(code_bank);
                List<Fund> get_all_from_funds_table = ak.Funds.Where(i => i.ID == gg).ToList();
                bank_name = get_all_from_funds_table[0].FBank;
                shomare_bank = get_all_from_funds_table[0].FBankNO;

                txt_nameBank.Text = bank_name;
                txt_codeBank.Text = shomare_bank;
            }
            else
            {
                MessageBox.Show("رکوردی در بانک وجود ندارد");
            }
        }

        private int get_noe_cheque_for_combo(Guid noe_cheque)
        {
    
            if (noe_cheque == Common.Constants.BaseInfoType.bargashte_cheque)
            {
                return 5;
            }

            if (noe_cheque == Common.Constants.BaseInfoType.cheque_kharjShode)
            {
                return 1;
            }

            if (noe_cheque == Common.Constants.BaseInfoType.vosole_cheque)
            {
                return 2;
            }

            if (noe_cheque == Common.Constants.BaseInfoType.ebtale_cheque)
            {
                return 6;
            }

            if (noe_cheque == Common.Constants.BaseInfoType.esterdade_cheque)
            {
                return 4;
            }

            if (noe_cheque == Common.Constants.BaseInfoType.bargashte_cheque_kharj_shode)
            {
                return 3;
            }

            return 0;

           // return 1;
        }

        private bool get_validation_for_reg_cheque()
        {
            return false;
        }

        private void txt_shomareCheque_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            txt_filter.chequeSerial(e);
        }

        private void txt_serialeCheque_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            txt_filter.chequeSerial(e);
            txt_filter.AddZero(sender, e);
        }

        private void txt_mablagheCheque_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            txt_filter.AddZero(sender, e);
            txt_filter.CheckIsNumeric(e);
        }

        private void txt_mablagheCheque_TextChanged(object sender, TextChangedEventArgs e)
        {
            txt_mablagheCheque.Text = txt_filter.SepratNumber(Convert.ToInt32(txt_mablagheCheque.Text));
           
           
        }

        private void txt_sharheCheck_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            txt_filter.JustPersian(e);
        }
    }
}
