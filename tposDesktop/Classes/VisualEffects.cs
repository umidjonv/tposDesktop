using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Classes.Forms
{
    public class DesignedForm : Form
    {


        protected bool _dragging = false;
        protected Point _offset;
        public PictureBox pbCaption;
        public Button btnCancel;
        public Label lblCaption;
        protected Point _start_point = new Point(0, 0);


        public bool ShowCloseButton
        {
            set { btnCancel.Visible = value; }
            get { return btnCancel.Visible; }
        }

        public bool ShowCaption
        {
            set { lblCaption.Visible = value; }
            get { return lblCaption.Visible; }
        }


        public DesignedForm()
        {
            
            InitializeComponent();
            lblCaption.MouseDown += Form_MouseDown;
            lblCaption.MouseMove += Form_MouseMove;
            lblCaption.MouseUp += Form_MouseUp;
            pbCaption.MouseDown += Form_MouseDown;
            pbCaption.MouseMove += Form_MouseMove;
            pbCaption.MouseUp += Form_MouseUp;
            
        }
        
        protected void Form_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _start_point = new Point(e.X, e.Y);
        }

        protected void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);

            }
        }

        protected void Form_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        protected void InitializeComponent()
        {
            this.pbCaption = new System.Windows.Forms.PictureBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblCaption = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaption)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCaption
            // 
            this.pbCaption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this.pbCaption.Location = new System.Drawing.Point(-3, 0);
            this.pbCaption.Name = "pbCaption";
            this.pbCaption.Size = new System.Drawing.Size(548, 66);
            this.pbCaption.TabIndex = 8;
            this.pbCaption.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Arial Black", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Transparent;
            this.btnCancel.Location = new System.Drawing.Point(476, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(69, 66);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "X";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblCaption
            // 
            this.lblCaption.AutoSize = true;
            this.lblCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this.lblCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCaption.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblCaption.Location = new System.Drawing.Point(12, 16);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(76, 33);
            this.lblCaption.TabIndex = 10;
            this.lblCaption.Text = "Text";
            // 
            // DesignedForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(219)))), ((int)(((byte)(179)))));
            this.ClientSize = new System.Drawing.Size(544, 337);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.pbCaption);
            
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DesignedForm";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DesignedForm_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pbCaption)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected void DesignedForm_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rec = new Rectangle(1, 2, this.Width - 3, this.Height - 4);
            
            Pen p = new Pen(Brushes.Tomato);
            p.Width = 5;

            e.Graphics.DrawRectangle(p, rec);
            //e.Graphics
        }

    }
}
