   M S B A M L   `   `   `  ����K  GAccountingKernel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:AccountingKernel.Forms.AssetGoods!AccountingKernel.Forms.AssetGoods  5   	   9    3AccountingKernel.Forms.AssetGoods.FrmAssetGoodGroup   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Bdxg2http://schemas.devexpress.com/winfx/2008/xaml/grid     5   	   JAccountingProj/clr-namespace:AccountingKernel.Forms.AssetGoods     5   	   $	��600��5   	   $	��800��6     � WindowStartupLocation$  CenterScreen=�6"   $��RightToLeft=�6G      WindowStyle#���   6c    � 	Resources 5      ;   5AccountingKernel.Forms.AssetGoods.BoxinItemsConverter  boxingItems��%   &	         5   
   6-   5	      .��5
      � $��0,-1,0,1q�6   .+�5   
   �� $��
جستجو��6   $��35��6    $��10,10,740,0q�6,   $	��Top=�6A     
LabelStyle#��[ 6Y   �� 5   
   -   5         ��Name$ 	txtSearch��5      $��35��6%   $��57,10,212,0q�61   $	��Top=�6F     TextBoxStyle#��[ 6v   �� 5   
   -   5         ��Name$ BtnPrint��5       � ToolTip$ چاپ��6#     ButtonStyleRD#��[ 61   $��	0,10,10,0q�6Y   $	��Top=�6l   $��Right=�6�   $��35��6�   �� 5   
   -   5        $ BtnExel��5      $ اکسل��6"   #��[ 61   $��	0,10,50,0q�6Y   $	��Top=�6l   $��Right=�6�   $��35��6�   �� 5   
   -   5        $ BtnDel��5      $ حذف��6!   #��[ 6/   $��	0,10,90,0q�6W   $	��Top=�6j   $��Right=�6�   $��35��6�   �� 5   
   -   5        $ BtnEdit��5      $ ویرایش��6"   #��[ 63   $��
0,10,130,0q�6[   $	��Top=�6o   $��Right=�6�   $��35��6�   �� 5   
   -   5        $ BtnNew��5      $ جدید��6!   #��[ 60   $��
0,10,170,0q�6X   $	��Top=�6l   $��Right=�6�   $��35��6�   R� 5   
   -   5         R�Name$ treeView��5      $��10,52,10,10q�6&    5       �� DataType1   +AccountingKernel.Forms.AssetGoods.MainGroup �� ItemsSource �� Path	 �� 	Converter
 �� ConverterParameter:   4AccountingKernel.Forms.AssetGoods.DetailItemsWrapper&   System.Windows.Controls.DataGrid   AutoGenerateColumns   Columns0  *System.Windows.Controls.DataGridTextColumn,  &System.Windows.Controls.DataGridColumn   Header1  +System.Windows.Controls.DataGridBoundColumn   Binding��%�  (��       5   +   *, +)7  (�� �     5      *, +)�� 5      "  6+    5   '   �� $ 	SubGroups�8	   "
  .R�5      �� .+�5      �� $��4q�6$   ��6/   �� $
 name�5      5      �� 5      "  6   .R�5        -   5         .  ��5      �� $ Items� 5        5      $ نام��61    6>   �� $
 name�6_   5!      5"      5#      5$      �� 5&   
   -	   5        $��انتخاب��5&      #��[ 6"   $��10,525,10,0q�6I   $	��Top=�6^   6v   5)      5*      