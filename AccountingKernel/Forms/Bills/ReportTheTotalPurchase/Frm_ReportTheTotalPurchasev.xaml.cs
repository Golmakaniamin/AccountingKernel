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
using System.Globalization;

namespace AccountingKernel.Forms.Bills.ReportTheTotalPurchase
{
    /// <summary>
    /// Interaction logic for Frm_ReportTheTotalPurchasev.xaml
    /// </summary>
    public partial class Frm_ReportTheTotalPurchasev : Window
    {
        AccountingKernelEntities10 ak = new AccountingKernelEntities10();
        public Frm_ReportTheTotalPurchasev()
        {
            InitializeComponent();
            SetDataGrid();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Guid BuyerID = Guid.Parse("b3d717fa-e85d-4c2d-94a3-a1c48105eadb");
            var fullJoin = from com in ak.Coms
                           join storeorder in ak.StoreOrders on com.Id equals storeorder.IdCompany
                           join storeorderdetails in ak.StoreOrderDetails on storeorder.Id equals storeorderdetails.IdStoreOrder
                           join stores in ak.StoreS on storeorderdetails.IdCommodity equals stores.IdCommodity
                           join baseinfo in ak.BaseInfoes on stores.Sname equals baseinfo.Id
                           select new 
                           { 
                            com.CType,
                            Anbar= baseinfo.AssignName,
                            Code= storeorder.OId,
                            Date=storeorder.ODate,
                            Buyer=com.CName,
                            BuyerCode=com.Id,
                            Count= storeorderdetails.ODCount,
                            SumMoney= storeorder.OSumMoney,                          
                           };
            var r = fullJoin.Where(i => i.Date == (PDate1.Text) && i.CType == BuyerID);

            if (PDate1.Text != string.Empty)
            {
                r = fullJoin.Where(i => i.Date == (PDate1.Text) && i.CType == BuyerID);
                //DataGrid.ItemsSource = fullJoin.Where(i => i.Date => (PDate1.Text) && i.Date <= (PDate2.Text)i.CType && i.Date== BuyerID).ToList();
                this.DataGrid.ItemsSource = r.ToList();
            }
            else
                DataGrid.ItemsSource = fullJoin.Where(i => i.CType == BuyerID).ToList();

            StiReport report = new StiReport();
            report.Load(@".\\Report\\Procurement\\Sar_Jame_Kharid.mrt");
            report.RegData("Sar_Jam", r.ToList());
            report.Show();
        }


        private void SetDataGrid()

        {
            //DateTime startDate = (PDate1.Text).ToDate();
            //DateTime endDate = (PDate2.Text).ToDate();
     
            Guid BuyerID = Guid.Parse("b3d717fa-e85d-4c2d-94a3-a1c48105eadb");
            var fullJoin = from com in ak.Coms
                           join storeorder in ak.StoreOrders on com.Id equals storeorder.IdCompany
                           join storeorderdetails in ak.StoreOrderDetails on storeorder.Id equals storeorderdetails.IdStoreOrder
                           join stores in ak.StoreS on storeorderdetails.IdCommodity equals stores.IdCommodity
                           join baseinfo in ak.BaseInfoes on stores.Sname equals baseinfo.Id
                           select new 
                           { 
                            com.CType,
                            Anbar= baseinfo.AssignName,
                            Code= storeorder.OId,
                            Date=storeorder.ODate,
                            Buyer=com.CName,
                            BuyerCode=com.Id,
                            Count= storeorderdetails.ODCount,
                            SumMoney= storeorder.OSumMoney,                          
                           };       
           
            var r = fullJoin.Where(i => i.CType == BuyerID);
            if ( PDate1.Text!=string.Empty  )
            {
                r = fullJoin.Where(i => i.Date == (PDate1.Text) && i.CType == BuyerID);

                //r = fullJoin.Where(i => ((i.Date.ToChar() > (PDate1.Text).ToChar() && i.Date.ToChar() <= (PDate2.Text).ToChar()) && i.CType == BuyerID));
               
               //// //DataGrid.ItemsSource = fullJoin.Where(i => i.Date => (PDate1.Text) && i.Date <= (PDate2.Text)i.CType && i.Date== BuyerID).ToList();  
              this.DataGrid.ItemsSource = r.ToList();
            }
            //else
            //DataGrid.ItemsSource = fullJoin.Where(i => i.CType == BuyerID).ToList();
       
        }

        private void PDate1_SelectedDateChanged(object sender, RoutedEventArgs e)
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

        private void PDate2_SelectedDateChanged(object sender, RoutedEventArgs e)
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
