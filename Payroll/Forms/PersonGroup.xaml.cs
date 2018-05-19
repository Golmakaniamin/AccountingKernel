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


namespace AccountingKernel.Forms
{
    /// <summary>
    /// Interaction logic for PersonGroup.xaml
    /// </summary>
    public partial class PersonGroup : Window
    {
        //List<MyMenuItem> menuItems = null;

        //public PersonGroup()
        //{
        //    InitializeComponent();
        //    FillTreeView();
        //}

        //private void FillTreeView()
        //{
        //    menuItems = Business.GetPersonStructureDefineChildBusiness().GetAll().Where(r => r.Parent_ID == Guid.Empty).
        //       Select(r => new MyMenuItem() { ID = r.ID, Title = r.Name, Code = r.Code }).ToList();

        //    this.DataContext = null;

        //    foreach (MyMenuItem item in menuItems)
        //    {
        //        var child = Business.GetPersonStructureDefineChildBusiness().GetAll().Where(r => r.Parent_ID == item.ID)
        //            .Select(r => new MyMenuItem() { ID = r.ID, Code = r.Code, Title = r.Name }).ToList();

        //        foreach (var childItem in child)
        //            item.Items.Add(childItem);
        //    }
        //    trvMenu.ItemsSource = menuItems;
        //}

        //private void new_Click(object sender, RoutedEventArgs e)
        //{
        //    MyMenuItem SelectedItem;
        //    PersonStructureDefine ChangableItem;
        //    PersonStructureDefine Child;
        //    PersonStructureDefineChild structure = new PersonStructureDefineChild();

        //    GetSelected(sender, out SelectedItem, out ChangableItem, out Child);

        //    var ChangableItemParent = Business.GetPersonStructureDefineChildBusiness().GetParent(ChangableItem);

        //    if (ChangableItem.Type == Constants.CodeTitle.PersonSecendryGroup)
        //    {
        //        setDisablePrimeryItem(structure);

        //        structure.txtPrimeryGroupCode.Text = ChangableItemParent.Code;
        //        structure.txtPrimeryGroupName.Text = ChangableItemParent.Name;
        //        structure.CallPrimeryLostFocus();

        //    }

        //    structure.ShowDialog();

        //    if (structure.EntityPrimery != null)
        //    {
        //        SelectedItem = new MyMenuItem() { Code = structure.EntityPrimery.Code, ID = structure.EntityPrimery.ID, Title = structure.EntityPrimery.Name };
        //        if (trvMenu.Items.Contains(SelectedItem) == false)
        //            menuItems.Add(SelectedItem);
        //    }
        //    if (structure.EntitySecondery != null && SelectedItem != null)
        //    {
        //        var item = menuItems.Find(r => r.ID == ChangableItemParent.ID);
        //        item.Items.Add(new MyMenuItem() { Code = structure.EntitySecondery.Code, ID = structure.EntitySecondery.ID, Title = structure.EntitySecondery.Name });
        //    }

        //    trvMenu.Items.Refresh();
        //}

        //private void edit_Click(object sender, RoutedEventArgs e)
        //{
        //    MyMenuItem SelectedItem;
        //    PersonStructureDefine ChangableItem;
        //    PersonStructureDefine Child;
        //    GetSelected(sender, out SelectedItem, out ChangableItem, out Child);

        //    PersonStructureDefineChild structure = new PersonStructureDefineChild(ChangableItem);
        //    if (ChangableItem.Type == Constants.CodeTitle.PersonPrimeryGroup)
        //    {
        //        setDisableSecenderyItem(structure);

        //        structure.txtPrimeryGroupCode.Text = ChangableItem.Code;
        //        structure.txtPrimeryGroupName.Text = ChangableItem.Name;
        //        if (Child != null)
        //            structure.txtPrimeryGroupCode.IsEnabled = false;
        //    }
        //    else if (ChangableItem.Type == Constants.CodeTitle.PersonSecendryGroup)
        //    {
        //        setDisablePrimeryItem(structure);

        //        structure.txtSecenderyGroupCode.Text = ChangableItem.Code.Substring(structure.codeTitleLen);
        //        structure.txtSecenderyGroupName.Text = ChangableItem.Name;

        //        var parent = Business.GetPersonStructureDefineChildBusiness().GetParent(ChangableItem);
        //        structure.txtPrimeryGroupCode.Text = parent.Code;
        //        structure.txtPrimeryGroupName.Text = parent.Name;

        //        if (Child != null)
        //            structure.txtSecenderyGroupCode.IsEnabled = false;
        //    }

        //    structure.DisableEvent();

        //    structure.ShowDialog();

        //    SelectedItem.ID = structure.EditedItem.ID;
        //    SelectedItem.Title = structure.EditedItem.Name;
        //    SelectedItem.Code = structure.EditedItem.Code;

        //    trvMenu.Items.Refresh();
        //}

        //private static void setDisableSecenderyItem(PersonStructureDefineChild structure)
        //{
        //    structure.txtSecenderyGroupCode.IsEnabled = false;
        //    structure.txtSecenderyGroupName.IsEnabled = false;
        //}

        //private static void setDisablePrimeryItem(PersonStructureDefineChild structure)
        //{
        //    structure.txtPrimeryGroupCode.IsEnabled = false;
        //    structure.txtPrimeryGroupName.IsEnabled = false;
        //}

        //private void delete_Click(object sender, RoutedEventArgs e)
        //{
        //    MyMenuItem SelectedItem;
        //    PersonStructureDefine ChangableItem;
        //    PersonStructureDefine Child;
        //    GetSelected(sender, out SelectedItem, out ChangableItem, out Child);

        //    if (Child != null)
        //        MessageBox.Show("آیتم انتخاب شده دارای زیر مجموعه میباشد");
        //    else
        //    {
        //        Business.GetPersonStructureDefineChildBusiness().Delete(ChangableItem);
        //        menuItems.ForEach(r => r.Items.Remove(SelectedItem));
        //        menuItems.Remove(SelectedItem);
        //        trvMenu.Items.Refresh();
        //    }
        //}

        //private void GetSelected(object sender, out MyMenuItem SelectedItem, out PersonStructureDefine ChangableItem, out PersonStructureDefine Child)
        //{
        //    SelectedItem = ((sender as MenuItem).DataContext) as MyMenuItem;
        //    ChangableItem = Business.GetPersonStructureDefineChildBusiness().GetByID(SelectedItem.ID).FirstOrDefault();
        //    Child = Business.GetPersonStructureDefineChildBusiness().GetByParentID(ChangableItem.ID).FirstOrDefault();
        //}

        //private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        //{

        //}
        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void new_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
