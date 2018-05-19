using Data;
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

namespace AccountingKernel.Forms.tankhah
{
    /// <summary>
    /// Interaction logic for frm_amaliateCheque.xaml
    /// </summary>
    public partial class frm_amaliateCheque : Window
    {

        Class.UI.TextHandeler c = new Class.UI.TextHandeler();
        public frm_amaliateCheque()
        {
            InitializeComponent();
        }

        AccountingKernelEntities10 ak = new AccountingKernelEntities10();
        Guid id_bank;
        Guid g;

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_search1_Click(object sender, RoutedEventArgs e)
        {
            Forms.KazaneDari.pass_data.get_bank  = "1";
            AccountingKernel.Forms.KazaneDari.frm_get_code_bank gcf = new KazaneDari.frm_get_code_bank();
            gcf.ShowDialog();
            string code_bank;
            string bank_name;
            string shomare_bank;

                if (Class.Variable.Variables.idFunds != "")
                {
                    code_bank = Class.Variable.Variables.idFunds;
                    Guid gg = Guid.Parse(code_bank);
                    List<Fund> get_all_from_funds_table = ak.Funds.Where(i => i.ID == gg).ToList();
                    bank_name = get_all_from_funds_table[0].FBank;
                    shomare_bank = get_all_from_funds_table[0].FBankNO;
                    id_bank = get_all_from_funds_table[0].ID;
                    btn_code_bank.Text = shomare_bank;
                }
        }
 
        private void btn_search2_Click(object sender, RoutedEventArgs e)
        {
            Class.Variable.Variables.bank_code = id_bank;
            AccountingKernel.Forms.KazaneDari.frm_get_code_cheque gcc = new KazaneDari.frm_get_code_cheque();
            gcc.ShowDialog();

            if (Class.Variable.Variables.idCheque.ToString() != "")
            {
                g = Guid.Parse(Class.Variable.Variables.idCheque.ToString());
                List<Check> ch = ak.Checks.Where(i => i.ID == g).ToList();
                txt_code_cheque.Text = ch[0].CNO;
            }

        }

        private void btn_search3_Click(object sender, RoutedEventArgs e)
        {
         
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Class.Variable.Variables.noe_cheque == "1") // خرج چک
            {
                if (txt_code_cheque.Text != "")
                {
                    CheckProcess ch = ak.CheckProcesses.First(i => i.IDCheck == g);
                    ch.CPType = Common.Constants.BaseInfoType.cheque_kharjShode;
                    Check c = ak.Checks.First(i => i.ID == ch.IDCheck);
                    c.CDate = pic_datePicker.Text;

                    int r = ak.SaveChanges();
                    if (r > 0)
                    {
                        MessageBox.Show("با موفقیت ثبت شد");
                        this.Hide();
                    }
                }
                /////////
                if (Class.Variable.Variables.noe_cheque == "2") // وصول چک
                {
                    CheckProcess ch = ak.CheckProcesses.First(i => i.IDCheck == g);
                    ch.CPType = Common.Constants.BaseInfoType.vosole_cheque;
                    int r = ak.SaveChanges();
                    if (r == 1)
                    {
                        MessageBox.Show("با موفقیت ثبت شد");
                        this.Hide();
                    }
                }
                ////////
                if (Class.Variable.Variables.noe_cheque == "3") // ابطال چک
                {
                    CheckProcess ch = ak.CheckProcesses.First(i => i.IDCheck == g);
                    ch.CPType = Common.Constants.BaseInfoType.ebtale_cheque;
                    int r = ak.SaveChanges();
                    if (r == 1)
                    {
                        MessageBox.Show("با موفقیت ثبت شد");
                        this.Hide();
                    }
                }
                //////
                if (Class.Variable.Variables.noe_cheque == "4") // برگشت چک
                {
                    CheckProcess ch = ak.CheckProcesses.First(i => i.IDCheck == g);
                    ch.CPType = Common.Constants.BaseInfoType.bargashte_cheque;
                    int r = ak.SaveChanges();
                    if (r == 1)
                    {
                        MessageBox.Show("با موفقیت ثبت شد");
                        this.Hide();
                    }
                }
                //////
                if (Class.Variable.Variables.noe_cheque == "5") //استرداد
                {
                    CheckProcess ch = ak.CheckProcesses.First(i => i.IDCheck == g);
                    ch.CPType = Common.Constants.BaseInfoType.esterdade_cheque;
                    int r = ak.SaveChanges();
                    if (r == 1)
                    {
                        MessageBox.Show("با موفقیت ثبت شد");
                        this.Hide();
                    }
                }
                /////
                if (Class.Variable.Variables.noe_cheque == "6") // برگشت چک خرج شده
                {
                    CheckProcess ch = ak.CheckProcesses.First(i => i.IDCheck == g);
                    ch.CPType = Common.Constants.BaseInfoType.bargashte_cheque_kharj_shode;
                    int r = ak.SaveChanges();
                    if (r == 1)
                    {
                        MessageBox.Show("با موفقیت ثبت شد");
                        this.Hide();
                    }
                }
            }
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
           // MessageBox.Show(Class.Variable.Variables.noe_cheque);
        }

        private void btn_code_bank_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.chequeSerial(e);
        }

        private void txt_code_cheque_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.chequeSerial(e);
        }
    }
}
