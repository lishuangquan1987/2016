using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Common
{
    public partial class TrackBar : UserControl
    {
        private Point location;

        private bool isMouseStatus;
        public delegate void ScrollValueEventHandler(object sender, EventArgs e);

        public event ScrollValueEventHandler ScrollValueChange;
        public TrackBar()
        {
            InitializeComponent();

        }

        [Browsable(true)]
        [Description("滑块的位置 ")]
        private int value;
        /// <summary>
        /// 滑块的位置
        /// </summary>
        public int Value
        {
            get { return this.value; }
            set
            {
                try
                {
                    //如果当前处于进度滑动状态则不允许改变Value值
                    if (isMouseStatus)
                    {

                    }
                    else
                    {
                        if (value <= this.maximum)
                        {
                            this.value = value;
                            //滑块坐标是从左边开始的，所以要减掉滑块本身的宽度
                            var track = (double)(this.Width - this.pnlSlider.Width / 2) / this.maximum;
                            var maxValue = track * this.value;
                            this.pnlSlider.Location = new Point(maxValue < 1 ? 1 : (int)maxValue, 0);
                        }
                        else
                        {
                            this.value = this.maximum;
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }


            }
        }

        [Browsable(true)]
        [Description("滑块的最大位置 ")]
        private int maximum;
        /// <summary>
        /// 滑块的最大位置
        /// </summary>
        public int Maximum
        {
            get { return maximum; }
            set
            {
                //如果当前处于进度滑动状态则不允许改变Value值
                if (isMouseStatus)
                {

                }
                else
                {
                    if (value >= this.value)
                    {
                        this.maximum = value;
                        var track = this.Width * 1.0 / (this.maximum * 1.0);
                        var maxValue = track * this.value;
                        this.pnlSlider.Location = new Point(maxValue < 1 ? 1 : (int)maxValue, 0);
                    }
                    else
                    {
                    }
                }
            }
        }

        protected virtual void ScrollValue(EventArgs e)
        {
            if (ScrollValueChange != null)
                ScrollValueChange(this, e);
        }

        /// <summary>
        /// 鼠标按钮下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlSlider_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.isMouseStatus = true;
                pnlSlider_MouseMove(sender, e);
            }
        }

        private void pnlSlider_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Point mousePointOnContainer = this.PointToClient(Control.MousePosition); // 鼠标在容器上的相对坐标
                //判断当前鼠标是否超出最小坐标值
                if (mousePointOnContainer.X < this.pnlSlider.Width - 5)
                {
                    this.pnlSlider.Location = new Point(0, 0); //将滑块归位到初始状态
                    this.value = 0;
                }
                //判断当前鼠标是否超出最大坐标值
                else if (mousePointOnContainer.X > (this.Width - this.pnlSlider.Width + 4))
                {
                    this.pnlSlider.Location = new Point(this.Width - this.pnlSlider.Width);
                    this.value = this.maximum;
                }
                else
                {
                    this.pnlSlider.Location = new Point((mousePointOnContainer.X - (this.pnlSlider.Width / 2)), 0);
                    this.value = (int)(this.pnlSlider.Location.X / (this.Width * 1.0 / (this.maximum * 1.0)));
                }
                ScrollValue(e);
            }
        }

        /// <summary>
        /// 鼠标释放事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlSlider_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)//鼠标左键按钮
            {
                this.isMouseStatus = false;
            }
        }

        /// <summary>
        /// 鼠标按钮下时定位进度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExTrackBar_MouseDown(object sender, MouseEventArgs e)
        {
            pnlSlider_MouseMove(sender, e);
        }
    }
}
