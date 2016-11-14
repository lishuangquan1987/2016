using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace 数据库操作
{
   public class TableTreeViewModel:INotifyPropertyChanged
    {
       public event PropertyChangedEventHandler PropertyChanged;
       private void OnPropertyChanged(string name)
       {
           if (PropertyChanged != null)
               this.PropertyChanged(this, new PropertyChangedEventArgs(name));
       }
       private ObservableCollection<MyTable> lstTable = new ObservableCollection<MyTable>();
       public ObservableCollection<MyTable> LstTable
       {
           get { return this.lstTable; }
           set { this.lstTable = value; OnPropertyChanged("LstTable"); }
       }
    }
   public class MyTable : BaseViewModel,INotifyPropertyChanged
   {
       private string name;
       private string iconPath;
       private ObservableCollection<BaseViewModel> children = new ObservableCollection<BaseViewModel>();
       public override string Name
       {
           get
           {
               return this.name;
           }
           set
           {
               this.name = value;
               OnPropertyChanged("Name");
           }
       }
       public override string IconPath
       {
           get
           {
               return this.iconPath;
           }
           set
           {
               this.iconPath = value;
               OnPropertyChanged("IconPath");
           }
       }
       public override ObservableCollection<BaseViewModel> Children
       {
           get
           {
               return this.children;
           }
           set
           {
               this.children = value;
               OnPropertyChanged("Children");
           }
       }
       public event PropertyChangedEventHandler PropertyChanged;
       private void OnPropertyChanged(string name)
       {
           if (PropertyChanged != null)
               this.PropertyChanged(this, new PropertyChangedEventArgs(name));
       }
   }
}
