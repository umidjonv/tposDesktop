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
using Classes.Forms;
namespace tposDesktop
{
    public partial class AddRealizeLocations : DesignedForm
    {
        int pack;
        int prodId;
        public AddRealizeLocations(string barcode)
        {
            
            InitializeComponent();
            
            if (barcode != null)
                tbxShtrix.Text = barcode;
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;

            
            
        }
        public AddRealizeLocations(DataSetTpos.productRow productRow, DataSetTpos.fakturaRow faktRow)
        {
            prodId = productRow.productId;
            prRow = productRow;
            fkRow = faktRow;
            
            InitializeComponent();
            //blnLbl.Text = getSold(productRow.productId).ToString();
            tbxName.Text = productRow.name;
            tbxPack.Text = 1.ToString();
            pack = productRow.pack;
            //tbxPricePrixod.Text = productRow.price.ToString();
            tbxShtrix.Text = productRow.barcode;
            if (productRow.barcode != null)
                tbxShtrix.Text = productRow.barcode;
            if (productRow.limitProd == 1)
                limitChbx.Checked = true;
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            if (productRow.pack == 0 || productRow.pack == 1)
            {
                tbxKol.Visible = false;
                lblKol.Visible = false;
            }
            
            DataSetTposTableAdapters.locationsTableAdapter locDa = new DataSetTposTableAdapters.locationsTableAdapter();
            locDa.Fill(DBclass.DS.locations);
            FillDGV_locations();
            dgvPrices.DataSource = DBclass.DS.locPrices_t;
            

        }

        private void FillDGV_locations()
        {
            DBclass.DS.locPrices_t.Clear();
            foreach(DataSetTpos.locationsRow lrow in DBclass.DS.locations)
            {
                DataSetTpos.locPrices_tRow row = DBclass.DS.locPrices_t.NewlocPrices_tRow();
                row.locationID = lrow.locationID;
                row.LocationName = lrow.LocationName;
                DBclass.DS.locPrices_t.Rows.Add(row);
                
            }
            
        }

        private string getSold(int id)
        {
            DataSetTposTableAdapters.balanceviewTableAdapter bln = new DataSetTposTableAdapters.balanceviewTableAdapter();
            bln.Fill(DBclass.DS.balanceview, DateTime.Now.AddDays(-1));
            DataView balance = new DataView(DBclass.DS.balanceview);
            balance.RowFilter = "balanceDate = '" + DateTime.Now.ToString("yyyy-MM-dd") + "' and prodId = " + id;

            return balance[0]["endCount"].ToString();
        }

        DataSetTpos.productRow prRow;
        DataSetTpos.fakturaRow fkRow;
        DataSetTpos.realizeRow rlRow;
        private void AddOrEdit(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbxName.Text))
            {
                
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                DataSetTposTableAdapters.realizeTableAdapter daReal = new DataSetTposTableAdapters.realizeTableAdapter();
                
                DataSetTpos.realizeRow[] rlRows = (DataSetTpos.realizeRow[])DBclass.DS.realize.Select("prodid = "+prRow.productId+" and fakturaId = "+fkRow.fakturaId);
                DataSetTpos.realizeRow rlRow;
                if (rlRows.Length > 0)
                {
                    rlRow = rlRows[0];
                    if (pack != 0)
                    {
                        rlRow.count += Convert.ToInt32(tbxPack.Text) * pack + Convert.ToInt32(tbxKol.Text);
                    }
                    else
                    {
                        rlRow.count += Convert.ToInt32(tbxPack.Text);
                    }
                    //rlRow.price = Convert.ToInt32(tbxPricePrixod.Text);
                    //rlRow.soldPrice = Convert.ToInt32(tbxSoldPrice.Text);
                    
                    
                    
                }
                else
                {
                    rlRow = DBclass.DS.realize.NewrealizeRow();
                    if (pack != 0)
                    {
                        rlRow.count = Convert.ToInt32(Math.Round(Convert.ToDouble(tbxPack.Text) * pack, 2) + Convert.ToInt32(tbxKol.Text));
                    }
                    else
                    {
                        rlRow.count = Convert.ToInt32(tbxPack.Text);
                    }
                    //rlRow.price = Convert.ToInt32(tbxPricePrixod.Text);
                    //rlRow.soldPrice = Convert.ToInt32(tbxSoldPrice.Text);
                    rlRow.fakturaId = fkRow.fakturaId;
                    rlRow.prodId = prRow.productId;
                    if (Convert.ToDateTime(expiry.Text) != DateTime.Now)
                        rlRow.expiryDate = Convert.ToDateTime(expiry.Text);
                    DBclass.DS.realize.AddrealizeRow(rlRow);
                }
                DataSetTposTableAdapters.productTableAdapter pr = new DataSetTposTableAdapters.productTableAdapter();
                if (limitChbx.Checked)
                    prRow.limitProd = 1;
                if (prRow.price == 0)
                {
                    prRow.price = rlRow.soldPrice;

                }
                pr.Update(prRow);
                
                
                daReal.Update(DBclass.DS.realize);
                daReal.Fill(DBclass.DS.realize);
                
            }
        }

        private void AddRows()
        {
            foreach (DataSetTpos.locPrices_tRow locrow in DBclass.DS.locPrices_t.Rows)
            {
                DataSetTpos.realizeRow[] rlRows = (DataSetTpos.realizeRow[])DBclass.DS.realize.Select("(prodid = " + prRow.productId + " and fakturaId = " + fkRow.fakturaId+") and locationID = "+locrow.locationID);
                DataSetTpos.realizeRow rlRow;
                if (rlRows.Length > 0)
                {
                }
                else
                {
                    rlRow = DBclass.DS.realize.NewrealizeRow();
                    if (pack != 0)
                    {
                        rlRow.count = Convert.ToInt32(Math.Round(Convert.ToDouble(locrow.count) * pack, 2));
                    }
                    else
                    {
                        rlRow.count = Convert.ToInt32(locrow.count);
                    }
                    rlRow.price = Convert.ToInt32(locrow.price);
                    rlRow.soldPrice = Convert.ToInt32(locrow.soldPrice);
                    rlRow.fakturaId = fkRow.fakturaId;
                    rlRow.prodId = prRow.productId;
                    if (Convert.ToDateTime(expiry.Text) != DateTime.Now)
                        rlRow.expiryDate = Convert.ToDateTime(expiry.Text);
                    DBclass.DS.realize.AddrealizeRow(rlRow);
                }
            }
 
        }

        private void AddRealize_Load(object sender, EventArgs e)
        {
            tbxPack.Focus();
            dgvPrices.Columns["locationID"].HeaderText = "№";
            dgvPrices.Columns["LocationName"].HeaderText = "Точка";
            dgvPrices.Columns["count"].HeaderText = "Кол.";
            dgvPrices.Columns["price"].HeaderText = "Цена фактуры";
            dgvPrices.Columns["soldPrice"].HeaderText = "Цена продажи";

            dgvPrices.Columns["locationID"].Width = 50;
            dgvPrices.Columns["LocationName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvPrices.Columns["count"].Width = 70;
            dgvPrices.Columns["price"].Width = 100;
            dgvPrices.Columns["soldPrice"].Width = 100;

            dgvPrices.Columns["locationID"].ReadOnly = true;
            dgvPrices.Columns["LocationName"].ReadOnly = true;

            if (dgvPrices.Rows.Count > 0)
                dgvPrices.CurrentCell = dgvPrices.Rows[0].Cells[2];
            //Classes.GridCells.NumericCell numc = new Classes.GridCells.NumericCell();



            //dgvPrices.Columns["count"].CellTemplate = numc;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddForm adF = new AddForm("");
            //if (tbxSoldPrice.Text == "0")
            //{
            //    MessageBox.Show("не указана цена");
            //}
            //else
            //{
            //    adF.forPrinting(tbxName.Text, tbxSoldPrice.Text, tbxShtrix.Text,prodId);
            //}
        }

        private void dgvPrices_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                MoveNext();
                
                
            }
        }

        private void MoveNext()
        {
            int countC = dgvPrices.Columns.Count;
            int countR = dgvPrices.Rows.Count;
            int curRow = dgvPrices.CurrentCell.RowIndex;
            int curCol = dgvPrices.CurrentCell.ColumnIndex;
            if (countC != (curCol + 1))
            {
                dgvPrices.CurrentCell = dgvPrices[curCol + 1, curRow];
            }
            else if (countR != (curRow + 1))
            {
                dgvPrices.CurrentCell = dgvPrices[2, curRow + 1];
            }
        }
        private void dgvPrices_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        bool dgv_tbx_enter = false;
        private void dgvPrices_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (!dgv_tbx_enter)
            {
                e.Control.KeyDown += Control_KeyDown;
                e.Control.KeyPress += Control_KeyPress;
                dgv_tbx_enter = true;
            }
            e.Control.KeyPress -= new KeyPressEventHandler(Control_KeyPress);
            int ind = dgvPrices.CurrentCell.ColumnIndex;
            if (ind == 2 || ind == 3 || ind == 4) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Control_KeyPress);
                }
            }
        }

        void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        void Control_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                MoveNext();
            }
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            int icolumn = dgvPrices.CurrentCell.ColumnIndex;
            int irow = dgvPrices.CurrentCell.RowIndex;

            if (keyData == Keys.Enter)
            {
                if (icolumn == dgvPrices.Columns.Count - 1)
                {
                    if (dgvPrices.Rows.Count != irow + 1)
                    dgvPrices.CurrentCell = dgvPrices[2, irow + 1];
                    else
                        dgvPrices.CurrentCell = dgvPrices[2, 0];
                }
                else
                {
                    dgvPrices.CurrentCell = dgvPrices[icolumn + 1, irow];
                }
                return true;
            }
            else
                return base.ProcessCmdKey(ref msg, keyData);
        }
        
    

        

       
    }
}
