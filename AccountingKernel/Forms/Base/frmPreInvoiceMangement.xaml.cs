using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using AccountingKernel.Common;
using System.Transactions;

namespace AccountingKernel.Forms.Bill
{
    /// <summary>
    /// Interaction logic for Document.xaml
    /// </summary>
    public partial class FrmPreInvoiceMangement : Window
    {
        public FrmPreInvoiceMangement()
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

                var iqStoreOrder = storeOrderBusiness.GetAll();
                if (txtSearch.Text != string.Empty)
                    iqStoreOrder = iqStoreOrder.Where(r => r.ODate.Contains(txtSearch.Text) ||
                                r.OSumMoney.ToString().Contains(txtSearch.Text) || r.ODiscount.ToString().Contains(txtSearch.Text) ||
                                r.OTax.ToString().Contains(txtSearch.Text) || r.OMunicipalTax.ToString().Contains(txtSearch.Text));

                var storeOrders = iqStoreOrder.Join(Business.GetCompanyBusiness().GetAll(), o => o.IdCompany, i => i.Id,
                    (o, i) => new { StoreOrder= o, Company= i}).ToList();


                DataGrid.ItemsSource = storeOrders.Select(r => new
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

        private void MenuItem_Register(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                var frmPreInvoice = new Bill.frmPreInvoice();
                frmPreInvoice.ShowDialog();
                SetDataGrid();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void MenuItem_Edit(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                if (DataGrid.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);

                Guid id;
                id = (DataGrid.SelectedValue as dynamic).Id;

                var frmPreInvoice = new Bill.frmPreInvoice(id);
                frmPreInvoice.ShowDialog();
                SetDataGrid();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void MenuItem_Delete(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                if (DataGrid.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);

                var msgResult = MessageBox.Show(Localize.DeleteRecordMessage, Localize.DeleteRecordCaption, MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                if (msgResult != MessageBoxResult.Yes)
                    return;

                Guid id = (DataGrid.SelectedValue as dynamic).Id;

                var storeOrderBusiness = Business.GetStoreOrderBusiness();
                var storeOrderDetailBusiness = Business.GetStoreOrderDetailBusiness();

                var storeOrder = storeOrderBusiness.GetById(id);
                var storeOrderDetail = storeOrderDetailBusiness.GetByStoreOrderId(storeOrder.Id).ToList();

                using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
                {
                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted,
                    Timeout = new TimeSpan(2, 0, 0)
                }))
                {
                    storeOrderDetailBusiness.Delete(storeOrderDetail);
                    storeOrderBusiness.Delete(storeOrder);

                    scope.Complete();
                }
	
                SetDataGrid();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }

        }

        private void MenuItem_EffectiveOperative(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                if (DataGrid.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);

                Guid id;
                id = (DataGrid.SelectedValue as dynamic).Id;

                var frmBillOperative = new Bill.frmBillOperative(id);
                frmBillOperative.ShowDialog();
                SetDataGrid();
    
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
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

    }
}
