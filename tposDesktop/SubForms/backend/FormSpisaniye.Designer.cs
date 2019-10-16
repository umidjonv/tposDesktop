namespace tposDesktop.SubForms
{
    partial class FormSpisaniye
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
            this.dgvSpisaniye = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpisaniye)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCaption
            // 
            this.pbCaption.Size = new System.Drawing.Size(547, 66);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnCancel.Location = new System.Drawing.Point(475, 0);
            // 
            // lblCaption
            // 
            this.lblCaption.Size = new System.Drawing.Size(234, 33);
            this.lblCaption.Text = "Даты списания";
            // 
            // dgvSpisaniye
            // 
            this.dgvSpisaniye.AllowUserToAddRows = false;
            this.dgvSpisaniye.AllowUserToDeleteRows = false;
            this.dgvSpisaniye.AllowUserToResizeRows = false;
            this.dgvSpisaniye.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSpisaniye.ColumnHeadersHeight = 40;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSpisaniye.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSpisaniye.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvSpisaniye.Location = new System.Drawing.Point(11, 71);
            this.dgvSpisaniye.Margin = new System.Windows.Forms.Padding(2);
            this.dgvSpisaniye.MultiSelect = false;
            this.dgvSpisaniye.Name = "dgvSpisaniye";
            this.dgvSpisaniye.RowHeadersVisible = false;
            this.dgvSpisaniye.RowHeadersWidth = 50;
            this.dgvSpisaniye.RowTemplate.Height = 40;
            this.dgvSpisaniye.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSpisaniye.Size = new System.Drawing.Size(521, 467);
            this.dgvSpisaniye.TabIndex = 17;
            this.dgvSpisaniye.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFaktura_CellDoubleClick);
            // 
            // FormSpisaniye
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 549);
            this.Controls.Add(this.dgvSpisaniye);
            this.Name = "FormSpisaniye";
            this.Text = "FakturaForm";
            this.Load += new System.EventHandler(this.GetFakturaForm_Load);
            this.Controls.SetChildIndex(this.pbCaption, 0);
            this.Controls.SetChildIndex(this.lblCaption, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.dgvSpisaniye, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pbCaption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpisaniye)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSpisaniye;
    }
}