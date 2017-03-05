using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class ProductOne
    {
        public ProductOne(string barCode, System.Data.DataRow[] dr)
        {
            drow = dr;
            barcode = barCode;
 
        }
        public string barcode;
        public System.Data.DataRow[] drow;
    }
}
