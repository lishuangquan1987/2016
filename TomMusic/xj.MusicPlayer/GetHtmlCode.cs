using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace xj.fm.xinli001.com
{
    public class GetHtmlCode
    {
        private static string StrHtmlCode { get; set; }
        private static string SongList { get; set; }

        /// <summary>
        /// 获取网页源码
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetHttpWebRequest(string url)
        {
            //try
            //{
                Uri uri = new Uri(url);
                HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(uri);
                myReq.UserAgent = "User-Agent	Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.1; WOW64; Trident/6.0)";
                myReq.Accept = "*/*";
                myReq.KeepAlive = true;
                myReq.Headers.Add("Accept-Language", "zh-cn,en-us;q=0.5");
                HttpWebResponse result = (HttpWebResponse)myReq.GetResponse();
                Stream receviceStream = result.GetResponseStream();
                StreamReader readerOfStream = new StreamReader(receviceStream, System.Text.Encoding.GetEncoding("utf-8"));
                string strHTML = readerOfStream.ReadToEnd();
                readerOfStream.Close();
                receviceStream.Close();
                result.Close();
                return strHTML;
            //}
            //catch (Exception)
            //{

            //}

        }

        /// <summary>
        /// 获取音乐链接和标题
        /// </summary>
        /// <returns></returns>
        public static string GetSongUrl(string url)
        {
            StrHtmlCode = GetHttpWebRequest(url);
            //StrHtmlCode = GetWebClient("http://m.xinli001.com/fm/2172");

            string regSong = "(var broadcast_url = \")(.+)(\", broadcastListUrl = \"/fm/items/\";)";    //正则匹配音乐链接
            Match mcSong = Regex.Match(StrHtmlCode, regSong);
            return mcSong.Groups[2].ToString();    //设置音乐链接 
        }

        /// <summary>
        /// 分页读取数据
        /// </summary>
        /// <param name="pageindex"></param>
        public static List<string> WriteInfo(int pageindex)
        {
            SongList = GetHttpWebRequest("http://m.xinli001.com/fm/items/?t=1399027296350&p=" + pageindex);
            string regList = "(<ul id=\"fmlistUl\" data-p=\"1\">)(.+)(</ul>)";
            string regTitle = @"(?<=<li>)[\s\S]*?(?=</li>)";
            MatchCollection mcList = Regex.Matches(SongList, regTitle);
            List<string> list = new List<string>();
            StringBuilder sb = new StringBuilder();
            foreach (var item in mcList)
            {
                //匹配下载链接
                string regUrl = @"/\w+/\d+/";
                string musicUrl = "http://m.xinli001.com" + Regex.Match(item.ToString(), regUrl).ToString();
                sb.Append(GetSongUrl(musicUrl)).Append("___");
                //匹配音乐时间
                sb.Append(GetSongTime(musicUrl)).Append("___");
                //匹配图片地址和标题
                string regPic = "(<img src=\")(.+)(!80\" width=\"70\" height=\"70\" alt=\")(.+)(\">)";
                Match m = Regex.Match(item.ToString(), regPic);
                sb.Append(m.Groups[2].ToString() + "___");

                sb.Append(m.Groups[4].ToString() + " - ");

                //匹配主播
                string regAnnouncer = "(<span>主播 )(.+)(</span>)";
                sb.Append(Regex.Match(item.ToString(), regAnnouncer).Groups[2].ToString());

                list.Add(sb.ToString());
                sb.Clear();
            }
            return list;
        }

        /// <summary>
        /// 获取歌曲时间
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private static string GetSongTime(string url)
        {
            StrHtmlCode = GetHttpWebRequest(url);
            string regSong = @"( duration = parseInt\(')(\d+)('\);)";    //正则匹配音乐链接
            Match mcSong = Regex.Match(StrHtmlCode, regSong);
            string time = mcSong.Groups[2].ToString();    //设置音乐链接 
            if (time.Length > 4)
            {
                time = time.Substring(0, 3);
            }
            return time;
        }
    }
}
