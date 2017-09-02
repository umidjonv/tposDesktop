namespace FirstConfig
{
    partial class FormConfig
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
            this.pbConfig = new System.Windows.Forms.ProgressBar();
            this.lbxConfig = new System.Windows.Forms.ListBox();
            this.btnNext = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaption)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCaption
            // 
            this.pbCaption.Size = new System.Drawing.Size(608, 66);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnCancel.Location = new System.Drawing.Point(536, 0);
            // 
            // lblCaption
            // 
            this.lblCaption.Size = new System.Drawing.Size(214, 42);
            this.lblCaption.Text = "Настройка";
            // 
            // pbConfig
            // 
            this.pbConfig.Location = new System.Drawing.Point(19, 87);
            this.pbConfig.Name = "pbConfig";
            this.pbConfig.Size = new System.Drawing.Size(563, 49);
            this.pbConfig.TabIndex = 11;
            // 
            // lbxConfig
            // 
            this.lbxConfig.FormattingEnabled = true;
            this.lbxConfig.ItemHeight = 16;
            this.lbxConfig.Location = new System.Drawing.Point(19, 154);
            this.lbxConfig.Name = "lbxConfig";
            this.lbxConfig.Size = new System.Drawing.Size(563, 212);
            this.lbxConfig.TabIndex = 12;
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnNext.Location = new System.Drawing.Point(428, 372);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(154, 49);
            this.btnNext.TabIndex = 13;
            this.btnNext.Text = "Configuring";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // FormConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 433);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.lbxConfig);
            this.Controls.Add(this.pbConfig);
            this.Name = "FormConfig";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormConfig_Load);
            this.Controls.SetChildIndex(this.pbCaption, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.lblCaption, 0);
            this.Controls.SetChildIndex(this.pbConfig, 0);
            this.Controls.SetChildIndex(this.lbxConfig, 0);
            this.Controls.SetChildIndex(this.btnNext, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pbCaption)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbConfig;
        private System.Windows.Forms.ListBox lbxConfig;
        private System.Windows.Forms.Button btnNext;
    }
}

