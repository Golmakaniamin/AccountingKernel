   M S B A M L   `   `   `  ����K  GAccountingKernel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:AccountigKernel.Class.UIAccountigKernel.Class.UI  5   	   *    $AccountingKernel.Forms.Document.frmB   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   5UI&clr-namespace:AccountigKernel.Class.UI     5   	   -   5          � Title$.  (انتخاب کدهای حسابداری��5   	   $	��600��6'   $	��800��64    � WindowStartupLocation$ CenterScreen=�6@   $��Tohama)�6e   $��14(�6y   $
��Bold"�6�   $��RightToLeft=�6�      WindowStyle#���   5      .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DataGridTest��5
   /      AutoGenerateColumns .     CanUserAddRows .   DataGridStyle#��[ 6s   $��10,50,10,416q�5   p   ��5
   [   ��  �� SelectedItem 5      �� *AccountingArticle+ �� Mode$ TwoWay=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 کد��6%   	   
IsReadOnly	 . 
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 50 6\   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6C   �� *IdIn+6\     5      $ نام��6%   	 . $	
 100 6^    6E   �� *Name+6^   5      �� 5   
   $��سطح��6     
LabelStyle#��[ 6   $
��Left=�6B   $	��Top=�6]   $��40��6u   $��	10,10,0,0q�6�   ,   &AccountigKernel.Class.UI.NavigationBar  5   
   -   5          Name$ NavBar��5      $
��Left=�6+   $	��250��6F   $��
19,234,0,0q�6S   $	��Top=�6g   $	��178��6   �� 5   
   -   5         ��Name$ btn_ok��5      $��
تایید��6!     ButtonStyleRD#��[ 61   $��10,527,9.6,10q�6X   6o   5      5      