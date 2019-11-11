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
using Classes.Model;
namespace tposDesktop.Debts
{
    public partial class DebtTypeForm : DesignedForm
    {
        public DebtTypeForm()
        {
            
            InitializeComponent();
            mainHandler = new MainHandlerADO();
            cbxKredit.DisplayMember = "typename";
            cbxKredit.ValueMember = "debttypeId";
            cbxKredit.DataSource = mainHandler.RefreshDebttypes();
            

        }
        MainHandlerADO mainHandler;
        int curDebttypeID = 0;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbxKredit.SelectedValue!=null)
            {
                curDebttypeID = (int)(cbxKredit.SelectedValue);
                DataSetDebt.debttypesRow dtRow = mainHandler.GetDebttype(curDebttypeID);
                tbxTypename.Text = dtRow.typename;
                tbxPercent.Text = dtRow.percent.ToString();
                tbxPeriod.Text = dtRow.period.ToString();
            }
            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            mainHandler.EditDebttype(Convert.ToInt32(cbxKredit.SelectedValue), tbxTypename.Text, Convert.ToInt32(tbxPercent.Text), Convert.ToInt32(tbxPeriod.Text));
            cbxKredit.DataSource = mainHandler.RefreshDebttypes();
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            mainHandler.AddDebttype(tbxTypename.Text, Convert.ToInt32(tbxPercent.Text), Convert.ToInt32(tbxPeriod.Text));
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            mainHandler.DeleteDebttype(Convert.ToInt32(cbxKredit.SelectedValue));
            cbxKredit.DataSource = mainHandler.RefreshDebttypes();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbxPercent.Text = "0";
            tbxPeriod.Text = "0";
            tbxTypename.Text = "";
        }
    }
}
