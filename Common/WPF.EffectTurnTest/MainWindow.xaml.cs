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
using Common.WPF;

namespace WPF.EffectTurnTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EffectTurn effect;
        Page2 page2 = new Page2();
        public MainWindow()
        {
            InitializeComponent();
            effect = new EffectTurn(this);
            
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            effect.TurnPage(page1, page2, TurnType.Left);
        }
    }
}
