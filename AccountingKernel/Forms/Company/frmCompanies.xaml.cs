using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Common;
using System.Transactions;
using Data;
using System.Data;
using Stimulsoft.Report;

namespace AccountingKernel.Forms.Company
{
    /// <summary>
    /// Interaction logic for Document.xaml
    /// </summary>
    public partial class frmCompanies : Window
    {
        string[,] ss;
        int cc;

        public Guid Result { get; set; }
        private Guid? CustomerTypeId;
        public frmCompanies()
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

        public frmCompanies(Guid customerTypeId)
        {
            try
            {
                this.CustomerTypeId = customerTypeId;
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
                var iqcompanies = Business.GetComBusiness().GetAll();

                if (CustomerTypeId.HasValue)
                    iqcompanies = iqcompanies.Where(r => r.CType == CustomerTypeId);

                if (txtSearch.Text != string.Empty)
                {
                    var searchIntValue = txtSearch.Text.ToNullableInt();
                    iqcompanies = iqcompanies.Where(r => r.CName.Contains(txtSearch.Text) ||
                        (r.CRegisterNo.HasValue && r.CRegisterNo.Value == searchIntValue) ||
                        r.CNationalCode.Contains(txtSearch.Text) || r.CEconomyCode.Contains(txtSearch.Text) || r.CPostalCode.Contains(txtSearch.Text) ||
                        r.CAddress.Contains(txtSearch.Text) || r.CPostalCode.Contains(txtSearch.Text) || r.CTell.Contains(txtSearch.Text) ||
                        r.CMobile.Contains(txtSearch.Text) || r.CFax.Contains(txtSearch.Text) || r.CEMail.Contains(txtSearch.Text) ||
                        r.CWebsite.Contains(txtSearch.Text));
                }

                var jResult = iqcompanies.ToList().Join(Business.GetBaseInfoBusiness().GetByType(Constants.BaseInfoType.Personality), o => o.CPersonType, i => i.Id,
                    (o, i) => new { Company = o, Type = i });
                var vv = jResult.Select(r => new
                {
                    Id = r.Company.Id,
                    Name = r.Company.CName,
                    Type = r.Type.AssignName,
                    RegNationalCode = string.Concat(r.Company.CNationalCode, r.Company.CRegisterNo),
                    EconomyCode = r.Company.CEconomyCode
                }).ToList();
                this.grdCompany.ItemsSource = vv;
                var v = jResult.ToList();
                cc = v.Count();
                ss = new string[cc, 4];
                int ii = 0;
                foreach (var item in vv)
                {
                    string Name = item.Name;
                    string Noe = item.Type;
                    string Sh_S_M = item.RegNationalCode;
                    string C_E = item.EconomyCode;

                    ss[ii, 0] = Name;
                    ss[ii, 1] = Noe;
                    ss[ii, 2] = Sh_S_M;
                    ss[ii, 3] = C_E;

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


            table = exp.get_dataGridColumnNames(grdCompany);

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
                    //    row[this.grdCompany.Columns[j + 1].Header.ToString()] = int.Parse(a[i, j].ToString());
                    //else
                    row[this.grdCompany.Columns[j + 1].Header.ToString()] = a[i, j];
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
                //var frmRegisterCompanies = new frmRegisterCompanies();
                var frmRegisterCompanies = new frmRegister();
                frmRegisterCompanies.ShowDialog();
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
                if (grdCompany.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);

                Guid id;
                id = (grdCompany.SelectedValue as dynamic).Id;
                //var frmRegisterCompanies = new frmRegisterCompanies(id);
                var frmRegisterCompanies = new frmRegister(id);
                frmRegisterCompanies.ShowDialog();
                SetDataGrid();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }

        }

        private void MenuItem_UnitCount(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //new frmUnitCount().Show((DataGrid.SelectedValue as dynamic).Id);

            //SetDataGrid();
        }

        private void MenuItem_Delete(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                if (grdCompany.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);

                var msgResult = MessageBox.Show(Localize.DeleteRecordMessage, Localize.DeleteRecordCaption, MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (msgResult != MessageBoxResult.Yes)
                    return;

                Guid id = (grdCompany.SelectedValue as dynamic).Id;

                var companyBusiness = Business.GetComBusiness();
                //var companyDetailBusiness = Business.GetCompanyDetailBusiness();
                var company = companyBusiness.GetById(id);
                //var companyDetail = companyDetailBusiness.GetByCompanyId(company.Id);
                //companyDetailBusiness.Delete(companyDetail.ToList());
                companyBusiness.Delete(company);

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

        private void grdCompany_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void grdCompany_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                SelectCompany();

            }
            catch
            {

                throw;
            }
        }

        private void SelectCompany()
        {
            try
            {
                if (grdCompany.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);

                this.Result = (grdCompany.SelectedValue as dynamic).Id;
                this.Close();

            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void btnSelectCompany_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SelectCompany();
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
            var iqcompanies = Business.GetComBusiness().GetAll();

            if (CustomerTypeId.HasValue)
                iqcompanies = iqcompanies.Where(r => r.CType == CustomerTypeId);

            if (txtSearch.Text != string.Empty)
            {
                var searchIntValue = txtSearch.Text.ToNullableInt();
                iqcompanies = iqcompanies.Where(r => r.CName.Contains(txtSearch.Text) ||
                    (r.CRegisterNo.HasValue && r.CRegisterNo.Value == searchIntValue) ||
                    r.CNationalCode.Contains(txtSearch.Text) || r.CEconomyCode.Contains(txtSearch.Text) || r.CPostalCode.Contains(txtSearch.Text) ||
                    r.CAddress.Contains(txtSearch.Text) || r.CPostalCode.Contains(txtSearch.Text) || r.CTell.Contains(txtSearch.Text) ||
                    r.CMobile.Contains(txtSearch.Text) || r.CFax.Contains(txtSearch.Text) || r.CEMail.Contains(txtSearch.Text) ||
                    r.CWebsite.Contains(txtSearch.Text));
            }

            var jResult = iqcompanies.ToList().Join(Business.GetBaseInfoBusiness().GetByType(Constants.BaseInfoType.Personality), o => o.CPersonType, i => i.Id,
                (o, i) => new { Company = o, Type = i });
            var vv = jResult.Select(r => new
            {
                Id = r.Company.Id,
                Name = r.Company.CName,
                Type = r.Type.AssignName,
                RegNationalCode = string.Concat(r.Company.CNationalCode, r.Company.CRegisterNo),
                EconomyCode = r.Company.CEconomyCode
            }).ToList();

            StiReport report = new StiReport();

            report.Load(@".\\Report\\Basic_Information\\frmCompanies.mrt");

            report.RegData("vv", vv);

            report.Show();
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //var frmRegisterCompanies = new frmRegisterCompanies();
                var frmRegisterCompanies = new frmRegister();
                frmRegisterCompanies.ShowDialog();
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
                if (grdCompany.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);

                Guid id;
                id = (grdCompany.SelectedValue as dynamic).Id;
                //var frmRegisterCompanies = new frmRegisterCompanies(id);
                var frmRegisterCompanies = new frmRegister(id);
                frmRegisterCompanies.ShowDialog();
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
                if (grdCompany.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);

                var msgResult = MessageBox.Show(Localize.DeleteRecordMessage, Localize.DeleteRecordCaption, MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (msgResult != MessageBoxResult.Yes)
                    return;

                Guid id = (grdCompany.SelectedValue as dynamic).Id;

                var companyBusiness = Business.GetComBusiness();
                //var companyDetailBusiness = Business.GetCompanyDetailBusiness();
                var company = companyBusiness.GetById(id);
                //var companyDetail = companyDetailBusiness.GetByCompanyId(company.Id);
                //companyDetailBusiness.Delete(companyDetail.ToList());
                companyBusiness.Delete(company);

                SetDataGrid();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

    }
}
