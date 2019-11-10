namespace tposDesktop.SubForms
{
    partial class FormToFilial
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
            this.dgvTofilial = new System.Windows.Forms.DataGridView();
            this.colBtnDel = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnOK = new System.Windows.Forms.Button();
            this.tbxTovar = new System.Windows.Forms.TextBox();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tbxFilial = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbxTovary = new System.Windows.Forms.ListBox();
            this.tbxTovarName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTofilial)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCaption
            // 
            this.pbCaption.Size = new System.Drawing.Size(696, 66);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnCancel.Location = new System.Drawing.Point(624, 0);
            // 
            // lblCaption
            // 
            this.lblCaption.Size = new System.Drawing.Size(289, 33);
            this.lblCaption.Text = "Экспорт в филиал ";
            // 
            // dgvTofilial
            // 
            this.dgvTofilial.AllowUserToAddRows = false;
            this.dgvTofilial.AllowUserToResizeRows = false;
            this.dgvTofilial.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTofilial.BackgroundColor = System.Drawing.Color.White;
            this.dgvTofilial.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTofilial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTofilial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBtnDel});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTofilial.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTofilial.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dgvTofilial.Location = new System.Drawing.Point(12, 167);
            this.dgvTofilial.Name = "dgvTofilial";
            this.dgvTofilial.RowHeadersVisible = false;
            this.dgvTofilial.RowTemplate.Height = 40;
            this.dgvTofilial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvTofilial.Size = new System.Drawing.Size(668, 361);
            this.dgvTofilial.TabIndex = 0;
            this.dgvTofilial.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTofilial_CellClick);
            this.dgvTofilial.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTofilial_CellLeave);
            this.dgvTofilial.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgv_EditingControlShowing);
            this.dgvTofilial.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvTofilial_RowPostPaint);
            this.dgvTofilial.Enter += new System.EventHandler(this.dgvTofilial_Enter);
            this.dgvTofilial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvTofilial_KeyDown);
            this.dgvTofilial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvTofilial_KeyPress);
            // 
            // colBtnDel
            // 
            this.colBtnDel.HeaderText = "";
            this.colBtnDel.Name = "colBtnDel";
            this.colBtnDel.ReadOnly = true;
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOK.Location = new System.Drawing.Point(430, 534);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(137, 54);
            this.btnOK.TabIndex = 16;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tbxTovar
            // 
            this.tbxTovar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbxTovar.Location = new System.Drawing.Point(165, 102);
            this.tbxTovar.Name = "tbxTovar";
            this.tbxTovar.Size = new System.Drawing.Size(515, 26);
            this.tbxTovar.TabIndex = 17;
            this.tbxTovar.Enter += new System.EventHandler(this.tbxTovar_Enter);
            this.tbxTovar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvTofilial_KeyPress);
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.HeaderText = "";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.ReadOnly = true;
            // 
            // tbxFilial
            // 
            this.tbxFilial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbxFilial.Location = new System.Drawing.Point(165, 70);
            this.tbxFilial.Name = "tbxFilial";
            this.tbxFilial.Size = new System.Drawing.Size(515, 26);
            this.tbxFilial.TabIndex = 18;
            this.tbxFilial.Enter += new System.EventHandler(this.tbxFilial_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(14, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "Имя филиала:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "Штрих код или ID:";
            // 
            // lbxTovary
            // 
            this.lbxTovary.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbxTovary.FormattingEnabled = true;
            this.lbxTovary.ItemHeight = 18;
            this.lbxTovary.Location = new System.Drawing.Point(165, 162);
            this.lbxTovary.Name = "lbxTovary";
            this.lbxTovary.Size = new System.Drawing.Size(515, 130);
            this.lbxTovary.TabIndex = 20;
            this.lbxTovary.Visible = false;
            this.lbxTovary.DoubleClick += new System.EventHandler(this.lbxTovary_DoubleClick);
            this.lbxTovary.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxTovarName_KeyDown);
            // 
            // tbxTovarName
            // 
            this.tbxTovarName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbxTovarName.Location = new System.Drawing.Point(165, 135);
            this.tbxTovarName.Name = "tbxTovarName";
            this.tbxTovarName.Size = new System.Drawing.Size(515, 26);
            this.tbxTovarName.TabIndex = 17;
            this.tbxTovarName.TextChanged += new System.EventHandler(this.tbxTovarName_TextChanged);
            this.tbxTovarName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxTovarName_KeyDown);
            this.tbxTovarName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxTovarName_KeyPress);
            this.tbxTovarName.Leave += new System.EventHandler(this.tbxTovarName_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "По наименованию:";
            // 
            // FormToFilial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 600);
            this.Controls.Add(this.lbxTovary);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxFilial);
            this.Controls.Add(this.tbxTovarName);
            this.Controls.Add(this.tbxTovar);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.dgvTofilial);
            this.Name = "FormToFilial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormToFilial";
            this.Load += new System.EventHandler(this.FormToFilial_Load);
            this.Controls.SetChildIndex(this.pbCaption, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.lblCaption, 0);
            this.Controls.SetChildIndex(this.dgvTofilial, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.tbxTovar, 0);
            this.Controls.SetChildIndex(this.tbxTovarName, 0);
            this.Controls.SetChildIndex(this.tbxFilial, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.lbxTovary, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pbCaption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTofilial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTofilial;
        private System.Windows.Forms.DataGridViewButtonColumn colBtnDel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.TextBox tbxTovar;
        private System.Windows.Forms.TextBox tbxFilial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbxTovary;
        private System.Windows.Forms.TextBox tbxTovarName;
        private System.Windows.Forms.Label label3;
    }
}