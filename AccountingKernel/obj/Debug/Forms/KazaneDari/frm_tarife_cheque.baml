   M S B A M L   `   `   `  ����K  GAccountingKernel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:WPFAutoCompleteTextboxWPFAutoCompleteTextbox  5   Y   U QPersianDateControls, Version=1.2.5439.35283, Culture=neutral, PublicKeyToken=nullbDclr-namespace:Arash.PersianDateControls;assembly=PersianDateControlsArash.PersianDateControls 6�   9    3AccountingKernel.Forms.KazaneDari.frm_tarife_cheque   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   MCustom@http://schemas.microsoft.com/winfx/2006/xaml/presentation/ribbon  5   	   AWPFAutoCompleteTextbox$clr-namespace:WPFAutoCompleteTextbox  6Y   ^PersianDateControlsDclr-namespace:Arash.PersianDateControls;assembly=PersianDateControls  6�   -   5          � Title$  frm_tarife_cheque��5   	   $	��480��6#   $	��640��60      WindowStyle#���   6U   $��RightToLeft=�6{   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��209* �6   .+�5
   
   �� $��کد بانک��6     
LabelStyle#��[ 6"   $
��Left=�6F   $	��Top=�6a   $��
10,116,0,0q�6y   $��75��6�   �� 5   
   $��نام بانک��6   #��[ 6#   $
��Left=�6G   $	��Top=�6b   $��388,116,0,0q�6z   $��83��6�   �� 5   
   -   5         ��Name$ txt_nameBank��5        TextBoxStyle#��[ 6(   $
��Left=�6N   $��476,116,0,0q�6i    �� TextWrapping$
 Wrap=�6~   $	��Top=�6�   $	��130��6�   6�   �� 5   
   -   5        $ txt_shomareCheque��5      #��[ 6-   $
��Left=�6S   $��
90,156,0,0q�6n   $
 Wrap=�6�   $	��Top=�6�   $	��185��6�   6�   �� 5   
   $��شماره چک��6   #��[ 6#   $
��Left=�6G   $��
10,156,0,0q�6b   $	��Top=�6v   $��75��6�   �� 5   
   $��تاریخ سررسید��6   #��[ 6'   $
��Left=�6K   $	��Top=�6f   $��
10,236,0,0q�6~   $��75��6�   �� 5   
   $��سریال چک��6   #��[ 6#   $
��Left=�6G   $	��Top=�6b   $��388,156,0,0q�6z   $��83��6�   �� 5   
   -   5        $ txt_serialeCheque��5      #��[ 6-   $
��Left=�6S   $��476,156,0,0q�6n   $
 Wrap=�6�   $	��Top=�6�   $	��130��6�   6�   �� 5   
   $��مبلغ چک��6   #��[ 6"   $
��Left=�6F   $	��Top=�6a   $��
10,196,0,0q�6y   $��75��6�   �� 5   
   -   5        $ txt_mablagheCheque��5      $��RightToLeft=�6.   #��[ 6J   $
��Left=�6p   $��
90,196,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��185��6�   6  �� 5   
   $
��Left=�6   #��[ 6+   $	��Top=�6O   $��388,196,0,0q�6g   $��83��6}   $��نوع چک��6�   �� 5   
   -   5         ��Name$ cmb_noeCheque��5      $
��Left=�6*   $��476,196,0,0q�6E   $	��Top=�6Z   $	��130��6r   $��35��6~   �� 5   
   $��شرح چک��6   #��[ 6!   $
��Left=�6E   $	��Top=�6`   $��
10,276,0,0q�6x   $��75��6�   �� 5   
   -   5        $ txt_sharheCheck��5      #��[ 6+   $
��Left=�6Q   $��
92,276,0,0q�6l   $
 Wrap=�6�   $	��Top=�6�   $	��514��6�   6�   �� 5   
   -   5         ��Name$ btn_sabt��5      $��ثبت��6#     ButtonStyleRD#��[ 61   $��10,431,10,10q�6X   6n   �� 5   
   -	   5        $ btn_entekhabeCodeBank��5      $	��...��60   #��[ 6>   $
��Left=�6e   $��223,112,0,0q�6�   $	��Top=�6�   $��55��6�    J� RenderTransformOrigin$ 
-0.645,0.7&�6�   6�   0   *WPFAutoCompleteTextbox.AutoCompleteTextBox  5   
   -
   5          Name$ txt_codeBank��5   5   0   *WPFAutoCompleteTextbox.AutoCompleteTextBox   PreviewTextInput$# txt_codeBank_PreviewTextInput��6�   $
��Left=�6K   $��35��6f   $��
90,116,0,0q�6r   $	��Top=�6�   $	��128��6�   6�   1  +Arash.PersianDateControls.PersianDatePicker  5   
   -   5        	  Name$	 pic_datePicker��5   0   $
��Left=�6H   $��
90,236,0,0q�6c   $	��Top=�6w   $	��188��6�   $��35��6�   5      5       