namespace tposDesktop
{
    partial class printerSettings
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ipTbx = new System.Windows.Forms.TextBox();
            this.ethernetRadio = new System.Windows.Forms.RadioButton();
            this.usbRadio = new System.Windows.Forms.RadioButton();
            this.Lbl_NetPort = new System.Windows.Forms.Label();
            this.TbxNetPort = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Num_GapFeed = new System.Windows.Forms.NumericUpDown();
            this.Lbl_Label_H = new System.Windows.Forms.Label();
            this.Lbl_GapFeed = new System.Windows.Forms.Label();
            this.Num_Label_H = new System.Windows.Forms.NumericUpDown();
            this.Num_Label_W = new System.Windows.Forms.NumericUpDown();
            this.Lbl_Label_W = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaption)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Num_GapFeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_Label_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_Label_W)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnCancel.TabIndex = 11;
            // 
            // lblCaption
            // 
            this.lblCaption.Size = new System.Drawing.Size(275, 33);
            this.lblCaption.Text = "Настройки печати";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ipTbx);
            this.groupBox1.Controls.Add(this.ethernetRadio);
            this.groupBox1.Controls.Add(this.usbRadio);
            this.groupBox1.Controls.Add(this.Lbl_NetPort);
            this.groupBox1.Controls.Add(this.TbxNetPort);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.groupBox1.Location = new System.Drawing.Point(12, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(308, 135);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Интерфейс";
            // 
            // ipTbx
            // 
            this.ipTbx.Location = new System.Drawing.Point(131, 58);
            this.ipTbx.Name = "ipTbx";
            this.ipTbx.Size = new System.Drawing.Size(171, 24);
            this.ipTbx.TabIndex = 3;
            this.ipTbx.Text = "192.168.102.101";
            // 
            // ethernetRadio
            // 
            this.ethernetRadio.AutoSize = true;
            this.ethernetRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ethernetRadio.Location = new System.Drawing.Point(6, 58);
            this.ethernetRadio.Name = "ethernetRadio";
            this.ethernetRadio.Size = new System.Drawing.Size(89, 24);
            this.ethernetRadio.TabIndex = 2;
            this.ethernetRadio.TabStop = true;
            this.ethernetRadio.Text = "Ethernet";
            this.ethernetRadio.UseVisualStyleBackColor = true;
            // 
            // usbRadio
            // 
            this.usbRadio.AutoSize = true;
            this.usbRadio.Checked = true;
            this.usbRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.usbRadio.Location = new System.Drawing.Point(6, 22);
            this.usbRadio.Name = "usbRadio";
            this.usbRadio.Size = new System.Drawing.Size(61, 24);
            this.usbRadio.TabIndex = 1;
            this.usbRadio.TabStop = true;
            this.usbRadio.Text = "USB";
            this.usbRadio.UseVisualStyleBackColor = true;
            // 
            // Lbl_NetPort
            // 
            this.Lbl_NetPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_NetPort.AutoSize = true;
            this.Lbl_NetPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Lbl_NetPort.Location = new System.Drawing.Point(127, 98);
            this.Lbl_NetPort.Name = "Lbl_NetPort";
            this.Lbl_NetPort.Size = new System.Drawing.Size(48, 20);
            this.Lbl_NetPort.TabIndex = 29;
            this.Lbl_NetPort.Text = "Порт";
            // 
            // TbxNetPort
            // 
            this.TbxNetPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TbxNetPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.TbxNetPort.Location = new System.Drawing.Point(214, 95);
            this.TbxNetPort.Name = "TbxNetPort";
            this.TbxNetPort.Size = new System.Drawing.Size(88, 26);
            this.TbxNetPort.TabIndex = 4;
            this.TbxNetPort.Text = "9100";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Num_GapFeed);
            this.groupBox2.Controls.Add(this.Lbl_Label_H);
            this.groupBox2.Controls.Add(this.Lbl_GapFeed);
            this.groupBox2.Controls.Add(this.Num_Label_H);
            this.groupBox2.Controls.Add(this.Num_Label_W);
            this.groupBox2.Controls.Add(this.Lbl_Label_W);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.groupBox2.Location = new System.Drawing.Point(326, 72);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(203, 135);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Этикетка";
            // 
            // Num_GapFeed
            // 
            this.Num_GapFeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Num_GapFeed.Location = new System.Drawing.Point(112, 96);
            this.Num_GapFeed.Name = "Num_GapFeed";
            this.Num_GapFeed.Size = new System.Drawing.Size(78, 26);
            this.Num_GapFeed.TabIndex = 7;
            this.Num_GapFeed.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // Lbl_Label_H
            // 
            this.Lbl_Label_H.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_Label_H.AutoSize = true;
            this.Lbl_Label_H.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Lbl_Label_H.Location = new System.Drawing.Point(5, 62);
            this.Lbl_Label_H.Name = "Lbl_Label_H";
            this.Lbl_Label_H.Size = new System.Drawing.Size(102, 20);
            this.Lbl_Label_H.TabIndex = 33;
            this.Lbl_Label_H.Text = "Высота (мм)";
            // 
            // Lbl_GapFeed
            // 
            this.Lbl_GapFeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_GapFeed.AutoSize = true;
            this.Lbl_GapFeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Lbl_GapFeed.Location = new System.Drawing.Point(5, 98);
            this.Lbl_GapFeed.Name = "Lbl_GapFeed";
            this.Lbl_GapFeed.Size = new System.Drawing.Size(101, 20);
            this.Lbl_GapFeed.TabIndex = 33;
            this.Lbl_GapFeed.Text = "Разрыв (мм)";
            // 
            // Num_Label_H
            // 
            this.Num_Label_H.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Num_Label_H.Location = new System.Drawing.Point(112, 60);
            this.Num_Label_H.Name = "Num_Label_H";
            this.Num_Label_H.Size = new System.Drawing.Size(78, 26);
            this.Num_Label_H.TabIndex = 6;
            this.Num_Label_H.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // Num_Label_W
            // 
            this.Num_Label_W.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Num_Label_W.Location = new System.Drawing.Point(112, 24);
            this.Num_Label_W.Name = "Num_Label_W";
            this.Num_Label_W.Size = new System.Drawing.Size(78, 26);
            this.Num_Label_W.TabIndex = 5;
            this.Num_Label_W.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // Lbl_Label_W
            // 
            this.Lbl_Label_W.AutoSize = true;
            this.Lbl_Label_W.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Lbl_Label_W.Location = new System.Drawing.Point(5, 26);
            this.Lbl_Label_W.Name = "Lbl_Label_W";
            this.Lbl_Label_W.Size = new System.Drawing.Size(103, 20);
            this.Lbl_Label_W.TabIndex = 30;
            this.Lbl_Label_W.Text = "Ширина (мм)";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Yellow;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.Orange;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Orange;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.btnSave.Location = new System.Drawing.Point(359, 270);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(158, 46);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.btnPrint.Location = new System.Drawing.Point(18, 270);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(184, 46);
            this.btnPrint.TabIndex = 9;
            this.btnPrint.Text = "Тестовая печать";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // printerSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 337);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "printerSettings";
            this.Text = "printSettings";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.pbCaption, 0);
            this.Controls.SetChildIndex(this.lblCaption, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnPrint, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pbCaption)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Num_GapFeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_Label_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_Label_W)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox ipTbx;
        private System.Windows.Forms.RadioButton ethernetRadio;
        private System.Windows.Forms.RadioButton usbRadio;
        private System.Windows.Forms.Label Lbl_NetPort;
        private System.Windows.Forms.TextBox TbxNetPort;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label Lbl_Label_H;
        private System.Windows.Forms.NumericUpDown Num_Label_H;
        private System.Windows.Forms.NumericUpDown Num_Label_W;
        private System.Windows.Forms.Label Lbl_Label_W;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.NumericUpDown Num_GapFeed;
        private System.Windows.Forms.Label Lbl_GapFeed;
        private System.Windows.Forms.Button btnPrint;
    }
}