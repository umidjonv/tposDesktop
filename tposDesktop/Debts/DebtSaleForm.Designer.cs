namespace tposDesktop.Debts
{
    partial class DebtSaleForm
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
            this.showBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblActualSum = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblClient = new System.Windows.Forms.Label();
            this.btnSale = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblFIO = new System.Windows.Forms.Label();
            this.tbxPercent = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxPeriod = new System.Windows.Forms.TextBox();
            this.cbxKredit = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblOneMonthSum = new System.Windows.Forms.Label();
            this.lblPercentSum = new System.Windows.Forms.TextBox();
            this.tbxBeginSum = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnTerminal = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaption)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCaption
            // 
            this.pbCaption.Size = new System.Drawing.Size(423, 66);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnCancel.Location = new System.Drawing.Point(351, 0);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // lblCaption
            // 
            this.lblCaption.Size = new System.Drawing.Size(167, 33);
            this.lblCaption.Text = "Рассрочка";
            // 
            // showBtn
            // 
            this.showBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.showBtn.BackColor = System.Drawing.Color.Yellow;
            this.showBtn.FlatAppearance.BorderSize = 0;
            this.showBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.showBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.showBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(91)))), ((int)(((byte)(139)))));
            this.showBtn.Location = new System.Drawing.Point(198, 72);
            this.showBtn.Name = "showBtn";
            this.showBtn.Size = new System.Drawing.Size(209, 34);
            this.showBtn.TabIndex = 18;
            this.showBtn.Text = "ВЫБРАТЬ КЛИЕНТА ->";
            this.showBtn.UseVisualStyleBackColor = false;
            this.showBtn.Click += new System.EventHandler(this.showBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(42, 366);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 24);
            this.label3.TabIndex = 19;
            this.label3.Text = "Сумма товаров :";
            // 
            // lblActualSum
            // 
            this.lblActualSum.AutoSize = true;
            this.lblActualSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblActualSum.Location = new System.Drawing.Point(210, 366);
            this.lblActualSum.Name = "lblActualSum";
            this.lblActualSum.Size = new System.Drawing.Size(20, 24);
            this.lblActualSum.TabIndex = 19;
            this.lblActualSum.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(43, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 24);
            this.label1.TabIndex = 19;
            this.label1.Text = "Клиент :";
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblClient.Location = new System.Drawing.Point(195, 125);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(28, 24);
            this.lblClient.TabIndex = 19;
            this.lblClient.Text = "---";
            // 
            // btnSale
            // 
            this.btnSale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSale.BackColor = System.Drawing.Color.Yellow;
            this.btnSale.FlatAppearance.BorderSize = 0;
            this.btnSale.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.btnSale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSale.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(91)))), ((int)(((byte)(139)))));
            this.btnSale.Location = new System.Drawing.Point(12, 568);
            this.btnSale.Name = "btnSale";
            this.btnSale.Size = new System.Drawing.Size(333, 49);
            this.btnSale.TabIndex = 18;
            this.btnSale.Text = "Оформить";
            this.btnSale.UseVisualStyleBackColor = false;
            this.btnSale.Click += new System.EventHandler(this.btnSale_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(138, 490);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 24);
            this.label5.TabIndex = 19;
            this.label5.Text = "Сумма оплаты";
            // 
            // lblFIO
            // 
            this.lblFIO.AutoSize = true;
            this.lblFIO.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFIO.Location = new System.Drawing.Point(43, 218);
            this.lblFIO.Name = "lblFIO";
            this.lblFIO.Size = new System.Drawing.Size(88, 24);
            this.lblFIO.TabIndex = 19;
            this.lblFIO.Text = "Процент";
            // 
            // tbxPercent
            // 
            this.tbxPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbxPercent.Location = new System.Drawing.Point(215, 215);
            this.tbxPercent.Name = "tbxPercent";
            this.tbxPercent.ReadOnly = true;
            this.tbxPercent.Size = new System.Drawing.Size(140, 29);
            this.tbxPercent.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(43, 253);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 24);
            this.label2.TabIndex = 19;
            this.label2.Text = "Месяц";
            // 
            // tbxPeriod
            // 
            this.tbxPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbxPeriod.Location = new System.Drawing.Point(214, 250);
            this.tbxPeriod.Name = "tbxPeriod";
            this.tbxPeriod.ReadOnly = true;
            this.tbxPeriod.Size = new System.Drawing.Size(140, 29);
            this.tbxPeriod.TabIndex = 20;
            // 
            // cbxKredit
            // 
            this.cbxKredit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxKredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbxKredit.FormattingEnabled = true;
            this.cbxKredit.Location = new System.Drawing.Point(47, 166);
            this.cbxKredit.Name = "cbxKredit";
            this.cbxKredit.Size = new System.Drawing.Size(307, 32);
            this.cbxKredit.TabIndex = 21;
            this.cbxKredit.SelectedIndexChanged += new System.EventHandler(this.cbxKredit_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(44, 315);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 24);
            this.label4.TabIndex = 23;
            this.label4.Text = "В месяц по :";
            // 
            // lblOneMonthSum
            // 
            this.lblOneMonthSum.AutoSize = true;
            this.lblOneMonthSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblOneMonthSum.Location = new System.Drawing.Point(210, 315);
            this.lblOneMonthSum.Name = "lblOneMonthSum";
            this.lblOneMonthSum.Size = new System.Drawing.Size(20, 24);
            this.lblOneMonthSum.TabIndex = 19;
            this.lblOneMonthSum.Text = "0";
            // 
            // lblPercentSum
            // 
            this.lblPercentSum.BackColor = System.Drawing.Color.Lime;
            this.lblPercentSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPercentSum.Location = new System.Drawing.Point(12, 518);
            this.lblPercentSum.Name = "lblPercentSum";
            this.lblPercentSum.Size = new System.Drawing.Size(395, 44);
            this.lblPercentSum.TabIndex = 19;
            this.lblPercentSum.Text = "0";
            this.lblPercentSum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbxBeginSum
            // 
            this.tbxBeginSum.BackColor = System.Drawing.Color.White;
            this.tbxBeginSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbxBeginSum.Location = new System.Drawing.Point(12, 443);
            this.tbxBeginSum.Name = "tbxBeginSum";
            this.tbxBeginSum.Size = new System.Drawing.Size(395, 44);
            this.tbxBeginSum.TabIndex = 19;
            this.tbxBeginSum.Text = "0";
            this.tbxBeginSum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxBeginSum.TextChanged += new System.EventHandler(this.tbxBeginSum_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(118, 416);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(172, 24);
            this.label6.TabIndex = 19;
            this.label6.Text = "Начальная оплата";
            // 
            // btnTerminal
            // 
            this.btnTerminal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTerminal.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnTerminal.BackColor = System.Drawing.Color.ForestGreen;
            this.btnTerminal.BackgroundImage = global::tposDesktop.Properties.Resources.terminal2;
            this.btnTerminal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTerminal.FlatAppearance.BorderColor = System.Drawing.Color.LawnGreen;
            this.btnTerminal.FlatAppearance.BorderSize = 0;
            this.btnTerminal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow;
            this.btnTerminal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTerminal.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnTerminal.ForeColor = System.Drawing.Color.White;
            this.btnTerminal.Location = new System.Drawing.Point(351, 568);
            this.btnTerminal.Name = "btnTerminal";
            this.btnTerminal.Size = new System.Drawing.Size(56, 49);
            this.btnTerminal.TabIndex = 24;
            this.btnTerminal.UseVisualStyleBackColor = false;
            this.btnTerminal.Click += new System.EventHandler(this.btnTerminal1_Click);
            // 
            // DebtSaleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 643);
            this.Controls.Add(this.btnTerminal);
            this.Controls.Add(this.tbxBeginSum);
            this.Controls.Add(this.lblPercentSum);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbxKredit);
            this.Controls.Add(this.lblOneMonthSum);
            this.Controls.Add(this.lblActualSum);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxPeriod);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxPercent);
            this.Controls.Add(this.lblClient);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblFIO);
            this.Controls.Add(this.btnSale);
            this.Controls.Add(this.showBtn);
            this.Name = "DebtSaleForm";
            this.ShowCaption = true;
            this.ShowCloseButton = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IndirectSaleForm";
            this.Controls.SetChildIndex(this.showBtn, 0);
            this.Controls.SetChildIndex(this.btnSale, 0);
            this.Controls.SetChildIndex(this.lblFIO, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lblClient, 0);
            this.Controls.SetChildIndex(this.tbxPercent, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.tbxPeriod, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.lblActualSum, 0);
            this.Controls.SetChildIndex(this.lblOneMonthSum, 0);
            this.Controls.SetChildIndex(this.cbxKredit, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.pbCaption, 0);
            this.Controls.SetChildIndex(this.lblCaption, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.lblPercentSum, 0);
            this.Controls.SetChildIndex(this.tbxBeginSum, 0);
            this.Controls.SetChildIndex(this.btnTerminal, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pbCaption)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button showBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblActualSum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.Button btnSale;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblFIO;
        private System.Windows.Forms.TextBox tbxPercent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxPeriod;
        private System.Windows.Forms.ComboBox cbxKredit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblOneMonthSum;
        private System.Windows.Forms.TextBox lblPercentSum;
        private System.Windows.Forms.TextBox tbxBeginSum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnTerminal;
    }
}