   M S B A M L   `   `   `  ����\  XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   StealthButtonTemplate  �� 
TargetType � 	Resources  Key �� 
TargetName �� TargetProperty g� Duration g� FillBehavior t� From	 t� To g� AutoReverse	 �Name
 ��Name �� CornerRadius J� Opacity �� EndPoint �� 
StartPoint � Color � Offset ��Name � OverridesDefaultStyle �� Triggers P� Property P� Value �� 
TargetName �� Property �� Value O� 	GlowColor O� GlowSize O� Opacity :� RoutedEvent :� 
SourceName  MouseOverButtonEffect  ButtonStyleRD �� 
TargetType�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml      5      %�  &	        7  &	 C    �� 5      "  ��64    5   
   ���� 5      MouseOverButtonEffect .��5      t� $ ButtonBorder��6%   $ (Control.Margin)�6J   $ 0:0:0.05D�5	      $
 Stop=�6&   $ 0,0,0,0X�6:   $ 2,2,2,2X�6I    . 6V   5
      5      .R�5   
   � $	 StealthButtonOuterGrid��6   .+�5      �� $
 ButtonBorder��6   $ 2,2,2,2��6+   $��0,0,0,0q�6B   
������ $ 0Q�6l   $��2q�6x   6�   �� 5      $
 ButtonBorderFill��6   $ 2,2,2,2��6/   $��0,0,0,0q�6F   $��3q�6W   $ 1Q�6k   ��5      �� 5      $ 0.5,1&�6*   $ 0.5,0&�6;   .��5      � $ 	#FF33B2EC��6'   $ 0Q�69   � 5      $ 	#FF2391C2��6'   $	 0.5Q�69   � 5      $ 	#FF167199��6'   $ 1Q�69   5      5      �� 5      $
 ButtonContent��6   $��2,2,2,2q�6,   ._�5      �� $ ContentPresenterLabel��6   
���   �$
��Bold"�6J   $
��Auto��6\   $��Center=�6i   .��5      �� $
��Auto��6'   $
��Auto��65   $��Center=�6B   $��Center=�6_   $��LeftToRight=�6z    . 6�   5      5      5       5   
   P� 5        �@J�IsMouseOver .  �5!      �� 5"      $ ContentPresenterLabel��63    � ��
 �����6f   �� 5#      $ ContentPresenterLabel��63    � ��$ Normal"�6V   6g   �� 5$      $ ContentPresenterLabel��60    �@J�Opacity$ 1Q�6S   6_   �� 5%      $ ButtonBorderFill��60    �@J�Opacity$ 1Q�6N   6Z   �� 5&      $ ButtonBorder��60    �@J�Opacity$ 1Q�6J   6V   �� 5'      $ ButtonBorder��64    � ��
 �   �6^   �� 5(      $ ButtonBorder��6<    �@J�BitmapEffect 5)      O� 5*      $
 Gray��64   $ 2Q�6E   $ 1Q�6R   6`   5,      5.      :� 5/      $ Grid.MouseEnter��6   $ StealthButtonOuterGrid��69   .[�50      �� 8��  6"   51      53      �� 55      " ��6"   .�56   
   ��  � ��# �   6%   57      58      