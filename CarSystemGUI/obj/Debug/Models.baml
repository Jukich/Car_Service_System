   M S B A M L   `   `   `  ����G  CCarSystemGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:CarSystemGUICarSystemGUI  5          CarSystemGUI.Models   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:CarSystemGUI     5      -   5        $��
pageModels��5        N� Title$  Models��5
      .��5      � -   5        $��gr��5      
������� � 	Resources 5   
    �� 
TargetType   TextBoxInError �� BasedOn��%0   '��       7   �� 5      " ��6   8   6)   5       � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      5       � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   �� -   5        $��btnStartEdit��5   E   $��0��5      $��2��6   $	��100��6.   $��50��6:   $��	Edit mode��6F   
������ $��Right=�5      $	��Top=�6-   6Y   �� 5   
   -   5        $��btnStopEdit��5   E   $��0��5      $��2��6   $	��100��6.   $��50��6:   $��Stop edit mode��6F   
������ $��Right=�5      $	��Top=�6-   $y�Hidden=�6X   6l   �� 5    
   -   5        $��txtModelName��5       $��1��6&   $��2��63   $
��Left=�6C   $	��Top=�6^   $	��100��5!      $��30��6   $y�Hidden=�6*   .��6A   ��5"      �� 5#       �� Path$ 	ModelName�6    �� ValidatesOnDataErrors .  �� NotifyOnValidationError . 	 �� UpdateSourceTrigger$	 	LostFocus=�5$      
 �� ValidationRules
 5%         CarSystemGUI.CustomRule  5&         PropertyName$ Model��6+   5(      .��5)      5+      �� 5-   
   -   5        $��btnAdd��5.   D   $��1��5-   &   $��2��63   $	��100��6C   $��20��6O   $��Add new model��6[   
������ $
��Left=�5.      $	��Top=�6,   $��
0.4,35,0,0q�6R   $y�Hidden=�6f   �� 50   
   -   5        $��txtChangeName��50      $��1��6'   $��2��64   $��Right=�6D   #��[  6a   $	��Top=�51      $	��120��6*   $��30��66   $y�Hidden=�6B   .��6W   ��52      �� 53      $ 	BrandName�6    .  . $	 Explicit=�54      
 55        56      $ Brand��6+   58      .��59      5:      �� 5<   
   -   5        $��btnChangeName��5=   D   $��Change brand name��5<      $��1��6.   $��2��6;   $	��120��6K   $��20��6W   
������ $��Right=�5=      $	��Top=�6,   $��0,35,0,0q�6Y   $y�Hidden=�6k   �� 5?   
   -	   5        $��btnCnageIMG��5@   E   $��Change image��5?      $��1��6(   $��2��65   $	��266��6E   $��30��6Q   
������ $��Right=�5@      $	��Top=�6-   $��0,88,0,0q�6X   $y�Hidden=�6k   �� 5B   
   -
   5        $��btnRemoveModel��5C   E   $��Delete model��5B      $��1��6(   $��2��65   $	��266��6E   $��30��6Q   
������ $��Right=�5C      $	��Top=�6-   $��	0,168,0,0q�6[   $y�Hidden=�6n   �� 5E   
   -   5        $��btnRemoveBrand��5F   H   $��Delete brand��5E      $��1��6(   $��2��65   $	��266��6E   $��30��6Q   
���   �
�������$��Right=�5F      $��Bottom=�6-   $y�Hidden=�6^   6r   �� 5I   
   -   5        $��lblBrand��5I      $	��Top=�6    $��0��68   $��3��6E   $��35(�6Y   $��Center=�6g   $
��auto��6�   $��60��6�   &   System.Windows.Controls.DataGrid  5J   
   -   5        $��datagr��5M         HorizontalGridLinesBrush
 ����    VerticalGridLinesBrush
 ����    ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 5J   a   ��. $��Visible=�5K   8      RowBackground
 ���� 
������    SelectionMode$ Extended=�5L   H      CanUserAddRows .  $��1��5M   !   $��1��6.      AutoGenerateColumns .  $��20(�6Z   ��6h   �� *	_Models+ �� Mode$ TwoWay=� 5N      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� Property �� Value:  4System.Windows.Controls.Primitives.DataGridRowHeader��%  '        7 '  u     7 �� 5O      8   "  6Q   .�5P      ��  � ��
 ���� 63   �� 5Q       � ��
 �����63   5R      �� 5S      8   "  6N   .�5T      ��  � ��
 ���� 63   �� 5U       � ��
 �����63   5V      5W      !   RowValidationErrorTemplate 5Y      �� 5Z      .R�5[      � $��	0,-2,0,-2q�6    � ToolTip 5\      ��  �� RelativeSource �� *FindAncestor+ �� AncestorType)  #System.Windows.Controls.DataGridRow"  $) #(Validation.Errors)[0].ErrorContent�5_      5`         Columns 5b      0  *System.Windows.Controls.DataGridTextColumn  5c      -   5        	datagrCol��   FontSize$ 25Q�5c   8   ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly . 1	  +System.Windows.Controls.DataGridBoundColumn 	  EditingElementStyle 5e      �� 5f      " ��6    .�5g      -   5        5h       	  Binding 5j      �� 5k      $
 Name�6"   $	 PropertyChanged=�6.   $ OneTime=�6T   
 5l        5m   "   $
 Name��63   5p      5s      5u      5v      5w      