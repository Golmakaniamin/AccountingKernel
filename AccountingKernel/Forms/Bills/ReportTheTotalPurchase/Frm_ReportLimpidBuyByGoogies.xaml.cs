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
using Data;
using Stimulsoft.Report;

namespace AccountingKernel.Forms.Bills.ReportTheTotalPurchase
{
    /// <summary>
    /// Interaction logic for ReportLimpidBuyByGoogies.xaml
    /// </summary>
    public partial class ReportLimpidBuyByGoogies : Window
    {
        AccountingKernelEntities10 ak = new AccountingKernelEntities10();
        public ReportLimpidBuyByGoogies()
        {
            InitializeComponent();
            cmbStoreS.ItemsSource = Business.GetBaseInfoBusiness().GetByType(Common.Constants.BaseInfoType.StoreSType);
            SetDataGrid();
        }
       
        private void SetDataGrid()
        {
            //var result = from goodies in ak.Goodies
            //             join goodyConvert in ak.GoodyConvertCountingUnits on goodies.ID equals goodyConvert.IDCommodity
            //             join GPriceList in ak.GoodyPriceLists on goodyConvert.IDCommodity equals GPriceList.IDGoody
            //             join stores in ak.StoreS on GPriceList.IDGoody equals stores.IdCommodity
            //             select new { 
            //             goodies.CID1,
            //             goodies.CName,
            //             goodyConvert.ID,//?????????????????واحد شمارش
            //             GPriceList.PLPrice
            //             };
            Guid BuyerID = Guid.Parse("b3d717fa-e85d-4c2d-94a3-a1c48105eadb");
            var a = from com in ak.Coms
                    join storeorder in ak.StoreOrders on com.Id equals storeorder.IdCompany
                    join storeorderdeatails in ak.StoreOrderDetails on storeorder.Id equals storeorderdeatails.IdStoreOrder
                    join goodies in ak.Goodies on storeorderdeatails.IdCommodity equals goodies.ID
                    join stores in ak.StoreS on goodies.ID equals stores.IdCommodity
                    join baseinfo in ak.BaseInfoes on stores.Sname equals baseinfo.Id
                    select new
                    {
                        com.CType,
                        goodies.CID1,
                        goodies.CName,
                        goodies.CInventoryMax,
                        goodies.ID,
                        storeorder.OSumMoney,
                        baseinfo.AssignName,
                        storeorder.ODate
                       
                    };
            var b = from GCUnit in ak.GoodyConvertCountingUnits
                    join c in a on GCUnit.IDCommodity equals c.ID
                    select new
                    { 
                 
                    Code=c.CID1,
                    Amount=c.CInventoryMax,                 
                    Sum_Price=c.OSumMoney,
                    c.CType,
                    Date=c.ODate,
                    Anbar= c.AssignName,
                    Kala=c.CName

                    };
            var fina1=b.Where(i=>i.CType==BuyerID && i.Date==(PDate.Text));
            var final = b.Where(i => i.CType == BuyerID &&  i.Date==(PDate.Text) && i.Anbar==(cmbStoreS.Text));
            
            if (cmbStoreS.Text== null)
            {
                Grd.ItemsSource = fina1.ToList(); 
            }
            else
            Grd.ItemsSource = final.ToList();

            SumTxT.Text = final.Sum(r => r.Amount).ToString();
            SumPrice.Text = final.Sum(c => c.Sum_Price).ToString();
          
        }

        private void PDate_SelectedDateChanged(object sender, RoutedEventArgs e)
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

        private void cmbStoreS_SelectionChanged(object sender, SelectionChangedEventArgs e)
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Guid BuyerID = Guid.Parse("b3d717fa-e85d-4c2d-94a3-a1c48105eadb");
            var a = from com in ak.Coms
                    join storeorder in ak.StoreOrders on com.Id equals storeorder.IdCompany
                    join storeorderdeatails in ak.StoreOrderDetails on storeorder.Id equals storeorderdeatails.IdStoreOrder
                    join goodies in ak.Goodies on storeorderdeatails.IdCommodity equals goodies.ID
                    join stores in ak.StoreS on goodies.ID equals stores.IdCommodity
                    join baseinfo in ak.BaseInfoes on stores.Sname equals baseinfo.Id
                    select new
                    {
                        com.CType,
                        goodies.CID1,
                        goodies.CName,
                        goodies.CInventoryMax,
                        goodies.ID,
                        storeorder.OSumMoney,
                        baseinfo.AssignName,
                        storeorder.ODate

                    };
            var b = from GCUnit in ak.GoodyConvertCountingUnits
                    join c in a on GCUnit.IDCommodity equals c.ID
                    select new
                    {

                        Code = c.CID1,
                        Amount = c.CInventoryMax,
                        Sum_Price = c.OSumMoney,
                        c.CType,
                        Date = c.ODate,
                        Anbar = c.AssignName,
                        Kala = c.CName

                    };

           
            var final = b.Where(i => i.CType == BuyerID && i.Date == (PDate.Text) );
         
            if (cmbStoreS.Text != null)
            {
               final = final.Where(i => i.CType == BuyerID && i.Date == (PDate.Text) && i.Anbar == (cmbStoreS.Text));
            }
            else
                Grd.ItemsSource = final.ToList();
            StiReport report = new StiReport();
            report.Load(@".\\Report\\Procurement\\ReportBuyWithGoodies.mrt");
            report.RegData("ReportByGoodies", final.ToList());
            report.Show();
        }

        
    }
}
