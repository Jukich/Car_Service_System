   M S B A M L   `   `   `  ����G  CCarSystemGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:CarSystemGUICarSystemGUI  5          CarSystemGUI.App   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      ,localclr-namespace:CarSystemGUI     5        �� 	Resources  5         TextBoxStyle �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value �� Self �� RelativeSource	 �� Path  
LabelStyle  TextBoxInError  TextBoxStyle2
 �� CornerRadius � ToolTip �� ElementName��%=  &	        &	 )    &	 �    &	 �    �� 5   
   " ��6%   .�5	      ��  � ��$ 0q�60   �� 5
       � ��$ 20(�6)   �� 5       � ��$	 290��6&   �� 5       � ��$ Center=�62   �� 5       � ��$ Right=�64   �� 5       �@��TextAlignment$
 Left=�6.   �� 5       � ��
 ���� 6+   �� 5       � ��
 �   �6+   �� 5       �@��
IsReadOnly . 6+    5      P� 5       �@=�HasError . . �5      ��  �@�ToolTip 5   	   �� # Z $&	  (Validation.Errors)/ErrorContent�5      5      �� 5   
   " ��6#   .�5      ��  � ��$ 15(�6)   �� 5       � ��$ 95��6&   �� 5       � ��$ Center=�62   �� 5       � ��$
 Left=�64   5      �� 5!   
   " ��6'    5"      P� 5#       �@=�HasError . . �5$      ��  �@�ToolTip 5%      �� # Z $)	 #(Validation.Errors)[0].ErrorContent�5'      5)      �� 5+   
   " ��6&   .�5,      ��  � ��$ 0,5,9,4q�6'   �� 5-       � ��$ 15(�6)   �� 5.       � ��$	 150��6&   �� 5/       � ��$ 25��6'   �� 50       � ��$ Center=�62   �� 51       � ��$ Right=�64   �� 52       �@��TextAlignment$
 Left=�6.   �� 54       �@=�ErrorTemplate 55      �� 56      .R�57      ]� ��. .+�58      �� 
���  ��$
��Left=�66   $��	-30,0,0,0q�6L   $��15��6_   $��15��6j   $
 10��6v    59   .   �� $ customAdorner��$8	 2AdornedElement.(Validation.Errors)[0].ErrorContent�._�5:   "   �� $��!��6,   $��Center=�65   $��Center=�6P   $��0��6m   $
��Bold"�6z   
�������5;   #   5<      �� 5=      $��customAdorner��68   $��Center=�6M   $��Right=�6h   .v�5>   "   �� 
���  ��$��1q�6;   5?      5@      5A      5C      5D      5F      5G      