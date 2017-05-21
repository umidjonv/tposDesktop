namespace tposDesktop
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCloseDay = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbxSearchPrice = new Classes.NumericTextBox();
            this.tbxSearchTovar = new System.Windows.Forms.TextBox();
            this.dgvTovar = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSum = new System.Windows.Forms.TextBox();
            this.btnDebt = new System.Windows.Forms.Button();
            this.btnTerminal = new System.Windows.Forms.Button();
            this.btnOplata = new System.Windows.Forms.Button();
            this.dgvExpense = new System.Windows.Forms.DataGridView();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDolg = new System.Windows.Forms.Button();
            this.btnVozvrat = new System.Windows.Forms.Button();
            this.soat = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.dataSetTpos = new tposDesktop.DataSetTpos();
            this.ordersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ordersTableAdapter = new tposDesktop.DataSetTposTableAdapters.ordersTableAdapter();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTovar)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpense)).BeginInit();
            this.panel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetTpos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DarkGreen;
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.menuStrip1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAdmin,
            this.exitMenu,
            this.menuCloseDay,
            this.menuSettings});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(10, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(1100, 52);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuAdmin
            // 
            this.menuAdmin.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuAdmin.ForeColor = System.Drawing.Color.Yellow;
            this.menuAdmin.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.menuAdmin.Name = "menuAdmin";
            this.menuAdmin.Size = new System.Drawing.Size(119, 44);
            this.menuAdmin.Text = "Администратор";
            this.menuAdmin.Visible = false;
            this.menuAdmin.Click += new System.EventHandler(this.администраторToolStripMenuItem_Click);
            // 
            // exitMenu
            // 
            this.exitMenu.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.exitMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.exitMenu.Image = global::tposDesktop.Properties.Resources.quit;
            this.exitMenu.Name = "exitMenu";
            this.exitMenu.Size = new System.Drawing.Size(52, 44);
            this.exitMenu.Text = "Выход";
            this.exitMenu.Click += new System.EventHandler(this.exitMenu_Click);
            // 
            // menuCloseDay
            // 
            this.menuCloseDay.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.menuCloseDay.ForeColor = System.Drawing.Color.Yellow;
            this.menuCloseDay.Name = "menuCloseDay";
            this.menuCloseDay.Size = new System.Drawing.Size(113, 44);
            this.menuCloseDay.Text = "Закрыть день";
            this.menuCloseDay.Click += new System.EventHandler(this.menuCloseDay_Click);
            // 
            // menuSettings
            // 
            this.menuSettings.ForeColor = System.Drawing.Color.Yellow;
            this.menuSettings.Name = "menuSettings";
            this.menuSettings.Size = new System.Drawing.Size(89, 44);
            this.menuSettings.Text = "Настройки";
            this.menuSettings.Click += new System.EventHandler(this.menuSettings_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.tbxSearchPrice);
            this.groupBox1.Controls.Add(this.tbxSearchTovar);
            this.groupBox1.Controls.Add(this.dgvTovar);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(12, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(517, 613);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // tbxSearchPrice
            // 
            this.tbxSearchPrice.ForeColor = System.Drawing.Color.Silver;
            this.tbxSearchPrice.Location = new System.Drawing.Point(316, 29);
            this.tbxSearchPrice.Name = "tbxSearchPrice";
            this.tbxSearchPrice.Size = new System.Drawing.Size(192, 26);
            this.tbxSearchPrice.TabIndex = 4;
            this.tbxSearchPrice.Text = "По цене";
            this.tbxSearchPrice.TextChanged += new System.EventHandler(this.tbxSearchTovar_TextChanged);
            this.tbxSearchPrice.Enter += new System.EventHandler(this.tbxEnter);
            this.tbxSearchPrice.Leave += new System.EventHandler(this.tbxLeave);
            // 
            // tbxSearchTovar
            // 
            this.tbxSearchTovar.ForeColor = System.Drawing.Color.Silver;
            this.tbxSearchTovar.Location = new System.Drawing.Point(6, 29);
            this.tbxSearchTovar.Name = "tbxSearchTovar";
            this.tbxSearchTovar.Size = new System.Drawing.Size(304, 26);
            this.tbxSearchTovar.TabIndex = 0;
            this.tbxSearchTovar.Text = "По имени";
            this.tbxSearchTovar.TextChanged += new System.EventHandler(this.tbxSearchTovar_TextChanged);
            this.tbxSearchTovar.Enter += new System.EventHandler(this.tbxEnter);
            this.tbxSearchTovar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgv_KeyPress);
            this.tbxSearchTovar.Leave += new System.EventHandler(this.tbxLeave);
            // 
            // dgvTovar
            // 
            this.dgvTovar.AllowUserToAddRows = false;
            this.dgvTovar.AllowUserToDeleteRows = false;
            this.dgvTovar.AllowUserToResizeColumns = false;
            this.dgvTovar.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvTovar.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTovar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTovar.BackgroundColor = System.Drawing.Color.Linen;
            this.dgvTovar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTovar.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvTovar.ColumnHeadersHeight = 35;
            this.dgvTovar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTovar.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTovar.GridColor = System.Drawing.Color.PaleGreen;
            this.dgvTovar.Location = new System.Drawing.Point(6, 61);
            this.dgvTovar.MultiSelect = false;
            this.dgvTovar.Name = "dgvTovar";
            this.dgvTovar.ReadOnly = true;
            this.dgvTovar.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvTovar.RowHeadersVisible = false;
            this.dgvTovar.RowHeadersWidth = 40;
            this.dgvTovar.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dgvTovar.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dgvTovar.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTovar.RowTemplate.Height = 45;
            this.dgvTovar.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTovar.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvTovar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTovar.Size = new System.Drawing.Size(502, 546);
            this.dgvTovar.TabIndex = 3;
            this.dgvTovar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTovar_CellContentClick);
            this.dgvTovar.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvSchet_CellPainting);
            this.dgvTovar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgv_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.dgvExpense);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(635, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(443, 613);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Счёт на расход ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblSum);
            this.panel1.Controls.Add(this.btnDebt);
            this.panel1.Controls.Add(this.btnTerminal);
            this.panel1.Controls.Add(this.btnOplata);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 398);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(437, 212);
            this.panel1.TabIndex = 7;
            // 
            // lblSum
            // 
            this.lblSum.BackColor = System.Drawing.Color.ForestGreen;
            this.lblSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 31F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSum.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblSum.Location = new System.Drawing.Point(0, 0);
            this.lblSum.Name = "lblSum";
            this.lblSum.Size = new System.Drawing.Size(473, 54);
            this.lblSum.TabIndex = 9;
            this.lblSum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnDebt
            // 
            this.btnDebt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDebt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDebt.BackColor = System.Drawing.Color.ForestGreen;
            this.btnDebt.FlatAppearance.BorderColor = System.Drawing.Color.LawnGreen;
            this.btnDebt.FlatAppearance.BorderSize = 0;
            this.btnDebt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow;
            this.btnDebt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDebt.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDebt.ForeColor = System.Drawing.Color.White;
            this.btnDebt.Location = new System.Drawing.Point(0, 136);
            this.btnDebt.Name = "btnDebt";
            this.btnDebt.Size = new System.Drawing.Size(230, 79);
            this.btnDebt.TabIndex = 2;
            this.btnDebt.Text = "В долг";
            this.btnDebt.UseVisualStyleBackColor = false;
            this.btnDebt.Click += new System.EventHandler(this.btnDebt_Click);
            // 
            // btnTerminal
            // 
            this.btnTerminal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTerminal.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnTerminal.BackColor = System.Drawing.Color.ForestGreen;
            this.btnTerminal.FlatAppearance.BorderColor = System.Drawing.Color.LawnGreen;
            this.btnTerminal.FlatAppearance.BorderSize = 0;
            this.btnTerminal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow;
            this.btnTerminal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTerminal.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnTerminal.ForeColor = System.Drawing.Color.White;
            this.btnTerminal.Location = new System.Drawing.Point(200, 136);
            this.btnTerminal.Name = "btnTerminal";
            this.btnTerminal.Size = new System.Drawing.Size(237, 76);
            this.btnTerminal.TabIndex = 2;
            this.btnTerminal.Text = "Терминал";
            this.btnTerminal.UseVisualStyleBackColor = false;
            this.btnTerminal.Click += new System.EventHandler(this.btnTerminal_Click);
            // 
            // btnOplata
            // 
            this.btnOplata.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOplata.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOplata.BackColor = System.Drawing.Color.Orange;
            this.btnOplata.FlatAppearance.BorderColor = System.Drawing.Color.LawnGreen;
            this.btnOplata.FlatAppearance.BorderSize = 0;
            this.btnOplata.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow;
            this.btnOplata.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOplata.Font = new System.Drawing.Font("Arial Black", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOplata.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.btnOplata.Location = new System.Drawing.Point(-3, 66);
            this.btnOplata.Name = "btnOplata";
            this.btnOplata.Size = new System.Drawing.Size(443, 70);
            this.btnOplata.TabIndex = 2;
            this.btnOplata.Text = "Оплата";
            this.btnOplata.UseVisualStyleBackColor = false;
            this.btnOplata.Click += new System.EventHandler(this.btnOplata_Click);
            // 
            // dgvExpense
            // 
            this.dgvExpense.AllowUserToAddRows = false;
            this.dgvExpense.AllowUserToResizeColumns = false;
            this.dgvExpense.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dgvExpense.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvExpense.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvExpense.BackgroundColor = System.Drawing.Color.Linen;
            this.dgvExpense.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvExpense.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvExpense.ColumnHeadersHeight = 35;
            this.dgvExpense.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductName,
            this.productPrice});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvExpense.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvExpense.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvExpense.GridColor = System.Drawing.Color.PaleGreen;
            this.dgvExpense.Location = new System.Drawing.Point(6, 29);
            this.dgvExpense.Name = "dgvExpense";
            this.dgvExpense.ReadOnly = true;
            this.dgvExpense.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvExpense.RowHeadersVisible = false;
            this.dgvExpense.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvExpense.RowTemplate.Height = 55;
            this.dgvExpense.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvExpense.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExpense.Size = new System.Drawing.Size(434, 370);
            this.dgvExpense.TabIndex = 1;
            this.dgvExpense.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvExpense_CellBeginEdit);
            this.dgvExpense.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExpense_CellContentClick);
            this.dgvExpense.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvSchet_CellPainting);
            this.dgvExpense.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExpense_CellValueChanged);
            this.dgvExpense.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvExpense_RowsAdded);
            this.dgvExpense.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgv_KeyPress);
            // 
            // ProductName
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ProductName.DefaultCellStyle = dataGridViewCellStyle4;
            this.ProductName.HeaderText = "Наименование";
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            this.ProductName.Width = 147;
            // 
            // productPrice
            // 
            this.productPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.NullValue = null;
            this.productPrice.DefaultCellStyle = dataGridViewCellStyle5;
            this.productPrice.FillWeight = 5F;
            this.productPrice.HeaderText = "Цена";
            this.productPrice.Name = "productPrice";
            this.productPrice.ReadOnly = true;
            this.productPrice.Width = 73;
            // 
            // btnDolg
            // 
            this.btnDolg.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnDolg.BackgroundImage = global::tposDesktop.Properties.Resources.qarz;
            this.btnDolg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDolg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDolg.Location = new System.Drawing.Point(3, 3);
            this.btnDolg.Name = "btnDolg";
            this.btnDolg.Size = new System.Drawing.Size(91, 91);
            this.btnDolg.TabIndex = 3;
            this.btnDolg.UseVisualStyleBackColor = false;
            this.btnDolg.Click += new System.EventHandler(this.btnDolg_Click);
            // 
            // btnVozvrat
            // 
            this.btnVozvrat.BackColor = System.Drawing.Color.Blue;
            this.btnVozvrat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVozvrat.BackgroundImage")));
            this.btnVozvrat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnVozvrat.FlatAppearance.BorderColor = System.Drawing.Color.Khaki;
            this.btnVozvrat.FlatAppearance.BorderSize = 3;
            this.btnVozvrat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnVozvrat.Location = new System.Drawing.Point(3, 100);
            this.btnVozvrat.Name = "btnVozvrat";
            this.btnVozvrat.Size = new System.Drawing.Size(91, 91);
            this.btnVozvrat.TabIndex = 3;
            this.btnVozvrat.UseVisualStyleBackColor = false;
            this.btnVozvrat.Click += new System.EventHandler(this.btnVozvrat_Click);
            // 
            // soat
            // 
            this.soat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.soat.AutoSize = true;
            this.soat.BackColor = System.Drawing.Color.DarkGreen;
            this.soat.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.soat.ForeColor = System.Drawing.Color.White;
            this.soat.Location = new System.Drawing.Point(769, 3);
            this.soat.Name = "soat";
            this.soat.Size = new System.Drawing.Size(99, 37);
            this.soat.TabIndex = 4;
            this.soat.Text = "00:00";
            this.soat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 52);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1100, 680);
            this.panel2.TabIndex = 7;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.btnDolg);
            this.flowLayoutPanel1.Controls.Add(this.btnVozvrat);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(535, 52);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(94, 201);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackColor = System.Drawing.Color.DarkGreen;
            this.pictureBox2.BackgroundImage = global::tposDesktop.Properties.Resources.logo_interface;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(539, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(0, 52);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // dataSetTpos
            // 
            this.dataSetTpos.DataSetName = "DataSetTpos";
            this.dataSetTpos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ordersBindingSource
            // 
            this.ordersBindingSource.DataMember = "orders";
            this.ordersBindingSource.DataSource = this.dataSetTpos;
            // 
            // ordersTableAdapter
            // 
            this.ordersTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewButtonColumn1.HeaderText = "Column1";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGreen;
            this.ClientSize = new System.Drawing.Size(1100, 732);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.soat);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Аптека";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTovar)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpense)).EndInit();
            this.panel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetTpos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuAdmin;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbxSearchTovar;
        private System.Windows.Forms.DataGridView dgvTovar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvExpense;
        private System.Windows.Forms.Button btnVozvrat;
        private System.Windows.Forms.Button btnDolg;
        private System.Windows.Forms.Button btnOplata;
        private DataSetTpos dataSetTpos;
        private System.Windows.Forms.BindingSource ordersBindingSource;
        private DataSetTposTableAdapters.ordersTableAdapter ordersTableAdapter;
        private System.Windows.Forms.ToolStripMenuItem exitMenu;
        private System.Windows.Forms.ToolStripMenuItem menuCloseDay;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label soat;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnDebt;
        private System.Windows.Forms.Button btnTerminal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn productPrice;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Classes.NumericTextBox tbxSearchPrice;
        private System.Windows.Forms.TextBox lblSum;
        private System.Windows.Forms.ToolStripMenuItem menuSettings;
    }
}