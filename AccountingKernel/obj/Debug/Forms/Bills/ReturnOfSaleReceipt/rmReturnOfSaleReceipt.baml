   M S B A M L   `   `   `  ����U  QPersianDateControls, Version=1.2.5439.35283, Culture=neutral, PublicKeyToken=nullbDclr-namespace:Arash.PersianDateControls;assembly=PersianDateControlsArash.PersianDateControls  5   	   K GAccountingKernel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:WPFAutoCompleteTextboxWPFAutoCompleteTextbox 6j   M   GAccountingKernel.Forms.Bills.ReturnOfSaleReceipt.FrmReturnOfSaleReceipt   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   dPersianDateControlsDclr-namespace:Arash.PersianDateControls;assembly=PersianDateControls     5   	   GWPFAutoCompleteTextbox$clr-namespace:WPFAutoCompleteTextbox     6j   -   5        $	��768��5   	   $
��1024��6      WindowStyle#���   6#     � WindowStartupLocation$  CenterScreen=�6I   $��RightToLeft=�6n   .��5      � .+�5   
   �� -   5         ��Name$ 	lblHeader��5   �   $
��Left=�6     
LabelStyle#��[ 6+   $��
437,24,0,0q�6O   $	��Top=�6c   $	��115��6{   6�   �� 5   
   $��نام انبار��6   #��[ 6$   $
��Left=�6H   $	��Top=�6c   $��76��6{   $��
502,64,0,0q�6�    J� RenderTransformOrigin$ 0.989,2.496&�6�   0  *WPFAutoCompleteTextbox.AutoCompleteTextBox  5	   
   -   5          Name$ txtRepository��5	   �   $
��Left=�65   $��35��6P   $��
583,63,0,0q�6\   $	��Top=�6p   $	��115��6�      	Threshold$ 1��6�   �� 5
   
   $
��Left=�6   #��[ 6+   $��
758,58,0,0q�6O   $	��Top=�6c   $	��107��6{   $��نوع حواله��6�   �� 5   
   -   5         ��Name$ cmbOrderType��5      $��35��6*   $��870,58,14,0q�66   $	��Top=�6K    �� DisplayMemberPath$ 
AssignName��6c    �� SelectedValuePath$ Id��6�   �� 5   
   $
��Left=�6   $��	35,62,0,0q�6+   $	��Top=�6>   $��56��6V   $��مبنا دارد��6a   #��[ 6u   �� 5   
   -   5         ��Name$ chbBase��5      $��35��6%   $��12,72,989.4,0q�61   $	��Top=�6H   6z   �� 5   
   $��نام خریدار��6   #��[ 6%   $
��Left=�6I   $	��Top=�6d   $��60��6|   $��
96,102,0,0q�6�   $ 0.989,2.496&�6�     5   
   -   5        $ 
txtCompany��5   �   $
��Left=�65   $��35��6P   $��161,101,0,0q�6\   $	��Top=�6q   $	��115��6�   $ 1��6�   �� 5   
   $
��Left=�6   $��	96,63,0,0q�6+   $	��Top=�6>   $��59��6V   $��برمبنای��6a   #��[ 6s   �� 5   
   -   5        $ cmbBase��5      $��35��6%   $��161,61,744.4,0q�61   $	��Top=�6I   $	��115��6a   $ 
AssignName��6m   $ Id��6�   6�   �� 5   
   -   5        	 ��Name$	 btnSelectBase��5   '   $��انتخاب مبنا��6   $
��Left=�6>   $��
300,61,0,0q�6Y     ButtonStyleRD#��[ 6m   $	��Top=�6�   $��80��6�   6�     5   
   -	   5        $ txtBase��5   5   $
��Left=�6F   $��35��6a   $��
388,61,0,0q�6m   $	��Top=�6�   $	��109��6�   $ 1��6�   �� 5   
   $��کد/ نام کالا��6   #��[ 6'   $
��Left=�6K   $	��Top=�6f   $��80��6~   $��300,101,0,0q�6�   $ 0.989,2.496&�6�     5   
   -
   5        $ txtCommodity��5   �   0  *WPFAutoCompleteTextbox.AutoCompleteTextBox
   	LostFocus$
 txtCommodity_LostFocus��6�   $
��Left=�65   $��35��6P   $��388,101,0,0q�6\   $	��Top=�6q   $	��109��6�   $ 1��6�   �� 5   
   $��
تعداد��6   #��[ 6    $
��Left=�6D   $	��Top=�6_   $��502,104,0,0q�6w   $ 0.989,2.496&�6�   $��76��6�   �� 5   
   -   5         ��Name$ txtCount��5   �   $
��Left=�6   $��RightToLeft=�6-   $��583,102,0,0q�6I   $	��Top=�6^   $	��115��6v     TextBoxStyle#��[ 6�   6�   �� 5   
   $&�� انتخاب واحد شمارش��6   #��[ 6,   $
��Left=�6P   $	��Top=�6k   $	��107��6�   $��
758,98,0,0q�6�   $ 0.989,2.496&�6�   �� 5   
   -   5        $ cmbUnitCount��5   r   $
��Left=�6   $��35��6.   $��
870,98,0,0q�6:   $	��Top=�6N   $	��140��6f   $ 
AssignName��6�   $ Id��6�   �� 5   
   $��توضیحات��6   #��[ 6"   $
��Left=�6F   $	��Top=�6a   $��61��6y   $��
96,141,0,0q�6�   $ 0.989,2.496&�6�   �� 5   
   -   5        $ 
txtComment��5   �   $
��Left=�6   $��162,141,0,0q�6.   #��[ 6C   $	��Top=�6i   $	��334��6�   6�   �� 5   
   $��تاریخ صدور ��6   #��[ 6&   $
��Left=�6J   $	��Top=�6e   $��76��6}   $��502,144,0,0q�6�   $ 0.989,2.496&�6�   1   +Arash.PersianDateControls.PersianDatePicker  5   
   -   5          Name$ dtpIssueDate��5   0   $��35��6F   $
��Left=�6R   $��583,144,0,0q�6m   $	��Top=�6�   $	��115��6�   �� 5   
   -   5        $	 btnRegisterCommodity��5   �   $��ثبت��6   $
��Left=�6   $��758,144,0,0q�6:   $	��Top=�6O   #��[ 6g   $	��252��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ DataGrid��5      $��10,184,10,50q�6%     DataGridStyle#��[ 6r      AutoGenerateColumns .     Columns 5!      0  *System.Windows.Controls.DataGridTextColumn  5"      ,  &System.Windows.Controls.DataGridColumn   Header$ 
شناسه��6%      
IsReadOnly .    
Visibility$ Hidden=�6F   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6Z   �� *Id+  5#      $ درصد تخفیف��6%    .  6K   �� *DiscountPrice+  5$      $ قیمت واحد��6%    .  6K   �� *	UnitPrice+  5%      $ واحد��6%    .  6F   �� *Unit+  5&      $ 
تعداد��6%    .  6G   �� *Count+  5'      $ نام کالا��6%    .  6J   �� *CommodityName+  5(      $ کد کالا��6%    .  6I   �� *CommodityCode+5*      �� 5+   
   -   5        $��ثبت��5+      $��10,0,10.4,10q�6   $��Bottom=�65   #��[ 6j   5,      5-      