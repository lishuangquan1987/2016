using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using WCFService;
using System.Collections.ObjectModel;
using System.IO;

namespace WCF_双工_Server
{
    /// <summary>
    /// 客户端调用的方法在服务端的实现
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
   public class ChatToServer:IChatToServer
    {
        public ChatToServer(System.Windows.Threading.Dispatcher mainDispatcher)
        {
            this.mainDispatcher = mainDispatcher;
        }
        private System.Windows.Threading.Dispatcher mainDispatcher;//得到主线程调度,防止跨线程操作
        private static ObservableCollection<User> lstUser = new ObservableCollection<User>();
        public static ObservableCollection<User> LstUser
        {
            get { return ChatToServer.lstUser; }
            set { ChatToServer.lstUser = value; }
        }
        
        /// <summary>
        /// 定义委托
        /// </summary>
        public delegate void Dele_Login(string key,string userName);
        public delegate void Dele_ReceiveMsg(string key,string msg);
        public delegate void Dele_ReceiveImage(string key,MyImage image);
        public delegate void Dele_ClientClosed(object sender, EventArgs e);
        /// <summary>
        /// 定义事件，当客户端调用时,触发此事件来更新UI
        /// </summary>
        public event Dele_Login LoginEvent;
        public event Dele_ReceiveMsg ReceiveMsgEvent;
        public event Dele_ReceiveImage ReceiveImageEvent;
        public event Dele_ClientClosed ClientClosedEvent;

        
        public void SendMessageToServer(string msg)
        {
            string key = OperationContext.Current.SessionId;
            if (ReceiveMsgEvent != null)
                ReceiveMsgEvent(key,msg);
        }

        public void SendImageToServer(MyImage image)
        {
            string key = OperationContext.Current.SessionId;
            if (ReceiveImageEvent != null)
                ReceiveImageEvent(key, image);
        }

        /// <summary>
        /// 当有客户端连接时，会调用此方法注册
        /// </summary>
        /// <param name="userName"></param>
        public void Login(string userName)
        {
            IChatToClient client = OperationContext.Current.GetCallbackChannel<IChatToClient>();            
            string key = OperationContext.Current.SessionId;
            IContextChannel chanel = OperationContext.Current.Channel;
            chanel.Closed += (sender, e) => { if (ClientClosedEvent != null) ClientClosedEvent(sender, e); };
            //检查是否有离线用户
            var users = LstUser.Where(x => x.Chanel.State != CommunicationState.Opened);
            if (users != null && users.Count() > 0)
                mainDispatcher.Invoke(new Action(() => users.ToList().ForEach(x => LstUser.Remove(x))));
            //将用户加入进去
            User user = new User() { Client = client, Key = key, Chanel = chanel, UserName = userName };
            var existUser = LstUser.Where(x => x.Key == user.Key);
            if (existUser != null && existUser.Count() > 0)
                return;
            mainDispatcher.Invoke(new Action(()=> LstUser.Add(user)));
            if (this.LoginEvent != null)
            {
                this.LoginEvent(key, userName);
            }
        }


        public void AAA(MyStream stream)
        {
            
            byte[] bytes = new byte[512];
            int readCount=1;
            while (readCount > 0)
            {
                FileStream localStream = new FileStream("c:\\test.txt", FileMode.Append, FileAccess.ReadWrite);
                readCount = stream.Read(bytes, 0, bytes.Length);
                localStream.Write(bytes, 0, bytes.Length);
                localStream.Close();
            }
        }
    }
}
