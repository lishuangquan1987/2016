using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace xj.MusicPlayer
{
    public partial class Abut : MySkin.Main
    {
        public Abut()
        {
            InitializeComponent();
        }
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_MOVE = 0xF010;
        private const int HTCAPTION = 0x0002;
        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int SC_MAXIMIZE = 0xF030;
        private const int SC_MINIMIZE = 0xF020;
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://shang.qq.com/wpa/qunwpa?idkey=7471a27268b43281b19b4cc6c2d01d2175aeb732c68c68df271ba13e16d9156a");
        }

        private void Abut_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            this.btnClose.BackgroundImage = Properties.Resources.btn_close_highlight;
            pic.BackgroundImage = Properties.Resources.btn_close_highlight;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            this.btnClose.BackgroundImage = Properties.Resources.btn_close_normal;
            pic.BackgroundImage = Properties.Resources.btn_close_normal;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel1.Visible = true;
            t.Enabled = true;
        }

        private void t_Tick(object sender, EventArgs e)
        {
            label5.Top -= 1;
            if (label5.Top <= -179)
            { label5.Top = 0; }
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            t.Enabled = false;
            label5.Top = -34;
        }
    }
}
