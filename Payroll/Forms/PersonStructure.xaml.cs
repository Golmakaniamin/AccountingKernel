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
namespace AccountingKernel
{
    /// <summary>
    /// Interaction logic for PersonStructure.xaml
    /// </summary>
    public partial class PersonStructure : Window
    {
        string[,] ss;
        int cc; 

        public PersonStructure()
        {
            InitializeComponent();
            LoadGrid();

        }

        private void LoadGrid()
        {

            try
            {
                var parents = Business.GetPersonStructureDefineChildBusiness().GetAll().Where(r => r.Type == Common.Constants.CodeTitle.PersonPrimeryGroup);
                var children = Business.GetPersonStructureDefineChildBusiness().GetAll().Where(r => r.Type == Common.Constants.CodeTitle.PersonSecendryGroup);

                var jresult =
                    parents.GroupJoin(children, Parent => Parent.ID, Child => Child.Parent_ID,
                                                    (Parent, Children) => new
                                                    {
                                                        Id = Parent.ID,
                                                        ParentName = Parent.Name,
                                                        Children = Children.DefaultIfEmpty()
                                                    })
                                        .SelectMany(
                                            x =>
                                            x.Children.Select(
                                                Child => new
                                                {
                                                    Id = Child.ID == null ? Guid.Empty : Child.ID,
                                                    ParentName = x.ParentName,
                                                    ChildName = Child == null ? "" : Child.Name,
                                                    ChildCode = Child == null ? "" : Child.Code
                                                })).ToList();

                ListCollectionView data = new ListCollectionView(jresult);
                data.GroupDescriptions.Add(new PropertyGroupDescription("ParentName"));
                grdLoanInsurance.ItemsSource = data;
            }
            catch
            {

                throw;
            }

        }

        private void GridDelete_Click(object sender, RoutedEventArgs e)
        {
            if (grdLoanInsurance.SelectedValue == null)
                //throw new Exception(Localize.ex_no_record_selected);
                throw new Exception();

            //var msgResult =  MessageBox.Show(Localize.DeleteRecordMessage, Localize.DeleteRecordCaption, MessageBoxButton.YesNo, MessageBoxImage.Question);
            var msgResult = MessageBox.Show("error", "delete", MessageBoxButton.YesNoCancel);
            if (msgResult != MessageBoxResult.Yes)
                return;

            Guid ID = (grdLoanInsurance.SelectedValue as dynamic).Id;

            var DeletedItem = Business.GetPersonStructureDefineChildBusiness().GetByID(ID).FirstOrDefault();

            Business.GetPersonStructureDefineChildBusiness().Delete(DeletedItem);

            LoadGrid();
        }

        private void GridNew_Click(object sender, RoutedEventArgs e)
        {
            new PersonStructureDefineChild().ShowDialog();
            LoadGrid();
        }

        private void GridLoadDetail_Click(object sender, RoutedEventArgs e)
        {
            if (grdLoanInsurance.SelectedValue == null)
                //throw new Exception(Localize.ex_no_record_selected);
                throw new Exception();
            Guid ID = (grdLoanInsurance.SelectedValue as dynamic).Id;

            var EditedItem = Business.GetPersonStructureDefineChildBusiness().GetByID(ID).FirstOrDefault();

            new PersonStructureDefineChild(EditedItem).ShowDialog();
            LoadGrid();
        }

        private void BtnExel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            new PersonStructureDefineChild().ShowDialog();
            LoadGrid();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (grdLoanInsurance.SelectedValue == null)
                //throw new Exception(Localize.ex_no_record_selected);
                throw new Exception();
            Guid ID = (grdLoanInsurance.SelectedValue as dynamic).Id;

            var EditedItem = Business.GetPersonStructureDefineChildBusiness().GetByID(ID).FirstOrDefault();

            new PersonStructureDefineChild(EditedItem).ShowDialog();
            LoadGrid();
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            if (grdLoanInsurance.SelectedValue == null)
                //throw new Exception(Localize.ex_no_record_selected);
                throw new Exception();

            //var msgResult =  MessageBox.Show(Localize.DeleteRecordMessage, Localize.DeleteRecordCaption, MessageBoxButton.YesNo, MessageBoxImage.Question);
            var msgResult = MessageBox.Show("error", "delete", MessageBoxButton.YesNoCancel);
            if (msgResult != MessageBoxResult.Yes)
                return;

            Guid ID = (grdLoanInsurance.SelectedValue as dynamic).Id;

            var DeletedItem = Business.GetPersonStructureDefineChildBusiness().GetByID(ID).FirstOrDefault();

            Business.GetPersonStructureDefineChildBusiness().Delete(DeletedItem);

            LoadGrid();
        }
    }
}
