using System;
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
namespace tposDesktop
{
    public partial class SettingsForm : DesignedForm
    {
        Properties.Settings settings;
        public SettingsForm(string config)
        {
            InitializeComponent();
            settings = Properties.Settings.Default;
            tbxOrgName.Text = settings.orgName;
            tbxOrgPlace.Text = settings.orgPlace;
            tbxOrgPhone.Text = settings.orgTel;
            tbxCom.Text = settings.SerialPort;
            chbCOM.Checked = settings.IsCom;
            kassaTbx.Text = settings.kassa;
            tbxPrimechaniye.Text = settings.site;
            //if (settings.IsCom)
            //{
                
            //    tbxCom.Enabled = false;
            //}
            if (settings.workMode == "0")
            {
                rbtMode.Checked = true;
            }
            else if (settings.workMode == "1")
            {
                rbtMode2.Checked = true;
            }
            tbxSN.Text = settings.SN;
            chbPrinter.Checked = settings.isPrinter;
            dtpExpDate.Value = settings.ExpDate;
            tbxDB.Text = settings.stockConnectionString;
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
            settings.orgPlace = tbxOrgPlace.Text;
            settings.orgTel = tbxOrgPhone.Text;
            settings.isPrinter = chbPrinter.Checked;
            settings.IsCom = chbCOM.Checked;
            settings.SN = tbxSN.Text;
            settings.SerialPort = tbxCom.Text;
            settings.ExpDate = dtpExpDate.Value;
            settings.kassa = kassaTbx.Text;
            settings.site = tbxPrimechaniye.Text;
            if (rbtMode.Checked)
            {
                settings.workMode = "0";
            }
            if (rbtMode2.Checked)
            {
                settings.workMode = "1";
            }
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.ConnectionStrings.ConnectionStrings["tposDesktop.Properties.Settings.stockConnectionString"].ConnectionString = tbxDB.Text;
            //config.ConnectionStrings.ConnectionStrings["tposDesktop.Properties.Settings.stockConnectionString"].ProviderName = "MySql.Data.MySqlClient";
            config.Save(ConfigurationSaveMode.Modified, true);
            //ConfigurationManager.RefreshSection("connectionStrings");
            
            settings.Save();
            this.Close();
        }

        private void rbtMode2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
