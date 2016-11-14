using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Markup;

namespace WPF练习4
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public MainWindow(string path)
        {
            this.Width = this.Top = 285;
            this.Left = this.Top = 80;
              DependencyObject xmlElement;
            using (FileStream fs = new FileStream(path,FileMode.Open))
            {
               xmlElement  =(DependencyObject) XamlReader.Load(fs);

            }
            this.Content = xmlElement;

            Button button =(Button) LogicalTreeHelper.FindLogicalNode(xmlElement, "jjjj");
            button.Content = "fjdsjfldsj";
            button.Click += button_Click;
        }

        void button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(((Button)sender).Content.ToString());
        }
    }
}
