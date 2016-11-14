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

namespace WPF_ListView深入研究
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Student> lstStudent = new List<Student>()
            {
                new Student(){Name="li",Age=29},
                new Student(){Name="liu",Age=80}
            };
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this.lstStudent;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ListViewItem item = this.listView.ItemContainerGenerator.ContainerFromIndex(0) as ListViewItem;
            Student s = item.Content as Student;
            item.Background =new SolidColorBrush(Colors.Red);

            ListViewItem item1 = this.listView.ItemContainerGenerator.ContainerFromIndex(1) as ListViewItem;
            item1.Foreground = new SolidColorBrush(Colors.Yellow);

            TextBox u = GetListViewCellControl(1, 1) as TextBox;
            u.Background = new SolidColorBrush(Colors.Black);
            u.Foreground = new SolidColorBrush(Colors.White);
            
        }
        private UIElement GetListViewCellControl(int rowIndex, int cellIndex)
        {// rowIndex 和 cellIndex 基於 0.
            // 首先应得到 ListViewItem, 毋庸置疑, 所有可视UI 元素都继承了UIElement:
            UIElement u = listView.ItemContainerGenerator.ContainerFromIndex(rowIndex) as UIElement;
            if (u == null) return null;
            // 然后在 ListViewItem 元素树中搜寻 单元格:
            while ((u = (VisualTreeHelper.GetChild(u, 0) as UIElement)) != null)
                if (u is GridViewRowPresenter) return VisualTreeHelper.GetChild(VisualTreeHelper.GetChild(u, cellIndex), 0) as UIElement; return u;
        }
    }
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }

    }
}
