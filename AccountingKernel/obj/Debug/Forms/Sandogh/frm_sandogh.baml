   M S B A M L   `   `   `  ����  AccountingKernel0    *AccountingKernel.Forms.Sandogh.frm_sandogh   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  frm_sandogh��5   	   $	��600��6   $	��800��6*   $��RightToLeft=�66      WindowStyle#���   6R    � WindowStartupLocation$ CenterScreen=�6x   .��5      � .+�5   
   �� -   5         ��Name$ BtnPrint��5       � ToolTip$ چاپ��6#   $��35��61   $��	0,10,10,0q�6>   $	��Top=�6Q   $��Right=�6i   $��35��6�   ��5      �� 5	       �� ImageSource$7 1/AccountingKernel;component/Themes/icon/Print.png��6   5      �� 5   
   -   5        $ BtnExel��5      $ اکسل��6"   $��35��61   $��	0,10,50,0q�6>   $	��Top=�6Q   $��Right=�6i   $��35��6�   ���	#FF7A7878
���   ���5      �� 5      $7 1/AccountingKernel;component/Themes/icon/Excel.png��6   5      �� 5   
   -   5        $ BtnDel��5      $ حذف��6!   $��35��6/   $��	0,10,90,0q�6<   $	��Top=�6O   $��Right=�6g   $��35��6�   ��5      �� 5      $8 2/AccountingKernel;component/Themes/icon/delete.png��6   5      �� 5   
   -   5        $ BtnEdit��5      $ ویرایش��6"   $��35��63   $��
0,10,130,0q�6?   $	��Top=�6S   $��Right=�6k   $��35��6�   ��5      �� 5      $6 0/AccountingKernel;component/Themes/icon/Edit.png��6   5      �� 5   
   -   5        $ BtnNew��5      $ جدید��6!   $��35��60   $��
0,10,170,0q�6=   $	��Top=�6Q   $��Right=�6i   $��35��6�   
���   ����	#FF7E7E7E��5      �� 5      $5 //AccountingKernel;component/Themes/icon/New.png��6   5      &   System.Windows.Controls.DataGrid  5    
   -   5          Name$ grid_sandogh��5         DataGridStyle#��[ 6)   $��
10,51,10,9q�6P      AutoGenerateColumns .     CanUserAddRows .   � ContextMenu 5!      �� 5"      .@�5#      m� -   5        $��جدید��5#      6-   m� 5$      -   5        $��ویرایش��5$      6/   5%      	   Columns	 5'      0  *System.Windows.Controls.DataGridTextColumn  5(      ,  &System.Windows.Controls.DataGridColumn
   Header$
 
شناسه��6%      
IsReadOnly .    
Visibility$ Hidden=�6F   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6Z   ��  �� Path$ Id�  5)      $
 نام��6%    .  6E   �� $ FName�  5*      $
 مبلغ��6%    .  6E   �� $ Fprice�5,      �� 5-   
   -	   5         ��Name$ 
txt_search��5-        TextBoxStyle#��[ 6&   $��73,10,213,0q�6L    �� TextWrapping$
 Wrap=�6a   $	��Top=�6u   6�   �� 5.   
   $��
جستجو��6   $
��Left=�6    $��	10,10,0,0q�6;   $	��Top=�6N     
LabelStyle#��[ 6f   $��50��6�   5/      50      