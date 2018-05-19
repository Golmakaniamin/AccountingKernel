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

namespace AccountingKernel.Forms.KazaneDari
{
    /// <summary>
    /// Interaction logic for frm_tarife_cheque.xaml
    /// </summary>
    ///
    public partial class frm_tarife_cheque : Window
    {
        Class.UI.TextHandeler txt_filter = new Class.UI.TextHandeler();
        AccountingKernelEntities10 ak = new AccountingKernelEntities10();

        public frm_tarife_cheque()
        {
            InitializeComponent();
        }

        string code_bank;
        string bank_name = "";
        string shomare_bank = "";


        private void btn_sabt_Click(object sender, RoutedEventArgs e)
        {
            Guid get_ID;
            Guid code_bank_id = Guid.Empty;
            if (code_bank != null)
            {
                code_bank_id = Guid.Parse(code_bank);
            }
            if (txt_mablagheCheque.Text != "" && txt_nameBank.Text != "" && txt_serialeCheque.Text != ""
                && txt_sharheCheck.Text != "" && txt_shomareCheque.Text != "" && pic_datePicker.Text != ""
                 && txt_codeBank.Text != "" && code_bank_id != Guid.Empty)
            {
               // check 
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

                    // make table 
                    string get_cmb_item = "";
                    Guid id_noe_chequ = Guid.Empty;
                    if (cmb_noeCheque.SelectedItem != null)
                    {
                        get_cmb_item = cmb_noeCheque.SelectedItem.ToString();
                        List<BaseInfo> bi = ak.BaseInfoes.Where(i => i.AssignName == get_cmb_item).ToList();
                        id_noe_chequ = bi[0].Id;
                    }

                    Check ck = new Check()
                    {
                        ID = Guid.NewGuid(),
                        CDescription = txt_sharheCheck.Text,
                        CPrice = Decimal.Parse(txt_shomareCheque.Text),
                        CNO = txt_shomareCheque.Text,
                        CDate = pic_datePicker.Text,
                        CBank = code_bank_id
                    };

                    get_ID = ck.ID;
                    ak.Checks.Add(ck);

                    int r = ak.SaveChanges();

                    CheckProcess ckp = new CheckProcess()
                    {
                        ID = Guid.NewGuid(),
                        IDCheck = get_ID,
                        CSerial = txt_serialeCheque.Text,
                        CPType = id_noe_chequ

                    };

                    ak.CheckProcesses.Add(ckp);

                    r += ak.SaveChanges();
                    if (r == 2)
                    {
                        MessageBox.Show("اطلاعات ثبت شد");
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("مشکل در ثبت اطلاعات");
                    }
                }
                else
                {
                    MessageBox.Show("کد چک در بانک وجود دارد");
                }
            }
            else if (cmb_noeCheque.SelectedIndex == 0)
            {
                MessageBox.Show("لطفا نوع چک را انتخاب کنید");
            }
            else
            {
                MessageBox.Show("تمامی مقادیر الزامی میباشد");
            }
        }

        private void btn_entekhabeCodeBank_Click(object sender, RoutedEventArgs e)
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

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            List<BaseInfo> bi = ak.BaseInfoes.Where(i => i.PID == Common.Constants.BaseInfoType.amaliateCheque).ToList();

            foreach (var item in bi)
            {
                cmb_noeCheque.Items.Add(item.AssignName);
            }      
        }

        private void txt_mablagheCheque_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            txt_filter.CheckIsNumeric(e);
            txt_filter.AddZero(sender,e);
            
        }

        private void txt_nameBank_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            txt_filter.JustPersian(e);
        }

        private void txt_sharheCheck_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            txt_filter.JustPersian(e);
        }

        private void txt_codeBank_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            txt_filter.chequeSerial(e);
        }

        private void txt_shomareCheque_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            txt_filter.chequeSerial(e);
        }

        private void txt_serialeCheque_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            txt_filter.chequeSerial(e);
        }

        private void txt_mablagheCheque_TextChanged(object sender, TextChangedEventArgs e)
        {
            txt_filter.SepratTextBox(sender, e);       
        }

    }
}
