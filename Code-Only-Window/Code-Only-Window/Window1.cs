using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Controls;

namespace Code_Only_Window
{
   public class Window1    :Window
    {
       private Button button;
       public Window1()
       {
           InitializeComponent();
       }
       private void InitializeComponent()
       {
           this.Height = 285;
           this.Width = 250;

           button = new Button();
           button.Content = "please click me";
           button.Margin = new Thickness(30);

           DockPanel panel = new DockPanel();
           panel.Children.Add(button);
           this.AddChild(panel);
           
             
           //IAddChild container = panel;
           //container.AddChild(button);
           //container = this;
           //container.AddChild(panel);
           button.Click += button_Click;   

       }

       void button_Click(object sender, RoutedEventArgs e)
       {
           (sender as Button).Content = "Thank you";
       }

    }
}
