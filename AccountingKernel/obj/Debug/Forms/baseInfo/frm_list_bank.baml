   M S B A M L   `   `   `  ����a  ]Stimulsoft.Report.Wpf, Version=2010.1.700.0, Culture=neutral, PublicKeyToken=ebe6666cba19647a�Uclr-namespace:Stimulsoft.Report.Wpf.XamlImages.ToolBox;assembly=Stimulsoft.Report.Wpf(Stimulsoft.Report.Wpf.XamlImages.ToolBox  5   	    AccountingKernel3   -AccountingKernel.Forms.baseInfo.frm_list_bank   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   iToolBoxUclr-namespace:Stimulsoft.Report.Wpf.XamlImages.ToolBox;assembly=Stimulsoft.Report.Wpf     5   	   -   5          � Title$  frm_list_bank��5   	   $	��600��6   $	��800��6,      WindowStyle#���   68    � WindowStartupLocation$ CenterScreen=�6^   $��RightToLeft=�6�   .��5      � .+�5   
   �� $��
جستجو��6   $
��Left=�6    $��35��6;   $��	10,10,0,0q�6G   $	��Top=�6Z   $��66��6r     
LabelStyle#��[ 6}   �� 5   
   -   5         ��Name$ 	txtSearch��5      $��RightToLeft=�6%     TextBoxStyle#��[ 6A   $��81,10,210,0q�6g    �� TextWrapping$
 Wrap=�6|   $	��Top=�6�   6�   �� 5
   
   -   5         ��Name$ BtnPrint��5
       � ToolTip$ چاپ��6#   $��35��61   $��	0,10,10,0q�6>   $	��Top=�6Q   $��Right=�6i   $��35��6�   ��5      �� 5       �� ImageSource$7 1/AccountingKernel;component/Themes/icon/Print.png��6   5      �� 5   
   -   5        $ BtnExel��5      $ اکسل��6"   $��35��61   $��	0,10,50,0q�6>   $	��Top=�6Q   $��Right=�6i   $��35��6�   ���	#FF7A7878
���   ���5      �� 5      $7 1/AccountingKernel;component/Themes/icon/Excel.png��6   5      �� 5   
   -   5        $ BtnDel��5      $ حذف��6!   $��35��6/   $��	0,10,90,0q�6<   $	��Top=�6O   $��Right=�6g   $��35��6�   ��5      �� 5      $8 2/AccountingKernel;component/Themes/icon/delete.png��6   5      �� 5   
   -   5        $ BtnEdit��5      $ ویرایش��6"   $��35��63   $��
0,10,130,0q�6?   $	��Top=�6S   $��Right=�6k   $��35��6�   ��5      �� 5      $6 0/AccountingKernel;component/Themes/icon/Edit.png��6   5      �� 5   
   -   5        $ BtnNew��5      $ جدید��6!   $��35��60   $��
0,10,170,0q�6=   $	��Top=�6Q   $��Right=�6i   $��35��6�   
���   ����	#FF7E7E7E��5      �� 5       $5 //AccountingKernel;component/Themes/icon/New.png��6   5"      &   System.Windows.Controls.DataGrid  5#   
   -   5          Name$ grid_listeBank��5#      $��10,50,10,10q�6+     DataGridStyle#��[ 6�      AutoGenerateColumns .  	   Columns	 5$      0  *System.Windows.Controls.DataGridTextColumn  5%      ,  &System.Windows.Controls.DataGridColumn
   
IsReadOnly
 .     
Visibility$ Hidden=�6O   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *ID+6O     5&         Header$ نام صاحب حساب��6?   
 .   6%   �� *FName+6V     5'      $ بانک��6?   
 .   6%   �� *FBank+6M     5(      $ شعبه��6A   
 .   6%   �� *	Fbranch+6O     5)      $ 
نشانی��6B   
 .   6%   �� *
FAddress+6Q     5*      $ موجودی��6Q   
 .   6%   �� *Fprice+ �� StringFormat$ N0��6a    � ContextMenu 5,      �� 5-      .@�5.      m� -	   5         m�Name$ mnu_reg��5.      $��جدید��60   6>   m� 5/      -
   5        $ mnu_edit��5/      $��ویرایش��61   6A   m� 50      -   5        $ 
mnu_remove��50      $��حذف��63   6@   m� 51      -   5        $ 
mnu_cheque��51      $��تعریف چک��63   6E   52      54      55      56      