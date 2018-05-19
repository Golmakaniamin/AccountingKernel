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
using Common;

namespace AccountingKernel.Forms.baseInfo
{
    /// <summary>
    /// Interaction logic for frm_list_bank.xaml
    /// </summary>
    public partial class FrmRegisterBaseInfo : Window
    {
        Class.UI.TextHandeler c = new Class.UI.TextHandeler();
        public Guid? EntityId;
        public Guid? PID;
        public FrmRegisterBaseInfo()
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

        public FrmRegisterBaseInfo(Guid entityId)
        {
            try
            {
                this.EntityId = entityId;
                InitializeComponent();

                var entity = Business.GetBaseInfoBusiness().GetById(EntityId.ToGUID());

                this.PID = entity.PID;
                txtAssignName.Text = entity.AssignName;
                txtExplain.Text = entity.Explain;
                txtPriority.Text = entity.Priority.ToString();
            }
            catch
            {

                throw;
            }
        }

        private void btnSave_click(object sender, RoutedEventArgs e)
        {
            try
            {
                var entity = Business.GetBaseInfoBusiness().GetById(EntityId.ToGUID());
                if (entity == null)
                {
                    entity = new Data.BaseInfo();
                    entity.PID = this.PID;
                }

                entity.AssignName = txtAssignName.Text;
                entity.Explain = txtExplain.Text;
                entity.Priority = txtPriority.Text.ToInt();

                Business.GetBaseInfoBusiness().Save(entity);

            }
            catch
            {

                throw;
            }
        }

        private void txtExplain_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            c.JustEnglish(e);
        }
    }
}
