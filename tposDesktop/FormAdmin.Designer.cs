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
            System.Windows.Media.SolidColorBrush solidColorBrush2 = new System.Windows.Media.SolidColorBrush();
            this.showBtn = new System.Windows.Forms.Button();
            this.reportDate = new System.Windows.Forms.DateTimePicker();
            this.tabRasxod = new System.Windows.Forms.TabPage();
            this.expenseGrid = new System.Windows.Forms.DataGridView();
            this.tabOtchety = new System.Windows.Forms.TabPage();
            this.Chart1 = new LiveCharts.WinForms.CartesianChart();
            this.infoGrid = new System.Windows.Forms.DataGridView();
            this.tabTovar = new System.Windows.Forms.TabPage();
            this.dgvTovar = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPrixod = new System.Windows.Forms.TabPage();
            this.dgvTovarPrixod = new System.Windows.Forms.DataGridView();
            this.realizeGrid = new System.Windows.Forms.DataGridView();
            this.colBtnDel = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnCloseFaktura = new System.Windows.Forms.Button();
            this.tabOstatok = new System.Windows.Forms.TabPage();
            this.balanceGrid = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.productTableAdapter1 = new tposDesktop.DataSetTposTableAdapters.productTableAdapter();
            this.infoTableAdapter1 = new tposDesktop.DataSetTposTableAdapters.infoTableAdapter();
            this.balanceviewTableAdapter1 = new tposDesktop.DataSetTposTableAdapters.balanceviewTableAdapter();
            this.realizeviewTableAdapter1 = new tposDesktop.DataSetTposTableAdapters.realizeviewTableAdapter();
            this.expenseviewTableAdapter1 = new tposDesktop.DataSetTposTableAdapters.expenseviewTableAdapter();
            this.tbxFilter = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.menuAdmin = new System.Windows.Forms.MenuStrip();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.realizeTableAdapter1 = new tposDesktop.DataSetTposTableAdapters.realizeTableAdapter();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tabRasxod.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expenseGrid)).BeginInit();
            this.tabOtchety.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.infoGrid)).BeginInit();
            this.tabTovar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTovar)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPrixod.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTovarPrixod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.realizeGrid)).BeginInit();
            this.tabOstatok.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.balanceGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.menuAdmin.SuspendLayout();
            this.SuspendLayout();
            // 
            // showBtn
            // 
            this.showBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.showBtn.Location = new System.Drawing.Point(458, 36);
            this.showBtn.Name = "showBtn";
            this.showBtn.Size = new System.Drawing.Size(93, 34);
            this.showBtn.TabIndex = 1;
            this.showBtn.Text = "Показать";
            this.showBtn.UseVisualStyleBackColor = true;
            this.showBtn.Click += new System.EventHandler(this.showBtn_Click);
            // 
            // reportDate
            // 
            this.reportDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.reportDate.Location = new System.Drawing.Point(254, 39);
            this.reportDate.Name = "reportDate";
            this.reportDate.Size = new System.Drawing.Size(198, 26);
            this.reportDate.TabIndex = 0;
            // 
            // tabRasxod
            // 
            this.tabRasxod.Controls.Add(this.expenseGrid);
            this.tabRasxod.Location = new System.Drawing.Point(4, 29);
            this.tabRasxod.Margin = new System.Windows.Forms.Padding(2);
            this.tabRasxod.Name = "tabRasxod";
            this.tabRasxod.Size = new System.Drawing.Size(806, 356);
            this.tabRasxod.TabIndex = 2;
            this.tabRasxod.Text = "Расход товаров";
            this.tabRasxod.UseVisualStyleBackColor = true;
            // 
            // expenseGrid
            // 
            this.expenseGrid.AllowUserToAddRows = false;
            this.expenseGrid.AllowUserToDeleteRows = false;
            this.expenseGrid.AllowUserToResizeRows = false;
            this.expenseGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.expenseGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.expenseGrid.Location = new System.Drawing.Point(3, 3);
            this.expenseGrid.Name = "expenseGrid";
            this.expenseGrid.ReadOnly = true;
            this.expenseGrid.RowHeadersVisible = false;
            this.expenseGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.expenseGrid.Size = new System.Drawing.Size(394, 320);
            this.expenseGrid.TabIndex = 13;
            this.expenseGrid.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_postPaint);
            // 
            // tabOtchety
            // 
            this.tabOtchety.Controls.Add(this.Chart1);
            this.tabOtchety.Controls.Add(this.infoGrid);
            this.tabOtchety.Location = new System.Drawing.Point(4, 29);
            this.tabOtchety.Margin = new System.Windows.Forms.Padding(2);
            this.tabOtchety.Name = "tabOtchety";
            this.tabOtchety.Padding = new System.Windows.Forms.Padding(2);
            this.tabOtchety.Size = new System.Drawing.Size(806, 356);
            this.tabOtchety.TabIndex = 1;
            this.tabOtchety.Text = "Информация о выручках";
            this.tabOtchety.UseVisualStyleBackColor = true;
            // 
            // Chart1
            // 
            this.Chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Chart1.Hoverable = true;
            this.Chart1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Chart1.Location = new System.Drawing.Point(538, 0);
            this.Chart1.Name = "Chart1";
            solidColorBrush2.Color = System.Windows.Media.Color.FromArgb(((byte)(30)), ((byte)(30)), ((byte)(30)), ((byte)(30)));
            this.Chart1.ScrollBarFill = solidColorBrush2;
            this.Chart1.ScrollHorizontalFrom = 0D;
            this.Chart1.ScrollHorizontalTo = 0D;
            this.Chart1.ScrollMode = LiveCharts.ScrollMode.None;
            this.Chart1.ScrollVerticalFrom = 0D;
            this.Chart1.ScrollVerticalTo = 0D;
            this.Chart1.Size = new System.Drawing.Size(269, 240);
            this.Chart1.TabIndex = 7;
            this.Chart1.Text = "cartesianChart1";
            // 
            // infoGrid
            // 
            this.infoGrid.AllowUserToAddRows = false;
            this.infoGrid.AllowUserToDeleteRows = false;
            this.infoGrid.AllowUserToResizeRows = false;
            this.infoGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.infoGrid.Dock = System.Windows.Forms.DockStyle.Left;
            this.infoGrid.Location = new System.Drawing.Point(2, 2);
            this.infoGrid.MultiSelect = false;
            this.infoGrid.Name = "infoGrid";
            this.infoGrid.ReadOnly = true;
            this.infoGrid.RowHeadersVisible = false;
            this.infoGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.infoGrid.Size = new System.Drawing.Size(530, 352);
            this.infoGrid.TabIndex = 6;
            this.infoGrid.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_postPaint);
            // 
            // tabTovar
            // 
            this.tabTovar.Controls.Add(this.dgvTovar);
            this.tabTovar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabTovar.Location = new System.Drawing.Point(4, 29);
            this.tabTovar.Margin = new System.Windows.Forms.Padding(2);
            this.tabTovar.Name = "tabTovar";
            this.tabTovar.Padding = new System.Windows.Forms.Padding(2);
            this.tabTovar.Size = new System.Drawing.Size(806, 356);
            this.tabTovar.TabIndex = 0;
            this.tabTovar.Text = "Товары";
            this.tabTovar.UseVisualStyleBackColor = true;
            // 
            // dgvTovar
            // 
            this.dgvTovar.AllowUserToAddRows = false;
            this.dgvTovar.AllowUserToDeleteRows = false;
            this.dgvTovar.AllowUserToResizeRows = false;
            this.dgvTovar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTovar.ColumnHeadersHeight = 40;
            this.dgvTovar.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvTovar.Location = new System.Drawing.Point(2, 2);
            this.dgvTovar.Margin = new System.Windows.Forms.Padding(2);
            this.dgvTovar.MultiSelect = false;
            this.dgvTovar.Name = "dgvTovar";
            this.dgvTovar.RowHeadersVisible = false;
            this.dgvTovar.RowHeadersWidth = 50;
            this.dgvTovar.RowTemplate.Height = 40;
            this.dgvTovar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTovar.Size = new System.Drawing.Size(383, 339);
            this.dgvTovar.TabIndex = 4;
            this.dgvTovar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTovar_CellContentClick);
            this.dgvTovar.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgv_CellPainting);
            this.dgvTovar.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_postPaint);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabTovar);
            this.tabControl1.Controls.Add(this.tabPrixod);
            this.tabControl1.Controls.Add(this.tabOtchety);
            this.tabControl1.Controls.Add(this.tabRasxod);
            this.tabControl1.Controls.Add(this.tabOstatok);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(814, 389);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPrixod
            // 
            this.tabPrixod.Controls.Add(this.dgvTovarPrixod);
            this.tabPrixod.Controls.Add(this.realizeGrid);
            this.tabPrixod.Controls.Add(this.btnCloseFaktura);
            this.tabPrixod.Location = new System.Drawing.Point(4, 29);
            this.tabPrixod.Margin = new System.Windows.Forms.Padding(2);
            this.tabPrixod.Name = "tabPrixod";
            this.tabPrixod.Padding = new System.Windows.Forms.Padding(2);
            this.tabPrixod.Size = new System.Drawing.Size(806, 356);
            this.tabPrixod.TabIndex = 4;
            this.tabPrixod.Text = "Приход товаров";
            this.tabPrixod.UseVisualStyleBackColor = true;
            // 
            // dgvTovarPrixod
            // 
            this.dgvTovarPrixod.AllowUserToAddRows = false;
            this.dgvTovarPrixod.AllowUserToDeleteRows = false;
            this.dgvTovarPrixod.AllowUserToResizeRows = false;
            this.dgvTovarPrixod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvTovarPrixod.ColumnHeadersHeight = 40;
            this.dgvTovarPrixod.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvTovarPrixod.Location = new System.Drawing.Point(3, 2);
            this.dgvTovarPrixod.Margin = new System.Windows.Forms.Padding(2);
            this.dgvTovarPrixod.MultiSelect = false;
            this.dgvTovarPrixod.Name = "dgvTovarPrixod";
            this.dgvTovarPrixod.RowHeadersVisible = false;
            this.dgvTovarPrixod.RowHeadersWidth = 50;
            this.dgvTovarPrixod.RowTemplate.Height = 40;
            this.dgvTovarPrixod.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTovarPrixod.Size = new System.Drawing.Size(423, 288);
            this.dgvTovarPrixod.TabIndex = 15;
            this.dgvTovarPrixod.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTovar_CellContentClick);
            this.dgvTovarPrixod.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgv_CellPainting);
            // 
            // realizeGrid
            // 
            this.realizeGrid.AllowUserToAddRows = false;
            this.realizeGrid.AllowUserToDeleteRows = false;
            this.realizeGrid.AllowUserToResizeRows = false;
            this.realizeGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.realizeGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.realizeGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBtnDel});
            this.realizeGrid.Location = new System.Drawing.Point(431, 3);
            this.realizeGrid.Name = "realizeGrid";
            this.realizeGrid.ReadOnly = true;
            this.realizeGrid.RowHeadersVisible = false;
            this.realizeGrid.RowTemplate.Height = 40;
            this.realizeGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.realizeGrid.Size = new System.Drawing.Size(371, 286);
            this.realizeGrid.TabIndex = 14;
            this.realizeGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTovar_CellContentClick);
            this.realizeGrid.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgv_CellPainting);
            this.realizeGrid.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_postPaint);
            // 
            // colBtnDel
            // 
            this.colBtnDel.HeaderText = "";
            this.colBtnDel.Name = "colBtnDel";
            this.colBtnDel.ReadOnly = true;
            // 
            // btnCloseFaktura
            // 
            this.btnCloseFaktura.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseFaktura.BackColor = System.Drawing.Color.Red;
            this.btnCloseFaktura.ForeColor = System.Drawing.Color.White;
            this.btnCloseFaktura.Location = new System.Drawing.Point(680, 295);
            this.btnCloseFaktura.Margin = new System.Windows.Forms.Padding(2);
            this.btnCloseFaktura.Name = "btnCloseFaktura";
            this.btnCloseFaktura.Size = new System.Drawing.Size(123, 62);
            this.btnCloseFaktura.TabIndex = 6;
            this.btnCloseFaktura.Text = "Закрыть приход";
            this.btnCloseFaktura.UseVisualStyleBackColor = false;
            this.btnCloseFaktura.Click += new System.EventHandler(this.btnCloseFaktura_Click);
            // 
            // tabOstatok
            // 
            this.tabOstatok.Controls.Add(this.balanceGrid);
            this.tabOstatok.Location = new System.Drawing.Point(4, 29);
            this.tabOstatok.Margin = new System.Windows.Forms.Padding(2);
            this.tabOstatok.Name = "tabOstatok";
            this.tabOstatok.Size = new System.Drawing.Size(806, 356);
            this.tabOstatok.TabIndex = 3;
            this.tabOstatok.Text = "Остаток";
            this.tabOstatok.UseVisualStyleBackColor = true;
            // 
            // balanceGrid
            // 
            this.balanceGrid.AllowUserToAddRows = false;
            this.balanceGrid.AllowUserToDeleteRows = false;
            this.balanceGrid.AllowUserToResizeRows = false;
            this.balanceGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.balanceGrid.Dock = System.Windows.Forms.DockStyle.Left;
            this.balanceGrid.Location = new System.Drawing.Point(0, 0);
            this.balanceGrid.MultiSelect = false;
            this.balanceGrid.Name = "balanceGrid";
            this.balanceGrid.ReadOnly = true;
            this.balanceGrid.RowHeadersVisible = false;
            this.balanceGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.balanceGrid.Size = new System.Drawing.Size(500, 356);
            this.balanceGrid.TabIndex = 8;
            this.balanceGrid.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_postPaint);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Location = new System.Drawing.Point(9, 74);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(814, 389);
            this.panel1.TabIndex = 2;
            // 
            // productTableAdapter1
            // 
            this.productTableAdapter1.ClearBeforeFill = true;
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
            // tbxFilter
            // 
            this.tbxFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbxFilter.Location = new System.Drawing.Point(82, 39);
            this.tbxFilter.Margin = new System.Windows.Forms.Padding(2);
            this.tbxFilter.Name = "tbxFilter";
            this.tbxFilter.Size = new System.Drawing.Size(153, 26);
            this.tbxFilter.TabIndex = 3;
            this.tbxFilter.TextChanged += new System.EventHandler(this.tbx_ValueChanged);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(656, 36);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(167, 34);
            this.button1.TabIndex = 4;
            this.button1.Text = "Перейти в расходы";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.menuRasxod_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(11, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "Товар:";
            // 
            // menuAdmin
            // 
            this.menuAdmin.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuExit});
            this.menuAdmin.Location = new System.Drawing.Point(0, 0);
            this.menuAdmin.Name = "menuAdmin";
            this.menuAdmin.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuAdmin.Size = new System.Drawing.Size(832, 24);
            this.menuAdmin.TabIndex = 15;
            this.menuAdmin.Text = "menuStrip1";
            // 
            // menuExit
            // 
            this.menuExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(53, 20);
            this.menuExit.Text = "Выход";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // realizeTableAdapter1
            // 
            this.realizeTableAdapter1.ClearBeforeFill = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAdd.Location = new System.Drawing.Point(556, 36);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(95, 34);
            this.btnAdd.TabIndex = 16;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 467);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbxFilter);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.showBtn);
            this.Controls.Add(this.reportDate);
            this.Controls.Add(this.menuAdmin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuAdmin;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Администратор";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAdmin_FormClosing);
            this.Load += new System.EventHandler(this.FormAdmin_Load);
            this.tabRasxod.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.expenseGrid)).EndInit();
            this.tabOtchety.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.infoGrid)).EndInit();
            this.tabTovar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTovar)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPrixod.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTovarPrixod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.realizeGrid)).EndInit();
            this.tabOstatok.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.balanceGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.menuAdmin.ResumeLayout(false);
            this.menuAdmin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataSetTposTableAdapters.productTableAdapter productTableAdapter1;
        private System.Windows.Forms.Button showBtn;
        private System.Windows.Forms.DateTimePicker reportDate;
        private DataSetTposTableAdapters.infoTableAdapter infoTableAdapter1;
        private DataSetTposTableAdapters.balanceviewTableAdapter balanceviewTableAdapter1;
        private DataSetTposTableAdapters.realizeviewTableAdapter realizeviewTableAdapter1;
        private DataSetTposTableAdapters.expenseviewTableAdapter expenseviewTableAdapter1;
        private System.Windows.Forms.TabPage tabRasxod;
        private System.Windows.Forms.DataGridView expenseGrid;
        private System.Windows.Forms.TabPage tabOtchety;
        private System.Windows.Forms.DataGridView infoGrid;
        private System.Windows.Forms.TabPage tabTovar;
        private System.Windows.Forms.DataGridView dgvTovar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabOstatok;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView balanceGrid;
        private System.Windows.Forms.TabPage tabPrixod;
        private System.Windows.Forms.Button btnCloseFaktura;
        private System.Windows.Forms.DataGridView realizeGrid;
        private System.Windows.Forms.TextBox tbxFilter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewButtonColumn colBtnDel;
        private System.Windows.Forms.DataGridView dgvTovarPrixod;
        private System.Windows.Forms.MenuStrip menuAdmin;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private LiveCharts.WinForms.CartesianChart Chart1;
        private DataSetTposTableAdapters.realizeTableAdapter realizeTableAdapter1;
        private System.Windows.Forms.Button btnAdd;
    }
}