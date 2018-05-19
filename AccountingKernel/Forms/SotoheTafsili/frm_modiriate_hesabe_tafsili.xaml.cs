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

namespace AccountingKernel.Forms.SotoheTafsili
{
    /// <summary>
    /// Interaction logic for frm_modiriate_hesabe_tafsili.xaml
    /// </summary>
    /// 

    public class get_set_moien_id_hesabeTafsili
    {
       

        public static string moien_id_1;

        /*public string get_set_moien_id_
        {
            get { return get_set_moien_id_; }
            set { get_set_moien_id_ = value; }
        }*/


    }
    public partial class frm_modiriate_hesabe_tafsili : Window
    {
        string[,] ss;
        int cc; 
        AccountingKernelEntities10 ak = new AccountingKernelEntities10();

        public frm_modiriate_hesabe_tafsili()
        {
            InitializeComponent();
        }

        // mnu_rem_Click_1
        private void mnu_rem_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (grd_AccountingTafsillevelsDetails.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);

                var msgResult = MessageBox.Show(Localize.DeleteRecordMessage, Localize.DeleteRecordCaption, MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (msgResult != MessageBoxResult.Yes)
                    return;


                var atldBusiness = Business.GetAccountingTafsilLevelDetailBusiness();

                Guid id = (grd_AccountingTafsillevelsDetails.SelectedValue as dynamic).Id;
                var atld = atldBusiness.GetById(id);
                var atlds = atldBusiness.GetByIdAccountingTafsilLevels(atld.IdAccountingTafsilLevels).ToList();

                atldBusiness.Delete(atlds);

                SetDataGrid();

            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }

        }

        private void mnu_reg_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                var frmths = new SotoheTafsili.frm_tarife_hesabe_tafsili();
                frmths.ShowDialog();

                grd_AccountingTafsillevelsDetails.ItemsSource = ak.AccountingTafsillevelsDetails.ToList();

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
                if (grd_AccountingTafsillevelsDetails.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);

                Guid id = (grd_AccountingTafsillevelsDetails.SelectedValue as dynamic).Id;
                var frmths = new SotoheTafsili.frm_tarife_hesabe_tafsili(id);
                frmths.ShowDialog();

                grd_AccountingTafsillevelsDetails.ItemsSource = ak.AccountingTafsillevelsDetails.ToList();
            }
            catch 
            {
                
                throw;
            }
        }

        private void grd_AccountingTafsillevelsDetails_Loaded(object sender, RoutedEventArgs e)
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

        private void SetDataGrid()
        {
            try
            {
                grd_AccountingTafsillevelsDetails.ItemsSource = Business.GetAccountingTafsilLevelDetailBusiness().GetAll().ToList();
                var v = Business.GetAccountingTafsilLevelDetailBusiness().GetAll().ToList();
                cc = v.Count();
                ss = new string[cc, 4];
                int ii = 0;
                foreach (var item in v)
                {
                    string Code1 = item.Id.ToString();
                    string Name = item.ATLName;
                    string N_L = item.ATLNameEn;
                    string Code2 = item.IdIn;

                    ss[ii, 0] = Code1;
                    ss[ii, 1] = Name;
                    ss[ii, 2] = N_L;
                    ss[ii, 3] = Code2;
                  
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


            table = exp.get_dataGridColumnNames(grd_AccountingTafsillevelsDetails);

            for (int i = 0; i <= rowC-1; i++)
            {
                var row = table.NewRow();
                /*
                row[this.grid_asnad.Columns[i + 1].Header.ToString()] = int.Parse(a[i, 0].ToString());
                row[this.grid_asnad.Columns[i + 1].Header.ToString()] = a[i, 1];
                row[this.grid_asnad.Columns[i + 1].Header.ToString()] = a[i, 2];
                row[this.grid_asnad.Columns[i + 1].Header.ToString()] = a[i, 3];
               */

                for (int j = 0; j <=3; j++)
                {
                    //if (j == 0)
                    //    row[this.grd_AccountingTafsillevelsDetails.Columns[j].Header.ToString()] = int.Parse(a[i, j].ToString());
                    //else
                        row[this.grd_AccountingTafsillevelsDetails.Columns[j].Header.ToString()] = a[i, j];
                }

                table.Rows.Add(row);
            }


            DataSet ds = new DataSet("New_DataSet");
            ds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;
            ds.Tables.Add(table);
            exp.showStuff(ds);

        }


        private void txt_search_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txt_search.Text == "")
            {
                grd_AccountingTafsillevelsDetails.ItemsSource = ak.AccountingTafsillevelsDetails.ToList();
            }
        }

        private void txt_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_search.Text == "")
            {
                grd_AccountingTafsillevelsDetails.ItemsSource = ak.AccountingTafsillevelsDetails.ToList();
            }

            List<AccountingTafsillevelsDetail> atld = ak.AccountingTafsillevelsDetails.Where(i => i.
                ATLName.Contains(txt_search.Text) || i.IdIn.Contains(txt_search.Text)).ToList();

            grd_AccountingTafsillevelsDetails.ItemsSource = atld;
        }

        private void BtnExel_Click(object sender, RoutedEventArgs e)
        {
            set_to_excell(ss, cc);
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            StiReport report = new StiReport();

            IQueryable<AccountingTafsillevelsDetail> t = ak.AccountingTafsillevelsDetails;

            var iqTafsil = t;

            if (txt_search.Text.Trim().Length > 0)
                iqTafsil = iqTafsil.Where(r => r.ATLName.Contains(txt_search.Text));

            report.Load(@"D:\New folder (2)\accountingKernel\AccountingKernel\Debug_AccountingKernel\Report\modiriate_hesabe_tafsili.mrt");

            report.RegData("testt", iqTafsil);
            report.Compile();
            report.Show();
            
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var frmths = new SotoheTafsili.frm_tarife_hesabe_tafsili();
                frmths.ShowDialog();

                grd_AccountingTafsillevelsDetails.ItemsSource = ak.AccountingTafsillevelsDetails.ToList();

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
                if (grd_AccountingTafsillevelsDetails.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);

                Guid id = (grd_AccountingTafsillevelsDetails.SelectedValue as dynamic).Id;
                var frmths = new SotoheTafsili.frm_tarife_hesabe_tafsili(id);
                frmths.ShowDialog();

                grd_AccountingTafsillevelsDetails.ItemsSource = ak.AccountingTafsillevelsDetails.ToList();
            }
            catch
            {

                throw;
            }
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (grd_AccountingTafsillevelsDetails.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);

                var msgResult = MessageBox.Show(Localize.DeleteRecordMessage, Localize.DeleteRecordCaption, MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (msgResult != MessageBoxResult.Yes)
                    return;


                var atldBusiness = Business.GetAccountingTafsilLevelDetailBusiness();

                Guid id = (grd_AccountingTafsillevelsDetails.SelectedValue as dynamic).Id;
                var atld = atldBusiness.GetById(id);
                var atlds = atldBusiness.GetByIdAccountingTafsilLevels(atld.IdAccountingTafsilLevels).ToList();

                atldBusiness.Delete(atlds);

                SetDataGrid();

            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }


    }
}
