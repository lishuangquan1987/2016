﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;

namespace Common
{
   public class User32DllHelper
    {
       /// <summary>
       /// 获取光标位置(相对于屏幕左上方)
       /// </summary>
       /// <param name="point">返回结果的点</param>
       /// <returns>获取是否成功</returns>
       [DllImport("user32.dll", SetLastError = true)]
       public static extern bool GetCursorPos(ref Point point);
        //如果函数执行成功，返回值不为0。
        //如果函数执行失败，返回值为0。要得到扩展错误信息，调用GetLastError。       
       /// <summary>
       ///获取当前软体界面的句柄
       /// </summary>
       /// <returns></returns>
        [DllImport("User32.dll")]
        public static extern IntPtr GetFocus();
        /// <summary>
        /// 注册热键,获取是否是热键请override WinProc(ref Message m)中判断 m.Msg是否为0x0312和m.WParm.ToString()是否为id
        /// </summary>
        /// <param name="hWnd">要定义热键的窗口的句柄</param>
        /// <param name="id">定义热键ID（不能与其它ID重复）</param>
        /// <param name="fsModifiers">标识热键是否在按Alt、Ctrl、Shift、Windows等键时才会生效</param>
        /// <param name="vk">定义热键的内容</param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool RegisterHotKey(
            IntPtr hWnd,                //
            int id,                     //           
            KeyModifiers fsModifiers,   //
            Keys vk                     //
            );

       /// <summary>
       /// 取消注册热键
       /// </summary>
        /// <param name="hWnd">要取消热键的窗口的句柄</param>
        /// <param name="id">要取消热键的ID</param>
       /// <returns>取消热键是否成功</returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnregisterHotKey(
            IntPtr hWnd,                //
            int id                      //
            );
       /// <summary>
       /// 将窗体设置到最前端来
       /// </summary>
       /// <param name="hWnd">要设置的窗体句柄</param>
       /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hwnd, int cmdShow);
        //定义了辅助键的名称（将数字转变为字符以便于记忆，也可去除此枚举而直接使用数值）
        [Flags()]
        public enum KeyModifiers
        {
            None = 0,
            Alt = 1,
            Ctrl = 2,
            Shift = 4,
            WindowsKey = 8
        }
        //
       /// <summary>
        ///  模拟键盘事件
       /// </summary>
       /// <param name="bVk"></param>
       /// <param name="bScan"></param>
       /// <param name="dwFlags"></param>
       /// <param name="dwExtraInfo"></param>
        [DllImport("User32.dll")]
        public static extern void keybd_event(Byte bVk, Byte bScan, Int32 dwFlags, Int32 dwExtraInfo);
        //释放按键的常量
        private const int KEYEVENTF_KEYUP = 2;
       /// <summary>
       /// 键值
       /// </summary>
        public enum key
        {
            VK_LBUTTON = 1,
            VK_RBUTTON = 2,
            VK_CANCEL = 3,
            VK_MBUTTON = 4,
            VK_BACK = 8,
            VK_TAB = 9,
            VK_CLEAR = 12,
            VK_RETURN = 13,
            VK_SHIFT = 16,
            VK_CONTROL = 17,
            VK_MENU = 18,
            VK_PAUSE = 19,
            VK_CAPITAL = 20,
            VK_ESCAPE = 27,
            VK_SPACE = 32,
            VK_PRIOR = 33,
            VK_NEXT = 34,
            VK_END = 35,
            VK_HOME = 36,
            VK_LEFT = 37,
            VK_UP = 38,
            VK_RIGHT = 39,
            VK_DOWN = 40,
            VK_SELECT = 41,
            VK_PRINT = 42,
            VK_EXECUTE = 43,
            VK_SNAPSHOT = 44,
            VK_INSERT = 45,
            VK_DELETE = 46,
            VK_HELP = 47,
            VK_NUM0 = 48, //0		
            VK_NUM1 = 49, //1		
            VK_NUM2 = 50, //2		
            VK_NUM3 = 51, //3		
            VK_NUM4 = 52, //4		
            VK_NUM5 = 53, //5		
            VK_NUM6 = 54, //6		
            VK_NUM7 = 55, //7		
            VK_NUM8 = 56, //8		
            VK_NUM9 = 57, //9		
            VK_A = 65, //A		
            VK_B = 66, //B		
            VK_C = 67, //C		
            VK_D = 68, //D		
            VK_E = 69, //E		
            VK_F = 70, //F		
            VK_G = 71, //G		
            VK_H = 72, //H		
            VK_I = 73, //I		
            VK_J = 74, //J		
            VK_K = 75, //K		
            VK_L = 76, //L		
            VK_M = 77, //M		
            VK_N = 78, //N		
            VK_O = 79, //O		
            VK_P = 80, //P		
            VK_Q = 81, //Q		
            VK_R = 82, //R		
            VK_S = 83, //S		
            VK_T = 84, //T		
            VK_U = 85, //U		
            VK_V = 86, //V		
            VK_W = 87, //W		
            VK_X = 88, //X		
            VK_Y = 89, //Y		
            VK_Z = 90, //Z		
            VK_NUMPAD0 = 96, //0		
            VK_NUMPAD1 = 97, //1		
            VK_NUMPAD2 = 98, //2		
            VK_NUMPAD3 = 99, //3		
            VK_NUMPAD4 = 100, //4		
            VK_NUMPAD5 = 101, //5		
            VK_NUMPAD6 = 102, //6		
            VK_NUMPAD7 = 103, //7		
            VK_NUMPAD8 = 104, //8		
            VK_NUMPAD9 = 105, //9		
            VK_NULTIPLY = 106,
            VK_ADD = 107,
            VK_SEPARATOR = 108,
            VK_SUBTRACT = 109,
            VK_DECIMAL = 110,
            VK_DIVIDE = 111,
            VK_F1 = 112,
            VK_F2 = 113,
            VK_F3 = 114,
            VK_F4 = 115,
            VK_F5 = 116,
            VK_F6 = 117,
            VK_F7 = 118,
            VK_F8 = 119,
            VK_F9 = 120,
            VK_F10 = 121,
            VK_F11 = 122,
            VK_F12 = 123,

        }
    }
}
