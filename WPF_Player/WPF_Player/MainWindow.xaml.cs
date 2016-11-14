using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing.Drawing2D;
using System.Drawing.Design;
using System.IO;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.Configuration;

namespace WPF_Player
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        MyPlayer player = new MyPlayer();
        MediaPlayer playerhandle = null;
        PlayerStatus currentStatus = PlayerStatus.NerverStart;
        ObservableCollection<Song> playList = new ObservableCollection<Song>();
        private int currentIndex = 0;
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.rollingText.StrText = "音乐播放器处于暂停状态";
            this.rollingText.label1.ForeColor = System.Drawing.Color.Blue;

            this.listBox.DataContext = playList;
            playerhandle = player.GetPlayerHandle();
            playerhandle.MediaEnded += playerhandle_MediaEnded;
            playerhandle.MediaFailed += playerhandle_MediaFailed;
            playerhandle.MediaOpened += playerhandle_MediaOpened;
            player.playEvent += player_playEvent;

            this.slider.DataContext = player;

            //读取配置
            string folderPath =ConfigurationManager.AppSettings["folderPath"];
            if(!Directory.Exists(folderPath))
                return;
            GetMP3Files(folderPath).ToList().ForEach(x => playList.Add(new Song() {Location=x}));
        }
        int lastValue;
        void player_playEvent(object sender)
        {
            if (!playerhandle.NaturalDuration.HasTimeSpan)
            {
                return;
            }
            
            double totalTime=playerhandle.NaturalDuration.TimeSpan.TotalSeconds;
            double PlayedTime = playerhandle.Position.TotalSeconds;
            this.trackBar.Text = string.Format("{0}/{1}", playerhandle.Position.TotalSeconds.ToString(), playerhandle.NaturalDuration.TimeSpan.ToString());
            if (lastValue == (int)PlayedTime)
                return;
            this.trackBar.Maximum = (int)totalTime;
            this.trackBar.Value = (int)PlayedTime;
            lastValue = this.trackBar.Value;
        }

        void playerhandle_MediaOpened(object sender, EventArgs e)
        {
            this.rollingText.StrText = "当前播放：" + player.CurrentSong.Name;
        }

        void playerhandle_MediaFailed(object sender, ExceptionEventArgs e)
        {
            
        }

        void playerhandle_MediaEnded(object sender, EventArgs e)
        {
            PlayNext();
        }

        private void btn_Play_Click(object sender, RoutedEventArgs e)
        {
            //1,暂停播放
            //2,从一首新歌播放
            if (currentStatus == PlayerStatus.Pause)
            {            
                Song song = this.listBox.SelectedItem as Song;
                currentIndex = this.listBox.SelectedIndex;
                if (song != player.CurrentSong)
                    player.CurrentSong = song;
                player.Play();
                currentStatus = PlayerStatus.Start;
                this.btn_Play.SetValue(System.Windows.Controls.Button.StyleProperty, System.Windows.Application.Current.Resources["buttonPause"]);
            }
            else if( currentStatus== PlayerStatus.NerverStart)
            {
                if (this.listBox.SelectedIndex < 0)
                {
                    this.rollingText.StrText = "请选择一首歌曲然后播放！";
                    return;
                }
                Song song = this.listBox.SelectedItem as Song;
                currentIndex = this.listBox.SelectedIndex;
                player.CurrentSong = song;
                player.Play();
                currentStatus = PlayerStatus.Start;
                this.btn_Play.SetValue(System.Windows.Controls.Button.StyleProperty, System.Windows.Application.Current.Resources["buttonPause"]);
            }
            else if (currentStatus == PlayerStatus.Start)
            {
                player.Pause();
                currentStatus = PlayerStatus.Pause;
                this.btn_Play.SetValue(System.Windows.Controls.Button.StyleProperty, System.Windows.Application.Current.Resources["buttonPlay"]);
            }

        }

        private void btn_Previous_Click(object sender, RoutedEventArgs e)
        {
            PlayPrevious();
        }
    
        void PlayPrevious()
        {
            if (currentStatus == PlayerStatus.Start)
                player.Stop();
            currentIndex--;
            if (currentIndex < 0)
                currentIndex = playList.Count - 1;
            this.listBox.SelectedIndex = currentIndex;
            player.CurrentSong = playList[currentIndex];
            player.Play();
            currentStatus = PlayerStatus.Start;
        }
        void PlayNext()
        {
            if (currentStatus == PlayerStatus.Start)
                player.Stop();
            currentIndex++;
            if (currentIndex > playList.Count - 1)
                currentIndex = 0;
            this.listBox.SelectedIndex = currentIndex;
            player.CurrentSong = playList[currentIndex];
            player.Play();
            currentStatus = PlayerStatus.Start;
        }
        private void btn_Next_Click(object sender, RoutedEventArgs e)
        {
            PlayNext();
        }
        enum PlayerStatus
        {
            NerverStart=1,
            Start,
            Pause,
            Stop
        }
        private void loadSong_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "请选择歌曲的文件夹";
            if (fbd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            string folderfName = fbd.SelectedPath;
            string[] mp3Files = GetMP3Files(folderfName);
            if(mp3Files!=null)
            {
                playList.Clear();
                mp3Files.ToList().ForEach(x => playList.Add(new Song(){ Location=x}));
            }
        }
        private string[] GetMP3Files(string folderName)
        {
            if (!Directory.Exists(folderName))
                throw new Exception("文件夹:" + folderName + "不存在！");
            Configuration c = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            c.AppSettings.Settings["folderPath"].Value = folderName;
            c.Save();          
            return Directory.GetFiles(folderName, "*.mp3");
        }

        private void listBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (currentStatus == PlayerStatus.Start)
                player.Stop();
            Song song = this.listBox.SelectedItem as Song;
            currentIndex = this.listBox.SelectedIndex;
            player.CurrentSong = song;
            player.Play();
            currentStatus = PlayerStatus.Start;
            this.btn_Play.SetValue(System.Windows.Controls.Button.StyleProperty, System.Windows.Application.Current.Resources["buttonPause"]);
        }
    }
}
