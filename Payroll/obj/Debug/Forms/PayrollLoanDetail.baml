   M S B A M L   `   `   `  ����U  QPersianDateControls, Version=1.2.5439.35283, Culture=neutral, PublicKeyToken=nullbDclr-namespace:Arash.PersianDateControls;assembly=PersianDateControlsArash.PersianDateControls  5   	    Payroll(   "AccountingKernel.PayrollLoanDetail   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   dPersianDateControlsDclr-namespace:Arash.PersianDateControls;assembly=PersianDateControls     5   	     � Title$  PayrollLoanDetail��5   	   $	��600��6#   $	��800��60   $��RightToLeft=�6<      WindowStyle#���   6X    � WindowStartupLocation$ CenterScreen=�6~   .��5      � .+�5   
   �� $"��تاریخ اولین قسط��6   $
��Left=�6+   $��	10,54,0,0q�6F   $	��Top=�6Y     
LabelStyle#��[ 6q   $	��100��6�   1   +Arash.PersianDateControls.PersianDatePicker  5   
   -   5        $��pdcFirstLoan��5   0   $��35��6D   $
��Left=�6P   $��
115,54,0,0q�6k   $	��Top=�6   $	��170��6�   �� 5	   
   $��تعداد اقساط��6   $
��Left=�6&   $��
457,60,0,0q�6A   $	��Top=�6U   #��[ 6m   $	��100��6�   �� 5
   
   -   5         ��Name$ txtPaymentQTY��5
      $��RightToLeft=�6)   $
��Left=�6E     TextBoxStyle#��[ 6`   $��
562,60,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��170��6�   6�   �� 5   
   $"�� میان بازپرداخت��6   $
��Left=�6*   $��	10,94,0,0q�6E   $	��Top=�6X   #��[ 6p   $	��100��6�   �� 5   
   -   5        $ txtRePayment��5      $��RightToLeft=�6(   $
��Left=�6D   #��[ 6_   $��
115,94,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��170��6�   6�   �� 5   
   $��قسط مساوی��6   $
��Left=�6$   $��457,100,0,0q�6?   $	��Top=�6T   #��[ 6l   $	��100��6�   �� 5   
   -   5        $ txtRePaymentEqual��5      $��RightToLeft=�6-   $
��Left=�6I   #��[ 6d   $��562,100,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��170��6�   6�   �� 5   
   $��قسط نامساوی��6   $
��Left=�6&   $��
10,134,0,0q�6A   $	��Top=�6U   #��[ 6m   $	��100��6�   �� 5   
   -   5        $ txtRePaymentNotEqual��5      $
��Left=�60   #��[ 6K   $��115,134,0,0q�6q   $
 Wrap=�6�   $	��Top=�6�   $	��170��6�   6�   �� 5   
   -   5        $��	btnSubmit��5      $��تعریف اقساط��6"     ButtonStyleRD#��[ 68   $��10,174,10,0q�6_   $	��Top=�6t   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ grdLoan��5      $��10,214,10,0q�6$   $	��Top=�69   $	��336��6Q      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%      
IsReadOnly . 	   
Visibility$	 Hidden=�6C   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6W   ��  �� Path$ ID�  5      $ تاریخ قسط��6%    . 
 6J   �� $ PrLDate�  5      $ مبلغ��6%    . 
 6F   �� $ PrLPrice�  5      $ وضعیت پرداخت��6%    . 6;   5      �� 5   
   -   5         ��Name$ 	btnUpdate��5      $��به روز رسانی��6$   #��[ 6;   $��10,555,10,0q�6b   $	��Top=�6w   6�   5      5      