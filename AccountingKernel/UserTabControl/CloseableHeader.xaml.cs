using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;



/// <summary>
/// Interaction logic for CloseableItem.xaml
/// </summary>
public partial class CloseableHeader : UserControl
{

    public CloseableHeader()
    {
        InitializeComponent();
    }

    private void button_close_Click(object sender, RoutedEventArgs e)
    {
       // MessageBox.Show( AccountingKernel.Class.Variable.check_for_tab_names.get_tab_names);

       // Class.Variable.check_for_tab_names.get_tab_names += Localize.AssetGood;

       AccountingKernel.Class.Variable.check_for_tab_names.get_tab_names = 
           AccountingKernel.Class.Variable.check_for_tab_names.get_tab_names.Replace(label_TabTitle.Content.ToString(), "");
      //  MessageBox.Show(AccountingKernel.Class.Variable.check_for_tab_names.get_tab_names);
       
    }



}

