using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Management;
using System.Management.Instrumentation;

namespace WordReport
{
    class GetHardwareInfo
    {
        public static string GetInfo()
        {
            StringBuilder sbRet = new StringBuilder();
            string cpuInfo = "";//cpu序列号  
            ManagementClass cimobject = new ManagementClass("Win32_Processor");
            ManagementObjectCollection moc = cimobject.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                cpuInfo = mo.Properties["ProcessorId"].Value.ToString();
                sbRet.Append(cpuInfo.ToString());//"cpu序列号：" + 
                //Response.Write("cpu序列号：" + cpuInfo.ToString());
            }

            //获取硬盘ID  
            String HDid;
            ManagementClass cimobject1 = new ManagementClass("Win32_DiskDrive");
            ManagementObjectCollection moc1 = cimobject1.GetInstances();
            foreach (ManagementObject mo in moc1)
            {
                HDid = (string)mo.Properties["Model"].Value;
                //Response.Write("硬盘序列号：" + HDid.ToString());
                sbRet.Append("-" + HDid.ToString());//;硬盘序列号：
            }


            //获取网卡硬件地址  

            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc2 = mc.GetInstances();
            foreach (ManagementObject mo in moc2)
            {
                if ((bool)mo["IPEnabled"] == true)
                {
                    //Response.Write("MAC address\t{0}" + mo["MacAddress"].ToString());
                    string dd = mo.Properties["MacAddress"].Value.ToString();
                    sbRet.Append("-" + mo["MacAddress"].ToString());//;MAC address\t{0}
                    mo.Dispose();
                }
            }

            return sbRet.ToString();
        }
    }
}
