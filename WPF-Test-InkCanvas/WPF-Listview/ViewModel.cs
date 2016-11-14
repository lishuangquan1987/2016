using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace WPF_Listview
{
   public class ViewModel
    {
       public ObservableCollection<People> listPeople;
       public ViewModel()
       {
           listPeople = new ObservableCollection<People>()
           {
               new People(){Name="li",Id=1,Num=1212,Age=13},
               new People(){Name="liu",Id=2,Num=456,Age=26}
           };
       }
    }
}
