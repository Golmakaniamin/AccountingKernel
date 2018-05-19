using AccountingKernel;
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
using System.Transactions;

namespace AccountingKernel.Forms.MmoienCode
{
    /// <summary>
    /// Interaction logic for dlg_detail.xaml
    /// </summary>
    public partial class dlg_detail : Window
    {
        Class.UI.TextHandeler c = new Class.UI.TextHandeler();
        AccountingKernelEntities10 ak1 = new AccountingKernelEntities10();

        public dlg_detail()
        {
            try
            {
                InitializeComponent();

                PageLoad();

            }
            catch
            {

                throw;
            }
        }

        private void PageLoad()
        {
            try
            {
                addSuggestionToTextBoxGrouh();
                addSuggestionToTextBoxKol();
                RegDataTo_cmb_NoeMoien();
            }
            catch
            {

                throw;
            }
        }

        public dlg_detail(Guid AccountingMoeinId)
        {
            try
            {
                InitializeComponent();
                PageLoad();

                this.AccountingMoeinId = AccountingMoeinId;
                PrepareControls();
            }
            catch
            {

                throw;
            }
        }

        private void PrepareControls()
        {
            try
            {
                var accountingMoein = Business.GetAccountingMoeinBusiness().GetById(AccountingMoeinId.Value);
                var accountingMoeinDetailBusiness = Business.GetAccountingMoeinDetailBusiness();
                var group = accountingMoeinDetailBusiness.GetByAccountingMoeinDetailId(AccountingMoeinId, Common.Constants.CodeTitle.Goruh).First();
                var kol = accountingMoeinDetailBusiness.GetByAccountingMoeinDetailId(AccountingMoeinId, Common.Constants.CodeTitle.Kol).First();
                var moein = accountingMoeinDetailBusiness.GetByAccountingMoeinDetailId(AccountingMoeinId, Common.Constants.CodeTitle.Moein).First();

                txt_group.Text = group.MDName;
                txt_name_latin_grouh.Text = group.MDNameEn;
                txt_grouhCode.Text = group.IdIn;

                txt_all.Text = kol.MDName;
                txt_name_latin_kol.Text = kol.MDNameEn;
                txt_kol_code.Text = kol.IdIn;

                txt_moien.Text = moein.MDName;
                txt_name_latin_moien.Text = moein.MDNameEn;
                txt_moien_code.Text = moein.IdIn;

                txt_mahiteMoien.Text = accountingMoein.MMoein;
                cmb_noeMoien.SelectedValue = accountingMoein.MMoienType;
            }
            catch
            {

                throw;
            }
        }

        string str_get_idin_kols_for_current_grouh = "";

        public Guid? AccountingMoeinId;
        string idIN_kol_for_check = "";
        string idIN_moien_for_check = "";

        private void btn_AddToDb_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txt_all.Text.Trim() == "" || txt_group.Text.Trim() == "" || txt_moien.Text.Trim() == "" || cmb_noeMoien.SelectedIndex == -1 || txt_mahiteMoien.Text == "") // تمام موارد ضروری میباشد
                    throw new Exception(Localize.ex_moein_no_correct_data);

                var codeTitles = Business.GetCodeTitleBusiness().GetAll().ToList();

                var groupCodeTitle = codeTitles.Find(r => r.Id == Common.Constants.CodeTitle.Goruh);
                var kolCodeTitle = codeTitles.Find(r => r.Id == Common.Constants.CodeTitle.Kol);
                var moeinCodeTitle = codeTitles.Find(r => r.Id == Common.Constants.CodeTitle.Moein);

                using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
                {
                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted,
                    Timeout = new TimeSpan(2, 0, 0)
                }))
                {
                    SaveAccountingMoein();

                    SaveGroup();
                    SaveKol();
                    SaveMoein();

                    scope.Complete();

                }

                MessageBox.Show("اطلاعات با موفقیت ثبت شد", "ثبت اطلاعات", MessageBoxButton.OK, MessageBoxImage.Information);

                if (MessageBox.Show("آیا مایل به تعیین سطوح تفصیلی میباشید ", "ثبت", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {

                    AccountingKernel.Class.Variable.Variables.idAccountingMoien = AccountingMoeinId.ToString();
                    new Forms.SotoheTafsili.frm_taien_sotohe_tafsili().ShowDialog();
                }

                this.Close();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }

        }

        private void SaveAccountingMoein()
        {
            try
            {
                var accountingMoeinBusiness = Business.GetAccountingMoeinBusiness();
                var entities = new List<AccountingMoein>();

                var am = accountingMoeinBusiness.GetById(AccountingMoeinId.ToGUID());
                if (am == null)
                    am = new AccountingMoein();

                am.MIdMoein = txt_grouhCode.Text + txt_kol_code.Text + txt_moien_code.Text;
                am.MName = txt_moien.Text;
                am.MIdGroup = txt_group.Text;
                am.MIdAll = txt_all.Text;
                am.MGrouhF = txt_name_latin_grouh.Text;
                am.MFALLName = txt_name_latin_kol.Text;
                am.MFName = txt_name_latin_moien.Text;
                am.MMoein = txt_mahiteMoien.Text;
                am.MMoienType = cmb_noeMoien.SelectedValue.ToGUID();

                accountingMoeinBusiness.Save(am);

                // update groups in accountingmoein by group
                var groups = accountingMoeinBusiness.GetByStartWithMIdMoein(txt_grouhCode.Text).ToList();
                groups.ForEach(r =>
                {
                    r.MName = txt_group.Text;
                    r.MFName = txt_name_latin_grouh.Text;
                    r.MIdMoein = txt_grouhCode.Text + r.MIdMoein.Remove(0, txt_grouhCode.Text.Length);
                });
                entities.AddRange(groups);

                // update kol in accountingmoein by kol
                var kolCode = txt_grouhCode.Text + txt_kol_code.Text;
                var kols = accountingMoeinBusiness.GetByStartWithMIdMoein(kolCode).ToList();
                kols.ForEach(r =>
                {
                    r.MName = txt_all.Text;
                    r.MFName = txt_name_latin_kol.Text;
                    r.MIdMoein = kolCode + r.MIdMoein.Remove(0, kolCode.Length);
                });
                entities.AddRange(kols);

                // update moeins in accountingmoein by moein
                var moeinCode = txt_grouhCode.Text + txt_kol_code.Text + txt_moien_code.Text;
                var moeins = accountingMoeinBusiness.GetByStartWithMIdMoein(moeinCode).ToList();
                moeins.ForEach(r =>
                {
                    r.MName = txt_moien.Text;
                    r.MFName = txt_name_latin_moien.Text;
                    r.MIdMoein = moeinCode + r.MIdMoein.Remove(0, moeinCode.Length);
                });
                entities.AddRange(moeins);

                accountingMoeinBusiness.Save(entities);

                AccountingMoeinId = am.Id;
            }
            catch
            {

                throw;
            }
        }

        private Data.AccountingMoeinDetail SaveGroup()
        {
            try
            {
                var accountingMoeinDetailBusiness = Business.GetAccountingMoeinDetailBusiness();
                var groups = new List<Data.AccountingMoeinDetail>();
                var group = new Data.AccountingMoeinDetail();
                string oldGroupIdIn = null;
                //edit mode
                group = accountingMoeinDetailBusiness.GetByAccountingMoeinDetailId(AccountingMoeinId, Common.Constants.CodeTitle.Goruh).FirstOrDefault();
                if (group == null)
                    group = new AccountingMoeinDetail() { IdAccountingMoein = AccountingMoeinId , IdCodeTitle = Common.Constants.CodeTitle.Goruh};
                else
                    oldGroupIdIn = group.IdIn;
                PrepareGroup(group);
                groups.Add(group);

                if (oldGroupIdIn != null)
                {
                    var otherGroups = accountingMoeinDetailBusiness.GetByIdIn(oldGroupIdIn, Common.Constants.CodeTitle.Goruh).Where(r => r.IdAccountingMoein != AccountingMoeinId).ToList();
                    otherGroups.ForEach(r => PrepareGroup(r));
                    groups.AddRange(otherGroups);
                }

                accountingMoeinDetailBusiness.Save(groups);
                return group;
            }
            catch
            {

                throw;
            }
        }

        private Data.AccountingMoeinDetail SaveKol()
        {
            try
            {
                var accountingMoeinDetailBusiness = Business.GetAccountingMoeinDetailBusiness();
                var kols = new List<Data.AccountingMoeinDetail>();
                string oldKolCode = null;

                //edit mode
                var kol = accountingMoeinDetailBusiness.GetByAccountingMoeinDetailId(AccountingMoeinId, Common.Constants.CodeTitle.Kol).FirstOrDefault();
                if (kol == null)
                    kol = new Data.AccountingMoeinDetail() { IdAccountingMoein = AccountingMoeinId , IdCodeTitle = Common.Constants.CodeTitle.Kol};
                else
                    oldKolCode = kol.IdIn;

                PrepareKol(kol);
                kols.Add(kol);

                if (oldKolCode != null)
                {
                    var otherKols = accountingMoeinDetailBusiness.GetByIdIn(oldKolCode, Common.Constants.CodeTitle.Kol).Where(r => r.IdAccountingMoein != AccountingMoeinId).ToList();
                    otherKols.ForEach(r => PrepareGroup(r));
                    kols.AddRange(otherKols);
                }

                accountingMoeinDetailBusiness.Save(kols);
                return kol;
            }
            catch
            {

                throw;
            }
        }

        private Data.AccountingMoeinDetail SaveMoein()
        {
            try
            {
                var accountingMoeinDetailBusiness = Business.GetAccountingMoeinDetailBusiness();
                var moeins = new List<Data.AccountingMoeinDetail>();
                string oldMoeinCode = null;

                //edit mode
                var moein = accountingMoeinDetailBusiness.GetByAccountingMoeinDetailId(AccountingMoeinId, Common.Constants.CodeTitle.Moein).FirstOrDefault();
                if (moein == null)
                    moein = new Data.AccountingMoeinDetail() { IdAccountingMoein = AccountingMoeinId , IdCodeTitle = Common.Constants.CodeTitle.Moein};
                else
                    oldMoeinCode = moein.IdIn;
                PrepareMoein(moein);
                moeins.Add(moein);

                if (oldMoeinCode != null)
                {
                    var otherMoeins = accountingMoeinDetailBusiness.GetByIdIn(oldMoeinCode, Common.Constants.CodeTitle.Moein).Where(r => r.IdAccountingMoein != AccountingMoeinId).ToList();
                    otherMoeins.ForEach(r => PrepareMoein(r));
                    moeins.AddRange(otherMoeins);
                }

                accountingMoeinDetailBusiness.Save(moein);
                return moein;
            }
            catch
            {

                throw;
            }
        }

        private void PrepareGroup(AccountingMoeinDetail item)
        {
            try
            {
                item.MDName = txt_group.Text;
                item.MDNameEn = txt_name_latin_grouh.Text;
                item.IdIn = txt_grouhCode.Text;
                var view = Business.GetAccountingMoeinDetailBusiness().GetViewById(item.Id);
                if (view == null || view.IdIn != item.IdIn)
                    item.LastEdit = DateTime.Now;
            }
            catch
            {

                throw;
            }
        }

        private void PrepareKol(AccountingMoeinDetail item)
        {
            try
            {
                item.MDName = txt_all.Text;
                item.MDNameEn = txt_name_latin_kol.Text;
                item.IdIn = txt_kol_code.Text;
                var view = Business.GetAccountingMoeinDetailBusiness().GetViewById(item.Id);
                if (view == null || view.IdIn != item.IdIn)
                    item.LastEdit = DateTime.Now;
            }
            catch
            {

                throw;
            }
        }

        private void PrepareMoein(AccountingMoeinDetail item)
        {
            try
            {
                item.MDName = txt_moien.Text;
                item.MDNameEn = txt_name_latin_moien.Text;
                item.IdIn = txt_moien_code.Text;
                var view = Business.GetAccountingMoeinDetailBusiness().GetViewById(item.Id);
                if (view == null || view.IdIn != item.IdIn)
                    item.LastEdit = DateTime.Now;
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="get_idIn"></param>
        /// <returns></returns>
        private bool check_for_moien_exist(out string get_idIn)
        {
            get_idIn = "";
            List<AccountingMoeinDetail> get_grouh_M = ak1.AccountingMoeinDetails.Where(i => i.MDName == txt_group.Text).ToList();
            List<AccountingMoeinDetail> get_kol_M = ak1.AccountingMoeinDetails.Where(i => i.MDName == txt_all.Text).ToList();

            List<AccountingMoeinDetail> get_all_moien_M = ak1.AccountingMoeinDetails.Where(i => i.IdCodeTitle == Common.Constants.CodeTitle.Moein).ToList();

            for (int i = 0; i <= get_kol_M.Count - 1; i++)
            {
                for (int j = 0; j <= get_all_moien_M.Count - 1; j++)
                {
                    if (get_kol_M[i].IdAccountingMoein == get_all_moien_M[j].IdAccountingMoein)
                    {
                        get_idIn += get_all_moien_M[j].IdIn + "_";
                        if (get_all_moien_M[j].MDName == txt_moien.Text)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// حذف رکورد از جدول معین
        /// </summary>
        /// <param name="accountigMoien"></param>
        private void remove_AccountingMoien(Guid accountingMoienId)
        {
            AccountingMoein am = ak1.AccountingMoeins.First(i => i.Id == accountingMoienId);
            ak1.AccountingMoeins.Remove(am);
            ak1.SaveChanges();

        }
        /// <summary>
        /// ثبت اطلاعات در جدول accountingMoien
        /// </summary>
        /// <param name="accountingMoienId"></param>
        /// <param name="grouhIdIn"></param>
        /// <param name="kolIdIn"></param>
        /// <param name="moienIdIn"></param>
        /// <param name="moienName"></param>



        /// <summary>
        ///بررسی جدول و پاک کردن رکورد در صورت تکراری بودن
        /// </summary>
        /// <param name="C_id_accounting_moien">کد معین ثبت شده</param>
        /// <param name="IdInGrouh">accountig moien گروه ثبت شده</param>
        /// <param name="IdInKol">accountig moien کل ثبت شده</param>
        /// <param name="IdInMoien">accountig moien معین ثبت شده</param>
        /// <returns></returns>
        private bool check_for_duplication_record(string C_id_accounting_moien, string IdInGrouh, string IdInKol, string IdInMoien)
        {
            int counter = 0;
            string[] sorted_idn = new string[3];


            List<AccountingMoeinDetail> get_all_from_table = ak1.AccountingMoeinDetails.OrderBy(i => i.IdAccountingMoein).ToList();
            ///////////////////////////////////////////////////////////////////////
            for (int i = 0; i <= get_all_from_table.Count - 1; i += 3)
            {
                for (int j = i; j <= (i + 3) - 1; j++)
                {
                    if (get_all_from_table[j].IdCodeTitle == Common.Constants.CodeTitle.Goruh)
                    {
                        sorted_idn[0] = get_all_from_table[j].IdIn.ToString();
                    }

                    if (get_all_from_table[j].IdCodeTitle == Common.Constants.CodeTitle.Kol)
                    {
                        sorted_idn[1] = get_all_from_table[j].IdIn.ToString();
                    }

                    if (get_all_from_table[j].IdCodeTitle == Common.Constants.CodeTitle.Moein)
                    {
                        sorted_idn[2] = get_all_from_table[j].IdIn.ToString();
                    }
                }
                ////////////////////////////////////////////////////////////////////

                if (sorted_idn[0] == IdInGrouh && sorted_idn[1] == IdInKol && sorted_idn[2] == IdInMoien)
                {
                    counter++;
                }

                if (sorted_idn[0] == "")
                {
                    counter = 2;
                }

            }


            if (counter > 1)
            {
                /////// پاک کردن تمام رکوردهای ثبت شده

                Guid guid_id_moien = Guid.Parse(C_id_accounting_moien);
                AccountingMoeinDetail akm = ak1.AccountingMoeinDetails.First(i => i.IdAccountingMoein == guid_id_moien);
                ak1.AccountingMoeinDetails.Remove(akm);
                ak1.SaveChanges();

                AccountingMoeinDetail akm1 = ak1.AccountingMoeinDetails.First(i => i.IdAccountingMoein == guid_id_moien);
                ak1.AccountingMoeinDetails.Remove(akm1);
                ak1.SaveChanges();

                AccountingMoeinDetail akm2 = ak1.AccountingMoeinDetails.First(i => i.IdAccountingMoein == guid_id_moien);
                ak1.AccountingMoeinDetails.Remove(akm2);
                ak1.SaveChanges();

                return true;
            }


            return false;

        }

        /// <summary>
        /// گرفتن کلهای گروه موجود
        /// </summary>
        private void get_current_group_kols()
        {
            Guid gg = Common.Constants.CodeTitle.Kol;

            List<AccountingMoeinDetail> get_grouh_ = ak1.AccountingMoeinDetails.Where(i => i.MDName == txt_group.Text).ToList();
            List<AccountingMoeinDetail> get_kol_ = ak1.AccountingMoeinDetails.Where(i => i.IdCodeTitle == gg).ToList();

            foreach (var i in get_grouh_)
            {
                foreach (var j in get_kol_)
                {
                    if (i.IdAccountingMoein == j.IdAccountingMoein)
                    {
                        str_get_idin_kols_for_current_grouh += j.IdIn + "_";
                    }
                }

            }
        }
        /// <summary>
        /// گرفتن طول کد از جدول
        /// </summary>
        /// <param name="MDName">نام مورد نظر</param>
        /// <returns></returns>

        private int get_code_length(string MDName)
        {
            int code_len = 0;
            List<CodeTitle> get_code_len = ak1.CodeTitles.Where(i => i.CodeName == MDName).ToList();

            foreach (var item in get_code_len)
            {
                code_len = int.Parse(item.CodeLen.ToString());
            }
            return code_len;
        }

        /// <summary>
        /// اضافه کردن توصیه ها به کادر متن مربوط به کل
        /// </summary>
        private void addSuggestionToTextBoxKol()
        {
            List<AccountingMoeinDetail> get_all_kol = ak1.AccountingMoeinDetails.OrderBy(i =>
                i.IdCodeTitle == Common.Constants.CodeTitle.Kol).Where(b => b.IdCodeTitle == Common.Constants
                    .CodeTitle.Kol).Distinct().ToList();

            foreach (var item in get_all_kol)
            {
                txt_all.AddItem(new WPFAutoCompleteTextbox.AutoCompleteEntry(item.MDName, item.MDName));

            }

        }

        /// <summary>
        /// اضافه کردن توصیه ها به کادر متن مربوط به گروه
        /// </summary>
        private void addSuggestionToTextBoxGrouh()
        {
            List<AccountingMoeinDetail> get_all_grouh = ak1.AccountingMoeinDetails.OrderBy(i =>
                i.IdCodeTitle == Common.Constants.CodeTitle.Goruh).Where(b => b.IdCodeTitle == Common.Constants
                    .CodeTitle.Goruh).Distinct().ToList();

            foreach (var item in get_all_grouh)
            {
                txt_group.AddItem(new WPFAutoCompleteTextbox.AutoCompleteEntry(item.MDName, item.MDName));
            }
        }

        private void RegDataTo_cmb_NoeMoien()
        {
            try
            {
                cmb_noeMoien.ItemsSource = Business.GetBaseInfoBusiness().GetByType(Common.Constants.BaseInfoType.NoeMoien).ToList();
            }
            catch
            {

                throw;
            }

        }

        private void txt_group_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                var accountingMoeinDetailsBusiness = Business.GetAccountingMoeinDetailBusiness();

                var group = accountingMoeinDetailsBusiness.GetByMDName(txt_group.Text, Common.Constants.CodeTitle.Goruh).FirstOrDefault();
                if (group != null)
                {
                    get_current_group_kols();
                    txt_grouhCode.Text = group.IdIn;
                    txt_name_latin_grouh.Text = group.MDNameEn;
                }
                else
                    // گروه والدی ندارد
                    txt_grouhCode.Text = accountingMoeinDetailsBusiness.GetNewCode(Common.Constants.CodeTitle.Goruh, new Data.AccountingMoeinDetail());
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void txt_all_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                var accountingMoeinDetailsBusiness = Business.GetAccountingMoeinDetailBusiness();

                var group = accountingMoeinDetailsBusiness.GetByMDName(txt_group.Text, Common.Constants.CodeTitle.Goruh).FirstOrDefault();

                var kol = accountingMoeinDetailsBusiness.GetByMDName(txt_all.Text, Common.Constants.CodeTitle.Kol).FirstOrDefault();
                if (kol != null)
                {
                    txt_kol_code.Text = kol.IdIn;
                    txt_name_latin_kol.Text = kol.MDNameEn;
                }
                else
                    txt_kol_code.Text = accountingMoeinDetailsBusiness.GetNewCode(Common.Constants.CodeTitle.Kol, group);
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void txt_moien_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                var accountingMoeinDetailsBusiness = Business.GetAccountingMoeinDetailBusiness();

                var kol = accountingMoeinDetailsBusiness.GetByMDName(txt_all.Text, Common.Constants.CodeTitle.Kol).FirstOrDefault();

                var moein = accountingMoeinDetailsBusiness.GetByMDName(txt_moien.Text, Common.Constants.CodeTitle.Moein).FirstOrDefault();
                if (moein != null)
                {
                    txt_moien_code.Text = moein.IdIn;
                    txt_name_latin_moien.Text = moein.MDNameEn;
                }
                else
                    txt_moien_code.Text = accountingMoeinDetailsBusiness.GetNewCode(Common.Constants.CodeTitle.Moein, kol);
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }

        }

        private void txt_grouhCode_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.JustPersian(e);
        }

        private void txt_group_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.JustPersian(e);
        }

        private void txt_moien_code_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.JustPersian(e);
        }

        private void txt_moien_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.JustPersian(e);
        }

        private void txt_name_latin_grouh_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.JustEnglish(e);
        }

        private void txt_name_latin_kol_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.JustEnglish(e);
        }

        private void txt_name_latin_moien_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.JustEnglish(e);
        }

        private void txt_kol_code_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.JustEnglish(e);
        }


    }
}
