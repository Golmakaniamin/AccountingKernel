   M S B A M L   `   `   `  ����  AccountingKernel3    -AccountingKernel.Forms.user_personel.frm_getp   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  frm_getp��5   	   $	��600��6   $	��800��6'   $��RightToLeft=�6L      WindowStyle#���   6h    � WindowStartupLocation$ CenterScreen=�6�   .��5      � .+�5   
   �� -   5         ��Name$ BtnPrint��5       � ToolTip$ چاپ��6#   $��35��61   $��	0,10,10,0q�6>   $	��Top=�6Q   $��Right=�6i   $��35��6�   ��5      �� 5	       �� ImageSource$7 1/AccountingKernel;component/Themes/icon/Print.png��6   5      �� 5   
   -   5        $ BtnExel��5      $ اکسل��6"   $��35��61   $��	0,10,50,0q�6>   $	��Top=�6Q   $��Right=�6i   $��35��6�   ���	#FF7A7878
���   ���5      �� 5      $7 1/AccountingKernel;component/Themes/icon/Excel.png��6   5      �� 5   
   -   5        $ BtnDel��5      $ حذف��6!   $��35��6/   $��	0,10,90,0q�6<   $	��Top=�6O   $��Right=�6g   $��35��6�   ��5      �� 5      $8 2/AccountingKernel;component/Themes/icon/delete.png��6   5      �� 5   
   -   5        $ BtnEdit��5      $ ویرایش��6"   $��35��63   $��
0,10,130,0q�6?   $	��Top=�6S   $��Right=�6k   $��35��6�   ��5      �� 5      $6 0/AccountingKernel;component/Themes/icon/Edit.png��6   5      �� 5   
   -   5        $ BtnNew��5      $ جدید��6!   $��35��60   $��
0,10,170,0q�6=   $	��Top=�6Q   $��Right=�6i   $��35��6�   
���   ����	#FF7E7E7E��5      �� 5      $5 //AccountingKernel;component/Themes/icon/New.png��6   5      &   System.Windows.Controls.DataGrid  5    
   -   5          Name$ grd_p��5         DataGridStyle#��[ 6"   $��
10,50,10,0q�6I   $	��Top=�6]   $	��503��6u      AutoGenerateColumns .  6�   �� 5!   
   -   5         ��Name$ 
txt_search��5!        TextBoxStyle#��[ 6&   $��65,10,215,0q�6L    �� TextWrapping$
 Wrap=�6a   $	��Top=�6u   �� 5"   
   -	   5        $��انتخاب��5"        ButtonStyleRD#��[ 6"   $��10,551,10,0q�6I   6^   �� 5#   
   $��
جستجو��6   $
��Left=�6    $��	10,10,0,0q�6;   $	��Top=�6N     
LabelStyle#��[ 6f   $��50��6�   5%      5&      