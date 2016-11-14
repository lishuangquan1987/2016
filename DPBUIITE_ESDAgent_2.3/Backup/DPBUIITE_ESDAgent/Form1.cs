using System;
using System. Collections. Generic;
using System. ComponentModel;
using System. Data;
using System. Drawing;
using System. Text;
using System. Windows. Forms;
using System.IO;

namespace DPBUIITE_ESDAgent
{
    public partial class Form1 : Form
    {
        public static dllESDComp_UART._Object _ESDUart = new dllESDComp_UART._Object();
        public static dllESDFileAP._Object _FileAP = new dllESDFileAP._Object();
        public static dllESDRegister._Object _Register = new dllESDRegister._Object();
        private bool _MeasureStop = true;
        private dllESDRegister._Execution _ExecutionResult = new dllESDRegister._Execution();
        private static int _temp_count = 3;

        public Form1()
        {
            InitializeComponent();
        }

        private void _Ininatial()
        {
            for (int _x = 0; _x < 0x40; _x++)
                ESDPanel.Controls[_x].Controls[2].BackColor = Color.LightGray;
        }

        private void ESDPanelLoadDefault()
        {
            this.ESDPanel.Controls.Clear();
            this.ESDPanel.Controls.Add(this.panel0);
            this.ESDPanel.Controls.Add(this.panel1);
            this.ESDPanel.Controls.Add(this.panel2);
            this.ESDPanel.Controls.Add(this.panel3);
            this.ESDPanel.Controls.Add(this.panel4);
            this.ESDPanel.Controls.Add(this.panel5);
            this.ESDPanel.Controls.Add(this.panel6);
            this.ESDPanel.Controls.Add(this.panel7);
            this.ESDPanel.Controls.Add(this.panel8);
            this.ESDPanel.Controls.Add(this.panel9);
            this.ESDPanel.Controls.Add(this.panel10);
            this.ESDPanel.Controls.Add(this.panel11);
            this.ESDPanel.Controls.Add(this.panel12);
            this.ESDPanel.Controls.Add(this.panel13);
            this.ESDPanel.Controls.Add(this.panel14);
            this.ESDPanel.Controls.Add(this.panel15);
            this.ESDPanel.Controls.Add(this.panel16);
            this.ESDPanel.Controls.Add(this.panel17);
            this.ESDPanel.Controls.Add(this.panel18);
            this.ESDPanel.Controls.Add(this.panel19);
            this.ESDPanel.Controls.Add(this.panel20);
            this.ESDPanel.Controls.Add(this.panel21);
            this.ESDPanel.Controls.Add(this.panel22);
            this.ESDPanel.Controls.Add(this.panel23);
            this.ESDPanel.Controls.Add(this.panel24);
            this.ESDPanel.Controls.Add(this.panel25);
            this.ESDPanel.Controls.Add(this.panel26);
            this.ESDPanel.Controls.Add(this.panel27);
            this.ESDPanel.Controls.Add(this.panel28);
            this.ESDPanel.Controls.Add(this.panel29);
            this.ESDPanel.Controls.Add(this.panel30);
            this.ESDPanel.Controls.Add(this.panel31);
            this.ESDPanel.Controls.Add(this.panel32);
            this.ESDPanel.Controls.Add(this.panel33);
            this.ESDPanel.Controls.Add(this.panel34);
            this.ESDPanel.Controls.Add(this.panel35);
            this.ESDPanel.Controls.Add(this.panel36);
            this.ESDPanel.Controls.Add(this.panel37);
            this.ESDPanel.Controls.Add(this.panel38);
            this.ESDPanel.Controls.Add(this.panel39);
            this.ESDPanel.Controls.Add(this.panel40);
            this.ESDPanel.Controls.Add(this.panel41);
            this.ESDPanel.Controls.Add(this.panel42);
            this.ESDPanel.Controls.Add(this.panel43);
            this.ESDPanel.Controls.Add(this.panel44);
            this.ESDPanel.Controls.Add(this.panel45);
            this.ESDPanel.Controls.Add(this.panel46);
            this.ESDPanel.Controls.Add(this.panel47);
            this.ESDPanel.Controls.Add(this.panel48);
            this.ESDPanel.Controls.Add(this.panel49);
            this.ESDPanel.Controls.Add(this.panel50);
            this.ESDPanel.Controls.Add(this.panel51);
            this.ESDPanel.Controls.Add(this.panel52);
            this.ESDPanel.Controls.Add(this.panel53);
            this.ESDPanel.Controls.Add(this.panel54);
            this.ESDPanel.Controls.Add(this.panel55);
            this.ESDPanel.Controls.Add(this.panel56);
            this.ESDPanel.Controls.Add(this.panel57);
            this.ESDPanel.Controls.Add(this.panel58);
            this.ESDPanel.Controls.Add(this.panel59);
            this.ESDPanel.Controls.Add(this.panel60);
            this.ESDPanel.Controls.Add(this.panel61);
            this.ESDPanel.Controls.Add(this.panel62);
            this.ESDPanel.Controls.Add(this.panel63);
        }
        private void TextBoxEnble()
        {
            for (int _x = 0; _x < 0x40; _x++)
                ESDPanel.Controls[_x].Controls[1].Enabled= true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Start")
            {
                saveToolStripMenuItem_Click(sender, e);
                _MeasureStop = true;
                button1.Text = "Cancel";
                button2.Focus();
                StartTest();
            }
            else
            {
                _MeasureStop = false;
                button1.Text = "Start";
                _Ininatial();
            }
        }

        private void StartTest()
        {
            _ESDUart.Device_ESD.CMD_Component._UART_Define(_Register);
            _ESDUart.Device_ESD.CMD_Component._UART_Open(_Register);
            byte[] _transmitter = new byte[1];
            int _temp_Int;
            string _temp_address;
            string _temp_name;
            
            TextBoxEnble();
            // progressBar1.Enabled = true;

            while (_MeasureStop)
            {
                for (int _x = 0x00; _x < 0x40; _x++)
                {
                    if (_MeasureStop == false)
                        break;
                    if (Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[_x]) == true)
                    {
                        ESDPanel.Controls[_x].Controls[3].BackColor = Color.LightGray;
                        continue;
                    }
                    _transmitter[0] = (byte)_x;
                    _ExecutionResult = _ESDUart.Device_ESD.CMD_Component._UART_Transmitter(_Register, _transmitter, 10);

                    progressBar1.Value = _x;
                    _temp_Int = (int)_ExecutionResult.abytResult_ack[0];
                    if (_x != (int)_ExecutionResult.abytResult_ack[1] && (int)_ExecutionResult.abytResult_ack[1]!=0)
                    {
                        if (_temp_count != 0)
                        {
                            _temp_count--;
                            _x--;
                            continue;
                        }
                    }              
                    _temp_address = ESDPanel.Controls[_x].Controls[2].Text;
                    _temp_name = ESDPanel.Controls[_x].Controls[1].Text;
                    switch (_temp_Int)
                    {
                        case 0:
                            ESDPanel.Controls[_x].Controls[3].BackColor = Color.Yellow;
                            if (_Register.ESDTSystem.ESDStatus[_x] != _temp_Int)
                            {
                                _FileAP.FAPLocation.SaveLogFile(_Register, _temp_address, _temp_name, "靜電環未偵測到", "0");
                            }
                            _Register.ESDTSystem.ESDStatus[_x] = _temp_Int;
                            break;
                        case 223:
                            ESDPanel.Controls[_x].Controls[3].BackColor = Color.Green;
                            if (_Register.ESDTSystem.ESDStatus[_x] != _temp_Int)
                            {
                                _FileAP.FAPLocation.SaveLogFile(_Register, _temp_address, _temp_name, "靜電環帶上", "1");
                            }
                            _Register.ESDTSystem.ESDStatus[_x] = _temp_Int;
                            break;
                        case 239:
                            ESDPanel.Controls[_x].Controls[3].BackColor = Color.Red;
                            if (_Register.ESDTSystem.ESDStatus[_x] != _temp_Int)
                            {
                                _FileAP.FAPLocation.SaveLogFile(_Register, _temp_address, _temp_name, "靜電環取下", "2");
                            }
                            _Register.ESDTSystem.ESDStatus[_x] = _temp_Int;
                            break;
                        case 3:
                            ESDPanel.Controls[_x].Controls[3].BackColor = Color.LightGray;
                            if (_Register.ESDTSystem.ESDStatus[_x] != _temp_Int)
                            {
                                _FileAP.FAPLocation.SaveLogFile(_Register, _temp_address, _temp_name, "未定義狀態", "3");
                            }
                            _Register.ESDTSystem.ESDStatus[_x] = _temp_Int;
                            break;
                    }
                    _temp_count = 3;
                    Application.DoEvents();
                }
            }
            _ESDUart.Device_ESD.CMD_Component._UART_Close(_Register);
            progressBar1.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _FileAP.FAPTSystem.LoadFile_TSystem(_Register);
            _FileAP.FAPLocation.LoadFile_Location(_Register);
            CheckBOXShow();
            for (int _x = 0; _x < 0x40; _x++)
            {
                ESDPanel.Controls[_x ].Controls[2].Text = "0x" + Convert.ToString(_x, 16).PadLeft(2, '0').ToUpper();
                ESDPanel.Controls[_x ].Controls[2].BackColor = Color.White;
                ESDPanel.Controls[_x ].Controls[1].Text = _Register.ESDTSystem.ESDLocation[_x ];
                _Register.ESDTSystem.ESDStatus[_x] = 0;
            }
           // this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Menu = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _ESDUart.Device_ESD.CMD_Component._UART_Define(_Register);
            _ESDUart.Device_ESD.CMD_Component._UART_Open(_Register);

            byte[] _transmitter = new byte[1];
            _transmitter[0] = 0x05;
            _ExecutionResult = _ESDUart.Device_ESD.CMD_Component._UART_Transmitter(_Register, _transmitter, 100);

            _ESDUart.Device_ESD.CMD_Component._UART_Close(_Register);


            /*
((Panel)ArrayList[i]). Controls[x]. Text = "xxxxxx"; 

foreach (Control control in (Panel)ArrayList[i]).Controls)
    {
    if(control is TextBox)
     {
      control.Text = "xxxxxx";
       }
    } 
 */


        }

        private void eSDBoardUartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UartSetting UartSetting = new UartSetting();

            UartSetting.ShowDialog(this);
            UartSetting.Dispose();


        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int _x = 0; _x < 0x40; _x++)
            {
                ESDPanel.Controls[_x].Controls[1].Enabled = true;
                ((TextBox)ESDPanel.Controls[_x].Controls[1]).ReadOnly = false;
                ESDPanel.Controls[_x].Controls[0].Visible = true;
                CheckBOXShow();
            }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckBOXSave();
            for (int _x = 0; _x < 0x40; _x++)
            {
                _Register.ESDTSystem.ESDLocation[_x] = ESDPanel.Controls[_x].Controls[1].Text;
                ESDPanel.Controls[_x].Controls[1].Enabled = false;
                ((TextBox)ESDPanel.Controls[_x].Controls[1]).ReadOnly = true;
                ESDPanel.Controls[_x].Controls[0].Visible = false;
            }
            TextBoxEnble();
            _FileAP.FAPLocation.SaveFile_Location(_Register);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _MeasureStop = false;
        }

        private void CheckBOXShow()
        {
            checkBox0.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[0]);
            checkBox1.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[1]);
            checkBox2.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[2]);
            checkBox3.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[3]);
            checkBox4.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[4]);
            checkBox5.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[5]);
            checkBox6.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[6]);
            checkBox7.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[7]);
            checkBox8.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[8]);
            checkBox9.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[9]);
            checkBox10.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[10]);
            checkBox11.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[11]);
            checkBox12.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[12]);
            checkBox13.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[13]);
            checkBox14.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[14]);
            checkBox15.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[15]);
            checkBox16.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[16]);
            checkBox17.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[17]);
            checkBox18.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[18]);
            checkBox19.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[19]);
            checkBox20.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[20]);
            checkBox21.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[21]);
            checkBox22.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[22]);
            checkBox23.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[23]);
            checkBox24.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[24]);
            checkBox25.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[25]);
            checkBox26.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[26]);
            checkBox27.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[27]);
            checkBox28.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[28]);
            checkBox29.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[29]);
            checkBox30.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[30]);
            checkBox31.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[31]);
            checkBox32.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[32]);
            checkBox33.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[33]);
            checkBox34.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[34]);
            checkBox35.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[35]);
            checkBox36.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[36]);
            checkBox37.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[37]);
            checkBox38.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[38]);
            checkBox39.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[39]);
            checkBox40.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[40]);
            checkBox41.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[41]);
            checkBox42.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[42]);
            checkBox43.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[43]);
            checkBox44.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[44]);
            checkBox45.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[45]);
            checkBox46.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[46]);
            checkBox47.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[47]);
            checkBox48.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[48]);
            checkBox49.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[49]);
            checkBox50.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[50]);
            checkBox51.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[51]);
            checkBox52.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[52]);
            checkBox53.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[53]);
            checkBox54.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[54]);
            checkBox55.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[55]);
            checkBox56.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[56]);
            checkBox57.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[57]);
            checkBox58.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[58]);
            checkBox59.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[59]);
            checkBox60.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[60]);
            checkBox61.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[61]);
            checkBox62.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[62]);
            checkBox63.Checked = Convert.ToBoolean(_Register.ESDTSystem.ESDDisable[63]);
        }
        private void CheckBOXSave()
        {
            _Register.ESDTSystem.ESDDisable[0] = checkBox0.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[1] = checkBox1.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[2] = checkBox2.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[3] = checkBox3.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[4] = checkBox4.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[5] = checkBox5.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[6] = checkBox6.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[7] = checkBox7.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[8] = checkBox8.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[9] = checkBox9.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[10] = checkBox10.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[11] = checkBox11.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[12] = checkBox12.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[13] = checkBox13.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[14] = checkBox14.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[15] = checkBox15.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[16] = checkBox16.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[17] = checkBox17.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[18] = checkBox18.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[19] = checkBox19.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[20] = checkBox20.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[21] = checkBox21.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[22] = checkBox22.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[23] = checkBox23.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[24] = checkBox24.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[25] = checkBox25.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[26] = checkBox26.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[27] = checkBox27.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[28] = checkBox28.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[29] = checkBox29.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[30] = checkBox30.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[31] = checkBox31.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[32] = checkBox32.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[33] = checkBox33.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[34] = checkBox34.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[35] = checkBox35.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[36] = checkBox36.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[37] = checkBox37.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[38] = checkBox38.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[39] = checkBox39.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[40] = checkBox40.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[41] = checkBox41.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[42] = checkBox42.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[43] = checkBox43.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[44] = checkBox44.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[45] = checkBox45.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[46] = checkBox46.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[47] = checkBox47.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[48] = checkBox48.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[49] = checkBox49.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[50] = checkBox50.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[51] = checkBox51.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[52] = checkBox52.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[53] = checkBox53.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[54] = checkBox54.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[55] = checkBox55.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[56] = checkBox56.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[57] = checkBox57.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[58] = checkBox58.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[59] = checkBox59.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[60] = checkBox60.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[61] = checkBox61.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[62] = checkBox62.Checked.ToString();
            _Register.ESDTSystem.ESDDisable[63] = checkBox63.Checked.ToString();
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Control) != 0 && e.KeyCode == Keys.S)
                saveToolStripMenuItem_Click(sender, e);
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFind frmFind = new FrmFind();
            frmFind.Show(this);
           /* frmFind.ShowDialog(this);
            frmFind.Dispose();*/
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
            if (button2.Text == "顯示地址")
            {
                richTextBox0.Visible = true;
                richTextBox1.Visible = true;
                richTextBox2.Visible = true;
                richTextBox3.Visible = true;
                richTextBox4.Visible = true;
                richTextBox5.Visible = true;
                richTextBox6.Visible = true;
                richTextBox7.Visible = true;
                richTextBox8.Visible = true;
                richTextBox9.Visible = true;
                richTextBox10.Visible = true;
                richTextBox11.Visible = true;
                richTextBox12.Visible = true;
                richTextBox13.Visible = true;
                richTextBox14.Visible = true;
                richTextBox15.Visible = true;
                richTextBox16.Visible = true;
                richTextBox17.Visible = true;
                richTextBox18.Visible = true;
                richTextBox19.Visible = true;
                richTextBox20.Visible = true;
                richTextBox21.Visible = true;
                richTextBox22.Visible = true;
                richTextBox23.Visible = true;
                richTextBox24.Visible = true;
                richTextBox25.Visible = true;
                richTextBox26.Visible = true;
                richTextBox27.Visible = true;
                richTextBox28.Visible = true;
                richTextBox29.Visible = true;
                richTextBox30.Visible = true;
                richTextBox31.Visible = true;
                richTextBox32.Visible = true;
                richTextBox33.Visible = true;
                richTextBox34.Visible = true;
                richTextBox35.Visible = true;
                richTextBox36.Visible = true;
                richTextBox37.Visible = true;
                richTextBox38.Visible = true;
                richTextBox39.Visible = true;
                richTextBox40.Visible = true;
                richTextBox41.Visible = true;
                richTextBox42.Visible = true;
                richTextBox43.Visible = true;
                richTextBox44.Visible = true;
                richTextBox45.Visible = true;
                richTextBox46.Visible = true;
                richTextBox47.Visible = true;
                richTextBox48.Visible = true;
                richTextBox49.Visible = true;
                richTextBox50.Visible = true;
                richTextBox51.Visible = true;
                richTextBox52.Visible = true;
                richTextBox53.Visible = true;
                richTextBox54.Visible = true;
                richTextBox55.Visible = true;
                richTextBox56.Visible = true;
                richTextBox57.Visible = true;
                richTextBox58.Visible = true;
                richTextBox59.Visible = true;
                richTextBox60.Visible = true;
                richTextBox61.Visible = true;
                richTextBox62.Visible = true;
                richTextBox63.Visible = true;
                
                button2.Text = "隱藏地址";
            }
            else
            {
                richTextBox0.Visible = false;
                richTextBox1.Visible = false;
                richTextBox2.Visible = false;
                richTextBox3.Visible = false;
                richTextBox4.Visible = false;
                richTextBox5.Visible = false;
                richTextBox6.Visible = false;
                richTextBox7.Visible = false;
                richTextBox8.Visible = false;
                richTextBox9.Visible = false;
                richTextBox10.Visible = false;
                richTextBox11.Visible = false;
                richTextBox12.Visible = false;
                richTextBox13.Visible = false;
                richTextBox14.Visible = false;
                richTextBox15.Visible = false;
                richTextBox16.Visible = false;
                richTextBox17.Visible = false;
                richTextBox18.Visible = false;
                richTextBox19.Visible = false;
                richTextBox20.Visible = false;
                richTextBox21.Visible = false;
                richTextBox22.Visible = false;
                richTextBox23.Visible = false;
                richTextBox24.Visible = false;
                richTextBox25.Visible = false;
                richTextBox26.Visible = false;
                richTextBox27.Visible = false;
                richTextBox28.Visible = false;
                richTextBox29.Visible = false;
                richTextBox30.Visible = false;
                richTextBox31.Visible = false;
                richTextBox32.Visible = false;
                richTextBox33.Visible = false;
                richTextBox34.Visible = false;
                richTextBox35.Visible = false;
                richTextBox36.Visible = false;
                richTextBox37.Visible = false;
                richTextBox38.Visible = false;
                richTextBox39.Visible = false;
                richTextBox40.Visible = false;
                richTextBox41.Visible = false;
                richTextBox42.Visible = false;
                richTextBox43.Visible = false;
                richTextBox44.Visible = false;
                richTextBox45.Visible = false;
                richTextBox46.Visible = false;
                richTextBox47.Visible = false;
                richTextBox48.Visible = false;
                richTextBox49.Visible = false;
                richTextBox50.Visible = false;
                richTextBox51.Visible = false;
                richTextBox52.Visible = false;
                richTextBox53.Visible = false;
                richTextBox54.Visible = false;
                richTextBox55.Visible = false;
                richTextBox56.Visible = false;
                richTextBox57.Visible = false;
                richTextBox58.Visible = false;
                richTextBox59.Visible = false;
                richTextBox60.Visible = false;
                richTextBox61.Visible = false;
                richTextBox62.Visible = false;
                richTextBox63.Visible = false;
                

                button2.Text = "顯示地址";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox0_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}