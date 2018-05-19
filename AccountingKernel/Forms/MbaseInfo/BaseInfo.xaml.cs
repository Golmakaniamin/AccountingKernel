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
using AccountingKernel;
using Data;

namespace AccountingKernel.Forms.MbaseInfo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class FrmBaseInfo : Window
    {
        Class.UI.TextHandeler c = new Class.UI.TextHandeler();
        AccountingKernelEntities10 ak1 = new AccountingKernelEntities10();
        string ID = "";
        string selected_id = "";

        public FrmBaseInfo()
        {
            InitializeComponent();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            
        }

        private void grd_companyParent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                BaseInfo b = (BaseInfo)grd_companyParent.SelectedItem;

                ID = b.Id.ToString();

                Guid PID_ = System.Guid.Parse(ID);
                grd_childC.ItemsSource = ak1.BaseInfoes.Where(a => a.PID == PID_).ToList();

            }
            catch { }
        }

        private void btn_saveToDB_Click(object sender, RoutedEventArgs e)
        {
            if (txt_name.Text.Trim() != "" && txt_name_Copy.Text.Trim() != "")
            {
                if (ID != "")
                {
                    BaseInfo tbl_baseInfo = new BaseInfo
                    {
                        AssignName = txt_name.Text,
                        Explain = txt_name_Copy.Text,
                        PID = System.Guid.Parse(ID),
                        Id = Guid.NewGuid()
                    };

                    ak1.BaseInfoes.Add(tbl_baseInfo);
                    ak1.SaveChanges();

                    Guid PID_ = System.Guid.Parse(ID);
                    grd_childC.ItemsSource = ak1.BaseInfoes.Where(a => a.PID == PID_).ToList();
                }
                else
                {
                    MessageBox.Show("گروه اصلی را انتخاب نمایید", "خطا", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("تمامی مقادیر الزامی میباشد", "خطا", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        private void grd_childC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
               BaseInfo b = (BaseInfo)grd_childC.SelectedItem;
       
            selected_id = b.Id.ToString();
            }
            catch
            { }

            //this.txt_name.Text = selected_id + "";
        }

        private void grd_childC_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            int r = 0;
     
            FrameworkElement element_1 = grd_childC.Columns[2].GetCellContent(e.Row);
            if (element_1.GetType() == typeof(TextBox))
            {
                var Explain_ = ((TextBox)element_1).Text;
                Guid selectedID = Guid.Parse(selected_id);
                BaseInfo b = ak1.BaseInfoes.First(i => i.Id == selectedID);
                b.Explain = Explain_;

               r+= ak1.SaveChanges();
              
            }
            FrameworkElement element_2 = grd_childC.Columns[1].GetCellContent(e.Row);
            if (element_1.GetType() == typeof(TextBox))
            {
                var an = ((TextBlock)element_2).Text;
                Guid selectedID = Guid.Parse(selected_id);
                BaseInfo b = ak1.BaseInfoes.First(i => i.Id == selectedID);
                b.AssignName = an;
                
              r+=  ak1.SaveChanges();

            }


            if (r > 1)
            {
                MessageBox.Show("تغییرات با موفقیت ذخیره شد","ثبت داده ها",MessageBoxButton.OK,MessageBoxImage.Information);
            }

        }

        private void menu100_Click_1(object sender, RoutedEventArgs e)
        {              
                 if (selected_id != "")
                 {
                     MessageBoxResult m = MessageBox.Show("آیا مایل به حذف رکورد میباشید", "حذف رکورد", MessageBoxButton.YesNo, MessageBoxImage.Question);
                     if (m == MessageBoxResult.Yes)
                     {
                         Guid selectedID = Guid.Parse(selected_id);
                        BaseInfo b = ak1.BaseInfoes.First(i => i.Id == selectedID);
                         ak1.BaseInfoes.Remove(b);
                         ak1.SaveChanges();
                         Guid PID_ = System.Guid.Parse(ID);
                         grd_childC.ItemsSource = ak1.BaseInfoes.Where(a => a.PID == PID_).ToList();

                         selected_id = "";
                     }
          
                 }
                 else
                 {
                     MessageBox.Show("مقداری جهت حذف یافت نشده است", "حذف رکورد", MessageBoxButton.OK, MessageBoxImage.Warning);
                 }

        }
        private void Grid_GotFocus_1(object sender, RoutedEventArgs e)
        {
           
        }

        private void Grid_Initialized_1(object sender, EventArgs e)
        {
       
                grd_companyParent.ItemsSource = ak1.BaseInfoes.Where(a => a.PID == null).ToList();
            
        }

        private void DataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txt_name_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
          
        }

        private void txt_name_Copy_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.JustEnglish(e);
        }
    }
}
