   M S B A M L   `   `   `  ����  AccountingKernel1    +AccountingKernel.Forms.Goodies.FrmUnitCount   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Document��5   	   $	��600��6   $	��800��6'      WindowStyle#���   63    � WindowStartupLocation$ CenterScreen=�6Y   $��RightToLeft=�6~   .��5      � .+�5   
   �� $��کد کالا��6     
LabelStyle#��[ 6"   $
��Left=�6F   $��
414,42,0,0q�6a   $	��Top=�6u   $��44��6�   �� 5   
   -   5         ��Name$ txtCode��5      #��[ 6!   $
��Left=�6E   $��
463,42,0,0q�6a   $	��Top=�6u   $	��324��6�   6�   �� 5   
   $��عنوان کالا��6   #��[ 6%   $
��Left=�6I   $��	31,41,0,0q�6d   $	��Top=�6w   $��63��6�   �� 5	   
   -   5        $ txtTitle��5	      #��[ 6"   $
��Left=�6F   $��	99,41,0,0q�6a   $	��Top=�6t   $	��270��6�   �� 5
   
   $��
جستجو��6   #��[ 6    $
��Left=�6D   $��	10,82,0,0q�6_   $	��Top=�6r   $��50��6�   �� 5   
   -   5         ��Name$ 	txtSearch��5        TextBoxStyle#��[ 6%   $��65,82,223,0q�6K   $	��Top=�6`   6y   �� 5   
   -   5         ��Name$ BtnPrint��5       � ToolTip$ چاپ��6#   $��35��61   $��	0,82,12,0q�6>   $	��Top=�6Q   $��Right=�6i   $��35��6�   ��5      �� 5       �� ImageSource$7 1/AccountingKernel;component/Themes/icon/Print.png��6   5      �� 5   
   -   5        $ BtnExel��5      $ اکسل��6"   $��35��61   $��	0,82,52,0q�6>   $	��Top=�6Q   $��Right=�6i   $��35��6�   ���	#FF7A7878
���   ���5      �� 5      $7 1/AccountingKernel;component/Themes/icon/Excel.png��6   5      �� 5   
   -   5        $ BtnDel��5      $ حذف��6!   $��35��6/   $��	0,82,92,0q�6<   $	��Top=�6O   $��Right=�6g   $��35��6�   ��5      �� 5      $8 2/AccountingKernel;component/Themes/icon/delete.png��6   5      �� 5   
   -   5        $ BtnEdit��5      $ ویرایش��6"   $��35��63   $��
0,82,132,0q�6?   $	��Top=�6S   $��Right=�6k   $��35��6�   ��5      �� 5      $6 0/AccountingKernel;component/Themes/icon/Edit.png��6   5      �� 5    
   -   5        $ BtnNew��5       $ جدید��6!   $��35��60   $��
0,82,172,0q�6=   $	��Top=�6Q   $��Right=�6i   $��35��6�   
���   ����	#FF7E7E7E��5!      �� 5"      $5 //AccountingKernel;component/Themes/icon/New.png��6   5$      &   System.Windows.Controls.DataGrid  5%   
   -	   5          Name$ grdUnitCount��5%      $��10,124,10,0q�6)      AutoGenerateColumns .    DataGridStyle#��[ 6Z   $	��424��6�   $	��Top=�6�   	 � ContextMenu	 5&      �� 5'      .@�5(      m� -
   5        $��حذف��5(      6,   5)      
   Columns
 5+      4  .System.Windows.Controls.DataGridCheckBoxColumn  5,      ,  &System.Windows.Controls.DataGridColumn   Header$  ��6)      
Visibility$ Hidden=�6O   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   ��  �� Path$ Id�6O     5-      $  ��6)   $ Hidden=�6X    63   �� $ IsAllocated�6X   4  .System.Windows.Controls.DataGridComboBoxColumn  5.      $ واحد فرعی��6)   -   5        cmbSecondUnit��   SelectedValueBinding 5.   T   �� $ SecondUnitId�0  *System.Windows.Controls.DataGridTextColumn  5/      $ 
مقدار��6%    64   �� $ Count2�52      �� 53   
   -   5        $��
تایید��53        ButtonStyleRD#��[ 6!   $��10,555,10,0q�6H   $	��Top=�6]   $��35��6�   55      56      