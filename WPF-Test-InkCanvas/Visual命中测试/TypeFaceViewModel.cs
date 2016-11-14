using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Drawing.Text;

namespace Visual命中测试
{
    /// FontFamily fontFamily, FontStyle style, FontWeight weight, FontStretch stretch
   public class TypeFaceViewModel
    {
       public List<System.Drawing.FontFamily> lstFontFamily = new List<System.Drawing.FontFamily>();
       //public List<FontStyle> lstFontStyle = new List<FontStyle>();
       //public List<FontWeight> lstFontWeight = new List<FontWeight>();
       //public List<FontStretch> lstFontStretch = new List<FontStretch>();
       public TypeFaceViewModel()
       {
           InstalledFontCollection myFont = new InstalledFontCollection();
           lstFontFamily = myFont.Families.ToList();
       }
    }
}
