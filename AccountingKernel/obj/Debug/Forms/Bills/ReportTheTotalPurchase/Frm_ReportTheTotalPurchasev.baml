   M S B A M L   `   `   `  ����U  QPersianDateControls, Version=1.2.5439.35283, Culture=neutral, PublicKeyToken=nullbDclr-namespace:Arash.PersianDateControls;assembly=PersianDateControlsArash.PersianDateControls  5   	    AccountingKernelU   OAccountingKernel.Forms.Bills.ReportTheTotalPurchase.Frm_ReportTheTotalPurchasev   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   dPersianDateControlsDclr-namespace:Arash.PersianDateControls;assembly=PersianDateControls     5   	     � Title$!  Frm_ReportTheTotalPurchasev��5   	   $	��768��6-   $
��1024��6:      WindowStyle#���   6G   $��RightToLeft=�6m    � WindowStartupLocation$ CenterScreen=�6�   .��5      � .+�5   
   �� -   5        $��چاپ گزارش��5        ButtonStyleRD#��[ 6%   $��618,64,303,669q�6L   6d   �� 5   
   $+��%گزارش سرجمع در تاریخ��6     
LabelStyle#��[ 6/   $	��Top=�6S   $��	10,60,0,0q�6k    J� RenderTransformOrigin$ 0.989,2.496&�6~   $
��Left=�6�   $	��111��6�   1   +Arash.PersianDateControls.PersianDatePicker  5	   
   -   5          Name$ PDate1��5	   0   $��
136,61,0,0q�6@   $	��Top=�6T   $	��115��6l   $��35��6x   $
��Left=�6�   6�   �� 5
   
   $��الی��6   #��[ 6   $	��Top=�6B   $��
283,60,0,0q�6Z   $ 0.989,2.496&�6n   $
��Left=�6�   $��20��6�     5   
   -   5        $ PDate2��5   0   $
��Left=�6@   $��
321,59,0,0q�6[   $	��Top=�6o   $��35��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ DataGrid��5      $��10,127,10,10q�6%      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ نام انبار��6%      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6J   �� 
 �� Path$
 Anbar�  5      $&  شماره فاکتور خرید��6%    . 	 6R   �� $

 Code�  5      $&  تاریخ فاکتور خرید��6%    . 	 6R   �� $

 Date�  5      $ کد طرف حساب��6%    . 	 6L   �� $
 	BuyerCode�  5      $ نام طرف حساب��6%    . 	 6M   �� $
 Buyer�  5      $ مقدار خرید��6%    . 	 6L   �� $
 Count�  5      $) #مبلغ کل فاکتور خرید��6%    . 	 6T   �� $
 SumMoney�5      5      5      