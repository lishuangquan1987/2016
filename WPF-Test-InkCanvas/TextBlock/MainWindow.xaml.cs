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

namespace TextBlock
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

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            new System.Threading.Thread(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Color color = i % 2 == 0 ? Colors.Red : Colors.Blue;
                    UpdateText("this is  i:" + i.ToString(), color, true);
                    System.Threading.Thread.Sleep(500);
                }
            }).Start();
        }
        delegate void deleUpdate(string msg, Color color, bool nextline);
        public void UpdateText(string msg, Color color, bool nextline)
        {
            this.Dispatcher.Invoke(new Action(() =>
            {
                SolidColorBrush _brushColor = new SolidColorBrush(color);
               
                string _msg=nextline ? msg + "\r\n" : msg;
                var r = new Run(_msg);
                Paragraph p = new Paragraph() { Foreground = _brushColor };
                p.Inlines.Add(r);
                rb.Document.Blocks.Add(p);
                rb.Focus();
                rb.ScrollToEnd();
            }));
        }

    }
}
