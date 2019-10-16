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
    public partial class KolForm : DesignedForm
    {
        private bool _dragging = false;
        private Point _offset;
        private Point _start_point = new Point(0, 0);
        float bal;
        bool kg = false;
        public KolForm(DataSetTpos.productRow prrow)
        {
           
            InitializeComponent();
            lblCaption.Text = prrow.name;
            if (prrow.measureId != 2)
            {
                tbxCount1.isFloat = true;
                kg = true;
            }
            
        }
        public KolForm(DataSetTpos.productRow prrow, float kol)
        {

            InitializeComponent();
            lblKol.Text = kol.ToString();
            lblCaption.Text = prrow.name;
            if (prrow.measureId != 2)
            {
                tbxCount1.isFloat = true;
                kg = true;
            }

        }
        public float count = 0;
        public int sum = 0;
        bool isSetDecimalChar = false;
        private void OrderForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13&&EmptyChar())
            {
                button1_Click(null, new EventArgs());
            }
            if(e.KeyChar == 43 && EmptyChar())
            {
                button2_Click(null, new EventArgs());
            }
            if (e.KeyChar == 27)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }
            if (e.KeyChar == 46 || e.KeyChar == 44)
            {
                if (this.kg)
                {
                    if ((sender as TextBox).Text.IndexOf(char.Parse(",")) != -1 || (sender as TextBox).Text.IndexOf(char.Parse(".")) != -1)
                        e.Handled = true;
                }
                else e.Handled = true;
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
                System.Globalization.NumberFormatInfo numberformat = new System.Globalization.NumberFormatInfo();

                count = Single.Parse(tbxCount1.Text.Replace(",", numberformat.CurrencyDecimalSeparator).Replace(".", numberformat.CurrencyDecimalSeparator), numberformat);
                
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
        private void button2_Click(object sender, EventArgs e)
        {
            if (EmptyChar())
            {
                //prrow.price = (int)Math.Round(getPrice(prrow.productId) * prrow.pack, 2);
                System.Globalization.NumberFormatInfo numberformat = new System.Globalization.NumberFormatInfo();

                count = Single.Parse(tbxCount1.Text.Replace(",", numberformat.CurrencyDecimalSeparator).Replace(".", numberformat.CurrencyDecimalSeparator), numberformat);
                count = count + Convert.ToSingle(lblKol.Text);
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
            
                
            
            
            
            
        }
        

        



        
    }
}
