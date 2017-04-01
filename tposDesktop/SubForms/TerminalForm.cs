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

namespace tposDesktop.SubForms
{
    public partial class TerminalForm : DesignedForm
    {
        public TerminalForm()
        {
            InitializeComponent();
            
        }
        public string sum;
        private void btnOK_Click(object sender, EventArgs e)
        {
            sum = tbxSumma.Text;
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

        private void TerminalForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            gr.DrawRectangle(new Pen(Color.Yellow), 0, 0, this.Width-2, this.Height-2);

        }

        private void TerminalForm_Load(object sender, EventArgs e)
        {

            tbxSumma.Focus();
            tbxSumma.Select();
        }

        
    }
}
