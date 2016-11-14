using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace 文件夹复制
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.CopyFolder(@"C:\Users\Administrator\Desktop\sql", @"C:\Users\Administrator\Desktop", false);
            Console.WriteLine("完成");
            Console.Read();
        }
        void CopyFile(string sourcePath, string destiPath)
        {
            if (!File.Exists(sourcePath))
                return;
            FileStream fs_read = new FileStream(sourcePath, FileMode.Open, FileAccess.Read);
            FileStream fs_write = new FileStream(destiPath, FileMode.Append, FileAccess.Write);
            int readCount = 0;
            int lengthToCopy=102400;
            byte[] tempBytes=new byte[lengthToCopy];
            do
            {
                readCount = fs_read.Read(tempBytes, 0, tempBytes.Length);
                fs_write.Write(tempBytes, 0, readCount);
            }
            while (readCount > 0);
            fs_read.Close();
            fs_write.Close();
        }
        void CopyFolder(string sourceDir, string destiDir,bool overwrite)
        {
            if (!Directory.Exists(sourceDir))
                return;
            string sourceDirName = Path.GetFileNameWithoutExtension(sourceDir);
            //获得目标文件夹路劲
            string _destDir = Path.Combine(destiDir, sourceDirName);
            if (Directory.Exists(_destDir))
            {
                if (overwrite)
                {
                    DeleteFolder(_destDir);
                    Directory.CreateDirectory(_destDir);
                }
                else
                {
                    _destDir += "_copy";
                    Directory.CreateDirectory(_destDir);
                }
            }
            else
            {
                Directory.CreateDirectory(_destDir);
            }
            string[] files = Directory.GetFiles(sourceDir);
            string[] folders = Directory.GetDirectories(sourceDir);

            if (files != null || files.Length > 0)
                files.ToList().ForEach(x => CopyFile(x, Path.Combine(_destDir, Path.GetFileName(x))));
            //递归复制
            if (folders != null || folders.Length > 0)
                folders.ToList().ForEach(x => CopyFolder(x, _destDir,overwrite));
        }
        /// <summary>
        /// 递归删除文件夹
        /// </summary>
        /// <param name="sourceDir"></param>
        void DeleteFolder(string sourceDir)
        {
            if (!Directory.Exists(sourceDir))
                return;
            string[] files = Directory.GetFiles(sourceDir);
            string[] directorys = Directory.GetDirectories(sourceDir);
            if (files == null || files.Length == 0)
            {
                if (directorys == null || directorys.Length == 0)
                    Directory.Delete(sourceDir);
            }
            if(files!=null||files.Length>0)
                files.ToList().ForEach(x => File.Delete(x));
            if (directorys != null || directorys.Length > 0)
                directorys.ToList().ForEach(x => DeleteFolder(x));
        }
    }
}
