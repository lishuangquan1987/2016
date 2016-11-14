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

namespace 数据库操作
{
    /// <summary>
    /// Interaction logic for BusyUC.xaml
    /// </summary>
    public partial class BusyUC : UserControl
    {
        public BusyUC()
        {
            InitializeComponent();
            this.loadingCircle.Color = System.Drawing.Color.Blue;
            this.MsgLable.Content = "";
        }
    }
}
