using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Xiongxiaokang
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string rowDataPath
        {
            get { return this.textBox_path.Text; }
            set { this.textBox_path.Text = value; }
        }
        Chip[] chips;
        private void button_scan_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "请选择rowData的excel文件";
            op.Multiselect = false;
            if (op.ShowDialog() != DialogResult.OK)
                return;
            rowDataPath = op.FileName;
            
            chips = ReadRowData(rowDataPath);
            ExDictionary dic = new ExDictionary();
            if (chips != null)
            {
                
                dic["msg"] = "载入并读取数据成功！Row Data:" + rowDataPath;
                dic["color"] = Color.Green;
                dic["nextline"] = true;
            }
            else
            {
                
                dic["msg"] = "载入数据失败，请检查Row Data:" + rowDataPath;
                dic["color"] = Color.Red;
                dic["nextline"] = true;
            }
            Notification.GetInstance().PostNotification("log", dic);
     
        }
        Chip[] ReadRowData(string path)
        {
            return ExcelOperation.ReadRowData(path);
        }

        private void button_chips_Click(object sender, EventArgs e)
        {
            if (chips == null)
            {
                Log("看个毛线，Row Data都没有载入！", Color.Red, true);
                return;
            }
            this.richTextBox_log.AppendText("--------------------------------------------\r\n");
            var count = from i in chips select i[1];//选取所有的chipID
            var count_distinct = count.Distinct().ToArray();//对chipID去重
            richTextBox_log.AppendText("共有"+count_distinct.Length.ToString()+"个chip:\r\n");
            for (int i = 0; i < count_distinct.Length; i++)
            {
                richTextBox_log.AppendText(count_distinct[i]+";\r\n");
            }
        }

        private void Btn_result_Click(object sender, EventArgs e)
        {
            if (rowDataPath == "" || rowDataPath == null)
            {
                Log("请先载入rowData再点分析！", Color.Red, true);
                return;
            }
            string new_path = Path.GetDirectoryName(rowDataPath) + "\\生成的数据.xls";
            //ExcelOperation.Analysize(new_path, chips);
            bool result = ExcelOperation.Analysize(new_path, chips);
            if (result)
            {
               
                //Log("分析完成,数据保存在"+new_path, Color.Green, true);
                ExDictionary dic = new ExDictionary();
                dic["msg"] = "分析完成,数据保存在" + new_path;
                dic["color"] = Color.Green;
                dic["nextline"] = true;
                Notification.GetInstance().PostNotification("log", dic);
                MessageBox.Show("分析完成!");
            }
            else
            {
                MessageBox.Show("分析失败", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Log("分析失败",Color.Red,true);
                ExDictionary dic = new ExDictionary();
                dic["msg"] = "分析失败！";
                dic["color"] = Color.Red;
                dic["nextline"] = true;
                Notification.GetInstance().PostNotification("log", dic);
            }
        }
        delegate void delegateLog(string msg,Color color,bool nextline);
        /// <summary>
        /// 为适应借口而写的
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public int Log(ExDictionary dic)
        {
            string msg = dic["msg"] as string;
            Color color = (Color)dic["color"];
            bool nextline = (bool)dic["nextline"];
            Log(msg, color, nextline);
            return 0;

        }
        public void Log(string msg, Color color, bool nextline)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new delegateLog(Log), new object[] { msg, color, nextline });
                return;
            }
            this.richTextBox_log.SelectionColor = color;
            string _msg = "";
            if (nextline)
                _msg = msg + "\r\n";
            else
                _msg = msg;
            string time = "["+DateTime.Now.ToString()+"]:";
            _msg = time + _msg;
            this.richTextBox_log.AppendText(_msg);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string msg = "1.先载入rowData\r\n2.点击分析并保存按钮即可";
            MessageBox.Show(msg, "tip", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Notification.GetInstance().AddObserver("log", Log);
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToString();
            this.toolStripStatusLabel1.Text = "当前时间:"+time;
        }

    }
}
