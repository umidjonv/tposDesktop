namespace tposDesktop.Debts
{
    partial class DebtForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblClient = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClient = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbxDebts = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblAllSum = new System.Windows.Forms.Label();
            this.tbxPercentSum = new System.Windows.Forms.TextBox();
            this.btnSale = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvSums = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSums)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCaption
            // 
            this.pbCaption.Size = new System.Drawing.Size(942, 66);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnCancel.Location = new System.Drawing.Point(870, 0);
            // 
            // lblCaption
            // 
            this.lblCaption.Size = new System.Drawing.Size(102, 33);
            this.lblCaption.Text = "Долги";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(219)))), ((int)(((byte)(179)))));
            this.tabPage1.Location = new System.Drawing.Point(4, 33);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(352, 344);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Отсрочка";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 33);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(465, 492);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Долг";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblClient.Location = new System.Drawing.Point(187, 142);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(28, 24);
            this.lblClient.TabIndex = 22;
            this.lblClient.Text = "---";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(35, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 24);
            this.label2.TabIndex = 21;
            this.label2.Text = "Клиент :";
            // 
            // btnClient
            // 
            this.btnClient.BackColor = System.Drawing.Color.Yellow;
            this.btnClient.FlatAppearance.BorderSize = 0;
            this.btnClient.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.btnClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(91)))), ((int)(((byte)(139)))));
            this.btnClient.Location = new System.Drawing.Point(191, 84);
            this.btnClient.Name = "btnClient";
            this.btnClient.Size = new System.Drawing.Size(236, 34);
            this.btnClient.TabIndex = 20;
            this.btnClient.Text = "ВЫБРАТЬ КЛИЕНТА ->";
            this.btnClient.UseVisualStyleBackColor = false;
            this.btnClient.Click += new System.EventHandler(this.btnClient_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(35, 235);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 24);
            this.label1.TabIndex = 21;
            this.label1.Text = "Долги :";
            // 
            // lbxDebts
            // 
            this.lbxDebts.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbxDebts.FormattingEnabled = true;
            this.lbxDebts.ItemHeight = 24;
            this.lbxDebts.Location = new System.Drawing.Point(192, 235);
            this.lbxDebts.Name = "lbxDebts";
            this.lbxDebts.Size = new System.Drawing.Size(235, 148);
            this.lbxDebts.TabIndex = 23;
            this.lbxDebts.SelectedIndexChanged += new System.EventHandler(this.lbxDebts_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(35, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 24);
            this.label3.TabIndex = 21;
            this.label3.Text = "Общая сумма :";
            // 
            // lblAllSum
            // 
            this.lblAllSum.AutoSize = true;
            this.lblAllSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAllSum.Location = new System.Drawing.Point(187, 179);
            this.lblAllSum.Name = "lblAllSum";
            this.lblAllSum.Size = new System.Drawing.Size(20, 24);
            this.lblAllSum.TabIndex = 21;
            this.lblAllSum.Text = "0";
            // 
            // tbxPercentSum
            // 
            this.tbxPercentSum.BackColor = System.Drawing.Color.Lime;
            this.tbxPercentSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbxPercentSum.Location = new System.Drawing.Point(32, 401);
            this.tbxPercentSum.Name = "tbxPercentSum";
            this.tbxPercentSum.Size = new System.Drawing.Size(395, 44);
            this.tbxPercentSum.TabIndex = 25;
            this.tbxPercentSum.Text = "0";
            this.tbxPercentSum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxPercentSum.TextChanged += new System.EventHandler(this.tbxPercentSum_TextChanged);
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
            this.btnSale.Location = new System.Drawing.Point(32, 451);
            this.btnSale.Name = "btnSale";
            this.btnSale.Size = new System.Drawing.Size(395, 49);
            this.btnSale.TabIndex = 24;
            this.btnSale.Text = "Погасить";
            this.btnSale.UseVisualStyleBackColor = false;
            this.btnSale.Click += new System.EventHandler(this.btnSale_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Yellow;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(91)))), ((int)(((byte)(139)))));
            this.button1.Location = new System.Drawing.Point(689, 550);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(190, 49);
            this.button1.TabIndex = 24;
            this.button1.Text = "Закрыть";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // dgvSums
            // 
            this.dgvSums.AllowUserToAddRows = false;
            this.dgvSums.AllowUserToDeleteRows = false;
            this.dgvSums.AllowUserToResizeColumns = false;
            this.dgvSums.AllowUserToResizeRows = false;
            this.dgvSums.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSums.BackgroundColor = System.Drawing.Color.White;
            this.dgvSums.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSums.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvSums.ColumnHeadersHeight = 40;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSums.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvSums.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvSums.Location = new System.Drawing.Point(459, 142);
            this.dgvSums.Margin = new System.Windows.Forms.Padding(2);
            this.dgvSums.MultiSelect = false;
            this.dgvSums.Name = "dgvSums";
            this.dgvSums.RowHeadersVisible = false;
            this.dgvSums.RowHeadersWidth = 50;
            this.dgvSums.RowTemplate.Height = 40;
            this.dgvSums.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvSums.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSums.Size = new System.Drawing.Size(420, 358);
            this.dgvSums.TabIndex = 26;
            this.dgvSums.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSums_CellContentClick);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Yellow;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(91)))), ((int)(((byte)(139)))));
            this.btnClose.Location = new System.Drawing.Point(32, 552);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(395, 49);
            this.btnClose.TabIndex = 24;
            this.btnClose.Text = "Закрыть долг";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // DebtForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 636);
            this.Controls.Add(this.dgvSums);
            this.Controls.Add(this.tbxPercentSum);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSale);
            this.Controls.Add(this.lbxDebts);
            this.Controls.Add(this.lblAllSum);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblClient);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClient);
            this.Name = "DebtForm";
            this.ShowCaption = true;
            this.ShowCloseButton = true;
            this.Text = "DebtForm";
            this.Load += new System.EventHandler(this.DebtForm_Load);
            this.Controls.SetChildIndex(this.pbCaption, 0);
            this.Controls.SetChildIndex(this.lblCaption, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnClient, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.lblClient, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.lblAllSum, 0);
            this.Controls.SetChildIndex(this.lbxDebts, 0);
            this.Controls.SetChildIndex(this.btnSale, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.tbxPercentSum, 0);
            this.Controls.SetChildIndex(this.dgvSums, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pbCaption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSums)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClient;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbxDebts;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblAllSum;
        private System.Windows.Forms.TextBox tbxPercentSum;
        private System.Windows.Forms.Button btnSale;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvSums;
        private System.Windows.Forms.Button btnClose;
    }
}