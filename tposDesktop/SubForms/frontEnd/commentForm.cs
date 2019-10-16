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
        public commentForm(bool isSpisaniye)
        {
            InitializeComponent();
            this.lblCaption.Text = "Комментарий к списанию";
            this.btnDolg.Visible = false;
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;


        }
        public string comment;
        private void btnOk_Click(object sender, EventArgs e)
        {
            
            if ((comment != null && comment != "") || contRow != null )
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }
        public DataSetTpos.contragentRow contRow;
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if ((comment != null && comment != "") || (contRow != null))
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

        private void button1_Click(object sender, EventArgs e)
        {
            Contragent cont = new Contragent();
            if (cont.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                contRow = cont.activeContragentRow;
                lblname.Text = contRow.name.ToString();
            }
        }
    }
}
