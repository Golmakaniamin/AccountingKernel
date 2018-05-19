using System;
using System.Collections.Generic;
using System.Data.Metadata.Edm;
using System.Data.Objects;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AccountingKernel.Report
{
    /// <summary>
    /// Interaction logic for frm_report.xaml
    /// </summary>
    /// 
    public partial class frm_report : Window
    {


        Data.AccountingKernelEntities10 ak = new Data.AccountingKernelEntities10();
        private System.Data.Entity.DbSet<Data.Check> dbSet;

        public frm_report()
        {
            InitializeComponent();
        }
        public frm_report(IQueryable a)
        {
                       
            InitializeComponent();
        }

        public frm_report(string [] column_names , string [] columns_type)
        {

            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
         
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            


           
            /*ComboBox cmb = new ComboBox();
            cmb.Width = 50;
            cmb.Height = 20;

            cmb.Margin = new Thickness(500, 50, 5, 2);
            canvas.Children.Add(cmb);*/

           /* ComboBox[] cmb = new ComboBox[50];
            Label[] lbl = new Label[50];
            for (int i = 0; i < cmb.Length; i++)
            {
                cmb[i] = new ComboBox();
                cmb[i].Width = 100;
                cmb[i].Height = 30;
                cmb[i].Margin = new Thickness(canvas.Width - 200, 10, 0, 0);
                canvas.Children.Add(cmb[i]);
            }*/

        }

  

    }
}
