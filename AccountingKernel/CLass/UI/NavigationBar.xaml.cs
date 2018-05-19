using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AccountigKernel.Class.UI
{
    /// <summary>
    /// Interaction logic for NavigationBar.xaml
    /// </summary>
    public partial class NavigationBar : UserControl
    {
        public List<string> itemsList = new List<string>();
        public List<string> ItemsList
        {
            set
            {
                itemsList = value;
                this.listBox.ItemsSource = itemsList;
            }
            get
            {
                return itemsList;
            }
        }

        public NavigationBar()
        {
            InitializeComponent();
        }



    }
}
