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

namespace AccountingKernel.Forms.MmoienCode
{
    /// <summary>
    /// Interaction logic for dlg_moienEdit.xaml
    /// </summary>
    /// 

    public class get_set_moien_id
    {
        
        public static string moien_id_;

        /*public string get_set_moien_id_
        {
            get { return get_set_moien_id_; }
            set { get_set_moien_id_ = value; }
        }*/
    }

    public partial class dlg_moienEdit : Window
    {
        Class.UI.TextHandeler c = new Class.UI.TextHandeler();
        Guid guide_grouh_code = Common.Constants.CodeTitle.Goruh;
        Guid guide_kol_code = Common.Constants.CodeTitle.Kol;
        Guid guide_moien_code = Common.Constants.CodeTitle.Moein;

        AccountingKernelEntities10 ak1 = new AccountingKernelEntities10();
        string get_moien_id = "";
        public dlg_moienEdit()
        {
            InitializeComponent();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            get_moien_id = get_set_moien_id.moien_id_;
            /////////////////////////////////////////////////////////////////////////////////////////////////////   نمایش اطلاعات 
            Guid gg = Guid.Parse(get_moien_id);
            List<AccountingMoeinDetail> get_data_form_acm = ak1.AccountingMoeinDetails.Where(i => i.IdAccountingMoein == gg ).ToList();

            foreach (var item in get_data_form_acm)
            {
                if (item.IdCodeTitle == guide_grouh_code)
                {
                    txt_group.Text = item.MDName;
                }

                if (item.IdCodeTitle == guide_kol_code)
                {
                    txt_all.Text = item.MDName;
                }

                if (item.IdCodeTitle == guide_moien_code)
                {
                    txt_moien.Text = item.MDName;
                }
            }
            /////////////////////////////////////////////////////////////////////////////////////////////////////

        }

        private void btn_AddToDb_Click(object sender, RoutedEventArgs e)
        {
            Guid gg = Guid.Parse(get_moien_id);

            int r = 0;
          MessageBoxResult mr =  MessageBox.Show("ایا مایل به ویرایش میباشید", "ویرایش", MessageBoxButton.YesNo, MessageBoxImage.Question);

          if (mr == MessageBoxResult.Yes)
          {
           /*   List<AccountingMoeinDetail> mDname = ak1.AccountingMoeinDetails.Where(i => i.IdAccountingMoein == gg).ToList();
             
              

              foreach (var item in mDname)
              {
                  if (item.IdCodeTitle == guide_grouh_code)
                  {
                      item.MDName = txt_group.Text;
                  }

                  if (item.IdCodeTitle == guide_kol_code)
                  {
                      item.MDName = txt_all.Text;
                  }

                  if (item.IdCodeTitle == guide_moien_code)
                  {
                      item.MDName = txt_moien.Text;
                  }
              } */

              List<AccountingMoeinDetail> mDname = ak1.AccountingMoeinDetails.Where(i => i.IdCodeTitle == guide_grouh_code).ToList();
              
                            
              foreach (var item in mDname)
              {
                 
                      item.MDName = txt_group.Text;
                      r += ak1.SaveChanges();

              }






              //ak1.SaveChanges();
             
             //r += ak1.SaveChanges();
          }

          if (mr == MessageBoxResult.Yes)
          {
           /*   AccountingMoein MoienTable = ak1.AccountingMoeins.First(i => i.Id == gg);
              MoienTable.MName = txt_moien.Text;
               r += ak1.SaveChanges();
              */

              List<AccountingMoein> mDname = ak1.AccountingMoeins.Where(i => i.Id == guide_grouh_code).ToList();


              foreach (var item in mDname)
              {

                  item.MName = txt_moien.Text;
                  item.MIdAll = txt_all.Text;
                  item.MIdGroup = txt_group.Text;

                  r += ak1.SaveChanges();
              }


             // r += ak1.SaveChanges();
          }


          if (r > 1)
          {
              this.Hide();
          }

        }

        private void txt_group_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.JustPersian(e);    
        }

        private void txt_all_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.JustPersian(e);
        }

        private void txt_moien_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.JustPersian(e);
        }

   

    }
}
