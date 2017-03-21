using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Management;
using System.Windows.Forms;
using System.IO;

namespace Cryptapp
{
    class Check
    {
        public Check(string key, DateTime extime)
        {
            Key = key;
            time = extime;
            ProcessorID = GetProcessorId();
            time = extime;
            

        }
        string ProcessorID;
        string Key;
        DateTime time;
        string Hash;
        public static String GetProcessorId()
        {

            ManagementClass mc = new ManagementClass("win32_processor");
            ManagementObjectCollection moc = mc.GetInstances();
            String Id = String.Empty;
            foreach (ManagementObject mo in moc)
            {

                Id = mo.Properties["processorID"].Value.ToString();
                break;
            }
            return Id;


        }
        private string GetMD5(string keyID)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(keyID);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }
        
        public string CreateHash()
        {
            string hash = GetMD5(Key + ProcessorID+time.ToString("dd.MM.YYYY"));
            Hash = hash;
            return hash;
        }

        public void SaveHash()
        {
            StreamWriter sw = new StreamWriter(Application.StartupPath+ "\\tpos.data");
            sw.WriteLine(Hash);
            sw.Close();
        }


        public bool CheckExist(string hash)
        {
            try
            {
                StreamReader sr = new StreamReader(Application.StartupPath + "\\tpos.data");
                string h = sr.ReadLine();
                sr.Close();
                if (hash == h)
                {
                    return true;
                }
                else
                    return false;
                
            }
            catch (Exception ex)
            {
                
                return false;
            }
 
        }
        
        
        
    }
}
