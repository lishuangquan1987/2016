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

namespace 大文件的拷贝
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }
       public string sourcePath = "";
       public string destiPath = "";
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog op = new System.Windows.Forms.OpenFileDialog();
            op.Multiselect = false;
            if (op.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                sourcePath = null;                
                return;
            }
            sourcePath = op.FileName;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(sourcePath==null)
            {
                MessageBox.Show("请先选择文件");
                return;
            }
            System.Windows.Forms.FolderBrowserDialog fbd = new System.Windows.Forms.FolderBrowserDialog();
            if (fbd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                destiPath = null;
                return;
            }
            destiPath = System.IO.Path.Combine(fbd.SelectedPath, System.IO.Path.GetFileName(sourcePath));
        }

        private void btn_Start_Click(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(sourcePath))
            {
                MessageBox.Show("文件不存在");
                return;
            }
            int transferCount = 1024000;
            FileInfo ff = new FileInfo(sourcePath);
            byte[] bytes = new byte[transferCount];
            this.processBar.Maximum=ff.Length/transferCount;
            new System.Threading.Thread(() =>
            {
                FileStream fs_read = new FileStream(sourcePath, FileMode.Open, FileAccess.Read);
                FileStream fs_write = new FileStream(destiPath, FileMode.Append, FileAccess.Write);
                int readCount = 0;
                int i = 1;
                do
                {
                    this.Dispatcher.Invoke(new Action(() => { this.processBar.Value = i; }));
                    readCount = fs_read.Read(bytes, 0, bytes.Length);
                    fs_write.Write(bytes, 0, bytes.Length);
                    i++;

                }
                while (readCount > 0);
                fs_read.Close();
                fs_write.Close();
            }).Start();
            

        }
    }
}
