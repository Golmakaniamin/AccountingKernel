using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Common;
using System.Transactions;

namespace AccountingKernel.Forms.Interface
{
    /// <summary>
    /// Interaction logic for Document.xaml
    /// </summary>
    public partial class frmSaveInterfaces : Window
    {
        Class.UI.TextHandeler c = new Class.UI.TextHandeler();
        List<AccountingKernel.Forms.Document.frmB.LabelValues> debtorLabels = new List<Document.frmB.LabelValues>();
        List<AccountingKernel.Forms.Document.frmB.LabelValues> creditorLabels = new List<Document.frmB.LabelValues>();

        public frmSaveInterfaces()
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

        private void btnDebtorSelecting_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var fb = new Forms.Document.frmB(debtorLabels);
                fb.ShowDialog();

                debtorLabels = fb.Labels;
                txtDebtorCode.Text = fb.AccountingCode;

            }
            catch
            {

                throw;
            }

        }

        private void btnCreditorSelecting_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var fb = new Forms.Document.frmB(creditorLabels);
                fb.ShowDialog();

                creditorLabels = fb.Labels;
                txtCreditorCode.Text = fb.AccountingCode;

            }
            catch
            {

                throw;
            }
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var moeinDetailBusiness = Business.GetAccountingMoeinDetailBusiness();

                if (debtorLabels.Count < 3)
                    throw new Exception(Localize.ex_invalid_moein_debtor);

                var debtorGrouh = moeinDetailBusiness.GetByIdIn(debtorLabels[0].code, Common.Constants.CodeTitle.Goruh).Select(r => r.IdAccountingMoein);
                var debtorKol = debtorGrouh.Join(moeinDetailBusiness.GetByIdIn(debtorLabels[1].code, Common.Constants.CodeTitle.Kol).Select(r => r.IdAccountingMoein),
                    o => o, i => i, (o, i) => new { i }).Select(r => r.i);
                var debtorMoein = debtorKol.Join(moeinDetailBusiness.GetByIdIn(debtorLabels[2].code, Common.Constants.CodeTitle.Moein).Select(r => r.IdAccountingMoein),
                    o => o, i => i, (o, i) => new { i }).Select(r => r.i).FirstOrDefault();

                if (debtorMoein == null)
                    throw new Exception(Localize.ex_invalid_moein_debtor);

                if (creditorLabels.Count < 3)
                    throw new Exception(Localize.ex_invalid_moein_creditor);

                var creditorGrouh = moeinDetailBusiness.GetByIdIn(creditorLabels[0].code, Common.Constants.CodeTitle.Goruh).Select(r => r.IdAccountingMoein);
                var creditorKol = creditorGrouh.Join(moeinDetailBusiness.GetByIdIn(creditorLabels[1].code, Common.Constants.CodeTitle.Kol).Select(r => r.IdAccountingMoein),
                    o => o, i => i, (o, i) => new { i }).Select(r => r.i);
                var creditorMoein = creditorKol.Join(moeinDetailBusiness.GetByIdIn(creditorLabels[2].code, Common.Constants.CodeTitle.Moein).Select(r => r.IdAccountingMoein),
                    o => o, i => i, (o, i) => new { i }).Select(r => r.i).FirstOrDefault();

                if (debtorMoein == null)
                    throw new Exception(Localize.ex_invalid_moein_debtor);


                var accountingInterface = new Data.AccountingInterface()
                {
                    AIName = txtAIName.Text,
                    AIDebtor_IDAccountingMoein = debtorMoein,
                    AICreditor_IDAccountingMoein = creditorMoein
                };


                if (debtorLabels.Count > 3)
                {
                    Guid codeTitleId = Guid.Empty;
                    switch (debtorLabels.Count)
                    {
                        case 4:
                            codeTitleId = Common.Constants.CodeTitle.Tafsil1;
                            break;
                        case 5:
                            codeTitleId = Common.Constants.CodeTitle.Tafsil2;
                            break;
                        case 6:
                            codeTitleId = Common.Constants.CodeTitle.Tafsil3;
                            break;
                        default:
                            break;
                    }

                    var atld = Business.GetAccountingTafsilLevelDetailBusiness().GetByATLName(debtorLabels[debtorLabels.Count - 1].value, codeTitleId).FirstOrDefault();
                    if (atld == null)
                        throw new Exception(Localize.ex_invalid_moein_debtor);

                    accountingInterface.AIDebtor_IDAccountingMoeinTafsilLevels = Business.GetAccountingMoeinTafsilLevelBusiness().GetAll().
                                    Where(r => r.IdTafsilGroup == codeTitleId &&
                                           r.IdAccountingMoein == accountingInterface.AIDebtor_IDAccountingMoein &&
                                           r.IdAccountingTafsilLevels == atld.IdAccountingTafsilLevels).First().ID;




                }

                if (creditorLabels.Count > 3)
                {
                    Guid codeTitleId = Guid.Empty;
                    switch (creditorLabels.Count)
                    {
                        case 4:
                            codeTitleId = Common.Constants.CodeTitle.Tafsil1;
                            break;
                        case 5:
                            codeTitleId = Common.Constants.CodeTitle.Tafsil2;
                            break;
                        case 6:
                            codeTitleId = Common.Constants.CodeTitle.Tafsil3;
                            break;
                        default:
                            break;
                    }

                    var atld = Business.GetAccountingTafsilLevelDetailBusiness().GetByATLName(creditorLabels[creditorLabels.Count - 1].value, codeTitleId).FirstOrDefault();
                    if (atld == null)
                        throw new Exception(Localize.ex_invalid_moein_debtor);

                    accountingInterface.AIDebtor_IDAccountingMoeinTafsilLevels = Business.GetAccountingMoeinTafsilLevelBusiness().GetAll().
                                    Where(r => r.IdTafsilGroup == codeTitleId &&
                                           r.IdAccountingMoein == accountingInterface.AIDebtor_IDAccountingMoein &&
                                           r.IdAccountingTafsilLevels == atld.IdAccountingTafsilLevels).First().ID;
                }

                Business.GetAccountingInterfaceBusiness().Save(accountingInterface);

                this.Close();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void txtAIName_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            c.JustPersian(e);
        }




    }
}
