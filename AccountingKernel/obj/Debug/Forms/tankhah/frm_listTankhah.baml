   M S B A M L   `   `   `  ����  AccountingKernel4    .AccountingKernel.Forms.tankhah.frm_listTankhah   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  frm_listTankhah��5   	   $	��600��6!   $	��800��6.   $��RightToLeft=�6]      WindowStyle#���   6y   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��287* �6   �� 5      $
��505* �6   .+�5
   
   �� -   5         ��Name$ 
txt_search��5
        TextBoxStyle#��[ 6&   $��65,10,211,0q�6L    �� TextWrapping$
 Wrap=�6a   $	��Top=�6u   $��2��6�   �� 5   
   $��
جستجو��6   $
��Left=�6    $��	10,10,0,0q�6;   $	��Top=�6N   $��50��6f     
LabelStyle#��[ 6q   �� 5   
   -   5         ��Name$ BtnPrint��5       � ToolTip$ چاپ��6#   $��35��61   $��	0,10,10,0q�6>   $	��Top=�6Q   $��Right=�6i   $��35��6�   $��1��6�   ��5      �� 5       �� ImageSource$7 1/AccountingKernel;component/Themes/icon/Print.png��6   5      �� 5   
   -   5        $ BtnExel��5      $ اکسل��6"   $��35��61   $��	0,10,50,0q�6>   $	��Top=�6Q   $��Right=�6i   $��35��6�   ���	#FF7A7878
���   �$��1��6�   ��5      �� 5      $7 1/AccountingKernel;component/Themes/icon/Excel.png��6   5      �� 5   
   -   5        $ BtnDel��5      $ حذف��6!   $��35��6/   $��	0,10,91,0q�6<   $	��Top=�6O   $��Right=�6g   $��35��6�   $��1��6�   ��5      �� 5      $8 2/AccountingKernel;component/Themes/icon/delete.png��6   5      �� 5   
   -   5        $ BtnEdit��5      $ ویرایش��6"   $��35��63   $��
0,10,131,0q�6?   $	��Top=�6S   $��Right=�6k   $��35��6�   $��1��6�   ��5      �� 5      $6 0/AccountingKernel;component/Themes/icon/Edit.png��6   5      �� 5    
   -   5        $ BtnNew��5       $ جدید��6!   $��35��60   $��
0,10,171,0q�6=   $	��Top=�6Q   $��Right=�6i   $��35��6�   
���   ����	#FF7E7E7E$��1��6�   ��5!      �� 5"      $5 //AccountingKernel;component/Themes/icon/New.png��6   5$      &   System.Windows.Controls.DataGrid  5%   
   -   5          Name$ grd_tankhah��5%      $��RightToLeft=�6(     DataGridStyle#��[ 6D   $��10,50,10,98q�6k      AutoGenerateColumns .  $��2��6�   	   Columns	 5&      0  *System.Windows.Controls.DataGridTextColumn  5(      ,  &System.Windows.Controls.DataGridColumn
   Header$
 
شماره��6B      
IsReadOnly .  1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   ��  �� Path$	 CNO�6Q     5)      $
 
تاریخ��6D    .   6%   �� $ CDate�6S     5+      $
 مبلغ��6J    .   6%   �� $ CTotalPrice�6X    � ContextMenu 5.      �� 5/      .@�50      m� -	   5        $��mnu_reg��50      $��جدید��6.   6<   m� 51      -
   5        $��mnu_edit��51      $��ویرایش��6/   6?   m� 52      -   5        $��
mnu_remove��52      $��حذف��61   6>   54      5;      5=      5>      