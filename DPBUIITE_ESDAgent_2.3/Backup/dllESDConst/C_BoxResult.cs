using System;
using System.Collections.Generic;
using System.Text;

namespace dllConst
{
    public class C_BoxResult
    {
        public const int T_Pass = 0x01;
        public const int T_Fail = 0x02;
        public const int T_Wait = 0x00;
        public const int T_Testing = 0x04;

        public const int Equipment_NG = 0x10;
        public const int Equipment_OK = 0x11;
        public const int Equipment_NoItem = 0x12;
        public const int Equipment_Disable = 0x13;

        public const int SerialNumber_NG = 0x05;
        public const int SerialNumber_OK = 0x06;

        public const int Model_OK = 0x07;
        public const int Model_NG = 0x08;
    }
}
