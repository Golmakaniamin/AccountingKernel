   M S B A M L   `   `   `  ����  Payroll*    $AccountingKernel.PayrollSalaryFactor   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  PayrollSalaryFactor��5   	   $	��630��6&   $	��800��63   $��RightToLeft=�6?      WindowStyle#���   6[    � WindowStartupLocation$ CenterScreen=�6�   .��5      � .+�5   
   �� $��نام��6     
LabelStyle#��[ 6   $
��Left=�6B   $��
204,46,0,0q�6]   $	��Top=�6q   $��40��6�   �� 5   
   $��
فرمول��6   #��[ 6    $
��Left=�6D   $��
374,46,0,0q�6_   $	��Top=�6s   $��40��6�   �� 5   
   -   5        $��txtName��5        TextBoxStyle#��[ 6!   $
��Left=�6G   $��
249,46,0,0q�6b    �� TextWrapping$
 Wrap=�6v   $	��Top=�6�   $	��120��6�   �� 5	   
   -   5        $��	txtFurmol��5	      #��[ 6#   $
��Left=�6I   $��
419,46,0,0q�6d   $
 Wrap=�6x   $	��Top=�6�   $	��135��6�   �� 5
   
   -   5         ��Name$ 	btnSubmit��5
        ButtonStyleRD#��[ 6$   $��
تعریف��6K   $	��Top=�6\   $��10,104,10,0q�6t   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 	grdSalary��5      $	��Top=�6&   $	��436��6>      AutoGenerateColumns .  $��10,144,10,0q�6g      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%      
IsReadOnly . 	   
Visibility$	 Hidden=�6C   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6W   ��  �� Path$ ID�  5      $ نام��6%    . 
 6D   �� $ PrIDate�  5      $ مبلغ��6%    . 
 6E   �� $ PrIPrice�5      �� 5   
   -   5        $ 	btnCommit��5      #��[ 6$   $��به روز رسانی��6K   $	��Top=�6b   $��10,585,10,0q�6z   6�   5      5      