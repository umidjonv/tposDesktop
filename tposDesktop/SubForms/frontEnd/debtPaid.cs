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
    public partial class debtPaid : DesignedForm
    {
        public int paidSumm;
        public bool terminal = false;
        public debtPaid(int summ)
        {
            InitializeComponent();
            tbxSum.Text = summ.ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            paidSumm = Convert.ToInt32(tbxSum.Text);
            if (ckbxTerm.Checked)
            {
                terminal = true;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void tbxSumma_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnOK_Click(null, null);
            }
        }
    }
}
