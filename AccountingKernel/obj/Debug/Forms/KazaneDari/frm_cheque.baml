   M S B A M L   `   `   `  ����  AccountingKernel/    )AccountingKernel.Forms.tankhah.frm_cheque   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  
frm_cheque��5   	   $	��600��6   $	��800��6)      WindowStyle#���   6X   $��RightToLeft=�6~   .��5      � .+�5   
   �� $��
جستجو��6     
LabelStyle#��[ 6    $��10,10,740,0q�6D   $	��Top=�6Y   $��50��6q   $��RightToLeft=�6|   �� 5   
   -   5         ��Name$ 	TB_Search��5        TextBoxStyle#��[ 6%   $��65,10,215,0q�6K    �� TextWrapping$
 Wrap=�6`   $	��Top=�6t   6�   �� 5   
   -   5         ��Name$ BtnPrint��5       � ToolTip$ چاپ��6#   $��35��61   $��	0,10,10,0q�6>   $	��Top=�6Q   $��Right=�6i   $��35��6�   ��5	      �� 5
       �� ImageSource$7 1/AccountingKernel;component/Themes/icon/Print.png��6   5      �� 5   
   -   5        $ BtnExel��5      $ اکسل��6"   $��35��61   $��	0,10,50,0q�6>   $	��Top=�6Q   $��Right=�6i   $��35��6�   ���	#FF7A7878
���   ���5      �� 5      $7 1/AccountingKernel;component/Themes/icon/Excel.png��6   5      �� 5   
   -   5        $ BtnDel��5      $ حذف��6!   $��35��6/   $��	0,10,90,0q�6<   $	��Top=�6O   $��Right=�6g   $��35��6�   ��5      �� 5      $8 2/AccountingKernel;component/Themes/icon/delete.png��6   5      �� 5   
   -   5        $ BtnEdit��5      $ ویرایش��6"   $��35��63   $��
0,10,130,0q�6?   $	��Top=�6S   $��Right=�6k   $��35��6�   ��5      �� 5      $6 0/AccountingKernel;component/Themes/icon/Edit.png��6   5      �� 5   
   -   5        $ BtnNew��5      $ جدید��6!   $��35��60   $��
0,10,170,0q�6=   $	��Top=�6Q   $��Right=�6i   $��35��6�   
���   ����	#FF7E7E7E��5      �� 5      $5 //AccountingKernel;component/Themes/icon/New.png��6   5       &   System.Windows.Controls.DataGrid  5!   
   -   5          Name$ 
grd_cheque��5!        DataGridStyle#��[ 6'   $��RightToLeft=�6N   $��
10,50,10,0q�6j   $	��Top=�6~   $	��496��6�      AutoGenerateColumns .     Columns 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      ,  &System.Windows.Controls.DataGridColumn	   Header$	 شماره چک��6B   
   
IsReadOnly
 .  1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   ��  �� Path$	 CNO�6T     5$      $	 سریال چک��6F   
 .   6%   �� $ CSerial�6X     5%      $	 شرح��6K   
 .   6%   �� $ CDescription�6X     5&      $	 مبلغ��6V   
 .   6%   �� $ CPrice� �� StringFormat$ N0��6d    � ContextMenu 5(      �� 5)      .@�5*      m� -	   5        $��mnu_reg��5*      $��جدید��6.   6<   m� 5+      -
   5        $��mnu_edit��5+      $��ویرایش��6/   6?   m� 5,      -   5        $��
mnu_remove��5,      $��حذف��61   6>   5-      5/      �� 50   
   -   5        $"��خروجی برای اکسل��50      $��10,551,10,0q�6+     ButtonStyleRD#��[ 6@   $	��Top=�6g   6   51      52      