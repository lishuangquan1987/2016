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
using System.IO;
using System.Net;

namespace FTP示例
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FtpWebRequest ftpRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://127.0.0.1:21/sogou_pinyin_8.0.0.8268_6991.exe"));
            ftpRequest.UseBinary = true;
            FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse();
            Stream ftpStream = response.GetResponseStream();
            long lenth = response.ContentLength;
            int bufferSize = 2048;
            int readCount = 0;
            byte[] tempbytes=new byte[bufferSize];
            FileStream outputStream = new FileStream("111.exe", FileMode.Append, FileAccess.Write);
            do
            {
                readCount = ftpStream.Read(tempbytes, 0, tempbytes.Length);
                outputStream.Write(tempbytes, 0, readCount);
            }
            while (readCount > 0);
            ftpStream.Close();
            outputStream.Close();
            response.Close();

            System.Diagnostics.Process.Start("111.exe");
            
        }
    }
}
