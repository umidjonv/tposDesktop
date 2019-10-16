using Classes.DB;
using Classes.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tposDesktop.DataSetTposTableAdapters;

namespace tposDesktop
{
    public partial class ProdListLibra : DesignedForm
    {
        public string prodName;
        public int prodId;
        public int price;
        string btn;
        int lbr;
        bool isNew = true;
        public bool cleared = false;
        DataSetTpos.hotkeysLibraRow[] hdr;
        public ProdListLibra(string btnNum, string btns, int libraId)
        {
            InitializeComponent();
            btn = btnNum;
            lbr = libraId;
            prodName = btns;
            DBclass db = new DBclass();
            productTableAdapter1.Fill(DBclass.DS.product);
            DataView dtv = new DataView(DBclass.DS.product);
            dgvTovar.DataSource = dtv;
            this.hotkeysLibraTableAdapter1.Fill(DBclass.DS.hotkeysLibra);
            hdr = (DataSetTpos.hotkeysLibraRow[])DBclass.DS.hotkeysLibra.Select("btnLibraId = '" + btn + "' and libraId = '" + lbr + "'");
            if (hdr.Length > 0)
            {
                isNew = false;
            }

        }

        private void tbx_ValueChanged(object sender, EventArgs e)
        {
            TextBox tbx = sender as TextBox;
            DataView dv = dgvTovar.DataSource as DataView;
            dv.RowFilter = "name like '%" + tbx.Text + "%'";
                    
        }

        private void Form_Load(object sender, EventArgs e)
        {
            dgvTovar.Columns["productId"].HeaderText = "№";
            dgvTovar.Columns["name"].HeaderText = "Товар";
            dgvTovar.Columns["price"].HeaderText = "Цена";
            dgvTovar.Columns["measureId"].Visible = false;
            dgvTovar.Columns["barcode"].Visible = false;
            dgvTovar.Columns["providerId"].Visible = false;
            dgvTovar.Columns["pack"].Visible = false;
            dgvTovar.Columns["status"].Visible = false;
            dgvTovar.Columns["productId"].Width = 50;
            dgvTovar.Columns["name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvTovar.Columns["price"].Width = 90;
            DataGridViewButtonColumn cellBtn = new System.Windows.Forms.DataGridViewButtonColumn();
            cellBtn.HeaderText = "";
            cellBtn.Name = "colBtn";
            cellBtn.Width = 100;
            dgvTovar.Columns.Add(cellBtn);
        }

        private void double_click(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = sender as DataGridView;
            
            switch (dgv.Name)
            {
                case "dgvTovar":
                        DataSetTpos.productRow[] dr = (DataSetTpos.productRow[])DBclass.DS.product.Select("productId = " + dgv.Rows[e.RowIndex].Cells["productId"].Value.ToString());
                    if (dgv.Columns[e.ColumnIndex].Name == "colBtn")
                    {
                        prodId = dr[0].productId;
                        prodName = dr[0].name;
                        price = dr[0].price;
                        
                        DataSetTpos.hotkeysLibraRow[] htr = (DataSetTpos.hotkeysLibraRow[])DBclass.DS.hotkeysLibra.Select("prodLibraId like '%" + prodName + "%'");
                        if (htr.Length > 0)
                        {
                            MessageBox.Show("Этот продукт уже прикреплён.");
                            
                        }
                        else
                        {
                            if (isNew)
                            {
                                DataSetTpos.hotkeysLibraRow htk = DBclass.DS.hotkeysLibra.NewhotkeysLibraRow();
                                htk.btnLibraId = btn;
                                htk.prodLibraId = prodName;
                                htk.libraId = lbr;

                                hotkeysLibraTableAdapter daKeyLib = new hotkeysLibraTableAdapter();
                                DBclass.DS.hotkeysLibra.AddhotkeysLibraRow(htk);
                                daKeyLib.Update(DBclass.DS.hotkeysLibra);
                                daKeyLib.Fill(DBclass.DS.hotkeysLibra);
                                
                            }
                            else
                            {
                                hdr[0].prodLibraId = prodName;
                                hdr[0].btnLibraId = btn;
                                hotkeysLibraTableAdapter daKeyLib = new hotkeysLibraTableAdapter();
                                daKeyLib.Update(DBclass.DS.hotkeysLibra);
                                daKeyLib.Fill(DBclass.DS.hotkeysLibra);

                            }
                            cleared = false;
                            DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                    break;
            }
        }

        private void dgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            var grid = sender as DataGridView;
            if (grid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                DataGridViewButtonCell dgvCell = (DataGridViewButtonCell)grid.Rows[e.RowIndex].Cells[e.ColumnIndex];
                
                switch (grid.Columns[e.ColumnIndex].Name)
                {
                    case "colBtn":
                        dgvCell.Value = "Выбрать";
                        break;
                }
            }
        }

        private void clrBtn_Click(object sender, EventArgs e)
        {
            if (isNew == false)
            {
                hdr[0].Delete();
                this.hotkeysLibraTableAdapter1.Update(DBclass.DS.hotkeysLibra);
                this.hotkeysLibraTableAdapter1.Fill(DBclass.DS.hotkeysLibra);
                prodName = btn;
                this.cleared = true;
                DialogResult = DialogResult.Cancel;
                this.Close();
            }
            else
            {
                MessageBox.Show("Этой кнопке товар не прикреплён.");
            }
        }   
    }
}
