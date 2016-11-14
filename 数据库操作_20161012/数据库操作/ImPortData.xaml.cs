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
using System.ComponentModel;
using System.Collections.ObjectModel;
using GDJL.MTST.Model;
using 数据库操作.View;


namespace 数据库操作
{
    /// <summary>
    /// Interaction logic for ImPortData.xaml
    /// </summary>
    public partial class ImPortData : Window
    {
        public ImPortData()
        {
            InitializeComponent();
        }
        #region 字段、属性
        GDJL.MTST.DAL.ExcelHelper excelHelper = GDJL.MTST.Singleton.ClientHelper.GetInstance().excelHelper;
        GDJL.MTST.DAL.SQLHelper sqlHelper = GDJL.MTST.Singleton.ClientHelper.GetInstance().sqlHelper;

        private ObservableCollection<Capacitor> lstCapacitor=new ObservableCollection<Capacitor>();
        private ObservableCollection<IC> lstIC=new ObservableCollection<IC>();
        private ObservableCollection<Inductor> lstInductor=new ObservableCollection<Inductor>();
        private ObservableCollection<Misc> lstMisc=new ObservableCollection<Misc>();
        private ObservableCollection<Module> lstModule=new ObservableCollection<Module>();
        private ObservableCollection<Oscillator> lstOscillator=new ObservableCollection<Oscillator>();
        private ObservableCollection<Resistor> lstResistor=new ObservableCollection<Resistor>();
        private ObservableCollection<Sensors> lstSensors=new ObservableCollection<Sensors>();


        public ObservableCollection<Capacitor> LstCapacitor
        {
            get
            {
                return lstCapacitor;
            }
            set
            {
                lstCapacitor=value;
            }
        }
        public ObservableCollection<IC> LstIC
        {
            get
            {
                return lstIC;
            }
            set
            {
                lstIC=value;
            }
        }
        public ObservableCollection<Inductor> LstInductor
        {
            get
            {
                return lstInductor;
            }
            set
            {
                lstInductor=value;
            }
        }
        public ObservableCollection<Misc> LstMisc
        {
            get
            {
                return lstMisc;
            }
            set
            {
                lstMisc=value;
            }
        }

        public ObservableCollection<Module> LstModule
        {
            get
            {
                return lstModule;
            }
            set
            {
                lstModule=value;
            }
        }
        public ObservableCollection<Oscillator> LstOscillator
        {
            get
            {
                return lstOscillator;
            }
            set
            {
                lstOscillator=value;
            }
        }
        public ObservableCollection<Resistor> LstResistor
        {
            get
            {
                return lstResistor;
            }
            set
            {
                lstResistor=value;
            }
        }
        public ObservableCollection<Sensors> LstSensors
        {
            get
            {
                return lstSensors;
            }
            set
            {
                lstSensors=value;
            }
        }
        List<string> lstTable = new List<string>()
            {
                "Capacitor",
                "IC",
                "Inductor",
                "Misc",
                "Module",
                "Oscillator",
                "Resistor",
                "Sensors"
            };
        #endregion
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.tableCombox.ItemsSource = lstTable;
        }

        private void FileSelectBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.tableCombox.SelectedIndex == -1)
            {
                MessageBox.Show("请选择一张表来导入");
                return;
            }
            System.Windows.Forms.OpenFileDialog op = new System.Windows.Forms.OpenFileDialog();
            op.Multiselect = false;
            op.Title = "请选择从Acess导入的EXCEL文件";
            string msg = "";
            if (op.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            this.tb_Path.Text = op.FileName;
            Page page = null;
            int count = 0;
            try
            {
                switch (this.tableCombox.SelectedIndex)
                {
                    case 0://Capacitor                       
                        excelHelper.GetDatasFromAccess_Capacitor(op.FileName).ForEach(x => LstCapacitor.Add(x));
                        count = LstCapacitor.Count;
                        page = new CapacitorPage();                                              
                        break;
                    case 1://IC
                        excelHelper.GetDatasFromAccess_IC(op.FileName).ForEach(x => LstIC.Add(x));
                        count = LstIC.Count;
                        page = new ICPage();
                        break;
                    case 2: //Inductor
                        excelHelper.GetDatasFromAccess_Inductor(op.FileName).ForEach(x => LstInductor.Add(x));
                        count = LstInductor.Count;
                        page = new InductorPage();
                        break;
                    case 3: // Misc
                        excelHelper.GetDatasFromAccess_Misc(op.FileName).ForEach(x => LstMisc.Add(x));
                        count = LstMisc.Count;
                        page = new MiscPage();
                        break;
                    case 4: //Module
                        excelHelper.GetDatasFromAccess_Module(op.FileName).ForEach(x => LstModule.Add(x));
                        count = LstModule.Count;
                        page = new ModulePage();
                        break;
                    case 5: //Oscillator
                        excelHelper.GetDatasFromAccess_Oscillator(op.FileName).ForEach(x => LstOscillator.Add(x));
                        count = LstOscillator.Count;
                        page = new OscillatorPage();
                        break;
                    case 6: //Resistor
                        excelHelper.GetDatasFromAccess_Resistor(op.FileName).ForEach(x => LstResistor.Add(x));
                        count = LstResistor.Count;
                        page = new ResistorPage();
                        break;
                    case 7: //Sensors
                        excelHelper.GetDatasFromAccess_Sensors(op.FileName).ForEach(x => LstSensors.Add(x));
                        count = LstSensors.Count;
                        page = new SensorsPage();
                        break;
                }
                page.DataContext = this;
                this.frame.Content = page;
                this.lb_Msg.Content = string.Format("本次从excel读取到{0}条记录", count);  
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.lb_Msg.Foreground = new SolidColorBrush(Colors.Green);
            object result = "";
            try
            {
                switch (this.tableCombox.SelectedIndex)
                {
                    case 0://Capacitor
                        if (LstCapacitor.Count == 0)
                        {
                            MessageBox.Show("没有要导入的数据");
                            return;
                        }
                        result = sqlHelper.Add<Capacitor>(LstCapacitor.ToList());
                        this.LstCapacitor.Clear();
                        break;
                    case 1://IC
                        if (LstIC.Count == 0)
                        {
                            MessageBox.Show("没有要导入的数据");
                            return;
                        }
                        result = sqlHelper.Add<IC>(LstIC.ToList());
                        this.lstIC.Clear();
                        break;
                    case 2: //Inductor
                        if (LstInductor.Count == 0)
                        {
                            MessageBox.Show("没有要导入的数据");
                            return;
                        }
                        result = sqlHelper.Add<Inductor>(LstInductor.ToList());
                        this.LstInductor.Clear();
                        break;
                    case 3: // Misc
                        if (LstMisc.Count == 0)
                        {
                            MessageBox.Show("没有要导入的数据");
                            return;
                        }
                        result = sqlHelper.Add<Misc>(LstMisc.ToList());
                        this.LstMisc.Clear();
                        break;
                    case 4: //Module
                        if (LstModule.Count == 0)
                        {
                            MessageBox.Show("没有要导入的数据");
                            return;
                        }
                        result = sqlHelper.Add<Module>(LstModule.ToList());
                        this.LstModule.Clear();
                        break;
                    case 5: //Oscillator
                        if (LstOscillator.Count == 0)
                        {
                            MessageBox.Show("没有要导入的数据");
                            return;
                        }
                        result = sqlHelper.Add<Oscillator>(LstOscillator.ToList());
                        this.LstOscillator.Clear();
                        break;
                    case 6: //Resistor
                        if (LstResistor.Count == 0)
                        {
                            MessageBox.Show("没有要导入的数据");
                            return;
                        }
                        result = sqlHelper.Add<Resistor>(LstResistor.ToList());
                        this.LstResistor.Clear();
                        break;
                    case 7: //Sensors
                        if (LstSensors.Count == 0)
                        {
                            MessageBox.Show("没有要导入的数据");
                            return;
                        }
                        result = sqlHelper.Add<Sensors>(LstSensors.ToList());
                        this.LstSensors.Clear();
                        break;
                }
                this.lb_Msg.Content = string.Format("成功导入{0}条记录", result);
                MessageBox.Show(string.Format("成功导入{0}条记录", result));
                
            }
            catch (Exception ee)
            {
                this.lb_Msg.Foreground=new SolidColorBrush(Colors.Red);
                this.lb_Msg.Content = "导入失败！";
                MessageBox.Show(ee.Message);
            }
        }
    }
}
