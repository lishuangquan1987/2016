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
using GDJL.MTST.Model;


namespace 数据库操作
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            Login login = new Login();
            login.ShowDialog();
            InitializeComponent();
            
        }
        

        private void ImportBtn_Click(object sender, RoutedEventArgs e)
        {
            ImPortData importWindow = new ImPortData();
            importWindow.ShowDialog();
        }

        private void OKBtn_Click(object sender, RoutedEventArgs e)
        {
            
            
        }

        private void QueryBtn_Click(object sender, RoutedEventArgs e)
        {
            QueryData queryWin = new QueryData();
            queryWin.ShowDialog();
        }
      
    }
}
