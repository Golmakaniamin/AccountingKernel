   M S B A M L   `   `   `  ����B  >Payroll, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:AccountingKernel.ClassAccountingKernel.Class  5   	   (    "AccountingKernel.Forms.PersonGroup   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   5self$clr-namespace:AccountingKernel.Class     5   	     � Title$  PersonGroup��5   	   $	��600��5   
   $	��800��6    � WindowStartupLocation$ CenterScreen=�6#   $��RightToLeft=�6H      WindowStyle#���   5      .��5      � .+�5	   
   �� $��
جستجو��6   $��35��6    $��10,10,740,0q�6,   $	��Top=�6A     
LabelStyle#��[ 6Y   �� 5
   
   -   5         ��Name$ 	txtSearch��5
      $��35��6%   $��57,10,212,0q�61   $	��Top=�6F     TextBoxStyle#��[ 6v   �� 5   
   -   5         ��Name$ BtnPrint��5       � ToolTip$ چاپ��6#     ButtonStyleRD#��[ 61   $��	0,10,10,0q�6Y   $	��Top=�6l   $��Right=�6�   $��35��6�   �� 5   
   -   5        $ BtnExel��5      $ اکسل��6"   #��[ 61   $��	0,10,50,0q�6Y   $	��Top=�6l   $��Right=�6�   $��35��6�   �� 5   
   -   5        $ BtnDel��5      $ حذف��6!   #��[ 6/   $��	0,10,90,0q�6W   $	��Top=�6j   $��Right=�6�   $��35��6�   �� 5   
   -   5        $ BtnEdit��5      $ ویرایش��6"   #��[ 63   $��
0,10,130,0q�6[   $	��Top=�6o   $��Right=�6�   $��35��6�   �� 5   
   -   5        $ BtnNew��5      $ جدید��6!   #��[ 60   $��
0,10,170,0q�6X   $	��Top=�6l   $��Right=�6�   $��35��6�   R� 5   
   -   5        $��trvMenu��5      ��5      �� 5       �� DataType'   !AccountingKernel.Class.MyMenuItem"  6+    �� ItemsSource 6O   �� *Items+.R�5      ��  �� Orientation$ 
Horizontal=�6!    � ContextMenu 5      �� 5      .@�5   "   m� $��عملیات��6+   .@�5   &   m� $	��new��6=   -   5        $��جدید��5   /   6H   m� 5   &   $
��edit��6?   -	   5        $��ویرایش��5   /   6K   m� 5   &   $��delete��6<   -
   5        $��حذف��5   /   6J   5   #   5      .+�5      �� ��6$   �� *Title+5      5      5!      5"      5#      