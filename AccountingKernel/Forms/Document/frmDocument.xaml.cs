using AccountingKernel.CLass;
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
using System.Data;
using System.Transactions;

namespace AccountingKernel.Forms.Document
{
    /// <summary>
    /// Interaction logic for Document.xaml
    /// </summary>
    public partial class frmDocument : Window
    {
        class DataGridRows
        {
            public Guid Id { set; get; }
            public string Count { set; get; }
            public string Debtor { set; get; }
            public string Creditor { set; get; }
            public string Description { set; get; }
            public string CodehaieHesabdari { set; get; } //گروه کل معین و حساب های تفصیلی
        }

        Class.UI.TextHandeler c = new Class.UI.TextHandeler();
        public Data.AccountingDocument Document;
        public Guid? AccountingArticleId;

        private List<frmB.LabelValues> FrmBLablels;
        private Common.Enum.FormMode formMode;

        public frmDocument()
        {
            try
            {
                NormalConstructor();
            }
            catch
            {

                throw;
            }

        }

        public frmDocument(Common.Enum.FormMode formMode, Data.AccountingDocument document)
        {
            try
            {
                NormalConstructor();

                this.formMode = formMode;
                this.Document = document;

                SetDataGrid();
                var articles = Business.GetAccountingArticleBusiness().GetByAccountingDcoumentId(Document.Id).ToList();

                txtArticleNo.Text = document.ADCode.ToInt().ToString(Localize.DoubleMaskType);
                cmbDocumentType.SelectedValue = document.ADType;

                SetDocumentInfo(document, articles);

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
                InitializeComponent();

                btnRegisterDocument.IsEnabled = false;

                txtArticleNo.Text = Business.GetAccountingDocumentBusiness().GetNextCode().ToString();

                cmbDocumentType.DataContext = Business.GetBaseInfoBusiness().GetByType(Constants.BaseInfoType.DocumentType).Select(r => new
                {
                    Id = r.Id,
                    Name = r.AssignName
                });

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
                if (Document == null)
                    return;

                var articles = Business.GetAccountingArticleBusiness().GetByAccountingDcoumentId(Document.Id);

                var dataGridRows = new List<DataGridRows>();

                foreach (var item in articles)
                {

                    var tafsils = Business.GetAccountingTafsilArticleBusiness().GetByAccountingArticleId(item.ID).ToList();

                    var moein = Business.GetAccountingMoeinBusiness().GetById(tafsils.First().IDAccountingMoein.Value);

                    var tafsilLevelDetails = Business.GetAccountingTafsilLevelDetailBusiness().GetByIds(tafsils.Where(r => r.IdAccountingTafsilLDetails.HasValue)
                        .Select(r => r.IdAccountingTafsilLDetails.Value).ToList()).ToList();

                    var dataGridRow = new DataGridRows()
                    {
                        Count = item.ACount.ToInt().ToString(),
                        Creditor = item.ACreditor.ToDecimal().ToString(Localize.DoubleMaskType),
                        Debtor = item.ADebtor.ToDecimal().ToString(Localize.DoubleMaskType),
                        Description = item.ADescription,
                        Id = item.ID
                    };

                    dataGridRow.CodehaieHesabdari = string.Format("{0},{1},{2}", moein.MIdGroup, moein.MIdAll, moein.MName);
                    foreach (var tafsilLevelDetail in tafsilLevelDetails)
                    {
                        dataGridRow.CodehaieHesabdari = string.Format("{0}, {1}", dataGridRow.CodehaieHesabdari, tafsilLevelDetail.ATLName);
                    }

                    dataGridRows.Add(dataGridRow);
                }

                DataGridTest.ItemsSource = dataGridRows;
            }
            catch
            {

                throw;
            }
        }

        private void DataGridTest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (DataGridTest.SelectedValue == null)
                {
                    AccountingArticleId = null;
                    return;
                }

                AccountingArticleId = (DataGridTest.SelectedValue as dynamic).Id;
                var accountingArticle = Business.GetAccountingArticleBusiness().GetById(AccountingArticleId.Value);

                txtCount.Text = accountingArticle.ACount.ToInt().ToString();
                txtDebtor.Text = accountingArticle.ADebtor.ToString(Localize.DoubleMaskType);
                txtCreditor.Text = accountingArticle.ACreditor.ToString(Localize.DoubleMaskType);
                txtDocument_Desc.Text = accountingArticle.ADescription;

                txtFormB.Text = (DataGridTest.SelectedValue as dynamic).CodehaieHesabdari;
                FrmBLablels = new List<frmB.LabelValues>();

                var accountingTafsilArticles = Business.GetAccountingTafsilArticleBusiness().GetByArticleId(accountingArticle.ID);
                var moeinId = accountingTafsilArticles.First().IDAccountingMoein;

                var moeinDetail = Business.GetAccountingMoeinDetailBusiness().GetByMoeinId(moeinId.Value).ToList();

                var atld = Business.GetAccountingTafsilLevelDetailBusiness().GetByKeys(accountingTafsilArticles.Select(r => r.IdAccountingTafsilLDetails.Value)).Join(
                    Business.GetAccountingMoeinTafsilLevelBusiness().GetAll(), i => i.IdAccountingTafsilLevels, o => o.IdAccountingTafsilLevels, (o, i) =>
                    new { atld = o, amtld = i }).Where(r => r.amtld.IdAccountingMoein == moeinId).ToList();

                var codeTitles = Business.GetCodeTitleBusiness().GetByCodeGroups(new List<int>() { 1, 2 }).OrderBy(r => r.CodePriority).ToList();

                var goruh = moeinDetail.First(r => r.IdCodeTitle == Common.Constants.CodeTitle.Goruh);
                FrmBLablels.Add(new frmB.LabelValues() { code = goruh.IdIn, codeTitle = Common.Constants.CodeTitle.Goruh, value = goruh.MDName });
                var kol = moeinDetail.First(r => r.IdCodeTitle == Common.Constants.CodeTitle.Kol);
                FrmBLablels.Add(new frmB.LabelValues() { code = kol.IdIn, codeTitle = Common.Constants.CodeTitle.Kol, value = kol.MDName });
                var moein = moeinDetail.First(r => r.IdCodeTitle == Common.Constants.CodeTitle.Moein);
                FrmBLablels.Add(new frmB.LabelValues() { code = moein.IdIn, codeTitle = Common.Constants.CodeTitle.Moein, value = moein.MDName });

                var taf1 = atld.FirstOrDefault(r => r.amtld.IdTafsilGroup == Constants.CodeTitle.Tafsil1);
                if (taf1 != null)
                    FrmBLablels.Add(new frmB.LabelValues() { code = taf1.atld.IdIn, codeTitle = Common.Constants.CodeTitle.Tafsil1, value = taf1.atld.ATLName });
                var taf2 = atld.FirstOrDefault(r => r.amtld.IdTafsilGroup == Common.Constants.CodeTitle.Tafsil2);
                if (taf2 != null)
                    FrmBLablels.Add(new frmB.LabelValues() { code = taf2.atld.IdIn, codeTitle = Common.Constants.CodeTitle.Tafsil2, value = taf2.atld.ATLName });
                var taf3 = atld.FirstOrDefault(r => r.amtld.IdTafsilGroup == Common.Constants.CodeTitle.Tafsil3);
                if (taf3 != null)
                    FrmBLablels.Add(new frmB.LabelValues() { code = taf3.atld.IdIn, codeTitle = Common.Constants.CodeTitle.Tafsil3, value = taf3.atld.ATLName });
            }
            catch
            {

                throw;
            }
        }

        private void btnRegisterDocument_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Document.AIdStatus = Common.Constants.DocumentStatus.TemporaryApproved;
                Document.ADDescription = txtDocument_Desc.Text;
                Business.GetAccountingDocumentBusiness().Save(Document);

                this.Close();
            }
            catch
            {

                throw;
            }
        }

        private void txtDebtor_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                c.SepratTextBox(sender, e);
                
                txtCreditor.IsEnabled = txtDebtor.Text.ToDouble() == 0;

                if (txtDebtor.Text.ToDouble() != 0)
                    txtCreditor.Text = string.Empty;
            }
            catch
            {

                throw;
            }
        }

        private void txtCreditor_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {

                c.SepratTextBox(sender, e);
                txtDebtor.IsEnabled = txtCreditor.Text.ToDouble() == 0;

                if (txtCreditor.Text.ToDouble() != 0)
                    txtDebtor.Text = string.Empty;
            }
            catch
            {

                throw;
            }
        }

        private void btnShowFormB_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var fb = new frmB(FrmBLablels);
                fb.ShowDialog();

                FrmBLablels = fb.Labels;
                txtFormB.Text = fb.AccountingCode;

            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void TxtResults_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                TxtDiff.Text = (TxtTotalCreditor.Text.ToDouble() - TxtTotalDebtor.Text.ToDouble()).ToString(Localize.DoubleMaskType);
                BtnRegisterEnabling();
                c.SepratTextBox(sender, e);
               
            }
            catch
            {

                throw;
            }
        }

        private void BtnRegisterEnabling()
        {
            try
            {
                btnRegisterDocument.IsEnabled = TxtTotalCreditor.Text == TxtTotalDebtor.Text;
            }
            catch
            {

                throw;
            }
        }

        private void Register()
        {
            try
            {
                var accountingDocumentBusiness = Business.GetAccountingDocumentBusiness();
                var accountingArticleBusiness = Business.GetAccountingArticleBusiness();
                var accountingArticle = new Data.AccountingArticle();
                if (AccountingArticleId.HasValue)
                    accountingArticle = accountingArticleBusiness.GetById(AccountingArticleId.Value);

                using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
                {
                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted,
                    Timeout = new TimeSpan(2, 0, 0)
                }))
                {
                    if (Document == null)
                    {
                        Document = new Data.AccountingDocument()
                        {
                            ADDate = dtpDate.Text,
                            ADDescription = txtArticleDescription.Text,
                            ADCode = txtArticleNo.Text.ToNullableInt(),
                            ADOldCode = txtArticleOldNo.Text,
                            ADType = cmbDocumentType.SelectedValue.ToGUID(),
                            AIdStatus = Common.Constants.DocumentStatus.Draft,
                            AISDeleted = false
                        };

                        accountingDocumentBusiness.Save(Document);
                    }
                    else
                    {
                        Document.ADDate = dtpDate.Text;
                        Document.ADDescription = txtDocument_Desc.Text;
                        Document.ADCode = txtArticleNo.Text.ToNullableInt();
                        Document.ADOldCode = txtArticleOldNo.Text;
                        Document.ADType = cmbDocumentType.SelectedValue.ToGUID();
                        accountingDocumentBusiness.Save(Document);
                    }

                    if (txtCount.Text != string.Empty)
                    {
                        accountingArticle.IDAccountingDocument = Document.Id;
                        accountingArticle.ADescription = txtArticleDescription.Text;
                        accountingArticle.ADebtor = txtDebtor.Text.ToNullableDecimal();
                        accountingArticle.ACreditor = txtCreditor.Text.ToNullableDecimal();
                        accountingArticle.ACount = txtCount.Text.ToNullableInt();
                        accountingArticleBusiness.Save(accountingArticle);
                    }


                    var accountingTafsilArticleBusiness = Business.GetAccountingTafsilArticleBusiness();

                    accountingTafsilArticleBusiness.Delete(accountingTafsilArticleBusiness.GetByAccountingArticleId(accountingArticle.ID).ToList());



                    ////
                    var tCode = FrmBLablels[0].code + FrmBLablels[1].code + FrmBLablels[2].code;

                    var accountingMoein = Business.GetAccountingMoeinBusiness().GetByMIdMoein(tCode);

                    var ata = new List<Data.AccountingTafsilArticle>();

                    if (FrmBLablels.Count <= 3)
                    {
                        ata.Add(new Data.AccountingTafsilArticle()
                        {
                            IDAccountingMoein = accountingMoein.Id,
                            IDAccountingMoeinTafsilLevels = null,
                            IdAccountingTafsilLDetails = null,
                            IdAccountingArticle = accountingArticle.ID,
                        });
                    }

                    for (int i = 4; i <= FrmBLablels.Count; i++)
                    {
                        var satheTafsil = Common.Constants.CodeTitle.Tafsil1;
                        switch (i)
                        {
                            case 5:
                                satheTafsil = Common.Constants.CodeTitle.Tafsil2;
                                break;
                            case 6:
                                satheTafsil = Common.Constants.CodeTitle.Tafsil3;
                                break;
                            default:
                                break;
                        }


                        var accountingTafsillevelsDetailCode = FrmBLablels[i].code;
                        var accountingMoeinTafsilLevels = Business.GetAccountingMoeinTafsilLevelBusiness().GetByIdAccountingMoein(accountingMoein.Id, satheTafsil);

                        var accountingTafsillevelsDetails = Business.GetAccountingTafsilLevelDetailBusiness().GetHesabTafsilByAccountingTafsilLevelsId(
                            accountingMoeinTafsilLevels.Select(r => r.IdAccountingTafsilLevels.Value).ToList())
                            .Where(r => r.IdIn == accountingTafsillevelsDetailCode).First();


                        ata.Add(new Data.AccountingTafsilArticle()
                        {
                            IDAccountingMoein = accountingMoein.Id,
                            IDAccountingMoeinTafsilLevels = accountingMoeinTafsilLevels.First().ID,
                            IdAccountingTafsilLDetails = accountingTafsillevelsDetails.Id,
                            IdAccountingArticle = accountingArticle.ID,
                        });

                    }
                    accountingTafsilArticleBusiness.Save(ata);


                    scope.Complete();
                }

                SetDataGrid();

                SetDocumentInfo(Document, accountingArticleBusiness.GetByAccountingDcoumentId(Document.Id).ToList());

                txtCount.Clear();
                txtDebtor.Clear();
                txtCreditor.Clear();
            }
            catch
            {

                throw;
            }
        }

        private void MenuItem_DeleteClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (DataGridTest.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);

                var accountingArticleBusiness = Business.GetAccountingArticleBusiness();

                Guid atlid = (DataGridTest.SelectedValue as dynamic).Id;

                var accountingArticle = accountingArticleBusiness.GetById(atlid);
                var document = Business.GetAccountingDocumentBusiness().GetById(accountingArticle.IDAccountingDocument.Value);


                using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
                {
                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted,
                    Timeout = new TimeSpan(2, 0, 0)
                }))
                {
                    accountingArticleBusiness.Delete(accountingArticle);
                    document.AIdStatus = Common.Constants.DocumentStatus.Draft;
                    Business.GetAccountingDocumentBusiness().SubmitChanges();


                    scope.Complete();
                }

                SetDataGrid();
                SetDocumentInfo(document, accountingArticleBusiness.GetByAccountingDcoumentId(document.Id).ToList());
            }
            catch
            {

                throw;
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Register();

            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void SetDocumentInfo(Data.AccountingDocument document, List<Data.AccountingArticle> articles)
        {
            try
            {

                TxtTotalDebtor.Text = articles.FindAll(r => r.ADebtor.HasValue).Sum(r => r.ADebtor.Value).ToString(Localize.DoubleMaskType);
                TxtTotalCreditor.Text = articles.FindAll(r => r.ACreditor.HasValue).Sum(r => r.ACreditor.Value).ToString(Localize.DoubleMaskType);
                TxtDiff.Text = (TxtTotalCreditor.Text.ToDouble() - TxtTotalDebtor.Text.ToDouble()).ToString(Localize.DoubleMaskType);
                txtDocument_Desc.Text = document.ADDescription;
                txtArticleNo.Text = document.ADCode.HasValue ? document.ADCode.Value.ToString() : string.Empty;
                txtArticleOldNo.Text = document.ADOldCode;
                cmbDocumentType.SelectedValue = document.ADType;

                BtnRegisterEnabling();

            }
            catch
            {

                throw;
            }
        }

        private void txtArticleNo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

            c.CheckIsNumeric(e);
        }

        private void txtArticleDescription_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.JustPersian(e);
        }

        private void txtDocument_Desc_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.JustPersian(e);
        }

        private void TxtTotalDebtor_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
            c.AddZero(sender, e);
        }

        private void TxtTotalCreditor_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
            c.AddZero(sender, e);
        }

        private void TxtDiff_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
            c.AddZero(sender, e);
        }

        private void txtCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            c.SepratTextBox(sender, e);
        }

        private void TxtDiff_TextChanged(object sender, TextChangedEventArgs e)
        {
            c.SepratTextBox(sender, e);
        }

        private void txtArticleOldNo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }

        private void txtDebtor_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
            c.AddZero(sender, e);
        }

        private void txtCreditor_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
            c.AddZero(sender, e);
        }

        private void txtCount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }

    }
}
