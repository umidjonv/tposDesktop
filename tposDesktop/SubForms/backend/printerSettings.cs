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
    public partial class printerSettings : DesignedForm
    {

        GodexPrinter Printer = new GodexPrinter();
        Properties.printer settings;
        public printerSettings()
        {
            InitializeComponent();
            settings = Properties.printer.Default;
            ipTbx.Text = settings.ip;
            TbxNetPort.Text = settings.port.ToString();
            Num_Label_W.Value = settings.witdh;
            Num_Label_H.Value = settings.height;
            Num_GapFeed.Value = settings.gap;
            if (settings.PrinterInterface == "USB")
            {
                usbRadio.Checked = true;
            }
            if (settings.PrinterInterface == "Ethernet")
            {
                ethernetRadio.Checked = true;
            }
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            settings.ip = ipTbx.Text;
            settings.port = Convert.ToInt32(TbxNetPort.Text);
            settings.witdh = Convert.ToInt32(Num_Label_W.Value);
            settings.height = Convert.ToInt32(Num_Label_H.Value);
            settings.gap = Convert.ToInt32(Num_GapFeed.Value);
            if (usbRadio.Checked)
            {
                settings.PrinterInterface = "USB";
            }
            if (ethernetRadio.Checked)
            {
                settings.PrinterInterface = "Ethernet";
            }
            settings.Save();
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            int PosX = 5;
            int PosY = 5;
            int FontHeight = 18;


            ConnectPrinter();
            LabelSetup();

            Printer.Command.Start();
            Printer.Command.PrintText(PosX, PosY += 10, FontHeight, "Arial", "Тестовая печать");
            Printer.Command.PrintBarCode(BarCodeType.EAN13, 10, 65, "123456789012");     // Code39   // Code128 Subset A
            Printer.Command.End();

            DisconnectPrinter();
        }

        private void ConnectPrinter()
        {
            if (usbRadio.Checked)
            {
                Printer.Open(PortType.USB);
            }
            else if (ethernetRadio.Checked)
            {
                Printer.Open(ipTbx.Text, Convert.ToInt32(TbxNetPort.Text));
            }
        }
        private void DisconnectPrinter()
        {
            Printer.Close();
        }


        private void LabelSetup()
        {
            Printer.Config.LabelMode((PaperMode)0, (int)Num_Label_H.Value, (int)Num_GapFeed.Value);
            Printer.Config.LabelWidth((int)Num_Label_W.Value);
            Printer.Config.Dark(10);
            Printer.Config.Speed(3);
            Printer.Config.PageNo(1);
            Printer.Config.CopyNo(1);
        }
    }
}
