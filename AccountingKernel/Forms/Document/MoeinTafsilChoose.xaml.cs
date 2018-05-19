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

namespace AccountingKernel.Forms.Document
{
    /// <summary>
    /// Interaction logic for MoeinTafsilChoose.xaml
    /// </summary>
    public partial class MoeinTafsilChoose : Window
    {
        public class LabelValues
        {
            public Guid codeTitle;
            public string value;
            public string code;
            public Label label;
        }

        private int Level;

        private Guid parentId;

        public List<LabelValues> LabelList;

        private Guid? Goruh = Constants.CodeTitle.Goruh;

        private int top, left, width, height, depth;

        private Data.AccountingMoeinStructureDefine Moein;


        public MoeinTafsilChoose()
        {
            InitializeComponent();
            Level = 1;
            LabelList = new List<LabelValues>();
            ResetLablePosition();

            grdList.ItemsSource = Business.GetMoeinStructureDefineBusiness().GetAll().Where(r => r.Type == Goruh)
                .Select(r => new { ID = r.ID, Code = r.Code, Name = r.Name, Type = r.Type }).ToList();
        }

        private void ResetLablePosition()
        {
            top = 0;
            left = 0;
            width = 100;
            height = 50;
            depth = 0;
        }

        private void grdList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Level++;
            try
            {
                if (grdList.SelectedValue == null)
                    return;

                parentId = (grdList.SelectedValue as dynamic).ID;
                string code = (grdList.SelectedValue as dynamic).Code;
                string name = (grdList.SelectedValue as dynamic).Name;

                FillGrid(parentId, code, name);
            }
            catch
            {
                throw;
            }

        }
        private void FillGrid(Guid parentId, string code, string name)
        {
            if (Level <= 3)
            {
                grdList.ItemsSource = Business.GetMoeinStructureDefineBusiness().GetByParentID(parentId).ToList();
            }
            if (Level == 4)
            {
                Moein = Business.GetMoeinStructureDefineBusiness().GetByID(parentId).FirstOrDefault();

                Data.AccountingMoeinStructureDefine Tafsil1 = Business.GetMoeinStructureDefineBusiness()
                    .GetTafsil(Moein.ID, Constants.CodeTitle.Tafsil1).FirstOrDefault();
                if (Tafsil1 == null)
                {
                    grdList.ItemsSource = null;
                    LabelList.Add(new LabelValues() { code = code, codeTitle = parentId.ToGUID(), value = name });
                    AddLabel(LabelList[depth]);
                    return;
                }
                List<Data.AccountingTafsilStructureDefine> TafsilList = new List<Data.AccountingTafsilStructureDefine>();
                foreach (var item in Business.GetAccountingMoeinTafsilRelationBussiness().GetByMoeinID(Tafsil1.ID))
                {
                    TafsilList.Add(Business.GetTafsilStructureDefineBusiness().GetByID(item.AccountingTafsil_ID).FirstOrDefault());
                }
                grdList.ItemsSource = TafsilList;
            }
            else if (Level == 5)
            {
                Data.AccountingMoeinStructureDefine Tafsil2 = Business.GetMoeinStructureDefineBusiness()
                    .GetTafsil(Moein.ID, Constants.CodeTitle.Tafsil2).FirstOrDefault();

                if (Tafsil2 == null)
                {
                    grdList.ItemsSource = null;
                    LabelList.Add(new LabelValues() { code = code, codeTitle = parentId.ToGUID(), value = name });
                    AddLabel(LabelList[depth]);
                    return;
                }
                List<Data.AccountingTafsilStructureDefine> TafsilList = new List<Data.AccountingTafsilStructureDefine>();

                foreach (var item in Business.GetAccountingMoeinTafsilRelationBussiness().GetByMoeinID(Tafsil2.ID))
                {
                    TafsilList.Add(Business.GetTafsilStructureDefineBusiness().GetByID(item.AccountingTafsil_ID).FirstOrDefault());
                }
                grdList.ItemsSource = TafsilList;
            }
            else if (Level == 6)
            {
                Data.AccountingMoeinStructureDefine Tafsil3 = Business.GetMoeinStructureDefineBusiness()
                    .GetTafsil(Moein.ID, Constants.CodeTitle.Tafsil3).FirstOrDefault();

                if (Tafsil3 == null)
                {
                    grdList.ItemsSource = null;
                    LabelList.Add(new LabelValues() { code = code, codeTitle = parentId.ToGUID(), value = name });
                    AddLabel(LabelList[depth]);
                    return;
                }
                List<Data.AccountingTafsilStructureDefine> TafsilList = new List<Data.AccountingTafsilStructureDefine>();

                foreach (var item in Business.GetAccountingMoeinTafsilRelationBussiness().GetByMoeinID(Tafsil3.ID))
                {
                    TafsilList.Add(Business.GetTafsilStructureDefineBusiness().GetByID(item.AccountingTafsil_ID).FirstOrDefault());
                }
                grdList.ItemsSource = TafsilList;
            }

            LabelList.Add(new LabelValues() { code = code, codeTitle = parentId.ToGUID(), value = name });
            AddLabel(LabelList[depth]);
        }
        private void AddLabel(LabelValues labellsit)
        {
            try
            {
                var label = new Label();
                label.Content = labellsit.value;
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

            int index = -1;
            foreach (var item in LabelList)
            {
                index++;
                if (item.label == sender as Label)
                {
                    for (int i = LabelList.Count - 1; i >= index; i--)
                    {
                        LabelList.RemoveAt(i);

                    }
                    Level = 1;
                    break;
                }
            }

            canvas.Children.Clear();
            ResetLablePosition();


            foreach (var item in LabelList)
            {
                AddLabel(item);
                Level++;
            }

            if (LabelList.LastOrDefault() == null)
            {
                grdList.ItemsSource = Business.GetMoeinStructureDefineBusiness().GetAll().Where(r => r.Type == Goruh)
                .Select(r => new { ID = r.ID, Code = r.Code, Name = r.Name, Type = r.Type }).ToList();
                Level = 1;
            }
            else
            {
                FillGrid(LabelList.LastOrDefault().codeTitle, LabelList.LastOrDefault().code, LabelList.LastOrDefault().value);
                depth--;
                canvas.Children.RemoveAt(Level - 1);
                LabelList.Remove(LabelList.LastOrDefault());
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (Level < 4)
            {
                MessageBox.Show("گروه فرعی را انتخاب کنید");
                return;
            }
            FormClose();
        }

        private void FormClose()
        {
            foreach (var item in LabelList)
            {
                AccountingName = string.Format("{0}/{1}", AccountingName, item.value);
            }
            this.Close();
        }

        public string AccountingName;

    }
}
