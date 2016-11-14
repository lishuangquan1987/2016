using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WordReport
{
    class IniOperate
    {
        /// <summary>
        /// 从ini文件读取记录
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="def"></param>
        /// <param name="retVar"></param>
        /// <param name="size"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVar, int size, string filePath);
        public static string GetConfigString(string section, string key, int size, string filePath)
        {
            StringBuilder myStr = new StringBuilder(size);
            try
            {
                GetPrivateProfileString(section, key, "Error", myStr, size, filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return myStr.ToString();
        }
        /// <summary>
        /// 写入ini文件
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="val"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        public static int SetConfigString(string section, string key, string val, string filePath)
        {
            return (int)WritePrivateProfileString(section, key, val, filePath);
        }
    }
}
