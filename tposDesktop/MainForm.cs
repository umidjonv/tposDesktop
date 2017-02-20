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
namespace tposDesktop
{
    public partial class MainForm : Form
    {
        DBclass db;
        public MainForm()
        {
            InitializeComponent();
            db = new DBclass();
            db.FillProduct();
            DataView dv = new DataView(DBclass.DS.product);
            dgvTovar.DataSource = dv;
            dv.RowFilter = tbxSearchTovar.Text;
            

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(Program.window_type!=1)
            Program.window_type = 0;

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
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
                
            }
        }
        private void dgvSchet_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            var grid = (DataGridView)sender;
            if (grid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                DataGridViewButtonCell dgvCell = (DataGridViewButtonCell)grid.Rows[e.RowIndex].Cells[e.ColumnIndex];
                dgvCell.Value = "+";
            }

        }

        
        
    }
}
