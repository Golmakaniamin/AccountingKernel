   M S B A M L   `   `   `  ����a  ]Stimulsoft.Report.Wpf, Version=2010.1.700.0, Culture=neutral, PublicKeyToken=ebe6666cba19647a�Uclr-namespace:Stimulsoft.Report.Wpf.XamlImages.ToolBox;assembly=Stimulsoft.Report.Wpf(Stimulsoft.Report.Wpf.XamlImages.ToolBox  5   	    AccountingKernel1   +AccountingKernel.Forms.baseInfo.FrmBaseInfo   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   iToolBoxUclr-namespace:Stimulsoft.Report.Wpf.XamlImages.ToolBox;assembly=Stimulsoft.Report.Wpf     5   	     � Title$   ��5   	   $	��600��6   $	��800��6      WindowStyle#���   6+    � WindowStartupLocation$ CenterScreen=�6Q   $��RightToLeft=�6v   .��5      � .+�5   
   �� $��
جستجو��6   $
��Left=�6    $��35��6;   $��	10,10,0,0q�6G   $	��Top=�6Z   $��50��6r     
LabelStyle#��[ 6}   �� 5   
   -   5         ��Name$ 	txtSearch��5   .   $��RightToLeft=�6     TextBoxStyle#��[ 6A   $��65,10,210,0q�6g    �� TextWrapping$
 Wrap=�6|   $	��Top=�6�   6�   �� 5	   
   -   5         ��Name$ BtnPrint��5	       � ToolTip$ چاپ��6#   $��35��61   $��	0,10,10,0q�6>   $	��Top=�6Q   $��Right=�6i   $��35��6�   ��5
      �� 5       �� ImageSource$7 1/AccountingKernel;component/Themes/icon/Print.png��6   5      �� 5   
   -   5        $ BtnExel��5      $ اکسل��6"   $��35��61   $��	0,10,50,0q�6>   $	��Top=�6Q   $��Right=�6i   $��35��6�   ���	#FF7A7878
���   ���5      �� 5      $7 1/AccountingKernel;component/Themes/icon/Excel.png��6   5      �� 5   
   -   5        $ BtnDel��5      $ حذف��6!   $��35��6/   $��	0,10,90,0q�6<   $	��Top=�6O   $��Right=�6g   $��35��6�   ��5      �� 5      $8 2/AccountingKernel;component/Themes/icon/delete.png��6   5      �� 5   
   -   5        $ BtnEdit��5      $ ویرایش��6"   $��35��63   $��
0,10,130,0q�6?   $	��Top=�6S   $��Right=�6k   $��35��6�   ��5      �� 5      $6 0/AccountingKernel;component/Themes/icon/Edit.png��6   5      �� 5   
   -   5        $ BtnNew��5      $ جدید��6!   $��35��60   $��
0,10,170,0q�6=   $	��Top=�6Q   $��Right=�6i   $��35��6�   
���   ����	#FF7E7E7E��5      �� 5      $5 //AccountingKernel;component/Themes/icon/New.png��6   5!      &   System.Windows.Controls.DataGrid  5"   
   -   5          Name$ grdBaseInfo��5"      $��10,50q�6(      AutoGenerateColumns .    DataGridStyle#��[ 6S   	 � ContextMenu	 5#      �� 5$      .@�5%      m� -   5        $��جدید��5%      6-   m� 5&      -	   5        $��ویرایش��5&      6/   5'      
   Columns
 5)      0  *System.Windows.Controls.DataGridTextColumn  5*      ,  &System.Windows.Controls.DataGridColumn   Header$ نام��6D      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *
AssignName+6Q   5,      �� 5-   
   -
   5        $��انتخاب��5-      $��10,555,10,10q�6"     ButtonStyleRD#��[ 6M   5.      5/      