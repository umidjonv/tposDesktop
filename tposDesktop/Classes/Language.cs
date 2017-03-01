using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    
    class Language
    {
        
        
        string[] keys = {"LOGIN", "PASS","ENTER"};
        Dictionary<string, string> dic_uz;
        Dictionary<string, string> dic_ru;
        Dictionary<string, string> dic;
        public enum lng { uz, ru }
        lng lang;
        public Language(lng lg)
        {
            lang = lg;
            dic = new Dictionary<string, string>();
            string[] vals;
            switch (lang)
            {
                case lng.ru:
                    dic.Clear();
                    set_ru();
                    
                    break;
                case lng.uz:
                    dic.Clear();
                    set_uz();
                    
                    break;
            }
            

        }

        public void set_uz()
        {
            dic["Login"] = "Login";
            dic["Pass"] = "Parol";
            dic["Login_Enter"] = "Kirish";
            dic["Err_Login"] = "Foydalanuvchi nomi yoki paroli xato kiritilgan";
            
        }
        public void set_ru()
        {
            dic["Login"] = "Логин";
            dic["Pass"] = "Пароль";
            dic["Login_Enter"] = "Вход";
            dic["Err_Login"] = "Логин или пароль введён неверно";

        }

        public string Value(string val)
        {
            return dic[val];

            
        }
        
        public void setValue(string str)
        {
 
        }
    }
}
