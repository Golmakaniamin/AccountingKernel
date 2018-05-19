using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Common;
using System.Transactions;
using System.Windows.Data;
using System.Data;
using Data;
using System.Windows.Controls.Primitives;
using Stimulsoft.Report;
namespace AccountingKernel.Forms.Asset
{
    /// <summary>
    /// Interaction logic for Document.xaml
    /// </summary>
    public partial class FrmAsset : Window
    {
        string[,] ss;
        int cc;

        public Guid? AssetId;

        AccountingKernelEntities10 ak = new AccountingKernelEntities10();
        


        public FrmAsset()
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

        public class a1
        {
            public string PersonCode { set; get; }
            public string PersonName { set; get; }
            public string AssetGoodCode { set; get; }
            public string AssetGoodName { set; get; }
            public string AssetNo { set; get; }
        }

        public class a2
        {
            public string PersonCode;
            public string PersonName;
            public string AssetGoodCode;
            public string AssetGoodName;
            public string AssetNo;
        }

        /// <summary>
        /// sets store order detail data grid 
        /// </summary>

      
        private void SetDataGrid()
        {
            try
            {

                var assetBusines = Business.GetAssetBusiness();
                var assets = Business.GetAssetBusiness().GetAll().Where(r => !r.Accumulative_amortization.HasValue);
                var assetsJGoods = assets.Join(Business.GetAssetGoodsBusiness().GetAll(), o => o.Idassetgoods, i => i.ID, (o, i) => new { Asset = o, AssetGoods = i });
                var jResult = assetsJGoods.Join(Business.GetPayrollPersonBusiness().GetAll(), o => o.Asset.Idperson, i => i.id, (o, i) => new
                {
                    AssetJGoods = o,
                    Person = i
                });


                var intSerachValue = txtSearch.Text.ToInt();
                if (txtSearch.Text != string.Empty)
                    jResult = jResult.Where(r => r.Person.PPerson_Code.Contains(txtSearch.Text) || (r.Person.PFristName + r.Person.PLastName).Contains(txtSearch.Text) ||
                                                 r.AssetJGoods.AssetGoods.code.Contains(txtSearch.Text) || r.AssetJGoods.AssetGoods.name.Contains(txtSearch.Text) ||
                                                 r.AssetJGoods.Asset.asset_number == intSerachValue);



                var awe =
                                jResult.Select(r => new
                                {
                                    Id = r.AssetJGoods.Asset.ID,
                                    PersonCode = r.Person.PPerson_Code,
                                    PersonName = r.Person.PFristName + r.Person.PLastName,
                                    AssetGoodCode = r.AssetJGoods.AssetGoods.code,
                                    AssetGoodName = r.AssetJGoods.AssetGoods.name,
                                    AssetNo = r.AssetJGoods.Asset.asset_number
                                }).Distinct().ToList();


                DataGrid.ItemsSource = jResult.Select(r => new
                {
                    Id = r.AssetJGoods.Asset.ID,
                    PersonCode = r.Person.PPerson_Code,
                    PersonName = r.Person.PFristName + r.Person.PLastName,
                    AssetGoodCode = r.AssetJGoods.AssetGoods.code,
                    AssetGoodName = r.AssetJGoods.AssetGoods.name,
                    AssetNo = r.AssetJGoods.Asset.asset_number
                }).Distinct().ToList();

           

              //  var awe = get_asset_data();
                var v = awe;
                cc = v.Count();
                ss = new string[cc, 5];
                int ii = 0;
                foreach (var item in v)
                {
                    string P_Code = item.PersonCode;
                    string P_Name = item.PersonName;
                    string C_K_Amval = item.AssetGoodCode;
                    string N_K_Amval = item.AssetGoodName;
                    int sh_Amval =(int) item.AssetNo;


                    ss[ii, 0] = P_Code;
                    ss[ii, 1] = P_Name;
                    ss[ii, 2] = C_K_Amval;
                    ss[ii, 3] = N_K_Amval;
                    ss[ii, 4] = sh_Amval.ToString();
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

                for (int j = 0; j <= 4; j++)
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
                new FrmRegisterAsset().ShowDialog();
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

                Data.Asset asset = Business.GetAssetBusiness().GetById((DataGrid.SelectedValue as dynamic).Id);
                new FrmRegisterAsset(asset.ID).ShowDialog();

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

                Business.GetAssetBusiness().Delete(Business.GetAssetBusiness().GetById((DataGrid.SelectedValue as dynamic).Id));

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
                    AssetId = (DataGrid.SelectedValue as dynamic).Id;
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
            var vvv = get_asset_data();

            StiReport report = new StiReport();

            report.Load(@"D:\New folder (2)\accountingKernel\AccountingKernel\Debug_AccountingKernel\Report\FrmAsset.mrt");

            report.RegData("vvv", vvv);

            report.Show();

           

        }



        //public static DataGridCell GetCell(DataGrid dataGrid, int row, int column)
        //{
        //    //DataGridRow rowContainer = GetRow(dataGrid, row);
        //    //if (rowContainer != null)
        //    //{
        //    //    DataGridCellsPresenter presenter = GetVisualChild<datagridcellspresenter>(rowContainer);

        //    //    // try to get the cell but it may possibly be virtualized
        //    //    DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(column);
        //    //    if (cell == null)
        //    //    {
        //    //        // now try to bring into view and retreive the cell
        //    //        dataGrid.ScrollIntoView(rowContainer, dataGrid.Columns[column]);

        //    //        cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(column);
        //    //    }

        //    //    return cell;
        //    //}

        //    //return null;
        //}


        private IQueryable get_asset_data()
        {
            var assetBusines = Business.GetAssetBusiness();
            var assets = Business.GetAssetBusiness().GetAll().Where(r => !r.Accumulative_amortization.HasValue);
            var assetsJGoods = assets.Join(Business.GetAssetGoodsBusiness().GetAll(), o => o.Idassetgoods, i => i.ID, (o, i) => new { Asset = o, AssetGoods = i });
            var jResult = assetsJGoods.Join(Business.GetPayrollPersonBusiness().GetAll(), o => o.Asset.Idperson, i => i.id, (o, i) => new
            {
                AssetJGoods = o,
                Person = i
            });


            var intSerachValue = txtSearch.Text.ToInt();
            if (txtSearch.Text != string.Empty)
                jResult = jResult.Where(r => r.Person.PPerson_Code.Contains(txtSearch.Text) || (r.Person.PFristName + r.Person.PLastName).Contains(txtSearch.Text) ||
                                             r.AssetJGoods.AssetGoods.code.Contains(txtSearch.Text) || r.AssetJGoods.AssetGoods.name.Contains(txtSearch.Text) ||
                                             r.AssetJGoods.Asset.asset_number == intSerachValue);



            var awe =
                            jResult.Select(r => new
                            {
                                Id = r.AssetJGoods.Asset.ID,
                                PersonCode = r.Person.PPerson_Code,
                                PersonName = r.Person.PFristName + r.Person.PLastName,
                                AssetGoodCode = r.AssetJGoods.AssetGoods.code,
                                AssetGoodName = r.AssetJGoods.AssetGoods.name,
                                AssetNo = r.AssetJGoods.Asset.asset_number
                            }).Distinct().ToList();


            IQueryable iq = jResult.Select(r => new
            {
                Id = r.AssetJGoods.Asset.ID,
                PersonCode = r.Person.PPerson_Code,
                PersonName = r.Person.PFristName + r.Person.PLastName,
                AssetGoodCode = r.AssetJGoods.AssetGoods.code,
                AssetGoodName = r.AssetJGoods.AssetGoods.name,
                AssetNo = r.AssetJGoods.Asset.asset_number
            }).Distinct();


            return iq;

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DataGrid.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);

                Data.Asset asset = Business.GetAssetBusiness().GetById((DataGrid.SelectedValue as dynamic).Id);
                new FrmRegisterAsset(asset.ID).ShowDialog();

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

                Business.GetAssetBusiness().Delete(Business.GetAssetBusiness().GetById((DataGrid.SelectedValue as dynamic).Id));

                SetDataGrid();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                new FrmRegisterAsset().ShowDialog();
                SetDataGrid();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }

        }

       


    }
}
