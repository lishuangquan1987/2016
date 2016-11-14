using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using Microsoft.Office.Interop.Word;
using Microsoft.Office;
using Microsoft.Office.Interop;
using System.Reflection;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WordReport
{
    public class TestReport
    {

        [DllImport("shell32.dll")]
        public static extern int ShellExecute(IntPtr hwnd, String lpszOp, String lpszFile, String lpszParams, String lpszDir, int FsShowCmd);

        Microsoft.Office.Interop.Word.Application wordApp = new Application();
        Microsoft.Office.Interop.Word.Document wordDoc;

        StringBuilder longstr = new StringBuilder();
        string strcontent = "";
        object start = Type.Missing;
        object end = Type.Missing;
        object missingvalue = Type.Missing;

        public TestReport()
        { 
        }

        ~TestReport()
        {
            //foreach (Process pro in Process.GetProcesses())
            //{
            //    if (pro.ProcessName.Trim() == "WINWORD")
            //        pro.Kill();
            //}
        }

        /// <summary>
        /// 生成word测试报告
        /// </summary>
        public void CreateWordReport()
        {
            object nothing = Missing.Value;
            wordDoc = wordApp.Documents.Add(ref nothing, ref nothing, ref nothing, ref nothing);
            //页面参数设置
            wordApp.ActiveDocument.PageSetup.SectionStart = WdSectionStart.wdSectionContinuous;//节的起始位置：新建页

            object Unit = Microsoft.Office.Interop.Word.WdUnits.wdStory;
            object Extend = Microsoft.Office.Interop.Word.WdMovementType.wdMove;

            //wordDoc.ActiveWindow.Selection.EndKey(ref Unit, ref Extend);
            //wordDoc.ActiveWindow.Selection.TypeParagraph();

            #region 标题部分

            strcontent = "中国人民解放军六一一九五部队第三计量站\n";
            InsertContent(WdParagraphAlignment.wdAlignParagraphCenter, strcontent, 16, 1, "宋体",0);//三号
            strcontent = "The third Metrology Station of the PLA Unit 61195 \n";
            InsertContent(WdParagraphAlignment.wdAlignParagraphCenter, strcontent, 10.5f, 0, "Times New Roman", 0);//五号

            strcontent = "测 试 报 告\n";
            InsertContent(WdParagraphAlignment.wdAlignParagraphCenter, strcontent, 36, 10, "隶书",0);//小初
            strcontent = "Test Certificate\n\r";
            InsertContent(WdParagraphAlignment.wdAlignParagraphCenter, strcontent, 10.5f, 0, "宋体", 0);//五号

            strcontent = "证书编号：";
            InsertContent(WdParagraphAlignment.wdAlignParagraphLeft, strcontent, 12, 0, "黑体",0);
            strcontent = "RX12174\n";
            InsertContent(WdParagraphAlignment.wdAlignParagraphLeft, strcontent, 12, 0, "Times New Roman",0);
            strcontent = "Certificate No.\n\r\r\r";
            InsertContent(WdParagraphAlignment.wdAlignParagraphLeft, strcontent, 9.0f, 0, "Times New Roman", 1);//小五

            #endregion 

            #region 添加第一个表格

            start = wordDoc.Content.End - 1;
            ///绘制表格
            AddTables(2, 1, "0.8", 10.5f);//两行，一列
            AddTables(2, 2, "0.8", 10.5f);//两行，两列

            //[1,1]
            InsertContToCell(1, WdParagraphAlignment.wdAlignParagraphLeft, 1, 1, "送检单位：   \nApplicant", "宋体", 10.5f, 0, 0);
            //指定内容
            end = wordDoc.Content.End - 5;
            start = int.Parse(end.ToString()) - 16;
            SetStyles(WdParagraphAlignment.wdAlignParagraphLeft, "Times New Roman", 9.0f, 0, 1);

            start = wordDoc.Content.End - 10;
            //[2,1]
            InsertContToCell(1, WdParagraphAlignment.wdAlignParagraphLeft, 2, 1, "地址：北京市\nAddres", "宋体", 10.5f, 0, 0);
            end = wordDoc.Content.End - 9;
            start = int.Parse(end.ToString()) - 6;
            SetStyles(WdParagraphAlignment.wdAlignParagraphLeft, "Times New Roman", 9.0f, 0, 1);

            start = wordDoc.Content.End - 1;
            //[3,1]
            InsertContToCell(1, WdParagraphAlignment.wdAlignParagraphLeft, 3, 1, "仪器名称：超短波数字化接收机\nInstrument name", "宋体", 10.5f, 0, 0);
            //指定内容
            end = wordDoc.Content.End - 7;
            start = int.Parse(end.ToString()) - 15;
            SetStyles(WdParagraphAlignment.wdAlignParagraphLeft, "Times New Roman", 9.0f, 0, 1);


            start = wordDoc.Content.End - 1;
            //[3,2]
            InsertContToCell(1, WdParagraphAlignment.wdAlignParagraphLeft, 3, 2, "制造商：常州无线电厂\nManufacturer", "宋体", 10.5f, 0, 0);
            //指定内容
            end = wordDoc.Content.End - 6;
            start = int.Parse(end.ToString()) - 12;
            SetStyles(WdParagraphAlignment.wdAlignParagraphLeft, "Times New Roman", 9.0f, 0, 1);

            start = wordDoc.Content.End - 1;
            //[4,1]
            InsertContToCell(1, WdParagraphAlignment.wdAlignParagraphLeft, 4, 1, "型号：SSC018A\nType", "宋体", 10.5f, 0, 0);
            //指定内容
            end = wordDoc.Content.End - 4;
            start = int.Parse(end.ToString()) - 4;
            SetStyles(WdParagraphAlignment.wdAlignParagraphLeft, "Times New Roman", 9.0f, 0, 1);
         
            start = wordDoc.Content.End - 1;
            //[4,2]
            InsertContToCell(1, WdParagraphAlignment.wdAlignParagraphLeft, 4, 2, "编号：08004\nNo.", "宋体", 10.5f, 0, 0);
            //指定内容
            end = wordDoc.Content.End - 3;
            start = int.Parse(end.ToString()) - 3;
            SetStyles(WdParagraphAlignment.wdAlignParagraphLeft, "Times New Roman", 9.0f, 0, 1);

            #endregion
            //页首插入行
            wordDoc.ActiveWindow.Selection.TypeParagraph();
            wordDoc.ActiveWindow.Selection.EndKey(ref Unit, ref Extend);
            wordDoc.ActiveWindow.Selection.TypeParagraph();

            start = wordDoc.Content.End - 1;
            end = start;
            strcontent = "\r                                    \r\r\r\r";
            InsertContent(WdParagraphAlignment.wdAlignParagraphLeft, strcontent, 10.5f, 0, "Times New Roman", 0);//小五

            #region 添加第二个表格

            AddTables(3, 2, "0.8", 10.5f);

            //[1,1]
            InsertContToCell(2, WdParagraphAlignment.wdAlignParagraphLeft, 1, 1, "测试人：\nOperato", "宋体", 10.5f, 0, 0);
            //指定内容
            end = wordDoc.Content.End - 9;
            start = int.Parse(end.ToString()) - 9;
            SetStyles(WdParagraphAlignment.wdAlignParagraphLeft, "Times New Roman", 9.0f, 0, 1);

            start = wordDoc.Content.End - 1;
            //[1,2]
            InsertContToCell(2, WdParagraphAlignment.wdAlignParagraphLeft, 1, 2, "发证日期：" + DateTime.Now.ToLongDateString() + "\nIssued date", "宋体", 10.5f, 0, 0);
            //指定内容
            end = wordDoc.Content.End - 8;
            start = int.Parse(end.ToString()) - 12;
            SetStyles(WdParagraphAlignment.wdAlignParagraphLeft, "Times New Roman", 9.0f, 0, 1);

            start = wordDoc.Content.End - 1;
            //[2,1]
            InsertContToCell(2, WdParagraphAlignment.wdAlignParagraphLeft, 2, 1, "审核员：\nInspector", "宋体", 10.5f, 0, 0);
            //指定内容
            end = wordDoc.Content.End - 7;
            start = int.Parse(end.ToString()) - 10;
            SetStyles(WdParagraphAlignment.wdAlignParagraphLeft, "Times New Roman", 9.0f, 0, 1);

            start = wordDoc.Content.End - 1;
            //[3,1]
            InsertContToCell(2, WdParagraphAlignment.wdAlignParagraphLeft, 3, 1, "签发人：\nDirector", "宋体", 10.5f, 0, 0);
            //指定内容
            end = wordDoc.Content.End - 4;
            start = int.Parse(end.ToString()) - 8;
            SetStyles(WdParagraphAlignment.wdAlignParagraphLeft, "Times New Roman", 9.0f, 0, 1);

            start = wordDoc.Content.End - 1;
            //[3,2]
            InsertContToCell(2, WdParagraphAlignment.wdAlignParagraphLeft, 3, 2, "发证单位：(专用章)\nIssued By (stamp)", "宋体", 10.5f, 0, 0);
            //指定内容
            end = wordDoc.Content.End - 3;
            start = int.Parse(end.ToString()) - 17;
            SetStyles(WdParagraphAlignment.wdAlignParagraphLeft, "Times New Roman", 9.0f, 0, 1);//小五

            start = wordDoc.Content.End - 1;
            end = start;
            strcontent = "\r\r\r\r";
            InsertContent(WdParagraphAlignment.wdAlignParagraphLeft, strcontent, 10.5f, 0, "Times New Roman", 0);


            #endregion

            #region 联系方式
            start = wordDoc.Content.End - 1;
            end = start;
            strcontent = "通信地址(Add):北京市5102信箱201号 (5102-201,Beijing)             邮编(Post Code):100094\r";
            InsertContent(WdParagraphAlignment.wdAlignParagraphLeft, strcontent, 9.0f, 0, "Times New Roman", 0);

            start = int.Parse(start.ToString()) - 71;
            end = int.Parse(start.ToString()) + 3;
            SetStyles(WdParagraphAlignment.wdAlignParagraphLeft, "Times New Roman", 9.0f, 0, 1);//小五

            start = wordDoc.Content.End - 19;
            end = int.Parse(start.ToString()) + 9;
            SetStyles(WdParagraphAlignment.wdAlignParagraphLeft, "Times New Roman", 9.0f, 0, 1);//小五

            start = wordDoc.Content.End - 1;
            end = start;
            strcontent = "联系电话(Tel):010-66324147,010-66324148                           传真(Fax):010-66766671\r\n";
            InsertContent(WdParagraphAlignment.wdAlignParagraphLeft, strcontent, 9.0f, 0, "Times New Roman", 0);

            start = int.Parse(start.ToString()) - 78;
            end = int.Parse(start.ToString()) + 3;
            SetStyles(WdParagraphAlignment.wdAlignParagraphLeft, "Times New Roman", 9.0f, 0, 1);//小五

            start = wordDoc.Content.End - 19;
            end = int.Parse(start.ToString()) + 3;
            SetStyles(WdParagraphAlignment.wdAlignParagraphLeft, "Times New Roman", 9.0f, 0, 1);//小五

            #endregion

            //插入分页符
            InsertBreak();

            #region 第二页
            //首行缩进
            FirstLineIndent(25.1f);
            start = wordDoc.Content.End - 1;
            end = start;
            longstr.Append("\n本计量站于1992年经原国防科工委考核认可成立（认可证书号：1992国防计认字第152号）");
            longstr.Append("，并于2010年通过中国人民解放军总装备部军用实验室的认可（认可证书号：校/测[2011-05]。\n");
            InsertContent(WdParagraphAlignment.wdAlignParagraphLeft, longstr.ToString(), 10.5f, 0, "宋体", 0);


            //取消首行缩进
            FirstLineIndent(0f);
            start = wordDoc.Content.End - 1;
            end = start;
            strcontent = "   ";
            InsertContent(WdParagraphAlignment.wdAlignParagraphLeft, strcontent, 10.5f, 0, "Times New Roman", 0);

            start = wordDoc.Content.End - 1;
            end = start;
            longstr.Remove(0, longstr.Length);
            longstr.Append("This metrology station was accredited by the former Committee of Science and Technology Industry of ");
            longstr.Append("National Defense and established in 1992 (accreditation Certificate No.:1992 guo fang ji ren zi No.152). In ");
            longstr.Append("2010,the station was accredited by the PLA about the laboratory for the army (accreditation Certificate No.: ");
            longstr.Append("Jiao/Ce[ 2011-05].\r\n");
            InsertContent(WdParagraphAlignment.wdAlignParagraphLeft, longstr.ToString(), 9.0f, 0, "Times New Roman", 1);

            start = wordDoc.Content.End - 1;
            end = start;
            strcontent = "     \r\r";
            InsertContent(WdParagraphAlignment.wdAlignParagraphLeft, strcontent, 10.5f, 0, "Times New Roman", 0);


            start = wordDoc.Content.End - 1;
            end = start;
            strcontent = "测试中使用的主要测量设备（Equipments used in the test）";
            InsertContent(WdParagraphAlignment.wdAlignParagraphLeft, strcontent, 10.5f, 0, "宋体", 0);

            start = int.Parse(start.ToString()) - 28;
            end = int.Parse(start.ToString()) + 27;
            SetStyles(WdParagraphAlignment.wdAlignParagraphLeft, "Times New Roman", 9.0f, 0, 1);//小五


            #region 第三个表格
            //添加表格
            AddTables(7, 5, "0.8", 10.5f);
            ///设置单元格剧中
            for (int i = 1; i < 8; i++)
            {
                for (int j = 1; j < 6; j++)
                {
                    wordDoc.Tables[3].Cell(i, j).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                }
            }

            SetColumnsWidth();

            InsertContToCell(3, 1, 1, "名称（Name）", WdParagraphAlignment.wdAlignParagraphCenter, 4, 44, WdColor.wdColorBlack, "Times New Roman", 0, 10.5f, 1);

            InsertContToCell(3, 1, 2, "型号（Type）", WdParagraphAlignment.wdAlignParagraphCenter, 4, 43, WdColor.wdColorBlack, "Times New Roman", 0, 10.5f, 1);

            InsertContToCell(3, 1, 3, "编号(No.)", WdParagraphAlignment.wdAlignParagraphCenter, 3, 42, WdColor.wdColorBlack, "Times New Roman", 0, 10.5f, 1);

            InsertContToCell(3, 1, 4, "证书号\r(Cert. No.)", WdParagraphAlignment.wdAlignParagraphCenter, 9, 41, WdColor.wdColorBlack, "Times New Roman", 0, 10.5f, 1);
            end = wordDoc.Content.End - 52;
            start = int.Parse(end.ToString()) - 3;
            SetStyles(WdParagraphAlignment.wdAlignParagraphCenter, "宋体", 10.5f, 0, 0);

            InsertContToCell(3, 1, 5, "有效期至\r（Cal Due Date）", WdParagraphAlignment.wdAlignParagraphCenter, 12, 40, WdColor.wdColorBlack, "Times New Roman", 0, 10.5f, 1);
            end = wordDoc.Content.End - 56;
            start = int.Parse(end.ToString()) - 4;
            SetStyles(WdParagraphAlignment.wdAlignParagraphCenter, "宋体", 10.5f, 0, 0);
            //第二行
            InsertContToCell(3, 2, 1, "信号发生器", WdParagraphAlignment.wdAlignParagraphLeft, 6, 36, WdColor.wdColorRed, "宋体", 0, 10.5f, 0);
            InsertContToCell(3, 2, 2, "8648B", WdParagraphAlignment.wdAlignParagraphLeft, 6, 35, WdColor.wdColorRed, "宋体", 0, 10.5f, 0);
            InsertContToCell(3, 2, 3, "3847U02406", WdParagraphAlignment.wdAlignParagraphCenter, 11, 34, WdColor.wdColorRed, "宋体", 0, 10.5f, 0);
            InsertContToCell(3, 2, 4, "SG12026", WdParagraphAlignment.wdAlignParagraphCenter, 8, 33, WdColor.wdColorRed, "宋体", 0, 10.5f, 0);
            InsertContToCell(3, 2, 5, "2014.06.05", WdParagraphAlignment.wdAlignParagraphCenter, 11, 32, WdColor.wdColorRed, "宋体", 0, 10.5f, 0);

            //第三行
            InsertContToCell(3, 3, 1, "信号发生器", WdParagraphAlignment.wdAlignParagraphLeft, 6, 31, WdColor.wdColorRed, "宋体", 0, 10.5f, 0);
            InsertContToCell(3, 3, 2, "E4432B", WdParagraphAlignment.wdAlignParagraphLeft, 6, 30, WdColor.wdColorRed, "宋体", 0, 10.5f, 0);
            InsertContToCell(3, 3, 3, "GB40050869", WdParagraphAlignment.wdAlignParagraphLeft, 11, 29, WdColor.wdColorRed, "宋体", 0, 10.5f, 0);
            InsertContToCell(3, 3, 4, "SG12024", WdParagraphAlignment.wdAlignParagraphCenter, 8, 28, WdColor.wdColorRed, "宋体", 0, 10.5f, 0);
            InsertContToCell(3, 3, 5, "2013.06.05", WdParagraphAlignment.wdAlignParagraphCenter, 11, 27, WdColor.wdColorRed, "宋体", 0, 10.5f, 0);

            //第四行
            InsertContToCell(3, 4, 1, "频谱分析仪", WdParagraphAlignment.wdAlignParagraphLeft, 6, 25, WdColor.wdColorRed, "宋体", 0, 10.5f, 0);
            InsertContToCell(3, 4, 2, "HP8563E", WdParagraphAlignment.wdAlignParagraphLeft, 7, 24, WdColor.wdColorRed, "宋体", 0, 10.5f, 0);
            InsertContToCell(3, 4, 3, "3751A08296", WdParagraphAlignment.wdAlignParagraphLeft, 11, 23, WdColor.wdColorRed, "宋体", 0, 10.5f, 0);
            InsertContToCell(3, 4, 4, "SA12042", WdParagraphAlignment.wdAlignParagraphCenter, 8, 22, WdColor.wdColorRed, "宋体", 0, 10.5f, 0);
            InsertContToCell(3, 4, 5, "2013.06.05", WdParagraphAlignment.wdAlignParagraphCenter, 11, 21, WdColor.wdColorRed, "宋体", 0, 10.5f, 0);


            #endregion
            strcontent = "标准装置的不确定度：\r";
            InsertContent2(WdParagraphAlignment.wdAlignParagraphLeft, strcontent, 10.5f, 0, "宋体", 0,WdColor.wdColorBlack);

            strcontent = "Uncertainty of measurement standard\r";
            InsertContent2(WdParagraphAlignment.wdAlignParagraphLeft, strcontent, 9.0f, 0, "Times New Roman", 1, WdColor.wdColorBlack);

            FirstLineIndent(25.1f);
            strcontent = "频率测量准确度：1×10-8\r";
            InsertContent2(WdParagraphAlignment.wdAlignParagraphLeft, strcontent, 10.5f, 0, "宋体", 0, WdColor.wdColorRed);

            end = wordDoc.Content.End - 2;
            start = int.Parse(end.ToString()) - 6;
            SetStyles(WdParagraphAlignment.wdAlignParagraphLeft, "Times New Roman", 10.5f, 0, 0);
            int s = wordDoc.Content.End - 4;
            int e = s + 2;
            SetStyles(s, e);

            strcontent = "电平准确度：±0.5dB\r";
            InsertContent2(WdParagraphAlignment.wdAlignParagraphLeft, strcontent, 10.5f, 0, "宋体", 0, WdColor.wdColorRed);
            end = wordDoc.Content.End - 2;
            start = int.Parse(end.ToString()) - 6;
            SetStyles(WdParagraphAlignment.wdAlignParagraphLeft, "Times New Roman", 10.5f, 0, 0);

            strcontent = "失真测试准确度：±1dB\r\r";
            InsertContent2(WdParagraphAlignment.wdAlignParagraphLeft, strcontent, 10.5f, 0, "宋体", 0, WdColor.wdColorRed);
            end = wordDoc.Content.End - 3;
            start = int.Parse(end.ToString()) - 4;
            SetStyles(WdParagraphAlignment.wdAlignParagraphLeft, "Times New Roman", 10.5f, 0, 0);
            
            //取消首行缩进
            FirstLineIndent(0f);

            strcontent = "测试所依据的技术文件或者校准方法：\r";
            InsertContent2(WdParagraphAlignment.wdAlignParagraphLeft, strcontent, 10.5f, 0, "宋体", 0, WdColor.wdColorBlack);

            strcontent = "Reference document or methods for test\r";
            InsertContent2(WdParagraphAlignment.wdAlignParagraphLeft, strcontent, 9.0f, 0, "Times New Roman", 1, WdColor.wdColorBlack);

            strcontent = "\rGB/T6394-1995《短波单边带接收机电性能测量方法》\r";
            InsertContent2(WdParagraphAlignment.wdAlignParagraphLeft, strcontent, 10.5f, 0, "宋体", 0, WdColor.wdColorBlack);
            strcontent = "GJB4210.1-2001《军用无线电通用设备通用检验验收规程（超短波电台）》\r";
            InsertContent2(WdParagraphAlignment.wdAlignParagraphLeft, strcontent, 10.5f, 0, "宋体", 0, WdColor.wdColorBlack);
            strcontent = "GJB4264-2001《超短波通信侦察系统通用规范》\r\r\r";
            InsertContent2(WdParagraphAlignment.wdAlignParagraphLeft, strcontent, 10.5f, 0, "宋体", 0, WdColor.wdColorBlack);

            strcontent = "测试的环境条件\r";
            InsertContent2(WdParagraphAlignment.wdAlignParagraphLeft, strcontent, 10.5f, 0, "宋体", 0, WdColor.wdColorBlack);

            strcontent = "Environmental condition in the test";
            InsertContent2(WdParagraphAlignment.wdAlignParagraphLeft, strcontent, 9.0f, 0, "Times New Roman", 1, WdColor.wdColorBlack);

            #region 添加第四个表

            strcontent = "\r";
            InsertContent2(WdParagraphAlignment.wdAlignParagraphLeft, strcontent, 9.0f, 0, "Times New Roman", 0, WdColor.wdColorBlack);
            AddTables(1, 2, "0.5", 10.5f);

            InsertContToCell(4, 1, 1, "温度：19℃", WdParagraphAlignment.wdAlignParagraphLeft, 6, 4, WdColor.wdColorBlack, "宋体", 0, 10.5f, 0);
            InsertContToCell(4, 1, 2, "相对湿度：22%", WdParagraphAlignment.wdAlignParagraphLeft, 8, 3, WdColor.wdColorBlack, "宋体", 0, 10.5f, 0);

            strcontent = "\r本结果仅对所测试样品有效。证书未经本站批准，不准部分复印。\r";
            InsertContent2(WdParagraphAlignment.wdAlignParagraphLeft, strcontent, 9.0f, 0, "宋体", 0, WdColor.wdColorBlack);
            //首行缩进设置
            FirstLineIndent(12.5f);
            strcontent = "These results apply only to the tested sample. The certificates must not be partially duplicated without permission from the Station at which the calibration has been conducted.\n";
            InsertContent2(WdParagraphAlignment.wdAlignParagraphLeft, strcontent, 7.5f, 0, "Times New Roman", 1, WdColor.wdColorBlack);
            //FirstLineIndent(0f);

            //插入分页符
            InsertBreak();

            #endregion

            #endregion

            #region 第三页  检测结果
            FirstLineIndent(0f);
            //固定1
            end = wordDoc.Content.End - 1;
            start = end;
            strcontent = "1.外观及功能性检查\r";
            InsertContent2(WdParagraphAlignment.wdAlignParagraphLeft, strcontent, 12f, 1, "宋体", 0, WdColor.wdColorBlack);

            FirstLineIndent(32.5f);
            end = wordDoc.Content.End - 1;
            start = end;
            strcontent = "外观良好、功能正常\r";
            InsertContent2(WdParagraphAlignment.wdAlignParagraphLeft, strcontent, 12f, 0, "宋体", 0, WdColor.wdColorBlack);
            FirstLineIndent(0f);

            //固定2
            end = wordDoc.Content.End - 1;
            start = end;
            strcontent = "2.频率范围\r";
            InsertContent2(WdParagraphAlignment.wdAlignParagraphLeft, strcontent, 12f, 1, "宋体", 0, WdColor.wdColorBlack);

            FirstLineIndent(32.5f);
            end = wordDoc.Content.End - 1;
            start = end;
            strcontent = "20.00000MHz～1000.00000MHz\r";
            InsertContent2(WdParagraphAlignment.wdAlignParagraphLeft, strcontent, 12f, 0, "宋体", 0, WdColor.wdColorBlack);
            FirstLineIndent(0f);

            //固定3
            end = wordDoc.Content.End - 1;
            start = end;
            strcontent = "3.频率分辨率\r";
            InsertContent2(WdParagraphAlignment.wdAlignParagraphLeft, strcontent, 12f, 1, "宋体", 0, WdColor.wdColorBlack);

            FirstLineIndent(32.5f);
            end = wordDoc.Content.End - 1;
            start = end;
            strcontent = "最小调谐步进或分辨率实测值为 10 Hz   \r";
            InsertContent2(WdParagraphAlignment.wdAlignParagraphLeft, strcontent, 12f, 0, "宋体", 0, WdColor.wdColorBlack);
            FirstLineIndent(0f);

            //固定4
            end = wordDoc.Content.End - 1;
            start = end;
            strcontent = "4.BFO范围\r";
            InsertContent2(WdParagraphAlignment.wdAlignParagraphLeft, strcontent, 12f, 1, "宋体", 0, WdColor.wdColorBlack);

            FirstLineIndent(32.5f);
            end = wordDoc.Content.End - 1;
            start = end;
            strcontent = "-5000Hz～+5000Hz\r";
            InsertContent2(WdParagraphAlignment.wdAlignParagraphLeft, strcontent, 12f, 0, "宋体", 0, WdColor.wdColorBlack);
            FirstLineIndent(0f);




            #endregion

            #region 页眉、页脚
            wordApp.ActiveWindow.View.Type = WdViewType.wdOutlineView;
            wordApp.ActiveWindow.View.SeekView = WdSeekView.wdSeekPrimaryHeader;

            wordApp.ActiveWindow.ActivePane.Selection.ParagraphFormat.Borders[WdBorderType.wdBorderBottom].LineStyle = WdLineStyle.wdLineStyleNone;
            wordApp.ActiveWindow.ActivePane.Selection.ParagraphFormat.Borders[WdBorderType.wdBorderBottom].Visible = false;


            //获取文档的页数
            object oMissing = System.Reflection.Missing.Value;
            int pages = wordDoc.ComputeStatistics(WdStatistic.wdStatisticPages, ref oMissing);


            //设置分节符
            //for (int i = 3; i <= pages; i++)
            //{
            //    Range range = GetPages(i);
            //    object oCollapseEnd = WdCollapseDirection.wdCollapseEnd;
            //    object oPageBreak = WdBreakType.wdSectionBreakContinuous;//分页符   
            //    range.Collapse(ref oCollapseEnd);
            //    range.InsertBreak(ref oPageBreak);
            //    range.Collapse(ref oCollapseEnd);
            //}

            //取消链接上一节。。
            int secs = wordDoc.Sections.Count;
            for (int p = 1; p <= secs; p++)
            {
                wordDoc.Sections[p].Headers[WdHeaderFooterIndex.wdHeaderFooterPrimary].LinkToPrevious = false;
                wordDoc.Sections[p].Footers[WdHeaderFooterIndex.wdHeaderFooterPrimary].LinkToPrevious = false;
            }

            string firstLine = "";
            string secondLine = "";

            object down =0;
            object up = 0;
            for (int iP = 1; iP <= pages; iP++)
            {
                switch (iP)
                {
                    case 1:
                        firstLine = "证书编号：RX12174                                              " + getPageDes(false, iP, pages);
                        secondLine = "\rCertificate No                                                        " + getPageDes(true, iP, pages);
                        wordApp.ActiveWindow.ActivePane.Selection.InsertAfter(firstLine);
                        wordApp.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;

                        wordApp.ActiveWindow.ActivePane.Selection.InsertAfter(secondLine);
                        wordApp.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                        wordApp.Selection.Font.Size = 10.5f;
                        wordApp.Selection.Font.Name = "Times New Roman";

                        wordApp.ActiveWindow.ActivePane.Selection.GoToNext(WdGoToItem.wdGoToSection);
                        break;
                    case 2:
                        wordApp.ActiveWindow.View.SeekView = WdSeekView.wdSeekCurrentPageHeader;
                        firstLine = "证书编号：RX12174                                              " + getPageDes(false, iP, pages);
                        secondLine = "\rCertificate No                                                        " + getPageDes(true, iP, pages);
                        wordApp.ActiveWindow.ActivePane.Selection.InsertAfter(firstLine);
                        wordApp.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;

                        wordApp.ActiveWindow.ActivePane.Selection.InsertAfter(secondLine);
                        wordApp.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                        wordApp.Selection.Font.Size = 10.5f;
                        wordApp.Selection.Font.Name = "Times New Roman";

                        wordApp.ActiveWindow.ActivePane.Selection.GoToNext(WdGoToItem.wdGoToSection);
                        break;
                    default :
                        wordApp.ActiveWindow.View.SeekView = WdSeekView.wdSeekCurrentPageHeader;
                        firstLine = "证书编号：RX12174                                              " + getPageDes(false, iP, pages);
                        secondLine = "\rCertificate No                                                       " + getPageDes(true, iP, pages);
                        wordApp.ActiveWindow.ActivePane.Selection.InsertAfter(firstLine);
                        wordApp.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;

                        wordApp.ActiveWindow.ActivePane.Selection.InsertAfter(secondLine + "\r");
                        wordApp.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;

                        wordApp.ActiveWindow.ActivePane.Selection.InsertAfter("测试结果\rTestResult");
                        wordApp.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                        wordApp.Selection.Font.Size = 10.5f;
                        wordApp.Selection.Font.Name = "Times New Roman";

                        //页脚设置
                        wordApp.ActiveWindow.View.SeekView = WdSeekView.wdSeekCurrentPageFooter;
                        firstLine = "测试人（签字）：                            审核员（签字）：";
                        secondLine = "\rOperator                                   Inspector ";
                        wordApp.ActiveWindow.ActivePane.Selection.InsertAfter(firstLine);
                        wordApp.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;

                        wordApp.ActiveWindow.ActivePane.Selection.InsertAfter(secondLine);
                        wordApp.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                        wordApp.Selection.Font.Italic = 1;
                        wordApp.Selection.Font.Size = 10.5f;
                        wordApp.Selection.Font.Name = "Times New Roman";

                        wordApp.ActiveWindow.ActivePane.Selection.GoToNext(WdGoToItem.wdGoToSection);
                        break;
                }


            }




            //关闭文档
            //object saveOption = WdSaveOptions.wdDoNotSaveChanges;
            //wordDoc.Close(ref nothing,ref nothing,ref nothing);
            //wordApp.Application.Quit(ref saveOption, ref nothing, ref nothing);

            //wordDoc = null;
            //wordApp = null;

            //ShellExecute(IntPtr.Zero,"open","c:\\new.doc","","",3);

            #endregion

            /*
            */




            wordApp.Visible = true;

        }
        /// <summary>
        /// 获取指定页的 Range。。。
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public Range GetPages(int pageIndex)
        {
            object objWhat = WdGoToItem.wdGoToPage;
            object objWhich = WdGoToDirection.wdGoToAbsolute;
            object oMissing = System.Reflection.Missing.Value;
            object objPage = pageIndex;
            Range range1 = wordDoc.GoTo(ref objWhat, ref objWhich, ref objPage, ref oMissing);
            Range range2 = range1.GoToNext(WdGoToItem.wdGoToPage);
            object objStart = range1.Start;
            object objEnd = range2.Start;

            if (range1.Start == range2.Start)
            {
                objEnd = wordDoc.Content.End;
            }
            else
            {
                objEnd = range2.Start - 1;
            }

            return wordDoc.Range(ref objStart, ref objEnd);
        }

        /// <summary>
        /// 各种文档格式设置
        /// </summary>
        private void PageSetup()
        {
            wordApp.ActiveDocument.PageSetup.LineNumbering.Active = 0;//行编号
            wordApp.ActiveDocument.PageSetup.Orientation = WdOrientation.wdOrientLandscape;//页面方向
            wordApp.ActiveDocument.PageSetup.TopMargin = wordApp.CentimetersToPoints(float.Parse("2.54"));//上页边距
            wordApp.ActiveDocument.PageSetup.BottomMargin = wordApp.CentimetersToPoints(float.Parse("2.54"));//下页边距


            wordApp.ActiveDocument.PageSetup.SectionStart = WdSectionStart.wdSectionContinuous;//节的起始位置：新建页
 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isEng"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private string getPageDes(bool isEng, int x, int y)
        {
            string strRet = "";
            if (isEng)
            {
                strRet = string.Format("Page {0:D} Of {1:D}", x, y);
            }
            else
            {
                strRet = string.Format("第 {0:D} 页 共 {1:D} 页", x, y);
            }
            return strRet;
        }

        /// <summary>
        /// 插入文本
        /// </summary>
        /// <param name="aligh">对齐方式</param>
        /// <param name="content">内容</param>
        /// <param name="fontsize">大小</param>
        /// <param name="bold">粗细</param>
        /// <param name="fontname">字体名称</param>
        /// <param name="ital">斜体</param>
        private void InsertContent(WdParagraphAlignment aligh, string content, float fontsize, int bold, string fontname,int ital)
        {
            wordDoc.Range(ref start, ref end).InsertAfter(content);
            end = wordDoc.Content.End;

            //设置样式
            SetStyles(aligh, fontname, fontsize, bold, ital);

            start = wordDoc.Content.End - 1;
            end = start;
        }
        /// <summary>
        /// 插入文本
        /// </summary>
        /// <param name="aligh"></param>
        /// <param name="content"></param>
        /// <param name="fontsize"></param>
        /// <param name="bold"></param>
        /// <param name="fontname"></param>
        /// <param name="ital"></param>
        private void InsertContent2(WdParagraphAlignment aligh, string content, float fontsize, int bold, string fontname, int ital,WdColor color)
        {
            start = wordDoc.Content.End - 1;
            end = start;
            wordDoc.Range(ref start, ref end).InsertAfter(content);
            end = wordDoc.Content.End;

            //设置样式
            SetStyles(aligh, fontname, fontsize, bold, ital,color);

            start = wordDoc.Content.End - 1;
            end = start;
        }

        /// <summary>
        /// 将文本插入到单元格
        /// </summary>
        /// <param name="tNo"></param>
        /// <param name="aligh"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="content"></param>
        /// <param name="fontname"></param>
        /// <param name="fontsize"></param>
        /// <param name="bold"></param>
        /// <param name="ital"></param>
        private void InsertContToCell(int tNo, WdParagraphAlignment aligh, int row, int col, string content, string fontname, float fontsize, int bold,int ital)
        {
            wordDoc.Tables[tNo].Cell(row, col).Range.Text = content;
            end = wordDoc.Content.End;

            SetStyles(aligh, fontname, fontsize, bold,ital);
        }

        /// <summary>
        /// 将文本插入到单元格
        /// </summary>
        /// <param name="tNo"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="content"></param>
        /// <param name="aligh"></param>
        /// <param name="startMod"></param>
        /// <param name="endMod"></param>
        /// <param name="color"></param>
        /// <param name="fontname"></param>
        /// <param name="bold"></param>
        /// <param name="fontsize"></param>
        /// <param name="ital"></param>
        private void InsertContToCell(int tNo,int row,int col,string content,WdParagraphAlignment aligh,int startMod,int endMod,WdColor color,string fontname,int bold,float fontsize,int ital)
        {
            start = wordDoc.Content.End - 1;

            wordDoc.Tables[tNo].Cell(row, col).Range.Text = content;
            end = wordDoc.Content.End - endMod;
            start = int.Parse(end.ToString()) - startMod;

            SetStyles(aligh, fontname, fontsize, bold, ital, color);
        }

        /// <summary>
        /// 设置文本格式
        /// </summary>
        /// <param name="aligh">对齐方式</param>
        /// <param name="fontname">字体名称</param>
        /// <param name="fontsize">大小</param>
        /// <param name="bold">粗细</param>
        /// <param name="ital">斜体</param>
        public void SetStyles(WdParagraphAlignment aligh, string fontname, float fontsize, int bold,int ital)
        {
            wordDoc.Range(ref start, ref end).ParagraphFormat.Alignment = aligh;
            wordDoc.Range(ref start, ref end).Font.Name = fontname;
            wordDoc.Range(ref start, ref end).Font.Size = fontsize;
            wordDoc.Range(ref start, ref end).Font.Bold = bold;
            wordDoc.Range(ref start, ref end).Font.Italic = ital;
            
        }

        /// <summary>
        /// 设置文本格式
        /// </summary>
        /// <param name="aligh"></param>
        /// <param name="fontname"></param>
        /// <param name="fontsize"></param>
        /// <param name="bold"></param>
        /// <param name="ital"></param>
        /// <param name="color"></param>
        public void SetStyles(WdParagraphAlignment aligh, string fontname, float fontsize, int bold, int ital,WdColor color)
        {
            wordDoc.Range(ref start, ref end).ParagraphFormat.Alignment = aligh;
            wordDoc.Range(ref start, ref end).Font.Name = fontname;
            wordDoc.Range(ref start, ref end).Font.Size = fontsize;
            wordDoc.Range(ref start, ref end).Font.Bold = bold;
            wordDoc.Range(ref start, ref end).Font.Italic = ital;
            wordDoc.Range(ref start, ref end).Font.Color = color;

        }

        /// <summary>
        /// 设置文本格式：上标
        /// </summary>
        /// <param name="startInd"></param>
        /// <param name="endInd"></param>
        public void SetStyles(int startInd,int endInd)
        {
            start = startInd;
            end = endInd;
            wordDoc.Range(ref start, ref end).Font.Superscript = 1;
        }

        /// <summary>
        /// 向文档中插入表格
        /// </summary>
        /// <param name="rowCount"></param>
        /// <param name="colCount"></param>
        /// <param name="rowsHight"></param>
        /// <param name="fontsize"></param>
        public void AddTables(int rowCount,int colCount,string rowsHight,float fontsize)
        {
            object location = wordDoc.Content.End - 1;
            Range rng2 = wordDoc.Range(ref location, ref location);
            wordDoc.Tables.Add(rng2, rowCount, colCount, ref missingvalue, ref missingvalue);
            int tableNum = wordDoc.Tables.Count;

            wordDoc.Tables[tableNum].Rows.HeightRule = Microsoft.Office.Interop.Word.WdRowHeightRule.wdRowHeightAtLeast;
            wordDoc.Tables[tableNum].Rows.Height = wordApp.CentimetersToPoints(float.Parse(rowsHight));
            wordDoc.Tables[tableNum].Range.Font.Size = fontsize;
            wordDoc.Tables[tableNum].Range.Font.Name = "宋体";
           
        }

        /// <summary>
        /// 设置列宽
        /// </summary>
        public void SetColumnsWidth()
        {
            int tableNum = wordDoc.Tables.Count;
            //float tbWidth = wordDoc.Tables[tableNum].Columns.Width;

            //wordDoc.Tables[tableNum].Columns.Width = 90.0f;
            wordDoc.Tables[tableNum].Columns[1].Width = 120.0f;
            wordDoc.Tables[tableNum].Columns[2].Width = 60.0f;
 
        }

        /// <summary>
        /// 插入分页符，即创建新页
        /// </summary>
        public void InsertBreak()
        {
            object nothing = Missing.Value;
            Microsoft.Office.Interop.Word.Paragraph para;
            para = wordDoc.Content.Paragraphs.Add(ref nothing);
            object pBreak = Microsoft.Office.Interop.Word.WdBreakType.wdSectionBreakNextPage;
            para.Range.InsertBreak(ref pBreak);
        }

        /// <summary>
        /// 首行缩进
        /// </summary>
        public void FirstLineIndent(float ind)
        {
            start = wordDoc.Content.End - 1;
            end = start;
            wordDoc.Range(ref start, ref end).ParagraphFormat.FirstLineIndent = ind;
        }

        /// <summary>
        /// 字体颜色设置
        /// </summary>
        public void FontColor(WdColor color)
        {
            wordDoc.Range(ref start, ref end).Font.Color = color;
 
        }

    }
}
