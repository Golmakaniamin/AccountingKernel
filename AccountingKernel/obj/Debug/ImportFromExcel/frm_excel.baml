   M S B A M L   `   `   `  ����K  GAccountingKernel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:AccountingKernel.ImportFromExcel AccountingKernel.ImportFromExcel  5   
   0    *AccountingKernel.ImportFromExcel.frm_excel   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   E
staticData.clr-namespace:AccountingKernel.ImportFromExcel     5   
     � Title$  	frm_excel��5   	   $��370.173��6   $��539.098��6,    � 	Resources 5      /   )AccountingKernel.ImportFromExcel.ItemList   ItemList��%   &	          5   
   6   5      .��5      �  � RowDefinitions 5   
   �� 5      $	��82* �6   �� 5      $
��207* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 	grd_excel��5      $
��Left=�6&   $��10,8,0,0q�6A   $	��Top=�6S   $	��511��6k   $	��243��6w   $��2��6�      AutoGenerateColumns .     CanUserAddRows .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ستونهای اصلی��6F      Width5  /System.Windows.Controls.DataGridLengthConverter$	 250 6\   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6%   �� *MainGridCols+6\   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ ستونهای اکسل��6)   $ * 6?   
   CellTemplate
 5      �� 5      .R�5      �� ��6(   �� *	ExcellCol+5         CellEditingTemplate 5      �� 5      .R�5      �� $��22��6'   #��[  5   '    �� SelectedItem 5   '   �� *	ExcellCol+5       5#      5&      �� 5'   
   -   5         ��Name$ btn_get_data��5'      $(��"بارگذاری فایل اکسل��6'   $
��Left=�6D   $��
10,160,0,0q�6_   $��1��6s   $	��Top=�6�   $	��511��6�   $��33��6�   �� 5(   
   -   5        $ btn_rev_data��5(      $��
تایید��6'   $
��Left=�67   $��
10,198,0,0q�6R   $��1��6f   $	��Top=�6s   $	��511��6�   $��36��6�   5*      5+      