   M S B A M L   `   `   `  ����  AccountingKernel4    .AccountingKernel.Forms.Interface.frmInterfaces   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Document��5   	   $	��600��6      WindowStyle#���   6'   $	��800��6M    � WindowStartupLocation$ CenterScreen=�6Y   $��RightToLeft=�6~   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DataGrid��5      $��10q�6%      AutoGenerateColumns .     CanUserAddRows .   DataGridStyle#��[ 6c    � ContextMenu 5      �� 5      .@�5	      m� -   5        $��mnu_reg��5	      $��جدید��6.   6<   m� 5
      -   5        $��
mnu_remove��5
      $��حذف��61   6>   5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
شناسه��6%      
IsReadOnly . 	   
Visibility$	 Hidden=�6F   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6Z   ��  �� Path$ Id�  5      $ 
عنوان��6%    . 
 6G   �� $ AIName�  5      $ معین بدهکار��6%    . 
 6L   �� $ AIDebtor_Moein�  5      $$ سطح تفصیل بدهکار��6%    . 
 6Q   �� $ AIDebtor_TafsilLevel�  5      $ معین بستانکار��6%    . 
 6O   �� $ AICreditor_Moein�  5      $( "سطح تفصیل بستانکار��6%    . 
 6T   �� $ AICreditor_TafsilLevel�5      5      5      