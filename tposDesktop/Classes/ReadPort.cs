using System;
using System.Collections.Generic;

using System.Text;

using System.Timers;
using System.IO.Ports;
using System.Threading;

namespace Serial
{
    public class ReadPort
    {

        public static int command_timeout = 500;
        public bool textMode = false;

        public ReadPort()
        {
            //OpenPort("COM1", 9600, 8, 1000, 300);
        }
        #region Open and Close Ports
        //Open Port
        public SerialPort OpenPort(string p_strPortName, int p_uBaudRate, int p_uDataBits, int p_uReadTimeout, int p_uWriteTimeout)
        {
            receiveNow = new AutoResetEvent(false);
            SerialPort port = new SerialPort();

            try
            {
                port.PortName = p_strPortName;                 //COM1
                port.BaudRate = p_uBaudRate;                   //9600
                port.DataBits = p_uDataBits;                   //8
                port.StopBits = StopBits.One;                  //1
                port.Parity = Parity.None;                     //None
                port.ReadTimeout = p_uReadTimeout;             //300
                port.WriteTimeout = p_uWriteTimeout;           //300
                port.Encoding = Encoding.GetEncoding("iso-8859-1");
                port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                port.Open();
                port.DtrEnable = true;
                port.RtsEnable = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return port;
        }

        //Close Port
        public void ClosePort(SerialPort port)
        {
            try
            {
                port.Close();
                port.DataReceived -= new SerialDataReceivedEventHandler(port_DataReceived);
                port = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        //Execute AT Command


        //Receive data from port
        public void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (e.EventType == SerialData.Chars)
                {
                    receiveNow.Set();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string ReadResponse(SerialPort port, int timeout, string errorMessage)
        {
            string buffer = string.Empty;
            try
            {
                //do
                //{
                if (receiveNow.WaitOne(timeout, false))
                {
                    string t = port.ReadExisting();
                    buffer += t;
                }
                else
                {
                    if (buffer.Length > 0)
                    {
                        if (buffer.ToUpper().Contains("ERROR"))
                        {
                            throw new ApplicationException("err:" + buffer + "." + errorMessage);
                        }
                        else
                        {
                            buffer += "buffer not have error and ok";
                        }

                    }
                    else
                        throw new ApplicationException("No data received from phone. " + errorMessage);
                }
                //}
                //while (!buffer.EndsWith("\r\nOK\r\n") && !buffer.EndsWith("\r\n> "));//(!buffer.EndsWith("\r\nERROR\r\n")
            }
            catch (Exception ex)
            {
                Console.WriteLine("No data");
            }
            return buffer;
        }

        #region Count SMS

        #endregion

        #region Read SMS

        public AutoResetEvent receiveNow;



        #endregion




    }


}
