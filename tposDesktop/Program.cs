using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace tposDesktop
{
    static class Program
    {
        enum WorkType { Touch, Mouse };
        static WorkType wType = WorkType.Mouse;
        public static int window_type =1;
        public static bool onClose = false;
        public static int oldWindow_type;
        public static Classes.Language Lang;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
                Lang = new Classes.Language(Classes.Language.lng.ru);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
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
       
    } 
    static class UserValues
    {
        public static string CurrentUser;
        public static int CurrentUserID;
        public static int CurrentTable;
        public static int expense_id;
        public static string role;

    }
    struct Paramaters
    {
        string LangPath;
        
    }
}
