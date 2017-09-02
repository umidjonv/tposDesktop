namespace tposDesktop.SubForms
{
    partial class TerminalForm
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
            this.tbxSumma = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaption)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCaption
            // 
            this.pbCaption.Location = new System.Drawing.Point(-2, 0);
            this.pbCaption.Margin = new System.Windows.Forms.Padding(2);
            this.pbCaption.Size = new System.Drawing.Size(227, 41);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnCancel.Font = new System.Drawing.Font("Arial Black", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(184, 0);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Size = new System.Drawing.Size(40, 41);
            // 
            // lblCaption
            // 
            this.lblCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCaption.Location = new System.Drawing.Point(3, 9);
            this.lblCaption.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCaption.Size = new System.Drawing.Size(166, 20);
            this.lblCaption.Text = "Сумма терминала:";
            // 
            // tbxSumma
            // 
            this.tbxSumma.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbxSumma.Location = new System.Drawing.Point(15, 48);
            this.tbxSumma.Margin = new System.Windows.Forms.Padding(2);
            this.tbxSumma.Name = "tbxSumma";
            this.tbxSumma.Size = new System.Drawing.Size(189, 29);
            this.tbxSumma.TabIndex = 17;
            this.tbxSumma.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxSumma_KeyPress);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Yellow;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOK.Location = new System.Drawing.Point(15, 80);
            this.btnOK.Margin = new System.Windows.Forms.Padding(2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(189, 41);
            this.btnOK.TabIndex = 18;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // TerminalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.ClientSize = new System.Drawing.Size(224, 131);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tbxSumma);
            this.Location = new System.Drawing.Point(600, 100);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TerminalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "TerminalForm";
            this.Load += new System.EventHandler(this.TerminalForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.TerminalForm_Paint);
            this.Controls.SetChildIndex(this.tbxSumma, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.pbCaption, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.lblCaption, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pbCaption)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.TextBox tbxSumma;
    }
}