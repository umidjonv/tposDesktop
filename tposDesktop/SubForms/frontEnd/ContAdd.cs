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

namespace tposDesktop
{
    public partial class ContAdd : DesignedForm
    {
        public ContAdd(DataSetTpos.contragentRow contRow)
        {
            prRow = contRow;
            InitializeComponent();
        }
        DataSetTpos.contragentRow prRow;
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (tbxOrgName.Text != "" && maskedTextBox1.Text != "")
            {
                prRow.name = tbxOrgName.Text;
                prRow.phone = maskedTextBox1.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void tbxOrgName_Enter(object sender, EventArgs e)
        {

            System.Diagnostics.Process.Start("osk.exe");
        }

        private void maskedTextBox1_Enter(object sender, EventArgs e)
        {

            System.Diagnostics.Process.Start("osk.exe");
        }
    }
}
