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

namespace AccountingKernel.Forms.Bills.Order
{
    /// <summary>
    /// Interaction logic for Document.xaml
    /// </summary>
    public partial class FrmOrderManagment : Window
    {
        string[,] ss;
        int cc; 

        public Guid? StoreOrderId;
        public FrmOrderManagment()
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

        /// <summary>
        /// sets store order detail data grid 
        /// </summary>
        private void SetDataGrid()
        {
            try
            {
                var storesBusiness = Business.GetStoreSBusiness();
                var storeOrderDetailBusiness = Business.GetStoreOrderDetailBusiness();
                var storeOrderBusiness = Business.GetStoreOrderBusiness();

                var storeOrders = storeOrderBusiness.GetByStoreOperation(Common.Constants.StoreOperation.WarehouseReceipts).Where(r => r.OIsDeleted == false);

                var companies = Business.GetComBusiness().GetAll();

                var storeOrdersJcompanies = storeOrders.Join(companies, o => o.IdCompany, i => i.Id,
                    (o, i) => new { StoreOrder = o, Company = i });

                var jResult = storeOrdersJcompanies.Join(storeOrders, o => o.StoreOrder.Id, i => i.Id, (o, i) => new
                {
                    storeOrdersJcompanies = o,
                    storesJstoreDetails = i
                });
                if (txtSearch.Text != string.Empty)
                    jResult = jResult.Where(r => r.storeOrdersJcompanies.StoreOrder.ODate.Contains(txtSearch.Text) ||
                                r.storeOrdersJcompanies.Company.CName.Contains(txtSearch.Text) || r.storeOrdersJcompanies.StoreOrder.ODate.Contains(txtSearch.Text));

               var vv = jResult.Select(r => new
                {
                    Id = r.storeOrdersJcompanies.StoreOrder.Id,
                    Serial = r.storeOrdersJcompanies.StoreOrder.OId,
                    CompanyCode = r.storeOrdersJcompanies.Company.CEconomyCode == string.Empty ? r.storeOrdersJcompanies.Company.CNationalCode : r.storeOrdersJcompanies.Company.CEconomyCode,
                    CompanyName = r.storeOrdersJcompanies.Company.CName,
                }).Distinct().ToList();
                 this.DataGrid.ItemsSource = vv; 
                /////////////////////
               var v = jResult.ToList();
                cc = v.Count();
                ss = new string[cc, 3];
                int ii = 0;
                foreach (var item in vv)
                {
                    string S_H = item.Serial;
                    string C_T_H = item.CompanyCode;
                    string N_T_H = item.CompanyName;

                    ss[ii, 0] = S_H;
                    ss[ii, 1] = C_T_H;
                    ss[ii, 2] = N_T_H;
                   
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
                    if (j == 0)
                        row[this.DataGrid.Columns[j + 1].Header.ToString()] = int.Parse(a[i, j].ToString());
                    else
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

        private void MenuItem_Register(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                var frmOrder = new FrmOrder(Common.Enum.FormMode.New, Common.Constants.StoreOperation.WarehouseReceipts, null);
                frmOrder.ShowDialog();
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
                var frmOrder = new FrmOrder(Common.Enum.FormMode.Edit, Common.Constants.StoreOperation.WarehouseReceipts, (DataGrid.SelectedValue as dynamic).Id);
                frmOrder.ShowDialog();
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

                var msgResult = MessageBox.Show(Localize.DeleteRecordMessage, Localize.DeleteRecordCaption, MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (msgResult != MessageBoxResult.Yes)
                    return;

                Business.GetStoreOrderBusiness().Delete(Business.GetStoreOrderBusiness().GetById((DataGrid.SelectedValue as dynamic).Id));

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
            var storesBusiness = Business.GetStoreSBusiness();
            var storeOrderDetailBusiness = Business.GetStoreOrderDetailBusiness();
            var storeOrderBusiness = Business.GetStoreOrderBusiness();

            var storeOrders = storeOrderBusiness.GetByStoreOperation(Common.Constants.StoreOperation.WarehouseReceipts).Where(r => r.OIsDeleted == false);

            var companies = Business.GetComBusiness().GetAll();

            var storeOrdersJcompanies = storeOrders.Join(companies, o => o.IdCompany, i => i.Id,
                (o, i) => new { StoreOrder = o, Company = i });

            var jResult = storeOrdersJcompanies.Join(storeOrders, o => o.StoreOrder.Id, i => i.Id, (o, i) => new
            {
                storeOrdersJcompanies = o,
                storesJstoreDetails = i
            });
            if (txtSearch.Text != string.Empty)
                jResult = jResult.Where(r => r.storeOrdersJcompanies.StoreOrder.ODate.Contains(txtSearch.Text) ||
                            r.storeOrdersJcompanies.Company.CName.Contains(txtSearch.Text) || r.storeOrdersJcompanies.StoreOrder.ODate.Contains(txtSearch.Text));

            var vv = jResult.Select(r => new
            {
                Id = r.storeOrdersJcompanies.StoreOrder.Id,
                Serial = r.storeOrdersJcompanies.StoreOrder.OId,
                CompanyCode = r.storeOrdersJcompanies.Company.CEconomyCode == string.Empty ? r.storeOrdersJcompanies.Company.CNationalCode : r.storeOrdersJcompanies.Company.CEconomyCode,
                CompanyName = r.storeOrdersJcompanies.Company.CName,
            }).Distinct().ToList();


            StiReport report = new StiReport();


            report.Load(@".\\Report\\Store\\frmOrderManagment.mrt");

            report.RegData("vv", vv);

            report.Show();
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var frmOrder = new FrmOrder(Common.Enum.FormMode.New, Common.Constants.StoreOperation.WarehouseReceipts, null);
                frmOrder.ShowDialog();
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
                var frmOrder = new FrmOrder(Common.Enum.FormMode.Edit, Common.Constants.StoreOperation.WarehouseReceipts, (DataGrid.SelectedValue as dynamic).Id);
                frmOrder.ShowDialog();
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

                Business.GetStoreOrderBusiness().Delete(Business.GetStoreOrderBusiness().GetById((DataGrid.SelectedValue as dynamic).Id));

                SetDataGrid();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

    }
}
