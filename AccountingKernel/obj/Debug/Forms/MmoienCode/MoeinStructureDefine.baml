   M S B A M L   `   `   `  ����  AccountingKernel<    6AccountingKernel.Forms.MmoienCode.MoeinStructureDefine   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  MoeinStructureDefine��5   	   $	��670��6'   $	��800��64   $��RightToLeft=�6@      WindowStyle#���   6\    � WindowStartupLocation$ CenterScreen=�6�   .��5      � .+�5   
   �� $��
جستجو��6   $
��Left=�6    $��6,73,0,0q�6;   $	��Top=�6M   �� 5   
   -   5         ��Name$ 	txtSearch��5   �     TextBoxStyle#��[ 6   $��
56,73,10,0q�68    �� TextWrapping$
 Wrap=�6L   $	��Top=�6a   6�   �� 5	   
   $��سطح��6     
LabelStyle#��[ 6   $
��Left=�6B   $	��Top=�6]   $��32��6u   $��	12,33,0,0q�6�   �� 5
   
   -   5         ��Name$ canvas��5
   M   $
��Left=�6   $��56,33,0,602q�6,   $	��731��6A   $��35��6]   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ grdList��5   /      AutoGenerateColumns .     CanUserAddRows .    DataGridStyle#��[ 6o   $��10,120,10,54q�5   D   ��5   W   ��  �� SelectedItem 5      �� *AccountingArticle+	 �� Mode$	 TwoWay=�
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 کد��6%      
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6\   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6C   �� *Code+6\     5      $ نام��6%    . $	 100 6^    6E   �� *Name+6^   5      �� 5   
   -   5         ��Name$ 	btnSubmit��5      $��
تایید��6$     ButtonStyleRD#��[ 64   $��10,625,10,10q�6[   6q   5      5      