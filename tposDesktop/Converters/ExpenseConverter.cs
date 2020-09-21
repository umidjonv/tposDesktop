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
    class ExpenseConverter:Converter<DataSetTpos.expenseRow>
    {
        DataSetTpos.expenseRow _expenseRow;
        public ExpenseConverter(DataSetTpos.expenseRow expenseRow):base(expenseRow)
        {
            _expenseRow = expenseRow;
        }

        public string Convert()
        {

            if (!UserValues.stockId.HasValue)
                return null;

            var expense = new Expense()
            {
                expenseDate = _expenseRow.expenseDate,
                debt = _expenseRow.debt,
                contragentId = _expenseRow.contragentId,
                expType = _expenseRow.expType,
                terminal = _expenseRow.terminal,
                expSum = _expenseRow.expSum,
                status = _expenseRow.status,
                userID = _expenseRow.userID,
                charge = _expenseRow.charge,
                stockId = UserValues.stockId??0


            };
            string json = JsonConvert.SerializeObject(expense);
            return json;
        }
         
    }
}
