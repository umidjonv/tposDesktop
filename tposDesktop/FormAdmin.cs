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
using MySql.Data.MySqlClient;
using tposDesktop.SubForms;
using ZXing;
using ZXing.Common;
using ZXing.Rendering;
using System.Drawing.Imaging;
using System.IO;


namespace tposDesktop
{
    public partial class FormAdmin : Form
    {
        Scanner scanner;
        DBclass db;
        private EncodingOptions EncodingOptions { get; set; }
        private Type Renderer { get; set; }
        delegate void SendInfoDel(string text);
        bool isExit = false;
        //Diagramm
        bool tproc = true;
        bool tnal = true;
        bool tterm = true;
        bool tback = true;
        bool limit = false;

        //Prixod
        bool isPrixod = false;
        int idFaktura = -1;

        private void Update()
        {
            this.expenseviewTableAdapter1.Fill(DBclass.DS.expenseview);
            this.expenseTableAdapter1.Fill(DBclass.DS.expense);
            this.balanceviewTableAdapter1.Fill(DBclass.DS.balanceview);
            this.realizeviewTableAdapter1.Fill(DBclass.DS.realizeview);
 
        }

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


                DataView dvExp = new DataView(DBclass.DS.product);
                
                //int mx = Convert.ToInt32(DateTime.Now.Month) + 3;
                //string maxYear = DateTime.Now.Year.ToString();
                //string dt = mx.ToString() + "." + maxYear;
                //DateTime dt = DateTime.ParseExact(DateTime.Now.ToString(), "dd.mm.yyyy", System.Globalization.CultureInfo.InstalledUICulture);
                dvExp.RowFilter = "expiry is not null and expiry <= '" + Convert.ToDateTime(DateTime.Now.AddMonths(3)) + "'";
                dvExp.Sort = "expiry asc";
                dgvExpiry.DataSource = dvExp;


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
                realize.Sort = "realizeId DESC";
                realizeGrid.DataSource = realize;
                
                this.expenseviewTableAdapter1.Fill(DBclass.DS.expenseview);
                DataView expense = new DataView(DBclass.DS.expenseview);
                expense.RowFilter = "expenseDate = '" + reportDate.Value.ToString("yyyy-MM-dd") + "'";
                expenseGrid.DataSource = expense;

                this.expenseTableAdapter1.Fill(DBclass.DS.expense);
                DataView expenseView = new DataView(DBclass.DS.expense);
                expenseView.RowFilter = "expenseDate <= '" + Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59") + "' and expenseDate >= '" + Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00") + "'";
                dgvExpense.DataSource = expenseView;

                this.balanceviewTableAdapter1.Fill(DBclass.DS.balanceview);
                DataView balance = new DataView(DBclass.DS.balanceview);
                //balance.RowFilter = "balanceDate = '" + reportDate.Value.ToString("yyyy-MM-dd") + "'";
                balanceGrid.DataSource = balance;

                fakturaviewTableAdapter fviewda = new fakturaviewTableAdapter();
                fviewda.Fill(DBclass.DS.fakturaview);
                DataView fkview = new DataView(DBclass.DS.fakturaview);
                fkview.RowFilter = "fakturaDate = '" + reportDate.Value.ToString("yyyy-MM-dd") + "'";
                fkview.Sort = "fakturaId desc";
                dgvFaktura.DataSource = fkview;
                productviewTableAdapter prdv = new productviewTableAdapter();
                prdv.Fill(DBclass.DS.productview);
                DataView prV = new DataView(DBclass.DS.productview);
                prV.RowFilter = "";
                dgvSpisaniye.DataSource = prV;

                DataView dvRealize = new DataView(DBclass.DS.realizeview);
                dgvFakturaTovar.DataSource = dvRealize;

                ordersviewTableAdapter orV = new ordersviewTableAdapter();
                orV.Fill(DBclass.DS.ordersview);
                DataView ordersView = new DataView(DBclass.DS.ordersview);
                ordersView.RowFilter = "expenseDate <= '" + Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59") + "' and expenseDate >= '" + Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00") + "'";
                dgvOrders.DataSource = ordersView;
                loadBtn();
                liveChartLoad();
                pieChartLoad();
                balanceSumm();
                realizeSumm();
                Renderer = typeof(BitmapRenderer);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                isExit = true;
            }

            
            
            try
            {
                if (Properties.Settings.Default.IsCom)
                {
                    scanner = new Scanner();
                    scanner.ScannerEvent += scanner_ScannerEvent;
                }
                else
                {
                    tscanner = new TextScanner();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                tscanner = new TextScanner();
            }
        }
        
        
        void scanner_ScannerEvent(object source, ScannerEventArgs e)
        {
            this.Invoke(new SendInfoDel(SendInfo), new object[] { e.GetInfo() });
        }

        private void SendInfo(string text)
        {
            string barcode = text;
            if (barcode == null) barcode = "-1";
            DataRow[] dr;
            if (text.Length <= 5)
            {
                dr = DBclass.DS.product.Select("productId = '" + Convert.ToInt32(text.ToString()) + "'");                
            }
            else
            {
                dr = DBclass.DS.product.Select("barcode = '" + barcode + "'");
            }
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

                case "tabSpisaniye":
                    DBclass db = new DBclass();
                    db.AddProduct(dr, true, barcode);
                    db.Debt();
                    break;
            }
        }

        #region Product
        private void AddProduct(DataRow[] dr, string barcode)
        {
            AddForm addForm;
            if (dr.Length != 0)
            {
                DataSetTpos.productRow prRow = (DataSetTpos.productRow)dr[0];
                addForm = new AddForm(prRow);
                addForm.ShowDialog();
                
            }
            else
            {
                addForm = new AddForm(barcode);
                addForm.ShowDialog();
            }
        }
        #endregion

        #region Prixod
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
                int curPrice = prRow.price;
                AddRealize addForm = new AddRealize(prRow, faktRow);
                if (addForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //if (curPrice != prRow.price && prRow.price != 0)
                    //{
                    //    productTableAdapter prda = new productTableAdapter();
                    //    prda.Update(prRow);
                    //}
                    realizeGrid.Columns["colBtnDel"].Visible = true;
                    this.realizeviewTableAdapter1.Fill(DBclass.DS.realizeview);
                }

                
            }
            realizeSumm();
            
            
        }
        #endregion

        #region FormLoad, Init, Close
        private void FormAdmin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSetTpos.ordersview' table. You can move, or remove it, as needed.
            
            if (isExit)
            {
                Program.window_type = 1;
                this.Close();
                return;
            }
            this.productTableAdapter1.Fill(DBclass.DS.product);
            InitDataGridViews();
            
         //   BackgroundWorker bg = new BackgroundWorker();
            //ScannerEvent = new ScannerEventHandler(
           // bg.DoWork += expirePaint;
            //bg.RunWorkerAsync();
            int xLoc = (this.Width - panel1.Size.Width) / 2;
            int wid = panel1.Width;
            if(xLoc>30)
            { wid = (xLoc - 30) * 2;
            xLoc = 30;
            }
            panel1.Location = new Point(xLoc, panel1.Location.Y);
            panel1.Size = new Size(wid + panel1.Width, panel1.Height);
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
            dgvTovar.Columns["expiry"].Visible = false;
            dgvTovar.Columns["exp"].Visible = false;
            dgvTovar.Columns["limitProd"].Visible = false;
            dgvTovar.Columns["pack"].Visible = false;
            dgvTovar.Columns["status"].Visible = false;
            dgvTovar.Columns["productId"].Width = 50;
            dgvTovar.Columns["name"].Width = 300;
            dgvTovar.Columns["name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvTovar.Columns["price"].Width = 150;
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
            //Srok godnosti

            dgvExpiry.Columns["productId"].HeaderText = "№";
            dgvExpiry.Columns["name"].HeaderText = "Товар";
            dgvExpiry.Columns["price"].Visible = false;
            dgvExpiry.Columns["measureId"].Visible = false;
            dgvExpiry.Columns["barcode"].Visible = false;
            dgvExpiry.Columns["expiry"].HeaderText = "Срок годности";
            dgvExpiry.Columns["expiry"].Width = 50;
            dgvExpiry.Columns["expiry"].Visible = false;
            dgvExpiry.Columns["limitProd"].Visible = false;
            dgvExpiry.Columns["pack"].Visible = false;
            dgvExpiry.Columns["status"].Visible = false;
            dgvExpiry.Columns["productId"].Width = 50;
            dgvExpiry.Columns["name"].Width = 300;
            dgvExpiry.Columns["name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvExpiry.Columns["price"].Width = 150;


            //Tovar rasxod
            dgvTovarPrixod.Columns["productId"].HeaderText = "№";
            dgvTovarPrixod.Columns["name"].HeaderText = "Товар";
            dgvTovarPrixod.Columns["price"].HeaderText = "Цена";
            dgvTovarPrixod.Columns["measureId"].Visible = false;
            dgvTovarPrixod.Columns["expiry"].Visible = false;
            dgvTovarPrixod.Columns["exp"].Visible = false;
            //dgvTovarPrixod.Columns["barcode"].HeaderText = "Штрихкод";
            dgvTovarPrixod.Columns["barcode"].Visible = false;
            dgvTovarPrixod.Columns["pack"].Visible = false;
            dgvTovarPrixod.Columns["limitProd"].Visible = false;
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
            realizeGrid.Columns["price"].Visible = false;
            realizeGrid.Columns["fakturaPrice"].DisplayIndex = 3;
            realizeGrid.Columns["fakturaPrice"].HeaderText = "Ц/Фактуры";
            //realizeGrid.Columns["name"].Width = 200;
            realizeGrid.Columns["fakturaId"].DisplayIndex = 0;
            realizeGrid.Columns["fakturaId"].HeaderText = "№ Фактуры";
            realizeGrid.Columns["fakturaId"].Width = 70;
            realizeGrid.Columns["colBtnDel"].DisplayIndex = 5;
            realizeGrid.Columns["soldPrice"].HeaderText = "Ц/продажу";
            realizeGrid.Columns["soldPrice"].DisplayIndex = 6;
            realizeGrid.Columns["soldPrice"].Width = 100;
            realizeGrid.Columns["productId"].Visible = false;
            realizeGrid.Columns["expiryDate"].HeaderText = "Срок годности";
            realizeGrid.Columns["barcode"].Visible = false;
            realizeGrid.Columns["providerId"].Visible = false;
            
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
            balanceGrid.Columns["barcode"].HeaderText = "Штрих-код";
            balanceGrid.Columns["barcode"].Width = 150;
            balanceGrid.Columns["status"].Visible = false;
            balanceGrid.Columns["price"].Visible = false;
            balanceGrid.Columns["pack"].Visible = false;
            balanceGrid.Columns["endCount"].HeaderText = "Кол-во";
            balanceGrid.Columns["curEndCount"].HeaderText = "Сумма";
            balanceGrid.Columns["name"].Width = 200;
            balanceGrid.Columns["name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //fakturaTovar
            dgvFakturaTovar.Columns["name"].HeaderText = "Товар";
            dgvFakturaTovar.Columns["fakturaId"].HeaderText = "№ фактуры";
            dgvFakturaTovar.Columns["fakturaDate"].HeaderText = "Дата";
            dgvFakturaTovar.Columns["realizeId"].Visible = false;
            dgvFakturaTovar.Columns["productId"].Visible = false;
            dgvFakturaTovar.Columns["providerId"].Visible = false;
            dgvFakturaTovar.Columns["barcode"].Visible = false;
            dgvFakturaTovar.Columns["fakturaPrice"].HeaderText = "Ц/Фактуры";
            dgvFakturaTovar.Columns["soldPrice"].HeaderText = "Ц/Продажи";
            dgvFakturaTovar.Columns["price"].HeaderText = "Цена";
            dgvFakturaTovar.Columns["count"].HeaderText = "Кол.";
            dgvFakturaTovar.Columns["name"].Width = 250;
            dgvFakturaTovar.Columns["fakturaDate"].Width = 150;
            dgvFakturaTovar.Columns["name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //dgvFaktura
            dgvFaktura.Columns["orgName"].HeaderText = "Поставщик";
            dgvFaktura.Columns["fakturaId"].HeaderText = "№ фактуры";
            dgvFaktura.Columns["fakturaDate"].HeaderText = "Дата";
            
            
            //dgvFaktura.Columns["fakturaDate"].HeaderText = "Тел.";
            dgvFaktura.Columns["phone"].Visible = false;
            dgvFaktura.Columns["orgName"].Width = 250;
            dgvFaktura.Columns["fakturaDate"].Width = 150;


            dgvSpisaniye.Columns["productId"].HeaderText = "№";
            dgvSpisaniye.Columns["name"].HeaderText = "Товар";
            dgvSpisaniye.Columns["price"].HeaderText = "Цена";
            dgvSpisaniye.Columns["endCount"].HeaderText = "Кол.";
            dgvSpisaniye.Columns["balanceDate"].Visible = false;
            dgvSpisaniye.Columns["barcode"].HeaderText = "штрих-код";
            dgvSpisaniye.Columns["barcode"].Width = 200;

            dgvSpisaniye.Columns["productId"].Width = 50;
            dgvSpisaniye.Columns["name"].Width = 215;
            dgvSpisaniye.Columns["name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSpisaniye.Columns["price"].Width = 70;
            Classes.GridCells.ImageButtonColumn cellBtnSp = new Classes.GridCells.ImageButtonColumn();
            cellBtnSp.HeaderText = "";
            cellBtnSp.Name = "colBtnSpisat";
            cellBtnSp.Width = 100;

            dgvSpisaniye.Columns.Add(cellBtnSp);
            ///Change end!

            dgvExpense.Columns["expenseId"].Width = 50;
            dgvExpense.Columns["expenseId"].HeaderText = "№";
            dgvExpense.Columns["expenseDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvExpense.Columns["expenseDate"].HeaderText = "Время";
            dgvExpense.Columns["Debt"].Visible = false;
            dgvExpense.Columns["Comment"].Visible = false;
            dgvExpense.Columns["off"].Visible = false;
            dgvExpense.Columns["expType"].Visible = false;
            dgvExpense.Columns["terminal"].Visible = false;
            dgvExpense.Columns["expsum"].Width = 100;
            dgvExpense.Columns["expsum"].HeaderText = "Сумма";
            dgvExpense.Columns["status"].Visible = false;
            DataGridViewTextBoxColumn dtbx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dtbx.HeaderText = "Тип";
            dtbx.Name = "expTypeStr";
            dtbx.Width = 120;
            dtbx.DisplayIndex = 2;
            dgvExpense.Columns.Add(dtbx);

            dgvOrders.Columns["expenseId"].Visible = false;
            dgvOrders.Columns["expenseDate"].Visible = false;
            dgvOrders.Columns["name"].HeaderText = "Наименование";
            dgvOrders.Columns["name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvOrders.Columns["cnt"].HeaderText = "Кол-во";
            dgvOrders.Columns["cnt"].Width = 100;
            dgvOrders.Columns["orderSumm"].HeaderText = "Сумма";
            dgvOrders.Columns["orderSumm"].Width = 150;


        }

        private void FormAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (scanner != null)
            {
                scanner.isWorked = false;
                scanner.rd.ClosePort(scanner.port);
            }
            if (isPrixod)
            {
                isPrixod = false;
                DBclass dbC = new DBclass();
                dbC.triggerExecute("FakturaTrigger", idFaktura);
                idFaktura = -1;
                
                
            }
            if (Program.window_type != 2 && Program.window_type != 1)
                Program.window_type = 0;
        }
        #endregion

        #region Diagram functions

        private void balanceSumm()
        {
            int sum = 0;
            try
            {
                //for (int i = 0; i < balanceGrid.Rows.Count; ++i)
                //{
                //    if (balanceGrid.Rows[i].Cells["curEndCount"].Value != DBNull.Value)
                //    sum += Convert.ToInt32(balanceGrid.Rows[i].Cells["curEndCount"].Value);
                //}
                getPriceTableAdapter getprDa = new getPriceTableAdapter();
                object summa = getprDa.OstatokSum();
                if (summa != null)
                {
                    sum = Convert.ToInt32(summa);
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
        private void loadBtn()
        {
            this.hotkeysTableAdapter1.Fill(DBclass.DS.hotkeys);

            DataView htk = new DataView(DBclass.DS.hotkeys);
            foreach (DataRowView temp in htk)
            {
                string[] hkeys = temp["btnId"].ToString().Split(new char[] { '$' });
                string bkey = "";
                string idh = "";
                if (hkeys.Length > 0 && hkeys.Length == 2)
                {
                    bkey = hkeys[0];
                    idh = hkeys[1];
                }
                else
                {
                    bkey = hkeys[0];
                }

                Button btn = this.Controls.Find("hot_" + bkey, true).FirstOrDefault() as Button;
                btn.Tag = idh;
                btn.Text = temp["prodId"].ToString();
            }


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


        }

        private void pieChartLoad()
        {
            Func<ChartPoint, string> labelPoint = chartPoint =>
                   string.Format("{1:P}", chartPoint.Y, chartPoint.Participation);

            int i = 0;
            DataView ExpV = (expenseGrid.DataSource) as DataView;
            SeriesCollection pS = new SeriesCollection();
            foreach (DataRow val in ExpV.ToTable().Rows)
            {
                if (Convert.ToDouble(val["count"]) > 1)
                    pS.Add( new PieSeries
                    {
                        Title = val["name"].ToString(),
                        Values = new ChartValues<double> { Convert.ToDouble(val["count"]) },
                        PushOut = Convert.ToDouble(val["count"]),
                        DataLabels = true,
                        LabelPoint = labelPoint
                    });
                i++;
            }



            pieChart1.Series = pS;

            pieChart1.LegendLocation = LegendLocation.Bottom;


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

        #endregion

        #region Filtering
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
                    pieChartLoad();
                    break;
                case "tabFaktura":
                    fakturaviewTableAdapter fak = new fakturaviewTableAdapter();
                    fak.Fill(DBclass.DS.fakturaview);
                    DataView dvf = dgvFaktura.DataSource as DataView;
                    dvf.RowFilter = "fakturaDate = '" + reportDate.Value.ToString("yyyy-MM-dd") + "'";

                    break;
                //case "tabOstatok":
                //    this.balanceviewTableAdapter1.Fill(DBclass.DS.balanceview, DateTime.Now.AddDays(-30));
                //    DataView balance = balanceGrid.DataSource as DataView;
                //    balance.RowFilter = "balanceDate = '" + reportDate.Value.ToString("yyyy-MM-dd") + "'";
                //    break;
                case "tabExpense":
                    this.expenseTableAdapter1.Fill(DBclass.DS.expense);
                    DataView expenseView = new DataView(DBclass.DS.expense);
                    expenseView.RowFilter = "expenseDate <= '" + Convert.ToDateTime(reportDate.Value.ToString("yyyy-MM-dd") + " 23:59:59") + "' and expenseDate >= '" + Convert.ToDateTime(reportDate.Value.ToString("yyyy-MM-dd") + " 00:00:00") + "'";
                    dgvExpense.DataSource = expenseView;

                    this.ordersviewTableAdapter1.Fill(DBclass.DS.ordersview);
                    DataView ordersView = new DataView(DBclass.DS.ordersview);
                    ordersView.RowFilter = "expenseDate <= '" + Convert.ToDateTime(reportDate.Value.ToString("yyyy-MM-dd") + " 23:59:59") + "' and expenseDate >= '" + Convert.ToDateTime(reportDate.Value.ToString("yyyy-MM-dd") + " 00:00:00") + "'";
                    dgvOrders.DataSource = ordersView;

                    break;
            }
                        
        }

        private void showBtn_Click(object sender, EventArgs e)
        {
            Filtering(tabControl1.SelectedTab.Name);
            balanceSumm();
            realizeSumm();
        }
        private void tbx_ValueChanged(object sender, EventArgs e)
        {
            TextBox tbx = sender as TextBox;
            switch (tabControl1.SelectedTab.Name)
            {
                case "tabTovar":
                    DataView dv = dgvTovar.DataSource as DataView;
                    if(limit == true)
                        dv.RowFilter = "name like '%" + tbx.Text + "%' and limitProd = 1";
                    else
                        dv.RowFilter = "name like '%" + tbx.Text + "%' ";
                    break;
                case "tabPrixod":
                    DataView dvP = dgvTovar.DataSource as DataView;
                    if(limit == true)
                        dvP.RowFilter = "name like '%" + tbx.Text + "%' and limitProd = 1";
                    else
                        dvP.RowFilter = "name like '%" + tbx.Text + "%' ";
                    break;
                case "tabOstatok":
                    DataView bdv = balanceGrid.DataSource as DataView;
                    if (limit == true)
                    {
                        bdv.RowFilter = "(name like '%" + tbx.Text + "%' or barcode like '%" + tbx.Text + "%') and limit = 1";
                    }
                    else
                    {
                        bdv.RowFilter = "(name like '%" + tbx.Text + "%' or barcode like '%" + tbx.Text + "%')";
                    }
                    break;

                case "tabSpisaniye":
                    DataView sps = dgvSpisaniye.DataSource as DataView;
                    sps.RowFilter = "name like '%" + tbx.Text + "%'";
                    break;
            }
        }

        private void chbxSearchLimit_changes(object sender, EventArgs e)
        {
            CheckBox chb = sender as CheckBox;
            if (chb.Checked)
            {
                limit = true;
            }
            else
            {
                limit = false;
            }
            DataView dv = dgvTovar.DataSource as DataView;
            if (limit == true)
                dv.RowFilter = "name like '%" + tbxFilter.Text + "%' and limitProd = 1";
            else
                dv.RowFilter = "name like '%" + tbxFilter.Text + "%' ";
        }
        #endregion

        #region DataGridViews Event cells, Repaint and etc

        /// <summary>
        /// Event change grid colour even, odd
        /// </summary>
        /// <param name="sender">Datagridview</param>
        /// <param name="e">Event params</param>
        private void dgv_postPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            switch (grid.Name)
            {
                case "dgvTovar":
                    if (e.RowIndex % 2 == 1) style.BackColor = System.Drawing.Color.FromArgb(192, 230, 214);
                    else
                        style.BackColor = System.Drawing.Color.FromArgb(232, 232, 232);
                    grid.Rows[e.RowIndex].DefaultCellStyle = style;
                    
                    break;
                case "dgvExpense":
                    if (e.RowIndex % 2 == 1) style.BackColor = System.Drawing.Color.FromArgb(192, 230, 214);
                    else
                        style.BackColor = System.Drawing.Color.FromArgb(232, 232, 232);
                    string some = grid.Rows[e.RowIndex].Cells[7].Value.ToString();
                    if (grid.Rows[e.RowIndex].Cells[7].Value.ToString() == "0")
                    {
                        grid.Rows[e.RowIndex].Cells["expTypeStr"].Value = "Продажа";
                    }
                    else if (grid.Rows[e.RowIndex].Cells[7].Value.ToString() == "3")
                    {
                        grid.Rows[e.RowIndex].Cells["expTypeStr"].Value = "Списание";
                    }
                    else
                    {
                        grid.Rows[e.RowIndex].Cells["expTypeStr"].Value = "Возврат";
                    }
                    break;
                case "dgvExpiry":

                    String expiryDate = grid.Rows[e.RowIndex].Cells[8].Value.ToString();
                    if (expiryDate != "" )
                    {
                        DateTime month1 = DateTime.Now.AddDays(30);
                        DateTime month2 = DateTime.Now.AddDays(60);
                        DateTime expires = Convert.ToDateTime(expiryDate) ;
                        if (expires < month2 && expires > month1)
                        {
                            grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.Yellow;
                        }
                        else if (expires < month1)
                        {
                            grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                        }
                        else 
                        {
                            grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.Green;
                        }
                    }
                    break;

                default:
                    
                    if (e.RowIndex % 2 == 1) style.BackColor = System.Drawing.Color.FromArgb(192, 230, 214);
                    else
                        style.BackColor = System.Drawing.Color.FromArgb(232, 232, 232);
                    grid.Rows[e.RowIndex].DefaultCellStyle = style;
                    break;
            }
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
                            if (MessageBox.Show("Удалить товар?","",MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
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
                        DBclass dbC = new DBclass();
                        dbC.calcProc("minus", rls[0].prodId, rls[0].count);
                        rls[0].Delete();
                        
                        this.realizeTableAdapter1.Update(DBclass.DS.realize);
                        this.realizeviewTableAdapter1.Fill(DBclass.DS.realizeview);
                        break;

                    ///Change!
                    case "dgvSpisaniye":
                        if (dgv.Columns[e.ColumnIndex].Name == "colBtnSpisat")
                        {
                            var grid = (DataGridView)sender;
                            if (grid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                            {
                                int id = (int)grid.Rows[e.RowIndex].Cells["productid"].Value;

                                DBclass db = new DBclass();
                                DataRow[] drProduct = DBclass.DS.product.Select("productId = " + id);
                                db.AddProduct(drProduct, false, "");
                                db.Debt();
                                productviewTableAdapter prVda = new productviewTableAdapter();
                                prVda.Fill(DBclass.DS.productview);
                            }
                        }
                        break;
                    ///Change end!
                    
                }
                
            }
            if (e.RowIndex != -1)
            {
                switch (dgv.Name)
                {
                    case "dgvFaktura":
                        DataView dv = dgvFakturaTovar.DataSource as DataView;
                        dv.RowFilter = "fakturaId =" + dgv.Rows[e.RowIndex].Cells["fakturaId"].Value.ToString();
                        break;
                    case "dgvExpense":
                        DataView dvExp = dgvOrders.DataSource as DataView;
                        dvExp.RowFilter = "expenseId =" + dgv.Rows[e.RowIndex].Cells["expenseId"].Value.ToString();
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
                        
					case "dgvSpisaniye":
                        dgvCell.Value = "Списать";
                        break;

                }
                
                
                

                
            }
        }
        #endregion

        private void btnCloseFaktura_Click(object sender, EventArgs e)
        {
            if (isPrixod)
            {
                isPrixod = false;
                DBclass dbC = new DBclass();

                MySqlCommand command = new MySqlCommand("CALL `FakturaTrigger`('" + idFaktura + "')", dbC.connection);
                if (dbC.connection.State == ConnectionState.Closed)
                {
                    try
                    {
                        dbC.connection.Open();
                        command.ExecuteNonQuery();
                        dbC.connection.Close();
                        //System.Windows.Forms.MessageBox.Show("Операция выполнена успешно!");
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.Message);
                    }
                }
                //getPriceTableAdapter getPriceDA = new getPriceTableAdapter();
                //getPriceDA.FakturaTrigger(idFaktura);
                idFaktura = -1;
                MessageBox.Show("Приход закрыт!");
                realizeGrid.Columns["colBtnDel"].Visible = false;
            }
        }



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

                case "tabSpisaniye":

                    break;
                                
            }
            tbxFilter.Focus();
            balanceSumm();

        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void menuRasxod_Click(object sender, EventArgs e)
        {
            Program.window_type = 2;
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SendInfo("-1");
            tbxFilter.Focus();
        }
        


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
                    
                    if (st != "")
                        (sender as TextBox).Text = "";
                }
            }
           
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var ds = new DataSet();
            var dt = new DataTable();
            //Получаем из  
            MySqlCommand command = new MySqlCommand();
            command.Connection = productTableAdapter1.Connection;
            command.CommandText = "select p.productId as `#`, p.name as `Имя`, p.price as `Цена`, p.barcode as `Штрих`, "+
                                    "CASE WHEN pack != 0 THEN  CONCAT(FLOOR(endCount/pack) ,'/',(endCount - FLOOR(endCount/pack)*pack) ) "+
                                    "else endCount END as `Кол. общ` , "+
                                    "CASE WHEN pack != 0 THEN  FLOOR(endCount/pack) "+
                                    "else endCount END as `Кол.`, "+
                                    "CASE WHEN pack != 0 THEN  (endCount - FLOOR(endCount/pack)*pack) "+
                                    "else endCount END as `Остаток`  "+
                                    "from product as p left join balance as b "+
                                    "on p.productId = b.prodId "+
                                    "where b.balanceDate = '2000-01-01'";
            //prDa.Fill(dataSetTpos.productview);
            MySqlDataAdapter myDa = new MySqlDataAdapter(command);
            //if (dt.Columns.CanRemove(dt.Columns["balanceDate"]))
            //{
            //    dt.Columns.Remove(dt.Columns["balanceDate"]);
            //}
            myDa.Fill(dt);
            
            
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

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm settingsform = new SettingsForm(null);
            settingsform.ShowDialog();
        }

        private void парольToolStripMenuItem_Click(object sender, EventArgs e)
        {
            passForm passform = new passForm();
            if (passform.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.Close();
            }
        }

        private Bitmap encodingZxing(string barcode)
        {
            Bitmap img = null;
            //Renderer = typeof(Bitmap);
            try
            {
                BarcodeFormat frmt = new BarcodeFormat() ;
                if (barcode.Length == 12)
                {
                    frmt = BarcodeFormat.UPC_A;
                }
                else if (barcode.Length == 13)
                {
                    frmt = BarcodeFormat.EAN_13;
                }
                
                var writer = new BarcodeWriter
                {
                    Format = frmt,
                    Options = EncodingOptions ?? new EncodingOptions
                    {
                        Height = 100,
                        Width = 800
                    },
                    Renderer = (IBarcodeRenderer<Bitmap>)Activator.CreateInstance(Renderer)
                };
                img = writer.Write(barcode);
            }
            catch (Exception exc)
            {
                MessageBox.Show(this, exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return img;

        }

        public void saveBmp(string barcode)
        {
            Bitmap img = encodingZxing(barcode);
            var fileName = String.Empty;
            fileName = Directory.GetCurrentDirectory() + "\\barcode.png";
            var extension = Path.GetExtension(fileName).ToLower();
            var bmp = (Bitmap)img;

            bmp.Save(fileName, ImageFormat.Png);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabControl1.TabPages[1]);
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Add(tabControl1.TabPages[1]);
        }

        private void menuEksportFilial_Click(object sender, EventArgs e)
        {
            FormToFilial formFilial = new FormToFilial();
            formFilial.ShowDialog();
        }

        private void ExportradioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void libraBtn_Click(object sender, EventArgs e)
        {

        }

        private void btnGetFaktura_Click(object sender, EventArgs e)
        {

        }

        private void realizeSearchTxt_valueChanged(object sender, EventArgs e)
        {

        }

        private void splitContainer3_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void backSearchTxt_valueChanged(object sender, EventArgs e)
        {

        }

        private void providerCmbx_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void provCmbx_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbxUsersSchet_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
        private void libraCmx_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void hotKey_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string[] temp = btn.Name.Split('_');

            using (ProdList prodList = new ProdList(temp[1], btn.Text, (btn.Tag == null ? "" : btn.Tag.ToString())))
            {
                prodList.ShowDialog();
                string result = prodList.prodName;
                btn.Text = result;
                btn.Tag = prodList.id;
            }

        }

        private void menuUpdate_Click(object sender, EventArgs e)
        {
            Update();
        }

        private void realizeGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (UserValues.role == "admin" && e.RowIndex >= 0)
            {
                int realizeId = (int)realizeGrid.Rows[e.RowIndex].Cells["realizeId"].Value;
                int fakturaId = (int)realizeGrid.Rows[e.RowIndex].Cells["fakturaId"].Value;
                DataSetTposTableAdapters.realizeTableAdapter rlDa = new realizeTableAdapter();
                rlDa.FillByID(DBclass.DS.realize, realizeId);
                DataSetTpos.realizeRow rlRow = DBclass.DS.realize.FindByrealizeId(realizeId);
                DataSetTpos.productRow prRow = DBclass.DS.product.Single<DataSetTpos.productRow>(rl => rl.productId == rlRow.prodId);
                DataSetTpos.realizeviewRow rlvRow = DBclass.DS.realizeview.Single<DataSetTpos.realizeviewRow>(rl => rl.realizeId == realizeId);
                AddRealize adReal = new AddRealize(rlRow, rlvRow, prRow);
                adReal.ShowDialog();
                productTableAdapter prDa = new productTableAdapter();
                prDa.Update(prRow);
                realizeSumm();
            }
        }
    }
}
