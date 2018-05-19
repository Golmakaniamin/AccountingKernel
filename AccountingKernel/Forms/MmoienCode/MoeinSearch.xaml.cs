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
using Common;
using System.Transactions;
using AccountingKernel.Forms.SotoheTafsili;
using System.Data;
using Stimulsoft.Report;
using AccountingKernel.Class;

namespace AccountingKernel.Forms.MmoienCode
{
    /// <summary>
    /// Interaction logic for MoeinSearch.xaml
    /// </summary>

    public partial class MoeinSearch : Window
    {
        AccountingKernel.Class.UI.TextHandeler c = new AccountingKernel.Class.UI.TextHandeler();

        string[,] ss;
        int cc;

        public MoeinSearch()
        {
            InitializeComponent();
            LoadGrid();
        }

        private void LoadGrid()
        {
            grdLoanInsurance.ItemsSource = null;
            grdLoanInsurance.ItemsSource = Business.GetMoeinStructureDefineBusiness().GetMoeins();

            var V = Business.GetMoeinStructureDefineBusiness().GetMoeins();
            cc = V.Count();
            ss = new string[cc, 6];
            int ii = 0;
            foreach (var item in V)
            {
                string C_G = item.FirstLevelCode;
                string N_G = item.FirstLevelName;
                string C_K = item.SecondLevelCode;
                string N_K = item.SecondLevelName;
                string C_M = item.ThirdLevelCode;
                string N_M = item.ThirdLevelName;

                ss[ii, 0] = C_G;
                ss[ii, 1] = N_G;
                ss[ii, 2] = C_K;
                ss[ii, 3] = N_K;
                ss[ii, 4] = C_M;
                ss[ii, 5] = N_M;
                ii++;
            }
        }

        private void set_to_excell(string[,] a, int rowC)
        {
            ExcelImpExp.ExportToExcel exp = new ExcelImpExp.ExportToExcel();
            var table = new System.Data.DataTable();


            table = exp.get_dataGridColumnNames(grdLoanInsurance);

            for (int i = 0; i <= rowC - 1; i++)
            {
                var row = table.NewRow();
                for (int j = 1; j <= 6; j++)
                {

                    row[this.grdLoanInsurance.Columns[j].Header.ToString()] = a[i, j - 1].ToString();
                }

                table.Rows.Add(row);
            }
            DataSet ds = new DataSet("New_DataSet");
            ds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;
            ds.Tables.Add(table);
            exp.showStuff(ds);
        }

        private void GridNew_Click(object sender, RoutedEventArgs e)
        {
            MoeinAdd add = new MoeinAdd();
            add.ShowDialog();
            LoadGrid();
        }

        private void GridLoadDetail_Click(object sender, RoutedEventArgs e)
        {
            Guid id = Guid.Empty;
            if (grdLoanInsurance.SelectedValue != null)
            {
                id = (grdLoanInsurance.SelectedValue as dynamic).ID;
                MoeinAdd edit = new MoeinAdd(id);
                edit.ShowDialog();
                LoadGrid();
            }
        }

        private void GridDelete_Click(object sender, RoutedEventArgs e)
        {


            Guid id = Guid.Empty;
            if (grdLoanInsurance.SelectedValue != null)
            {
                if (MessageBox.Show("آیا مایل حذف هستید", "", MessageBoxButton.YesNo) == MessageBoxResult.No)
                    return;

                id = (grdLoanInsurance.SelectedValue as dynamic).ID;

                var deletedDefine = Business.GetMoeinStructureDefineBusiness().GetByID(id).FirstOrDefault();
                var deletedCode = Business.GetMoeinCodesBusiness().GetByStructureDefine_ID(id).FirstOrDefault();
                using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
                {
                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted,
                    Timeout = new TimeSpan(2, 0, 0)
                }))
                {
                    Business.GetMoeinStructureDefineBusiness().Delete(deletedDefine);
                    Business.GetMoeinCodesBusiness().Delete(deletedCode);
                    scope.Complete();
                }
                LoadGrid();
            }
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            MoeinAdd add = new MoeinAdd();
            add.ShowDialog();
            LoadGrid();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

            Guid id = Guid.Empty;
            if (grdLoanInsurance.SelectedValue != null)
            {
                id = (grdLoanInsurance.SelectedValue as dynamic).ID;
                MoeinAdd edit = new MoeinAdd(id);
                edit.ShowDialog();
            }
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            Guid id = Guid.Empty;
            if (grdLoanInsurance.SelectedValue != null)
            {
                id = (grdLoanInsurance.SelectedValue as dynamic).ID;
                var deletedDefine = Business.GetMoeinStructureDefineBusiness().GetByID(id).FirstOrDefault();
                var deletedCode = Business.GetMoeinCodesBusiness().GetByStructureDefine_ID(id).FirstOrDefault();
                using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
                {
                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted,
                    Timeout = new TimeSpan(2, 0, 0)
                }))
                {
                    Business.GetMoeinStructureDefineBusiness().Delete(deletedDefine);
                    Business.GetMoeinCodesBusiness().Delete(deletedCode);
                    scope.Complete();
                }
            }

        }

        private void BtnExel_Click(object sender, RoutedEventArgs e)
        {
            set_to_excell(ss, cc);
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            var v = Business.GetMoeinStructureDefineBusiness().GetMoeins().ToList();
            if (txtSearch.Text.Trim().Length > 0)
            {
                v = Business.GetMoeinStructureDefineBusiness().GetMoeins().Where(i => i.FirstLevelName.Contains
                    (txtSearch.Text) || i.SecondLevelName.Contains(txtSearch.Text) || i.ThirdLevelName.Contains(txtSearch.Text)).ToList();
            }
            else
            {
                v = Business.GetMoeinStructureDefineBusiness().GetMoeins().ToList();
            }

            StiReport report = new StiReport();
            report.Load(@"D:\New folder (2)\accountingKernel\AccountingKernel\Debug_AccountingKernel\Report\MoeinSearch.mrt");

            report.RegData("v", v);

            report.Show();


        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtSearch.Text.Trim().Length > 0)
            {
                grdLoanInsurance.ItemsSource = Business.GetMoeinStructureDefineBusiness().GetMoeins()
                    .Where(i => i.FirstLevelName.Contains(txtSearch.Text) || i.SecondLevelName.Contains(txtSearch.Text)
                        || i.ThirdLevelName.Contains(txtSearch.Text) || i.FirstLevelCode.Contains(txtSearch.Text)
                        || i.SecondLevelCode.Contains(txtSearch.Text) || i.ThirdLevelCode.Contains(txtSearch.Text)).ToList();
            }
            else
            {
                grdLoanInsurance.ItemsSource = Business.GetMoeinStructureDefineBusiness().GetMoeins().ToList();
            }
        }

        private void GridTafzili_Click(object sender, RoutedEventArgs e)
        {
            //Guid id = Guid.Empty;
            MoeinReport MoeinReport = null;
            if (grdLoanInsurance.SelectedValue != null)
            {
                MoeinReport = grdLoanInsurance.SelectedValue as MoeinReport;
                TaienSotoheTafsili tafsili = new TaienSotoheTafsili(MoeinReport);
                tafsili.ShowDialog();
            }
        }

        private void txtJustPersian(object sender, TextCompositionEventArgs e)
        {            
            c.JustPersian(e);
        }
    }
}
