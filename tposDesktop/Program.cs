using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Cryptapp;

namespace tposDesktop
{
    static class Program
    {
        enum WorkType { Touch, Mouse };
        static WorkType wType = WorkType.Mouse;
        public static int window_type = 3;
        public static bool onClose = false;
        public static int oldWindow_type;
        public static Classes.Language Lang;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] argument)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if(argument.Length!=0)
            {
                switch (argument[0])
                {
                    case "-config":
                        SettingsForm settings = new SettingsForm(argument[0]);
                        settings.ShowDialog();
                        break;
                    case "-admin":
                        break;
                }
            }
            DateTime expDate = Properties.Settings.Default.ExpDate;
            Cryptapp.Check ch = new Check(Properties.Settings.Default.SN, expDate);
            string hash = ch.CreateHash();
            if (ch.CheckExist(hash))
            {
                if (expDate >= DateTime.Now.Date)
                {
                    Lang = new Classes.Language(Classes.Language.lng.ru);
                   
                    Form form;
                    UserValues.role = "admin";
                    while (window_type != 0)
                    {

                        switch (window_type)
                        {
                            case 1:
                                Application.Run(new FormLogin());

                                break;
                            case 2:
                                Application.Run(new MainForm());
                                break;
                            case 3:
                                Application.Run(new FormAdmin());
                                break;

                        }

                        GC.Collect();
                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Изменена конфигурация, обратитесь в поддержку!");
                }

            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Изменена конфигурация, обратитесь в поддержку!");
            }
        }
       
    } 
    static class UserValues
    {
        public static string CurrentUser;
        public static int CurrentUserID;
        public static int CurrentTable;
        public static int expense_id;
        public static string role;
        public static string CurrentUserName;

    }
    struct Parameters
    {
        string LangPath;
        
    }
}
