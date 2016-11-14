using System;
using System.Collections.Generic;
using System.Text;

namespace dllESDRegister
    {
    public class _Component_UART
        {
        public string Release_Day = "20100729";
        public string Version = "04";
        public bool CMD_Status;     // 傳送的狀況回應
        public int CMD_Counter;     // 一共有多少個指令陣列需要傳送
        public string[] CMD_Buffer = new string[100];         // 要傳送的指令暫存的記憶體
        public string[] RTN_Buffer = new string[512];         // 已接收的指令暫存的記憶體

        public byte[] CMD_Byte = new byte[12];   // 傳送Class內部的暫存
        public byte[] CMD_ByteACK;                   // 傳送Class內部的暫存
        public string CMD_String;                        // 傳送Class內部的暫存
        public string CMD_StringACK;                  // 傳送Class內部的暫存

        public string[] CMD_Debug = new string[100];
        public byte[] CMD_Debug1 = new byte[100];
        public string CMD_Debug2;
        public string CMD_Debug3;
        public byte[] CMD_Debug4 = new byte[12];
        public byte[] CMD_Debug5 = new byte[12];


        public string[] CMD_Receiver_Command = new string[12];
        public string[] CMD_Receiver_Parameter = new string[200];
        public int CMD_Receiver_Count = 0;

        public string[] CMD_Transfer_CodingTx = new string[12];
        public string[] CMD_Transfer_CodingRx = new string[12];
        public string[] CMD_Transfer_Parameter = new string[200];
        public int CMD_Transfer_Count = 0;

        public string CMD_WaitACK_Time;        // 最大等待接收時間
        public string CMD_DelayByte;             // "F6" 每一個BYTE之間的延遲設定
        public string CMD_DelayReturnByte;   // "F3" 每一組資料傳送與回應之間的延遲時間
        public string CMD_DelayTime;          // 指令傳送接收完畢後,延遲時間

        public string CMD_ACKResult;         // 狀況回應
        }
    }
