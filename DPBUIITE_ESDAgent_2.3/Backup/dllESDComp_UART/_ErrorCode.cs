using System;
using System. Collections. Generic;
using System. Text;

namespace dllESDComp_UART
    {
    public class _ErrorCode
        {
        public string EESD00 = "EESD00:Define ESD Board被其他未知程式占用";
        public string EESD01 = "EESD01:Define 關閉ESD傳輸埠失敗";
        public string EESD02 = "EESD02:Define 串口設定值不符合該設備";
        public string EESD03 = "EESD03:Define ESD Board參數錯誤";
        public string EESD04 = "EESD04:Define 通訊開啟中,請關閉該通訊,始可開始設定";

        public string EESD05 = "EESD05:Open ESD Board被其他未知程式占用";
        public string EESD06 = "EESD06:Open 關閉ESD傳輸埠失敗";
        public string EESD07 = "EESD07:Open 串口設定值不符合該設備";
        public string EESD08 = "EESD08:Open ESD Board參數錯誤";
        public string EESD09 = "EESD09:Open 通訊開啟中,請關閉該通訊,始可開始設定";

        public string EESD10 = "EESD10:Close ESD Board被其他未知程式占用";
        public string EESD11 = "EESD11:Close 關閉ESD傳輸埠失敗";
        public string EESD12 = "EESD12:Close 串口設定值不符合該設備";
        public string EESD13 = "EESD13:Close ESD Board參數錯誤";
        public string EESD14 = "EESD14:Close 通訊開啟中,請關閉該通訊,始可開始設定";

        public string EESD15 = "EESD10:Transfer ESD Board被其他未知程式占用";
        public string EESD16 = "EESD11:Transfer 關閉ESD傳輸埠失敗";
        public string EESD17 = "EESD12:Transfer 串口設定值不符合該設備";
        public string EESD18 = "EESD13:Transfer ESD Board參數錯誤";
        public string EESD19 = "EESD14:Transfer 通訊開啟中,請關閉該通訊,始可開始設定";

        public string EESD20 = "EESD20:尚未收到指令,指令回應區域: [NULL] 傳輸Fail";
        public string EESD21 = "EESD21:傳輸超過系統設定時間時間";


        public string EESD30 = "EESD30:回應不是B0";
        public string EESD31 = "EESD31:參數長度不等於參數空間長度";
        public string EESD32 = "EESD32:回應錯誤";
        public string EESD33 = "EESD33:Checksum 錯誤";
        public string EESD34 = "EESD34:回應不是B2";



        }
    }
