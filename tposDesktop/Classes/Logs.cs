using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
namespace Classes
{
    class Logs
    {
        static Thread th;
        public enum LogStatus {Error, Warning, Info};
        public Logs()
        {
            th = new Thread(new ThreadStart(ThreadStarting));
            th.Start();
        }
        static Queue<LogMessage> messages = new Queue<LogMessage>();
        public static void SetLog(string message, LogStatus status)
        {
            SetLog(new LogMessage(message, status));
        }

        static void SetLog(LogMessage log)
        {
            messages.Enqueue(log);
            
        }
        
        static StreamWriter sw;
        static string message = "";
        static LogStatus stat;
        

        private static void ThreadStarting()
        {
            string curM = message;
            while (true)
            {
                
                if (messages.Count==0)
                { 
                    Thread.Sleep(5000);
                    continue;
                }

                Write(messages.Dequeue());
                
            }
        }
        static void Write(LogMessage log)
        {
            
            sw = new StreamWriter(Environment.CurrentDirectory + "tposLog" + DateTime.Now.ToShortDateString() + ".log", true);
            sw.WriteLine(log.l_status.ToString() + ";" + DateTime.Now.ToString() + ";Message:" + log.message);
            if (sw != null)
                sw.Close();
        }
        public static void StopLog()
        {
            if (th != null)
            {
                th.Abort();
            }
        }
        
    }
    class LogMessage 
    {
        public string message;
        public Logs.LogStatus l_status;
        public LogMessage(string msg, Logs.LogStatus status)
        {
            message = msg;
            l_status = status;
        }
    }
}
