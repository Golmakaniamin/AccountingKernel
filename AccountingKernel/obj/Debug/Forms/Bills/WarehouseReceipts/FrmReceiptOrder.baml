   M S B A M L   `   `   `  ����U  QPersianDateControls, Version=1.2.5439.35283, Culture=neutral, PublicKeyToken=nullbDclr-namespace:Arash.PersianDateControls;assembly=PersianDateControlsArash.PersianDateControls  5   	   K GAccountingKernel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:WPFAutoCompleteTextboxWPFAutoCompleteTextbox 6j   D   >AccountingKernel.Forms.Bills.WarehouseReceipts.FrmReceiptOrder   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   dPersianDateControlsDclr-namespace:Arash.PersianDateControls;assembly=PersianDateControls     5   	   GWPFAutoCompleteTextbox$clr-namespace:WPFAutoCompleteTextbox     6j   -   5        $	��768��5   	   $
��1024��6      WindowStyle#���   5        � WindowStartupLocation$  CenterScreen=�6'   $��RightToLeft=�6L   .��5	      � $��	0,0,3.6,4q�6   .+�5
   
   �� $��
شماره��6     
LabelStyle#��[ 6    $
��Left=�6D   $��35��6_   $	��Top=�6k   $��87��6�   $��	12,61,0,0q�6�    J� RenderTransformOrigin$ 0.989,2.496&�6�   �� 5   
   -   5         ��Name$ 	txtNumber��5      $
��Left=�6%     TextBoxStyle#��[ 6@   $��RightToLeft=�6f   $��
104,64,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��107��6�   6�   �� 5   
   -   5         ��Name$ 	lblHeader��5   o   $
��Left=�6   $��35��6+   $��
449,10,0,0q�67   $	��Top=�6K   $	��115��6c   6o   �� 5   
   $��نام انبار��6   #��[ 6$   $
��Left=�6H   $��35��6c   $	��Top=�6o   $��42��6�   $��
218,62,0,0q�6�   $ 0.989,2.496&�6�   0  *WPFAutoCompleteTextbox.AutoCompleteTextBox  5   
   -   5          Name$ txtRepository��5   �   $
��Left=�65   $��35��6P   $��
265,61,0,0q�6\   $	��Top=�6p   $��91��6�      	Threshold$ 1��6�   �� 5   
   -   5         ��Name$ btnSelectRepository��5      $	��...��6   $
��Left=�6<   $��35��6W   $��
361,61,0,0q�6c     ButtonStyleRD#��[ 6w   $	��Top=�5      $��44��6   6'   �� 5   
   $
��Left=�6   #��[ 6+   $��35��6O   $��
410,61,0,0q�6[   $	��Top=�6o   $��50��6�   $��نوع رسید��6�   �� 5   
   -   5         ��Name$ cmbOrderType��5      $��35��6*   $��465,61,440.4,0q�66   $	��Top=�6N   $	��115��6f   	 �� DisplayMemberPath$	 
AssignName��6r   
 �� SelectedValuePath$
 Id��6�   �� 5   
   $
��Left=�6   #��[ 6+   $��35��6O   $��
611,64,0,0q�6[   $	��Top=�6o   $��49��6�   $��مبنا دارد��6�   �� 5   
   -   5         ��Name$ chbBase��5      $��35��6%   $��585,66,414.4,0q�61   $	��Top=�6I   $ 0.534,0.647&�6�   �� 5   
   $��نام خریدار��6   #��[ 6%   $
��Left=�6I   $��35��6d   $	��Top=�6p   $��89��6�   $��
10,101,0,0q�6�   $ 0.989,2.496&�6�     5   
   -   5        $ 
txtCompany��5   �   $
��Left=�65   $��35��6P   $��104,102,0,0q�6\   $	��Top=�6q   $	��107��6�   $ 1��6�   �� 5   
   -	   5        $ btnSelectCompany��5      $	��...��6   $
��Left=�69   $��35��6T   $��216,102,0,0q�6`   #��[ 6u   $	��Top=�5      $��44��6   6'   �� 5   
   $
��Left=�6   #��[ 6+   $��35��6O   $��
665,66,0,0q�6[   $	��Top=�6o   $��35��6�   $��برمبنای��6�   �� 5   
   -
   5        $ cmbBase��5      $��35��6%   $��705,66,200.4,0q�61   $	��Top=�6I   $	��115��6a   $	 
AssignName��6m   $
 Id��6�   5      �� 5   
   -   5        $ btnSelectBase��5   '   $��انتخاب مبنا��6   $
��Left=�6>   $��35��6Y   $��
825,66,0,0q�6e   #��[ 6y   $	��Top=�5      $��80��6   6'     5   
   -   5        $ txtBase��5   5   $
��Left=�6F   $��35��6a   $��
910,66,0,0q�6m   $	��Top=�6�   $	��101��6�   $ 1��5       �� 5!   
   $��کد/ نام کالا��6   #��[ 6'   $
��Left=�6K   $��35��6f   $	��Top=�6r   $��80��6�   $��265,105,0,0q�6�   $ 0.989,2.496&�6�     5"   
   -   5        $ txtCommodity��5"   �   0  *WPFAutoCompleteTextbox.AutoCompleteTextBox   	LostFocus$ txtCommodity_LostFocus��5#      $
��Left=�5"   5   $��35��6P   $��350,106,0,0q�6\   $	��Top=�6q   $	��115��6�   $ 1��5#   '   �� 5$   
   $��
تعداد��6   $
��Left=�6    #��[ 6;   $��35��6_   $	��Top=�6k   $��88��6�   $��470,106,0,0q�6�   $ 0.989,2.496&�6�   �� 5%   
   -   5        $ txtCount��5%   �   $
��Left=�6   $��RightToLeft=�6-   #��[ 6I   $��563,106,0,0q�6o   $	��Top=�6�   $	��107��6�   6�   �� 5&   
   $&�� انتخاب واحد شمارش��6   #��[ 6,   $
��Left=�6P   $��35��6k   $	��Top=�6w   $��87��6�   $��675,106,0,0q�6�   $ 0.989,2.496&�6�   �� 5'   
   -   5        $ cmbUnitCount��5'   s   $
��Left=�6   $��35��6.   $��767,106,0,0q�6:   $	��Top=�6O   $	��138��6g   $	 
AssignName��5(      $
 Id��6#   �� 5)   
   $��توضیحات��6   $
��Left=�6"   #��[ 6=   $��35��6a   $	��Top=�6m   $��88��6�   $��
10,141,0,0q�6�   $ 0.989,2.496&�6�   �� 5*   
   -   5        $ 
txtComment��5*   �   $
��Left=�6   #��[ 6-   $��103,146,0,0q�6S   $	��Top=�6h   $	��364��6�   6�   �� 5+   
   $��تاریخ صدور ��6   #��[ 6&   $
��Left=�6J   $��35��6e   $	��Top=�6q   $��86��6�   $��472,146,0,0q�6�   $ 0.989,2.496&�6�   1   +Arash.PersianDateControls.PersianDatePicker  5,   
   -   5          Name$ dtpIssueDate��5,   0   $��35��6F   $
��Left=�6R   $��563,146,0,0q�6m   $	��Top=�6�   $	��107��6�   �� 5-   
   -   5        $ btnRegisterCommodity��5-   �   $��ثبت��6   $
��Left=�6   $��767,146,0,0q�6;   #��[ 6P   $	��Top=�6w   $	��244��6�   6�   &   System.Windows.Controls.DataGrid  5.   
   -   5          Name$ DataGrid��5.      $��10,186,10.4,50q�6%     DataGridStyle#��[ 6r      AutoGenerateColumns .     Columns 50      0  *System.Windows.Controls.DataGridTextColumn  51      ,  &System.Windows.Controls.DataGridColumn   Header$ 
شناسه��6%      
IsReadOnly .    
Visibility$ Hidden=�6F   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6Z   �� *Id+  52      $ درصد تخفیف��6%    .  6K   �� *DiscountPrice+  53      $ قیمت واحد��6%    .  6K   �� *	UnitPrice+  54      $ واحد��6%    .  6F   �� *Unit+  55      $ 
تعداد��6%    .  6G   �� *Count+  56      $ نام کالا��6%    .  6J   �� *CommodityName+  57      $ کد کالا��6%    .  6I   �� *CommodityCode+59      �� 5:   
   -   5        $��ثبت��5:      $��11,0,10.4,10q�6   $��Bottom=�65   #��[ 6j   5=      5>      