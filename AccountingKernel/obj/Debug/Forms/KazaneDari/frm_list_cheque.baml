   M S B A M L   `   `   `  ����  AccountingKernel7    1AccountingKernel.Forms.KazaneDari.frm_list_cheque   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  frm_list_cheque��5   	      WindowStyle#���   6!   $	��600��6G   $	��800��6T    � WindowStartupLocation$ CenterScreen=�6`   $��RightToLeft=�6�   .��5      � .+�5   
   �� $��
جستجو��6     
LabelStyle#��[ 6    $
��Left=�6D   $��35��6_   $��	10,10,0,0q�6k   $	��Top=�6~   $��50��6�   �� 5   
   -   5         ��Name$ 
txt_search��5        TextBoxStyle#��[ 6&   $��35��6L   $��65,10,213,0q�6X    �� TextWrapping$
 Wrap=�6m   $	��Top=�6�   6�   �� 5   
   -   5         ��Name$ BtnPrint��5       � ToolTip$ چاپ��6#   $��35��61   $��	0,10,10,0q�6>   $	��Top=�6Q   $��Right=�6i   $��35��6�   ��5	      �� 5
       �� ImageSource$7 1/AccountingKernel;component/Themes/icon/Print.png��6   5      �� 5   
   -   5        $ BtnExel��5      $ اکسل��6"   $��35��61   $��	0,10,50,0q�6>   $	��Top=�6Q   $��Right=�6i   $��35��6�   ���	#FF7A7878
���   ���5      �� 5      $7 1/AccountingKernel;component/Themes/icon/Excel.png��6   5      �� 5   
   -   5        $ BtnDel��5      $ حذف��6!   $��35��6/   $��	0,10,90,0q�6<   $	��Top=�6O   $��Right=�6g   $��35��6�   ��5      �� 5      $8 2/AccountingKernel;component/Themes/icon/delete.png��6   5      �� 5   
   -   5        $ BtnEdit��5      $ ویرایش��6"   $��35��63   $��
0,10,130,0q�6?   $	��Top=�6S   $��Right=�6k   $��35��6�   ��5      �� 5      $6 0/AccountingKernel;component/Themes/icon/Edit.png��6   5      �� 5   
   -   5        $ BtnNew��5      $ جدید��6!   $��35��60   $��
0,10,170,0q�6=   $	��Top=�6Q   $��Right=�6i   $��35��6�   
���   ����	#FF7E7E7E��5      �� 5      $5 //AccountingKernel;component/Themes/icon/New.png��6   5       &   System.Windows.Controls.DataGrid  5!   
   -   5          Name$ grid_cheque��5!        DataGridStyle#��[ 6(   $��10,50,10,64q�6O      AutoGenerateColumns .  	   Columns	 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      ,  &System.Windows.Controls.DataGridColumn
   Header$
 شماره چک��6C      
IsReadOnly .  1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   ��  �� Path$	 CNO�6U     5$      $
 شماره حساب��6M    .   6%   �� $ CAccountnumber�6a     5%      $
 مبلغ��6E    .   6%   �� $ CPrice�6S     5&      $
 بابت��6K    .   6%   �� $ CDescription�6Y     5'      $
 
تاریخ��6D    .   6%   �� $ CDate�6S     5(      $
 نام صاحب چک��6D    .   6%   �� $ CName�6Y    � ContextMenu 5*      �� 5+      .@�5,      m� -	   5        $��mnu_reg��5,      $��جدید��6.   6<   m� 5-      -
   5        $��mnu_edit��5-      $��ویرایش��6/   6?   m� 5.      -   5        $��
mnu_remove��5.      $��حذف��61   6>   5/      51      �� 52   
   -   5        $ btn_Geteport��52   �   $��گزارش گیری��6   $
��Left=�6&   $��
654,50,0,0q�6A   $	��Top=�6U   $	��136��6m    J� RenderTransformOrigin$ 0.5,0.5&�6y   $��43��6�   6�   54      55      