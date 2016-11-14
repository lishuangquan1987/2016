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
using System.IO;

namespace 重写button
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            player.MediaEnded += player_MediaEnded;
            player.MediaOpened += player_MediaOpened;
            player.MediaFailed += player_MediaFailed;
            
        }
        string path = @"D:\KuGou\Listen";
        int playIndex = 0;
        void player_MediaFailed(object sender, ExceptionEventArgs e)
        {
            MessageBox.Show("播放失败！" + e.ErrorException.Message);
        }

        void player_MediaOpened(object sender, EventArgs e)
        {
            MessageBox.Show("当前播放：" + ((MediaPlayer)sender).Source.LocalPath);
        }

        void player_MediaEnded(object sender, EventArgs e)
        {
            
            PlayNext();
        }
        MediaPlayer player = new MediaPlayer();
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            string toolTip = b.ToolTip.ToString();
            if (toolTip == "播放")
            {
                b.SetValue(Button.StyleProperty, Application.Current.Resources["buttonPause"]);
                b.ToolTip = "暂停";
                Play(Directory.GetFiles(path, "*.mp3")[0]);
                
            }
            else
            {
                b.SetValue(Button.StyleProperty,Application.Current.Resources["buttonPlay"]);
                b.ToolTip = "播放";
                player.Pause();
            }
        }
        void Play(string filename)
        {
            //string path = @"D:\KuGou\Listen\南征北战 - 我的天空 - 影片剪辑版 - 《青春派》 电影原声.mp3";           
            player.Open(new Uri(filename));
            player.Play();
        }
        void PlayNext()
        {
            player.Stop();
            playIndex++;
            string[] filenames= Directory.GetFiles(path, "*.mp3");
            if (playIndex >= filenames.Length)
                playIndex = 0;
            Play(filenames[playIndex]);
        }
        void PlayPrevious()
        {
            player.Stop();
            playIndex--;
            string[] filenames = Directory.GetFiles(path, "*.mp3");
            if (playIndex < 0)
                playIndex = filenames.Length-1;
            Play(filenames[playIndex]);
        }
        private void Next_btn_Click(object sender, RoutedEventArgs e)
        {
            PlayNext();
        }

        private void Previous_btn_Click(object sender, RoutedEventArgs e)
        {
            PlayPrevious();
        }
    }
}
