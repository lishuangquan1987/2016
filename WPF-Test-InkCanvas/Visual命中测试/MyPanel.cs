using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace Visual命中测试
{
   public class MyPanel:Panel
    {
       private List<Visual> visuals = new List<Visual>();
       protected override Visual GetVisualChild(int index)
       {
           return visuals[index];
       }
       protected override int VisualChildrenCount
       {
           get
           {
               return visuals.Count;
           }
       }
       public void AddVisual(Visual visual)
       {
           visuals.Add(visual);
           base.AddLogicalChild(visual);
           base.AddVisualChild(visual);
       }
       public void DeleteVisual(Visual visual)
       {
           visuals.Remove(visual);
           base.RemoveLogicalChild(visual);
           base.RemoveVisualChild(visual);
       }
       public DrawingVisual GetDrawingVisual(System.Windows.Point p)
       {
           HitTestResult hitResult = VisualTreeHelper.HitTest(this, p);
           if (hitResult != null)
               return hitResult.VisualHit as DrawingVisual;
           else
               return null;
       }
    }
}
