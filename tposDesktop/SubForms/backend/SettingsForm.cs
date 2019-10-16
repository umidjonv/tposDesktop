﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Classes.Forms;
using Classes;
namespace tposDesktop
{
    public partial class SettingsForm : DesignedForm
    {
        Properties.Settings settings;
        public SettingsForm(string config)
        {
            InitializeComponent();
            settings = Properties.Settings.Default;

            
            if (Configs.GetConfig("IsPercentAll") != "" && Configs.GetConfig("IsPercentAll") == "True")
                chbRebate.Checked = true;
            else chbRebate.Checked = false;

            if (Configs.GetConfig("PercentAll") != "")
                tbxPercent.Text = Configs.GetConfig("PercentAll");
            else tbxPercent.Text = "0";

            tbxOrgName.Text = settings.orgName;
            tbxCom.Text = settings.SerialPort;
            chbCOM.Checked = settings.IsCom;
            kassaTbx.Text = settings.kassa;
            //if (settings.IsCom)
            //{
                
            //    tbxCom.Enabled = false;
            //}
            
            tbxSN.Text = settings.SN;
            chbPrinter.Checked = settings.isPrinter;
            dtpExpDate.Value = settings.ExpDate;
            tbxDB.Text = settings.testConnectionString;
            if (config == "-config")
            {
                tbxSN.Enabled = true;
                dtpExpDate.Enabled = true;
                lblDB.Visible = true;
                tbxDB.Visible = true;
            }

        }

        private void chbCOM_CheckedChanged(object sender, EventArgs e)
        {
            tbxCom.Enabled = chbCOM.Checked;
            settings.IsCom = chbCOM.Checked;
        }

        private void chbPrinter_CheckedChanged(object sender, EventArgs e)
        {
            settings.isPrinter = chbPrinter.Checked;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            settings.orgName = tbxOrgName.Text;
            settings.isPrinter = chbPrinter.Checked;
            settings.IsCom = chbCOM.Checked;
            settings.SN = tbxSN.Text;
            settings.SerialPort = tbxCom.Text;
            settings.ExpDate = dtpExpDate.Value;
            settings.kassa = kassaTbx.Text;
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.StartupPath+"\\tposDesktop.exe");
            config.ConnectionStrings.ConnectionStrings["tposDesktop.Properties.Settings.testConnectionString"].ConnectionString = tbxDB.Text;
            //config.ConnectionStrings.ConnectionStrings["tposDesktop.Properties.Settings.testConnectionString"].ProviderName = "MySql.Data.MySqlClient";
            config.Save(ConfigurationSaveMode.Modified, true);
            //ConfigurationManager.RefreshSection("connectionStrings");

            Configs.SetConfig("IsPercentAll", this.chbRebate.Checked.ToString());
            Configs.SetConfig("PercentAll", tbxPercent.Text);
            //if(this.chbRebate.Checked) settings.chbRebateChecked = this.chbRebate.Checked;

            //settings.PercentPensioner = int.Parse(tbxPercent.Text);

            settings.Save();
            this.Close();
        }

        private void txbPercent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.Match(e.KeyChar.ToString(), @"[0-9]").Success)
            {
                e.Handled = true;
            }
        }

        private void chbRebate_CheckedChanged(object sender, EventArgs e)
        {
            //MainForm mf = new MainForm();
            if (chbRebate.Checked)
            {
                tbxPercent.Enabled = true;
                settings.chbRebateChecked = true;
            }
            else
            {
                tbxPercent.Enabled = false;
                settings.chbRebateChecked = false;
            }
        }
    }
}
