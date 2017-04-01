namespace tposDesktop
{
    partial class FormDolgi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDolgi));
            this.dgvDolgi = new System.Windows.Forms.DataGridView();
            this.tbxFilter = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDolgi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCaption
            // 
            this.pbCaption.Size = new System.Drawing.Size(614, 66);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnCancel.Location = new System.Drawing.Point(542, 0);
            // 
            // lblCaption
            // 
            this.lblCaption.Size = new System.Drawing.Size(337, 42);
            this.lblCaption.Text = "Книга должников";
            // 
            // dgvDolgi
            // 
            this.dgvDolgi.AllowUserToAddRows = false;
            this.dgvDolgi.AllowUserToResizeRows = false;
            this.dgvDolgi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvDolgi.BackgroundColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LimeGreen;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDolgi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDolgi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDolgi.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvDolgi.Location = new System.Drawing.Point(26, 116);
            this.dgvDolgi.Margin = new System.Windows.Forms.Padding(5);
            this.dgvDolgi.MultiSelect = false;
            this.dgvDolgi.Name = "dgvDolgi";
            this.dgvDolgi.RowHeadersVisible = false;
            this.dgvDolgi.RowHeadersWidth = 50;
            this.dgvDolgi.RowTemplate.Height = 40;
            this.dgvDolgi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDolgi.Size = new System.Drawing.Size(551, 280);
            this.dgvDolgi.TabIndex = 1;
            this.dgvDolgi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDolgi_CellClick);
            this.dgvDolgi.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvDolgi_CellPainting);
            this.dgvDolgi.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDolgi_RowEnter);
            this.dgvDolgi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvDolgi_KeyPress);
            // 
            // tbxFilter
            // 
            this.tbxFilter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbxFilter.ForeColor = System.Drawing.Color.DarkGray;
            this.tbxFilter.Location = new System.Drawing.Point(68, 78);
            this.tbxFilter.Name = "tbxFilter";
            this.tbxFilter.Size = new System.Drawing.Size(513, 30);
            this.tbxFilter.TabIndex = 2;
            this.tbxFilter.Text = "Поиск";
            this.tbxFilter.TextChanged += new System.EventHandler(this.tbxFilter_TextChanged);
            this.tbxFilter.Enter += new System.EventHandler(this.tbxFilter_Enter);
            this.tbxFilter.Leave += new System.EventHandler(this.tbxFilter_Leave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(26, 71);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 37);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // FormDolgi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGreen;
            this.ClientSize = new System.Drawing.Size(610, 439);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tbxFilter);
            this.Controls.Add(this.dgvDolgi);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDolgi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Долги";
            this.Load += new System.EventHandler(this.FormDolgi_Load);
            this.Controls.SetChildIndex(this.dgvDolgi, 0);
            this.Controls.SetChildIndex(this.tbxFilter, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.pbCaption, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.lblCaption, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pbCaption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDolgi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDolgi;
        private System.Windows.Forms.TextBox tbxFilter;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}