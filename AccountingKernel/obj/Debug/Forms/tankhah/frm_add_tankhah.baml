   M S B A M L   `   `   `  ����U  QPersianDateControls, Version=1.2.5439.35283, Culture=neutral, PublicKeyToken=nullbDclr-namespace:Arash.PersianDateControls;assembly=PersianDateControlsArash.PersianDateControls  5   	    AccountingKernel4   .AccountingKernel.Forms.tankhah.frm_add_tankhah   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   dPersianDateControlsDclr-namespace:Arash.PersianDateControls;assembly=PersianDateControls     5   	   -   5          � Title$  frm_add_tankhah��5   	   $	��480��6!   $	��640��6.   $��RightToLeft=�6p      WindowStyle#���   6�   .��5      � .+�5   
   �� $��
شماره��6   $
��Left=�6    $��
441,32,0,0q�6;   $	��Top=�6O     
LabelStyle#��[ 6g   �� 5   
   -   5         ��Name$ txt_shomare��5        TextBoxStyle#��[ 6'   $
��Left=�6M   $��
470,32,0,0q�6h    �� TextWrapping$
 Wrap=�6|   $	��Top=�6�   $	��154��6�   6�   �� 5	   
   $��تاریخ تنخواه��6   $
��Left=�6'   $��
267,33,0,0q�6B   $	��Top=�6V   #��[ 6n   �� 5
   
   $�� تنخواه گردان��6   $
��Left=�6(   $��	10,33,0,0q�6C   $	��Top=�6V   #��[ 6n   $��67��6�   �� 5   
   -   5        $ txt_code_personnel��5      #��[ 6.   $
��Left=�6T   $��	83,33,0,0q�6o   $
 Wrap=�6�   $	��Top=�6�   $	��132��6�   �� 5   
   -   5         ��Name$ btn_selectPersonnel��5        ButtonStyleRD#��[ 6.   $	��...��6U   $
��Left=�6c   $��
220,32,0,0q�6~   $	��Top=�6�   $��42��6�   6�   �� 5   
   $��تاریخ هزینه��6   $
��Left=�6&   $��
269,73,0,0q�6A   $	��Top=�6U   #��[ 6m   �� 5   
   $��توضیحات��6   $
��Left=�6"   $��
11,117,0,0q�6=   $	��Top=�6Q   #��[ 6i   $��67��6�   �� 5   
   -   5        $ txt_tozihat��5      #��[ 6'   $
��Left=�6M   $��
83,117,0,0q�6h   $
 Wrap=�6|   $	��Top=�6�   $	��355��6�   6�   �� 5   
   $��مبلغ��6   $
��Left=�6   $��	11,73,0,0q�6:   $	��Top=�6M   #��[ 6e   $��67��6�   �� 5   
   -   5        $ btn_sabt��5      $��ثبت��6#   #��[ 61   $
��Left=�6X   $��470,114,0,0q�6s   $	��Top=�6�   $	��160��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ grid_tankhah��5        DataGridStyle#��[ 6)   $��RightToLeft=�6P   $��10,157,10,0q�6l      AutoGenerateColumns .  $	��269��6�   $	��Top=�6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
تاریخ��6@      
IsReadOnly .  1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6%   �� *CDDate+6O     5      $ مبلغ��6A    .  	 6%   �� *	CDPrice+6O     5      $ شرح��6G    .  	 6%   �� *CDDescription+6T   5      1   +Arash.PersianDateControls.PersianDatePicker  5   
   -   5        
  Name$
 pic_date��5   0   $
��Left=�6B   $��
320,33,0,0q�6]   $	��Top=�6q   $��35��6�   $	��116��6�   �� 5   
   -	   5        $ 	btn_sabt2��5      $��ثبت��6$   #��[ 62   $��10,431,10,0q�6Y   $	��Top=�6n   6�     5   
   -
   5        $
 pic_tarikhe_hazine��5   0   $
��Left=�6L   $��
320,73,0,0q�6g   $	��Top=�6{   $��35��6�   $	��116��6�   �� 5   
   -   5        $ txtprice��5      #��[ 6$   $��RightToLeft=�6J   $
��Left=�6f   $��	83,73,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��132��6�   6�   �� 5   
   -   5        $0��*ورودی از نرم افزار اکسل��5      $
��Left=�63   $��
470,74,0,0q�6N   $	��Top=�6b   $	��154��6z   $��35��6�   6�   5       5!      