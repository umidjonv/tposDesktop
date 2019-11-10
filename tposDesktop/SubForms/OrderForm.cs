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
        DataSetTpos.productRow prRow;
        public OrderForm(DataSetTpos.productRow prrow)
        {
            count = prrow.pack;
            if (Properties.Settings.Default.workMode == "0")
            {

                DataSetTposTableAdapters.realizeTableAdapter rlzDa = new DataSetTposTableAdapters.realizeTableAdapter();

                rlzDa.FillByIsSold(DBclass.DS.realize, prrow.productId);
                prrow.price = getPrice(prrow.productId);

                

                //DateTime date = getExpire(prrow.productId);
                //if (date!= DateTime.Parse("2000-01-01"))
                //{
                //    prrow.expiry = date;

                //}
            }
            
            
            prRow = prrow;
            InitializeComponent();
            lblCaption.Text = prrow.name;

            
            DataSetTpos.productviewRow prViewRow = DBclass.DS.productview.FindByproductId(prrow.productId);
            
            int allkol;
            if (prViewRow.endCount.Contains("/"))
            {
                string[] sp = prViewRow.endCount.Split(new char[] { '/' });
                int pachka = Convert.ToInt32(sp[0]);
                int kol = Convert.ToInt32(sp[1]);
                allkol = pachka * prrow.pack + kol;
                lblCnt.Text = prViewRow.endCount.ToString() + "  шт";

            }
            else
            {
                allkol = Convert.ToInt32(prViewRow.endCount);
                lblCnt.Text = prViewRow.endCount.ToString() + "  шт";
            }
            if (prrow.pack > allkol)
            {
                count = allkol;
            }
            maxCount = allkol;






            donasi = (prrow.pack != 0 ? prrow.price / prrow.pack : prrow.price);
            if (count>0 && (prrow.pack != 0 && count% prrow.pack == 0))
            {
                lblPrice.Text = prrow.price.ToString();
            }
            else
            {
                lblPrice.Text = (Math.Round(donasi * count)).ToString();
            }

            
            tbxCount1.Text = (count != 0 ? count : 1).ToString();
            

            

            if (prrow.limitProd == 1)
            {
                lblLimit.Visible = true;
            }
            
        }
        public double donasi = 0;
        public int count = 0;
        public int sum = 0;
        public int maxCount = 0;
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
                sum = Int32.Parse(lblOnePrice.Text);
                DataSetTposTableAdapters.realizeTableAdapter rlzDa = new DataSetTposTableAdapters.realizeTableAdapter();

                float tCnt = (float)count;
                ////////foreach (DataRow dr in DBclass.DS.realize.Rows)
                ////////{
                ////////    DataSetTpos.realizeRow rlzRow = (DataSetTpos.realizeRow)dr;
                ////////    //rlzDa.FillByID(DBclass.DS.realize, rlzNRow.realizeId);
                ////////    //DataSetTpos.realizeRow rlzRow = DBclass.DS.realize.FindByrealizeId(rlzNRow.realizeId);
                ////////    if (tCnt == 0) break;
                ////////    float rCount = (rlzRow.IsSold == 0 ? rlzRow.count : rlzRow.IsSold);

                    
                ////////    if (tCnt >= rCount)
                ////////    {
                ////////        tCnt = tCnt - rCount;
                ////////        rlzRow.IsSold = -1;
                ////////    }
                ////////    else
                ////////    {
                        
                ////////        rlzRow.IsSold = (int)(rCount - tCnt);
                ////////        tCnt = 0;
                ////////    }
                ////////    rlzDa.Update(rlzRow);
                    

                ////////}
                //rlzDa.FillByID(DBclass.DS.realize, )
                
                
                //if (pMax == 0)
                //{
                //    MessageBox.Show("Товара не осталось");
                //}
                //else if (pMax < count)ve
                //{
                //    MessageBox.Show("Количество больше чем на складе");
                //    count = pMax;
                //}
                //else
                //{
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                //}
            }
        }
        private void tbxCount1_TextChanged(object sender, EventArgs e)
        {
            TextBox t = sender as TextBox;
            int num;
            int cnt = (count == 0 ? 1 : count);
            int curCnt = 0;
            //double donasi = Math.Round((Convert.ToSingle(lblPrice.Text) / (prRow.pack == 0 ? 1 : prRow.pack)),2);
                
            if (tbxCount1.Text != "")
            {
                if (count.ToString() != tbxCount1.Text)
                {
                    
                    curCnt = Convert.ToInt32(tbxCount1.Text);
                    if (curCnt > maxCount)
                    {
                        tbxCount1.Text = maxCount.ToString();
                        curCnt = maxCount;
                    }
                    
                    //if (i == 1)

                    lblOnePrice.Text = Math.Round(curCnt * donasi).ToString();
                }
                else
                    lblOnePrice.Text = lblPrice.Text;
                    

                if (curCnt!=0&& prRow.pack != 0 && curCnt% prRow.pack == 0)
                {
                    int roundKol = 1;
                    if (curCnt / prRow.pack != 0)
                    {
                        roundKol = curCnt / prRow.pack;
                    }

                    lblOnePrice.Text = (prRow.price * roundKol).ToString();
                }
                
            }
            string d = donasi.ToString();
            if (d.IndexOf(".")!=-1)
            lblOne.Text = d.Remove(d.IndexOf("."));
            else
                lblOne.Text = d;
            
            
            
        }
        private int getPrice(int id)
        {
            DataSetTposTableAdapters.realizeTableAdapter rlzDa = new DataSetTposTableAdapters.realizeTableAdapter();

            rlzDa.FillByIsSold(DBclass.DS.realize, id);
            if (DBclass.DS.realize.Rows.Count > 0) 
            {
                return (DBclass.DS.realize.Rows[0] as DataSetTpos.realizeRow).soldPrice;
            }else
            { return 0; }

            //DataSetTposTableAdapters.getPriceTableAdapter daGetPrice = new DataSetTposTableAdapters.getPriceTableAdapter();
            //object price = daGetPrice.GetPrice(id.ToString(),Properties.Settings.Default.workMode);
            //return Convert.ToInt32(price);
        }
        
        private DateTime getExpire(int id)
        {
            //DataSetTposTableAdapters.getPriceTableAdapter daGetPrice = new DataSetTposTableAdapters.getPriceTableAdapter();
            //object price = daGetPrice.GetExpiry(id.ToString());
            //return Convert.ToDateTime(price);
            
            if (DBclass.DS.realize.Rows.Count > 0)
            {
                try
                {
                    return (DBclass.DS.realize.Rows[0] as DataSetTpos.realizeRow).expiryDate;
                }
                catch (Exception)
                {
                    return DateTime.Parse("2000-01-01");

                }
            }
            else
            { return DateTime.Parse("2000-01-01"); }
        }
        
        private string getProdBalance(int id)
        {
            DataView dv = new DataView(Classes.DB.DBclass.DS.productview);
            dv.RowFilter = "productId = " + id.ToString();
            
            return dv[0][5].ToString();
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
                        if(Properties.Settings.Default.workMode == "0" ){ this.Close();}
                    }
                }
                else
                {
                    pMax = Convert.ToInt32(prv[0].endCount);
                    if (pMax <= 0)
                    {
                        if (Properties.Settings.Default.workMode == "0") { this.Close(); }
                    }
                }

            }
            if (lblOnePrice.Text == "0")
            { 

                this.Close(); 
            }
        }

        private void lblLimit_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
