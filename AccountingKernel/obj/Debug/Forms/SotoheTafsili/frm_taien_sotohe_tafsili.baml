   M S B A M L   `   `   `  ����  AccountingKernelC    =AccountingKernel.Forms.SotoheTafsili.frm_taien_sotohe_tafsili   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  frm_taien_sotohe_tafsili��5   	      WindowStyle#���   5      $	��600��6'   $	��800��64    � WindowStartupLocation$ CenterScreen=�6@   $��RightToLeft=�6e   .��5      � .+�5   
   �� $�� ��6   $��
13,49,10,0q�6   $	��Top=�61   $��50��6I   .��5      �� $��کد معین��6   $
��Left=�6&   $	��Top=�6A    J� RenderTransformOrigin$ 1.026,-0.731&�6Y   $��
563,-9,0,0q�6~     
LabelStyle#��[ 6�   5	      �� 5
   
   -   5         ��Name$ lbl_codeMoien��5
      $��-��6'   $
��Left=�63   $��
671,59,0,0q�6N   $	��Top=�6b   #��[ 6z   �� 5   
   $��عنوان معین��6   $
��Left=�6%   $��
399,59,0,0q�6@   $	��Top=�6T   #��[ 6l   �� 5   
   -   5        $ lbl_onvaneMoien��5      $��-��6)   $
��Left=�65   $��
509,61,0,0q�6P   $	��Top=�6d   #��[ 6|   �� 5   
   $��عنوان کل��6   $
��Left=�6#   $��
223,59,0,0q�6>   $	��Top=�6R   #��[ 6j   �� 5   
   -   5        $ lbl_onvaneKol��5      $��-��6'   $
��Left=�63   $��
326,59,0,0q�6N   $	��Top=�6b   #��[ 6z   �� 5   
   $��عنوان گروه��6   $
��Left=�6%   $��	36,59,0,0q�6@   $	��Top=�6S   #��[ 6k   �� 5   
   -   5        $ lbl_onvaneGrouh��5      $��-��6)   $
��Left=�65   $��
147,59,0,0q�6P   $	��Top=�6d   #��[ 6|   �� 5   
   $�� ��6   $��10,104,10,0q�6   $	��Top=�62   $��74��6J   .��5      �� -   5         ��Name$ cmb_sotoheTafsili��5      $
��Left=�62   $	��Top=�6M   $	��120��6e   $��
408,10,0,0q�6q   $��35��6�   5      �� 5   
   -   5         ��Name$! btn_fehresteGrouhayeTafsili��5        ButtonStyleRD#��[ 66   $*��$فهرست گروهای تفصیلی��6]   $
��Left=�6{   $��260,128,0,0q�6�   $	��Top=�6�   $	��153��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ grid_AccountiTafsilLevels��5   *   $��10,188,10,10q�6     DataGridStyle#��[ 6M      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 نام گروه��6F   
   
IsReadOnly
 . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   ��  �� Path$ ATLName�6X     5      $	 گروه��6G   
 .  6%   �� $ CodeName�6U    � ContextMenu 5      �� 5      .@�5      m� -	   5        $��mnu_del��5      $��حذف��6.   5       5!      5&      5'      5(      