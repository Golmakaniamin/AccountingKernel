   M S B A M L   `   `   `  ����U  QPersianDateControls, Version=1.2.5439.35283, Culture=neutral, PublicKeyToken=nullbDclr-namespace:Arash.PersianDateControls;assembly=PersianDateControlsArash.PersianDateControls  5   	   K GAccountingKernel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:WPFAutoCompleteTextboxWPFAutoCompleteTextbox 6j   C   =AccountingKernel.Forms.Bills.ReturnOfBuying.FrmReturnOfBuying   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   dPersianDateControlsDclr-namespace:Arash.PersianDateControls;assembly=PersianDateControls     5   	   GWPFAutoCompleteTextbox$clr-namespace:WPFAutoCompleteTextbox     6j   -   5        $	��768��5   �   $
��1024��6�     � WindowStartupLocation$  CenterScreen=�6�      WindowStyle#���   6�   $��RightToLeft=�6   � Title$2 ,ثبت فاکتور برگشت از خرید��5   	   .��5      � $��	0,0,3.6,4q�6   .+�5   
   ��   
LabelStyle#��[ 6   $��44,47,920.4,0q�64   $	��Top=�6K   $��مبنا دارد��6c   �� 5   
   -   5         ��Name$ chbBase��5      $��35��6$   $��23,57,978.4,0q�60   $	��Top=�6G   6y   �� 5	   
   $��نام خریدار��6   #��[ 6%   $	��Top=�6I   $��26,99,935.4,0q�6a    J� RenderTransformOrigin$ 0.989,2.496&�6x   0  *WPFAutoCompleteTextbox.AutoCompleteTextBox  5
   
   -   5          Name$ 
txtCompany��5
   ~   $��35��65   $��90,101,823.4,0q�6A   $	��Top=�6Y   $
��Auto��6q      	Threshold$ 1��6�   �� 5   
   #��[ 6   $��107,47,857.4,0q�65   $	��Top=�6M   $��برمبنای��6e   �� 5   
   -   5         ��Name$ cmbBase��5      $��35��6$   $��172,47,733.4,0q�60   $	��Top=�6H   $	��115��6`    �� DisplayMemberPath$ 
AssignName��6l    �� SelectedValuePath$ Id��6�   6�   �� 5   
   -   5        	 ��Name$	 btnSelectBase��5   '   $��انتخاب مبنا��6   $��491,50,450.4,0q�6>     ButtonStyleRD#��[ 6V   $	��Top=�6}   6�     5   
   -   5        $ txtBase��5   5   0  *WPFAutoCompleteTextbox.AutoCompleteTextBox
   	LostFocus$
 txtBase_LostFocus��6�   $��35��6F   $��575,50,309.4,0q�6R   $	��Top=�6j   $
��Auto��6�   $ 1��6�   6�   �� 5   
   -   5        $	 btnSelectCommodity��5   x   $	��...��6   $��400,101,567.4,0q�6    #��[ 69   $	��Top=�6`   6�     5   
   -   5        $ txtCommodity��5      $
 txtCommodity_LostFocus��6�   $��35��65   $��279,101,625.4,0q�6A   $	��Top=�6Z   $
��Auto��6r   $ 1��6�   �� 5   
   $��
تعداد��6   $
��Left=�6    #��[ 6;   $	��Top=�6_   $��81��6w   $��491,101,0,0q�6�   $ 0.989,2.496&�6�   �� 5   
   -	   5         ��Name$ txtCount��5   i     TextBoxStyle#��[ 6   $��577,101,309.4,0q�68   $	��Top=�6Q   6�   �� 5   
   $&�� انتخاب واحد شمارش��6   #��[ 6,   $
��Left=�6P   $	��Top=�6k   $	��114��6�   $��
745,93,0,0q�6�   $ 0.989,2.496&�6�   �� 5   
   -
   5        $ cmbUnitCount��5   r   $
��Left=�6   $��35��6.   $��
866,95,0,0q�6:   $	��Top=�6N   $	��144��6f   $ 
AssignName��6�   $ Id��6�   �� 5   
   $��توضیحات��6   $	��Top=�6"   $��26,154,934.4,0q�6:   $ 0.989,2.496&�6R   �� 5   
   -   5        $ 
txtComment��5   d   #��[ 6   $��
91,154,0,0q�68   $	��Top=�6L   $
��Left=�6x   $	��358��6�   �� 5   
   $��تاریخ صدور ��6   #��[ 6&   $
��Left=�6J   $	��Top=�6e   $��81��6}   $��491,152,0,0q�6�   $ 0.989,2.496&�6�   1   +Arash.PersianDateControls.PersianDatePicker  5   
   -   5          Name$ dtpIssueDate��5   0   $
��Left=�6F   $��579,153,0,0q�6a   $	��Top=�6v   $	��134��6�   $��35��6�   �� 5   
   -   5        $	 btnRegisterCommodity��5   �   $��ثبت��6   $
��Left=�6   $��866,154,0,0q�6:   #��[ 6O   $	��Top=�6v   $	��144��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ DataGrid��5      $��10,214,10.4,54q�6%     DataGridStyle#��[ 6r      AutoGenerateColumns .   � ContextMenu 5      �� 5      .@�5      m� -   5        $��حذف��5      6[   5         Columns 5       0  *System.Windows.Controls.DataGridTextColumn  5!      ,  &System.Windows.Controls.DataGridColumn   Header$ 
شناسه��6%      
IsReadOnly .    
Visibility$ Hidden=�6F   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6Z   �� *Id+  5"      $ قیمت واحد��6%    .  6K   �� *	UnitPrice+  5#      $ واحد��6%    .  6F   �� *Unit+  5$      $ 
تعداد��6%    .  6G   �� *Count+  5%      $ نام کالا��6%    .  6J   �� *CommodityName+  5&      $ کد کالا��6%    .  6I   �� *CommodityCode+5(      �� 5)   
   -   5        $��ثبت��5)      $��
10,0,10,10q�6   $��Bottom=�63   #��[ 6h   �� 5*   
   $��انتخاب کالا��6   #��[ 6&   $
��Left=�6J   $��
202,99,0,0q�6e   $	��Top=�6y   $��72��6�   5,      5-      