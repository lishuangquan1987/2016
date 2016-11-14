using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WordReport
{
    public partial class LuaFrm : Form
    {

        TestReport myReport = new TestReport();

        FileOperator fOp = new FileOperator();

        RSAEncrypt myRas = new RSAEncrypt();

        string LuaPath = @"E:\我的项目\1123#\1123# V0.0.0.5 入库\源程序\LuaScript";
        string AtsPath = @"E:\我的项目\1123#\1123# V0.0.0.5 入库\源程序\加密脚本";

        public LuaFrm()
        {
            InitializeComponent();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            myReport.CreateWordReport();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadScriptFiles();

            LoadAtsFiles();

            myRas.Initial();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string key = "";
            StringBuilder value = new StringBuilder();

            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    for (int z = 0; z < 10; z++)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            value.Append(string.Format("{0:D}{1:D}{2:D}{3:D}{4:S}", x, y, z, i, ","));
                        }
                    }


                    key = string.Format("SSD{0:D}{1:D}", x, y);

                    WriteToIni(key, value.ToString());
                    value.Remove(0, value.Length);
                }
            }

        }

        private void WriteToIni(string key, string value)
        {
            string sec = "组合数";
            string path = @"C:\Documents and Settings\admin\桌面\passWord.ini";
            IniOperate.SetConfigString(sec, key, value, path);
        }

        /// <summary>
        /// 加密后的文件保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            string fileName = cmbLuaFiles.Text.Trim();
            ReadLuaFile(fileName);

            if (txtEncrypt.Text.Trim() != "")
            {
                txtDecrypt.Text = DESEncrypt.Encrypt(txtEncrypt.Text.Trim());
                //txtDecrypt.Text = myRas.EncryptProcess("123456");
                //加密后的文件保存
                string path = Path.ChangeExtension(Path.Combine(AtsPath, fileName), ".ats");
                fOp.WriteFile(path, txtDecrypt.Text.Trim());
            }

            //txtDecrypt.Text = myRas.EncryptProcess("放纵的爱是害。。。123");

        }

        /// <summary>
        /// 解密文件并临时存储
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            string fileName = cmbAtsFiles.Text.Trim();
            string path = Path.Combine(AtsPath, fileName);
            txtDecrypt.Text = fOp.ReadFile(path);

            txtEncrypt.Text = DESEncrypt.Decrypt(txtDecrypt.Text.Trim());
            //txtEncrypt.Text = myRas.DecryptProcess(txtDecrypt.Text.Trim());
            string path1 = Path.ChangeExtension(Path.Combine(LuaPath, fileName), ".Lua");
            fOp.WriteFile(path1, txtEncrypt.Text.Trim());

            if (File.Exists(path1))
            {
                MessageBox.Show("");
                //File.Delete(path1);
            }
            //txtEncrypt.Text = myRas.DecryptProcess(txtDecrypt.Text.Trim());
        }

        private void txtInfo_TextChanged(object sender, EventArgs e)
        {

        }


        private void ReadLuaFile(string fileName)
        {
            string path0 = Path.Combine(LuaPath, fileName);
            string read = fOp.ReadFile(path0);
            txtEncrypt.Text = read;
        }

        /// <summary>
        /// 加载测试参数
        /// </summary>
        private void LoadScriptFiles()
        {
            cmbLuaFiles.DropDownStyle = ComboBoxStyle.DropDownList;

            try
            {
                string[] fileNames = Directory.GetFiles(LuaPath);
                string name1 = "";
                foreach (string name in fileNames)
                {
                    if (Path.GetExtension(name) == ".lua")
                    {
                        name1 = Path.GetFileName(name);
                        if (!name1.Contains("Base") && !name1.Contains("DllBase") && !name1.Contains("Tune"))
                        {
                            cmbLuaFiles.Items.Add(name1);
                        }
                    }

                }
            }
            catch (Exception err)
            {
                MessageBox.Show("系统错误:" + err.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        /// <summary>
        /// 加载加密后的测试脚本文件
        /// </summary>
        private void LoadAtsFiles()
        {
            cmbAtsFiles.DropDownStyle = ComboBoxStyle.DropDownList;

            try
            {
                string[] fileNames = Directory.GetFiles(AtsPath);
                string name1 = "";
                foreach (string name in fileNames)
                {
                    if (Path.GetExtension(name) == ".ats")
                    {
                        name1 = Path.GetFileName(name);
                        cmbAtsFiles.Items.Add(name1);
                       
                    }

                }
            }
            catch (Exception err)
            {
                MessageBox.Show("系统错误:" + err.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }


    }
}
