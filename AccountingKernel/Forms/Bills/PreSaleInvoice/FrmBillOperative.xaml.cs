using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Common;
using System.Transactions;
using System.Windows.Data;

namespace AccountingKernel.Forms.Bills.PreSaleInvoice
{
    /// <summary>
    /// Interaction logic for Document.xaml
    /// </summary>
    public partial class FrmBillOperative : Window
    {
        private Guid storeOrderId;
        private Guid? storeDetailId;
        private bool isEffective;

        private class DataGridData
        {
            public Guid Id { set; get; }
            public bool IsAllocated { set; get; }
            public Guid OperativeId { get; set; }
            public string Price { get; set; }
            public string Percent { get; set; }

        }

        public FrmBillOperative()
        {
            try
            {
                InitializeComponent();
            }
            catch
            {

                throw;
            }

        }

        public FrmBillOperative(Guid storeOrderId, bool isEffective)
        {
            try
            {
                InitializeComponent();

                this.storeOrderId = storeOrderId;
                this.isEffective = isEffective;
                cmbOperative.ItemsSource = Business.GetOperativeBusiness().GetByOISEffective(isEffective).ToList();

                var storeOrder = Business.GetStoreOrderBusiness().GetById(this.storeOrderId);
                lblBillNum.Content = storeOrder.OId;
                lblDate.Content = storeOrder.ODate;
                if (storeOrder.IdCompany.HasValue)
                    lblCompany.Content = Business.GetComBusiness().GetById(storeOrder.IdCompany.Value).CName;

                SetDataGrid();

            }
            catch
            {

                throw;
            }
        }

        public FrmBillOperative(Guid storeOrderId, Guid storeOrderDetailId, bool isEffective)
        {
            try
            {
                InitializeComponent();


                this.storeOrderId = storeOrderId;
                this.storeDetailId = storeOrderDetailId;
                this.isEffective = isEffective;

                cmbOperative.ItemsSource = Business.GetOperativeBusiness().GetByOISEffective(isEffective).ToList();

                var storeOrder = Business.GetStoreOrderBusiness().GetById(this.storeOrderId);

                lblBillNum.Content = storeOrder.OId;
                lblDate.Content = storeOrder.ODate;
                if (storeOrder.IdCompany.HasValue)
                    lblCompany.Content = Business.GetComBusiness().GetById(storeOrder.IdCompany.Value).CName;

                SetDataGrid();

            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// sets store order detail data grid 
        /// </summary>
        private void SetDataGrid()
        {
            try
            {
                var operatives = Business.GetOperativeBusiness().GetByOISEffective(isEffective);

                cmbOperative.ItemsSource = operatives.Select(r => new { OperativeId = r.Id, OperativeName = r.OName }).ToList();
                cmbOperative.DisplayMemberPath = "OperativeName";
                cmbOperative.SelectedValuePath = "OperativeId";

                var storeOperatives = Business.GetStoreOperativeBusiness().GetByStoreOrderId(storeOrderId).ToList();

                var items = new List<DataGridData>();
                foreach (var operative in operatives)
                {
                    var currentEntity = storeOperatives.Find(r => r.IdOperative == operative.Id);
                    if (currentEntity != null)
                        items.Add(new DataGridData
                        {
                            Id = currentEntity.Id,
                            IsAllocated = true,
                            OperativeId = operative.Id,
                            Price = currentEntity.SPrice == null ? string.Empty : currentEntity.SPrice.ToString(Localize.DoubleMaskType)
                        });
                    else
                        items.Add(new DataGridData
                        {
                            Id = Guid.Empty,
                            IsAllocated = false
                        });
                }


                DataGrid.ItemsSource = items.OrderByDescending(r => r.IsAllocated).ToList();

            }
            catch
            {

                throw;
            }
        }


        /// <summary>
        /// finds storeorder by oid, odate and company
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtHeaders_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
            }
            catch
            {

                throw;
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var errorMessage = string.Empty;
                if (!ValidateForm(out errorMessage))
                    //رخداد خطا
                    throw new Exception(errorMessage);

                var operatives = Business.GetOperativeBusiness().GetByOISEffective(isEffective).ToList();
                var storeOperativeBusiness = Business.GetStoreOperativeBusiness();
                Data.StoreOperative storeOperative;

                var storeDetail = Business.GetStoreOrderDetailBusiness().GetById(storeDetailId.Value);

                for (int i = 0; i < DataGrid.Items.Count; i++)
                {
                    var row = (DataGridData)DataGrid.Items[i];

                    if (row.OperativeId == null)
                        continue;

                    var operative = operatives.Find(r => r.Id == row.OperativeId);

                    if (storeDetailId.HasValue)
                        storeOperative = storeOperativeBusiness.GetByStoreOrderDetailId(storeDetailId.Value, operative.Id);
                    else
                        storeOperative = storeOperativeBusiness.GetByStoreOrderId(storeDetailId.Value, operative.Id);

                    if (storeOperative == null)
                        storeOperative = new Data.StoreOperative();

                    storeOperative.IdOperative = operative.Id;
                    storeOperative.IdStoreOrder = storeOrderId;
                    storeOperative.IdStoreDetail = storeDetailId;
                    if (operative.OCalculationMethod == Common.Constants.CalculationMethod.Percent)
                        storeOperative.SPrice = operative.OPercent.ToDecimal() * storeDetail.ODMoney.ToDecimal();
                    else
                        storeOperative.SPrice = row.Price.ToDecimal();


                    storeOperativeBusiness.Save(storeOperative);

                }

            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private bool ValidateForm(out string errorMessage)
        {
            try
            {
                errorMessage = string.Empty;

                return errorMessage == string.Empty;
            }
            catch
            {

                throw;
            }
        }


    }
}
