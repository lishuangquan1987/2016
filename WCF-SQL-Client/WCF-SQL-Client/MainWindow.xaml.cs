﻿using System;
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
using System.Collections.ObjectModel;


namespace WCF_SQL_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = lstPerson;
            
        }
        MyProxyService.Service1Client service = new MyProxyService.Service1Client();
        ObservableCollection<MyProxyService.Person> lstPerson = new ObservableCollection<MyProxyService.Person>();

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            MyProxyService.Person[] _lstPerson = service.Query("select * from person");
            _lstPerson.ToList().ForEach(x => lstPerson.Add(x));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = lstPerson;
        }
        
    }
    
}
