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
    public partial class Frm_ShowCheques : Window
    {
        public Guid ChequeId;
        public Guid ChequeTypeId;

        public Frm_ShowCheques()
        {
            try
            {
                InitializeComponent();

                SetDatagrid();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        public Frm_ShowCheques(Guid chequeTypeId)
        {
            try
            {
                InitializeComponent();

                this.ChequeTypeId = chequeTypeId;

                SetDatagrid();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void SetDatagrid()
        {
            try
            {
                var cheques = Business.GetChequeBusiness().GetAll();
                if (this.ChequeTypeId != Guid.Empty)
                    cheques = cheques.Where(r => r.CType == this.ChequeTypeId);
                var funds = Business.GetFundsBusiness().GetAll();
                var jResult = cheques.Join(funds, o => o.CBank, i => i.ID, (o, i) => new { Cheque = o, Fund = i });
                grdCheques.ItemsSource = jResult.Select(r => new { r.Cheque.ID, r.Fund.FName, r.Fund.FAccountnumber, r.Cheque.CNO }).ToList();

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
                SelectCheque();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void grdCheques_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                SelectCheque();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void SelectCheque()
        {
            try
            {
                if (grdCheques.SelectedIndex == -1)
                    throw new Exception(Localize.ex_no_record_selected);

                ChequeId = (grdCheques.SelectedValue as dynamic).ID;
                this.Close();

            }
            catch
            {

                throw;
            }
        }

    }
}
