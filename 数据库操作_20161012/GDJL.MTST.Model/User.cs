using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDJL.MTST.Model
{
   public class User
    {
       /// <summary>
       /// 用户名，唯一
       /// </summary>
       public virtual string UserName
       {
           get;
           set;
       }
       public virtual string PassWord
       {
           get;
           set;
       }
    }
}
