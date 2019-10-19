namespace tposDesktop
{
    partial class ProdList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.searchBtn = new System.Windows.Forms.TextBox();
            this.dgvTovar = new System.Windows.Forms.DataGridView();
            this.productTableAdapter1 = new tposDesktop.DataSetTposTableAdapters.productTableAdapter();
            this.hotkeysTableAdapter1 = new tposDesktop.DataSetTposTableAdapters.hotkeysTableAdapter();
            this.clrBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTovar)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCaption
            // 
            this.pbCaption.Size = new System.Drawing.Size(727, 66);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnCancel.Location = new System.Drawing.Point(655, 0);
            // 
            // lblCaption
            // 
            this.lblCaption.Size = new System.Drawing.Size(243, 33);
            this.lblCaption.Text = "Список товаров";
            // 
            // searchBtn
            // 
            this.searchBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.searchBtn.Location = new System.Drawing.Point(13, 78);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(559, 28);
            this.searchBtn.TabIndex = 11;
            this.searchBtn.TextChanged += new System.EventHandler(this.tbx_ValueChanged);
            // 
            // dgvTovar
            // 
            this.dgvTovar.AllowUserToAddRows = false;
            this.dgvTovar.AllowUserToDeleteRows = false;
            this.dgvTovar.AllowUserToResizeColumns = false;
            this.dgvTovar.AllowUserToResizeRows = false;
            this.dgvTovar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTovar.BackgroundColor = System.Drawing.Color.White;
            this.dgvTovar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTovar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTovar.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTovar.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTovar.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvTovar.Location = new System.Drawing.Point(13, 118);
            this.dgvTovar.Margin = new System.Windows.Forms.Padding(2);
            this.dgvTovar.MultiSelect = false;
            this.dgvTovar.Name = "dgvTovar";
            this.dgvTovar.RowHeadersVisible = false;
            this.dgvTovar.RowHeadersWidth = 50;
            this.dgvTovar.RowTemplate.Height = 40;
            this.dgvTovar.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvTovar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTovar.Size = new System.Drawing.Size(699, 378);
            this.dgvTovar.TabIndex = 12;
            this.dgvTovar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.selectproduct_click);
            this.dgvTovar.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgv_CellPainting);
            // 
            // productTableAdapter1
            // 
            this.productTableAdapter1.ClearBeforeFill = true;
            // 
            // hotkeysTableAdapter1
            // 
            this.hotkeysTableAdapter1.ClearBeforeFill = true;
            // 
            // clrBtn
            // 
            this.clrBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.clrBtn.Location = new System.Drawing.Point(578, 72);
            this.clrBtn.Name = "clrBtn";
            this.clrBtn.Size = new System.Drawing.Size(133, 41);
            this.clrBtn.TabIndex = 13;
            this.clrBtn.Text = "Очистить";
            this.clrBtn.UseVisualStyleBackColor = true;
            this.clrBtn.Click += new System.EventHandler(this.clrBtn_Click);
            // 
            // ProdList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 507);
            this.Controls.Add(this.clrBtn);
            this.Controls.Add(this.dgvTovar);
            this.Controls.Add(this.searchBtn);
            this.Name = "ProdList";
            this.Text = "ProdList";
            this.Load += new System.EventHandler(this.Form_Load);
            this.Controls.SetChildIndex(this.pbCaption, 0);
            this.Controls.SetChildIndex(this.lblCaption, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.searchBtn, 0);
            this.Controls.SetChildIndex(this.dgvTovar, 0);
            this.Controls.SetChildIndex(this.clrBtn, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pbCaption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTovar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox searchBtn;
        private System.Windows.Forms.DataGridView dgvTovar;
        private DataSetTposTableAdapters.productTableAdapter productTableAdapter1;
        private DataSetTposTableAdapters.hotkeysTableAdapter hotkeysTableAdapter1;
        private System.Windows.Forms.Button clrBtn;
    }
}