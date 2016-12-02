using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace WPF.Model
{
    public class Student:BaseModel
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged("Name"); }
        }
        private bool _pass;

        public bool Pass
        {
            get { return _pass; }
            set { _pass = value; OnPropertyChanged("Pass"); }
        }
        private Uri _uri;

        public Uri Uri
        {
            get { return _uri; }
            set { _uri = value; OnPropertyChanged("Uri"); }
        }
        private Gender _gender;

        public Gender Gender
        {
            get { return _gender; }
            set { _gender = value; OnPropertyChanged("Gender"); }
        }
    }
    public enum Gender
    {
        Male,
        Female,
        Other
    }
}
