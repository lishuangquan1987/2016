using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Media;
using System.IO;
using System.Windows.Forms;

namespace WPF_Player
{
   public class MyPlayer:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
     
 
       public delegate void PlayEvent(object sender);
       /// <summary>
       /// 定义事件委托，在播放时不断触发
       /// </summary>
        public event PlayEvent playEvent;
        private Timer timer = new Timer();
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        private MediaPlayer _player = null;
        private Song currentSong;
        public Song CurrentSong
        {
            get { return currentSong; }
            set { currentSong = value; OnPropertyChanged("Song"); SongPath = value.Location; }
        }
      
        public double Volume
        {
            get { return _player.Volume*100; }
            set { _player.Volume = value/100; OnPropertyChanged("Volume"); }
        }
        public MyPlayer()
        {
            _player = new MediaPlayer();
            timer.Interval = 500;
            timer.Tick += timer_Tick;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (playEvent != null)
                playEvent(this);
        }
        private string _songPath;
       /// <summary>
       /// 歌曲路劲
       /// </summary>
        public string SongPath
        {
            get { return _player.Source.LocalPath; }
            set { 
                         _songPath = value; OnPropertyChanged("SongPath");
                         if (File.Exists(value))
                         {
                             _player.Open(new Uri(value));
                             if(_player.NaturalDuration.HasTimeSpan)
                             Length = _player.NaturalDuration.TimeSpan.TotalSeconds;
                        }
                  }
        }
       public void Play()
        {
            _player.Play();
            timer.Enabled = true;
        }
       public void Stop()
       {
           _player.Stop();
           timer.Enabled = false;
       }
       public void Pause()
       {
           _player.Pause();
           timer.Enabled = false;
       }
       private double _length;
       public MediaPlayer GetPlayerHandle()
       {
           return _player;
       }
        public double Length
        {
          get { return _length; }
            set { _length = value; OnPropertyChanged("Length"); }
        }
    }
}
