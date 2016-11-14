using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace WCFService
{
  [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(IChatToClient))]
  public interface IChatToServer
    {
      [OperationContract(IsOneWay=true)]
      void SendMessageToServer(string msg);
      [OperationContract(IsOneWay = true)]
      void SendImageToServer(MyImage image);
      [OperationContract(IsOneWay = true)]
      void Login(string userName);

      [OperationContract(IsOneWay = true)]
      void AAA( MyStream stream);
    }
  public interface IChatToClient
  {
      [OperationContract(IsOneWay = true)]
      void SendMessageToClient(string msg);
      [OperationContract(IsOneWay = true)]
      void SendImageToClient(MyImage image);
  }
}
