   M S B A M L   `   `   `  ����  AccountingKernelG    AAccountingKernel.Forms.SotoheTafsili.frm_modiriate_hesabe_tafsili   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$"  frm_modiriate_hesabe_tafsili��5   	      WindowStyle#���   6.   $	��600��6T   $	��800��6a    � WindowStartupLocation$ CenterScreen=�6m   $��RightToLeft=�6�   .��5      � .+�5   
   �� -   5         ��Name$ BtnPrint��5       � ToolTip$ چاپ��6#   $��35��61   $��	0,10,10,0q�6>   $	��Top=�6Q   $��Right=�6i   $��35��6�   ��5      �� 5	       �� ImageSource$7 1/AccountingKernel;component/Themes/icon/Print.png��6   5      �� 5   
   -   5        $ BtnExel��5      $ اکسل��6"   $��35��61   $��	0,10,50,0q�6>   $	��Top=�6Q   $��Right=�6i   $��35��6�   ���	#FF7A7878
���   ���5      �� 5      $7 1/AccountingKernel;component/Themes/icon/Excel.png��6   5      �� 5   
   -   5        $ BtnDel��5      $ حذف��6!   $��35��6/   $��	0,10,90,0q�6<   $	��Top=�6O   $��Right=�6g   $��35��6�   ��5      �� 5      $8 2/AccountingKernel;component/Themes/icon/delete.png��6   5      �� 5   
   -   5        $ BtnEdit��5      $ ویرایش��6"   $��35��63   $��
0,10,130,0q�6?   $	��Top=�6S   $��Right=�6k   $��35��6�   ��5      �� 5      $6 0/AccountingKernel;component/Themes/icon/Edit.png��6   5      �� 5   
   -   5        $ BtnNew��5      $ جدید��6!   $��35��60   $��
0,10,170,0q�6=   $	��Top=�6Q   $��Right=�6i   $��35��6�   
���   ����	#FF7E7E7E��5      �� 5      $5 //AccountingKernel;component/Themes/icon/New.png��6   5      &   System.Windows.Controls.DataGrid  5    
   -   5          Name$' !grd_AccountingTafsillevelsDetails��5         DataGridStyle#��[ 6>   $��10,50,10,10q�6e      AutoGenerateColumns .  $��2��6�      Columns 5!      0  *System.Windows.Controls.DataGridTextColumn  5"      ,  &System.Windows.Controls.DataGridColumn   Header$
 کد��6A   	   
IsReadOnly	 .  1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6%   ��  �� Path$ Id�6M     5#      $ نام��6F   	 .  
 6%   �� $ ATLName�6S     5$      $ نام لاتین��6H   	 .  
 6%   �� $ 	ATLNameEn�6[     5%      $
 کد��6C   	 .  
 6%   �� $
 IdIn�6O    � ContextMenu 5(      �� 5)      .@�5*      m� -   5        $��mnu_reg��5*      $��جدید��6.   6<   m� 5+      -   5        $��mnu_edit��5+      $��ویرایش��6/   6?   m� 5,      -	   5        $��
mnu_remove��5,      $��حذف��61   6>   5-      5/      �� 50   
   $��
جستجو��6   $
��Left=�6    $��	10,10,0,0q�6;   $	��Top=�6N   $��50��6f     
LabelStyle#��[ 6q   �� 51   
   -
   5         ��Name$ 
txt_search��51      $��65,10,214,0q�6&    �� TextWrapping$
 Wrap=�6;     TextBoxStyle#��[ 6O   $	��Top=�6u   $��2��6�   52      53      