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

namespace AccountingKernel.Forms.Bills.WarehouseReceipts
{
    /// <summary>
    /// Interaction logic for Document.xaml
    /// </summary>
    public partial class FrmReceiptManagment : Window
    {
        string[,] ss;
        int cc; 

        public Guid? StoreOrderId;

        public FrmReceiptManagment()
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

                var stores = storesBusiness.GetAll();
                var storeOrders = storeOrderBusiness.GetByStoreOperation(Common.Constants.StoreOperation.WarehouseReceipts).Where(r => r.OIsDeleted == false);
                var storeDetails = storeOrderDetailBusiness.GetAll();
                var repositories = Business.GetBaseInfoBusiness().IQGetByType(Common.Constants.BaseInfoType.Repository);

                var companies = Business.GetComBusiness().GetAll();

                var tt = stores.Join(storeDetails, o => o.Id, i => i.IdStoreS, (o, i) => new { StoreS = o, StoreDetails = i });
                var storesJstoreDetails = repositories.Join(tt,
                    o => o.Id, i => i.StoreS.Sname, (o, i) => new { repositories = o, stores = i });

                var storeOrdersJcompanies = storeOrders.Join(companies, o => o.IdCompany, i => i.Id,
                    (o, i) => new { StoreOrder = o, Company = i });

                var jResult = storeOrdersJcompanies.Join(storesJstoreDetails, o => o.StoreOrder.Id, i => i.stores.StoreDetails.IdStoreOrder, (o, i) => new
                {
                    storeOrdersJcompanies = o,
                    storesJstoreDetails = i
                });
                if (txtSearch.Text != string.Empty)
                    jResult = jResult.Where(r => r.storeOrdersJcompanies.StoreOrder.ODate.Contains(txtSearch.Text) ||
                                r.storeOrdersJcompanies.Company.CName.Contains(txtSearch.Text) || r.storeOrdersJcompanies.StoreOrder.ODate.Contains(txtSearch.Text) ||
                                r.storesJstoreDetails.repositories.AssignName.Contains(txtSearch.Text));

                var vv = jResult.Select(r => new
                {
                    Id = r.storeOrdersJcompanies.StoreOrder.Id,
                    Serial = r.storeOrdersJcompanies.StoreOrder.OId,
                    RepositoryName = r.storesJstoreDetails.repositories.AssignName,
                }).ToList();
                this.DataGrid.ItemsSource = vv;   
                var v = jResult.ToList();
                cc = v.Count();
                ss = new string[cc, 2];
                int ii = 0;
                foreach (var item in vv)
                {
                    string S_H = item.Serial;
                    string N_A = item.RepositoryName;

                    ss[ii, 0] = S_H;
                    ss[ii, 1] = N_A;
                  
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

                for (int j = 0; j <=1; j++)
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
                var frmReceiptOrder = new FrmReceiptOrder(Common.Enum.FormMode.New, Common.Constants.StoreOperation.WarehouseReceipts, null);
                frmReceiptOrder.ShowDialog();
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
                var frmReceiptOrder = new FrmReceiptOrder(Common.Enum.FormMode.Edit, Common.Constants.StoreOperation.WarehouseReceipts, (DataGrid.SelectedValue as dynamic).Id);
                frmReceiptOrder.ShowDialog();
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
                //if (grdCompany.SelectedValue == null)
                //    throw new Exception(Localize.ex_no_record_selected);

                //var msgResult = MessageBox.Show(Localize.DeleteRecordMessage, Localize.DeleteRecordCaption, MessageBoxButton.YesNo, MessageBoxImage.Question);
                //if (msgResult != MessageBoxResult.Yes)
                //    return;

                //Guid id = (grdCompany.SelectedValue as dynamic).Id;

                //var companyBusiness = Business.GetCompanyBusiness();
                //var companyDetailBusiness = Business.GetCompanyDetailBusiness();
                //var company = companyBusiness.GetById(id);
                //var companyDetail = companyDetailBusiness.GetByCompanyId(company.Id);
                //companyDetailBusiness.Delete(companyDetail.ToList());
                //companyBusiness.Delete(company);

                //SetDataGrid();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void BtnExel_Click(object sender, RoutedEventArgs e)
        {
            set_to_excell(ss, cc);
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var frmReceiptOrder = new FrmReceiptOrder(Common.Enum.FormMode.New, Common.Constants.StoreOperation.WarehouseReceipts, null);
                frmReceiptOrder.ShowDialog();
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
                var frmReceiptOrder = new FrmReceiptOrder(Common.Enum.FormMode.Edit, Common.Constants.StoreOperation.WarehouseReceipts, (DataGrid.SelectedValue as dynamic).Id);
                frmReceiptOrder.ShowDialog();
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
                //if (grdCompany.SelectedValue == null)
                //    throw new Exception(Localize.ex_no_record_selected);

                //var msgResult = MessageBox.Show(Localize.DeleteRecordMessage, Localize.DeleteRecordCaption, MessageBoxButton.YesNo, MessageBoxImage.Question);
                //if (msgResult != MessageBoxResult.Yes)
                //    return;

                //Guid id = (grdCompany.SelectedValue as dynamic).Id;

                //var companyBusiness = Business.GetCompanyBusiness();
                //var companyDetailBusiness = Business.GetCompanyDetailBusiness();
                //var company = companyBusiness.GetById(id);
                //var companyDetail = companyDetailBusiness.GetByCompanyId(company.Id);
                //companyDetailBusiness.Delete(companyDetail.ToList());
                //companyBusiness.Delete(company);

                //SetDataGrid();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            var storesBusiness = Business.GetStoreSBusiness();
            var storeOrderDetailBusiness = Business.GetStoreOrderDetailBusiness();
            var storeOrderBusiness = Business.GetStoreOrderBusiness();

            var stores = storesBusiness.GetAll();
            var storeOrders = storeOrderBusiness.GetByStoreOperation(Common.Constants.StoreOperation.WarehouseReceipts).Where(r => r.OIsDeleted == false);
            var storeDetails = storeOrderDetailBusiness.GetAll();
            var repositories = Business.GetBaseInfoBusiness().IQGetByType(Common.Constants.BaseInfoType.Repository);

            var companies = Business.GetComBusiness().GetAll();

            var tt = stores.Join(storeDetails, o => o.Id, i => i.IdStoreS, (o, i) => new { StoreS = o, StoreDetails = i });
            var storesJstoreDetails = repositories.Join(tt,
                o => o.Id, i => i.StoreS.Sname, (o, i) => new { repositories = o, stores = i });

            var storeOrdersJcompanies = storeOrders.Join(companies, o => o.IdCompany, i => i.Id,
                (o, i) => new { StoreOrder = o, Company = i });

            var jResult = storeOrdersJcompanies.Join(storesJstoreDetails, o => o.StoreOrder.Id, i => i.stores.StoreDetails.IdStoreOrder, (o, i) => new
            {
                storeOrdersJcompanies = o,
                storesJstoreDetails = i
            });
            if (txtSearch.Text != string.Empty)
                jResult = jResult.Where(r => r.storeOrdersJcompanies.StoreOrder.ODate.Contains(txtSearch.Text) ||
                            r.storeOrdersJcompanies.Company.CName.Contains(txtSearch.Text) || r.storeOrdersJcompanies.StoreOrder.ODate.Contains(txtSearch.Text) ||
                            r.storesJstoreDetails.repositories.AssignName.Contains(txtSearch.Text));

            var vv = jResult.Select(r => new
            {
                Id = r.storeOrdersJcompanies.StoreOrder.Id,
                Serial = r.storeOrdersJcompanies.StoreOrder.OId,
                RepositoryName = r.storesJstoreDetails.repositories.AssignName,
            }).ToList();

            StiReport report = new StiReport();

            report.Load(@".\\Report\\Store\\FrmReceiptManagment.mrt");

            report.RegData("vv", vv);

            report.Show();
        }

    }
}
