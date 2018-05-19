using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Common;
using System.Transactions;
using System.Windows.Data;
using System.Data;
using Stimulsoft.Report;

namespace AccountingKernel.Forms.Bills.PreSaleInvoice
{
    /// <summary>
    /// Interaction logic for Document.xaml
    /// </summary>
    public partial class FrmPreSaleInvoiceManagement : Window
    {
        string[,] ss;
        int cc; 

        public Guid? StoreOrderId;

        public FrmPreSaleInvoiceManagement()
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

                var storeOrders = storeOrderBusiness.GetByStoreOperation(Common.Constants.StoreOperation.PreSaleInvoice);

                var companies = Business.GetComBusiness().GetAll();
                var jResult = storeOrders.Join(companies, o => o.IdCompany, i => i.Id,
                    (o, i) => new { StoreOrder = o, Company = i });

                if (txtSearch.Text != string.Empty)
                    jResult = jResult.Where(r => r.StoreOrder.ODate.Contains(txtSearch.Text) ||
                                r.Company.CName.Contains(txtSearch.Text) || r.StoreOrder.ODate.Contains(txtSearch.Text));

                var vv = jResult.Select(r => new
                {
                    Id = r.StoreOrder.Id,
                    CompanyName = r.Company.CName,
                    Date = r.StoreOrder.ODate,
                    Code = r.StoreOrder.OId

                }).ToList();
                
                   

                this.DataGrid.ItemsSource = vv;
                /////////////////////////////////////////////////////////////
                var v = jResult.ToList();
                cc = v.Count();
                ss = new string[cc, 3];
                int ii = 0;
                foreach (var item in vv)
                {
                    string N_M = item.CompanyName;
                    string Ta = item.Date;
                    string Sh = item.Code;

                    ss[ii, 0] = N_M;
                    ss[ii, 1] = Ta;
                    ss[ii, 2] = Sh;
                   
                    ii++;
                }      
            }
            catch
            {

                throw;
            }
        }
        private void set_to_excell(string[,] a, int rowC)
        {
            ExcelImpExp.ExportToExcel exp = new ExcelImpExp.ExportToExcel();
            var table = new System.Data.DataTable();


            table = exp.get_dataGridColumnNames(DataGrid);

            for (int i = 0; i <= rowC - 1; i++)
            {
                var row = table.NewRow();
                /*
                row[this.grid_asnad.Columns[i + 1].Header.ToString()] = int.Parse(a[i, 0].ToString());
                row[this.grid_asnad.Columns[i + 1].Header.ToString()] = a[i, 1];
                row[this.grid_asnad.Columns[i + 1].Header.ToString()] = a[i, 2];
                row[this.grid_asnad.Columns[i + 1].Header.ToString()] = a[i, 3];
               */

                for (int j = 0; j <= 2; j++)
                {
                   // if (j == 0)
                        //row[this.DataGrid.Columns[j + 1].Header.ToString()] = int.Parse(a[i, j].ToString());
                    //else
                        row[this.DataGrid.Columns[j + 1].Header.ToString()] = a[i, j];
                }

                table.Rows.Add(row);
            }


            DataSet ds = new DataSet("New_DataSet");
            ds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;
            ds.Tables.Add(table);
            exp.showStuff(ds);

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

                var frmPreInvoice = new Bills.SaleInvoice.FrmSaleInvoice(Common.Enum.FormMode.New, (DataGrid.SelectedValue as dynamic).Id, Constants.StoreOperation.SaleInvoice);
                frmPreInvoice.Title = Localize.SaleInvoice;
                frmPreInvoice.ShowDialog();
                SetDataGrid();

            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }

        }

        private void MenuItem_NewClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                var frmPreInvoice = new Bills.PreSaleInvoice.FrmPreSaleInvoice(Common.Enum.FormMode.New, null, Constants.StoreOperation.PreSaleInvoice);
                frmPreInvoice.Title = Localize.PreInvoiceManagment;
                frmPreInvoice.ShowDialog();
                SetDataGrid();

            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }

        }

        private void MenuItem_EditClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                if (DataGrid.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);

                var frmPreInvoice = new Bills.PreSaleInvoice.FrmPreSaleInvoice(Common.Enum.FormMode.Edit, (DataGrid.SelectedValue as dynamic).Id, Constants.StoreOperation.PreSaleInvoice);
                frmPreInvoice.Title = Localize.PreInvoiceManagment;
                frmPreInvoice.ShowDialog();
                SetDataGrid();

            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }

        }

        private void MenuItem_DeleteClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                if (DataGrid.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);

                var msgResult = MessageBox.Show(Localize.DeleteRecordMessage, Localize.DeleteRecordCaption, MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (msgResult != MessageBoxResult.Yes)
                    return;

                var preInvoice = Business.GetStoreOrderBusiness().GetById((DataGrid.SelectedValue as dynamic).Id);
                Business.GetStoreOrderBusiness().Delete(preInvoice);
                SetDataGrid();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }

        }

        private void DataGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                if (DataGrid.SelectedValue != null)
                    StoreOrderId = (DataGrid.SelectedValue as dynamic).Id;
                this.Close();
            }
            catch
            {

                throw;
            }

        }

        private void BtnExel_Click(object sender, RoutedEventArgs e)
        {
            set_to_excell(ss, cc);
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            var storeOrderDetailBusiness = Business.GetStoreOrderDetailBusiness();
            var storeOrderBusiness = Business.GetStoreOrderBusiness();
            var storeOrders = storeOrderBusiness.GetByStoreOperation(Common.Constants.StoreOperation.PreSaleInvoice);
            var companies = Business.GetComBusiness().GetAll();
            var jResult = storeOrders.Join(companies, o => o.IdCompany, i => i.Id,
                (o, i) => new { StoreOrder = o, Company = i });

            if (txtSearch.Text != string.Empty)
                jResult = jResult.Where(r => r.StoreOrder.ODate.Contains(txtSearch.Text) ||
                            r.Company.CName.Contains(txtSearch.Text) || r.StoreOrder.ODate.Contains(txtSearch.Text));

            var vv = jResult.Select(r => new
            {
                Id = r.StoreOrder.Id,
                CompanyName = r.Company.CName,
                Date = r.StoreOrder.ODate,
                Code = r.StoreOrder.OId

            }).ToList();

            StiReport report = new StiReport();

            report.Load(@".\\Report\\Sale\\FrmPreSaleInvoiceManagement.mrt");

            report.RegData("vv", vv);

            report.Show();
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var frmPreInvoice = new Bills.PreSaleInvoice.FrmPreSaleInvoice(Common.Enum.FormMode.New, null, Constants.StoreOperation.PreSaleInvoice);
                frmPreInvoice.Title = Localize.PreInvoiceManagment;
                frmPreInvoice.ShowDialog();
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
                if (DataGrid.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);

                var frmPreInvoice = new Bills.PreSaleInvoice.FrmPreSaleInvoice(Common.Enum.FormMode.Edit, (DataGrid.SelectedValue as dynamic).Id, Constants.StoreOperation.PreSaleInvoice);
                frmPreInvoice.Title = Localize.PreInvoiceManagment;
                frmPreInvoice.ShowDialog();
                SetDataGrid();

            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DataGrid.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);

                var msgResult = MessageBox.Show(Localize.DeleteRecordMessage, Localize.DeleteRecordCaption, MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (msgResult != MessageBoxResult.Yes)
                    return;

                var preInvoice = Business.GetStoreOrderBusiness().GetById((DataGrid.SelectedValue as dynamic).Id);
                Business.GetStoreOrderBusiness().Delete(preInvoice);
                SetDataGrid();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }
    }
}
