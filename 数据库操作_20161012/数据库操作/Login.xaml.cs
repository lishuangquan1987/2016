using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GDJL.MTST.Singleton;

namespace 数据库操作
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }
        GDJL.MTST.BLL.UserBLL userBll = new GDJL.MTST.BLL.UserBLL();
        
        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            string userName = this.tb_UserName.Text;
            IntPtr p=System.Runtime.InteropServices.Marshal.SecureStringToBSTR(this.tb_PassWord.SecurePassword);
            string passWord = System.Runtime.InteropServices.Marshal.PtrToStringBSTR(p);
            string msg;
            bool result = userBll.CheckUser(userName, passWord, out msg);
            if (result)
            {
                this.DialogResult = true;
            }
            else
            {
                MessageBox.Show(msg);
                this.DialogResult = false;
            }
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
