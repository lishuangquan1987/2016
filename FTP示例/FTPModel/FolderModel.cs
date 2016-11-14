using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace FTPModel
{
    /// <summary>
    /// 文件
    /// </summary>
    public class Files:INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            if(PropertyChanged!=null)
                PropertyChanged(this,new PropertyChangedEventArgs(name));
        }
        /// <summary>
        /// 只包含名称，不包含路劲
        /// </summary>
        public string ShortName
        {
            get;set;
        }
        /// <summary>
        /// 路劲
        /// </summary>
        public string LongName
        {
            get;set;
        }
        public FolderModel Parent
        {
            get;
            set;
        }
    }
    /// <summary>
    /// 文件夹结构
    /// </summary>
    public class FolderModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        /// <summary>
        /// 只包含名称，不包含路劲
        /// </summary>
        public string ShortName
        {
            get;
            set;
        }
        /// <summary>
        /// 路劲
        /// </summary>
        public string LongName
        {
            get;
            set;
        }
        public FolderModel Parent
        {
            get;
            set;
        }
        public ObservableCollection<FolderModel> Children
        {
            get;
            set;
        }
    }
   
}
