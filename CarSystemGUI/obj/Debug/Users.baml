   M S B A M L   `   `   `  ����G  CCarSystemGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:CarSystemGUICarSystemGUI  5          CarSystemGUI.Users   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:CarSystemGUI     5        N� Title$  Users��5	      .��5      � 
������� � RowDefinitions 5   
   �� 5      $	��13* �6   �� 5      $��1* �6   .+�5   
   �� -   5        $��1��5      $	��800��6   $��0q�6*   
������ $��Add User��5   *   $��17(�6=   $��	UltraBold"�6K   $��0,0.4,0,1.6q�6z   &   System.Windows.Controls.DataGrid  5   
   -   5        $��datagr��5         HorizontalGridLinesBrush
 ����    VerticalGridLinesBrush
 ����    ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 5   `   ��. $��Visible=�5   8      RowBackground
 ���� 
������    SelectionMode$ Extended=�5   H      CanUserAddRows .     AutoGenerateColumns .  $��20(�5   >   $��Times New Roman)�6L   $��0��6i   ��6v   �� *_User+	 � 	Resources	 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader
 �� BasedOn �� 
TargetType �� Property �� Value:  4System.Windows.Controls.Primitives.DataGridRowHeader��%.  '        7 '  �     7 �� 5      8
   "  6Q   .�5      ��  � ��
 ���� 63   �� 5       � ��
 �   �63   �� 5       � ��$ Center=�6<   5      �� 5      8
   "  6N   .�5      ��  � ��
 ���� 63   �� 5       � ��
 �����63   5      5          Columns 5!      0  *System.Windows.Controls.DataGridTextColumn  5"      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6%   -   5        datagrNameCol��   Width$
 auto 5"   J      FontSize$ 30Q�6W      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6e   �� *Name+5$        5%      $ Surename��6%   -   5        datagrSurenameCol��$	 200 5%   R   $ 30Q�6_    .  6m   �� *
Surename+   ElementStyle 5&      �� 5'      " ��6    .�5(      ��  � ��$ Center=�6D   5)      5,        5-      $ Email��6%   -   5        datagrEmailCol��$
 auto 5-   M   $ 30Q�6Z    .  6h   �� *Email+5/      4  .System.Windows.Controls.DataGridTemplateColumn  51      $ 	More info��6)      CellTemplate 52      �� 53      .R�54      �� -   5        
������ .��54   T   	Details6]   55      57      5:      5;      5<      