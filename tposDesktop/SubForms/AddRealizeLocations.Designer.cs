namespace tposDesktop
{
    partial class AddRealizeLocations
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
            this.lblName = new System.Windows.Forms.Label();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.tbxShtrix = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblPack = new System.Windows.Forms.Label();
            this.lblKol = new System.Windows.Forms.Label();
            this.tbxKol = new Classes.NumericTextBox();
            this.tbxPack = new Classes.NumericTextBox();
            this.limitChbx = new System.Windows.Forms.CheckBox();
            this.blnLbl = new System.Windows.Forms.Label();
            this.expiry = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvPrices = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrices)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCaption
            // 
            this.pbCaption.Location = new System.Drawing.Point(-2, -2);
            this.pbCaption.Size = new System.Drawing.Size(641, 66);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnCancel.Location = new System.Drawing.Point(552, -2);
            this.btnCancel.Size = new System.Drawing.Size(87, 66);
            this.btnCancel.TabIndex = 10;
            // 
            // lblCaption
            // 
            this.lblCaption.Location = new System.Drawing.Point(25, 9);
            this.lblCaption.Size = new System.Drawing.Size(292, 33);
            this.lblCaption.Text = "Приходовать товар";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblName.Location = new System.Drawing.Point(27, 94);
            this.lblName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(54, 20);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Товар";
            // 
            // tbxName
            // 
            this.tbxName.Enabled = false;
            this.tbxName.Location = new System.Drawing.Point(143, 91);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(483, 28);
            this.tbxName.TabIndex = 1;
            this.tbxName.TabStop = false;
            // 
            // tbxShtrix
            // 
            this.tbxShtrix.Enabled = false;
            this.tbxShtrix.Location = new System.Drawing.Point(143, 132);
            this.tbxShtrix.Name = "tbxShtrix";
            this.tbxShtrix.Size = new System.Drawing.Size(345, 28);
            this.tbxShtrix.TabIndex = 1;
            this.tbxShtrix.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(27, 135);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Штрих";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Yellow;
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.Orange;
            this.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Orange;
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Location = new System.Drawing.Point(468, 452);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(158, 46);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.AddOrEdit);
            // 
            // lblPack
            // 
            this.lblPack.AutoSize = true;
            this.lblPack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPack.Location = new System.Drawing.Point(27, 192);
            this.lblPack.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPack.Name = "lblPack";
            this.lblPack.Size = new System.Drawing.Size(110, 20);
            this.lblPack.TabIndex = 0;
            this.lblPack.Text = "Пачка всего :";
            // 
            // lblKol
            // 
            this.lblKol.AutoSize = true;
            this.lblKol.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblKol.Location = new System.Drawing.Point(27, 236);
            this.lblKol.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblKol.Name = "lblKol";
            this.lblKol.Size = new System.Drawing.Size(42, 20);
            this.lblKol.TabIndex = 0;
            this.lblKol.Text = "Кол.";
            // 
            // tbxKol
            // 
            this.tbxKol.Location = new System.Drawing.Point(143, 230);
            this.tbxKol.Name = "tbxKol";
            this.tbxKol.Size = new System.Drawing.Size(148, 28);
            this.tbxKol.TabIndex = 3;
            this.tbxKol.Text = "0";
            // 
            // tbxPack
            // 
            this.tbxPack.Location = new System.Drawing.Point(143, 186);
            this.tbxPack.Name = "tbxPack";
            this.tbxPack.Size = new System.Drawing.Size(148, 28);
            this.tbxPack.TabIndex = 2;
            this.tbxPack.Text = "0";
            // 
            // limitChbx
            // 
            this.limitChbx.AutoSize = true;
            this.limitChbx.Location = new System.Drawing.Point(429, 184);
            this.limitChbx.Name = "limitChbx";
            this.limitChbx.Size = new System.Drawing.Size(90, 28);
            this.limitChbx.TabIndex = 6;
            this.limitChbx.Text = "Огран.";
            this.limitChbx.UseVisualStyleBackColor = true;
            // 
            // blnLbl
            // 
            this.blnLbl.AutoSize = true;
            this.blnLbl.Location = new System.Drawing.Point(519, 136);
            this.blnLbl.Name = "blnLbl";
            this.blnLbl.Size = new System.Drawing.Size(0, 24);
            this.blnLbl.TabIndex = 12;
            // 
            // expiry
            // 
            this.expiry.Location = new System.Drawing.Point(429, 230);
            this.expiry.Name = "expiry";
            this.expiry.Size = new System.Drawing.Size(185, 28);
            this.expiry.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(314, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "Срок годн.";
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::tposDesktop.Properties.Resources.printer_icon_vector_stock_vector_532760;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(551, 132);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 60);
            this.button1.TabIndex = 8;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvPrices
            // 
            this.dgvPrices.AllowUserToAddRows = false;
            this.dgvPrices.AllowUserToDeleteRows = false;
            this.dgvPrices.AllowUserToResizeRows = false;
            this.dgvPrices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrices.Location = new System.Drawing.Point(31, 279);
            this.dgvPrices.Name = "dgvPrices";
            this.dgvPrices.RowHeadersVisible = false;
            this.dgvPrices.RowTemplate.Height = 30;
            this.dgvPrices.Size = new System.Drawing.Size(595, 167);
            this.dgvPrices.TabIndex = 15;
            this.dgvPrices.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPrices_CellEndEdit);
            this.dgvPrices.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvPrices_EditingControlShowing);
            this.dgvPrices.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvPrices_KeyDown);
            // 
            // AddRealizeLocations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGreen;
            this.ClientSize = new System.Drawing.Size(638, 510);
            this.Controls.Add(this.dgvPrices);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.expiry);
            this.Controls.Add(this.blnLbl);
            this.Controls.Add(this.limitChbx);
            this.Controls.Add(this.tbxKol);
            this.Controls.Add(this.tbxPack);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblKol);
            this.Controls.Add(this.tbxShtrix);
            this.Controls.Add(this.lblPack);
            this.Controls.Add(this.tbxName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddRealizeLocations";
            this.Text = "Приходовать товар";
            this.Load += new System.EventHandler(this.AddRealize_Load);
            this.Controls.SetChildIndex(this.lblName, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.tbxName, 0);
            this.Controls.SetChildIndex(this.lblPack, 0);
            this.Controls.SetChildIndex(this.tbxShtrix, 0);
            this.Controls.SetChildIndex(this.lblKol, 0);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.tbxPack, 0);
            this.Controls.SetChildIndex(this.tbxKol, 0);
            this.Controls.SetChildIndex(this.pbCaption, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.lblCaption, 0);
            this.Controls.SetChildIndex(this.limitChbx, 0);
            this.Controls.SetChildIndex(this.blnLbl, 0);
            this.Controls.SetChildIndex(this.expiry, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.dgvPrices, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pbCaption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.TextBox tbxShtrix;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblPack;
        private Classes.NumericTextBox tbxPack;
        private System.Windows.Forms.Label lblKol;
        private Classes.NumericTextBox tbxKol;
        private System.Windows.Forms.CheckBox limitChbx;
        private System.Windows.Forms.Label blnLbl;
        private System.Windows.Forms.DateTimePicker expiry;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvPrices;
    }
}