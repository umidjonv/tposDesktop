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
        public OrderForm(string name, int cnt, string price)
        {
            count = cnt;
            
            InitializeComponent();
            this.Text = name;
            lblPrice.Text = price;
            tbxCount1.Text = (cnt != 0 ? cnt : 1).ToString();
        }
        public int count = 0;
        private void OrderForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13&&EmptyChar())
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
            int donasi = Convert.ToInt32(lblPrice.Text) / cnt;
                
            if (tbxCount1.Text != "")
            {
                if (count.ToString() != tbxCount1.Text)
                {
                    
                    int curCnt = Convert.ToInt32(tbxCount1.Text);

                    
                    //if (i == 1)

                    lblOnePrice.Text = (curCnt * donasi).ToString();
                }
                else
                    lblOnePrice.Text = lblPrice.Text;
                
            }
            lblOne.Text = donasi.ToString();
            
            //if (Int32.TryParse(t.Text, out num))
            //{
            //    text = t.Text;
            //    //t.SelectionStart = t.Text.Length;
            //}
        }



    }
}
