using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCF_SQL_Server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        OperationBLL bll = new OperationBLL();

        public int Add(Person p)
        {
            return bll.Add(p);
        }

        public int Delete(Person p)
        {
            return bll.Delete(p);
        }

        public int Update(Person p)
        {
            return bll.Update(p);
        }

        public List<Person> Query(string sql)
        {
            return bll.Query(sql);
        }
    }
}
