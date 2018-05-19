using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Common;
using System.Transactions;
using System.Windows.Data;
using System.Data;

namespace AccountingKernel.Forms.Goodies.Groups
{
    /// <summary>
    /// Interaction logic for Document.xaml
    /// </summary>
    public partial class FrmGoodiesGroups : Window
    {
        public List<MainGroup> MainGroups { get; set; }
        public List<SubGroup> SubCategories { get; set; }
        Guid? SelectedId;
        bool IsMain = false;

        string[,] ss;
        int cc;
        public Guid? GoodiesGroupId;

        public FrmGoodiesGroups()
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

        /// <summary>
        /// sets store order detail data grid 
        /// </summary>
        private void SetDataGrid()
        {
            try
            {


                var goodiesGroupBusiness = Business.GetGoodiesGroupBusiness();
                var mainGroups = goodiesGroupBusiness.GetByCodeTitleId(Common.Constants.CodeTitle.CommodityMainGroup).ToList();
                var subsidiaryGroups = goodiesGroupBusiness.GetByCodeTitleId(Common.Constants.CodeTitle.CommoditySubsidiaryGroup).ToList();

                MainGroups = new List<MainGroup>();

                foreach (var item in mainGroups)
                {
                    var subGroup = subsidiaryGroups.FindAll(r => r.ParentId == item.ID);
                    MainGroups.Add(new MainGroup(item, subGroup));
                };

                treeView.ItemsSource = MainGroups;

                DataContext = this;


            }

            catch
            {

                throw;
            }

        }

        private void txtSearch_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            try
            {
                SetDataGrid();
            }
            catch
            {

                throw;
            }
        }

        private void MenuItem_Edit(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                if (!SelectedId.HasValue)
                    throw new Exception(Localize.ex_no_record_selected);

                new FrmRegisterGoodiesGroups(SelectedId.Value, IsMain).ShowDialog();
                SetDataGrid();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }

        }

        private void MenuItem_Register(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                new FrmRegisterGoodiesGroups().ShowDialog();
                SetDataGrid();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }

        }

        private void MenuItem_Delete(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                if (!SelectedId.HasValue)
                    throw new Exception(Localize.ex_no_record_selected);

                var msgResult = MessageBox.Show(Localize.DeleteRecordMessage, Localize.DeleteRecordCaption, MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (msgResult != MessageBoxResult.Yes)
                    return;

                Business.GetGoodiesGroupBusiness().Delete(Business.GetGoodiesGroupBusiness().GetById(SelectedId.Value));

                SetDataGrid();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void btnSelectGroup_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SelectAssetGood();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }

        }

        private void DataGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                SelectAssetGood();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }

        }

        private void SelectAssetGood()
        {
            try
            {
                //    if (DataGrid.SelectedItem == null)
                //        throw new Exception(Localize.ex_no_record_selected);

                //    this.GoodiesGroupId = (DataGrid.SelectedItem as dynamic).Id;
                //    this.Close();
            }
            catch
            {

                throw;
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!SelectedId.HasValue)
                    throw new Exception(Localize.ex_no_record_selected);

                new FrmRegisterGoodiesGroups(SelectedId.Value, IsMain).ShowDialog();
                SetDataGrid();

            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }

        }

        private void MenuItem_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                if (treeView.SelectedValue == null)
                    throw new Exception(Localize.ex_no_record_selected);

                //new FrmRegisterGoodiesGroups((DataGrid.SelectedValue as dynamic).MainGroupId, (DataGrid.SelectedValue as dynamic).SubsidiaryGroupId).ShowDialog();
                SetDataGrid();

            }
            catch
            {

                throw;
            }
        }


        private void grd_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                if (e.EditAction != DataGridEditAction.Commit)
                    return;

                Guid selectedItemId;
                selectedItemId = ((sender as DataGrid).SelectedItem as dynamic).Id;
                var entity = Business.GetGoodiesGroupBusiness().GetById(selectedItemId);
                entity.CName = ((System.Windows.Controls.TextBox)e.EditingElement).Text;
                Business.GetGoodiesGroupBusiness().Save(entity);
            }
            catch
            {

                throw;
            }


        }

        private void DataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            try
            {
                if ((sender as DataGrid).SelectedValue != null)
                {
                    SelectedId = ((sender as DataGrid).SelectedValue as dynamic).Id;
                    IsMain = false;
                }
            }
            catch
            {

                throw;
            }
        }

        private void treeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            try
            {
                if ((sender as TreeView).SelectedValue != null)
                {
                    SelectedId = ((sender as TreeView).SelectedValue as dynamic).ID;
                    IsMain = true;
                }
            }
            catch
            {

                throw;
            }
        }

    }
}
