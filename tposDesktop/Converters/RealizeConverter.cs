using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using tposDesktop;
using tposDesktop.Converters.Models;

namespace tposDesktop.Converters
{
    class RealizeConverter:Converter<DataSetTpos.realizeRow>
    {
        DataSetTpos.realizeRow _realizeRow;
        public RealizeConverter(DataSetTpos.realizeRow realizeRow):base(realizeRow)
        {
            _realizeRow = realizeRow;
        }

        public string Convert()
        {
            DateTime? expDate = null;
            if (!_realizeRow.IsexpiryDateNull()) expDate = _realizeRow.expiryDate;
            var realize = new Realize()
            {
                fakturaId = _realizeRow.fakturaId,
                count = _realizeRow.count,
                productId = _realizeRow.prodId,
                price = _realizeRow.price,
                soldPrice = _realizeRow.soldPrice,
                expiryDate =  expDate


            };
            string json = JsonConvert.SerializeObject(realize);
            return json;
        }
         
    }
}
