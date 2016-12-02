using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows.Data;
using WPF.Model;
using System.Windows.Media;
namespace WPFControls
{
   public class ColorConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            EnumTestStatus ts =(EnumTestStatus)Enum.Parse(typeof(EnumTestStatus), value.ToString());
            SolidColorBrush color = new SolidColorBrush(Colors.White);
            switch(ts)
            {
                case EnumTestStatus.Normal:
                    color = new SolidColorBrush(Colors.White);break;
                case EnumTestStatus.Fail:
                    color = new SolidColorBrush(Colors.Red);break;
                case EnumTestStatus.Pass:
                    color = new SolidColorBrush(Colors.Green);break;
                    
            }
            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
