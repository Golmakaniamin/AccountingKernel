   M S B A M L   `   `   `  ����B  >Payroll, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullP5clr-namespace:AccountingKernel.Class;assembly=PayrollAccountingKernel.Class  5   	    AccountingKernel2   ,AccountingKernel.Forms.MmoienCode.MoeinGroup   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Bdxg2http://schemas.devexpress.com/winfx/2008/xaml/grid     5   	   Fself5clr-namespace:AccountingKernel.Class;assembly=Payroll     5   	   $	��600��5   
   $	��800��6     � WindowStartupLocation$  CenterScreen=�6#   $��RightToLeft=�6H      WindowStyle#���   6d   .��5      � .+�5   
   �� $��
جستجو��6   $
��Left=�6    $��	11,10,0,0q�6;   $	��Top=�6N   $��50��6f     
LabelStyle#��[ 6q   �� 5	   
   -   5        $��	txtSearch��5	        TextBoxStyle#��[ 6#   $��66,10,213,0q�6I    �� TextWrapping$
 Wrap=�6^   $	��Top=�6s   6�   �� 5
   
   -   5         ��Name$ BtnPrint��5
       � ToolTip$ چاپ��6#   $��35��61   $��	0,10,10,0q�6>   $	��Top=�6Q   $��Right=�6i   $��35��6�   ��5      �� 5       �� ImageSource$. (/Payroll;component/Themes/icon/print.png��6   5      �� 5   
   -   5        $ BtnExel��5      $ اکسل��6"   $��35��61   $��	0,10,50,0q�6>   $	��Top=�6Q   $��Right=�6i   $��35��6�   ���	#FF7A7878
���   ���5      �� 5      $. (/Payroll;component/Themes/icon/Excel.png��6   5      �� 5   
   -   5        $ BtnDel��5      $ حذف��6!   $��35��6/   $��	0,10,90,0q�6<   $	��Top=�6O   $��Right=�6g   $��35��6�   ��5      �� 5      $/ )/Payroll;component/Themes/icon/delete.png��6   5      �� 5   
   -   5        $ BtnEdit��5      $ ويرايش��6"   $��35��63   $��
0,10,130,0q�6?   $	��Top=�6S   $��Right=�6k   $��35��6�   ��5      �� 5      $- '/Payroll;component/Themes/icon/Edit.png��6   5      �� 5   
   -   5        $ BtnNew��5      $ جديد��6!   $��35��60   $��
0,10,170,0q�6=   $	��Top=�6Q   $��Right=�6i   $��35��6�   
���   ����	#FF7E7E7E��5      �� 5       $, &/Payroll;component/Themes/icon/New.png��6   5"      R� 5#   
   -   5        $��trvMenu��5#      $��11,50,10,10q�6"   ��5$      �� 5%       �� DataType'   !AccountingKernel.Class.MyMenuItem"  6+    �� ItemsSource 6O   �� *Items+.R�5&      ��  �� Orientation$ 
Horizontal=�6!    � ContextMenu 5'      �� 5(      .@�5)   "   m� $��عملیات��6+   .@�5*   &   m� $	��new��6=   -   5        $��جدید��5*   /   6H   m� 5+   &   $
��edit��6?   -	   5        $��ویرایش��5+   /   6K   m� 5,   &   $��delete��6<   -
   5        $��حذف��5,   /   6J   5-   #   5.      .+�50      �� ��6$   �� *Title+51      52      54      55      56      