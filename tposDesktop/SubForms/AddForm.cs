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
        private bool _dragging = false;
        private Point _offset;
        private Point _start_point = new Point(0, 0);
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
                    daProduct.Update(prRowN);
                    
                    daProduct.Fill(DBclass.DS.product);
                    int? lId = daProduct.LastID();


                    if (lId != null&&tbxShtrix.Text=="")
                    {

                        int id = lId.Value;
                        DataSetTpos.productRow pr = DBclass.DS.product.FindByproductId(id);
                        string barcode = randNumbers(id);
                        pr.barcode = barcode;
                        pr.status = 1;
                        daProduct.Update(pr);
                    }
                    
                
                }
                else
                {
                    prRow.name = tbxName.Text;
                    prRow.barcode = tbxShtrix.Text;
                    prRow.measureId = 2;
                    prRow.pack = tbxPack.Text != "0" && tbxPack.Text != "" ? Convert.ToInt32(tbxPack.Text) : 0; ;
                    
                    prRow.price = Convert.ToInt32(tbxPrice.Text);
                    daProduct.Update(prRow);
                    daProduct.Fill(DBclass.DS.product);
                
                }
                
                

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddForm_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _start_point = new Point(e.X, e.Y);
        }

        private void AddForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X-this._start_point.X,p.Y-this._start_point.Y);
            
            }
        }

        private void AddForm_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        private void control_keypress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }
        }

        private string randNumbers(int id)
        {
            int cnt = id.ToString().Length;
            Random rand = new Random();
            string temp1 = "";

            if (cnt == 1)
            {
                temp1 = rand.Next(100000, 199999).ToString() + rand.Next(10000, 99999).ToString();
            }
            else if (cnt == 2)
            {
                temp1 = rand.Next(100000, 199999).ToString() + rand.Next(1000, 9999).ToString();
            }
            else if (cnt == 3)
            {
                temp1 = rand.Next(100000, 199999).ToString() + rand.Next(100, 999).ToString();
            }
            else if (cnt == 4)
            {
                temp1 = rand.Next(100000, 199999).ToString() + rand.Next(10, 99).ToString();
            }
            else if (cnt == 5)
            {
                temp1 = rand.Next(100000, 199999).ToString() + rand.Next(10, 9).ToString();
            }
            
            return id.ToString() + temp1;
        }

    }
}
