using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingKernel.ExcelImpExp
{
     class ExportToExcel
    {

        public void showStuff(DataSet ds)
        {

            //// baz kardane dialoge save 
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = ""; // Default file name
            dlg.DefaultExt = ".xls"; // Default file extension
            dlg.Filter = "Excel Document (.xls)|*.xls"; // Filter files by extension
            Nullable<bool> result = dlg.ShowDialog();
            string filename = "";
            if (result == true)
            {
                filename = dlg.FileName;

                // Step 2: Create the Excel .xlsx file
                try
                {
                    bool b = CreateExcelFile.CreateExcelDocument(ds, filename);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Couldn't create Excel file.\r\nException: " + ex.Message);
                    return;
                }
            }
            //// --
        }

        /////////////////////////////////////////////////////////////

      public  DataTable get_dataGridColumnNames( System.Windows.Controls.DataGrid dg )
      {
          DataTable table = new System.Data.DataTable();

          if (dg.Columns.Count == 1)
          {

              table.Columns.Add(dg.Columns[0].Header.ToString());

              return table;

          }

          for (int i = 1; i <= dg.Columns.Count - 1; i++)
          {
            //  if (i == 1)
              try
              {
                  table.Columns.Add(dg.Columns[i].Header.ToString());
              }
              catch { }
              //if (i == 2)
              //    table.Columns.Add(dg.Columns[i].Header.ToString(), typeof(string));
              //if (i == 3)
              //    table.Columns.Add(dg.Columns[i].Header.ToString(), typeof(string));
              //if (i == 4)
              //    table.Columns.Add(dg.Columns[i].Header.ToString(), typeof(string));
          }

          return table;

      }
      public DataTable get_dataGridColumnNames(System.Windows.Controls.DataGrid dg , string [] customs)
      {
          DataTable table = new System.Data.DataTable();

          if (dg.Columns.Count == 1)
          {

              table.Columns.Add(dg.Columns[0].Header.ToString());

              return table;

          }

          for (int i = 1; i <= dg.Columns.Count - 1; i++)
          {

              try
              {
                  bool exist = false;
                  //// che for col names
                  for (int j = 0; j <= customs.Length - 1; j++)
                  {
                      if (customs[j] == dg.Columns[i].Header.ToString())
                      {
                          exist = true;
                      }


                  }
                  // end check

                  if ( exist == true)
                  table.Columns.Add(dg.Columns[i].Header.ToString());
              }
              catch { }

          }

          return table;

      }




    }
}
