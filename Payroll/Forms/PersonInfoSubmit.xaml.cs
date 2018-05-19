using Data;
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
using Stimulsoft.Report;
namespace AccountingKernel
{
    /// <summary>
    /// Interaction logic for PersonInfo.xaml
    /// </summary>
    public partial class PersonInfoSubmit : Window
    {
        string[,] ss;
        int cc;

        public Guid PersonId;
        private Guid _financialyear = new Guid();

        public PersonInfoSubmit()
        {
            InitializeComponent();
            loadGridLinq();
        }

        private void loadGridLinq()
        {
            var _result = Business.GetPayrollPersonBusiness().GetAll().
                Where(o => o.PPerson_Code.Contains(txtSearch.Text) ||
                    o.PFristName.Contains(txtSearch.Text) ||
                    o.PLastName.Contains(txtSearch.Text) ||
                    o.PIdNational.Contains(txtSearch.Text)
                    );
            grdPerson.ItemsSource = _result.ToList();

            var v = _result;

            cc = v.Count();
            ss = new string[cc, 9];
            int ii = 0;
            foreach (var item in v)
            {
                // string Code = item.PId;
                string Name = item.PFristName;
                string Family = item.PLastName;
                string N_Pedar = item.PFather;
                string C_Melli = item.PIdNational;
                string SH_SH = item.PSHSH;
                string Tedad = item.PNumberChild.ToString();
                string Tell = item.PPhoneHome;
                string CodePosti = item.PIdPostal;

                // ss[ii, 0] = Code;
                ss[ii, 1] = Name;
                ss[ii, 2] = Family;
                ss[ii, 3] = N_Pedar;
                ss[ii, 4] = C_Melli;
                ss[ii, 5] = SH_SH;
                ss[ii, 6] = Tedad;
                ss[ii, 7] = Tell;
                ss[ii, 8] = CodePosti;
                ii++;
            }
        }
        private void set_to_excell(string[,] a, int rowC)
        {
            ExcelImpExp.ExportToExcel exp = new ExcelImpExp.ExportToExcel();
            var table = new System.Data.DataTable();

            string[] arr_names = new string[9];//تعداد ستون            
            for (int i = 0, c = 0; i <= grdPerson.Columns.Count - 1; i++)
            {
                if (grdPerson.Columns[i].Visibility != System.Windows.Visibility.Hidden)
                {
                    arr_names[c] = grdPerson.Columns[i].Header.ToString();
                    c++;
                }
            }
            table = exp.get_dataGridColumnNames(grdPerson, arr_names);
            for (int i = 0; i <= rowC - 1; i++)
            {
                var row = table.NewRow();

                for (int j = 0, b = 0; j <= 15; j++)
                {
                    if (j == 0 || j == 1 || j == 2 || j == 3 || j == 5 || j == 6 || j == 8 || j == 9 || j == 12)
                    {
                        row[this.grdPerson.Columns[j + 1].Header.ToString()] = a[i, b];
                        b++;
                    }
                }

                table.Rows.Add(row);
            }


            DataSet ds = new DataSet("New_DataSet");
            ds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;
            ds.Tables.Add(table);
            exp.showStuff(ds);

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loadGridLinq();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            loadGridLinq();
        }

        private void Gridnew_Click(object sender, RoutedEventArgs e)
        {
            new PersonInfoSubmitChild(null).ShowDialog();
            this.Close();
        }

        private void GridEdit_Click(object sender, RoutedEventArgs e)
        {
            new PersonInfoSubmitChild(GetselectedValue()).Show();
            this.Close();
        }

        private void ContractStaffLink_Click(object sender, RoutedEventArgs e)
        {
            new PayrollContract(GetselectedValue().id).ShowDialog();
            this.Close();
        }

        private void GridDelete_Click(object sender, RoutedEventArgs e)
        {
            var me = MessageBox.Show("آیا مایل به حذف هستید", "حذف", MessageBoxButton.YesNo);
            if (me == MessageBoxResult.Yes)
            {
                try
                {
                    Business.GetPayrollPersonBusiness().Delete(GetselectedValue());
                    loadGridLinq();
                }
                catch
                {

                    throw;
                }
            }

        }
        private PayrollPerson GetselectedValue()
        {
            Guid id = Guid.Empty;
            try
            {
                if (grdPerson.SelectedValue != null)
                    id = (grdPerson.SelectedValue as dynamic).id;

                return Business.GetPayrollPersonBusiness().GetById(id);
            }
            catch
            {
                return null;
            }
        }

        private void GridLoan_Click(object sender, RoutedEventArgs e)
        {
            new PayrollAddLoan(GetselectedValue().id).Show();
            this.Close();
        }

        private void GridMPJ_Click(object sender, RoutedEventArgs e)
        {

            new PayrollMPJ(GetselectedValue().id, _financialyear).Show();
            this.Close();
        }

        private void grdPerson_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                SelectEntity();
            }
            catch
            {

                throw;
            }
        }

        private void SelectEntity()
        {
            try
            {
                if (grdPerson.SelectedItem == null)
                    return;
                this.PersonId = (grdPerson.SelectedItem as dynamic).id;
                this.Close();
            }
            catch
            {

                throw;
            }
        }

        private void btnSelect_click(object sender, RoutedEventArgs e)
        {
            try
            {
                SelectEntity();
            }
            catch
            {

                throw;
            }
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            new PersonInfoSubmitChild(null).ShowDialog();
            this.Close();
        }

        //akhari
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            new PersonInfoSubmitChild(GetselectedValue()).Show();
            this.Close();
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            var me = MessageBox.Show("آیا مایل به حذف هستید", "حذف", MessageBoxButton.YesNo);
            if (me == MessageBoxResult.Yes)
            {
                try
                {
                    Business.GetPayrollPersonBusiness().Delete(GetselectedValue());
                    loadGridLinq();
                }
                catch
                {

                    throw;
                }
            }
        }

        private void BtnExel_Click(object sender, RoutedEventArgs e)
        {

            set_to_excell(ss, cc);
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            var v = Business.GetPayrollPersonBusiness().GetAll();

            if (txtSearch.Text.Trim().Length > 0)
            {
                v = Business.GetPayrollPersonBusiness().GetAll().
                   Where(o => o.PPerson_Code.Contains(txtSearch.Text) ||
                       o.PFristName.Contains(txtSearch.Text) ||
                       o.PLastName.Contains(txtSearch.Text) ||
                       o.PIdNational.Contains(txtSearch.Text)
                       );

            }


            StiReport report = new StiReport();

            report.Load(@"D:\New folder (2)\accountingKernel\AccountingKernel\Debug_AccountingKernel\Report\PersonInfoSubmit.mrt");

            report.RegData("v", v);

            report.Show();
        }

    }
}
