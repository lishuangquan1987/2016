using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SpreadsheetGear;
using System.Windows.Forms;
using System.Drawing;

namespace Xiongxiaokang
{
   public class ExcelOperation
    {
        enum RowName
        {
            A = 1, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z
        }
        public static string GetRowNameByIndex(int index)
        {
            //if (index <= 26)
            //{
            //    return ((RowName)index).ToString();
            //}
            //int i = index % 26;//余数
            //int j = (index - i) / 26;//商
            ////获取商的值
            //string head = ((RowName)j).ToString();
            //string k = ((RowName)i).ToString();
            //return head + k;


            string head = "";
            string k = "";
            int i = index % 26;
            int j = (index - i) / 26;
            /*
             * 26:Z-->i:0;j:1
             * 52:AZ-->i:0;j:2
             * 51:AY-->i:25;j:1
             * */
            if (j == 0)//表示index的值小于26；
            {
                head = ((RowName)index).ToString();
                return head;
            }
            else
            {
                if (i == 0)//表明是26的整数倍
                {
                    if (j != 1)
                    {
                        head = ((RowName)(j - 1)).ToString();
                        k = "Z";
                        return head + k;
                    }
                    else
                    {
                        return "Z";
                    }

                }
                else
                {
                    head = ((RowName)j).ToString();
                    k = ((RowName)i).ToString();
                    return head + k;
                }

            }

        }
        public static Chip[] ReadRowData(string path)
        {           
            Chip[] _chips;
            try
            {
                IWorkbook workbook = Factory.GetWorkbook(path);
                IWorksheet worksheet = workbook.Worksheets["Overview"];
                if (worksheet == null)
                {
                    ExDictionary dic = new ExDictionary();
                    dic["msg"] = "所载入的RowData格式不正确：没有Overview工作表！";
                    dic["color"] = Color.Red;
                    dic["nextline"] = true;
                    Notification.GetInstance().PostNotification("log", dic);
                    return null;
                }
                int height = worksheet.UsedRange.RowCount;
                int chips = height - 11;
                _chips = new Chip[chips];
                for (int i = 0; i < chips; i++)
                {
                    _chips[i] = new Chip();
                    //赋值
                    //int endCount = (int)RowName.B * 26 + (int)RowName.A;
                    int endCount = 59;
                    for (int j = 1; j <=endCount; j++)
                    {
                        
                        string address = GetRowNameByIndex(j) + (i + 12).ToString();
                        _chips[i][j-1] = worksheet.UsedRange.Cells[address].Value.ToString();                                            
                    }
                }
            }
            catch (Exception e)
            {
                ExDictionary dic = new ExDictionary();
                dic["msg"] = "信息:" + e.Message + "\r\n源:" + e.StackTrace;
                dic["color"] = Color.Red;
                dic["nextline"] = true;
                Notification.GetInstance().PostNotification("log", dic);
                _chips = null;
            }
            return _chips;
        }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="path">生成的文件路径</param>
       /// <param name="chips">源数据</param>
        public static bool Analysize(string path, Chip[] chips)
        {
            bool result = false;
            FileStream fs_create = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
            try
            {
                //1.获取有多少个chip
                var count = from i in chips select i[1];//选取所有的chipID
                var count_distinct = count.Distinct().ToArray();//对chipID去重,结果是数组。
                //2.通过文件流来创建workbook,注意最后要关闭。
               
                IWorkbook workbook = Factory.GetWorkbook();
                IWorksheet worksheet = (IWorksheet)workbook.Sheets[0];
                for (int i = 0; i < count_distinct.Length; i++)
                {
                    if (i == 0)
                        worksheet.Name = count_distinct[0];
                    else
                    {
                        IWorksheet next_worksheet = (IWorksheet)worksheet.CopyAfter(worksheet);
                        next_worksheet.Name = count_distinct[i];
                    }
                    IWorksheet currentworksheet = workbook.Worksheets[count_distinct[i]];
                    //分析数据
                    //1.搜索chipID为count_distinct[i]的所有chip对象。
                    var chip_group = from j in chips where j[1] == count_distinct[i] select j;
                    //2.对同一个chipID的所有chip对象进行分析。
                    var TemperatureMeasureds = (from j in chip_group select j[8]).ToArray();
                    //3.取最大温度量测值和最小温度量测值做比较
                    double[] temperatures = new double[TemperatureMeasureds.Length];
                    for (int k = 0; k < TemperatureMeasureds.Length; k++)
                    {
                        temperatures[k] = Convert.ToDouble(TemperatureMeasureds[k]);
                    }
                    double maxvalue = Enumerable.Max(temperatures);
                    double minvalue = Enumerable.Min(temperatures);
                    //4.搜索最大温度值的芯片与最小温度值的芯片：
                    var Max_chip = (from j in chip_group where Convert.ToDouble(j[8]) == maxvalue select j).ToArray()[0];
                    var Min_chip = (from j in chip_group where Convert.ToDouble(j[8]) == minvalue select j).ToArray()[0];
                    //得出需要的数据：
                    //Gain Resistance   14 L
                    //Imod_90mA  38 L
                    //Ith_Imod  17 L
                    //Pout_90mA 42 两个，一个高一个低 H L
                    //Reflection3rd Distance 23 L
                    //SMSR_90mA  57 L
                    //Vgain_90mA 34 L
                    //WVL_90mA 50 H L
                    IWorksheet current_worksheet = workbook.Worksheets[i];
                    current_worksheet.Cells["A1"].Value = "GAINR_L";
                    current_worksheet.Cells["B1"].Value = "Gain Resistance (Ohm)";
                    current_worksheet.Cells["C1"].Value = Min_chip[14];

                    current_worksheet.Cells["A2"].Value = "IMOD_90MA_L";
                    current_worksheet.Cells["B2"].Value = "Imod_90mA (mA)";
                    current_worksheet.Cells["C2"].Value = Min_chip[38];


                    current_worksheet.Cells["A3"].Value = "ITH_L";
                    current_worksheet.Cells["B3"].Value = "Ith_Imod (mA)";
                    current_worksheet.Cells["C3"].Value = Min_chip[17];

                    current_worksheet.Cells["A4"].Value = "POUT_90MA_H";
                    current_worksheet.Cells["B4"].Value = "Pout_90mA (mW)";
                    current_worksheet.Cells["C4"].Value = Max_chip[42];

                    current_worksheet.Cells["A5"].Value = "POUT_90MA_L";
                    current_worksheet.Cells["B5"].Value = "Pout_90mA (mW)";
                    current_worksheet.Cells["C5"].Value = Min_chip[42];

                    current_worksheet.Cells["A6"].Value = "REFCECTLON_D3_L";
                    current_worksheet.Cells["B6"].Value = "Reflection3rd Distance (K/A^3)";
                    current_worksheet.Cells["C6"].Value = Min_chip[23];

                    current_worksheet.Cells["A7"].Value = "SMSR_90MA_L";
                    current_worksheet.Cells["B7"].Value = "SMSR_90mA (dB)";
                    current_worksheet.Cells["C7"].Value = Min_chip[57];

                    current_worksheet.Cells["A8"].Value = "VGAIN_90MA_L";
                    current_worksheet.Cells["B8"].Value = Chip.properties[34];
                    current_worksheet.Cells["C8"].Value = Min_chip[34];

                    current_worksheet.Cells["A9"].Value = "WL_90MA_H";
                    current_worksheet.Cells["B9"].Value = Chip.properties[50];
                    current_worksheet.Cells["C9"].Value = Max_chip[50];

                    current_worksheet.Cells["A10"].Value = "WL_90MA_L";
                    current_worksheet.Cells["B10"].Value = Chip.properties[50];
                    current_worksheet.Cells["C10"].Value = Min_chip[50];


                }
                workbook.SaveToStream(fs_create, FileFormat.Excel8);
                
                result = true;
            }
            catch (Exception e)
            {
                ExDictionary dic = new ExDictionary();
                dic["msg"] ="异常："+ e.Message+"\r\n异常出现的地方："+e.StackTrace;
                dic["color"] = Color.Red;
                dic["nextline"] = true;
                Notification.GetInstance().PostNotification("log", dic);
                result = false;
            }
            finally
            {
                fs_create.Close();
            }
            return result;
        }
    }
}
