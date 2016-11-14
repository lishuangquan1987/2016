using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;

namespace GDJL.MTST.DAL
{
    public class SQLHelper
    {
        private ISessionFactory factory;
        private ISession session;
        private ITransaction tran;
        string cfgPath = System.AppDomain.CurrentDomain.BaseDirectory + "hibernate.cfg.xml";
        Configuration config;
        public SQLHelper()
        {
            config = new Configuration().Configure(cfgPath);
        }
        #region 增
        /// <summary>
        /// 返回的是主键
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public object Add(object obj)
        {
            try
            {
                factory = config.BuildSessionFactory();
                session = factory.OpenSession();
                tran = session.BeginTransaction();

                object returnObj= session.Save(obj);

                tran.Commit();
                session.Close();
                factory.Close();
                return returnObj;
            }
            catch (Exception e)
            {
                tran.Rollback();
                string exPath = "exception.txt";
                System.IO.File.AppendAllText(exPath, e.Message);
                throw e;
            }
        }
        /// <summary>
        /// 返回添加的记录条数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lstObj"></param>
        /// <returns></returns>
        public object Add<T>(List<T> lstObj) where T : class
        {
            try
            {
                factory = config.BuildSessionFactory();
                session = factory.OpenSession();
                tran = session.BeginTransaction();
                int count = 0;
                foreach (T obj in lstObj)
                {
                    session.Save(obj);
                    count++;
                }

                tran.Commit();
                session.Close();
                factory.Close();
                return count;
            }
            catch (Exception e)
            {
                tran.Rollback();
                string exPath = "exception.txt";
                System.IO.File.AppendAllText(exPath, e.Message);
                throw e;
            }
        }
        #endregion

        #region 删
        public void Delete(object obj)
        {
            try
            {
                factory = config.BuildSessionFactory();
                session = factory.OpenSession();
                tran = session.BeginTransaction();

                session.Delete(obj);

                tran.Commit();
                session.Close();
                factory.Close();
            }
            catch (Exception e)
            {
                tran.Rollback();
                string exPath = "exception.txt";
                System.IO.File.AppendAllText(exPath, e.Message);
                throw e;
            }
        }
        #endregion

        #region 改
        public void Update(object obj)
        {
            try
            {
                factory = config.BuildSessionFactory();
                session = factory.OpenSession();
                tran = session.BeginTransaction();

                session.Update(obj);

                tran.Commit();
                session.Close();
                factory.Close();               
            }
            catch (Exception e)
            {
                tran.Rollback();
                string exPath = "exception.txt";
                System.IO.File.AppendAllText(exPath, e.Message);
                throw e;
            }
        }
        #endregion
     
        #region 查
        public IList<T> GetAll<T>() where T : class
        {
            try
            {
                factory= config.BuildSessionFactory();
                session = factory.OpenSession();
                

                var returnValue= session.CreateCriteria<T>().List<T>();

               
                session.Close();
                factory.Close();
                return returnValue;
            }
            catch (Exception e)
            {
                string exPath = "exception.txt";
                System.IO.File.AppendAllText(exPath, e.Message);
                throw e;
            }
            
        }
        public IList<T> CreateSqlQuery<T>(string sql) where T : class
        {
            try
            {
                factory = config.BuildSessionFactory();
                session = factory.OpenSession();               
                ISQLQuery isqlquery = session.CreateSQLQuery(sql).AddEntity(typeof(T));
                var returnValue = isqlquery.List<T>();
                session.Close();
                factory.Close();
                return returnValue;
            }
            catch (Exception e)
            {
                string exPath = "exception.txt";
                System.IO.File.AppendAllText(exPath, e.Message);
                throw e;
            }

        }
        public System.Collections.IList CreateSqlQuery(string sql) 
        {
            try
            {
                factory = config.BuildSessionFactory();
                session = factory.OpenSession();
                IQuery isqluery1 = session.CreateQuery(sql);
                System.Collections.IList returnValue = isqluery1.List();                
                session.Close();
                factory.Close();
                return returnValue;
            }
            catch (Exception e)
            {
                string exPath = "exception.txt";
                System.IO.File.AppendAllText(exPath, e.Message);
                throw e;
            }

        }
        #endregion
    }
}
