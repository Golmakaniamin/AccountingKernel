   M S B A M L   `   `   `  ����  AccountingKernel1    +AccountingKernel.Forms.Goodies.FrmPriceList   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Document��5   	      WindowStyle#���   6   $	��600��6@   $	��800��6M    � WindowStartupLocation$ CenterScreen=�6Y   $��RightToLeft=�6~   .��5      � .+�5   
   �� -   5         ��Name$ lblHeaderCommodityCode��5        
LabelStyle#��[ 60   $
��Left=�6T   $��
508,64,0,0q�6o   $	��Top=�6�   $��71��6�   $��کد کالا��6�   6�   �� 5   
   -   5        $! lblHeaderCommodityCodeValue��5      #��[ 65   $
��Left=�6Y   $��
584,64,0,0q�6t   $	��Top=�6�   $	��119��6�   6�   �� 5	   
   -   5        $ lblHeaderCommodityTitle��5	      #��[ 61   $
��Left=�6U   $��	75,64,0,0q�6p   $	��Top=�6�   $��74��6�   $��عنوان کالا��6�   �� 5
   
   -   5        $" lblHeaderCommodityTitleValue��5
      #��[ 66   $
��Left=�6Z   $��
154,64,0,0q�6u   $	��Top=�6�   $	��120��6�   $�� ��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ grdPriceLists��5      $��10,115,10,54q�6*      AutoGenerateColumns .    DataGridStyle#��[ 6\    � ContextMenu 5      �� 5      .@�5      m� -   5        $��حذف��5      6,   5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
شناسه��6%      
IsReadOnly . 	   
Visibility$	 Hidden=�6F   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6Z   �� *Id+4  .System.Windows.Controls.DataGridCheckBoxColumn  5      $  ��6)   $	 Hidden=�6S   
 63   �� *IsAllocated+6S   4  .System.Windows.Controls.DataGridComboBoxColumn  5      $ نوع مشتری��6)   -   5        cmbCustomerType��   DisplayMemberPath 5   V   �� *CustomerTypeName+   SelectedValueBinding 6�   �� *CustomerTypeId+  5      $ مبلغ��6%   
 64   �� *Value+5      �� 5   
   -   5        $��
تایید��5        ButtonStyleRD#��[ 6"   $
��Left=�6I   $��
10,551,0,0q�6d   $	��Top=�6x   $	��780��6�   6�   5      5      