   M S B A M L   `   `   `  ����K  GAccountingKernel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:AccountigKernel.Class.UIAccountigKernel.Class.UI  5   	   7    1AccountingKernel.Forms.Document.MoeinTafsilChoose   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5   	   9UI&clr-namespace:AccountigKernel.Class.UI       5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  MoeinTafsilChoose��5   	   $	��630��6#   $	��800��60   $��RightToLeft=�6<      WindowStyle#���   6X    � WindowStartupLocation$ CenterScreen=�6~   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ grdList��5   /      AutoGenerateColumns .     CanUserAddRows .    DataGridStyle#��[ 6o   $��10,80,10,54q�5   D   ��5   W   ��  �� SelectedItem 5      �� *AccountingArticle+ �� Mode$ TwoWay=�   Columns 5	      0  *System.Windows.Controls.DataGridTextColumn  5
      ,  &System.Windows.Controls.DataGridColumn   Header$
 کد��6%   	   
IsReadOnly	 . 
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 50 6\   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6C   �� *Code+6\     5      $ نام��6%   	 . $	
 100 6^    6E   �� *Name+6^   5      �� 5   
   $��سطح��6     
LabelStyle#��[ 6   $
��Left=�6B   $	��Top=�6]   $��50��6u   $��	10,40,0,0q�6�   �� 5   
   -   5         ��Name$ 	btnSubmit��5      $��
تایید��6$     ButtonStyleRD#��[ 64   $��10,585,10,10q�6[   6q   �� 5   
   -   5         ��Name$ canvas��5   M   $
��Left=�6   $��65,40,0,525q�6,   $	��725��6A   $��35��6]   5      5      