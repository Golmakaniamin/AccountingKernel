   M S B A M L   `   `   `  ����  AccountingKernelO    IAccountingKernel.Forms.Bills.PurchaseInvoice.FrmPurchaseInvoiceManagement   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Document��5   	   $	��600��6      WindowStyle#���   6'   $	��800��6M    � WindowStartupLocation$ CenterScreen=�6Y   $��RightToLeft=�6~   .��5      � .+�5   
   �� $��
جستجو��6   $
��Left=�6    $��35��6;   $��	10,10,0,0q�6G   $	��Top=�6Z   $��50��6r     
LabelStyle#��[ 6}   �� 5   
   -   5         ��Name$ 	txtSearch��5      $��35��6%     TextBoxStyle#��[ 61   $��65,10,212,0q�6W   $	��Top=�6l   6�   �� 5   
   -   5         ��Name$ BtnPrint��5       � ToolTip$ چاپ��6#   $��35��61   $��	0,10,10,0q�6>   $	��Top=�6Q   $��Right=�6i   $��35��6�   ��5	      �� 5
       �� ImageSource$7 1/AccountingKernel;component/Themes/icon/Print.png��6   5      �� 5   
   -   5        $ BtnExel��5      $ اکسل��6"   $��35��61   $��	0,10,50,0q�6>   $	��Top=�6Q   $��Right=�6i   $��35��6�   ���	#FF7A7878
���   ���5      �� 5      $7 1/AccountingKernel;component/Themes/icon/Excel.png��6   5      �� 5   
   -   5        $ BtnDel��5      $ حذف��6!   $��35��6/   $��	0,10,90,0q�6<   $	��Top=�6O   $��Right=�6g   $��35��6�   ��5      �� 5      $8 2/AccountingKernel;component/Themes/icon/delete.png��6   5      �� 5   
   -   5        $ BtnEdit��5      $ ویرایش��6"   $��35��63   $��
0,10,130,0q�6?   $	��Top=�6S   $��Right=�6k   $��35��6�   ��5      �� 5      $6 0/AccountingKernel;component/Themes/icon/Edit.png��6   5      �� 5   
   -   5        $ BtnNew��5      $ جدید��6!   $��35��60   $��
0,10,170,0q�6=   $	��Top=�6Q   $��Right=�6i   $��35��6�   
���   ����	#FF7E7E7E��5      �� 5      $5 //AccountingKernel;component/Themes/icon/New.png��6   5       &   System.Windows.Controls.DataGrid  5!   
   -   5          Name$ DataGrid��5!      $��10,50,10,10q�6%      AutoGenerateColumns .    DataGridStyle#��[ 6�    � ContextMenu 5"      �� 5#      .@�5$      m� $��عملیات��6   .@�5%      m� -   5        $��جدید��5%   #   61   m� 5&      -	   5        $��ویرایش��5&   #   63   m� 5'      -
   5        $��حذف��5'   #   60   5(      5)      	   Columns	 5+      0  *System.Windows.Controls.DataGridTextColumn  5,      ,  &System.Windows.Controls.DataGridColumn
   Header$
 
شناسه��6%      
IsReadOnly .    
Visibility$ Hidden=�6F   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6Z   ��  �� Path$ Id�  5-      $"
 نام تامین کننده��6%    .  6P   �� $ CompanyName�  5.      $
 تاریخ فاکتور��6%    .  6N   �� $
 Date�  5/      $
 شماره فاکتور��6%    .  6N   �� $
 Code�4  .System.Windows.Controls.DataGridTemplateColumn  51      $
 چاپ گزارش��6)    .    CellTemplate 52      �� 53      .R�54      �� $ Report��6%   -   5        $��35��54   L   $��35��6X   .��55   "   �� $7��1/AccountingKernel;component/Themes/icon/Print.png��6(   56      57      59      5;      5<      5=      