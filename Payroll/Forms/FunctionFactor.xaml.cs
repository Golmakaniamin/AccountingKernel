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

namespace AccountingKernel.Forms
{
    /// <summary>
    /// Interaction logic for FunctionFactor.xaml
    /// </summary>
    public partial class FunctionFactor : Window
    {
        private List<Data.PayrollWorkDoneFactor> _workDoneFactor = null;

        public FunctionFactor()
        {
            InitializeComponent();
            SetGrid();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text) == false && string.IsNullOrEmpty(txtQuantity.Text) == false)
            {
                Data.PayrollWorkDoneFactor _entity = new Data.PayrollWorkDoneFactor();

                _entity.PrWFDescription = txtName.Text;
                _entity.PrWFContent = txtQuantity.Text;
                _workDoneFactor.Add(_entity);
                SetGrid();

                txtName.Text = string.Empty;
                txtQuantity.Text = string.Empty;
            }
        }

        private void SetGrid()
        {
            grdFunction.ItemsSource = null;
            if (_workDoneFactor == null)
                _workDoneFactor = Business.GetPayrollWorkDoneFactorsBussines().GetAll().ToList();
            grdFunction.ItemsSource = _workDoneFactor;
        }

        private void btnCommit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Business.GetPayrollWorkDoneFactorsBussines().Save(_workDoneFactor);
            }
            catch
            {

                throw;
            }
        }

        private void grdDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (grdFunction.SelectedValue != null)
                {
                    //foreach (var item in grdFunction.SelectedValue)
                    //{
                    //    item as PayrollWorkDoneFactorsB
                    //}
                    PayrollWorkDoneFactor DeletedItem = grdFunction.SelectedValue as PayrollWorkDoneFactor;
                    //var DeletedItem = Business.GetPayrollWorkDoneFactorsBussines().GetByID(ID);
                    Business.GetPayrollWorkDoneFactorsBussines().Delete(DeletedItem);
                    _workDoneFactor.Remove(DeletedItem);
                    SetGrid();
                }
            }
            catch
            {

                throw;
            }
        }
    }
}
