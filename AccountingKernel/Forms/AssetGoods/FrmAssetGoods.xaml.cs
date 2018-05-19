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

namespace AccountingKernel.Forms.AssetGoods
{
    /// <summary>
    /// Interaction logic for Document.xaml
    /// </summary>
    public partial class FrmAssetGoods : Window
    {
        string[,] ss;
        int cc;
        public Guid? AssetGoodId;

        public FrmAssetGoods()
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

                var assetGoodBusiness = Business.GetAssetGoodsBusiness();


                var titleAssetGoods = assetGoodBusiness.GetByCodeTitleId(Common.Constants.CodeTitle.AssetGoodTitle);
                var subsidiaryJTitleGroup = titleAssetGoods.Join(assetGoodBusiness.GetByCodeTitleId(Common.Constants.CodeTitle.AssetGoodSubsidiaryGroup),
                    o => o.parentId, i => i.ID, (o, i) => new { TitleAssetGood = o, SubsidiaryGroupAssetGood = i });
                var jResult = subsidiaryJTitleGroup.Join(assetGoodBusiness.GetByCodeTitleId(Common.Constants.CodeTitle.AssetGoodMianGroup),
                    o => o.SubsidiaryGroupAssetGood.parentId, i => i.ID, (o, i) => new { TitleJSubsidiaryAssetGood = o, MainGroupAssetGood = i });

                if (txtSearch.Text != string.Empty)
                    jResult = jResult.Where(r => r.MainGroupAssetGood.code.Contains(txtSearch.Text) || r.MainGroupAssetGood.name.Contains(txtSearch.Text) ||
                        r.TitleJSubsidiaryAssetGood.SubsidiaryGroupAssetGood.code.Contains(txtSearch.Text) ||
                        r.TitleJSubsidiaryAssetGood.SubsidiaryGroupAssetGood.name.Contains(txtSearch.Text) ||
                        r.TitleJSubsidiaryAssetGood.TitleAssetGood.code.Contains(txtSearch.Text) ||
                        r.TitleJSubsidiaryAssetGood.TitleAssetGood.name.Contains(txtSearch.Text));


                var vv = jResult.Select(r => new
                {
                    Id = r.TitleJSubsidiaryAssetGood.TitleAssetGood.ID,
                    MainGroupCode = r.MainGroupAssetGood.code,
                    MainGroupName = r.MainGroupAssetGood.name,
                    SubsidiaryGroupCode = r.TitleJSubsidiaryAssetGood.SubsidiaryGroupAssetGood.code,
                    SubsidiaryGroupName = r.TitleJSubsidiaryAssetGood.SubsidiaryGroupAssetGood.name,
                    AssetGoodCode = r.TitleJSubsidiaryAssetGood.TitleAssetGood.code,
                    AssetGoodName = r.TitleJSubsidiaryAssetGood.TitleAssetGood.name,
                }).ToList();

                this.DataGrid.ItemsSource = vv;
/////////////////////////////////////////////////
                var v = jResult.ToList();
                cc = v.Count();
                ss = new string[cc, 6];
                int ii = 0;
                foreach (var item in vv)
                {
                    string C_G_A = item.MainGroupCode;
                    string N_G_A = item.MainGroupName;
                    string C_G_F = item.SubsidiaryGroupCode;
                    string N_G_F = item.SubsidiaryGroupName;
                    string C_K_A=item.AssetGoodCode;
                    string N_K_A = item.AssetGoodName;

                    ss[ii, 0] = C_G_A;
                    ss[ii, 1] = N_G_A;
                    ss[ii, 2] = C_G_F;
                    ss[ii, 3] = N_G_F;
                    ss[ii, 4] = C_K_A;
                    ss[ii, 5] = N_K_A;
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

                for (int j = 0; j <= 5; j++)
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
                var frmRegisterAssetGoods = new FrmRegisterAssetGoods();
                frmRegisterAssetGoods.ShowDialog();
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
                new FrmRegisterAssetGoods((DataGrid.SelectedValue as dynamic).Id).ShowDialog();
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

                Business.GetAssetGoodsBusiness().Delete(Business.GetAssetGoodsBusiness().GetById((DataGrid.SelectedValue as dynamic).Id));

                SetDataGrid();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void btnSelectAssetGood_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SelectAssetGood();
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
                SelectAssetGood();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }

        }

        private void SelectAssetGood()
        {
            try
            {
                if (DataGrid.SelectedItem == null)
                    throw new Exception(Localize.ex_no_record_selected);

                this.AssetGoodId = (DataGrid.SelectedItem as dynamic).Id;
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
            var assetGoodBusiness = Business.GetAssetGoodsBusiness();
            var titleAssetGoods = assetGoodBusiness.GetByCodeTitleId(Common.Constants.CodeTitle.AssetGoodTitle);
            var subsidiaryJTitleGroup = titleAssetGoods.Join(assetGoodBusiness.GetByCodeTitleId(Common.Constants.CodeTitle.AssetGoodSubsidiaryGroup),
                o => o.parentId, i => i.ID, (o, i) => new { TitleAssetGood = o, SubsidiaryGroupAssetGood = i });
            var jResult = subsidiaryJTitleGroup.Join(assetGoodBusiness.GetByCodeTitleId(Common.Constants.CodeTitle.AssetGoodMianGroup),
                o => o.SubsidiaryGroupAssetGood.parentId, i => i.ID, (o, i) => new { TitleJSubsidiaryAssetGood = o, MainGroupAssetGood = i });

            if (txtSearch.Text != string.Empty)
                jResult = jResult.Where(r => r.MainGroupAssetGood.code.Contains(txtSearch.Text) || r.MainGroupAssetGood.name.Contains(txtSearch.Text) ||
                    r.TitleJSubsidiaryAssetGood.SubsidiaryGroupAssetGood.code.Contains(txtSearch.Text) ||
                    r.TitleJSubsidiaryAssetGood.SubsidiaryGroupAssetGood.name.Contains(txtSearch.Text) ||
                    r.TitleJSubsidiaryAssetGood.TitleAssetGood.code.Contains(txtSearch.Text) ||
                    r.TitleJSubsidiaryAssetGood.TitleAssetGood.name.Contains(txtSearch.Text));


            var vv = jResult.Select(r => new
            {
                Id = r.TitleJSubsidiaryAssetGood.TitleAssetGood.ID,
                MainGroupCode = r.MainGroupAssetGood.code,
                MainGroupName = r.MainGroupAssetGood.name,
                SubsidiaryGroupCode = r.TitleJSubsidiaryAssetGood.SubsidiaryGroupAssetGood.code,
                SubsidiaryGroupName = r.TitleJSubsidiaryAssetGood.SubsidiaryGroupAssetGood.name,
                AssetGoodCode = r.TitleJSubsidiaryAssetGood.TitleAssetGood.code,
                AssetGoodName = r.TitleJSubsidiaryAssetGood.TitleAssetGood.name,
            }).ToList();


            StiReport report = new StiReport();
            report.Load(@".\\Report\\Real_estate\\FrmAssetGoods.mrt");
            report.RegData("vv", vv);
            report.Show();
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var frmRegisterAssetGoods = new FrmRegisterAssetGoods();
                frmRegisterAssetGoods.ShowDialog();
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
                new FrmRegisterAssetGoods((DataGrid.SelectedValue as dynamic).Id).ShowDialog();
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

                Business.GetAssetGoodsBusiness().Delete(Business.GetAssetGoodsBusiness().GetById((DataGrid.SelectedValue as dynamic).Id));

                SetDataGrid();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }


    }
}
