using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace WordReport
{
    public class FileOperator
    {
        public FileOperator()
        { 

        }

        ~FileOperator()
        { 

        }

        public FileOperator(string fileName)
        {
            this.fileName = fileName;
        }

        private string fileName = "";

        /// <summary>
        /// 读取文件数据
        /// </summary>
        /// <param name="filePath"></param>
        public string ReadFileData(string filePath)
        {
            string strRet = "";
            if (File.Exists(filePath))
            {
                FileInfo fi = new FileInfo(filePath);
                FileStream fs = fi.Open(FileMode.Open, FileAccess.Read);
                byte[] buff = new byte[fs.Length];
                fs.Read(buff, 0, buff.Length);

                strRet = ASCIIEncoding.ASCII.GetString(buff);
                
                fs.Flush();
                fs.Close();
            }

            return strRet;
 
        }

        /// <summary>
        /// 读取文件数据
        /// </summary>
        /// <param name="filePath"></param>
        public string ReadFile(string filePath)
        {
            string strRet = "";
            if (File.Exists(filePath))
            {
                StreamReader streamOpen = new StreamReader(filePath, Encoding.GetEncoding("gb2312"));
                strRet = streamOpen.ReadToEnd();

                streamOpen.Close();
            }

            return strRet;

        }

        /// <summary>
        /// 向指定文件写入数据
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="strWrite"></param>
        public void WriteToFile(string filePath,string strWrite)
        {
            FileInfo fi = new FileInfo(filePath);
            FileStream fs = fi.Open(FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
            byte[] buff = ASCIIEncoding.ASCII.GetBytes(strWrite);
            
            fs.Write(buff, 0, buff.Length);

            fs.Flush();
            fs.Close();
        }

        /// <summary>
        /// 向指定文件写入数据
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="strWrite"></param>
        public void WriteFile(string filePath, string strWrite)
        {
            StreamWriter streamWrite = new StreamWriter(filePath, false, Encoding.GetEncoding("gb2312"));

            streamWrite.Write(strWrite);
            streamWrite.Close();
        }

        /// <summary>
        /// 文件加密
        /// </summary>
        /// <param name="fileName"></param>
        public void FileEncrypt(string fileName)
        {
            File.Encrypt(fileName);
            
        }

        /// <summary>
        /// 文件解密
        /// </summary>
        /// <param name="fileName"></param>
        public void Decrypt(string fileName)
        {
            File.Decrypt(fileName);

        }

    }
}
