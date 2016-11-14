using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.ServiceModel;

namespace WCFService
{
    [Serializable]
    [DataContract(IsReference=true)]
   public class MyStream:FileStream
    {
        [DataMember]
        public string FileName
        {
            get;
            set;
        }
        [DataMember]
        public FileMode filemode
        {
            get;
            set;
        }
        [DataMember]
        public FileAccess fileaccess
        {
            get;
            set;
        }
    }
}
