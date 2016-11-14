using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GDJL.MTST.DAL;
using GDJL.MTST.Singleton;

namespace GDJL.MTST.BLL
{
    public class UserBLL
    {
        private SQLHelper sqlHelper = ClientHelper.GetInstance().sqlHelper;
        public bool CheckUser(string userName, string passWord,out string msg)
        {
            msg = "";
            try
            {
                string sql = string.Format("select * from [dbo].[User] where UserName='{0}'", userName);
                IList<GDJL.MTST.Model.User> lstUser = sqlHelper.CreateSqlQuery<GDJL.MTST.Model.User>(sql);
                if (lstUser == null || lstUser.Count == 0)
                {
                    msg = "用户名不存在";
                    return false;
                }
                if (lstUser[0].PassWord != passWord)
                {
                    msg = "密码错误";
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                msg = e.Message;
                return false;
            }
        }
    }
}
