using System;
using System.Collections.Generic;
using System.Text;

namespace dllESDComp_UART
    {
    class _Private
        {
        // ~將指令(BYTE)轉換為(16進位字串)
        public string _ToHexString(byte[] _Transformer)
            {
            StringBuilder sb = new StringBuilder(_Transformer. Length * 3);
            foreach (byte b in _Transformer)
                sb. Append(Convert. ToString(b, 16). PadLeft(2, '0'). PadRight(3, ' '));
            return sb. ToString(). ToUpper();
            }

        // ~將指令(16進位字串)轉換為(BYTE)
        public byte[] _ToByteArray(string _Transformer)
            {
            _Transformer = _Transformer. Replace(" ", "");
            byte[] buffer = new byte[_Transformer. Length / 2];
            for (int i = 0; i < _Transformer. Length; i += 2)
                buffer[i / 2] = (byte)Convert. ToByte(_Transformer. Substring(i, 2), 16);
            return buffer. Clone() as byte[];
            }

        // ~傳輸指令計算CheckSUM
        public string _GetCheckSum(byte[] tf_CheckSum)
            {
            Int32 _itemp_checksum = 0;

            for (int i = 1; i < 10; i++)
                _itemp_checksum = _itemp_checksum + Convert. ToInt16(tf_CheckSum[i]);

            _itemp_checksum = 0x100 - _itemp_checksum;
            tf_CheckSum[10] = (byte)_itemp_checksum;
            string str_checksum = Convert. ToString(tf_CheckSum[10], 16). ToUpper(). PadLeft(2, '0');

            return str_checksum;
            }

        // ~傳輸指令計算CheckSUM
        public byte[] _GetCheckSum_Byte(byte[] tf_CheckSum)
            {
            Int32 _itemp_checksum = 0;

            for (int i = 1; i < 10; i++)
                _itemp_checksum = _itemp_checksum + Convert. ToInt16(tf_CheckSum[i]);

            _itemp_checksum = 0x100 - _itemp_checksum;
            tf_CheckSum[10] = (byte)_itemp_checksum;

            return tf_CheckSum;
            }

        // ~延遲計數器
        public void _WaitDelayTime(int _temp_DelayTime)
            {
            System. Threading. Thread. Sleep(_temp_DelayTime);   //delay 1ms for each loop
            }
        }
    }
