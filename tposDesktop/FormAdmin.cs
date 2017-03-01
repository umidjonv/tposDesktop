using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Classes;
using Classes.DB;
using tposDesktop.DataSetTposTableAdapters;


namespace tposDesktop
{
    public partial class FormAdmin : Form
    {
        Scanner scanner;
        DBclass db;
        public FormAdmin()
        {
            InitializeComponent();
            if (UserValues.role != "admin")
                this.Dispose();
            db = new DBclass();
            DataView dv = new DataView(DBclass.DS.product);
            dv.RowFilter = "";
            dgvTovar.DataSource = dv;
            infoLoad(); 
            realizeLoad();
            expenseLoad();
            balanceLoad();
            infoGraph();
            try
            {
                scanner = new Scanner();
                scanner.ScannerEvent += scanner_ScannerEvent;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        delegate void SendInfoDel(string text);
        
        void scanner_ScannerEvent(object source, ScannerEventArgs e)
        {
            this.Invoke(new SendInfoDel(SendInfo), new object[] { e.GetInfo() });
        }

        private void SendInfo(string text)
        {
            string barcode = text;
            DataRow[] dr = DBclass.DS.product.Select("barcode = '" + barcode + "'");
            AddProduct(dr, barcode);
        }

        private void AddProduct(DataRow[] dr, string barcode)
        {
            if (dr.Length != 0)
            {
                DataSetTpos.productRow prRow = (DataSetTpos.productRow)dr[0];
                AddForm addForm = new AddForm(prRow);
                if (addForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    
                }
            }
            else
            {
                AddForm addForm = new AddForm(barcode);
                if (addForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    productTableAdapter daProduct = new productTableAdapter();
                    daProduct.Fill(DBclass.DS.product);


                }

            }
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            this.productTableAdapter1.Fill(DBclass.DS.product);
            dgvTovar.Columns["productId"].HeaderText = "№";
            dgvTovar.Columns["name"].HeaderText = "Товар";
            dgvTovar.Columns["price"].HeaderText = "Цена";
            dgvTovar.Columns["measureId"].Visible = false;
            dgvTovar.Columns["barcode"].HeaderText = "Штрихкод";
            dgvTovar.Columns["barcode"].Width = 150;
            dgvTovar.Columns["pack"].Visible = false;
            dgvTovar.Columns["status"].Visible = false;
            dgvTovar.Columns["productId"].Width = 50;
            dgvTovar.Columns["name"].Width = 200;
            dgvTovar.Columns["name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvTovar.Columns["price"].Width = 90;
            DataGridViewButtonColumn cellBtn = new System.Windows.Forms.DataGridViewButtonColumn();
            cellBtn.HeaderText = "";
            cellBtn.Name = "colBtn";
            cellBtn.Width = 40;
            dgvTovar.Columns.Add(cellBtn);
        }

        private void FormAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            scanner.isWorked = false;
            scanner.rd.ClosePort(scanner.port);
            if (Program.window_type != 2 && Program.window_type != 1)
                Program.window_type = 0;
        }

        private void infoLoad()
        {
            DataView info = new DataView(DBclass.DS.info);
            info.RowFilter = "";// "Dates = " + reportDate.Value.ToString("yyyy-MM-dd");
            infoGrid.DataSource = info;

            this.infoTableAdapter1.Fill(DBclass.DS.info);
            infoGrid.Columns["Dates"].HeaderText = "Товар";
            infoGrid.Columns["proceed"].HeaderText = "Выручка";
            infoGrid.Columns["nal"].HeaderText = "Наличные";
            infoGrid.Columns["back"].HeaderText = "Возврат";
            infoGrid.Columns["terminal"].HeaderText = "Терминал";
            
        }

        private void infoGraph()
        {
            DataTable table = DBclass.DS.Tables["info"];
            DataRow[] rows = table.Select();
            try
            {
                foreach (var val in rows)
                {
                    this.infoChart.Series["Выручка"].Points.AddXY(val["Dates"].ToString(), (val["proceed"] == null) ? 1 : val["proceed"]);
                    this.infoChart.Series["Наличка"].Points.AddXY(val["Dates"].ToString(), (val["nal"] == null) ? 1 : val["nal"]);
                    this.infoChart.Series["Терминал"].Points.AddXY(val["Dates"].ToString(), (val["terminal"] == null) ? 1 : val["terminal"]);
                    this.infoChart.Series["Возврат"].Points.AddXY(val["Dates"].ToString(), (val["back"] == null) ? 1 : val["back"]);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void realizeLoad()
        {
            DataView realize = new DataView(DBclass.DS.realizeview);
            realize.RowFilter = "fakturaDate = '" + reportDate.Value.ToString("yyyy-MM-dd")+"'";
            realizeGrid.DataSource = realize;

            this.realizeviewTableAdapter1.Fill(DBclass.DS.realizeview);
            realizeGrid.Columns["name"].HeaderText = "Наименование";
            realizeGrid.Columns["fakturaDate"].Visible = false;
            realizeGrid.Columns["count"].HeaderText = "Кол-во";
            realizeGrid.Columns["price"].HeaderText = "Цена";
            realizeGrid.Columns["name"].Width = 200;
            realizeGrid.Columns["fakturaId"].Visible = false;
        }

        private void expenseLoad()
        {
            DataView expense = new DataView(DBclass.DS.expenseview);
            expense.RowFilter = "expenseDate = '" + reportDate.Value.ToString("yyyy-MM-dd") + "'";
            expenseGrid.DataSource = expense;

            this.expenseviewTableAdapter1.Fill(DBclass.DS.expenseview);
            expenseGrid.Columns["name"].HeaderText = "Наименование";
            expenseGrid.Columns["expenseDate"].Visible = false;
            expenseGrid.Columns["count"].HeaderText = "Кол-во";
            expenseGrid.Columns["name"].Width = 200;
            expenseGrid.Columns["pack"].Visible = false;
        }

        private void balanceLoad()
        {
            DataView balance = new DataView(DBclass.DS.balanceview);
            balance.RowFilter = "balanceDate = '" + reportDate.Value.ToString("yyyy-MM-dd") + "'";
            balanceGrid.DataSource = balance;

            this.balanceviewTableAdapter1.Fill(DBclass.DS.balanceview);
            balanceGrid.Columns["name"].HeaderText = "Наименование";
            balanceGrid.Columns["prodId"].HeaderText = "№";
            balanceGrid.Columns["balanceDate"].Visible = false;
            balanceGrid.Columns["balanceId"].Visible = false;
            balanceGrid.Columns["productId"].Visible = false;
            balanceGrid.Columns["measureId"].Visible = false;
            balanceGrid.Columns["barcode"].Visible = false;
            balanceGrid.Columns["status"].Visible = false;
            balanceGrid.Columns["price"].Visible = false;
            balanceGrid.Columns["pack"].Visible = false;
            balanceGrid.Columns["endCount"].HeaderText = "Кол-во";
            balanceGrid.Columns["curEndCount"].HeaderText = "Кол-во";
            balanceGrid.Columns["name"].Width = 200;
        }

        

        private void reportDate_ValueChanged(object sender, EventArgs e)
        {
            expenseLoad();
            infoLoad();
            realizeLoad();
            balanceLoad();
        }
    }
}
