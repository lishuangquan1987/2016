using xj.MusicPlayer.Properties;

namespace xj.MusicPlayer
{
    partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.lbTitle = new System.Windows.Forms.Label();
            this.panelVol = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPlay = new System.Windows.Forms.PictureBox();
            this.btnPrev = new System.Windows.Forms.PictureBox();
            this.btnNext = new System.Windows.Forms.PictureBox();
            this.lbTime = new System.Windows.Forms.Label();
            this.picHead = new System.Windows.Forms.PictureBox();
            this.pMain = new System.Windows.Forms.Panel();
            this.muing = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pMusicList = new System.Windows.Forms.Panel();
            this.axWindowsMediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.pGroup = new System.Windows.Forms.Panel();
            this.pGroups = new System.Windows.Forms.Panel();
            this.lbAddMusic = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbAddFolder = new System.Windows.Forms.Label();
            this.lbMusicOnline = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbLocalMusic = new System.Windows.Forms.Label();
            this.lbCollection = new System.Windows.Forms.Label();
            this.panelMyMusic = new System.Windows.Forms.Panel();
            this.lbTextRolling = new System.Windows.Forms.Timer(this.components);
            this.pBottom = new System.Windows.Forms.Panel();
            this.down = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.btnHide = new System.Windows.Forms.PictureBox();
            this.Skin = new System.Windows.Forms.PictureBox();
            this.Skins = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.div = new System.Windows.Forms.PictureBox();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.Errs = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.not = new System.Windows.Forms.NotifyIcon(this.components);
            this.Mene = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.播放暂停ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.上一首ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.下一首ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.锁屏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Nso = new System.Windows.Forms.Label();
            this.Suo = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.trackBar1 = new xj.fm.xinli001.com.ctrl.TrackBar();
            this.volControl = new xj.fm.xinli001.com.ctrl.TrackBar();
            this.panelVol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPlay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHead)).BeginInit();
            this.pMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.muing)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer)).BeginInit();
            this.pGroup.SuspendLayout();
            this.pGroups.SuspendLayout();
            this.pBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.down)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Skin)).BeginInit();
            this.Skins.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.div)).BeginInit();
            this.Errs.SuspendLayout();
            this.Mene.SuspendLayout();
            this.panel4.SuspendLayout();
            this.Suo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbTitle.Font = new System.Drawing.Font("宋体", 10F);
            this.lbTitle.ForeColor = System.Drawing.Color.Gainsboro;
            this.lbTitle.Location = new System.Drawing.Point(73, 5);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(194, 16);
            this.lbTitle.TabIndex = 1;
            this.lbTitle.Text = "Tom音乐 - 音乐你的生活";
            this.lbTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainWindow_MouseDown);
            // 
            // panelVol
            // 
            this.panelVol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelVol.BackColor = System.Drawing.Color.Transparent;
            this.panelVol.Controls.Add(this.volControl);
            this.panelVol.Controls.Add(this.panel1);
            this.panelVol.Location = new System.Drawing.Point(535, 13);
            this.panelVol.Name = "panelVol";
            this.panelVol.Size = new System.Drawing.Size(75, 25);
            this.panelVol.TabIndex = 13;
            this.panelVol.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainWindow_MouseDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::xj.MusicPlayer.Properties.Resources.playing_volumn_slide_sound_icon_pressed;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(23, 23);
            this.panel1.TabIndex = 2;
            // 
            // btnPlay
            // 
            this.btnPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPlay.BackColor = System.Drawing.Color.Transparent;
            this.btnPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPlay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlay.Image = global::xj.MusicPlayer.Properties.Resources.playbtn_play;
            this.btnPlay.Location = new System.Drawing.Point(314, 6);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(46, 46);
            this.btnPlay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnPlay.TabIndex = 10;
            this.btnPlay.TabStop = false;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrev.BackColor = System.Drawing.Color.Transparent;
            this.btnPrev.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrev.BackgroundImage")));
            this.btnPrev.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrev.Location = new System.Drawing.Point(273, 6);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(35, 46);
            this.btnPrev.TabIndex = 11;
            this.btnPrev.TabStop = false;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNext.BackColor = System.Drawing.Color.Transparent;
            this.btnNext.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNext.BackgroundImage")));
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.Location = new System.Drawing.Point(366, 6);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(35, 46);
            this.btnNext.TabIndex = 12;
            this.btnNext.TabStop = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lbTime
            // 
            this.lbTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbTime.AutoSize = true;
            this.lbTime.BackColor = System.Drawing.Color.Transparent;
            this.lbTime.ForeColor = System.Drawing.Color.White;
            this.lbTime.Location = new System.Drawing.Point(621, 43);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(35, 12);
            this.lbTime.TabIndex = 8;
            this.lbTime.Text = "00:00";
            this.lbTime.TextChanged += new System.EventHandler(this.lbTime_TextChanged);
            this.lbTime.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainWindow_MouseDown);
            // 
            // picHead
            // 
            this.picHead.BackColor = System.Drawing.Color.Transparent;
            this.picHead.Image = global::xj.MusicPlayer.Properties.Resources.Tomlogo1;
            this.picHead.Location = new System.Drawing.Point(0, -1);
            this.picHead.Name = "picHead";
            this.picHead.Size = new System.Drawing.Size(71, 71);
            this.picHead.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHead.TabIndex = 0;
            this.picHead.TabStop = false;
            this.picHead.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainWindow_MouseDown);
            // 
            // pMain
            // 
            this.pMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.pMain.Controls.Add(this.muing);
            this.pMain.Controls.Add(this.panel2);
            this.pMain.Controls.Add(this.axWindowsMediaPlayer);
            this.pMain.Controls.Add(this.pGroup);
            this.pMain.Location = new System.Drawing.Point(0, 63);
            this.pMain.Name = "pMain";
            this.pMain.Size = new System.Drawing.Size(672, 298);
            this.pMain.TabIndex = 2;
            // 
            // muing
            // 
            this.muing.Image = global::xj.MusicPlayer.Properties.Resources.henniu;
            this.muing.Location = new System.Drawing.Point(-6, 294);
            this.muing.Name = "muing";
            this.muing.Size = new System.Drawing.Size(667, 3);
            this.muing.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.muing.TabIndex = 4;
            this.muing.TabStop = false;
            this.muing.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.pMusicList);
            this.panel2.Location = new System.Drawing.Point(96, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(563, 298);
            this.panel2.TabIndex = 3;
            // 
            // pMusicList
            // 
            this.pMusicList.AutoScroll = true;
            this.pMusicList.BackColor = System.Drawing.Color.Transparent;
            this.pMusicList.Location = new System.Drawing.Point(0, 0);
            this.pMusicList.Name = "pMusicList";
            this.pMusicList.Size = new System.Drawing.Size(568, 298);
            this.pMusicList.TabIndex = 2;
            this.pMusicList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainWindow_MouseDown);
            // 
            // axWindowsMediaPlayer
            // 
            this.axWindowsMediaPlayer.Enabled = true;
            this.axWindowsMediaPlayer.Location = new System.Drawing.Point(-90, -90);
            this.axWindowsMediaPlayer.Name = "axWindowsMediaPlayer";
            this.axWindowsMediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer.OcxState")));
            this.axWindowsMediaPlayer.Size = new System.Drawing.Size(30, 10);
            this.axWindowsMediaPlayer.TabIndex = 0;
            this.axWindowsMediaPlayer.Visible = false;
            // 
            // pGroup
            // 
            this.pGroup.BackColor = System.Drawing.Color.Transparent;
            this.pGroup.Controls.Add(this.pGroups);
            this.pGroup.Controls.Add(this.panelMyMusic);
            this.pGroup.Location = new System.Drawing.Point(6, 0);
            this.pGroup.Name = "pGroup";
            this.pGroup.Size = new System.Drawing.Size(80, 259);
            this.pGroup.TabIndex = 0;
            // 
            // pGroups
            // 
            this.pGroups.Controls.Add(this.lbAddMusic);
            this.pGroups.Controls.Add(this.label3);
            this.pGroups.Controls.Add(this.lbAddFolder);
            this.pGroups.Controls.Add(this.lbMusicOnline);
            this.pGroups.Controls.Add(this.label1);
            this.pGroups.Controls.Add(this.lbLocalMusic);
            this.pGroups.Controls.Add(this.lbCollection);
            this.pGroups.Location = new System.Drawing.Point(0, 23);
            this.pGroups.Name = "pGroups";
            this.pGroups.Size = new System.Drawing.Size(80, 233);
            this.pGroups.TabIndex = 8;
            // 
            // lbAddMusic
            // 
            this.lbAddMusic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbAddMusic.ForeColor = System.Drawing.Color.DarkGray;
            this.lbAddMusic.Location = new System.Drawing.Point(-3, 195);
            this.lbAddMusic.Name = "lbAddMusic";
            this.lbAddMusic.Size = new System.Drawing.Size(80, 35);
            this.lbAddMusic.TabIndex = 1;
            this.lbAddMusic.Text = "音乐";
            this.lbAddMusic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbAddMusic.Click += new System.EventHandler(this.panelAddMusic_Click);
            this.lbAddMusic.MouseEnter += new System.EventHandler(this.lbMouseEnter);
            this.lbAddMusic.MouseLeave += new System.EventHandler(this.lbMouseLeave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(4, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "我的音乐";
            // 
            // lbAddFolder
            // 
            this.lbAddFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbAddFolder.ForeColor = System.Drawing.Color.DarkGray;
            this.lbAddFolder.Location = new System.Drawing.Point(0, 158);
            this.lbAddFolder.Name = "lbAddFolder";
            this.lbAddFolder.Size = new System.Drawing.Size(80, 35);
            this.lbAddFolder.TabIndex = 1;
            this.lbAddFolder.Text = "文件夹";
            this.lbAddFolder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbAddFolder.Click += new System.EventHandler(this.panelAddFolder_Click);
            this.lbAddFolder.MouseEnter += new System.EventHandler(this.lbMouseEnter);
            this.lbAddFolder.MouseLeave += new System.EventHandler(this.lbMouseLeave);
            // 
            // lbMusicOnline
            // 
            this.lbMusicOnline.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbMusicOnline.ForeColor = System.Drawing.Color.DarkGray;
            this.lbMusicOnline.Location = new System.Drawing.Point(0, 20);
            this.lbMusicOnline.Name = "lbMusicOnline";
            this.lbMusicOnline.Size = new System.Drawing.Size(80, 35);
            this.lbMusicOnline.TabIndex = 0;
            this.lbMusicOnline.Text = "心理ＦＭ";
            this.lbMusicOnline.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbMusicOnline.Click += new System.EventHandler(this.lbMusicOnline_Click);
            this.lbMusicOnline.MouseEnter += new System.EventHandler(this.lbMouseEnter);
            this.lbMusicOnline.MouseLeave += new System.EventHandler(this.lbMusicOnline_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(4, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "添加";
            // 
            // lbLocalMusic
            // 
            this.lbLocalMusic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbLocalMusic.ForeColor = System.Drawing.Color.DarkGray;
            this.lbLocalMusic.Location = new System.Drawing.Point(-2, 55);
            this.lbLocalMusic.Name = "lbLocalMusic";
            this.lbLocalMusic.Size = new System.Drawing.Size(80, 35);
            this.lbLocalMusic.TabIndex = 0;
            this.lbLocalMusic.Text = "本地音乐";
            this.lbLocalMusic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbLocalMusic.Click += new System.EventHandler(this.lbLocalMusic_Click);
            this.lbLocalMusic.MouseEnter += new System.EventHandler(this.lbMouseEnter);
            this.lbLocalMusic.MouseLeave += new System.EventHandler(this.lbLocalMusic_MouseLeave);
            // 
            // lbCollection
            // 
            this.lbCollection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbCollection.ForeColor = System.Drawing.Color.DarkGray;
            this.lbCollection.Location = new System.Drawing.Point(-2, 90);
            this.lbCollection.Name = "lbCollection";
            this.lbCollection.Size = new System.Drawing.Size(80, 35);
            this.lbCollection.TabIndex = 0;
            this.lbCollection.Text = "在线音乐";
            this.lbCollection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbCollection.Click += new System.EventHandler(this.lbCollection_Click);
            this.lbCollection.MouseEnter += new System.EventHandler(this.lbMouseEnter);
            this.lbCollection.MouseLeave += new System.EventHandler(this.lbCollection_MouseLeave);
            // 
            // panelMyMusic
            // 
            this.panelMyMusic.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMyMusic.Location = new System.Drawing.Point(0, 0);
            this.panelMyMusic.Name = "panelMyMusic";
            this.panelMyMusic.Size = new System.Drawing.Size(80, 24);
            this.panelMyMusic.TabIndex = 7;
            // 
            // lbTextRolling
            // 
            this.lbTextRolling.Enabled = true;
            this.lbTextRolling.Interval = 500;
            this.lbTextRolling.Tick += new System.EventHandler(this.lbTextRolling_Tick);
            // 
            // pBottom
            // 
            this.pBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pBottom.BackColor = System.Drawing.Color.Transparent;
            this.pBottom.BackgroundImage = global::xj.MusicPlayer.Properties.Resources.bei;
            this.pBottom.Controls.Add(this.down);
            this.pBottom.Controls.Add(this.picHead);
            this.pBottom.Controls.Add(this.lbTitle);
            this.pBottom.Controls.Add(this.trackBar1);
            this.pBottom.Controls.Add(this.lbTime);
            this.pBottom.Controls.Add(this.panelVol);
            this.pBottom.Controls.Add(this.btnNext);
            this.pBottom.Controls.Add(this.btnPrev);
            this.pBottom.Controls.Add(this.btnPlay);
            this.pBottom.Location = new System.Drawing.Point(0, 360);
            this.pBottom.Name = "pBottom";
            this.pBottom.Size = new System.Drawing.Size(661, 70);
            this.pBottom.TabIndex = 3;
            this.pBottom.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainWindow_MouseDown);
            // 
            // down
            // 
            this.down.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.down.BackColor = System.Drawing.Color.Transparent;
            this.down.Cursor = System.Windows.Forms.Cursors.Hand;
            this.down.Image = global::xj.MusicPlayer.Properties.Resources.down;
            this.down.Location = new System.Drawing.Point(507, 16);
            this.down.Name = "down";
            this.down.Size = new System.Drawing.Size(16, 26);
            this.down.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.down.TabIndex = 14;
            this.down.TabStop = false;
            this.down.Click += new System.EventHandler(this.down_Click);
            this.down.MouseEnter += new System.EventHandler(this.down_MouseEnter);
            this.down.MouseLeave += new System.EventHandler(this.down_MouseLeave);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClose.Location = new System.Drawing.Point(632, -1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 27);
            this.btnClose.TabIndex = 4;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.Close_Click);
            this.btnClose.MouseEnter += new System.EventHandler(this.btnClose_MouseEnter);
            this.btnClose.MouseLeave += new System.EventHandler(this.btnClose_MouseLeave);
            // 
            // btnHide
            // 
            this.btnHide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHide.BackColor = System.Drawing.Color.Transparent;
            this.btnHide.BackgroundImage = global::xj.MusicPlayer.Properties.Resources.btn_mini_normal;
            this.btnHide.Location = new System.Drawing.Point(604, -1);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(30, 27);
            this.btnHide.TabIndex = 5;
            this.btnHide.TabStop = false;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            this.btnHide.MouseEnter += new System.EventHandler(this.btnHide_MouseEnter);
            this.btnHide.MouseLeave += new System.EventHandler(this.btnHide_MouseLeave);
            // 
            // Skin
            // 
            this.Skin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Skin.BackColor = System.Drawing.Color.Transparent;
            this.Skin.BackgroundImage = global::xj.MusicPlayer.Properties.Resources.skin;
            this.Skin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Skin.Location = new System.Drawing.Point(572, -1);
            this.Skin.Name = "Skin";
            this.Skin.Size = new System.Drawing.Size(28, 28);
            this.Skin.TabIndex = 6;
            this.Skin.TabStop = false;
            this.Skin.Click += new System.EventHandler(this.Skin_Click);
            this.Skin.MouseEnter += new System.EventHandler(this.Skin_MouseEnter);
            this.Skin.MouseLeave += new System.EventHandler(this.Skin_MouseLeave);
            // 
            // Skins
            // 
            this.Skins.BackColor = System.Drawing.Color.Transparent;
            this.Skins.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Skins.BackgroundImage")));
            this.Skins.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Skins.Controls.Add(this.linkLabel1);
            this.Skins.Controls.Add(this.panel3);
            this.Skins.Controls.Add(this.div);
            this.Skins.Location = new System.Drawing.Point(390, 21);
            this.Skins.Name = "Skins";
            this.Skins.Size = new System.Drawing.Size(215, 235);
            this.Skins.TabIndex = 7;
            this.Skins.Visible = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.SteelBlue;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.DodgerBlue;
            this.linkLabel1.Location = new System.Drawing.Point(115, 20);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(77, 12);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "初始化播放器";
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.DodgerBlue;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel3.Location = new System.Drawing.Point(10, 39);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(190, 180);
            this.panel3.TabIndex = 6;
            this.panel3.Click += new System.EventHandler(this.divbei);
            // 
            // div
            // 
            this.div.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.div.BackColor = System.Drawing.Color.Transparent;
            this.div.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.div.Location = new System.Drawing.Point(31, 14);
            this.div.Name = "div";
            this.div.Size = new System.Drawing.Size(25, 25);
            this.div.TabIndex = 5;
            this.div.TabStop = false;
            this.div.Click += new System.EventHandler(this.div_Click);
            this.div.MouseEnter += new System.EventHandler(this.div_MouseEnter);
            this.div.MouseLeave += new System.EventHandler(this.div_MouseLeave);
            // 
            // openFile
            // 
            this.openFile.FileName = "openFileDialog1";
            this.openFile.Filter = "支持图片类型|*.jpg;*png;*bmg";
            // 
            // Errs
            // 
            this.Errs.BackColor = System.Drawing.Color.DarkGray;
            this.Errs.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Errs.BackgroundImage")));
            this.Errs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Errs.Controls.Add(this.label2);
            this.Errs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Errs.Location = new System.Drawing.Point(0, 0);
            this.Errs.Name = "Errs";
            this.Errs.Size = new System.Drawing.Size(574, 18);
            this.Errs.TabIndex = 8;
            this.Errs.Visible = false;
            this.Errs.Click += new System.EventHandler(this.Errs_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Brown;
            this.label2.Location = new System.Drawing.Point(21, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(299, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "还没联网哦，先听下本地歌曲吧！   点击重新连接";
            this.label2.Click += new System.EventHandler(this.Errs_Click);
            // 
            // not
            // 
            this.not.ContextMenuStrip = this.Mene;
            this.not.Icon = ((System.Drawing.Icon)(resources.GetObject("not.Icon")));
            this.not.Text = "Tom音乐 - 音乐你的生活";
            this.not.Visible = true;
            this.not.DoubleClick += new System.EventHandler(this.not_Click);
            // 
            // Mene
            // 
            this.Mene.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Mene.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.播放暂停ToolStripMenuItem,
            this.toolStripSeparator1,
            this.上一首ToolStripMenuItem,
            this.下一首ToolStripMenuItem,
            this.toolStripSeparator2,
            this.锁屏ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.退出ToolStripMenuItem});
            this.Mene.Name = "contextMenuStrip1";
            this.Mene.Size = new System.Drawing.Size(156, 148);
            // 
            // 播放暂停ToolStripMenuItem
            // 
            this.播放暂停ToolStripMenuItem.ForeColor = System.Drawing.Color.DimGray;
            this.播放暂停ToolStripMenuItem.Name = "播放暂停ToolStripMenuItem";
            this.播放暂停ToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.播放暂停ToolStripMenuItem.Text = "播放/暂停";
            this.播放暂停ToolStripMenuItem.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(152, 6);
            // 
            // 上一首ToolStripMenuItem
            // 
            this.上一首ToolStripMenuItem.ForeColor = System.Drawing.Color.DimGray;
            this.上一首ToolStripMenuItem.Name = "上一首ToolStripMenuItem";
            this.上一首ToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.上一首ToolStripMenuItem.Text = "上一首";
            this.上一首ToolStripMenuItem.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // 下一首ToolStripMenuItem
            // 
            this.下一首ToolStripMenuItem.ForeColor = System.Drawing.Color.DimGray;
            this.下一首ToolStripMenuItem.Name = "下一首ToolStripMenuItem";
            this.下一首ToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.下一首ToolStripMenuItem.Text = "下一首";
            this.下一首ToolStripMenuItem.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(152, 6);
            // 
            // 锁屏ToolStripMenuItem
            // 
            this.锁屏ToolStripMenuItem.ForeColor = System.Drawing.Color.DimGray;
            this.锁屏ToolStripMenuItem.Name = "锁屏ToolStripMenuItem";
            this.锁屏ToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.锁屏ToolStripMenuItem.Text = "锁定TomMusic";
            this.锁屏ToolStripMenuItem.Click += new System.EventHandler(this.SuoP);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.ForeColor = System.Drawing.Color.DimGray;
            this.toolStripMenuItem1.Image = global::xj.MusicPlayer.Properties.Resources.Tomlogo1;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(155, 22);
            this.toolStripMenuItem1.Text = "关于Tom";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.ForeColor = System.Drawing.Color.Firebrick;
            this.退出ToolStripMenuItem.Image = global::xj.MusicPlayer.Properties.Resources.menu_icon_exit_normal;
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BackgroundImage = global::xj.MusicPlayer.Properties.Resources.div1;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel4.Controls.Add(this.Nso);
            this.panel4.Location = new System.Drawing.Point(0, 500);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(661, 430);
            this.panel4.TabIndex = 9;
            // 
            // Nso
            // 
            this.Nso.BackColor = System.Drawing.Color.Transparent;
            this.Nso.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Nso.ForeColor = System.Drawing.Color.White;
            this.Nso.Location = new System.Drawing.Point(0, 0);
            this.Nso.Name = "Nso";
            this.Nso.Size = new System.Drawing.Size(662, 430);
            this.Nso.TabIndex = 0;
            this.Nso.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // Suo
            // 
            this.Suo.BackColor = System.Drawing.Color.White;
            this.Suo.Controls.Add(this.label5);
            this.Suo.Controls.Add(this.panel5);
            this.Suo.Controls.Add(this.pictureBox1);
            this.Suo.Location = new System.Drawing.Point(0, 435);
            this.Suo.Name = "Suo";
            this.Suo.Size = new System.Drawing.Size(661, 430);
            this.Suo.TabIndex = 10;
            this.Suo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainWindow_MouseDown);
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(166, 403);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(340, 27);
            this.label5.TabIndex = 6;
            this.label5.Text = "正在加载,鼠标移进去看看";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.Location = new System.Drawing.Point(200, 152);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(270, 270);
            this.panel5.TabIndex = 5;
            this.panel5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawMouseDown);
            this.panel5.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawMouseMove);
            this.panel5.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DrawMouseUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::xj.MusicPlayer.Properties.Resources.Tomlogo1;
            this.pictureBox1.Location = new System.Drawing.Point(265, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 150);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainWindow_MouseDown);
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar1.BackColor = System.Drawing.Color.Transparent;
            this.trackBar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("trackBar1.BackgroundImage")));
            this.trackBar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.trackBar1.Location = new System.Drawing.Point(71, 56);
            this.trackBar1.Maximum = 0;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(590, 14);
            this.trackBar1.TabIndex = 0;
            this.trackBar1.Value = 0;
            this.trackBar1.MouseEnter += new System.EventHandler(this.trackBar1_MouseEnter);
            this.trackBar1.MouseLeave += new System.EventHandler(this.trackBar1_MouseLeave);
            // 
            // volControl
            // 
            this.volControl.BackColor = System.Drawing.Color.Transparent;
            this.volControl.BackgroundImage = global::xj.MusicPlayer.Properties.Resources.play_slider_value;
            this.volControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.volControl.Location = new System.Drawing.Point(23, 6);
            this.volControl.Maximum = 100;
            this.volControl.Name = "volControl";
            this.volControl.Size = new System.Drawing.Size(51, 14);
            this.volControl.TabIndex = 3;
            this.volControl.Value = 70;
            this.volControl.ScrollValueChange += new xj.fm.xinli001.com.ctrl.TrackBar.ScrollValueEventHandler(this.volControl_ScrollValueChange);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(661, 430);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.Suo);
            this.Controls.Add(this.btnHide);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.Skins);
            this.Controls.Add(this.Errs);
            this.Controls.Add(this.Skin);
            this.Controls.Add(this.pBottom);
            this.Controls.Add(this.pMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(661, 430);
            this.Name = "MainWindow";
            this.Text = "Tom音乐 - 音乐你的生活";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainWindow_MouseDown);
            this.panelVol.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnPlay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHead)).EndInit();
            this.pMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.muing)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer)).EndInit();
            this.pGroup.ResumeLayout(false);
            this.pGroups.ResumeLayout(false);
            this.pGroups.PerformLayout();
            this.pBottom.ResumeLayout(false);
            this.pBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.down)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Skin)).EndInit();
            this.Skins.ResumeLayout(false);
            this.Skins.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.div)).EndInit();
            this.Errs.ResumeLayout(false);
            this.Errs.PerformLayout();
            this.Mene.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.Suo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picHead;
        private System.Windows.Forms.Label lbTitle;
        private fm.xinli001.com.ctrl.TrackBar trackBar1;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Panel panelVol;
        private System.Windows.Forms.PictureBox btnPlay;
        private System.Windows.Forms.PictureBox btnPrev;
        private System.Windows.Forms.PictureBox btnNext;
        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.Panel pBottom;
        private System.Windows.Forms.Panel pMusicList;
        private System.Windows.Forms.Timer lbTextRolling;
        private System.Windows.Forms.Panel panel1;
        private fm.xinli001.com.ctrl.TrackBar volControl;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer;
        private System.Windows.Forms.PictureBox btnHide;
        private System.Windows.Forms.PictureBox btnClose;
        private System.Windows.Forms.Panel pGroup;
        private System.Windows.Forms.Panel pGroups;
        private System.Windows.Forms.Label lbAddMusic;
        private System.Windows.Forms.Label lbAddFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbCollection;
        private System.Windows.Forms.Label lbLocalMusic;
        private System.Windows.Forms.Label lbMusicOnline;
        private System.Windows.Forms.Panel panelMyMusic;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox Skin;
        private System.Windows.Forms.Panel Skins;
        private System.Windows.Forms.PictureBox div;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel Errs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NotifyIcon not;
        private System.Windows.Forms.ContextMenuStrip Mene;
        private System.Windows.Forms.ToolStripMenuItem 播放暂停ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 上一首ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 下一首ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label Nso;
        private System.Windows.Forms.PictureBox muing;
        private System.Windows.Forms.PictureBox down;
        private System.Windows.Forms.Panel Suo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem 锁屏ToolStripMenuItem;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label5;
    }
}

