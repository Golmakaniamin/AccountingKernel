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
using System.Data.SqlClient;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Text;
using System.Globalization;

namespace AccountingKernel.Forms.Bills.SaleInvoice
{
    /// <summary>
    /// Interaction logic for Document.xaml
    /// </summary>
    /// 
    public class get_grid_data
    {
       public Guid Id { get; set; }
       public string CompanyName { get; set; }
       public string Date { get; set; }
       public string Code { get; set; }
    }

    public partial class FrmSaleInvoiceManagement : Window
    {
        string[,] ss;
        int cc;

        public Guid? StoreOrderId;

        public FrmSaleInvoiceManagement()
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

                var storeOrders = storeOrderBusiness.GetByStoreOperation(Common.Constants.StoreOperation.SaleInvoice);

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
                }).ToList();
                this.DataGrid.ItemsSource = vv;
                ////////////////////
                var v = jResult.ToList();
                cc = v.Count();
                ss = new string[cc, 3];
                int ii = 0;
                foreach (var item in vv)
                {
                    string N_M = item.CompanyName;
                    string T_F = item.Date;
                    string SH_F = item.Code;


                    ss[ii, 0] = N_M;
                    ss[ii, 1] = T_F;
                    ss[ii, 2] = SH_F;

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
               

                for (int j = 0; j <= 2; j++)
                {
                    //if (j == 0)
                    //    row[this.DataGrid.Columns[j + 1].Header.ToString()] = int.Parse(a[i, j].ToString());
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

        private void MenuItem_NewClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                var frmSaleInvoice = new Bills.SaleInvoice.FrmSaleInvoice(Common.Enum.FormMode.New, null, Constants.StoreOperation.SaleInvoice);
                frmSaleInvoice.Title = Localize.SaleInvoice;
                frmSaleInvoice.ShowDialog();
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

                var frmSaleInvoice = new Bills.SaleInvoice.FrmSaleInvoice(Common.Enum.FormMode.Edit, (DataGrid.SelectedValue as dynamic).Id, Constants.StoreOperation.SaleInvoice);
                frmSaleInvoice.Title = Localize.SaleInvoice;
                frmSaleInvoice.ShowDialog();
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

                var invoice = Business.GetStoreOrderBusiness().GetById((DataGrid.SelectedValue as dynamic).Id);
                Business.GetStoreOrderBusiness().Delete(invoice);
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
               // this.Close();
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

            var storeOrders = storeOrderBusiness.GetByStoreOperation(Common.Constants.StoreOperation.SaleInvoice);

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
            }).ToList();


            StiReport report = new StiReport();

            report.Load(@"D:\New folder (2)\accountingKernel\AccountingKernel\Debug_AccountingKernel\Report\FrmSaleInvoiceManagement.mrt");

            report.RegData("vv", vv);

            report.Show();
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var frmSaleInvoice = new Bills.SaleInvoice.FrmSaleInvoice(Common.Enum.FormMode.New, null, Constants.StoreOperation.SaleInvoice);
                frmSaleInvoice.Title = Localize.SaleInvoice;
                frmSaleInvoice.ShowDialog();
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

                var frmSaleInvoice = new Bills.SaleInvoice.FrmSaleInvoice(Common.Enum.FormMode.Edit, (DataGrid.SelectedValue as dynamic).Id, Constants.StoreOperation.SaleInvoice);
                frmSaleInvoice.Title = Localize.SaleInvoice;
                frmSaleInvoice.ShowDialog();
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

                var invoice = Business.GetStoreOrderBusiness().GetById((DataGrid.SelectedValue as dynamic).Id);
                Business.GetStoreOrderBusiness().Delete(invoice);
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
          
            //var storeOrderBusiness = Business.GetStoreOrderBusiness();
            //var storeOrders = storeOrderBusiness.GetByStoreOperation(Common.Constants.StoreOperation.SaleInvoice);

            //var q = from i in ak.Coms// Join Tow tables with name's Com & StoreOrder
            //        join b in ak.StoreOrders
            //        on i.Id equals b.IdCompany
            //        select new
            //        {
            //            i.CName,
            //            i.CNationalCode,
            //            i.CRegisterNo,
            //            i.CTell,
            //            i.CEconomyCode,
            //            i.CType,
            //            i.CAddress,
            //            b.Id,
            //            b.ODate
            //        };

            var q = from Goodies in ak.Goodies
                    join StoreOrderDetails in ak.StoreOrderDetails on Goodies.ID equals StoreOrderDetails.IdCommodity
                    join StoreOrders in ak.StoreOrders on StoreOrderDetails.IdStoreOrder equals StoreOrders.Id
                    join coms in ak.Coms on StoreOrders.IdCompany equals coms.Id
                   
                    select new
                    {
                       N_Taraf= coms.CName,
                       Code_Melli= coms.CNationalCode,
                       SN_Number= coms.CRegisterNo,
                       Tell=coms.CTell,
                       coms.CType,
                       Address= coms.CAddress,
                       PostalCode=coms.CPostalCode,
                       StoreOrders.Id,
                       Tax= StoreOrders.OTax,
                       Date=StoreOrders.ODate,
                       Number= StoreOrderDetails.ODCount,
                       StoreOrderDetails.ODMoney,
                       StoreOrderDetails.ODDiscount,
                       StoreOrders.OSumMoney,
                       Code_Kala= Goodies.CID1,
                       Name_kala= Goodies.CName,
                       coms.CEconomyCode
                    };

            Guid BuyerID = Guid.Parse("b3d717fa-e85d-4c2d-94a3-a1c48105eadb");//ID's BUYER in DB tables
            var get_by_id = q.Where(i => i.Id == RowId && i.CType == BuyerID);//Choice Information of choiced row and is Buyer
                       
            StiReport report = new StiReport();
                report.Load(@"D:\New folder (2)\accountingKernel\AccountingKernel\Debug_AccountingKernel\Report2\SaleInvoice.mrt");
                report.RegData("Sale_Invoice", get_by_id.ToList());
                report.Show();

}       
            
    }


        }
