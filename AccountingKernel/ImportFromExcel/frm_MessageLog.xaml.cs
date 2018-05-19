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

namespace AccountingKernel.ImportFromExcel
{
    /// <summary>
    /// Interaction logic for frm_MessageLog.xaml
    /// </summary>
    public partial class frm_MessageLog : Window
    {
        public frm_MessageLog()
        {
            InitializeComponent();

     
        }
        public frm_MessageLog(string [] log_array)
        {
            InitializeComponent();

            var gridView = new GridView();
            this.lst_MessageLog.View = gridView;


            gridView.Columns.Add(new GridViewColumn
            {
                Header = "               وضعیت             ",
                DisplayMemberBinding = new Binding("status"),

            });

            gridView.Columns.Add(new GridViewColumn
            {
                Header = "             نام کالا             ",
                DisplayMemberBinding = new Binding("name_kala"),

            });

            gridView.Columns.Add(new GridViewColumn
            {
                Header = "           گروه فرعی             ",
                DisplayMemberBinding = new Binding("grouhe_fari")
            });

            gridView.Columns.Add(new GridViewColumn
            {
                Header = "           گروه اصلی             ",
                DisplayMemberBinding = new Binding("grouhe_asli"),
                Width = 150 
            });
            

            for ( int i = 0 ; i<= log_array.Length - 1 ; i++ )
            {
                string[] get_detail_ = log_array[i].Split(',');
                this.lst_MessageLog.Items.Add(new MyItem { grouhe_asli = get_detail_[0], grouhe_fari = get_detail_[1], name_kala = get_detail_[2], status = get_detail_[3] });
            }

        }

     /*   private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("");            
            //lst_MessageLog.Items.
        }
     */

    }

    public class MyItem
    {
        public string grouhe_asli { get; set; }

        public string grouhe_fari { get; set; }

        public string name_kala { get; set; }

        public string status { get; set; }
    }
}
