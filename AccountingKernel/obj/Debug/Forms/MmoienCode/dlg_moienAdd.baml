   M S B A M L   `   `   `  ����K  GAccountingKernel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:WPFAutoCompleteTextboxWPFAutoCompleteTextbox  5   	   2    ,AccountingKernel.Forms.MmoienCode.dlg_detail   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   GWPFAutoCompleteTextbox$clr-namespace:WPFAutoCompleteTextbox     5   	   -   5        $��	FrmDetail��5         WindowStyle#���   6     � Title$  
dlg_detail��6<   $	��480��6O   $	��640��6\    � WindowStartupLocation$ CenterScreen=�6h   $��RightToLeft=�6�   .��5      � $��10q�6    � ColumnDefinitions 5   
   �� 5	      .+�5   
   �� $��گروه��6   $
��Left=�6   $��	10,50,0,0q�6:   $	��Top=�6M   $	��105��6e     
LabelStyle#��[ 6q   0   *WPFAutoCompleteTextbox.AutoCompleteTextBox  5   
   -   5          Name$ 	txt_group��5   5   0   *WPFAutoCompleteTextbox.AutoCompleteTextBox   	LostFocus$ txt_group_LostFocus��6�      PreviewTextInput$  txt_group_PreviewTextInput��6�   $
��Left=�6H   $��
120,50,0,0q�6d   $��35��6x   $	��Top=�6�   $	��232��6�   6�   �� 5   
   -   5         ��Name$ txt_grouhCode��5      $
��Left=�6)     TextBoxStyle#��[ 6D   $��
435,50,0,0q�6j    �� TextWrapping$
 Wrap=�6~   $	��Top=�6�   $	��177��6�   6�   �� 5   
   $$��عنوان لاتین گروه��6   $
��Left=�6+   $��	10,90,0,0q�6F   $	��Top=�6Y   $	��105��6q   #��[ 6}     5   
   -   5        $ txt_name_latin_grouh��5   5   $ txt_group_LostFocus��6�   $+ %txt_name_latin_grouh_PreviewTextInput��6�   $
��Left=�6S   $��35��6n   $��
120,90,0,0q�6z   $	��Top=�6�   $	��232��6�   6�   �� 5   
   $
��کل��6   $
��Left=�6   $��
10,130,0,0q�68   $	��Top=�6L   $	��105��6d   #��[ 6p     5   
   -   5        $ txt_all��5   5   $ txt_all_LostFocus��6�   $
��Left=�6F   $��120,130,0,0q�6a   $��35��6v   $	��Top=�6�   $	��232��6�   6�   �� 5   
   -   5        $ txt_kol_code��5      $
��Left=�6(   #��[ 6C   $��432,130,0,0q�6i   $
 Wrap=�6~   $	��Top=�6�   $	��178��6�   6�   �� 5   
   $ ��عنوان لاتین کل��6   $
��Left=�6)   $��
10,170,0,0q�6D   $	��Top=�6X   $	��105��6p   #��[ 6|     5   
   -   5        $ txt_name_latin_kol��5   5   $ txt_all_LostFocus��6�   $) #txt_name_latin_kol_PreviewTextInput��6�   $
��Left=�6R   $��120,170,0,0q�6m   $	��Top=�6�   $	��232��6�   $��35��6�   �� 5   
   $��معین��6   $
��Left=�6   $��
10,210,0,0q�6:   $	��Top=�6N   $	��105��6f   #��[ 6r   �� 5   
   -   5        $ 	txt_moien��5      $
��Left=�6%   #��[ 6@   $��122,210,0,0q�6f   $
 Wrap=�6{   $	��Top=�6�   $	��230��6�   6�   �� 5   
   -	   5        $ txt_moien_code��5      $
��Left=�6*   #��[ 6E   $��427,210,0,0q�6k   $
 Wrap=�6�   $	��Top=�6�   $	��183��6�   6�   �� 5   
   $$��عنوان لاتین معین��6   $
��Left=�6+   $��
10,250,0,0q�6F   $	��Top=�6Z   $	��104��6r   #��[ 6~   �� 5   
   -
   5        $ txt_name_latin_moien��5      #��[ 60   $
��Left=�6V   $��120,250,0,0q�6q   $
 Wrap=�6�   $	��Top=�6�   $	��232��6�   6�   �� 5   
   $��ماهیت معین��6   $
��Left=�6%   $��
10,290,0,0q�6@   $	��Top=�6T   $	��105��6l   #��[ 6x   �� 5    
   -   5        $ txt_mahiteMoien��5       $
��Left=�6+   #��[ 6F   $��120,290,0,0q�6l   $
 Wrap=�6�   $	��Top=�6�   $	��231��6�   �� 5!   
   -   5         ��Name$ cmb_noeMoien��5!      $
��Left=�6)   $��120,330,0,0q�6D   $	��Top=�6Y   $	��231��6q   $��35��6}   	 �� DisplayMemberPath$	 
AssignName��6�   
 �� SelectedValuePath$
 Id��6�   �� 5"   
   $��نوع معین��6   $
��Left=�6#   $��
10,330,0,0q�6>   $	��Top=�6R   $	��104��6j   #��[ 6v   �� 5#   
   -   5         ��Name$ btn_AddToDb��5#        ButtonStyleRD#��[ 6&   $��ثبت��6M   $��10,421,10,0q�6[   $	��Top=�6p    J� RenderTransformOrigin$ 1.278,1.173&�6�   5$      5%      