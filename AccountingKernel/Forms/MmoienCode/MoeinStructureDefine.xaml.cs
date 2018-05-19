using AccountingKernel.Class;
using Common;
using System;
using System.Collections;
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

namespace AccountingKernel.Forms.MmoienCode
{
    /// <summary>
    /// Interaction logic for MoeinStructureDefine.xaml              SearchTemplate
    /// </summary>
    public partial class MoeinStructureDefine : Window
    {
        public Guid ID;
        public string Code;
        public Guid ParentID;
        public string Name;

        private class LabelValues
        {
            public Guid ID;
            public string name;
            public string code;
            public Guid Type;
            public Label label;
        }

        private Guid? parentId;
        private List<LabelValues> LabelList;
        private int top, left, width, height, depth;

        public MoeinStructureDefine()
        {
            InitializeComponent();

            LabelList = new List<LabelValues>();
            top = 0;
            left = 0;
            width = 100;
            height = 50;
            depth = 0;
            var entity = Business.GetMoeinStructureDefineBusiness().GetAll().Where(r => r.Type == Constants.CodeTitle.Goruh && r.Parent_ID.Equals(null));
            SetGrid(entity);
        }

        private void grdList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (grdList.SelectedValue == null)
                    return;

                parentId = (grdList.SelectedValue as dynamic).ID;
                string code = (grdList.SelectedValue as dynamic).Code;
                string name = (grdList.SelectedValue as dynamic).Name;
                Guid type = (grdList.SelectedValue as dynamic).Type;

                if (type == Constants.CodeTitle.Moein)
                    return;

                var en = Business.GetMoeinStructureDefineBusiness().GetByParentID(parentId);

                SetGrid(en);

                if (LabelList.Count > depth)
                    LabelList.RemoveAt(depth);
                LabelList.Add(new LabelValues() { code = code, ID = parentId.ToGUID(), name = name, Type = type });

                AddLabel(LabelList[depth]);
            }
            catch
            {
                throw;
            }
        }

        private void SetGrid(IQueryable<Data.AccountingMoeinStructureDefine> entity)
        {
            grdList.ItemsSource = null;

            if (entity.Count() == 0)
            {
                grdList.ItemsSource = null;
                return;
            }
            if (entity.FirstOrDefault().Type == Constants.CodeTitle.Goruh)
            {
                grdList.ItemsSource = Business.GetMoeinStructureDefineBusiness().GetAll().Where(r => r.Parent_ID == null && r.Type == Constants.CodeTitle.Goruh)
                    .Select(r => new SearchTemplate() { ID = r.ID, Code = r.Code, Name = r.Name, Type = r.Type, ParentID = r.Parent_ID }).ToList(); ;
                return;
            }
            if (entity.FirstOrDefault().Type == Constants.CodeTitle.Kol)
                grdList.ItemsSource = entity.Select(r => new SearchTemplate() { ID = r.ID, Code = r.Code, Name = r.Name, Type = r.Type, ParentID = r.Parent_ID }).ToList();
        }

        private void AddLabel(LabelValues labellsit)
        {
            try
            {
                var label = new Label();
                label.Content = labellsit.name;
                label.Width = width;
                label.Height = height;
                label.Margin = new Thickness(left + depth * width, top, left + label.Width + depth * width, top + label.Height);
                label.MouseLeftButtonDown += label_MouseLeftButtonDown;
                labellsit.label = label;
                depth++;
                canvas.Children.Add(label);
            }
            catch
            {
                throw;
            }
        }

        private void label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            LabelValues Removeditem = LabelList.FirstOrDefault(r => r.label == sender);

            var p = Business.GetMoeinStructureDefineBusiness().GetByID(Removeditem.ID);

            if (Removeditem.Type == Constants.CodeTitle.Goruh)
            {
                canvas.Children.Clear();
                LabelList.Clear();
                top = 0;
                left = 0;
                width = 100;
                height = 50;
                depth = 0;
                SetGrid(p);
                return;
            }

            Label RemovedLabel = Removeditem.label;

            Guid? id = Removeditem.ID;

            LabelList.Remove(Removeditem);
            canvas.Children.Remove(RemovedLabel);
            depth--;

            //pass removed id
            SetGridOnRemove(id);
        }

        private void SetGridOnRemove(Guid? id)
        {
            Guid? Parentid = Business.GetMoeinStructureDefineBusiness().GetByID(id).Select(r => r.Parent_ID).FirstOrDefault();
            grdList.ItemsSource = Business.GetMoeinStructureDefineBusiness().GetAll().Where(r => r.Parent_ID == Parentid).
                Select(r => new SearchTemplate() { ID = r.ID, Code = r.Code, Name = r.Name, Type = r.Type, ParentID = r.Parent_ID }).ToList();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            FormClose();
        }

        private void FormClose()
        {
            if (LabelList.Count == 0)
                return;

            var first = LabelList.First();
            var last = LabelList.Last();

            if (first.name.Equals(last.name))
            {
                MessageBox.Show(" کل را انتخاب کنید");
                return;
            }
            Name = string.Format("{0}/{1}", first.name, last.name);
            ID = last.ID;

            string DefaultCode = Business.GetMoeinStructureDefineBusiness().GetDefualtCode(Common.Constants.CodeTitle.Moein, ID);
            Code = Business.GetMoeinStructureDefineBusiness().GetCode(Constants.CodeTitle.Moein, DefaultCode);

            this.Close();
        }

        private void Search(object sender, KeyEventArgs e)
        {
            Guid? GridItemsType;
            Guid? GridItemsParentID = null;

            GetGridType(out GridItemsType);

            foreach (LabelValues item in LabelList)
            {

                GridItemsParentID = item.ID;
                break;
            }


            if (txtSearch.Text.Trim().Length > 0)
            {
                if (GridItemsParentID == null)
                    grdList.ItemsSource = Business.GetMoeinStructureDefineBusiness().GetAll().Where(r => r.Type == GridItemsType && r.Parent_ID.Equals(GridItemsParentID) &&
                        r.Code.Contains(txtSearch.Text) || r.Name.StartsWith(txtSearch.Text)).Select(r => new SearchTemplate() { ID = r.ID, Code = r.Code, Name = r.Name, ParentID = r.Parent_ID, Type = r.Type }).ToList();
                else
                    grdList.ItemsSource = Business.GetMoeinStructureDefineBusiness().GetAll().Where(r => r.Type == GridItemsType && r.Parent_ID == GridItemsParentID &&
                        (r.Code.Contains(txtSearch.Text) || r.Name.StartsWith(txtSearch.Text))).Select(r => new SearchTemplate() { ID = r.ID, Code = r.Code, Name = r.Name, ParentID = r.Parent_ID, Type = r.Type }).ToList();
            }
            else
            {
                IQueryable<Data.AccountingMoeinStructureDefine> entity = null;
                if (GridItemsParentID == null)
                    entity = Business.GetMoeinStructureDefineBusiness().GetAll().Where(r => r.Type == GridItemsType && r.Parent_ID.Equals(GridItemsParentID));
                else
                    entity = Business.GetMoeinStructureDefineBusiness().GetAll().Where(r => r.Type == GridItemsType && r.Parent_ID == GridItemsParentID);

                SetGrid(entity);
            }
        }

        private void GetGridType(out Guid? GridItemsType)
        {
            GridItemsType = null;

            if (canvas.Children.Count == 0)
                GridItemsType = Constants.CodeTitle.Goruh;

            if (canvas.Children.Count == 1)
                GridItemsType = Constants.CodeTitle.Kol;
        }
    }
}
