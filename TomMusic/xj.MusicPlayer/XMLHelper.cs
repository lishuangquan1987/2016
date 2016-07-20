using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace xj.MusicPlayer
{
    public class XMLHelper
    {
        /// <summary>
        /// 创建播放列表
        /// </summary>
        /// <param name="musicList"></param>
        public static void WritXML(List<Music> musicList)
        {
            string c = File.Exists("musiccount.dat") ? File.ReadAllText("musiccount.dat") : "0";
            int count = 0;
            if (!string.IsNullOrEmpty(c))
            {
                count = Convert.ToInt32(c);
            }
            string xmlFile = Path.GetFullPath("musicList.xml"); //获取XML文件的路径
            if (File.Exists(xmlFile))
            {
                XDocument xd = XDocument.Load(xmlFile);
                //如果当前的播放列表已经有内容了
                if (xd.Element("Music").Elements().Count() > 0)
                {
                    for (int i = 0; i < musicList.Count; i++)
                    {
                        XElement xelMusic = new XElement("music"); //加入一个music节点
                        XAttribute xa = new XAttribute("id", i + 1 + count); //加入一个属性编号
                        xelMusic.Add(xa);
                        xelMusic.Add(
                            new XElement("name", musicList[i].MusicName), //添加文件名
                            new XElement("url", musicList[i].MusciURL), //添加路径
                            new XElement("time", musicList[i].MusicTime), //添加时长
                            new XElement("bit",musicList[i].Bitrate)    //比特率
                            );
                        xd.Element("Music").Add(xelMusic);
                    }
                    //xd.Save("config/musicList.xml"); //保存
                    xd.Save("musicList.xml"); //保存
                    return;
                }
                else
                {
                    XDocument xd1 = new XDocument();
                    XElement xele = new XElement("Music"); //添加一个根节点
                    xd1.Add(xele);
                    //遍历播放集合
                    for (int i = 0; i < musicList.Count; i++)
                    {
                        XElement xelMusic = new XElement("music"); //加入一个music节点
                        XAttribute xa = new XAttribute("id", i + 1); //加入一个属性编号
                        xelMusic.Add(xa);
                        xelMusic.Add(
                            new XElement("name", musicList[i].MusicName), //添加文件名
                            new XElement("url", musicList[i].MusciURL), //添加路径
                            new XElement("time", musicList[i].MusicTime), //添加时长
                            new XElement("bit", musicList[i].Bitrate)    //比特率
                            );
                        xele.Add(xelMusic);
                    }
                    //xd1.Save("config/musicList.xml"); //保存
                    xd1.Save("musicList.xml");
                }
            }
            else
            {
                CreateXml(xmlFile);
            }
        }

        /// <summary>
        /// 读取播放列表
        /// </summary>
        /// <returns></returns>
        public static List<Music> ReadXML()
        {
            List<Music> list = new List<Music>();
            string xmlFile = Path.GetFullPath("musicList.xml");
            if (File.Exists(xmlFile))
            {

                XDocument doc = XDocument.Load(xmlFile);           //读取计算机内在中
                foreach (XElement element in doc.Element("Music").Elements())
                {
                    Music mu = new Music();
                    mu.MusciURL = (string)element.Element("url");   //读取路径
                    mu.MusicName = (string)element.Element("name") + "    "; //读取文件名
                    mu.MusicTime = (string)element.Element("time");    //读取时长
                    mu.Bitrate = (string) element.Element("bit");   //读取比特率
                    list.Add(mu);
                }
                return list;    //返回播放列表

            }
            else
            {
                CreateXml(xmlFile);
                return null;
            }
        }

        /// <summary>
        /// 创建XML文件
        /// </summary>
        private static void CreateXml(string xmlName)
        {
            string xmlFile = Path.GetFullPath(xmlName);
            if (File.Exists(xmlFile))
                return;
            XDocument doc = new XDocument(
             new XDeclaration("1.0", "utf-8", "yes"),//创建版本<?xml version="1.0" encoding="utf-8" standalone="yes" ?>
             new XComment("Created:" + DateTime.Now.ToString()),//创建注释节点
             new XElement("Music"));
            doc.Save(xmlFile);  //保存为DvdList.xml
        }
    }

}
