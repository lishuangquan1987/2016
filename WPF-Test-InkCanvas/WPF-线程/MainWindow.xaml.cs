using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_线程
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //System.Windows.Threading.Dispatcher d1 = System.Windows.Threading.Dispatcher.CurrentDispatcher;
            //System.Windows.Threading.Dispatcher d2 = this.Dispatcher;
            //MessageBox.Show((d1.Equals(d2)).ToString());
            System.Windows.Threading.Dispatcher d1 = System.Windows.Threading.Dispatcher.CurrentDispatcher;
            System.Windows.Threading.Dispatcher d2=null;
            System.Threading.Thread t = new System.Threading.Thread(() => { DoSomething(d2); });
            t.Start();
            MessageBox.Show((d1.Equals(d2)).ToString());
            d1.Invoke(() => { this.Title = "使用主线程调用"; });
            d2.Invoke(() => { this.Title = "使用其他线程调用"; });
            

        }
        void DoSomething(System.Windows.Threading.Dispatcher d)
        {
            d=System.Windows.Threading.Dispatcher.CurrentDispatcher;
            System.Threading.Thread.Sleep(5000);
        }
    }
}
