using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WordReport
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str1 = Application.StartupPath;
            str1 = str1.Substring(0, str1.LastIndexOf('\\'));
            RSAEncrypt rsa = new RSAEncrypt(str1 + @"\Keys");
            rsa.GenericKey();
            MessageBox.Show("加解密密码生成成功！", "生成成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RegGenerateFrm reggen = new RegGenerateFrm();
            reggen.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegisterFrm regfrm = new RegisterFrm();
            regfrm.ShowDialog();
        }
    }
}
