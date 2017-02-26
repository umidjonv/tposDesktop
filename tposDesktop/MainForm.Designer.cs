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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.администраторToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbxSearchTovar = new System.Windows.Forms.TextBox();
            this.dgvTovar = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvExpense = new System.Windows.Forms.DataGridView();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnDolg = new System.Windows.Forms.Button();
            this.btnOplata = new System.Windows.Forms.Button();
            this.lblSum = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chbTerminal = new System.Windows.Forms.CheckBox();
            this.chbDolg = new System.Windows.Forms.CheckBox();
            this.tbxTerminal = new System.Windows.Forms.TextBox();
            this.dataSetTpos = new tposDesktop.DataSetTpos();
            this.ordersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ordersTableAdapter = new tposDesktop.DataSetTposTableAdapters.ordersTableAdapter();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTovar)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetTpos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.администраторToolStripMenuItem,
            this.exitMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(10, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(1081, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // администраторToolStripMenuItem
            // 
            this.администраторToolStripMenuItem.Name = "администраторToolStripMenuItem";
            this.администраторToolStripMenuItem.Size = new System.Drawing.Size(106, 19);
            this.администраторToolStripMenuItem.Text = "Администратор";
            // 
            // exitMenu
            // 
            this.exitMenu.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.exitMenu.Name = "exitMenu";
            this.exitMenu.Size = new System.Drawing.Size(53, 19);
            this.exitMenu.Text = "Выход";
            this.exitMenu.Click += new System.EventHandler(this.exitMenu_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.tbxSearchTovar);
            this.groupBox1.Controls.Add(this.dgvTovar);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(12, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(411, 572);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Имена товаров";
            // 
            // tbxSearchTovar
            // 
            this.tbxSearchTovar.Location = new System.Drawing.Point(6, 29);
            this.tbxSearchTovar.Name = "tbxSearchTovar";
            this.tbxSearchTovar.Size = new System.Drawing.Size(399, 26);
            this.tbxSearchTovar.TabIndex = 2;
            this.tbxSearchTovar.TextChanged += new System.EventHandler(this.tbxSearchTovar_TextChanged);
            // 
            // dgvTovar
            // 
            this.dgvTovar.AllowUserToAddRows = false;
            this.dgvTovar.AllowUserToResizeRows = false;
            this.dgvTovar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvTovar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTovar.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvTovar.Location = new System.Drawing.Point(6, 70);
            this.dgvTovar.MultiSelect = false;
            this.dgvTovar.Name = "dgvTovar";
            this.dgvTovar.RowHeadersVisible = false;
            this.dgvTovar.RowHeadersWidth = 50;
            this.dgvTovar.RowTemplate.Height = 40;
            this.dgvTovar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTovar.Size = new System.Drawing.Size(405, 490);
            this.dgvTovar.TabIndex = 0;
            this.dgvTovar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTovar_CellContentClick);
            this.dgvTovar.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvSchet_CellPainting);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.dgvExpense);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(523, 35);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(557, 474);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Счет";
            // 
            // dgvExpense
            // 
            this.dgvExpense.AllowUserToAddRows = false;
            this.dgvExpense.AllowUserToResizeRows = false;
            this.dgvExpense.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvExpense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExpense.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductName,
            this.productPrice});
            this.dgvExpense.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvExpense.Location = new System.Drawing.Point(3, 29);
            this.dgvExpense.Name = "dgvExpense";
            this.dgvExpense.RowHeadersVisible = false;
            this.dgvExpense.RowTemplate.Height = 40;
            this.dgvExpense.Size = new System.Drawing.Size(554, 433);
            this.dgvExpense.TabIndex = 1;
            this.dgvExpense.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvExpense_CellBeginEdit);
            this.dgvExpense.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExpense_CellContentClick);
            this.dgvExpense.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvSchet_CellPainting);
            this.dgvExpense.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExpense_CellValueChanged);
            this.dgvExpense.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvExpense_RowsAdded);
            // 
            // ProductName
            // 
            this.ProductName.HeaderText = "Наименование";
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            // 
            // productPrice
            // 
            this.productPrice.HeaderText = "Цена";
            this.productPrice.Name = "productPrice";
            this.productPrice.ReadOnly = true;
            // 
            // btnInsert
            // 
            this.btnInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnInsert.Location = new System.Drawing.Point(429, 114);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(91, 85);
            this.btnInsert.TabIndex = 3;
            this.btnInsert.Text = "Возврат";
            this.btnInsert.UseVisualStyleBackColor = true;
            // 
            // btnDolg
            // 
            this.btnDolg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDolg.Location = new System.Drawing.Point(429, 205);
            this.btnDolg.Name = "btnDolg";
            this.btnDolg.Size = new System.Drawing.Size(91, 85);
            this.btnDolg.TabIndex = 3;
            this.btnDolg.Text = "Долги";
            this.btnDolg.UseVisualStyleBackColor = true;
            this.btnDolg.Click += new System.EventHandler(this.btnDolg_Click);
            // 
            // btnOplata
            // 
            this.btnOplata.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOplata.BackColor = System.Drawing.Color.Red;
            this.btnOplata.ForeColor = System.Drawing.Color.White;
            this.btnOplata.Location = new System.Drawing.Point(965, 520);
            this.btnOplata.Name = "btnOplata";
            this.btnOplata.Size = new System.Drawing.Size(115, 76);
            this.btnOplata.TabIndex = 4;
            this.btnOplata.Text = "Оплата";
            this.btnOplata.UseVisualStyleBackColor = false;
            this.btnOplata.Click += new System.EventHandler(this.btnOplata_Click);
            // 
            // lblSum
            // 
            this.lblSum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSum.AutoSize = true;
            this.lblSum.Location = new System.Drawing.Point(632, 566);
            this.lblSum.Name = "lblSum";
            this.lblSum.Size = new System.Drawing.Size(20, 24);
            this.lblSum.TabIndex = 5;
            this.lblSum.Text = "0";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(521, 566);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Итого:";
            // 
            // chbTerminal
            // 
            this.chbTerminal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chbTerminal.AutoSize = true;
            this.chbTerminal.Location = new System.Drawing.Point(734, 520);
            this.chbTerminal.Name = "chbTerminal";
            this.chbTerminal.Size = new System.Drawing.Size(118, 28);
            this.chbTerminal.TabIndex = 6;
            this.chbTerminal.Text = "Терминал";
            this.chbTerminal.UseVisualStyleBackColor = true;
            this.chbTerminal.CheckedChanged += new System.EventHandler(this.chbTerminal_CheckedChanged);
            // 
            // chbDolg
            // 
            this.chbDolg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chbDolg.AutoSize = true;
            this.chbDolg.Location = new System.Drawing.Point(526, 520);
            this.chbDolg.Name = "chbDolg";
            this.chbDolg.Size = new System.Drawing.Size(73, 28);
            this.chbDolg.TabIndex = 6;
            this.chbDolg.Text = "Долг";
            this.chbDolg.UseVisualStyleBackColor = true;
            this.chbDolg.CheckedChanged += new System.EventHandler(this.chbDolg_CheckedChanged_1);
            // 
            // tbxTerminal
            // 
            this.tbxTerminal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbxTerminal.Location = new System.Drawing.Point(734, 568);
            this.tbxTerminal.Name = "tbxTerminal";
            this.tbxTerminal.Size = new System.Drawing.Size(173, 28);
            this.tbxTerminal.TabIndex = 7;
            this.tbxTerminal.Visible = false;
            this.tbxTerminal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Text_KeyPress);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 608);
            this.Controls.Add(this.tbxTerminal);
            this.Controls.Add(this.chbDolg);
            this.Controls.Add(this.chbTerminal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSum);
            this.Controls.Add(this.btnOplata);
            this.Controls.Add(this.btnDolg);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTovar)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpense)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetTpos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem администраторToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbxSearchTovar;
        private System.Windows.Forms.DataGridView dgvTovar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvExpense;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnDolg;
        private System.Windows.Forms.Button btnOplata;
        private DataSetTpos dataSetTpos;
        private System.Windows.Forms.BindingSource ordersBindingSource;
        private DataSetTposTableAdapters.ordersTableAdapter ordersTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn productPrice;
        private System.Windows.Forms.Label lblSum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem exitMenu;
        private System.Windows.Forms.CheckBox chbTerminal;
        private System.Windows.Forms.CheckBox chbDolg;
        private System.Windows.Forms.TextBox tbxTerminal;
    }
}