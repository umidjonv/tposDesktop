namespace tposDesktop
{
    partial class FakturaOrgsForm
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvFakturaOrg = new System.Windows.Forms.DataGridView();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFakturaOrg)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCaption
            // 
            this.pbCaption.Location = new System.Drawing.Point(-4, 0);
            this.pbCaption.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbCaption.Size = new System.Drawing.Size(549, 73);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnCancel.Location = new System.Drawing.Point(463, 0);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Size = new System.Drawing.Size(82, 73);
            // 
            // lblCaption
            // 
            this.lblCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCaption.Location = new System.Drawing.Point(13, 19);
            this.lblCaption.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCaption.Size = new System.Drawing.Size(231, 26);
            this.lblCaption.Text = "Выбор поставщика:";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.BackColor = System.Drawing.Color.Yellow;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAdd.Location = new System.Drawing.Point(12, 381);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(147, 56);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "+ Добавить";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgvFakturaOrg
            // 
            this.dgvFakturaOrg.AllowUserToAddRows = false;
            this.dgvFakturaOrg.AllowUserToDeleteRows = false;
            this.dgvFakturaOrg.AllowUserToResizeRows = false;
            this.dgvFakturaOrg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvFakturaOrg.BackgroundColor = System.Drawing.Color.PaleTurquoise;
            this.dgvFakturaOrg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkTurquoise;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFakturaOrg.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFakturaOrg.ColumnHeadersHeight = 40;
            this.dgvFakturaOrg.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvFakturaOrg.Location = new System.Drawing.Point(12, 93);
            this.dgvFakturaOrg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvFakturaOrg.MultiSelect = false;
            this.dgvFakturaOrg.Name = "dgvFakturaOrg";
            this.dgvFakturaOrg.RowHeadersVisible = false;
            this.dgvFakturaOrg.RowHeadersWidth = 50;
            this.dgvFakturaOrg.RowTemplate.Height = 40;
            this.dgvFakturaOrg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFakturaOrg.Size = new System.Drawing.Size(519, 283);
            this.dgvFakturaOrg.TabIndex = 16;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.BackColor = System.Drawing.Color.Yellow;
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOK.Location = new System.Drawing.Point(377, 381);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(154, 56);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "Выбрать";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FakturaOrgsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 449);
            this.Controls.Add(this.dgvFakturaOrg);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnAdd);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FakturaOrgsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FakturaOrgsForm";
            this.Load += new System.EventHandler(this.FakturaOrgsForm_Load);
            this.Controls.SetChildIndex(this.pbCaption, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.lblCaption, 0);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.dgvFakturaOrg, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pbCaption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFakturaOrg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvFakturaOrg;
        private System.Windows.Forms.Button btnOK;
    }
}