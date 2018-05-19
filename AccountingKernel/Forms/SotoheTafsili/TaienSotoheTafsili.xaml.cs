using AccountingKernel.Class;
using Common;
using Data;
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

namespace AccountingKernel.Forms.SotoheTafsili
{
    /// <summary>
    /// Interaction logic for TaienSotoheTafsili.xaml
    /// </summary>
    public partial class TaienSotoheTafsili : Window
    {

        Guid parentID = Guid.Empty;


        public TaienSotoheTafsili(MoeinReport Moein)
        {
            InitializeComponent();
            lbl_onvaneGrouh.Content = Moein.FirstLevelName;
            lbl_onvaneKol.Content = Moein.SecondLevelName;
            lbl_onvaneMoien.Content = Moein.ThirdLevelName;
            lbl_codeMoien.Content = Moein.ThirdLevelCode;

            FillCombo();
            parentID = Moein.ID;
        }

        private void FillCombo()
        {
            cmb_sotoheTafsili.ItemsSource = null;
            var TafsilLevels = Business.GetBaseInfoBusiness().GetAll().Where(r => r.PID == Constants.BaseInfoType.TafsilLevel || r.Id == Constants.BaseInfoType.TafsilLevel).OrderBy(r => r.Priority).Select(r => new { Id = r.Id, Name = r.AssignName }).ToList();
            cmb_sotoheTafsili.ItemsSource = TafsilLevels;
            cmb_sotoheTafsili.SelectedIndex = 0;
        }

        private void btn_fehresteGrouhayeTafsili_Click(object sender, RoutedEventArgs e)
        {
            if (cmb_sotoheTafsili.SelectedIndex != 0)
            {
                fehreste_grouhe_tafsili fehreste_grouh = new fehreste_grouhe_tafsili();
                fehreste_grouh.ShowDialog();

                if (fehreste_grouh.ReturnedList.Count != 0)
                {
                    Data.AccountingMoeinStructureDefine tafsil = null;

                    if (cmb_sotoheTafsili.SelectedIndex == 1)
                        tafsil = Tafsil(Constants.CodeTitle.Tafsil1);
                    if (cmb_sotoheTafsili.SelectedIndex == 2)
                        tafsil = Tafsil(Constants.CodeTitle.Tafsil2);
                    if (cmb_sotoheTafsili.SelectedIndex == 3)
                        tafsil = Tafsil(Constants.CodeTitle.Tafsil3);

                    Business.GetMoeinStructureDefineBusiness().SaveWithID(tafsil);

                    List<Data.AccountingMoeinTafsilRelation> RelationList =
                        Business.GetAccountingMoeinTafsilRelationBussiness().SetRelation(tafsil, fehreste_grouh.ReturnedList);

                    Business.GetAccountingMoeinTafsilRelationBussiness().Save(RelationList);

                    grid_AccountiTafsilLevels.ItemsSource = fehreste_grouh.ReturnedList.Select(r => new { Id = r.ID, Name = r.Name, CodeName = r.Code }).ToList();
                }
            }
            else MessageBox.Show("لطفا یک سطح تفصیلی انتخاب کنید");

        }

        private Data.AccountingMoeinStructureDefine Tafsil(Guid Type)
        {
            Guid tafsil = Type;
            string name = "tafsil";
            var result = Business.GetMoeinStructureDefineBusiness().GetStructure(tafsil, name, name, parentID, "");
            result.ID = (Guid)cmb_sotoheTafsili.SelectedValue;
            return result;
        }

        private void cmb_sotoheTafsili_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var s = sender as ComboBox;
            var tafsil = Business.GetAccountingMoeinTafsilRelationBussiness().GetByMoeinID((Guid)s.SelectedValue).Select(r => r.AccountingTafsil_ID);
            RefreshGrid(tafsil);
        }

        private void RefreshGrid(IQueryable<Guid?> tafsil)
        {
            grid_AccountiTafsilLevels.ItemsSource = Business.GetTafsilStructureDefineBusiness().InFilter(tafsil).
                Select(r => new { Id = r.ID, Name = r.Name, CodeName = r.Code }).ToList();
        }

        private void grid_AccountiTafsilLevels_SelectedCellsChanged_1(object sender, SelectedCellsChangedEventArgs e)
        {

        }

        private void grid_AccountiTafsilLevels_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {

        }

        private void mnu_reg_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBoxResult m = MessageBox.Show("آیا مایل به حذف رکورد میباشید" + Environment.NewLine + "", "حذف رکورد", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (m == MessageBoxResult.Yes)
            {
                var id = (grid_AccountiTafsilLevels.SelectedValue as dynamic).Id;

                AccountingMoeinTafsilRelation deleteItem = Business.GetAccountingMoeinTafsilRelationBussiness().GetByTafsilID(id, parentID);
                Business.GetAccountingMoeinTafsilRelationBussiness().Delete(deleteItem);
                var tafsil = Business.GetAccountingMoeinTafsilRelationBussiness().GetByMoeinID((Guid)cmb_sotoheTafsili.SelectedValue).Select(r => r.AccountingTafsil_ID);
                RefreshGrid(tafsil);
            }
        }
    }
}
