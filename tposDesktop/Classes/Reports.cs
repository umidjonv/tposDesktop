using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
namespace Classes
{
    class Reports
    {
        Application excel;
        //Прибыль
        public void PeriodProfid()
        {
            excel = new Application();
            excel.Visible = true;
            excel.Workbooks.Add();
            Microsoft.Office.Interop.Excel.Worksheet workSheet = (Microsoft.Office.Interop.Excel.Worksheet)excel.ActiveSheet;


            //workSheet.get_Range("A").ColumnWidth = 35;
            
        }

        private string GetQuery()
        {
            var query = "select " +
                        "p.productId, p.name, p.price, p.pack, p.measureId, ex.expenseId, ex.expenseDate," +
                        "ex.debt, ex.contragentId, ex.expSum, ex.terminal, ex.prodId, ex.count, ex.packCount," +
                        "ex.orderSumm " +
                        "from product as p left join " +
                            "(select e.expenseId, e.expenseDate, e.debt,e.contragentId, e.expSum, " +
                            "e.terminal, o.prodId, o.count, o.packCount, o.orderSumm  " +
                            "from expense as e left join orders as o " +
                            "on e.expenseId = o.expenseId) as ex " +
                            "on p.productId = ex.prodId " +
                            "where ex.orderSumm is not null";
            return query;
        }


    }
}
