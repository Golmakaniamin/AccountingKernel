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
using AccountigKernel;
using Stimulsoft.Report;
namespace AccountingKernel.Forms.Document
{
    /// <summary>
    /// Interaction logic for frm_modAsnad.xaml
    /// </summary>
    /// 
   

    public partial class frm_modAsnad : Window
    {
        string[,] ss;
        int cc;

        public frm_modAsnad()
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
                var statauses = Business.GetBaseInfoBusiness().IQGetByType(Common.Constants.BaseInfoType.DocumentStatus);
                var jResult = Business.GetAccountingDocumentBusiness().GetAll().Join(statauses, o => o.AIdStatus, i => i.Id, (o, i) => new
                {
                    Id = o.Id,
                    ADCode = o.ADCode,
                    AIdStatus = i.AssignName,
                    ADDescription = o.ADDescription,
                    ADDate = o.ADDate,
                }).ToList();

                grid_asnad.ItemsSource = jResult.ToList();

                /////////////////////////////////////////////////////////////////////////////

                var v = jResult.ToList();
                cc = v.Count();
                ss = new string[cc,4];
                int ii = 0;
                foreach (var item in v)
                {
                    int code_ = (int)item.ADCode;
                    string stat = item.AIdStatus;
                    string d = item.ADDate;
                    string dis = item.ADDescription;
                    ss[ii, 0] = code_.ToString();
                    ss[ii, 1] = stat;
                    ss[ii, 2] = d;
                    ss[ii, 3] = dis;
                     ii++;
                }

                ///////////////////////////////////////////////////////////////////////////////
            }
            catch
            {

                throw;
            }
        }

        private void mnu_reg_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                var frmDocument = new frmDocument(Common.Enum.FormMode.New, null);
                frmDocument.ShowDialog();
                SetDataGrid();
            }
            catch
            {

                throw;
            }
        }

        private void mnu_edit_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (grid_asnad.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);

                Guid documentId = (grid_asnad.SelectedValue as dynamic).Id;
                var document = Business.GetAccountingDocumentBusiness().GetById(documentId);
                if (document.AIdStatus != Common.Constants.DocumentStatus.Draft)
                    throw new Exception(Localize.ex_invalid_record_status);

                var frmDocument = new frmDocument(Common.Enum.FormMode.Edit, document);
                frmDocument.ShowDialog();
                SetDataGrid();

            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void mnu_rem_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (grid_asnad.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);

                Guid documentId = (grid_asnad.SelectedValue as dynamic).Id;
                var document = Business.GetAccountingDocumentBusiness().GetById(documentId);
                if (document.AIdStatus != Common.Constants.DocumentStatus.Draft)
                    throw new Exception(Localize.ex_invalid_record_status);

                Business.GetAccountingDocumentBusiness().Delete(Business.GetAccountingDocumentBusiness().GetById(documentId));
                SetDataGrid();
            }
            catch
            {

                throw;
            }
        }

        private void set_to_excell(string[,] a , int rowC)
        {
            ExcelImpExp.ExportToExcel exp = new ExcelImpExp.ExportToExcel();
            var table = new System.Data.DataTable();

           
            table = exp.get_dataGridColumnNames(grid_asnad);

            for ( int i = 0 ; i<= rowC-1; i++ )
            {
                var row = table.NewRow();
                /*
                row[this.grid_asnad.Columns[i + 1].Header.ToString()] = int.Parse(a[i, 0].ToString());
                row[this.grid_asnad.Columns[i + 1].Header.ToString()] = a[i, 1];
                row[this.grid_asnad.Columns[i + 1].Header.ToString()] = a[i, 2];
                row[this.grid_asnad.Columns[i + 1].Header.ToString()] = a[i, 3];
               */

                for (int j = 0; j <= 3 ; j++)
                {
                    if ( j == 0)
                    row[this.grid_asnad.Columns[j + 1].Header.ToString()] = int.Parse(a[i, j].ToString());
                    else
                    row[this.grid_asnad.Columns[j + 1].Header.ToString()] = a[i, j];
                }

                    table.Rows.Add(row);
            }


            DataSet ds = new DataSet("New_DataSet");
            ds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;
            ds.Tables.Add(table);  
            exp.showStuff(ds);

        }

        private void BtnExel_Click(object sender, RoutedEventArgs e)
        {

            set_to_excell(ss, cc);
    
          
         }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            var statauses = Business.GetBaseInfoBusiness().IQGetByType(Common.Constants.BaseInfoType.DocumentStatus);
            var jResult = Business.GetAccountingDocumentBusiness().GetAll().Join(statauses, o => o.AIdStatus, i => i.Id, (o, i) => new
            {
                Id = o.Id,
                ADCode = o.ADCode,
                AIdStatus = i.AssignName,
                ADDescription = o.ADDescription,
                ADDate = o.ADDate,
            }).ToList();
            var vv = jResult.ToList();


            if (txtSearch.Text.Length > 0) // agar text khali nabood
            {
                vv = vv.Where(i => i.AIdStatus.Contains(txtSearch.Text) == true || i.ADDate.Contains(txtSearch.Text) == true).ToList();
            }


            StiReport report = new StiReport();
            report.Load(@".\\Report\\Accountancy\\frm_modAsnad.mrt");
            report.RegData("vv", vv);
            report.Show();
        }

       
        private void set_data_grid()//search
        {
            var statauses = Business.GetBaseInfoBusiness().IQGetByType(Common.Constants.BaseInfoType.DocumentStatus);
            var jResult = Business.GetAccountingDocumentBusiness().GetAll().Join(statauses, o => o.AIdStatus, i => i.Id, (o, i) => new
            {
                Id = o.Id,
                ADCode = o.ADCode,
                AIdStatus = i.AssignName,
                ADDescription = o.ADDescription,
                ADDate = o.ADDate,
            }).ToList();

            string str = txtSearch.Text.Trim();
            jResult = jResult.Where(i => i.AIdStatus.Contains(str) == true || i.ADDate.Contains(str)).ToList();
            grid_asnad.ItemsSource = jResult;
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
           set_data_grid();
         }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var frmDocument = new frmDocument(Common.Enum.FormMode.New, null);
                frmDocument.ShowDialog();
                SetDataGrid();
            }
            catch
            {

                throw;
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (grid_asnad.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);

                Guid documentId = (grid_asnad.SelectedValue as dynamic).Id;
                var document = Business.GetAccountingDocumentBusiness().GetById(documentId);
                if (document.AIdStatus != Common.Constants.DocumentStatus.Draft)
                    throw new Exception(Localize.ex_invalid_record_status);

                var frmDocument = new frmDocument(Common.Enum.FormMode.Edit, document);
                frmDocument.ShowDialog();
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
                if (grid_asnad.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);

                Guid documentId = (grid_asnad.SelectedValue as dynamic).Id;
                var document = Business.GetAccountingDocumentBusiness().GetById(documentId);
                if (document.AIdStatus != Common.Constants.DocumentStatus.Draft)
                    throw new Exception(Localize.ex_invalid_record_status);

                Business.GetAccountingDocumentBusiness().Delete(Business.GetAccountingDocumentBusiness().GetById(documentId));
                SetDataGrid();
            }
            catch
            {

                throw;
            }
        }
    
    }
}
