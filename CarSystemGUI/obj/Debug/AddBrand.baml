   M S B A M L   `   `   `  ����G  CCarSystemGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:CarSystemGUICarSystemGUI  5   	       CarSystemGUI.AddBrand   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:CarSystemGUI     5   	     � Title$  AddBrand��5   	   $	��300��6   $	��300��6'   .��5	      � -   5        $��gr��5	       � 	Resources 5
   
    �� 
TargetType   TextBoxInError �� BasedOn��%0   '��       7   �� 5      " ��6   8   6)   5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��Choose brand name: ��6   $��30��6.   $��Bottom=�6:   $��1��6U   $	��120��6b   $��Center=�6n   �� 5   
   -   5        $��txtRead��5      $��30��6!   $	��100��6-   $	��Top=�69   $��2��6Q   .��6`   ��5      �� 5       �� Path$ _Name�6    �� ValidatesOnDataErrors .  �� NotifyOnValidationError .  �� UpdateSourceTrigger$ PropertyChanged=�5      	 �� Mode$	 TwoWay=�6=   
 �� ValidationRules
 5         CarSystemGUI.CustomRule  5         PropertyName$ Brand��6+   5      .��5      5      �� 5   
   -   5        $��Choose image��5      $��30��6(   $	��100��64   $��2��6@   $��Center=�6M   $��Center=�6h   
������ $��2��6�   �� 5    
   -   5        $��btnAdd��5       $��	Add Brand��6   $��30��63   $	��100��6?   $��4��6K   {�.  
������ $	��Top=�5!   <   5#      5$      