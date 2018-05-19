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

namespace AccountingKernel.Forms.Settings.Tax
{
    /// <summary>
    /// Interaction logic for frm_tarife_toole_code.xaml
    /// </summary>
    public partial class FrmRegisterSOTax : Window
    {
        Class.UI.TextHandeler c = new Class.UI.TextHandeler();
        public FrmRegisterSOTax()
        {
            try
            {
                InitializeComponent();

                cmbBaseInfo.ItemsSource = Business.GetBaseInfoBusiness().GetByType(Common.Constants.BaseInfoType.Tax);
                cmbFinancialYear.ItemsSource = Business.GetFinancialMainYearBusiness().GetByCorporationId(MainWindow.CorposrationId).ToList();
            }
            catch
            {

                throw;
            }
        }

        private void btn_click(object sender, RoutedEventArgs e)
        {
            try
            {
                var soTax = Business.GetSOTaxBusiness().GetByFinancialYearBaseInfo(cmbFinancialYear.SelectedValue.ToGUID(), cmbBaseInfo.SelectedValue.ToGUID());
                if (soTax == null)
                    soTax = new Data.SOTax()
                    {
                        IdBaseinfo = cmbBaseInfo.SelectedValue.ToGUID(),
                        IdFinancialMainYear = cmbFinancialYear.SelectedValue.ToGUID(),
                    };
                soTax.Percent = txtPercent.Text.ToDecimal();
                Business.GetSOTaxBusiness().Save(soTax);
                this.Close();
            }
            catch
            {

                throw;
            }
        }

        private void cmbBaseInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var soTax = Business.GetSOTaxBusiness().GetByFinancialYearBaseInfo(cmbFinancialYear.SelectedValue.ToGUID(), cmbBaseInfo.SelectedValue.ToGUID());

                txtPercent.Text = soTax == null ? string.Empty : soTax.Percent.ToString();
            }
            catch
            {

                throw;
            }
        }

        private void txtPercent_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e); 
        }

    }
}
