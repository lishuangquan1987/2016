   M S B A M L   `   `   `  ����F  BWPFControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WPFControlsWPFControls  5          WPFControls.UCListView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:WPFControls     5      
�������$	��592��5   6     � 	Resources  5	          WPFControls.ColorConverter   colorConverter �� 
TargetType �� Property �� Value �� Mode �� UpdateSourceTrigger �� 	Converter �� Triggers P� Property	 P� Value
 :� RoutedEvent �� TargetProperty W� From	 W� To g� Duration��%_  &	        '��      7   '�� �      5
   
   68   �� 5   
   " ��6   .�5      ��  � �� 6+   �� *
TestStatus+$ TwoWay=�$ PropertyChanged=�8   6�   �� 5       � ��$ Center=�6;   6L    5      P� 5       �@��
IsSelected	 . . �5      ��  � ��
 ����6H   5      :� 5      $
 
MouseEnter��6   .[�5      �� .��5      �� .��5      W� $ FontSize�6.   $ 12X�6T   $ 20X�6^   $ 0:0:0.1D�6f   6{   5      5      5      :� 5      $
 
MouseLeave��6   .[�5      �� .��5      �� .��5      W� $ FontSize�6.   $ 20X�6T   $ 12X�6^   $ 0:0:0.1D�6f   6{   5      5      5      5"      �� 5#   
   " ��6   .�5$      ��  � ��
 ��ح�6@   �� 5%       � ��$ 18(�6)   66   �� 5&       � ��$
 Bold"�6+   6:   5'      5(      .��5)      � .+�5*   
   �� $��Center=�6   ��68   �� *LstTestItem+ �� View 5+      �� 5,      .P�5-      �� $��ItemName��6&    �� Width$	 150��68    �� DisplayMemberBinding 6D   �� *
ItemName+$ TwoWay=�$ PropertyChanged=�6�   �� 5.      $��Upper��6%   $ 70��65    6@   �� *Upper+$ TwoWay=�$ PropertyChanged=�6�   �� 5/      $��Lower��6%   $ 70��65    6@   �� *Lower+$ TwoWay=�$ PropertyChanged=�6�   �� 50      $��Value��6%   $	 200��65    6A   �� *Value+$ TwoWay=�$ PropertyChanged=�6�   51      54      58      59      