   M S B A M L   `   `   `  ����U  QPersianDateControls, Version=1.2.5439.35283, Culture=neutral, PublicKeyToken=nullbDclr-namespace:Arash.PersianDateControls;assembly=PersianDateControlsArash.PersianDateControls  5   	   K GAccountingKernel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:WPFAutoCompleteTextboxWPFAutoCompleteTextbox 6j   1   +AccountingKernel.Forms.Bills.Order.FrmOrder   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   dPersianDateControlsDclr-namespace:Arash.PersianDateControls;assembly=PersianDateControls     5   	   GWPFAutoCompleteTextbox$clr-namespace:WPFAutoCompleteTextbox     6j   -   5        $	��768��5   	   $
��1024��6     � WindowStartupLocation$  CenterScreen=�6#   $��RightToLeft=�6H      WindowStyle#���   6}   .��5      � .+�5	   
   �� $��نام انبار��6     
LabelStyle#��[ 6$   $
��Left=�6H   $��35��6c   $	��Top=�6o   $	��100��6�   $��	10,60,0,0q�6�    J� RenderTransformOrigin$ 0.989,2.496&�6�   0  *WPFAutoCompleteTextbox.AutoCompleteTextBox  5
   
   -   5          Name$ txtRepository��5
   �   0  *WPFAutoCompleteTextbox.AutoCompleteTextBox   PreviewTextInput$$ txtRepository_PreviewTextInput��6�   $
��Left=�65   $��35��6P   $��
115,60,0,0q�6\   $	��Top=�6p   $	��107��6�      	Threshold$ 1��6�   6�   �� 5   
   $
��Left=�6   $��35��6+   $��
227,60,0,0q�67   #��[ 6K   $	��Top=�6o   $��61��6�   $��نوع حواله��6�   �� 5   
   -   5         ��Name$ cmbOrderType��5      $��35��6*   $��293,59,577,0q�66   $	��Top=�6L    �� DisplayMemberPath$ 
AssignName��6d    �� SelectedValuePath$ Id��6�   �� 5   
   $
��Left=�6   $��35��6+   $��
488,59,0,0q�67   $	��Top=�6K   $��50��6c   #��[ 6n   $��مبنا دارد��6�   �� 5   
   -   5         ��Name$ chbBase��5      $��35��6%   $��452,60,541,0q�61   $	��Top=�6G   6y   �� 5   
   $��نام خریدار��6   $
��Left=�6%   $��35��6@   #��[ 6L   $	��Top=�6p   $	��100��6�   $��
10,114,0,0q�6�   $ 0.989,2.496&�6�     5   
   -   5        $ 
txtCompany��5   �   $! txtCompany_PreviewTextInput��6�   $
��Left=�65   $��35��6Q   $��115,114,0,0q�6]   $	��Top=�6r   $	��107��6�   $ 1��6�   6�   �� 5   
   -   5        	 ��Name$	 btnSelectCommodity��5   �   $	��...��6   $
��Left=�6     ButtonStyleRD#��[ 6:   $��405,114,0,0q�6a   $	��Top=�6v   $��42��6�   6�   �� 5   
   $
��Left=�6   $��35��6+   $��
552,59,0,0q�67   $	��Top=�6K   $��67��6c   #��[ 6n   $��برمبنای��6�   �� 5   
   -   5        $ cmbBase��5      $��35��6%   $��624,59,306,0q�61   $	��Top=�6G   $ 
AssignName��6_   $ Id��6~   5      �� 5   
   -   5        $	 btnSelectBase��5   '   $��انتخاب مبنا��6   $
��Left=�6>   $��35��6Y   $��
723,60,0,0q�6e   #��[ 6y   $	��Top=�5      $��90��6   6'     5   
   -	   5        $ txtBase��5   5   $
��Left=�6F   $��35��6a   $��
818,59,0,0q�6n   $	��Top=�6�   $	��130��6�   $ 1��5        5   
   -
   5        $ txtCommodity��5   �   
   	LostFocus$
 txtCommodity_LostFocus��5      $
��Left=�5   5   $��35��6P   $��293,114,0,0q�6]   $	��Top=�6r   $	��107��6�   $ 1��5   '   �� 5   
   $��
تعداد��6   #��[ 6    $
��Left=�6D   $��35��6_   $	��Top=�6k   $��86��6�   $��452,114,0,0q�6�   $ 0.989,2.496&�6�   �� 5   
   $&�� انتخاب واحد شمارش��6   #��[ 6,   $
��Left=�6P   $��35��6k   $	��Top=�6w   $	��100��6�   $��713,114,0,0q�6�   $ 0.989,2.496&�6�   �� 5   
   -   5        $ cmbUnitCount��5   s   $
��Left=�6   $��35��6.   $��818,114,0,0q�6:   $	��Top=�6O   $	��130��6g   $ 
AssignName��5       $ Id��6#   �� 5!   
   $��توضیحات��6   $
��Left=�6"   #��[ 6=   $��35��6a   $	��Top=�6m   $	��100��6�   $��
10,173,0,0q�6�   �� 5"   
   -   5         ��Name$ 
txtComment��5"   �   $
��Left=�6     TextBoxStyle#��[ 6-   $��35��6S   $��115,173,0,0q�6_   $	��Top=�6t   $	��335��6�   6�   �� 5#   
   $��تاریخ صدور ��6   #��[ 6&   $
��Left=�6J   $��35��6e   $	��Top=�6q   $��83��6�   $��455,173,0,0q�6�   1   +Arash.PersianDateControls.PersianDatePicker  5$   
   -   5          Name$ dtpIssueDate��5$   0   $
��Left=�6F   $��543,173,0,0q�6a   $	��Top=�6v   $	��120��6�   $��35��6�   �� 5%   
   -   5        $	 btnRegisterCommodity��5%   �   $��ثبت��6   $
��Left=�6   $��35��6:   #��[ 6F   $��818,170,0,0q�6m   $	��Top=�6�   $	��130��6�   6�   &   System.Windows.Controls.DataGrid  5'   
   -   5          Name$ DataGrid��5'      $��10,213,10,50q�6%      AutoGenerateColumns .    DataGridStyle#��[ 6�      Columns 5(      0  *System.Windows.Controls.DataGridTextColumn  5)      ,  &System.Windows.Controls.DataGridColumn   Header$ 
شناسه��6%      
IsReadOnly .    
Visibility$ Hidden=�6F   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6Z   �� *Id+  5*      $ درصد تخفیف��6%    .  6K   �� *DiscountPrice+ �� StringFormat$ N0��  5+      $ قیمت واحد��6%    .  6K   �� *	UnitPrice+$ N0��  5,      $ واحد��6%    .  6F   �� *Unit+  5-      $ 
تعداد��6%    .  6G   �� *Count+  5.      $ نام کالا��6%    .  6J   �� *CommodityName+  5/      $ کد کالا��6%    .  6I   �� *CommodityCode+51      �� 52   
   -   5        $��ثبت��52      $��35��6   $��
10,0,10,10q�6+   #��[ 6?   $��Bottom=�6f   6�   �� 53   
   -   5        $ txtCount��53      $
��Left=�6$   #��[ 6?   $��543,114,0,0q�6e    �� TextWrapping$
 Wrap=�6z   $	��Top=�6�   $	��120��6�   $��35��6�   6�   �� 54   
   $��انتخاب کالا��6   $
��Left=�6&   $��227,114,0,0q�6A   $	��Top=�6V   #��[ 6n   $��RightToLeft=�6�   57      58      