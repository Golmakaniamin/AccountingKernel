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
    public partial class FrmShow : Window
    {
        string[,] ss;
        int cc;

        public Guid Result { get; set; }

        public FrmShow()
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
                var goodiesGroupBusiness = Business.GetGoodiesGroupBusiness();
                var codeTitelBusiness = Business.GetCodeTitleBusiness();

                var gooidesJGroups = goodiesBusiness.GetAll().Join(goodiesGroupBusiness.GetAll(),
                    o => o.IdGoodiesGroups,
                    i => i.ID,
                    (o, i) => new { SubGroup = i, Goody = o }
                    );

                var jResult = gooidesJGroups.Join(goodiesGroupBusiness.GetAll(),
                    o => o.SubGroup.ParentId,
                    i => i.ID,
                    (o, i) => new { GoodyJSubGroup = o, MainGroup = i }
                    );


                if (txtSearch.Text != string.Empty)
                    jResult= jResult.Where(r =>
                        r.GoodyJSubGroup.Goody.CName.Contains(txtSearch.Text) ||
                        r.GoodyJSubGroup.Goody.CID1.Contains(txtSearch.Text) ||
                        r.MainGroup.CName.Contains(txtSearch.Text) ||
                        r.GoodyJSubGroup.SubGroup.CName.Contains(txtSearch.Text));


                var vv = jResult.Select(r => new
                {
                    Id = r.GoodyJSubGroup.Goody.ID,
                    SubsidiaryGroup = r.GoodyJSubGroup.SubGroup.CName,
                    MainGroup = r.MainGroup.CName,
                    GoodTitle = r.GoodyJSubGroup.Goody.CName,
                    GoodCode = r.GoodyJSubGroup.Goody.CID1
                }).ToList();
                this.grdCommodities.ItemsSource = vv;
                cc = vv.Count();
                ss = new string[cc, 4];
                int ii = 0;
                foreach (var item in vv)
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


            table = exp.get_dataGridColumnNames(grdCommodities);

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
                    //    row[this.grdCommodities.Columns[j + 1].Header.ToString()] = int.Parse(a[i, j].ToString());
                    //else
                    row[this.grdCommodities.Columns[j + 1].Header.ToString()] = a[i, j];
                }

                table.Rows.Add(row);
            }


            DataSet ds = new DataSet("New_DataSet");
            ds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;
            ds.Tables.Add(table);
            exp.showStuff(ds);

        }

        private void btnSelectCommodity_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SelectCommodity();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void SelectCommodity()
        {
            try
            {
                if (grdCommodities.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);

                this.Result = (grdCommodities.SelectedValue as dynamic).Id;
                this.Close();

            }
            catch
            {

                throw;
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

        private void grdCommodities_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                SelectCommodity();
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

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            var goodiesBusiness = Business.GetGoodiesBusiness();
            var goodiesGroupBusiness = Business.GetGoodiesGroupBusiness();
            var codeTitelBusiness = Business.GetCodeTitleBusiness();

            var gooidesJGroups = goodiesBusiness.GetAll().Join(goodiesGroupBusiness.GetAll(),
                o => o.IdGoodiesGroups,
                i => i.ID,
                (o, i) => new { SubGroup = i, Goody = o }
                );

            var jResult = gooidesJGroups.Join(goodiesGroupBusiness.GetAll(),
                o => o.SubGroup.ParentId,
                i => i.ID,
                (o, i) => new { GoodyJSubGroup = o, MainGroup = i }
                );


            if (txtSearch.Text != string.Empty)
                jResult = jResult.Where(r =>
                    r.GoodyJSubGroup.Goody.CName.Contains(txtSearch.Text) ||
                    r.GoodyJSubGroup.Goody.CID1.Contains(txtSearch.Text) ||
                    r.MainGroup.CName.Contains(txtSearch.Text) ||
                    r.GoodyJSubGroup.SubGroup.CName.Contains(txtSearch.Text));


            var vv = jResult.Select(r => new
            {
                Id = r.GoodyJSubGroup.Goody.ID,
                SubsidiaryGroup = r.GoodyJSubGroup.SubGroup.CName,
                MainGroup = r.MainGroup.CName,
                GoodTitle = r.GoodyJSubGroup.Goody.CName,
                GoodCode = r.GoodyJSubGroup.Goody.CID1
            }).ToList();

            StiReport report = new StiReport();

            report.Load(@"D:\New folder (2)\accountingKernel\AccountingKernel\Debug_AccountingKernel\Report\FrmShow.mrt");

            report.RegData("vv", vv);

            report.Show();
        }
    }
}
