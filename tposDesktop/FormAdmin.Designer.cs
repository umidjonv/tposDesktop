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
            this.components = new System.ComponentModel.Container();
            System.Windows.Media.SolidColorBrush solidColorBrush1 = new System.Windows.Media.SolidColorBrush();
            this.showBtn = new System.Windows.Forms.Button();
            this.reportDate = new System.Windows.Forms.DateTimePicker();
            this.tabRasxod = new System.Windows.Forms.TabPage();
            this.expenseGrid = new System.Windows.Forms.DataGridView();
            this.tabOtchety = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.Chart1 = new LiveCharts.WinForms.CartesianChart();
            this.infoGrid = new System.Windows.Forms.DataGridView();
            this.tabTovar = new System.Windows.Forms.TabPage();
            this.btnExport = new System.Windows.Forms.Button();
            this.dgvTovar = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPrixod = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvTovarPrixod = new System.Windows.Forms.DataGridView();
            this.realizeGrid = new System.Windows.Forms.DataGridView();
            this.colBtnDel = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnCloseFaktura = new System.Windows.Forms.Button();
            this.lblRealizeSum = new System.Windows.Forms.Label();
            this.tabFaktura = new System.Windows.Forms.TabPage();
            this.dgvFakturaTovar = new System.Windows.Forms.DataGridView();
            this.dgvFaktura = new System.Windows.Forms.DataGridView();
            this.tabOstatok = new System.Windows.Forms.TabPage();
            this.btnExportBalance = new System.Windows.Forms.Button();
            this.lblBalanceSum = new System.Windows.Forms.Label();
            this.balanceGrid = new System.Windows.Forms.DataGridView();
            this.tabSpisaniye = new System.Windows.Forms.TabPage();
            this.dgvSpisaniye = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chbxSearchLimit = new System.Windows.Forms.CheckBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tbxFilter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.menuAdmin = new System.Windows.Forms.MenuStrip();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productTableAdapter1 = new tposDesktop.DataSetTposTableAdapters.productTableAdapter();
            this.infoTableAdapter1 = new tposDesktop.DataSetTposTableAdapters.infoTableAdapter();
            this.balanceviewTableAdapter1 = new tposDesktop.DataSetTposTableAdapters.balanceviewTableAdapter();
            this.realizeviewTableAdapter1 = new tposDesktop.DataSetTposTableAdapters.realizeviewTableAdapter();
            this.expenseviewTableAdapter1 = new tposDesktop.DataSetTposTableAdapters.expenseviewTableAdapter();
            this.realizeTableAdapter1 = new tposDesktop.DataSetTposTableAdapters.realizeTableAdapter();
            this.dataSetTpos = new tposDesktop.DataSetTpos();
            this.expenseviewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.realizeviewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.realizeviewBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.productviewTableAdapter1 = new tposDesktop.DataSetTposTableAdapters.productviewTableAdapter();
            this.btnLocations = new System.Windows.Forms.Button();
            this.tabRasxod.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expenseGrid)).BeginInit();
            this.tabOtchety.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.infoGrid)).BeginInit();
            this.tabTovar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTovar)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPrixod.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTovarPrixod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.realizeGrid)).BeginInit();
            this.tabFaktura.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFakturaTovar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaktura)).BeginInit();
            this.tabOstatok.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.balanceGrid)).BeginInit();
            this.tabSpisaniye.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpisaniye)).BeginInit();
            this.panel1.SuspendLayout();
            this.menuAdmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetTpos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.expenseviewBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.realizeviewBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.realizeviewBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // showBtn
            // 
            this.showBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.showBtn.BackColor = System.Drawing.Color.Orange;
            this.showBtn.FlatAppearance.BorderSize = 0;
            this.showBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.showBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.showBtn.Location = new System.Drawing.Point(608, 15);
            this.showBtn.Name = "showBtn";
            this.showBtn.Size = new System.Drawing.Size(94, 34);
            this.showBtn.TabIndex = 1;
            this.showBtn.Text = "Показать";
            this.showBtn.UseVisualStyleBackColor = false;
            this.showBtn.Click += new System.EventHandler(this.showBtn_Click);
            // 
            // reportDate
            // 
            this.reportDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.reportDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.reportDate.Location = new System.Drawing.Point(717, 24);
            this.reportDate.Name = "reportDate";
            this.reportDate.Size = new System.Drawing.Size(198, 26);
            this.reportDate.TabIndex = 1;
            // 
            // tabRasxod
            // 
            this.tabRasxod.Controls.Add(this.expenseGrid);
            this.tabRasxod.Location = new System.Drawing.Point(4, 29);
            this.tabRasxod.Margin = new System.Windows.Forms.Padding(2);
            this.tabRasxod.Name = "tabRasxod";
            this.tabRasxod.Size = new System.Drawing.Size(883, 310);
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
            this.expenseGrid.Size = new System.Drawing.Size(394, 349);
            this.expenseGrid.TabIndex = 13;
            this.expenseGrid.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_postPaint);
            // 
            // tabOtchety
            // 
            this.tabOtchety.Controls.Add(this.panel2);
            this.tabOtchety.Controls.Add(this.Chart1);
            this.tabOtchety.Controls.Add(this.infoGrid);
            this.tabOtchety.Location = new System.Drawing.Point(4, 29);
            this.tabOtchety.Margin = new System.Windows.Forms.Padding(2);
            this.tabOtchety.Name = "tabOtchety";
            this.tabOtchety.Padding = new System.Windows.Forms.Padding(2);
            this.tabOtchety.Size = new System.Drawing.Size(883, 310);
            this.tabOtchety.TabIndex = 1;
            this.tabOtchety.Text = "Информация о выручках";
            this.tabOtchety.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.Controls.Add(this.checkBox4);
            this.panel2.Controls.Add(this.checkBox3);
            this.panel2.Controls.Add(this.checkBox2);
            this.panel2.Controls.Add(this.checkBox1);
            this.panel2.Location = new System.Drawing.Point(657, 257);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(228, 71);
            this.panel2.TabIndex = 8;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Checked = true;
            this.checkBox4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox4.Location = new System.Drawing.Point(115, 40);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(92, 24);
            this.checkBox4.TabIndex = 3;
            this.checkBox4.Text = "Возврат";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Location = new System.Drawing.Point(115, 3);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(106, 24);
            this.checkBox3.TabIndex = 2;
            this.checkBox3.Text = "Наличные";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(3, 40);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(103, 24);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "Терминал";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(3, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(92, 24);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Выручка";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Chart1
            // 
            this.Chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Chart1.Hoverable = true;
            this.Chart1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Chart1.Location = new System.Drawing.Point(585, 5);
            this.Chart1.Name = "Chart1";
            solidColorBrush1.Color = System.Windows.Media.Color.FromArgb(((byte)(30)), ((byte)(30)), ((byte)(30)), ((byte)(30)));
            this.Chart1.ScrollBarFill = solidColorBrush1;
            this.Chart1.ScrollHorizontalFrom = 0D;
            this.Chart1.ScrollHorizontalTo = 0D;
            this.Chart1.ScrollMode = LiveCharts.ScrollMode.None;
            this.Chart1.ScrollVerticalFrom = 0D;
            this.Chart1.ScrollVerticalTo = 0D;
            this.Chart1.Size = new System.Drawing.Size(285, 236);
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
            this.infoGrid.Size = new System.Drawing.Size(530, 306);
            this.infoGrid.TabIndex = 6;
            this.infoGrid.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_postPaint);
            // 
            // tabTovar
            // 
            this.tabTovar.Controls.Add(this.btnExport);
            this.tabTovar.Controls.Add(this.dgvTovar);
            this.tabTovar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabTovar.Location = new System.Drawing.Point(4, 29);
            this.tabTovar.Margin = new System.Windows.Forms.Padding(2);
            this.tabTovar.Name = "tabTovar";
            this.tabTovar.Padding = new System.Windows.Forms.Padding(2);
            this.tabTovar.Size = new System.Drawing.Size(883, 310);
            this.tabTovar.TabIndex = 0;
            this.tabTovar.Text = "Товары";
            this.tabTovar.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(772, 3);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(93, 32);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "Экспорт";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // dgvTovar
            // 
            this.dgvTovar.AllowUserToAddRows = false;
            this.dgvTovar.AllowUserToDeleteRows = false;
            this.dgvTovar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTovar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTovar.BackgroundColor = System.Drawing.Color.White;
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
            this.dgvTovar.Size = new System.Drawing.Size(765, 306);
            this.dgvTovar.TabIndex = 4;
            this.dgvTovar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTovar_CellContentClick);
            this.dgvTovar.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgv_CellPainting);
            this.dgvTovar.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_postPaint);
            this.dgvTovar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.control_keyPress);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabTovar);
            this.tabControl1.Controls.Add(this.tabPrixod);
            this.tabControl1.Controls.Add(this.tabFaktura);
            this.tabControl1.Controls.Add(this.tabOtchety);
            this.tabControl1.Controls.Add(this.tabRasxod);
            this.tabControl1.Controls.Add(this.tabOstatok);
            this.tabControl1.Controls.Add(this.tabSpisaniye);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.Location = new System.Drawing.Point(16, 51);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(891, 343);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPrixod
            // 
            this.tabPrixod.Controls.Add(this.splitContainer1);
            this.tabPrixod.Controls.Add(this.lblRealizeSum);
            this.tabPrixod.Location = new System.Drawing.Point(4, 29);
            this.tabPrixod.Margin = new System.Windows.Forms.Padding(2);
            this.tabPrixod.Name = "tabPrixod";
            this.tabPrixod.Padding = new System.Windows.Forms.Padding(2);
            this.tabPrixod.Size = new System.Drawing.Size(883, 310);
            this.tabPrixod.TabIndex = 4;
            this.tabPrixod.Text = "Приход товаров";
            this.tabPrixod.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(2, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvTovarPrixod);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.realizeGrid);
            this.splitContainer1.Panel2.Controls.Add(this.btnCloseFaktura);
            this.splitContainer1.Size = new System.Drawing.Size(879, 306);
            this.splitContainer1.SplitterDistance = 292;
            this.splitContainer1.TabIndex = 17;
            // 
            // dgvTovarPrixod
            // 
            this.dgvTovarPrixod.AllowUserToAddRows = false;
            this.dgvTovarPrixod.AllowUserToDeleteRows = false;
            this.dgvTovarPrixod.AllowUserToResizeRows = false;
            this.dgvTovarPrixod.ColumnHeadersHeight = 40;
            this.dgvTovarPrixod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTovarPrixod.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvTovarPrixod.Location = new System.Drawing.Point(0, 0);
            this.dgvTovarPrixod.Margin = new System.Windows.Forms.Padding(2);
            this.dgvTovarPrixod.MultiSelect = false;
            this.dgvTovarPrixod.Name = "dgvTovarPrixod";
            this.dgvTovarPrixod.RowHeadersVisible = false;
            this.dgvTovarPrixod.RowHeadersWidth = 50;
            this.dgvTovarPrixod.RowTemplate.Height = 40;
            this.dgvTovarPrixod.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTovarPrixod.Size = new System.Drawing.Size(292, 306);
            this.dgvTovarPrixod.TabIndex = 15;
            this.dgvTovarPrixod.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTovar_CellContentClick);
            this.dgvTovarPrixod.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgv_CellPainting);
            this.dgvTovarPrixod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.control_keyPress);
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
            this.realizeGrid.Location = new System.Drawing.Point(0, 0);
            this.realizeGrid.Name = "realizeGrid";
            this.realizeGrid.ReadOnly = true;
            this.realizeGrid.RowHeadersVisible = false;
            this.realizeGrid.RowTemplate.Height = 40;
            this.realizeGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.realizeGrid.Size = new System.Drawing.Size(574, 226);
            this.realizeGrid.TabIndex = 14;
            this.realizeGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTovar_CellContentClick);
            this.realizeGrid.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgv_CellPainting);
            this.realizeGrid.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_postPaint);
            this.realizeGrid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.control_keyPress);
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
            this.btnCloseFaktura.Location = new System.Drawing.Point(415, 243);
            this.btnCloseFaktura.Margin = new System.Windows.Forms.Padding(2);
            this.btnCloseFaktura.Name = "btnCloseFaktura";
            this.btnCloseFaktura.Size = new System.Drawing.Size(159, 51);
            this.btnCloseFaktura.TabIndex = 6;
            this.btnCloseFaktura.Text = "Закрыть приход";
            this.btnCloseFaktura.UseVisualStyleBackColor = false;
            this.btnCloseFaktura.Click += new System.EventHandler(this.btnCloseFaktura_Click);
            // 
            // lblRealizeSum
            // 
            this.lblRealizeSum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRealizeSum.AutoSize = true;
            this.lblRealizeSum.Location = new System.Drawing.Point(431, 301);
            this.lblRealizeSum.Name = "lblRealizeSum";
            this.lblRealizeSum.Size = new System.Drawing.Size(105, 20);
            this.lblRealizeSum.TabIndex = 16;
            this.lblRealizeSum.Text = "Итого : 0 сум";
            // 
            // tabFaktura
            // 
            this.tabFaktura.Controls.Add(this.dgvFakturaTovar);
            this.tabFaktura.Controls.Add(this.dgvFaktura);
            this.tabFaktura.Location = new System.Drawing.Point(4, 29);
            this.tabFaktura.Margin = new System.Windows.Forms.Padding(2);
            this.tabFaktura.Name = "tabFaktura";
            this.tabFaktura.Padding = new System.Windows.Forms.Padding(2);
            this.tabFaktura.Size = new System.Drawing.Size(883, 310);
            this.tabFaktura.TabIndex = 5;
            this.tabFaktura.Text = "Фактуры";
            this.tabFaktura.UseVisualStyleBackColor = true;
            // 
            // dgvFakturaTovar
            // 
            this.dgvFakturaTovar.AllowUserToAddRows = false;
            this.dgvFakturaTovar.AllowUserToDeleteRows = false;
            this.dgvFakturaTovar.AllowUserToResizeRows = false;
            this.dgvFakturaTovar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFakturaTovar.ColumnHeadersHeight = 40;
            this.dgvFakturaTovar.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvFakturaTovar.Location = new System.Drawing.Point(512, 4);
            this.dgvFakturaTovar.Margin = new System.Windows.Forms.Padding(2);
            this.dgvFakturaTovar.MultiSelect = false;
            this.dgvFakturaTovar.Name = "dgvFakturaTovar";
            this.dgvFakturaTovar.RowHeadersVisible = false;
            this.dgvFakturaTovar.RowHeadersWidth = 50;
            this.dgvFakturaTovar.RowTemplate.Height = 40;
            this.dgvFakturaTovar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFakturaTovar.Size = new System.Drawing.Size(358, 318);
            this.dgvFakturaTovar.TabIndex = 16;
            // 
            // dgvFaktura
            // 
            this.dgvFaktura.AllowUserToAddRows = false;
            this.dgvFaktura.AllowUserToDeleteRows = false;
            this.dgvFaktura.AllowUserToResizeRows = false;
            this.dgvFaktura.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvFaktura.ColumnHeadersHeight = 40;
            this.dgvFaktura.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvFaktura.Location = new System.Drawing.Point(3, 4);
            this.dgvFaktura.Margin = new System.Windows.Forms.Padding(2);
            this.dgvFaktura.MultiSelect = false;
            this.dgvFaktura.Name = "dgvFaktura";
            this.dgvFaktura.RowHeadersVisible = false;
            this.dgvFaktura.RowHeadersWidth = 50;
            this.dgvFaktura.RowTemplate.Height = 40;
            this.dgvFaktura.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFaktura.Size = new System.Drawing.Size(504, 315);
            this.dgvFaktura.TabIndex = 16;
            this.dgvFaktura.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTovar_CellContentClick);
            // 
            // tabOstatok
            // 
            this.tabOstatok.Controls.Add(this.btnExportBalance);
            this.tabOstatok.Controls.Add(this.lblBalanceSum);
            this.tabOstatok.Controls.Add(this.balanceGrid);
            this.tabOstatok.Location = new System.Drawing.Point(4, 29);
            this.tabOstatok.Margin = new System.Windows.Forms.Padding(2);
            this.tabOstatok.Name = "tabOstatok";
            this.tabOstatok.Size = new System.Drawing.Size(883, 310);
            this.tabOstatok.TabIndex = 3;
            this.tabOstatok.Text = "Остаток";
            this.tabOstatok.UseVisualStyleBackColor = true;
            // 
            // btnExportBalance
            // 
            this.btnExportBalance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportBalance.Location = new System.Drawing.Point(718, 3);
            this.btnExportBalance.Name = "btnExportBalance";
            this.btnExportBalance.Size = new System.Drawing.Size(149, 31);
            this.btnExportBalance.TabIndex = 12;
            this.btnExportBalance.Text = "Экспорт остаток";
            this.btnExportBalance.UseVisualStyleBackColor = true;
            this.btnExportBalance.Click += new System.EventHandler(this.btnExportBalance_Click);
            // 
            // lblBalanceSum
            // 
            this.lblBalanceSum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBalanceSum.AutoSize = true;
            this.lblBalanceSum.Location = new System.Drawing.Point(697, 37);
            this.lblBalanceSum.Name = "lblBalanceSum";
            this.lblBalanceSum.Size = new System.Drawing.Size(170, 20);
            this.lblBalanceSum.TabIndex = 11;
            this.lblBalanceSum.Text = "Итого остаток : 0 сум";
            // 
            // balanceGrid
            // 
            this.balanceGrid.AllowUserToAddRows = false;
            this.balanceGrid.AllowUserToDeleteRows = false;
            this.balanceGrid.AllowUserToResizeRows = false;
            this.balanceGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.balanceGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.balanceGrid.Location = new System.Drawing.Point(0, 0);
            this.balanceGrid.MultiSelect = false;
            this.balanceGrid.Name = "balanceGrid";
            this.balanceGrid.ReadOnly = true;
            this.balanceGrid.RowHeadersVisible = false;
            this.balanceGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.balanceGrid.Size = new System.Drawing.Size(691, 318);
            this.balanceGrid.TabIndex = 8;
            this.balanceGrid.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_postPaint);
            // 
            // tabSpisaniye
            // 
            this.tabSpisaniye.Controls.Add(this.dgvSpisaniye);
            this.tabSpisaniye.Location = new System.Drawing.Point(4, 29);
            this.tabSpisaniye.Name = "tabSpisaniye";
            this.tabSpisaniye.Size = new System.Drawing.Size(883, 310);
            this.tabSpisaniye.TabIndex = 7;
            this.tabSpisaniye.Text = "Списание";
            this.tabSpisaniye.UseVisualStyleBackColor = true;
            // 
            // dgvSpisaniye
            // 
            this.dgvSpisaniye.AllowUserToAddRows = false;
            this.dgvSpisaniye.AllowUserToDeleteRows = false;
            this.dgvSpisaniye.AllowUserToResizeRows = false;
            this.dgvSpisaniye.ColumnHeadersHeight = 40;
            this.dgvSpisaniye.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSpisaniye.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvSpisaniye.Location = new System.Drawing.Point(0, 0);
            this.dgvSpisaniye.Margin = new System.Windows.Forms.Padding(2);
            this.dgvSpisaniye.MultiSelect = false;
            this.dgvSpisaniye.Name = "dgvSpisaniye";
            this.dgvSpisaniye.RowHeadersVisible = false;
            this.dgvSpisaniye.RowHeadersWidth = 50;
            this.dgvSpisaniye.RowTemplate.Height = 40;
            this.dgvSpisaniye.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSpisaniye.Size = new System.Drawing.Size(883, 310);
            this.dgvSpisaniye.TabIndex = 18;
            this.dgvSpisaniye.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTovar_CellContentClick);
            this.dgvSpisaniye.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgv_CellPainting);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chbxSearchLimit);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.tbxFilter);
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnLocations);
            this.panel1.Controls.Add(this.showBtn);
            this.panel1.Controls.Add(this.reportDate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 43);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(918, 405);
            this.panel1.TabIndex = 2;
            // 
            // chbxSearchLimit
            // 
            this.chbxSearchLimit.AutoSize = true;
            this.chbxSearchLimit.Location = new System.Drawing.Point(251, 29);
            this.chbxSearchLimit.Name = "chbxSearchLimit";
            this.chbxSearchLimit.Size = new System.Drawing.Size(100, 17);
            this.chbxSearchLimit.TabIndex = 17;
            this.chbxSearchLimit.Text = "Ограниченные";
            this.chbxSearchLimit.UseVisualStyleBackColor = true;
            this.chbxSearchLimit.CheckedChanged += new System.EventHandler(this.chbxSearchLimit_changes);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Lime;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAdd.ForeColor = System.Drawing.Color.Black;
            this.btnAdd.Location = new System.Drawing.Point(356, 16);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 34);
            this.btnAdd.TabIndex = 16;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.btnAdd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.control_keyPress);
            // 
            // tbxFilter
            // 
            this.tbxFilter.BackColor = System.Drawing.Color.White;
            this.tbxFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbxFilter.Location = new System.Drawing.Point(93, 24);
            this.tbxFilter.Margin = new System.Windows.Forms.Padding(2);
            this.tbxFilter.Name = "tbxFilter";
            this.tbxFilter.Size = new System.Drawing.Size(153, 26);
            this.tbxFilter.TabIndex = 0;
            this.tbxFilter.TextChanged += new System.EventHandler(this.tbx_ValueChanged);
            this.tbxFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.control_keyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Green;
            this.label1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 24);
            this.label1.TabIndex = 14;
            this.label1.Text = "Товар:";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Yellow;
            this.button1.BackgroundImage = global::tposDesktop.Properties.Resources.prodaja;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(790, 2);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(34, 33);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.menuRasxod_Click);
            // 
            // menuAdmin
            // 
            this.menuAdmin.BackColor = System.Drawing.Color.Green;
            this.menuAdmin.ImageScalingSize = new System.Drawing.Size(35, 35);
            this.menuAdmin.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuExit,
            this.настройкиToolStripMenuItem});
            this.menuAdmin.Location = new System.Drawing.Point(0, 0);
            this.menuAdmin.Name = "menuAdmin";
            this.menuAdmin.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuAdmin.Size = new System.Drawing.Size(918, 43);
            this.menuAdmin.TabIndex = 15;
            this.menuAdmin.Text = "menuStrip1";
            // 
            // menuExit
            // 
            this.menuExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.menuExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuExit.Image = global::tposDesktop.Properties.Resources.quit;
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(47, 39);
            this.menuExit.Text = "Выход";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Black", 12F);
            this.настройкиToolStripMenuItem.ForeColor = System.Drawing.Color.Yellow;
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(109, 39);
            this.настройкиToolStripMenuItem.Text = "Настройки";
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
            // realizeTableAdapter1
            // 
            this.realizeTableAdapter1.ClearBeforeFill = true;
            // 
            // dataSetTpos
            // 
            this.dataSetTpos.DataSetName = "DataSetTpos";
            this.dataSetTpos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // expenseviewBindingSource
            // 
            this.expenseviewBindingSource.DataMember = "expenseview";
            this.expenseviewBindingSource.DataSource = this.dataSetTpos;
            // 
            // realizeviewBindingSource
            // 
            this.realizeviewBindingSource.DataMember = "realizeview";
            this.realizeviewBindingSource.DataSource = this.dataSetTpos;
            // 
            // realizeviewBindingSource1
            // 
            this.realizeviewBindingSource1.DataMember = "realizeview";
            this.realizeviewBindingSource1.DataSource = this.dataSetTpos;
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.HeaderText = "";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.ReadOnly = true;
            // 
            // productviewTableAdapter1
            // 
            this.productviewTableAdapter1.ClearBeforeFill = true;
            // 
            // btnLocations
            // 
            this.btnLocations.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLocations.BackColor = System.Drawing.Color.Orange;
            this.btnLocations.FlatAppearance.BorderSize = 0;
            this.btnLocations.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.btnLocations.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLocations.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnLocations.Location = new System.Drawing.Point(508, 15);
            this.btnLocations.Name = "btnLocations";
            this.btnLocations.Size = new System.Drawing.Size(94, 34);
            this.btnLocations.TabIndex = 1;
            this.btnLocations.Text = "Точки";
            this.btnLocations.UseVisualStyleBackColor = false;
            this.btnLocations.Click += new System.EventHandler(this.btnLocations_Click);
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(918, 448);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
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
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.infoGrid)).EndInit();
            this.tabTovar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTovar)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPrixod.ResumeLayout(false);
            this.tabPrixod.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTovarPrixod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.realizeGrid)).EndInit();
            this.tabFaktura.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFakturaTovar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaktura)).EndInit();
            this.tabOstatok.ResumeLayout(false);
            this.tabOstatok.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.balanceGrid)).EndInit();
            this.tabSpisaniye.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpisaniye)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuAdmin.ResumeLayout(false);
            this.menuAdmin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetTpos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.expenseviewBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.realizeviewBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.realizeviewBindingSource1)).EndInit();
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
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label lblBalanceSum;
        private System.Windows.Forms.Label lblRealizeSum;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnExportBalance;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.TabPage tabFaktura;
        private System.Windows.Forms.DataGridView dgvFakturaTovar;
        private System.Windows.Forms.DataGridView dgvFaktura;
        private System.Windows.Forms.CheckBox chbxSearchLimit;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabPage tabSpisaniye;
        private System.Windows.Forms.DataGridView dgvSpisaniye;
        private DataSetTpos dataSetTpos;
        private System.Windows.Forms.BindingSource realizeviewBindingSource;
        private System.Windows.Forms.BindingSource expenseviewBindingSource;
        private System.Windows.Forms.BindingSource realizeviewBindingSource1;
        private DataSetTposTableAdapters.productviewTableAdapter productviewTableAdapter1;
        private System.Windows.Forms.Button btnLocations;
    }
}