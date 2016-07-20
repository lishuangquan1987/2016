using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using xj.MusicPlayer.Properties;

namespace xj.MusicPlayer
{
    public class AddMusic
    {
        /// <summary>
        /// 添加文件夹，获取其中所有的音频文件
        /// </summary>
        /// <returns></returns>
        public static void OpenFolder()
        {
            List<Music> musicList = new List<Music>();
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string foldPath = fbd.SelectedPath;     //获取到选择的文件夹路径
                string[] fileStrings = Directory.GetFiles(foldPath);    //获取所有文件
                if (fileStrings.Length > 0)
                {
                    //遍历这个数组
                    for (int i = 0; i < fileStrings.Length; i++)
                    {
                        //判断是否是音频文件
                        if (fileStrings[i].Contains(".mp3") || fileStrings[i].Contains(".wma") || fileStrings[i].Contains(".wav") || fileStrings[i].Contains(".m4a"))
                        {
                            Music music = new Music();
                            //是加到集合里
                            music.MusciURL = fileStrings[i];
                            string name = Regex.Match(fileStrings[i], "[^/\\\\]+$").ToString();     //正则匹配文件名
                            music.MusicName = name.Substring(0, name.Length - 4);   //不要扩展名
                            string musicTime = MusicTimes.GetMusicTime(fileStrings[i]);
                            music.MusicTime = musicTime.Length == 0 ? "00:00" : musicTime.Substring(3, 5);  //获取时长
                            music.Bitrate = MusicTimes.GetMusicBit(fileStrings[i]);
                            musicList.Add(music);
                        }
                    }
                }
            }
            fbd.Dispose();
            //判断获取到的歌曲数目是否大于0
            if (musicList.Count > 0)
            {
                //这里将获取到的歌曲数量存储到本地的文件中
                using (FileStream stream = new FileStream("musiccount.dat", FileMode.Create))
                {
                    string count = musicList.Count.ToString();
                    byte[] buffers = System.Text.Encoding.UTF8.GetBytes(count);
                    stream.Write(buffers, 0, buffers.Length);
                }
                XMLHelper.WritXML(musicList);   //调用xml存储到xml中
            }
        }

        /// <summary>
        /// 选择音乐文件
        /// </summary>
        public static void SelectMusic()
        {
            List<Music> musicList = new List<Music>();
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = Resources.AddMusic_SelectMusic;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string file = ofd.FileName;
                    Music music = new Music();
                    //是加到集合里
                    music.MusciURL = file;
                    string name = Regex.Match(file, "[^/\\\\]+$").ToString();     //正则匹配文件名
                    music.MusicName = name.Substring(0, name.Length - 4);   //不要扩展名
                    string musicTime = MusicTimes.GetMusicTime(file);
                    music.MusicTime = musicTime.Length == 0 ? "00:00" : musicTime.Substring(3, 5);  //获取时长
                    music.Bitrate = MusicTimes.GetMusicBit(file);
                    musicList.Add(music);
                }
            }
            //判断获取到的歌曲数目是否大于0
            if (musicList.Count > 0)
            {
                //这里将获取到的歌曲数量存储到本地的文件中
                using (FileStream stream = new FileStream("musiccount.dat", FileMode.Create))
                {
                    string count = musicList.Count.ToString();
                    byte[] buffers = System.Text.Encoding.UTF8.GetBytes(count);
                    stream.Write(buffers, 0, buffers.Length);
                }
                XMLHelper.WritXML(musicList);   //调用xml存储到xml中
            }
        }
    }
}
