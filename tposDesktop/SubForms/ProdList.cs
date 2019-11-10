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
    public partial class ProdList : DesignedForm
    {
        public string prodName;
        public string id;
        string btn;
        bool isNew = true;
        
        DataSetTpos.hotkeysRow[] hdr;
        public ProdList(string btnNum,string btns, string ID)
        {
            InitializeComponent();
            id = ID;
            btn = btnNum;
            prodName = btns;
            DBclass db = new DBclass();
            productTableAdapter1.Fill(DBclass.DS.product);
            DataView dtv = new DataView(DBclass.DS.product);
            dtv.RowFilter = "price <> 0";
            dgvTovar.DataSource = dtv;
            this.hotkeysTableAdapter1.Fill(DBclass.DS.hotkeys);
            hdr = (DataSetTpos.hotkeysRow[])DBclass.DS.hotkeys.Select("btnId = '" + btn +"$"+ ID+"'");
            if (hdr.Length > 0)
            {
                isNew = false;
            }
            else
            {
                //btn = btnNum;
                //prodName = "";
 
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
            //dgvTovar.Columns["providerId"].Visible = false;
            dgvTovar.Columns["pack"].Visible = false;
            dgvTovar.Columns["status"].Visible = false;
            dgvTovar.Columns["productId"].Width = 50;
            dgvTovar.Columns["name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvTovar.Columns["price"].Width = 90;
            dgvTovar.Columns["limitProd"].Visible = false;
            dgvTovar.Columns["expiry"].Visible = false;
            dgvTovar.Columns["exp"].Visible = false;
            DataGridViewButtonColumn cellBtn = new DataGridViewButtonColumn();
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
                            string btnvalue = prodName;
                            prodName = dr[0].name;
                            id = dr[0].productId.ToString();
                            DataSetTpos.hotkeysRow[] htr = (DataSetTpos.hotkeysRow[])DBclass.DS.hotkeys.Select("prodId like '%" + prodName + "%'");
                            if (htr.Length > 0)
                            {
                                MessageBox.Show("Этот продукт уже прикреплён.");
                                prodName = btnvalue;
                                id = null;
                            }
                            else
                            {
                                if (isNew)
                                {
                                    DataSetTpos.hotkeysRow htk = DBclass.DS.hotkeys.NewhotkeysRow();
                                    htk.btnId = btn + "$" + id;
                                    htk.prodId = prodName;

                                    hotkeysTableAdapter daKey = new hotkeysTableAdapter();
                                    DBclass.DS.hotkeys.AddhotkeysRow(htk);
                                    daKey.Update(DBclass.DS.hotkeys);
                                    daKey.Fill(DBclass.DS.hotkeys);
                                }
                                else
                                {
                                    hdr[0].prodId = prodName;
                                    hdr[0].btnId = btn + "$" + id;
                                    hotkeysTableAdapter daKey = new hotkeysTableAdapter();
                                    daKey.Update(DBclass.DS.hotkeys);
                                    daKey.Fill(DBclass.DS.hotkeys);
                                }
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
                this.hotkeysTableAdapter1.Update(DBclass.DS.hotkeys);
                this.hotkeysTableAdapter1.Fill(DBclass.DS.hotkeys);
                prodName = btn;
                this.Close();
            }
            else
            {
                MessageBox.Show("Этой кнопке товар не прикреплён.");
            }
        }   
    }
}
