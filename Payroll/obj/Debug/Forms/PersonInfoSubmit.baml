   M S B A M L   `   `   `  ����  Payroll'    !AccountingKernel.PersonInfoSubmit   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  
PersonInfo��5   	   $	��600��6   $	��800��6)   $��RightToLeft=�65      WindowStyle#���   6h    � WindowStartupLocation$ CenterScreen=�6�   .��5      � .+�5   
   �� $��
جستجو��6   $
��Left=�6    $��	11,10,0,0q�6;   $	��Top=�6N   $��50��6f     
LabelStyle#��[ 6q   �� 5   
   -   5        $��	txtSearch��5        TextBoxStyle#��[ 6#   $��66,10,213,0q�6I    �� TextWrapping$
 Wrap=�6^   $	��Top=�6s   6�   �� 5   
   -   5         ��Name$ BtnPrint��5       � ToolTip$ چاپ��6#   $��35��61   $��	0,10,10,0q�6>   $	��Top=�6Q   $��Right=�6i   $��35��6�   ��5	      �� 5
       �� ImageSource$. (/Payroll;component/Themes/icon/print.png��6   5      �� 5   
   -   5        $ BtnExel��5      $ اکسل��6"   $��35��61   $��	0,10,50,0q�6>   $	��Top=�6Q   $��Right=�6i   $��35��6�   ���	#FF7A7878
���   ���5      �� 5      $. (/Payroll;component/Themes/icon/Excel.png��6   5      �� 5   
   -   5        $ BtnDel��5      $ حذف��6!   $��35��6/   $��	0,10,90,0q�6<   $	��Top=�6O   $��Right=�6g   $��35��6�   ��5      �� 5      $/ )/Payroll;component/Themes/icon/delete.png��6   5      �� 5   
   -   5        $ BtnEdit��5      $ ويرايش��6"   $��35��63   $��
0,10,130,0q�6?   $	��Top=�6S   $��Right=�6k   $��35��6�   ��5      �� 5      $- '/Payroll;component/Themes/icon/Edit.png��6   5      �� 5   
   -   5        $ BtnNew��5      $ جديد��6!   $��35��60   $��
0,10,170,0q�6=   $	��Top=�6Q   $��Right=�6i   $��35��6�   
���   ����	#FF7E7E7E��5      �� 5      $, &/Payroll;component/Themes/icon/New.png��6   5       &   System.Windows.Controls.DataGrid  5"   
   -   5        $��	grdPerson��5"         AutoGenerateColumns .  $��10,50q�6A   $��RightToLeft=�6P    � ContextMenu 5#      �� 5$      .@�5%      m� $��
عمیات��6   .@�5&      m� -	   5        $��Gridnew��5&   1   $��جدید��6#   6@   m� 5'      -
   5        $��GridEdit��5'   3   $��ویرایش��6#   6C   m� 5(      -   5        $��
GridDelete��5(   0   $��حذف��6#   6B   m� 5*      -   5        $��ContractStaffLink��5*   6   $��تعریف حکم��6#   6O   m� 5+      -   5        $��GridLoan��5+   5   $��لیست وام��6#   6E   m� 5,      -   5        $��GridMPJ��5,   3   $��مساعده��6#   6B   5-      5.         Columns 50      0  *System.Windows.Controls.DataGridTextColumn  51      ,  &System.Windows.Controls.DataGridColumn	   Header$	 
شناسه��6%   
   
IsReadOnly
 .    
Visibility$ Hidden=�6F   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6Z   ��  �� Path$ id�  52      $	 نام��6%   
 .  6D   �� $ 
PFristName�  53      $	 نام خانوادگی��6%   
 .  6M   �� $ 	PLastName�  54      $	 نام پدر��6%   
 .  6I   �� $ PFather�  55      $	 کد ملی��6%   
 .  6G   �� $ PIdNational�  56      $!	 شماره شناسنامه��6%   
 .  6O   �� $ PSHSH�  57      $	 
تعداد��6%   
 .  6F   �� $ PNumberChild�  58      $	 تلفن��6%   
 .  6E   �� $ 
PPhoneHome�  59      $	 کد پستی��6%   
 .  6H   �� $ 	PIdPostal�5;      �� 5=   
   -   5        $��انتخاب��5=        ButtonStyleRD#��[ 6"   $
��Left=�6I   $��
10,555,0,0q�6d   $	��Top=�6x   $	��780��6�   6�   5>      5?      