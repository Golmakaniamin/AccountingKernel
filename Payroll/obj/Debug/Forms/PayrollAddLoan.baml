   M S B A M L   `   `   `  ����U  QPersianDateControls, Version=1.2.5439.35283, Culture=neutral, PublicKeyToken=nullbDclr-namespace:Arash.PersianDateControls;assembly=PersianDateControlsArash.PersianDateControls  5   	    Payroll%   AccountingKernel.PayrollAddLoan   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   dPersianDateControlsDclr-namespace:Arash.PersianDateControls;assembly=PersianDateControls     5   	     � Title$  PayrollAddLoan��5   	   $	��600��6!   $	��800��6.   $��RightToLeft=�6:      WindowStyle#���   6V    � WindowStartupLocation$ CenterScreen=�6|   .��5      � .+�5   
   �� $��کد وام��6     
LabelStyle#��[ 6!   $
��Left=�6E   $��	77,60,0,0q�6`   $	��Top=�6s   $��44��6�   �� 5   
   -   5         ��Name$ txtLoanCode��5        TextBoxStyle#��[ 6'   $
��Left=�6M   $��
126,60,0,0q�6i    �� TextWrapping$
 Wrap=�6}   $	��Top=�6�   $	��130��6�   �� 5	   
   $��تاریخ پرداخت��6   #��[ 6'   $
��Left=�6K   $��
279,60,0,0q�6f   $	��Top=�6z   $��60��6�   1   +Arash.PersianDateControls.PersianDatePicker  5
   
   -   5        $��pdcPaymentDate��5
   0   $��35��6F   $
��Left=�6R   $��
344,60,0,0q�6m   $	��Top=�6�   �� 5   
   $��مبلغ وام��6   #��[ 6#   $
��Left=�6G   $��
505,60,0,0q�6b   $	��Top=�6v   $��44��6�   �� 5   
   -   5        $ txtLoanPrice��5      $��RightToLeft=�6(   #��[ 6D   $
��Left=�6j   $��
554,60,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��142��6�   6�   �� 5   
   -   5         ��Name$ 
btnNewLoan��5        ButtonStyleRD#��[ 6%   $��تعریف وام��6L   $��10,119,10,0q�6`   $	��Top=�6u   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ grdLoan��5      $��10,159,10,0q�6$   $	��Top=�69   $	��366��6Q      AutoGenerateColumns .   � ContextMenu 5      �� 5      .@�5      m� -   5        $��GridLoanDetail��5   .   $��
اقساط��6   6D   5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 id��6%   
   
IsReadOnly
 .    
Visibility$ Hidden=�6Z   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6C   �� *ID+6Z     5      $	 کد وام��6%   
 .  6G   �� *PrLID+  5      $	 تاریخ پرداخت��6%   
 .  6M   �� *
PrLDDate+  5      $	 مبلغ وام��6%   
 .  6K   �� *	PrLDPrice+5      �� 5   
   -   5        $ 	btnSubmit��5      #��[ 6$   $��به روز رسانی��6K   $��10,530,10,0q�6b   $	��Top=�6w   6�   5      5      