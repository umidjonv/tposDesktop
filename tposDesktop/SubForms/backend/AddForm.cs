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
using Classes.Forms;
using System.IO;
using tposDesktop.SubForms;
using ZXing.QrCode;
using System.Collections;
using ZXing;
using ZXing.QrCode.Internal;
using ZXing.Common;
using System.Drawing.Imaging;
using ZXing.Rendering;
namespace tposDesktop
{
    public partial class AddForm : DesignedForm
    {
        private EncodingOptions EncodingOptions { get; set; }
        private Type Renderer { get; set; }
        //private bool _dragging = false;
        //private Point _offset;
        //private Point _start_point = new Point(0, 0);
        public AddForm(string barcode)
        {
            isAdd = true;
            InitializeComponent();
            CheckRole();
            providerTableAdapter1.Fill(DBclass.DS.provider);
            DataView dv = new DataView(DBclass.DS.provider);
            
            dv.RowFilter = "";
            prCmbx.DataSource = DBclass.DS.provider;
            prCmbx.DisplayMember = "orgName";
            prCmbx.ValueMember = "providerId";

            
            if (barcode != null)
                tbxShtrix.Text = barcode;
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;

        }
        public AddForm(DataSetTpos.productRow productRow)
        {
            prRow = productRow;
            isAdd = false;
            InitializeComponent();
            CheckRole();
            providerTableAdapter1.Fill(DBclass.DS.provider);
            DataView dv = new DataView(DBclass.DS.provider);
            dv.RowFilter = "";

            prCmbx.DataSource = DBclass.DS.provider;
            prCmbx.DisplayMember = "orgName";
            prCmbx.ValueMember = "providerId";
            if (!isAdd)
            {
                lblCaption.Text = "Редактировать товар";
                btnAdd.Text = "Изменить";
                button1.Visible = true;
            }
            if (productRow.measureId == 2)
            {
                measureRadio.Checked = true;
            }
            if (productRow.measureId == 1)
            {
                measureRadio2.Checked = true;
            }
            switch (productRow.measureId)
            {
                case 1:
                    measureRadio2.Checked = true;
                    break;
                case 2:
                    measureRadio.Checked = true;
                    break;
                case 3:
                    measureRadio3.Checked = true;
                    break;
                case 4:
                    measureRadio4.Checked = true;
                    break;
            }
            if (prCmbx.Items.Count > 0)
            {
                 prCmbx.SelectedValue = productRow.providerId;
            }
            DataSetTposTableAdapters.realizeTableAdapter rda = new DataSetTposTableAdapters.realizeTableAdapter();
            if(prCmbx.Items.Count>0)
            {
                object providerID = rda.LastProvider(prRow.productId);
                if(providerID!=null)
                prCmbx.SelectedValue = providerID;
            }
                
            
            tbxName.Text = productRow.name;
            tbxPack.Text = productRow.pack.ToString();
            tbxPrice.Text = productRow.price.ToString();
            tbxShtrix.Text = productRow.barcode;
            if (productRow.barcode != null)
                tbxShtrix.Text = productRow.barcode;
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Renderer = typeof(BitmapRenderer);

        }
        private void CheckRole()
        {
            if(UserValues.role == "manager")
            {
                tbxPrice.Enabled = false;
            }
 
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
                    int rbtn = 2;
                    DataSetTpos.productRow prRowN = DBclass.DS.product.NewproductRow();
                    prRowN.name = tbxName.Text;
                    prRowN.barcode = tbxShtrix.Text;
                    if (measureRadio.Checked)
                    {
                        rbtn = 2; //ШТ
                    }
                    else if (measureRadio2.Checked)
                    {
                        rbtn = 1;//КГ
                    }
                    else if (measureRadio3.Checked)
                    {
                        rbtn = 3;//литр
                    }
                    else if (measureRadio4.Checked)
                    {
                        rbtn = 4; //кв.м
                    }
                    prRowN.measureId = rbtn;
                    prRowN.pack = 0;// tbxPack.Text != "0" && tbxPack.Text != "" ? Convert.ToInt32(tbxPack.Text) : 0;
                    prRowN.status = 0;
                    if (prCmbx.Text == "")
                    {
                        prRowN.providerId = 1;
                    }
                    else
                    {
                        prRowN.providerId = prCmbx.FindStringExact(prCmbx.Text);
                    }
                    prRowN.price = Convert.ToInt32(tbxPrice.Text);
                    DBclass.DS.product.AddproductRow(prRowN);
                    if (daProduct.Connection.State == ConnectionState.Closed)
                    {
                        daProduct.Connection.Open();

                    }

                    using (MySql.Data.MySqlClient.MySqlTransaction transaction = daProduct.Connection.BeginTransaction())
                    {
                        daProduct.Transaction = transaction;
                        daProduct.Update(prRowN);

                        daProduct.Fill(DBclass.DS.product);
                        int? lId = daProduct.LastID();
                        DataSetTposTableAdapters.balanceTableAdapter bAdapetr = new DataSetTposTableAdapters.balanceTableAdapter();
                        DataSetTpos.balanceRow bRow = DBclass.DS.balance.NewbalanceRow();
                        bRow.balanceDate = Convert.ToDateTime("2000-01-01");
                        bRow.prodId = Convert.ToInt32(lId);
                        bRow.endCount = 0;
                        bRow.curEndCount = 0;
                        DBclass.DS.balance.AddbalanceRow(bRow);
                        bAdapetr.Connection = daProduct.Connection;
                        bAdapetr.Transaction = transaction;
                        bAdapetr.Update(bRow);
                        transaction.Commit();
                        if (lId != null && tbxShtrix.Text == "")
                        {

                            int id = lId.Value;
                            DataSetTpos.productRow pr = DBclass.DS.product.FindByproductId(id);
                            string barcode = randNumbers(id);
                            pr.barcode = barcode;
                            pr.status = 1;
                            daProduct.Update(pr);
                        }
                    }
                    ///Change changeprice
                    
                    

                    
                
                }
                else
                {
                    int rbtn = 2;
                    prRow.name = tbxName.Text;
                    prRow.barcode = tbxShtrix.Text;
                    if (measureRadio.Checked)
                    {
                        rbtn = 2; //ШТ
                    }
                    else if (measureRadio2.Checked)
                    {
                        rbtn = 1;//КГ
                    }
                    else if (measureRadio3.Checked)
                    {
                        rbtn = 3;//литр
                    }
                    else if (measureRadio4.Checked)
                    {
                        rbtn = 4; //кв.м
                    }
                    if (prCmbx.Text == "")
                    {
                        prRow.providerId = 1;
                    }
                    else
                    {
                        prRow.providerId = prCmbx.FindStringExact(prCmbx.Text);
                    }
                    
                    prRow.measureId = rbtn;
                    prRow.pack = 0;// tbxPack.Text != "0" && tbxPack.Text != "" ? Convert.ToInt32(tbxPack.Text) : 0; ;
                    
                    prRow.price = Convert.ToInt32(tbxPrice.Text);
                    

                    

                    DataSetTposTableAdapters.realizeviewTableAdapter realzvwDa = new DataSetTposTableAdapters.realizeviewTableAdapter();
                    DataSetTpos.realizeviewDataTable realviewtable = new DataSetTpos.realizeviewDataTable();
                    realzvwDa.FillByID(realviewtable, prRow.productId);
                    if(realviewtable.Rows.Count>0)
                    {
                        DataSetTposTableAdapters.changepriceTableAdapter chDa = new DataSetTposTableAdapters.changepriceTableAdapter();
                        DataSetTpos.changepriceRow changepriceRow = DBclass.DS.changeprice.NewchangepriceRow();
                        
                        changepriceRow.IDFaktura = (realviewtable.Rows[0] as DataSetTpos.realizeviewRow).fakturaId;
                        changepriceRow.IDProduct = prRow.productId;
                        changepriceRow.DateChange = DateTime.Now.Date;
                        changepriceRow.Price = prRow.price;
                        DBclass.DS.changeprice.AddchangepriceRow(changepriceRow);
                        chDa.Update(changepriceRow);
                    }
                    daProduct.Update(DBclass.DS.product);
                    daProduct.Fill(DBclass.DS.product);
                
                }
                
                

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void AddForm_MouseDown(object sender, MouseEventArgs e)
        //{
        //    _dragging = true;
        //    _start_point = new Point(e.X, e.Y);
        //}

        //private void AddForm_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (_dragging)
        //    {
        //        Point p = PointToScreen(e.Location);
        //        Location = new Point(p.X-this._start_point.X,p.Y-this._start_point.Y);
            
        //    }
        //}

        //private void AddForm_MouseUp(object sender, MouseEventArgs e)
        //{
        //    _dragging = false;
        //}

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
            int productBarcode = 1;
            int cnt = id.ToString().Length;
            Random rand = new Random();
            string temp1 = "";

            if (cnt == 1)
            {
                temp1 = rand.Next(10000, 19999).ToString() + rand.Next(10000, 99999).ToString();
            }
            else if (cnt == 2)
            {
                temp1 = rand.Next(10000, 19999).ToString() + rand.Next(1000, 9999).ToString();
            }
            else if (cnt == 3)
            {
                temp1 = rand.Next(10000, 19999).ToString() + rand.Next(100, 999).ToString();
            }
            else if (cnt == 4)
            {
                temp1 = rand.Next(10000, 19999).ToString() + rand.Next(10, 99).ToString();
            }
            else if (cnt == 5)
            {
                temp1 = rand.Next(10000, 19999).ToString() + rand.Next(1, 9).ToString(); 
            }

            //ischange = true;
            temp1 = id.ToString() + temp1+productBarcode;
            long n;
            n = Convert.ToInt64(temp1);
            long oddSum = 0, evenSum = 0;
            bool odd = true;
            while (n != 0)
            {
                if (odd)
                    oddSum += n % 10;
                else
                    evenSum += n % 10;
                n /= 10;
                odd = !odd;

            }
            long temp2 = oddSum * 3 + evenSum;
            if (temp2 != 0)
            {
                long temp3 = temp2 % 10;
                temp1 = temp1 + ((temp3 == 0) ? temp3 : (10 - temp3)).ToString();
            }
            else
            {
                temp1 = temp1 + temp2.ToString();
            }
            return temp1;
        }

        public void forPrinting(string id,string name, string price, string barcode)
        {
            string dataHtml = "";
            StreamWriter sw = new StreamWriter(System.IO.Path.GetTempPath() + "\\tempData.htm");
            //summa += decimal.Parse((Math.Round(Double.Parse(sr[1]) * Double.Parse(sr[2]))).ToString());
            string font = "12pt";
            if (name.Length <= 24)
                name += "<br/><br/><br/>";
            else if (name.Length <= 48)
                name += "<br/><br/>";
            else if (name.Length <= 72)
                name += "<br/>";
            else font = "10pt";
            //dataHtml = "<head></head><body>" +
            //        "<table style='font-size: 9px; font-family: Tahoma; width: 100%;'>" +
            //                "<tr >" +
            //                "<th><h5 style='height:28px;overflow:hidden;'>" + (name.Length > 30 ? name.Substring(0, 30) + "<br/>" + name.Substring(30) : name) + "</h4></th>" +
            //                "</tr>" +
            //                "<tr>" +
            //                    "<th><b><span style='font-size:26pt;'>" + price + "</span></b> <br/> <span style='font-size:12pt;'>" + barcode + "</span></th>" +
            //                "</tr>" +
            //        "</table>" +
            //    "</body>";

            //dataHtml = "<table style=\"font-family: 'Tahoma'; width: 220px; height: 80px;\">"+
            //            "<tbody>"+
            //            "<tr>"+
            //            "<td style=\"width: 50px; border:1px solid black; \"><strong>"+id+"</strong></td>"+
            //            "<td style=\"text-align:center;\"><span style=\"height: 28px; overflow: hidden; font-family: 'Arial';\">"+name+"</span></td>"+
            //            "</tr>"+
            //            "<tr>"+
            //            "<td colspan=\"2\"><span style=\"font-size: 8pt;\"><b>" + tposDesktop.Properties.Settings.Default.orgName + "</b> <br/>#" + barcode + "</span><strong> <div style=\"font-size: 26pt; font-family: 'Agency FB';float:right;margin-left:5px;\">" + String.Format("{0:n0}",int.Parse(price)) + " c.</div></strong></td>" +
            //            "</tr>"+
            //            "</tbody>"+
            //            "</table>";

            dataHtml = "<table align=\"center\" style=\"font-family: 'Tahoma'; width: 220px; height: 80px;padding:2px;\">"+
                        "<tbody>"+
                        "<tr>"+
                        "<td colspan=\"2\" style=\"text-align:center;border:1px solid black;\"><span style=\"height: 28px; overflow: hidden; font-family: 'Arial';font-size: "+font+";\">"+name+"</span></td>"+
                        "</tr>"+
                        "<tr>"+
                        "<td  style=\"width:60px;\">"+
                        "<strong>"+id+"</strong><br/>"+
                        "<span style=\"font-size:6pt;\"><b>"+ tposDesktop.Properties.Settings.Default.orgName +"</b> <br/>#"+barcode+"</span>" +
                        "</td>"+
                        "<td ><strong> <div style=\"font-size: 30pt; font-family: 'Agency FB';float:right;margin-left:5px;\">" + String.Format("{0:n0}",int.Parse(price)) + "c</div></strong></td>"+
                        "</tr>"+
                        "</tbody>"+
                        "</table>";
            sw.Write(dataHtml);
            sw.Close();
            //printing();
            string keyName = @"Software\Microsoft\Internet Explorer\PageSetup";
            using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(keyName, true))
            {
                if (key != null)
                {
                    string old_footer = (string)key.GetValue("footer");
                    string old_header = (string)key.GetValue("header");
                    key.SetValue("footer", "");
                    key.SetValue("header", "");

                    WebBrowser browser = new WebBrowser();
                    browser.DocumentText = dataHtml;
                    browser.DocumentCompleted += browser_DocumentCompleted;
                    browser.Print();
                    if (old_footer != null)
                        key.SetValue("footer", old_footer);
                    if (old_header != null)
                        key.SetValue("header", old_header);
                }
            }

            //PrintClass cl = new PrintClass();
            //cl.Printing();
        }

        void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser browser = sender as WebBrowser;
            browser.Print();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (tbxName.Text == "" & tbxPrice.Text == "0")
            {
                MessageBox.Show("не указано название товара или цена");
            }
            else
            {
                if (this.isAdd)
                { forPrinting(prRow.productId.ToString(), tbxName.Text, tbxPrice.Text, tbxShtrix.Text); }
                else
                { forPrinting(prRow.productId.ToString(), tbxName.Text, tbxPrice.Text, prRow.barcode); }

            }
        }

        private void btnBarcode_Click(object sender, EventArgs e)
        {
            printForm pr = new printForm(tbxName.Text,tbxPrice.Text,tbxShtrix.Text);
            pr.ShowDialog();
        }

        private Bitmap encodingZxing(string barcode)
        {
            Bitmap img = null;
            try
            {
                var writer = new BarcodeWriter
                {
                    Format = ZXing.BarcodeFormat.EAN_13,
                    Options = EncodingOptions ?? new EncodingOptions
                            {
                                Height = 100,
                                Width = 800
                            },
                    Renderer = (IBarcodeRenderer<Bitmap>)Activator.CreateInstance(Renderer)
                };
                img = writer.Write(barcode);
            }
            catch (Exception exc)
            {
                MessageBox.Show(this, exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return img;
            
        }

        private void saveBmp(string barcode)
        {
            Bitmap img = encodingZxing(barcode);
                var fileName = String.Empty;
                fileName = Directory.GetCurrentDirectory() + "\\files.png";
                var extension = Path.GetExtension(fileName).ToLower();
                var bmp = (Bitmap)img;

                bmp.Save(fileName, ImageFormat.Png);
            

        }
    }
}
