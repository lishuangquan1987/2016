using System;
using System.Collections.Generic;
using System.Text;

namespace dllESDRegister
{
    public class _ESDTSystem
    {
        public _ESDSetting ESD_Setting = new _ESDSetting();
        public _ESDUart ESDUart_Setting = new _ESDUart();
        public string[] ESDLocation = new string[0x40];
        public string[] ESDDisable = new string[0x40];
        public int[] ESDStatus = new int[0x40];

        public class _ESDSetting
        {
            public string index;
            public string EnableESD;
        }

        public class _ESDUart
        {
            public string index;
            public string CommunicationType;
            public string ESDVendor;
            public string ESDModel;
            public string ESDPort;
            public string ESDBautRate;
            public string ESDParity;
            public string ESDDataBits;
            public string ESDStopBits;
        }

    }
}