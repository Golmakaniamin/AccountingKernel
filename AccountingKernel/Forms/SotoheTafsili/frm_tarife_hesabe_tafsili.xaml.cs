using Data;
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

namespace AccountingKernel.Forms.SotoheTafsili
{
    /// <summary>
    /// Interaction logic for frm_tarife_hesabe_tafsili.xaml
    /// </summary>
    /// 



    public partial class frm_tarife_hesabe_tafsili : Window
    {
        Class.UI.TextHandeler c = new Class.UI.TextHandeler();
        private Guid? atldId;
        private Guid? atlId;

        public frm_tarife_hesabe_tafsili()
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

        private void NormalConstructor()
        {
            try
            {
                InitializeComponent();
                addSuggestionToTextBoxHesab();
                addSuggestionToTextBoxTafsil();

            }
            catch
            {

                throw;
            }
        }

        public frm_tarife_hesabe_tafsili(Guid atldId)
        {
            try
            {
                NormalConstructor();
                this.atldId = atldId;


                var atldBusiness = Business.GetAccountingTafsilLevelDetailBusiness();


                var atld = atldBusiness.GetById(atldId);
                var atlds = atldBusiness.GetByIdAccountingTafsilLevels(atld.IdAccountingTafsilLevels).ToList();
                txt_grouh_tafsili.Text = atlds.First(r => r.IdCodeTitle == Common.Constants.CodeTitle.GoruheTafsili).ATLName;
                txt_grouh_eng_name.Text = atlds.First(r => r.IdCodeTitle == Common.Constants.CodeTitle.GoruheTafsili).ATLNameEn;
                txt_grouh_code.Text = atlds.First(r => r.IdCodeTitle == Common.Constants.CodeTitle.GoruheTafsili).IdIn;

                txt_onvane_hesab1.Text = atlds.First(r => r.IdCodeTitle == Common.Constants.CodeTitle.HesabTafsil).ATLName;
                txt_hesab_eng_name.Text = atlds.First(r => r.IdCodeTitle == Common.Constants.CodeTitle.HesabTafsil).ATLNameEn;
                txt_hesab_code.Text = atlds.First(r => r.IdCodeTitle == Common.Constants.CodeTitle.HesabTafsil).IdIn;

                this.atlId = atld.IdAccountingTafsilLevels.Value;
            }
            catch
            {

                throw;
            }
        }

        private void txt_grouh_tafsili_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txt_grouh_tafsili.Text == "" || txt_onvane_hesab1.Text == "")
                    throw new Exception(Localize.ex_all_item_mandatory);

                var atldBusiness = Business.GetAccountingTafsilLevelDetailBusiness();
                var atlBusiness = Business.GetAccountingTafsilLevelBusiness();
                var goldIdin = string.Empty;
                var holdIdin = string.Empty;

                using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
                {
                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted,
                    Timeout = new TimeSpan(2, 0, 0)
                }))
                {

                    var atl = new Data.AccountingTafsilLevel();

                    if (!this.atlId.HasValue || this.atlId == Guid.Empty)
                    {
                        atlBusiness.Save(atl);
                        atlId = atl.Id;
                    }
                    else
                        atl = atlBusiness.GetById(this.atlId.Value);
                    var atlds = atldBusiness.GetByIdAccountingTafsilLevels(this.atlId.ToGUID()).ToList();

                    #region Goruh

                    var goruh = atlds.FirstOrDefault(r => r.IdCodeTitle == Common.Constants.CodeTitle.GoruheTafsili);

                    if (goruh == null)
                        goruh = new Data.AccountingTafsillevelsDetail()
                        {
                            IdAccountingTafsilLevels = atlId,
                            IdCodeTitle = Common.Constants.CodeTitle.GoruheTafsili
                        };
                    else
                        goldIdin = goruh.IdIn;

                    PrepareGroup(goruh);

                    atldBusiness.Save(goruh);

                    #endregion

                    #region Hesab

                    var hesab = atlds.FirstOrDefault(r => r.IdCodeTitle == Common.Constants.CodeTitle.HesabTafsil);

                    if (hesab == null)
                        hesab = new Data.AccountingTafsillevelsDetail()
                        {
                            IdAccountingTafsilLevels = atlId,
                            IdCodeTitle = Common.Constants.CodeTitle.HesabTafsil
                        };
                    else
                        holdIdin = hesab.IdIn;

                    PrepareHesab(hesab);

                    atldBusiness.Save(hesab);

                    #endregion

                    #region Update Other Groups

                    var otherGroups = atldBusiness.GetByIdIn(goruh.IdIn, Common.Constants.CodeTitle.GoruheTafsili).Where(r => r.Id != goruh.Id).ToList();
                    foreach (var item in otherGroups)
                    {
                        PrepareGroup(item);
                        atldBusiness.Save(item);
                    }

                    var otherHesabs = atldBusiness.GetByIdIn(hesab.IdIn, Common.Constants.CodeTitle.HesabTafsil).Where(r => r.Id != hesab.Id).ToList();
                    foreach (var item in otherHesabs)
                    {
                        PrepareHesab(item);
                        atldBusiness.Save(item);
                    }

                    #endregion

                    #region Accounting Tafsil Level

                    atl.IdIn = goruh.IdIn + hesab.IdIn;
                    atlBusiness.Save(atl);

                    var atls = atlBusiness.GetIdInStartWith(goruh.IdIn).ToList();
                    foreach (var item in atls)
                    {
                        item.IdIn = goruh.IdIn + item.IdIn.Remove(0, goruh.IdIn.Length);
                        atlBusiness.Save(item);
                    }

                    #endregion

                    scope.Complete();
                }

                this.Close();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void PrepareHesab(AccountingTafsillevelsDetail hesab)
        {
            try
            {
                hesab.IdIn = txt_hesab_code.Text;
                hesab.ATLName = txt_onvane_hesab1.Text;
                hesab.ATLNameEn = txt_hesab_eng_name.Text;

            }
            catch
            {

                throw;
            }
        }

        private void PrepareGroup(AccountingTafsillevelsDetail goruh)
        {
            try
            {
                goruh.IdIn = txt_grouh_code.Text;
                goruh.ATLName = txt_grouh_tafsili.Text;
                goruh.ATLNameEn = txt_grouh_eng_name.Text;
            }
            catch
            {

                throw;
            }
        }

        private void addSuggestionToTextBoxHesab()
        {
            try
            {
                var get_all_from_tafsil_level_detail = Business.GetAccountingTafsilLevelDetailBusiness().GetByIdCodeTitle(Common.Constants.CodeTitle.GoruheTafsili).ToList();

                foreach (var item in get_all_from_tafsil_level_detail)
                    txt_grouh_tafsili.AddItem(new WPFAutoCompleteTextbox.AutoCompleteEntry(item.ATLName, item.ATLName));
            }
            catch
            {

                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private void addSuggestionToTextBoxTafsil()
        {
            try
            {
                var get_all_from_tafsil_level_detail = Business.GetAccountingTafsilLevelDetailBusiness().GetByIdCodeTitle(Common.Constants.CodeTitle.HesabTafsil).ToList();

                foreach (var item in get_all_from_tafsil_level_detail)
                {
                    txt_onvane_hesab1.AddItem(new WPFAutoCompleteTextbox.AutoCompleteEntry(item.ATLName, item.ATLName));
                }

            }
            catch
            {

                throw;
            }
        }

        private void txt_grouh_tafsili_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
           
                c.JustPersian(e);
        }

        private void txt_grouh_tafsili_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                var atld = Business.GetAccountingTafsilLevelDetailBusiness().GetByATLName(txt_grouh_tafsili.Text, Common.Constants.CodeTitle.GoruheTafsili).FirstOrDefault();
                if (atld == null)
                    txt_grouh_code.Text = Business.GetAccountingTafsilLevelDetailBusiness().GetNewCodeForGroup(Common.Constants.CodeTitle.GoruheTafsili);
                else
                    txt_grouh_code.Text = atld.IdIn;
            }
            catch (Exception ex)
            {

                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);

            }
        }

        private void txt_onvane_hesab1_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                var group = Business.GetAccountingTafsilLevelDetailBusiness().GetByATLName(txt_grouh_tafsili.Text, Common.Constants.CodeTitle.GoruheTafsili).FirstOrDefault();

                var atld = Business.GetAccountingTafsilLevelDetailBusiness().GetByATLName(txt_onvane_hesab1.Text, Common.Constants.CodeTitle.HesabTafsil).FirstOrDefault();
                if (atld == null)
                    txt_hesab_code.Text = Business.GetAccountingTafsilLevelDetailBusiness().GetNewCodeForHesab(Common.Constants.CodeTitle.HesabTafsil, group);
                else
                    txt_hesab_code.Text = atld.IdIn;
            }
            catch (Exception ex)
            {

                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);

            }
        }

        private void txt_grouh_eng_name_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.JustEnglish(e);
        }

        private void txt_hesab_eng_name_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.JustEnglish(e);
        }

        private void txt_grouh_code_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }

        private void txt_hesab_code_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }

        private void txt_onvane_hesab1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.JustPersian(e);
        }




    }
}
