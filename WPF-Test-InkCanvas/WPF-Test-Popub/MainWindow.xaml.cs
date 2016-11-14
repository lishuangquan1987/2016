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

namespace WPF_Test_Popub
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
        //protected override void OnMouseDown(MouseButtonEventArgs e)
        //{
            
        //    base.OnMouseDown(e);
        //    //MessageBox.Show(e.OriginalSource.ToString());
        //    this.textbox.AppendText(e.Source.ToString() + "\r\n");
        //}

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //MessageBox.Show(e.OriginalSource.ToString());
            this.textbox.AppendText(e.Source.ToString() + "\r\n");
        }
    }
}
