using AccountingKernel.Class;
//using AccountingKernel.Forms.AssetGoods;
using Common;
using Data;
using DocumentFormat.OpenXml.EMMA;
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
using System.Xml;

namespace AccountingKernel.Forms.MmoienCode
{
    /// <summary>
    /// Interaction logic for MoeinGroup.xaml
    /// </summary>
    public partial class MoeinGroup : Window
    {
        List<MyMenuItem> menuItems = null;
        private Guid? FristLevel = Constants.CodeTitle.Goruh;
        private Guid? SecondLevel = Constants.CodeTitle.Kol;

        public MoeinGroup()
        {
            InitializeComponent();
            FillTreeView();
        }

        private void FillTreeView()
        {
            menuItems = Business.GetMoeinStructureDefineBusiness().GetAll().Where(r => r.Parent_ID == null).
               Select(r => new MyMenuItem() { ID = r.ID, Name = r.Name, Code = r.Code, Type = r.Type }).ToList();

            this.DataContext = null;

            FillChildMenuItem();
            trvMenu.ItemsSource = menuItems;
        }

        private void FillChildMenuItem()
        {
            foreach (MyMenuItem item in menuItems)
            {
                var child = Business.GetMoeinStructureDefineBusiness().GetAll().
                    Where(r => r.Parent_ID == item.ID).Select(r => new MyMenuItem() { ID = r.ID, Code = r.Code, Name = r.Name, Type = r.Type }).ToList();


                foreach (var childItem in child)
                    item.Items.Add(childItem);
            }
        }

        private void new_Click(object sender, RoutedEventArgs e)
        {
            MyMenuItem SelectedItem;
            AccountingMoeinStructureDefine ChangableItem;
            AccountingMoeinStructureDefine Child;
            MoeinStructureDefineChild structure = new MoeinStructureDefineChild();

            GetSelected(sender, out SelectedItem, out ChangableItem, out Child);

            if (SelectedItem == null)
            {
                MoeinStructureDefineChild moein = new MoeinStructureDefineChild();
                moein.ShowDialog();
                if (moein.EntityPrimery != null)
                    menuItems.Add(new MyMenuItem() { ID = moein.EntityPrimery.ID, Code = moein.EntityPrimery.Code, Name = moein.EntityPrimery.Name, Type = moein.EntityPrimery.Type });
                if (moein.EntitySecondery != null)
                    menuItems.Find(r => r.ID == moein.EntityPrimery.ID).
                        Items.Add(new MyMenuItem() { ID = moein.EntitySecondery.ID, Code = moein.EntitySecondery.Code, Name = moein.EntitySecondery.Name, Type = moein.EntitySecondery.Type });
                trvMenu.Items.Refresh();
                return;
            }

            if (ChangableItem.Type == SecondLevel)
            {
                var ChangableItemParent = Business.GetMoeinStructureDefineBusiness().GetParent(ChangableItem);
                setDisablePrimeryItem(structure);

                structure.txtPrimeryGroupCode.Text = ChangableItemParent.Code;
                structure.txtPrimeryGroupName.Text = ChangableItemParent.Name;
                structure.txtPrimeryGroupLatinName.Text = ChangableItemParent.Latin_Name;
                structure.CallPrimeryLostFocus();
            }

            structure.ShowDialog();

            if (SelectedItem.Type == Constants.CodeTitle.Goruh && structure.EntityPrimery != null)
            {
                SelectedItem = new MyMenuItem() { Code = structure.EntityPrimery.Code, ID = structure.EntityPrimery.ID, Name = structure.EntityPrimery.Name, Type = Constants.CodeTitle.Goruh };
                menuItems.Add(SelectedItem);
            }
            if (SelectedItem.Type == Constants.CodeTitle.Goruh && structure.EntitySecondery != null)
            {
                AccountingMoeinStructureDefine ChangableItemParent = Business.GetMoeinStructureDefineBusiness().GetParent(structure.EntitySecondery);
                MyMenuItem item = menuItems.Find(r => r.ID == ChangableItemParent.ID);
                item.Items.Add(new MyMenuItem() { Code = structure.EntitySecondery.Code, ID = structure.EntitySecondery.ID, Name = structure.EntitySecondery.Name, Type = Constants.CodeTitle.Kol });
            }

            if (SelectedItem.Type == Common.Constants.CodeTitle.Kol && structure.EntitySecondery != null)
            {
                AccountingMoeinStructureDefine ChangableItemParent = Business.GetMoeinStructureDefineBusiness().GetParent(ChangableItem);
                MyMenuItem item = menuItems.Find(r => r.ID == ChangableItemParent.ID);
                item.Items.Add(new MyMenuItem() { Code = structure.EntitySecondery.Code, ID = structure.EntitySecondery.ID, Name = structure.EntitySecondery.Name, Type = Constants.CodeTitle.Kol });
            }

            trvMenu.Items.Refresh();
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            MyMenuItem SelectedItem;
            AccountingMoeinStructureDefine ChangableItem;
            AccountingMoeinStructureDefine Child;
            GetSelected(sender, out SelectedItem, out ChangableItem, out Child);
            MoeinStructureDefineChild structure = new MoeinStructureDefineChild(ChangableItem);

            try
            {
                if (SelectedItem == null)
                    throw new Exception(Localize.ex_no_record_selected);



                if (ChangableItem.Type == FristLevel)
                {
                    setDisableSecenderyItem(structure);

                    structure.txtPrimeryGroupCode.Text = ChangableItem.Code;
                    structure.txtPrimeryGroupName.Text = ChangableItem.Name;
                    structure.txtPrimeryGroupLatinName.Text = ChangableItem.Latin_Name;
                    if (Child != null)
                        structure.txtPrimeryGroupCode.IsEnabled = false;
                }
                else if (ChangableItem.Type == SecondLevel)
                {
                    setDisablePrimeryItem(structure);

                    structure.txtSecenderyGroupCode.Text = ChangableItem.Code.Substring(structure.GoruhLen);
                    structure.txtSecenderyGroupName.Text = ChangableItem.Name;
                    structure.txtSecenderyGroupLatinName.Text = ChangableItem.Latin_Name;

                    var parent = Business.GetMoeinStructureDefineBusiness().GetParent(ChangableItem);
                    structure.txtPrimeryGroupCode.Text = parent.Code;
                    structure.txtPrimeryGroupName.Text = parent.Name;
                    structure.txtPrimeryGroupLatinName.Text = parent.Latin_Name;

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

        private static void setDisableSecenderyItem(MoeinStructureDefineChild structure)
        {
            structure.txtSecenderyGroupCode.IsEnabled = false;
            structure.txtSecenderyGroupName.IsEnabled = false;
            structure.txtSecenderyGroupLatinName.IsEnabled = false;
        }

        private static void setDisablePrimeryItem(MoeinStructureDefineChild structure)
        {
            structure.txtPrimeryGroupCode.IsEnabled = false;
            structure.txtPrimeryGroupName.IsEnabled = false;
            structure.txtPrimeryGroupLatinName.IsEnabled = false;
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            MyMenuItem SelectedItem;
            AccountingMoeinStructureDefine ChangableItem;
            AccountingMoeinStructureDefine Child;

            GetSelected(sender, out SelectedItem, out ChangableItem, out Child);

            try
            {
                if (SelectedItem == null)
                    throw new Exception(Localize.ex_no_record_selected);
                if (Child != null)
                    throw new Exception(Localize.HasChild);
                else
                {
                    Business.GetMoeinStructureDefineBusiness().Delete(ChangableItem);
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

        private void GetSelected(object sender, out MyMenuItem SelectedItem, out AccountingMoeinStructureDefine ChangableItem, out AccountingMoeinStructureDefine Child)
        {
            if (trvMenu.SelectedItem == null)
            {
                SelectedItem = null;
                ChangableItem = null;
                Child = null;
                return;
            }
            SelectedItem = trvMenu.SelectedItem as MyMenuItem;
            ChangableItem = Business.GetMoeinStructureDefineBusiness().GetByID(SelectedItem.ID).FirstOrDefault();
            Child = Business.GetMoeinStructureDefineBusiness().GetByParentID(ChangableItem.ID).FirstOrDefault();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty((sender as TextBox).Text))
            {
                FillTreeView();
                return;
            }

            var SearchItems = Business.GetMoeinStructureDefineBusiness().Search((sender as TextBox).Text,
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
                    var parent = Business.GetMoeinStructureDefineBusiness().GetParent(item);

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

        AccountingKernelEntities10 ak = new AccountingKernelEntities10();
        private void BtnExel_Click(object sender, RoutedEventArgs e)
        {
            var SearchItems = Business.GetMoeinStructureDefineBusiness().Search(txtSearch.Text,
            new List<Guid?> { FristLevel, SecondLevel }).ToList();

            string get_grouh_id = "";
            int count = 0;
            foreach (var item in SearchItems)
            {
                if (item.Parent_ID != null)
                {
                    get_grouh_id += "," + item.Parent_ID.ToString();
                    count++;
                }
                if (item.Parent_ID == null)
                {
                    if (!get_grouh_id.Contains(item.ID.ToString()))
                        count += ak.AccountingMoeinStructureDefines.Count(l => l.Parent_ID == item.ID);
                }

            }

            string[,] final_array = new string[count, 5];
            string get_id_grouh = String.Empty;

            ////  excel 
            var table = new System.Data.DataTable();
            table.Columns.Add("گروه", typeof(string));
            table.Columns.Add("کل", typeof(string));
            table.Columns.Add("کد گروه", typeof(string));
            table.Columns.Add("کد کل", typeof(string));
            ////
            System.Data.DataRow row = null;
            foreach (var item in SearchItems)
            {

                if (item.Parent_ID != null) // kol
                {
                    // make row
                    get_id_grouh += "," + ak.AccountingMoeinStructureDefines.First(i => i.ID == item.Parent_ID).ID.ToString();
                    string get_grouh_name = ak.AccountingMoeinStructureDefines.First(i => i.ID == item.Parent_ID).Name; // get grouh name 
                    string get_grouh_code = ak.AccountingMoeinStructureDefines.First(i => i.ID == item.Parent_ID).Code;
                    string get_kol_name = item.Name;
                    string get_kol_code = item.Code;

                    row = table.NewRow();
                    row["گروه"] = get_grouh_name;
                    row["کل"] = get_kol_name;
                    row["کد گروه"] = get_grouh_code;
                    row["کد کل"] = get_kol_code;
                    table.Rows.Add(row);
                }

                if (item.Parent_ID == null) // grouh
                {
                    if (!get_id_grouh.Contains(item.ID.ToString()))
                    {
                        // get all sub grouh 
                        var b = ak.AccountingMoeinStructureDefines.Where(i => i.Parent_ID == item.ID);
                        foreach (var item_ in b)
                        {

                            string get_grouh_name = ak.AccountingMoeinStructureDefines.First(i => i.ID == item_.Parent_ID).Name; // get grouh name 
                            string get_grouh_code = ak.AccountingMoeinStructureDefines.First(i => i.ID == item_.Parent_ID).Code;
                            string get_kol_name = item_.Name;
                            string get_kol_code = item_.Code;

                            row = table.NewRow();
                            row["گروه"] = get_grouh_name;
                            row["کل"] = get_kol_name;
                            row["کد گروه"] = get_grouh_code;
                            row["کد کل"] = get_kol_code;
                            table.Rows.Add(row);
                        }
                    }
                }

            }

            ///// dorost kardane DatsET
            System.Data.DataSet ds = new System.Data.DataSet("New_DataSet");
            ds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;
            ds.Tables.Add(table);
            ///////////////////////////

            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = ""; // Default file name
            dlg.DefaultExt = ".xls"; // Default file extension
            dlg.Filter = "Text documents (.xls)|*.xls"; // Filter files by extension
            Nullable<bool> result = dlg.ShowDialog();
            string filename = "";
            if (result == true)
            {
                filename = dlg.FileName;
                //ExcelLibrary.DataSetHelper.CreateWorkbook(filename, ds);
                // Step 2: Create the Excel .xlsx file
                try
                {
                    bool b = CreateExcelFile.CreateExcelDocument(ds, filename);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Couldn't create Excel file.\r\nException: " + ex.Message);
                    return;
                }
            }

        }

    }


}
