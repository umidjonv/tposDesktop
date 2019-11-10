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
            this.rbtMode = new System.Windows.Forms.RadioButton();
            this.rbtMode2 = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxOrgPlace = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxOrgPhone = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbxPrimechaniye = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaption)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCaption
            // 
            this.pbCaption.Location = new System.Drawing.Point(-2, 0);
            this.pbCaption.Margin = new System.Windows.Forms.Padding(2);
            this.pbCaption.Size = new System.Drawing.Size(412, 54);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnCancel.Location = new System.Drawing.Point(358, 0);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Size = new System.Drawing.Size(52, 54);
            // 
            // lblCaption
            // 
            this.lblCaption.Location = new System.Drawing.Point(9, 7);
            this.lblCaption.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCaption.Size = new System.Drawing.Size(168, 33);
            this.lblCaption.Text = "Настройки";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.BackColor = System.Drawing.Color.Yellow;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOK.Location = new System.Drawing.Point(292, 517);
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
            this.chbPrinter.Location = new System.Drawing.Point(133, 313);
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
            this.tbxCom.Location = new System.Drawing.Point(268, 277);
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
            this.label3.Location = new System.Drawing.Point(19, 439);
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
            this.tbxSN.Location = new System.Drawing.Point(133, 439);
            this.tbxSN.Margin = new System.Windows.Forms.Padding(2);
            this.tbxSN.Name = "tbxSN";
            this.tbxSN.Size = new System.Drawing.Size(256, 26);
            this.tbxSN.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(19, 379);
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
            this.chbCOM.Location = new System.Drawing.Point(133, 277);
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
            this.dtpExpDate.Location = new System.Drawing.Point(133, 391);
            this.dtpExpDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpExpDate.Name = "dtpExpDate";
            this.dtpExpDate.Size = new System.Drawing.Size(197, 26);
            this.dtpExpDate.TabIndex = 15;
            // 
            // lblDB
            // 
            this.lblDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDB.Location = new System.Drawing.Point(19, 479);
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
            this.tbxDB.Location = new System.Drawing.Point(133, 487);
            this.tbxDB.Margin = new System.Windows.Forms.Padding(2);
            this.tbxDB.Name = "tbxDB";
            this.tbxDB.Size = new System.Drawing.Size(256, 26);
            this.tbxDB.TabIndex = 13;
            this.tbxDB.Visible = false;
            // 
            // kassaTbx
            // 
            this.kassaTbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kassaTbx.Location = new System.Drawing.Point(133, 211);
            this.kassaTbx.Margin = new System.Windows.Forms.Padding(2);
            this.kassaTbx.Name = "kassaTbx";
            this.kassaTbx.Size = new System.Drawing.Size(256, 26);
            this.kassaTbx.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(19, 211);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "Кассир";
            // 
            // rbtMode
            // 
            this.rbtMode.AutoSize = true;
            this.rbtMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rbtMode.Location = new System.Drawing.Point(133, 248);
            this.rbtMode.Name = "rbtMode";
            this.rbtMode.Size = new System.Drawing.Size(114, 24);
            this.rbtMode.TabIndex = 18;
            this.rbtMode.TabStop = true;
            this.rbtMode.Text = "по фактуре";
            this.rbtMode.UseVisualStyleBackColor = true;
            // 
            // rbtMode2
            // 
            this.rbtMode2.AutoSize = true;
            this.rbtMode2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rbtMode2.Location = new System.Drawing.Point(271, 248);
            this.rbtMode2.Name = "rbtMode2";
            this.rbtMode2.Size = new System.Drawing.Size(78, 24);
            this.rbtMode2.TabIndex = 19;
            this.rbtMode2.TabStop = true;
            this.rbtMode2.Text = "ручной";
            this.rbtMode2.UseVisualStyleBackColor = true;
            this.rbtMode2.CheckedChanged += new System.EventHandler(this.rbtMode2_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(19, 252);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 20);
            this.label5.TabIndex = 20;
            this.label5.Text = "Цена";
            // 
            // tbxOrgPlace
            // 
            this.tbxOrgPlace.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbxOrgPlace.Location = new System.Drawing.Point(133, 125);
            this.tbxOrgPlace.Margin = new System.Windows.Forms.Padding(2);
            this.tbxOrgPlace.Name = "tbxOrgPlace";
            this.tbxOrgPlace.Size = new System.Drawing.Size(256, 26);
            this.tbxOrgPlace.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(19, 125);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 20);
            this.label6.TabIndex = 21;
            this.label6.Text = "Адрес:";
            // 
            // tbxOrgPhone
            // 
            this.tbxOrgPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbxOrgPhone.Location = new System.Drawing.Point(133, 168);
            this.tbxOrgPhone.Margin = new System.Windows.Forms.Padding(2);
            this.tbxOrgPhone.Name = "tbxOrgPhone";
            this.tbxOrgPhone.Size = new System.Drawing.Size(256, 26);
            this.tbxOrgPhone.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(19, 168);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 20);
            this.label7.TabIndex = 23;
            this.label7.Text = "Телефон:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(19, 341);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 20);
            this.label8.TabIndex = 16;
            this.label8.Text = "Примечание";
            // 
            // tbxPrimechaniye
            // 
            this.tbxPrimechaniye.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbxPrimechaniye.Location = new System.Drawing.Point(133, 341);
            this.tbxPrimechaniye.Margin = new System.Windows.Forms.Padding(2);
            this.tbxPrimechaniye.Name = "tbxPrimechaniye";
            this.tbxPrimechaniye.Size = new System.Drawing.Size(256, 26);
            this.tbxPrimechaniye.TabIndex = 17;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 574);
            this.Controls.Add(this.tbxOrgPhone);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbxOrgPlace);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rbtMode2);
            this.Controls.Add(this.rbtMode);
            this.Controls.Add(this.tbxPrimechaniye);
            this.Controls.Add(this.label8);
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
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.tbxPrimechaniye, 0);
            this.Controls.SetChildIndex(this.rbtMode, 0);
            this.Controls.SetChildIndex(this.rbtMode2, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.tbxOrgPlace, 0);
            this.Controls.SetChildIndex(this.pbCaption, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.lblCaption, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.tbxOrgPhone, 0);
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
        private System.Windows.Forms.RadioButton rbtMode;
        private System.Windows.Forms.RadioButton rbtMode2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxOrgPlace;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxOrgPhone;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbxPrimechaniye;
    }
}