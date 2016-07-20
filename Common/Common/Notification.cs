using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    /// <summary>
    /// 委托，参数是一个字典
    /// </summary>
    /// <param name="dic">字典，按照key,value来对应，可以放任何对象</param>
    /// <returns></returns>
   public delegate int delegate_NF(ExDictionary dic);
    /// <summary>
    /// 观察者模式类
    /// </summary>
   public class Notification
    {
       private List<NotificationEntry> _notificationEntrys = new List<NotificationEntry>();
       private static Notification _instance = null;
       private Notification()
       { 
       }
       /// <summary>
       /// 懒汉式单例模式：获取唯一单例
       /// </summary>
       /// <returns></returns>
       public static Notification GetInstance()
       {
           if (_instance == null)
               _instance = new Notification();
           return _instance;
       }
       /// <summary>
       /// 调用方法
       /// </summary>
       /// <param name="name">与方法相关联的字符串</param>
       /// <param name="dic">方法的参数</param>
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
       /// <summary>
       /// 注册方法
       /// </summary>
       /// <param name="name">与方法相关联的字符串</param>
       /// <param name="nf">委托：方法的指针</param>
       public void AddObserver(string name,delegate_NF nf)
       {
           NotificationEntry notificationEntry = new NotificationEntry(name, nf);
           _notificationEntrys.Add(notificationEntry);
       }
    }
    public class ExDictionary:Dictionary<string,object>
    {
    }
    /// <summary>
    /// 字符串与委托关联的类
    /// </summary>
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
