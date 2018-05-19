using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Common;
using System.Transactions;
using System.Data;
using Stimulsoft.Report;
namespace AccountingKernel.Forms.Goodies
{
    /// <summary>
    /// Interaction logic for Document.xaml
    /// </summary>
    public partial class FrmGoods : Window
    {
        string[,] ss;
        int cc;

        public FrmGoods()
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
                var goodiesBusiness = Business.GetGoodiesBusiness();
                var goodiesGroupsBusiness = Business.GetGoodiesGroupBusiness();
                var codeTitelBusiness = Business.GetCodeTitleBusiness();

                var goodies = goodiesBusiness.GetAll();

                var goodiesJSubsidiaryGroup = goodies.Join(goodiesGroupsBusiness.GetByCodeTitleId(Common.Constants.CodeTitle.CommoditySubsidiaryGroup),
                    o => o.IdGoodiesGroups,
                    i => i.ID,
                    (o, i) => new { Goodies = o, SubsidiaryGroup = i }
                    );

                var mainGroups = goodiesGroupsBusiness.GetByCodeTitleId(Common.Constants.CodeTitle.CommodityMainGroup);
                var jResult = goodiesJSubsidiaryGroup.Join(mainGroups,
                    o => o.SubsidiaryGroup.ParentId,
                    i => i.ID,
                    (o, i) => new { goodiesJSubsidiaryGroup = o, MainGroup = i });


                if (txtSearch.Text != string.Empty)
                    jResult = jResult.Where(r =>
                        r.goodiesJSubsidiaryGroup.Goodies.CName.Contains(txtSearch.Text) ||
                        r.goodiesJSubsidiaryGroup.Goodies.CID1.Contains(txtSearch.Text) ||
                        r.MainGroup.CName.Contains(txtSearch.Text) ||
                        r.goodiesJSubsidiaryGroup.SubsidiaryGroup.CName.Contains(txtSearch.Text));

                var v = jResult.Select(r => new
                {
                    Id = r.goodiesJSubsidiaryGroup.Goodies.ID,
                    MainGroup = r.MainGroup.CName,
                    SubsidiaryGroup = r.goodiesJSubsidiaryGroup.SubsidiaryGroup.CName,
                    GoodTitle = r.goodiesJSubsidiaryGroup.Goodies.CName,
                    GoodCode = r.goodiesJSubsidiaryGroup.Goodies.CID1
                }).ToList();

                this.DataGrid.ItemsSource = v;

                cc = v.Count();
                ss = new string[cc, 4];
                int ii = 0;
                foreach (var item in v)
                {
                    string G_A = item.MainGroup;
                    string G_F = item.SubsidiaryGroup;
                    string O_K = item.GoodTitle;
                    string C_K = item.GoodCode;

                    ss[ii, 0] = G_A;
                    ss[ii, 1] = G_F;
                    ss[ii, 2] = O_K;
                    ss[ii, 3] = C_K;

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

                for (int j = 0; j <= 3; j++)
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

        private void MenuItem_Register(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                var frmRegisterGoods = new FrmRegisterGoods();
                frmRegisterGoods.ShowDialog();
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

                Guid id;
                id = (DataGrid.SelectedValue as dynamic).Id;
                new FrmRegisterGoods(id).ShowDialog();
                SetDataGrid();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }

        }

        private void MenuItem_UnitCount(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                if (DataGrid.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);

                var frmUnitCount = new FrmUnitCount((DataGrid.SelectedValue as dynamic).Id);
                frmUnitCount.ShowDialog();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void MenuItem_PriceList(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                if (DataGrid.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);

                Guid id;
                id = (DataGrid.SelectedValue as dynamic).Id;
                new FrmPriceList(id).ShowDialog();
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

                var goodiesBusiness = Business.GetGoodiesBusiness();
                var goody = goodiesBusiness.GetById(id);
                goodiesBusiness.Delete(goody);

                SetDataGrid();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }

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

        private void BtnExel_Click(object sender, RoutedEventArgs e)
        {

            set_to_excell(ss, cc);

        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            var goodiesBusiness = Business.GetGoodiesBusiness();
            var goodiesGroupsBusiness = Business.GetGoodiesGroupBusiness();
            var codeTitelBusiness = Business.GetCodeTitleBusiness();

            var goodies = goodiesBusiness.GetAll();

            var goodiesJSubsidiaryGroup = goodies.Join(goodiesGroupsBusiness.GetByCodeTitleId(Common.Constants.CodeTitle.CommoditySubsidiaryGroup),
                o => o.IdGoodiesGroups,
                i => i.ID,
                (o, i) => new { Goodies = o, SubsidiaryGroup = i }
                );

            var mainGroups = goodiesGroupsBusiness.GetByCodeTitleId(Common.Constants.CodeTitle.CommodityMainGroup);
            var jResult = goodiesJSubsidiaryGroup.Join(mainGroups,
                o => o.SubsidiaryGroup.ParentId,
                i => i.ID,
                (o, i) => new { goodiesJSubsidiaryGroup = o, MainGroup = i });


            if (txtSearch.Text != string.Empty)
                jResult = jResult.Where(r =>
                    r.goodiesJSubsidiaryGroup.Goodies.CName.Contains(txtSearch.Text) ||
                    r.goodiesJSubsidiaryGroup.Goodies.CID1.Contains(txtSearch.Text) ||
                    r.MainGroup.CName.Contains(txtSearch.Text) ||
                    r.goodiesJSubsidiaryGroup.SubsidiaryGroup.CName.Contains(txtSearch.Text));

            var vv = jResult.Select(r => new
            {
                Id = r.goodiesJSubsidiaryGroup.Goodies.ID,
                MainGroup = r.MainGroup.CName,
                SubsidiaryGroup = r.goodiesJSubsidiaryGroup.SubsidiaryGroup.CName,
                GoodTitle = r.goodiesJSubsidiaryGroup.Goodies.CName,
                GoodCode = r.goodiesJSubsidiaryGroup.Goodies.CID1
            }).ToList();

            StiReport report = new StiReport();
           
            report.Load(@".\\Report\\Basic_Information\\FrmGoods.mrt");

            report.RegData("vv", vv);

            report.Show();
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var frmRegisterGoods = new FrmRegisterGoods();
                frmRegisterGoods.ShowDialog();
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

                Guid id;
                id = (DataGrid.SelectedValue as dynamic).Id;
                new FrmRegisterGoods(id).ShowDialog();
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

                var goodiesBusiness = Business.GetGoodiesBusiness();
                var goody = goodiesBusiness.GetById(id);
                goodiesBusiness.Delete(goody);

                SetDataGrid();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }

        }

    }
}
