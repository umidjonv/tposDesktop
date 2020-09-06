using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tposDesktop.Converters
{
    public class Converter<T>
    {
        private T _row;
        public Converter(T row)
        {
            _row = row;
        }

        public string Convert()
        {
            string json = JsonConvert.SerializeObject(_row, Formatting.Indented);
            return json;
        }



    }
}
