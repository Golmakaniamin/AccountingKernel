   M S B A M L   `   `   `  ����  AccountingKernel8    2AccountingKernel.Forms.KazaneDari.frm_list_daryaft   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  frm_list_daryaft��5   	   $	��600��6"      WindowStyle#���   6/   $	��800��6U    � WindowStartupLocation$ CenterScreen=�6a   $
��Bold"�6�   $��RightToLeft=�6�   .��5      � .+�5   
   �� $��
جستجو��6     
LabelStyle#��[ 6    $
��Left=�6D   $��	10,10,0,0q�6_   $	��Top=�6r   $��50��6�   �� 5   
   -   5         ��Name$ 
txt_search��5        TextBoxStyle#��[ 6&   $��65,10,213,0q�6L    �� TextWrapping$
 Wrap=�6a   $	��Top=�6u   6�   �� 5   
   -   5         ��Name$ BtnPrint��5       � ToolTip$ چاپ��6#   $��35��61   $��	0,10,10,0q�6>   $	��Top=�6Q   $��Right=�6i   $��35��6�   ��5	      �� 5
       �� ImageSource$7 1/AccountingKernel;component/Themes/icon/Print.png��6   5      �� 5   
   -   5        $ BtnExel��5      $ اکسل��6"   $��35��61   $��	0,10,50,0q�6>   $	��Top=�6Q   $��Right=�6i   $��35��6�   ���	#FF7A7878
���   ���5      �� 5      $7 1/AccountingKernel;component/Themes/icon/Excel.png��6   5      �� 5   
   -   5        $ BtnDel��5      $ حذف��6!   $��35��6/   $��	0,10,90,0q�6<   $	��Top=�6O   $��Right=�6g   $��35��6�   ��5      �� 5      $8 2/AccountingKernel;component/Themes/icon/delete.png��6   5      �� 5   
   -   5        $ BtnEdit��5      $ ویرایش��6"   $��35��63   $��
0,10,130,0q�6?   $	��Top=�6S   $��Right=�6k   $��35��6�   ��5      �� 5      $6 0/AccountingKernel;component/Themes/icon/Edit.png��6   5      �� 5   
   -   5        $ BtnNew��5      $ جدید��6!   $��35��60   $��
0,10,170,0q�6=   $	��Top=�6Q   $��Right=�6i   $��35��6�   
���   ����	#FF7E7E7E��5      �� 5      $5 //AccountingKernel;component/Themes/icon/New.png��6   5       &   System.Windows.Controls.DataGrid  5!   
   -   5          Name$ 	grdRecive��5!      $��10,50,10,10q�6&      AutoGenerateColumns .    DataGridStyle#��[ 6W   	 � ContextMenu	 5"      �� 5#      .@�5$      m� -   5        $��mnu_reg��5$      $��جدید��6.   6<   m� 5%      -	   5        $��mnu_edit��5%      $��ویرایش��6/   6?   m� 5&      -
   5        $��
mnu_remove��5&      $��حذف��61   6>   5'      
   Columns
 5)      0  *System.Windows.Controls.DataGridTextColumn  5*      ,  &System.Windows.Controls.DataGridColumn   
Visibility$ Hidden=�6A      
IsReadOnly .  1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   ��  �� Path$ ID�6U     5+         Header$
 کد��6B    .   6%   �� $	 TNO�6N     5,      $ 
تاریخ��6D    .   6%   �� $ TDate�6S     5-      $ مبلغ��6E    .   6%   �� $ TPrice�6S   5/      50      51      