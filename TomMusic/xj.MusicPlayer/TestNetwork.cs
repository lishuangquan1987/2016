using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xj.fm.xinli001.com
{
    /// <summary>
    /// 测试网络连接
    /// </summary>
    public class TestNetwork
    {
        /// <summary>
        /// 测试方法
        /// </summary>
        public static bool Test()
        {
            try
            {
                string strHtml = GetHtmlCode.GetSongUrl("http://www.baidu.com/img/baidu_jgylogo3.gif");
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
    }
}
