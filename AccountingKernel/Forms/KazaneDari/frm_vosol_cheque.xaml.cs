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
    /// Interaction logic for frm_vosol_cheque.xaml
    /// </summary>
    public partial class frm_vosol_cheque : Window
    {
        Class.UI.TextHandeler c = new Class.UI.TextHandeler();
        public frm_vosol_cheque()
        {
            InitializeComponent();
        }
        AccountingKernelEntities10 ak = new AccountingKernelEntities10();
        Guid g;

        string bank_name = "";

        int sandogh_selected = 0;
        int bank_selected = 0;

        Guid ID_sandogh;
        Guid ID_cheque;
        Guid ID_bank;

        
        private void btn_entekhabe_cheque_Click(object sender, RoutedEventArgs e)
        {
            frm_get_bank_get_cheque frmGbGc = new frm_get_bank_get_cheque();
            frmGbGc.ShowDialog();
            txt_entekhabe_cheque.Text = pass_data.ch_id;
            
        }

        private decimal get_CPrice(string ch_code)
        {

            List<Check> c = ak.Checks.Where(i => i.CNO == ch_code).ToList();

            return (decimal)c[0].CPrice;
        }


        private decimal get_mablaghe_cheque(string code_cheque)
        {
            decimal d;
            List<Check> c = ak.Checks.Where(i => i.CNO == code_cheque).ToList();
            d = (decimal)c[0].CPrice;
            return d;
        }

        private string get_bank_number(Guid bank_id)
        {
            List<Fund> f = ak.Funds.Where(i => i.ID == bank_id).ToList();
            return f[0].FBankNO;
        }

        private string get_bank_name(Guid bank_id)
        {
            List<Fund> f = ak.Funds.Where(i => i.ID == bank_id).ToList();
            return f[0].FBank;
        }


        private void txt_entekhabe_sandogh_Click(object sender, RoutedEventArgs e)
        {
            pass_data.get_fund = "1";
            frm_entekhabe_bank eb = new frm_entekhabe_bank();
            eb.ShowDialog();
            pass_data.get_fund = "0";

            if (Class.Variable.Variables.idFunds != "")
            {
                ID_sandogh = Guid.Parse(Class.Variable.Variables.idFunds);
                txt_sandogh.Text = get_bank_number(ID_sandogh);
                sandogh_selected = 1;


            }
        }

        private void btn_reg_Click(object sender, RoutedEventArgs e)
        {
            if (txt_entekhabe_cheque.Text != "")
            {
                if (sandogh_selected == 1)
                {
                    if (txt_sandogh.Text != "")
                    {
                        decimal fPrice = 0;
                        ///// get FPrice for sandogh
                        var v = ak.Funds.First(i => i.ID == ID_sandogh);
                        if (v.Fprice != null)
                        {
                            fPrice = (decimal)v.Fprice;
                        }

                        ////////////////////////////
                        decimal cp = get_mablaghe_cheque(pass_data.ch_id);
                        ///////////////////////////

                        decimal get_final_price = fPrice + cp;

                        //// updae price for sandogh 

                        List<Fund> f = ak.Funds.Where(j => j.ID == ID_sandogh).ToList();
                        f[0].Fprice = get_final_price;

                        int k = ak.SaveChanges();

                        if (k == 1)
                        {
                            MessageBox.Show("مبلغ چک در صندوق مورد نظر ثبت گردید");
                            this.Hide();
                        }

                    }

                    else
                    {
                        MessageBox.Show("<-->");
                    }
                }

                if (bank_selected == 1)
                {
                    decimal d = 0;
                    ///// get mablaghe hesab 
                    var v = ak.Funds.First(i => i.FAccountnumber == txt_shomare_hesab.Text && i.FBank == txt_banke_hesab.Text);

                    ///// GET PPPP
                    if (v.Fprice != null)
                    {
                        d = (decimal)v.Fprice;
                    }

                    /// GET CCCCC

                    decimal cp = get_mablaghe_cheque(pass_data.ch_id);

                    decimal new_price = d + cp;

                    List<Fund> f = ak.Funds.Where(i => i.FAccountnumber == txt_shomare_hesab.Text && i.FBank == txt_banke_hesab.Text).ToList();
                    f[0].Fprice = new_price;

                    //چک تغییر نوع 

                    Guid get_check_id = Guid.NewGuid();
                    string id_cheque = pass_data.ch_id;
                    List<Check> get_CBank = ak.Checks.Where(i => i.CNO == id_cheque).ToList();

                    foreach (var item_getCBank in get_CBank)
                    {
                        var get_bank = ak.Funds.FirstOrDefault(i => i.ID == item_getCBank.CBank);
                        if (get_bank.FBank == pass_data.get_bank_selected)
                        {
                            get_check_id = item_getCBank.ID;
                            break;
                        }
                    }

                    var up = ak.CheckProcesses.Where(i => i.IDCheck == get_check_id).First();
                    up.CPType = Common.Constants.BaseInfoType.vosole_cheque;
                    //ak.SaveChanges();

                    // 

                    int k = ak.SaveChanges();

                    if (k >= 1)
                    {
                        MessageBox.Show("مبلغ چک در صندوق مورد نظر ثبت گردید");
                        this.Hide();
                    }

                }

            } // کد چک
            else
            {
                MessageBox.Show("شماره چک وارد نشده است");
            }


        }

        private void btn_entekhabe_banke_hesab_Click(object sender, RoutedEventArgs e)
        {
            pass_data.get_bank = "1";
            frm_entekhabe_bank eb = new frm_entekhabe_bank();
            eb.ShowDialog();
            pass_data.get_bank = "0";

            if (Class.Variable.Variables.idFunds != "")
            {
                ID_bank = Guid.Parse(Class.Variable.Variables.idFunds);
                txt_banke_hesab.Text = get_bank_name(ID_bank);
                bank_name = get_bank_name(ID_bank);
                bank_selected = 1;
            }
        }

        private void btn_shomare_hesab_Click(object sender, RoutedEventArgs e)
        {
            pass_data.b_name = txt_banke_hesab.Text;
            frm_get_shomare_hesab sh = new frm_get_shomare_hesab();
            sh.ShowDialog();
            pass_data.b_name = "";

            txt_shomare_hesab.Text = pass_data.sh_hesab;
        
        }

        private void txt_sandogh_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_sandogh.Text != "")
            {
                btn_entekhabe_banke_hesab.IsEnabled = false;
                txt_banke_hesab.IsEnabled = false;
                txt_shomare_hesab.IsEnabled = false;
                btn_shomare_hesab.IsEnabled = false;
            }
            else
            {
                btn_entekhabe_banke_hesab.IsEnabled = true;
                txt_banke_hesab.IsEnabled = true;
                txt_shomare_hesab.IsEnabled = true;
                btn_shomare_hesab.IsEnabled = true;
            }
        }

        private void txt_banke_hesab_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_banke_hesab.Text != "")
            {
                txt_sandogh.IsEnabled = false;
                txt_entekhabe_sandogh.IsEnabled = false;
                
            }
            else
            {
                txt_sandogh.IsEnabled = true;
                txt_entekhabe_sandogh.IsEnabled = true;
            }
        }

        private void txt_shomare_hesab_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }


    }
}
