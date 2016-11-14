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
using System.Drawing.Text;
using windows= System.Drawing;

namespace Visual命中测试
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
        TypeFaceViewModel tfVM = new TypeFaceViewModel();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.fontCom.ItemsSource = tfVM.lstFontFamily;
            this.fontCom.DisplayMemberPath = "Name";     
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(myPanel);
            DrawingVisual dv = myPanel.GetDrawingVisual(p);
            if (dv != null)
                return;
            dv = new DrawingVisual();
            DrawText("李双全", dv, p);
        }
        void DrawText(string text,DrawingVisual dv,Point p)
        {          
            DrawingContext dc = dv.RenderOpen();
            Brush brush = new SolidColorBrush(Colors.Red);
            Pen pen = new Pen();
            System.Drawing.FontFamily ff = this.fontCom.SelectedItem as System.Drawing.FontFamily;
            ff = ff == null ? new System.Drawing.FontFamily("宋体") : ff;
            Typeface tf = new Typeface(ff.Name);
            dc.DrawText(new FormattedText(text, System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, tf, 25, new SolidColorBrush(Colors.Blue)), p);
            dc.Close();
            myPanel.AddVisual(dv);
        }

        private void Window_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(myPanel);
            DrawingVisual dv = myPanel.GetDrawingVisual(p);
            if (dv != null)
                myPanel.DeleteVisual(dv);
        }

    }
}
