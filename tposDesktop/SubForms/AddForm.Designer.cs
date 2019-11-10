namespace tposDesktop
{
    partial class AddForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblPack = new System.Windows.Forms.Label();
            this.tbxPrice = new Classes.NumericTextBox();
            this.tbxPack = new Classes.NumericTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.limitProdChbx = new System.Windows.Forms.CheckBox();
            this.blnLbl = new System.Windows.Forms.Label();
            this.lblExpiry = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaption)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCaption
            // 
            this.pbCaption.Size = new System.Drawing.Size(600, 66);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnCancel.Location = new System.Drawing.Point(528, 0);
            // 
            // lblCaption
            // 
            this.lblCaption.Size = new System.Drawing.Size(243, 33);
            this.lblCaption.Text = "Добавить товар";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(20, 94);
            this.lblName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(65, 24);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Товар";
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(101, 96);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(451, 28);
            this.tbxName.TabIndex = 1;
            this.tbxName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.control_keypress);
            // 
            // tbxShtrix
            // 
            this.tbxShtrix.Enabled = false;
            this.tbxShtrix.Location = new System.Drawing.Point(101, 143);
            this.tbxShtrix.Name = "tbxShtrix";
            this.tbxShtrix.Size = new System.Drawing.Size(332, 28);
            this.tbxShtrix.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 144);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Штрих";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 245);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Цена";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Yellow;
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.Orange;
            this.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Orange;
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Location = new System.Drawing.Point(404, 223);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(158, 46);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.AddOrEdit);
            // 
            // lblPack
            // 
            this.lblPack.AutoSize = true;
            this.lblPack.Location = new System.Drawing.Point(97, 180);
            this.lblPack.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPack.Name = "lblPack";
            this.lblPack.Size = new System.Drawing.Size(120, 24);
            this.lblPack.TabIndex = 0;
            this.lblPack.Text = "Кол. в пачке";
            // 
            // tbxPrice
            // 
            this.tbxPrice.Enabled = false;
            this.tbxPrice.Location = new System.Drawing.Point(101, 242);
            this.tbxPrice.Name = "tbxPrice";
            this.tbxPrice.Size = new System.Drawing.Size(148, 28);
            this.tbxPrice.TabIndex = 4;
            this.tbxPrice.Text = "0";
            // 
            // tbxPack
            // 
            this.tbxPack.Location = new System.Drawing.Point(101, 207);
            this.tbxPack.Name = "tbxPack";
            this.tbxPack.Size = new System.Drawing.Size(148, 28);
            this.tbxPack.TabIndex = 3;
            this.tbxPack.Text = "0";
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::tposDesktop.Properties.Resources.printer_icon_vector_stock_vector_532760;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(487, 144);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 60);
            this.button1.TabIndex = 11;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // limitProdChbx
            // 
            this.limitProdChbx.AutoSize = true;
            this.limitProdChbx.Location = new System.Drawing.Point(276, 242);
            this.limitProdChbx.Name = "limitProdChbx";
            this.limitProdChbx.Size = new System.Drawing.Size(90, 28);
            this.limitProdChbx.TabIndex = 12;
            this.limitProdChbx.Text = "Огран.";
            this.limitProdChbx.UseVisualStyleBackColor = true;
            this.limitProdChbx.CheckedChanged += new System.EventHandler(this.limitProdChbx_CheckedChanged);
            // 
            // blnLbl
            // 
            this.blnLbl.AutoSize = true;
            this.blnLbl.Location = new System.Drawing.Point(272, 245);
            this.blnLbl.Name = "blnLbl";
            this.blnLbl.Size = new System.Drawing.Size(0, 24);
            this.blnLbl.TabIndex = 13;
            // 
            // lblExpiry
            // 
            this.lblExpiry.AutoSize = true;
            this.lblExpiry.Location = new System.Drawing.Point(272, 245);
            this.lblExpiry.Name = "lblExpiry";
            this.lblExpiry.Size = new System.Drawing.Size(0, 24);
            this.lblExpiry.TabIndex = 14;
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGreen;
            this.ClientSize = new System.Drawing.Size(595, 309);
            this.Controls.Add(this.lblExpiry);
            this.Controls.Add(this.blnLbl);
            this.Controls.Add(this.limitProdChbx);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbxPrice);
            this.Controls.Add(this.tbxPack);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.tbxShtrix);
            this.Controls.Add(this.lblPack);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddForm";
            this.Text = "Добавить товар";
            this.Controls.SetChildIndex(this.lblName, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.tbxName, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.lblPack, 0);
            this.Controls.SetChildIndex(this.tbxShtrix, 0);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.tbxPack, 0);
            this.Controls.SetChildIndex(this.tbxPrice, 0);
            this.Controls.SetChildIndex(this.pbCaption, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.lblCaption, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.limitProdChbx, 0);
            this.Controls.SetChildIndex(this.blnLbl, 0);
            this.Controls.SetChildIndex(this.lblExpiry, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pbCaption)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.TextBox tbxShtrix;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblPack;
        private Classes.NumericTextBox tbxPack;
        private Classes.NumericTextBox tbxPrice;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox limitProdChbx;
        private System.Windows.Forms.Label blnLbl;
        private System.Windows.Forms.Label lblExpiry;
    }
}