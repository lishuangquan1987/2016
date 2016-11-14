using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Diagnostics;

namespace dllConst
{
    public class Version_Cell
    {
        public string Version = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion.ToString();
    }

    public class ACT
    {
        public const int aFail = 0x08;
        public const int aTesting = 0x09;
        public const int aWrongStatus = 0x0a;
        public const int aPLCAction_Mode = 0x0b;
        public const int aStandby = 0x0c;
    }

    public class Color
    {
       public const int cRed = 1;
       public const int cBlue = 2;
        public const int cGreen = 3;
    }

    public class EquipmentStatus
    {
        public const int eWait = 0x01;
        public const int eTesting = 0x02;
        public const int eFail = 0x00;
    }

    public class USNMethod
    {
        public const int u0_fromBorcode = 0x00;
        public const int u1_fromBorcode_SaveDUT = 0x01;
        public const int u2_fromBorcode_SaveIBOX = 0x02;
        public const int u3_fromDUT = 0x03;
        public const int u4_fromIBOX = 0x04;
        public const int u5_ACT_fromDUT = 0x05;
        public const int u6_ACT_fromIBOX = 0x06;
        public const int u7_ACT_fromIBOX_SaveDUT = 0x07;
    }

    public class SysRetest
    {
        public const int System_Retest_Count_main = 0x02;
        public const int System_Retest_Count_Dialog = 0x02;
    }

    public class Mainstatus
    {
        public const int _ACT_DeviceMount = 0x00;
        public const int _ACT_DeviceUnmount = 0x01;
        public const int _ACT_DeviceStatus = 0x02;

        public const int _Start = 0x10;

        public const int _Pre_Setting = 0x11;
        public const int _Pre_SetupUI = 0x12;
        public const int _Pre_CleanStatus = 0x13;

        public const int _DeviceTest = 0x20;
        public const int _DeviceMount = 0x21;
        public const int _DeviceUnmount = 0x22;

        public const int _SerialNumber_Get = 0x30;
        public const int _SerialNumber_Enter = 0x31;
        public const int _SerialNumner_Fail = 0x32;
        public const int _SerialNumner_Fail_ACT = 0x33;

        public const int _IBOXInformation_Read = 0x40;
        public const int _IBOXInformation_Write_Pass = 0x41;
        public const int _IBOXInformation_Write_Fail = 0x42;

        public const int _FlowItemTest_PreStart_Setting = 0x55;
        public const int _FlowItemTest_PreStart = 0x56;
        public const int _FlowItemTest_Start_Setting = 0x54;
        public const int _FlowItemTest_Start = 0x50;
        public const int _FlowItemTest_Fail = 0x51;
        public const int _FlowItemTest_Pass = 0x52;
        public const int _FlowItemTest_FailACT = 0x53;

        public const int _End_SaveLogFile = 0x60;
        public const int _End_StatusLast = 0x61;
        public const int _End_Status = 0x62;
        public const int _End_Standby = 0x63;

    }

    public class Return_Status
        {
        public const int C_PASS = 0;
        public const int C_Retest = 1;
        public const int C_Jump = 2;
        public const int C_RetestFlow = 3;
        public const int C_Idle = 4;
        }
}

