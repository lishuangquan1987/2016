using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            MyService.SysUpDateServiceClient client = new MyService.SysUpDateServiceClient();
            WSHttpBinding bingding = client.Endpoint.Binding as WSHttpBinding;

                bingding.MaxReceivedMessageSize = Int32.MaxValue;
                bingding.MaxBufferPoolSize = Int32.MaxValue;
                bingding.OpenTimeout = new TimeSpan(0, 20, 0);
                bingding.SendTimeout = new TimeSpan(0, 20, 0);
                //必须加上，否则传输大文件有问题..
                bingding.ReaderQuotas.MaxDepth = int.MaxValue;
                bingding.ReaderQuotas.MaxStringContentLength = int.MaxValue;
                bingding.ReaderQuotas.MaxArrayLength = int.MaxValue;
                bingding.ReaderQuotas.MaxBytesPerRead = int.MaxValue;
                bingding.ReaderQuotas.MaxNameTableCharCount = int.MaxValue;

                //安全性
                bingding.UseDefaultWebProxy = false;
                bingding.Security.Message.ClientCredentialType = MessageCredentialType.None;
                bingding.Security.Mode = SecurityMode.None;

            string[] files = client.GetLatestFileNames();
            string msg;
            for (int i = 0; i < files.Length; i++)
            {
                MyService.SysFile s = new MyService.SysFile();
                s = client.GetLastestFile(files[i], out msg);
            }
        }
    }
}
