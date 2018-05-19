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
//using LinqLib.Sequence;
using System.Data;
using System.Data.Objects;
using System.Data.Common;

namespace AccountingKernel.Forms
{
    /// <summary>
    /// Interaction logic for PayrollFunction.xaml
    /// </summary>
    public partial class PayrollFunction : Window
    {

        Dictionary<Guid, string> Map = null;
        DataTable dt = null;
        List<Data.PayrollPersonWorkDone> WorkDownList = null;
        public PayrollFunction()
        {
            InitializeComponent();
            InitializeGrid();
            Map = Business.GetPayrollWorkDoneFactorsBussines().GetDic();
            WorkDownList = Business.GetPayrollPersonWorkDoneBusiness().GetAll().ToList();
        }

        private void InitializeGrid()
        {
            var Person = Business.GetPayrollPersonWorkDoneBusiness().GetPerson().ToList();

            dt = new DataTable();
            // Create the DataColumns for the data table
            DataColumn dc = new DataColumn("شناسه پرسنل", typeof(Guid));
            dt.Columns.Add(dc);
            dc = new DataColumn("شناسه", typeof(Guid));
            dt.Columns.Add(dc);
            dc = new DataColumn("نام", typeof(string));
            dt.Columns.Add(dc);
            dc = new DataColumn("نام خانوادگی", typeof(string));
            dt.Columns.Add(dc);
            //TODO : when add Finance year change here
            //dc = new DataColumn("Financialyear", typeof(Guid));
            //dt.Columns.Add(dc);

            var Headers = (from header in Person.Select(r => r.FactorHeader)
                           from h in header
                           select h.ToString()).Distinct().ToList();

            // Create the DataColumns for the table
            Headers.ForEach(delegate(string head)
            {
                dc = new DataColumn(head, typeof(string));
                dt.Columns.Add(dc);
            });
            // Populate the rowa of the DataTable
            foreach (var rec in Person)
            {
                // The first two columns of the row always has a ISO Code and Description
                DataRow dr = dt.NewRow();
                dr[0] = rec.PersonID;
                dr[1] = rec.ID;
                dr[2] = rec.PersonFirstName;
                dr[3] = rec.PersonLastName;
                //TODO : when add Finince year change here again
                //dr[4] = rec.Financialyear;

                // For each record
                var headers = rec.FactorHeader.ToList();
                var values = rec.PersonContent.ToList();
                for (int i = 0; i < values.Count; i++)
                {
                    dr[headers[i].ToString()] = values[i];
                }

                // Add the DataRow to the DataTable
                dt.Rows.Add(dr);
            }
            grdFuntion.ItemsSource = dt.AsDataView();
        }

        private void grdFuntion_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                var HeaderID = Map.Where(r => r.Value == (e.Column.Header.ToString())).Select(r => r.Key).FirstOrDefault();
                Guid? PersonID = (Guid?)(e.Row.Item as DataRowView)[0];
                var Content = (e.EditingElement as TextBox).Text;

                if (string.IsNullOrEmpty(Content))
                    return;

                var Row = WorkDownList.Find(r => r.IDPayrollPerson == PersonID && r.IDPayrollWorkDoneFactors == HeaderID);
                if (Row == null)
                {
                    Data.PayrollPersonWorkDone entity = new Data.PayrollPersonWorkDone();
                    entity.IDPayrollPerson = PersonID;
                    entity.IDPayrollWorkDoneFactors = HeaderID;
                    WorkDownList.Add(entity);
                }
                else
                    Row.PrPWContent = Content;
            }
            else MessageBox.Show("error", "Not Commited");

        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {

            Business.GetPayrollPersonWorkDoneBusiness().Save(WorkDownList);
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var index = grdFuntion.Columns.Single(c => c.Header.ToString() == "شناسه پرسنل").DisplayIndex;
                grdFuntion.Columns[index].Visibility = System.Windows.Visibility.Hidden;
                index = grdFuntion.Columns.Single(c => c.Header.ToString() == "شناسه").DisplayIndex;
                grdFuntion.Columns[index].Visibility = System.Windows.Visibility.Hidden;
            }
            catch
            {

                throw;
            }

        }

    }
}
