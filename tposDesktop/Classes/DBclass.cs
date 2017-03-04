using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using tposDesktop;
using tposDesktop.DataSetTposTableAdapters;

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
        string conStr = "server=localhost;user id=root;database=stock;";//"server=localhost;user id=foodsDB_user;password=D@faul(t);database=foods;persistsecurityinfo=True";
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
        public void FillExpense()
        {
            expenseTableAdapter daEx = new expenseTableAdapter();
            daEx.Fill(DS.expense);
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

        
        /// <summary>
        /// Update insert delete expense
        /// </summary>
        /// <returns>Last ID was inserted</returns>
        
        
        
    }
}
