   M S B A M L   `   `   `  ����  AccountingKernel3    -AccountingKernel.Forms.MmoienCode.MoeinSearch   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  MoeinSearch��5   	   $	��600��6   $	��800��6+   $��RightToLeft=�67      WindowStyle#���   5   	    � WindowStartupLocation$ CenterScreen=�6/   .��5      � .+�5   
   �� $��
جستجو��6     
LabelStyle#��[ 6    $
��Left=�6D   $��	10,10,0,0q�6_   $	��Top=�6r   $��33��6�   �� 5   
   -   5        $��	txtSearch��5        TextBoxStyle#��[ 6#   $��48,10,215,0q�6I   $	��Top=�6^   6�   �� 5	   
   -   5         ��Name$ BtnPrint��5	       � ToolTip$ چاپ��6#   $��35��61   $��	0,10,10,0q�6>   $	��Top=�6Q   $��Right=�6i   $��35��6�   ��5
      �� 5       �� ImageSource$7 1/AccountingKernel;component/Themes/icon/Print.png��6   5      �� 5   
   -   5        $ BtnExel��5      $ اکسل��6"   $��35��61   $��	0,10,50,0q�6>   $	��Top=�6Q   $��Right=�6i   $��35��6�   ���	#FF7A7878
���   ���5      �� 5      $7 1/AccountingKernel;component/Themes/icon/Excel.png��6   5      �� 5   
   -   5        $ BtnDel��5      $ حذف��6!   $��35��6/   $��	0,10,90,0q�6;   $	��Top=�6N   $��Right=�6f   $��35��6�   ��5      �� 5      $8 2/AccountingKernel;component/Themes/icon/delete.png��6   5      �� 5   
   -   5        $ BtnEdit��5      $ ویرایش��6"   $��35��63   $��
0,10,130,0q�6?   $	��Top=�6S   $��Right=�6k   $��35��6�   ��5      �� 5      $6 0/AccountingKernel;component/Themes/icon/Edit.png��6   5      �� 5   
   -   5        $ BtnNew��5      $ جدید��6!   $��35��60   $��
0,10,170,0q�6=   $	��Top=�6Q   $��Right=�6i   $��35��6�   
���   ����	#FF7E7E7E��5      �� 5      $5 //AccountingKernel;component/Themes/icon/New.png��6   5!      &   System.Windows.Controls.DataGrid  5"   
   -   5          Name$ grdLoanInsurance��5"      $��10,50,10,10q�6-      AutoGenerateColumns .     CanUserAddRows .   � ContextMenu 5#      �� 5$      .@�5%      m� $��عملیات��6   .@�5&      m� -   5        $��GridNew��5&   1   $��جدید��6#   6@   m� 5'      -	   5        $��GridLoadDetail��5'   3   $��وبرایش��6#   6I   m� 5(      -
   5        $��
GridDelete��5(   0   $��حذف��6#   6B   m� 5)      -   5        $��GridTafzili��5)   >   $&�� تعیین سطوح تفضیلی��6#   6Q   5*      5+      	   Columns	 5-      0  *System.Windows.Controls.DataGridTextColumn  5.      ,  &System.Windows.Controls.DataGridColumn
   Header$
 ID��6%      
IsReadOnly .    
Visibility$ Hidden=�6Z   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6C   �� *ID+6Z     5/      $
 کد گروه��6%    .  6H   �� *FirstLevelCode+  50      $
 نام گروه��6%    .  6I   �� *FirstLevelName+  51      $
 	کد کل��6%    .  6F   �� *SecondLevelCode+  52      $
 نام کل��6%    .  6G   �� *SecondLevelName+  53      $
 کد معین��6%    .  6H   �� *ThirdLevelCode+  54      $
 نام معین��6%    .  6I   �� *ThirdLevelName+56      57      58      