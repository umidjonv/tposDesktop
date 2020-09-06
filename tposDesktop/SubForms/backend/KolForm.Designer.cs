namespace tposDesktop
{
    partial class KolForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbxCount1 = new Classes.NumericTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.balanceTableAdapter1 = new tposDesktop.DataSetTposTableAdapters.balanceTableAdapter();
            this.label2 = new System.Windows.Forms.Label();
            this.lblKol = new System.Windows.Forms.Label();
            this.lblOstatok = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaption)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCaption
            // 
            this.pbCaption.Size = new System.Drawing.Size(637, 66);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnCancel.Location = new System.Drawing.Point(565, 0);
            // 
            // lblCaption
            // 
            this.lblCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCaption.Location = new System.Drawing.Point(12, 17);
            this.lblCaption.Size = new System.Drawing.Size(139, 25);
            this.lblCaption.Text = "Количество";
            this.lblCaption.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(105, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Кол./Вес";
            // 
            // tbxCount1
            // 
            this.tbxCount1.Location = new System.Drawing.Point(197, 96);
            this.tbxCount1.MaxLength = 6;
            this.tbxCount1.Name = "tbxCount1";
            this.tbxCount1.Size = new System.Drawing.Size(321, 28);
            this.tbxCount1.TabIndex = 1;
            this.tbxCount1.TextChanged += new System.EventHandler(this.tbxCount1_TextChanged);
            this.tbxCount1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OrderForm_KeyPress);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Yellow;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(350, 199);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 49);
            this.button1.TabIndex = 2;
            this.button1.Text = "Изменить";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // balanceTableAdapter1
            // 
            this.balanceTableAdapter1.ClearBeforeFill = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(105, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Текущее:";
            // 
            // lblKol
            // 
            this.lblKol.AutoSize = true;
            this.lblKol.BackColor = System.Drawing.Color.Transparent;
            this.lblKol.Location = new System.Drawing.Point(202, 152);
            this.lblKol.Name = "lblKol";
            this.lblKol.Size = new System.Drawing.Size(0, 24);
            this.lblKol.TabIndex = 0;
            // 
            // lblOstatok
            // 
            this.lblOstatok.AutoSize = true;
            this.lblOstatok.Location = new System.Drawing.Point(452, 152);
            this.lblOstatok.Name = "lblOstatok";
            this.lblOstatok.Size = new System.Drawing.Size(0, 24);
            this.lblOstatok.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(346, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 24);
            this.label4.TabIndex = 16;
            this.label4.Text = "Остаток:";
            // 
            // KolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(219)))), ((int)(((byte)(179)))));
            this.ClientSize = new System.Drawing.Size(632, 274);
            this.Controls.Add(this.lblOstatok);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbxCount1);
            this.Controls.Add(this.lblKol);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "KolForm";
            this.ShowCaption = true;
            this.ShowCloseButton = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "На заказ";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OrderForm_KeyPress);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.lblKol, 0);
            this.Controls.SetChildIndex(this.tbxCount1, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.pbCaption, 0);
            this.Controls.SetChildIndex(this.lblCaption, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.lblOstatok, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pbCaption)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Classes.NumericTextBox tbxCount1;
        private System.Windows.Forms.Button button1;
        private DataSetTposTableAdapters.balanceTableAdapter balanceTableAdapter1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblKol;
        private System.Windows.Forms.Label lblOstatok;
        private System.Windows.Forms.Label label4;
    }
}