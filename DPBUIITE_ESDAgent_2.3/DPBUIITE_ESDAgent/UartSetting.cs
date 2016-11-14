using System;
using System. Collections. Generic;
using System. ComponentModel;
using System. Data;
using System. Drawing;
using System. Text;
using System. Windows. Forms;

namespace DPBUIITE_ESDAgent
    {
    public partial class UartSetting : Form
        {
        public UartSetting()
            {
            InitializeComponent();
            }

        private void UartSetting_Load(object sender, EventArgs e)
            {
            Form1. _FileAP. FAPTSystem. LoadFile_TSystem(Form1. _Register);

            #region ~ESD Board
            cb_EnableESDBoard. Checked = Convert. ToBoolean(Form1. _Register. ESDTSystem. ESD_Setting. EnableESD);
            Checked_ESD();

            cb_ESDCommunicationType. Enabled = false;
            cb_ESDModel. Enabled = false;
            cb_ESDCommunicationType. Text = Form1. _Register. ESDTSystem. ESDUart_Setting. CommunicationType;
            cb_ESDModel. Text = Form1. _Register. ESDTSystem. ESDUart_Setting. ESDModel;
            cb_ESDPort. Text = Form1. _Register. ESDTSystem. ESDUart_Setting. ESDPort;
            cb_ESDBautRate. Text = Form1. _Register. ESDTSystem. ESDUart_Setting. ESDBautRate;
            cb_ESDParity. SelectedIndex = Convert. ToInt16(Form1. _Register. ESDTSystem. ESDUart_Setting. ESDParity);
            cb_ESDDataBits. Text = Convert. ToString(Form1. _Register. ESDTSystem. ESDUart_Setting. ESDDataBits);
            cb_ESDStopBits. SelectedIndex = Convert. ToInt16(Form1. _Register. ESDTSystem. ESDUart_Setting. ESDStopBits);
            #endregion
            }

        private void Checked_ESD()
            {
            if (cb_EnableESDBoard. Checked == true)
                {
                cb_ESDPort. Enabled = true;
                cb_ESDBautRate. Enabled = true;
                cb_ESDParity. Enabled = true;
                cb_ESDDataBits. Enabled = true;
                cb_ESDStopBits. Enabled = true;
                btTest_ESD. Enabled = true;
                } else
                {
                cb_ESDCommunicationType. Enabled = false;
                cb_ESDModel. Enabled = false;
                cb_ESDCommunicationType. Enabled = false;
                cb_ESDModel. Enabled = false;
                cb_ESDPort. Enabled = false;
                cb_ESDBautRate. Enabled = false;
                cb_ESDParity. Enabled = false;
                cb_ESDDataBits. Enabled = false;
                cb_ESDStopBits. Enabled = false;
                btTest_ESD. Enabled = false;
                }
            }

        private void btTest_ESD_Click(object sender, EventArgs e)
        {
            /*
            Save_Setting();
            _execution_result = Class_Main_Device. Device_Management(Class_Main_Device. C_DeviceTest_ISP);
            if (_execution_result. _blResult_execution_Element == false)
                {
                gb_ISP. BackColor = Color. Pink;
                } else
                {
                gb_ISP. BackColor = Color. LightBlue;
                }
            Application. DoEvents();
            */
         }

        private void bt_Save_Click(object sender, EventArgs e)
            {
            Save_Setting();
            }

        private void bt_Cancel_Click(object sender, EventArgs e)
            {
            this. Close();
            }

        private void Save_Setting()
            {
            Form1. _Register. ESDTSystem. ESD_Setting. EnableESD = Convert. ToString(cb_EnableESDBoard. Checked);
            Form1. _Register. ESDTSystem. ESDUart_Setting. CommunicationType = cb_ESDCommunicationType. Text;
            Form1. _Register. ESDTSystem. ESDUart_Setting. ESDModel = cb_ESDModel. Text;
            Form1. _Register. ESDTSystem. ESDUart_Setting. ESDPort = cb_ESDPort. Text;
            Form1. _Register. ESDTSystem. ESDUart_Setting. ESDBautRate = cb_ESDBautRate. Text;
            Form1. _Register. ESDTSystem. ESDUart_Setting. ESDParity = Convert. ToString(cb_ESDParity. SelectedIndex);
            Form1. _Register. ESDTSystem. ESDUart_Setting. ESDDataBits = Convert. ToString(cb_ESDDataBits. Text);
            Form1. _Register. ESDTSystem. ESDUart_Setting. ESDStopBits = Convert. ToString(cb_ESDStopBits. SelectedIndex);

            Form1. _FileAP. FAPTSystem. SaveFile_TSystem(Form1. _Register);

            this. Close();
            }

        private void cb_ESDCommunicationType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cb_ESDModel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cb_ESDPort_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        }
    }