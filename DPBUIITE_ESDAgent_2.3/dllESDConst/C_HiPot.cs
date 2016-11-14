using System;
using System.Collections.Generic;
using System.Text;

namespace dllConst
{
    public class C_HiPot
    {
        public const string constrPmcmd_Query_Voltage = "R0;?V;\r\n";      // measure voltage by auto range
        public const string constrPmcmd_Query_Watt = "R0;?W;\r\n";        // measure watt by auto range
        public const string constrPmcmd_Query_Ampere = "R0;?A;\r\n";     // measure Current by auto range
        public const string constrPmcmd_Query_PF = "R0;?P;\r\n";             // measure PF

        public const string constrHpcmd_Qurey_Status = "SOURce:SAFEty:STATus?\r\n";
        public const string constrHpcmd_Action_Start = "SOURce:SAFEty:STARt\r\n";
        public const string constrHpcmd_Action_Stop = "SOURce:SAFEty:STOP\r\n";
        public const string constrHpmcd_Result_OutputMeter = "SAFEty:RESult:ALL:OMET?\r\n";
        public const string constrHpcmd_Result_MeasureMeter = "SAFEty:RESult:ALL:MMET?\r\n";
        public const string constrHpcmd_Result = "SAFEty:RESult:ALL:JUDGment?\r\n";

    }
}
