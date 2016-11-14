using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace WCF_SQL_Server
{
    public class OperationBLL:IService1
    {
        SQLHelper sqlhelper = new SQLHelper();
        public int Add(Person p)
        {
            string msg;
            string sqlcommand = string.Format("insert into Person values({0},'{1}',{2})", p.ID, p.Name, p.Age);
            return sqlhelper.ExecuteNonQuery(sqlcommand, out msg);
        }

        public int Delete(Person p)
        {
            string msg;
            string sqlcommand = string.Format("Delete from Person where ID={0}", p.ID);
            return sqlhelper.ExecuteNonQuery(sqlcommand, out msg);
        }

        public int Update(Person p)
        {
            string msg;
            string sqlcommand = string.Format("Update from Person set Name='{0}',Age={1} where ID={2}", p.Name,p.Age,p.ID);
            return sqlhelper.ExecuteNonQuery(sqlcommand, out msg);
        }

        public List<Person> Query(string sql)
        {
            List<Person> lstPerson = new List<Person>();
            string msg;
            DataTable reader = sqlhelper.ExecuteQuery(sql,out msg);
            if (reader == null)
                return null;
            for (int i = 0; i < reader.Rows.Count; i++)
            {
                Person p = new Person();
                p.ID = int.Parse(reader.Rows[i][0].ToString());
                p.Name = reader.Rows[i][1].ToString();
                p.Age = int.Parse(reader.Rows[i][2].ToString());
                lstPerson.Add(p);
            }              
            return lstPerson;
        }
    }
}