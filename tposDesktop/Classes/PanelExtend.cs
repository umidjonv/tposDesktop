using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Classes
{
    class PanelExtend : Panel
    {
        

        public PanelExtend()
        {
            InitializeComponents();
            this.Refresh();
            lbl.Location = new System.Drawing.Point(this.Width - 110, this.Height / 3 * 2);
        }
        public PanelExtend(int id, string btnText, float labelText, int type)
        {
            var dph = new DishProdHstuf();
            dph.ID = id;
            dph.Name = btnText;
            dph.price = labelText;
            dph.type = type;

            this.Tag = dph;
            InitializeComponents(); 
            btn.Text = btnText;
            lbl.Text = labelText.ToString();
            this.Refresh();
            lbl.Location = new System.Drawing.Point(this.Width-110, this.Height / 3 * 2);

        }
        private void InitializeComponents()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = System.Drawing.Color.FromArgb(178, 132, 16);  
            btn = new Button();
            
            lbl = new Label();
            lbl.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btn.Dock = DockStyle.Top;
            btn.Width = 100;
            btn.Height = 130;
            btn.BackColor = System.Drawing.Color.FromArgb(35, 255, 177);
            lbl.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            lbl.ForeColor = System.Drawing.Color.White;
            //lbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;

            this.Controls.Add(btn);
            this.Controls.Add(lbl); 
        }
        Button btn;
        Label lbl;
        public Button PanelButton { get { return btn; } }
        public Label PanelLabel { get { return lbl; } }
    }
}
