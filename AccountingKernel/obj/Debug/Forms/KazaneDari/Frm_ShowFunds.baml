   M S B A M L   `   `   `  ����U  QPersianDateControls, Version=1.2.5439.35283, Culture=neutral, PublicKeyToken=nullbDclr-namespace:Arash.PersianDateControls;assembly=PersianDateControlsArash.PersianDateControls  5   	    AccountingKernel5   /AccountingKernel.Forms.KazaneDari.Frm_ShowFunds   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   dPersianDateControlsDclr-namespace:Arash.PersianDateControls;assembly=PersianDateControls     5   	     � Title$  انتخاب صندوق��5   	   $	��600��6   $	��800��6+   $��RightToLeft=�67      WindowStyle#���   6S   .��5      � .+�5   
   �� $ ��کد گیرنده مبلغ��6   $
��Left=�6)     
LabelStyle#��[ 6D   $��	10,44,0,0q�6h   $	��Top=�6{   $��91��6�   �� 5   
   -   5         ��Name$ cmbReciverCode��5      $
��Left=�6+   $��35��6F   $��
106,44,0,0q�6R   $	��Top=�6f   $	��152��6~    �� DisplayMemberPath$ 
AssignName��6�    �� SelectedValuePath$ Id��6�   &   System.Windows.Controls.DataGrid  5	   
   -   5          Name$ grdFunds��5	      $��
10,84,10,0q�6%      AutoGenerateColumns .  $��RightToLeft=�6U     DataGridStyle#��[ 6q   $	��462��6�   $	��Top=�6�      CanUserAddRows .     Columns 5
      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   
Visibility$ Hidden=�6<   	   
IsReadOnly	 . 1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6%   �� *ID+6P     5         Header$ نام��6%   	 . 
 63   �� *FName+6N     5      $ شماره حساب��6%   	 . 
 6:   �� *FAccountnumber+6]   5      �� 5   
   -   5         ��Name$ 	btnSelect��5      $��ثبت��6$     ButtonStyleRD#��[ 62   $��10,551,10,10q�6q   5      5      