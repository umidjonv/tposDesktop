using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Classes
{
    class TablePanelDishes :FlowLayoutPanel
    {
        public TablePanelDishes()
        {
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "tablePanelDishes";
            this.Size = new System.Drawing.Size(747, 442);
            this.TabIndex = 4;
            this.Visible = false;
        }
        public void initControls()
        {

        }

    }
}
