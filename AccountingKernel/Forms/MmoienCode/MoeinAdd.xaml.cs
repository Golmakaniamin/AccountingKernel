using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AccountingKernel.Forms.MmoienCode
{
    /// <summary>
    /// Interaction logic for MoeinAdd.xaml
    /// </summary>
    public partial class MoeinAdd : Window
    {

        Class.UI.TextHandeler c = new Class.UI.TextHandeler();
        private Guid ParentID;
        private Guid id = Guid.Empty;
        private Data.AccountingMoeinStructureDefine MoeinStructure = null;
        private Data.AccountingMoeinCode MoeinCodes = null;
        private int Gurohlen;
        private int Kollen;
        private int Moeinlen;
        public MoeinAdd()
        {
            InitializeComponent();
            Gurohlen = (int)Business.GetCodeTitleBusiness().GetById(Constants.CodeTitle.Goruh).CodeLen;
            Kollen = (int)Business.GetCodeTitleBusiness().GetById(Constants.CodeTitle.Kol).CodeLen;
            Moeinlen = (int)Business.GetCodeTitleBusiness().GetById(Constants.CodeTitle.Moein).CodeLen;

            txtMoeinCode.MaxLength = Moeinlen;

            var baseInfos = Business.GetBaseInfoBusiness().GetAll().OrderBy(r => r.Priority).Select(r => new { Id = r.Id, Name = r.AssignName, PId = r.PID }).ToList();
            cmbMoeinType.ItemsSource = baseInfos.FindAll(r => r.PId == Constants.BaseInfoType.MoeinType);
            cmbMoeinNature.ItemsSource = baseInfos.FindAll(r => r.PId == Constants.BaseInfoType.MoeinNature);
        }

        public MoeinAdd(Guid id)
            : this()
        {
            this.id = id;

            MoeinStructure = Business.GetMoeinStructureDefineBusiness().GetByID(id).FirstOrDefault();
            txtMoeinCode.Text = MoeinStructure.Code.Substring(Gurohlen + Kollen);
            txtGurohKol.Text = MoeinStructure.Code.Substring(0, Gurohlen + Kollen);
            txtMoeinLatinName.Text = MoeinStructure.Latin_Name;
            txtMoeinName.Text = MoeinStructure.Name;

            MoeinCodes = Business.GetMoeinCodesBusiness().GetByStructureDefine_ID(id).FirstOrDefault();
            cmbMoeinType.SelectedValue = MoeinCodes.MType;
            cmbMoeinNature.SelectedValue = MoeinCodes.MNature;
        }

        private void btnAddParent_Click(object sender, RoutedEventArgs e)
        {
            MoeinStructureDefine Moein = new MoeinStructureDefine();
            Moein.ShowDialog();
            if (Moein.Code == null)
                return;

            ParentID = Moein.ID;
            lblMoeinGroup.Content = Moein.Name;

            var DefualtCode = Business.GetMoeinStructureDefineBusiness().GetDefualtCode(Constants.CodeTitle.Moein, ParentID);
            txtGurohKol.Text = Business.GetMoeinStructureDefineBusiness().GetByID(ParentID).FirstOrDefault().Code;

            if (DefualtCode.Length > Gurohlen + Kollen)
                txtMoeinCode.Text = DefualtCode.Substring(Gurohlen + Kollen);
            else
                txtMoeinCode.Text = DefualtCode;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (FormIsValid())
            {

                if (id != Guid.Empty)
                {
                    MoeinStructure.Code = string.Format("{0}{1}", txtGurohKol.Text, txtMoeinCode.Text);
                    MoeinStructure.Name = txtMoeinName.Text;
                    MoeinStructure.Latin_Name = txtMoeinLatinName.Text;
                    MoeinStructure.LastEdit = System.DateTime.Now;
                    MoeinCodes.MNature = (Guid)cmbMoeinNature.SelectedValue;
                    MoeinCodes.MType = (Guid)cmbMoeinType.SelectedValue;

                }
                else
                {
                    MoeinStructure = Business.GetMoeinStructureDefineBusiness().
                        GetStructure(Constants.CodeTitle.Moein, txtMoeinName.Text, txtMoeinLatinName.Text, ParentID, string.Format("{0}{1}", txtGurohKol.Text, txtMoeinCode.Text));
                    MoeinCodes = Business.GetMoeinCodesBusiness().GetMoeinCode(MoeinStructure.ID, (Guid)cmbMoeinType.SelectedValue, (Guid)cmbMoeinNature.SelectedValue);
                }
                using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions()
                {
                    IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted,
                    Timeout = new TimeSpan(2, 0, 0)
                }))
                {
                    Business.GetMoeinStructureDefineBusiness().SaveWithID(MoeinStructure);
                    Business.GetMoeinCodesBusiness().Save(MoeinCodes);
                    scope.Complete();
                }

                this.Close();
            }
        }

        private bool FormIsValid()
        {

            string message = string.Empty;

            string code = string.Format("{0}{1}", txtGurohKol.Text, txtMoeinCode.Text);
            if (Business.GetMoeinStructureDefineBusiness().GetByCode(code) != null && id == null)
            {
                message = "کد تکراری است";
                MessageBox.Show(message);
                return false;
            }

            if (txtMoeinCode.Text.Count() < Moeinlen)
            {
                message = "کد کمتر از حد تعیین شده میباشد";
                MessageBox.Show(message);
                return false;
            }

            if (string.IsNullOrEmpty(txtMoeinCode.Text))
            {
                message = "لطفا کد را وارد کنید";
                MessageBox.Show(message);
                return false;
            }

            if (string.IsNullOrEmpty(txtMoeinName.Text))
            {
                message = "لطفا نام را وارد کنید";
                MessageBox.Show(message);
                return false;

            }

            if (cmbMoeinType.SelectedValue == null)
            {
                message = "لطفا نوع معیین را انتخاب کنید";
                MessageBox.Show(message);
                return false;
            }

            if (cmbMoeinNature.SelectedValue == null)
            {
                message = "لطفا ماهیت معیین را انتخاب کنید";
                MessageBox.Show(message);
                return false;
            }
            return true;
        }

        private void JustEnglish(object sender, TextCompositionEventArgs e)
        {
            c.JustEnglish(e);
        }

        private void CheckIsNumeric(object sender, TextCompositionEventArgs e)
        {
            c.CheckIsNumeric(e);
        }

        private void JustPersian(object sender, TextCompositionEventArgs e)
        {
            c.JustPersian(e);
        }
    }
}
