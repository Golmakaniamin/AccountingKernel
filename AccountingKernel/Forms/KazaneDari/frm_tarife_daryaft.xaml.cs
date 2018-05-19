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
using System.Transactions;

namespace AccountingKernel.Forms.KazaneDari
{
    /// <summary>
    /// Interaction logic for frm_tarife_daryaft.xaml
    /// </summary>
    public partial class frm_tarife_daryaft : Window
    {
        Class.UI.TextHandeler c = new Class.UI.TextHandeler();
        public Guid TreasuryId;
        private Guid TreasuryDetailId;
        private Guid FundId;

        public frm_tarife_daryaft()
        {
            try
            {
                InitializeComponent();

                NormalConstructor();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        public frm_tarife_daryaft(Guid TreasuryId)
        {
            try
            {
                InitializeComponent();

                this.TreasuryId = TreasuryId;

                NormalConstructor();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void NormalConstructor()
        {
            try
            {
                cmb_noe_daryaft.ItemsSource = Business.GetBaseInfoBusiness().GetByType(Common.Constants.BaseInfoType.TreasuryDetailType);
                cmb_noe_daryaft_SelectionChanged();

                var treasury = Business.GetTreasuryBusiness().GetById(TreasuryId);
                if (treasury == null)
                {
                    txtNo.Text = Business.GetTreasuryBusiness().GetNewCode(Common.Constants.CodeTitle.Recive);
                }
                else
                {
                    txtNo.Text = treasury.TNO;
                    dtpDate.Text = treasury.TDate;
                    txtTreasuryDescription.Text = treasury.TDescription;
                    cmb_noe_daryaft.SelectedValue = treasury.Ttype;
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
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void cmb_noe_daryaft_SelectionChanged()
        {
            try
            {
                txtRecivePlace.IsEnabled = btnRecivePlace.IsEnabled = txtCashDescription.IsEnabled = cmb_noe_daryaft.SelectedValue.ToGUID() == Common.Constants.TreasuryDetailType.Cash;
                txtNumCheque.IsEnabled = txtBankName.IsEnabled = txtBankBranchCode.IsEnabled = txtBankBranchCode.IsEnabled = txtChequeDescription.IsEnabled = cmb_noe_daryaft.SelectedValue.ToGUID() == Common.Constants.TreasuryDetailType.Cheque;
                //if (cmb_noe_daryaft.SelectedValue.ToGUID() == Common.Constants.TreasuryDetailType.Cheque)
                //{
                //    var funds = Business.GetFundsBusiness().GetByFType(Common.Constants.BankType.Bank);
                //    foreach (var item in funds)
                //    {
                //        var name = string.Format("{0}{1}{2}", item.FAccountnumber, Localize.Cheque_Fund_Seperator, item.FBank);
                //        txtRecivePlace.AddItem(new WPFAutoCompleteTextbox.AutoCompleteEntry(name, name));
                //    }
                //}
                //else
                //{
                //    var funds = Business.GetFundsBusiness().GetByFType(Common.Constants.BankType.Sandogh);
                //    foreach (var item in funds)
                //    {
                //        var name = string.Format("{0}{1}{2}", item.FAccountnumber, Localize.Cheque_Fund_Seperator, item.FName);
                //        txtRecivePlace.AddItem(new WPFAutoCompleteTextbox.AutoCompleteEntry(name, name));
                //    }
                //}
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
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

                if (dtpDate.Text.Trim().Length == 0)
                    errorMessage += string.Format("{0}{1}", Localize.ex_enter_date, Environment.NewLine);

                //if (txtReciver.Text.Trim().Length == 0)
                //    errorMessage += string.Format("{0}{1}", Localize.ex_invalid_reciver, Environment.NewLine);

                if (cmb_noe_daryaft.SelectedIndex < 0)
                    errorMessage += string.Format("{0}{1}", Localize.ex_invalid_revice_type, Environment.NewLine);

                if (cmb_noe_daryaft.SelectedValue.ToGUID() == Common.Constants.TreasuryDetailType.Cash)
                {
                    if (txtRecivePlace.Text.Trim().Length == 0)
                        errorMessage += string.Format("{0}{1}", Localize.ex_invalid_recive_place, Environment.NewLine);

                    if (txtPrice.Text.Trim().Length == 0)
                        errorMessage += string.Format("{0}{1}", Localize.ex_enter_price, Environment.NewLine);

                    if (txtPrice.Text.ToDecimal() < 0)
                        errorMessage += string.Format("{0}{1}", Localize.ex_invalid_price, Environment.NewLine);
                }
                else
                {
                    if (txtNumCheque.Text.Trim().Length == 0)
                        errorMessage += string.Format("{0}{1}", Localize.ex_invalid_cheque_num, Environment.NewLine);

                    if (txtBankName.Text.Trim().Length == 0)
                        errorMessage += string.Format("{0}{1}", Localize.ex_invalid_bankname, Environment.NewLine);

                    if (txtBankBranchCode.Text.Trim().Length == 0)
                        errorMessage += string.Format("{0}{1}", Localize.ex_invalid_bankbranchcode, Environment.NewLine);
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
                var frm_ShowFunds = new Frm_ShowFunds();
                frm_ShowFunds.ShowDialog();
                var fund = Business.GetFundsBusiness().GetById(frm_ShowFunds.FundId);
                if (fund == null)
                    return;
                FundId = fund.ID;
                txtRecivePlace.Text = string.Format("{0}{1}{2}", fund.FAccountnumber, Localize.Cheque_Fund_Seperator, fund.FName);
                //}
                //else
                //{
                //    var frm_ShowBanks = new Frm_ShowBanks();
                //    frm_ShowBanks.ShowDialog();
                //    var fund = Business.GetFundsBusiness().GetById(frm_ShowBanks.FundId);
                //    if (fund == null)
                //        return;
                //    txtRecivePlace.Text = string.Format("{0}{1}{2}", fund.FAccountnumber, Localize.Cheque_Fund_Seperator, fund.FBank);
                //}
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

                this.ClearForm();
                TreasuryDetailId = (grdTreasuryDetails.SelectedValue as dynamic).ID;
                var treasuryDetail = Business.GetTreasuryDetailBusiness().GetById(TreasuryDetailId);
                cmb_noe_daryaft.SelectedValue = treasuryDetail.TDType;
                if (treasuryDetail.TDType == Common.Constants.TreasuryDetailType.Cash)
                    txtCashDescription.Text = treasuryDetail.TDDescription;
                else
                    txtChequeDescription.Text = treasuryDetail.TDDescription;

                cmb_noe_daryaft_SelectionChanged();

                if (treasuryDetail.IDFund.HasValue)
                {
                    var fund = Business.GetFundsBusiness().GetById(treasuryDetail.IDFund.ToGUID());
                    txtRecivePlace.Text = string.Format("{0}{1}{2}", fund.FAccountnumber, Localize.Cheque_Fund_Seperator, fund.FName);
                    txtPrice.Text = fund.Fprice.ToString(Localize.DoubleMaskType);
                }
                else
                {
                    var cheque = Business.GetChequeBusiness().GetById(treasuryDetail.IDCheck.ToGUID());
                    var bank = Business.GetFundsBusiness().GetById(cheque.CBank.ToGUID());

                    txtNumCheque.Text = cheque.CNO;
                    txtBankName.Text = bank.FName;
                    txtBankBranchCode.Text = bank.Fbranch;
                    dtpChequeDate.Text = cheque.CDate;
                    txtChequePrice.Text = cheque.CPrice.ToString(Localize.DoubleMaskType);
                }

            }
            catch
            {

                throw;
            }
        }

        private void SetFundControl(Data.Check cheque)
        {
            try
            {
                var fund = Business.GetFundsBusiness().GetById(cheque.CBank.ToGUID());
                if (fund == null)
                    return;

                txtNumCheque.Text = string.Format("{0}{1}{2}", cheque.CNO, Localize.Cheque_Fund_Seperator, fund.FBank);
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

                    var treasuryDetail = Business.GetTreasuryDetailBusiness().GetById(TreasuryDetailId);
                    if (treasuryDetail == null)
                        treasuryDetail = new Data.TreasuryDetail()
                        {
                            IDTreasury = treasury.ID,
                            TDPrice = txtPrice.Text.ToDecimal()
                        };

                    if (cmb_noe_daryaft.SelectedValue.ToGUID() == Common.Constants.TreasuryDetailType.Cash)
                    {
                        treasuryDetail.IDCheck = null;
                        treasuryDetail.IDFund = FundId;
                        treasuryDetail.TDPrice = txtPrice.Text.ToDecimal();
                        treasuryDetail.TDDescription = txtCashDescription.Text;

                    }
                    else
                    {
                        treasuryDetail.IDCheck = SaveCheque(treasuryDetail);
                        treasuryDetail.IDFund = null;
                        treasuryDetail.TDPrice = txtChequePrice.Text.ToDecimal();
                        treasuryDetail.TDDescription = txtChequeDescription.Text;

                    }
                    treasuryDetail.TDType = cmb_noe_daryaft.SelectedValue.ToGUID();

                    Business.GetTreasuryDetailBusiness().Save(treasuryDetail);

                    scope.Complete();
                }

                ClearForm();

                SetDataGrid();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void ClearForm()
        {
            try
            {
                txtRecivePlace.Clear();
                txtPrice.Clear();
                txtCashDescription.Clear();
                txtNumCheque.Clear();
                txtBankName.Text = string.Empty;
                txtBankBranchCode.Text = string.Empty;
                txtChequePrice.Clear();
                txtChequeDescription.Clear();
            }
            catch 
            {
                
                throw;
            }
        }


        private Guid? SaveCheque(Data.TreasuryDetail treasuryDetail)
        {
            try
            {
                var cheque = Business.GetChequeBusiness().GetById(treasuryDetail.IDCheck.ToGUID());
                if (cheque == null)
                    cheque = new Data.Check();

                cheque.CNO = txtNumCheque.Text;
                cheque.CPrice = txtChequePrice.Text.ToDecimal();
                cheque.CDate = dtpChequeDate.Text;
                cheque.CBank = FundId;
                cheque.CType = Common.Constants.ChequeType.Recive;
                Business.GetChequeBusiness().Save(cheque);
                return cheque.ID;
            }
            catch
            {

                throw;
            }
        }

        private Data.Treasury SaveTreasury()
        {
            try
            {
                var treasury = new Data.Treasury();
                if (TreasuryId == Guid.Empty)
                {
                    treasury = new Data.Treasury()
                    {
                        TDate = DateTime.Now.ToPersian(),
                        TPrice = txtPrice.Text.ToDecimal()
                    };

                }
                else
                {
                    decimal oldPrice = 0;
                    if (TreasuryDetailId != Guid.Empty)
                        oldPrice = Business.GetTreasuryDetailBusiness().GetById(TreasuryDetailId).TDPrice.ToDecimal();

                    treasury = Business.GetTreasuryBusiness().GetById(TreasuryId);
                    treasury.TPrice += -oldPrice + txtPrice.Text.ToDecimal();
                }


                treasury.TNO = txtNo.Text;
                treasury.Ttype = Common.Constants.TreasuryType.Recive;
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
                SetDataGrid();
            }
            catch
            {

                throw;
            }
        }

        private void txtNo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {


            c.CheckIsNumeric(e);
        }

        private void txtCheque_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

            c.chequeSerial(e);
        }

        private void txtRecivePlace_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

            c.CheckIsNumeric(e);
        }

        private void txtPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.AddZero(sender, e);
            c.CheckIsAccountNumber(e);
        }

        private void txtTreasuryDescription_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.JustPersian(e);
        }

        private void Menu_Delete_Click(object sender, RoutedEventArgs e)
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
            c.SepratTextBox(sender, e);
        }


    }
}
