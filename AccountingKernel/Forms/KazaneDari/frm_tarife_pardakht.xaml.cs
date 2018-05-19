using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
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
    /// Interaction logic for frm_tarife_pardakht.xaml
    /// </summary>
    public partial class frm_tarife_pardakht : Window
    {
        Class.UI.TextHandeler txt_filter = new Class.UI.TextHandeler();

        public Guid TreasuryId;
        private Guid TreasuryDetailId;
        private Guid? FundId = null;

        public frm_tarife_pardakht()
        {
            try
            {
                InitializeComponent();

                NormalConstructor();
            }
            catch
            {

                throw;
            }
        }

        public frm_tarife_pardakht(Guid TreasuryId)
        {
            try
            {
                InitializeComponent();

                this.TreasuryId = TreasuryId;

                var treasury = Business.GetTreasuryBusiness().GetById(TreasuryId);

                if (treasury != null)
                {
                    txtNo.Text = treasury.TNO;
                    txtTreasuryDescription.Text = treasury.TDescription;
                    dtpDate.Text = treasury.TDate;
                }

                NormalConstructor();
            }
            catch
            {

                throw;
            }
        }

        private void NormalConstructor()
        {
            try
            {
                cmb_noe_daryaft.ItemsSource = Business.GetBaseInfoBusiness().GetByType(Common.Constants.BaseInfoType.TreasuryDetailType);
                cmb_noe_daryaft_SelectionChanged();

                txtNo.Text = Business.GetTreasuryBusiness().GetNewCode(Common.Constants.CodeTitle.Recive);

                var funds = Business.GetFundsBusiness().GetAll();
                var jResult = Business.GetChequeBusiness().GetByCType(Common.Constants.ChequeType.Payment).Join(funds, o => o.CBank, i => i.ID, (o, i) => new
                {
                    Cheque = o,
                    Fund = i
                }).ToList();

                foreach (var item in jResult)
                {
                    var name = string.Format("{0}{1}{2}", item.Cheque.CNO, Localize.Cheque_Fund_Seperator, item.Fund.FBank);
                    txtCheque.AddItem(new WPFAutoCompleteTextbox.AutoCompleteEntry(name, name));
                }

                SetDataGrid();
            }
            catch
            {

                throw;
            }
        }

        private void cmb_noe_daryaft_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                cmb_noe_daryaft_SelectionChanged();
            }
            catch
            {

                throw;
            }
        }

        private void cmb_noe_daryaft_SelectionChanged()
        {
            try
            {
                txtPaymentFrom.IsEnabled = btnRecivePlace.IsEnabled = txtPrice.IsEnabled = txtDetailDescrition.IsEnabled =
                    cmb_noe_daryaft.SelectedValue.ToGUID() == Common.Constants.TreasuryDetailType.Cash;

                txtCheque.IsEnabled = btnSelectCheque.IsEnabled = txtChequePrice.IsEnabled = txtChequeDetailDescrition.IsEnabled =
                    cmb_noe_daryaft.SelectedValue.ToGUID() == Common.Constants.TreasuryDetailType.Cheque;

            }
            catch
            {

                throw;
            }
        }

        private void SetDataGrid()
        {
            try
            {
                grdTreasuryDetails.ItemsSource = Business.GetTreasuryDetailBusiness().GetViewByTreasuryId(TreasuryId).ToList();
            }
            catch
            {

                throw;
            }
        }

        private bool ValidateData(out string errorMessage)
        {
            try
            {
                errorMessage = string.Empty;

                if (Business.GetTreasuryBusiness().IsCodeExists(TreasuryId, txtNo.Text))
                    errorMessage += string.Format("{0}{1}", Localize.ex_duplicated_code, Environment.NewLine);

                if (cmb_noe_daryaft.SelectedIndex == -1)
                    errorMessage += string.Format("{0}{1}", Localize.ex_recivetype_not_found, Environment.NewLine);

                if (txtNo.Text.Trim().Length == 0)
                    errorMessage += string.Format("{0}{1}", Localize.ex_enter_code, Environment.NewLine);

                if (cmb_noe_daryaft.SelectedValue.ToGUID() == Common.Constants.TreasuryDetailType.Cash)
                {
                    if (!FundId.HasValue)
                        errorMessage += string.Format("{0}{1}", Localize.ex_enter_fund, Environment.NewLine);

                    if (dtpDate.Text.Trim().Length == 0)
                        errorMessage += string.Format("{0}{1}", Localize.ex_enter_date, Environment.NewLine);

                    if (txtPrice.Text.Trim().Length == 0)
                        errorMessage += string.Format("{0}{1}", Localize.ex_enter_price, Environment.NewLine);

                    if (txtPrice.Text.ToDecimal() < 0)
                        errorMessage += string.Format("{0}{1}", Localize.ex_invalid_price, Environment.NewLine);
                }
                else
                {
                    if (txtCheque.Text.Trim().Length == 0)
                        errorMessage += string.Format("{0}{1}", Localize.ex_enter_cheque_number, Environment.NewLine);

                    if (dtpChequeDate.Text.Trim().Length == 0)
                        errorMessage += string.Format("{0}{1}", Localize.ex_enter_cheque_date, Environment.NewLine);

                    if (txtChequePrice.Text.ToDecimal() < 0)
                        errorMessage += string.Format("{0}{1}", Localize.ex_invalid_cheque_price, Environment.NewLine);
                }

                return errorMessage == string.Empty;
            }
            catch
            {

                throw;
            }
        }

        private void btnRecivePlace_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var frm_ShowFunds = new Frm_ShowFunds(Common.Constants.BankType.Sandogh);
                frm_ShowFunds.ShowDialog();
                FundId = frm_ShowFunds.FundId;
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void txtCheque_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                var chequeStrings = txtCheque.Text.Split(Localize.Cheque_Fund_Seperator.ToChar());
                if (chequeStrings.Count() <= 1)
                    return;
                var cheque = Business.GetChequeBusiness().GetByNumber(chequeStrings[0], chequeStrings[1]);
                if (cheque != null)
                    txtPrice.Text = cheque.CPrice.ToString(Localize.DoubleMaskType);
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void btnSelectCheque_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var frm_ShowCheques = new Frm_ShowCheques(Common.Constants.ChequeType.Payment);
                frm_ShowCheques.ShowDialog();
                var cheque = Business.GetChequeBusiness().GetById(frm_ShowCheques.ChequeId);
                if (cheque == null)
                    return;

                SetChequeControls(cheque);
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void grdTreasuryDetails_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                if (grdTreasuryDetails.SelectedValue == null)
                    return;
                TreasuryDetailId = (grdTreasuryDetails.SelectedValue as dynamic).ID;
                var treasuryDetail = Business.GetTreasuryDetailBusiness().GetById(TreasuryDetailId);
                cmb_noe_daryaft.SelectedValue = treasuryDetail.TDType;
                cmb_noe_daryaft_SelectionChanged();


                var cheque = Business.GetChequeBusiness().GetById(treasuryDetail.IDCheck.ToGUID());
                if (cheque != null)
                    SetChequeControls(cheque);


            }
            catch
            {

                throw;
            }
        }

        private void SetChequeControls(Data.Check cheque)
        {
            try
            {
                var fund = Business.GetFundsBusiness().GetById(cheque.CBank.ToGUID());
                if (fund == null)
                    return;

                txtCheque.Text = string.Format("{0}{1}{2}", cheque.CNO, Localize.Cheque_Fund_Seperator, fund.FBank);
                txtPrice.Text = cheque.CPrice.ToString(Localize.DoubleMaskType);

            }
            catch
            {

                throw;
            }
        }

        private void btnRegDetail_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var errorMessage = string.Empty;
                if (!ValidateData(out errorMessage))
                    throw new Exception(errorMessage);


                using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
                {
                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted,
                    Timeout = new TimeSpan(2, 0, 0)
                }))
                {

                    var treasury = SaveTreasury();
                    var chequeStrings = txtCheque.Text.Split(Localize.Cheque_Fund_Seperator.ToChar());

                    Guid? chequeId = null;

                    if (cmb_noe_daryaft.SelectedValue.ToGUID() == Common.Constants.TreasuryDetailType.Cheque)
                    {
                        var cheque = Business.GetChequeBusiness().GetByNumber(chequeStrings[0], chequeStrings[1]);
                        if (cheque != null)
                            chequeId = cheque.ID;
                    }


                    var treasuryDetail = Business.GetTreasuryDetailBusiness().GetById(TreasuryDetailId);
                    if (treasuryDetail == null)
                    {
                        treasuryDetail = new Data.TreasuryDetail()
                        {
                            IDTreasury = treasury.ID
                        };
                    }

                    treasuryDetail.TDPrice = cmb_noe_daryaft.SelectedValue.ToGUID() == Common.Constants.TreasuryDetailType.Cash ? txtPrice.Text.ToDecimal() : txtChequePrice.Text.ToDecimal();
                    treasuryDetail.IDCheck = chequeId;
                    treasuryDetail.IDFund = FundId;
                    treasuryDetail.TDType = cmb_noe_daryaft.SelectedValue.ToGUID();
                    treasuryDetail.TDDescription = cmb_noe_daryaft.SelectedValue.ToGUID() == Common.Constants.TreasuryDetailType.Cash ? txtDetailDescrition.Text : txtChequeDetailDescrition.Text;

                    Business.GetTreasuryDetailBusiness().Save(treasuryDetail);

                    scope.Complete();
                }

                SetDataGrid();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private Data.Treasury SaveTreasury()
        {
            try
            {
                var treasury = Business.GetTreasuryBusiness().GetById(TreasuryId);
                if (treasury == null)
                    treasury = new Data.Treasury()
                    {
                        TPrice = cmb_noe_daryaft.SelectedValue.ToGUID() == Common.Constants.TreasuryDetailType.Cash ? txtPrice.Text.ToDecimal() : txtChequePrice.Text.ToDecimal()
                    };
                else
                    if (TreasuryDetailId != Guid.Empty)
                    {
                        decimal oldPrice = 0;
                        oldPrice = Business.GetTreasuryDetailBusiness().GetById(TreasuryDetailId).TDPrice.ToDecimal();
                        treasury.TPrice += -oldPrice + (cmb_noe_daryaft.SelectedValue.ToGUID() == Common.Constants.TreasuryDetailType.Cash ? txtPrice.Text.ToDecimal() : txtChequePrice.Text.ToDecimal());
                    }

                treasury.TDate = DateTime.Now.ToPersian();
                treasury.TNO = txtNo.Text;
                treasury.Ttype = Common.Constants.TreasuryType.Payment;
                treasury.TDescription = txtTreasuryDescription.Text;

                Business.GetTreasuryBusiness().Save(treasury);
                TreasuryId = treasury.ID;

                return treasury;
            }
            catch
            {

                throw;
            }
        }

        private void btnRegTreasury_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveTreasury();
                this.Close();
            }
            catch
            {

                throw;
            }
        }

        private void txtNo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

            txt_filter.CheckIsNumeric(e);
        }

        private void txtCheque_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void txtPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

            txt_filter.AddZero(sender, e);
        }

        private void txtTreasuryDescription_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            txt_filter.JustPersian(e);
        }

        private void txtRecivePlace_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            txt_filter.CheckIsNumeric(e);
        }

        private void TextBox_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        {
            txt_filter.JustPersian(e);
        }

        private void MenuItem_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (grdTreasuryDetails.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);

                Guid treasuryDetailId = (grdTreasuryDetails.SelectedValue as dynamic).ID;
                var treasuryDetail = Business.GetTreasuryDetailBusiness().GetById(treasuryDetailId);
                var treasury = Business.GetTreasuryBusiness().GetById(treasuryDetail.IDTreasury.ToGUID());
                treasury.TPrice -= treasuryDetail.TDPrice;


                using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
                {
                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted,
                    Timeout = new TimeSpan(2, 0, 0)
                }))
                {
                    Business.GetTreasuryBusiness().Save(treasury);
                    Business.GetTreasuryDetailBusiness().Delete(treasuryDetail);

                    scope.Complete();
                }

                SetDataGrid();
            }
            catch
            {

                throw;
            }
        }

        private void txtChequePrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            txt_filter.SepratTextBox(sender, e);
        }

        private void txtPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            txt_filter.SepratTextBox(sender, e);
        }

        private void txtChequeDetailDescrition_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
