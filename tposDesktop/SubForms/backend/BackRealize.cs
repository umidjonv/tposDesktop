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
    public partial class BackRealize : DesignedForm
    {
        float pack;
        
        public BackRealize(string barcode)
        {

            InitializeComponent();
            tbxPack.isFloat = true;
            if (barcode != null)
                tbxShtrix.Text = barcode;
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;

        }
        public BackRealize(DataSetTpos.productRow productRow, DataSetTpos.backfakturaRow faktRow)
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
        DataSetTpos.backfakturaRow fkRow;
        DataSetTpos.realizeRow rlRow;
        private void AddOrEdit(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbxName.Text))
            {

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                DataSetTposTableAdapters.backrealizeTableAdapter daReal = new DataSetTposTableAdapters.backrealizeTableAdapter();
                DBclass db = new DBclass();
                DataSetTpos.backrealizeRow[] rlRows = (DataSetTpos.backrealizeRow[])DBclass.DS.backrealize.Select("prodid = " + prRow.productId + " and backFakturaId = " + fkRow.backFakturaId);
                DataSetTpos.backrealizeRow rlRow;
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


                    db.calcProc("plus", prRow.productId, cnt);   

                }
                else
                {
                    float cnt;
                    rlRow = DBclass.DS.backrealize.NewbackrealizeRow();
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
                    rlRow.backFakturaId = fkRow.backFakturaId;
                    rlRow.prodId = prRow.productId;
                    DBclass.DS.backrealize.AddbackrealizeRow(rlRow);  
                }
                //if(prRow.price==0)


                daReal.Update(DBclass.DS.backrealize);
                daReal.Fill(DBclass.DS.backrealize);

            }
        }

        private void BackRealize_Load(object sender, EventArgs e)
        {
            tbxPack.Focus();
        }

        


    }
}
