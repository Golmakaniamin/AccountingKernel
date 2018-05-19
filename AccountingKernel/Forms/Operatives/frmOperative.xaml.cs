using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Common;
using System.Transactions;
using Data;
using AccountingKernel;
namespace AccountingKernel.Forms.Operatives
{
    /// <summary>
    /// Interaction logic for Document.xaml
    /// </summary>
    public partial class frmOperative : Window
    {
        private Guid operativeId;
        Class.UI.TextHandeler c = new Class.UI.TextHandeler();

        public frmOperative()
        {
            try
            {
                InitializeComponent();

                cmbOperativeType.ItemsSource = Business.GetBaseInfoBusiness().GetByType(Constants.BaseInfoType.OperativeType);
                cmbCalculationMethod.ItemsSource = Business.GetBaseInfoBusiness().GetByType(Constants.BaseInfoType.CalculationMethod);

            }
            catch
            {

                throw;
            }

        }

        public frmOperative(Guid id)
        {
            try
            {
                InitializeComponent();

                cmbOperativeType.ItemsSource = Business.GetBaseInfoBusiness().GetByType(Constants.BaseInfoType.OperativeType);
                cmbCalculationMethod.ItemsSource = Business.GetBaseInfoBusiness().GetByType(Constants.BaseInfoType.CalculationMethod);

                this.operativeId = id;
                var operative = Business.GetOperativeBusiness().GetById(this.operativeId);

                txtName.Text = operative.OName;
                cmbCalculationMethod.SelectedValue = operative.OCalculationMethod;
                cmbOperativeType.SelectedValue = operative.OType;
                chboxIsEffective.IsChecked = operative.OISEffective;
                if (operative.OCalculationMethod == Common.Constants.CalculationMethod.Price)
                    txtPercent.IsEnabled = false;
                else
                {
                    txtPercent.Text = operative.OPercent.ToString(Localize.DoubleMaskType);
                    txtPercent.IsEnabled = true;
                }

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
                var isValidated = ValidateForm(out errorMessage);
                if (!isValidated)
                    //رخداد خطا
                    throw new Exception(errorMessage);

                var operative = new Operative();
                if (operativeId != Guid.Empty)
                    operative = Business.GetOperativeBusiness().GetById(operativeId);
                else
                    operative = Business.GetOperativeBusiness().GetByOName(txtName.Text);

                if (operative == null)
                    operative = new Operative();


                operative.OType = cmbOperativeType.SelectedValue.ToGUID();
                operative.OCalculationMethod = cmbCalculationMethod.SelectedValue.ToGUID();
                operative.OISEffective = chboxIsEffective.IsChecked;

                operative.OPercent = txtPercent.Text.ToNullableDecimal();
                operative.OName = txtName.Text;

                Business.GetOperativeBusiness().Save(operative);

                this.Close();

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

                if (txtName.Text.Trim().Length == 0)
                    errorMessage = Localize.ex_empty_operativename;

                if (cmbOperativeType.SelectedIndex == -1)
                    errorMessage = Localize.ex_operativetype_not_selected;

                if (cmbCalculationMethod.SelectedIndex == -1)
                    errorMessage = Localize.ex_calculationtype_not_seletced;

                if (cmbCalculationMethod.SelectedValue.ToGUID() == Common.Constants.CalculationMethod.Percent && txtPercent.Text.Trim().Length == 0)
                    errorMessage = Localize.ex_empty_percent_value;

                return errorMessage == string.Empty;
            }
            catch
            {

                throw;
            }
        }

        private void cmbCalculationMethod_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                txtPercent.IsEnabled = cmbCalculationMethod.SelectedValue.ToGUID() == Common.Constants.CalculationMethod.Percent;
                txtPercent.Clear();
            }
            catch
            {

                throw;
            }
        }

        private void txtName_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            c.JustPersian(e);
        }




    }
}
