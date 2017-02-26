using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tposDesktop
{
    public partial class OrderForm : Form
    {
        public OrderForm(int cnt, string price)
        {
            count = cnt;
            
            InitializeComponent();
            lblPrice.Text = price;
            tbxCount1.Text = (cnt != 0 ? cnt : 1).ToString();
        }
        public int count = 0;
        private void OrderForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                count = Int32.Parse(tbxCount1.Text);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            if (e.KeyChar == 27)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            count = Int32.Parse(tbxCount1.Text);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
        string text="";
        private void tbxCount1_TextChanged(object sender, EventArgs e)
        {
            TextBox t = sender as TextBox;
            int num;
            if (Int32.TryParse(t.Text, out num))
            {
                text = t.Text;
                t.SelectionStart = t.Text.Length;
            }
            else
            {
                t.Text = text;
            }
        }
    }
}
