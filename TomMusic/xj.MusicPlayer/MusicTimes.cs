using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shell32;

namespace xj.MusicPlayer
{
    public class MusicTimes
    {
        /// <summary>
        /// 获取指定的音乐的时间
        /// </summary>
        /// <param name="fileUrl"></param>
        /// <returns></returns>
        public static string GetMusicTime(string fileUrl)
        {
            ShellClass sh = new ShellClass();
            Folder dir = sh.NameSpace(Path.GetDirectoryName(fileUrl));
            FolderItem item = dir.ParseName(Path.GetFileName(fileUrl));
            string str = dir.GetDetailsOf(item, 27);
            return str;
        }

        /// <summary>
        /// 获取比特率
        /// </summary>
        /// <param name="fileUrl"></param>
        /// <returns></returns>
        public static string GetMusicBit(string fileUrl)
        {
            ShellClass sh = new ShellClass();
            Folder dir = sh.NameSpace(Path.GetDirectoryName(fileUrl));
            FolderItem item = dir.ParseName(Path.GetFileName(fileUrl));
            string str = dir.GetDetailsOf(item, 28);
            if (string.IsNullOrEmpty(str))
                str = "0kbps";
            return str;
        }

        /// <summary>
        /// 时间转换，将秒转换为对应的   mm：ss
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string ConvertTime(int time)
        {
            string musicTime = "00:00";
            if (time > 0)
            {
                int minute = time / 60;
                int seconds = time % 60;
                musicTime = (minute < 10 ? "0" + minute.ToString() : minute.ToString()) + ":" + (seconds < 10 ? "0" + seconds.ToString() : seconds.ToString());
            }
            return musicTime;
        }
    }
}


/*
 * ID  => DETAIL-NAME
0   => Name
1   => Size     // MP3 文件大小
2   => Type
3   => Date modified
4   => Date created
5   => Date accessed
6   => Attributes
7   => Offline status
8   => Offline availability
9   => Perceived type
10  => Owner
11  => Kinds
12  => Date taken
13  => Artists   // MP3 歌手
14  => Album     // MP3 专辑
15  => Year
16  => Genre
17  => Conductors
18  => Tags
19  => Rating
20  => Authors    
21  => Title     // MP3 歌曲名
22  => Subject
23  => Categories
24  => Comments
25  => Copyright
26  => #
27  => Length    // MP3 时长
28  => Bit rate  //比特率
29  => Protected
30  => Camera model
31  => Dimensions
32  => Camera maker
33  => Company
34  => File description
35  => Program name
36  => Duration
37  => Is online
38  => Is recurring
39  => Location
40  => Optional attendee addresses
41  => Optional attendees
42  => Organizer address
43  => Organizer name
44  => Reminder time
45  => Required attendee addresses
46  => Required attendees
47  => Resources
48  => Free/busy status
49  => Total size
50  => Account name
51  => Computer
52  => Anniversary
53  => Assistant's name
54  => Assistant's phone
55  => Birthday
56  => Business address
57  => Business city
58  => Business country/region
59  => Business P.O. box
60  => Business postal code
61  => Business state or province
62  => Business street
63  => Business fax
64  => Business home page
65  => Business phone
66  => Callback number
67  => Car phone
68  => Children
69  => Company main phone
70  => Department
71  => E-mail Address
72  => E-mail2
73  => E-mail3
74  => E-mail list
75  => E-mail display name
76  => File as
77  => First name
78  => Full name
79  => Gender
80  => Given name
81  => Hobbies
82  => Home address
83  => Home city
84  => Home country/region
85  => Home P.O. box
86  => Home postal code
*/