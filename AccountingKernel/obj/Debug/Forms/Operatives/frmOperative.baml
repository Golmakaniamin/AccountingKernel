   M S B A M L   `   `   `  ����  AccountingKernel4    .AccountingKernel.Forms.Operatives.frmOperative   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Document��5   	      WindowStyle#���   6   $	��320��6@   $	��480��6M    � WindowStartupLocation$ CenterScreen=�6Y   $��RightToLeft=�6~   .��5      � .+�5   
   �� $��نام عامل��6     
LabelStyle#��[ 6$   $
��Left=�6I   $��	48,31,0,0q�6d   $	��Top=�6w   $	��111��6�   �� 5   
   -   5         ��Name$ txtName��5   {   $
��Left=�6     TextBoxStyle#��[ 6-   $��
164,39,0,0q�6S    �� TextWrapping$
 Wrap=�6g   $	��Top=�6�   $	��249��6�   6�   �� 5	   
   $��نوع عامل��6   #��[ 6$   $
��Left=�6H   $��	48,79,0,0q�6c   $	��Top=�6v   $	��111��6�   �� 5
   
   -   5         ��Name$ cmbOperativeType��5
   N   $
��Left=�6   $��35��6.   $��
164,79,0,0q�6:   $	��Top=�6i   $	��249��6�    �� DisplayMemberPath$ 
AssignName��6�    �� SelectedValuePath$ Id��6�   �� 5   
   $��روش محاسبه��6   #��[ 6&   $
��Left=�6K   $��
48,127,0,0q�6f   $	��Top=�6z   $	��111��6�   �� 5   
   -   5        $ cmbCalculationMethod��5   O   $
��Left=�6   $��35��6.   $��164,119,0,0q�6:   $	��Top=�6n   $	��249��6�   $ 
AssignName��6�   $ Id��6�   6�   �� 5   
   $��موثر/غیر موثر��6   #��[ 6)   $
��Left=�6N   $��
48,176,0,0q�6i   $	��Top=�6}   $	��111��6�   �� 5   
   -   5         ��Name$ chboxIsEffective��5   O   $
��Left=�6   $��35��6.   $��164,0,0,109q�6:   $��Bottom=�6j   $	��249��6�   �� 5   
   $��درصد محاسبه��6   #��[ 6'   $
��Left=�6L   $��
48,217,0,0q�6g   $	��Top=�6{   $	��111��6�   �� 5   
   -   5        $ 
txtPercent��5   �   $
��Left=�6   #��[ 6-   $��RightToLeft=�6S   $��164,216,0,0q�6o   $
 Wrap=�6�   $	��Top=�6�   $	��249��6�    �� 	MaxLength$ 2��6�   �� 5   
   -   5        	 ��Name$	 btnRegister��5   \     ButtonStyleRD#��[ 6   $��ثبت��68   $��10,275,10,10q�6F   6q   5      5      