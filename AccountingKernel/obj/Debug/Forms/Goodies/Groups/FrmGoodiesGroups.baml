   M S B A M L   `   `   `  ����K  GAccountingKernel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]3clr-namespace:AccountingKernel.Forms.Goodies.Groups%AccountingKernel.Forms.Goodies.Groups  5   	   <    6AccountingKernel.Forms.Goodies.Groups.FrmGoodiesGroups   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   NAccountingProj3clr-namespace:AccountingKernel.Forms.Goodies.Groups     5   	   $	��600��5   	   $	��800��6     � WindowStartupLocation$  CenterScreen=�6"   $��RightToLeft=�6G      WindowStyle#���   6c    � 	Resources 5      ?   9AccountingKernel.Forms.Goodies.Groups.BoxinItemsConverter  boxingItems��%   &	         5   
   6-   5      .��5	      � .+�5
   
   �� $��
جستجو��6   $��35��6    $��10,10,740,0q�6,   $	��Top=�6A     
LabelStyle#��[ 6Y   �� 5   
   -   5         ��Name$ 	txtSearch��5      $��35��6%   $��65,10,215,0q�61   $	��Top=�6F     TextBoxStyle#��[ 6v   �� 5   
   -   5         ��Name$ BtnPrint��5       � ToolTip$ چاپ��6#     ButtonStyleRD#��[ 61   $��	0,10,10,0q�6Y   $	��Top=�6l   $��Right=�6�   $��35��6�   �� 5   
   -   5        $ BtnExel��5      $ اکسل��6"   #��[ 61   $��	0,10,50,0q�6Y   $	��Top=�6l   $��Right=�6�   $��35��6�   �� 5   
   -   5        $ BtnDel��5      $ حذف��6!   #��[ 6/   $��	0,10,90,0q�6W   $	��Top=�6j   $��Right=�6�   $��35��6�   �� 5   
   -   5        $ BtnEdit��5      $ ویرایش��6"   #��[ 63   $��
0,10,130,0q�6[   $	��Top=�6o   $��Right=�6�   $��35��6�   6�   �� 5   
   -   5        $ BtnNew��5      $ جدید��6!   #��[ 60   $��
0,10,170,0q�6X   $	��Top=�6l   $��Right=�6�   $��35��6�   R� 5   
   -   5         R�Name$ treeView��5      $��10, 50q�6&    � ContextMenu 5      �� 5      .@�5      m� $��عملیات��6   .@�5      m� -   5        $��جدید��5   #   61   m� 5      -	   5        $��ویرایش��5   #   63   m� 5      -
   5        $��حذف��5   #   60   5      5       5       �� DataType5   /AccountingKernel.Forms.Goodies.Groups.MainGroup �� ItemsSource	 �� Path
 �� 	Converter �� ConverterParameter>   8AccountingKernel.Forms.Goodies.Groups.DetailItemsWrapper&   System.Windows.Controls.DataGrid   AutoGenerateColumns   CanUserAddRows   Columns0  *System.Windows.Controls.DataGridTextColumn,  &System.Windows.Controls.DataGridColumn   Header   
IsReadOnly1  +System.Windows.Controls.DataGridBoundColumn   Binding��%�  (��       5   +   *, +)7  (�� �     5#      *, +)�� 5      "  6+    5   '   �� $	 	SubGroups�8
   "  .R�5      �� .+�5       �� $��4q�6$   ��6/   �� $
	 name�5!      5"      �� 5#      "  6   .R�5$        -   5         .   .  ��5$      �� $	 Items� 5&        5'      $ نام��61    .  6>   �� $
	 name�6q   5)      5*      5+      5,      �� 5-   
   -   5        $��انتخاب��5-      #��[ 6"   $��10,525,10,0q�6I   $	��Top=�6^   6v   5.      5/      