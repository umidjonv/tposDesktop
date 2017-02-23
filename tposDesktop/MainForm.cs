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
    public partial class MainForm : Form
    {
        DBclass db;
        Scanner scan;
        DataSetTpos.ordersDataTable order;
        public MainForm()
        {
            InitializeComponent();
            db = new DBclass();
            db.FillProduct();
            DataView dv = new DataView(DBclass.DS.product);
            DataView dvOr = new DataView(DBclass.DS.orders);
            dvOr.RowFilter = "expenseId = -1";
            dgvTovar.DataSource = dv;
            dgvExpense.DataSource = dvOr;
            
            dv.RowFilter = tbxSearchTovar.Text;
            scan = new Scanner();
            scan.ScannerEvent += scan_ScannerEvent;

        }

        

        void scan_ScannerEvent(object source, ScannerEventArgs e)
        {
            MessageBox.Show(e.GetInfo());
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(Program.window_type!=1)
            Program.window_type = 0;

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSetTpos.orders' table. You can move, or remove it, as needed.
            this.ordersTableAdapter.Fill(this.dataSetTpos.orders);
            dgvTovar.Columns["productId"].HeaderText = "№";
            dgvTovar.Columns["name"].HeaderText = "Товар";
            dgvTovar.Columns["price"].HeaderText = "Цена";
            dgvTovar.Columns["measureId"].Visible = false;
            dgvTovar.Columns["barcode"].Visible = false;
            dgvTovar.Columns["pack"].Visible = false;
            dgvTovar.Columns["status"].Visible = false;
            dgvTovar.Columns["productId"].Width = 50;
            dgvTovar.Columns["name"].Width = 200;
            dgvTovar.Columns["price"].Width= 90;
            DataGridViewButtonColumn cellBtn = new System.Windows.Forms.DataGridViewButtonColumn();
            cellBtn.HeaderText = "";
            cellBtn.Name = "colBtn";
            cellBtn.Width = 40;
            dgvTovar.Columns.Add(cellBtn);

            dgvExpense.Columns["prodId"].Visible = false;
            dgvExpense.Columns["orderId"].Visible = false;
            dgvExpense.Columns["expenseId"].Visible = false;
            dgvExpense.Columns["count"].Visible = false;
            dgvExpense.Columns["packCount"].HeaderText = "Кол.";
            dgvExpense.Columns["productName"].Width = 200;

            DataGridViewButtonColumn cellBtn2 = new System.Windows.Forms.DataGridViewButtonColumn();
            cellBtn2.HeaderText = "";
            cellBtn2.Name = "colBtn";
            cellBtn2.Width = 40;
            dgvExpense.Columns.Add(cellBtn2);
        }

        private void tbxSearchTovar_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dgvTovar.DataSource as DataView;
            dv.RowFilter = "name like '%" + tbxSearchTovar.Text+"%'";
            
        }

        private void dgvTovar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;
            if (grid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                
                    DataSetTpos.ordersRow ordrow = DBclass.DS.orders.NewordersRow();
                    DataRow[] dr = DBclass.DS.product.Select("productId = "+grid.Rows[e.RowIndex].Cells["productid"].Value.ToString());
                    if (dr.Length != 0)
                    {
                        DataSetTpos.productRow drP = (DataSetTpos.productRow)dr[0];

                        ordrow.prodId = drP.productId;
                        ordrow.expenseId = -1;
                        OrderForm oform = new OrderForm(drP.pack, drP.price.ToString());
                        if (oform.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            ordrow.packCount = oform.count;
                        }
                        else { return; }
                        DBclass.DS.orders.AddordersRow(ordrow);

                        if (isNewExpense)
                        {
                            //dgvExpense.Columns["productName"].Visible = true;
                            //dgvExpense.Columns["productPrice"].Visible = true;
                            isNewExpense = false;
                        }
                    }
                
            }
        }
        private void dgvSchet_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            var grid = (DataGridView)sender;
            if (grid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (grid.Name == "dgvTovar")
                {
                    DataGridViewButtonCell dgvCell = (DataGridViewButtonCell)grid.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    dgvCell.Value = "+";
                }
                else
                {
                    DataGridViewButtonCell dgvCell = (DataGridViewButtonCell)grid.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    dgvCell.Value = "-";
                }
            }
            
        }
        bool isNewExpense = true;
        private void btnOplata_Click(object sender, EventArgs e)
        {
            expenseTableAdapter expDa = new expenseTableAdapter();
            DataSetTpos.expenseDataTable expTable = new DataSetTpos.expenseDataTable();
            DataSetTpos.expenseRow expRow = expTable.NewexpenseRow();
            float sum = 0;
            foreach (DataGridViewRow dgvRow in dgvExpense.Rows)
            {
                sum += (float)dgvRow.Cells["packCount"].Value * (int)dgvRow.Cells["productPrice"].Value;
            }
            expRow.expenseDate = DateTime.Now;
            expRow.debt = 0;
            expRow.status = 0;
            expRow.terminal = 0;
            expRow.expSum = (int)sum;
            expTable.Rows.Add(expRow);
            
            expDa.Update(expTable);
            expDa.Fill(expTable);
            ordersTableAdapter prDa = new ordersTableAdapter();
            DataSetTpos.ordersRow[] orRows = (DataSetTpos.ordersRow[])DBclass.DS.orders.Select("expenseId = -1");
            foreach (DataSetTpos.ordersRow oneRow in orRows)
            {
                //oneRow.expenseId = 
            }
            prDa.Update(DBclass.DS.orders);
            DataView dv = dgvExpense.DataSource as DataView;
            
            
            
            //dgvExpense.Columns["productName"].Visible = false;
            //dgvExpense.Columns["productPrice"].Visible = false;
            isNewExpense = true;
        }

        private void dgvExpense_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            
            var grid = (DataGridView)sender;
            if (grid.Columns["prodId"] != null && grid.Rows[e.RowIndex].Cells["prodId"].Value != null)
            {
                DataSetTpos.productRow prRow = DBclass.DS.product.Select("productId = " + grid.Rows[e.RowIndex].Cells["prodId"].Value)[0] as DataSetTpos.productRow ;
                grid.Rows[e.RowIndex].Cells["productName"].Value = prRow.name;
                grid.Rows[e.RowIndex].Cells["productPrice"].Value = prRow.price; 

            }
        }

        
        
    }
}
