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
            this.dgvDolgi = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDolgi)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDolgi
            // 
            this.dgvDolgi.AllowUserToAddRows = false;
            this.dgvDolgi.AllowUserToResizeRows = false;
            this.dgvDolgi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvDolgi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDolgi.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvDolgi.Location = new System.Drawing.Point(-6, 2);
            this.dgvDolgi.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dgvDolgi.MultiSelect = false;
            this.dgvDolgi.Name = "dgvDolgi";
            this.dgvDolgi.RowHeadersVisible = false;
            this.dgvDolgi.RowHeadersWidth = 50;
            this.dgvDolgi.RowTemplate.Height = 40;
            this.dgvDolgi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDolgi.Size = new System.Drawing.Size(617, 436);
            this.dgvDolgi.TabIndex = 1;
            this.dgvDolgi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDolgi_CellClick);
            this.dgvDolgi.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvDolgi_CellPainting);
            this.dgvDolgi.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDolgi_RowEnter);
            // 
            // FormDolgi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 439);
            this.Controls.Add(this.dgvDolgi);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDolgi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Долги";
            this.Load += new System.EventHandler(this.FormDolgi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDolgi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDolgi;
    }
}