using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xj.MusicPlayer.ctrl
{
    public partial class NavControl : UserControl
    {
        public NavControl()
        {
            InitializeComponent();
        }

        [Browsable(true)]
        [Description("页码")]
        private int pageindex;

        public int PageIndex
        {
            get { return this.pageindex; }
            set
            {
                if (value < 1)
                {
                    this.pageindex = 1;
                }
                else
                {
                    pageindex = value;
                }
            }
        }

        [Browsable(true)]
        [Description("总页数")]
        private int pagecount;

        public int PageCount
        {
            get { return this.pagecount; }
            set
            {
                if (value < 1)
                {
                    this.pagecount = 1;
                }
                else
                {
                    pagecount = value;
                }
            }
        }

        [Browsable(true)]
        [Description("页大小")]
        private int pagesize;

        public int PageSize
        {
            get { return this.pagesize; }
            set
            {
                if (value < 1)
                {
                    this.pagesize = 12;
                }
                else
                {
                    pagesize = value;
                }
            }
        }

        [Browsable(true)]
        [Description("搜索文本")]
        private string searchText;

        public string SearchText
        {
            get { return this.searchText; }
            set
            {
                searchText = value;
            }
        }

        private void NavControl_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(148, 187, 193);
            this.Dock = DockStyle.Bottom;
            this.pageindex = PageInfo.PageIndex;
            this.pagecount = PageInfo.PageCount;
            this.searchText = PageInfo.SearchText;
            this.pagesize = PageInfo.PageSize;
        }

        private void lbPrev_Click(object sender, EventArgs e)
        {
            if (pageindex <= 1)
            {
                pageindex = 1;
            }
            else
            {
                pageindex -= 1;
            }
            new SearchMusic().GetMusicByApi(searchText, pageindex, pagesize);
        }

        private void lbNext_Click(object sender, EventArgs e)
        {
            if (pageindex >= pagecount)
            {
                pageindex = pagecount;
            }
            else
            {
                pageindex += 1;
            }
            var musiclist = new SearchMusic().GetMusicByApi(searchText, pageindex, pagesize);
            if (musiclist != null && musiclist.data != null)
            {
                List<Music> searchMusicList=new List<Music>();
                searchMusicList.Clear(); //这里如果清空那么正在播放的音乐完成后会接不上下一曲
                foreach (var item in musiclist.data.info)
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
                this.Parent.Controls.Clear();
                new MainWindow().LoadData(searchMusicList);
                //this.Parent.Controls.Add(new NavControl());
                //new MainWindow().CreateSearchControl(sender, e);
            }
        }
    }
}
