   M S B A M L   `   `   `  ����  大文件的拷贝#    大文件的拷贝.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)   .��5      ��  �� Orientation$ Vertical=�6   .+�5   
   �� $ 
Horizontal=�6   .+�5      �� .��6   要拷贝的文件：6   �� 5      -   5        $��tb_sourcePath��5   "   $	��400��6   ��67   �� *
sourcePath+6U   �� 5	      -   5        $��20��5	      $��Center=�6    $	��Top=�6D   ��6c   ��  �� ElementName$ 
sourcePath�� �� Path$ 
Background�.��6�   ...6�   5
      �� 5   
   $ Vertical=�6   .+�5      �� $ 
Horizontal=�6   .+�5      �� .��6   存放目录：6   �� 5      -   5        $��tb_destiDir��5   &   $	��400��6   ��69   �� *	destiPath+6V   �� 5      -   5        $��20��5      $��Center=�6$   $	��Top=�6H   ��6g   �� $ 
sourcePath��$ 
Background�.��6�   ...6�   5      5      �� 5   
   -   5        $��	btn_Start��5   >   $	��100��6   $��43��6   $��208,0,209,0q�6)   .��6g   开始6k   � 5   
   -   5        $��
processBar��5   .   $��20��6   $	��300��6"   6B   5      5      