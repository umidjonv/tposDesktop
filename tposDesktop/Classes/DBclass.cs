using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Threading;
using tposDesktop;
using tposDesktop.DataSetTposTableAdapters;
using System.ComponentModel;

namespace Classes.DB
{
    class DBclass
    {
        MySqlConnection connection;
        MySqlDataAdapter adapter;
        public DataTable Product { get; set; }
        public static DataSetTpos DS { get; set; }

        
        public UpdateThreading updateThread;
        //public DBclass()
        //{
        //    connection = new MySqlConnection("server=localhost;user id=foodsDB_user;password=D@faul(t);database=foods;persistsecurityinfo=True");
        //    string[] tables = { "employee", "dishes", "halfstaff", "products" };
        //    if (DS == null)
        //        DS = new DataSet();
        //    foreach(string tableName in tables)
        //    Fill(tableName);
        //}
        //string conStr = "server=localhost;user id=root;database=test;";//"server=localhost;user id=foodsDB_user;password=D@faul(t);database=foods;persistsecurityinfo=True";
        public DBclass(string[] tables)
        {
            connection = new MySqlConnection(tposDesktop.Properties.Settings.Default.testConnectionString);
            
            
            if (DS == null)
                DS = new DataSetTpos();
            foreach (string table in tables)
            {
                Fill(table);
            }
            updateThread = new UpdateThreading();
            
        }
        public DBclass()
        {
            connection = new MySqlConnection(tposDesktop.Properties.Settings.Default.testConnectionString);
            if (DS == null)
                DS = new DataSetTpos();
            //updateThread = new UpdateThreading();
        }

        public DBclass(bool isUpdateThread)
        {
            connection = new MySqlConnection(tposDesktop.Properties.Settings.Default.testConnectionString);
            if (DS == null)
                DS = new DataSetTpos();
            if(isUpdateThread)
            updateThread = new UpdateThreading();
        }

        public void Fill(string table_name)
        {
            try
            {
                adapter = new MySqlDataAdapter("select * from " + table_name, connection);
                DataTable dt = new DataTable(table_name);
                adapter.Fill(dt);
                if (!DS.Tables.Contains(table_name))
                {
                    DS.Tables.Add(dt);
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            //else
            //{
            //    DS.Tables.Remove(table_name);
            //    DS.Tables.Add(table_name);
            //}

            
        }
        public void FillExpense(string filter)
        {
            expenseTableAdapter daEx = new expenseTableAdapter();
            if (filter != "")
            {
                DS.expense.Clear();
                daEx.Adapter.SelectCommand = new MySqlCommand("select * from expense where " + filter, daEx.Connection);
                
                daEx.Adapter.Fill(DS.expense);
            }
            else
            {
                daEx.Fill(DS.expense);
            }
            //DS.expense
        }


        public void FillProduct()
        {

            tposDesktop.DataSetTposTableAdapters.productTableAdapter productDA = new tposDesktop.DataSetTposTableAdapters.productTableAdapter();



            productDA.Fill(DS.product);
        }
        public void FillNoZeroProduct()
        {

            tposDesktop.DataSetTposTableAdapters.productTableAdapter productDA = new tposDesktop.DataSetTposTableAdapters.productTableAdapter();



            productDA.FillNotZero(DS.product); 
        }

        

        public DataRow[] GetDishesRow(int id)
        {
            DataRow[] rows = DS.Tables["menu_dishes_v"].Select("type_id = " + id);
            return rows;
 
        }


        BackgroundWorker bgw;
        System.Windows.Forms.Form form;
        public void CloseDay()
        {
            bgw = new BackgroundWorker();
            bgw.DoWork += bgw_DoWork;
            bgw.RunWorkerAsync();
                
            

        }

        public void OpenDay(System.Windows.Forms.Form curForm)
        {
            form = curForm;
            bgw = new BackgroundWorker();
            bgw.DoWork += bgw_DoWorkOpenDay;
            bgw.RunWorkerCompleted += bgw_RunWorkerCompleted;
            bgw.WorkerSupportsCancellation = true;
            bgw.RunWorkerAsync();
        }

        void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (form != null)
            {
                form.Close();
            }
        }

        public void bgw_DoWorkOpenDay(object sender, DoWorkEventArgs e)
        {
            DateTime oldTime60 = DateTime.Now.AddDays(-60);
            DateTime oldTime180 = DateTime.Now.AddMonths(-6);
            DateTime begin_date = DateTime.Now.AddDays(-3);
            string bDate = begin_date.ToString("yyyy-MM-dd 00:00:00");
            string eDate = DateTime.Now.ToString("yyyy-MM-dd 00:00:00");
            //MySqlCommand command = new MySqlCommand("CALL `p_prodBalance`()", connection);
            MySqlCommand command = new MySqlCommand("CALL `_proc_update_balancelist_partly`('"+bDate+"', '"+eDate+"')", connection);
            if (connection.State == ConnectionState.Closed)
            {
                try
                {
                    string result;
                    connection.Open();
                    command.CommandTimeout = 600;
                    command.ExecuteNonQuery().ToString();

                    command.CommandText = "delete from balancelist where balanceDate < '" + oldTime60.Year + "-" + (oldTime60.Month<10?"0"+oldTime60.Month.ToString():oldTime60.Month.ToString()) + "-" + (oldTime60.Day<10? "0"+oldTime60.Day.ToString() :oldTime60.Day.ToString())+"'";
                    command.ExecuteNonQuery();



                    connection.Close();
                    //if (result == "0")
                    //{
                    //    Program.backDate = true;
                    //}
                    //System.Windows.Forms.MessageBox.Show("Операция выполнена успешно!");
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                    
                }
                e.Result = true;
                
            }
        }
        void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            MySqlCommand command = new MySqlCommand("CALL `balanceCalc`()", connection);
            if (connection.State == ConnectionState.Closed)
            {
                try
                {
                    connection.Open();
                    command.CommandTimeout = 200;
                    command.ExecuteNonQueryAsync();
                    connection.Close();
                    System.Windows.Forms.MessageBox.Show("Операция выполнена успешно!");
                }
                catch(Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
            }
        }
        
        /// Change!
        
        bool isNewExpense = false;
        public bool AddProduct(DataRow[] dr, bool isBarcode, string barcode)
        {
            bool next = false;


            float kg = -1;
            if (isBarcode && dr.Length == 0)
            {
                //object[] obj = getProductWithMassa(barcode);
                //dr = (DataRow[])obj[0];
                //kg = (float)obj[1];
                dr = getProductWithMassa(barcode);
            }

            if (dr.Length != 0)
            {
                DataSetTpos.productRow drP = (DataSetTpos.productRow)dr[0];
                DataRow[] existRows = DBclass.DS.orders.Select("expenseId=-1 and prodId = " + drP.productId);
                if (existRows.Length > 0)
                {
                    DataSetTpos.ordersRow ordrow = (DataSetTpos.ordersRow)existRows[0];
                    ordrow.packCount = ordrow.packCount + (drP.pack == 0 ? 1 : drP.pack);
                    DataRow drOrder = ordrow;
                    drOrder["sumProduct"] = ordrow.packCount * drP.price / (drP.pack == 0 ? 1 : drP.pack);//ordrow.AcceptChanges();
                }
                else
                {
                    DataSetTpos.ordersRow ordrow = DBclass.DS.orders.NewordersRow();



                    ordrow.prodId = drP.productId;
                    if (drP.pack == 0) drP.pack = 1;
                    ordrow.expenseId = -1;
                    int curPrice = drP.price;
                    OrderForm oform = new OrderForm(drP);
                    System.Windows.Forms.DialogResult result = oform.ShowDialog();
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        ordrow.packCount = (float)oform.count;
                        DataRow drOrder = ordrow;
                        drOrder["sumProduct"] = oform.sum;//ordrow.packCount * drP.price / (drP.pack == 0 ? 1 : drP.pack);
                        ordrow.orderSumm = Convert.ToSingle(drOrder["sumProduct"]);

                        //grid.Rows[e.RowIndex].Cells["sumProduct"].Value = (Convert.ToInt32(grid.Rows[e.RowIndex].Cells["packCount"].Value) * Convert.ToInt32(grid.Rows[e.RowIndex].Cells["productPrice"].Value)).ToString();
                    }
                    else if (result == System.Windows.Forms.DialogResult.Cancel)
                    {
                        //ordrow.RejectChanges();
                        drP.RejectChanges();
                        return false;
                    }else
                    {
                        if (drP.price == 0)
                        {
                            System.Windows.Forms.MessageBox.Show("Товар на складе отсутствует");
                            drP.RejectChanges();
                        }
                        return false;
                    }
                    DBclass.DS.orders.AddordersRow(ordrow);
                    if (curPrice != drP.price && drP.price != 0)
                    {

                        productTableAdapter prda = new productTableAdapter();
                        prda.Update(drP);
                        return true;
                    }

                }
                if (isNewExpense)
                {
                    //dgvExpense.Columns["productName"].Visible = true;
                    //dgvExpense.Columns["productPrice"].Visible = true;
                    isNewExpense = false;
                }
                //sumTable();
            }
            else if (isBarcode && UserValues.role == "admin")
            {
                AddForm addForm = new AddForm(barcode);
                if (addForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //productTableAdapter daProduct = new productTableAdapter();
                    //daProduct.Fill(DBclass.DS.product);


                }

            }

            next = true;
            return true;

        }
        //private void sumTable()
        //{
        //    var sum = DBclass.DS.orders.AsEnumerable().Sum(x => x.Field<int>("sumProduct"));
        //    this.Invoke(new SetLabel(SetTBX), new object[] { sum.ToString() });
        //}
        private DataRow[] getProductWithMassa(string barcode)
        {
            int prefix = Int32.Parse(barcode.Substring(0, 2));
            if (prefix == 20)
            {
                barcode = barcode.Substring(2);
                string id = barcode.Substring(0, 5);
                string kg = barcode.Remove(0, 5).Substring(0, 5);
                kg = kg.Insert(2, ".");
                //float kgf = Convert.ToSingle(kg);
                DataRow[] dr = DBclass.DS.product.Select("productId = " + Convert.ToInt32(id));
                if (dr.Length != 0)
                {
                    ((DataSetTpos.productRow)dr[0]).pack = Convert.ToSingle(kg);
                }
                return dr;
            }
            else
            {
                barcode = barcode.Substring(2);
                string id = barcode.Substring(0, 5);
                string sht = barcode.Remove(0, 5).Substring(0, 5);
                //sht = sht.Insert(2, ".");
                //float kgf = Convert.ToSingle(kg);
                DataRow[] dr = DBclass.DS.product.Select("productId = " + Convert.ToInt32(id));
                if (dr.Length != 0)
                {
                    ((DataSetTpos.productRow)dr[0]).pack = Convert.ToSingle(sht);
                }
                return dr;
            }
            //new object[] { dr, kgf };
        }
        public void Debt(string comment)
        {
            expenseTableAdapter expDa = new expenseTableAdapter();
            expDa.Adapter.SelectCommand = new MySql.Data.MySqlClient.MySqlCommand("select * from expense order by expenseId desc limit 1", expDa.Connection);
            DataSetTpos.expenseDataTable expTable = new DataSetTpos.expenseDataTable();
            DataSetTpos.expenseRow expRow = expTable.NewexpenseRow();
            double sum = 0;
            
            expRow.expenseDate = DateTime.Now;
            expRow.debt = 0;
            expRow.status = 0;
            expRow.comment = comment;
            expRow.expType = 3;

            expRow.expSum = (int)Math.Round(sum);
            expRow.terminal = 0;
            
            expTable.Rows.Add(expRow);
            int expId;
            expDa.Update(expTable);
            expDa.FillLast(expTable);
            ordersTableAdapter prDa = new ordersTableAdapter();
            DataSetTpos.ordersRow[] orRows = (DataSetTpos.ordersRow[])DBclass.DS.orders.Select("expenseId = -1");
            foreach (DataSetTpos.ordersRow oneRow in orRows)
            {
                oneRow.expenseId = (expTable.Rows[0] as DataSetTpos.expenseRow).expenseId;
            }
            expId = Convert.ToInt32((expTable.Rows[0] as DataSetTpos.expenseRow).expenseId);
            prDa.Update(DBclass.DS.orders);
            
            triggerExecute("ExpenseTrigger",expId);
            


            productviewTableAdapter prVda = new productviewTableAdapter();
            prVda.Fill(DBclass.DS.productview);

            
            isNewExpense = true;

            
        }


        public void triggerExecute(string trigger, int id)
        {
            MySqlCommand command = new MySqlCommand("CALL `" + trigger + "`('" + id + "')", connection);
            if (connection.State == ConnectionState.Closed)
            {
                try
                {
                    connection.Open();
                    command.CommandTimeout = 200;
                    command.ExecuteNonQueryAsync();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
            }
        }

        public void calcProc(string t, int id, float cnt)
        {
            getPriceTableAdapter gda = new getPriceTableAdapter();
            gda.calc(id, t, cnt);
            //MySqlCommand command = new MySqlCommand("CALL `calc`('" + id + "','" + t + "','" + cnt + "')", connection);
            //if (connection.State == ConnectionState.Closed)
            //{
            //    try
            //    {
            //        connection.Open();
            //        command.CommandTimeout = 200;
            //        command.ExecuteNonQueryAsync();
            //        connection.Close();
            //    }
            //    catch (Exception ex)
            //    {
            //        System.Windows.Forms.MessageBox.Show(ex.Message);
            //    }
            //}
        }


    }
    public class UpdateThreading
    {
        class ExpenseOrders
        {
            public int[] expense;
            public DataRow[] rows;
        }
        Thread th;
        public Queue<int[]> listExpenseID;
        public bool haveCheck = false;
        bool blocking = false;
        int[] expense;
        public UpdateThreading()
        {

            listExpenseID = new Queue<int[]>();
            ordersTable = new DataSetTpos.ordersDataTable();
            if (!(ordersTable.Columns["sumProduct"] is DataColumn))
                ordersTable.Columns.Add("sumProduct", typeof(int));
            string s ="";
            th = new Thread(new ParameterizedThreadStart(CheckForUpdate));
            th.Start();

        }

        public void StopThread()
        {
            if (th != null)
            {
                th.Abort();
            }
        }
        public void AddToExpenseList(int expenseId, DataSetTpos.ordersRow[] orRows, int expType)
        {
            expense = new int[2] { expenseId, expType };
            listExpenseID.Enqueue(expense);
            foreach (DataSetTpos.ordersRow ordRow in orRows)
            { 
                
                ordersTable.Rows.Add(ordRow.ItemArray);
            }
            
        }
        DataSetTpos.ordersDataTable ordersTable;
        object obj = new object();
        private void CheckForUpdate(object argument)
        {
            DBclass dbcl = new DBclass();
            while (true)
            {
                if (haveCheck)
                {
                    while(listExpenseID.Count!=0)
                    {
                        lock (obj)
                        {
                            DataTable table = new DataTable();

                            int[] expenseT = listExpenseID.Dequeue();

                            DataSetTpos.ordersRow[] ordRows = (DataSetTpos.ordersRow[])ordersTable.Select("expenseId = " + expenseT[0]);
                            ordersTableAdapter ordDa = new ordersTableAdapter();
                            ordDa.Update(ordRows);
                            //ordersTable.Clear();
                            switch (expenseT[1])
                            {
                                case 0:
                                    dbcl.triggerExecute("ExpenseTrigger", expenseT[0]);
                                    break;
                                case 1:
                                    dbcl.triggerExecute("BackTrigger", expenseT[0]);
                                    break;
                            }
                        }

                    }

                }

                Thread.Sleep(10000);
            }
 
        }
    }
}
