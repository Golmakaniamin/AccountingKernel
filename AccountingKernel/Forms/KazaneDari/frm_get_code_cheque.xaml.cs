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

namespace AccountingKernel.Forms.KazaneDari
{
    public class CheksAndChecksProcess
    {
        public string CDescription { get; set; }
        public decimal CPrice { get; set; }
        public string CSerial { get; set; }
        public string CNO { get; set; }
        public Guid CBank { get; set; }
    }

    /// <summary>
    /// Interaction logic for frm_get_code_cheque.xaml
    /// </summary>
    public partial class frm_get_code_cheque : Window
    {
        public frm_get_code_cheque()
        {
            InitializeComponent();
        }
        AccountingKernelEntities10 ak = new AccountingKernelEntities10();

        private void btn_select_Click(object sender, RoutedEventArgs e)
        {
          //  Class.Variable.Variables.idCheque  = ID;
            this.Hide();
        }



        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            if (Class.Variable.Variables.noe_cheque == "1" || 
                Class.Variable.Variables.noe_cheque == "2" ||
                Class.Variable.Variables.noe_cheque == "4" ||
                Class.Variable.Variables.noe_cheque == "5"  )
            {
                loadNullChequeToGrid();
            }
            if (Class.Variable.Variables.noe_cheque == "3")
            {
                loadAllChequeToGrid();
            }

            if (Class.Variable.Variables.noe_cheque == "6")
            {
                loadChequeHayeKharjShodeToGrid();
            }

        }

        private void loadNullChequeToGrid()
        {
            if (Class.Variable.Variables.bank_code != Guid.Empty)
            {
                List<CheckProcess> query_check = ak.CheckProcesses.Where(i => i.CPType == Guid.Empty
                    ).ToList();

                var query = from cp in query_check
                            join c in ak.Checks on cp.IDCheck equals c.ID
                            select new { c.CDescription, c.CPrice, cp.CSerial, c.CNO, c.CBank, c.ID };

                var query2 = query.Where(i => i.CBank == Class.Variable.Variables.bank_code).ToList();
                grd_chequ.ItemsSource = query2.ToList();

            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void loadAllChequeToGrid()
        {
            if (Class.Variable.Variables.bank_code != Guid.Empty)
            {
                List<CheckProcess> query_check = ak.CheckProcesses.Where(i => i.CPType != Common.Constants
                    .BaseInfoType.ebtale_cheque
                    ).ToList();

                var query = from cp in query_check
                            join c in ak.Checks on cp.IDCheck equals c.ID
                            select new { c.CDescription, c.CPrice, cp.CSerial, c.CNO, c.CBank, c.ID };

                var query2 = query.Where(i => i.CBank == Class.Variable.Variables.bank_code).ToList();
                grd_chequ.ItemsSource = query2.ToList();

            }
        }
/// <summary>
/// 
/// </summary>
        private void loadChequeHayeKharjShodeToGrid()
        {
            if (Class.Variable.Variables.bank_code != Guid.Empty)
            {
                List<CheckProcess> query_check = ak.CheckProcesses.Where(i => i.CPType == Common.Constants
                    .BaseInfoType.cheque_kharjShode
                    ).ToList();

                var query = from cp in query_check
                            join c in ak.Checks on cp.IDCheck equals c.ID
                            select new { c.CDescription, c.CPrice, cp.CSerial, c.CNO, c.CBank, c.ID };

                var query2 = query.Where(i => i.CBank == Class.Variable.Variables.bank_code).ToList();
                grd_chequ.ItemsSource = query2.ToList();

                
            }
        }




        private void grd_chequ_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        
                string g = grd_chequ.SelectedItem.ToString();

                string get_final_str = "";
                for (int i = 0; i <= g.Length - 3; i++)
                {
                    if (g.Substring(i, 2) == "ID")
                    {
                       get_final_str = g.Substring(i + 5, 36);
                    }
                }
                   Guid get_id = Guid.Parse(get_final_str);
                   Class.Variable.Variables.idCheque = get_id.ToString();
         
        }
    }
}
