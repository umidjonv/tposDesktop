namespace tposDesktop
{
    partial class packing
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
            this.tbxShtrix = new System.Windows.Forms.TextBox();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPack = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tbxPack = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaption)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            // 
            // lblCaption
            // 
            this.lblCaption.Size = new System.Drawing.Size(140, 33);
            this.lblCaption.Text = "Фасовка";
            // 
            // tbxShtrix
            // 
            this.tbxShtrix.Enabled = false;
            this.tbxShtrix.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.tbxShtrix.Location = new System.Drawing.Point(90, 135);
            this.tbxShtrix.Name = "tbxShtrix";
            this.tbxShtrix.Size = new System.Drawing.Size(281, 28);
            this.tbxShtrix.TabIndex = 14;
            // 
            // tbxName
            // 
            this.tbxName.Enabled = false;
            this.tbxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.tbxName.Location = new System.Drawing.Point(90, 88);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(439, 28);
            this.tbxName.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.label2.Location = new System.Drawing.Point(19, 136);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 24);
            this.label2.TabIndex = 11;
            this.label2.Text = "Штрих";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.lblName.Location = new System.Drawing.Point(19, 86);
            this.lblName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(65, 24);
            this.lblName.TabIndex = 12;
            this.lblName.Text = "Товар";
            // 
            // lblPack
            // 
            this.lblPack.AutoSize = true;
            this.lblPack.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.lblPack.Location = new System.Drawing.Point(19, 190);
            this.lblPack.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPack.Name = "lblPack";
            this.lblPack.Size = new System.Drawing.Size(48, 24);
            this.lblPack.TabIndex = 15;
            this.lblPack.Text = "Кол.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.label1.Location = new System.Drawing.Point(19, 242);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 24);
            this.label1.TabIndex = 17;
            this.label1.Text = "Цена";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.lblPrice.Location = new System.Drawing.Point(106, 242);
            this.lblPrice.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(20, 24);
            this.lblPrice.TabIndex = 18;
            this.lblPrice.Text = "0";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Yellow;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(391, 242);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 67);
            this.button1.TabIndex = 2;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbxPack
            // 
            this.tbxPack.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.tbxPack.Location = new System.Drawing.Point(90, 187);
            this.tbxPack.MaxLength = 6;
            this.tbxPack.Name = "tbxPack";
            this.tbxPack.Size = new System.Drawing.Size(160, 28);
            this.tbxPack.TabIndex = 19;
            // 
            // packing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 337);
            this.Controls.Add(this.tbxPack);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPack);
            this.Controls.Add(this.tbxShtrix);
            this.Controls.Add(this.tbxName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblName);
            this.Name = "packing";
            this.Text = "packing";
            this.Controls.SetChildIndex(this.pbCaption, 0);
            this.Controls.SetChildIndex(this.lblCaption, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.lblName, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.tbxName, 0);
            this.Controls.SetChildIndex(this.tbxShtrix, 0);
            this.Controls.SetChildIndex(this.lblPack, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lblPrice, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.tbxPack, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pbCaption)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxShtrix;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbxPack;
    }
}