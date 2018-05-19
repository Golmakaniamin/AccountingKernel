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
using Data;

namespace AccountingKernel.Forms.Bills.PurchaseInvoice
{
    /// <summary>
    /// Interaction logic for Document.xaml
    /// </summary>
    public partial class FrmPurchaseInvoiceManagement : Window
    {
        string[,] ss;
        int cc; 

        public Guid? StoreOrderId;

        public FrmPurchaseInvoiceManagement()
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
                Guid CUstomerID = Guid.Parse("b07b682c-4507-4d55-8e5d-7543bc53159e");
                var storeOrderDetailBusiness = Business.GetStoreOrderDetailBusiness();
                var storeOrderBusiness = Business.GetStoreOrderBusiness();

                var storeOrders = storeOrderBusiness.GetByStoreOperation(Common.Constants.StoreOperation.PurchaseInvoice).Where(r => r.OIsDeleted == false);
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
                    Code = r.StoreOrder.OId,
                    cType = r.Company.CType

                }).ToList();//.OrderByDescending(r => r.Date).ThenByDescending(r => r.Code).ToList();
                this.DataGrid.ItemsSource =  vv.Where( i => i.cType == CUstomerID ).ToList();
                ///////////////////////////////////////////////////////
                var v = jResult.ToList();
                cc = v.Count();
                ss = new string[cc,3];
                int ii = 0;
                foreach (var item in vv)
                {
                    string N_T_K = item.CompanyName;
                    string T_F = item.Date;
                    string Sh_F = item.Code;

                    ss[ii, 0] = N_T_K;
                    ss[ii, 1] = T_F;
                    ss[ii, 2] = Sh_F;
                   
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

                for (int j = 0; j <=2; j++)
                {
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
                var frmPurcahseInvoice = new Bills.PurchaseInvoice.FrmPurchaseInvoice(Common.Enum.FormMode.New, Constants.StoreOperation.PurchaseInvoice);
                frmPurcahseInvoice.Title = Localize.PurchaseInvoice;
                frmPurcahseInvoice.ShowDialog();
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

                var frmPurcahseInvoice = new Bills.PurchaseInvoice.FrmPurchaseInvoice(Common.Enum.FormMode.Edit, (DataGrid.SelectedValue as dynamic).Id, Constants.StoreOperation.PurchaseInvoice);
                frmPurcahseInvoice.Title = Localize.PurchaseInvoice;
                frmPurcahseInvoice.ShowDialog();
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

                Guid id = (DataGrid.SelectedValue as dynamic).Id;

                var storeOrderBusiness = Business.GetStoreOrderBusiness();
                var storeOrderDetailBusiness = Business.GetStoreOrderDetailBusiness();

                var storeOrder = storeOrderBusiness.GetById(id);

                using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
                {
                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted,
                    Timeout = new TimeSpan(2, 0, 0)
                }))
                {
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

        private void DataGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                if (DataGrid.SelectedValue == null)
                    return;

                this.StoreOrderId = (DataGrid.SelectedValue as dynamic).Id;
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

            var storeOrders = storeOrderBusiness.GetByStoreOperation(Common.Constants.StoreOperation.PurchaseInvoice).Where(r => r.OIsDeleted == false);

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
                Code = r.StoreOrder.OId,
            }).OrderByDescending(r => r.Date).ThenByDescending(r => r.Code).ToList();

            StiReport report = new StiReport();

            report.Load(@"D:\New folder (2)\accountingKernel\AccountingKernel\Debug_AccountingKernel\Report\frmPurchaseInvoiceManagement.mrt");

            report.RegData("vv", vv);

            report.Show();
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var frmPurcahseInvoice = new Bills.PurchaseInvoice.FrmPurchaseInvoice(Common.Enum.FormMode.New, Constants.StoreOperation.PurchaseInvoice);
                frmPurcahseInvoice.Title = Localize.PurchaseInvoice;
                frmPurcahseInvoice.ShowDialog();
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

                var frmPurcahseInvoice = new Bills.PurchaseInvoice.FrmPurchaseInvoice(Common.Enum.FormMode.Edit, (DataGrid.SelectedValue as dynamic).Id, Constants.StoreOperation.PurchaseInvoice);
                frmPurcahseInvoice.Title = Localize.PurchaseInvoice;
                frmPurcahseInvoice.ShowDialog();
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

                Guid id = (DataGrid.SelectedValue as dynamic).Id;

                var storeOrderBusiness = Business.GetStoreOrderBusiness();
                var storeOrderDetailBusiness = Business.GetStoreOrderDetailBusiness();

                var storeOrder = storeOrderBusiness.GetById(id);

                using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
                {
                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted,
                    Timeout = new TimeSpan(2, 0, 0)
                }))
                {
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

        AccountingKernelEntities10 ak = new AccountingKernelEntities10();
        private void Report_Click_1(object sender, RoutedEventArgs e)
        {
            var GetOnRow = DataGrid.SelectedItem as dynamic;//Choice a row when if click
            Guid RowId = GetOnRow.Id;//When click Buttone in row, give me the 1 unique ID      
           


            //var q = from Goodies in ak.Goodies
            //        join StoreOrderDetails in ak.StoreOrderDetails on Goodies.ID equals StoreOrderDetails.IdCommodity
            //        join StoreOrders in ak.StoreOrders on StoreOrderDetails.IdStoreOrder equals StoreOrders.Id
            //        join coms in ak.Coms on StoreOrders.IdCompany equals coms.Id

            //        select new
            //        {
            //            coms.CName,
            //            coms.CNationalCode,
            //            coms.CRegisterNo,
            //            coms.CTell,
            //            coms.CType,
            //            coms.CAddress,
            //            coms.CPostalCode,
            //            coms.CEconomyCode,
            //            StoreOrders.Id,
            //            StoreOrders.OTax,
            //            StoreOrders.ODate,
            //            StoreOrderDetails.ODCount,
            //            StoreOrderDetails.ODMoney,
            //            StoreOrderDetails.ODDiscount,
            //            StoreOrders.OId
            //            //  Goodies.ID,

            //            //   Goodies.CName

            //        };


            Guid CUstomerID = Guid.Parse("b07b682c-4507-4d55-8e5d-7543bc53159e");
            var comStoreOrders = from storeorders in ak.StoreOrders
                          join coms in ak.Coms on storeorders.IdCompany equals coms.Id
                          select new
                          {
                             cname= coms.CName,
                              coms.CNationalCode,
                              coms.CRegisterNo,
                              coms.CTell,
                              coms.CType,
                              coms.CAddress,
                              coms.CPostalCode,
                              coms.CEconomyCode,
                              storeorders.Id,
                              storeorders.OTax,
                              storeorders.ODate,
                              storeId = storeorders.Id,
                              storeorders.OSumMoney
                          };
            comStoreOrders = comStoreOrders.Where(i => i.CType == CUstomerID);
            var comStoreOrdersFilter = comStoreOrders.Where(i => i.storeId == RowId);
            var comStoreOrdersFilterSD = from comStoreOrdersFilters in comStoreOrdersFilter join SD in ak.StoreOrderDetails
                                         on comStoreOrdersFilters.storeId equals SD.IdStoreOrder
                                         select new 
                                         { 
                                             comStoreOrdersFilters.cname,
                                             comStoreOrdersFilters.CAddress,
                                             comStoreOrdersFilters.CEconomyCode, 
                                             comStoreOrdersFilters.CNationalCode,
                                             comStoreOrdersFilters.CPostalCode, 
                                             comStoreOrdersFilters.CRegisterNo,
                                             comStoreOrdersFilters.CTell, 
                                             comStoreOrdersFilters.CType,
                                             comStoreOrdersFilters.storeId,
                                             SD.IdCommodity, SD.ODMoney,comStoreOrdersFilters.OSumMoney
                                         };
            comStoreOrdersFilterSD = comStoreOrdersFilterSD.Where(i => i.storeId == RowId);
            var FinalJoin = from Goodies in ak.Goodies join s3 in comStoreOrdersFilterSD on Goodies.ID equals s3.IdCommodity 
                            select new
                            {
                                Goodies.ID,
                                Goodies.CName,
                                Goodies.CID1,
                                s3.CNationalCode,
                                s3.cname,
                                s3.CPostalCode,
                                s3.CRegisterNo,
                                s3.CTell,
                                s3.ODMoney,
                                s3.CAddress,
                                s3.OSumMoney
                               
                            };
            var FinalJoin2 = from CountingUnit in ak.GoodyConvertCountingUnits
                             join FJ in FinalJoin on CountingUnit.IDCommodity equals FJ.ID
                             select new
                             {
                                 FJ.ID,
                                 KalaName = FJ.CName,
                                 FJ.CID1,
                                 FJ.CNationalCode,
                                 FJ.cname,
                                 FJ.CPostalCode,
                                 FJ.CRegisterNo,
                                 FJ.CTell,
                                 FJ.ODMoney,
                                 FJ.CAddress,
                                 
                                // CountingUnit.واحد شمارش

                             };

         //   DataGrid.ItemsSource = FinalJoin.ToList();

            StiReport report = new StiReport();
            report.Load(@"D:\New folder (2)\accountingKernel\AccountingKernel\Debug_AccountingKernel\Report2\BuyInvoice - Copy.mrt");
            report.RegData("BuyInvoice", FinalJoin.ToList());
            report.Show();

        }
    }
}
