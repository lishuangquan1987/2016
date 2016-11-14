using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace 数据库操作
{
   public class BaseViewModel
    {
       public virtual string Name
       {
           get;
           set;
       }
       public virtual string IconPath
       {
           get;
           set;
       }
       public virtual BaseViewModel Parent
       {
           get;
           set;
       }
       public virtual ObservableCollection<BaseViewModel> Children
       {
           get;
           set;
       }
    }
}
