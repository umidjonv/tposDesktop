﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Classes;
using Classes.DB;
using tposDesktop.DataSetTposTableAdapters;


namespace tposDesktop
{
    public partial class FormAdmin : Form
    {
        Scanner scanner;
        DBclass db;
        public FormAdmin()
        {
            InitializeComponent();
            if (UserValues.role != "admin")
                this.Dispose();
            db = new DBclass();
            DataView dv = new DataView(DBclass.DS.product);
            dv.RowFilter = "";
            dgvTovar.DataSource = dv;

            
            dv.RowFilter = "";
            dgvTovarPrixod.DataSource = dv;

            //DataGridViewButtonColumn cellBtn2 = new System.Windows.Forms.DataGridViewButtonColumn();
            //cellBtn2.HeaderText = "";
            //cellBtn2.Name = "colBtnDel";
            //cellBtn2.Width = 100;
            //realizeGrid.Columns.Add(cellBtn2);
            
            this.infoTableAdapter1.Fill(DBclass.DS.info);
            DataView info = new DataView(DBclass.DS.info);
            info.RowFilter = "";// "Dates = " + reportDate.Value.ToString("yyyy-MM-dd");
            info.Sort = "Dates desc";
            infoGrid.DataSource = info;
            

            this.realizeviewTableAdapter1.Fill(DBclass.DS.realizeview);
            DataView realize = new DataView(DBclass.DS.realizeview);
            realize.RowFilter = "fakturaDate = '" + reportDate.Value.ToString("yyyy-MM-dd") + "'";
            realizeGrid.DataSource = realize;

            this.expenseviewTableAdapter1.Fill(DBclass.DS.expenseview);
            DataView expense = new DataView(DBclass.DS.expenseview);
            expense.RowFilter = "expenseDate = '" + reportDate.Value.ToString("yyyy-MM-dd") + "'";
            expenseGrid.DataSource = expense;

            this.balanceviewTableAdapter1.Fill(DBclass.DS.balanceview);
            DataView balance = new DataView(DBclass.DS.balanceview);
            balance.RowFilter = "balanceDate = '" + reportDate.Value.ToString("yyyy-MM-dd") + "'";
            balanceGrid.DataSource = balance;

            
            
            
            try
            {
                scanner = new Scanner();
                scanner.ScannerEvent += scanner_ScannerEvent;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        delegate void SendInfoDel(string text);
        
        void scanner_ScannerEvent(object source, ScannerEventArgs e)
        {
            this.Invoke(new SendInfoDel(SendInfo), new object[] { e.GetInfo() });
        }

        private void SendInfo(string text)
        {
            string barcode = text;
            DataRow[] dr = DBclass.DS.product.Select("barcode = '" + barcode + "'");
            switch(tabControl1.SelectedTab.Name)
            {
                case "tabTovar":
                AddProduct(dr, barcode);
                break;
                case "tabPrixod":
                AddPrixod(dr, barcode);
                break;

            }
        }

        private void AddProduct(DataRow[] dr, string barcode)
        {
            if (dr.Length != 0)
            {
                DataSetTpos.productRow prRow = (DataSetTpos.productRow)dr[0];
                AddForm addForm = new AddForm(prRow);
                if (addForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    
                }
            }
            else
            {
                AddForm addForm = new AddForm(barcode);
                if (addForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    productTableAdapter daProduct = new productTableAdapter();
                    daProduct.Fill(DBclass.DS.product);


                }

            }
        }
        bool isPrixod = false;

        private void AddPrixod(DataRow[] dr, string barcode)
        {
            DataSetTpos.productRow prRow = (DataSetTpos.productRow)dr[0];

            if (!isPrixod&&MessageBox.Show("Начать приход товаров?", "Приход", MessageBoxButtons.YesNo,  MessageBoxIcon.Question)== System.Windows.Forms.DialogResult.Yes)
            {

                DataSetTpos.fakturaRow fkrow = DBclass.DS.faktura.NewfakturaRow();
                fkrow.fakturaDate = DateTime.Now;
                fakturaTableAdapter daFaktura = new fakturaTableAdapter();
                DBclass.DS.faktura.AddfakturaRow(fkrow);
                daFaktura.Update(DBclass.DS.faktura);
                daFaktura.Fill(DBclass.DS.faktura);
                
                isPrixod = true;

            }
            DataSetTpos.fakturaRow faktRow = (DataSetTpos.fakturaRow)DBclass.DS.faktura.Rows[0];

            DataView dv = realizeGrid.DataSource as DataView;
            dv.RowFilter = "fakturaId = " + faktRow.fakturaId;

            AddRealize addForm = new AddRealize(prRow, faktRow);
            if (addForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.realizeviewTableAdapter1.Fill(DBclass.DS.realizeview);
            }
            
        }
        private void FormAdmin_Load(object sender, EventArgs e)
        {
            this.productTableAdapter1.Fill(DBclass.DS.product);
            InitDataGridViews();

            int xLoc = (this.Width - panel1.Size.Width) / 2;
            int wid = panel1.Width;
            if(xLoc>30)
            { wid = (xLoc - 30) * 2;
            xLoc = 30;
            }
            panel1.Location = new Point(xLoc, panel1.Location.Y);
            panel1.Size = new Size(wid + panel1.Width, panel1.Height);
        }

        private void FormAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            scanner.isWorked = false;
            scanner.rd.ClosePort(scanner.port);
            if (Program.window_type != 2 && Program.window_type != 1)
                Program.window_type = 0;
        }

        private void InitDataGridViews()
        {
            //Tovar grid init
            dgvTovar.Columns["productId"].HeaderText = "№";
            dgvTovar.Columns["name"].HeaderText = "Товар";
            dgvTovar.Columns["price"].HeaderText = "Цена";
            dgvTovar.Columns["measureId"].Visible = false;
            dgvTovar.Columns["barcode"].HeaderText = "Штрихкод";
            dgvTovar.Columns["barcode"].Width = 150;
            dgvTovar.Columns["pack"].Visible = false;
            dgvTovar.Columns["status"].Visible = false;
            dgvTovar.Columns["productId"].Width = 50;
            dgvTovar.Columns["name"].Width = 300;
            dgvTovar.Columns["name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvTovar.Columns["price"].Width = 90;
            DataGridViewButtonColumn cellBtn = new System.Windows.Forms.DataGridViewButtonColumn();
            cellBtn.HeaderText = "";
            cellBtn.Name = "colBtn";
            cellBtn.Width = 100;
            dgvTovar.Columns.Add(cellBtn);


            //Tovar rasxod
            dgvTovarPrixod.Columns["productId"].HeaderText = "№";
            dgvTovarPrixod.Columns["name"].HeaderText = "Товар";
            dgvTovarPrixod.Columns["price"].HeaderText = "Цена";
            dgvTovarPrixod.Columns["measureId"].Visible = false;
            //dgvTovarPrixod.Columns["barcode"].HeaderText = "Штрихкод";
            dgvTovarPrixod.Columns["barcode"].Visible = false;
            dgvTovarPrixod.Columns["pack"].Visible = false;
            dgvTovarPrixod.Columns["status"].Visible = false;
            dgvTovarPrixod.Columns["productId"].Width = 50;
            dgvTovarPrixod.Columns["name"].Width = 300;
            dgvTovarPrixod.Columns["name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvTovarPrixod.Columns["price"].Width = 90;
            DataGridViewButtonColumn cellBtnRas = new System.Windows.Forms.DataGridViewButtonColumn();
            cellBtnRas.HeaderText = "";
            cellBtnRas.Name = "colBtn";
            cellBtnRas.Width = 100;
            dgvTovarPrixod.Columns.Add(cellBtnRas);

            //Info grid
            
            
            infoGrid.Columns["Dates"].HeaderText = "Товар";
            infoGrid.Columns["proceed"].HeaderText = "Выручка";
            infoGrid.Columns["proceed"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            infoGrid.Columns["nal"].HeaderText = "Наличные";
            infoGrid.Columns["back"].HeaderText = "Возврат";
            infoGrid.Columns["terminal"].DisplayIndex = 3;
            infoGrid.Columns["terminal"].HeaderText = "Терминал";

            //Realize grid
            
            realizeGrid.Columns["name"].HeaderText = "Наименование";
            realizeGrid.Columns["name"].DisplayIndex = 1;
            realizeGrid.Columns["name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            realizeGrid.Columns["fakturaDate"].Visible = false;
            
            realizeGrid.Columns["count"].HeaderText = "Кол-во";
            realizeGrid.Columns["count"].DisplayIndex = 2;
            realizeGrid.Columns["price"].HeaderText = "Цена";
            realizeGrid.Columns["price"].DisplayIndex = 3;
            //realizeGrid.Columns["name"].Width = 200;
            realizeGrid.Columns["fakturaId"].DisplayIndex = 0;
            realizeGrid.Columns["fakturaId"].HeaderText = "№ Прихода";
            realizeGrid.Columns["fakturaId"].Width = 70;
            realizeGrid.Columns["colBtnDel"].DisplayIndex = 5;
            //cellBtn2.DisplayIndex = 5;
            //Expense grid
            expenseGrid.Columns["name"].HeaderText = "Наименование";
            expenseGrid.Columns["name"].DisplayIndex = 0;
            expenseGrid.Columns["expenseDate"].Visible = false;
            expenseGrid.Columns["count"].HeaderText = "Кол-во";
            expenseGrid.Columns["name"].Width = 200;
            expenseGrid.Columns["pack"].Visible = false;
            expenseGrid.Columns["name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //Balance grid
            balanceGrid.Columns["name"].HeaderText = "Наименование";
            balanceGrid.Columns["name"].DisplayIndex = 0;

            balanceGrid.Columns["prodId"].HeaderText = "№";
            balanceGrid.Columns["prodId"].DisplayIndex = 0;
            balanceGrid.Columns["balanceDate"].Visible = false;
            balanceGrid.Columns["balanceId"].Visible = false;
            balanceGrid.Columns["productId"].Visible = false;
            balanceGrid.Columns["measureId"].Visible = false;
            balanceGrid.Columns["barcode"].Visible = false;
            balanceGrid.Columns["status"].Visible = false;
            balanceGrid.Columns["price"].Visible = false;
            balanceGrid.Columns["pack"].Visible = false;
            balanceGrid.Columns["endCount"].HeaderText = "Кол-во";
            balanceGrid.Columns["curEndCount"].HeaderText = "Кол-во";
            balanceGrid.Columns["name"].Width = 200;
            balanceGrid.Columns["name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
 
            
        }

        private void Filtering()
        {
            

            this.infoTableAdapter1.Fill(DBclass.DS.info);
            var info = infoGrid.DataSource as DataView;
            info.RowFilter = "Dates > '" + reportDate.Value.ToString("yyyy-MM-dd")+"'";
            info.Sort = "Dates desc";
            

            this.realizeviewTableAdapter1.Fill(DBclass.DS.realizeview);
            var realize = realizeGrid.DataSource as DataView;
            realize.RowFilter = "fakturaDate = '" + reportDate.Value.ToString("yyyy-MM-dd") + "'";
            

            this.expenseviewTableAdapter1.Fill(DBclass.DS.expenseview);
            DataView expense = expenseGrid.DataSource as DataView;
            expense.RowFilter = "expenseDate = '" + reportDate.Value.ToString("yyyy-MM-dd") + "'";
            

            this.balanceviewTableAdapter1.Fill(DBclass.DS.balanceview);
            DataView balance = balanceGrid.DataSource as DataView;
            balance.RowFilter = "balanceDate = '" + reportDate.Value.ToString("yyyy-MM-dd") + "'";
            

        }

        private void infoGraph()
        {
            DataTable table = DBclass.DS.Tables["info"];
            DataRow[] rows = table.Select();
            try
            {
                foreach (var val in rows)
                {
                    //this.infoChart.Series["Выручка"].Points.AddXY(val["Dates"].ToString(), (val["proceed"] == null) ? 1 : val["proceed"]);
                    //this.infoChart.Series["Наличка"].Points.AddXY(val["Dates"].ToString(), (val["nal"] == null) ? 1 : val["nal"]);
                    //this.infoChart.Series["Терминал"].Points.AddXY(val["Dates"].ToString(), (val["terminal"] == null) ? 1 : val["terminal"]);
                    //this.infoChart.Series["Возврат"].Points.AddXY(val["Dates"].ToString(), (val["back"] == null) ? 1 : val["back"]);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        

        private void reportDate_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void showBtn_Click(object sender, EventArgs e)
        {
            Filtering();
        }

        private void menuRasxod_Click(object sender, EventArgs e)
        {
            Program.window_type = 2;
            this.Close();
        }

        private void dgv_postPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            if (e.RowIndex % 2 == 1) style.BackColor = Color.FromArgb(192, 230, 214);
            else
                style.BackColor = Color.FromArgb(232, 232, 232);
            grid.Rows[e.RowIndex].DefaultCellStyle = style;
        }

        private void dgvTovar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                switch (dgv.Name)
                {
                    case "dgvTovar":
                        DataRow[] dr = DBclass.DS.product.Select("productId = " + dgv.Rows[e.RowIndex].Cells["productId"].Value.ToString());
                        AddProduct(dr, null);
                        break;
                    case "dgvTovarPrixod":
                        DataRow[] drP = DBclass.DS.product.Select("productId = " + dgv.Rows[e.RowIndex].Cells["productId"].Value.ToString());
                        AddPrixod(drP, null);
                        break;
                    case "realizeGrid":
                        //dgvCell.Value = "Удалить";
                        break;
                }
                
            }
        }

        private void dgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            var grid = sender as DataGridView;
            if (grid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                DataGridViewButtonCell dgvCell = (DataGridViewButtonCell)grid.Rows[e.RowIndex].Cells[e.ColumnIndex];
                switch (grid.Name)
                {
                    case "dgvTovar":
                        dgvCell.Value = "Изменить";
                        break;
                    case "dgvTovarPrixod":
                        dgvCell.Value = "В приход";
                        break;
                    case "realizeGrid":
                        dgvCell.Value = "Удалить";
                        break;
                }
                
                
                

                
            }
        }

        private void btnCloseFaktura_Click(object sender, EventArgs e)
        {
            if (isPrixod)
            {
                isPrixod = false;
                MessageBox.Show("Приход закрыт!");
            }
        }

        private void tbx_ValueChanged(object sender, EventArgs e)
        {
            TextBox tbx = sender as TextBox;
            switch (tabControl1.SelectedTab.Name)
            {
                case "tabTovar":
                    DataView dv = dgvTovar.DataSource as DataView;
                    dv.RowFilter = "name like '%" + tbx.Text + "%'";
                    break;
                case "tabPrixod":
                    DataView dvP = dgvTovar.DataSource as DataView;
                    dvP.RowFilter = "name like '%" + tbx.Text + "%'";
                    break;

            }
        }

       

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl tabControl = sender as TabControl;
            Filtering();
            switch(tabControl.SelectedTab.Name)
            {
                case "tabPrixod":
                    realizeGrid.Columns["colBtnDel"].DisplayIndex = 4;    
                    break;
                
            }

        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
