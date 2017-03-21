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
    public partial class AddRealize : Form
    {
        int pack;
        public AddRealize(string barcode)
        {
            isAdd = true;
            InitializeComponent();
            
            if (barcode != null)
                tbxShtrix.Text = barcode;
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            
        }
        public AddRealize(DataSetTpos.productRow productRow, DataSetTpos.fakturaRow faktRow)
        {
            prRow = productRow;
            fkRow = faktRow;
            isAdd = true;
            InitializeComponent();
            
            tbxName.Text = productRow.name;
            tbxPack.Text = 1.ToString();
            pack = productRow.pack;
            tbxPrice.Text = productRow.price.ToString();
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
        bool isAdd = true;
        DataSetTpos.productRow prRow;
        DataSetTpos.fakturaRow fkRow;
        DataSetTpos.realizeRow rlRow;
        private void AddOrEdit(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbxName.Text))
            {
                
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                DataSetTposTableAdapters.realizeTableAdapter daReal = new DataSetTposTableAdapters.realizeTableAdapter();

                DataSetTpos.realizeRow rlRow = DBclass.DS.realize.NewrealizeRow();
                if (pack != 0)
                {
                    rlRow.count = Convert.ToInt32(tbxPack.Text) * pack + Convert.ToInt32(tbxKol.Text);
                }
                else
                {
                    rlRow.count = Convert.ToInt32(tbxPack.Text);
                }
                rlRow.price = Convert.ToInt32(tbxPrice.Text);
                rlRow.fakturaId = fkRow.fakturaId;
                rlRow.prodId = prRow.productId;
                DBclass.DS.realize.AddrealizeRow(rlRow);
                daReal.Update(DBclass.DS.realize);
                daReal.Fill(DBclass.DS.realize);
                
            }
        }
    }
}
