using System;
using System.Collections.Generic;
using System.Data;
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

namespace AccountingKernel.Forms.SotoheTafsili
{
    public partial class frmManageTafsiliGroup : Window
    {
        Data.AccountingKernelEntities10 ak = new Data.AccountingKernelEntities10();

        public frmManageTafsiliGroup()
        {
            InitializeComponent();
        }

        void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
             }
            catch (Exception ex) { }
        }

        void SetDataGrid()
        {
            try
            {
                var assetGoodsBusiness = ak.AccountingTafsilStructureDefines.ToList();

                //Ali younesi
                //var assetGoodMainGroup =  assetGoodsBusiness.GetByCodeTitleId(Common.Constants.CodeTitle.AssetGoodMianGroup).ToList();
                //var assetGoodSubsidiaryGroup = assetGoodsBusiness.GetByCodeTitleId(Common.Constants.CodeTitle.AssetGoodSubsidiaryGroup).ToList();

                //MainGroups = new List<MainGroup>();
                //foreach (var item in assetGoodMainGroup)
                //{
                //    var subGroup = assetGoodSubsidiaryGroup.FindAll(r => r.parentId == item.ID);
                //    MainGroups.Add(new MainGroup(item, subGroup));
                //};
                //treeView.ItemsSource = MainGroups;
                DataContext = this;
            }
            catch
            {
                throw;
            }
        }

        private void BtnExel_Click(object sender, RoutedEventArgs e)
        {
            var entities = ak.Capitals.ToList();
            var table = new System.Data.DataTable();
            table.Columns.Add("شماره", typeof(int));
            table.Columns.Add("تاریخ", typeof(string));
            table.Columns.Add("مبلغ", typeof(string));
            foreach (var entity in entities)
            {
                var row = table.NewRow();
                row["شماره"] = entity.CNO;
                row["تاریخ"] = entity.CDate;
                row["مبلغ"] = entity.CTotalPrice;
                table.Rows.Add(row);
            }
            DataSet ds = new DataSet("New_DataSet");
            ds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;
            ds.Tables.Add(table);
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = ""; 
            dlg.DefaultExt = ".xls"; 
            dlg.Filter = "Text documents (.xls)|*.xls"; 
            Nullable<bool> result = dlg.ShowDialog();
            string filename = "";
            if (result == true)
            {
                filename = dlg.FileName;
                try
                {
                    bool b = CreateExcelFile.CreateExcelDocument(ds, filename);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Couldn't create Excel file.\r\nException: " + ex.Message);
                    return;
                }
            }
        }

    }
}
