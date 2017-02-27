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
    public partial class AddForm : Form
    {
        public AddForm(string barcode)
        {
            isAdd = true;
            InitializeComponent();
            
            if (barcode != null)
                tbxShtrix.Text = barcode;
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;

        }
        public AddForm(DataSetTpos.productRow productRow)
        {
            prRow = productRow;
            isAdd = false;
            InitializeComponent();
            if (!isAdd)
            {
                this.Text = "Редактировать товар";
                btnAdd.Text = "Изменить";
            }
            tbxName.Text = productRow.name;
            tbxPack.Text = productRow.pack.ToString();
            tbxPrice.Text = productRow.price.ToString();
            tbxShtrix.Text = productRow.barcode;
            if (productRow.barcode != null)
                tbxShtrix.Text = productRow.barcode;
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;

        }
        bool isAdd = true;
        DataSetTpos.productRow prRow;
        private void AddOrEdit(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbxName.Text))
            {
                
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                DataSetTposTableAdapters.productTableAdapter daProduct = new DataSetTposTableAdapters.productTableAdapter();
                if (isAdd)
                {
                    
                    DataSetTpos.productRow prRowN = DBclass.DS.product.NewproductRow();
                    prRowN.name = tbxName.Text;
                    prRowN.barcode = tbxShtrix.Text;
                    prRowN.measureId = 2;
                    prRowN.pack = tbxPack.Text!="0"&&tbxPack.Text!=""?Convert.ToInt32(tbxPack.Text):0;
                    prRowN.status = 0;
                    prRowN.price = Convert.ToInt32(tbxPrice.Text);
                    DBclass.DS.product.AddproductRow(prRowN);
                }
                else
                {
                    prRow.name = tbxName.Text;
                    prRow.barcode = tbxShtrix.Text;
                    prRow.measureId = 2;
                    prRow.pack = tbxPack.Text != "0" && tbxPack.Text != "" ? Convert.ToInt32(tbxPack.Text) : 0; ;
                    prRow.status = 0;
                    prRow.price = Convert.ToInt32(tbxPrice.Text); 
                }
                
                daProduct.Update(DBclass.DS.product);
            }
        }
    }
}
