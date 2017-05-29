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
    public partial class AddRealize : DesignedForm
    {
        int pack;
        int prodId;
        public AddRealize(string barcode)
        {
            
            InitializeComponent();
            
            if (barcode != null)
                tbxShtrix.Text = barcode;
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            
        }
        public AddRealize(DataSetTpos.productRow productRow, DataSetTpos.fakturaRow faktRow)
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
                DBclass db = new DBclass();
                DataSetTpos.realizeRow[] rlRows = (DataSetTpos.realizeRow[])DBclass.DS.realize.Select("prodid = "+prRow.productId+" and fakturaId = "+fkRow.fakturaId);
                DataSetTpos.realizeRow rlRow;
                if (rlRows.Length > 0)
                {
                    Int32 cnt;
                    rlRow = rlRows[0];
                    if (pack != 0)
                    {
                        cnt = Convert.ToInt32(tbxPack.Text) * pack + Convert.ToInt32(tbxKol.Text);
                    }
                    else
                    {
                        cnt = Convert.ToInt32(tbxPack.Text);
                    }
                    rlRow.count += cnt;
                    rlRow.price = Convert.ToInt32(tbxPricePrixod.Text);
                    rlRow.soldPrice = Convert.ToInt32(tbxSoldPrice.Text);
                    
                    db.calcProc("plus", prRow.productId, cnt);   
                    
                }
                else
                {
                    Int32 cnt;
                    rlRow = DBclass.DS.realize.NewrealizeRow();
                    if (pack != 0)
                    {
                        cnt = Convert.ToInt32(Math.Round(Convert.ToDouble(tbxPack.Text) * pack, 2) + Convert.ToInt32(tbxKol.Text));
                    }
                    else
                    {
                        cnt = Convert.ToInt32(tbxPack.Text);
                    }
                    rlRow.count = cnt;
                    rlRow.price = Convert.ToInt32(tbxPricePrixod.Text);
                    rlRow.soldPrice = Convert.ToInt32(tbxSoldPrice.Text);
                    rlRow.fakturaId = fkRow.fakturaId;
                    rlRow.prodId = prRow.productId;
                    if (expiry.Enabled == true)
                    {
                        rlRow.expiryDate = Convert.ToDateTime(expiry.Text);
                        if (prRow.expiry == null)
                        {
                            prRow.expiry = Convert.ToDateTime(expiry.Text).ToString("yyyy-MM-dd");
                        }
                    }

                    db.calcProc("plus", prRow.productId, cnt);
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

        private void AddRealize_Load(object sender, EventArgs e)
        {
            tbxPack.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddForm adF = new AddForm("");
            if (tbxSoldPrice.Text == "0")
            {
                MessageBox.Show("не указана цена");
            }
            else
            {
                adF.forPrinting(tbxName.Text, tbxSoldPrice.Text, tbxShtrix.Text,prodId);
            }
        }

        private void checkExpire_CheckedChanged(object sender, EventArgs e)
        {
            if (checkExpire.Checked == true)
            {
                expiry.Enabled = true;
            }
            else
            {
                expiry.Enabled = false;
            }
        }

       
    }
}
