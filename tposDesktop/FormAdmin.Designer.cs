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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.showBtn = new System.Windows.Forms.Button();
            this.reportDate = new System.Windows.Forms.DateTimePicker();
            this.productTableAdapter1 = new tposDesktop.DataSetTposTableAdapters.productTableAdapter();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.перейтиВРасходыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoTableAdapter1 = new tposDesktop.DataSetTposTableAdapters.infoTableAdapter();
            this.balanceviewTableAdapter1 = new tposDesktop.DataSetTposTableAdapters.balanceviewTableAdapter();
            this.realizeviewTableAdapter1 = new tposDesktop.DataSetTposTableAdapters.realizeviewTableAdapter();
            this.expenseviewTableAdapter1 = new tposDesktop.DataSetTposTableAdapters.expenseviewTableAdapter();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabOtchety = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.infoGrid = new System.Windows.Forms.DataGridView();
            this.balanceGrid = new System.Windows.Forms.DataGridView();
            this.infoChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabTovar = new System.Windows.Forms.TabPage();
            this.dgvTovar = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.expenseGrid = new System.Windows.Forms.DataGridView();
            this.realizeGrid = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabOtchety.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.infoGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.balanceGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoChart)).BeginInit();
            this.tabTovar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTovar)).BeginInit();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expenseGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.realizeGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // showBtn
            // 
            this.showBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.showBtn.Location = new System.Drawing.Point(1198, 35);
            this.showBtn.Margin = new System.Windows.Forms.Padding(4);
            this.showBtn.Name = "showBtn";
            this.showBtn.Size = new System.Drawing.Size(184, 41);
            this.showBtn.TabIndex = 1;
            this.showBtn.Text = "Показать";
            this.showBtn.UseVisualStyleBackColor = true;
            // 
            // reportDate
            // 
            this.reportDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.reportDate.Location = new System.Drawing.Point(924, 41);
            this.reportDate.Margin = new System.Windows.Forms.Padding(4);
            this.reportDate.Name = "reportDate";
            this.reportDate.Size = new System.Drawing.Size(265, 30);
            this.reportDate.TabIndex = 0;
            this.reportDate.ValueChanged += new System.EventHandler(this.reportDate_ValueChanged);
            // 
            // productTableAdapter1
            // 
            this.productTableAdapter1.ClearBeforeFill = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.перейтиВРасходыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1385, 31);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // перейтиВРасходыToolStripMenuItem
            // 
            this.перейтиВРасходыToolStripMenuItem.Name = "перейтиВРасходыToolStripMenuItem";
            this.перейтиВРасходыToolStripMenuItem.Size = new System.Drawing.Size(174, 27);
            this.перейтиВРасходыToolStripMenuItem.Text = "Перейти в расходы";
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
            this.tabPage1.Size = new System.Drawing.Size(1377, 732);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Приход Расход";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabOtchety
            // 
            this.tabOtchety.Controls.Add(this.infoChart);
            this.tabOtchety.Controls.Add(this.balanceGrid);
            this.tabOtchety.Controls.Add(this.infoGrid);
            this.tabOtchety.Controls.Add(this.label2);
            this.tabOtchety.Controls.Add(this.label1);
            this.tabOtchety.Location = new System.Drawing.Point(4, 34);
            this.tabOtchety.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabOtchety.Name = "tabOtchety";
            this.tabOtchety.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabOtchety.Size = new System.Drawing.Size(1377, 732);
            this.tabOtchety.TabIndex = 1;
            this.tabOtchety.Text = "Информация о выручках";
            this.tabOtchety.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 59);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Информация о выручках";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1360, 59);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Остатки товаров";
            // 
            // infoGrid
            // 
            this.infoGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.infoGrid.Location = new System.Drawing.Point(16, 87);
            this.infoGrid.Margin = new System.Windows.Forms.Padding(4);
            this.infoGrid.Name = "infoGrid";
            this.infoGrid.Size = new System.Drawing.Size(667, 369);
            this.infoGrid.TabIndex = 6;
            // 
            // balanceGrid
            // 
            this.balanceGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.balanceGrid.Location = new System.Drawing.Point(1365, 87);
            this.balanceGrid.Margin = new System.Windows.Forms.Padding(4);
            this.balanceGrid.Name = "balanceGrid";
            this.balanceGrid.Size = new System.Drawing.Size(667, 369);
            this.balanceGrid.TabIndex = 7;
            // 
            // infoChart
            // 
            chartArea1.AlignmentOrientation = System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal;
            chartArea1.AxisX.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Lines;
            chartArea1.Name = "ChartArea1";
            this.infoChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.infoChart.Legends.Add(legend1);
            this.infoChart.Location = new System.Drawing.Point(691, 87);
            this.infoChart.Margin = new System.Windows.Forms.Padding(4);
            this.infoChart.Name = "infoChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Выручка";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Наличка";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Терминал";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Возврат";
            this.infoChart.Series.Add(series1);
            this.infoChart.Series.Add(series2);
            this.infoChart.Series.Add(series3);
            this.infoChart.Series.Add(series4);
            this.infoChart.Size = new System.Drawing.Size(667, 369);
            this.infoChart.TabIndex = 10;
            this.infoChart.Text = "chart1";
            // 
            // tabTovar
            // 
            this.tabTovar.Controls.Add(this.dgvTovar);
            this.tabTovar.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabTovar.Location = new System.Drawing.Point(4, 34);
            this.tabTovar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabTovar.Name = "tabTovar";
            this.tabTovar.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabTovar.Size = new System.Drawing.Size(1540, 732);
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
            this.dgvTovar.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvTovar.Location = new System.Drawing.Point(0, 0);
            this.dgvTovar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvTovar.MultiSelect = false;
            this.dgvTovar.Name = "dgvTovar";
            this.dgvTovar.RowHeadersVisible = false;
            this.dgvTovar.RowHeadersWidth = 50;
            this.dgvTovar.RowTemplate.Height = 40;
            this.dgvTovar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTovar.Size = new System.Drawing.Size(885, 526);
            this.dgvTovar.TabIndex = 4;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabTovar);
            this.tabControl1.Controls.Add(this.tabOtchety);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.Location = new System.Drawing.Point(0, 76);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1385, 770);
            this.tabControl1.TabIndex = 0;
            // 
            // expenseGrid
            // 
            this.expenseGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.expenseGrid.Location = new System.Drawing.Point(700, 43);
            this.expenseGrid.Margin = new System.Windows.Forms.Padding(4);
            this.expenseGrid.Name = "expenseGrid";
            this.expenseGrid.Size = new System.Drawing.Size(667, 369);
            this.expenseGrid.TabIndex = 13;
            // 
            // realizeGrid
            // 
            this.realizeGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.realizeGrid.Location = new System.Drawing.Point(14, 43);
            this.realizeGrid.Margin = new System.Windows.Forms.Padding(4);
            this.realizeGrid.Name = "realizeGrid";
            this.realizeGrid.Size = new System.Drawing.Size(667, 369);
            this.realizeGrid.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(694, 14);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Расход товаров";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 14);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 25);
            this.label3.TabIndex = 11;
            this.label3.Text = "Приход товаров";
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1385, 846);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.showBtn);
            this.Controls.Add(this.reportDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAdmin";
            this.Text = "FormAdmin";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAdmin_FormClosing);
            this.Load += new System.EventHandler(this.FormAdmin_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabOtchety.ResumeLayout(false);
            this.tabOtchety.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.infoGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.balanceGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.infoChart)).EndInit();
            this.tabTovar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTovar)).EndInit();
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.expenseGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.realizeGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataSetTposTableAdapters.productTableAdapter productTableAdapter1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem перейтиВРасходыToolStripMenuItem;
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
        private System.Windows.Forms.DataVisualization.Charting.Chart infoChart;
        private System.Windows.Forms.DataGridView balanceGrid;
        private System.Windows.Forms.DataGridView infoGrid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabTovar;
        private System.Windows.Forms.DataGridView dgvTovar;
        private System.Windows.Forms.TabControl tabControl1;
    }
}