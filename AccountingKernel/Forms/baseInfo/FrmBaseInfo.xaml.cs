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
using System.Data;
using Stimulsoft.Report;
using System.IO;
using System.Data.SqlClient;
using System.Globalization;


namespace AccountingKernel.Forms.baseInfo
{
    /// <summary>
    /// Interaction logic for frm_list_bank.xaml
    /// </summary>
    public partial class FrmBaseInfo : Window
    {
        string[,] ss;
        int cc; 
        Guid? BaseInfoTypeId;
        public Guid? Result;

        public FrmBaseInfo()
        {
            try
            {
                InitializeComponent();

            }
            catch
            {

                throw;
            }
        }

        public FrmBaseInfo(Guid baseInfoTypeId)
        {
            try
            {
                this.BaseInfoTypeId = baseInfoTypeId;
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
                var iqBaeInfo = Business.GetBaseInfoBusiness().GetAll();


                if (this.BaseInfoTypeId.HasValue)
                    iqBaeInfo = iqBaeInfo.Where(r => r.PID == this.BaseInfoTypeId);

                if (txtSearch.Text.Trim().Length > 0)
                    iqBaeInfo = iqBaeInfo.Where(r => r.AssignName.Contains(txtSearch.Text));

                grdBaseInfo.ItemsSource = iqBaeInfo.ToList();

                var v = iqBaeInfo.ToList();
                cc = v.Count();
                ss = new string[cc, 1];
                int ii = 0;
                foreach (var item in v)
                {
                    string Name = item.AssignName;

                    ss[ii, 0] = Name;

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


            table = exp.get_dataGridColumnNames(grdBaseInfo);

            for (int i = 0; i <= rowC - 1; i++)
            {
                var row = table.NewRow();
                               for (int j = 0; j <= 0; j++)
                {
                    row[this.grdBaseInfo.Columns[j].Header.ToString()] = a[i, j].ToString();
                }

                table.Rows.Add(row);
            }


            DataSet ds = new DataSet("New_DataSet");
            ds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;
            ds.Tables.Add(table);
            exp.showStuff(ds);

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BaseinfoSelected();
            }
            catch 
            {
                
                throw;
            }
        }

        private void BaseinfoSelected()
        {
            try
            {
                if (grdBaseInfo.SelectedValue != null)
                    Result = (grdBaseInfo.SelectedValue as dynamic).Id;
                this.Close();

            }
            catch 
            {
                
                throw;
            }
        }

        private void grdBaseInfo_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                BaseinfoSelected();
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
                var frmRegisterBaseInfo = new FrmRegisterBaseInfo();
                frmRegisterBaseInfo.PID = Common.Constants.BaseInfoType.Repository;
                frmRegisterBaseInfo.ShowDialog();
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
                if (grdBaseInfo.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);
                var frmRegisterBaseInfo = new FrmRegisterBaseInfo((grdBaseInfo.SelectedValue as dynamic).Id);
                frmRegisterBaseInfo.ShowDialog();
                SetDataGrid();
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
        public class Item
        {
            public int Id { get; set; }
            public double Price { get; set; }
            public string Genre { get; set; }
        }

        public class Book : Item
        {
            public string Author { get; set; }
        }

        public class Movie : Item
        {
            public string Director { get; set; }
        }

        AccountingKernelEntities10 ak = new AccountingKernelEntities10();
        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            StiReport report = new StiReport();

            IQueryable<BaseInfo> t = ak.BaseInfoes;

            var iqBasedInfo = t;

            if (txtSearch.Text.Trim().Length > 0)
                iqBasedInfo = iqBasedInfo.Where(r => r.AssignName.Contains(txtSearch.Text));

            iqBasedInfo = iqBasedInfo.Where(i => i.PID == this.BaseInfoTypeId);

            report.Load(@"D:\New folder (2)\accountingKernel\AccountingKernel\Debug_AccountingKernel\Report\FrmBaseInfo.mrt");

            report.RegData("iqBasedInfo", iqBasedInfo);

            report.Show();
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var frmRegisterBaseInfo = new FrmRegisterBaseInfo();
                frmRegisterBaseInfo.PID = Common.Constants.BaseInfoType.Repository;
                frmRegisterBaseInfo.ShowDialog();
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
                if (grdBaseInfo.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);
                var frmRegisterBaseInfo = new FrmRegisterBaseInfo((grdBaseInfo.SelectedValue as dynamic).Id);
                frmRegisterBaseInfo.ShowDialog();
                SetDataGrid();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }


    }
}
