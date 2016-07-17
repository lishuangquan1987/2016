using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 图片缩放
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Point originalPoint = new Point(0, 0);
        private Point originalLocation = new Point(0, 0);
        private bool canMove = false;
        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.pictureBox1.Size = this.panel1.Size;
            this.pictureBox1.Location = new Point(0, 0);

           
           
        }
        protected override void OnDragDrop(DragEventArgs drgevent)
        {
            base.OnDragEnter(drgevent);
            if (!drgevent.Data.GetDataPresent(DataFormats.FileDrop))
                return;
            Array paths = (Array)drgevent.Data.GetData(DataFormats.FileDrop);
            string path = paths.GetValue(0).ToString();
            Bitmap bmp=null;
            try
            {
                bmp= new Bitmap(path);
            }
            catch(Exception e)
            {
                bmp=null;
            }
            if (bmp != null)
                this.pictureBox1.BackgroundImage = bmp;
           
        }
        protected override void OnDragEnter(DragEventArgs drgevent)
        {
            base.OnDragDrop(drgevent);
            if (drgevent.Data.GetDataPresent(DataFormats.FileDrop))
                drgevent.Effect = DragDropEffects.Link;
            else
                drgevent.Effect = DragDropEffects.None;
         }
        /// <summary>
        /// 判断点是否在picturebox内
        /// </summary>
        /// <param name="p"></param>
        /// <param name="pixturebox"></param>
        /// <returns></returns>
        bool IsPointInPictureBox(Point p, PictureBox pixturebox)
        {
            int pb_Range_Xmin = pixturebox.Location.X;
            int pb_Range_Xmax = pixturebox.Location.X + pixturebox.Width;
            int pb_Range_Ymin = pixturebox.Location.Y;
            int pb_Range_Ymax = pixturebox.Location.Y + pixturebox.Height;
            if (p.X >= pb_Range_Xmin && p.X <= pb_Range_Xmax && p.Y >= pb_Range_Ymin && p.Y <= pb_Range_Ymax)
                return true;
            else
                return false;
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {

            if (!canMove)
                return;
            //PictureBox picturebox = sender as PictureBox;
            Point p = new Point(0, 0);
            if (!User32DllHelper.GetCursorPos(ref p))
            {
                MessageBox.Show("User32DllHelper.GetCursorPos获取坐标失败！");

                return;
            }
            //label2.Text = string.Format("移动时的坐标：x:{0},y:{1}", p.X, p.Y);
            Move(originalLocation, originalPoint, p, this.pictureBox1);

            //GC.Collect();
                

        }
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            if (!IsPointInPictureBox(e.Location, pictureBox1))
            {
                return;
            }
            //MessageBox.Show("x:" + e.X + "y:" + e.Y);
            if (e.Delta > 0)
            {
                ExpandByPoint(this.pictureBox1, e.Location, 1.1);
            }
            else
                ExpandByPoint(this.pictureBox1, e.Location, 0.9);
        }
        void ExpandByPoint(Control control,Point point, double para)
        {
            Point oriLocation = control.Location;
            Size oriSize = control.Size;           
            Size newSize = new Size((int)(oriSize.Width * para), (int)(oriSize.Height * para));
            Point newLocation = new Point((int)(para * (oriLocation.X - point.X) + point.X),(int)( para * (oriLocation.Y - point.Y) + point.Y));
            control.Size = newSize;
            control.Location = newLocation;
        }
        void Move(Point originalLocation, Point originalPoint, Point currentPoint,Control control)
        {
            Point currentLocation = new Point(0, 0);
            currentLocation.X = (originalLocation.X - (originalPoint.X - currentPoint.X));
            currentLocation.Y = (originalLocation.Y - (originalPoint.Y - currentPoint.Y));
            //if (currentLocation.X <= 0 || currentLocation.Y <= 0 || currentLocation.X >= control.Parent.Width || currentLocation.Y >= control.Parent.Height)
            //    return;
            control.Location = currentLocation;
            //Application.DoEvents();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {

                 if (e.Button != System.Windows.Forms.MouseButtons.Left)
                     return;

                 Point p = new Point(0, 0);
                 if (!User32DllHelper.GetCursorPos(ref p))
                 {
                     MessageBox.Show("User32DllHelper.GetCursorPos获取坐标失败！");

                     return;
                 }
                 //label1.Text = string.Format("鼠标点下时的坐标：x:{0},y:{1}",p.X,p.Y);
                 originalPoint = p;
                 originalLocation = this.pictureBox1.Location;
                 canMove = true;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Left)
                return;
            if (!canMove)
                return;
            Point p = new Point(0, 0);
            if (!User32DllHelper.GetCursorPos(ref p))
            {
                MessageBox.Show("User32DllHelper.GetCursorPos获取坐标失败！");

                return;
            }
            //label2.Text = string.Format("鼠标松开时的坐标：x:{0},y:{1}", p.X, p.Y);
            Move(originalLocation, originalPoint, p, this.pictureBox1);
            canMove = false;
        }

        //private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        //{
        //  
        //}

        //private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        //{
        //    
        //}

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "选择图片";
            if (op.ShowDialog() != DialogResult.OK)
                return;
            this.pictureBox1.BackgroundImage = new Bitmap(op.FileName);
            
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            Point centerPoint=new Point(this.pictureBox1.Location.X+this.pictureBox1.Width/2,this.pictureBox1.Location.Y+this.pictureBox1.Height/2);
            ExpandByPoint(this.pictureBox1, centerPoint, 1.1);
        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            Point centerPoint = new Point(this.pictureBox1.Location.X + this.pictureBox1.Width / 2, this.pictureBox1.Location.Y + this.pictureBox1.Height / 2);
            ExpandByPoint(this.pictureBox1, centerPoint, 0.9);
        }

        private void pictureBox1_DragDrop(object sender, DragEventArgs e)
        {
            OnDragDrop(e);
        }

        private void pictureBox1_DragEnter(object sender, DragEventArgs e)
        {
            OnDragEnter(e);
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            OnDragDrop(e);
        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            OnDragEnter(e);
        }
    }
}
