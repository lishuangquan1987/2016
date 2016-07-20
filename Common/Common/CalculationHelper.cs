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
    }
}
