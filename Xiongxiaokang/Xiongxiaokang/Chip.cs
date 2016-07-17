using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xiongxiaokang
{
    public class EXDictionary : Dictionary<string, string>
    { 
    }
    public class Chip
    {
        public  EXDictionary dic = new EXDictionary();
        public string this[int index]
        {
            get { return dic[properties[index]]; }
            set { dic[properties[index]] = value; }
        }
        public static string[] properties ={
                    //INFO
                    "WaferID",//0
                    "ChipID",
                    "ChipStatus",
                    "FailCount",
                    "NotTested",
                    "StartTestTime",
                    "BINPartNumber",
                    "WaveLength_setT_70C",
                    "TemperatureMeasured",//8
                    "TemperatureSetPoint",
                    //LIV Sweep
                    "DarCurrentGain",
                    "DarCurrentMod",
                    "XtalkModToGain",
                    "XtalkGainToMod",
                    "GainResistance",//14
                    "GainVoltage0",
                    "lth_Calc",
                    "lth_lmod",
                    "lth_Pout",
                    "lth_Pdfb",
                    "Mod_Current_Ratio",//20
                    "Kink2nd_Derivative",
                    "Kink_Current",
                    "Reflection3rd_Distance",
                    "Kink2ndDrv_Pdfb_Idfb",
                    "KinkCurrent_Pdfb_Idfb",
                    "Kink2ndDrv_Pout_Idfb",
                    "KinkCurrent_Pout_Idfb",
                    "RollOver_Current",
                    "Rollover_Power",
                    "SlopeEfficiency_Pdfb_Idfb",
                    "SlopeEfficiency_Pdfb_Ppump",//31
                    //Gain Voltage
                    "Vgain_30mA",
                    "Vgain_60mA",
                    "Vgain_90mA",
                    "Vgain_120mA",//35
                    //Modulator Current
                    "Imod_30mA",//36
                    "Imod_60mA",
                    "Imod_90mA",
                    "Imod_120mA",
                    //Output Power
                    "Pout_30mA",//40
                    "Pout_60mA",
                    "Pout_90mA",
                    "Pout_120mA",//43
                    //Laser Power Pdfb
                    "Pdfb_30mA",//44
                    "Pdfb_60mA",
                    "Pdfb_90mA",
                    "CorrelationOnFactor",
                    //WaveLenth
                    "WVL_30mA",//48
                    "WVL_60mA",
                    "WVL_90mA",
                    "WVL_120mA",
                    "WaveLength_80mA",//52
                    //SMSRTest2
                    "MaxDetWvlPerPwr_EA-V",
                    "MaxDetWvlPerCurrent_EA-V",//54
                    //SMSR (dB)
                    "SMSR_30mA",//55
                    "SMSR_60mA",
                    "SMSR_90mA",
                    "SMSRTest2_EA_Voltage",//58
                                   };
        /*
        //INFO
        public string WaferID;
        public string ChipID;
        public string ChipStatus;
        public string FailCount;
        public string NotTested;
        public string StartTestTime;
        public string BINPartNumber;
        public string WaveLength_setT_70C;
        public string TemperatureMeasured;
        public string TemperatureSetPoint;
        //LIV Sweep
        public string DarCurrentGain;
        public string DarCurrentMod;
        public string XtalkModToGain;
        public string XtalkGainToMod;
        public string GainResistance;
        public string GainVoltage0;
        public string lth_Calc;
        public string lth_lmod;
        public string lth_Pout;
        public string lth_Pdfb;
        public string Mod_Current_Ratio;
        public string Kink2nd_Derivative;
        public string Kink_Current;
        public string Reflection3rd_Distance;
        public string Kink2ndDrv_Pdfb_Idfb;
        public string KinkCurrent_Pdfb_Idfb;
        public string Kink2ndDrv_Pout_Idfb;
        public string KinkCurrent_Pout_Idfb;
        public string RollOver_Current;
        public string   Rollover_Power;
        public string SlopeEfficiency_Pdfb_Idfb;
        public string SlopeEfficiency_Pdfb_Ppump;
        //Gain Voltage
        public string Vgain_30mA;
        public string Vgain_60mA;
        public string Vgain_90mA;
        public string Vgain_120mA;
        //Modulator Current
        public string Imod_30mA;
        public string Imod_60mA;
        public string Imod_90mA;
        public string Imod_120mA;
        //Output Power
        public string Pout_30mA;
        public string Pout_60mA;
        public string Pout_90mA;
        public string Pout_120mA;
        //Laser Power Pdfb
        public string Pdfb_30mA;
        public string Pdfb_60mA;
        public string Pdfb_90mA;
        public string CorrelationOnFactor;
        //WaveLenth
        public string WVL_30mA;
        public string WVL_60mA;
        public string WVL_90mA;
        public string WVL_120mA;
        public string WaveLength_80mA;
         * */

    }
    
}
