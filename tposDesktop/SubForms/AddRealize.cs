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
        bool isEdit = false;
        public AddRealize(DataSetTpos.realizeRow rlzRow, DataSetTpos.realizeviewRow rlvRow, DataSetTpos.productRow productRow)
        {
            prRow = productRow;
            prRow = productRow;
            rlviewRow = rlvRow;
            isEdit = true;
            InitializeComponent();
            string sum = "0";


            if (DBclass.DS.balanceview.Rows.Count > 0)
            {
                DataRow[] blncs = DBclass.DS.balanceview.Select("prodId = " + rlvRow.productId);
                if (blncs.Length > 0)
                {
                    sum = ((DataSetTpos.balanceviewRow)blncs[0]).endCount;

                }
            }
            btnAdd.Text = "Изменить";
            lblSoldPrice.Visible = true;
            tbxSoldPrice.Visible = true;
            tbxSoldPrice.Text = rlzRow.soldPrice.ToString();
            pack = productRow.pack;
            lblAllCount.Text = sum;
            //DataView dv = new DataView(DBclass.DS.provider);
            //dv.RowFilter = "providerId = " + rlvRow.providerId.ToString();
            ////providerLbl.Text = dv[0]["orgName"].ToString();
            tbxPack.isFloat = true;
            tbxName.Text = rlvRow.name;
            tbxPack.Text =  ((int)rlzRow.count/(productRow.pack==0?1: productRow.pack)).ToString();
            tbxKol.Text = ((int)rlzRow.count % (productRow.pack == 0 ? 1 : productRow.pack)).ToString();
            //tbxPack.Text = int.Parse(rlvRow.count);

            tbxPricePrixod.Text = rlzRow.price.ToString();
            //tbxShtrix.Text = rlvRow.barcode;
            //tbxSoldPrice.Text = productRow.price.ToString();

            DataSetTposTableAdapters.realizeviewTableAdapter rlvda = new DataSetTposTableAdapters.realizeviewTableAdapter();
            DataSetTpos.realizeviewDataTable tablerlv = new DataSetTpos.realizeviewDataTable();
            //rlvda.FillByID(tablerlv, rlvRow.productId);
            //tbxPricePrixod.Text = (tablerlv.Rows.Count > 0 ? (tablerlv.Rows[0] as DataSetTpos.realizeviewRow).fakturaPrice.ToString() : "0");


            //if (rlvRow.barcode != null)
            //    tbxShtrix.Text = rlvRow.barcode;
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;

            

            
            //rlviewRow = rlvRow;
            rlRow = rlzRow;
        }
        DataSetTpos.productRow prRow;
        DataSetTpos.fakturaRow fkRow;
        DataSetTpos.realizeRow rlRow;
        DataSetTpos.realizeviewRow rlviewRow;
        private void AddOrEdit(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbxName.Text))
            {
                if (string.IsNullOrEmpty(tbxKol.Text))
                {
                    tbxKol.Text = "0";
                }
                if (string.IsNullOrEmpty(tbxPack.Text))
                {
                    tbxPack.Text = "0";
                }
                if (string.IsNullOrEmpty(tbxPricePrixod.Text))
                {
                    tbxPricePrixod.Text = "0";
                }
                if (string.IsNullOrEmpty(tbxSoldPrice.Text))
                {
                    tbxSoldPrice.Text = "0";
                }
                if (Convert.ToInt32(tbxPack.Text) > 0 || Convert.ToInt32(tbxKol.Text) > 0)
                {
                    if (Convert.ToInt32(tbxSoldPrice.Text) == 0 || string.IsNullOrEmpty(tbxSoldPrice.Text))
                    {
                        MessageBox.Show("Цена продажи не может быть равно нулю или пустым");
                    }
                    else
                    {
                        if (!isEdit)
                        {
                            addRealizeFunc();
                        }
                        else
                        { editRealizeFunc(); }
                    }
                }
                else
                {
                    if (!isEdit)
                    {
                        addRealizeFunc();
                    }
                    else
                    {
                        editRealizeFunc();
                    }

                }
                
                
            }
        }
        private void editRealizeFunc()
        {
            DataSetTposTableAdapters.realizeTableAdapter daReal = new DataSetTposTableAdapters.realizeTableAdapter();
            DataSetTposTableAdapters.realizeviewTableAdapter daRealV = new DataSetTposTableAdapters.realizeviewTableAdapter();
            DBclass db = new DBclass();
            float cnt, count;
            
            if (pack != 0)
            {
                count = cnt = Convert.ToInt32(tbxPack.Text) * pack + Convert.ToInt32(tbxKol.Text);
            }
            else
            {
                count = cnt = Convert.ToInt32(tbxPack.Text);
            }
            if (rlRow.count > cnt)
            {
                cnt = rlRow.count - cnt;
                db.calcProc("minus", prRow.productId, cnt);
            }
            else if (rlRow.count < cnt)
            {
                cnt = cnt - rlRow.count;
                db.calcProc("plus", prRow.productId, cnt);
            }
            rlRow.count = count;

            rlRow.soldPrice = int.Parse(tbxSoldPrice.Text);
            
           
            if (UserValues.role=="admin")prRow.price = rlRow.soldPrice;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            daReal.Update(rlRow);
            daReal.Fill(DBclass.DS.realize);
            

            //daRealV.Update(rlviewRow);
            daRealV.FillByFaktura(DBclass.DS.realizeview, rlviewRow.fakturaId);
            
            
        }
        private void addRealizeFunc()
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            DataSetTposTableAdapters.realizeTableAdapter daReal = new DataSetTposTableAdapters.realizeTableAdapter();
            DBclass db = new DBclass();
            DataSetTpos.realizeRow[] rlRows = (DataSetTpos.realizeRow[])DBclass.DS.realize.Select("prodid = " + prRow.productId + " and fakturaId = " + fkRow.fakturaId);
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
                    if (prRow.exp == null && Properties.Settings.Default.workMode=="0")
                    {
                        prRow.expiry = Convert.ToDateTime(expiry.Text);
                    }
                }

                db.calcProc("plus", prRow.productId, cnt);
                DBclass.DS.realize.AddrealizeRow(rlRow);
            }

            DataSetTposTableAdapters.productTableAdapter pr = new DataSetTposTableAdapters.productTableAdapter();
            if (limitChbx.Checked)
                prRow.limitProd = 1;
            if (prRow.price == 0)
                prRow.price = rlRow.soldPrice;

            pr.Update(prRow);


            daReal.Update(DBclass.DS.realize);
            daReal.Fill(DBclass.DS.realize);
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

        private void expiry_ValueChanged(object sender, EventArgs e)
        {
            
            //expiry.Value = new DateTime(expiry.Value.Year, expiry.Value.Month, 01);

        }

        private void limitChbx_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tbxPercent_TextChanged(object sender, EventArgs e)
        {
            if (tbxPercent.Text != "0")
            {
                tbxSoldPrice.Text =  (int.Parse(tbxPricePrixod.Text) + float.Parse(tbxPricePrixod.Text) /100 * int.Parse(tbxPercent.Text==""?"0": tbxPercent.Text)).ToString();
            }
            
        }
    }
}
