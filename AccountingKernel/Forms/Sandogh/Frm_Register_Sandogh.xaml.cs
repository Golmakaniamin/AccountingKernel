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
using Common;

namespace AccountingKernel.Forms.Sandogh
{
    /// <summary>
    /// Interaction logic for frm_sandogh.xaml
    /// </summary>
    public partial class Frm_Register_Sandogh : Window
    {
      
        Guid? FundId;
        public Frm_Register_Sandogh()
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

        public Frm_Register_Sandogh(Guid fundId)
        {
            try
            {
                InitializeComponent();
                var fund = Business.GetFundsBusiness().GetById(fundId);
                this.FundId = fundId;
                txtName.Text = fund.FName;
                numPrice.Text = fund.Fprice.ToDecimal().ToString();
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
                
                var fundBusiness= Business.GetFundsBusiness();

 
                var fund = fundBusiness.GetById(FundId.ToGUID());
                if (fund == null)
                    fund = new Data.Fund() { FType = Common.Constants.BankType.Sandogh };

                fund.FName = txtName.Text;
                fund.Fprice = numPrice.Text.ToDecimal();

                fundBusiness.Save(fund);
                this.Close();
            }
            catch
            {

                throw;
            }
        }

        Class.UI.TextHandeler a = new Class.UI.TextHandeler();

        private void numPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            a.SepratTextBox(sender, e);
        }

        private void txtName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            a.JustPersian(e);
        }

        private void numPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            a.CheckIsNumeric(e);
        }
    }
}
