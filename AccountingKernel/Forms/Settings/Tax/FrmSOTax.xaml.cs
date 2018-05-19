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

namespace AccountingKernel.Forms.Settings.Tax
{
    /// <summary>
    /// Interaction logic for frm_tarife_toole_code.xaml
    /// </summary>
    public partial class FrmSOTax : Window
    {
        public FrmSOTax()
        {
            try
            {
                InitializeComponent();
                SetDataGrid();
            }
            catch
            {

                throw;
            }
        }

        public class DataGridEntity
        {
            public Guid Id { get; set; }
            public string BaseInfoTitle { get; set; }
            public string FinancialMainYear { get; set; }
            public string Percent { get; set; }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
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

        private void SetDataGrid()
        {
            try
            {
                grd_SOTax.ItemsSource = Business.GetSOTaxBusiness().GetViewAll().ToList().Select(r => new DataGridEntity()
                {
                    Id = r.Id,
                    BaseInfoTitle = r.AssignName,
                    FinancialMainYear = r.FYear.ToString(),
                    Percent = r.Percent.ToString()
                }).ToList();

            }
            catch
            {

                throw;
            }
        }

        private void MenuItem_Register(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                var frmRegisterSOTax = new FrmRegisterSOTax();
                frmRegisterSOTax.ShowDialog();
                SetDataGrid();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }

        }

        private void meunitem_register_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var frmRegSOTax = new FrmRegisterSOTax();
                frmRegSOTax.ShowDialog();
                SetDataGrid();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void meunitem_edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void meunitem_delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }


    }
}
