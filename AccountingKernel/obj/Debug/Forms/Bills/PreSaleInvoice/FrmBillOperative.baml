   M S B A M L   `   `   `  ����  AccountingKernelB    <AccountingKernel.Forms.Bills.PreSaleInvoice.FrmBillOperative   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   $	��600��5   	   $	��800��6      WindowStyle#���   6"     � WindowStartupLocation$  CenterScreen=�6I   $��RightToLeft=�6n   .��5      � .+�5   
   �� $$��عوامل پیش فاکتور��6     
LabelStyle#��[ 6+   $
��Left=�6O   $��
334,35,0,0q�6j   $	��Top=�6~   $	��100��6�   �� 5   
   $��شماره ��6   #��[ 6!   $
��Left=�6E   $	��Top=�6`   $	��100��6x   $��
430,89,0,0q�6�    J� RenderTransformOrigin$ 0.989,2.496&�6�   �� 5   
   -   5         ��Name$ 
lblBillNum��5   �   $
��Left=�6   #��[ 6+   $��35��6O   $	��Top=�6[   $	��100��6s   $��
535,89,0,0q�6   6�   �� 5	   
   $��
تاریخ��6   #��[ 6    $
��Left=�6D   $	��Top=�6_   $	��100��6w   $��
220,89,0,0q�6�   $ 0.989,2.496&�6�   �� 5
   
   -   5        $ lblDate��5
   �   $
��Left=�6   $��35��6+   #��[ 67   $	��Top=�6[   $	��100��6s   $��
325,89,0,0q�6   6�   �� 5   
   $��نام مشتری��6   #��[ 6$   $
��Left=�6H   $	��Top=�6c   $	��100��6{   $��	10,89,0,0q�6�   $ 0.989,2.496&�6�   �� 5   
   -   5        $ 
lblCompany��5   �   $
��Left=�6   #��[ 6+   $	��Top=�6O   $	��100��6g   $��
115,89,0,0q�6s   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ DataGrid��5      $��10,143,10,50q�6%     DataGridStyle#��[ 6;      AutoGenerateColumns .     CanUserAddRows .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
شناسه��6%      
IsReadOnly . 	   
Visibility$	 Hidden=�6F   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6Z   �� *Id+4  .System.Windows.Controls.DataGridCheckBoxColumn  5      $  ��6)   $	 Hidden=�6S   
 63   �� *IsAllocated+6S   4  .System.Windows.Controls.DataGridComboBoxColumn  5      $ نام عامل��6)   -   5        cmbOperative��   DisplayMemberPath 5   R   �� *OperativeName+   SelectedValueBinding 6~   �� *OperativeId+  5      $ مبلغ��6%   
 64   �� *Price+  5      $ درصد��6%   
 64   �� *	Percent+5      �� 5   
   -   5        $��ثبت��5      $��
10,0,10,10q�6   $��Bottom=�63     ButtonStyleRD#��[ 6h   5      5      