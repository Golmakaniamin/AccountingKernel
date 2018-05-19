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

namespace AccountingKernel.Forms.SotoheTafsili
{
    /// <summary>
    /// Interaction logic for fehreste_grouhe_tafsili.xaml
    /// </summary>
    public partial class fehreste_grouhe_tafsili : Window
    {
        private List<Data.AccountingTafsilStructureDefine> TafsilList = Business.GetTafsilStructureDefineBusiness().NotInFilter().ToList();

        public List<Data.AccountingTafsilStructureDefine> ReturnedList = new List<Data.AccountingTafsilStructureDefine>();

        public fehreste_grouhe_tafsili()
        {
            InitializeComponent();
            SetGrid();
        }

        private void SetGrid()
        {
            grd_tafsil.ItemsSource = TafsilList.Select(r => new { Id = r.ID, TafsilName = r.Name, TafsilCode = r.Code });
        }

        private void btn_sabteTafsili_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            CheckBox s = sender as CheckBox;
            var id = (grd_tafsil.SelectedItem as dynamic).Id;
            if (s.IsChecked == true)
                ReturnedList.Add(TafsilList.Find(r => r.ID == id));
            else
                ReturnedList.Remove(TafsilList.Find(r => r.ID == id));
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnExel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
