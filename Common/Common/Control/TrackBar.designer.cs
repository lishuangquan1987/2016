namespace Common
{
    partial class TrackBar
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrackBar));
            this.pnlSlider = new System.Windows.Forms.PictureBox();
            this.lb_Describe = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSlider
            // 
            this.pnlSlider.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlSlider.Image = ((System.Drawing.Image)(resources.GetObject("pnlSlider.Image")));
            this.pnlSlider.Location = new System.Drawing.Point(-1, 3);
            this.pnlSlider.Name = "pnlSlider";
            this.pnlSlider.Size = new System.Drawing.Size(22, 22);
            this.pnlSlider.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pnlSlider.TabIndex = 4;
            this.pnlSlider.TabStop = false;
            this.pnlSlider.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlSlider_MouseDown);
            this.pnlSlider.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlSlider_MouseMove);
            this.pnlSlider.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlSlider_MouseUp);
            // 
            // lb_Describe
            // 
            this.lb_Describe.AutoSize = true;
            this.lb_Describe.Location = new System.Drawing.Point(75, 39);
            this.lb_Describe.Name = "lb_Describe";
            this.lb_Describe.Size = new System.Drawing.Size(0, 12);
            this.lb_Describe.TabIndex = 5;
            // 
            // TrackBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Controls.Add(this.lb_Describe);
            this.Controls.Add(this.pnlSlider);
            this.Name = "TrackBar";
            this.Size = new System.Drawing.Size(173, 22);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ExTrackBar_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pnlSlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pnlSlider;
        private System.Windows.Forms.Label lb_Describe;




    }
}
