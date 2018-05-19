using AccountingKernel.CLass;
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
using Common;
using System.Data;
using System.Transactions;

namespace AccountingKernel.Forms.Document
{
    /// <summary>
    /// Interaction logic for Document.xaml
    /// </summary>
    public partial class frmB : Window
    {
        public class LabelValues
        {
            public Guid codeTitle;
            public string value;
            //public Label label;
            public string code;

        }


        public List<LabelValues> Labels;
        int top, left, width, height;
        int _depth;
        int depth
        {
            set
            {
                _depth = value;
            }
            get
            {
                return _depth;
            }
        }
        Guid? codeTitleId;
        Guid? SatheTafsil;

        public string AccountingCode
        {
            get
            {
                var value = string.Empty;
                if (!Labels.Any())
                    return value;

                for (int i = 0; i < Labels.Count; i++)
                    value = string.Format("{0}/{1}", value, Labels[i].value);
                return value.Remove(0, 1);

            }
        }
        public frmB(List<LabelValues> labels)
        {
            try
            {
                InitializeComponent();

                codeTitleId = Constants.CodeTitle.Goruh;
                string code = null;
                if (labels != null && labels.Any())
                {
                    this.Labels = labels;
                    code = Labels[Labels.Count - 1].code;
                }
                else
                    Labels = new List<LabelValues>();

                var items = new List<string>();
                foreach (var item in Labels)
                    items.Add(item.value);


                NavBar.ItemsList = items;
                switch (Labels.Count())
                {
                    case 0:
                    case 1:
                        codeTitleId = Constants.CodeTitle.Goruh;
                        break;
                    case 2:
                        codeTitleId = Constants.CodeTitle.Kol;
                        break;
                    case 3:
                        codeTitleId = Constants.CodeTitle.Moein;
                        break;
                    case 4:
                        codeTitleId = Constants.CodeTitle.Tafsil1;
                        break;
                    case 5:
                        codeTitleId = Constants.CodeTitle.Tafsil2;
                        break;
                    default:
                    case 6:
                        codeTitleId = Constants.CodeTitle.Tafsil3;
                        break;
                }
                top = 0;
                left = 0;
                width = 100;
                height = 50;
                depth = Labels.Count;


                SetDataGrid(code);

                SetBtnOkIsEnabled();

            }
            catch
            {

                throw;
            }

        }

        private void SetDataGrid(string code)
        {
            try
            {
                if (codeTitleId == Constants.CodeTitle.Goruh)
                {
                    DataGridTest.ItemsSource = Business.GetAccountingMoeinDetailBusiness().GetByIdCodeTitle(Constants.CodeTitle.Goruh)
                        .Select(r => new { IdIn = r.IdIn, Name = r.MDName }).Distinct().OrderBy(r => r.IdIn).ToList();
                }
                else if (codeTitleId == Constants.CodeTitle.Kol)
                {
                    DataGridTest.ItemsSource = Business.GetAccountingMoeinDetailBusiness().GetKolsByGroupsCode(code)
                        .Select(r => new { IdIn = r.IdIn, Name = r.MDName }).Distinct().OrderBy(r => r.IdIn).ToList();
                }
                else if (codeTitleId == Constants.CodeTitle.Moein)
                {
                    DataGridTest.ItemsSource = Business.GetAccountingMoeinDetailBusiness().GetMoeinsByKolCode(Labels[0].code, Labels[1].code)
                        .Select(r => new { IdIn = r.IdIn, Name = r.MDName }).Distinct().OrderBy(r => r.IdIn).ToList();
                }
                else if (codeTitleId == Constants.CodeTitle.GoruheTafsili)
                {
                    var tCode = Labels[0].code + Labels[1].code + Labels[2].code;

                    var accountingMoein = Business.GetAccountingMoeinBusiness().GetByMIdMoein(tCode);

                    var satheTafsil = SatheTafsil;
                    if (satheTafsil == null)
                        satheTafsil = Common.Constants.CodeTitle.Tafsil1;

                    var accountingMoeinTafsilLevels = Business.GetAccountingMoeinTafsilLevelBusiness().GetByIdAccountingMoein(accountingMoein.Id, satheTafsil.Value);

                    var accountingTafsillevelsDetails = Business.GetAccountingTafsilLevelDetailBusiness().GetHesabTafsilByAccountingTafsilLevelsId(
                        accountingMoeinTafsilLevels.Select(r => r.IdAccountingTafsilLevels.Value).ToList());

                    DataGridTest.ItemsSource = accountingTafsillevelsDetails.Select(r => new { IdIn = r.IdIn, Name = r.ATLName }).Distinct().OrderBy(r => r.IdIn).ToList();
                }

            }
            catch
            {

                throw;
            }
        }

        private void SetBtnOkIsEnabled()
        {
            try
            {
                btn_ok.IsEnabled = depth >= 3;

            }
            catch
            {

                throw;
            }
        }

        private void AddLabel(LabelValues labelValue)
        {
            try
            {
                //var label = new Label();
                //label.Content = labelValue.value;
                //label.Width = width;
                //label.Height = height;
                //label.Margin = new Thickness(left + depth * width, top, left + label.Width + depth * width, top + label.Height);
                //labelValue.label = label;
                depth++;

                var T = new List<string>();
                foreach (var item in this.NavBar.ItemsList)
                {
                    T.Add(item);
                }

                T.Add(labelValue.value);

                this.NavBar.ItemsList = T;

                //this.NavBar.ItemsList.Add(label.Content.ToString());
                //canvas.Children.Add(label);

            }
            catch
            {

                throw;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
            }
            catch
            {

                throw;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (btn_ok.IsEnabled)
                    return;

                Labels.Clear();
            }
            catch
            {

                throw;
            }
        }

        private void DataGridTest_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (DataGridTest.SelectedValue == null)
                    return;

                string idIn = (DataGridTest.SelectedValue as dynamic).IdIn;
                string name = (DataGridTest.SelectedValue as dynamic).Name;

                if (codeTitleId == Constants.CodeTitle.Goruh || codeTitleId == Constants.CodeTitle.Kol || codeTitleId == Constants.CodeTitle.Moein)
                {
                    if (Labels.Count > depth)
                        Labels.RemoveAt(depth);
                    Labels.Add(new LabelValues() { code = idIn, codeTitle = codeTitleId.Value, value = name });

                    AddLabel(Labels[depth]);
                }

                //if (codeTitleId == Constants.CodeTitle.Moein)
                //    MoeinId = Business.GetAccountingMoeinDetailBusiness().GetById(id).IdAccountingMoein.Value;

                var codeTitles = Business.GetCodeTitleBusiness().GetAll().ToList();

                if (codeTitleId != Common.Constants.CodeTitle.GoruheTafsili)
                {
                    var currentCodeTile = codeTitles.Find(r => r.Id == codeTitleId);
                    var groupYek = codeTitles.FindAll(r => r.CodeGroup == (int)Common.Enum.CodeGroup.Yek);
                    codeTitleId = groupYek.FindAll(r => r.CodePriority > currentCodeTile.CodePriority).OrderBy(r => r.CodePriority).First().Id;
                }
                else if (codeTitleId == Common.Constants.CodeTitle.GoruheTafsili)
                {
                    var groupDO = codeTitles.FindAll(r => r.CodeGroup == (int)Common.Enum.CodeGroup.Do);

                    if (SatheTafsil == null)
                        SatheTafsil = Common.Constants.CodeTitle.Tafsil1;


                    if (Labels.Count > depth)
                        Labels.RemoveAt(depth);
                    Labels.Add(new LabelValues() { code = idIn, codeTitle = SatheTafsil.Value, value = name });

                    AddLabel(Labels[depth]);
                    //id = MoeinId;

                    ////
                    var currentSatheTafsil = groupDO.Find(r => r.Id == SatheTafsil);

                    var t = groupDO.FindAll(r => r.CodePriority > currentSatheTafsil.CodePriority).OrderBy(r => r.CodePriority).FirstOrDefault();

                    if (t != null)
                        SatheTafsil = t.Id;
                    else
                    {
                        DataGridTest.ItemsSource = null;
                        return;
                    }

                    SetDataGrid(idIn);
                    SetBtnOkIsEnabled();

                }

                if (SatheTafsil == null)
                {
                    SetDataGrid(idIn);
                    SetBtnOkIsEnabled();
                }

            }
            catch
            {

                throw;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.NavBar.listBox.MouseDoubleClick += new MouseButtonEventHandler(listBox_MouseDoubleClick);

        }

        private void listBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var index = ((System.Windows.Controls.ListBox)sender).SelectedIndex;


                if (index >= 3)
                {
                    codeTitleId = Constants.CodeTitle.GoruheTafsili;
                    SatheTafsil = Labels[index].codeTitle;
                }
                else
                {
                    codeTitleId = Labels[index].codeTitle;
                    SatheTafsil = null;
                }

                var codeTitle = Business.GetCodeTitleBusiness().GetById(Labels[index].codeTitle);
                var codeGroups = new List<int>() { 1, 2 };
                var coCodeTitles = Business.GetCodeTitleBusiness().GetByCodeGroups(codeGroups).Where(r => r.CodePriority >= codeTitle.CodePriority).ToList();

                var removingItems = new List<string>();

                foreach (var item in coCodeTitles)
                {
                    var entity = Labels.FirstOrDefault(r => r.codeTitle == item.Id);
                    if (entity == null)
                        continue;

                    removingItems.Add(entity.value);

                    //canvas.Children.Remove(entity.label);

                    Labels.Remove(entity);

                    depth--;
                }

                this.NavBar.ItemsList = NavBar.ItemsList.Except(removingItems).ToList();

                SetBtnOkIsEnabled();
                var code = string.Empty;
                if (index > 0)
                    code = Labels[index - 1].code;
                SetDataGrid(code);
            }
            catch
            {

                throw;
            }
        }



    }
}
