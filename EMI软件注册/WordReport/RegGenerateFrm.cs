using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Xml;

namespace WordReport
{
    public partial class RegGenerateFrm : Form
    {
        private string keysPath = "";
        private string publicKeyPath = "";

        private string fileName = "";
        private string filePath = "";

        private string publicKeyFileName = "PublicKey.xml";
        private string publicKey = "";

        private string xmlStr = "";
        private XmlDocument xmlApplyDoc = new XmlDocument();
        private XmlDocument xmlPublickeyDoc = new XmlDocument();

        private RSAEncrypt myRsa;

        public RegGenerateFrm()
        {
            InitializeComponent();
        }

        private void btnFileBrowser_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "注册文件查找";
            openFileDialog1.FileName = "PublicKey.xml";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.Filter = "XML文件(.xml)|";
            openFileDialog1.FilterIndex = 0;

            DialogResult drt = openFileDialog1.ShowDialog();
            if (drt == DialogResult.OK)
            {
                fileName = openFileDialog1.FileName.Trim();
                txtFileName.Text = fileName;
            }
        }

        private void RegGenerateFrm_Load(object sender, EventArgs e)
        {
            string str1 = Application.StartupPath;
            str1 = str1.Substring(0, str1.LastIndexOf('\\'));
            publicKeyPath = str1 + @"\Lics\";
            keysPath = str1 + @"\Keys";
            myRsa = new RSAEncrypt(keysPath);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtFileName.Text != "")
            {
                if (File.Exists(fileName))
                {
                    filePath = Path.GetDirectoryName(fileName);
                    xmlApplyDoc.Load(fileName);

                    if (xmlApplyDoc.GetElementsByTagName("ApplyCode").Count > 0)
                    {
                        XmlNode xNode = xmlApplyDoc.GetElementsByTagName("ApplyCode")[0];

                        xmlStr = xNode.InnerText.Trim();
                        string xmlStr64 = ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(xmlStr));
                        if (xmlStr64.Split('-').Length > 0)
                        {
                            publicKeyPath += xmlStr64.Split('-')[0].Trim();
                        }

                        myRsa.Initial();

                        XmlDocument xmlDOC = new XmlDocument();
                        publicKey = myRsa.PublicKey;
                        XmlElement xEle = xmlDOC.CreateElement("DesKeyValue");
                        XmlNode newNode = xmlDOC.CreateNode(XmlNodeType.Element, "RegCode", "");
                        string strRsa = myRsa.EncryptProcess(xmlStr);
                        int nLen = strRsa.Length;
                        Random rm = new Random();
                        int[] nRm = new int[nLen * 3];
                        for (int i = 0; i < nLen * 3; i++)
                        {
                            nRm[i] = rm.Next(62);
                            if (nRm[i] < 10)
                                nRm[i] += 48;
                            else if (nRm[i] < 36)
                                nRm[i] += 55;
                            else
                                nRm[i] += 61;
                        }
                        byte[] byteRm1 = new byte[nLen * 4];
                        for (int i = 0; i < nLen; i++)
                        {
                            byteRm1[4 * i] = (byte)nRm[3 * i];
                            byteRm1[4 * i + 1] = (byte)strRsa[i];
                            byteRm1[4 * i + 2] = (byte)nRm[3 * i + 1];
                            byteRm1[4 * i + 3] = (byte)nRm[3 * i + 2];
                        }
                        string strByte = System.Text.Encoding.Default.GetString(byteRm1);
                        newNode.InnerText = strByte;

                        xEle.AppendChild(newNode);


                        xmlDOC.AppendChild(xEle);

                        if (!Directory.Exists(publicKeyPath))
                        {
                            Directory.CreateDirectory(publicKeyPath);
                        }

                        if (File.Exists(publicKeyPath + "\\GRGTEMIRegKey.xml"))
                        {
                            DialogResult drt = MessageBox.Show("同一设备注册码已经生成，确认重新生成？", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (drt == DialogResult.No)
                            {
                                return;
                            }
                        }
                        xmlDOC.Save(publicKeyPath + "\\GRGTEMIRegKey.xml");


                        MessageBox.Show("生成激活码成功！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("无效的注册码申请文件！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    MessageBox.Show("指定文件路径无效！","操作提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
