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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Windows.Controls.Ribbon;
using Common;
using AccountingKernel.Forms;
using AccountingKernel.Forms.SotoheTafsili;

namespace AccountingKernel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Guid CorposrationId = new Guid("278E6285-73D5-4FC9-91AE-E38F337806CA");
        string names;
        string current_tab = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Ribbon_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btn_manageMainContent_Click(object sender, RoutedEventArgs e)
        {
            // 
            if (check_for_tab_state("مدیریت عناوین اصلی"))
            {
                Class.Variable.check_for_tab_names.get_tab_names += "مدیریت عناوین اصلی";
                Class.Variable.check_for_tab_names.get_tab_names += ",";

                ClosableTab tabItem = new ClosableTab();   /// 
                tabItem.Title = "مدیریت عناوین اصلی";
                tabItem.Unloaded += tabItem_Unloaded;
                mainTab.Items.Add(tabItem);
                tabItem.Focus();
                tabItem.Content = new AccountingKernel.Forms.MbaseInfo.FrmBaseInfo().Content;
            }
            else
            {

                MessageBox.Show("مدیریت عناوین اصلی");
            }
        }

        void tabItem_Unloaded(object sender, RoutedEventArgs e)
        {



            //MessageBox.Show(h.Header.ToString());
            // throw new NotImplementedException();
        }

        private void btn_moienCodeManagement_Click_1(object sender, RoutedEventArgs e)
        {

            Class.Variable.check_for_tab_names.get_tab_names += "کدهای معین";
            Class.Variable.check_for_tab_names.get_tab_names += ",";

            ClosableTab theTabItem = new ClosableTab();
            theTabItem.Title = "کدهای معین";
            theTabItem.Unloaded += tabItem_Unloaded;
            mainTab.Items.Add(theTabItem);
            theTabItem.Focus();

            theTabItem.Content = new AccountingKernel.Forms.MmoienCode.MoeinSearch().Content;
        }



        private void btn_documentCode_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Class.Variable.check_for_tab_names.get_tab_names += Localize.DocumentManagement;
                Class.Variable.check_for_tab_names.get_tab_names += ",";

                ClosableTab tabItem = new ClosableTab();
                tabItem.Title = Localize.DocumentManagement;
                mainTab.Items.Add(tabItem);
                tabItem.Focus();

                //tabItem.Content = new AccountingKernel.Forms.Document.frmDocument().Content;
                tabItem.Content = new AccountingKernel.Forms.Document.Document().Content;


            }
            catch
            {

                throw;
            }
        }

        private void btn_GoodsManagement_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                Class.Variable.check_for_tab_names.get_tab_names += Localize.GoodsManagement;
                Class.Variable.check_for_tab_names.get_tab_names += ",";

                ClosableTab tabItem = new ClosableTab();
                tabItem.Title = Localize.GoodsManagement;
                mainTab.Items.Add(tabItem);
                tabItem.Focus();

                tabItem.Content = new AccountingKernel.Forms.Goodies.FrmGoods().Content;
            }
            catch
            {

                throw;
            }
        }

        private void btn_GoodiesManagement_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                Class.Variable.check_for_tab_names.get_tab_names += Localize.GoodsManagement;
                Class.Variable.check_for_tab_names.get_tab_names += ",";

                ClosableTab tabItem = new ClosableTab();
                tabItem.Title = Localize.GoodsManagement;
                mainTab.Items.Add(tabItem);
                tabItem.Focus();

                tabItem.Content = new AccountingKernel.Forms.Goodies.FrmGoods().Content;
            }
            catch
            {

                throw;
            }
        }

        private void btn_GoodiesGroupManagement_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Class.Variable.check_for_tab_names.get_tab_names += Localize.GoodsManagement;
                Class.Variable.check_for_tab_names.get_tab_names += ",";


                ClosableTab tabItem = new ClosableTab();
                tabItem.Title = Localize.GoodsManagement;
                mainTab.Items.Add(tabItem);
                tabItem.Focus();

                //  tabItem.Content = new AccountingKernel.Forms.Goods.Groups.FrmGoodiesGroups().Content;
            }
            catch
            {

                throw;
            }
        }

        //tarife_toole_code_Click_1
        private void tarife_toole_code_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Class.Variable.check_for_tab_names.get_tab_names += "تعریف طول کد";
                Class.Variable.check_for_tab_names.get_tab_names += ",";


                ClosableTab tabItem = new ClosableTab();
                tabItem.Title = "تعریف طول کد";
                // tabItem.Title = Localize.CompanyManagement;
                mainTab.Items.Add(tabItem);
                tabItem.Focus();

                tabItem.Content = new AccountingKernel.Forms.Settings.frm_tarife_toole_code().Content;

            }
            catch
            {

                throw;
            }


        }

        //btn_formAsnad_Click
        private void btn_formAsnad_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                Class.Variable.check_for_tab_names.get_tab_names += Localize.DocumentForm;
                Class.Variable.check_for_tab_names.get_tab_names += ",";

                ClosableTab tabItem = new ClosableTab();
                tabItem.Title = Localize.DocumentForm;
                mainTab.Items.Add(tabItem);
                tabItem.Focus();

                tabItem.Content = new AccountingKernel.Forms.Document.frm_modAsnad().Content;

            }
            catch
            {

                throw;
            }

        }

        private void btn_CompaniesManagement_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Class.Variable.check_for_tab_names.get_tab_names += Localize.CompanyManagement;
                Class.Variable.check_for_tab_names.get_tab_names += ",";


                ClosableTab tabItem = new ClosableTab();
                tabItem.Title = Localize.CompanyManagement;
                mainTab.Items.Add(tabItem);
                tabItem.Focus();

                tabItem.Content = new AccountingKernel.Forms.Company.frmCompanies().Content;

            }
            catch
            {

                throw;
            }
        }

        private void btn_InvoiceBillManagement_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                Class.Variable.check_for_tab_names.get_tab_names += Localize.InvoiceManagement;
                Class.Variable.check_for_tab_names.get_tab_names += ",";


                ClosableTab tabItem = new ClosableTab();
                tabItem.Title = Localize.InvoiceManagement;
                mainTab.Items.Add(tabItem);
                tabItem.Focus();

                tabItem.Content = new AccountingKernel.Forms.Bills.SaleInvoice.FrmSaleInvoiceManagement().Content;

            }
            catch
            {

                throw;
            }
        }

        private void btn_RegisterInvoiceBillManagement_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                /*Class.Variable.check_for_tab_names.get_tab_names += Localize.SaleInvoice;
                Class.Variable.check_for_tab_names.get_tab_names += ",";*/


                var frmSaleInvoice = new AccountingKernel.Forms.Bills.SaleInvoice.FrmSaleInvoice(Common.Enum.FormMode.New, null, Constants.StoreOperation.SaleInvoice);
                frmSaleInvoice.Title = Localize.SaleInvoice;
                frmSaleInvoice.ShowDialog();

            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void btn_PreInvoiceManagement_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Class.Variable.check_for_tab_names.get_tab_names += Localize.PreInvoiceManagment;
                Class.Variable.check_for_tab_names.get_tab_names += ",";


                ClosableTab tabItem = new ClosableTab();
                tabItem.Title = Localize.PreInvoiceManagment;
                mainTab.Items.Add(tabItem);
                tabItem.Focus();

                tabItem.Content = new AccountingKernel.Forms.Bills.PreSaleInvoice.FrmPreSaleInvoiceManagement().Content;

            }
            catch
            {

                throw;
            }
        }

        private void btn_RegisterPreInvoiceManagement_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                /*names += Localize.PreInvoiceManagment;
                names += ",";*/
                var frmPreInvoice = new AccountingKernel.Forms.Bills.PreSaleInvoice.FrmPreSaleInvoice(Common.Enum.FormMode.New, null, Constants.StoreOperation.PreSaleInvoice);
                frmPreInvoice.Title = Localize.PreInvoiceManagment;
                frmPreInvoice.ShowDialog();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void btnRepository_click(object sender, RoutedEventArgs e)
        {
            try
            {
                Class.Variable.check_for_tab_names.get_tab_names += Localize.Repository;
                Class.Variable.check_for_tab_names.get_tab_names += ",";


                ClosableTab tabItem = new ClosableTab();
                tabItem.Title = Localize.Repository;
                mainTab.Items.Add(tabItem);
                tabItem.Focus();

                tabItem.Content = new AccountingKernel.Forms.baseInfo.FrmBaseInfo(Common.Constants.BaseInfoType.Repository).Content;
            }
            catch
            {

                throw;
            }
        }

        private void btn_OperativeManagement_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Class.Variable.check_for_tab_names.get_tab_names += Localize.OperativeManagement;
                Class.Variable.check_for_tab_names.get_tab_names += ",";


                ClosableTab tabItem = new ClosableTab();
                tabItem.Title = Localize.OperativeManagement;
                mainTab.Items.Add(tabItem);
                tabItem.Focus();

                tabItem.Content = new AccountingKernel.Forms.Operatives.frmOperativeMangement().Content;
            }
            catch
            {

                throw;
            }
        }

        private void btn_modiriateFaktorKharid_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("");
        }

        private void mainTab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void MainWin_Loaded(object sender, RoutedEventArgs e)
        {
            //this.Title = "نرم افزار مدیریت مالی";
        }

        private void btn_SaleInvoiceManagement_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Class.Variable.check_for_tab_names.get_tab_names += Localize.PurchaseInvoice;
                Class.Variable.check_for_tab_names.get_tab_names += ",";



                ClosableTab tabItem = new ClosableTab();
                tabItem.Title = Localize.PurchaseInvoice;
                mainTab.Items.Add(tabItem);
                tabItem.Focus();

                tabItem.Content = new AccountingKernel.Forms.Bills.PurchaseInvoice.FrmPurchaseInvoiceManagement().Content;

            }
            catch
            {

                throw;
            }
        }

        private void btn_OrderManagmentClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Class.Variable.check_for_tab_names.get_tab_names += Localize.Order;
                Class.Variable.check_for_tab_names.get_tab_names += ",";


                ClosableTab tabItem = new ClosableTab();
                tabItem.Title = Localize.Order;
                mainTab.Items.Add(tabItem);
                tabItem.Focus();

                tabItem.Content = new AccountingKernel.Forms.Bills.Order.FrmOrderManagment().Content;

            }
            catch
            {

                throw;
            }
        }

        private void btn_RegisterOrderManagmentClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var frmOrder = new AccountingKernel.Forms.Bills.Order.FrmOrder(Common.Enum.FormMode.New, Common.Constants.StoreOperation.WarehouseReceipts, null);
                frmOrder.ShowDialog();

            }
            catch
            {

                throw;
            }
        }

        private void btn_ReceiptMangementClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Class.Variable.check_for_tab_names.get_tab_names += Localize.ReceiptManagement;
                Class.Variable.check_for_tab_names.get_tab_names += ",";


                ClosableTab tabItem = new ClosableTab();
                tabItem.Title = Localize.ReceiptManagement;
                mainTab.Items.Add(tabItem);
                tabItem.Focus();

                tabItem.Content = new AccountingKernel.Forms.Bills.WarehouseReceipts.FrmReceiptManagment().Content;

            }
            catch
            {

                throw;
            }
        }

        private void btn_RegisterReceiptMangementClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var frmReceiptOrder = new AccountingKernel.Forms.Bills.WarehouseReceipts.FrmReceiptOrder(Common.Enum.FormMode.New, Common.Constants.StoreOperation.WarehouseReceipts, null);
                frmReceiptOrder.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void _0009_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void btn_manageBank_1_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Class.Variable.check_for_tab_names.get_tab_names += "تعریف بانک";
                Class.Variable.check_for_tab_names.get_tab_names += ",";


                ClosableTab tabItem = new ClosableTab();
                tabItem.Title = "تعریف بانک";
                mainTab.Items.Add(tabItem);
                tabItem.Focus();

                tabItem.Content = new AccountingKernel.Forms.baseInfo.frm_list_bank().Content;

            }
            catch
            {

                throw;
            }

        }

        private void _0006_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void _tarife_cheq_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Class.Variable.check_for_tab_names.get_tab_names += "تعریف چک";
                Class.Variable.check_for_tab_names.get_tab_names += ",";

                ClosableTab tabItem = new ClosableTab();
                tabItem.Title = "تعریف چک";
                // tabItem.Title = Localize.OperativeManagement;
                mainTab.Items.Add(tabItem);
                tabItem.Focus();

                tabItem.Content = new AccountingKernel.Forms.KazaneDari.frm_list_cheque().Content;
            }
            catch
            {

                throw;
            }

        }

        private void _tarife_daryaft_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Class.Variable.check_for_tab_names.get_tab_names += "دریافت";
                Class.Variable.check_for_tab_names.get_tab_names += ",";

                ClosableTab tabItem = new ClosableTab();
                tabItem.Title = "دریافت";
                // tabItem.Title = Localize.PreInvoiceManagment;
                mainTab.Items.Add(tabItem);
                tabItem.Focus();

                tabItem.Content = new AccountingKernel.Forms.KazaneDari.frm_list_daryaft().Content;

            }
            catch
            {

                throw;
            }
        }

        private void _tarife_pardakht_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Class.Variable.check_for_tab_names.get_tab_names += "پرداخت";
                Class.Variable.check_for_tab_names.get_tab_names += ",";

                ClosableTab tabItem = new ClosableTab();
                tabItem.Title = "پرداخت";
                // tabItem.Title = Localize.OperativeManagement;
                mainTab.Items.Add(tabItem);
                tabItem.Focus();
                tabItem.Content = new AccountingKernel.Forms.KazaneDari.frm_list_pardakht().Content;
            }
            catch
            {

                throw;
            }
        }

        private void btn_manageBank_000_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Class.Variable.check_for_tab_names.get_tab_names += "خرج چک";
                Class.Variable.check_for_tab_names.get_tab_names += ",";

                Class.Variable.Variables.noe_cheque = "1";
                ClosableTab tabItem = new ClosableTab();
                tabItem.Title = "خرج چک";
                // tabItem.Title = Localize.OperativeManagement;
                mainTab.Items.Add(tabItem);
                tabItem.Focus();
                tabItem.Content = new AccountingKernel.Forms.tankhah.frm_cheque().Content;
            }
            catch
            {

                throw;
            }
        }

        private void btn_manageBank_001_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Class.Variable.check_for_tab_names.get_tab_names += "وصول چک";
                Class.Variable.check_for_tab_names.get_tab_names += ",";


                Class.Variable.Variables.noe_cheque = "2";
                ClosableTab tabItem = new ClosableTab();
                tabItem.Title = "وصول چک";
                mainTab.Items.Add(tabItem);
                tabItem.Focus();
                tabItem.Content = new AccountingKernel.Forms.tankhah.frm_cheque().Content;
            }
            catch
            {

                throw;
            }
        }

        private void btn_manageBank_002_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {

                Class.Variable.check_for_tab_names.get_tab_names += "ابطال چک";
                Class.Variable.check_for_tab_names.get_tab_names += ",";


                ClosableTab tabItem = new ClosableTab();
                Class.Variable.Variables.noe_cheque = "3";
                tabItem.Title = "ابطال چک";
                mainTab.Items.Add(tabItem);
                tabItem.Focus();
                tabItem.Content = new AccountingKernel.Forms.tankhah.frm_cheque().Content;
            }
            catch
            {

                throw;
            }
        }

        private void btn_manageBank_0000_Click_1(object sender, RoutedEventArgs e)
        {

            try
            {
                Class.Variable.check_for_tab_names.get_tab_names += "برگشت چک";
                Class.Variable.check_for_tab_names.get_tab_names += ",";


                Class.Variable.Variables.noe_cheque = "4";
                ClosableTab tabItem = new ClosableTab();
                tabItem.Title = "برگشت چک";
                mainTab.Items.Add(tabItem);
                tabItem.Focus();
                tabItem.Content = new AccountingKernel.Forms.tankhah.frm_cheque().Content;
            }
            catch
            {

                throw;
            }
        }

        private void btn_manageBank_0011_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Class.Variable.check_for_tab_names.get_tab_names += "استرداد چک";
                Class.Variable.check_for_tab_names.get_tab_names += ",";


                ClosableTab tabItem = new ClosableTab();
                Class.Variable.Variables.noe_cheque = "5";
                tabItem.Title = "استرداد چک";
                mainTab.Items.Add(tabItem);
                tabItem.Focus();
                tabItem.Content = new AccountingKernel.Forms.tankhah.frm_cheque().Content;
            }
            catch
            {

                throw;
            }
        }

        private void btn_manageBank_0022_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Class.Variable.check_for_tab_names.get_tab_names += "برگشت چک خرج شده";
                Class.Variable.check_for_tab_names.get_tab_names += ",";


                ClosableTab tabItem = new ClosableTab();
                Class.Variable.Variables.noe_cheque = "6";
                tabItem.Title = "برگشت چک خرج شده";
                mainTab.Items.Add(tabItem);
                tabItem.Focus();
                tabItem.Content = new AccountingKernel.Forms.tankhah.frm_cheque().Content;
            }
            catch
            {

                throw;
            }
        }

        private void btn_manageBank_00_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Class.Variable.check_for_tab_names.get_tab_names += "لیست تنخواه";
                Class.Variable.check_for_tab_names.get_tab_names += ",";

                ClosableTab tabItem = new ClosableTab();
                tabItem.Title = "لیست تنخواه";
                mainTab.Items.Add(tabItem);
                tabItem.Focus();
                tabItem.Content = new AccountingKernel.Forms.tankhah.frm_listTankhah().Content;
            }
            catch
            {

                throw;
            }
        }

        private void btn_ReturnOfSaleManagement_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Class.Variable.check_for_tab_names.get_tab_names += Localize.ReturnOfSale;
                Class.Variable.check_for_tab_names.get_tab_names += ",";

                ClosableTab tabItem = new ClosableTab();
                tabItem.Title = Localize.ReturnOfSale;
                mainTab.Items.Add(tabItem);
                tabItem.Focus();
                tabItem.Content = new AccountingKernel.Forms.Bills.ReturnOfSale.FrmReturnOfSaleManagment().Content;
            }
            catch
            {

                throw;
            }
        }

        private void btn_RegisterReturnOfSaleManagement_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var frmOrder = new AccountingKernel.Forms.Bills.ReturnOfSale.FrmReturnOfSale(Common.Enum.FormMode.New, Common.Constants.StoreOperation.ReturnOfSale, null);
                frmOrder.ShowDialog();
            }
            catch
            {

                throw;
            }
        }

        private void btn_ReturnOfBuyingBillManagement_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Class.Variable.check_for_tab_names.get_tab_names += Localize.ReturnOfBuying;
                Class.Variable.check_for_tab_names.get_tab_names += ",";


                ClosableTab tabItem = new ClosableTab();
                tabItem.Title = Localize.ReturnOfBuying;
                mainTab.Items.Add(tabItem);
                tabItem.Focus();
                tabItem.Content = new AccountingKernel.Forms.Bills.ReturnOfBuying.FrmReturnOfBuyingManagment().Content;
            }
            catch
            {

                throw;
            }
        }

        private void btn_manageBank_000000_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void btn_tarife_hesabe_tafsili_Click_1(object sender, RoutedEventArgs e)
        {
            /* string ID = Class.Variable.Variables.ID_for_tarife_hesabe_tafsili;
             string getID = ID;
             AccountingKernel.Forms.SotoheTafsili.frm_taien_sotohe_tafsili frm_sathe_tafsili = new
             Forms.SotoheTafsili.frm_taien_sotohe_tafsili();

             if (ID != "")
             {
                 AccountingKernel.Forms.SotoheTafsili.get_set_moien_id_tafsili.moien_id_ = ID;
                 AccountingKernel.Class.Variable.Variables.idAccountingMoien = ID;
                 frm_sathe_tafsili.ShowDialog();
                 this.InvalidateVisual();

             }
             else
             {
                 MessageBox.Show("معینی انتخاب نشده است", "خطا", MessageBoxButton.OK, MessageBoxImage.Warning);
             } */

            Forms.SotoheTafsili.Tarife_hesabe_tafsili tst = new Forms.SotoheTafsili.Tarife_hesabe_tafsili();
            tst.ShowDialog();

        }

        private void btn_hesab_tafsili_Click_1(object sender, RoutedEventArgs e)
        {


            Class.Variable.check_for_tab_names.get_tab_names += "حسابهای تفصیل";
            Class.Variable.check_for_tab_names.get_tab_names += ",";

            AccountingKernel.Class.Variable.Variables.idAccountingMoien = Class.Variable.Variables.ID_for_tarife_hesabe_tafsili;

            ClosableTab tabItem = new ClosableTab();
            tabItem.Title = "حسابهای تفصیل";
            mainTab.Items.Add(tabItem);
            tabItem.Focus();
            tabItem.Content = new ManageTafsiliGroup().Content;
        }

        private void click_personnel(object sender, RoutedEventArgs e)
        {
            try
            {
                Class.Variable.check_for_tab_names.get_tab_names += "پرسنل";
                Class.Variable.check_for_tab_names.get_tab_names += ",";

                ClosableTab tabItem = new ClosableTab();
                tabItem.Title = "پرسنل";
                mainTab.Items.Add(tabItem);
                tabItem.Focus();
                tabItem.Content = new PersonInfoSubmit().Content;
            }
            catch
            {

                throw;
            }
        }

        private void btn_tarifeKarbar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void click_user(object sender, RoutedEventArgs e)
        {
            try
            {
                Class.Variable.check_for_tab_names.get_tab_names += "تعریف کاربر";
                Class.Variable.check_for_tab_names.get_tab_names += ",";

                ClosableTab tabItem = new ClosableTab();
                tabItem.Title = "تعریف کاربر";
                mainTab.Items.Add(tabItem);
                tabItem.Focus();
                tabItem.Content = new AccountingKernel.Forms.user_personel.frm_user().Content;
            }
            catch
            {
                throw;
            }
        }

        private void sale_maly_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Class.Variable.check_for_tab_names.get_tab_names += "سال مالی";
                Class.Variable.check_for_tab_names.get_tab_names += ",";

                ClosableTab tabItem = new ClosableTab();
                tabItem.Title = "سال مالی";
                mainTab.Items.Add(tabItem);
                tabItem.Focus();
                tabItem.Content = new AccountingKernel.Forms.saleMaly.frm_saleMaly().Content;
                current_tab = "سال مالی";
                //tabItem.Unloaded += tabItem_Unloaded;
            }
            catch
            {

                throw;
            }
        }

        //void tabItem_Unloaded(object sender, RoutedEventArgs e)
        //{
        //    MessageBox.Show( ((ClosableTab)sender).Title.ToString());



        //}

        private void tarife_saleMaly_Click(object sender, RoutedEventArgs e)
        {

        }

        private void tarife_grouh_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Class.Variable.check_for_tab_names.get_tab_names += "تعریف گروه";
                Class.Variable.check_for_tab_names.get_tab_names += ",";


                ClosableTab tabItem = new ClosableTab();
                tabItem.Title = "تعریف گروه";
                mainTab.Items.Add(tabItem);
                tabItem.Focus();
                tabItem.Content = new AccountingKernel.Forms.saleMaly.frm_tarifeGrouh().Content;
            }
            catch
            {

                throw;
            }

        }

        private void grouh_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Class.Variable.check_for_tab_names.get_tab_names += "گروه";
                Class.Variable.check_for_tab_names.get_tab_names += ",";


                ClosableTab tabItem = new ClosableTab();
                tabItem.Title = "گروه";
                mainTab.Items.Add(tabItem);
                tabItem.Focus();
                tabItem.Content = new AccountingKernel.Forms.saleMaly.frm_grouh().Content;
            }
            catch
            {

                throw;
            }
        }

        private void btn_manageInterfaces_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Class.Variable.check_for_tab_names.get_tab_names += "رابط های مالی";
                Class.Variable.check_for_tab_names.get_tab_names += ",";


                ClosableTab tabItem = new ClosableTab();
                tabItem.Title = "رابط های مالی";
                mainTab.Items.Add(tabItem);
                tabItem.Focus();
                tabItem.Content = new AccountingKernel.Forms.Interface.frmInterfaces().Content;

            }
            catch
            {

                throw;
            }
        }

        private void btn_tarifeSandogh_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Class.Variable.check_for_tab_names.get_tab_names += "تعریف صندوق";
                Class.Variable.check_for_tab_names.get_tab_names += ",";


                ClosableTab tabItem = new ClosableTab();
                tabItem.Title = "تعریف صندوق";
                mainTab.Items.Add(tabItem);
                tabItem.Focus();
                tabItem.Content = new AccountingKernel.Forms.Sandogh.frm_sandogh().Content;
            }
            catch
            {

                throw;
            }
        }

        private void btn_RegisterSaleInvoiceBillManagement_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Class.Variable.check_for_tab_names.get_tab_names += Localize.PurchaseInvoice;
                Class.Variable.check_for_tab_names.get_tab_names += ",";



                var frmPurcahseInvoice = new AccountingKernel.Forms.Bills.PurchaseInvoice.FrmPurchaseInvoice(Common.Enum.FormMode.New, Constants.StoreOperation.PurchaseInvoice);
                frmPurcahseInvoice.Title = Localize.PurchaseInvoice;
                frmPurcahseInvoice.ShowDialog();
            }
            catch (Exception ex)
            {

                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);

            }
        }

        private void btn_RegisterReturnOfBuyingBillManagement_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Class.Variable.check_for_tab_names.get_tab_names += Localize.ReturnOfBuying;
                Class.Variable.check_for_tab_names.get_tab_names += ",";



                var frmReturnOrder = new AccountingKernel.Forms.Bills.ReturnOfBuying.FrmReturnOfBuying(Common.Enum.FormMode.New, Common.Constants.StoreOperation.ReturnOfBuying, null);
                frmReturnOrder.Title = Localize.ReturnOfBuying;
                frmReturnOrder.ShowDialog();
            }
            catch
            {

                throw;
            }
        }

        private void soTax_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Class.Variable.check_for_tab_names.get_tab_names += Localize.SOTaxForm;
                Class.Variable.check_for_tab_names.get_tab_names += ",";


                ClosableTab tabItem = new ClosableTab();
                tabItem.Title = Localize.SOTaxForm;
                mainTab.Items.Add(tabItem);
                tabItem.Focus();

                tabItem.Content = new AccountingKernel.Forms.Settings.Tax.FrmSOTax().Content;
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void btn_Personel_1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Class.Variable.check_for_tab_names.get_tab_names += "تعریف پرسنل";
                Class.Variable.check_for_tab_names.get_tab_names += ",";



                ClosableTab tabItem = new ClosableTab();
                tabItem.Title = "تعریف پرسنل";
                // tabItem.Title = Localize.OperativeManagement;
                mainTab.Items.Add(tabItem);
                tabItem.Focus();
                tabItem.Content = new PersonInfoSubmitChild(null).Content;

            }
            catch
            {

                throw;
            }
        }

        private void MenuPayrollSentencesSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Class.Variable.check_for_tab_names.get_tab_names += "عوامل حکم";
                Class.Variable.check_for_tab_names.get_tab_names += ",";



                ClosableTab tabItem = new ClosableTab();
                tabItem.Title = "عوامل حکم";
                // tabItem.Title = Localize.OperativeManagement;
                mainTab.Items.Add(tabItem);
                tabItem.Focus();
                tabItem.Content = new PayrollSentencesSubmit().Content;

            }
            catch
            {

                throw;
            }
        }

        private void btn_DefinedMandate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Class.Variable.check_for_tab_names.get_tab_names += "تعریف حکم";
                Class.Variable.check_for_tab_names.get_tab_names += ",";

                ClosableTab tabItem = new ClosableTab();
                tabItem.Title = "تعریف حکم";
                // tabItem.Title = Localize.OperativeManagement;
                mainTab.Items.Add(tabItem);
                tabItem.Focus();
                tabItem.Content = new PayrollContract().Content;
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void btn_CommissionAgents_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Class.Variable.check_for_tab_names.get_tab_names += "عوامل حقوق";
                Class.Variable.check_for_tab_names.get_tab_names += ",";


                ClosableTab tabItem = new ClosableTab();
                tabItem.Title = "عوامل حقوق";
                // tabItem.Title = Localize.OperativeManagement;
                mainTab.Items.Add(tabItem);
                tabItem.Focus();
                tabItem.Content = new PayrollSalaryFactor().Content;
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void btn_Assest_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Class.Variable.check_for_tab_names.get_tab_names += Localize.Asset;
                Class.Variable.check_for_tab_names.get_tab_names += ",";

                ClosableTab tabItem = new ClosableTab();
                tabItem.Title = Localize.Asset;
                mainTab.Items.Add(tabItem);
                tabItem.Focus();
                tabItem.Content = new AccountingKernel.Forms.Asset.FrmAsset().Content;

            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void btn_AssestEstablishment_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Class.Variable.check_for_tab_names.get_tab_names += Localize.AssetEstablishment;
                Class.Variable.check_for_tab_names.get_tab_names += ",";


                ClosableTab tabItem = new ClosableTab();
                tabItem.Title = Localize.AssetEstablishment;
                mainTab.Items.Add(tabItem);
                tabItem.Focus();
                tabItem.Content = new AccountingKernel.Forms.Asset.FrmAssetEstablishment().Content;

            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void btn_AssetGoodGroup_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Class.Variable.check_for_tab_names.get_tab_names += Localize.AssetGoodGroup;
                Class.Variable.check_for_tab_names.get_tab_names += ",";


                ClosableTab tabItem = new ClosableTab();
                tabItem.Title = Localize.AssetGoodGroup;
                mainTab.Items.Add(tabItem);
                tabItem.Focus();
                tabItem.Content = new AccountingKernel.Forms.AssetGoods.FrmAssetGoodGroup().Content;

            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }

        }

        private void btn_AssestGoods_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Class.Variable.check_for_tab_names.get_tab_names += Localize.AssetGood;
                Class.Variable.check_for_tab_names.get_tab_names += ",";


                ClosableTab tabItem = new ClosableTab();
                tabItem.Title = Localize.AssetGood;
                mainTab.Items.Add(tabItem);
                tabItem.Focus();
                tabItem.Content = new AccountingKernel.Forms.AssetGoods.FrmAssetGoods().Content;

            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }



        private bool check_for_tab_state(string tab_name)
        {
            string[] get_names = Class.Variable.check_for_tab_names.get_tab_names.Split(',');

            foreach (var item in get_names)
            {
                if (item == tab_name)
                {
                    return false;
                }

            }

            return true;
        }

        private void btn_ReportTheTotalPurchasev_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Class.Variable.check_for_tab_names.get_tab_names += Localize.ReportTheTotalPurchase;
                //Class.Variable.check_for_tab_names.get_tab_names += ",";



                //var frmReturnOrder = new AccountingKernel.Forms.Bills.ReturnOfBuying.FrmReturnOfBuying(Common.Enum.FormMode.New, Common.Constants.StoreOperation.ReturnOfBuying, null);
                //frmReturnOrder.Title = Localize.ReturnOfBuying;
                // frmReturnOrder.ShowDialog();
                var Frm_ReportTheTotalPurchase = new AccountingKernel.Forms.Bills.ReportTheTotalPurchase.Frm_ReportTheTotalPurchasev();
                //Frm_ReportTheTotalPurchase.Title=Localize.ReportTheTotalPurchase;
                Frm_ReportTheTotalPurchase.ShowDialog();

            }
            catch
            {

                throw;
            }
        }

        private void btn_report(object sender, RoutedEventArgs e)
        {
            var Frm_ReportLimpidBuyByGoogies = new AccountingKernel.Forms.Bills.ReportTheTotalPurchase.ReportLimpidBuyByGoogies();
            Frm_ReportLimpidBuyByGoogies.ShowDialog();
        }

        private void btn_moienStuctureDefine_Click(object sender, RoutedEventArgs e)
        {

            Class.Variable.check_for_tab_names.get_tab_names += Localize.PurchaseInvoice;
            Class.Variable.check_for_tab_names.get_tab_names += ",";

            var MoeinDefine = new AccountingKernel.Forms.MmoienCode.MoeinStructureDefineChild();

            //var frmPurcahseInvoice = new AccountingKernel.Forms.Bills.PurchaseInvoice.FrmPurchaseInvoice(Common.Enum.FormMode.New, Constants.StoreOperation.PurchaseInvoice);
            MoeinDefine.Title = Localize.PurchaseInvoice;
            MoeinDefine.ShowDialog();
        }

        private void btn_moienCodeDefine_Click(object sender, RoutedEventArgs e)
        {
            Class.Variable.check_for_tab_names.get_tab_names += Localize.PurchaseInvoice;
            Class.Variable.check_for_tab_names.get_tab_names += ",";

            var MoeinAdd = new AccountingKernel.Forms.MmoienCode.MoeinAdd();
            MoeinAdd.Title = Localize.PurchaseInvoice;
            MoeinAdd.ShowDialog();
            //
        }

        private void btn_manageMainContent_1_Click(object sender, RoutedEventArgs e)
        {
            //
            Class.Variable.check_for_tab_names.get_tab_names += Localize.MoeinSd;
            Class.Variable.check_for_tab_names.get_tab_names += ",";


            ClosableTab tabItem = new ClosableTab();
            tabItem.Title = Localize.MoeinSd;
            mainTab.Items.Add(tabItem);
            tabItem.Focus();
            tabItem.Content = new AccountingKernel.Forms.MmoienCode.MoeinGroup().Content;
        }

        private void btn_0000_Click(object sender, RoutedEventArgs e)
        {
            Class.Variable.check_for_tab_names.get_tab_names += Localize.PersonSd;
            Class.Variable.check_for_tab_names.get_tab_names += ",";


            ClosableTab tabItem = new ClosableTab();
            tabItem.Title = Localize.PersonSd;
            mainTab.Items.Add(tabItem);
            tabItem.Focus();
            tabItem.Content = new PersonGroup().Content;
        }

        private void btn_PersonManagement_Click(object sender, RoutedEventArgs e)
        {

            Class.Variable.check_for_tab_names.get_tab_names += Localize.PurchaseInvoice;
            Class.Variable.check_for_tab_names.get_tab_names += ",";

            var PersonDefine = new PersonStructureDefineChild();

            PersonDefine.Title = Localize.PurchaseInvoice;
            PersonDefine.ShowDialog();

        }
    }
}
public class CloseableHeader_ : Control
{
    static CloseableHeader_()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(CloseableHeader), new FrameworkPropertyMetadata(typeof(CloseableHeader)));
    }
}

