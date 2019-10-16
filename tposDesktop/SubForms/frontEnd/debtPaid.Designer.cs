namespace tposDesktop
{
    partial class debtPaid
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
            this.tbxSum = new System.Windows.Forms.TextBox();
            this.ckbxNal = new System.Windows.Forms.RadioButton();
            this.ckbxTerm = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaption)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCaption
            // 
            this.pbCaption.Size = new System.Drawing.Size(230, 39);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnCancel.Font = new System.Drawing.Font("Arial Black", 13.8F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Location = new System.Drawing.Point(183, 0);
            this.btnCancel.Size = new System.Drawing.Size(44, 39);
            // 
            // lblCaption
            // 
            this.lblCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold);
            this.lblCaption.Location = new System.Drawing.Point(12, 8);
            this.lblCaption.Size = new System.Drawing.Size(125, 24);
            this.lblCaption.Text = "Вид оплаты";
            // 
            // tbxSum
            // 
            this.tbxSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.tbxSum.Location = new System.Drawing.Point(18, 45);
            this.tbxSum.Name = "tbxSum";
            this.tbxSum.Size = new System.Drawing.Size(189, 28);
            this.tbxSum.TabIndex = 11;
            // 
            // ckbxNal
            // 
            this.ckbxNal.AutoSize = true;
            this.ckbxNal.Checked = true;
            this.ckbxNal.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.ckbxNal.Location = new System.Drawing.Point(18, 79);
            this.ckbxNal.Name = "ckbxNal";
            this.ckbxNal.Size = new System.Drawing.Size(66, 28);
            this.ckbxNal.TabIndex = 12;
            this.ckbxNal.TabStop = true;
            this.ckbxNal.Text = "Нал.";
            this.ckbxNal.UseVisualStyleBackColor = true;
            // 
            // ckbxTerm
            // 
            this.ckbxTerm.AutoSize = true;
            this.ckbxTerm.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.ckbxTerm.Location = new System.Drawing.Point(122, 79);
            this.ckbxTerm.Name = "ckbxTerm";
            this.ckbxTerm.Size = new System.Drawing.Size(80, 28);
            this.ckbxTerm.TabIndex = 13;
            this.ckbxTerm.Text = "Терм.";
            this.ckbxTerm.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Yellow;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOK.Location = new System.Drawing.Point(16, 112);
            this.btnOK.Margin = new System.Windows.Forms.Padding(2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(191, 41);
            this.btnOK.TabIndex = 19;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // debtPaid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 168);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.ckbxTerm);
            this.Controls.Add(this.ckbxNal);
            this.Controls.Add(this.tbxSum);
            this.Location = new System.Drawing.Point(600, 100);
            this.Name = "debtPaid";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "debtPaid";
            this.Controls.SetChildIndex(this.pbCaption, 0);
            this.Controls.SetChildIndex(this.lblCaption, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.tbxSum, 0);
            this.Controls.SetChildIndex(this.ckbxNal, 0);
            this.Controls.SetChildIndex(this.ckbxTerm, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pbCaption)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxSum;
        private System.Windows.Forms.RadioButton ckbxNal;
        private System.Windows.Forms.RadioButton ckbxTerm;
        private System.Windows.Forms.Button btnOK;
    }
}