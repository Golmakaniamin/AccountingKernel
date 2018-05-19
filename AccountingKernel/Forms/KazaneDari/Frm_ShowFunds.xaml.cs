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
using Common;

namespace AccountingKernel.Forms.KazaneDari
{
    /// <summary>
    /// Interaction logic for frm_amaliateCheque.xaml
    /// </summary>
    public partial class Frm_ShowFunds : Window
    {
        public Guid FundId;

        public Frm_ShowFunds()
        {
            try
            {
                InitializeComponent();
                cmbReciverCode.ItemsSource = Business.GetBaseInfoBusiness().GetByType(Common.Constants.BaseInfoType.BankType);
            }
            catch
            {

                throw;
            }
        }

        public Frm_ShowFunds(Guid bankTypeId)
        {
            try
            {
                InitializeComponent();
                cmbReciverCode.IsEnabled = false;
                cmbReciverCode.ItemsSource = Business.GetBaseInfoBusiness().GetByType(bankTypeId);
                cmbReciverCode_SelectionChanged();
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
                SelectFund();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void cmbReciverCode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                cmbReciverCode_SelectionChanged();
            }
            catch
            {

                throw;
            }
        }

        private void cmbReciverCode_SelectionChanged()
        {
            try
            {
                grdFunds.ItemsSource = Business.GetFundsBusiness().GetByFType(cmbReciverCode.SelectedValue.ToGUID()).ToList();
            }
            catch 
            {
                
                throw;
            }
        }

        private void grdFunds_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                SelectFund();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void SelectFund()
        {
            try
            {
                if (grdFunds.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);

                FundId = (grdFunds.SelectedValue as dynamic).ID;

                this.Close();
            }
            catch
            {

                throw;
            }
        }


    }
}
