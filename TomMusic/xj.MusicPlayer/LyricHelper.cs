using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xj.MusicPlayer
{
    /// <summary>
    /// 解析歌词文件
    /// </summary>
    public class LyricHelper
    {
        public static Dictionary<string, string> ReadLrc(string path)
        {
            Dictionary<string, string> lrcDic = new Dictionary<string, string>();
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string lrc = sr.ReadToEnd();
                    string reg = @"((?:\[\d+:\d+(?:.\d+)?\])+)(.*)";    //匹配时间和歌词
                    MatchCollection mc = Regex.Matches(lrc, reg);
                    foreach (var item in mc)
                    {
                        string timeReg = @"\[(\d+):(\d+)(?:.(\d+))?\]";     //匹配时间
                        MatchCollection mcMatch = Regex.Matches(item.ToString(), timeReg);
                        foreach (var mcTime in mcMatch)
                        {
                            string lrcReg = @"\][^\]]*$";
                            Match lrcMatch = Regex.Match(item.ToString(), lrcReg);

                            lrcDic.Add(mcTime.ToString().Substring(1, mcTime.ToString().Length - 2), lrcMatch.Value.Substring(1, lrcMatch.Length - 1));
                        }
                    }
                }
            }
            else
            {
                //todo:没有歌词先下载再调用这个方法
                //http://music.baidu.com/search/lrc?from=new_mp3&key=歌曲名称
            }
            return lrcDic;
        }
    }

    public class LrcSpeed
    {
        public static double Speed { get; set; }
    }

}
