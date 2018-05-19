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
using System.Transactions;

namespace AccountingKernel.Forms.saleMaly
{
    /// <summary>
    /// Interaction logic for frm_tarifeSaleMaly.xaml
    /// </summary>
    public partial class frm_tarifeSaleMaly : Window
    {
        AccountingKernelEntities10 ak = new AccountingKernelEntities10();
        Guid get_id_corporation = Guid.Empty;

        public frm_tarifeSaleMaly()
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

        public frm_tarifeSaleMaly(Guid entityId)
        {
            try
            {
                InitializeComponent();
                get_id_corporation = entityId;
                txtCorporation.IsEnabled = false;
                txtCorporation.Text = Business.GetCorporartionBusiness().GetById(entityId).CorporationName;
            }
            catch
            {

                throw;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                ValidateData();
                int sale_maly = txt_saleMaly.Text.ToInt();

                var fyList = new List<Data.Financialyear>();

                var financialMainYear = new Data.FinancialMainYear()
                {
                    IDCorporation = get_id_corporation,
                    FYear = sale_maly
                };

                for (int i = 1; i <= 12; i++)
                {
                    fyList.Add(new Financialyear()
                    {
                        FYyear = sale_maly,
                        IDCorporation = get_id_corporation,
                        FYMonthName = get_mounth_name(i),
                        FYMonthNumber = i,
                        FYMonthNO = get_mounth_numberOFDays(i),
                        piroity = i
                    });
                }


                using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
                {
                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted,
                    Timeout = new TimeSpan(2, 0, 0)
                }))
                {
                    Business.GetFinancialMainYearBusiness().Save(financialMainYear);

                    Business.GetFinancialyearBusiness().Save(fyList);

                    scope.Complete();
                }

                this.Hide();

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
                int value_to_save = 0;
                if (!int.TryParse(txt_saleMaly.Text, out value_to_save))
                    throw new Exception(Localize.ex_invalid_salemali);

                if (Business.GetCorporartionBusiness().GetByName(txtCorporation.Text) == null)
                    throw new Exception(Localize.ex_no_corporartion);

                var finacialMainYear = Business.GetFinancialMainYearBusiness().GetByCorporartionId(get_id_corporation, txt_saleMaly.Text.ToInt());

                if (finacialMainYear != null)
                    throw new Exception(Localize.ex_dupliacted_year);

            }
            catch
            {

                throw;
            }
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            if (pass_data.get_ID != "")
            {
                get_id_corporation = Guid.Parse(pass_data.get_ID);
            }
        }

        private string get_mounth_name(int monthNumber)
        {
            if (monthNumber == 1)
            {
                return "فروردین";
            }
            if (monthNumber == 2)
            {
                return "اردیبهشت";
            }
            if (monthNumber == 3)
            {
                return "خرداد";
            }
            if (monthNumber == 4)
            {
                return "تیر";
            }
            if (monthNumber == 5)
            {
                return "مرداد";
            }
            if (monthNumber == 6)
            {
                return "شهریور";
            }
            if (monthNumber == 7)
            {
                return "مهر";
            }
            if (monthNumber == 8)
            {
                return "آبان";
            }
            if (monthNumber == 9)
            {
                return "آذر";
            }
            if (monthNumber == 10)
            {
                return "دی";
            }
            if (monthNumber == 11)
            {
                return "بهمن";
            }
            if (monthNumber == 12)
            {
                return "اسفند";
            }

            return "";
        }

        private int get_mounth_numberOFDays(int mounth_number)
        {

            if (mounth_number >= 1 && mounth_number <= 6)
            {
                return 31;
            }
            if (mounth_number >= 7 && mounth_number <= 11)
            {
                return 30;
            }
            if (mounth_number == 12)
            {
                return 29;
            }

            return 0;
        }

    }
}
