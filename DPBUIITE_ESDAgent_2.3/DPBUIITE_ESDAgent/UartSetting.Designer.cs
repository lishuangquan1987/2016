namespace DPBUIITE_ESDAgent
    {
    partial class UartSetting
        {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System. ComponentModel. IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
            {
            if (disposing && (components != null))
                {
                components. Dispose();
                }
            base. Dispose(disposing);
            }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
            {
                this.gb_ISP = new System.Windows.Forms.GroupBox();
                this.btTest_ESD = new System.Windows.Forms.Button();
                this.cb_ESDStopBits = new System.Windows.Forms.ComboBox();
                this.cb_ESDDataBits = new System.Windows.Forms.ComboBox();
                this.cb_ESDParity = new System.Windows.Forms.ComboBox();
                this.cb_ESDBautRate = new System.Windows.Forms.ComboBox();
                this.cb_ESDPort = new System.Windows.Forms.ComboBox();
                this.cb_ESDModel = new System.Windows.Forms.ComboBox();
                this.cb_ESDCommunicationType = new System.Windows.Forms.ComboBox();
                this.label15 = new System.Windows.Forms.Label();
                this.label16 = new System.Windows.Forms.Label();
                this.label17 = new System.Windows.Forms.Label();
                this.label18 = new System.Windows.Forms.Label();
                this.label19 = new System.Windows.Forms.Label();
                this.label20 = new System.Windows.Forms.Label();
                this.label21 = new System.Windows.Forms.Label();
                this.cb_EnableESDBoard = new System.Windows.Forms.CheckBox();
                this.bt_Save = new System.Windows.Forms.Button();
                this.bt_Cancel = new System.Windows.Forms.Button();
                this.gb_ISP.SuspendLayout();
                this.SuspendLayout();
                // 
                // gb_ISP
                // 
                this.gb_ISP.Controls.Add(this.btTest_ESD);
                this.gb_ISP.Controls.Add(this.cb_ESDStopBits);
                this.gb_ISP.Controls.Add(this.cb_ESDDataBits);
                this.gb_ISP.Controls.Add(this.cb_ESDParity);
                this.gb_ISP.Controls.Add(this.cb_ESDBautRate);
                this.gb_ISP.Controls.Add(this.cb_ESDPort);
                this.gb_ISP.Controls.Add(this.cb_ESDModel);
                this.gb_ISP.Controls.Add(this.cb_ESDCommunicationType);
                this.gb_ISP.Controls.Add(this.label15);
                this.gb_ISP.Controls.Add(this.label16);
                this.gb_ISP.Controls.Add(this.label17);
                this.gb_ISP.Controls.Add(this.label18);
                this.gb_ISP.Controls.Add(this.label19);
                this.gb_ISP.Controls.Add(this.label20);
                this.gb_ISP.Controls.Add(this.label21);
                this.gb_ISP.Controls.Add(this.cb_EnableESDBoard);
                this.gb_ISP.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                this.gb_ISP.Location = new System.Drawing.Point(12, 12);
                this.gb_ISP.Name = "gb_ISP";
                this.gb_ISP.Size = new System.Drawing.Size(182, 305);
                this.gb_ISP.TabIndex = 16;
                this.gb_ISP.TabStop = false;
                this.gb_ISP.Text = "ESD連線治具";
                // 
                // btTest_ESD
                // 
                this.btTest_ESD.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                this.btTest_ESD.Location = new System.Drawing.Point(6, 267);
                this.btTest_ESD.Name = "btTest_ESD";
                this.btTest_ESD.Size = new System.Drawing.Size(170, 30);
                this.btTest_ESD.TabIndex = 19;
                this.btTest_ESD.Text = "測試";
                this.btTest_ESD.UseVisualStyleBackColor = true;
                this.btTest_ESD.Click += new System.EventHandler(this.btTest_ESD_Click);
                // 
                // cb_ESDStopBits
                // 
                this.cb_ESDStopBits.FormattingEnabled = true;
                this.cb_ESDStopBits.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "1.5"});
                this.cb_ESDStopBits.Location = new System.Drawing.Point(61, 235);
                this.cb_ESDStopBits.Name = "cb_ESDStopBits";
                this.cb_ESDStopBits.Size = new System.Drawing.Size(115, 26);
                this.cb_ESDStopBits.TabIndex = 14;
                this.cb_ESDStopBits.Text = "0";
                // 
                // cb_ESDDataBits
                // 
                this.cb_ESDDataBits.FormattingEnabled = true;
                this.cb_ESDDataBits.Items.AddRange(new object[] {
            "8",
            "7",
            "6"});
                this.cb_ESDDataBits.Location = new System.Drawing.Point(61, 203);
                this.cb_ESDDataBits.Name = "cb_ESDDataBits";
                this.cb_ESDDataBits.Size = new System.Drawing.Size(115, 26);
                this.cb_ESDDataBits.TabIndex = 13;
                this.cb_ESDDataBits.Text = "8";
                // 
                // cb_ESDParity
                // 
                this.cb_ESDParity.FormattingEnabled = true;
                this.cb_ESDParity.Items.AddRange(new object[] {
            "NONE",
            "ODD",
            "EVEN",
            "MARK",
            "SPACE"});
                this.cb_ESDParity.Location = new System.Drawing.Point(61, 174);
                this.cb_ESDParity.Name = "cb_ESDParity";
                this.cb_ESDParity.Size = new System.Drawing.Size(115, 26);
                this.cb_ESDParity.TabIndex = 12;
                this.cb_ESDParity.Text = "NONE";
                // 
                // cb_ESDBautRate
                // 
                this.cb_ESDBautRate.FormattingEnabled = true;
                this.cb_ESDBautRate.Items.AddRange(new object[] {
            "115200",
            "56000",
            "38400",
            "19200",
            "9600",
            "4800",
            "1200",
            "300"});
                this.cb_ESDBautRate.Location = new System.Drawing.Point(61, 145);
                this.cb_ESDBautRate.Name = "cb_ESDBautRate";
                this.cb_ESDBautRate.Size = new System.Drawing.Size(115, 26);
                this.cb_ESDBautRate.TabIndex = 11;
                this.cb_ESDBautRate.Text = "115200";
                // 
                // cb_ESDPort
                // 
                this.cb_ESDPort.FormattingEnabled = true;
                this.cb_ESDPort.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8"});
                this.cb_ESDPort.Location = new System.Drawing.Point(61, 116);
                this.cb_ESDPort.Name = "cb_ESDPort";
                this.cb_ESDPort.Size = new System.Drawing.Size(115, 26);
                this.cb_ESDPort.TabIndex = 10;
                this.cb_ESDPort.Text = "COM1";
                this.cb_ESDPort.SelectedIndexChanged += new System.EventHandler(this.cb_ESDPort_SelectedIndexChanged);
                // 
                // cb_ESDModel
                // 
                this.cb_ESDModel.FormattingEnabled = true;
                this.cb_ESDModel.Location = new System.Drawing.Point(61, 87);
                this.cb_ESDModel.Name = "cb_ESDModel";
                this.cb_ESDModel.Size = new System.Drawing.Size(115, 26);
                this.cb_ESDModel.TabIndex = 9;
                this.cb_ESDModel.Text = "ESD_Board";
                this.cb_ESDModel.SelectedIndexChanged += new System.EventHandler(this.cb_ESDModel_SelectedIndexChanged);
                // 
                // cb_ESDCommunicationType
                // 
                this.cb_ESDCommunicationType.DropDownWidth = 115;
                this.cb_ESDCommunicationType.FormattingEnabled = true;
                this.cb_ESDCommunicationType.Items.AddRange(new object[] {
            "RS-232",
            "USB"});
                this.cb_ESDCommunicationType.Location = new System.Drawing.Point(61, 55);
                this.cb_ESDCommunicationType.Name = "cb_ESDCommunicationType";
                this.cb_ESDCommunicationType.Size = new System.Drawing.Size(115, 26);
                this.cb_ESDCommunicationType.TabIndex = 8;
                this.cb_ESDCommunicationType.Text = "RS-232";
                this.cb_ESDCommunicationType.SelectedIndexChanged += new System.EventHandler(this.cb_ESDCommunicationType_SelectedIndexChanged);
                // 
                // label15
                // 
                this.label15.AutoSize = true;
                this.label15.Location = new System.Drawing.Point(6, 238);
                this.label15.Name = "label15";
                this.label15.Size = new System.Drawing.Size(62, 18);
                this.label15.TabIndex = 7;
                this.label15.Text = "StopBits:";
                // 
                // label16
                // 
                this.label16.AutoSize = true;
                this.label16.Location = new System.Drawing.Point(6, 206);
                this.label16.Name = "label16";
                this.label16.Size = new System.Drawing.Size(62, 18);
                this.label16.TabIndex = 6;
                this.label16.Text = "DataBits:";
                // 
                // label17
                // 
                this.label17.AutoSize = true;
                this.label17.Location = new System.Drawing.Point(6, 177);
                this.label17.Name = "label17";
                this.label17.Size = new System.Drawing.Size(46, 18);
                this.label17.TabIndex = 5;
                this.label17.Text = "Parity:";
                // 
                // label18
                // 
                this.label18.AutoSize = true;
                this.label18.Location = new System.Drawing.Point(6, 148);
                this.label18.Name = "label18";
                this.label18.Size = new System.Drawing.Size(59, 18);
                this.label18.TabIndex = 4;
                this.label18.Text = "Bu/Rate:";
                // 
                // label19
                // 
                this.label19.AutoSize = true;
                this.label19.Location = new System.Drawing.Point(6, 119);
                this.label19.Name = "label19";
                this.label19.Size = new System.Drawing.Size(36, 18);
                this.label19.TabIndex = 3;
                this.label19.Text = "Port:";
                // 
                // label20
                // 
                this.label20.AutoSize = true;
                this.label20.Location = new System.Drawing.Point(6, 90);
                this.label20.Name = "label20";
                this.label20.Size = new System.Drawing.Size(47, 18);
                this.label20.TabIndex = 2;
                this.label20.Text = "Model:";
                // 
                // label21
                // 
                this.label21.AutoSize = true;
                this.label21.Location = new System.Drawing.Point(6, 58);
                this.label21.Name = "label21";
                this.label21.Size = new System.Drawing.Size(41, 18);
                this.label21.TabIndex = 1;
                this.label21.Text = "Type:";
                // 
                // cb_EnableESDBoard
                // 
                this.cb_EnableESDBoard.AutoSize = true;
                this.cb_EnableESDBoard.Checked = true;
                this.cb_EnableESDBoard.CheckState = System.Windows.Forms.CheckState.Checked;
                this.cb_EnableESDBoard.Location = new System.Drawing.Point(8, 21);
                this.cb_EnableESDBoard.Name = "cb_EnableESDBoard";
                this.cb_EnableESDBoard.Size = new System.Drawing.Size(136, 22);
                this.cb_EnableESDBoard.TabIndex = 0;
                this.cb_EnableESDBoard.Text = "Enable ESD Board";
                this.cb_EnableESDBoard.UseVisualStyleBackColor = true;
                // 
                // bt_Save
                // 
                this.bt_Save.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                this.bt_Save.Location = new System.Drawing.Point(111, 334);
                this.bt_Save.Name = "bt_Save";
                this.bt_Save.Size = new System.Drawing.Size(83, 30);
                this.bt_Save.TabIndex = 20;
                this.bt_Save.Text = "SAVE";
                this.bt_Save.UseVisualStyleBackColor = true;
                this.bt_Save.Click += new System.EventHandler(this.bt_Save_Click);
                // 
                // bt_Cancel
                // 
                this.bt_Cancel.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                this.bt_Cancel.Location = new System.Drawing.Point(12, 334);
                this.bt_Cancel.Name = "bt_Cancel";
                this.bt_Cancel.Size = new System.Drawing.Size(83, 30);
                this.bt_Cancel.TabIndex = 21;
                this.bt_Cancel.Text = "Cancel";
                this.bt_Cancel.UseVisualStyleBackColor = true;
                this.bt_Cancel.Click += new System.EventHandler(this.bt_Cancel_Click);
                // 
                // UartSetting
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(210, 385);
                this.Controls.Add(this.bt_Cancel);
                this.Controls.Add(this.bt_Save);
                this.Controls.Add(this.gb_ISP);
                this.Name = "UartSetting";
                this.Text = "UartSetting";
                this.Load += new System.EventHandler(this.UartSetting_Load);
                this.gb_ISP.ResumeLayout(false);
                this.gb_ISP.PerformLayout();
                this.ResumeLayout(false);

            }

        #endregion

        private System. Windows. Forms. GroupBox gb_ISP;
        private System. Windows. Forms. Button btTest_ESD;
        private System. Windows. Forms. ComboBox cb_ESDStopBits;
        private System. Windows. Forms. ComboBox cb_ESDDataBits;
        private System. Windows. Forms. ComboBox cb_ESDParity;
        private System. Windows. Forms. ComboBox cb_ESDBautRate;
        private System. Windows. Forms. ComboBox cb_ESDPort;
        private System. Windows. Forms. ComboBox cb_ESDModel;
        private System. Windows. Forms. ComboBox cb_ESDCommunicationType;
        private System. Windows. Forms. Label label15;
        private System. Windows. Forms. Label label16;
        private System. Windows. Forms. Label label17;
        private System. Windows. Forms. Label label18;
        private System. Windows. Forms. Label label19;
        private System. Windows. Forms. Label label20;
        private System. Windows. Forms. Label label21;
        private System. Windows. Forms. CheckBox cb_EnableESDBoard;
        private System. Windows. Forms. Button bt_Save;
        private System. Windows. Forms. Button bt_Cancel;
        }
    }