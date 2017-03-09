using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.ComponentModel;

namespace Classes
{
    class TextScanner
    {
        string barcode;
        string temp;
        string compare;
        BackgroundWorker worker;

        public TextScanner()
        {
            worker = new BackgroundWorker();
            worker.DoWork += worker_DoWork;
            worker.RunWorkerAsync();

             
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (temp == compare&&!isEnd)
                {
                    temp = "";
                    compare = "";
                    barcode = "";
                }
                else 
                {
                    
                    compare = temp;
                }
                Thread.Sleep(500);
            }
        }
        public void Symbol(char ch)
        {
            temp += ch;
        }
        bool isEnd = false;
        public void End()
        {
            isEnd = true;
            barcode = temp;
        }
        public void Start()
        {
            isEnd = false;
            
        }
    }
}
