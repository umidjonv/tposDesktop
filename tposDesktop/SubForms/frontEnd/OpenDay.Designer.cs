namespace Classes
{
    partial class OpenDay
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaption)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCaption
            // 
            this.pbCaption.Location = new System.Drawing.Point(-2, 0);
            this.pbCaption.Margin = new System.Windows.Forms.Padding(2);
            this.pbCaption.Size = new System.Drawing.Size(285, 31);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnCancel.Location = new System.Drawing.Point(221, 0);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Size = new System.Drawing.Size(62, 71);
            this.btnCancel.Visible = false;
            // 
            // lblCaption
            // 
            this.lblCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCaption.Location = new System.Drawing.Point(5, 5);
            this.lblCaption.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCaption.Size = new System.Drawing.Size(226, 20);
            this.lblCaption.Text = "Обновление базы данных";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(9, 36);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(265, 25);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 11;
            this.progressBar1.Value = 100;
            // 
            // OpenDay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 70);
            this.Controls.Add(this.progressBar1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "OpenDay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OpenDay";
            this.Load += new System.EventHandler(this.OpenDay_Load);
            this.Controls.SetChildIndex(this.pbCaption, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.lblCaption, 0);
            this.Controls.SetChildIndex(this.progressBar1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pbCaption)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
    }
}