using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;


namespace SQL_Operation
{
    
    public class Person:INotifyPropertyChanged
    {
        private int _id;
        
        public int ID
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged("ID"); }
        }
        private string _name;
        
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged("Name"); }
        }

        private int _age;
        
        public int Age
        {
            get { return _age; }
            set { _age = value; OnPropertyChanged("Age"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            if(PropertyChanged!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}