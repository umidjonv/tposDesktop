using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
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

        //public DBclass()
        //{
        //    connection = new MySqlConnection("server=localhost;user id=foodsDB_user;password=D@faul(t);database=foods;persistsecurityinfo=True");
        //    string[] tables = { "employee", "dishes", "halfstaff", "products" };
        //    if (DS == null)
        //        DS = new DataSet();
        //    foreach(string tableName in tables)
        //    Fill(tableName);
        //}
        //string conStr = "server=localhost;user id=root;database=stock;";//"server=localhost;user id=foodsDB_user;password=D@faul(t);database=foods;persistsecurityinfo=True";
        public DBclass(string[] tables)
        {
            connection = new MySqlConnection(tposDesktop.Properties.Settings.Default.stockConnectionString);
            
            
            if (DS == null)
                DS = new DataSetTpos();
            foreach (string table in tables)
            {
                Fill(table);
            }
        }
        public DBclass()
        {
            connection = new MySqlConnection(tposDesktop.Properties.Settings.Default.stockConnectionString);
            if (DS == null)
                DS = new DataSetTpos();
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
        bool isNewExpense = false;
      

        public void AddProduct(DataRow[] dr, bool isBarcode, string barcode)
        {
            bool next = false;


            float kg = -1;
            if (isBarcode && dr.Length == 0)
            {
                //object[] obj = getProductWithMassa(barcode);
                //dr = (DataRow[])obj[0];
                //kg = (float)obj[1];
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
                    if (oform.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        ordrow.packCount = (float)oform.count;
                        DataRow drOrder = ordrow;
                        drOrder["sumProduct"] = oform.sum;//ordrow.packCount * drP.price / (drP.pack == 0 ? 1 : drP.pack);

                        //grid.Rows[e.RowIndex].Cells["sumProduct"].Value = (Convert.ToInt32(grid.Rows[e.RowIndex].Cells["packCount"].Value) * Convert.ToInt32(grid.Rows[e.RowIndex].Cells["productPrice"].Value)).ToString();
                    }
                    else
                    {
                        if (drP.price == 0)
                        {
                            System.Windows.Forms.MessageBox.Show("Товар на складе отсутствует");
                            drP.RejectChanges();
                        }
                        return;
                    }
                    DBclass.DS.orders.AddordersRow(ordrow);
                    if (curPrice != drP.price && drP.price != 0)
                    {

                        productTableAdapter prda = new productTableAdapter();
                        prda.Update(drP);
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

        }

        void bgw_DoWorkOpenDay(object sender, DoWorkEventArgs e)
        {
            
            MySqlCommand command = new MySqlCommand("select `prodBalance`(0)", connection);
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
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                e.Result = true;
            }
        }
        public void Debt()
        {
            expenseTableAdapter expDa = new expenseTableAdapter();
            expDa.Adapter.SelectCommand = new MySql.Data.MySqlClient.MySqlCommand("select * from expense order by expenseId desc limit 1", expDa.Connection);
            DataSetTpos.expenseDataTable expTable = new DataSetTpos.expenseDataTable();
            DataSetTpos.expenseRow expRow = expTable.NewexpenseRow();
            double sum = 0;

            expRow.expenseDate = DateTime.Now;
            expRow.debt = 0;
            expRow.status = 0;
            expRow.comment = "";
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
            getPriceTableAdapter getPriceda = new getPriceTableAdapter();
            getPriceda.ExpenseTrigger(expId);



            productviewTableAdapter prVda = new productviewTableAdapter();
            prVda.Fill(DBclass.DS.productview);


            isNewExpense = true;


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

    }
}
