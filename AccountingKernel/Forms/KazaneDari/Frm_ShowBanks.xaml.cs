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

namespace AccountingKernel.Forms.KazaneDari
{
    /// <summary>
    /// Interaction logic for frm_amaliateCheque.xaml
    /// </summary>
    public partial class Frm_ShowBanks : Window
    {
        public Guid FundId;

        public Frm_ShowBanks()
        {
            try
            {
                InitializeComponent();

                grdFunds.ItemsSource = Business.GetFundsBusiness().GetByFType(Common.Constants.BankType.Bank).ToList();
            }
            catch
            {

                throw;
            }
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (grdFunds.SelectedIndex == -1)
                    throw new Exception(Localize.ex_no_record_selected);

                FundId = (grdFunds.SelectedValue as dynamic).ID;
                this.Close();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }


    }
}
