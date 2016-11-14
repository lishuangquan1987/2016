using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Service1”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 Service1.svc 或 Service1.svc.cs，然后开始调试。
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
    [DataContract]
    public class People
    {
        private string _name;
        private int _age;
        [DataMember]
        public string Name
        {
            get { return this._name; }
            set { _name = value; }
        }
        [DataMember]
        public int Age
        {
            get { return this._age; }
            set { _age = value; }
 
        }
        [OperationContract]
        public string Eat()
        {
            return string.Format("姓名：{0}，年龄{1}在吃饭",Name,Age);
        }


    }
}
