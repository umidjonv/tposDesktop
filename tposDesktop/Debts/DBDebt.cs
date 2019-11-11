using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tposDesktop;

namespace Classes.DB
{
    public class DBDebt
    {

        public static DataSetDebt DS { get; set; }
        public DBDebt()
        {
            DS = new DataSetDebt();
        }

    }
}
