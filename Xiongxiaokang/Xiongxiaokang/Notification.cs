using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xiongxiaokang
{
   public delegate int delegate_NF(ExDictionary dic);
    /// <summary>
    /// 观察者模式
    /// </summary>
   public class Notification
    {
       private List<NotificationEntry> _notificationEntrys = new List<NotificationEntry>();
       private static Notification _instance = null;
       private Notification()
       { 
       }
       public static Notification GetInstance()
       {
           if (_instance == null)
               _instance = new Notification();
           return _instance;
       }
       public void PostNotification(string name, ExDictionary dic)
       {
           foreach (NotificationEntry i in _notificationEntrys)
           {
               if (i.name == name)
               {
                   if (i.nf != null)
                       i.nf(dic);
               }
           }
       }
       public void AddObserver(string name,delegate_NF nf)
       {
           NotificationEntry notificationEntry = new NotificationEntry(name, nf);
           _notificationEntrys.Add(notificationEntry);
       }
    }
    public class ExDictionary:Dictionary<string,object>
    {
    }
    public class NotificationEntry
    {
        public delegate_NF nf;
        public string name;
        public NotificationEntry()
        {
        }
        public NotificationEntry(string name,delegate_NF nf)
        {
            this.name=name;
            this.nf=nf;

        }

    }
}
