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

namespace AccountingKernel.Forms.Sandogh
{
    /// <summary>
    /// Interaction logic for frm_tarifeSandogh.xaml
    /// </summary>
    public partial class frm_tarifeSandogh : Window
    {
        public frm_tarifeSandogh()
        {
            InitializeComponent();
        }

        private void TextBox_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        {
            Class.UI.TextHandeler c = new Class.UI.TextHandeler();
            c.JustPersian(e);
        }
    }
}
