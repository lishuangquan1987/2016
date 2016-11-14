using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data;

namespace dllESDFileAP
    {
    public class _TSystem
        {
        private static string[] _sFileContant = new string[1000];
        private static string[] _sFileContant_temp = new string[1000];
        public _ErrorCode ErrorCode = new _ErrorCode();

        #region 設定值存入檔案
        public dllESDRegister. _Execution SaveFile_TSystem(dllESDRegister. _Object _Register)
            {
            dllESDRegister. _Execution _execution_result = new dllESDRegister. _Execution();

            if (!SaveTitle(_Register). _blResult_execution_Item)
                {
                return _execution_result. Clone() as dllESDRegister. _Execution;
                }
            _execution_result. _blResult_execution_Item = true;

            File. WriteAllLines("TSystem.cfg", _sFileContant_temp);

            return _execution_result. Clone() as dllESDRegister. _Execution;

            }

        private dllESDRegister. _Execution SaveTitle(dllESDRegister. _Object _Register)
            {
            dllESDRegister. _Execution _execution_result = new dllESDRegister. _Execution();
            int _temp_WriteLineCount;

            _execution_result. _blResult_execution_Item = true;
            _temp_WriteLineCount = 0;

            _sFileContant_temp[_temp_WriteLineCount] = "[Setting]";
            _temp_WriteLineCount = SaveItem_Setting(_Register, _temp_WriteLineCount + 1);
            _sFileContant_temp[_temp_WriteLineCount++] = "";

            _sFileContant_temp[_temp_WriteLineCount] = "[ESDUart_Setting]";
            _temp_WriteLineCount = SaveItem_Setting_ESDUart(_Register, _temp_WriteLineCount + 1);
            _sFileContant_temp[_temp_WriteLineCount++] = "";

            return _execution_result. Clone() as dllESDRegister. _Execution;
            }

        private int SaveItem_Setting(dllESDRegister. _Object _Register, int i)
            {
            _sFileContant_temp[i++] = "1~" + "Index=" + _Register. ESDTSystem. ESD_Setting. index;
            _sFileContant_temp[i++] = "2~" + "EnableESD=" + _Register. ESDTSystem. ESD_Setting. EnableESD;
            return i;
            }

        private int SaveItem_Setting_ESDUart(dllESDRegister. _Object _Register, int i)
            {
            _sFileContant_temp[i++] = "1~" + "Index=" + _Register. ESDTSystem. ESDUart_Setting. index;
            _sFileContant_temp[i++] = "2~" + "CommunicationType=" + _Register. ESDTSystem. ESDUart_Setting. CommunicationType;
            _sFileContant_temp[i++] = "3~" + "ESDVendor=" + _Register. ESDTSystem. ESDUart_Setting. ESDVendor;
            _sFileContant_temp[i++] = "4~" + "ESDModel=" + _Register. ESDTSystem. ESDUart_Setting. ESDModel;
            _sFileContant_temp[i++] = "5~" + "ESDPort=" + _Register. ESDTSystem. ESDUart_Setting. ESDPort;
            _sFileContant_temp[i++] = "6~" + "ESDBautRate=" + _Register. ESDTSystem. ESDUart_Setting. ESDBautRate;
            _sFileContant_temp[i++] = "7~" + "ESDParity=" + _Register. ESDTSystem. ESDUart_Setting. ESDParity;
            _sFileContant_temp[i++] = "8~" + "ESDDataBits=" + _Register. ESDTSystem. ESDUart_Setting. ESDDataBits;
            _sFileContant_temp[i++] = "9~" + "ESDStopBits=" + _Register. ESDTSystem. ESDUart_Setting. ESDStopBits;
            return i;
            }
        #endregion

        #region 讀取檔案設定值
        public dllESDRegister. _Execution LoadFile_TSystem(dllESDRegister. _Object _Register)
            {
            dllESDRegister. _Execution _execution_result = new dllESDRegister. _Execution();

            _sFileContant = File. ReadAllLines("TSystem.cfg");

            if (!LoadTitle(_Register). _blResult_execution_Item)
                {
                return _execution_result. Clone() as dllESDRegister. _Execution;
                }
            return _execution_result. Clone() as dllESDRegister. _Execution;
            }

        private dllESDRegister. _Execution LoadTitle(dllESDRegister. _Object _Register)
            {
            dllESDRegister. _Execution _execution_result = new dllESDRegister. _Execution();

            for (Int32 i = 0; i <= (_sFileContant. Length - 1); i++)
                {
                if (_sFileContant[i]. Contains("["))
                    {
                    if (_sFileContant[i] == "[Setting]")
                        LoadItem_Setting(_Register, i);

                    if (_sFileContant[i] == "[ESDUart_Setting]")
                        LoadItem_SettingESDUart(_Register, i);
                    }
                }
            return _execution_result. Clone() as dllESDRegister. _Execution;
            }

        private void LoadItem_Setting(dllESDRegister. _Object _Register, int i)
            {
            string[] _sIndexVariable = _sFileContant[i + 1]. Split('=', '~');

            for (int j = 1; j <= (Convert. ToInt16(_sIndexVariable[2])); j++)
                {
                string[] _sVeriableName = _sFileContant[i + j]. Split('=', '~');
                switch (Convert. ToInt16(_sVeriableName[0]))
                    {
                    case 1: _Register. ESDTSystem. ESD_Setting. index = _sVeriableName[2]; break;
                    case 2: _Register. ESDTSystem. ESD_Setting. EnableESD = _sVeriableName[2]; break;
                    }
                }
            }

        private void LoadItem_SettingESDUart(dllESDRegister. _Object _Register, int i)
            {
            string[] _sIndexVariable = _sFileContant[i + 1]. Split('=', '~');

            for (int j = 1; j <= (Convert. ToInt16(_sIndexVariable[2])); j++)
                {
                string[] _sVeriableName = _sFileContant[i + j]. Split('=', '~');
                switch (Convert. ToInt16(_sVeriableName[0]))
                    {
                    case 1: _Register. ESDTSystem. ESDUart_Setting. index = _sVeriableName[2]; break;
                    case 2: _Register. ESDTSystem. ESDUart_Setting. CommunicationType = _sVeriableName[2]; break;
                    case 3: _Register. ESDTSystem. ESDUart_Setting. ESDVendor = _sVeriableName[2]; break;
                    case 4: _Register. ESDTSystem. ESDUart_Setting. ESDModel = _sVeriableName[2]; break;
                    case 5: _Register. ESDTSystem. ESDUart_Setting. ESDPort = _sVeriableName[2]; break;
                    case 6: _Register. ESDTSystem. ESDUart_Setting. ESDBautRate = _sVeriableName[2]; break;
                    case 7: _Register. ESDTSystem. ESDUart_Setting. ESDParity = _sVeriableName[2]; break;
                    case 8: _Register. ESDTSystem. ESDUart_Setting. ESDDataBits = _sVeriableName[2]; break;
                    case 9: _Register. ESDTSystem. ESDUart_Setting. ESDStopBits = _sVeriableName[2]; break;
                    }
                }
            }
        #endregion
        }
    }
