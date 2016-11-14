using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Code_Only_Window
{
   public class Program :Application
    {
       [STAThread()]
       static void Main()
       {
           Program c = new Program();
           c.MainWindow = new Window1();
           c.MainWindow.ShowDialog();
       }
    }
}
