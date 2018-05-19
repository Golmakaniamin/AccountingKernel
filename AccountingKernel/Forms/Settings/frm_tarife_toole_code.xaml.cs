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

namespace AccountingKernel.Forms.Settings
{
    /// <summary>
    /// Interaction logic for frm_tarife_toole_code.xaml
    /// </summary>
    public partial class frm_tarife_toole_code : Window
    {
        public frm_tarife_toole_code()
        {
            InitializeComponent();
        }

        public class DataGridEntity
        {
            public Guid Id { get; set; }
            public string CodeName { get; set; }
            public int? CodeLen { get; set; }
            public int? CodeStart { get; set; }
        }

        private void DataGrid_Initialized_1(object sender, EventArgs e)
        {
            try
            {
                SetDataGrid();
            }
            catch
            {

                throw;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                var codeTitles = Business.GetCodeTitleBusiness().GetAll().ToList();
                for (int i = 0; i < grd_codeTitle.Items.Count; i++)
                {
                    var item = (DataGridEntity)grd_codeTitle.Items[i];
                    var codeTitle = codeTitles.Find(r => r.Id == item.Id);

                    if (codeTitle.CodeStart == null)
                        codeTitle.CodeStart = item.CodeStart;
                }

                Business.GetCodeTitleBusiness().SubmitChanges();
                SetDataGrid();
            }
            catch
            {

                throw;
            }
        }

        private void SetDataGrid()
        {
            try
            {
                grd_codeTitle.ItemsSource = Business.GetCodeTitleBusiness().GetAll().Select(r => new DataGridEntity()
                {
                    Id = r.Id,
                    CodeName = r.CodeName,
                    CodeLen = r.CodeLen,
                    CodeStart = r.CodeStart
                }).ToList();

            }
            catch 
            {
                
                throw;
            }
        }


    }
}
