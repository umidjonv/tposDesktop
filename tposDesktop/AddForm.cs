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
    public partial class AddForm : Form
    {
        public AddForm(bool isadd)
        {
            isAdd = isadd;
            InitializeComponent();
            if(!isAdd)
            {
                this.Text = "Редактировать товар";
                btnAdd.Text = "Изменить";
            }
        }
        bool isAdd = true;
        private void AddOrEdit(object sender, EventArgs e)
        {
            
        }
    }
}
