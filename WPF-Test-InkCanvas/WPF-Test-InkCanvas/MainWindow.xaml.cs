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
using System.IO;
using System.Windows;

namespace WPF_Test_InkCanvas
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            foreach(InkCanvasEditingMode mode in Enum.GetValues(typeof(InkCanvasEditingMode)))
            {
                this.combox.Items.Add(mode);
            }
            this.combox.SelectedIndex = 0;
        }

        private void combox_Selected(object sender, RoutedEventArgs e)
        {
            this.inkCanvas.EditingMode = (InkCanvasEditingMode)((ComboBox)sender).SelectedItem;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            
            System.Windows.Forms.SaveFileDialog sfd=new System.Windows.Forms.SaveFileDialog();
            sfd.Filter="图片文件|*.bmp";
            if(sfd.ShowDialog()!= System.Windows.Forms.DialogResult.OK)
                return;

            InkCanvas ink = this.inkCanvas;
            string path = sfd.FileName;
            FileStream fs = new FileStream(path, FileMode.Create); //文件流对象  
            //RenderTargetBitmap用来创建一副位图对象  
            RenderTargetBitmap rtb = new RenderTargetBitmap((int)ink.ActualWidth,
            (int)ink.ActualHeight, 1/100, 1/100, PixelFormats.Default);
            rtb.Render(ink); //呈现位图对象  
            //BitmapEncoder用来保存BitmapFrame对象，并保存为指定的文件  
            //BitmapFrame是图像数据  
            BitmapEncoder be = new TiffBitmapEncoder(); //指定格式  
            be.Frames.Add(BitmapFrame.Create(rtb));
            be.Save(fs);
            fs.Close();  
            
        }
    }
}
