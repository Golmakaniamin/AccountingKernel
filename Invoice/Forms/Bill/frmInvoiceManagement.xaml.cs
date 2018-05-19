using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using AccountingKernel.Common;
using System.Transactions;
using System.Windows.Data;

namespace AccountingKernel.Forms.Bill
{
    /// <summary>
    /// Interaction logic for Document.xaml
    /// </summary>
    public partial class frmInvoiceManagement : Window
    {
        public frmInvoiceManagement()
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

        private void SetDataGrid()
        {
            try
            {
                var storeOrderDetailBusiness = Business.GetStoreOrderDetailBusiness();
                var storeOrderBusiness = Business.GetStoreOrderBusiness();

                var storeOrders = storeOrderBusiness.GetPreInvoices();

                var companies = Business.GetCompanyBusiness().GetAll();
                var jResult = storeOrders.Join(companies, o => o.IdCompany, i => i.Id,
                    (o, i) => new { StoreOrder = o, Company = i });

                if (txtSearch.Text != string.Empty)
                    jResult = jResult.Where(r => r.StoreOrder.ODate.Contains(txtSearch.Text) ||
                                r.Company.CName.Contains(txtSearch.Text) || r.StoreOrder.ODate.Contains(txtSearch.Text));

                DataGrid.ItemsSource = jResult.Select(r => new
                {
                    Id = r.StoreOrder.Id,
                    CompanyName = r.Company.CName,
                    Date = r.StoreOrder.ODate,
                    Code = r.StoreOrder.OId,
                }).ToList();


            }
            catch
            {

                throw;
            }
        }

        private void txtSearch_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
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

        private void MenuItem_IssueSaleInvoice(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                if (DataGrid.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);

                var frmPreInvoice = new Bill.frmPreInvoice((DataGrid.SelectedValue as dynamic).Id, Constants.StoreOperation.SaleInvoice);
                frmPreInvoice.Title = Localize.SaleInvoice;
                frmPreInvoice.ShowDialog();
                SetDataGrid();

            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }

        }
    }
}
