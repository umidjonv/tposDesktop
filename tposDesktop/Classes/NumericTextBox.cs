using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Classes
{
    class NumericTextBox : TextBox
    {
        public NumericTextBox()
        {
            this.KeyPress += NumericTextBox_KeyPress;
        }
        public bool isFloat = false;

        void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (isFloat)
            {
                if ((e.KeyChar == '.' || e.KeyChar == ',') && !this.Text.Contains('.'))
                {

                    if (e.KeyChar == ',')
                        e.KeyChar = '.';

                }
                else
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    {
                        e.Handled = true;
                    }
            }
            else
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

        }

    }
}
