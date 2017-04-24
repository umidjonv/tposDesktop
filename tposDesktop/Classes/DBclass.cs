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
