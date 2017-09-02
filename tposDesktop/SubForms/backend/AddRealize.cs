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
        float pack;

        public AddRealize(string barcode)
        {

            InitializeComponent();
            tbxPack.isFloat = true;
            if (barcode != null)
                tbxShtrix.Text = barcode;
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;

        }
        public AddRealize(DataSetTpos.productRow productRow, DataSetTpos.fakturaRow faktRow)
        {
            prRow = productRow;
            fkRow = faktRow;

            InitializeComponent();
            DataView dv = new DataView(DBclass.DS.provider);
            dv.RowFilter = "providerId = " + fkRow.providerId.ToString();
            providerLbl.Text = dv[0]["orgName"].ToString();
            tbxPack.isFloat = true;
            tbxName.Text = productRow.name;
            tbxPack.Text = 1.ToString();
            pack = productRow.pack;
            
            tbxPricePrixod.Text = "0";
            tbxShtrix.Text = productRow.barcode;
            tbxSoldPrice.Text = productRow.price.ToString();
            if (productRow.barcode != null)
                tbxShtrix.Text = productRow.barcode;
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            if (productRow.pack == 0 || productRow.pack == 1)
            {
                tbxKol.Visible = false;
                lblKol.Visible = false;
            }


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
                DataSetTpos.realizeRow[] rlRows = (DataSetTpos.realizeRow[])DBclass.DS.realize.Select("prodid = " + prRow.productId + " and fakturaId = " + fkRow.fakturaId);
                DataSetTpos.realizeRow rlRow;
                if (rlRows.Length > 0)
                {
                    float cnt;
                    rlRow = rlRows[0];
                    if (pack != 0)
                    {
                        cnt = Convert.ToInt32(tbxPack.Text) * pack + Convert.ToInt32(tbxKol.Text);
                    }
                    else
                    {
                        cnt = Convert.ToSingle(tbxPack.Text);
                    }
                    rlRow.count += cnt;
                    rlRow.price = Convert.ToInt32(tbxPricePrixod.Text);
                    rlRow.soldPrice = Convert.ToInt32(tbxSoldPrice.Text);


                    db.calcProc("plus", prRow.productId, cnt);   

                }
                else
                {
                    float cnt;
                    rlRow = DBclass.DS.realize.NewrealizeRow();
                    if (pack != 0)
                    {
                        cnt = Convert.ToInt32(Math.Round(Convert.ToDouble(tbxPack.Text) * pack, 2) + Convert.ToInt32(tbxKol.Text));
                    }
                    else
                    {
                        cnt = Convert.ToSingle(tbxPack.Text);
                    }
                    rlRow.count = cnt;
                    rlRow.price = Convert.ToInt32(tbxPricePrixod.Text);
                    rlRow.soldPrice = Convert.ToInt32(tbxSoldPrice.Text);
                    rlRow.fakturaId = fkRow.fakturaId;
                    rlRow.prodId = prRow.productId;
                    DBclass.DS.realize.AddrealizeRow(rlRow);
                    db.calcProc("plus", prRow.productId, cnt);   
                }
                //if(prRow.price==0)
                prRow.price = rlRow.soldPrice;


                daReal.Update(DBclass.DS.realize);
                daReal.Fill(DBclass.DS.realize);

            }
        }

        private void AddRealize_Load(object sender, EventArgs e)
        {
            tbxPack.Focus();
        }

        private void btnBarcode_Click(object sender, EventArgs e)
        {

            printForm pr = new printForm(tbxName.Text, tbxSoldPrice.Text, tbxShtrix.Text);
            pr.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (tbxName.Text == "" & tbxSoldPrice.Text == "0")
            {
                MessageBox.Show("не указан названия товара или цена");
            }
            else
            {
                AddForm adF = new AddForm(prRow);
                adF.forPrinting(tbxName.Text, tbxSoldPrice.Text, tbxShtrix.Text);

            }
        }


    }
}
