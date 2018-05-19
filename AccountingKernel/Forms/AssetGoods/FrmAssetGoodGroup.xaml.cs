using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Common;
using System.Transactions;
using System.Windows.Data;


namespace AccountingKernel.Forms.AssetGoods
{


    /// Interaction logic for Document.xaml
    /// </summary>
    public partial class FrmAssetGoodGroup : Window
    {
        public List<MainGroup> MainGroups { get; set; }
        public List<SubGroup> SubCategories { get; set; }

        public Guid? AssetGoodId;

        public FrmAssetGoodGroup()
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


                var assetGoodsBusiness = Business.GetAssetGoodsBusiness();
                var assetGoodMainGroup = assetGoodsBusiness.GetByCodeTitleId(Common.Constants.CodeTitle.AssetGoodMianGroup).ToList();
                var assetGoodSubsidiaryGroup = assetGoodsBusiness.GetByCodeTitleId(Common.Constants.CodeTitle.AssetGoodSubsidiaryGroup).ToList();

                MainGroups = new List<MainGroup>();

                foreach (var item in assetGoodMainGroup)
                {
                    var subGroup = assetGoodSubsidiaryGroup.FindAll(r => r.parentId == item.ID);
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

        private void btnSelectAssetGood_Click(object sender, RoutedEventArgs e)
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
                //if (devgrid.SelectedItem == null)
                //    throw new Exception(Localize.ex_no_record_selected);

                //this.AssetGoodId = (devgrid.SelectedItem as dynamic).Id;
                //this.Close();
            }
            catch
            {

                throw;
            }
        }

        private void MenuItem_Register(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                var frmRegisterAssetGoodGroups = new FrmRegisterAssetGoodGroup();
                frmRegisterAssetGoodGroups.ShowDialog();
                SetDataGrid();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }

        }

        private void MenuItem_Edit(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                //if (DataGrid.SelectedValue == null)
                //    throw new Exception(Localize.ex_no_record_selected);
                //new FrmRegisterAssetGoodGroup((DataGrid.SelectedValue as dynamic).Id).ShowDialog();
                //SetDataGrid();
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
                //if (DataGrid.SelectedValue == null)
                //    throw new Exception(Localize.ex_no_record_selected);

                //var msgResult = MessageBox.Show(Localize.DeleteRecordMessage, Localize.DeleteRecordCaption, MessageBoxButton.YesNo, MessageBoxImage.Question);
                //if (msgResult != MessageBoxResult.Yes)
                //    return;

                //Business.GetAssetGoodsBusiness().Delete(Business.GetAssetGoodsBusiness().GetById((DataGrid.SelectedValue as dynamic).Id));

                SetDataGrid();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void mnuNew_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var frmRegisterAssetGoodGroups = new FrmRegisterAssetGoodGroup();
                frmRegisterAssetGoodGroups.ShowDialog();
                SetDataGrid();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }

        }

        private void menuEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                try
                {
                    //if (devgrid.SelectedItem == null)
                    //    throw new Exception(Localize.ex_no_record_selected);
                    //new FrmRegisterAssetGoodGroup((devgrid.SelectedItem as dynamic).Id).ShowDialog();
                    //SetDataGrid();
                }
                catch (Exception ex)
                {
                    AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
                }

            }
            catch
            {

                throw;
            }
        }

        private void mnuDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //if (devgrid.SelectedItem == null)
                //    throw new Exception(Localize.ex_no_record_selected);

                //var msgResult = MessageBox.Show(Localize.DeleteRecordMessage, Localize.DeleteRecordCaption, MessageBoxButton.YesNo, MessageBoxImage.Question);
                //if (msgResult != MessageBoxResult.Yes)
                //    return;

                //Business.GetAssetGoodsBusiness().Delete(Business.GetAssetGoodsBusiness().GetById((devgrid.SelectedItem as dynamic).Id));

                SetDataGrid();
            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void devgrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
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

        private void DataGrid_MouseRightButtonDown_1(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            
        }



    }
}
