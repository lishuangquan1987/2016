using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GDJL.MTST.DAL;

namespace GDJL.MTST.Singleton
{
    /// <summary>
    /// 单例模式，确保只有一个实例,避免每一次去new
    /// </summary>
    public class ClientHelper
    {
        private static ClientHelper instance;
        private ClientHelper()
        { }
        public static ClientHelper GetInstance()
        {
            if (instance == null)
                instance = new ClientHelper();
            return instance;
        }

        public SQLHelper sqlHelper = new SQLHelper();
        public ExcelHelper excelHelper = new ExcelHelper();
    }
}
