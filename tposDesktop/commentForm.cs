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
    public partial class commentForm : Form
    {
        public commentForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            VirtualKeyboard.FormKeyBoard form = new VirtualKeyboard.FormKeyBoard();
            form.Show();
        }
    }
}
