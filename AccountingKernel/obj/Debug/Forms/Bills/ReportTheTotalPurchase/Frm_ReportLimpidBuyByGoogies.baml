   M S B A M L   `   `   `  ����U  QPersianDateControls, Version=1.2.5439.35283, Culture=neutral, PublicKeyToken=nullbDclr-namespace:Arash.PersianDateControls;assembly=PersianDateControlsArash.PersianDateControls  5   	    AccountingKernelR   LAccountingKernel.Forms.Bills.ReportTheTotalPurchase.ReportLimpidBuyByGoogies   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   dPersianDateControlsDclr-namespace:Arash.PersianDateControls;assembly=PersianDateControls     5   	     � Title$  ReportLimpidBuyByGoogies��5   	   $	��768��6*   $
��1024��67      WindowStyle#���   6D   $��RightToLeft=�6j    � WindowStartupLocation$ CenterScreen=�6�   .��5      � .+�5   
   �� $��نام انبار��6     
LabelStyle#��[ 6$   $
��Left=�6H   $��	29,70,0,0q�6c   $	��Top=�6v   $��39��6�   �� 5   
   -   5         ��Name$ 	cmbStoreS��5      $
��Left=�6&   $��	75,71,0,0q�6A   $��35��6T   $	��Top=�6`   $	��120��6x    �� DisplayMemberPath$ 
AssignName��6�    �� SelectedValuePath$ Id��6�   6�   �� 5	   
   $��در تاریخ��6   #��[ 6#   $
��Left=�6G   $��
304,70,0,0q�6b   $	��Top=�6v   $��47��6�   1   +Arash.PersianDateControls.PersianDatePicker  5   
   -   5          Name$ PDate��5   0   $
��Left=�6?   $��35��6Z   $��
358,70,0,0q�6f   $	��Top=�6z   6�   �� 5   
   -   5        $��چاپ گزارش��5        ButtonStyleRD#��[ 6%   $
��Left=�6L   $��
494,69,0,0q�6g   $	��Top=�6{   $��75��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$	 Grd��5      $��10,123,10,0q�6    $	��Top=�65   $	��534��6M      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 کد کالا��6%   
   
IsReadOnly
 . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6I   �� *Code+  5      $	 نام کالا��6%   
 .  6J   �� *Kala+  5      $	 واحد شمارش��6%   
 .  6L   ��   5      $	 
تعداد��6%   
 .  6G   �� *Amount+  5      $	 مبلغ کل��6%   
 .  6I   �� *	Sum_Price+5      �� 5   
   $��مجموع تعداد��6   #��[ 6&   $
��Left=�6J   $��180,689,0,0q�6e   $	��Top=�6z   $��74��6�   �� 5   
   -   5         ��Name$ SumTxT��5      $
��Left=�6"   {�.    TextBoxStyle#��[ 6O   $��267,689,0,0q�6u    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��120��6�   �� 5   
   $��جمع مبلغ��6   #��[ 6#   $
��Left=�6G   $��532,688,0,0q�6b   $	��Top=�6w   $��74��6�   �� 5   
   -   5        $ SumPrice��5      {�.  $
��Left=�66   #��[ 6Q   $��614,688,0,0q�6w   $
 Wrap=�6�   $	��Top=�6�   $	��120��6�   5      5      