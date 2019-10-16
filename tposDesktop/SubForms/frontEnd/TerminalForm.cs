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
using keypad;
namespace tposDesktop.SubForms
{
    public partial class TerminalForm : DesignedForm
    {
        public TerminalForm(string summa)
        {
            keypad = new Keypad();
            keypad.Resulted +=keypad_Resulted;
            InitializeComponent();
            panel1.Controls.Add(keypad);
            keypad.Font = panel1.Font;
            keypad.Size = new Size(panel1.Size.Width-1, panel1.Height - 1);
            keypad.tbxMain.Text = summa;
            currentSumma = summa;
        }
        string currentSumma = "0";

        void keypad_Resulted()
        {
            if (double.Parse(keypad.result) > double.Parse(currentSumma))
            {
                MessageBox.Show("Сумма больше чем сумма продажи!"); 
            }
            else
            {
                sum = keypad.result;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }


        public string sum;
        public Keypad keypad;
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
