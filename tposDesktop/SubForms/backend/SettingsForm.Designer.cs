namespace tposDesktop
{
    partial class SettingsForm
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
            this.btnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxOrgName = new System.Windows.Forms.TextBox();
            this.chbPrinter = new System.Windows.Forms.CheckBox();
            this.tbxCom = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxSN = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chbCOM = new System.Windows.Forms.CheckBox();
            this.dtpExpDate = new System.Windows.Forms.DateTimePicker();
            this.lblDB = new System.Windows.Forms.Label();
            this.tbxDB = new System.Windows.Forms.TextBox();
            this.kassaTbx = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaption)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCaption
            // 
            this.pbCaption.Location = new System.Drawing.Point(-2, 0);
            this.pbCaption.Margin = new System.Windows.Forms.Padding(2);
            this.pbCaption.Size = new System.Drawing.Size(411, 54);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnCancel.Location = new System.Drawing.Point(357, 0);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Size = new System.Drawing.Size(52, 54);
            // 
            // lblCaption
            // 
            this.lblCaption.Location = new System.Drawing.Point(9, 9);
            this.lblCaption.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCaption.Size = new System.Drawing.Size(194, 33);
            this.lblCaption.Text = "Орг. данные";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.BackColor = System.Drawing.Color.Yellow;
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOK.Location = new System.Drawing.Point(291, 396);
            this.btnOK.Margin = new System.Windows.Forms.Padding(2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(97, 46);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(19, 84);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Организация:";
            // 
            // tbxOrgName
            // 
            this.tbxOrgName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbxOrgName.Location = new System.Drawing.Point(133, 84);
            this.tbxOrgName.Margin = new System.Windows.Forms.Padding(2);
            this.tbxOrgName.Name = "tbxOrgName";
            this.tbxOrgName.Size = new System.Drawing.Size(256, 26);
            this.tbxOrgName.TabIndex = 13;
            // 
            // chbPrinter
            // 
            this.chbPrinter.AutoSize = true;
            this.chbPrinter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chbPrinter.Location = new System.Drawing.Point(133, 205);
            this.chbPrinter.Margin = new System.Windows.Forms.Padding(2);
            this.chbPrinter.Name = "chbPrinter";
            this.chbPrinter.Size = new System.Drawing.Size(132, 24);
            this.chbPrinter.TabIndex = 14;
            this.chbPrinter.Text = "Есть принтер";
            this.chbPrinter.UseVisualStyleBackColor = true;
            this.chbPrinter.CheckedChanged += new System.EventHandler(this.chbPrinter_CheckedChanged);
            // 
            // tbxCom
            // 
            this.tbxCom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbxCom.Location = new System.Drawing.Point(268, 169);
            this.tbxCom.Margin = new System.Windows.Forms.Padding(2);
            this.tbxCom.MaxLength = 5;
            this.tbxCom.Name = "tbxCom";
            this.tbxCom.Size = new System.Drawing.Size(62, 26);
            this.tbxCom.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(19, 298);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Ключ:";
            // 
            // tbxSN
            // 
            this.tbxSN.Enabled = false;
            this.tbxSN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbxSN.Location = new System.Drawing.Point(133, 298);
            this.tbxSN.Margin = new System.Windows.Forms.Padding(2);
            this.tbxSN.Name = "tbxSN";
            this.tbxSN.Size = new System.Drawing.Size(256, 26);
            this.tbxSN.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(19, 238);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 50);
            this.label4.TabIndex = 12;
            this.label4.Text = "Дата истечения:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chbCOM
            // 
            this.chbCOM.AutoSize = true;
            this.chbCOM.Checked = true;
            this.chbCOM.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbCOM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chbCOM.Location = new System.Drawing.Point(133, 169);
            this.chbCOM.Margin = new System.Windows.Forms.Padding(2);
            this.chbCOM.Name = "chbCOM";
            this.chbCOM.Size = new System.Drawing.Size(97, 24);
            this.chbCOM.TabIndex = 14;
            this.chbCOM.Text = "SerialPort";
            this.chbCOM.UseVisualStyleBackColor = true;
            this.chbCOM.CheckedChanged += new System.EventHandler(this.chbCOM_CheckedChanged);
            // 
            // dtpExpDate
            // 
            this.dtpExpDate.CustomFormat = "dd.MM.yyyy";
            this.dtpExpDate.Enabled = false;
            this.dtpExpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtpExpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpExpDate.Location = new System.Drawing.Point(133, 250);
            this.dtpExpDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpExpDate.Name = "dtpExpDate";
            this.dtpExpDate.Size = new System.Drawing.Size(197, 26);
            this.dtpExpDate.TabIndex = 15;
            // 
            // lblDB
            // 
            this.lblDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDB.Location = new System.Drawing.Point(19, 338);
            this.lblDB.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDB.Name = "lblDB";
            this.lblDB.Size = new System.Drawing.Size(110, 47);
            this.lblDB.TabIndex = 12;
            this.lblDB.Text = "Подключение БД:";
            this.lblDB.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblDB.Visible = false;
            // 
            // tbxDB
            // 
            this.tbxDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbxDB.Location = new System.Drawing.Point(133, 346);
            this.tbxDB.Margin = new System.Windows.Forms.Padding(2);
            this.tbxDB.Name = "tbxDB";
            this.tbxDB.Size = new System.Drawing.Size(256, 26);
            this.tbxDB.TabIndex = 13;
            this.tbxDB.Visible = false;
            // 
            // kassaTbx
            // 
            this.kassaTbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kassaTbx.Location = new System.Drawing.Point(132, 126);
            this.kassaTbx.Margin = new System.Windows.Forms.Padding(2);
            this.kassaTbx.Name = "kassaTbx";
            this.kassaTbx.Size = new System.Drawing.Size(256, 26);
            this.kassaTbx.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(18, 126);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "Кассир";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 462);
            this.Controls.Add(this.kassaTbx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpExpDate);
            this.Controls.Add(this.chbCOM);
            this.Controls.Add(this.chbPrinter);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxSN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxCom);
            this.Controls.Add(this.tbxDB);
            this.Controls.Add(this.lblDB);
            this.Controls.Add(this.tbxOrgName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOK);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SettingsForm";
            this.Controls.SetChildIndex(this.pbCaption, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.lblCaption, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.tbxOrgName, 0);
            this.Controls.SetChildIndex(this.lblDB, 0);
            this.Controls.SetChildIndex(this.tbxDB, 0);
            this.Controls.SetChildIndex(this.tbxCom, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.tbxSN, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.chbPrinter, 0);
            this.Controls.SetChildIndex(this.chbCOM, 0);
            this.Controls.SetChildIndex(this.dtpExpDate, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.kassaTbx, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pbCaption)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxOrgName;
        private System.Windows.Forms.CheckBox chbPrinter;
        private System.Windows.Forms.TextBox tbxCom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxSN;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chbCOM;
        private System.Windows.Forms.DateTimePicker dtpExpDate;
        private System.Windows.Forms.Label lblDB;
        private System.Windows.Forms.TextBox tbxDB;
        private System.Windows.Forms.TextBox kassaTbx;
        private System.Windows.Forms.Label label2;
    }
}