using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Classes.Forms;
using Classes.DB;
namespace tposDesktop
{
    public partial class OrderForm : DesignedForm
    {
        private bool _dragging = false;
        private Point _offset;
        private Point _start_point = new Point(0, 0);
        float bal;
        public OrderForm(DataSetTpos.productRow prrow)
        {
            count = prrow.pack;
            
 
            prrow.price = getPrice(prrow.productId);
            InitializeComponent();
            //lblOne.Visible = false;
                lblOne.Text = prrow.price.ToString();
            lblCaption.Text = prrow.name;

            lblPrice.Text = (Math.Round(prrow.price * prrow.pack, 0)).ToString();

            bal = getSold(prrow.productId);
            tbxCount1.Text = (count != 0 ? count : 1).ToString();
            //float f = prrow.pack - (int)prrow.pack;
            //if (f > 0) prrow.pack = 1;
            if (Program.window_type == 2)
            {
                button1_Click(button1, new EventArgs());
            }
        }

        private float getSold(int id)
        {
            this.balanceTableAdapter1.Fill(DBclass.DS.balance);
            DataView balance = new DataView(DBclass.DS.balance);
            balance.RowFilter = "balanceDate = '2000-01-01' and prodId = " + id;

            return float.Parse(balance[0]["endCount"].ToString());
        }
        public float count = 0;
        public int sum = 0;
        private void OrderForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13&&EmptyChar())
            {
                button1_Click(null, new EventArgs());
            }
            if (e.KeyChar == 27)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }
            if (e.KeyChar == 46 || e.KeyChar == 44)
            {

            }
            else
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            
            
        
        }
        bool EmptyChar()
        { 
            if (tbxCount1.Text == "")
            {
                MessageBox.Show("Количество/вес не должно быть пустым");
                return false;
            }else
                return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(EmptyChar())
            {
                //prrow.price = (int)Math.Round(getPrice(prrow.productId) * prrow.pack, 2);
                count = Single.Parse(tbxCount1.Text);
                sum = Int32.Parse(lblOnePrice.Text);
                //if (bal == 0)
                //{
                //    MessageBox.Show("Товара не осталось");
                //}
                //else if (bal < count)
                //{
                //    MessageBox.Show("Количество больше чем на складе");
                //}
                //else
                //{
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                //}
            }
        }
        string text="";
        private void tbxCount1_TextChanged(object sender, EventArgs e)
        {
            TextBox t = sender as TextBox;
            int num;
            double cnt = (count == 0 ? 1 : count);
            double donasi = Math.Round((Convert.ToSingle(lblPrice.Text) / Math.Round(cnt,3)),2);
                
            if (tbxCount1.Text != "")
            {
                if (count.ToString() != tbxCount1.Text)
                {
                    
                    double curCnt = Convert.ToDouble(tbxCount1.Text);

                    
                    //if (i == 1)

                    lblOnePrice.Text = Math.Round(curCnt * donasi).ToString();
                }
                else
                    lblOnePrice.Text = lblPrice.Text;
                
            }
            string d = donasi.ToString();
            //if (d.IndexOf(".")!=-1)
            //lblOne.Text = d.Remove(d.IndexOf("."));
            //else
                //lblOne.Text = d;

            
            
        }
        private int getPrice(int id)
        {
            DataSetTposTableAdapters.getPriceTableAdapter daGetPrice = new DataSetTposTableAdapters.getPriceTableAdapter();
            object price = daGetPrice.GetPrice(id.ToString());
            return Convert.ToInt32(price);
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            if (lblOnePrice.Text == "0")
            { this.Close(); }
        }



        
    }
}
