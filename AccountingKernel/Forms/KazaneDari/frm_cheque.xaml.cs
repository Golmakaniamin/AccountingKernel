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
using System.Collections.ObjectModel;
using System.Windows.Controls.Primitives;
using System.Data;
using Stimulsoft.Report;
namespace AccountingKernel.Forms.tankhah
{
    /// <summary>
    /// Interaction logic for frm_cheque.xaml
    /// </summary>
    public partial class frm_cheque : Window
    {
        string[,] ss;
        int cc; 

        public frm_cheque()
        {
            InitializeComponent();
        }
        AccountingKernelEntities10 ak = new AccountingKernelEntities10();
        string ID;
        private void mnu_reg_Click_1(object sender, RoutedEventArgs e)
        {
            if (Class.Variable.Variables.noe_cheque == "2")
            {
                AccountingKernel.Forms.KazaneDari.frm_vosol_cheque frmVc = new KazaneDari.frm_vosol_cheque();
                frmVc.ShowDialog();
            }

            if (Class.Variable.Variables.noe_cheque != "2")
            {
                frm_amaliateCheque frmAmChk = new frm_amaliateCheque();
                frmAmChk.ShowDialog();

                if (Class.Variable.Variables.noe_cheque == "1") // چک خرج شده
                {
                    CheckKharjShode();
                }

                if (Class.Variable.Variables.noe_cheque == "2") // چک وصول شده
                {

                    CheckVosolShode();
                }

                if (Class.Variable.Variables.noe_cheque == "3") // ابطال چک
                {
                    CheckEbtalShode();
                }

                if (Class.Variable.Variables.noe_cheque == "4") // برگشت چک
                {
                    CheckBargasht();
                }

                if (Class.Variable.Variables.noe_cheque == "5") // استرداد چک
                {
                    CheckEsterdad();
                }

                if (Class.Variable.Variables.noe_cheque == "6") // برگشت چک خرج شده
                {
                    bargashteChequeKharjShode();
                }
            }
        }

        private void mnu_edit_Click_1(object sender, RoutedEventArgs e)
        {

        }



        private void Window_Initialized_1(object sender, EventArgs e)
        {
            loadChequeTOGridByNoeCheque();

        }

        private void loadChequeTOGridByNoeCheque()
        {
            if (Class.Variable.Variables.noe_cheque == "1") // چک خرج شده
            {
                CheckKharjShode();
            }
            if (Class.Variable.Variables.noe_cheque == "2") // وصول چک  
            {
                CheckVosolShode();
            }
            if (Class.Variable.Variables.noe_cheque == "3") // ابطال چک
            {
                CheckEbtalShode();
            }
            if (Class.Variable.Variables.noe_cheque == "4") // برگشت چک
            {
                CheckBargasht();
            }
            if (Class.Variable.Variables.noe_cheque == "5") // استرداد
            {
                CheckEsterdad();
            }
            if (Class.Variable.Variables.noe_cheque == "6") // برگشت چکهای خرج شده
            {
                bargashteChequeKharjShode();
            }
        }
        /// <summary>
        /// چک خرج شده
        /// </summary>
        private void CheckKharjShode()
        {
            // select from checkProcess
            
            List<CheckProcess> chk = ak.CheckProcesses.Where(i => i.CPType ==
                Common.Constants.BaseInfoType.cheque_kharjShode
                ).ToList();

            var query = from cp in chk
                        join c in ak.Checks on cp.IDCheck equals c.ID
                        select new { c.CDescription, c.CPrice, cp.CSerial, c.CNO, c.ID };


            grd_cheque.ItemsSource = query.ToList();
        }

        //////////////////////////////////////////////////////////
        /// <summary>
        /// چک وصول شده
        /// </summary>
        private void CheckVosolShode()
        {
            // select from checkProcess

            List<CheckProcess> chk = ak.CheckProcesses.Where(i => i.CPType ==
                Common.Constants.BaseInfoType.vosole_cheque
                ).ToList();

            var query = from cp in chk
                        join c in ak.Checks on cp.IDCheck equals c.ID
                        select new { c.CDescription, c.CPrice, cp.CSerial, c.CNO, c.ID };

            grd_cheque.ItemsSource = query.ToList();
        }
        /// <summary>
        /// چک ابطال شده
        /// </summary>
        private void CheckEbtalShode()
        {
            // select from checkProcess

            List<CheckProcess> chk = ak.CheckProcesses.Where(i => i.CPType ==
                Common.Constants.BaseInfoType.ebtale_cheque
                ).ToList();

            var query = from cp in chk
                        join c in ak.Checks on cp.IDCheck equals c.ID
                        select new { c.CDescription, c.CPrice, cp.CSerial, c.CNO, c.ID };

            grd_cheque.ItemsSource = query.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        private void CheckBargasht()
        {
            // select from checkProcess

            List<CheckProcess> chk = ak.CheckProcesses.Where(i => i.CPType ==
                Common.Constants.BaseInfoType.bargashte_cheque
                ).ToList();

            var query = from cp in chk
                        join c in ak.Checks on cp.IDCheck equals c.ID
                        select new { c.CDescription, c.CPrice, cp.CSerial, c.CNO, c.ID };

            grd_cheque.ItemsSource = query.ToList();
        }
        /////
        /// <summary>
        /// 
        /// </summary>
        private void CheckEsterdad()
        {
            // select from checkProcess

            List<CheckProcess> chk = ak.CheckProcesses.Where(i => i.CPType ==
                Common.Constants.BaseInfoType.esterdade_cheque
                ).ToList();

            var query = from cp in chk
                        join c in ak.Checks on cp.IDCheck equals c.ID
                        select new { c.CDescription, c.CPrice, cp.CSerial, c.CNO, c.ID };

            grd_cheque.ItemsSource = query.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        private void bargashteChequeKharjShode()
        {
            // select from checkProcess

            List<CheckProcess> chk = ak.CheckProcesses.Where(i => i.CPType ==
                Common.Constants.BaseInfoType.bargashte_cheque_kharj_shode
                ).ToList();

            var query = from cp in chk
                        join c in ak.Checks on cp.IDCheck equals c.ID
                        select new { c.CDescription, c.CPrice, cp.CSerial, c.CNO, c.ID };

           var vv = query.ToList();
             this.grd_cheque.ItemsSource = vv; 
            var v = query.ToList();
                cc = v.Count();
                ss = new string[cc, 4];
                int ii = 0;
                foreach (var item in vv)
                {
                    string Sh_Ch = item.CNO;
                    string S_Ch = item.CSerial;
                    string Sharh = item.CDescription;
                    string Mablagh = item.CPrice.ToString();

                    ss[ii, 0] = Sh_Ch;
                    ss[ii, 1] = S_Ch;
                    ss[ii, 2] = Sharh;
                    ss[ii, 3] = Mablagh;
                  
                    ii++;
                }      
        }

        
         private void set_to_excell(string[,] a, int rowC)
        {
            ExcelImpExp.ExportToExcel exp = new ExcelImpExp.ExportToExcel();
            var table = new System.Data.DataTable();


            table = exp.get_dataGridColumnNames(grd_cheque);

            for (int i = 0; i <= rowC - 1; i++)
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
                    if (j == 0)
                        row[this.grd_cheque.Columns[j + 1].Header.ToString()] = int.Parse(a[i, j].ToString());
                    else
                        row[this.grd_cheque.Columns[j + 1].Header.ToString()] = a[i, j];
                }

                table.Rows.Add(row);
            }


            DataSet ds = new DataSet("New_DataSet");
            ds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;
            ds.Tables.Add(table);
            exp.showStuff(ds);

        }


        private void grd_cheque_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string g = grd_cheque.SelectedItem.ToString();

                string get_final_str = "";
                for (int i = 0; i <= g.Length - 3; i++)
                {
                    if (g.Substring(i, 2) == "ID")
                    {
                        get_final_str = g.Substring(i + 5, 36);
                    }
                }
                Guid get_id = Guid.Parse(get_final_str);
                ID = get_id.ToString();
            }
            catch { }
        }

        private void mnu_remove_Click_1(object sender, RoutedEventArgs e)
        {
            if (ID != "" && ID != null)
            {
                MessageBoxResult m = MessageBox.Show("حذف شود ", "حذف", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (m == MessageBoxResult.Yes)
                {

                    Guid g = Guid.Parse(ID);
                    var lst = ak.Checks.Where(i => i.ID == g).FirstOrDefault();

                    var get_from_chP = ak.CheckProcesses.Where(i => i.IDCheck == lst.ID).FirstOrDefault();

                    if (get_from_chP.CPType != Common.Constants.BaseInfoType.bargashte_cheque_kharj_shode)
                    {
                        get_from_chP.CPType = Guid.Empty;
                    }
                    else
                    {
                        get_from_chP.CPType = Common.Constants.BaseInfoType.bargashte_cheque;
                    }


                    int io = ak.SaveChanges();

                    if (io == 1)
                    {
                        if (Class.Variable.Variables.noe_cheque == "1") // چک خرج شده
                        {
                            CheckKharjShode();
                        }
                        if (Class.Variable.Variables.noe_cheque == "2") // وصول چک  
                        {
                            CheckVosolShode();
                        }
                        if (Class.Variable.Variables.noe_cheque == "3") // ابطال چک
                        {
                            CheckEbtalShode();
                        }
                        if (Class.Variable.Variables.noe_cheque == "4") // برگشت چک
                        {
                            CheckBargasht();
                        }
                        if (Class.Variable.Variables.noe_cheque == "5") // استرداد
                        {
                            CheckEsterdad();
                        }
                        if (Class.Variable.Variables.noe_cheque == "6") // برگشت چکهای خرج شده
                        {
                            bargashteChequeKharjShode();
                        }
                    }
                    else
                    {
                        MessageBox.Show("مقداری جهت حذف یافت نشد");
                    }
                }
            }
            else
            {
                MessageBox.Show("مقداری جهت حذف یافت نشد");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           // ExportToExcel();
            //var v = GetElements<String>(grd_cheque, 1, 1);
        }

        private void ExportToExcel()
        {

            // creating Excel Application

          /* Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
           Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
           Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
           app.Visible = true;
           worksheet = workbook.Sheets["Sheet1"];
           worksheet = workbook.ActiveSheet;
           worksheet.Name = "Exported from gridview";

           for (int i = 1; i < grd_cheque.Columns.Count + 1; i++)
           {

               worksheet.Cells[1, i] = grd_cheque.Columns[i - 1].Header;

           }*/


          /* for (int i = 0; i < grd_cheque.Items.Count - 1; i++)
           {

               for (int j = 0; j < grd_cheque.Columns.Count; j++)
               {

                  // worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                   worksheet.Cells[i + 2, j + 1] = grd_cheque.Items[i].Cells[j].Value.ToString();
                   worksheet.Cells[i + 2, j + 1] = grd_cheque.
               }

           }*/


    }


        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            List<Capital> LC = ak.Capitals.Where(i => i.CNO.Contains(TB_Search.Text) || i.CNO.Contains(TB_Search.Text) || i.CDescription.Contains(TB_Search.Text)).ToList();

            grd_cheque.ItemsSource = LC;
        }

        private void BtnExel_Click(object sender, RoutedEventArgs e)
        {
            set_to_excell(ss, cc);
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            List<CheckProcess> chk = ak.CheckProcesses.Where(i => i.CPType ==
               Common.Constants.BaseInfoType.bargashte_cheque_kharj_shode
               ).ToList();

            var query = from cp in chk
                        join c in ak.Checks on cp.IDCheck equals c.ID
                        select new { c.CDescription, c.CPrice, cp.CSerial, c.CNO, c.ID };

            var vv = query.ToList();

            StiReport report = new StiReport();

            report.Load(@"D:\New folder (2)\accountingKernel\AccountingKernel\Debug_AccountingKernel\Report\frm_cheque.mrt");

            report.RegData("vv", vv);

            report.Show();
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            if (Class.Variable.Variables.noe_cheque == "2")
            {
                AccountingKernel.Forms.KazaneDari.frm_vosol_cheque frmVc = new KazaneDari.frm_vosol_cheque();
                frmVc.ShowDialog();
            }

            if (Class.Variable.Variables.noe_cheque != "2")
            {
                frm_amaliateCheque frmAmChk = new frm_amaliateCheque();
                frmAmChk.ShowDialog();

                if (Class.Variable.Variables.noe_cheque == "1") // چک خرج شده
                {
                    CheckKharjShode();
                }

                if (Class.Variable.Variables.noe_cheque == "2") // چک وصول شده
                {

                    CheckVosolShode();
                }

                if (Class.Variable.Variables.noe_cheque == "3") // ابطال چک
                {
                    CheckEbtalShode();
                }

                if (Class.Variable.Variables.noe_cheque == "4") // برگشت چک
                {
                    CheckBargasht();
                }

                if (Class.Variable.Variables.noe_cheque == "5") // استرداد چک
                {
                    CheckEsterdad();
                }

                if (Class.Variable.Variables.noe_cheque == "6") // برگشت چک خرج شده
                {
                    bargashteChequeKharjShode();
                }
            }
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            if (ID != "" && ID != null)
            {
                MessageBoxResult m = MessageBox.Show("حذف شود ", "حذف", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (m == MessageBoxResult.Yes)
                {

                    Guid g = Guid.Parse(ID);
                    var lst = ak.Checks.Where(i => i.ID == g).FirstOrDefault();

                    var get_from_chP = ak.CheckProcesses.Where(i => i.IDCheck == lst.ID).FirstOrDefault();

                    if (get_from_chP.CPType != Common.Constants.BaseInfoType.bargashte_cheque_kharj_shode)
                    {
                        get_from_chP.CPType = Guid.Empty;
                    }
                    else
                    {
                        get_from_chP.CPType = Common.Constants.BaseInfoType.bargashte_cheque;
                    }


                    int io = ak.SaveChanges();

                    if (io == 1)
                    {
                        if (Class.Variable.Variables.noe_cheque == "1") // چک خرج شده
                        {
                            CheckKharjShode();
                        }
                        if (Class.Variable.Variables.noe_cheque == "2") // وصول چک  
                        {
                            CheckVosolShode();
                        }
                        if (Class.Variable.Variables.noe_cheque == "3") // ابطال چک
                        {
                            CheckEbtalShode();
                        }
                        if (Class.Variable.Variables.noe_cheque == "4") // برگشت چک
                        {
                            CheckBargasht();
                        }
                        if (Class.Variable.Variables.noe_cheque == "5") // استرداد
                        {
                            CheckEsterdad();
                        }
                        if (Class.Variable.Variables.noe_cheque == "6") // برگشت چکهای خرج شده
                        {
                            bargashteChequeKharjShode();
                        }
                    }
                    else
                    {
                        MessageBox.Show("مقداری جهت حذف یافت نشد");
                    }
                }
            }
            else
            {
                MessageBox.Show("مقداری جهت حذف یافت نشد");
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
