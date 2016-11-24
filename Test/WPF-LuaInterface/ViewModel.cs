using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;

namespace WPF_LuaInterface
{
   public class ViewModel:INotifyPropertyChanged
    {
       private string txt;
       public string Txt
       {
           get { return this.txt; }
           set { this.dispatcher.Invoke(new Action(() => { this.txt = value; OnPropertyChanged("Txt"); })); }
       }
       private ICommand clickCommand;
       public ICommand ClickCommand
       {
           get { return this.clickCommand; }
           set { this.clickCommand = value; }
       }
       LuaInterface.Lua lua;
       private System.Windows.Threading.Dispatcher dispatcher;
       public ViewModel(System.Windows.Threading.Dispatcher d)
       {
           dispatcher = d;
           ClickCommand = new CommonCommand(OnClick);
           lua = new LuaInterface.Lua();
           lua.DoFile("aaa.lua");
           lua["this"] = this;
       }
       public void Delay(int ms)
       {
           System.Threading.Thread.Sleep(ms);
       }
       public void OnClick(object par)
       {
           new System.Threading.Thread(() => lua.DoString("return Main();")).Start();
           
       }
       public void OnPropertyChanged(string name)
       {
           if (PropertyChanged != null)
               this.PropertyChanged(this, new PropertyChangedEventArgs(name));
       }
       public event PropertyChangedEventHandler PropertyChanged;
    }
   public class CommonCommand : ICommand
    {
        readonly Action<object> execute = null;
        readonly Predicate<object> canExecute = null;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="execute">命令执行函数</param>
        public CommonCommand(Action<object> execute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            this.execute = execute;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="execute">命令执行函数</param>
        /// <param name="canExecute">命令能否执行判断函数</param>
        public CommonCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            this.canExecute = canExecute;
            this.execute = execute;
        }
        #region  实现ICommand
        /// <summary>
        /// 定义用于确定此命令是否可以在其当前状态下执行的方法
        /// </summary>
        /// <param name="parameter">此命令使用的数据。 如果此命令不需要传递数据，则该对象可以设置为 nul</param>
        /// <returns>如果可以执行此命令，则为 true；否则为 false。</returns>
        public bool CanExecute(object parameter)
        {
            return canExecute == null ? true : canExecute(parameter);
        }
        /// <summary>
        /// 定义在调用此命令时调用的方法
        /// </summary>
        /// <param name="parameter">此命令使用的数据。 如果此命令不需要传递数据，则该对象可以设置为 null。</param>
        public void Execute(object parameter)
        {
            //如果方法不为空，则调用定义的方法
            if (execute != null)
            {
                execute(parameter);
            }
        }
        /// <summary>
        /// 当出现影响是否应执行该命令的更改时发生
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        #endregion
    }

}
