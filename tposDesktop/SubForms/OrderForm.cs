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
namespace tposDesktop
{
    public partial class OrderForm : DesignedForm
    {
        private bool _dragging = false;
        private Point _offset;
        private Point _start_point = new Point(0, 0);
        DataSetTpos.productRow prRow;
        public OrderForm(DataSetTpos.productRow prrow)
        {
            count = prrow.pack;
            prrow.price = getPrice(prrow.productId);
            prRow = prrow;
            InitializeComponent();
            lblCaption.Text = prrow.name;
            lblPrice.Text = prrow.price.ToString();
            tbxCount1.Text = (count != 0 ? count : 1).ToString();
            
        }
        public int count = 0;
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

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            
        
        }
        bool EmptyChar()
        { 
            if (tbxCount1.Text == "")
            {
                MessageBox.Show("Количество не должно быть пустым");
                return false;
            }else
                return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(EmptyChar())
            {
                
                count = Int32.Parse(tbxCount1.Text);
                if (pMax >= count)
                {
                    sum = Int32.Parse(lblOnePrice.Text);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                else 
                {
                    MessageBox.Show("Количество больше чем на складе!");
                }
            }
        }
        string text="";
        private void tbxCount1_TextChanged(object sender, EventArgs e)
        {
            TextBox t = sender as TextBox;
            int num;
            int cnt = (count == 0 ? 1 : count);
            double donasi = Math.Round((Convert.ToSingle(lblPrice.Text) / cnt),2);
                
            if (tbxCount1.Text != "")
            {
                if (count.ToString() != tbxCount1.Text)
                {
                    
                    int curCnt = Convert.ToInt32(tbxCount1.Text);

                    
                    //if (i == 1)

                    lblOnePrice.Text = Math.Round(curCnt * donasi).ToString();
                }
                else
                    lblOnePrice.Text = lblPrice.Text;
                
            }
            string d = donasi.ToString();
            if (d.IndexOf(".")!=-1)
            lblOne.Text = d.Remove(d.IndexOf("."));
            else
                lblOne.Text = d;

            
            
        }
        private int getPrice(int id)
        {
            DataSetTposTableAdapters.getPriceTableAdapter daGetPrice = new DataSetTposTableAdapters.getPriceTableAdapter();
            object price = daGetPrice.GetPrice(id.ToString());
            return Convert.ToInt32(price);
        }
        int pMax = 0;
        private void OrderForm_Load(object sender, EventArgs e)
        {
            DataSetTpos.productviewRow[] prv = (DataSetTpos.productviewRow[])Classes.DB.DBclass.DS.productview.Select("productId = " + prRow.productId);
            int cnt = Convert.ToInt32(tbxCount1.Text);
            if(prv.Length>0)
            {
                if (prv[0].endCount.Contains("/"))
                {
                    string[] s = prv[0].endCount.Split(new char[] { '/' });
                    int a = Convert.ToInt32(s[0].Trim());
                    if (s[1].Contains("."))
                    { s[1] = s[1].Remove(s[1].IndexOf(".")); }
                    int b = Convert.ToInt32(s[1].Trim());
                    pMax = a * prRow.pack + b;
                    if (pMax <= 0)
                    {
                        this.Close();
                    }
                }
                else
                {
                    pMax = Convert.ToInt32(prv[0].endCount);
                    if (pMax <= 0)
                    {
                        this.Close();
                    }
                }

            }
            if (lblOnePrice.Text == "0")
            { 

                this.Close(); 
            }
        }



        
    }
}
