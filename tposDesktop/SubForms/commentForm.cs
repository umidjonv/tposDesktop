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
namespace tposDesktop
{
    public partial class commentForm : DesignedForm
    {
        public commentForm()
        {
            InitializeComponent();
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            
            
        }
        public string comment;
        private void btnOk_Click(object sender, EventArgs e)
        {
            
            if (comment != null && comment != "")
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (comment != null && comment != "")
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
            if (e.KeyChar == 27)
            {
                this.Close();
            }
        }

        private void commentForm_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            comment = textBox1.Text;
        }
    }
}
