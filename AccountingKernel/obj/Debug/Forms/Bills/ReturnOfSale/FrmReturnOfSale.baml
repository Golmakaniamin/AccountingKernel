   M S B A M L   `   `   `  ����U  QPersianDateControls, Version=1.2.5439.35283, Culture=neutral, PublicKeyToken=nullbDclr-namespace:Arash.PersianDateControls;assembly=PersianDateControlsArash.PersianDateControls  5   	   K GAccountingKernel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:WPFAutoCompleteTextboxWPFAutoCompleteTextbox 6j   ?   9AccountingKernel.Forms.Bills.ReturnOfSale.FrmReturnOfSale   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   dPersianDateControlsDclr-namespace:Arash.PersianDateControls;assembly=PersianDateControls     5   	   GWPFAutoCompleteTextbox$clr-namespace:WPFAutoCompleteTextbox     6j   -   5        $	��768��5   	   $
��1024��6     � WindowStartupLocation$  CenterScreen=�6#   $��RightToLeft=�6H    � Title$2 ,ثبت فاکتور برگشت از فروش��6}      WindowStyle#���   6�   .��5      � $��	0,0,3.6,4q�6   .+�5   
   �� -   5         ��Name$ 	lblHeader��5   �   $
��Left=�6   $��35��6+     
LabelStyle#��[ 67   $��
458,27,0,0q�6[   $	��Top=�6o   $	��115��6�   6�   �� 5	   
   $
��Left=�6   #��[ 6+   $��35��6O   $��	10,63,0,0q�6[   $	��Top=�6n   $��74��6�   $��نوع حواله��6�   �� 5
   
   -   5         ��Name$ cmbOrderType��5
      $��35��6*   $��89,63,816.4,0q�66   $	��Top=�6M   $	��115��6e    �� DisplayMemberPath$ 
AssignName��6q    �� SelectedValuePath$ Id��6�   �� 5   
   $
��Left=�6   #��[ 6+   $��35��6O   $��
249,63,0,0q�6[   $	��Top=�6o   $��56��6�   $��مبنا دارد��6�   �� 5   
   -   5         ��Name$ chbBase��5      $��13��6%   $��235,74,772.4,0q�61   $	��Top=�6I   6{   �� 5   
   $��نام خریدار��6   #��[ 6%   $
��Left=�6I   $��35��6d   $	��Top=�6p   $��75��6�   $��
10,103,0,0q�6�    J� RenderTransformOrigin$ 0.989,2.496&�6�   0  *WPFAutoCompleteTextbox.AutoCompleteTextBox  5   
   -   5          Name$ 
txtCompany��5   �   $
��Left=�65   $��35��6P   $��
90,103,0,0q�6\   $	��Top=�6p   $	��114��6�   	   	Threshold$	 1��6�   �� 5   
   $
��Left=�6   #��[ 6+   $��35��6O   $��
349,63,0,0q�6[   $	��Top=�6o   $��47��6�   $��برمبنای��6�   �� 5   
   -   5        $ cmbBase��5      $��35��6%   $��401,63,504.4,0q�61   $	��Top=�6I   $	��115��6a   $ 
AssignName��6m   $ Id��6�   5      �� 5   
   -   5        
 ��Name$
 btnSelectBase��5   '   $��انتخاب مبنا��6   $
��Left=�6>   $��
521,59,0,0q�6Y     ButtonStyleRD#��[ 6m   $	��Top=�5      $��80��6)   64     5   
   -   5        $ txtBase��5   5   0  *WPFAutoCompleteTextbox.AutoCompleteTextBox   	LostFocus$ txtBase_LostFocus��5   C   $
��Left=�5   F   $��35��6a   $��
606,59,0,0q�6m   $	��Top=�6�   $	��109��6�   $	 1��5   5   6C   �� 5   
   $��کد/ نام کالا��6   #��[ 6'   $
��Left=�6K   $��35��6f   $	��Top=�6r   $��67��6�   $��209,103,0,0q�6�   $ 0.989,2.496&�6�     5   
   -	   5        $ txtCommodity��5   �   $ txtCommodity_LostFocus��5   4   $
��Left=�5   5   $��35��6P   $��281,103,0,0q�6\   $	��Top=�6q   $	��115��6�   $	 1��5   W   �� 5   
   $��
تعداد��6   #��[ 6    $
��Left=�6D   $��35��6_   $	��Top=�6k   $��46��6�   $��401,103,0,0q�6�   $ 0.989,2.496&�6�   �� 5   
   -
   5         ��Name$ txtCount��5   �   $
��Left=�6   $��452,103,0,0q�6-     TextBoxStyle#��[ 6B   $	��Top=�6h   $	��148��6�   6�   �� 5   
   $&�� انتخاب واحد شمارش��6   #��[ 6,   $
��Left=�6P   $��35��6k   $	��Top=�6w   $	��111��6�   $��605,103,0,0q�6�   $ 0.989,2.496&�6�   �� 5   
   -   5        $ cmbUnitCount��5   s   $
��Left=�6   $��35��6.   $��721,103,0,0q�6:   $	��Top=�6O   $	��130��6g   $ 
AssignName��5   
   $ Id��6)   �� 5    
   $��توضیحات��6   #��[ 6"   $
��Left=�6F   $��35��6a   $	��Top=�6m   $��75��6�   $��
10,143,0,0q�6�   $ 0.989,2.496&�6�   �� 5!   
   -   5        $ 
txtComment��5!   �   $
��Left=�6   $��
90,143,0,0q�6-   #��[ 6A   $	��Top=�6g   $	��510��6   6�   �� 5"   
   $��تاریخ صدور ��6   #��[ 6&   $
��Left=�6J   $��35��6e   $	��Top=�6q   $	��110��6�   $��605,143,0,0q�6�   $ 0.989,2.496&�6�   1   +Arash.PersianDateControls.PersianDatePicker  5#   
   -   5          Name$ dtpIssueDate��5#   0   $
��Left=�6F   $��720,143,0,0q�6a   $	��Top=�6v   $	��131��6�   $��35��6�   �� 5$   
   -   5        $
 btnRegisterCommodity��5$   �   $��ثبت��6   $
��Left=�6   #��[ 6:   $��856,140,0,0q�6a   $	��Top=�6v   $	��154��6�   6�   &   System.Windows.Controls.DataGrid  5&   
   -   5          Name$ DataGrid��5&      $��10,183,10.4,50q�6%     DataGridStyle#��[ 6r      AutoGenerateColumns .     Columns 5(      0  *System.Windows.Controls.DataGridTextColumn  5)      ,  &System.Windows.Controls.DataGridColumn   Header$ 
شناسه��6%      
IsReadOnly .    
Visibility$ Hidden=�6F   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6Z   �� *Id+  5*      $ قیمت واحد��6%    .  6K   �� *	UnitPrice+  5+      $ واحد��6%    .  6F   �� *Unit+  5,      $ 
تعداد��6%    .  6G   �� *Count+  5-      $ نام کالا��6%    .  6J   �� *CommodityName+  5.      $ کد کالا��6%    .  6I   �� *CommodityCode+50      �� 51   
   -   5        $��ثبت��51      $��
10,0,10,10q�6   $��Bottom=�63   #��[ 6h   53      54      