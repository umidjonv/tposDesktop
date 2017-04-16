using System;
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
using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Media;
using Classes;


namespace tposDesktop
{
    public partial class FormAdmin : Form
    {
        Scanner scanner;
        DBclass db;
        bool isExit = false;
        bool tproc = true;
        bool tnal = true;
        bool tterm = true;
        bool tback = true;
        public FormAdmin()
        {
            InitializeComponent();
            try
            {
                this.Icon = tposDesktop.Properties.Resources.mainIcon;
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


                liveChartLoad();
                balanceSumm();
                realizeSumm();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                isExit = true;
            }

            
            
            try
            {
                scanner = new Scanner();
                scanner.ScannerEvent += scanner_ScannerEvent;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                tscanner = new TextScanner();
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
            if (barcode == null) barcode = "-1";
            DataRow[] dr = DBclass.DS.product.Select("barcode = '" + barcode + "'");
            if (barcode == "-1") barcode = "";
            string tname = tabControl1.SelectedTab.Name;

            if (dr.Length == 0&&tname=="tabPrixod")
                tname = "tabTovar";
            switch(tname)
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
                    //productTableAdapter daProduct = new productTableAdapter();
                    //daProduct.Fill(DBclass.DS.product);


                }

            }
        }
        bool isPrixod = false;
        int idFaktura = -1;
        private void AddPrixod(DataRow[] dr, string barcode)
        {
            DataSetTpos.productRow prRow = (DataSetTpos.productRow)dr[0];
            FakturaOrgsForm orgForm = new FakturaOrgsForm();
            
            if (!isPrixod)
            {
                if (orgForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    DataSetTpos.fakturaRow fkrow = DBclass.DS.faktura.NewfakturaRow();
                    fkrow.providerId = orgForm.activeProviderRow.providerId;
                    fkrow.fakturaDate = DateTime.Now;
                    fakturaTableAdapter daFaktura = new fakturaTableAdapter();
                    DBclass.DS.faktura.AddfakturaRow(fkrow);
                    daFaktura.Update(DBclass.DS.faktura);
                    daFaktura.Fill(DBclass.DS.faktura);
                    idFaktura =  (DBclass.DS.faktura.Rows[0] as DataSetTpos.fakturaRow).fakturaId;
                    realizeGrid.Columns["colBtnDel"].Visible = true;
                    isPrixod = true;
                    
                }
                

            }
            if(isPrixod)
            {
                DataSetTpos.fakturaRow faktRow = (DataSetTpos.fakturaRow)DBclass.DS.faktura.Rows[0];

                DataView dv = realizeGrid.DataSource as DataView;
                dv.RowFilter = "fakturaId = " + faktRow.fakturaId;

                AddRealize addForm = new AddRealize(prRow, faktRow);
                if (addForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    realizeGrid.Columns["colBtnDel"].Visible = true;
                    this.realizeviewTableAdapter1.Fill(DBclass.DS.realizeview);
                }
            }
            
            
        }
        private void FormAdmin_Load(object sender, EventArgs e)
        {
            if (isExit)
            {
                Program.window_type = 1;
                this.Close();
                return;
            }
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
            if (scanner != null)
            {
                scanner.isWorked = false;
                scanner.rd.ClosePort(scanner.port);
            }
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
            DataGridViewButtonColumn cellBtnDel = new System.Windows.Forms.DataGridViewButtonColumn();
            cellBtnDel.HeaderText = "";
            cellBtnDel.Name = "colBtnDel";
            cellBtnDel.Width = 70;
            dgvTovar.Columns.Add(cellBtnDel);

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
            realizeGrid.Columns["realizeId"].Visible = false;
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
            realizeGrid.Columns["fakturaId"].HeaderText = "№ Фактуры";
            realizeGrid.Columns["fakturaId"].Width = 70;
            realizeGrid.Columns["colBtnDel"].DisplayIndex = 5;
            realizeGrid.Columns["productId"].Visible = false;
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
            balanceGrid.Columns["curEndCount"].HeaderText = "Сумма";
            balanceGrid.Columns["name"].Width = 200;
            balanceGrid.Columns["name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
 
            
        }

        private void balanceSumm()
        {
            int sum = 0;
            try
            {
                for (int i = 0; i < balanceGrid.Rows.Count; ++i)
                {
                    sum += Convert.ToInt32(balanceGrid.Rows[i].Cells[4].Value);
                }
                lblBalanceSum.Text = "Итого остаток : " +sum.ToString() + " сум";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void realizeSumm()
        {
            int sum = 0;
            try
            {
                for (int i = 0; i < realizeGrid.Rows.Count; ++i)
                {
                    sum += Convert.ToInt32(realizeGrid.Rows[i].Cells["price"].Value);
                }
                lblRealizeSum.Text = "Итого : "+sum.ToString() + " сум";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Filtering(string tab)
        {
            switch (tab)
            {
                case "tabTovar":

                    break;
                case "tabPrixod":
                    this.realizeviewTableAdapter1.Fill(DBclass.DS.realizeview);
                    var realize = realizeGrid.DataSource as DataView;
                    realize.RowFilter = "fakturaDate = '" + reportDate.Value.ToString("yyyy-MM-dd") + "'";
                    realizeGrid.Columns["colBtnDel"].Visible = false;
                    break;
                case "tabOtchety":
                    this.infoTableAdapter1.Fill(DBclass.DS.info);
                    var info = infoGrid.DataSource as DataView;
                    //info.RowFilter = "Dates > '" + reportDate.Value.ToString("yyyy-MM-dd")+"'";
                    info.Sort = "Dates desc";
                    break;
                case "tabRasxod":
                    this.expenseviewTableAdapter1.Fill(DBclass.DS.expenseview);
            DataView expense = expenseGrid.DataSource as DataView;
            expense.RowFilter = "expenseDate = '" + reportDate.Value.ToString("yyyy-MM-dd") + "'";
                    break;
                case "tabOstatok":
                    this.balanceviewTableAdapter1.Fill(DBclass.DS.balanceview);
                    DataView balance = balanceGrid.DataSource as DataView;
                    balance.RowFilter = "balanceDate = '" + reportDate.Value.ToString("yyyy-MM-dd") + "'";
                    break;
            }

            

            

            
            

            

            
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
            Filtering(tabControl1.SelectedTab.Name);
            balanceSumm();
            realizeSumm();
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
            if (e.RowIndex % 2 == 1) style.BackColor = System.Drawing.Color.FromArgb(192, 230, 214);
            else
                style.BackColor = System.Drawing.Color.FromArgb(232, 232, 232);
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
                        if (dgv.Columns[e.ColumnIndex].Name == "colBtn")
                        {
                            AddProduct(dr, null);
                        }
                        else if (dgv.Columns[e.ColumnIndex].Name == "colBtnDel")
                        {
                            if (MessageBox.Show("Удалить товар?") == System.Windows.Forms.DialogResult.Yes)
                            {
                                dr[0].Delete();
                                this.productTableAdapter1.Update(DBclass.DS.product);
                                this.productTableAdapter1.Fill(DBclass.DS.product);
                            }
                        }

                        
                        
                        break;
                    case "dgvTovarPrixod":
                        DataRow[] drP = DBclass.DS.product.Select("productId = " + dgv.Rows[e.RowIndex].Cells["productId"].Value.ToString());
                        
                        AddPrixod(drP, null);
                        break;
                    case "realizeGrid":
                        DataSetTpos.realizeRow[] rls = (DataSetTpos.realizeRow[])DBclass.DS.realize.Select("realizeId=" + dgv.Rows[e.RowIndex].Cells["realizeId"].Value.ToString());
                        rls[0].Delete();
                        
                        this.realizeTableAdapter1.Update(DBclass.DS.realize);
                        this.realizeviewTableAdapter1.Fill(DBclass.DS.realizeview);
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
                        switch (grid.Columns[e.ColumnIndex].Name)
                        {
                            case "colBtn":
                                dgvCell.Value = "Изменить";
                                break;
                            case "colBtnDel":
                                dgvCell.Value = "X";
                                break;
                        }
                        
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
                idFaktura = -1;
                MessageBox.Show("Приход закрыт!");
                realizeGrid.Columns["colBtnDel"].Visible = false;
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


        string selectedOldTab;
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl tabControl = sender as TabControl;
            Filtering(tabControl1.SelectedTab.Name);
            switch(tabControl.SelectedTab.Name)
            {
                case "tabPrixod":
                    realizeGrid.Columns["colBtnDel"].DisplayIndex = 4;
                    if (isPrixod)
                    {
                        realizeGrid.Columns["colBtnDel"].Visible = true;
                        DataSetTpos.fakturaRow faktRow = (DataSetTpos.fakturaRow)DBclass.DS.faktura.Rows[0];

                        DataView dv = realizeGrid.DataSource as DataView;
                        dv.RowFilter = "fakturaId = " + faktRow.fakturaId;
                    }
                    
                    break;

                                
            }
            tbxFilter.Focus();
            

        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void liveChartLoad()
        {
            Chart1.AxisX.Clear();
            Chart1.AxisY.Clear();
            DataTable table = DBclass.DS.Tables["info"];
            DataRow[] rows = table.Select();
            double[] tempproc = new double[rows.Count()];
            double[] tempnal = new double[rows.Count()];
            double[] tempterm = new double[rows.Count()];
            double[] tempback = new double[rows.Count()];
            ChartValues<double> proc = new ChartValues<double>();
            ChartValues<double> nal = new ChartValues<double>();
            ChartValues<double> term = new ChartValues<double>();
            ChartValues<double> back = new ChartValues<double>();
            string[] dates = new string[rows.Count()];
            int i = 0;
            try
            {
                foreach (var val in rows)
                {
                    tempproc[i] = (val["proceed"].ToString() == "") ? 0 : Convert.ToInt32(val["proceed"]);
                    tempnal[i] = (val["nal"].ToString() == "") ? 0 : Convert.ToInt32(val["nal"]);
                    tempterm[i] = (val["terminal"].ToString() == "") ? 0 : Convert.ToInt32(val["terminal"]);
                    tempback[i] = (val["back"].ToString() == "") ? 0 : Convert.ToInt32(val["back"]);
                    dates[i] = Convert.ToDateTime(val["Dates"]).ToString("dd.MM");
                    i++;
                }
                if (tproc == true)
                {
                    proc.AddRange(tempproc);
                }
                if (tnal == true)
                {
                    nal.AddRange(tempnal);
                }
                if (tterm == true)
                {
                    term.AddRange(tempterm);
                }
                if (tback == true)
                {
                    back.AddRange(tempback);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
            Chart1.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Выручка",
                    Values = proc
                },
                new LineSeries
                {
                    Title = "Наличка",
                    Values = nal,
                    PointGeometry = DefaultGeometries.Diamond,
                    PointGeometrySize = 10
                },
                new LineSeries
                {
                    Title = "Терминал",
                    Values = term,
                    PointGeometry = DefaultGeometries.Triangle,
                    PointGeometrySize = 10
                },
                new LineSeries
                {
                    Title = "Возврат",
                    Values = back,
                    PointGeometry = DefaultGeometries.Square,
                    PointGeometrySize = 10
                }
            };

            Chart1.AxisX.Add(new Axis
            {
                Title = "month",
                Labels = dates
            });

            Chart1.AxisY.Add(new Axis
            {
                Title = "",
                //LabelFormatter = value => value.ToString("C")
            });

            Chart1.LegendLocation = LegendLocation.Right;

            //modifying the series collection will animate and update the chart


            //modifying any series values will also animate and update the chart
            //Chart1.Series[2].Values.Add(5d);



        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SendInfo("-1");
            tbxFilter.Focus();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                tproc = true;
            }
            else
            {
                tproc = false;
            }
            liveChartLoad();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                tnal = true;
            }
            else
            {
                tnal = false;
            }
            liveChartLoad();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                tterm = true;
            }
            else
            {
                tterm = false;
            }
            liveChartLoad();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                tback = true;
            }
            else
            {
                tback = false;
            }
            liveChartLoad();
        }
        string curBarcode = "";
        bool beginBarcode = false;
        TextScanner tscanner;
        private void control_keyPress(object sender, KeyPressEventArgs e)
        {
            if (tscanner != null)
            {
                decimal dec;
                string st = "";
                if (sender is TextBox)
                    st = (sender as TextBox).Text;
                if (decimal.TryParse(st, out dec) || st == "")
                {
                    if (char.IsDigit(e.KeyChar))
                    {

                        if (!beginBarcode)
                        {
                            tscanner.Start();
                            beginBarcode = true;
                        }
                        tscanner.Symbol(e.KeyChar);
                        //if (Decimal.TryParse(curBarcode))
                        //{

                        //}
                    }
                }
                else { beginBarcode = false; tscanner.End(); }
                if (e.KeyChar == 13 && beginBarcode)
                {

                    tscanner.End();
                    if (tbxFilter.Text != ""&&tbxFilter.Focused)
                        SendInfo(tbxFilter.Text);
                    else
                    SendInfo(tscanner.barcode);
                    beginBarcode = false;
                    //tscanner.
                    curBarcode = "";
                    if (st != "")
                        (sender as TextBox).Text = "";
                }
            }
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var ds = new DataSet();
            var dt = new DataTable();
            //Получаем из  
            dt = ExportExcel.ToDataTable(dgvTovar, "PC");
            //Записываем в Dataset нашу полученную таблицу 
            ds.Tables.Add(dt);
            var save = new SaveFileDialog();
            save.Filter = "xls files (*.xls)|*.xls|All files|*.*";
            if (save.ShowDialog() == DialogResult.OK)
            {
                //Собсвенно вот тут и передаем DataSet в наш метод который формирует Excel-документ
                ExportExcel.CreateWorkbook(save.FileName, ds);
            }
        }

        private void btnExportBalance_Click(object sender, EventArgs e)
        {
            var ds = new DataSet();
            var dt = new DataTable();
            //Получаем из  
            dt = ExportExcel.ToDataTable(balanceGrid, "PC");
            //Записываем в Dataset нашу полученную таблицу 
            ds.Tables.Add(dt);
            var save = new SaveFileDialog();
            save.Filter = "xls files (*.xls)|*.xls|All files|*.*";
            if (save.ShowDialog() == DialogResult.OK)
            {
                //Собсвенно вот тут и передаем DataSet в наш метод который формирует Excel-документ
                ExportExcel.CreateWorkbook(save.FileName, ds);
            }
        }

    }
}
