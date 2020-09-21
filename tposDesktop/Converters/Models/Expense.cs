using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tposDesktop.Converters.Models
{
	public class Expense
	{
		public DateTime? expenseDate { get; set; }

		public int debt { get; set; }

		public int? contragentId { get; set; }

		public int expType { get; set; }

		public int terminal { get; set; }

		public int expSum { get; set; }

		public int status { get; set; }

		public int userID { get; set; }

		public int charge { get; set; }
		
		public int stockId { get; set; }


	}
	
}
