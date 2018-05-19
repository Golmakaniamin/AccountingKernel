using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using AccountingKernel.Common;
using System.Transactions;
using System.Windows.Data;

namespace AccountingKernel.Forms.Bill
{
    /// <summary>
    /// Interaction logic for Document.xaml
    /// </summary>
    public partial class frmBillOperative : Window
    {
        private Guid storeOrderId;
        private Guid? storeDetailId;
        private bool isEffective;


        public frmBillOperative()
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

        public frmBillOperative(Guid storeOrderId, bool isEffective)
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
                    lblCompany.Content = Business.GetCompanyBusiness().GetById(storeOrder.IdCompany.Value).CName;

                SetDataGrid();

            }
            catch
            {

                throw;
            }
        }

        public frmBillOperative(Guid storeOrderId, Guid storeOrderDetailId, bool isEffective)
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
                    lblCompany.Content = Business.GetCompanyBusiness().GetById(storeOrder.IdCompany.Value).CName;

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
                var storeOperatives = Business.GetStoreOperativeBusiness().GetByStoreOrderId(storeOrderId);
                if (storeDetailId.HasValue)
                    storeOperatives = storeOperatives.Where(r => r.IdStoreDetail == storeDetailId.Value);
                var operatives = Business.GetOperativeBusiness().GetByOISEffective(isEffective);
                storeOperatives = storeOperatives.Where(r => operatives.Select(t => t.Id).Contains(r.IdOperative));

                var jResult = storeOperatives.ToList();
                DataGrid.ItemsSource = jResult.ToList();
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
                if (ValidateForm(out errorMessage))
                    //رخداد خطا
                    throw new Exception(errorMessage);

                var operative = Business.GetOperativeBusiness().GetById(cmbOperative.SelectedValue.ToGUID());


                var storeOperativeBusiness = Business.GetStoreOperativeBusiness();
                StoreOperative storeOperative;

                if (storeDetailId.HasValue)
                    storeOperative = storeOperativeBusiness.GetByStoreOrderDetailId(storeDetailId.Value, operative.Id);
                else
                    storeOperative = storeOperativeBusiness.GetByStoreOrderId(storeDetailId.Value, operative.Id);

                if (storeOperative == null)
                    storeOperative = new StoreOperative();

                storeOperative.IdOperative = operative.Id;
                storeOperative.IdStoreOrder = storeOrderId;
                storeOperative.IdStoreDetail = storeDetailId;
                storeOperative.SPrice = txtPrice.Text.ToDecimal();

                storeOperativeBusiness.Save(storeOperative);
            }
            catch
            {

                throw;
            }
        }

        private bool ValidateForm(out string errorMessage)
        {
            try
            {
                errorMessage = string.Empty;
                if (cmbOperative.SelectedIndex < 0)
                    errorMessage = Localize.ex_operative_not_selected;

                return errorMessage == string.Empty;
            }
            catch
            {

                throw;
            }
        }

        private void cmbOperative_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var operative = Business.GetOperativeBusiness().GetById(cmbOperative.SelectedValue.ToGUID());
                if (operative == null || operative.OType != Constants.CalculationMethod.Percent)
                    return;

                var price = default(decimal);
                if (storeDetailId.HasValue)
                    price = Business.GetStoreOrderDetailBusiness().GetById(storeDetailId.Value).ODMoney.ToDecimal();
                else
                    price = Business.GetStoreOrderBusiness().GetById(storeOrderId).OSumMoney.ToDecimal();

                txtPrice.IsEnabled = false;
                txtPrice.Text = (price * operative.OPercent).ToString();
            }
            catch
            {

                throw;
            }
        }


    }
}
