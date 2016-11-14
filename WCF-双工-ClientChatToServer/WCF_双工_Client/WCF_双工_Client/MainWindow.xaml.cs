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
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Configuration;
using System.IO;

namespace WCF_双工_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string UserName = "";
        public MainWindow()
        {
            Login login = new Login();
            if (login.ShowDialog() != true)
            {
                Application.Current.Shutdown(-1);
            }
            UserName = login.tb_UserName.Text;
            InitializeComponent();
            this.Title = "Client-" + UserName;

            #region~loadingFrame
            Loading loadingpage = new Loading();
            loadingpage.lb_Msg.Content = "正在连接服务器，请稍后...";
            this.loadingFrame.Content = loadingpage;
            #endregion
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string ipAdress = ConfigurationManager.AppSettings["ipAdress"];
            new System.Threading.Thread(() =>
            {
                ChatToClient server = new ChatToClient();
                server.ReceiveMsgEvent += server_ReceiveMsgEvent;
                server.ReceiveImageEvent += server_ReceiveImageEvent;
                InstanceContext context = new InstanceContext(server);
                WSDualHttpBinding bingding = new WSDualHttpBinding();
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

                factory = new DuplexChannelFactory<IChatToServer>(context, bingding, new EndpointAddress(ipAdress));
                foreach (OperationDescription op in factory.Endpoint.Contract.Operations)
                {
                    DataContractSerializerOperationBehavior dataContractBehavior = op.Behaviors.Find<DataContractSerializerOperationBehavior>() as DataContractSerializerOperationBehavior;
                    if (dataContractBehavior != null)
                    {
                        dataContractBehavior.MaxItemsInObjectGraph = Int32.MaxValue;
                    }
                }
                try
                {
                    client = factory.CreateChannel();
                    client.Login(UserName);
                    UpdateText(DateTime.Now.ToString() + "  已经与服务器连接..", Colors.Gray, true);
                    this.Dispatcher.Invoke(new Action(() =>
                    {
                        this.loadingFrame.Visibility = System.Windows.Visibility.Collapsed;
                        this.mainGrid.Visibility = System.Windows.Visibility.Visible;
                    }));

                    client.AAA(new MyStream(@"C:\Users\Administrator\Desktop\新建文本文档.txt", FileMode.Open, FileAccess.Read));
                }
                catch (Exception ee)
                {
                    UpdateText(DateTime.Now.ToString() + "  " + ee.Message + "\r\n请重启客户端重新来连接", Colors.Red, true);
                    this.Dispatcher.Invoke(new Action(() =>
                    {
                        this.loadingFrame.Visibility = System.Windows.Visibility.Collapsed;
                        this.mainGrid.Visibility = System.Windows.Visibility.Visible;
                    }));
                }
            }).Start();

        }
        IChatToServer client = null;
        DuplexChannelFactory<IChatToServer> factory;
        private void btn_SendMsg_Click(object sender, RoutedEventArgs e)
        {
            if (this.tb_preChat.Text == "")
                return;
            client.SendMessageToServer(tb_preChat.Text);
            string msg = string.Format("我 {0}：{1}", DateTime.Now, tb_preChat.Text);
            UpdateText(msg, Colors.Green, true);
            this.tb_preChat.Clear();
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                btn_SendMsg_Click(this, e);
            base.OnKeyDown(e);
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
            client.SendImageToServer(file);
            UpdateText(DateTime.Now.ToString()+"发送图片成功" + file.ImageName, Colors.Green, true);

        }
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
       

        void server_ReceiveImageEvent(MyImage image)
        {
            if (MessageBox.Show(string.Format("{0}给你发送了一张图片：\r\n{1}\r\n是否接收？", "服务器", image.ImageName), "提示", MessageBoxButton.OKCancel) != MessageBoxResult.OK)
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
                string msg=string.Format("{0} 接收图片完毕,保存在{1}",DateTime.Now,sd.FileName);
                UpdateText(msg, Colors.Green, true);
            }));
            
        }

        void server_ReceiveMsgEvent(string msg)
        {
            msg = string.Format("服务器 {0}：{1}", DateTime.Now, msg);
            UpdateText(msg, Colors.Blue, true);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if(factory!=null)
            factory.Close();
        }
    }
}
