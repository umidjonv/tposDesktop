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
        public AddForm(bool isadd, string barcode)
        {
            isAdd = isadd;
            InitializeComponent();
            if(!isAdd)
            {
                this.Text = "Редактировать товар";
                btnAdd.Text = "Изменить";
            }
            if (barcode != null)
                tbxShtrix.Text = barcode;
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;

        }
        bool isAdd = true;
        private void AddOrEdit(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbxName.Text))
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                DataSetTposTableAdapters.productTableAdapter daProduct = new DataSetTposTableAdapters.productTableAdapter();
                DataSetTpos.productRow prRow = DBclass.DS.product.NewproductRow();
                prRow.name = tbxName.Text;
                prRow.barcode = tbxShtrix.Text;
                prRow.measureId = 0;
                prRow.pack = 0;
                prRow.status = 0;
                prRow.price = Convert.ToInt32(tbxPrice.Text);
                DBclass.DS.product.AddproductRow(prRow);
                daProduct.Update(DBclass.DS.product);
            }
        }
    }
}
