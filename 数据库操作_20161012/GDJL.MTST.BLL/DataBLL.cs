using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GDJL.MTST.DAL;
using GDJL.MTST.Singleton;
using GDJL.MTST.Model;

namespace GDJL.MTST.BLL
{
   public class DataBLL
   {
       private SQLHelper sqlHelper = ClientHelper.GetInstance().sqlHelper;
       private ExcelHelper excelHelper = ClientHelper.GetInstance().excelHelper;
       #region excel数据导入
       public bool ImPort_Capacitor(string path, out string msg)
       {
           msg = "";
           try
           {
               List<Capacitor> lstCapacitor = excelHelper.GetDatasFromAccess_Capacitor(path);
               if (lstCapacitor == null || lstCapacitor.Count == 0)
               {
                   msg = "读取的数据为空";
                   return false;
               }
               return Add<Capacitor>(lstCapacitor, out msg);
           }
           catch (Exception e)
           {
               msg = e.Message;
               return false;
           }
       }
       public bool ImPort_IC(string path, out string msg)
       {
           msg = "";
           try
           {
               List<IC> lstCapacitor = excelHelper.GetDatasFromAccess_IC(path);
               if (lstCapacitor == null || lstCapacitor.Count == 0)
               {
                   msg = "读取的数据为空";
                   return false;
               }
               return Add<IC>(lstCapacitor, out msg);
           }
           catch (Exception e)
           {
               msg = e.Message;
               return false;
           }
       }
       public bool ImPort_Inductor(string path, out string msg)
       {
           msg = "";
           try
           {
               List<Inductor> lstCapacitor = excelHelper.GetDatasFromAccess_Inductor(path);
               if (lstCapacitor == null || lstCapacitor.Count == 0)
               {
                   msg = "读取的数据为空";
                   return false;
               }
               return Add<Inductor>(lstCapacitor, out msg);
           }
           catch (Exception e)
           {
               msg = e.Message;
               return false;
           }
       }
       public bool ImPort_Misc(string path, out string msg)
       {
           msg = "";
           try
           {
               List<Misc> lstCapacitor = excelHelper.GetDatasFromAccess_Misc(path);
               if (lstCapacitor == null || lstCapacitor.Count == 0)
               {
                   msg = "读取的数据为空";
                   return false;
               }
               return Add<Misc>(lstCapacitor, out msg);
           }
           catch (Exception e)
           {
               msg = e.Message;
               return false;
           }
       }
       public bool ImPort_Module(string path, out string msg)
       {
           msg = "";
           try
           {
               List<Module> lstCapacitor = excelHelper.GetDatasFromAccess_Module(path);
               if (lstCapacitor == null || lstCapacitor.Count == 0)
               {
                   msg = "读取的数据为空";
                   return false;
               }
               return Add<Module>(lstCapacitor, out msg);
           }
           catch (Exception e)
           {
               msg = e.Message;
               return false;
           }
       }
       public bool ImPort_Oscillator(string path, out string msg)
       {
           msg = "";
           try
           {
               List<Oscillator> lstCapacitor = excelHelper.GetDatasFromAccess_Oscillator(path);
               if (lstCapacitor == null || lstCapacitor.Count == 0)
               {
                   msg = "读取的数据为空";
                   return false;
               }
               return Add<Oscillator>(lstCapacitor, out msg);
           }
           catch (Exception e)
           {
               msg = e.Message;
               return false;
           }
       }
       public bool ImPort_Resistor(string path, out string msg)
       {
           msg = "";
           try
           {
               List<Resistor> lstCapacitor = excelHelper.GetDatasFromAccess_Resistor(path);
               if (lstCapacitor == null || lstCapacitor.Count == 0)
               {
                   msg = "读取的数据为空";
                   return false;
               }
               return Add<Resistor>(lstCapacitor, out msg);
           }
           catch (Exception e)
           {
               msg = e.Message;
               return false;
           }
       }
       public bool ImPort_Sensors(string path, out string msg)
       {
           msg = "";
           try
           {
               List<Sensors> lstCapacitor = excelHelper.GetDatasFromAccess_Sensors(path);
               if (lstCapacitor == null || lstCapacitor.Count == 0)
               {
                   msg = "读取的数据为空";
                   return false;
               }
               return Add<Sensors>(lstCapacitor, out msg);
           }
           catch (Exception e)
           {
               msg = e.Message;
               return false;
           }
       }
       #endregion
       #region 数据库增删改查
       public bool Add(object obj, out string msg)
       {
           msg = "";
           if (obj == null)
           {
               msg = "对象为空";
               return false;
           }
           try
           {
               sqlHelper.Add(obj);
               return true;
           }
           catch (Exception e)
           {
               msg = e.Message;
               return false;
           }
       }
       public bool Add<T>(List<T> lstObj, out string msg) where T : class
       {
           msg = "";
           if (lstObj == null || lstObj.Count == 0)
           {
               msg = "对象不能为空";
               return false;
           }
           try
           {
               string count = sqlHelper.Add(lstObj).ToString();
               msg = string.Format("成功导入{0}条记录", count);
               return true;
           }
           catch (Exception e)
           {
               msg = e.Message;
               return false;
           }

       }
       public bool Delete(object obj, out string msg)
       {
           msg = "";
           if (obj == null)
           {
               msg = "对象为空";
               return false;
           }
           try
           {
               sqlHelper.Delete(obj);
               return true;
           }
           catch (Exception e)
           {
               msg = e.Message;
               return false;
           }
       }
       public bool Update(object obj, out string msg)
       {
           msg = "";
           if (obj == null)
           {
               msg = "对象为空";
               return false; 
           }
           try
           {
               sqlHelper.Update(obj);
               return true;
           }
           catch (Exception e)
           {
               msg = e.Message;
               return false;
           }
       }
       public IList<T> GetAll<T>(out string msg) where T : class
       {
           msg = "";
           try
           {
               IList<T> lstResult= sqlHelper.GetAll<T>();
               msg = string.Format("共查询到{0}条记录", lstResult.Count);
               return lstResult;
           }
           catch (Exception e)
           {
               msg = e.Message;
               return null;
           }
       }
       /// <summary>
       /// 实体类查询
       /// </summary>
       /// <typeparam name="T"></typeparam>
       /// <param name="sql"></param>
       /// <param name="msg"></param>
       /// <returns></returns>
       public IList<T> CreateSqlQuery<T>(string sql,out string msg) where T : class
       {
           msg = "";
           try
           {
               IList<T> lstResult= sqlHelper.CreateSqlQuery<T>(sql);
               msg = string.Format("共查询到{0}条记录", lstResult.Count);
               return lstResult;
           }
           catch (Exception e)
           {
               msg=e.Message;
               return null;
           }
       }
       /// <summary>
       /// 个别项查询
       /// </summary>
       /// <param name="sql"></param>
       /// <param name="msg"></param>
       /// <returns></returns>
       public System.Collections.IList CreateSqlQuery(string sql, out string msg) 
       {
           msg = "";
           try
           {
               System.Collections.IList lstResult = sqlHelper.CreateSqlQuery(sql);
               msg = string.Format("共查询到{0}条记录", lstResult.Count);
               return lstResult;
           }
           catch (Exception e)
           {
               msg = e.Message;
               return null;
           }
       }
       #endregion
   }
}
