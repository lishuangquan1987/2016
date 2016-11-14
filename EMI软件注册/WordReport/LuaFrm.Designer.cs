namespace WordReport
{
    partial class LuaFrm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnReport = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.txtEncrypt = new System.Windows.Forms.TextBox();
            this.txtDecrypt = new System.Windows.Forms.TextBox();
            this.btnGetInfo = new System.Windows.Forms.Button();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.cmbLuaFiles = new System.Windows.Forms.ComboBox();
            this.cmbAtsFiles = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(928, 15);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(75, 23);
            this.btnReport.TabIndex = 0;
            this.btnReport.Text = "Word";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 384);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(337, 14);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(94, 23);
            this.btnEncrypt.TabIndex = 2;
            this.btnEncrypt.Text = "加 密&&保 存";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(802, 15);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(109, 23);
            this.btnDecrypt.TabIndex = 3;
            this.btnDecrypt.Text = "解 密&&存 储";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // txtEncrypt
            // 
            this.txtEncrypt.Location = new System.Drawing.Point(12, 59);
            this.txtEncrypt.Multiline = true;
            this.txtEncrypt.Name = "txtEncrypt";
            this.txtEncrypt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEncrypt.Size = new System.Drawing.Size(419, 206);
            this.txtEncrypt.TabIndex = 4;
            // 
            // txtDecrypt
            // 
            this.txtDecrypt.Location = new System.Drawing.Point(482, 59);
            this.txtDecrypt.Multiline = true;
            this.txtDecrypt.Name = "txtDecrypt";
            this.txtDecrypt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDecrypt.Size = new System.Drawing.Size(521, 206);
            this.txtDecrypt.TabIndex = 4;
            // 
            // btnGetInfo
            // 
            this.btnGetInfo.Location = new System.Drawing.Point(12, 302);
            this.btnGetInfo.Name = "btnGetInfo";
            this.btnGetInfo.Size = new System.Drawing.Size(111, 23);
            this.btnGetInfo.TabIndex = 5;
            this.btnGetInfo.Text = "获取硬件信息";
            this.btnGetInfo.UseVisualStyleBackColor = true;
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(156, 304);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(847, 21);
            this.txtInfo.TabIndex = 6;
            this.txtInfo.TextChanged += new System.EventHandler(this.txtInfo_TextChanged);
            // 
            // cmbLuaFiles
            // 
            this.cmbLuaFiles.FormattingEnabled = true;
            this.cmbLuaFiles.Location = new System.Drawing.Point(12, 15);
            this.cmbLuaFiles.Name = "cmbLuaFiles";
            this.cmbLuaFiles.Size = new System.Drawing.Size(306, 20);
            this.cmbLuaFiles.TabIndex = 7;
            // 
            // cmbAtsFiles
            // 
            this.cmbAtsFiles.FormattingEnabled = true;
            this.cmbAtsFiles.Location = new System.Drawing.Point(482, 15);
            this.cmbAtsFiles.Name = "cmbAtsFiles";
            this.cmbAtsFiles.Size = new System.Drawing.Size(314, 20);
            this.cmbAtsFiles.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 278);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "解密硬件信息";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 349);
            this.Controls.Add(this.cmbAtsFiles);
            this.Controls.Add(this.cmbLuaFiles);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnGetInfo);
            this.Controls.Add(this.txtDecrypt);
            this.Controls.Add(this.txtEncrypt);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnReport);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.TextBox txtEncrypt;
        private System.Windows.Forms.TextBox txtDecrypt;
        private System.Windows.Forms.Button btnGetInfo;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.ComboBox cmbLuaFiles;
        private System.Windows.Forms.ComboBox cmbAtsFiles;
        private System.Windows.Forms.Button button2;
    }
}

