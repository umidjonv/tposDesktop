﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Classes.Forms;
namespace tposDesktop
{
    public partial class FormFaktura : DesignedForm
    {
        public FormFaktura(DataSetTpos.providerRow providerRow)
        {
            prRow = providerRow;
            InitializeComponent();
        }
        DataSetTpos.providerRow prRow;
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (tbxOrgName.Text != "" && maskedTextBox1.Text != "")
            {
                prRow.orgName = tbxOrgName.Text;
                prRow.phone = maskedTextBox1.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }


       
    }
}
