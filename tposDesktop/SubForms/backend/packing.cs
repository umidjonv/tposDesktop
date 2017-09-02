using Classes.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using ZXing.Rendering;

namespace tposDesktop
{
    public partial class packing : DesignedForm
    {
        int measure;
        int id;
        private EncodingOptions EncodingOptions { get; set; }
        private Type Renderer { get; set; }
        public packing(DataSetTpos.productRow productRow)
        {
            InitializeComponent();
            measure = productRow.measureId;
            tbxName.Text = productRow.name;
            tbxShtrix.Text = productRow.barcode;
            lblPrice.Text = productRow.price.ToString();
            id = productRow.productId;
            Renderer = typeof(BitmapRenderer);
            tbxPack.Focus();
        }

        private void tbxCount1_TextChanged(object sender, EventArgs e)
        {
            
            //if (d.IndexOf(".")!=-1)
            //lblOne.Text = d.Remove(d.IndexOf("."));
            //else
            //lblOne.Text = d;



        }

        private void button1_Click(object sender, EventArgs e)
        {
            forPrinting();
        }


        string randNumbers()
        {
            int cnt = id.ToString().Length;

            string temp1 = "";
            if (measure == 1)
            {
                temp1 += "20";
            }
            if (measure == 2)
            {
                temp1 += "21";
            }
            switch (cnt)
            {
                case 1:
                    temp1 += "0000" + id;
                    break;
                case 2:
                    temp1 += "000" + id;
                    break;
                case 3:
                    temp1 += "00" + id;
                    break;
                case 4:
                    temp1 += "0" + id;
                    break;
                case 5:
                    temp1 += id;
                    break;
            }
            string pckg = "";
            if (tbxPack.Text.Contains('.'))
            {
                string[] sub = tbxPack.Text.Split('.');
                pckg = sub[0] + sub[1];
            }
            else
            {
                pckg = tbxPack.Text;
            }
            int packgCnt = pckg.Length;

            switch (packgCnt)
            {
                case 1:
                    temp1 += "0000" + pckg;
                    break;
                case 2:
                    temp1 += "000" + pckg;
                    break;
                case 3:
                    temp1 += "00" + pckg;
                    break;
                case 4:
                    temp1 += "0" + pckg;
                    break;
                case 5:
                    temp1 += pckg;
                    break;
            }
            //ischange = true;
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

        public void forPrinting()
        {
            string name = tbxName.Text;
            string barcode = randNumbers();
            string price = lblPrice.Text;
            saveBmp(barcode);
            string dataHtml = "";
            StreamWriter sw = new StreamWriter(System.IO.Path.GetTempPath() + "\\tempData.htm");
            //summa += decimal.Parse((Math.Round(Double.Parse(sr[1]) * Double.Parse(sr[2]))).ToString());


            dataHtml = "<head></head><body>" +
                    "<table style='font-size: 12px; font-family: Tahoma; width: 100%;'>" +
                            "<tr >" +
                                "<th colspan = '3' style=''><span style='font-size: 14px; text-align: center;'>" + Properties.Settings.Default.orgName + "</span></th>" +
                            "</tr>" +
                            "<tr >" +
                                "<th colspan = '3' style=''><span >" + /*(name.Length > 30 ? name.Substring(0, 30) : name)*/ name + "</span></th>" +
                            "</tr>" +
                            "<tr>" +
                                "<th colspan = '3'><img width ='150' height='30' src='" + Directory.GetCurrentDirectory() + "\\barcode.png '/></th>" +
                            "</tr>" +
                            "<tr>" +
                                "<th colspan = '3' >" + barcode + "</th>" +
                            "</tr>" +
                            "<tr>" +
                                "<th style=''><div>Цена сум/" + (measure == 1 ? "кг" : "шт") + "</div><div>" + price + "</div></th>" +
                                "<th style=''><div>Масса </div><div>" + tbxPack.Text + (measure == 1 ? "кг" : "шт") + " </div></th>" +
                                "<th><div style='padding: 5px; border: 1px solid #000'>" + Math.Round(Convert.ToUInt32(price) * Convert.ToSingle(tbxPack.Text)) + "</div><div>Сумма</div></th>" +
                            "</tr>" +
                    "</table>" +
                "</body>";
            //dataHtml = GenerateHTML(dataHtml, expTable, Convert.ToInt32(summa));
            //string zakaz = "<h4>Номер заказа: " + nomerZakaza + "</h4>";
            //string oficiant = "<h4>Официант: " + lblUser.Text + "</h4>";
            //dataHtml = zakaz+oficiant+"<h4>Официант: " + DateTime.Now.ToString("dd.MM.YYYY HH:mm")+ "</h4>" + dataHtml;
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
            fileName = Directory.GetCurrentDirectory() + "\\barcode.png";
            var extension = Path.GetExtension(fileName).ToLower();
            var bmp = (Bitmap)img;

            bmp.Save(fileName, ImageFormat.Png);


        }
    }
}
