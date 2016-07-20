namespace xj.MusicPlayer.ctrl
{
    partial class NavControl
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
            this.btnPrev = new System.Windows.Forms.Panel();
            this.lbPrev = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Panel();
            this.lbNext = new System.Windows.Forms.Label();
            this.btnPrev.SuspendLayout();
            this.btnNext.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPrev
            // 
            this.btnPrev.Controls.Add(this.lbPrev);
            this.btnPrev.ForeColor = System.Drawing.Color.DimGray;
            this.btnPrev.Location = new System.Drawing.Point(26, 3);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(50, 20);
            this.btnPrev.TabIndex = 0;
            // 
            // lbPrev
            // 
            this.lbPrev.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbPrev.Location = new System.Drawing.Point(0, 0);
            this.lbPrev.Name = "lbPrev";
            this.lbPrev.Size = new System.Drawing.Size(50, 20);
            this.lbPrev.TabIndex = 0;
            this.lbPrev.Text = "上一页";
            this.lbPrev.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbPrev.Click += new System.EventHandler(this.lbPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Controls.Add(this.lbNext);
            this.btnNext.ForeColor = System.Drawing.Color.DimGray;
            this.btnNext.Location = new System.Drawing.Point(161, 3);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(50, 20);
            this.btnNext.TabIndex = 0;
            // 
            // lbNext
            // 
            this.lbNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbNext.Location = new System.Drawing.Point(0, 0);
            this.lbNext.Name = "lbNext";
            this.lbNext.Size = new System.Drawing.Size(50, 20);
            this.lbNext.TabIndex = 0;
            this.lbNext.Text = "下一页";
            this.lbNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbNext.Click += new System.EventHandler(this.lbNext_Click);
            // 
            // NavControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Name = "NavControl";
            this.Size = new System.Drawing.Size(240, 26);
            this.Load += new System.EventHandler(this.NavControl_Load);
            this.btnPrev.ResumeLayout(false);
            this.btnNext.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel btnPrev;
        private System.Windows.Forms.Label lbPrev;
        private System.Windows.Forms.Panel btnNext;
        private System.Windows.Forms.Label lbNext;
    }
}
