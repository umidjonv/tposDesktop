using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tposDesktop.Converters.Models
{
    class Realize
    {
        public int fakturaId { get; set; }
        public int productId { get; set; }
        public float? count { get; set; }
        public float? price { get; set; }
        public float? soldPrice { get; set; }
        public DateTime? expiryDate { get; set; }
    }
}
