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

                var frmPreInvoice = new Bill.frmPreInvoice((DataGrid.SelectedValue as dynamic).Id, Constants.StoreOperation.PreInvoice);
                frmPreInvoice.Title = Localize.PreInvoiceManagment;
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


                var frmBillOperative = new Bill.frmBillOperative((DataGrid.SelectedValue as dynamic).Id, true);
                frmBillOperative.Title = Localize.StoreOrderEffectiveOperative;
                frmBillOperative.ShowDialog();
                SetDataGrid();

            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }

        }

        private void MenuItem_InEffectiveOperative(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                if (DataGrid.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);

                var frmBillOperative = new Bill.frmBillOperative((DataGrid.SelectedValue as dynamic).Id, false);
                frmBillOperative.Title = Localize.StoreOrderInEffectiveOperative;
                frmBillOperative.ShowDialog();
                SetDataGrid();

            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
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
