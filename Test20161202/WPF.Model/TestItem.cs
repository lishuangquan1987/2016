using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace WPF.Model
{
    public class TestItem:BaseModel
    {

        
        private string _itemName;

        public string ItemName
        {
            get { return _itemName; }
            set { _itemName = value; OnPropertyChanged("ItemName"); }
        }
        private string _upper;

        public string Upper
        {
            get { return _upper; }
            set { _upper = value; OnPropertyChanged("Upper"); }
        }
        private string _lower;

        public string Lower
        {
            get { return _lower; }
            set { _lower = value; OnPropertyChanged("Lower"); }
        }
        private string _value;
        public string Value
        {
            get { return _value; }
            set { _value = value; OnPropertyChanged("Value"); }
        }
        private EnumTestStatus _testStatus;

        public EnumTestStatus TestStatus
        {
            get { return _testStatus; }
            set { _testStatus = value; OnPropertyChanged("TestStatus"); }
        }
    }
    public enum EnumTestStatus
    {
        Normal,
        Pass,
        Fail
    }
}
