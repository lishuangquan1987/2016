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
using System.Collections.ObjectModel;
using GDJL.MTST.Model;
using System.Collections;
using System.Threading;
using 数据库操作.View;

namespace 数据库操作
{
    /// <summary>
    /// Interaction logic for QueryData.xaml
    /// </summary>
    public partial class QueryData : Window
    {
        public QueryData()
        {
            InitializeComponent();
        }
        
        #region 字段、属性
        GDJL.MTST.BLL.DataBLL dataService = new GDJL.MTST.BLL.DataBLL();
        private ObservableCollection<Capacitor> lstCapacitor = new ObservableCollection<Capacitor>();
        private ObservableCollection<IC> lstIC = new ObservableCollection<IC>();
        private ObservableCollection<Inductor> lstInductor = new ObservableCollection<Inductor>();
        private ObservableCollection<Misc> lstMisc = new ObservableCollection<Misc>();
        private ObservableCollection<Module> lstModule = new ObservableCollection<Module>();
        private ObservableCollection<Oscillator> lstOscillator = new ObservableCollection<Oscillator>();
        private ObservableCollection<Resistor> lstResistor = new ObservableCollection<Resistor>();
        private ObservableCollection<Sensors> lstSensors = new ObservableCollection<Sensors>();
        public ObservableCollection<Capacitor> LstCapacitor
        {
            get
            {
                return lstCapacitor;
            }
            set
            {
                lstCapacitor = value;
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
                lstIC = value;
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
                lstInductor = value;
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
                lstMisc = value;
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
                lstModule = value;
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
                lstOscillator = value;
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
                lstResistor = value;
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
                lstSensors = value;
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
            new Thread(() =>
            {
                TableTreeViewModel model = new TableTreeViewModel();
                string msg = "";
                for (int i = 0; i < lstTable.Count; i++)
                {
                    string sql = "select distinct PartType from " + lstTable[i];
                    MyTable table = new MyTable() { Name = lstTable[i] };
                    IList lstPartType = dataService.CreateSqlQuery(sql, out msg);
                    foreach (BaseViewModel bv in GetBaseViewModel(lstPartType))
                    {
                        bv.Parent = table;//上下绑定
                        table.Children.Add(bv);
                    }
                    model.LstTable.Add(table);
                }
                this.Dispatcher.Invoke(new Action(() => this.DataContext = model));
            }).Start();            
        }
        private ObservableCollection<BaseViewModel> GetBaseViewModel(System.Collections.IList lstPartType)
        {
            ObservableCollection<BaseViewModel> lstBv = new ObservableCollection<BaseViewModel>();
            List<string> lstStr=new List<string>();//含有“\\”的字符串
            List<string> lstStr_sub = new List<string>(); //含有两个“\\”的字符串
            for (int i = 0; i < lstPartType.Count; i++)
            {
                if (!lstPartType[i].ToString().Contains("\\"))//第一级，无children
                {
                    BaseViewModel bv = new BaseViewModel();
                    bv.IconPath = "Icon\\table.png";
                    bv.Name = lstPartType[i].ToString();
                    lstBv.Add(bv);
                }
                else//递归更深一级  POWER\POWER LDO  POWER\POWER CONTROL
                {
                    //缓存含有\的字符串
                    lstStr.Add(lstPartType[i].ToString());
                }               
            }
            //遍历含有\的字符串
            List<string> header = new List<string>();
            lstStr.ForEach(x => header.Add(x.Split('\\')[0]));
            //去重复
            foreach (var h in header.Distinct())
            {
                BaseViewModel bv = new BaseViewModel();
                bv.Name = h;
                bv.Children = new ObservableCollection<BaseViewModel>();
                foreach (var r in lstStr.Where(x => x.StartsWith(h)))
                {
                    BaseViewModel sub_bv = new BaseViewModel();
                    int index = r.IndexOf("\\");
                    string splitStr = r.Substring(index+1, r.Length - index - 1);
                    sub_bv.Name = splitStr;
                    sub_bv.Parent = bv;
                    bv.Children.Add(sub_bv);
                }
                
                lstBv.Add(bv);
            }
            return lstBv;
        }       
        private void myTreeView_Selected(object sender, RoutedEventArgs e)
        {
            var item = e.OriginalSource as TreeViewItem;
            if (item == null)
                return;
            var source = item.DataContext;
            if (source is MyTable)
                return;
            else if (source is BaseViewModel)
            {
                BaseViewModel bv = source as BaseViewModel;
                //还有节点则返回
                if (bv.Children != null && bv.Children.Count > 0)
                    return;
                else
                {
                    string partType = GetPartTypeString(bv);
                    string tableName = GetTableName(bv);
                    string sql=string.Format("select * from {0} where PartType = '{1}'",tableName,partType);
                    Page page=null;
                    string msg;
                    #region 开始查询显示

                    switch (tableName)
                    {
                        case "Capacitor":
                            LstCapacitor.Clear();
                            page = new CapacitorPage();
                            dataService.CreateSqlQuery<Capacitor>(sql, out msg).ToList().ForEach(x=>LstCapacitor.Add(x));
                            
                            break;
                        case "IC":
                            LstIC.Clear();
                            page = new ICPage();
                            dataService.CreateSqlQuery<IC>(sql, out msg).ToList().ForEach(x=>LstIC.Add(x));
                            
                            break;
                        case "Inductor":
                            LstInductor.Clear();
                            page = new InductorPage();
                            dataService.CreateSqlQuery<Inductor>(sql, out msg).ToList().ForEach(x => LstInductor.Add(x));
                            
                            break;
                        case "Misc":
                            LstMisc.Clear();
                            page = new MiscPage();
                            dataService.CreateSqlQuery<Misc>(sql, out msg).ToList().ForEach(x => LstMisc.Add(x));
                            
                            break;
                        case "Module":
                            LstModule.Clear();
                            page = new ModulePage();
                            dataService.CreateSqlQuery<Module>(sql, out msg).ToList().ForEach(x => LstModule.Add(x));
                            
                            break;
                        case "Oscillator":
                            LstOscillator.Clear();
                            page = new OscillatorPage();
                            dataService.CreateSqlQuery<Oscillator>(sql, out msg).ToList().ForEach(x => LstOscillator.Add(x));
                            
                            break;
                        case "Resistor":
                            LstResistor.Clear();
                            page = new ResistorPage();
                            dataService.CreateSqlQuery<Resistor>(sql, out msg).ToList().ForEach(x => LstResistor.Add(x));
                            
                            break;
                        case "Sensors":
                            LstSensors.Clear();
                            page = new SensorsPage();
                            dataService.CreateSqlQuery<Sensors>(sql, out msg).ToList().ForEach(x => LstSensors.Add(x));
                            
                            break;
                    }
                    #endregion
                    page.DataContext = this;
                    this.frame.Content = page;
                }
            }
        }
        /// <summary>
        /// 根据树结构，获取点击的parttype全名称
        /// </summary>
        /// <param name="bv"></param>
        /// <returns></returns>
        private string GetPartTypeString(BaseViewModel bv)
        {
            string partType = "";
            if (bv.Parent is MyTable)
                partType = bv.Name + partType;
            else if (bv.Parent is BaseViewModel)
            {
                BaseViewModel parent = bv.Parent;
                partType =GetPartTypeString(bv.Parent)+"\\"+ bv.Name + "\\" + partType;               
            }
            if (partType.EndsWith("\\"))
                partType = partType.Substring(0, partType.Length - 1);
            return partType;
        }
        /// <summary>
        /// 根据点击树节点获取表的名称
        /// </summary>
        /// <param name="bv"></param>
        /// <returns></returns>
        private string GetTableName(BaseViewModel bv)
        {
            string tableName = "";
            if (bv is MyTable)
                tableName = bv.Name;
            else if (bv is BaseViewModel)
            {
                tableName = GetTableName(bv.Parent);
            }
            return tableName;
        }
    }
}
