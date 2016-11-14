using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFService;

namespace WCF_双工_Client
{
   public class ChatToClient:IChatToClient
    {
       /// <summary>
       /// 定义委托
       /// </summary>
       /// <param name="msg"></param>
       public delegate void Dele_ReceiveMsg(string msg);
       public delegate void Dele_ReceiveImage(MyImage image);
        /// <summary>
        /// 定义事件
        /// </summary>
       public event Dele_ReceiveMsg ReceiveMsgEvent;
       public event Dele_ReceiveImage ReceiveImageEvent;
       #region~实现IChatToClient
       public void SendMessageToClient(string msg)
        {
            if (ReceiveMsgEvent != null)
                ReceiveMsgEvent(msg);
        }

        public void SendImageToClient(MyImage image)
        {
            if (ReceiveImageEvent != null)
                ReceiveImageEvent(image);
        }
       #endregion
    }
}
