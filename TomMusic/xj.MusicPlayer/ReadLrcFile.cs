using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Xwlrc;
using System.Text.RegularExpressions;

namespace Xwlrc
{
    public class ReadLrcFile
    {
        #region 根据需求改写
        ///// <summary>
        ///// 读取Lrc格式歌词文件
        ///// </summary>
        ///// <param name="Url">路径</param>
        ///// <param name="Lrcs">歌词集合</param>
        ///// <returns>歌词集合</returns>
        //public Dictionary<int, string> ReadLrc(string Url,Dictionary<int, string> Lrcs)
        //{
        //    try
        //    {
        //        StreamReader sr = new StreamReader(Url, Encoding.Default);
        //        string s;
        //        while ((s = sr.ReadLine()) != null)
        //        {
        //            try
        //            {
        //                string[] temp = s.Split(']');
        //                temp[0] = temp[0].Remove(0, 1);
        //                string[] temp1 = temp[0].Split('.');
        //                if (temp1.Length > 1)
        //                {

        //                    double millTime = Convert.ToDouble(temp1[1]) / 100;
        //                    temp1 = temp1[0].Split(':');
        //                    double minTime = Convert.ToInt32(temp1[0]) * 60;
        //                    double sTime = Convert.ToInt32(temp1[1]);
        //                    double CountTime = (minTime + sTime + millTime) * 1000;
        //                    Lrcs.Add(Convert.ToInt32(CountTime), temp[1]);
        //                }
        //            }
        //            catch { continue; }
        //        }
        //    }
        //    catch {
        //        Lrcs.Clear();
        //    }
        //    return Lrcs;
        //}
        ///// <summary>
        ///// 读取Krc格式歌词文件
        ///// </summary>
        ///// <param name="FolderUrl">路径</param>
        ///// <param name="MusicName">歌曲名称</param>
        ///// <param name="Singer">歌手</param>
        ///// <returns>歌词集合</returns>
        //public Dictionary<int, List<LrcDec>> ReadKrc(string FolderUrl,string FileName,string MusicName, string Singer)
        //{
        //    Dictionary<int, List<LrcDec>> Lrcs = new Dictionary<int, List<LrcDec>>();
        //    Regex regLrcRows = new Regex(@"\[\d{1,}[^\r]+\r");//每行歌词
        //    Regex regLineTime = new Regex(@"\[[^\]]+\]");//每行时间
        //    Regex regEachTime = new Regex(@"<[^>]+>");  //每个字时间
        //    Regex regEachLrc = new Regex(@">[^<]+<");  //每个字
        //    string LrcText = FindKrc(FolderUrl,FileName,MusicName,Singer);
        //    MatchCollection matchs = regLrcRows.Matches(LrcText);
        //    string LrcLine = "";
        //    string MusicTitle = "";
        //    foreach (Match tmp in matchs)
        //    {
        //        string s = tmp.ToString();
        //        try
        //        {
        //            List<LrcDec> LrcDecs = new List<LrcDec>();
        //            string strLineTime = regLineTime.Match(s).ToString();
        //            if (strLineTime.Length > 1)
        //            {
        //                strLineTime = strLineTime.Substring(1, strLineTime.Length - 2);
        //                string[] startTimes = strLineTime.Split(',');
        //                MatchCollection EachTimeMatchs = regEachTime.Matches(s);
        //                MatchCollection EachTextMatchs = regEachLrc.Matches(s);
        //                for (int i = 0; i < EachTimeMatchs.Count; i++) {
        //                    string[] EachTimeCol = EachTimeMatchs[i].ToString().Substring(1, EachTimeMatchs[i].ToString().Length - 2).Split(',');
        //                    string EachText = i < EachTimeMatchs.Count - 1 ? EachTextMatchs[i].ToString().Substring(1, EachTextMatchs[i].ToString().Length - 2) : s.Substring(s.LastIndexOf(EachTimeMatchs[i].ToString()) + EachTimeMatchs[i].ToString().Length);
        //                    LrcLine += EachText;
        //                    LrcDec ld = new LrcDec()
        //                    {
        //                        LrcStartTime = Convert.ToInt32(EachTimeCol[0]),
        //                        LrcTime = Convert.ToInt32(EachTimeCol[1]),
        //                        SingleLrc = EachText,
        //                        CLrcTime = Convert.ToInt32(startTimes[1]),
        //                    };
        //                    LrcDecs.Add(ld);
        //                }
        //                if (LrcDecs.Count > 0) LrcDecs[0].Lrc = LrcLine.Replace("\r","");
        //                Lrcs.Add(Convert.ToInt32(startTimes[0]), LrcDecs);
        //                LrcLine = "";
        //            }
        //        }
        //        catch { continue; }
        //    }
        //    List<LrcDec> tempLD = new List<LrcDec>();
        //    if (Lrcs.Count > 0)
        //    {
        //        tempLD.Add(new LrcDec()
        //        {
        //            Lrc = MusicTitle,
        //            SingleLrc = MusicTitle
        //        });
        //        Lrcs.Add(9999999, tempLD);
        //    }
        //    return Lrcs;
        //}
        ///// <summary>
        ///// 从文件夹中查找歌词
        ///// </summary>
        ///// <param name="FolderUrl">文件夹路径</param>
        ///// <param name="MusicName">歌曲名称</param>
        ///// <param name="Singer">歌手</param>
        ///// <returns>歌词</returns>
        //public string FindKrc(string FolderUrl,string FileName,string MusicName,string Singer) {
        //    Regex regLrcTi = new Regex(@"\[ti:[^\r]+\r");//标题
        //    Regex regLrcAr = new Regex(@"\[ar:[^\r]+\r");//艺术家
        //    string findText = "";
        //    try
        //    {
        //        string[] MusicNames = FileName.Split('-');

        //        DirectoryInfo di = new DirectoryInfo(FolderUrl);
        //        if (MusicNames.Length > 1)
        //        {
        //            if (di.GetFiles("*"+MusicNames[0] + "*-*" + MusicNames[1] + "*").Length > 0)
        //                FileName = MusicNames[0] + "*-*" + MusicNames[1];
        //            if (di.GetFiles("*"+MusicNames[1] + "*-*" + MusicNames[0] + "*").Length > 0)
        //                FileName = MusicNames[1] + "*-*" + MusicNames[0];
        //        }
        //        foreach (FileInfo fi in di.GetFiles("*" + FileName + "*"))
        //        {
        //            string _lrc = KrcDecode.Decode(fi.FullName);
        //            if(MusicNames.Length>1){
        //                findText=_lrc;
        //                break;
        //            }

        //            string _title = regLrcTi.Match(_lrc).ToString().Trim();
        //            if (regLrcTi.Match(_lrc).ToString().Trim().Split(':').Length > 1)
        //                _title = regLrcTi.Match(_lrc).ToString().Trim().Split(':')[1].Replace("]", "");
        //            string _ar = regLrcAr.Match(_lrc).ToString().Trim();
        //            if (regLrcAr.Match(_lrc).ToString().Trim().Split(':').Length > 1)
        //                _ar = regLrcAr.Match(_lrc).ToString().Trim().Split(':')[1].Replace("]", "");

        //            MusicName = MusicName.ToUpper(); Singer = Singer.ToUpper();
        //            _title = _title.ToUpper(); _ar = _ar.ToUpper();
        //            if (MusicName == _title & Singer == _ar)
        //            {
        //                findText = _lrc;
        //                break;
        //            }
        //            if (MusicName == _title & Singer != _ar)
        //                findText = _lrc;
        //            if (MusicName.IndexOf(_title) != -1 & Singer == "")
        //                findText = _lrc;
        //            if (MusicName.IndexOf(_title) != -1 & Singer == _ar)
        //                findText = _lrc;
        //        }
        //        if (findText.Trim() == "")
        //        {
        //            if(MusicName.Trim()=="") MusicName = MusicNames[0].Trim();
        //            if (Singer.Trim() == "") Singer = MusicNames[1].Trim();
        //            int MatchLevel = 10; //匹配等级，越大越不匹配
        //            foreach (FileInfo fi in di.GetFiles("*.krc"))
        //            {
        //                string _lrc = KrcDecode.Decode(fi.FullName);
        //                string _title = regLrcTi.Match(_lrc).ToString().Trim();
        //                if (regLrcTi.Match(_lrc).ToString().Trim().Split(':').Length > 1)
        //                    _title = regLrcTi.Match(_lrc).ToString().Trim().Split(':')[1].Replace("]", "");
        //                string _ar = regLrcAr.Match(_lrc).ToString().Trim();
        //                if (regLrcAr.Match(_lrc).ToString().Trim().Split(':').Length > 1)
        //                    _ar = regLrcAr.Match(_lrc).ToString().Trim().Split(':')[1].Replace("]", "");
        //                MusicName = MusicName.ToUpper(); Singer = Singer.ToUpper();
        //                _title = _title.ToUpper(); _ar = _ar.ToUpper();
        //                if (MusicName == _title & Singer == _ar)    //歌名歌手都相等
        //                {
        //                    findText = _lrc;
        //                    break;
        //                }
        //                if (Singer == _title & MusicName == _ar)
        //                {
        //                    findText = _lrc;
        //                    break;
        //                }
        //                if (MusicName == _title & Singer != _ar & MatchLevel > 3)
        //                {
        //                    findText = _lrc;
        //                    MatchLevel = 3;
        //                }
        //                if (Singer == _title & MusicName != _ar & MatchLevel > 3)
        //                {
        //                    findText = _lrc;
        //                    MatchLevel = 3;
        //                }
        //                if (MusicName.IndexOf(_title) != -1 & Singer == "" & MatchLevel > 2)
        //                {
        //                    findText = _lrc;
        //                    MatchLevel = 2;
        //                }
        //                if (Singer.IndexOf(_title) != -1 & MusicName == "" & MatchLevel > 2)
        //                {
        //                    findText = _lrc;
        //                    MatchLevel = 2;
        //                }
        //                if (MusicName.IndexOf(_title) != -1 & Singer == _ar & MatchLevel > 1)
        //                {
        //                    findText = _lrc;
        //                    MatchLevel = 1;
        //                }
        //                if (Singer.IndexOf(_title) != -1 & MusicName == _ar & MatchLevel > 1)
        //                {
        //                    findText = _lrc;
        //                    MatchLevel = 1;
        //                }
        //            }
        //        }
        //    }
        //    catch { return ""; }
        //    return findText;
        //} 
        #endregion
    }
}
