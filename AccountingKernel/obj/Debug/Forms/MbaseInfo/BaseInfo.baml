   M S B A M L   `   `   `  ����  AccountingKernel2    ,AccountingKernel.Forms.MbaseInfo.FrmBaseInfo   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  
MainWindow��5   	   $	��768��6   $
��1024��6)    � WindowStartupLocation$ CenterScreen=�66      WindowStyle#���   6[   $��RightToLeft=�6�   .��5      � -   5        .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ grd_companyParent��5      $��	10,10,0,0q�6.     DataGridStyle#��[ 6A   $	��Top=�6h   $	��391��6�   $
��Left=�6�   $	��610��6�      AutoGenerateColumns .     AlternatingRowBackground
 �����   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5	      ,  &System.Windows.Controls.DataGridColumn   Header$
 کد��6A      
IsReadOnly .  1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� 	 �� Path$	 Id�6M     5
      $ نام لاتین��6I    .   6%   �� $	 
AssignName�6\     5      $ 
فارسی��6F    .   6%   �� $	 Explain�6U     5      $ اولویت��6G    .   6%   �� $	 Priority�6W     5      $ کد معین��6G    .   6%   �� $	 MIdMoein�6X   5        5   
   -   5        $ 
grd_childC��5      $��625,10,10,0q�6'   #��[ 6<   
 J� RenderTransformOrigin$
 -0.25,-3.308&�6c    .  
 �����$	��391��6#  $	��Top=�60   5        5      $
 کد��6A    .   6%   �� $	 Id�6M     5      $ نام لاتین��6I    .   6%   �� $	 
AssignName�6\     5      $ 
فارسی��6F    .   6%   �� $	 Explain�6U     5      $ اولویت��6G    .   6%   �� $	 Priority�6W     5      $ کد معین��6G    .   6%   �� $	 MIdMoein�6X    � ContextMenu 5      �� 5      .@�5      m� -   5        $��menu100��5      $��حذف��6.   6;   5      5      �� 5!   
   $��ثبت��6   $
��Left=�6    $��
10,406,0,0q�6;   $	��Top=�6O   $��75��6g   $	��610��6s   �� 5#   
   -   5         ��Name$ btn_saveToDB��5#      $��
ذخیره��6'     ButtonStyleRD#��[ 67   $
��Left=�6^   $��519,429,0,0q�6y   $	��Top=�6�   $��75��6�   6�   �� 5$   
   -   5         ��Name$
 Lbl1��5$      $��ذینفعان��6     
LabelStyle#��[ 60   $	��Top=�6T   $
 -0.421,-0.077&�6l   $��Stretch=�6�   $��Center=�6�   $��47,429,908,0q�6�   �� 5%   
   -   5         ��Name$ txt_name��5%        TextBoxStyle#��[ 6$   $
��Left=�6J   $��121,429,0,0q�6e    �� TextWrapping$
 Wrap=�6z   $	��Top=�6�   $	��120��6�   $��Center=�6�   $
 -1.875,0.867&�6�   6�   �� 5&   
   $�� نام لاتین��6   #��[ 6%   $
��Left=�6I   $��246,429,0,0q�6d   $	��Top=�6y   $
 -0.421,-0.077&�6�   $��80��6�   $��Stretch=�6�   $��Center=�6�   �� 5'   
   -	   5        $ txt_name_Copy��5'      #��[ 6)   $
��Left=�6O   $��331,431,0,0q�6j   $
 Wrap=�6   $	��Top=�6�   $	��120��6�   $��Center=�6�   6�   5(      5)      