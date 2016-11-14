using System;
using System.Collections.Generic;
using System.Text;

namespace dllConst
{
    public class C_PLC
    {
        public class Mode
        {
            public const int C_PLC_Action_Mode = 0x00;
            public const int C_PLC_Wrong_Action = 0x01;
            public const int C_PLC_Testing_Mode = 0x02;
            public const int C_PLC_Standby_Mode = 0x03;
        }

        public class FactoryCMD
        {
            public const byte _ACK = 0xB0;
            public const byte _Non_ACK = 0xB1;
            public const byte _ACKPARA = 0xB2;
            public const byte _Pre_ACK = 0xB3;
            public const byte _NoSupport = 0xB4;
            public const byte _PCACK = 0x30;
            public const byte _PCNACK = 0x31;
        }

        public class ACT
        {
            public const int aFail = 0x08;
            public const int aTesting = 0x09;
            public const int aWrongStatus = 0x0a;
            public const int aPLCAction_Mode = 0x0b;
            public const int aStandby = 0x0c;
        }

        public class Factory_Protocol
        {
            public const string _DelayReturnByte = "50 F3 01 %1 00 00 00 00 00 00 00 FE";   //資料串 [去 & 回] 之前的延遲 v
            public const string _DelayByte = "50 F6 01 %1 00 00 00 00 00 00 00 FE";    //[Byte & Byte] 之間的延遲 v
            public const string _Debug = "50 00 01 %1 00 00 00 00 00 00 00 FE";
            public const string _I2C_Checkdata = "50 F0 01 %1 00 00 00 00 00 00 00 FE";
            public const string _SerialNumber_Location = "50 F1 01 %1 00 00 00 00 00 00 00 FE";
            public const string _SourcePath = "50 F2 01 %1 00 00 00 00 00 00 00 FE";
            public static string _EEPROM_ID = "50 F5 01 %1 00 00 00 00 00 00 00 FE"; //EEPROM HW Address
            public static string _I2C_AutoFail = "50 FF 01 %1 00 00 00 00 00 00 00 FE"; //超過通訊時間自動判NG
            public static string _20100520 = "50 FE 01 %1 00 00 00 00 00 00 00 FE"; //新指令舊指令切換

            public static string _PCACK = "55 30 00 00 00 00 00 00 00 00 00 FE";
            public static string _PCNACK = "55 31 00 00 00 00 00 00 00 00 00 FE";
        }
    }
}
