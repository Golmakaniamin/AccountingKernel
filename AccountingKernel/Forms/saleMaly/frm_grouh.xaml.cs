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

namespace AccountingKernel.Forms.saleMaly
{
    /// <summary>
    /// Interaction logic for frm_grouh.xaml
    /// </summary>
    public partial class frm_grouh : Window
    {

        public frm_grouh()
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

        private void MenuItem_Delete(object sender, MouseButtonEventArgs e)
        {

        }

        private void MenuItem_Edit(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (grid_grouh.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);

                new frm_tarifeGrouh((grid_grouh.SelectedValue as dynamic).ID).ShowDialog();

                SetDataGrid();

            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void MenuItem_Register(object sender, MouseButtonEventArgs e)
        {
            try
            {
                new frm_tarifeGrouh().ShowDialog();

                SetDataGrid();

            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void SetDataGrid()
        {
            try
            {
                grid_grouh.ItemsSource = Business.GetCorporartionBusiness().GetAll().ToList();
            }
            catch
            {

                throw;
            }
        }

        private void MenuItem_saleMaly(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (grid_grouh.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);

                new frm_tarifeSaleMaly((grid_grouh.SelectedValue as dynamic).ID).ShowDialog();

            }
            catch
            {

                throw;
            }
        }

        private void doubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if ((grid_grouh.SelectedValue as dynamic).ID)
                    throw new Exception(Localize.ex_no_record_selected);

                pass_data.get_id_for_namayeshesSaleMaly = (grid_grouh.SelectedValue as dynamic).ID;
                new frm_namayesheSaleMaly().ShowDialog();

            }
            catch
            {

                throw;
            }
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                new frm_tarifeGrouh().ShowDialog();

                SetDataGrid();

            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (grid_grouh.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);

                new frm_tarifeGrouh((grid_grouh.SelectedValue as dynamic).ID).ShowDialog();

                SetDataGrid();

            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }
    }
}
