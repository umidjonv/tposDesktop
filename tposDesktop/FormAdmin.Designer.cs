namespace tposDesktop
{
    partial class FormAdmin
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.showBtn = new System.Windows.Forms.Button();
            this.reportDate = new System.Windows.Forms.DateTimePicker();
            this.productTableAdapter1 = new tposDesktop.DataSetTposTableAdapters.productTableAdapter();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuRasxod = new System.Windows.Forms.ToolStripMenuItem();
            this.infoTableAdapter1 = new tposDesktop.DataSetTposTableAdapters.infoTableAdapter();
            this.balanceviewTableAdapter1 = new tposDesktop.DataSetTposTableAdapters.balanceviewTableAdapter();
            this.realizeviewTableAdapter1 = new tposDesktop.DataSetTposTableAdapters.realizeviewTableAdapter();
            this.expenseviewTableAdapter1 = new tposDesktop.DataSetTposTableAdapters.expenseviewTableAdapter();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.expenseGrid = new System.Windows.Forms.DataGridView();
            this.realizeGrid = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabOtchety = new System.Windows.Forms.TabPage();
            this.infoGrid = new System.Windows.Forms.DataGridView();
            this.tabTovar = new System.Windows.Forms.TabPage();
            this.dgvTovar = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabOstatok = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.balanceGrid = new System.Windows.Forms.DataGridView();
            this.tabPrixod = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expenseGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.realizeGrid)).BeginInit();
            this.tabOtchety.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.infoGrid)).BeginInit();
            this.tabTovar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTovar)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabOstatok.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.balanceGrid)).BeginInit();
            this.tabPrixod.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // showBtn
            // 
            this.showBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.showBtn.Location = new System.Drawing.Point(911, 40);
            this.showBtn.Margin = new System.Windows.Forms.Padding(4);
            this.showBtn.Name = "showBtn";
            this.showBtn.Size = new System.Drawing.Size(181, 30);
            this.showBtn.TabIndex = 1;
            this.showBtn.Text = "Показать";
            this.showBtn.UseVisualStyleBackColor = true;
            this.showBtn.Click += new System.EventHandler(this.showBtn_Click);
            // 
            // reportDate
            // 
            this.reportDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.reportDate.Location = new System.Drawing.Point(637, 40);
            this.reportDate.Margin = new System.Windows.Forms.Padding(4);
            this.reportDate.Name = "reportDate";
            this.reportDate.Size = new System.Drawing.Size(262, 30);
            this.reportDate.TabIndex = 0;
            // 
            // productTableAdapter1
            // 
            this.productTableAdapter1.ClearBeforeFill = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuRasxod});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1109, 31);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuRasxod
            // 
            this.menuRasxod.Name = "menuRasxod";
            this.menuRasxod.Size = new System.Drawing.Size(174, 27);
            this.menuRasxod.Text = "Перейти в расходы";
            this.menuRasxod.Click += new System.EventHandler(this.menuRasxod_Click);
            // 
            // infoTableAdapter1
            // 
            this.infoTableAdapter1.ClearBeforeFill = true;
            // 
            // balanceviewTableAdapter1
            // 
            this.balanceviewTableAdapter1.ClearBeforeFill = true;
            // 
            // realizeviewTableAdapter1
            // 
            this.realizeviewTableAdapter1.ClearBeforeFill = true;
            // 
            // expenseviewTableAdapter1
            // 
            this.expenseviewTableAdapter1.ClearBeforeFill = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.expenseGrid);
            this.tabPage1.Controls.Add(this.realizeGrid);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1077, 441);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Приход Расход";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // expenseGrid
            // 
            this.expenseGrid.AllowUserToAddRows = false;
            this.expenseGrid.AllowUserToResizeRows = false;
            this.expenseGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.expenseGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.expenseGrid.Location = new System.Drawing.Point(548, 43);
            this.expenseGrid.Margin = new System.Windows.Forms.Padding(4);
            this.expenseGrid.Name = "expenseGrid";
            this.expenseGrid.ReadOnly = true;
            this.expenseGrid.RowHeadersVisible = false;
            this.expenseGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.expenseGrid.Size = new System.Drawing.Size(525, 394);
            this.expenseGrid.TabIndex = 13;
            this.expenseGrid.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_postPaint);
            // 
            // realizeGrid
            // 
            this.realizeGrid.AllowUserToAddRows = false;
            this.realizeGrid.AllowUserToResizeRows = false;
            this.realizeGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.realizeGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.realizeGrid.Location = new System.Drawing.Point(4, 43);
            this.realizeGrid.Margin = new System.Windows.Forms.Padding(4);
            this.realizeGrid.Name = "realizeGrid";
            this.realizeGrid.ReadOnly = true;
            this.realizeGrid.RowHeadersVisible = false;
            this.realizeGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.realizeGrid.Size = new System.Drawing.Size(535, 394);
            this.realizeGrid.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(726, 14);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Расход товаров";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(174, 14);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 25);
            this.label3.TabIndex = 11;
            this.label3.Text = "Приход товаров";
            // 
            // tabOtchety
            // 
            this.tabOtchety.Controls.Add(this.infoGrid);
            this.tabOtchety.Location = new System.Drawing.Point(4, 34);
            this.tabOtchety.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabOtchety.Name = "tabOtchety";
            this.tabOtchety.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabOtchety.Size = new System.Drawing.Size(1077, 441);
            this.tabOtchety.TabIndex = 1;
            this.tabOtchety.Text = "Информация о выручках";
            this.tabOtchety.UseVisualStyleBackColor = true;
            // 
            // infoGrid
            // 
            this.infoGrid.AllowUserToAddRows = false;
            this.infoGrid.AllowUserToResizeRows = false;
            this.infoGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.infoGrid.Dock = System.Windows.Forms.DockStyle.Left;
            this.infoGrid.Location = new System.Drawing.Point(3, 2);
            this.infoGrid.Margin = new System.Windows.Forms.Padding(4);
            this.infoGrid.MultiSelect = false;
            this.infoGrid.Name = "infoGrid";
            this.infoGrid.ReadOnly = true;
            this.infoGrid.RowHeadersVisible = false;
            this.infoGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.infoGrid.Size = new System.Drawing.Size(707, 437);
            this.infoGrid.TabIndex = 6;
            this.infoGrid.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_postPaint);
            // 
            // tabTovar
            // 
            this.tabTovar.Controls.Add(this.dgvTovar);
            this.tabTovar.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabTovar.Location = new System.Drawing.Point(4, 34);
            this.tabTovar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabTovar.Name = "tabTovar";
            this.tabTovar.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabTovar.Size = new System.Drawing.Size(1077, 441);
            this.tabTovar.TabIndex = 0;
            this.tabTovar.Text = "Товары";
            this.tabTovar.UseVisualStyleBackColor = true;
            // 
            // dgvTovar
            // 
            this.dgvTovar.AllowUserToAddRows = false;
            this.dgvTovar.AllowUserToResizeRows = false;
            this.dgvTovar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvTovar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTovar.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTovar.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvTovar.Location = new System.Drawing.Point(3, 2);
            this.dgvTovar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvTovar.MultiSelect = false;
            this.dgvTovar.Name = "dgvTovar";
            this.dgvTovar.RowHeadersVisible = false;
            this.dgvTovar.RowHeadersWidth = 50;
            this.dgvTovar.RowTemplate.Height = 40;
            this.dgvTovar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTovar.Size = new System.Drawing.Size(761, 435);
            this.dgvTovar.TabIndex = 4;
            this.dgvTovar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTovar_CellContentClick);
            this.dgvTovar.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvTovar_CellPainting);
            this.dgvTovar.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_postPaint);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabTovar);
            this.tabControl1.Controls.Add(this.tabPrixod);
            this.tabControl1.Controls.Add(this.tabOtchety);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabOstatok);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1085, 479);
            this.tabControl1.TabIndex = 0;
            // 
            // tabOstatok
            // 
            this.tabOstatok.Controls.Add(this.balanceGrid);
            this.tabOstatok.Location = new System.Drawing.Point(4, 34);
            this.tabOstatok.Name = "tabOstatok";
            this.tabOstatok.Size = new System.Drawing.Size(1077, 441);
            this.tabOstatok.TabIndex = 3;
            this.tabOstatok.Text = "Остаток";
            this.tabOstatok.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Location = new System.Drawing.Point(12, 91);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1085, 479);
            this.panel1.TabIndex = 2;
            // 
            // balanceGrid
            // 
            this.balanceGrid.AllowUserToAddRows = false;
            this.balanceGrid.AllowUserToResizeRows = false;
            this.balanceGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.balanceGrid.Dock = System.Windows.Forms.DockStyle.Left;
            this.balanceGrid.Location = new System.Drawing.Point(0, 0);
            this.balanceGrid.Margin = new System.Windows.Forms.Padding(4);
            this.balanceGrid.MultiSelect = false;
            this.balanceGrid.Name = "balanceGrid";
            this.balanceGrid.ReadOnly = true;
            this.balanceGrid.RowHeadersVisible = false;
            this.balanceGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.balanceGrid.Size = new System.Drawing.Size(667, 441);
            this.balanceGrid.TabIndex = 8;
            // 
            // tabPrixod
            // 
            this.tabPrixod.Controls.Add(this.dataGridView1);
            this.tabPrixod.Location = new System.Drawing.Point(4, 34);
            this.tabPrixod.Name = "tabPrixod";
            this.tabPrixod.Padding = new System.Windows.Forms.Padding(3);
            this.tabPrixod.Size = new System.Drawing.Size(1077, 441);
            this.tabPrixod.TabIndex = 4;
            this.tabPrixod.Text = "Приход товаров";
            this.tabPrixod.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(0, 1);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 50;
            this.dataGridView1.RowTemplate.Height = 40;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(703, 438);
            this.dataGridView1.TabIndex = 5;
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 575);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.showBtn);
            this.Controls.Add(this.reportDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Администратор";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAdmin_FormClosing);
            this.Load += new System.EventHandler(this.FormAdmin_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expenseGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.realizeGrid)).EndInit();
            this.tabOtchety.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.infoGrid)).EndInit();
            this.tabTovar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTovar)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabOstatok.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.balanceGrid)).EndInit();
            this.tabPrixod.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataSetTposTableAdapters.productTableAdapter productTableAdapter1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuRasxod;
        private System.Windows.Forms.Button showBtn;
        private System.Windows.Forms.DateTimePicker reportDate;
        private DataSetTposTableAdapters.infoTableAdapter infoTableAdapter1;
        private DataSetTposTableAdapters.balanceviewTableAdapter balanceviewTableAdapter1;
        private DataSetTposTableAdapters.realizeviewTableAdapter realizeviewTableAdapter1;
        private DataSetTposTableAdapters.expenseviewTableAdapter expenseviewTableAdapter1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView expenseGrid;
        private System.Windows.Forms.DataGridView realizeGrid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabOtchety;
        private System.Windows.Forms.DataGridView infoGrid;
        private System.Windows.Forms.TabPage tabTovar;
        private System.Windows.Forms.DataGridView dgvTovar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabOstatok;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView balanceGrid;
        private System.Windows.Forms.TabPage tabPrixod;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}