   M S B A M L   `   `   `  ����  WPF_按钮旋转!    WPF_按钮旋转.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)    � 	Resources 5       �� 
TargetType �� Property �� Value �� Triggers :� RoutedEvent W� From	 W� To	 �� TargetProperty
 g� Duration g� RepeatBehavior��%W  '��       �� 5   
   " ��6   .�5      ��  �@J�RenderTransformOrigin$ 0.5,0.5&�66   6H   �� 5       � z� 5	      �� 5
      6(   5       5      :� 5      $ 
MouseEnter��6   [�5      �� 5      .��5      �� .��5   "   W� $ 0X�62   $	 360X�6;   $	 RenderTransform.Angle�6D   $
 0:0:0.2D�6v   $ Forever��6�   6�   5      5      5      :� 5      $ 
MouseLeave��6   [�5      �� 5      .��5      �� .��5   "   W� $	 RenderTransform.Angle�62   $
 0:0:0.2D�6d   6z   5      5      5      5!      5"      .��5#      � .+�5$   
   �� $��Button��6   $
��Left=�6"   $��163,111,0,0q�6=   $	��Top=�6R   $	��166��6j   $��58��6v   5&      5'      