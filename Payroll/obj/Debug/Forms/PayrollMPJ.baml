   M S B A M L   `   `   `  ����U  QPersianDateControls, Version=1.2.5439.35283, Culture=neutral, PublicKeyToken=nullbDclr-namespace:Arash.PersianDateControls;assembly=PersianDateControlsArash.PersianDateControls  5   	    Payroll!   AccountingKernel.PayrollMPJ   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   dPersianDateControlsDclr-namespace:Arash.PersianDateControls;assembly=PersianDateControls     5   	   -   5          � Title$  
PayrollMPJ��5   	   $	��600��6   $	��800��6)   $��RightToLeft=�65      WindowStyle#���   6Q    � WindowStartupLocation$ CenterScreen=�6w   .��5      � .+�5   
   �� $��
تاریخ��6     
LabelStyle#��[ 6    $
��Left=�6D   $��	10,54,0,0q�6_   $	��Top=�6r   $��39��6�   1   +Arash.PersianDateControls.PersianDatePicker  5   
   -   5        $��pdcDate��5   0   $
��Left=�6?   $��	54,54,0,0q�6Z   $	��Top=�6m   $��35��6�   �� 5	   
   $��نوع��6   #��[ 6   $
��Left=�6B   $��
174,54,0,0q�6]   $	��Top=�6q   $��35��6�   �� 5
   
   -   5        $��cmbType��5
      $
��Left=�6"   $��35��6=   $��
214,54,0,0q�6I   $	��Top=�6]   $	��120��6u    �� DisplayMemberPath$
 Name��6�    �� SelectedValuePath 6�   �� *Id+�� 5   
   $��مبلغ��6   #��[ 6   $
��Left=�6C   $��
339,54,0,0q�6^   $	��Top=�6r   $��35��6�   �� 5   
   -   5        $��txtPrice��5      $��RightToLeft=�6"     TextBoxStyle#��[ 6>   $
��Left=�6d   $��
379,54,0,0q�6    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��160��6�   6�   �� 5   
   -   5         ��Name$ 	btnSubmit��5        ButtonStyleRD#��[ 6$   $��
تعریف��6K   $	��Top=�6[   $��10,104,10,0q�6s   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ grdMPJ��5      $	��Top=�6#   $	��406��6;      AutoGenerateColumns .  $��10,144,10,0q�6d   $��RightToLeft=�6y      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Id��6%   
   
IsReadOnly
 .    
Visibility$ Hidden=�6C   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6W   ��  �� Path$ ID�  5      $	 
تاریخ��6%   
 .  6F   �� $ PrIDate�4  .System.Windows.Controls.DataGridComboBoxColumn  5      -   5        Grid_combo_Type��$	 نوع��5   B      DisplayMemberPath$
 Name��6O      SelectedValuePath 6h   �� *Id+  5      $	 مبلغ��6%   
 .  6E   �� $ PrIPrice�5      �� 5   
   -   5        $ 	btnCommit��5      #��[ 6$   $��به روز رسانی��6K   $	��Top=�6b   $��10,555,10,0q�6z   6�   5      5      