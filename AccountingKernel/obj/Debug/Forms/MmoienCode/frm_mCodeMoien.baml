   M S B A M L   `   `   `  ����g  cStimulsoft.Report.WpfDesign, Version=2010.1.700.0, Culture=neutral, PublicKeyToken=ebe6666cba19647anNclr-namespace:Stimulsoft.Report.WpfDesign;assembly=Stimulsoft.Report.WpfDesignStimulsoft.Report.WpfDesign  5   	    AccountingKernel6   0AccountingKernel.Forms.MmoienCode.frm_mCodeMoien   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   d	WpfDesignNclr-namespace:Stimulsoft.Report.WpfDesign;assembly=Stimulsoft.Report.WpfDesign     5   	     � Title$  frm_mCodeMoien��5   	   $	��600��6       WindowStyle#���   6-   $	��800��6S    � WindowStartupLocation$ CenterScreen=�6_   $��RightToLeft=�6�   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 	grd_moien��5      $��10q�6&     DataGridStyle#��[ 62      AutoGenerateColumns .     AlternatingRowBackground
 �����   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5	      ,  &System.Windows.Controls.DataGridColumn   Header$
 کد��6B      
IsReadOnly .     
Visibility$ Hidden=�6a   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6&   �� 
 �� Path$
 Id�6a     5
      $ نام گروه��6B    .  	 6%   �� *
MIdGroup+6T     5      $ نام کل��6@    .  	 6%   �� *MIdAll+6P     5      $ معین��6?    .  	 6%   �� *MName+6M     5      $ کد معین��6B    .  	 6%   �� *
MIdMoein+6S    � ContextMenu 5      �� 5      .@�5      m� -   5         m�Name$ mnu_reg��5      $��جدید��60   6>   m� 5      -   5        $ mnu_edit��5      $��ویرایش��61   6A   m� 5      -   5        $ 
mnu_remove��5      $��حذف��63   6@   m� 5      -   5        $ mnu_more��5      $��سطوح تفصیلی��61   .@�5      m� -   5        $# mnu_modiriate_hesabe_tafsili_��5   #   $&�� تعیین سطوح تقصیلی��6J   6e   5      5       �� 
GroupStyle 5      (  "System.Windows.Controls.GroupStyle  5         ContainerStyle 5      �� 5       �� 
TargetType" ��6    .�5      ��  �� Property � �� �� Value 5   "   �� 5   &    �� 
TargetType" ��66   .R�5    *   9�  9� 
IsExpanded . ��5!   .   �� 5"   2    �� Orientation$ 
Horizontal=�6=   .+�5#   6   �� $��DemiBold"�6Z   ��6@   �� *
MIdGroup+6Z   �� 5$   6   $
�� a  ��6@   �� 5%   6   $��DemiBold"�6@   ��6V   �� *	ItemCount+5&   3   .��5(   .   �� 5)   +   5*   '   5,      5-         Panel 5/      �� 50      .R�51      >  8System.Windows.Controls.Primitives.DataGridRowsPresenter  52      54      56      59      5:      