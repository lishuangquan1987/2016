using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DPBUIITE_ESDAgent
{
    public partial class FrmFind : Form
    {
        public string[] flodername;
        public string[] filename;

        public FrmFind()
        {
            InitializeComponent();
        }

        private void FrmFind_Load(object sender, EventArgs e)
        {
            flodername = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\LogFile"); //Directory.GetFileSystemEntries(Directory.GetCurrentDirectory() + "\\LogFile");
            string _str;
           
            for (int i = 0; i < flodername.Length; i++)
            {
                _str = flodername[i].Substring(flodername[i].LastIndexOf("\\") + 1);
                comboBox1.Items.Add(_str);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            string _path = flodername[comboBox1.SelectedIndex];
         
            string[] _strfile = File.ReadAllLines(_path,Encoding.Default);
            for (int _i = 0; _i < _strfile.Length; _i++)
            {
                _strfile[_i] = _strfile[_i].Replace(" ", "");
                richTextBox1.AppendText(_strfile[_i] + "\r\n");
            }
           
        }

    }
}