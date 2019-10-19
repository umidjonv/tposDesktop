using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public static class Generator
    {
        public static string barcode_generate(int id, int type)
        {
            int typeBarcode = type;
            switch (type)
            {
                case 1:
                    
                    break;
                case 2:
                    break;
                case 3:
                    break;
                
            }

            
            int cnt = id.ToString().Length;
            Random rand = new Random();
            string temp1 = "";

            if (cnt == 1)
            {
                temp1 = rand.Next(10000, 19999).ToString() + rand.Next(10000, 99999).ToString();
            }
            else if (cnt == 2)
            {
                temp1 = rand.Next(10000, 19999).ToString() + rand.Next(1000, 9999).ToString();
            }
            else if (cnt == 3)
            {
                temp1 = rand.Next(10000, 19999).ToString() + rand.Next(100, 999).ToString();
            }
            else if (cnt == 4)
            {
                temp1 = rand.Next(10000, 19999).ToString() + rand.Next(10, 99).ToString();
            }
            else if (cnt == 5)
            {
                temp1 = rand.Next(10000, 19999).ToString() + rand.Next(1, 9).ToString();
            }

            //ischange = true;
            temp1 = id.ToString() + temp1 + typeBarcode;
            long n;
            n = Convert.ToInt64(temp1);
            long oddSum = 0, evenSum = 0;
            bool odd = true;
            while (n != 0)
            {
                if (odd)
                    oddSum += n % 10;
                else
                    evenSum += n % 10;
                n /= 10;
                odd = !odd;

            }
            long temp2 = oddSum * 3 + evenSum;
            if (temp2 != 0)
            {
                long temp3 = temp2 % 10;
                temp1 = temp1 + ((temp3 == 0) ? temp3 : (10 - temp3)).ToString();
            }
            else
            {
                temp1 = temp1 + temp2.ToString();
            }
            return temp1;
        }
    }

    
}
