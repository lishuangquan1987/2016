using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Collections.ObjectModel;
using FTPModel;

namespace FTPClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string path = @"E:\Project2016\Common";
            LstFolder= GetFolderModel(path);
            this.DataContext = this;

        }
        private ObservableCollection<FolderModel> lstFolder = new ObservableCollection<FolderModel>();
        public ObservableCollection<FolderModel> LstFolder
        {
            get { return this.lstFolder; }
            set { this.lstFolder = value; }
        }
        private ObservableCollection<FolderModel> GetFolderModel(string path)
        {
            FolderModel parentFolder = new FolderModel()
            {
                LongName = path,
                ShortName = System.IO.Path.GetFileName(path),
                Children=new ObservableCollection<FolderModel>()
            };
            if (!Directory.Exists(path))
                return null;
            //获取文件
            string[] files = Directory.GetFiles(path);
            if (files.Length > 0)
            {
                for (int i = 0; i < files.Length; i++)
                {
                    FolderModel f = new FolderModel();
                    f.Children = null;
                    f.ShortName = System.IO.Path.GetFileName(files[i]);
                    f.LongName = files[i];
                    parentFolder.Children.Add(f);
                }
            }
            //获取文件夹
            string[] folders = Directory.GetDirectories(path);
            if (folders.Length > 0)
            {
                for (int i = 0; i < folders.Length; i++)
                {
                    FolderModel f = new FolderModel();
                    f.LongName = folders[i];
                    f.ShortName = System.IO.Path.GetFileName(folders[i]);
                    f.Parent=parentFolder;                                        
                    f.Children=new ObservableCollection<FolderModel>();
                    foreach (var x in GetFolderModel(folders[i])[0].Children)
                    {
                        f.Children.Add(x);
                    }
                    parentFolder.Children.Add(f);
                }
            }
            return new ObservableCollection<FolderModel>() { parentFolder};
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            FolderModel f = e.NewValue as FolderModel;
            MessageBox.Show(f.LongName);
        }
    }
}
