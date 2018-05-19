using AccountingKernel.Forms.MmoienCode;
using AccountingKernel;
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
using Data;

//using Stimulsoft.Base;
//using Stimulsoft.Report;
using System.IO;

namespace AccountingKernel.Forms.MmoienCode
{

    /// <summary>
    /// Interaction logic for frm_mCodeMoien.xaml
    /// </summary>
    public partial class frm_mCodeMoien : Window
    {
        string ID = "";

        public frm_mCodeMoien()
        {
            try
            {
                InitializeComponent();
                grd_moien.ItemsSource = Business.GetAccountingMoeinBusiness().GetAll().OrderBy(i => i.MName).ToList();
                
            }
            catch 
            {
                
                throw;
            }
        }
        AccountingKernelEntities10 ak = new AccountingKernelEntities10();
        private void Grid_Initialized_1(object sender, EventArgs e)
        {
            ListCollectionView Set_All_User = new ListCollectionView(Business.GetAccountingMoeinBusiness().GetAll().OrderBy(i => i.MName).ToList());
            Set_All_User.GroupDescriptions.Add(new PropertyGroupDescription("MIdGroup"));
            grd_moien.ItemsSource = Set_All_User;
        }

        private void grd_moien_SelectionChanged(object sender, SelectionChangedEventArgs e) // دریافت آی دی رکورد انتخاب شده
        {
            try
            {
                AccountingMoein am = (AccountingMoein)grd_moien.SelectedItem;
                ID = am.Id.ToString();
                Class.Variable.Variables.ID_for_tarife_hesabe_tafsili = ID;
            }
            catch { }
        }
        // mnu_tarife_hesabe_tafsili
        private void mnu_tarife_hesabe_tafsili(object sender, RoutedEventArgs e)
        {
            //  MessageBox.Show("");
            /*  AccountingKernel.Forms.SotoheTafsili.frm_tarife_hesabe_tafsili ths = new SotoheTafsili.frm_tarife_hesabe_tafsili();
              ths.ShowDialog();*/
        }

        // mnu_modiriate_hesabe_tafsili

        private void mnu_modiriate_hesabe_tafsili(object sender, RoutedEventArgs e)
        {
           // if (ID != "")
          //  {
              /*  AccountingKernel.Class.Variable.Variables.idAccountingMoien = ID;
                AccountingKernel.Forms.SotoheTafsili.frm_modiriate_hesabe_tafsili fht = new SotoheTafsili.frm_modiriate_hesabe_tafsili();
                fht.ShowDialog();
              */
         //   }
         //   else
         //   {
         //       MessageBox.Show("معینی انتخاب نشده است", "خطا", MessageBoxButton.OK, MessageBoxImage.Warning);
         //   }
        }

        private void mnu_edit_Click_1(object sender, RoutedEventArgs e) // ویرایش رکورد
        {
            try
            {
                if (grd_moien.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);


                var dlg_1 = new dlg_detail((grd_moien.SelectedValue as dynamic).Id);
                dlg_1.ShowDialog();
                grd_moien.ItemsSource = Business.GetAccountingMoeinBusiness().GetAll().OrderBy(i => i.MName).ToList();

            }
            catch 
            {
                
                throw;
            }
            //dlg_moienEdit dlgMoienEdit = new dlg_moienEdit();

            //if (ID != "")
            //{
            //    get_set_moien_id.moien_id_ = ID;
            //    dlgMoienEdit.ShowDialog();
            //    this.InvalidateVisual();


            //   /* ListCollectionView Set_All_User = new ListCollectionView(Business.GetAccountingMoeinBusiness().GetAll().OrderBy(i => i.MName).ToList());
            //    Set_All_User.GroupDescriptions.Add(new PropertyGroupDescription("MIdGroup"));
            //    grd_moien.ItemsSource = Set_All_User;
            //    grd_moien.ItemsSource = Business.GetAccountingMoeinBusiness().GetAll().OrderBy(i => i.MName).ToList();*/

            //    grd_moien.ItemsSource = ak.AccountingMoeins.OrderBy(i => i.MName).ToList();

            //}
            //else
            //{
            //    MessageBox.Show("مقداری جهت ویرایش یافت نشده است", "خطا", MessageBoxButton.OK, MessageBoxImage.Warning);
            //}

        }
        private void mnu_rem_Click_1(object sender, RoutedEventArgs e) // حذف رکورد
        {
            if (ID != "")
            {
                MessageBoxResult m = MessageBox.Show("آیا مایل به حذف رکورد میباشید" + Environment.NewLine + "تمامی زیر مجموعه ها حذف خواهند شد", "حذف رکورد", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (m == MessageBoxResult.Yes)
                {
                    // first delete from accounting Moien DEtatils 

                    delete_from_accountinGMoiensDetail(Guid.Parse(ID));

                    ///

                    Guid selectedID = Guid.Parse(ID);
                    var moi = Business.GetAccountingMoeinBusiness().GetById(selectedID);
                    Business.GetAccountingMoeinBusiness().Delete(moi);

                    delete_null_value_from_accountinGMoiensDetail();
                    Guid PID_ = System.Guid.Parse(ID);
                    grd_moien.ItemsSource = Business.GetAccountingMoeinBusiness().GetAll().OrderBy(i => i.MName).ToList();

                    ID = "";
                }
            }
            else
            {
                MessageBox.Show("مقداری جهت حذف یافت نشده است", "حذف رکورد", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
        private void mnu_reg_Click_1(object sender, RoutedEventArgs e) // ثبت رکورد
        {
            dlg_detail dlg_1 = new dlg_detail();
            dlg_1.ShowDialog();
            grd_moien.ItemsSource = Business.GetAccountingMoeinBusiness().GetAll().OrderBy(i => i.MName).ToList();
        }
        //  mnu_tarif_sotohe_tafsili
        private void mnu_tarif_sotohe_tafsili(object sender, RoutedEventArgs e) // ثبت رکورد
        {
            /*   string getID = ID;
            AccountingKernel.Forms.SotoheTafsili.frm_taien_sotohe_tafsili frm_sathe_tafsili = new
            SotoheTafsili.frm_taien_sotohe_tafsili();

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
            }
            */

        }

        private void delete_null_value_from_accountinGMoiensDetail() // hazfe record dar jadvale accounting moien details
        {
            var akm = Business.GetAccountingMoeinDetailBusiness().GetAll().Where(r => r.IdAccountingMoein == null).ToList();
            foreach (var item in akm)
            {
                Business.GetAccountingMoeinDetailBusiness().Delete(item);
            }

        }

        private void delete_from_accountinGMoiensDetail(Guid ID) // hazfe record dar jadvale accounting moien details
        {
            List<AccountingMoeinDetail> akm = Business.GetAccountingMoeinDetailBusiness().GetAll().Where(r => r.IdAccountingMoein == ID).ToList();
            foreach (var item in akm)
            {
                Business.GetAccountingMoeinDetailBusiness().Delete(item);
            }


        }

        private void mnu_taien_sotohe_tafsili(object sender, RoutedEventArgs e)
        {
            if (ID != "")
            {
                AccountingKernel.Class.Variable.Variables.idAccountingMoien = ID;
                Forms.SotoheTafsili.frm_taien_sotohe_tafsili tst = new SotoheTafsili.frm_taien_sotohe_tafsili();
                tst.ShowDialog();
            }
            else
            {
                MessageBox.Show("معینی انتخاب نشده است");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
                 //StiReport st = GetReport();
                 //st.Show();                 
        }

        //private StiReport GetReport()
        //{
        //    StiReport report = new StiReport();
        //    if (File.Exists("D:\\stiReport1.mrt"))
        //    {
        //        report.Load("D:\\stiReport1.mrt");
        //    }
           
        //    var query = (from p in ak.AccountingMoeins select p).ToList();
           
        //    report.RegData("test",query);
        //    report.Dictionary.Synchronize();

        //    return report;
        //}


    }
}
