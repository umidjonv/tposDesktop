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
        public OrderForm(string name, int cnt, string price)
        {
            count = cnt;
            
            InitializeComponent();
            lblCaption.Text = name;
            lblPrice.Text = price;
            tbxCount1.Text = (cnt != 0 ? cnt : 1).ToString();
        }
        public int count = 0;
        public int sum = 0;
        private void OrderForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13&&EmptyChar())
            {
                count = Int32.Parse(tbxCount1.Text);
                sum = Int32.Parse(lblOnePrice.Text);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
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
                sum = Int32.Parse(lblOnePrice.Text);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
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

            
            //if (Int32.TryParse(t.Text, out num))
            //{
            //    text = t.Text;
            //    //t.SelectionStart = t.Text.Length;
            //}
        }

        private void OrderForm_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _start_point = new Point(e.X, e.Y);
        }

        private void OrderForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);

            }
        }

        private void OrderForm_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
