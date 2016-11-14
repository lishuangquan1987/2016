using System;
using System.Collections.Generic;
using System.Text;

namespace dllESDRegister
{
    public class _Execution : ICloneable
    {
        public bool _blResult_execution_Item = true;

        public string _strErrorDescription = "";
        public string _strErrorCode = "";

        public int intParameter_1 = 0;
        public int intParameter_2 = 0;
        public int intResult_length = 0;

        public byte[] abytResult_ack = new byte[10];

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
