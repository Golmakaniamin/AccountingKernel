   M S B A M L   `   `   `  ����U  QPersianDateControls, Version=1.2.5439.35283, Culture=neutral, PublicKeyToken=nullbDclr-namespace:Arash.PersianDateControls;assembly=PersianDateControlsArash.PersianDateControls  5   	   K GAccountingKernel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:WPFAutoCompleteTextboxWPFAutoCompleteTextbox 6j   :   4AccountingKernel.Forms.KazaneDari.frm_tarife_daryaft   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   dPersianDateControlsDclr-namespace:Arash.PersianDateControls;assembly=PersianDateControls     5   	   GWPFAutoCompleteTextbox$clr-namespace:WPFAutoCompleteTextbox     6j     � Title$  frm_tarife_daryaft��5   	      WindowStyle#���   6$   $	��768��6J   $
��1024��6W    � WindowStartupLocation$ CenterScreen=�6d   $��RightToLeft=�6�   .��5      � .+�5   	   �� -   5         ��Name$ btnRegDetail��5      $��ثبت��6&     ButtonStyleRD#��[ 64   $��10,271,10,0q�6[   $	��Top=�6p   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ grdTreasuryDetails��5      $��10,311,10,50q�6/     DataGridStyle#��[ 6E      AutoGenerateColumns .   � ContextMenu 5	      �� 5
      .@�5      m� -   5        $��Menu_Delete��5      $��حذف��62   6?   5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   
Visibility$ Hidden=�6A      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6%   �� 
 �� Path$
 ID�6U     5         Header$ نوع��6%    . 	 62   �� $
 
AssignName�6V     5      $ شرح��6%    . 	 62   �� $
 TDescription�6X     5      $ شماره حساب��6%    . 	 69   �� $
 Accountnumber�6`     5      $ تاریخ سررسید��6%    . 	 6;   �� $
 TDate�6[     5      $ مبلغ��6%    . 	 63   �� $
 TDPrice�6T   5      �� 5   
   -   5        $ btnRegTreasury��5      #��[ 6)   $��ثبت��6P   $��
10,0,10,10q�6^   $��Bottom=�6r   6�   �� 5   
   $,��&اطلاعات دریافت کننده��6   $	��Top=�61   $��71��6I   $��
10,43,10,0q�6U   .��5      � .+�5      �� $��
شماره��6   $
��Left=�6(   $��	10,10,0,0q�6C   $	��Top=�6V     
LabelStyle#��[ 6n   $��57��6�   �� 5      -   5         ��Name$ txtNo��5      $
��Left=�6)     TextBoxStyle#��[ 6D   $��	72,10,0,0q�6j    �� TextWrapping$
 Wrap=�6}   $	��Top=�6�   $	��116��6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   {�.  6�   �� 5      $��
تاریخ��6   #��[ 6(   $
��Left=�6L   $��
193,10,0,0q�6g   $	��Top=�6{   $��50��6�   1   +Arash.PersianDateControls.PersianDatePicker  5      -   5          Name$ dtpDate��5   8   $
��Left=�6I   $��
248,10,0,0q�6d   $	��Top=�6x   $��35��6�   $	��116��6�   �� 5      $+��%کد دریافت کننده مبلغ��6   #��[ 67   $
��Left=�6[   $��
369,10,0,0q�6v   $	��Top=�6�   $��36��6�   $	��114��6�   0  *WPFAutoCompleteTextbox.AutoCompleteTextBox  5      -   5          Name$ 
txtReciver��5   =   0  *WPFAutoCompleteTextbox.AutoCompleteTextBox   PreviewTextInput$% txtRecivePlace_PreviewTextInput��6�   $
��Left=�6Q   $��36��6l   $��
488,10,0,0q�6x   $	��Top=�6�   $	��105��6�   6�   �� 5       -   5        $ btnReciverCode��5       $��انتخاب کد��61   $
��Left=�6E   $��
598,10,0,0q�6`   #��[ 6t   $	��Top=�6�   $��59��6�   �� 5!      $��شرح ��6   $
��Left=�6'   $��
593,53,0,0q�6B   $	��Top=�6V   #��[ 6n   $��44��6�   �� 5"      -	   5        $ txtTreasuryDescription��5"      #��[ 6:   $��662,10,202,0q�6`   $
 Wrap=�6v   $	��Top=�6�   6�   �� 5#      $��نوع دریافت��6   $
��Left=�6-   $��
795,10,0,0q�6H   $	��Top=�6\   #��[ 6t   $��58��6�   �� 5$      -
   5         ��Name$ cmb_noe_daryaft��5$      $
��Left=�64   $��
858,10,0,0q�6O   $	��Top=�6c   $	��124��6{   $��35��6�    �� DisplayMemberPath$ 
AssignName��6�    �� SelectedValuePath$ Id��6�   6�   5&      5'      �� 5(      $��اطلاعات سند��6   $	��Top=�6-   $��71��6E   $��10,119,10,0q�6Q   .��5)      � .+�5*      �� $��دریافت از��6   #��[ 6,   $
��Left=�6P   $��	10,10,0,0q�6k   $	��Top=�6~   $��36��6�   $��46��6�   �� 5+      -   5        $ txtRecivePlace��5+      $
��Left=�62   $��	61,10,0,0q�6M   $
 Wrap=�6`   $	��Top=�6t   $	��131��6�   #��[ 6�   $��36��6�   �� 5,      -   5        $ btnRecivePlace��5,      $��انتخاب کد��61   #��[ 6E   $
��Left=�6l   $��
197,10,0,0q�6�   $	��Top=�6�   $	��100��6�   6�   �� 5-      $��مبلغ��6   $
��Left=�6'   #��[ 6B   $��
302,93,0,0q�6f   $	��Top=�6z   $��58��6�   �� 5.      -   5        $ txtPrice��5.      $
��Left=�6,   $��
302,10,0,0q�6G   $
 Wrap=�6[   $	��Top=�6o   $	��123��6�   #��[ 6�   $��RightToLeft=�6�   �� 5/      $��شرح��6   $
��Left=�6&   #��[ 6A   $��
430,11,0,0q�6e   $	��Top=�6y   $��44��6�   �� 50      -   5        $ txtCashDescription��50      #��[ 66   $��479,10,10,0q�6\   $
 Wrap=�6q   $	��Top=�6�   $��35��6�   51      52      �� 53   
   $��اطلاعات چک��6   $	��Top=�6'   $��71��6?   $��10,195,10,0q�6K   .��54      � .+�55      �� $��شماره چک��6   #��[ 6+   $
��Left=�6O   $��	10,10,0,0q�6j   $	��Top=�6}   $ 	1.098,0.5&�6�   $��50��6�   �� 56      -   5        $ txtNumCheque��56      #��[ 60   $
��Left=�6V   $��35��6q   $��	65,10,0,0q�6}   $	��Top=�6�   $��97��6�   6�   �� 57      $��نام بانک��6   #��[ 6+   $
��Left=�6O   $��
167,10,0,0q�6j   $	��Top=�6~   $ 	1.098,0.5&�6�   $��38��6�     58      -   5        $ txtBankName��58   =   $
��Left=�6R   $��35��6m   $��
210,10,0,0q�6y   $	��Top=�6�   $��83��6�   �� 59      $��کد شعبه��6   #��[ 6*   $
��Left=�6N   $��
298,11,0,0q�6i   $	��Top=�6}   $ 	1.098,0.5&�6�   $��57��6�     5:      -   5        $ txtBankBranchCode��5:   =   $  txtCheque_PreviewTextInput��6�   $
��Left=�6X   $��35��6s   $��
360,10,0,0q�6   $	��Top=�6�   $��92��6�   6�   �� 5;      $��تاریخ سررسید��6   #��[ 6/   $
��Left=�6S   $��
457,10,0,0q�6n   $	��Top=�6�   $��68��6�     5<      -   5        $ dtpChequeDate��5<   8   $
��Left=�6O   $��
530,10,0,0q�6j   $	��Top=�6~   $��35��6�   $��95��6�   �� 5=      $��مبلغ��6   $
��Left=�6'   #��[ 6B   $��
630,10,0,0q�6f   $	��Top=�6z   $��35��6�   �� 5>      -   5        $ txtChequePrice��5>      $
��Left=�62   $��
670,10,0,0q�6M   $
 Wrap=�6a   $	��Top=�6u   $��91��6�   #��[ 6�   $��RightToLeft=�6�   6  �� 5?      $��شرح��6   $
��Left=�6&   #��[ 6A   $��
766,10,0,0q�6e   $	��Top=�6y   $��27��6�   �� 5@      -   5        $ txtChequeDescription��5@      #��[ 68   $��
798,10,8,0q�6^   $
 Wrap=�6r   $	��Top=�6�   $��35��6�   5A      5B      5C      5D      