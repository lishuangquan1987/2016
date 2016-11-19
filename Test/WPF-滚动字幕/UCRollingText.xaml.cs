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

namespace WPF_滚动字幕
{
    /// <summary>
    /// Interaction logic for UCRollingText.xaml
    /// </summary>
    public partial class UCRollingText : UserControl
    {
        public UCRollingText()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            new System.Threading.Thread(Rolling).Start();
        }
        double i = 0;
        public bool isClose = false;
        private void Rolling()
        {
            while (!isClose)
            {
                i++;
                if (i >= this.mainGrid.ActualWidth)
                    i = 0;
                this.Dispatcher.Invoke(new Action(() => this.lb_Msg.Margin = new Thickness(i,0,0,0)));
                System.Threading.Thread.Sleep(delay);
            }
        }
        private int delay = 50;
        public int Delay
        {
            get { return delay; }
            set { this.delay = value; }
        }
        public string Text
        {
            get { return this.lb_Msg.Content.ToString(); }
            set { this.lb_Msg.Content = value; }
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            isClose = true;
        }
        

    }
}
