using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Common;
using System.Transactions;
using Data;

namespace AccountingKernel.Forms.Goodies
{
    /// <summary>
    /// Interaction logic for Document.xaml
    /// </summary>
    public partial class FrmRegisterGoods : Window
    {
        Class.UI.TextHandeler c = new Class.UI.TextHandeler();
        public Guid? goodyId { get; set; }

        public FrmRegisterGoods()
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

        public FrmRegisterGoods(Guid goodyid)
        {
            try
            {
                NormalConstructor();

                this.goodyId = goodyid;
                var goodiesBusiness = Business.GetGoodiesBusiness();
                var goodiesGroupsBusiness = Business.GetGoodiesGroupBusiness();
                var goody = goodiesBusiness.GetById(goodyid);

                if (goody == null)
                    return;

                txtGoodTitle.Text = goody.CName;
                txtGoodEngTitle.Text = goody.CNameEn;
                txtCOrderPoint.Text = goody.COrderPoint.ToString();
                txtCOrderMax.Text = goody.COrderMax.ToString();
                txtCOrderMin.Text = goody.COrderMin.ToString();
                txtCPointCritical.Text = goody.CPointCritical.ToString();
                txtCInventoryMax.Text = goody.CInventoryMax.ToString();
                cmbBaseCountingUnit.SelectedValue = goody.CBaseCountingUnit;
                cmbType.SelectedValue = goody.CType;
                txtGoodCode.Text = goody.CID1;

                var subsidiaryGroup = goodiesGroupsBusiness.GetById(goody.IdGoodiesGroups.Value);
                var mainGroup = goodiesGroupsBusiness.GetById(subsidiaryGroup.ParentId.Value);

                txtMainGroup.Text = mainGroup.CName;
                txtMainGroupCode.Text = mainGroup.Code;

                txtSubsidiaryGroup.Text = subsidiaryGroup.CName;
                txtSubsidiaryGroupCode.Text = subsidiaryGroup.Code.Remove(0, txtMainGroupCode.Text.Length);


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

                cmbBaseCountingUnit.ItemsSource = Business.GetBaseInfoBusiness().GetByType(Common.Constants.BaseInfoType.Units).ToList();
                cmbType.ItemsSource = Business.GetBaseInfoBusiness().GetByType(Common.Constants.BaseInfoType.CommodityType).ToList();

                var mainGroups = Business.GetGoodiesGroupBusiness().GetByCodeTitleId(Common.Constants.CodeTitle.CommodityMainGroup).ToList();
                mainGroups.Select(r => r.CName).Distinct().ToList().ForEach(r =>
                    txtMainGroup.AddItem(new WPFAutoCompleteTextbox.AutoCompleteEntry(r, r)));

                mainGroups.Select(r => r.Code).Distinct().ToList().ForEach(r =>
                    txtMainGroupCode.AddItem(new WPFAutoCompleteTextbox.AutoCompleteEntry(r, r)));

            }
            catch
            {

                throw;
            }
        }

        private void btnRegister_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                var errorMessage = string.Empty;
                if (!ValidateForm(out errorMessage))
                    throw new Exception(errorMessage);

                var goodiesBusiness = Business.GetGoodiesBusiness();
                var goody = goodiesBusiness.GetById(goodyId.ToGUID());
                if (goody == null)
                    goody = new Data.Goody();

                goody.CName = txtGoodTitle.Text;
                goody.CNameEn = txtGoodEngTitle.Text;
                goody.COrderPoint = txtCOrderPoint.Text.ToNullableInt();
                goody.COrderMax = txtCOrderMax.Text.ToNullableInt();
                goody.COrderMin = txtCOrderMin.Text.ToNullableInt();
                goody.CPointCritical = txtCPointCritical.Text.ToNullableInt();
                goody.CInventoryMax = txtCInventoryMax.Text.ToNullableInt();
                goody.CBaseCountingUnit = cmbBaseCountingUnit.SelectedValue.ToGUID();
                goody.CType = cmbType.SelectedValue.ToGUID();
                goody.CID1 = txtGoodCode.Text;
                goody.IdGoodiesGroups = Business.GetGoodiesGroupBusiness().GetByCode(txtMainGroupCode.Text + txtSubsidiaryGroupCode.Text, Common.Constants.CodeTitle.CommoditySubsidiaryGroup).ID;

                using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
                {
                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted,
                    Timeout = new TimeSpan(2, 0, 0)
                }))
                {

                    goodiesBusiness.Save(goody);
                   
                    scope.Complete();
                }

                this.goodyId = goody.ID;

                this.Close();

            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private bool ValidateForm(out string errorMessage)
        {
            try
            {
                errorMessage = string.Empty;

                if (cmbBaseCountingUnit.SelectedIndex < 0)
                    errorMessage += Localize.ex_no_base_count_unit + Environment.NewLine;

                if (txtCPointCritical.Text.ToInt() >= txtCOrderPoint.Text.ToInt())
                    errorMessage += Localize.ex_critical_greater_than_order_point + Environment.NewLine;

                if (txtCInventoryMax.Text.ToInt() < txtCPointCritical.Text.ToInt() || txtCInventoryMax.Text.ToInt() < txtCOrderPoint.Text.ToInt() ||
                    txtCInventoryMax.Text.ToInt() < txtCOrderMin.Text.ToInt() || txtCInventoryMax.Text.ToInt() < txtCOrderMax.Text.ToInt())
                    errorMessage += Localize.ex_invalid_max_Inventory + Environment.NewLine;

                if (cmbType.SelectedIndex < 0)
                    errorMessage += Localize.ex_commodity_type_is_mandatory + Environment.NewLine;

                if (txtCPointCritical.Text.IsNullOrEmpty())
                    errorMessage += Localize.ex_cpointcritical_is_mandatory + Environment.NewLine;

                if (txtCOrderMax.Text.IsNullOrEmpty())
                    errorMessage += Localize.ex_cordermax_is_mandatory + Environment.NewLine;

                if (txtCInventoryMax.Text.IsNullOrEmpty())
                    errorMessage += Localize.ex_cinventorymax_is_mandatory + Environment.NewLine;

                if (txtCOrderPoint.Text.IsNullOrEmpty())
                    errorMessage += Localize.ex_corderpoint_is_mandatory + Environment.NewLine;

                if (txtCOrderMin.Text.IsNullOrEmpty())
                    errorMessage += Localize.ex_cordermin_is_mandatory + Environment.NewLine;



                return errorMessage == string.Empty;
            }
            catch
            {

                throw;
            }
        }

        private void MainGroupNameChanged()
        {
            try
            {
                var goodiesBusiness = Business.GetGoodiesGroupBusiness();
                txtSubsidiaryGroup.ClearItems();
                txtSubsidiaryGroupCode.ClearItems();
                var mainGroup = goodiesBusiness.GetByName(txtMainGroup.Text, Common.Constants.CodeTitle.CommodityMainGroup);
                if (mainGroup == null)
                {
                    txtMainGroupCode.Text = goodiesBusiness.GetNewCode(Common.Constants.CodeTitle.CommodityMainGroup, string.Empty);
                    return;
                }

                txtMainGroupCode.Text = mainGroup.Code;

                var subsidiaryGroups = goodiesBusiness.GetByParentId(mainGroup.ID).ToList();
                subsidiaryGroups.Select(r => r.CName).Distinct().ToList()
                    .ForEach(r => txtSubsidiaryGroup.AddItem(new WPFAutoCompleteTextbox.AutoCompleteEntry(r, r)));
                subsidiaryGroups.Select(r => r.Code).Distinct().ToList().
                    ForEach(r => txtSubsidiaryGroupCode.AddItem(new WPFAutoCompleteTextbox.AutoCompleteEntry(r.Remove(0, mainGroup.Code.Length), r.Remove(0, mainGroup.Code.Length))));

            }
            catch
            {

                throw;
            }
        }


        private void txtMainGroup_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                MainGroupNameChanged();
            }
            catch
            {

                throw;
            }
        }

        private void txtSubsidiaryGroup_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                SubsidiaryGroupChanged();
            }
            catch
            {

                throw;
            }
        }

        private void SubsidiaryGroupChanged()
        {
            try
            {
                var subsidiaryGroup = Business.GetGoodiesGroupBusiness().GetByName(txtSubsidiaryGroup.Text, Constants.CodeTitle.CommoditySubsidiaryGroup.ToGUID());
                if (subsidiaryGroup == null)
                    txtSubsidiaryGroupCode.Text = Business.GetGoodiesGroupBusiness().GetNewCode(Constants.CodeTitle.CommoditySubsidiaryGroup, txtMainGroupCode.Text);
                else
                    txtSubsidiaryGroupCode.Text = subsidiaryGroup.Code.Remove(0, txtMainGroupCode.Text.Length);
            }
            catch
            {

                throw;
            }
        }

        private void txtGoodTitle_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                var goodiesBusiness = Business.GetGoodiesGroupBusiness();
                var commodityDetail = goodiesBusiness.GetByName(txtGoodTitle.Text, Constants.CodeTitle.CommodityTitle.ToGUID());

                if (commodityDetail == null)
                    txtGoodCode.Text = Business.GetGoodiesGroupBusiness().GetNewCode(Constants.CodeTitle.CommodityTitle, txtMainGroupCode.Text + txtSubsidiaryGroupCode.Text);
                else
                    txtGoodCode.Text = commodityDetail.Code;

            }
            catch
            {

                throw;
            }
        }

        private void txtGoodCode_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {


            c.CheckIsNumeric(e);
        }

        private void txtGoodEngTitle_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            c.JustEnglish(e);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /*string[] s = new string[11];
            s[0] = "گروه اصلی";
            s[1] = "گروه فرعی";
            s[2] = "عنوان کالا";
            s[3] = "عنوان لاتین";
            s[4] = "واحد شمارش پایه";
            s[5] = "نقطه سفارش";
            s[6] = "حداقل سفارش";
            s[7] = "سقف سفارش";
            s[8] = "سقف موجودی";
            s[9] = "نوع";
            s[10] = "نقطه بحرانی";
    
            ImportFromExcel.frm_excel f = new ImportFromExcel.frm_excel(s);

            f.ShowDialog();

            txtMainGroup.Text = "گروه";
               // MainGroupNameChanged();

            
            txtSubsidiaryGroup.Text = "زیر گروه";*/

            ImportFromExcel.ImportFromExcelSG sg = new ImportFromExcel.ImportFromExcelSG();

            sg.add_to_table_GoodiesGroup();

           /*string ss = sg.getExcelColumns();
           MessageBox.Show(ss);*/
           

        }
    }
}
