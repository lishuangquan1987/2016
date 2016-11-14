using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Markup;
using System.Windows;

namespace WPF练习4
{
   public class Class1: Application
    {
       [STAThread]
       static void Main()
       {
           Class1 app = new Class1();
           app.MainWindow = new MainWindow("Window1.xaml");
           app.MainWindow.ShowDialog();
       }
    }
}
