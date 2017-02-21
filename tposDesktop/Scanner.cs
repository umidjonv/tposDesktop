using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;
using System.ComponentModel;
using System.IO.Ports;

namespace tposDesktop
{
    class Scanner
    {
        SerialPort port;
        Serial.ReadPort rd;
        public event ScannerEventHandler ScannerEvent;
        public bool isWorked = true;
        public Scanner()
        {
            rd = new Serial.ReadPort();
            port = rd.OpenPort("COM3", 9600, 8, 1000, 300);
            BackgroundWorker bg = new BackgroundWorker();
            bg.DoWork += bg_DoWork;
            bg.RunWorkerAsync();
 
        }

        void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            //bool f = false;
            while (true)
            {
                if (isWorked == false)
                {
                    break;
                }
                string str = rd.ReadResponse(port, 100, "not found");
                if (str != "" && str != null)
                {
                    
                    ScannerEvent(this, new ScannerEventArgs(str));
                }
                System.Threading.Thread.Sleep(500);
            }
        }


    }
    public delegate void ScannerEventHandler(object source, ScannerEventArgs e);
    public class ScannerEventArgs : EventArgs
    {
        private string EventInfo;
        public ScannerEventArgs(string Text)
        {
            EventInfo = Text;
        }
        public string GetInfo()
        {
            return EventInfo;
        }
    }
}
