   M S B A M L   `   `   `  ����  AccountingKernel1    +AccountingKernel.Forms.Company.frmCompanies   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Document��5   	   $	��600��6   $	��800��6'      WindowStyle#���   63    � WindowStartupLocation$ CenterScreen=�6Y   $��tohama)�6~   $��14(�6�   $
��Bold"�6�   $��RightToLeft=�6�   .��5      � .+�5   
   �� $��
جستجو��6   $
��Left=�6      
LabelStyle#��[ 6;   $��	10,10,0,0q�6_   $	��Top=�6r   $��50��6�   �� 5   
   -   5         ��Name$ 	txtSearch��5        TextBoxStyle#��[ 6%   $��65,10,215,0q�6K   $	��Top=�6`   6x   �� 5   
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
   -   5          Name$ 
grdCompany��5!      $��
10,50,10,0q�6'      AutoGenerateColumns .    DataGridStyle#��[ 6W      
IsReadOnly . $	��500��5"   T   $	��Top=�6a   	   Columns	 5#      0  *System.Windows.Controls.DataGridTextColumn  5$      ,  &System.Windows.Controls.DataGridColumn
   
Visibility$
 Hidden=�6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   ��  �� Path$ Id�  5%         Header$ نام��6%      
IsReadOnly .   6F   �� $
 Name�  5&      $ نوع��6%    .   6F   �� $
 Type�  5'      $! شماره ثبتی/ ملی��6%    .   6R   �� $ RegNationalCode�  5(      $ کد اقتصادی��6%    .   6M   �� $ EconomyCode� � ContextMenu 5*      �� 5+      .@�5,      m� $��عملیات��6   .@�5-      m� -   5        $��جدید��5-   #   61   m� 5.      -	   5        $��ویرایش��5.   #   63   m� 5/      -
   5        $��حذف��5/   #   60   50      51      54      �� 55   
   -   5        $��انتخاب��55        ButtonStyleRD#��[ 6"   $��
10,0,10,10q�6I   $��Bottom=�6]   6x   57      59      