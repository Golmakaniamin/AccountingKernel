   M S B A M L   `   `   `  ����K  GAccountingKernel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:WPFAutoCompleteTextboxWPFAutoCompleteTextbox  5   	   5    /AccountingKernel.Forms.Goodies.FrmRegisterGoods   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   GWPFAutoCompleteTextbox$clr-namespace:WPFAutoCompleteTextbox     5   	     � Title$  Document��5   	      WindowStyle#���   6   $	��600��6@   $	��800��6M    � WindowStartupLocation$ CenterScreen=�6Y   $��RightToLeft=�6~   .��5      � .+�5   
   �� $��گروه اصلی��6     
LabelStyle#��[ 6$   $
��Left=�6H   $��35��6c   $��
184,47,0,0q�6o   $	��Top=�6�   $��84��6�   0   *WPFAutoCompleteTextbox.AutoCompleteTextBox  5   
   -   5          Name$ txtMainGroup��5   5   0   *WPFAutoCompleteTextbox.AutoCompleteTextBox   	LostFocus$ txtMainGroup_LostFocus��5	      $
��Left=�5   K   $��35��6f   $��
273,47,0,0q�6r   $	��Top=�6�   $	��100��5	         	Threshold$ 1��6   6   �� 5
   
   $��کد گروه اصلی��6   #��[ 6'   $
��Left=�6K   $��35��6f   $��
395,42,0,0q�6r   $	��Top=�6�   $	��101��6�     5   
   -   5        $ txtMainGroupCode��5   5   $
��Left=�6O   $��35��6j   $��
501,47,0,0q�6v   $	��Top=�6�   $	��100��5   
   $ 1��6   �� 5   
   $��گروه فرعی��6   #��[ 6$   $
��Left=�6H   $��35��6c   $��
190,87,0,0q�6o   $	��Top=�6�   $��78��6�     5   
   -   5        $ txtSubsidiaryGroup��5   5   $" txtSubsidiaryGroup_LostFocus��5      $
��Left=�5   Q   $��35��6l   $��
273,87,0,0q�6x   $	��Top=�6�   $	��100��5      $ 1��6   6   �� 5   
   $��کد گروه فرعی��6   #��[ 6'   $
��Left=�6K   $��35��6f   $��
401,82,0,0q�6r   $	��Top=�6�   $	��101��6�     5   
   -   5        $ txtSubsidiaryGroupCode��5   5   $
��Left=�6U   $��35��6p   $��
501,87,0,0q�6|   $	��Top=�6�   $	��100��5   
   $ 1��6   �� 5   
   $��عنوان کالا��6   #��[ 6%   $
��Left=�6I   $��35��6d   $��184,124,0,0q�6p   $	��Top=�6�   $��84��6�   �� 5   
   -   5         ��Name$ txtGoodTitle��5        TextBoxStyle#��[ 6(   $
��Left=�6N   $��35��6i   $��273,124,0,0q�6u   $	��Top=�6�   $	��100��6�   6�   �� 5   
   $��کد کالا��6   #��[ 6"   $
��Left=�6F   $��35��6a   $��418,124,0,0q�6m   $	��Top=�6�   $��78��6�   �� 5   
   -   5        $ txtGoodCode��5      #��[ 6'   $
��Left=�6M   $��35��6h   $��501,124,0,0q�6t   $	��Top=�6�   $	��100��6�   6�   �� 5   
   $��عنوان لاتین��6   #��[ 6&   $
��Left=�6J   $��35��6e   $��184,164,0,0q�6q   $	��Top=�6�   $��80��6�   �� 5   
   -   5        $ txtGoodEngTitle��5      #��[ 6+   $
��Left=�6Q   $��35��6l   $��273,169,0,0q�6x   $	��Top=�6�   $	��100��6�   6�   �� 5   
   $��سقف موجودی��6   #��[ 6%   $
��Left=�6I   $��35��6d   $��418,367,0,0q�6p   $	��Top=�6�   $��84��6�   �� 5   
   -   5        $ txtCInventoryMax��5      $
��Left=�6,   #��[ 6G   $��RightToLeft=�6m   $��507,367,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��100��6�   �� 5   
   $��سقف سفارش��6   #��[ 6$   $
��Left=�6H   $��35��6c   $��167,367,0,0q�6o   $	��Top=�6�   $	��101��6�   �� 5   
   -	   5        $ txtCOrderMax��5      $
��Left=�6)   #��[ 6D   $��RightToLeft=�6j   $��273,372,0,0q�6�   $	��Top=�6�   $	��100��6�   �� 5   
   $��حداقل سفارش��6   #��[ 6&   $
��Left=�6J   $��35��6e   $��418,244,0,0q�6q   $	��Top=�6�   $��78��6�   �� 5    
   -
   5        $ txtCOrderMin��5       $
��Left=�6)   #��[ 6D   $��RightToLeft=�6j   $��501,244,0,0q�6�   $	��Top=�6�   $	��100��6�   �� 5!   
   $��نقطه سفارش��6   #��[ 6%   $
��Left=�6I   $��35��6d   $��167,244,0,0q�6p   $	��Top=�6�   $	��101��6�   �� 5"   
   -   5        $ txtCOrderPoint��5"      $
��Left=�6+   #��[ 6F   $��RightToLeft=�6l   $��273,249,0,0q�6�   $	��Top=�6�   $	��100��6�   �� 5#   
   $��نقطه بحرانی��6   #��[ 6&   $
��Left=�6J   $��35��6e   $��418,412,0,0q�6q   $	��Top=�6�   $��84��6�   �� 5$   
   -   5        $ txtCPointCritical��5$      $
��Left=�6.   #��[ 6I   $��RightToLeft=�6o   $��507,407,0,0q�6�   $	��Top=�6�   $	��100��6�   �� 5&   
   $"��واحد شمارش پایه��6   #��[ 6*   $
��Left=�6N   $��35��6i   $��395,164,0,0q�6u   $	��Top=�6�   $	��101��6�   �� 5'   
   -   5         ��Name$ cmbBaseCountingUnit��5'      $
��Left=�60   $��35��6K   $��501,169,0,0q�6W   $	��Top=�6l   $	��100��6�    �� DisplayMemberPath$ 
AssignName��5(      	 �� SelectedValuePath$	 Id��6#   �� 5)   
   -   5        
 ��Name$
 btnRegister��5)        ButtonStyleRD#��[ 6&   $��LeftToRight=�6M   $��35��6i   $��10,555,10,0q�6u   $	��Top=�6�   .��5*      �� $��ثبت��6   5+      �� 5,   
   $��نوع��6   #��[ 6   $
��Left=�6B   $��35��6]   $��167,407,0,0q�6i   $	��Top=�6~   $	��101��6�   �� 5-   
   -   5        $ cmbType��5-      $
��Left=�6$   $��35��6?   $��273,412,0,0q�6K   $	��Top=�6`   $	��100��6x   $ 
AssignName��5.   
   $	 Id��6)   �� 5/   
   -   5        $��ورودی از اکسل��5/      $
��Left=�6)   $��
10,515,0,0q�6D   $	��Top=�6X   $	��780��6p   $��35��6|   6�   52      53      