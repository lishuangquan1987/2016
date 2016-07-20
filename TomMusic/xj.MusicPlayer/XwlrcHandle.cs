using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Drawing;
using System.Windows.Forms;
//using System.Windows.Media;
using System.Threading;
namespace Xwlrc
{
    public class XwlrcHandle
    {
        #region 根据需求改写
        //    bool showTab = true;    //切换显示歌词
        //    bool setText = false;   //重复赋值
        //    int oldrIndex = -1;
        //    MainWindow mwLrc = new MainWindow(true);    //歌词显示窗口
        //    getPage gp = new getPage();                 //歌词大小占用测试窗口
        //    public SizeF LrcFormSize = new SizeF();
        //    public SizeF NextLrcSize = new SizeF();

        //    public string DefaultLrc = "Xwlrc 桌面歌词测试版";
        //    public void Show() {
        //        mwLrc.Show();
        //        gp.Show();
        //        mwLrc.Topmost = true;
        //    }
        //    /// <summary>
        //    /// 显示或关闭显示
        //    /// </summary>
        //    /// <param name="RunOrColse">显示或关闭</param>
        //    public void RunOrCloseXtlrc(bool RunOrColse) {
        //        if (RunOrColse) mwLrc.Visibility = Visibility.Visible;
        //        else mwLrc.Visibility = Visibility.Hidden;
        //    }

        //    public double NextProTime = 0;
        //    public double NextWidth = 0;
        //    int NextrIndex = -1;
        //    /// <summary>
        //    /// 歌词显示进度模块
        //    /// </summary>
        //    /// <param name="Lrc">歌词</param>
        //    /// <param name="CountTime">本句歌词显示的总时间</param>
        //    /// <param name="ShowTime">音乐播放的时间</param>
        //    /// <param name="NextTime">下句歌词所在的时间</param>
        //    /// <param name="showHeight">歌词高度</param>
        //    /// <param name="overflowPer">当歌词长度溢出显示区域时，显示的百分比</param>
        //    /// <param name="isChange">歌词索引</param>
        //    public void ShowLrc(int CountTime, double ShowNextTime, double ShowTime, double StartTime,double NextTimeA, double overflowPer, int rIndex, bool isFirst, List<LrcDec> Lrcs, List<LrcDec> LrcsNext)
        //    {
        //        if (isFirst) {
        //            Lrcs[0].Lrc = DefaultLrc;
        //            Lrcs[0].SingleLrc = DefaultLrc;
        //            LrcsNext[0].Lrc = "";
        //            LrcsNext[0].SingleLrc = "";
        //        }
        //        string Lrc = Lrcs[0].Lrc;
        //        string NextLrc = LrcsNext[0].Lrc;
        //        if (CountTime == 0) return;
        //        if (overflowPer >= 1 | overflowPer <= 0) {
        //            overflowPer = 0.7;
        //        }
        //        //double schPer = ((NextTime - ShowTime) / CountTime);
        //        #region 逐字定位

        //        List<LrcDec> lrcDecs = GetSize(Lrcs);
        //        List<LrcDec> lrcDecsNext=GetSize(LrcsNext);
        //        LrcFormSize = GetSizeForLrc(Lrc);
        //        NextLrcSize = GetSizeNext(NextLrc);
        //        double CWidth = 0;
        //        double CNWidth = 0;
        //        if (ShowTime != 0)
        //        {
        //            double ProTime = ShowTime - StartTime;
        //            if (ProTime >= 0)
        //            {
        //                for (int i = 0; i < lrcDecs.Count; i++)
        //                {
        //                    if (ProTime == 0) break;
        //                    if (lrcDecs[i].LrcTime == 0) {
        //                        if (i != lrcDecs.Count - 1) lrcDecs[i].LrcTime = lrcDecs[i + 1].LrcStartTime - lrcDecs[i].LrcStartTime;
        //                        else lrcDecs[i].LrcTime = 1;
        //                    }
        //                    if (ProTime >= lrcDecs[i].LrcStartTime & ProTime < lrcDecs[i].LrcStartTime + lrcDecs[i].LrcTime)
        //                    {
        //                        // 当前时间减去开始时间除以当前文字所需要的时间
        //                        CWidth += lrcDecs[i].LrcSize.Width * ((ProTime - lrcDecs[i].LrcStartTime) / lrcDecs[i].LrcTime);
        //                        break;
        //                    }
        //                    else
        //                    {
        //                        CWidth += lrcDecs[i].LrcSize.Width;
        //                    }
        //                }
        //            }
        //            if (CWidth < 0) CWidth = 0;
        //        }
        //        if (ShowTime - ShowNextTime >= 0)
        //        {
        //            double ProTimeNext = ShowTime - ShowNextTime;
        //            for (int i = 0; i < lrcDecsNext.Count; i++)
        //            {
        //                if (ProTimeNext == 0) break;
        //                if (ProTimeNext >= lrcDecsNext[i].LrcStartTime & ProTimeNext < lrcDecsNext[i].LrcStartTime + lrcDecsNext[i].LrcTime)
        //                {
        //                    // 当前时间减去开始时间除以当前文字所需要的时间
        //                    CNWidth += lrcDecsNext[i].LrcSize.Width * ((ProTimeNext - lrcDecsNext[i].LrcStartTime) / lrcDecsNext[i].LrcTime);
        //                    break;
        //                }
        //                else
        //                {
        //                    CNWidth += lrcDecsNext[i].LrcSize.Width;
        //                }
        //            }
        //            if (CNWidth < 0) CNWidth = 0;
        //            NextWidth = CNWidth;
        //        }
        //        else {
        //            CNWidth = NextWidth;
        //            NextWidth = 0;
        //        }
        //        #endregion

        //        mwLrc.ShowGrid.Width = Screen.PrimaryScreen.WorkingArea.Width * 0.6;
        //        mwLrc.Width = mwLrc.ShowGrid.Width;
        //        if (isFirst)
        //        {
        //            mwLrc.lb_ShowBack.Margin = new Thickness(mwLrc.ShowGrid.Width / 2 - LrcFormSize.Width / 2, mwLrc.ShowGrid.Height / 2 - LrcFormSize.Height / 2, 0, 0);
        //            mwLrc.lb_BomBack.Margin = mwLrc.lb_ShowBack.Margin;
        //            showTab = true;
        //            setText = false;
        //        }
        //        else
        //        {
        //            #region 当前歌词处理
        //            if (LrcFormSize.Width > mwLrc.ShowGrid.Width)
        //            {
        //                //当歌词宽度溢出显示区域的时候，在进行到 显示区域*overflowPer（百分比） 时，将歌词向左移动
        //                if (CWidth >= mwLrc.ShowGrid.Width * overflowPer)
        //                {
        //                    if (!(LrcFormSize.Width - CWidth < mwLrc.ShowGrid.Width * (1 - overflowPer - 0.01)))
        //                    {
        //                        if (showTab)
        //                            mwLrc.lb_ShowBack.Margin = new Thickness(Convert.ToInt32(-(CWidth - mwLrc.ShowGrid.Width * overflowPer)), 0, 0, 0);
        //                        else
        //                            mwLrc.lb_BomBack.Margin = new Thickness(Convert.ToInt32(-(CWidth - mwLrc.ShowGrid.Width * overflowPer)), NextLrcSize.Height, 0, 0);
        //                    }
        //                }
        //                else
        //                {
        //                    if (showTab)
        //                        mwLrc.lb_ShowBack.Margin = new Thickness(0, 0, 0, 0);
        //                    else
        //                        mwLrc.lb_BomBack.Margin = new Thickness(0, NextLrcSize.Height, 0, 0);
        //                }
        //            }
        //            else
        //            {
        //                if (showTab)
        //                    mwLrc.lb_ShowBack.Margin = new Thickness(0, 0, 0, 0);
        //                else
        //                    mwLrc.lb_BomBack.Margin = new Thickness(Convert.ToInt32(this.mwLrc.ShowGrid.Width - LrcFormSize.Width), LrcFormSize.Height, 0, 0);
        //            }

        //            #endregion
        //            #region 下一句歌词处理
        //            if (NextLrcSize.Width > mwLrc.ShowGrid.Width)
        //            {
        //                //当歌词宽度溢出显示区域的时候，在进行到 显示区域*overflowPer（百分比） 时，将歌词向左移动
        //                if (CNWidth >= mwLrc.ShowGrid.Width * overflowPer)
        //                {
        //                    if (!(NextLrcSize.Width-CNWidth < mwLrc.ShowGrid.Width * (1 - overflowPer-0.01)))
        //                    {
        //                        if (!showTab)
        //                            mwLrc.lb_ShowBack.Margin = new Thickness(Convert.ToInt32(-(CNWidth - mwLrc.ShowGrid.Width * overflowPer)), 0,0, 0);
        //                        else
        //                            mwLrc.lb_BomBack.Margin = new Thickness(Convert.ToInt32(-(CNWidth - mwLrc.ShowGrid.Width * overflowPer)), NextLrcSize.Height, 0, 0);
        //                    }

        //                }
        //                else
        //                {
        //                    if (!showTab)
        //                        mwLrc.lb_ShowBack.Margin = new Thickness(0, 0, 0, 0);
        //                    else
        //                        mwLrc.lb_BomBack.Margin = new Thickness(0, NextLrcSize.Height, 0, 0);
        //                }
        //            }
        //            else
        //            {
        //                if (!showTab)
        //                    mwLrc.lb_ShowBack.Margin = new Thickness(0, 0, 0, 0);
        //                else
        //                    mwLrc.lb_BomBack.Margin = new Thickness(Convert.ToInt32(this.mwLrc.ShowGrid.Width - NextLrcSize.Width), NextLrcSize.Height, 0, 0);
        //            }
        //            #endregion
        //        }
        //        //调整底层歌词位置
        //        mwLrc.lb_ShowFore.Margin = mwLrc.lb_ShowBack.Margin;
        //        mwLrc.lb_BomFore.Margin = mwLrc.lb_BomBack.Margin;

        //        #region 设置歌词
        //        mwLrc.lb_ShowBack.Height = LrcFormSize.Height;
        //        mwLrc.lb_ShowFore.Height = LrcFormSize.Height;
        //        mwLrc.lb_BomBack.Height = LrcFormSize.Height;
        //        mwLrc.lb_BomFore.Height = LrcFormSize.Height;
        //        mwLrc.ShowGrid.Height = LrcFormSize.Height * 2;
        //        mwLrc.Width = mwLrc.ShowGrid.Width + 12;
        //        //mwLrc.Left = Screen.PrimaryScreen.WorkingArea.Width / 2 - mwLrc.Width / 2;
        //        if (showTab)
        //        {
        //            if (!setText)
        //            {
        //                if (mwLrc.lb_ShowFore.Content+"" != Lrc)
        //                {
        //                    mwLrc.lb_ShowFore.Content = Lrc;
        //                    mwLrc.lb_ShowBack.Content = Lrc;
        //                }

        //                mwLrc.lb_ShowBack.Height = LrcFormSize.Height;
        //                mwLrc.lb_ShowFore.Height = LrcFormSize.Height;
        //                mwLrc.lb_BomFore.Content = NextLrc;

        //                mwLrc.lb_BomBack.Content = NextLrc;
        //                if (!isFirst)
        //                    setText = true;
        //            }
        //            mwLrc.lb_BomFore.Width = NextLrcSize.Width;
        //            mwLrc.lb_BomBack.Width = NextLrcSize.Width;
        //            mwLrc.lb_ShowBack.Width = LrcFormSize.Width;
        //            mwLrc.lb_ShowFore.Width = CWidth;
        //            mwLrc.lb_BomFore.Width = CNWidth;
        //        }
        //        else
        //        {
        //            if (!setText)
        //            {
        //                if (mwLrc.lb_BomFore.Content+"" != Lrc)
        //                {
        //                    mwLrc.lb_BomFore.Content = Lrc;
        //                    mwLrc.lb_BomBack.Content = Lrc;
        //                }
        //                mwLrc.lb_BomBack.Height = LrcFormSize.Height;
        //                mwLrc.lb_BomFore.Height = LrcFormSize.Height;
        //                mwLrc.lb_ShowFore.Content = NextLrc;

        //                mwLrc.lb_ShowBack.Content = NextLrc;

        //                if (!isFirst)
        //                    setText = true;
        //            }
        //            mwLrc.lb_ShowFore.Width = NextLrcSize.Width;
        //            mwLrc.lb_ShowBack.Width = NextLrcSize.Width;
        //            mwLrc.lb_BomBack.Width = LrcFormSize.Width;
        //            mwLrc.lb_BomFore.Width = CWidth;
        //            mwLrc.lb_ShowFore.Width = CNWidth;
        //            //下一句

        //        }
        //        #endregion

        //        if (oldrIndex != rIndex)
        //        {
        //            oldrIndex = rIndex;
        //            if (Lrc.Trim() != "")
        //            {
        //                showTab = !showTab;
        //            }
        //            else
        //            {
        //                showTab = true;
        //            }
        //            setText = false;
        //        }
        //        if (rIndex == 0) showTab = true;
        //    }
        //    /// <summary>
        //    /// 设置字体
        //    /// </summary>
        //    /// <param name="fontSize"></param>
        //    public void SetFont(Font font) {
        //        mwLrc.lb_ShowFore.FontSize = font.Size;
        //        mwLrc.lb_ShowBack.FontSize = font.Size;
        //        gp.lb_AutoSize.FontSize = font.Size;
        //        mwLrc.lb_ShowFore.FontFamily = new System.Windows.Media.FontFamily(font.FontFamily.Name);
        //        mwLrc.lb_ShowBack.FontFamily = new System.Windows.Media.FontFamily(font.FontFamily.Name);
        //        gp.lb_AutoSize.FontFamily = new System.Windows.Media.FontFamily(font.FontFamily.Name);
        //        mwLrc.lb_ShowFore.FontWeight = font.Bold ? FontWeights.Bold : FontWeights.Normal;
        //        mwLrc.lb_ShowBack.FontWeight = font.Bold ? FontWeights.Bold : FontWeights.Normal;
        //        gp.lb_AutoSize.FontWeight = font.Bold ? FontWeights.Bold : FontWeights.Normal;
        //        mwLrc.lb_ShowFore.FontStyle = font.Italic ? FontStyles.Italic : FontStyles.Normal;
        //        mwLrc.lb_ShowBack.FontStyle = font.Italic ? FontStyles.Italic : FontStyles.Normal;
        //        gp.lb_AutoSize.FontStyle = font.Italic ? FontStyles.Italic : FontStyles.Normal;

        //        mwLrc.lb_BomFore.FontSize = font.Size;
        //        mwLrc.lb_BomFore.FontFamily = new System.Windows.Media.FontFamily(font.FontFamily.Name);
        //        mwLrc.lb_BomFore.FontWeight = font.Bold ? FontWeights.Bold : FontWeights.Normal;
        //        mwLrc.lb_BomFore.FontStyle = font.Italic ? FontStyles.Italic : FontStyles.Normal;

        //        mwLrc.lb_BomBack.FontSize = font.Size;
        //        mwLrc.lb_BomBack.FontFamily = new System.Windows.Media.FontFamily(font.FontFamily.Name);
        //        mwLrc.lb_BomBack.FontWeight = font.Bold ? FontWeights.Bold : FontWeights.Normal;                       
        //        mwLrc.lb_BomBack.FontStyle = font.Italic ? FontStyles.Italic : FontStyles.Normal;    

        //        gp.lb_AutoSizeBom.FontSize = font.Size;
        //        gp.lb_AutoSizeBom.FontFamily = new System.Windows.Media.FontFamily(font.FontFamily.Name);
        //        gp.lb_AutoSizeBom.FontWeight = font.Bold ? FontWeights.Bold : FontWeights.Normal;
        //        gp.lb_AutoSizeBom.FontStyle = font.Italic ? FontStyles.Italic : FontStyles.Normal;
        //    }
        //    /// <summary>
        //    /// 设置背景色
        //    /// </summary>
        //    /// <param name="color"></param>
        //    public void SetColor(System.Drawing.Color color) {
        //        mwLrc.lb_ShowBack.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B));
        //        mwLrc.lb_BomBack.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B));
        //    }
        //    /// <summary>
        //    /// 设置前景色
        //    /// </summary>
        //    /// <param name="color"></param>
        //    public void SetColoeT(System.Drawing.Color color) {
        //        mwLrc.lb_ShowFore.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B));
        //        mwLrc.lb_BomFore.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B));
        //    }
        //    /// <summary>
        //    /// 获取该歌词所占用的宽度
        //    /// </summary>
        //    /// <param name="Lrc">歌词</param>
        //    /// <returns>占用的宽度</returns>
        //    public SizeF GetSizeNext(string Lrc)
        //    {
        //        gp.lb_AutoSize.Content = Lrc;
        //        return new SizeF((float)gp.lb_AutoSize.ActualWidth, (float)gp.lb_AutoSize.ActualHeight);
        //    }
        //    /// <summary>
        //    /// 获取该歌词所占用的宽度
        //    /// </summary>
        //    /// <param name="Lrc">歌词</param>
        //    /// <returns>占用的宽度</returns>
        //    public SizeF GetSizeForLrc(string Lrc)
        //    {
        //        gp.lb_AutoSizeBom.Content = Lrc;
        //        return new SizeF((float)gp.lb_AutoSizeBom.ActualWidth, (float)gp.lb_AutoSizeBom.ActualHeight);
        //    }
        //    public List<LrcDec> GetSize(List<LrcDec> Lrcs)
        //    {
        //        List<LrcDec> lrcDecs = Lrcs;
        //        if (lrcDecs.Count == 0) lrcDecs.Add(new LrcDec() { Lrc="",LrcWidth = 0 });
        //        FormattedText formattedText;
        //        formattedText = new FormattedText(lrcDecs[0].Lrc,
        //             System.Globalization.CultureInfo.InvariantCulture,
        //             System.Windows.FlowDirection.LeftToRight,
        //             new Typeface(mwLrc.lb_BomFore.FontFamily, mwLrc.lb_BomFore.FontStyle, mwLrc.lb_BomFore.FontWeight, mwLrc.lb_BomFore.FontStretch),
        //             mwLrc.lb_BomFore.FontSize,
        //             System.Windows.Media.Brushes.Black);
        //        lrcDecs[0].LrcWidth = formattedText.WidthIncludingTrailingWhitespace + 10;
        //        foreach (LrcDec lrc in lrcDecs)
        //        {
        //            formattedText=new FormattedText(lrc.SingleLrc,
        //            System.Globalization.CultureInfo.InvariantCulture,
        //            System.Windows.FlowDirection.LeftToRight,
        //            new Typeface(mwLrc.lb_BomFore.FontFamily, mwLrc.lb_BomFore.FontStyle, mwLrc.lb_BomFore.FontWeight, mwLrc.lb_BomFore.FontStretch),
        //            mwLrc.lb_BomFore.FontSize,
        //            System.Windows.Media.Brushes.Black);
        //            lrc.LrcSize = new SizeF((float)formattedText.WidthIncludingTrailingWhitespace, (float)formattedText.Height+10);
        //        }
        //        //加上LABEL的Padding
        //        //lrcDecs[0].LrcSize = new SizeF(lrcDecs[0].LrcSize.Width+5, lrcDecs[0].LrcSize.Height);
        //        //lrcDecs[lrcDecs.Count - 1].LrcSize = new SizeF(lrcDecs[lrcDecs.Count - 1].LrcSize.Width + 10, lrcDecs[lrcDecs.Count - 1].LrcSize.Height);
        //        return lrcDecs;
        //    }
        //}
        //public class LrcDec {
        //    public double LrcTime { get; set; }
        //    public double LrcStartTime { get; set; }
        //    public double LrcWidth { get; set; }
        //    public SizeF LrcSize { get; set; }
        //    public string Lrc { get; set; }
        //    public int CLrcTime { get; set; }
        //    public string SingleLrc { get; set; } 
        #endregion
    }
}
