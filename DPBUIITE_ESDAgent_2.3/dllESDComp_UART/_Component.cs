using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.IO;
using System.Windows.Forms;
using System.Data;

namespace dllESDComp_UART
{
    public class _Component
    {
        public SerialPort System_IO_SerialPort_ESD = new SerialPort();
        public _ErrorCode ErrorCode = new _ErrorCode();
        private _Private _Pvt = new _Private();

        // ~定義ESD BOARD通訊設定 public static void UART_Define()~
        public dllESDRegister._Execution _UART_Define(dllESDRegister._Object _Register)
        {
            dllESDRegister._Execution _execution_result = new dllESDRegister._Execution();

            try
            {
                if (System_IO_SerialPort_ESD.IsOpen == true)
                    System_IO_SerialPort_ESD.Close();

                System_IO_SerialPort_ESD.PortName = _Register.ESDTSystem.ESDUart_Setting.ESDPort;
                System_IO_SerialPort_ESD.BaudRate = Convert.ToInt32(_Register.ESDTSystem.ESDUart_Setting.ESDBautRate);
                System_IO_SerialPort_ESD.Parity = (Parity)Convert.ToInt16(_Register.ESDTSystem.ESDUart_Setting.ESDParity);
                System_IO_SerialPort_ESD.DataBits = Convert.ToInt16(_Register.ESDTSystem.ESDUart_Setting.ESDDataBits);
                System_IO_SerialPort_ESD.StopBits = (StopBits)Convert.ToInt16(_Register.ESDTSystem.ESDUart_Setting.ESDStopBits);

                System_IO_SerialPort_ESD.Encoding = System.Text.UnicodeEncoding.Unicode;

                System_IO_SerialPort_ESD.DtrEnable = false;
                System_IO_SerialPort_ESD.RtsEnable = false;
                System_IO_SerialPort_ESD.DiscardNull = false;
                System_IO_SerialPort_ESD.WriteTimeout = 1000;
                System_IO_SerialPort_ESD.ReadTimeout = 1000;

                return _execution_result.Clone() as dllESDRegister._Execution;
            }
            #region 例外
            catch (UnauthorizedAccessException)
            {
                //ISP Board被其他未知程式占用
                System_IO_SerialPort_ESD.Close();
                return _execution_result.Clone() as dllESDRegister._Execution;
            }

            catch (IOException)
            {
                //關閉ISP傳輸埠失敗
                System_IO_SerialPort_ESD.Close();
                return _execution_result.Clone() as dllESDRegister._Execution;
            }

            catch (ArgumentOutOfRangeException)
            {
                //串口設定值不符合該設備
                System_IO_SerialPort_ESD.Close();
                return _execution_result.Clone() as dllESDRegister._Execution;
            }

            catch (ArgumentNullException)
            {
                //ISP Board參數錯誤
                System_IO_SerialPort_ESD.Close();
                return _execution_result.Clone() as dllESDRegister._Execution;
            }

            catch (InvalidOperationException)
            {
                //通訊開啟中,請關閉該通訊,始可開始設定
                System_IO_SerialPort_ESD.Close();
                return _execution_result.Clone() as dllESDRegister._Execution;
            }
            catch (TimeoutException)
            {
                //通訊開啟中,請關閉該通訊,始可開始設定
                System_IO_SerialPort_ESD.Close();
                return _execution_result.Clone() as dllESDRegister._Execution;
            }
            #endregion
        }

        // ~啟動ESD BOARD通訊設定 public static void UART_Open()~
        public dllESDRegister._Execution _UART_Open(dllESDRegister._Object _Register)
        {
            dllESDRegister._Execution _execution_result = new dllESDRegister._Execution();
            try
            {

                if (System_IO_SerialPort_ESD.IsOpen == false)
                    System_IO_SerialPort_ESD.Open();

                return _execution_result.Clone() as dllESDRegister._Execution;
            }
            #region 例外
            catch (UnauthorizedAccessException)
            {
                //ISP Board被其他未知程式占用
                System_IO_SerialPort_ESD.Close();
                return _execution_result.Clone() as dllESDRegister._Execution;
            }

            catch (IOException)
            {
                //關閉ISP傳輸埠失敗
                System_IO_SerialPort_ESD.Close();
                return _execution_result.Clone() as dllESDRegister._Execution;
            }

            catch (ArgumentOutOfRangeException)
            {
                //串口設定值不符合該設備
                System_IO_SerialPort_ESD.Close();
                return _execution_result.Clone() as dllESDRegister._Execution;
            }

            catch (ArgumentNullException)
            {
                //ISP Board參數錯誤
                System_IO_SerialPort_ESD.Close();
                return _execution_result.Clone() as dllESDRegister._Execution;
            }

            catch (InvalidOperationException)
            {
                //通訊開啟中,請關閉該通訊,始可開始設定
                System_IO_SerialPort_ESD.Close();
                return _execution_result.Clone() as dllESDRegister._Execution;
            }
            catch (TimeoutException)
            {
                //通訊開啟中,請關閉該通訊,始可開始設定
                System_IO_SerialPort_ESD.Close();
                return _execution_result.Clone() as dllESDRegister._Execution;
            }
            #endregion
        }

        // ~關閉ESD BOARD通訊設定 public static void UART_Close()~
        public dllESDRegister._Execution _UART_Close(dllESDRegister._Object _Register)
        {
            dllESDRegister._Execution _execution_result = new dllESDRegister._Execution();
            try
            {
                if (System_IO_SerialPort_ESD.IsOpen == true)
                    System_IO_SerialPort_ESD.Close();

                return _execution_result.Clone() as dllESDRegister._Execution;
            }
            #region 例外
            catch (UnauthorizedAccessException)
            {
                //ISP Board被其他未知程式占用
                System_IO_SerialPort_ESD.Close();
                return _execution_result.Clone() as dllESDRegister._Execution;
            }

            catch (IOException)
            {
                //關閉ISP傳輸埠失敗
                System_IO_SerialPort_ESD.Close();
                return _execution_result.Clone() as dllESDRegister._Execution;
            }

            catch (ArgumentOutOfRangeException)
            {
                //串口設定值不符合該設備
                System_IO_SerialPort_ESD.Close();
                return _execution_result.Clone() as dllESDRegister._Execution;
            }

            catch (ArgumentNullException)
            {
                //ISP Board參數錯誤
                System_IO_SerialPort_ESD.Close();
                return _execution_result.Clone() as dllESDRegister._Execution;
            }

            catch (InvalidOperationException)
            {
                //通訊開啟中,請關閉該通訊,始可開始設定
                System_IO_SerialPort_ESD.Close();
                return _execution_result.Clone() as dllESDRegister._Execution;
            }
            catch (TimeoutException)
            {
                //通訊開啟中,請關閉該通訊,始可開始設定
                System_IO_SerialPort_ESD.Close();
                return _execution_result.Clone() as dllESDRegister._Execution;
            }
            #endregion
        }

        // ~ESD BOARD傳輸元件
        public dllESDRegister._Execution _UART_Transmitter(dllESDRegister._Object _Register, byte[] _CMD_Coding, int _CMD_WaitDelayTime)
        {
            dllESDRegister._Execution _execution_result = new dllESDRegister._Execution();
            try 
            {
                if (System_IO_SerialPort_ESD.IsOpen == false)
                    System_IO_SerialPort_ESD.Open();

                System_IO_SerialPort_ESD.DiscardInBuffer();
                System_IO_SerialPort_ESD.DiscardOutBuffer();

                System_IO_SerialPort_ESD.Write(_CMD_Coding,0,1);      //write data into serial port for 12 bytes
                if (_WaitDelayTime_Return(_CMD_WaitDelayTime) == true)         //call wait delay time try to fine the serial port buffer to compare return bytes = 12 bytes
                {
                    int _readcount = 0;
                    while (System_IO_SerialPort_ESD.BytesToRead != 0)
                    {
                        _execution_result.abytResult_ack[_readcount] = Convert.ToByte(System_IO_SerialPort_ESD.ReadByte());
                        _readcount++;
                    }

                    _readcount--;

                    if (_readcount == 0)
                    {
                        //_execution_result. _subFail_Level(_Const. Return_Status. Retest, ErrorCode. EISP20);
                    }
                }

                _execution_result.intResult_length = System_IO_SerialPort_ESD.BytesToRead;
                return _execution_result.Clone() as dllESDRegister._Execution;
            }
            #region 例外
            catch (UnauthorizedAccessException)
            {
                //ISP Board被其他未知程式占用
                System_IO_SerialPort_ESD.Close();
                return _execution_result.Clone() as dllESDRegister._Execution;
            }

            catch (IOException)
            {
                //關閉ISP傳輸埠失敗
                System_IO_SerialPort_ESD.Close();
                return _execution_result.Clone() as dllESDRegister._Execution;
            }

            catch (ArgumentOutOfRangeException)
            {
                //串口設定值不符合該設備
                System_IO_SerialPort_ESD.Close();
                return _execution_result.Clone() as dllESDRegister._Execution;
            }

            catch (ArgumentNullException)
            {
                //ISP Board參數錯誤
                System_IO_SerialPort_ESD.Close();
                return _execution_result.Clone() as dllESDRegister._Execution;
            }

            catch (InvalidOperationException)
            {
                //通訊開啟中,請關閉該通訊,始可開始設定
                System_IO_SerialPort_ESD.Close();
                return _execution_result.Clone() as dllESDRegister._Execution;
            }

            catch (TimeoutException)
            {
                //通訊開啟中,請關閉該通訊,始可開始設定
                System_IO_SerialPort_ESD.Close();
                return _execution_result.Clone() as dllESDRegister._Execution;
            }
            #endregion
        }

        // ~指令回傳等待時間
        private bool _WaitDelayTime_Return(int _temp_DelayTime)
        {
            bool _temp_WaitTimeResult = false;

            for (int i = 0; i <= _temp_DelayTime; i++)  //set a time loop for 1ms to check the ByteToRead =12
            {
                System.Threading.Thread.Sleep(1);   //delay 1ms for each loop
                if (System_IO_SerialPort_ESD.BytesToRead == 2)   //check the ByteTo Read is =12 or not
                {
                    _temp_WaitTimeResult = true; //if ByteToRead = 12, set WaitTimeResult=true 
                    //System. Threading. Thread. Sleep(i);
                    break;
                }
            }
            return _temp_WaitTimeResult;  //return Wait Time Result
        }
    }
}
