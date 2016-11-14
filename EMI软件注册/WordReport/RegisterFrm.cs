using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

using System.Management;
using System.Management.Instrumentation;

namespace WordReport
{
    public partial class RegisterFrm : Form
    {
        private string filePath = "";
        private string fileName = "License.xml";


        private string xmlStr = "";
        private XmlDocument xmlDoc = new XmlDocument();

        public RegisterFrm()
        {
            InitializeComponent();
        }

        private void RegisterFrm_Load(object sender, EventArgs e)
        {
          
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            DialogResult drt = folderBrowserDialog1.ShowDialog();
            if (drt == DialogResult.OK)
            {
                filePath = folderBrowserDialog1.SelectedPath.Trim();
                txtFilePath.Text = filePath;
            }

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtFilePath.Text != "")
            {
                xmlStr = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(GetHardWareInfo()));
                xmlDoc.LoadXml("<ApplyCode>" + xmlStr + "</ApplyCode>");

                xmlDoc.Save(Path.Combine(filePath,fileName));
                MessageBox.Show("注册码申请文件生成成功！","操作提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("请选择文件路径!","操作提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 获取硬件信息
        /// </summary>
        /// <returns></returns>
        private string GetHardWareInfo()
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

            //ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            //ManagementObjectCollection moc2 = mc.GetInstances();
            //foreach (ManagementObject mo in moc2)
            //{
            //    if ((bool)mo["IPEnabled"] == true)
            //    {
            //        //Response.Write("MAC address\t{0}" + mo["MacAddress"].ToString());
            //        string dd = mo.Properties["MacAddress"].Value.ToString();
            //        if (!sbRet.ToString().Contains(mo["MacAddress"].ToString()))
            //        {
            //            sbRet.Append("-" + mo["MacAddress"].ToString());//;MAC address\t{0}
            //        }
            //        mo.Dispose();
            //    }
            //}

            return sbRet.ToString();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            string aimFileName = "PublicKey.xml";
            string aimPath = Application.StartupPath + @"\DataBase\Lic";
            string licFileName = "";

            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "XML文件(*.xml)|";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.DereferenceLinks = false;

            DialogResult drt = openFileDialog1.ShowDialog();
            if (drt == DialogResult.OK)
            {
                licFileName = openFileDialog1.FileName;

                if (!Directory.Exists(aimPath))
                {
                    Directory.CreateDirectory(aimPath);
                }
                File.Copy(licFileName, Path.Combine(aimPath,aimFileName), true);
                txtRegFile.Text = Path.Combine(aimPath, aimFileName);
                MessageBox.Show("导入注册文件成功!","操作提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LuaFrm lua = new LuaFrm();

            lua.ShowDialog();
        }

    }
}
