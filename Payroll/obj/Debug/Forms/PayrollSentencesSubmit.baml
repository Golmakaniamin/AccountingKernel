   M S B A M L   `   `   `  ����  Payroll-    'AccountingKernel.PayrollSentencesSubmit   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  PayrollSentencesSubmit��5      $	��600��60   $	��800��6=   $��RightToLeft=�6I      WindowStyle#���   6g   .��5      � .+�5   
   �� $��
جستجو��6   $
��Left=�6    $��	10,10,0,0q�6;   $	��Top=�6N   $��50��6f     
LabelStyle#��[ 6q   �� 5   
   -   5        $��	txtSearch��5        TextBoxStyle#��[ 6#   $��65,10,212,0q�6I    �� TextWrapping$
 Wrap=�6^   $	��Top=�6s   6�   �� 5   
   -   5         ��Name$ BtnPrint��5       � ToolTip$ چاپ��6#   $��35��61   $��	0,10,10,0q�6>   $	��Top=�6Q   $��Right=�6i   $��35��6�   ��5	      �� 5
       �� ImageSource$. (/Payroll;component/Themes/icon/print.png��6   5      �� 5   
   -   5        $ BtnExel��5      $ اکسل��6"   $��35��61   $��	0,10,50,0q�6>   $	��Top=�6Q   $��Right=�6i   $��35��6�   ���	#FF7A7878
���   � J� RenderTransformOrigin$ 0.286,0.714&�6�   ��5      �� 5      $. (/Payroll;component/Themes/icon/Excel.png��6   5      �� 5   
   -   5        $ BtnDel��5      $ حذف��6!   $��35��6/   $��	0,10,90,0q�6<   $	��Top=�6O   $��Right=�6g   $��35��6�   ��5      �� 5      $/ )/Payroll;component/Themes/icon/delete.png��6   5      �� 5   
   -   5        $ BtnEdit��5      $ ويرايش��6"   $��35��63   $��
0,10,130,0q�6?   $	��Top=�6S   $��Right=�6k   $��35��6�   ��5      �� 5      $- '/Payroll;component/Themes/icon/Edit.png��6   5      �� 5   
   -   5        $ BtnNew��5      $ جديد��6!   $��35��60   $��
0,10,170,0q�6=   $	��Top=�6Q   $��Right=�6i   $��35��6�   
���   ����	#FF7E7E7E��5      �� 5      $, &/Payroll;component/Themes/icon/New.png��6   5       &   System.Windows.Controls.DataGrid  5!   
   -   5        $"��grdBenefitAndDeductionsLists��5!         AutoGenerateColumns .  $��10,50q�6S   $��RightToLeft=�6b    � ContextMenu 5"      �� 5#      .@�5$      m� -   5        $��Gridnew��5$   -   $��جدید��6   6<   m� 5%      -	   5        $��GridEdit��5%   /   $��ویرایش��6   6?   5&         Columns 5(      0  *System.Windows.Controls.DataGridTextColumn  5)      ,  &System.Windows.Controls.DataGridColumn	   Header$	 
شناسه��6%   
   
IsReadOnly
 .    
Visibility$ Hidden=�6F   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6[   ��  �� Path$ PayrollSentencesID�  5*      $ 	 کسورات و مزایا��6%   
 .  6O   �� $ PrSTypeDesc�  5+      $	 نوع��6%   
 .  6D   �� $ PrSOTypeDesc�  5,      $ 	 کسورات و مزایا��6%   $ Hidden=�6=   
 .  6c   �� $ PrSType�  5-      $	 نوع��6%   $ Hidden=�62   
 .  6X   �� $ PrSOType�  5.      $	 
عنوان��6%   
 .  6F   �� $ PrSDescription�  5/      $	 مبلغ��6%   
 .  6E   �� $ PrSMoney�4  .System.Windows.Controls.DataGridCheckBoxColumn  50      $	 بیمه��6)   
 .  6I   �� $ PrSIsInsurance�  51      $	 مالیات��6)   
 .  6K   �� $ PrSIsTax�  52      $'	 !در صد بیمه کارفرما��6%   
 .  6S   �� $ PrSInsuranceEmployer�  53      $%	 در صد بیمه بیکاری��6%   
 .  6R   �� $ PrSInsuranceUnemployment�  54      $#	 در صد بیمه پرسنل��6%   
 .  6Q   �� $ PrSInsuranceEmployee�56      �� 57   
   -
   5        $��	btnUpdate��57   ~   $��به روز رسانی��6     ButtonStyleRD#��[ 6(   $��
10,0,10,10q�6O   $��Bottom=�6c   6�   58      59      