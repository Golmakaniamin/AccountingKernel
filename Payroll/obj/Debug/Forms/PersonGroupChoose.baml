   M S B A M L   `   `   `  ����  Payroll(    "AccountingKernel.PersonGroupChoose   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  PersonStructureDefine��5   	   $	��630��6'   $	��800��64   $��RightToLeft=�6@      WindowStyle#���   6\    � WindowStartupLocation$ CenterScreen=�6�   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ grdList��5   /      AutoGenerateColumns .     CanUserAddRows .   DataGridStyle#��[ 6n   $��10,80,10,54q�5   D   ��5   V   ��  �� SelectedItem 5      �� *AccountingArticle+ �� Mode$ TwoWay=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5	      ,  &System.Windows.Controls.DataGridColumn   Header$
 کد��6%   	   
IsReadOnly	 . 
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 50 6\   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6C   �� *Code+6\     5
      $ نام��6%   	 . $	
 100 6^    6E   �� *Name+6^   5      �� 5   
   $��سطح��6     
LabelStyle#��[ 6   $
��Left=�6B   $	��Top=�6]   $��50��6u   $��	10,40,0,0q�6�   �� 5   
   -   5         ��Name$ 	btnSubmit��5      $��
تایید��6$     ButtonStyleRD#��[ 64   $��10,585,10,10q�6[   6q   �� 5   
   -   5         ��Name$ canvas��5   M   $
��Left=�6   $��65,40,0,525q�6,   $	��725��6A   $��35��6]   5      5      