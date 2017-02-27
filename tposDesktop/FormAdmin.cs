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
    }
}
