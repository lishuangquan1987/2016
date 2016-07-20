using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common;
using System.Drawing.Drawing2D;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // this.WindowState = FormWindowState.Maximized;
            SetRegion();
            this.trackBar1.Maximum = 100;
          
            //for (int i = 0; i <= 100; i++)
            //{
            //    this.trackBar1.Value = i;
            //    Application.DoEvents();
            //    System.Threading.Thread.Sleep(500);
                
            //}
        }
        void SetRegion()
        {
            //using (GraphicsPath path = GraphicsPathHelper.CreatePath(new Rectangle(Point.Empty, base.Size), 6, RoundStyle.All, true))
            //{
            //    Region region = new Region(path);
            //    path.Widen(Pens.White);
            //    region.Union(path);
            //    this.Region = region;
            //}
            GraphicsPathHelper.SetRegion(this,50);
        }
    }
}
