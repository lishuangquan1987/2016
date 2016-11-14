using System;
using System.Collections.Generic;
using System.Text;

namespace dllESDRegister
{
    public class _Main : ICloneable
    {
        public double ScanBarcode_Opacity = 0.6;

        public string Testing_Error_Messenger_Description;
        public string Testing_Error_Messenger_CountFlow;
        public string Testing_Error_Messenger_CountItem;

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
