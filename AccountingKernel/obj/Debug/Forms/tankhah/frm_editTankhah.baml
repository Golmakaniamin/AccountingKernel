   M S B A M L   `   `   `  ����U  QPersianDateControls, Version=1.2.5439.35283, Culture=neutral, PublicKeyToken=nullbDclr-namespace:Arash.PersianDateControls;assembly=PersianDateControlsArash.PersianDateControls  5   	    AccountingKernel4   .AccountingKernel.Forms.tankhah.frm_editTankhah   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   dPersianDateControlsDclr-namespace:Arash.PersianDateControls;assembly=PersianDateControls     5   	   -   5          � Title$  frm_editTankhah��5   	      WindowStyle#���   6!   $	��480��6G   $	��640��6T   $��RightToLeft=�6y   .��5      �  � ColumnDefinitions 5   
   �� 5      .+�5
   
   �� $��
شماره��6   $
��Left=�6    $��
460,39,0,0q�6;   $	��Top=�6O     
LabelStyle#��[ 6g   $��43��6�   �� 5   
   -   5         ��Name$ txt_shomare��5      $
��Left=�6'     TextBoxStyle#��[ 6B   $��
508,40,0,0q�6h    �� TextWrapping$
 Wrap=�6|   $	��Top=�6�   $	��115��6�   6�   �� 5   
   $��تاریخ تنخواه��6   $
��Left=�6'   $��
272,40,0,0q�6B   $	��Top=�6V   #��[ 6n   $��63��6�   �� 5   
   $�� تنخواه گردان��6   $
��Left=�6(   $��	10,40,0,0q�6C   $	��Top=�6V   #��[ 6n   $��65��6�   �� 5   
   -   5        $ txt_code_personnel��5      $
��Left=�6.   #��[ 6I   $��	80,39,0,0q�6o   $
 Wrap=�6�   $	��Top=�6�   $	��120��6�   �� 5   
   -   5         ��Name$ btn_selectPersonnel��5      $	��...��6.     ButtonStyleRD#��[ 6<   $
��Left=�6c   $��
205,39,0,0q�6~   $	��Top=�6�   $��56��6�   6�   �� 5   
   $��تاریخ هزینه��6   $
��Left=�6&   $��	10,80,0,0q�6A   $	��Top=�6T   #��[ 6l   $��65��6�   �� 5   
   $��توضیحات��6   $
��Left=�6"   $��
10,124,0,0q�6=   $	��Top=�6Q   #��[ 6i   $��65��6�   �� 5   
   -   5        $ txt_tozihat��5      #��[ 6'   $
��Left=�6M   $��
80,124,0,0q�6h   $
 Wrap=�6|   $	��Top=�6�   $	��376��6�   6�   �� 5   
   $��مبلغ��6   $
��Left=�6   $��
272,80,0,0q�6:   $	��Top=�6N   #��[ 6f   $��63��6�   �� 5   
   -   5        $ btn_virayesh1��5      $��ویرایش��6(   #��[ 69   $
��Left=�6`   $��460,120,0,0q�6{   $	��Top=�6�   $	��170��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ grid_tankhah��5        DataGridStyle#��[ 6)   $��RightToLeft=�6P   $��10,164,10,0q�6l   $	��Top=�6�   $	��262��6�      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
تاریخ��6@   	   
IsReadOnly	 .  1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6%   �� *CDDate+6O     5      $ مبلغ��6A   	 .  
 6%   �� *	CDPrice+6O     5      $ شرح��6G   	 .  
 6%   �� *CDDescription+6T   5      1   +Arash.PersianDateControls.PersianDatePicker  5   
   -   5          Name$ pic_date��5   0   $
��Left=�6B   $��
340,40,0,0q�6]   $	��Top=�6q   $��35��6�   �� 5   
   -	   5        $ 	btn_edit2��5      $��ویرایش��6$   #��[ 65   $
��Left=�6\   $��
10,431,0,0q�6w   $	��Top=�6�   $	��620��6�   6�     5   
   -
   5        $ pic_tarikhe_hazine��5   0   $
��Left=�6L   $��	80,80,0,0q�6g   $	��Top=�6z   $��35��6�   $	��120��6�   �� 5    
   -   5        $ txtprice��5       $
��Left=�6$   $��
340,80,0,0q�6?   $
 Wrap=�6S   $	��Top=�6g   $	��115��6   #��[ 6�   $��RightToLeft=�6�   6�   5!      5"      