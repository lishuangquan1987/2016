using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nhibernate_数据库中插入图片
{
   public class Person
    {
       public virtual string Name
       {
           get;
           set;
       }
       public virtual int Age
       {
           get;
           set;
       }
       public virtual byte[] Image
       {
           get;
           set;
       }
    }
}
