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

namespace AccountingKernel.Forms.baseInfo
{
    /// <summary>
    /// Interaction logic for frm_list_bank.xaml
    /// </summary>
    public partial class FrmChequeDecleration : Window
    {
        Class.UI.TextHandeler c = new Class.UI.TextHandeler();
        Guid FundId;
        public FrmChequeDecleration()
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

        public FrmChequeDecleration(Guid fundId)
        {
            try
            {
                InitializeComponent();
                FundId = fundId;

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
                if (txtSerial.Text.Trim().Length == 0)
                    throw new Exception(Localize.ex_empty_serial);

                if (txtNum.Text.Trim().Length == 0)
                    throw new Exception(Localize.ex_empty_num);

                if (txtNum.Text.ToInt() <= 0)
                    throw new Exception(Localize.ex_invalid_num);

                var chequeBusiness = Business.GetChequeBusiness();

                if (chequeBusiness.GetByFundId(FundId, txtSerial.Text, (txtSerial.Text.ToInt() + txtNum.Text.ToInt()).ToString()).Any())
                    throw new Exception(Localize.ex_dupliacted_serial);

                var fund = Business.GetFundsBusiness().GetById(FundId);
                
                var cheques = new List<Data.Check>();
                for (int i = 0; i < txtNum.Text.ToInt(); i++)
                {
                    cheques.Add(new Data.Check()
                    {
                        CNO = (txtSerial.Text.ToInt() + i).ToString(),
                        CAccountnumber = fund.FAccountnumber,
                        CPrice = null,
                        CName = fund.FName,
                        CBank = fund.ID,
                        CType = Common.Constants.ChequeType.Payment
                    });
                }

                chequeBusiness.Save(cheques);

            }
            catch
            {

                throw;
            }
        }

        private void txtNum_TextChanged(object sender, TextChangedEventArgs e)
        {
            c.SepratTextBox(sender, e); 
        }

    }
}
