   M S B A M L   `   `   `  ����^  ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35rNclr-namespace:System.Windows.Automation.Peers;assembly=WindowsFormsIntegrationSystem.Windows.Automation.Peers  5   	   A =Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/$clr-namespace:Common;assembly=CommonCommon 5   	   U QSystem.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3aG4clr-namespace:System.Drawing;assembly=System.DrawingSystem.Drawing 5   	    LoadingCircleTest"   LoadingCircleTest.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   jWindowsFormHostNclr-namespace:System.Windows.Automation.Peers;assembly=WindowsFormsIntegration     5   	   >LoadingCircle$clr-namespace:Common;assembly=Common     5   	   HDrawing4clr-namespace:System.Drawing;assembly=System.Drawing     5   	   -   5          � Title$  
MainWindow��5   	   $	��175��6   $��537.069��6)    � WindowStyle$
 None=�69    � Topmost . 
������� J� Opacity$	 0.8Q�6�   .��5      � $��0q�6    � RowDefinitions 5
   
   �� 5      $��50 �6   6*   �� 5      6   .+�5   
   �� -   5        $��lbMsg��5   l   $!��正在加载，请稍后...��6   $��Center=�6&   $��Center=�6J   
����  �6�   7   1System.Windows.Forms.Integration.WindowsFormsHost  5   
   -   5        $
��host��5   ;   $��1��6      
Background
 �����   Child. 5        Common.LoadingCircle  -   5        loadingCircle��   Active .    InnerCircleRadius$ 12��5   P   	   OuterCircleRadius$	 20��6g   
   RotationSpeed$	
 160��6~      SpokeThickness$ 5��6�   5      5      5      5      