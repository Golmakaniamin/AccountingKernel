using System;
using Data;
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
using System.Data.Entity;
using Common;
using System.Collections;
using System.Data;
using AccountingKernel.Forms;
using Stimulsoft.Report;

namespace AccountingKernel
{
    /// <summary>
    /// Interaction logic for PayrollSentencesSubmit.xaml
    /// </summary>
    public partial class PayrollSentencesSubmit : Window
    {
        string[,] ss;
        int cc; 

        private bool IsSelected;
        private Guid PersonID;
        private System.Guid _personID;
        private bool p;
        private List<System.Guid?> l;


        public PayrollSentencesSubmit()
        {
            InitializeComponent();
            loadGridLinq();
        }

        public PayrollSentencesSubmit(bool HaveCheckBox, Guid PersonID, List<Guid?> SentencesID)
        {
            InitializeComponent();
            loadGridLinq();

            grdBenefitAndDeductionsLists.ItemsSource = Business.GetPayrollSentencesBusiness().GetItems().Where(r => !SentencesID.Contains(r.PayrollSentencesID)).ToList();
            DataGridCheckBoxColumn chbSentence = new DataGridCheckBoxColumn();
            Binding chbBinding = new Binding("IsSelected");
            chbSentence.Header = "انتخاب";
            chbSentence.Binding = chbBinding;

            grdBenefitAndDeductionsLists.Columns.Add(chbSentence);
            this.PersonID = PersonID;

            IsSelected = true;
        }

        private void loadGridLinq()
        {
            grdBenefitAndDeductionsLists.ItemsSource = Business.GetPayrollSentencesBusiness().GetItems().ToList();
            var v = Business.GetPayrollSentencesBusiness().GetItems().ToList();
            
                cc = v.Count();
                ss = new string[cc,9];
                int ii = 0;
                foreach (var item in v)
                {
                    string k_v_m = item.PrSTypeDesc;
                    string N_ = item.PrSOTypeDesc;
                    string Onv_ = item.PrSDescription;
                    string Mablagh = item.PrSMoney.ToString();
                    string Bime = item.PrSIsInsurance.ToString();
                    string Maliayat = item.PrSIsTax.ToString();
                    string D_B_K_F = item.PrSInsuranceEmployer;
                    string D_B_B = item.PrSInsuranceUnemployment;
                    string D_B_P = item.PrSInsuranceEmployee;

                    ss[ii, 0] = k_v_m;
                    ss[ii, 1] = N_;
                    ss[ii, 2] = Onv_;
                    ss[ii, 3] = Mablagh;
                    ss[ii, 4] = Bime;
                    ss[ii, 5] = Maliayat;
                    ss[ii, 6] = D_B_K_F;
                    ss[ii, 7] = D_B_B;
                    ss[ii, 8] = D_B_P;
                    ii++;
                }            
        }

          private void set_to_excell(string[,] a, int rowC)
        {
       
        //   AccountingKernel.Forms.


            ExcelImpExp.ExportToExcel exp = new ExcelImpExp.ExportToExcel();

            var table = new System.Data.DataTable();
            
            table = exp.get_dataGridColumnNames(grdBenefitAndDeductionsLists);

            for (int i = 0; i <= rowC - 1; i++)
            {
                var row = table.NewRow();
                for (int j = 0, b = 0; j <= 10; j++)
                {
                    if (j != 2 && j != 3)
                    {
                        row[this.grdBenefitAndDeductionsLists.Columns[j + 1].Header.ToString()] = a[i, b];
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
            //loadGridLinq();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            loadGridLinq();
        }

        private void Gridnew_Click(object sender, RoutedEventArgs e)
        {
            new PayrollSentencesSubmitChild(null).Show();
            this.Close();
        }

        private void GridEdit_Click(object sender, RoutedEventArgs e)
        {
            if (grdBenefitAndDeductionsLists.SelectedValue != null)
            {
                try
                {
                    Data.PayrollSentence myData = new PayrollSentence();
                    myData.ID = (grdBenefitAndDeductionsLists.SelectedValue as dynamic).ID;
                    myData.PrSType = (grdBenefitAndDeductionsLists.SelectedValue as dynamic).PrSType;
                    myData.PrSOType = (grdBenefitAndDeductionsLists.SelectedValue as dynamic).PrSOType;
                    myData.PrSDescription = (grdBenefitAndDeductionsLists.SelectedValue as dynamic).PrSDescription;
                    myData.PrSMoney = (grdBenefitAndDeductionsLists.SelectedValue as dynamic).PrSMoney;
                    myData.PrSIsInsurance = (grdBenefitAndDeductionsLists.SelectedValue as dynamic).PrSIsInsurance;
                    myData.PrSIsTax = (grdBenefitAndDeductionsLists.SelectedValue as dynamic).PrSIsTax;
                    myData.PrSInsuranceEmployer = (grdBenefitAndDeductionsLists.SelectedValue as dynamic).PrSInsuranceEmployer;
                    myData.PrSInsuranceUnemployment = (grdBenefitAndDeductionsLists.SelectedValue as dynamic).PrSInsuranceUnemployment;
                    myData.PrSInsuranceEmployee = (grdBenefitAndDeductionsLists.SelectedValue as dynamic).PrSInsuranceEmployee;
                    new PayrollSentencesSubmitChild(myData).ShowDialog();
                }
                catch
                {

                    throw;
                }
                loadGridLinq();
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (IsSelected)
            {
                List<Data.PayrollPersonSentence> _personSentence = new List<PayrollPersonSentence>();

                foreach (var item in grdBenefitAndDeductionsLists.ItemsSource)
                {
                    if ((item as dynamic).IsSelected)
                    {
                        Data.PayrollPersonSentence _entity = new PayrollPersonSentence();
                        _entity.IDPayrollPerson = PersonID;
                        _entity.IDPayrollSentences = (item as dynamic).PayrollSentencesID;
                        _entity.PrPSMoney = (item as dynamic).PrSMoney;
                        _personSentence.Add(_entity);
                    }
                }
                Business.GetPayrollPersonSentencesBusiness().Save(_personSentence);
            }
            this.Close();
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            new PayrollSentencesSubmitChild(null).Show();
            this.Close();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (grdBenefitAndDeductionsLists.SelectedValue != null)
            {
                try
                {
                    Data.PayrollSentence myData = new PayrollSentence();
                    myData.ID = (grdBenefitAndDeductionsLists.SelectedValue as dynamic).ID;
                    myData.PrSType = (grdBenefitAndDeductionsLists.SelectedValue as dynamic).PrSType;
                    myData.PrSOType = (grdBenefitAndDeductionsLists.SelectedValue as dynamic).PrSOType;
                    myData.PrSDescription = (grdBenefitAndDeductionsLists.SelectedValue as dynamic).PrSDescription;
                    myData.PrSMoney = (grdBenefitAndDeductionsLists.SelectedValue as dynamic).PrSMoney;
                    myData.PrSIsInsurance = (grdBenefitAndDeductionsLists.SelectedValue as dynamic).PrSIsInsurance;
                    myData.PrSIsTax = (grdBenefitAndDeductionsLists.SelectedValue as dynamic).PrSIsTax;
                    myData.PrSInsuranceEmployer = (grdBenefitAndDeductionsLists.SelectedValue as dynamic).PrSInsuranceEmployer;
                    myData.PrSInsuranceUnemployment = (grdBenefitAndDeductionsLists.SelectedValue as dynamic).PrSInsuranceUnemployment;
                    myData.PrSInsuranceEmployee = (grdBenefitAndDeductionsLists.SelectedValue as dynamic).PrSInsuranceEmployee;
                    new PayrollSentencesSubmitChild(myData).ShowDialog();
                }
                catch
                {

                    throw;
                }
                loadGridLinq();
            }
        }

        private void BtnExel_Click(object sender, RoutedEventArgs e)
        {
            set_to_excell(ss, cc);
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            var v = Business.GetPayrollSentencesBusiness().GetItems().ToList();

            if (txtSearch.Text.Trim().Length > 0)
            {
                v = Business.GetPayrollSentencesBusiness().GetItems().Where(i => i.PrSTypeDesc.Contains(txtSearch.Text) || i.PrSOTypeDesc.Contains(txtSearch.Text)).ToList();
            }
            else
            {
                grdBenefitAndDeductionsLists.ItemsSource = Business.GetPayrollSentencesBusiness().GetItems().ToList();
            }
            StiReport report = new StiReport();
            report.Load(@".\\Report\\Payroll\\PayrollSentencesSubmit.mrt");
            report.RegData("v", v);
            report.Show();
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
          
            if (txtSearch.Text.Trim().Length>0)
            {
                grdBenefitAndDeductionsLists.ItemsSource = Business.GetPayrollSentencesBusiness().GetItems().Where(i => i.PrSTypeDesc.Contains(txtSearch.Text) || i.PrSOTypeDesc.Contains(txtSearch.Text)).ToList();
            }
            else
            {
                grdBenefitAndDeductionsLists.ItemsSource = Business.GetPayrollSentencesBusiness().GetItems().ToList();
            }
        }

    }
}

