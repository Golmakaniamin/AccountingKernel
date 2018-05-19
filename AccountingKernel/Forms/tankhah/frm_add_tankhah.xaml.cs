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
using System.Text.RegularExpressions;

namespace AccountingKernel.Forms.tankhah
{
    /// <summary>
    /// Interaction logic for frm_add_tankhah.xaml
    /// </summary>
    public partial class frm_add_tankhah : Window
    {
        Class.UI.TextHandeler txt_filter = new Class.UI.TextHandeler();
        public frm_add_tankhah()
        {
            InitializeComponent();
        }

        AccountingKernelEntities10 ak = new AccountingKernelEntities10();
        Guid capital_id;
        private void btn_selectPersonnel_Click(object sender, RoutedEventArgs e)
        {
            frm_entekhabe_personnel_ ep = new frm_entekhabe_personnel_();
            ep.ShowDialog();
            // GET
            if (pass_data.ID != "")
            {
                Guid g = Guid.Parse(pass_data.ID);
                var v = ak.PayrollPersons.Where(i => i.id == g).First();

                if (pass_data.ID != "")
                {

                    txt_code_personnel.Text = v.PPerson_Code;
                }
            }
        }

        private void btn_sabt_Click(object sender, RoutedEventArgs e)
        {

            if (pic_tarikhe_hazine.Text.CompareTo(pic_date.Text) >= 0)
            {
                capital_id = pass_data.id_capital;

                if (txt_tozihat.Text != "" && txtprice.Text != "" && pic_date.Text != "")
                {
                    CapitalDetail cpd = new CapitalDetail()
                    {
                        ID = Guid.NewGuid(),
                        CDDate = pic_tarikhe_hazine.Text,
                        CDDescription = txt_tozihat.Text,
                        CDPrice = decimal.Parse(txtprice.Text),
                        IDCapital = capital_id
                    };
                    ak.CapitalDetails.Add(cpd);
                    int bb = ak.SaveChanges();

                    if (bb == 1)
                    {
                        MessageBox.Show("ذخیره شد");
                        grid_tankhah.ItemsSource = ak.CapitalDetails.Where(i => i.IDCapital == capital_id).ToList();

                        txt_tozihat.Text = "";
                        txtprice.Text = "";
                    }

                }
                else
                {
                    MessageBox.Show("تمامی مقادیر الزامی میباشد");
                }
            }
            else
            {
                MessageBox.Show("لطفا تاریخ را به درستی تنظیم نمایید");
            }
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            Capital cp = new Capital
            {
                ID = Guid.NewGuid()
            };

            ak.Capitals.Add(cp);
            ak.SaveChanges();

            pass_data.id_capital = cp.ID;

        }

        private void btn_sabt2_Click(object sender, RoutedEventArgs e)
        {

            // get total price
            var v = ak.CapitalDetails.Where(i => i.IDCapital == capital_id).ToList();
            decimal dc = 0.0M;

            for (int b = 0; b <= v.Count - 1; b++)
            {
                dc += (decimal)v[b].CDPrice;
            }

            //

            if (txt_shomare.Text != "" && txt_code_personnel.Text != "" && pic_date.Text != "")
            {
                Guid g = Guid.Parse(pass_data.ID);
                /*
            Capital cp = new Capital
            {
                CDate = pic_date.Text,
                CNO = txt_shomare.Text ,
                CPerson = g,
                ID = Guid.NewGuid(),
                CTotalPrice = dc
            };

            ak.Capitals.Add(cp);
            int bb = ak.SaveChanges();*/

                var p = ak.Capitals.Where(i => i.ID == pass_data.id_capital).First();
                p.CDate = pic_date.Text;
                p.CNO = txt_shomare.Text;
                p.CPerson = g;
                p.CTotalPrice = dc;

                int bb = ak.SaveChanges();

                if (bb == 1)
                {
                    MessageBox.Show("ذخیره شد");
                    pass_data.is_reg = 1;
                    this.Hide();
                }

            }
            else
            {
                MessageBox.Show("تمامی مقادیز الزامی میباشد");
            }
        }

        private void Window_Unloaded_1(object sender, RoutedEventArgs e)
        {


        }

        private void txtprice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            txt_filter.AddZero(sender, e);
        }

        private void txt_tozihat_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            txt_filter.JustPersian(e);
        }

        private void txt_shomare_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            txt_filter.CheckIsNumeric(e);
        }

        private void txtprice_TextChanged(object sender, TextChangedEventArgs e)
        {
            txt_filter.SepratTextBox(sender, e);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            

            capital_id = pass_data.id_capital;

            ImportFromExcel.frm_excel frmEx = new ImportFromExcel.frm_excel(grid_tankhah);
            
            frmEx.ShowDialog();
            string[,] get_data_array = frmEx.get_data_array();


            // gereftane dadeha va zakhire darone data base 
            CapitalDetail cd;
            int save_change_count = 0;
            if (get_data_array != null)
            {
                for (int i = 0, c = 1; i <= get_data_array.GetLength(0) - 2; i++, c++)
                {

                    cd = new CapitalDetail();
                    cd.IDCapital = capital_id;
                    cd.ID = Guid.NewGuid(); // new ID
                    cd.CDDate =  get_data_array[i+1, 0];  /*frmEx.get_data_by_name_index("تاریخ", c);*/
                    
                    if (/*frmEx.get_data_by_name_index("هزینه", c) */ (get_data_array[i, 1]) != null)
                    {
                        //string str = Regex.Replace(frmEx.get_data_by_name_index("هزینه", c), @"[^\d]", "");
                        string str = Regex.Replace(get_data_array[i+1, 1], @"[^\d]", "");
                        cd.CDPrice = decimal.Parse(get_data_array[i+1, 1]); /* decimal.Parse(str);*/
                    }
                    else
                    {
                        cd.CDPrice = /*decimal.Parse(get_data_array[i, 1]); */ 0;
                    }

                    cd.CDDescription = get_data_array[i+1, 2];  /*frmEx.get_data_by_name_index("اضافات", c);*/

                    ak.CapitalDetails.Add(cd);
                    save_change_count += ak.SaveChanges();
                }

                if (save_change_count == get_data_array.GetLength(0) - 1) // all data saved
                {
                    MessageBox.Show("ثبت شد");
                    grid_tankhah.ItemsSource = ak.CapitalDetails.Where(i => i.IDCapital == capital_id).ToList();
                }
                //
            }
        
        }

    }
}
