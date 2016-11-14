using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Common
{
    public class CalculationHelper
    {
        #region~遍历文件夹及其子目录获取所有文件的方法
        /// <summary>
        /// 递归方法：根据遍历目录获取目录及其子目录返回所有文件的方法
        /// </summary>
        /// <param name="path">要遍历的目录</param>
        /// <returns>返回包含所有文件路径的List</returns>
        public static List<string> GetAllFileName(string path)
        {
            string[] directorys = Directory.GetFileSystemEntries(path);
            List<string> filename_list = new List<string>();
            foreach (string directoy in directorys)
            {
                if (IsDirectory(directoy))
                    filename_list.AddRange(GetAllFileName(directoy));
                else
                    filename_list.Add(directoy);
            }
            return filename_list;
        }
        static bool IsDirectory(string path)
        {
            if (Directory.Exists(path))
                return true;
            else
                return false;
        }
        #endregion
        #region~二分法查找
        /// <summary>
        /// 使用递归在数字数组实现二分法查找，注意：传入的数组要经过排序
        /// </summary>
        /// <param name="val">要找的数字</param>
        /// <param name="arry">要传入的数组</param>
        /// <returns>返回元素的索引，没有找到返回-1</returns>
        public int search(int val, int[] arry)
        {
            int left = 0;
            int right = arry.Length - 1;
            int val_index = -1;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (val < arry[mid])
                    right = mid - 1;
                else if (val > arry[mid])
                    left = mid + 1;
                else
                    return val_index = mid;
            }
            return val_index;
        }
        #endregion

        #region 复制文件夹
       
        void CopyFolder(string sourceDir, string destiDir, bool overwrite)
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
                folders.ToList().ForEach(x => CopyFolder(x, _destDir, overwrite));
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
            if (files != null || files.Length > 0)
                files.ToList().ForEach(x => File.Delete(x));
            if (directorys != null || directorys.Length > 0)
                directorys.ToList().ForEach(x => DeleteFolder(x));
        }
        void CopyFile(string sourcePath, string destiPath)
        {
            if (!File.Exists(sourcePath))
                return;
            FileStream fs_read = new FileStream(sourcePath, FileMode.Open, FileAccess.Read);
            FileStream fs_write = new FileStream(destiPath, FileMode.Append, FileAccess.Write);
            int readCount = 0;
            int lengthToCopy = 102400;
            byte[] tempBytes = new byte[lengthToCopy];
            do
            {
                readCount = fs_read.Read(tempBytes, 0, tempBytes.Length);
                fs_write.Write(tempBytes, 0, readCount);
            }
            while (readCount > 0);
            fs_read.Close();
            fs_write.Close();
        }
        #endregion
    }
}
