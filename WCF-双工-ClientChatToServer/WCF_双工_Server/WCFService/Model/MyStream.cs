using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;

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
        
        public MyStream (string path,FileMode filemode,FileAccess fileaccess):base(path,filemode,fileaccess)
	    {
            FileName = path;           
	    }
    }
}
