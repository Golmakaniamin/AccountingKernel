using AccountingKernel.Class;
using AccountingKernel.Forms.MmoienCode;
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
    /// Interaction logic for ManageTafsiliGroup.xaml
    /// </summary>
    public partial class ManageTafsiliGroup : Window
    {
        List<MyMenuItem> menuItems = null;
        private Guid? FristLevel = Constants.CodeTitle.TafsilGroup;
        private Guid? SecondLevel = Constants.CodeTitle.AccountGroup;

        public ManageTafsiliGroup()
        {
            InitializeComponent();
            FillTreeView();
        }

        private void FillTreeView()
        {
            menuItems = Business.GetTafsilStructureDefineBusiness().GetAll().Where(r => r.Parent_ID == null).
               Select(r => new MyMenuItem() { ID = r.ID, Name = r.Name, Code = r.Code, Type = r.Type }).ToList();

            this.DataContext = null;

            FillChildMenuItem();
            trvMenu.ItemsSource = menuItems;
        }

        private void FillChildMenuItem()
        {
            foreach (MyMenuItem item in menuItems)
            {
                var child = Business.GetTafsilStructureDefineBusiness().GetAll().
                    Where(r => r.Parent_ID == item.ID).Select(r => new MyMenuItem() { ID = r.ID, Code = r.Code, Name = r.Name, Type = r.Type }).ToList();

                foreach (var childItem in child)
                    item.Items.Add(childItem);
            }
        }

        private void new_Click(object sender, RoutedEventArgs e)
        {
            MyMenuItem SelectedItem;
            AccountingTafsilStructureDefine ChangableItem;
            AccountingTafsilStructureDefine Child;
            Tarife_hesabe_tafsili structure = new Tarife_hesabe_tafsili();

            GetSelected(sender, out SelectedItem, out ChangableItem, out Child);

            if (SelectedItem == null)
            {
                Tarife_hesabe_tafsili tafsil = new Tarife_hesabe_tafsili();
                tafsil.ShowDialog();
                if (tafsil.EntityPrimery != null)
                    menuItems.Add(new MyMenuItem() { ID = tafsil.EntityPrimery.ID, Code = tafsil.EntityPrimery.Code, Name = tafsil.EntityPrimery.Name, Type = Constants.CodeTitle.TafsilGroup });
                if (tafsil.EntitySecondery != null)
                    menuItems.Find(r => r.ID == tafsil.EntityPrimery.ID).
                        Items.Add(new MyMenuItem() { ID = tafsil.EntitySecondery.ID, Code = tafsil.EntitySecondery.Code, Name = tafsil.EntitySecondery.Name, Type = Constants.CodeTitle.AccountGroup });
                trvMenu.Items.Refresh();
                return;
            }

            if (ChangableItem.Type == SecondLevel)
            {
                var ChangableItemParent = Business.GetTafsilStructureDefineBusiness().GetParent(ChangableItem);
                setDisablePrimeryItem(structure);

                structure.txtPrimeryGroupCode.Text = ChangableItemParent.Code;
                structure.txtPrimeryGroupName.Text = ChangableItemParent.Name;
                structure.CallPrimeryLostFocus();
            }

            structure.ShowDialog();

            if (SelectedItem.Type == Constants.CodeTitle.TafsilGroup && structure.EntityPrimery != null)
            {
                SelectedItem = new MyMenuItem() { Code = structure.EntityPrimery.Code, ID = structure.EntityPrimery.ID, Name = structure.EntityPrimery.Name, Type = Constants.CodeTitle.TafsilGroup };
                menuItems.Add(SelectedItem);
            }
            if (SelectedItem.Type == Constants.CodeTitle.TafsilGroup && structure.EntitySecondery != null)
            {
                AccountingTafsilStructureDefine ChangableItemParent = Business.GetTafsilStructureDefineBusiness().GetParent(structure.EntitySecondery);
                MyMenuItem item = menuItems.Find(r => r.ID == ChangableItemParent.ID);
                item.Items.Add(new MyMenuItem() { Code = structure.EntitySecondery.Code, ID = structure.EntitySecondery.ID, Name = structure.EntitySecondery.Name, Type = Constants.CodeTitle.AccountGroup });
            }

            if (SelectedItem.Type == Common.Constants.CodeTitle.AccountGroup && structure.EntitySecondery != null)
            {
                AccountingTafsilStructureDefine ChangableItemParent = Business.GetTafsilStructureDefineBusiness().GetParent(ChangableItem);
                MyMenuItem item = menuItems.Find(r => r.ID == ChangableItemParent.ID);
                item.Items.Add(new MyMenuItem() { Code = structure.EntitySecondery.Code, ID = structure.EntitySecondery.ID, Name = structure.EntitySecondery.Name, Type = Constants.CodeTitle.AccountGroup });
            }

            trvMenu.Items.Refresh();
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            MyMenuItem SelectedItem;
            AccountingTafsilStructureDefine ChangableItem;
            AccountingTafsilStructureDefine Child;
            GetSelected(sender, out SelectedItem, out ChangableItem, out Child);
            Tarife_hesabe_tafsili structure = new Tarife_hesabe_tafsili(ChangableItem);

            try
            {
                if (SelectedItem == null)
                    throw new Exception(Localize.ex_no_record_selected);

                if (ChangableItem.Type == FristLevel)
                {
                    setDisableSecenderyItem(structure);

                    structure.txtPrimeryGroupCode.Text = ChangableItem.Code;
                    structure.txtPrimeryGroupName.Text = ChangableItem.Name;
                    if (Child != null)
                        structure.txtPrimeryGroupCode.IsEnabled = false;
                }
                else if (ChangableItem.Type == SecondLevel)
                {
                    setDisablePrimeryItem(structure);

                    structure.txtSecenderyGroupCode.Text = ChangableItem.Code.Substring(structure.codeTitleLen);
                    structure.txtSecenderyGroupName.Text = ChangableItem.Name;

                    var parent = Business.GetTafsilStructureDefineBusiness().GetParent(ChangableItem);
                    structure.txtPrimeryGroupCode.Text = parent.Code;
                    structure.txtPrimeryGroupName.Text = parent.Name;

                    if (Child != null)
                        structure.txtSecenderyGroupCode.IsEnabled = false;
                }

                structure.DisableEvent();

                structure.ShowDialog();

                SelectedItem.ID = structure.EditedItem.ID;
                SelectedItem.Name = structure.EditedItem.Name;
                SelectedItem.Code = structure.EditedItem.Code;

            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
            trvMenu.Items.Refresh();
        }

        private static void setDisableSecenderyItem(Tarife_hesabe_tafsili structure)
        {
            structure.txtSecenderyGroupCode.IsEnabled = false;
            structure.txtSecenderyGroupName.IsEnabled = false;
        }

        private static void setDisablePrimeryItem(Tarife_hesabe_tafsili structure)
        {
            structure.txtPrimeryGroupCode.IsEnabled = false;
            structure.txtPrimeryGroupName.IsEnabled = false;
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            MyMenuItem SelectedItem;
            AccountingTafsilStructureDefine ChangableItem;
            AccountingTafsilStructureDefine Child;

            GetSelected(sender, out SelectedItem, out ChangableItem, out Child);

            try
            {
                if (SelectedItem == null)
                    throw new Exception(Localize.ex_no_record_selected);
                if (Child != null)
                    throw new Exception(Localize.HasChild);
                else
                {
                    Business.GetTafsilStructureDefineBusiness().Delete(ChangableItem);
                    menuItems.ForEach(r => r.Items.Remove(SelectedItem));
                    menuItems.Remove(SelectedItem);
                    trvMenu.Items.Refresh();
                }

            }
            catch (Exception ex)
            {
                AccountingKernel.Forms.Base.BaseWindow.ShowError(ex);
            }
        }

        private void GetSelected(object sender, out MyMenuItem SelectedItem, out AccountingTafsilStructureDefine ChangableItem, out AccountingTafsilStructureDefine Child)
        {
            if (trvMenu.SelectedItem == null)
            {
                SelectedItem = null;
                ChangableItem = null;
                Child = null;
                return;
            }
            SelectedItem = trvMenu.SelectedItem as MyMenuItem;
            ChangableItem = Business.GetTafsilStructureDefineBusiness().GetByID(SelectedItem.ID).FirstOrDefault();
            Child = Business.GetTafsilStructureDefineBusiness().GetByParentID(ChangableItem.ID).FirstOrDefault();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty((sender as TextBox).Text))
            {
                FillTreeView();
                return;
            }

            var SearchItems = Business.GetTafsilStructureDefineBusiness().Search((sender as TextBox).Text,
                new List<Guid?> { FristLevel, SecondLevel }).ToList();

            menuItems.Clear();

            foreach (var item in SearchItems)
            {
                if (item.Type == FristLevel)
                {
                    menuItems.Add(new MyMenuItem() { ID = item.ID, Code = item.Code, Name = item.Name, Type = item.Type });
                }
            }
            bool haveChild = false;
            foreach (var item in SearchItems)
            {
                if (item.Type == SecondLevel)
                {
                    var parent = Business.GetTafsilStructureDefineBusiness().GetParent(item);

                    if (menuItems.Find(r => r.ID == parent.ID) == null)
                        menuItems.Add(new MyMenuItem() { ID = parent.ID, Code = parent.Code, Name = parent.Name, Type = parent.Type });
                    menuItems.Find(r => r.ID == parent.ID).Items.Add(new MyMenuItem() { ID = item.ID, Code = item.Code, Name = item.Name, Type = item.Type });
                    haveChild = true;
                }
            }
            if (haveChild == false)
                FillChildMenuItem();

            trvMenu.ItemsSource = menuItems;
            trvMenu.Items.Refresh();

            foreach (var item in trvMenu.Items)
            {
                DependencyObject dObject = trvMenu.ItemContainerGenerator.ContainerFromItem(item);
                ((TreeViewItem)dObject).ExpandSubtree();
            }
        }

        private void BtnExel_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
