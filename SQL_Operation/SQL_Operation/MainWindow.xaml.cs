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
using System.Collections.ObjectModel;

namespace SQL_Operation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = lstPerson;
            
           
        }
        ObservableCollection<Person> lstPerson = new ObservableCollection<Person>();
        OperationBLL bll = new OperationBLL();
        private void btn_Click(object sender, RoutedEventArgs e)
        {

            //lstPerson.Clear();
            List<Person> _lstPerson = bll.Query("select * from person");
            _lstPerson.ForEach(x => { lstPerson.Add(x); });
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
    }
}
