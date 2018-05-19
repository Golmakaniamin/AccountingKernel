using Common;
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

namespace AccountingKernel.Forms.Company
{
    /// <summary>
    /// Interaction logic for CompanyStructureDefine.xaml
    /// </summary>
    public partial class CompanyStructureDefine : Window
    {
        public CompanyStructureDefine()
        {
            InitializeComponent();

            //Constants.CodeTitle.CompanyMainGroup //asli
            //Constants.CodeTitle.CompanySubsidiaryGroup //faree
            //Constants.CodeTitle.CompanyType 

            LabelList = new List<LabelValues>();
            //parentId = Constants.CodeTitle.PersonPrimeryGroup;
            top = 0;
            left = 0;
            width = 100;
            height = 50;
            depth = 0;
            SetGrid(Constants.CodeTitle.CompanyMainGroup);
        }

        public Guid ID;
        public string Code;
        public Guid ParentID;
        public string Name;

        private class LabelValues
        {
            public Guid ID;
            public string name;
            public string code;
            public Label label;
        }

        private Guid? parentId;

        private List<LabelValues> LabelList;

        private int top, left, width, height, depth;


        private void grdList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (grdList.SelectedValue == null)
                    return;

                parentId = (grdList.SelectedValue as dynamic).ID;
                string code = (grdList.SelectedValue as dynamic).Code;
                string name = (grdList.SelectedValue as dynamic).Name;

                Guid? type = Business.GetCompanyStructureDefineBusiness().GetByParentID(parentId).Select(r => r.Type).FirstOrDefault();

                SetGrid(type);

                if (LabelList.Count > depth)
                    LabelList.RemoveAt(depth);
                LabelList.Add(new LabelValues() { code = code, ID = parentId.ToGUID(), name = name });

                AddLabel(LabelList[depth]);
            }
            catch
            {
                throw;
            }
        }

        private void SetGrid(Guid? type)
        {

            if (type == Constants.CodeTitle.CompanyType)
            {
                grdList.ItemsSource = null;
                return;
            }
            grdList.ItemsSource = Business.GetCompanyStructureDefineBusiness().GetByType(type).
                Select(r => new { ID = r.ID, Code = r.Code, Name = r.Name, Type = r.Type }).ToList();
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
            var Removeditem = LabelList.FirstOrDefault(r => r.label == sender);

            if (Removeditem.code.Length == 3)
            {
                canvas.Children.Clear();
                LabelList.Clear();
                parentId = Constants.CodeTitle.CompanyMainGroup;
                top = 0;
                left = 0;
                width = 100;
                height = 50;
                depth = 0;
                SetGrid(parentId);
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
            //get removed Parent ID
            Guid? Pid = Business.GetCompanyStructureDefineBusiness().GetById(id).
                Select(r => r.Parent_ID).FirstOrDefault();

            if (Pid == null)
                SetGrid(Constants.CodeTitle.CompanyMainGroup);
            else
                //set Item source on parentid like removed parentid
                grdList.ItemsSource = Business.GetCompanyStructureDefineBusiness().GetAll().Where(r => r.Parent_ID == Pid).ToList();
        }


        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            FormClose();
        }

        private void FormClose()
        {
            var first = LabelList.AsQueryable().First();
            var last = LabelList.AsQueryable().Last();

            if (first.name.Equals(last.name))
            {
                MessageBox.Show("گروه فرعی را انتخاب کنید");
                return;
            }
            Name = string.Format("{0}/{1}", first.name, last.name);
            ID = last.ID;

            Code = Business.GetCompanyStructureDefineBusiness().GetCode(ID, Constants.CodeTitle.CompanyType, string.Format("{0}001", last.code));
            this.Close();
        }

    }
}
