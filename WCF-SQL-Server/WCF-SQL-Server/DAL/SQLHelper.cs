using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace WCF_SQL_Server
{
    public class SQLHelper
    {
        public string ConStr = "Data Source=I6LBDHWNNCC1JKL;Initial Catalog=People;Integrated Security=True";
        public int ExecuteNonQuery(string sql,out string msg)
        {
            msg="";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConStr))
                {
                    conn.Open();
                    using (SqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = sql;
                        return command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                msg = e.Message;
                return -1;
            }
        }
        public DataTable ExecuteQuery(string sql, out string msg)
        {
            msg = "";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConStr))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    using (SqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = sql;
                        dt.Load(command.ExecuteReader());
                        return dt;
                    }
                }
            }
            catch (Exception e)
            {
                msg = e.Message;
                return null;
            }
        }
    }
}