using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Common;
using System.Transactions;

namespace AccountingKernel.Forms.Interface
{
    /// <summary>
    /// Interaction logic for Document.xaml
    /// </summary>
    public partial class frmInterfaces : Window
    {
        private class DataGridEntity
        {
            public Guid Id { set; get; }
            public string AIDebtor_Moein { set; get; }
            public string AICreditor_Moein { set; get; }
            public string AICreditorCode { set; get; }
            public string AIDebtor_TafsilLevel { get; set; }
            public string AICreditor_TafsilLevel { get; set; }
            public string AIName { get; set; }
        }

        public frmInterfaces()
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
                var dataGridEntities = new List<DataGridEntity>();
                foreach (var item in Business.GetAccountingInterfaceBusiness().GetAll().ToList())
                {
                    var creditorMoein = Business.GetAccountingMoeinBusiness().GetById(item.AICreditor_IDAccountingMoein.Value);
                    var debtorMoein = Business.GetAccountingMoeinBusiness().GetById(item.AIDebtor_IDAccountingMoein.Value);

                    dataGridEntities.Add(new DataGridEntity()
                    {
                        Id = item.Id,
                        AIDebtor_Moein = creditorMoein.MIdGroup + " " + creditorMoein.MIdAll + " " + creditorMoein.MName,
                        AICreditor_Moein = debtorMoein.MIdGroup + " " + debtorMoein.MIdAll + " " + debtorMoein.MName,
                        AIDebtor_TafsilLevel = Business.GetAccountingTafsilLevelDetailBusiness().GetNameByIdAccountingTafsilLevels(item.AIDebtor_IDAccountingMoeinTafsilLevels),
                        AICreditor_TafsilLevel = Business.GetAccountingTafsilLevelDetailBusiness().GetNameByIdAccountingTafsilLevels(item.AICreditor_IDAccountingMoeinTafsilLevels),
                        AIName = item.AIName
                    });

                }

                DataGrid.ItemsSource = dataGridEntities;
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
                var frmSaveInterfaces = new frmSaveInterfaces();
                frmSaveInterfaces.ShowDialog();

                this.SetDataGrid();

            }
            catch
            {

                throw;
            }
        }

        private void mnu_remove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DataGrid.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);

                Guid id = (DataGrid.SelectedValue as dynamic).Id;
                Business.GetAccountingInterfaceBusiness().Delete(Business.GetAccountingInterfaceBusiness().GetById(id));

                this.SetDataGrid();

            }
            catch
            {

                throw;
            }
        }



    }
}
