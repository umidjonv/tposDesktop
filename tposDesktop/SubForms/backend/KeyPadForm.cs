using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using keypad;
namespace tposDesktop
{
    public partial class KeyPadForm : Form
    {
        public KeyPadForm()
        {
            InitializeComponent();
            keypad= new Keypad();
            keypad.Width = 240;
            keypad.Height = 280;
            keypad.Resulted += keypad_Resulted;
            
            this.Controls.Add(keypad);
            this.Width = keypad.Width + 10;
            this.Height = keypad.Height + 10;
        }
        Keypad keypad;
        public string text;
        void keypad_Resulted()
        {
            text = keypad.result;
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
