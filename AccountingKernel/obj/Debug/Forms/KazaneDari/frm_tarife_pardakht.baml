   M S B A M L   `   `   `  ����K  GAccountingKernel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:WPFAutoCompleteTextboxWPFAutoCompleteTextbox  5   	   U QPersianDateControls, Version=1.2.5439.35283, Culture=neutral, PublicKeyToken=nullbDclr-namespace:Arash.PersianDateControls;assembly=PersianDateControlsArash.PersianDateControls 6M   ;    5AccountingKernel.Forms.KazaneDari.frm_tarife_pardakht   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   GWPFAutoCompleteTextbox$clr-namespace:WPFAutoCompleteTextbox     5   	   dPersianDateControlsDclr-namespace:Arash.PersianDateControls;assembly=PersianDateControls     6M     � Title$  frm_tarife_pardakht��5   	      WindowStyle#���   6%   $	��768��6K   $
��1024��6X    � WindowStartupLocation$ CenterScreen=�6e   $��RightToLeft=�6�   .��5      � .+�5   
   �� $!��اطلاعات پرداخت��6   $	��Top=�6+   $	��116��6C   $��
10,39,10,0q�6P   .��5      � .+�5	      �� $��
شماره��6   $
��Left=�6(   $��	10,10,0,0q�6C   $	��Top=�6V     
LabelStyle#��[ 6n   $��49��6�   �� 5
      -   5         ��Name$ txtNo��5
      $
��Left=�6)     TextBoxStyle#��[ 6D   $��	64,10,0,0q�6j    �� TextWrapping$
 Wrap=�6}   $	��Top=�6�   $	��120��6�   {�.  6�   �� 5      $��
تاریخ��6   $
��Left=�6(   $��
189,10,0,0q�6C   $	��Top=�6W   #��[ 6o   $��49��6�   1  +Arash.PersianDateControls.PersianDatePicker  5      -   5          Name$ dtpDate��5   8   $
��Left=�6I   $��	243,9,0,0q�6d   $	��Top=�6w   $��35��6�   $	��120��6�   �� 5      $"��کد دریافت کننده��6   $
��Left=�62   $��
368,10,0,0q�6M   $	��Top=�6a   #��[ 6y   $��72��6�   0   *WPFAutoCompleteTextbox.AutoCompleteTextBox  5      0   *WPFAutoCompleteTextbox.AutoCompleteTextBox   PreviewTextInput$% txtRecivePlace_PreviewTextInput��6�   $
��Left=�6=   $��35��6X   $��
445,10,0,0q�6d   $	��Top=�6x   $	��141��6�   6�   �� 5      $��نوع پرداخت��6   $
��Left=�6-   $��
751,10,0,0q�6H   $	��Top=�6\   #��[ 6t   $��76��6�   �� 5      -   5         ��Name$ cmb_noe_daryaft��5      $��832,10,10,0q�64   $	��Top=�6I    �� DisplayMemberPath$ 
AssignName��6a    �� SelectedValuePath$ Id��6�   $��35��6�   �� 5      -   5        	 ��Name$	 btnPaymentFrom��5      $��انتخاب کد��61   $
��Left=�6E     ButtonStyleRD#��[ 6`   $��
591,10,0,0q�6�   $	��Top=�6�   $��83��6�   �� 5      $��مبلغ��6   $
��Left=�6'   $��
277,49,0,0q�6B   $	��Top=�6V   #��[ 6n   $��35��6�   �� 5      -   5        $ txtPrice��5      #��[ 6,   $��RightToLeft=�6R   $
��Left=�6n   $��
317,50,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��120��6�   6  �� 5      $��شرح��6   $
��Left=�6&   $��
442,50,0,0q�6A   $	��Top=�6U   #��[ 6m   $��45��6�   �� 5      -   5        $ txtDetailDescrition��5      #��[ 67   $��35��6]   $��492,50,10,0q�6i   $
 Wrap=�6~   $	��Top=�6�   �� 5      $��پرداخت از��6   $
��Left=�6,   $��	10,50,0,0q�6G   $	��Top=�6Z   #��[ 6r   $��49��6�   �� 5      -   5        $ txtPaymentFrom��5      $
��Left=�62   #��[ 6M   $��	64,50,0,0q�6s   $
 Wrap=�6�   $	��Top=�6�   $	��120��6�   6�   �� 5      -   5        $	 btnRecivePlace��5      $��انتخاب کد��61   #��[ 6E   $
��Left=�6l   $��
189,50,0,0q�6�   $	��Top=�6�   $��83��6�   6�   5      5      �� 5   
   $��اطلاعات چک��6   $	��Top=�6'   $��77��6?   $��10,160,10,0q�6K   .��5      � $��	0,0,0,-12q�6   .+�5      �� $��شماره چک��6   $
��Left=�6+   $��	10,10,0,0q�6F   $	��Top=�6Y   #��[ 6q   $��50��6�     5      -	   5        
  Name$
 	txtCheque��5   =      	LostFocus$ txtCheque_LostFocus��6�   $  txtCheque_PreviewTextInput��6�   $
��Left=�6P   $��35��6k   $��	65,10,0,0q�6w   $	��Top=�6�   $	��120��6�   6�   �� 5      -
   5        $	 btnSelectCheque��5      $��انتخاب چک��62   #��[ 6F   $
��Left=�6m   $��
190,10,0,0q�6�   $	��Top=�6�   $��90��6�   $��35��6�   6�   �� 5       $��تاریخ سررسید��6   $
��Left=�6/   $��
285,10,0,0q�6J   $	��Top=�6^   #��[ 6v   $��75��6�     5!      -   5        $ dtpChequeDate��5!   8   $
��Left=�6O   $��
365,10,0,0q�6j   $	��Top=�6~   $��35��6�   $	��120��6�   �� 5"      $��مبلغ��6   $
��Left=�6'   $��
490,10,0,0q�6B   $	��Top=�6V   #��[ 6n   $��30��6�   �� 5#      -   5        $ txtChequePrice��5#      #��[ 62   $��RightToLeft=�6X   $
��Left=�6t   $��
525,10,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��120��6�   6  �� 5$      $��شرح��6   $
��Left=�6&   $��
650,10,0,0q�6A   $	��Top=�6U   #��[ 6m   $��38��6�   �� 5%      -   5        $ txtChequeDetailDescrition��5%      #��[ 6=   $��35��6c   $��693,10,10,0q�6o   $
 Wrap=�6�   $	��Top=�6�   5&      5'      �� 5(   
   -   5        $	 btnRegDetail��5(      $��ثبت��6'   #��[ 65   $��10,242,10,0q�6\   $	��Top=�6q   6�   &   System.Windows.Controls.DataGrid  5)   
   -   5          Name$ grdTreasuryDetails��5)        DataGridStyle#��[ 6/   $��10,282,10,94q�6V      AutoGenerateColumns .   � ContextMenu 5*      �� 5+      .@�5,      m� -   5        $��حذف��5,      6,   5-         Columns 5/      0  *System.Windows.Controls.DataGridTextColumn  50      ,  &System.Windows.Controls.DataGridColumn   
Visibility$ Hidden=�6<      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *ID+6P     51         Header$ نوع��6%    .  62   �� *
AssignName+6Q     52      $ شرح��6%    .  62   �� *TDDescription+6T     53      $ شماره حساب��6%    .  69   �� *Accountnumber+6\     54      $ تاریخ سررسید��6%    .  6;   �� *TDate+6V     55      $ مبلغ��6%    .  63   �� *	TDPrice+6O   57      �� 58      $��شرح ��6   $
��Left=�6    $��
12,679,0,0q�6;   $	��Top=�6O   #��[ 6g   �� 59   
   -   5        $ txtTreasuryDescription��59      #��[ 62   $��40,679,10,0q�6X   $
 Wrap=�6m   $	��Top=�6�   6�   �� 5:   
   -   5        $	 btnRegTreasury��5:      $��ثبت��6)   #��[ 67   $��
10,0,10,10q�6^   $��Bottom=�6r   6�   5;      5<      