   M S B A M L   `   `   `  ����G  CCarSystemGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:CarSystemGUICarSystemGUI  5   	       CarSystemGUI.RepairInfo   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:CarSystemGUI     5   	     � Title$  
RepairInfo��5   	   $	��450��6   $	��300��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $��1* �6   �� 5      $��3* �6   �� 5      $��1* �6    � 	Resources 5   
    �� 
TargetType   TextBoxStyle2 �� BasedOn  
LabelStyle��%`   '��       7   '�� "     7  �� 5      " ��6   8   6)   �� 5      " ��6   8   6'   5      .+�5   
   �� -   5        $��lblDate��5      $��20(�6   $��Date of repair:��6-   $��35��6G   $	��200��6S   $��0��6`   $	��Top=�6m   (  "System.Windows.Controls.DatePicker  5   
   $
��Left=�6   $��	10,40,0,0q�5      $	��Top=�6#   $	��120��6;      SelectedDate 5   2   ��  �� Path$ DateOfRepair� �� Mode$ TwoWay=�5   ;   �� 5   
   -   5        $��lblDecription��5      $��Description:��6%   $	��200��6=   $	��Top=�6I   $��1��6a   $��20(�6n   $��0,6,0,0q�6|   �� 5   
   -   5        $��txtDecription��5      $��20(�6(   $
��Left=�66   $	��200��6Q   $	��284��6^   $��1��6j   
���   �$��Bottom=�5      
���   � �� 
IsReadOnly .  $��1,0,0,4q�6�   ��6@   �� $ Description�$ TwoWay=�	 �� UpdateSourceTrigger$	 	LostFocus=�6�   �� 5   
   	
 �� X1$	
 200��6   	 �� Y1$
 1100��6   	 �� X2$ 0��6"   	 �� Y2$
 1100��6*   $	��Top=�64   $��2��6L   
���   �$��1��5       �� Stretch$ Uniform=�62   �� 5    
   -   5        $��lblPrice��5       $��Price:��6    $��87��62   $��Center=�6=   $��2��6X   $��20(�6e   $
��0,24q�6s   �� 5!   
   -   5        $��txtPrice��5!      $��20(�6#   $��Center=�61   $��25��6N   $	��100��6Z   $��2��6f   
������ $��Center=�5"      
���   �.��6B   ��5#      �� 5$      $ Price�6    �� ValidatesOnDataErrors .  �� NotifyOnValidationError . $	 	LostFocus=�5%       �� ValidationRules 5&         CarSystemGUI.CustomRule  5'         PropertyName$ Price��6+   5)      .��5*      5+      5.      5/      