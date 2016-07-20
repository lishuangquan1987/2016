using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace xj.MusicPlayer
{
    public partial class Down : Form
    {
        public static string ud;
        public static string name;
        public Down(string Nam, string URL)
        {
            InitializeComponent();
            ud = URL; name = Nam.Trim();
            label1.Text += name;
            this.Text = "正在下载：" + name;
            if (!File.Exists(Application.StartupPath + "\\Music"))
            {
                Directory.CreateDirectory(Application.StartupPath + "\\Music");
            }
            Thread t = new Thread(Dowon);
            t.IsBackground = true;
            t.Start();
        }

        /// <summary>
        /// 下载文件的线程
        /// </summary>
        public void Dowon()
        {
            try
            {
                System.Net.HttpWebRequest Myrq = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(ud);
                System.Net.HttpWebResponse myrp = (System.Net.HttpWebResponse)Myrq.GetResponse();
                long totalBytes = myrp.ContentLength;
                if (prog != null)
                {
                    prog.Maximum = (int)totalBytes;
                }
                System.IO.Stream st = myrp.GetResponseStream();
                System.IO.Stream so = new System.IO.FileStream(Application.StartupPath + "\\Music\\" + name + ".mp3", System.IO.FileMode.Create);
                label1.Text += "\r\t下载到：" + Application.StartupPath + "\\Music\\" + name + ".mp3";
                long totalDownloadedByte = 0;
                byte[] by = new byte[1024];
                int osize = st.Read(by, 0, (int)by.Length);
                while (osize > 0)
                {
                    totalDownloadedByte = osize + totalDownloadedByte;
                    System.Windows.Forms.Application.DoEvents();
                    so.Write(by, 0, osize);
                    if (prog != null)
                    {
                        prog.Value = (int)totalDownloadedByte;
                    }
                    osize = st.Read(by, 0, (int)by.Length);
                }
                label1.Text += "\r\t下载完毕";
                Thread t = new Thread(close); Thread.Sleep(2000);
                t.Start();
                so.Close();
                st.Close();
            }
            catch (Exception)
            {
                label1.Text += "\r\t下载失败";
                Thread t = new Thread(close); Thread.Sleep(3000);
                t.Start();
            }
        }

        public void close()
        {
            this.Close();
            this.Dispose();
        }
    }
}
