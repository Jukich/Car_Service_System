   M S B A M L   `   `   `  ����G  CCarSystemGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:CarSystemGUICarSystemGUI  5   	       CarSystemGUI.AddUserCar   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:CarSystemGUI     5   	     � Title$  
AddUserCar��5   	   $	��450��6   $	��300��6)   .��5
      � -   5        $��gr��5
       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � 	Resources 5   
    �� 
TargetType   TextBoxStyle2 �� BasedOn  
LabelStyle��%`   '��       7   '�� "     7  �� 5      " ��6   8   6)   �� 5      " ��6   8   6'   5      .+�5   
   �� -   5        $��lblBrand��5      $��Brand:��6    $��0��62   �� 5   
   -   5        $��cmbBrand��5      $��0��6#    �� 
IsReadOnly .  $��30��5      $	��100��6   $
��Left=�6+   $��135,20,0,15q�6G   ��5   C   �� *Brand+ �� SelectedValue 6b   ��  �� Path$ SelectedBrand�5      �� 5    
   -   5        $��lblMoedl��5       $��Model:��6    $��1��62   �� 5!   
   -   5        $��cmbModel��5!      $��1��6#    .  $��30��5"      $	��100��6   $
��Left=�6+   $��135,20,0,15q�6G   ��5!   C   �� *Model+ 6a   �� $ SelectedModel�5"   G   �� 5$   
   -   5        $��lblVinNumber��5$      $��2��6$   $��
VIN Number��61   $	��100��6F   �� 5%   
   -   5        $��txtVinNumber��5%      $��2��6&    �� 
IsReadOnly .  .��6G   ��5&      �� 5'      $ 	VINNumber�6   	 �� ValidatesOnDataErrors	 . 
 �� NotifyOnValidationError
 .  �� UpdateSourceTrigger$ PropertyChanged=�5(       �� ValidationRules 5)         CarSystemGUI.CustomRule  5*         PropertyName$ 	VinNumber��6+   5,      .��5-      5.      �� 50   
   -   5        $��lblRegNumber��50      $��3��6%   .��51      �� Regustration�� 6%   	Number:69   52      �� 53   
   -	   5        $��txtRegNumber��53      $��3��6&    .  .��6G   ��54      �� 55      $ 	RegNumber�6   	 . 
 . $ 	LostFocus=�56       57        58      $ 	RegNumber��6+   5:      .��5;      5<      �� 5>   
   -
   5        $��	lblColour��5>      $��Colour:��6!   $��4��64   �� 5?   
   -   5        $��	cmbColour��5?      $��4��6$    .  $��30��6D   $	��100��6P   $��135,20,0,15q�6\   $
��Left=�5@      ��6,   �� *Colour+ 6K   �� $ SelectedColour��� 5B   
   -   5         ��Name$ btnAdd��5B      $��Add new car��6!    �� 	IsDefault . $��5��6H   
������ ��5C      �� 5D      " ��6    �� Triggers 5E      �� 5F       �� Binding 6&   �� *Text.Length+ �� ElementName$ cmbBrand��$ PropertyChanged=� �� Value 06�   .a�5G      ��  �� Property � {� �� Value .  6:   5H      �� 5I       6&   �� *Text.Length+$ cmbModel��$ PropertyChanged=� 06�   .a�5J      ��  � {� .  6:   5K      �� 5L       6&   �� *Text.Length+$ 	cmbColour��$ PropertyChanged=� 06�   .a�5M      ��  � {� .  6:   5N      5P      5R      5T      5U      