using Classes.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EzioDll;

namespace tposDesktop
{

    public partial class printForm : DesignedForm
    {
        Properties.printer settings;
        GodexPrinter Printer = new GodexPrinter();
        private string names;
        private string prices;
        private string barcodes;
        public printForm(string name, string price, string barcode)
        {
            InitializeComponent();
            this.names = name;
            this.prices = price;
            this.barcodes = barcode;
            tbxCnt.Focus();
            settings = Properties.printer.Default;

        }

        private void ConnectPrinter()
        {
            if (settings.PrinterInterface == "USB")
            {
                Printer.Open(PortType.USB);
            }
            else if (settings.PrinterInterface == "Ethernet")
            {
                Printer.Open(settings.ip, settings.port);
            }
        }
        private void DisconnectPrinter()
        {
            Printer.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            int PosX = 5;
            int PosY = 5;
            int FontHeight = 18;


            ConnectPrinter();
            LabelSetup();

            Printer.Command.Start();
            Printer.Command.PrintText(PosX, PosY += 10, FontHeight, "Arial", names);
            Printer.Command.PrintText(PosX += 100, PosY += 20, FontHeight += 10, "Arial", prices+" сум"); 
            Printer.Command.PrintBarCode(BarCodeType.EAN13, 10, 65, barcodes);     // Code39   // Code128 Subset A
            Printer.Command.End();

            DisconnectPrinter();
        }

        private void LabelSetup()
        {
            Printer.Config.LabelMode((PaperMode)0, settings.height, settings.gap);
            Printer.Config.LabelWidth(settings.witdh);
            Printer.Config.Dark(10);
            Printer.Config.Speed(3);
            Printer.Config.PageNo(1);
            Printer.Config.CopyNo(Convert.ToInt32(tbxCnt.Text));
        }
    }
}
