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

namespace AccountingKernel.Forms.Document
{
    /// <summary>
    /// Interaction logic for Document.xaml
    /// </summary>
    public partial class Document : Window
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

        #region fields...
        private List<MoeinTafsilChoose.LabelValues> FrmBLablels;
        public Guid? AccountingArticleId;
        private Common.Enum.FormMode formMode;
        private Class.UI.TextHandeler c = new Class.UI.TextHandeler();
        public Data.AccountingDocument xDocument;
        #endregion

        #region constructors...
        public Document()
        {
            InitializeComponent();
            Normalization();
        }

        public Document(Common.Enum.FormMode formMode, Data.AccountingDocument document)
        {
            try
            {
                Normalization();

                this.formMode = formMode;
                this.xDocument = document;

                SetDataGrid();
                var articles = Business.GetAccountingArticleBusiness().GetByAccountingDcoumentId(xDocument.Id).ToList();

                txtArticleNo.Text = document.ADCode.ToInt().ToString(Localize.DoubleMaskType);
                cmbDocumentType.SelectedValue = document.ADType;

                SetDocumentInfo(document, articles);

            }
            catch
            {

                throw;
            }
        }
        #endregion

        #region methods...
        private void Normalization()
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

        private void SetDataGrid()
        {
            try
            {
                if (xDocument == null)
                    return;

                var articles = Business.GetAccountingArticleBusiness().GetByAccountingDcoumentId(xDocument.Id);

                var dataGridRows = new List<DataGridRows>();

                foreach (var item in articles)
                {

                    var tafsils = Business.GetAccountingTafsilArticleBusiness().GetByAccountingArticleId(item.ID).ToList();

                    var moein = Business.GetMoeinStructureDefineBusiness().GetByID(tafsils.First().IDAccountingMoein.Value);

                    var dataGridRow = new DataGridRows()
                    {
                        Count = item.ACount.ToInt().ToString(),
                        Creditor = item.ACreditor.ToDecimal().ToString(Localize.DoubleMaskType),
                        Debtor = item.ADebtor.ToDecimal().ToString(Localize.DoubleMaskType),
                        Description = item.ADescription,
                        Id = item.ID
                    };

                    //TO DO: ali younesi enable this section

                    foreach (var labelItem in FrmBLablels)
                    {
                        dataGridRow.CodehaieHesabdari += labelItem.value;
                    }

                    //foreach (var tafsilLevelDetail in tafsilLevelDetails)
                    //{
                    //    dataGridRow.CodehaieHesabdari = string.Format("{0}, {1}", dataGridRow.CodehaieHesabdari, tafsilLevelDetail.ATLName);
                    //}
                    dataGridRows.Add(dataGridRow);
                }

                DataGridTest.ItemsSource = dataGridRows;
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
                    if (xDocument == null)
                    {
                        xDocument = new Data.AccountingDocument()
                        {
                            ADDate = dtpDate.Text,
                            ADDescription = txtArticleDescription.Text,
                            ADCode = txtArticleNo.Text.ToNullableInt(),
                            ADOldCode = txtArticleOldNo.Text,
                            ADType = cmbDocumentType.SelectedValue.ToGUID(),
                            AIdStatus = Common.Constants.DocumentStatus.Draft,
                            AISDeleted = false
                        };

                        accountingDocumentBusiness.Save(xDocument);
                    }
                    else
                    {
                        xDocument.ADDate = dtpDate.Text;
                        xDocument.ADDescription = txtDocument_Desc.Text;
                        xDocument.ADCode = txtArticleNo.Text.ToNullableInt();
                        xDocument.ADOldCode = txtArticleOldNo.Text;
                        xDocument.ADType = cmbDocumentType.SelectedValue.ToGUID();
                        accountingDocumentBusiness.Save(xDocument);
                    }

                    if (string.IsNullOrEmpty(txtCount.Text) == false)
                    {
                        accountingArticle.IDAccountingDocument = xDocument.Id;
                        accountingArticle.ADescription = txtArticleDescription.Text;
                        accountingArticle.ADebtor = txtDebtor.Text.ToNullableDecimal();
                        accountingArticle.ACreditor = txtCreditor.Text.ToNullableDecimal();
                        accountingArticle.ACount = txtCount.Text.ToNullableInt();
                        accountingArticleBusiness.Save(accountingArticle);
                    }


                    var accountingTafsilArticleBusiness = Business.GetAccountingTafsilArticleBusiness();

                    accountingTafsilArticleBusiness.Delete(accountingTafsilArticleBusiness.GetByAccountingArticleId(accountingArticle.ID).ToList());



                    ////
                    var tCode = FrmBLablels[2].code;

                    //changed by ali youensi
                    //var accountingMoein = Business.GetAccountingMoeinBusiness().GetByMIdMoein(tCode);
                    var accountingMoein = Business.GetMoeinStructureDefineBusiness().GetByCode(tCode);


                    var ata = new List<Data.AccountingTafsilArticle>();

                    if (FrmBLablels.Count <= 3)
                    {
                        ata.Add(new Data.AccountingTafsilArticle()
                        {
                            IDAccountingMoein = accountingMoein.ID,
                            IdAccountingArticle = accountingArticle.ID,
                            IDAccountingTafsilStructureDefine = null
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
                        ata.Add(new Data.AccountingTafsilArticle()
                        {
                            IDAccountingMoein = accountingMoein.ID,
                            IdAccountingArticle = accountingArticle.ID,
                            IDAccountingTafsilStructureDefine = satheTafsil
                        });

                    }
                    accountingTafsilArticleBusiness.Save(ata);


                    scope.Complete();
                }

                SetDataGrid();

                SetDocumentInfo(xDocument, accountingArticleBusiness.GetByAccountingDcoumentId(xDocument.Id).ToList());

                txtCount.Clear();
                txtDebtor.Clear();
                txtCreditor.Clear();
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

        private void CheckIsNumericAndAddZero(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
            c.AddZero(sender, e);
        }

        private void SepratTextBox(object sender, TextChangedEventArgs e)
        {
            c.SepratTextBox(sender, e);
        }

        private void CheckIsNumeric(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }

        private void JustPersian(object sender, TextCompositionEventArgs e)
        {
            c.JustPersian(e);
        }
        #endregion

        #region events...
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
                FrmBLablels = new List<MoeinTafsilChoose.LabelValues>();

                var accountingTafsilArticles = Business.GetAccountingTafsilArticleBusiness().GetByArticleId(accountingArticle.ID);
                var moeinId = accountingTafsilArticles.First().IDAccountingMoein;

                var moeinDetail = Business.GetAccountingMoeinDetailBusiness().GetByMoeinId(moeinId.Value).ToList();

                var atld = Business.GetAccountingTafsilLevelDetailBusiness().GetByKeys(accountingTafsilArticles.Select(r => r.IdAccountingTafsilLDetails.Value)).Join(
                    Business.GetAccountingMoeinTafsilLevelBusiness().GetAll(), i => i.IdAccountingTafsilLevels, o => o.IdAccountingTafsilLevels, (o, i) =>
                    new { atld = o, amtld = i }).Where(r => r.amtld.IdAccountingMoein == moeinId).ToList();

                var codeTitles = Business.GetCodeTitleBusiness().GetByCodeGroups(new List<int>() { 1, 2 }).OrderBy(r => r.CodePriority).ToList();

                var goruh = moeinDetail.First(r => r.IdCodeTitle == Common.Constants.CodeTitle.Goruh);
                FrmBLablels.Add(new MoeinTafsilChoose.LabelValues() { code = goruh.IdIn, codeTitle = Common.Constants.CodeTitle.Goruh, value = goruh.MDName });
                var kol = moeinDetail.First(r => r.IdCodeTitle == Common.Constants.CodeTitle.Kol);
                FrmBLablels.Add(new MoeinTafsilChoose.LabelValues() { code = kol.IdIn, codeTitle = Common.Constants.CodeTitle.Kol, value = kol.MDName });
                var moein = moeinDetail.First(r => r.IdCodeTitle == Common.Constants.CodeTitle.Moein);
                FrmBLablels.Add(new MoeinTafsilChoose.LabelValues() { code = moein.IdIn, codeTitle = Common.Constants.CodeTitle.Moein, value = moein.MDName });

                var taf1 = atld.FirstOrDefault(r => r.amtld.IdTafsilGroup == Constants.CodeTitle.Tafsil1);
                if (taf1 != null)
                    FrmBLablels.Add(new MoeinTafsilChoose.LabelValues() { code = taf1.atld.IdIn, codeTitle = Common.Constants.CodeTitle.Tafsil1, value = taf1.atld.ATLName });
                var taf2 = atld.FirstOrDefault(r => r.amtld.IdTafsilGroup == Common.Constants.CodeTitle.Tafsil2);
                if (taf2 != null)
                    FrmBLablels.Add(new MoeinTafsilChoose.LabelValues() { code = taf2.atld.IdIn, codeTitle = Common.Constants.CodeTitle.Tafsil2, value = taf2.atld.ATLName });
                var taf3 = atld.FirstOrDefault(r => r.amtld.IdTafsilGroup == Common.Constants.CodeTitle.Tafsil3);
                if (taf3 != null)
                    FrmBLablels.Add(new MoeinTafsilChoose.LabelValues() { code = taf3.atld.IdIn, codeTitle = Common.Constants.CodeTitle.Tafsil3, value = taf3.atld.ATLName });
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
                var fb = new MoeinTafsilChoose();
                fb.ShowDialog();

                FrmBLablels = fb.LabelList;
                txtFormB.Text = fb.AccountingName;
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
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

        private void btnRegisterDocument_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                xDocument.AIdStatus = Common.Constants.DocumentStatus.TemporaryApproved;
                xDocument.ADDescription = txtDocument_Desc.Text;
                Business.GetAccountingDocumentBusiness().Save(xDocument);

                this.Close();
            }
            catch
            {

                throw;
            }
        }
        #endregion
    }
}
