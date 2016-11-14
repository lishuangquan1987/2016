using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform_滚动字幕
{
    public partial class RollingText : UserControl
    {
        public RollingText()
        {
            InitializeComponent();
            timer1.Start();
        }
        public int Interval
        {
            get { return this.timer1.Interval; }
            set { if (value > 0) this.timer1.Interval = value; }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Point p = this.label1.Location;
            //this.Controls.Remove(label1);
            if (p.X >= this.Width)
                p.X = 0;
            p.X += 2;
            this.label1.Location = p;
            //this.Controls.Add(label1);
            //Application.DoEvents();
        }
        public string StrText
        {
            set { this.label1.Text = value; }
        }
        
    }
}
