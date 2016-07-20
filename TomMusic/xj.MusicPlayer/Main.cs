using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using xj.fm.xinli001.com;
using xj.MusicPlayer.ctrl;
using xj.MusicPlayer.Properties;
using xj.MusicPlayer.Update;

namespace xj.MusicPlayer
{
    public partial class MainWindow : MySkin.Main
    {
        public string LastControlName { get; set; }

        #region 调用非托管的动态链接库来让窗体可以拖动
        [DllImport("User32.DLL")]
        public static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);
        [DllImport("User32.DLL")]
        public static extern bool ReleaseCapture();
        public const uint WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 61456;
        public const int HTCAPTION = 2;
        #endregion

        public static int Labelsender = 2;

        private System.Windows.Forms.Panel panName;
        private List<Music> list = new List<Music>();
        private List<Music> musicOnlineList = new List<Music>();
        private List<Music> searchMusicList = new List<Music>();
        private string SearchText { get; set; }

        bool isDown;

        int r, g, b, rr, gg, bb, fr = 255, fg = 255, fb = 255;
        public MainWindow()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false; 
        }

        #region 允许窗体拖动
        private void MainWindow_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, WM_SYSCOMMAND, SC_MOVE | HTCAPTION, 0);
        }
        #endregion

        /// <summary>
        /// 程序启动，窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void mLoad()
        {
            Nso.Text += "\r\t开始填装背景";
            if (File.Exists(Properties.Settings.Default.backimg))
            {
                this.BackgroundImage = Image.FromFile(Properties.Settings.Default.backimg);
                Nso.Text += "\r\t背景填装完毕";
            }
            Nso.Text += "\r\t初始化界面";
            Thread ts = new Thread(Init);
            ts.IsBackground = true;
            ts.Start();
            Nso.Text += "\r\t加载界面完毕";
            Thread h = new Thread(timerPTick);
            h.Start();
            //注册鼠标滚动事件
            Nso.Text += "\r\t初始化引擎";
            this.MouseWheel += new MouseEventHandler(pMusicList_MouseWheel);
            Nso.Text += "\r\t确认引擎运转";
            Nso.Text += "\r\t全部机能正常 欢迎使用Tom音乐 - 音乐你的生活";
            Thread tas = new Thread(tex);
            Thread.Sleep(1000);
            tas.Start();
        }
        public void tex()
        {
            panel4.Dispose(); Nso.Dispose();
            Thread tu = new Thread(checkUpdate); tu.Start();
        }
        private void MainWindow_Load(object sender, EventArgs e)
        {
            panel4.Visible = true;
            Nso.Text += "Tom音乐 开始启动\r\t核对对象";
            Nso.Text += "\r\t - " + Environment.UserName;
            Nso.Text += "\r\t - " + Environment.OSVersion;//获取操作系统版本
            Nso.Text += "\r\t - " + Environment.MachineName;//获取机器名
            //Nso.Text += "\r\t - " + Environment.UserDomainName;
            this.DoubleBuffered = true;
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true);
            Nso.Text += "\r\t播放器初始化\r\t开始检测网络单元";
            //判断有没有联网
            if (!TestNetwork.Test())
            {
                Nso.Text += "\r\t未检测到网络 - 检索对应措施\r\t启用离线模式";
                Errs.Visible = true;
                lbMusicOnline.Enabled = false; lbCollection.Enabled = false;
                if (File.Exists(Application.StartupPath + (@"\musicList.xml")))
                {
                    Thread thread = new Thread(new ThreadStart(() =>
                    {
                        //加载本地音乐
                        list = XMLHelper.ReadXML();
                        LoadData(list);    //加载第几页
                    }));
                    thread.IsBackground = true;
                    thread.Start();
                }
            }
            else
            {
                Nso.Text += "\r\t成功连接云，从云启动";
                if (File.Exists(Application.StartupPath + (@"\musicList.xml")))
                {
                    Thread thread = new Thread(new ThreadStart(() =>
                    {
                        //加载本地音乐
                        list = XMLHelper.ReadXML();
                        LoadData(list);    //加载第几页
                        //加载心理Fm列表
                        musicOnlineList = ResolveOnlineMusicList.ResolveMusic(GetHtmlCode.WriteInfo(1));
                    }));
                    thread.IsBackground = true;
                    thread.Start();
                }
                else
                {
                    Thread thread = new Thread(new ThreadStart(() =>
                    {
                        //加载心理Fm列表
                        musicOnlineList = ResolveOnlineMusicList.ResolveMusic(GetHtmlCode.WriteInfo(1));
                    }));
                    thread.IsBackground = true;
                    thread.Start();
                    lbCollection.Enabled = true;
                }
            }
            Thread ts = new Thread(mLoad);
            ts.Start();
        }


        ///<summary>
        ///自动升级
        ///</summary>
        public void checkUpdate()
        {
            if (Properties.Settings.Default.Update == false) {return; }
            SoftUpdate app = new SoftUpdate(Application.ExecutablePath, "TomMusic");
            app.UpdateFinish += new UpdateState(app_UpdateFinish);
            try
            {
                if (app.IsUpdate && MessageBox.Show("检查到新版本，是否后台更新？", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Thread update = new Thread(app.Update);
                    update.Start();
                }
                else if (app.IsUpdate)
                {
                    if (MessageBox.Show("以后检查到新版本时，是否继续提示更新？", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    { Properties.Settings.Default.Update = false; }
                }
            }
            catch (Exception)
            { }
        }

        void app_UpdateFinish()
        {
            if (File.Exists(Application.StartupPath + "\\Update.exe"))
            {
                MessageBox.Show("更新完成，请重新启动程序！", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Properties.Settings.Default.volue = this.volControl.Value;
                Properties.Settings.Default.Save();
                using (var streamWriter = new StreamWriter("list.dat", false, Encoding.UTF8))
                {
                    streamWriter.Write("");
                } not.Dispose();
                System.Diagnostics.Process.Start(Application.StartupPath + "\\Update.exe");
                this.Close();
                Application.Exit();
                System.Environment.Exit(0);
                this.Dispose();
            }
            else { File.Delete(Application.StartupPath + "\\Update_TomMusic.exe"); }
        }
        /// <summary>
        /// 初始化各项参数
        /// </summary>
        private void Init()
        {
            picHead.Parent = pBottom;
            this.axWindowsMediaPlayer.settings.volume = Properties.Settings.Default.volue;  //设置默认音量
            this.volControl.Value = Properties.Settings.Default.volue;  //设置默认音量
            PlayHelper.PlayStatu = -1;  //默认播放状态为停止
            this.lbLocalMusic.ForeColor = Color.White;
            this.pMain.BackColor = Color.FromArgb(200, 200, 200);
            this.BackColor = Color.FromArgb(13, 174, 81);  //设置整个播放器窗体颜色
            lbLocalMusic.BackColor = Color.FromArgb(13, 174, 81);
            lbMusicOnline.ForeColor = Color.FromArgb(fr, fg, fb);
            lbLocalMusic.ForeColor = Color.FromArgb(fr, fg, fb);
            lbCollection.ForeColor = Color.FromArgb(fr, fg, fb);
            lbAddFolder.ForeColor = Color.FromArgb(fr, fg, fb);
            lbAddMusic.ForeColor = Color.FromArgb(fr, fg, fb); label3.ForeColor = Color.FromArgb(fr, fg, fb); label1.ForeColor = Color.FromArgb(fr, fg, fb);
            try
            {
                Properties.Settings.Default.Skmin = true;
                FileStream fs = new FileStream(Application.StartupPath + (@"\Skin.dll"), FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                r = System.Int32.Parse(sr.ReadLine());
                b = System.Int32.Parse(sr.ReadLine());
                g = System.Int32.Parse(sr.ReadLine());
                if (r >= 10) { rr = r - 10; } if (b >= 10) { bb = b - 10; } if (g >= 10) { gg = g - 10; }
                if (r >= 150 && b >= 150 && g >= 150) { fr = 0; fb = 0; fg = 0; }
                sr.Dispose();
                fs.Dispose();
            }
            catch (Exception) { Properties.Settings.Default.Skmin = false; }
            if (Properties.Settings.Default.Skmin == true)
            {
                this.BackColor = Color.FromArgb(r, g, b); lbLocalMusic.BackColor = Color.FromArgb(r, g, b);
                return;
            }
        }

        /// <summary>
        /// 关闭按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.volue = this.volControl.Value;
            Properties.Settings.Default.Save();
            using (var streamWriter = new StreamWriter("list.dat", false, Encoding.UTF8))
            {
                streamWriter.Write("");
            } not.Dispose(); this.Close();
            Application.Exit();
            System.Environment.Exit(0);
            this.Dispose();
        }

        /// <summary>
        /// 窗体最小化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHide_Click(object sender, EventArgs e)
        {
            Skins.Visible = false;
            this.WindowState = FormWindowState.Minimized;
        }

        #region 按钮鼠标移入和移出事件
        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            this.btnClose.BackgroundImage = xj.MusicPlayer.Properties.Resources.btn_close_highlight;
        }
        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            this.btnClose.BackgroundImage = xj.MusicPlayer.Properties.Resources.btn_close_normal;
        }
        private void btnHide_MouseEnter(object sender, EventArgs e)
        {
            this.btnHide.BackgroundImage = xj.MusicPlayer.Properties.Resources.btn_mini_highlight;
        }
        private void btnHide_MouseLeave(object sender, EventArgs e)
        {
            this.btnHide.BackgroundImage = xj.MusicPlayer.Properties.Resources.btn_mini_normal;
        }
        private void trackBar1_MouseEnter(object sender, EventArgs e)
        {
            trackBar1.BackgroundImageLayout = ImageLayout.Stretch;
        }
        private void trackBar1_MouseLeave(object sender, EventArgs e)
        {
            trackBar1.BackgroundImageLayout = ImageLayout.Zoom;
        }
        private void Skin_MouseEnter(object sender, EventArgs e)
        {
            Skin.BackgroundImage = Properties.Resources.skin_click;
        }
        private void Skin_MouseLeave(object sender, EventArgs e)
        {
            Skin.BackgroundImage = Properties.Resources.skin;
        }
        private void div_MouseEnter(object sender, EventArgs e)
        {
            div.BackgroundImage = Properties.Resources.div;
        }
        private void div_MouseLeave(object sender, EventArgs e)
        {
            div.BackgroundImage = null;
        }
        private void down_MouseEnter(object sender, EventArgs e)
        {
            down.Image = Properties.Resources.downon;
        }
        private void down_MouseLeave(object sender, EventArgs e)
        {
            down.Image = Properties.Resources.down;
        }
        #endregion

        #region 设置通用样式

        /// <summary>
        /// 音乐分组点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbMouseEnter(object sender, EventArgs e)
        {
            Label l = (Label)sender;
            if (Convert.ToInt32(l.Parent.Tag) == 100)
            {
            }
            else
            {
                l.ForeColor = Color.FromArgb(fr, fg, fb);
                if (Properties.Settings.Default.Skmin == true)
                {
                    l.BackColor = Color.FromArgb(r, g, b); return;
                }
                l.BackColor = Color.FromArgb(13, 174, 81);
            }
        }

        private void lbMouseLeave(object sender, EventArgs e)
        {
            Label l = (Label)sender;
            if (Convert.ToInt32(l.Parent.Tag) == 100)
            {
            }
            else
            {
                l.BackColor = Color.FromArgb(200, 200, 200);
                l.ForeColor = Color.FromArgb(fr, fg, fb);
            }
        }
        #endregion

        /// <summary>
        /// 添加文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelAddFolder_Click(object sender, EventArgs e)
        {
            AddMusic.OpenFolder();
            this.pMusicList.Controls.Clear();
            list = XMLHelper.ReadXML();
            LoadData(list);
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        public void LoadData(List<Music> list)
        {
            bool isLoad = list != null && list.Any();
            while (!isLoad)
            {
                if (PlayerType.type == PlayType.online)
                {
                    //todo:这里可以加入一个正在加载的图标
                    //list = ResolveOnlineMusicList.ResolveMusic(GetHtmlCode.WriteInfo(1));
                    isLoad = musicOnlineList != null && musicOnlineList.Any();
                    list = musicOnlineList;
                    Thread.Sleep(100);
                }
                else
                {
                    break;
                }
            }
            if (!isLoad)
                return;
            pMusicList.Invoke(new Action(() =>
            {
                string music = string.Empty;
                //正在播放或暂停
                if (PlayHelper.PlayStatu == 1 || PlayHelper.PlayStatu == 0)
                {
                    music = this.lbTitle.Text;
                    music = this.Text;
                    not.Text = music;
                }
                for (int i = list.Count - 1; i >= 0; i--)
                {
                    bool isCurrentMusic = list[i].MusicName.Equals(music);
                    System.Windows.Forms.Label lbBit = null;
                    if (isCurrentMusic)
                    {
                        lbBit = new System.Windows.Forms.Label();
                        lbBit.AutoSize = true;
                        lbBit.Tag = i + 1;
                        lbBit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
                        lbBit.Location = new System.Drawing.Point(7, 35);
                        lbBit.Name = "lbBit";
                        lbBit.Size = new System.Drawing.Size(113, 12);
                        lbBit.Text = "比特率:" + list[i].Bitrate;
                        lbBit.ForeColor = Color.White;
                        lbBit.Font = new Font(this.panName.Font.FontFamily, 7);
                    }
                    panName = new System.Windows.Forms.Panel();
                    panName.Dock = System.Windows.Forms.DockStyle.Top;
                    panName.Location = new System.Drawing.Point(0, 0);
                    panName.Name = "panelSong" + (i + 1);
                    panName.Tag = i + 1;
                    panName.Size = new System.Drawing.Size(279, 35);
                    panName.TabIndex = i + 1;
                    panName.BackColor = Color.White;

                    System.Windows.Forms.Label lbName = new System.Windows.Forms.Label();
                    lbName.AutoSize = false;
                    lbName.Tag = i + 1;
                    lbName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
                    lbName.Location = new System.Drawing.Point(7, 14);
                    lbName.Name = "lbSong";// + (i + 1);
                    lbName.Size = new System.Drawing.Size(175, 12);
                    lbName.Text = list[i].MusicName;
                    lbName.TabIndex = list[i].MusicName.Length > 16 ? 1 : 0;
                    //.Length > 16 ? list[i].MusicName.Substring(0, 16) + "..." : list[i].MusicName;
                    lbName.ForeColor = Color.FromArgb(106, 106, 106);

                    System.Windows.Forms.Label lbError = new System.Windows.Forms.Label();
                    lbError.AutoSize = true;
                    lbError.Tag = i + 1;
                    lbError.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
                    lbError.Location = new System.Drawing.Point(80, 35);
                    lbError.Name = "lbError";// + (i + 1);
                    lbError.Size = new System.Drawing.Size(113, 12);
                    lbError.Text = "读取错误，文件不存在！";
                    lbError.ForeColor = Color.Red;
                    lbError.Visible = false;

                    System.Windows.Forms.Label lbTime = new System.Windows.Forms.Label();
                    lbTime.AutoSize = true;
                    lbTime.Tag = i + 1;
                    lbTime.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
                    lbTime.Location = new System.Drawing.Point(200, 14);
                    lbTime.Name = "lbTime";
                    lbTime.Size = new System.Drawing.Size(113, 12);
                    lbTime.Text = list[i].MusicTime;
                    lbTime.ForeColor = Color.FromArgb(106, 106, 106);

                    panName.Controls.Add(lbTime);
                    panName.Controls.Add(lbName);
                    panName.Controls.Add(lbError);
                    if (lbBit != null)
                        panName.Controls.Add(lbBit);

                    //为生成的lable注册事件
                    lbName.MouseEnter += new System.EventHandler(lbName_MouseEnter);
                    lbName.MouseLeave += new System.EventHandler(lbName_MouseLeave);
                    lbName.Click += new System.EventHandler(lbName_Click);
                    lbName.DoubleClick += new EventHandler(lbName_DoubleClick);

                    //为生成的panel注册事件
                    panName.MouseEnter += new System.EventHandler(panName_MouseEnter);
                    panName.MouseLeave += new System.EventHandler(panName_MouseLeave);
                    panName.Click += new System.EventHandler(panName_Click);
                    panName.DoubleClick += new System.EventHandler(panName_DoubleClick);

                    this.pMusicList.Controls.Add(panName); muing.Visible = false;
                }
            })); lbCollection.Enabled = true;
        }

        #region 音乐列表事件
        /// <summary>
        /// 为动态生成的panel注册鼠标移入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panName_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                Panel p = (Panel)sender;
                foreach (Control control in p.Parent.Controls)  //遍历PanelList下的所有panel控件
                {
                    if (control is Panel && control == p)   //找到当前鼠标所在的panel
                    {
                        if (control.Height != 60)   //如果它的高度不是60的话
                        {
                            if (Properties.Settings.Default.Skmin == true)
                            { p.BackColor = Color.FromArgb(rr, gg, bb); }
                            else { p.BackColor = Color.FromArgb(13, 174, 81); }
                            //将颜色设置为默认
                            return;
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        private void lbName_MouseEnter(object sender, EventArgs e)
        {
            try { 
            Label l = (Label)sender;
            foreach (Control control in l.Parent.Parent.Controls)
            {
                if (control is Panel && control.Controls["lbSong"] == l)
                {
                    if (control.Height != 60)
                    {
                        if (Properties.Settings.Default.Skmin == true)
                        {l.Parent.BackColor = Color.FromArgb(rr, gg, bb);}
                        else { l.Parent.BackColor = Color.FromArgb(13, 174, 81); }
                        //调用父控件的backcolor属性设置
                        return;
                    }
                }
            }
            }
            catch (Exception) { }
        }

        /// <summary>
        /// 列表点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panName_Click(object sender, EventArgs e)
        {
            try
            {
                this.pMusicList.Focus();
                Panel p = (Panel)sender;
                foreach (Control control in p.Parent.Controls)
                {
                    if (control is Panel)
                    {
                        if (control == p)
                        {
                            control.Height = 60;
                            if (Properties.Settings.Default.Skmin == true)
                            { control.BackColor = Color.FromArgb(r, g, b); }
                            else { control.BackColor = Color.FromArgb(13, 174, 81); }
                            control.Controls["lbSong"].ForeColor = Color.White;
                            control.Controls["lbTime"].ForeColor = Color.White;
                            AddBitRate(control);
                        }
                        else
                        {
                            if (control.Name.Equals("panelNav"))
                                continue;
                            control.Height = 35;
                            control.BackColor = Color.White;
                            ;
                            if (control.Controls["lbSong"] != null)
                            {
                                control.Controls["lbSong"].ForeColor = Color.FromArgb(106, 106, 106);
                                control.Controls["lbTime"].ForeColor = Color.FromArgb(106, 106, 106);
                            }
                            if (PlayerType.type == PlayType.collection)
                                if (Properties.Settings.Default.Skmin == true)
                                { control.Parent.Controls["panelSearchMusic"].BackColor = Color.FromArgb(r, g, b); }
                                else { control.Parent.Controls["panelSearchMusic"].BackColor = Color.FromArgb(13, 174, 81); }
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        private void lbName_Click(object sender, EventArgs e)
        {
            try {
            this.pMusicList.Focus();
            Label l = (Label)sender;
            foreach (Control control in l.Parent.Parent.Controls)
            {
                if (control is Panel)
                {
                    if (control.Controls["lbSong"] == l)
                    {
                        control.Height = 60;
                        if (Properties.Settings.Default.Skmin == true)
                        { control.BackColor = Color.FromArgb(r,g,b); }
                        else { control.BackColor = Color.FromArgb(13, 174, 81); }
                        l.ForeColor = Color.White;
                        control.Controls["lbTime"].ForeColor = Color.White;
                        AddBitRate(control);
                    }
                    else
                    {
                        if (control.Name.Equals("panelNav"))
                            continue;
                        control.Height = 35;
                        control.BackColor = Color.White;
                        if (control.Controls["lbSong"] != null)
                        {
                            control.Controls["lbSong"].ForeColor = Color.FromArgb(106, 106, 106);
                            control.Controls["lbTime"].ForeColor = Color.FromArgb(106, 106, 106);
                        }
                        if (PlayerType.type == PlayType.collection)
                            if (Properties.Settings.Default.Skmin == true)
                            { control.Parent.Controls["panelSearchMusic"].BackColor = Color.FromArgb(r,g,b); }
                            else { control.Parent.Controls["panelSearchMusic"].BackColor = Color.FromArgb(13, 174, 81); }
                    }
                }
            }
            }
            catch (Exception) { }
        }

        /// <summary>
        /// 双击列表播放音乐
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panName_DoubleClick(object sender, EventArgs e)
        {
            this.btnPlay.Image = Properties.Resources.Playon;
            try
            {
                this.axWindowsMediaPlayer.settings.volume = volControl.Value;
            Panel p = (Panel)sender;
            foreach (Control control in p.Parent.Controls)
            {
                if (control is Panel)
                {
                    if (control == p)
                    {
                        int id = (int)control.Tag;     //读取歌曲编号
                        if (PlayerType.type == PlayType.local)
                        {
                            string url = list[id - 1].MusciURL;
                            if (File.Exists(url))
                            {
                                var imgs = new SearchMusic().GetPic_Music(list[id - 1].MusciURL);
                                this.picHead.Image = imgs.Any() ? imgs[0] : Resources.Tomlogo1;
                                PlayerType.PlayerGroup = PlayType.local;
                                this.axWindowsMediaPlayer.URL = list[id - 1].MusciURL; //给播放器设置文件路径
                                string musicName = list[id - 1].MusicName.Split('.')[0];
                                this.lbTitle.Text = musicName; this.Text = musicName; not.Text = musicName;
                            }
                            else
                            {
                                p.Controls[2].Visible = true;
                                return;
                            }
                        }
                        else if (PlayerType.type == PlayType.online)
                        {
                            PlayerType.PlayerGroup = PlayType.online;
                            string url = musicOnlineList[id - 1].MusciURL;
                            this.axWindowsMediaPlayer.URL = musicOnlineList[id - 1].MusciURL; //给播放器设置文件路径
                            string musicName = musicOnlineList[id - 1].MusicName.Split('.')[0];
                            this.lbTitle.Text = musicName;
                            this.Text = musicName; not.Text = musicName;
                            //加载网络图片
                            this.picHead.Image = LoadingPic.ReadImageFromUrl(musicOnlineList[id - 1].MusicPic);
                        }
                        else if (PlayerType.type == PlayType.collection)
                        {
                            PlayerType.PlayerGroup = PlayType.collection;
                            string url = searchMusicList[id - 1].MusciURL;
                            this.axWindowsMediaPlayer.URL = searchMusicList[id - 1].MusciURL; //给播放器设置文件路径
                            string musicName = searchMusicList[id - 1].MusicName;
                            this.lbTitle.Text = musicName;
                            this.Text = musicName; not.Text = musicName;
                            //加载网络图片
                            this.picHead.Image = string.IsNullOrEmpty(searchMusicList[id - 1].MusicPic)
                                ? Resources.Tomlogo1
                                : Image.FromFile(searchMusicList[id - 1].MusicPic);
                        }
                        PlayHelper.PlayStatu = 1; //设置播放器状态为正在播放
                        PlayHelper.MusicId = id;    //保存当前播放的歌曲Id
                    }
                }
            }
            }
            catch (Exception) { }
        }

        /// <summary>
        /// 双击列表播放音乐
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbName_DoubleClick(object sender, EventArgs e)
        {
            this.btnPlay.Image = Properties.Resources.Playon;
            try
            {
                this.axWindowsMediaPlayer.settings.volume = volControl.Value;
            Label l = (Label)sender;
            foreach (Control control in l.Parent.Controls)
            {
                if (control is Label)
                {
                    if (control == l)
                    {
                        int id = (int)control.Tag;     //读取歌曲编号
                        if (PlayerType.type == PlayType.local)
                        {
                            string url = list[id - 1].MusciURL;
                            if (File.Exists(url))
                            {
                                var imgs = new SearchMusic().GetPic_Music(list[id - 1].MusciURL);
                                this.picHead.Image = imgs.Any() ? imgs[0] : Resources.Tomlogo1;
                                PlayerType.PlayerGroup = PlayType.local;
                                this.axWindowsMediaPlayer.URL = list[id - 1].MusciURL; //给播放器设置文件路径
                                string musicName = list[id - 1].MusicName.Split('.')[0];
                                this.lbTitle.Text = musicName;
                                this.Text = musicName; not.Text = musicName;
                            }
                            else
                            {
                                l.Parent.Controls[2].Visible = true;
                                return;
                            }
                        }
                        else if (PlayerType.type == PlayType.online)
                        {
                            PlayerType.PlayerGroup = PlayType.online;
                            string url = musicOnlineList[id - 1].MusciURL;
                            this.axWindowsMediaPlayer.URL = musicOnlineList[id - 1].MusciURL; //给播放器设置文件路径
                            string musicName = musicOnlineList[id - 1].MusicName.Split('.')[0];
                            this.lbTitle.Text = musicName;
                            this.Text = musicName; not.Text = musicName;
                            //加载网络图片
                            this.picHead.Image = LoadingPic.ReadImageFromUrl(musicOnlineList[id - 1].MusicPic);
                        }
                        else if (PlayerType.type == PlayType.collection)
                        {
                            PlayerType.PlayerGroup = PlayType.collection;
                            string url = searchMusicList[id - 1].MusciURL;
                            this.axWindowsMediaPlayer.URL = searchMusicList[id - 1].MusciURL; //给播放器设置文件路径
                            string musicName = searchMusicList[id - 1].MusicName;
                            this.lbTitle.Text = musicName;
                            this.Text = musicName; not.Text = musicName;
                            //加载网络图片
                            this.picHead.Image = string.IsNullOrEmpty(searchMusicList[id - 1].MusicPic) ? Resources.Tomlogo1 : Image.FromFile(searchMusicList[id - 1].MusicPic);
                        }
                        PlayHelper.PlayStatu = 1; //设置播放器状态为正在播放
                        PlayHelper.MusicId = id;    //保存当前播放的歌曲Id
                    }
                }
            }
            }
            catch (Exception) { }
        }

        /// <summary>
        /// 为动态生成的panel注册鼠标移出事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panName_MouseLeave(object sender, EventArgs e)
        {
            Panel p = (Panel)sender;
            foreach (Control control in this.pMusicList.Controls)
            {
                if (control is Panel && control == p)
                {
                    if (control.Height != 60)
                    {
                        p.BackColor = Color.White;
                        return;
                    }
                }
            }
        }

        private void lbName_MouseLeave(object sender, EventArgs e)
        {
            Label l = (Label)sender;
            foreach (Control control in this.pMusicList.Controls)
            {
                if (control is Panel && control.Controls["lbSong"] == l)
                {
                    if (control.Height != 60)
                    {
                        l.Parent.BackColor = Color.FromArgb(200, 200, 200);
                        return;
                    }
                }
            }
        }
        #endregion

        /// <summary>
        /// 播放时间进度控制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void timerPTick()
        {
            try
            {
                //判断当前播放器状态
                if (this.axWindowsMediaPlayer.playState == WMPPlayState.wmppsPlaying)
                {
                    List<Music> musicList = null;
                    if (PlayerType.PlayerGroup == PlayType.local)
                    {
                        musicList = list;
                    }
                    else if (PlayerType.PlayerGroup == PlayType.online)
                    {
                        musicList = musicOnlineList;
                    }
                    else if (PlayerType.PlayerGroup == PlayType.collection)
                    {
                        musicList = searchMusicList;
                    }
                    //设置当前播放进度
                    this.lbTime.Text = axWindowsMediaPlayer.Ctlcontrols.currentPositionString;
                    string str = musicList[PlayHelper.MusicId - 1].MusicTime;    //获取当前播放歌曲时长
                    string[] strs = str.Split(':');
                    int soundtimes = int.Parse(strs[0]) * 60 + int.Parse(strs[1]);
                    //根据歌曲时长日计算滑块位置偏移，如果不计算的话歌曲放完时滑块进入最右边，被遮挡
                    int soundtimeout = (int)Math.Ceiling(soundtimes * 170 * 1.0 / 165);
                    this.trackBar1.Maximum = soundtimeout;   //设置进度条最大值

                    this.btnPlay.Image = Properties.Resources.playbtn_pause;

                    if (PlayHelper.PlayFlag == 1)
                    {
                        PlayHelper.PlayFlag = 0;
                        this.axWindowsMediaPlayer.Ctlcontrols.currentPosition = this.trackBar1.Value;
                    }
                }
                else if (axWindowsMediaPlayer.playState == WMPPlayState.wmppsStopped)    //播放完毕
                {
                    //跳转到下一首歌曲
                    isDown = true;
                    Thread ts = new Thread(AmendStyle);
                    ts.IsBackground = true;
                    ts.Start();
                }
            }
            catch (Exception) { }
            Thread h = new Thread(timerPTick); Thread.Sleep(1000);
            h.Start();
        }
        /// <summary>
        /// 滑块移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbTime_TextChanged(object sender, EventArgs e)
        {
            //如果切歌的话让进度条回到初始位置
            if (this.lbTime.Text == "00:00")
            {
                this.trackBar1.Value = 0;
            }
            this.trackBar1.Value += 1;
        }

        /// <summary>
        /// 歌曲切换加样式方法封装
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="isDown"></param>
        public void AmendStyle()
        {
            this.btnPlay.Image = Properties.Resources.Playon;
            this.axWindowsMediaPlayer.settings.volume = volControl.Value;
            if (PlayHelper.MusicId == 0) return;
            this.pMusicList.Controls.Find("panelSong" + PlayHelper.MusicId, false)[0].Height = 35;
            this.pMusicList.Controls.Find("panelSong" + PlayHelper.MusicId, false)[0].BackColor = Color.FromArgb(200, 200, 200);
            this.pMusicList.Controls.Find("panelSong" + PlayHelper.MusicId, false)[0].Controls["lbSong"].ForeColor = Color.FromArgb(106, 106, 106);
            this.pMusicList.Controls.Find("panelSong" + PlayHelper.MusicId, false)[0].Controls["lbTime"].ForeColor = Color.FromArgb(106, 106, 106);
            this.pMusicList.Controls.Find("panelSong" + PlayHelper.MusicId, false)[0].Controls["lbError"].Visible =false;

            //当前播放状态为播放或暂停时切换到下一曲
            if (PlayHelper.PlayStatu == 1 || PlayHelper.PlayStatu == 0)
            {
                if (isDown)     //是下一曲
                {
                    if (PlayHelper.MusicId == (PlayerType.PlayerGroup == PlayType.local ? list.Count : musicOnlineList.Count)) //已经是最后一首歌曲
                    {
                        PlayHelper.MusicId = 1; //切换到第一首
                    }
                    else
                    {
                        PlayHelper.MusicId += 1;
                    }
                }
                else    //是上一曲
                {
                    if (PlayHelper.MusicId == 1) //已经是最后一首歌曲
                    {
                        PlayHelper.MusicId = (PlayerType.type == PlayType.local ? list.Count : musicOnlineList.Count); //切换到第一首
                    }
                    else
                    {
                        PlayHelper.MusicId -= 1;
                    }
                }
            }
            this.trackBar1.Value = 0;
            //给当前播放的歌曲设置样式
            this.pMusicList.Controls.Find("panelSong" + PlayHelper.MusicId, false)[0].Height = 60;
            if (Properties.Settings.Default.Skmin == true)
            { this.pMusicList.Controls.Find("panelSong" + PlayHelper.MusicId, false)[0].BackColor = Color.FromArgb(r,g,b); }
            else { this.pMusicList.Controls.Find("panelSong" + PlayHelper.MusicId, false)[0].BackColor = Color.FromArgb(13, 174, 81); }
            this.pMusicList.Controls.Find("panelSong" + PlayHelper.MusicId, false)[0].Controls["lbSong"
                ].ForeColor = Color.White;
            this.pMusicList.Controls.Find("panelSong" + PlayHelper.MusicId, false)[0].Controls["lbTime"
                ].ForeColor = Color.White;
            string url = null;
            switch (PlayerType.PlayerGroup)
            {
                case PlayType.local:
                    url = list[PlayHelper.MusicId - 1].MusciURL;
                    break;
                case PlayType.collection:
                    url = searchMusicList[PlayHelper.MusicId - 1].MusciURL;
                    break;
                case PlayType.online:
                    url = musicOnlineList[PlayHelper.MusicId - 1].MusciURL;
                    break;
            }
            if (PlayerType.PlayerGroup == PlayType.local)
            {
                if (File.Exists(url))
                {
                    var imgs = new SearchMusic().GetPic_Music(list[PlayHelper.MusicId - 1].MusciURL);
                    this.axWindowsMediaPlayer.URL = url; //给播放器设置文件路径
                    this.lbTitle.Text = list[PlayHelper.MusicId - 1].MusicName;
                    this.Text = list[PlayHelper.MusicId - 1].MusicName;
                    not.Text = list[PlayHelper.MusicId - 1].MusicName;
                    this.picHead.Image = imgs.Any() ? imgs[0] : Resources.Tomlogo1;
                    PlayHelper.PlayStatu = 1;
                    try
                    {this.axWindowsMediaPlayer.Ctlcontrols.play();}catch (Exception) { }
                    this.btnPlay.Image = Properties.Resources.playbtn_pause;
                }
                else
                {
                    this.pMusicList.Controls.Find("panelSong" + PlayHelper.MusicId, false)[0].Controls[2].Visible = true;
                    //PlayHelper.PlayStatu = -1;
                    //PlayHelper.MusicId = 1;
                    this.btnPlay.Image = Properties.Resources.playbtn_play; //更换图标
                    return;
                }
            }
            else if (PlayerType.PlayerGroup == PlayType.online)
            {
                this.axWindowsMediaPlayer.URL = url; //给播放器设置文件路径
                this.lbTitle.Text = musicOnlineList[PlayHelper.MusicId - 1].MusicName;
                this.Text = musicOnlineList[PlayHelper.MusicId - 1].MusicName;
                not.Text = musicOnlineList[PlayHelper.MusicId - 1].MusicName;
                this.picHead.Image = LoadingPic.ReadImageFromUrl(musicOnlineList[PlayHelper.MusicId - 1].MusicPic);
                PlayHelper.PlayStatu = 1;
                this.axWindowsMediaPlayer.Ctlcontrols.play();
                this.btnPlay.Image = Properties.Resources.playbtn_pause;
            }
            else if (PlayerType.PlayerGroup == PlayType.collection)
            {
                this.axWindowsMediaPlayer.URL = url; //给播放器设置文件路径
                this.lbTitle.Text = searchMusicList[PlayHelper.MusicId - 1].MusicName;
                this.Text = searchMusicList[PlayHelper.MusicId - 1].MusicName;
                not.Text = searchMusicList[PlayHelper.MusicId - 1].MusicName;
                this.picHead.Image = string.IsNullOrEmpty(searchMusicList[PlayHelper.MusicId - 1].MusicPic) ? Resources.Tomlogo1 : Image.FromFile(searchMusicList[PlayHelper.MusicId - 1].MusicPic); ;
                PlayHelper.PlayStatu = 1;
                this.axWindowsMediaPlayer.Ctlcontrols.play();
                this.btnPlay.Image = Properties.Resources.playbtn_pause;
            }
        }
        /// <summary>
        /// 播放音乐
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlay_Click(object sender, EventArgs e)
        {
            Thread ts = new Thread(btnPlays);
            ts.IsBackground = true;
            ts.Start();
        }
        public static int volue = Properties.Settings.Default.volue;
        public void btnPlays()
        {
            btnPlay.Enabled = false;
            try
            {
                if (PlayHelper.PlayStatu == 1)   //如果正在播放
                {
                    volue = this.volControl.Value;
                    Thread ts = new Thread(Playson);
                    ts.IsBackground = true;
                    ts.Start();
                }
                else if (PlayHelper.PlayStatu == 0) //暂停
                {
                    this.axWindowsMediaPlayer.Ctlcontrols.play();   //开始播放
                    Thread ts = new Thread(Playsst);
                    ts.IsBackground = true;
                    ts.Start();
                }
                else    //停止
                {
                    Thread ts = new Thread(Playser);
                    ts.IsBackground = true;
                    ts.Start();
                }
            }
            catch (Exception) { }
        }
        public void Playson()
        {
            if (this.axWindowsMediaPlayer.settings.volume == 0)
            {
                PlayHelper.PlayStatu = 0;   //将状态设置为暂停
                this.axWindowsMediaPlayer.Ctlcontrols.pause();  //暂停播放
                this.btnPlay.Image = Properties.Resources.playbtn_play;    //更换图标
                btnPlay.Enabled = true;
            }
            else {
                this.axWindowsMediaPlayer.settings.volume -= 1;
                Thread ts = new Thread(Playson);
                Thread.Sleep(10);
                ts.Start();
            } 
        }
        public void Playsst()
        {
            if (this.axWindowsMediaPlayer.settings.volume == volue)
            {
                this.btnPlay.Image = Properties.Resources.playbtn_pause;   //更换图标
                PlayHelper.PlayStatu = 1;    //设置为播放
                btnPlay.Enabled = true;
            }
            else
            {
                this.axWindowsMediaPlayer.settings.volume += 1;
                Thread ts = new Thread(Playsst);
                Thread.Sleep(10);
                ts.Start();
            }
        }
        public void Playser()
        {
            string url = null;  //音乐链接
            string musicTitle = null;   //音乐标题
            if (PlayerType.PlayerGroup == PlayType.local)
            {
                url = list[0].MusciURL;
                musicTitle = list[0].MusicName.Split('.')[0];
            }
            else if (PlayerType.PlayerGroup == PlayType.online)
            {
                url = musicOnlineList[0].MusciURL;
                musicTitle = musicOnlineList[0].MusicName.Split('.')[0];
            }
            else if (PlayerType.PlayerGroup == PlayType.collection)
            {
                List<Music> musicList1 = null;
                if (!searchMusicList.Any())
                {
                    musicList1 = list;
                }
                else
                {
                    musicList1 = searchMusicList;
                }
                url = musicList1[0].MusciURL;
                musicTitle = musicList1[0].MusicName.Split('.')[0];
            }
            if (File.Exists(url))   //判断歌曲是否存在
            {
                this.axWindowsMediaPlayer.URL = url;   //默认播放第一首歌曲
                //this.axWindowsMediaPlayer.Ctlcontrols.play();
                PlayHelper.PlayStatu = 1;
                PlayHelper.MusicId = 1;
                this.btnPlay.Image = Properties.Resources.playbtn_pause;
                //给第一首歌曲设置样式
                this.pMusicList.Controls.Find("panelSong1", false)[0].Height = 60;
                if (Properties.Settings.Default.Skmin == true)
                { this.pMusicList.Controls.Find("panelSong1", false)[0].BackColor = Color.FromArgb(r, g, b); }
                else { this.pMusicList.Controls.Find("panelSong1", false)[0].BackColor = Color.FromArgb(13, 174, 81); }
                this.pMusicList.Controls.Find("panelSong1", false)[0].Controls["lbSong"].ForeColor = Color.White;
                this.pMusicList.Controls.Find("panelSong1", false)[0].Controls["lbTime"].ForeColor = Color.White;
            }
            else
            {
                PlayHelper.PlayStatu = 1;
                PlayHelper.MusicId = 1;
                this.btnPlay.Image = Properties.Resources.playbtn_pause;
                //给第一首歌曲设置样式
                this.pMusicList.Controls.Find("panelSong1", false)[0].Height = 60;
                if (Properties.Settings.Default.Skmin == true)
                { this.pMusicList.Controls.Find("panelSong1", false)[0].BackColor = Color.FromArgb(r, g, b); }
                else { this.pMusicList.Controls.Find("panelSong1", false)[0].BackColor = Color.FromArgb(13, 174, 81); }
                this.pMusicList.Controls.Find("panelSong1", false)[0].Controls["lbSong"].ForeColor = Color.White;
                this.pMusicList.Controls.Find("panelSong1", false)[0].Controls["lbTime"].ForeColor = Color.White;
                this.pMusicList.Controls.Find("panelSong1", false)[0].Controls["lbError"].Visible = true;
                this.btnPlay.Image = Properties.Resources.playbtn_play;
            }
            //todo:这里需要根据播放列表设置音乐标题
            this.lbTitle.Text = musicTitle;
            this.Text = musicTitle; not.Text = musicTitle;
            btnPlay.Enabled = true;
        }

        /// <summary>
        /// 下一曲
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, EventArgs e)
        {
            isDown = true;
            Thread ts = new Thread(AmendStyle);
            ts.IsBackground = true;
            ts.Start();
        }

        /// <summary>
        /// 上一曲
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrev_Click(object sender, EventArgs e)
        {
            isDown = false;
            Thread ts = new Thread(AmendStyle);
            ts.IsBackground = true;
            ts.Start();
        }

        /// <summary>
        /// 歌曲文字滚动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbTextRolling_Tick(object sender, EventArgs e)
        {
            TextRolling(this.lbTitle);
        }

        /// <summary>
        /// 文字滚动
        /// </summary>
        /// <param name="control"></param>
        private void TextRolling(Control control)
        {
            if (control.Text.Length > 15)
            {
                string musicTitle = control.Text.Substring(1, control.Text.Length - 1) + control.Text.Substring(0, 1);
                control.Text = musicTitle;
            }
        }

        /// <summary>
        /// 音量调节
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void volControl_ScrollValueChange(object sender, EventArgs e)
        {
            Thread h = new Thread(vCs); h.Start();
        }
        public void vCs()
        {
            this.axWindowsMediaPlayer.settings.volume = this.volControl.Value;
        }

        /// <summary>
        /// 添加音乐
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelAddMusic_Click(object sender, EventArgs e)
        {
            AddMusic.SelectMusic();
            this.pMusicList.Controls.Clear();
            list = XMLHelper.ReadXML();
            LoadData(list);
        }

        /// <summary>
        /// 创建搜索框和按钮等控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateSearchControl(object sender, EventArgs e)
        {
            Panel panName1 = new System.Windows.Forms.Panel();
            panName1.Dock = System.Windows.Forms.DockStyle.Top;
            panName1.Location = new System.Drawing.Point(0, 0);
            panName1.Name = "panelSearchMusic";
            panName1.Size = new System.Drawing.Size(279, 36);
            if (Properties.Settings.Default.Skmin == true)
            { panName1.BackColor = Color.FromArgb(r,g,b); }
            else { panName1.BackColor = Color.FromArgb(13, 174, 81); }

            Panel panelSearch = new Panel();
            panelSearch.Name = "panelOnlineMusic";
            panelSearch.Size = new Size(220, 26);
            panelSearch.Location = new Point(8, 5);
            panelSearch.BackgroundImage = Resources.search_edit;
            panelSearch.BackgroundImageLayout = ImageLayout.Stretch;

            System.Windows.Forms.TextBox txtSearch = new TextBox();
            txtSearch.Name = "txtSerarch";
            txtSearch.Location = new Point(8, 7);
            txtSearch.Width = 150;
            txtSearch.ForeColor = Color.DimGray;
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Text = "请输入歌曲名或歌手";
            txtSearch.ImeMode = ImeMode.On;

            Panel panelSearchMusic = new Panel();
            panelSearchMusic.Size = new Size(17, 17);
            panelSearchMusic.Location = new Point(195, 4);
            panelSearchMusic.BackgroundImage = Resources.fm_search_btn;
            panelSearchMusic.BackgroundImageLayout = ImageLayout.Zoom;
            panelSearchMusic.BackColor = Color.White;
            panelSearchMusic.Cursor = Cursors.Hand;

            //搜索按钮点击事件
            panelSearchMusic.Click += new EventHandler(panelSearchMusic_Click);
            txtSearch.KeyPress += new KeyPressEventHandler(txtSearch_KeyPress);
            txtSearch.Click += new EventHandler(txtSearch_Click);

            panelSearch.Controls.Add(txtSearch);
            panelSearch.Controls.Add(panelSearchMusic);
            panName1.Controls.Add(panelSearch);
            this.pMusicList.Controls.Add(panName1);
            this.pMusicList.Refresh();
        }

        /// <summary>
        /// 添加分页控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreatePageNavControl(object sender, EventArgs e)
        {
            Panel panel = new Panel()
            {
                Name = "panelNav",
                Size = new System.Drawing.Size(250, 26),
                BackColor = Color.White,
                Location = new System.Drawing.Point(0, 0),
                Dock = System.Windows.Forms.DockStyle.Bottom
            };
            Label lbPrev = new Label()
            {
                Text = "上一页",
                BackColor = Color.Transparent,
                ForeColor = SystemColors.ActiveCaptionText,
                AutoSize = false,
                Size = new Size(50, 20),
                Location = new Point(30, 3),
                TextAlign = ContentAlignment.MiddleCenter,
                Cursor = Cursors.Hand
            };
            Label lbNext = new Label()
            {
                Text = "下一页",
                BackColor = Color.Transparent,
                ForeColor = SystemColors.ActiveCaptionText,
                AutoSize = false,
                Size = new Size(50, 20),
                Location = new Point(150, 3),
                TextAlign = ContentAlignment.MiddleCenter,
                Cursor = Cursors.Hand
            };

            lbPrev.Click += new EventHandler(lbPrev_Click);
            lbNext.Click += new EventHandler(lbNext_Click);

            panel.Controls.Add(lbPrev);
            panel.Controls.Add(lbNext);
            pMusicList.Controls.Add(panel);
        }

        /// <summary>
        /// 点击搜索在线音乐
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelSearchMusic_Click(object sender, EventArgs e)
        {
            muing.Visible = true;
            SearchText = pMusicList.Controls["panelSearchMusic"].Controls["panelOnlineMusic"].Controls["txtSerarch"].Text;
            Task.Factory.StartNew(() =>
            {
                PageInfo.PageIndex = PageInfo.PageIndex == 0 ? 1 : PageInfo.PageIndex;
                PageInfo.PageSize = 12;
                #region old code
                //var musicOnlineList = new SearchMusic().GetMusicByApi(searchText, PageInfo.PageIndex, PageInfo.PageSize);
                //if (musicOnlineList != null && musicOnlineList.data != null)
                //{
                //    PageInfo.RecordCount = musicOnlineList.data.total;
                //    PageInfo.PageCount = (int)Math.Ceiling((double)PageInfo.RecordCount / PageInfo.PageSize);
                //    PageInfo.SearchText = searchText;
                //    searchMusicList.Clear(); //这里如果清空那么正在播放的音乐完成后会接不上下一曲
                //    foreach (var item in musicOnlineList.data.info)
                //    {
                //        var music = new Music()
                //        {
                //            MusciURL = new SearchMusic().GetMusicUrl(item.hash),
                //            MusicName = item.filename,
                //            MusicPic = new SearchMusic().GetMusicPic(item.singername),
                //            MusicTime = MusicTimes.ConvertTime(item.duration),
                //            Bitrate = item.bitrate + "kbps"
                //        };
                //        searchMusicList.Add(music);
                //    }
                //} 
                #endregion
                RequestMusicOnline(SearchText);
                pMusicList.Invoke(new Action(() =>
                {
                    this.pMusicList.Controls.Clear();
                    LoadData(searchMusicList);
                    CreateSearchControl(sender, e);
                    CreatePageNavControl(sender, e);
                }));
            });
        }

        /// <summary>
        /// 文本框回车响应事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)//如果输入的是回车键  
            {
                this.panelSearchMusic_Click(sender, e);//触发button事件  
            }
        }

        /// <summary>
        /// 获得焦点清楚提示文本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSearch_Click(object sender, EventArgs e)
        {
            pMusicList.Controls["panelSearchMusic"].Controls["panelOnlineMusic"].Controls["txtSerarch"].Text = string.Empty;
        }

        /// <summary>
        /// 歌曲列表中添加比特率Label控件
        /// </summary>
        /// <param name="control"></param>
        private void AddBitRate(Control control)
        {
            List<Music> currentList = null;
            if (PlayerType.type == PlayType.local)
            {
                currentList = list;
            }
            else if (PlayerType.type == PlayType.online)
            {
                currentList = musicOnlineList;
            }
            else if (PlayerType.type == PlayType.collection)
            {
                currentList = searchMusicList;
            }
            System.Windows.Forms.Label lbBit = new System.Windows.Forms.Label();
            lbBit.AutoSize = true;
            lbBit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            lbBit.Location = new System.Drawing.Point(7, 35);
            lbBit.Name = "lbBit";
            lbBit.Size = new System.Drawing.Size(113, 12);
            lbBit.Text = "比特率:" + currentList.FirstOrDefault(a => a.MusicName.Equals(control.Controls["lbSong"].Text)).Bitrate;
            lbBit.ForeColor = Color.White;
            lbBit.Font = new Font(this.panName.Font.FontFamily, 7);
            control.Controls.Add(lbBit);
        }

        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbPrev_Click(object sender, EventArgs e)
        {
            muing.Visible = true;
            if (!searchMusicList.Any())
                return;
            if (PageInfo.PageIndex <= 1)
                return;
            PageInfo.PageIndex -= 1;
            Task.Factory.StartNew(() =>
            {
                RequestMusicOnline(SearchText);
                pMusicList.Invoke(new Action(() =>
                {
                    this.pMusicList.Controls.Clear();
                    LoadData(searchMusicList);
                    CreateSearchControl(sender, e);
                    CreatePageNavControl(sender, e);
                }));
            });
        }

        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbNext_Click(object sender, EventArgs e)
        {
            muing.Visible = true;
            if (!searchMusicList.Any())
                return;
            if (PageInfo.PageIndex >= PageInfo.PageCount)
                return;
            PageInfo.PageIndex += 1;
            Task.Factory.StartNew(() =>
            {
                RequestMusicOnline(SearchText);
                pMusicList.Invoke(new Action(() =>
                {
                    this.pMusicList.Controls.Clear();
                    LoadData(searchMusicList);
                    CreateSearchControl(sender, e);
                    CreatePageNavControl(sender, e);
                }));
            });
        }

        /// <summary>
        /// 请求在线音乐列表
        /// </summary>
        /// <param name="searchText"></param>
        private void RequestMusicOnline(string searchText)
        {
            var musicOnlineList = new SearchMusic().GetMusicByApi(searchText, PageInfo.PageIndex, PageInfo.PageSize);
            if (musicOnlineList != null && musicOnlineList.data != null)
            {
                PageInfo.RecordCount = musicOnlineList.data.total;
                PageInfo.PageCount = (int)Math.Ceiling((double)PageInfo.RecordCount / PageInfo.PageSize);
                PageInfo.SearchText = searchText;
                searchMusicList.Clear(); //这里如果清空那么正在播放的音乐完成后会接不上下一曲
                foreach (var item in musicOnlineList.data.info)
                {
                    var music = new Music()
                    {
                        MusciURL = new SearchMusic().GetMusicUrl(item.hash),
                        MusicName = item.filename,
                        MusicPic = new SearchMusic().GetMusicPic(item.singername),
                        MusicTime = MusicTimes.ConvertTime(item.duration),
                        Bitrate = item.bitrate + "kbps"
                    };
                    searchMusicList.Add(music);
                }
            }
            muing.Visible = false;
        }

        /// <summary>
        /// 音乐列表滚轮滚动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pMusicList_MouseWheel(object sender, MouseEventArgs e)
        {
            Point mousePoint = new Point(e.X, e.Y);
            mousePoint.Offset(this.Location.X, this.Location.Y);
            if (pMusicList.RectangleToScreen(pMusicList.DisplayRectangle).Contains(mousePoint))
            {
                //滚动
                pMusicList.AutoScrollPosition = new Point(0, pMusicList.VerticalScroll.Value - e.Delta);
            }
        }

        private void lbLocalMusic_Click(object sender, EventArgs e)
        {
            Labelsender = 2;
            lbLocalMusic.ForeColor = Color.FromArgb(fr, fg, fb);
            if (Properties.Settings.Default.Skmin == true)
            { lbLocalMusic.BackColor = Color.FromArgb(r,g,b); }
            else { lbLocalMusic.BackColor = Color.FromArgb(13, 174, 81); }

            lbCollection.ForeColor = Color.FromArgb(fr, fg, fb);
            lbCollection.BackColor = Color.FromArgb(200, 200, 200);
            lbMusicOnline.ForeColor = Color.FromArgb(fr, fg, fb);
            lbMusicOnline.BackColor = Color.FromArgb(200, 200, 200);
            PlayerType.type = PlayType.local;
            this.pMusicList.Controls.Clear();
            LoadData(list);
        }

        private void lbCollection_Click(object sender, EventArgs e)
        {
            Labelsender = 3;
            lbCollection.ForeColor = Color.FromArgb(fr, fg, fb);
            if (Properties.Settings.Default.Skmin == true)
            { lbCollection.BackColor = Color.FromArgb(r,g,b); }
            else { lbCollection.BackColor = Color.FromArgb(13, 174, 81); }

            lbMusicOnline.ForeColor = Color.FromArgb(fr, fg, fb);
            lbMusicOnline.BackColor = Color.FromArgb(200, 200, 200);
            lbLocalMusic.ForeColor = Color.FromArgb(fr, fg, fb);
            lbLocalMusic.BackColor = Color.FromArgb(200, 200, 200);
            PlayerType.type = PlayType.collection;
            if (searchMusicList == null || !searchMusicList.Any())
            {
                this.pMusicList.Controls.Clear();
                CreateSearchControl(sender, e);
                CreatePageNavControl(sender, e);
            }
            else
            {
                this.pMusicList.Controls.Clear();
                CreatePageNavControl(sender, e);
                LoadData(searchMusicList);
                CreateSearchControl(sender, e);
            }
        }

        private void lbMusicOnline_Click(object sender, EventArgs e)
        {
            Labelsender = 1;
            lbMusicOnline.ForeColor = Color.FromArgb(fr, fg, fb);
            if (Properties.Settings.Default.Skmin == true)
            { lbMusicOnline.BackColor = Color.FromArgb(r,g,b); }
            else { lbMusicOnline.BackColor = Color.FromArgb(13, 174, 81); }

            lbCollection.ForeColor = Color.FromArgb(fr, fg, fb);
            lbCollection.BackColor = Color.FromArgb(200, 200, 200);
            lbLocalMusic.ForeColor = Color.FromArgb(fr, fg, fb);
            lbLocalMusic.BackColor = Color.FromArgb(200, 200, 200);
            PlayerType.type = PlayType.online;
            this.pMusicList.Controls.Clear();
            //todo:这里对在线音乐进行处理
            Task.Factory.StartNew(() => LoadData(musicOnlineList));
        }

        private void lbMusicOnline_MouseLeave(object sender, EventArgs e)
        {
            if (Labelsender != 1)
            {
                lbMusicOnline.ForeColor = Color.FromArgb(fr, fg, fb);
                lbMusicOnline.BackColor = Color.FromArgb(200, 200, 200);
            }
        }

        private void lbLocalMusic_MouseLeave(object sender, EventArgs e)
        {
            if (Labelsender != 2)
            {
                lbLocalMusic.ForeColor = Color.FromArgb(fr, fg, fb);
                lbLocalMusic.BackColor = Color.FromArgb(200, 200, 200);
            }
        }

        private void lbCollection_MouseLeave(object sender, EventArgs e)
        {
            if (Labelsender != 3)
            {
                lbCollection.ForeColor = Color.FromArgb(fr, fg, fb);
                lbCollection.BackColor = Color.FromArgb(200, 200, 200);
            }
        }

        private void Skin_Click(object sender, EventArgs e)
        {
            if (Skins.Visible == false)
            { Skins.Visible = true; }
            else
            { Skins.Visible = false; }
        }

        private void div_Click(object sender, EventArgs e)
        {
            Thread ts = new Thread(divc);
            ts.IsBackground = true;
            ts.Start();
        }
        public void divc()
        {
            //try {File.Delete(Application.StartupPath + @"/Skin.dll");}catch (Exception) { }
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(Application.StartupPath + (@"\Skin.dll"), FileMode.Create, FileAccess.Write);
                StreamWriter sr = new StreamWriter(fs, Encoding.Unicode);
                sr.WriteLine(colorDialog.Color.R + "\r\n" + colorDialog.Color.B + "\r\n" + colorDialog.Color.G);
                sr.Close();
                fs.Close();
                not.Dispose();
                Properties.Settings.Default.volue = this.volControl.Value;
                Properties.Settings.Default.Save();
                System.Windows.Forms.Application.Restart();
                using (var streamWriter = new StreamWriter("list.dat", false, Encoding.UTF8))
                {
                    streamWriter.Write("");
                } not.Dispose(); this.Close();
                Application.Exit();
                System.Environment.Exit(0);
                this.Dispose();
            }
        }

        private void divbei(object sender, EventArgs e)
        {
            PlayHelper.PlayStatu = 0;   //将状态设置为暂停
            this.axWindowsMediaPlayer.Ctlcontrols.pause();  //暂停播放
            this.btnPlay.Image = Properties.Resources.playbtn_play;    //更换图标
            try
            {if (openFile.ShowDialog() == DialogResult.OK)
            {
                Thread ts = new Thread(dibei);
                ts.IsBackground = true;
                ts.Start();
            }
            }
            catch (Exception) { }
        }
        public void dibei()
        {
            Properties.Settings.Default.backimg = openFile.FileName;
            this.BackgroundImage = Image.FromFile(openFile.FileName);
        }

        private void Errs_Click(object sender, EventArgs e)
        {
            Errs.Visible = false;
            Thread ts = new Thread(Errc);
            ts.IsBackground = true;
            ts.Start();
        }
        public void Errc()
        {
            if (!TestNetwork.Test())
            {
                Errs.Visible = true;
                lbMusicOnline.Enabled = false; lbCollection.Enabled = false;
            }
            else
            {
                Errs.Visible = false;
                lbMusicOnline.Enabled = true; lbCollection.Enabled = true;
                //加载心理Fm列表
                musicOnlineList = ResolveOnlineMusicList.ResolveMusic(GetHtmlCode.WriteInfo(1));
            }
        }
        public static bool Suop = false;

        private void Close_Click(object sender, EventArgs e)
        {
            Skins.Visible = false;
            this.Visible = false;
            Suo.Top = 435;
        }

        private void not_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            if (Suop == true) {
                Thread s = new Thread(Suopin); s.Start();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Abut ab = new Abut();
            ab.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Properties.Settings.Default.PassS = null;
                File.Delete(Application.StartupPath + @"\musicList.xml");
                File.Delete(Application.StartupPath + @"\musiccount.dat");
                File.Delete(Application.StartupPath + @"\Skin.dll");
                File.Delete(Application.StartupPath + @"\list.dat");
                Properties.Settings.Default.Update = true;
                Properties.Settings.Default.backimg = ""; Properties.Settings.Default.volue = 70;
            }
            catch
            {
                Properties.Settings.Default.PassS = null;
                File.Delete(Application.StartupPath + @"\musicList.xml");
                File.Delete(Application.StartupPath + @"\musiccount.dat");
                File.Delete(Application.StartupPath + @"\list.dat");
                Properties.Settings.Default.Update = true;
                Properties.Settings.Default.backimg = ""; Properties.Settings.Default.volue = 70;
            }
            Properties.Settings.Default.Save();
            System.Windows.Forms.Application.Restart();
            using (var streamWriter = new StreamWriter("list.dat", false, Encoding.UTF8))
            {
                streamWriter.Write("");
            } not.Dispose(); this.Close();
            Application.Exit();
            System.Environment.Exit(0);
            this.Dispose();
        }

        private void down_Click(object sender, EventArgs e)
        {
            try
            {
                if (Labelsender != 2)
                {
                    Form f1 = new Down(lbTitle.Text, axWindowsMediaPlayer.currentMedia.sourceURL);
                    f1.Show();
                }
            }
            catch (Exception) { }
        }

        private void SuoP(object sender, EventArgs e)
        {
            Suop = true;
            Thread s = new Thread(Suopin); s.Start();
        }

        #region 变量
        //九宫格的九个点
        public List<Point> NinePoints = new List<Point>();
        //解锁点列表
        public List<Point> UnLockPoint = new List<Point>();
        //绘制九宫格圆心点的画笔
        public Pen DrawPen = new Pen(Color.FromArgb(200, Color.DodgerBlue), 5);//线条颜色
        //是否开始绘制解锁（鼠标左键按下时开始）
        private bool _isDraw = false;
        //是否选中九宫格中的其中一个点
        private bool _isSelected = false;
        //临时存储密码字符串
        public string PasswordStr = "";
        #endregion

        public void Suopin()
        {
            if (Suo.Top <= 30)
            {
                Suo.Top =0;
                //添加一块画布
                Bitmap backBit = new Bitmap(panel5.Width, panel5.Height);
                Graphics g = Graphics.FromImage(backBit);
                g.SmoothingMode = SmoothingMode.HighQuality;
                //清除Graphics
                g.Clear(panel5.BackColor);
                //绘制画布
                g.DrawImage(backBit, new Rectangle(0, 0, panel5.Width, panel5.Height),
                    new Rectangle(0, 0, panel5.Width, panel5.Height), GraphicsUnit.Pixel);
                //绘制九宫格的点
                for (int i = 0; i < NinePoints.Count; i++)
                {
                    g.DrawImage(Resources.NinePoints, new Point(NinePoints[i].X - 20, NinePoints[i].Y - 20));
                }
                panel5.BackgroundImage = backBit;
                CreadtNinePoint();
            }
            else if (this.Visible == true)
            {
                Suo.Top -= 20; Thread s = new Thread(Suopin); Thread.Sleep(10); s.Start();
            }
        }

        #region 方法
        /// <summary>
        /// 初始化九宫格的九个点
        /// </summary>
        public void CreadtNinePoint()
        {
            NinePoints.Clear();
            int pwith = panel5.Width / 3;
            int pheight = panel5.Height / 3;
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    NinePoints.Add(new Point(pwith * x + pwith / 2, pheight * y + pheight / 2));
                }
            }
        }
        /// <summary>
        /// 绘制九宫格解锁图案
        /// </summary>
        public void ShowAreaAndLine()
        {
            try
            {
                //添加一块画布
                Bitmap backBit = new Bitmap(panel5.Width, panel5.Height);
                Graphics g = Graphics.FromImage(backBit);
                g.SmoothingMode = SmoothingMode.HighQuality;
                //清除Graphics
                g.Clear(panel5.BackColor);
                //绘制画布
                g.DrawImage(backBit, new Rectangle(0, 0, panel5.Width, panel5.Height),
                    new Rectangle(0, 0, panel5.Width, panel5.Height), GraphicsUnit.Pixel);
                //绘制九宫格的点
                for (int i = 0; i < NinePoints.Count; i++)
                {
                    g.DrawImage(Resources.NinePoints, new Point(NinePoints[i].X - 20, NinePoints[i].Y - 20));
                }
                //绘制选中的解锁点
                int pointIndex = 1;
                Point pointEnd;
                Point pointStart = new Point(0, 0);
                for (int i = 0; i < UnLockPoint.Count; i++)
                {
                    //绘制选中点背景
                    if (i < UnLockPoint.Count - 1 || _isSelected)
                    {
                        //高亮绘制选中点
                        g.DrawImage(Resources.NinePointsSelect, new Point(UnLockPoint[i].X - 20, UnLockPoint[i].Y - 20));
                    }
                    pointEnd = UnLockPoint[i];
                    //绘制两点连接的直线
                    if (pointIndex > 1)
                    {
                        g.DrawLine(DrawPen, pointStart, pointEnd);
                    }
                    //绘制小圆，覆盖两条线段的连接处
                    if (i < UnLockPoint.Count - 1 || _isSelected)
                    {
                        //绘制区域（）
                        Rectangle rg = new Rectangle(UnLockPoint[i].X - 6, UnLockPoint[i].Y - 6, 11, 11);
                        g.DrawEllipse(DrawPen, rg);
                        //画空心圆
                        Brush bru = new SolidBrush(Color.FromArgb(100, Color.DodgerBlue));//中心点Brush bru = new SolidBrush(Color.DodgerBlue);
                        g.FillEllipse(bru, rg);
                        //填充空心圆，实心圆

                    }
                    pointStart = UnLockPoint[i];
                    pointIndex++;

                }
                g.Dispose();
                panel5.CreateGraphics().DrawImage(backBit, 0, 0);
                backBit.Dispose();
            }
            catch(Exception ex)
            {
                Debug.Write(ex.Message);
            }
        }

        /// <summary>
        /// 传入一个点，判断是否是九宫格中的一个点，并处理
        /// </summary>
        /// <param name="p">点</param>
        public void AddPoint(Point p)
        {
            for (int i = 0; i < NinePoints.Count; i++)
            {
                //遍历九宫格的点，鼠标经过的点是否在其中一个九宫格的点的范围内
                if ((p.X > NinePoints[i].X - 20 && p.X < NinePoints[i].X + 20) && (p.Y > NinePoints[i].Y - 20 && p.Y < NinePoints[i].Y + 20))
                {
                    //判断九宫格的点是否已经选择过，若选择过则不处理
                    if (!(PasswordStr.IndexOf((i + 1).ToString()) > -1))
                    {
                        //若尚未选择过该点则添加
                        UnLockPoint[UnLockPoint.Count - 1] = (NinePoints[i]);
                        //追加密码字符串
                        PasswordStr = PasswordStr + (i + 1);
                        //密码顺序MessageBox.Show(PasswordStr);
                        _isSelected = true;
                        return;
                    }
                }
            }
        } 
        #endregion

        #region 事件
        /// <summary>
        /// 鼠标点击左键且移动时开始绘制解锁
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawMouseMove(object sender, MouseEventArgs e)
        {
            if (_isDraw)
            {
                //如果还未确定九宫格的点则实时改变最后一个点的坐标
                if (!_isSelected)
                {
                    UnLockPoint[UnLockPoint.Count - 1] = e.Location;

                }
                else//如果确定了则再添加一个改变点
                {
                    UnLockPoint.Add(e.Location);
                    _isSelected = false;
                }
                AddPoint(e.Location);

            }
            ShowAreaAndLine();
            GC.Collect();
        }
        /// <summary>
        /// 鼠标左键弹起时结束绘制九宫格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawMouseUp(object sender, MouseEventArgs e)
        {
            if (_isDraw)
            {
                //停止绘制标示
                _isDraw = false;
                //清除绘制的九宫格点
                UnLockPoint.Clear();
                //显示密码（可用来判断九宫格密码）
                if (PasswordStr.Length < 4)
                {
                    label5.Text="九宫格密码不能小于4个点";
                }
                else
                {
                    if (Properties.Settings.Default.PassS == "")
                    {
                        Properties.Settings.Default.PassS = PasswordStr;
                        label5.Text = "设置密码成功";
                    }
                    else
                    {
                        if (PasswordStr == Properties.Settings.Default.PassS)
                        {
                            label5.Text = null; Suo.Top = 435; Suop = false;
                        }
                        else
                        {
                            label5.Text = "解锁密码错误";
                        }
                    }
                }
                PasswordStr = "";
                //绘制九宫格（此处相当于初始化九宫格）
                ShowAreaAndLine();
            }
        }
        /// <summary>
        /// 鼠标左键点击时触发开始绘制九宫格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawMouseDown(object sender, MouseEventArgs e)
        {
            //开始绘制标记
            _isDraw = true;
            //添加第一个点击的点
            UnLockPoint.Add(e.Location);
            //显示九宫格解锁图案
            ShowAreaAndLine();
        } 
        #endregion
    }
}