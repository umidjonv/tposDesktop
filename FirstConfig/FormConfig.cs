using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Classes.Forms;
using System.Diagnostics;
using System.IO;
using System.ComponentModel;
using MySql.Data.MySqlClient;
using System.ServiceProcess;

namespace FirstConfig
{
    public partial class FormConfig : DesignedForm
    {
        public FormConfig()
        {
            InitializeComponent();

            
            
        }
        BackgroundWorker worker;
        private void FormConfig_Load(object sender, EventArgs e)
        {
            status = new SetStatusDel(SetStatus);
            worker = new System.ComponentModel.BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.DoWork += worker_DoWork;
        }

        void worker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            pbConfig.Value = e.ProgressPercentage;
        }
        public delegate void SetStatusDel(string txt);
        SetStatusDel status;
        void SetStatus(string txt)
        {
            lbxConfig.Items.Insert(0, txt);
            
                //lbxConfig.Items.Add(txt);
            
        }

        void Message(string txt)
        {
            this.Invoke(status, new object[] { txt }); 
        }

        void worker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            Message("Установка MySql сервера...");
            bool isInstalled = false;
            Process msiProc = new Process();

            ProcessStartInfo startInfo = new ProcessStartInfo("msiexec.exe");
            startInfo.UseShellExecute = true;

            startInfo.Arguments = "/i \"" + Directory.GetCurrentDirectory() + "\\install\\mysql-5.5.23-winx64.msi\" /passive";
            startInfo.WorkingDirectory = @"C:\Windows\temp\";
            startInfo.Verb = "runas";
            msiProc.StartInfo = startInfo;
            if (msiProc.Start())
            {


                msiProc.WaitForExit();
                if (msiProc.ExitCode == 0)
                {
                    worker.ReportProgress(50);
                    Message("Конфигурирование MySql...");
                    Process procConfig = new Process();
                    ProcessStartInfo configInfo = new ProcessStartInfo(@"C:\Program Files\MySQL\MySQL Server 5.5\bin\MySQLInstanceConfig.exe");
                    configInfo.Arguments = "-i -q ServerType=DEVELOPMENT DatabaseType=MIXED ServiceName=MySql Charset=utf8 RootPassword=198923233171 RootCurrentPassword=198923233171 max_allowed_packet=4M";
                    configInfo.UseShellExecute = true;
                    configInfo.Verb = "runas";
                    procConfig.StartInfo = configInfo;
                    if (procConfig.Start())
                    {
                        procConfig.WaitForExit();
                        
                        if (procConfig.ExitCode == 0)
                        {
                            isInstalled = true;

                            StreamWriter writer= new StreamWriter(@"C:\Program Files\MySQL\MySQL Server 5.5\my.ini", true);
                            writer.Write("max_allowed_packet = 10M");
                            writer.Close();

                            RestartService("MySql", 20000);


                            //Process mysqlProc = new Process();

                            //ProcessStartInfo startInfoM = new ProcessStartInfo(@"C:\Program Files\MySQL\MySQL Server 5.5\bin\mysql.exe");
                            //startInfoM.UseShellExecute = true;

                            //startInfoM.Arguments = "--max_allowed_packet=8M";
                            ////startInfoM.WorkingDirectory = @"C:\Windows\temp\";
                            //startInfoM.Verb = "runas";
                            //mysqlProc.StartInfo = startInfoM;
                            //mysqlProc.Start();
                            
                        }
                        else
                        { Message("Код ошибки:" + procConfig.ExitCode.ToString()); }
                    }
                    else
                    {
                        Message("Код ошибки:"+procConfig.ExitCode.ToString());
                    }

                }
                else
                    Message("Код ошибки:" + msiProc.ExitCode.ToString());

                if (isInstalled)
                {
                    Message("Установка скриптов...");
                    ConnectingDB(worker);
 
                }
                worker.ReportProgress(100);
                Message("Готово!");
            }
        }
        private void RestartService(string serviceName, int timeoutMilliseconds)
        {
            ServiceController service = new ServiceController(serviceName);
            try
            {
                int millisec1 = Environment.TickCount;
                TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);

                service.Stop();
                service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);

                int millisec2 = Environment.TickCount;
                timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds - (millisec2 - millisec1));

                service.Start();
                service.WaitForStatus(ServiceControllerStatus.Running, timeout);
            }
            catch(Exception ex)
            {
                Message(ex.Message);

            }
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (worker != null)
            {
                worker.RunWorkerAsync();
            }
            
        }
        private void ConnectingDB(BackgroundWorker worker)
        {
            bool isConnected = false;
            string conString = "server=localhost;user id=root;password=198923233171;";
            MySqlConnection connection = new MySqlConnection(conString);
            try
            {
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    isConnected = true;
                    Message("Создание БД");

                    MySqlCommand command = new MySqlCommand("create database stock", connection);
                    int i = command.ExecuteNonQuery();
                    if(i==1)
                        Message("БД создана!");
                    else
                    {
                        Message("Ошибка при создании БД!");
                        isConnected = false;
                    }
                    
                    connection.Close();
                }
            }catch(Exception ex)
            {
                Message("Ошибка: " + ex.Message);
            }
            if (isConnected)
            { 
                conString += "database=stock;" ;
                connection = new MySqlConnection(conString);
                StreamReader sr;
                MySqlCommand command;
                //if (connection.State == ConnectionState.Closed)
                //{



                //    command = new MySqlCommand("set GLOBAL max_allowed_packet = 10485760;", connection);
                //    connection.Open();

                //    int i = command.ExecuteNonQuery();
                //    connection.Close();

                //}
                if(connection.State == ConnectionState.Closed)
                {
                    string[] getFiles = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\scripts\\tables\\");
                    Message("Генерация таблиц...");
                    connection.Open();
                    foreach (string file in getFiles)
                    {
                        command = new MySqlCommand();
                        string query = File.ReadAllText(file);
                        
                        command.Connection = connection;
                        command.EnableCaching = true;
                        command.CommandType = CommandType.Text;
                        command.CommandText = query;
                        command.ExecuteNonQuery();
                        Message(file.Replace(Directory.GetCurrentDirectory()+"\\scripts\\tables\\", ""));

                    }
                    connection.Close();                    
                    Message("Генерация таблиц завершена!");
                    
                }
                string[] procedures = { "prodBalance", "checkRealize", "curbalance", "balanceCalc", "getPrice", "BackTrigger", "ExpenseTrigger", "FakturaTrigger" };
                if (connection.State == ConnectionState.Closed)
                {

                    string[] views = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\scripts\\views\\");
                    Message("Генерация представлений и процедур...");
                    connection.Open();
                    foreach (string file in views)
                    {
                        command = new MySqlCommand();
                        string query = File.ReadAllText(file);

                        command.Connection = connection;
                        command.EnableCaching = true;
                        command.CommandType = CommandType.Text;
                        command.CommandText = query;
                        command.ExecuteNonQuery();
                        Message(file.Replace(Directory.GetCurrentDirectory() + "\\scripts\\views\\", ""));

                    }
                    foreach (string file in procedures)
                    {
                        command = new MySqlCommand();
                        string query = File.ReadAllText(Directory.GetCurrentDirectory() + "\\scripts\\procedures\\"+file+".sql");

                        command.Connection = connection;
                        command.EnableCaching = true;
                        command.CommandType = CommandType.Text;
                        command.CommandText = query;
                        command.ExecuteNonQuery();
                        Message(file.Replace(Directory.GetCurrentDirectory() + "\\scripts\\procedures\\", ""));

                    }
                    connection.Close();
                    Message("Генерация таблиц завершена!");
                    
                }
            }
            
 
        }
    }
}
