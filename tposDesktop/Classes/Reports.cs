using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using MySql;
using MySql.Data.MySqlClient;
using System.Data;
namespace Classes
{
    class Reports
    {
        
        Application excel;
        public Reports(MySqlConnection connect)
        {
            connection = connect;
 
        }
        MySqlConnection connection;
        //Прибыль
        public void PeriodProfid(DateTime begin, DateTime end)
        {
            if ((end - begin).Days <= 5)
            {
                string beginDate = begin.ToString("yyyy-MM-dd");
                string endDate = end.ToString("yyyy-MM-dd");

                //excel = new Application();
                //excel.Visible = true;
                //excel.Workbooks.Add();
                //Microsoft.Office.Interop.Excel.Worksheet workSheet = (Microsoft.Office.Interop.Excel.Worksheet)excel.ActiveSheet;
                ExcelClass excel_class = new ExcelClass();
                excel_class.Open(System.Windows.Forms.Application.StartupPath + "\\reports\\period_expense1.xls");


                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;
                command.CommandText = GetQueryExpense(beginDate, endDate);
                System.Data.DataTable tableExpense = new System.Data.DataTable();
                System.Data.DataTable tableRealize = new System.Data.DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(tableExpense);
                command.CommandText = GetQueryRealize();
                adapter.Fill(tableRealize);

                excel_class.ColWidth("B", 50);
                int i = 7;
                foreach (DataRow dr in tableExpense.Rows)
                {
                    DataRow[] dr1 = tableRealize.Select("productId = " + dr["productId"]);
                    if (dr["productId"].ToString() == "2635")
                    { }
                    excel_class.SetCell("A" + i, dr["productId"].ToString(), false);
                    excel_class.SetCell("B" + i, dr["name"].ToString(), false);
                    //if (dr["measureId"].ToString() == "2")
                    //    excel_class.SetCell("C" + i, "ШТ", false);
                    //else
                    //    excel_class.SetCell("C" + i, "КГ", false);

                    excel_class.SetCell("E" + i, dr["SumCount"].ToString(), false);
                    excel_class.SetCell("F" + i, dr["SumOrder"].ToString(), false);
                    if (dr1.Length != 0)
                    {
                        double raznica = double.Parse(dr1[0]["soldPrice"].ToString()) - double.Parse(dr1[0]["price"].ToString());
                        excel_class.SetCell("G" + i, (double.Parse(dr["SumCount"].ToString()) * raznica).ToString(), false);
                    }
                    i++;


                }

                excel_class.activeSheet.Application.Visible = true;

            }



            //workSheet.get_Range("A").ColumnWidth = 35;
            
        }
        public void Selling(DateTime beginDate, DateTime endDate)
        {
            string dateBegin = beginDate.ToString("yyyy-MM-dd");
            string dateEnd = endDate.ToString("yyyy-MM-dd");

            //excel = new Application();
            //excel.Visible = true;
            //excel.Workbooks.Add();
            //Microsoft.Office.Interop.Excel.Worksheet workSheet = (Microsoft.Office.Interop.Excel.Worksheet)excel.ActiveSheet;
            ExcelClass excel_class = new ExcelClass();
            excel_class.Open(System.Windows.Forms.Application.StartupPath + "\\reports\\period_saldo.xls");


            MySqlCommand command = new MySqlCommand();
            command.Connection = connection;
            command.CommandText = GetQueryReport2(dateBegin, dateEnd);
            System.Data.DataTable tableReport = new System.Data.DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(tableReport);
            //command.CommandText = GetQueryExpense(dateBegin, dateEnd);
            //adapter.Fill(tableExpense);

            excel_class.ColWidth("B", 50);

            int i = 7;
            //DataRow[] rBalanceSaldo = tableBalanceList.Select("balanceDate = '"+dateBegin+"'");
            //DataRow[] rBalanceOstatok = tableBalanceList.Select("balanceDate = '" + dateEnd + "'");

            foreach (DataRow dr in tableReport.Rows)
            {
                

                excel_class.SetCell("A" + i, dr["productId"].ToString(), false);
                excel_class.SetCell("B" + i, dr["name"].ToString(), false);
                excel_class.SetCell("D" + i, dr["saldoCount"].ToString(), false);
                excel_class.SetCell("E" + i, dr["price"].ToString(), false);

                excel_class.SetCell("F" + i, Math.Round(double.Parse(dr["saldoCount"].ToString()) * double.Parse(dr["price"].ToString()),3).ToString(), false);

                excel_class.SetCell("G" + i, dr["prixCount"].ToString(), false);
                excel_class.SetCell("H" + i, dr["prPrice"].ToString(), false);
                if (dr["prixCount"] != DBNull.Value)
                {
                    excel_class.SetCell("I" + i, Math.Round(double.Parse(dr["prixCount"].ToString()) * double.Parse(dr["prPrice"].ToString()),3).ToString(), false);
                }

                excel_class.SetCell("K" + i, dr["spisCount"].ToString(), false);
                excel_class.SetCell("L" + i, dr["spisSumm"].ToString(), false);
                if (dr["spisCount"] != DBNull.Value)
                {
                    excel_class.SetCell("M" + i, Math.Round(double.Parse(dr["spisCount"].ToString()) * double.Parse(dr["spisSumm"].ToString()),3).ToString(), false);
                }
                excel_class.SetCell("N" + i, dr["exCount"].ToString(), false);
                excel_class.SetCell("O" + i, dr["exSumm"].ToString(), false);
                if (dr["exCount"] != DBNull.Value)
                {
                    excel_class.SetCell("P" + i, Math.Round(double.Parse(dr["exCount"].ToString()) * double.Parse(dr["exSumm"].ToString()),3).ToString(), false);
                }

                excel_class.SetCell("Q" + i, dr["backCount"].ToString(), false);
                excel_class.SetCell("R" + i, dr["backSumm"].ToString(), false);
                if (dr["backCount"] != DBNull.Value)
                {
                    excel_class.SetCell("S" + i, Math.Round(double.Parse(dr["backCount"].ToString()) * double.Parse(dr["backSumm"].ToString()),3).ToString(), false);
                }

                excel_class.SetCell("T" + i, dr["ostatokCount"].ToString(), false);
                excel_class.SetCell("U" + i, dr["price"].ToString(), false);
                if (dr["ostatokCount"] != DBNull.Value)
                {
                    excel_class.SetCell("V" + i, Math.Round(double.Parse(dr["ostatokCount"].ToString()) * double.Parse(dr["price"].ToString()),3).ToString(), false);
                }
                i++;


            }
            excel_class.activeSheet.Application.Visible = true;
        }

        public void TodayOrdersReport(string date)
        {
            
            
            ExcelClass excel_class = new ExcelClass();
            excel_class.Open(System.Windows.Forms.Application.StartupPath + "\\reports\\today_orders.xls");


            MySqlCommand command = new MySqlCommand();
            command.Connection = connection;
            command.CommandText = this.GetDateOrdersReport(date);
            System.Data.DataTable tableReport = new System.Data.DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(tableReport);
            command.CommandText = "select sum(e.expSum) as summa, sum(e.terminal) as terminal from expense as e where e.expType = 1 and date(e.expenseDate) = date("+date+")"+(userID == ""?"":" and e.userID ="+userID);
            System.Data.DataTable table2 = new System.Data.DataTable();
            adapter.Fill(table2);
            int i = 7;
            string expVal = "";
            int summa = 0;
            int dolg = 0;
            int terminal = 0;

            System.Drawing.Color clr1 = System.Drawing.Color.FromArgb(184, 197, 230);
            System.Drawing.Color clr2 = System.Drawing.Color.FromArgb(104, 222, 159);
            
            excel_class.SetCell("D1", "Магазин \""+tposDesktop.Properties.Settings.Default.orgName+"\"", false);
            excel_class.SetCell("D2", "Отчёт по продажам за " + (date == "now()"?"сегодня":date), false);
            excel_class.backColor = clr2;
            foreach (DataRow dr in tableReport.Rows)
            {
                if (expVal != dr["expenseId"].ToString())
                {
                    if (excel_class.backColor == clr1)
                    {
                        excel_class.backColor = clr2;
                    }else
                    {
                        excel_class.backColor = clr1;
                    }
                    expVal = dr["expenseId"].ToString();
                    if (dr["status"].ToString() == "0")
                    {
                        summa += Convert.ToInt32(dr["expSum"].ToString());
                    }
                    else
                    {
                        dolg += Convert.ToInt32(dr["expSum"].ToString());
                    }
                    int term = Convert.ToInt32(dr["terminal"].ToString());
                    terminal += term;
                    excel_class.SetCell("H" + i, dr["expSum"].ToString(), false);
 
                }
                excel_class.SetCell("A" + i, dr["expenseId"].ToString(), false);
                excel_class.SetCell("B" + i, dr["prodId"].ToString(), false);
                excel_class.SetCell("C" + i, dr["expenseDate"].ToString(), false);
                excel_class.SetCell("D" + i, dr["name"].ToString(), false);
                excel_class.SetCell("E" + i, dr["meas"].ToString(), false);
                excel_class.SetCell("F" + i, dr["packCount"].ToString(), false);
                excel_class.SetCell("G" + i, dr["orderSumm"].ToString(), false);
                //excel_class.SetCell("H" + i, dr["expSum"].ToString(), false);
                excel_class.SetCell("I" + i, dr["Debts"].ToString(), false);

                
                
                i++;
            }
            excel_class.backColor = System.Drawing.Color.White;
            excel_class.SetCell("F" + i, "Итого:", true);
            
            excel_class.SetCell("G" + i, "Сумма продажи:", true);
            excel_class.SetCell("H" + i, summa.ToString(), true);

            i++;
            excel_class.SetCell("G" + i, "Наличные:", true);
            excel_class.SetCell("H" + i, (summa-terminal).ToString(), true);
            
            i++;
            excel_class.SetCell("G" + i, "Терминал:", true);
            excel_class.SetCell("H" + i, terminal.ToString(), true);

            i++;
            excel_class.SetCell("G" + i, "Долг:", true);
            excel_class.SetCell("H" + i, dolg.ToString(), true);

            if (table2.Rows.Count > 0 && table2.Rows[0]["summa"]!=DBNull.Value)
            {
                i+=2;
                excel_class.SetCell("G" + i, "Возврат:", true);
                excel_class.SetCell("H" + i, table2.Rows[0]["summa"].ToString(), true);
                excel_class.SetCell("I" + i, table2.Rows[0]["terminal"].ToString(), true);
                i++;
                excel_class.SetCell("F" + i, "Всего наличных:", true);
                excel_class.SetCell("H" + i, ("=H"+(i-5)+"-(H"+(i-1)+"-I"+(i-1)+")").ToString(), true);
            }
            excel_class.activeSheet.Application.Visible = true;
            excel_class.savepath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+"\\"+(date=="now()"?DateTime.Now.ToShortDateString():date) +"_report.xls";
            excel_class.SaveOnly();
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

        private string GetQueryExpense(string begin, string end)
        {
            var query = "select distinct(p.productId) as productId, p.name as name, "+
            "(case when (p.measureId <> 2) then Round(sum(o.packCount), 3) else sum(o.packCount) end) as SumCount, sum(o.orderSumm) as SumOrder "+
                "from expense as e join orders as o "+
		        "on e.expenseId = o.expenseId "+
		        "join product as p on p.productId = o.prodId "+
                "where e.expenseId is not null and e.expenseDate between '"+begin+"' and '"+end+"' and expType = 0 "+  
		        "group by p.productId";
            return query;
        }
        

        private string GetQueryRealize()
        {
            var query = "select * from (select  p.productId, p.name, f.fakturaDate, r.price, r.soldPrice  from realize r join product p " +
                "on r.prodId = p.productId join faktura f " +
                "on r.fakturaId = f.fakturaId " +
                "order by fakturaDate desc) as t group by productId ";
            return query;
        }

        private string GetQueryReport2(string begin, string end)
        {
            string dateBetween = "'" + begin + "' and '" + end + "'";
            string query = "select p.productId,  p.name, b.endCount as saldoCount, b1.endCount as ostatokCount, p.price as price, "+
                "(case when (p.measureId <> 2) then Round(rl.sumCount, 3) else rl.sumCount end) as prixCount, " +
                "rl.price as prPrice, rl.soldPrice as prSoldPrice, "+
                "(case when (p.measureId <> 2) then Round(back.SumCount, 3) else back.SumCount end) as backCount, back.SumOrder as backSumm, " +
                "(case when (p.measureId <> 2) then Round(spis.SumCount, 3) else spis.SumCount end)  as spisCount, spis.SumOrder as spisSumm, " +
                "(case when (p.measureId <> 2) then Round(ex.SumCount, 3) else ex.SumCount end) as exCount, ex.SumOrder as exSumm " +
                "from product p left join balancelist b "+
                "on p.productId = b.prodId "+
                "left join balancelist b1 on p.productId = b1.prodId "+
                "left join "+
                "(select productId, fakturaDate, price, soldPrice, sum(count) as sumCount from  "+
                "(select  r.prodId as productId, f.fakturaDate, r.price, r.soldPrice, r.count  from realize r join faktura f  "+
                "                on r.fakturaId = f.fakturaId  "+
                "		                where f.fakturaDate between "+dateBetween+" " +
                "                order by fakturaDate desc) as t group by productId) as rl "+
                "on p.productId = rl.productId "+
                "left join /*vozvrat*/ "+
                "(select distinct(o.prodId) as productId, sum(o.packCount) as SumCount, sum(o.orderSumm) as SumOrder  "+
                "                from expense as e join orders as o  "+
                "                on e.expenseId = o.expenseId "+
                "                where e.expenseId is not null and e.expenseDate between " + dateBetween + " and expType = 1  " +
                "                group by o.prodId) as back "+
                "on p.productId = back.productId "+
                "/*spisaniye*/ "+
                "left join (select distinct(o.prodId) as productId, sum(o.packCount) as SumCount, sum(o.orderSumm) as SumOrder  "+
                "                from expense as e join orders as o  "+
                "                on e.expenseId = o.expenseId "+
                "                where e.expenseId is not null and e.expenseDate between " + dateBetween + " and expType = 3  " +
                "                group by o.prodId) as spis "+
                "on p.productId = spis.productId "+
                "left join (select distinct(o.prodId) as productId, sum(o.packCount) as SumCount, sum(o.orderSumm) as SumOrder  "+
                "                from expense as e join orders as o "+ 
                "               on e.expenseId = o.expenseId "+
                "                where e.expenseId is not null and e.expenseDate between " + dateBetween + " and expType = 0 " +
                "                group by o.prodId) as ex "+
                "on p.productId = ex.productId "+
                "where (b.balanceDate = '"+begin+"' and b1.balanceDate = '"+end+"') and not ex.SumCount is null";
            return query;
        }
        public string userID = "";
        private string GetDateOrdersReport(string date)
        {
            var query = "";
            query = "select e.expenseId, o.prodId, p.name,(case when p.measureId = 2 then 'шт' else 'кг' end) as meas , "+
                "o.packCount, e.`Status`, e.expSum, e.terminal , o.orderSumm, e.expenseDate, " +
                "(case when p.measureId = 2 THEN (o.orderSumm*o.packCount) else Round(o.orderSumm*o.packCount, 3) end) as summ, " +
                "(case when e.debt = 1 then 'Долг' else '' end) as Debts, e.userID "+
            "from expense as e left join orders as o " +
                "on e.expenseId = o.expenseId "+
                "left join product as p on p.productId = o.prodId "+
                "where date(e.expenseDate) = date(" + date + ") and e.expType = 0 "+(userID==""?"":" and e.userID ="+userID);
            return query;
        }
        private string GetTodayVozvrat()
        {
            var query = "";
            query = "select e.expenseId, o.prodId, p.name,(case when p.measureId = 2 then 'шт' else 'кг' end) as meas , " +
                "o.packCount, e.`Status`, e.expSum, e.terminal , o.orderSumm, e.expenseDate, " +
                "(case when p.measureId = 2 THEN (o.orderSumm*o.packCount) else Round(o.orderSumm*o.packCount, 3) end) as summ, " +
                "(case when e.debt = 1 then 'Долг' else '' end) as Debts from expense as e left join orders as o " +
                "on e.expenseId = o.expenseId " +
                "left join product as p on p.productId = o.prodId " +
                "where date(e.expenseDate) = date(now()) and e.expType = 2";
            return query;
        }

    }
}
