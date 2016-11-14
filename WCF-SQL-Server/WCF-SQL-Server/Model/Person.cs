using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace WCF_SQL_Server
{
    [DataContract]
    public class Person
    {
        private int _id;
        [DataMember]
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _name;
        [DataMember]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _age;
        [DataMember]
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }
    }
}