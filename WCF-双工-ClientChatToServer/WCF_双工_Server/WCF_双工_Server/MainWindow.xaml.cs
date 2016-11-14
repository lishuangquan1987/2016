using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WCFService;
using System.Threading;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Runtime.Serialization;
using System.Configuration;


namespace WCF_双工_Server
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();

            #region~Frame
            Loading loadingpage = new Loading();
            loadingpage.lb_Msg.Content = "正在打开服务，请稍后...";
            this.loadingFrame.Content = loadingpage;
            #endregion
            server = new ChatToServer(this.Dispatcher);
            server.ClientClosedEvent += ClientClosedEvent;
            server.ReceiveMsgEvent += ReceiveMsgFromClient;
            server.ReceiveImageEvent += ReceiveImageFromClient;
            server.LoginEvent += server_LoginEvent;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            string ipAdress = ConfigurationManager.AppSettings["ipAdress"];
            new Thread(() =>
            {
                host = new ServiceHost(server);
                WSDualHttpBinding bingding = new WSDualHttpBinding();
                bingding.MaxReceivedMessageSize = Int32.MaxValue;
                bingding.MaxBufferPoolSize = Int32.MaxValue;
                bingding.OpenTimeout = new TimeSpan(0, 20, 0);
                bingding.SendTimeout = new TimeSpan(0, 20, 0);

                
                //必须加上，否则传输大文件有问题...
                bingding.ReaderQuotas.MaxDepth = int.MaxValue;
                bingding.ReaderQuotas.MaxStringContentLength = int.MaxValue;
                bingding.ReaderQuotas.MaxArrayLength = int.MaxValue;
                bingding.ReaderQuotas.MaxBytesPerRead = int.MaxValue;
                bingding.ReaderQuotas.MaxNameTableCharCount = int.MaxValue;

                host.AddServiceEndpoint(typeof(IChatToServer), bingding, ipAdress);
                host.Opened += host_Opened;
                host.Closed += host_Closed;
                host.Open();
            }).Start();
            this.listBox.ItemsSource = ChatToServer.LstUser;
            this.listBox.DisplayMemberPath = "UserName";
            this.allRb.IsChecked = true;
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                btn_SendMsg_Click(this, e);
            base.OnKeyDown(e);
        }
        void server_LoginEvent(string key, string userName)
        {
            string msg=string.Format("{0}在{1}连接到了服务器...",userName,DateTime.Now);
            UpdateText(msg, Colors.Gray, true);
        }

        void ClientClosedEvent(object sender, EventArgs e)
        {
            IContextChannel chanel=sender as IContextChannel;
            string key = chanel.SessionId;
            var user = ChatToServer.LstUser.Where(x => x.Key == key).FirstOrDefault();
            string msg = string.Format("[{0}]:{1}下线了",DateTime.Now,user.UserName);
            
            this.Dispatcher.Invoke(new Action(()=>{ChatToServer.LstUser.Remove(user);}));
            new Thread(() => { UpdateText(msg, Colors.Red, true); }).Start();
        }
        ServiceHost host = null;
        ChatToServer server = null;
        delegate void deleUpdate(string msg, Color color, bool nextline);
        public void UpdateText(string msg, Color color, bool nextline)
        {
            this.Dispatcher.Invoke(new Action(() =>
            {
                SolidColorBrush _brushColor = new SolidColorBrush(color);

                string _msg = nextline ? msg + "\r\n" : msg;
                var r = new Run(_msg);
                Paragraph p = new Paragraph() { Foreground = _brushColor };
                p.Inlines.Add(r);
                this.richTextBox.Document.Blocks.Add(p);
                this.richTextBox.Focus();
                this.richTextBox.ScrollToEnd();
            }));
        }

        public void ReceiveMsgFromClient(string key,string msg)
        {
            var user = ChatToServer.LstUser.Where(x => x.Key == key).FirstOrDefault();
            string userName = user.UserName;
            msg = string.Format("{0} {1}:{2}", userName, DateTime.Now.ToString(), msg);
            new Thread(() => { UpdateText(msg, Colors.Blue, true); }).Start();
        }

        public void ReceiveImageFromClient(string key,MyImage image)
        {
            var user = ChatToServer.LstUser.Where(x => x.Key == key).FirstOrDefault();
            string userName = user.UserName;
            if (MessageBox.Show(string.Format("{0}给你发送了一张图片：\r\n{1}\r\n是否接收？",userName,image.ImageName), "提示", MessageBoxButton.OKCancel) != MessageBoxResult.OK)
            {
                return;
            }
            System.Windows.Forms.SaveFileDialog sd = new System.Windows.Forms.SaveFileDialog();
            sd.Title = "请设置保存路劲";
            string extension = System.IO.Path.GetExtension(image.ImageName);
            sd.Filter = string.Format("所发的文件(*{0})|*{0}", extension);
            this.Dispatcher.Invoke(new Action(() =>
            {
                if (sd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return;
                FileHelper.SaveFileFromBytes(image.Data, sd.FileName);
                string msg = string.Format("{0} 接收图片完毕,保存在{1}", DateTime.Now, sd.FileName);
                UpdateText(msg, Colors.Green, true);
            }));
            
        }

       

        void host_Closed(object sender, EventArgs e)
        {
            UpdateText("已经关闭连接", Colors.Green, true);
        }

        void host_Opened(object sender, EventArgs e)
        {
            UpdateText("服务已经打开", Colors.Green, true);
            this.Dispatcher.Invoke(new Action(() =>
            {
                this.loadingFrame.Visibility = System.Windows.Visibility.Collapsed;
                this.mainGrid.Visibility = System.Windows.Visibility.Visible;
            }));
        }

        private void btn_SendMsg_Click(object sender, RoutedEventArgs e)
        {
            if(this.tb_preChat.Text=="")
                return;
            string msg = "";
            if (this.allRb.IsChecked == true)
            {
                foreach (User user in ChatToServer.LstUser)
                {
                    user.Client.SendMessageToClient(this.tb_preChat.Text);
                }
                msg = string.Format("服务器 {0} 广播消息：{1}", DateTime.Now.ToString(), this.tb_preChat.Text);
            }
            else
            {
                if (this.listBox.SelectedIndex == -1)
                {
                    MessageBox.Show("请选定好友来发送私聊消息！");
                    return;
                }
                User user = this.listBox.SelectedItem as User;
                user.Client.SendMessageToClient(this.tb_preChat.Text);
                msg = string.Format("服务器 {0} 对 {1} 说：{2}", DateTime.Now, user.UserName, this.tb_preChat.Text);
            }
            UpdateText(msg, Colors.Green, true);
            this.tb_preChat.Clear();
        }

        private void btn_SendImage_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog op = new System.Windows.Forms.OpenFileDialog();
            op.Title = "请选择文件";
            op.Filter = "所有文件|*.*";
            if (op.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            byte[] data = FileHelper.GetBytesByFile(op.FileName);
            MyImage file = new MyImage() { ImageName = op.FileName, Data = data };
            string msg = "";
            if (this.allRb.IsChecked == true)
            {
                foreach (User user in ChatToServer.LstUser)
                {
                    user.Client.SendImageToClient(file);
                }
                msg = string.Format("服务器 {0} 群发图片成功：{1}", DateTime.Now.ToString(), file.ImageName);
            }
            else
            {
                if (this.listBox.SelectedIndex == -1)
                {
                    MessageBox.Show("请选定好友来发送文件！");
                    return;
                }
                User user = this.listBox.SelectedItem as User;
                user.Client.SendImageToClient(file);
                msg = string.Format("服务器 {0} 对 {1} 发送了文件：{2}", DateTime.Now, user.UserName, file.ImageName);
            }
            UpdateText(msg, Colors.Green, true);

        }
    }
}
