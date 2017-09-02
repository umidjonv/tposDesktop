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
            this.measureRadio = new System.Windows.Forms.RadioButton();
            this.measureRadio2 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.balanceTableAdapter1 = new tposDesktop.DataSetTposTableAdapters.balanceTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.prCmbx = new System.Windows.Forms.ComboBox();
            this.providerTableAdapter1 = new tposDesktop.DataSetTposTableAdapters.providerTableAdapter();
            this.btnBarcode = new System.Windows.Forms.Button();
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
            this.btnCancel.FlatAppearance.BorderSize = 0;
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
            this.tbxName.Location = new System.Drawing.Point(91, 96);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(471, 28);
            this.tbxName.TabIndex = 1;
            this.tbxName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.control_keypress);
            // 
            // tbxShtrix
            // 
            this.tbxShtrix.Enabled = false;
            this.tbxShtrix.Location = new System.Drawing.Point(91, 143);
            this.tbxShtrix.Name = "tbxShtrix";
            this.tbxShtrix.Size = new System.Drawing.Size(336, 28);
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
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Orange;
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Location = new System.Drawing.Point(404, 278);
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
            this.lblPack.Location = new System.Drawing.Point(20, 196);
            this.lblPack.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPack.Name = "lblPack";
            this.lblPack.Size = new System.Drawing.Size(48, 24);
            this.lblPack.TabIndex = 0;
            this.lblPack.Text = "Кол.";
            this.lblPack.Visible = false;
            // 
            // tbxPrice
            // 
            this.tbxPrice.Location = new System.Drawing.Point(91, 242);
            this.tbxPrice.Name = "tbxPrice";
            this.tbxPrice.Size = new System.Drawing.Size(148, 28);
            this.tbxPrice.TabIndex = 4;
            this.tbxPrice.Text = "0";
            // 
            // tbxPack
            // 
            this.tbxPack.Location = new System.Drawing.Point(91, 193);
            this.tbxPack.Name = "tbxPack";
            this.tbxPack.Size = new System.Drawing.Size(148, 28);
            this.tbxPack.TabIndex = 3;
            this.tbxPack.Text = "0";
            this.tbxPack.Visible = false;
            // 
            // measureRadio
            // 
            this.measureRadio.AutoSize = true;
            this.measureRadio.Location = new System.Drawing.Point(279, 192);
            this.measureRadio.Name = "measureRadio";
            this.measureRadio.Size = new System.Drawing.Size(52, 28);
            this.measureRadio.TabIndex = 11;
            this.measureRadio.TabStop = true;
            this.measureRadio.Text = "шт";
            this.measureRadio.UseVisualStyleBackColor = true;
            // 
            // measureRadio2
            // 
            this.measureRadio2.AutoSize = true;
            this.measureRadio2.Location = new System.Drawing.Point(279, 241);
            this.measureRadio2.Name = "measureRadio2";
            this.measureRadio2.Size = new System.Drawing.Size(46, 28);
            this.measureRadio2.TabIndex = 12;
            this.measureRadio2.TabStop = true;
            this.measureRadio2.Text = "кг";
            this.measureRadio2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::tposDesktop.Properties.Resources.printer_icon_vector_stock_vector_532760;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(502, 130);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 60);
            this.button1.TabIndex = 13;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // balanceTableAdapter1
            // 
            this.balanceTableAdapter1.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 293);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 24);
            this.label1.TabIndex = 14;
            this.label1.Text = "Поставщики";
            // 
            // prCmbx
            // 
            this.prCmbx.FormattingEnabled = true;
            this.prCmbx.Location = new System.Drawing.Point(145, 287);
            this.prCmbx.Name = "prCmbx";
            this.prCmbx.Size = new System.Drawing.Size(186, 30);
            this.prCmbx.TabIndex = 15;
            // 
            // providerTableAdapter1
            // 
            this.providerTableAdapter1.ClearBeforeFill = true;
            // 
            // btnBarcode
            // 
            this.btnBarcode.Location = new System.Drawing.Point(384, 206);
            this.btnBarcode.Name = "btnBarcode";
            this.btnBarcode.Size = new System.Drawing.Size(178, 44);
            this.btnBarcode.TabIndex = 16;
            this.btnBarcode.Text = "Печать этикеток";
            this.btnBarcode.UseVisualStyleBackColor = true;
            this.btnBarcode.Click += new System.EventHandler(this.btnBarcode_Click);
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(219)))), ((int)(((byte)(179)))));
            this.ClientSize = new System.Drawing.Size(595, 341);
            this.Controls.Add(this.btnBarcode);
            this.Controls.Add(this.prCmbx);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.measureRadio2);
            this.Controls.Add(this.measureRadio);
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
            this.Controls.SetChildIndex(this.measureRadio, 0);
            this.Controls.SetChildIndex(this.measureRadio2, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.prCmbx, 0);
            this.Controls.SetChildIndex(this.btnBarcode, 0);
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
        private System.Windows.Forms.RadioButton measureRadio;
        private System.Windows.Forms.RadioButton measureRadio2;
        private System.Windows.Forms.Button button1;
        private DataSetTposTableAdapters.balanceTableAdapter balanceTableAdapter1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox prCmbx;
        private DataSetTposTableAdapters.providerTableAdapter providerTableAdapter1;
        private System.Windows.Forms.Button btnBarcode;
    }
}