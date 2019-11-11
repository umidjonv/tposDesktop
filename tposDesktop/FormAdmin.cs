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
using System.IO;
using AddIn;

namespace tposDesktop
{
    public partial class    FormAdmin : Form
    {
        Scanner scanner;
        DBclass db;
        delegate void SendInfoDel(string text, bool isId);
        bool isExit = false;
        //Diagramm
        bool tproc = true;
        bool tnal = true;
        bool tterm = true;
        bool tback = true;

        //Prixod
        bool isPrixod = false;
        bool isBack = false;
        int idFaktura = -1;
        int idBackFaktura = -1;
        DrvLP tar = new DrvLP();
        int libra = 0;
        string currentTar = "";
        public FormAdmin()
        {
            //MessageBox.Show("admin");
            InitializeComponent();

            

            try
            {
                
                this.Icon = tposDesktop.Properties.Resources.mainIcon;
                if (UserValues.role != "admin" && UserValues.role != "manager")
                    this.Dispose();
                db = new DBclass();
                DataView dv = new DataView(DBclass.DS.product);
                dv.RowFilter = "";
                dgvTovar.DataSource = dv;
                


                dv.RowFilter = "";
                dgvTovarPrixod.DataSource = dv;
                dgvTovarBack.DataSource = dv;

                ///initialize config table and class
                configsTableAdapter cfgDa = new configsTableAdapter();
                cfgDa.Fill(DBclass.DS.configs);
                Configs cfgs = new Configs();

                DataSetTposTableAdapters.userTableAdapter userDa = new userTableAdapter();
                userDa.Fill(DBclass.DS.user);
                DataView dvUser = new DataView(DBclass.DS.user);
                dvUser.RowFilter = "role = 'user'";

                cbxUsersSchet.DataSource = dvUser;
                cbxUsersSchet.ValueMember = "IDUser";
                cbxUsersSchet.DisplayMember = "username";


                fakturaTableAdapter fakDa = new fakturaTableAdapter();
                fakDa.Fill(DBclass.DS.faktura);

                this.infoTableAdapter1.Fill(DBclass.DS.info);
                DataView info = new DataView(DBclass.DS.info);
                info.RowFilter = "userId = 0";// "Dates = " + reportDate.Value.ToString("yyyy-MM-dd");
                info.Sort = "Dates desc";
                infoGrid.DataSource = info;

                this.realizeviewTableAdapter1.Fill(DBclass.DS.realizeview, DateTime.Parse(reportDate.Value.ToString("yyyy-MM-dd")));
                DataView realize = new DataView(DBclass.DS.realizeview);
                realize.RowFilter = "fakturaDate = '" + reportDate.Value.ToString("yyyy-MM-dd") + "'";
                realizeGrid.DataSource = realize;

                this.backrealizeviewTableAdapter1.Fill(DBclass.DS.backrealizeview, DateTime.Parse(reportDate.Value.ToString("yyyy-MM-dd")));
                DataView Brealize = new DataView(DBclass.DS.backrealizeview);
                Brealize.RowFilter = "fakturaDate = '" + reportDate.Value.ToString("yyyy-MM-dd") + "'";
                backGrid.DataSource = Brealize;
                
                this.expenseviewTableAdapter1.FillByDate(DBclass.DS.expenseview, DateTime.Now.AddDays(-30));
                DataView expense = new DataView(DBclass.DS.expenseview);
                expense.RowFilter = "expenseDate = '" + reportDate.Value.ToString("yyyy-MM-dd") + "'";
                expenseGrid.DataSource = expense;
                
                this.expenseTableAdapter1.FillByDate(DBclass.DS.expense, DateTime.Now.AddDays(-60));
                DataView expenseView = new DataView(DBclass.DS.expense);
                expenseView.Sort = "expenseId desc";
                expenseView.RowFilter = "expenseDate <= '" + Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59") + "' and expenseDate >= '" + Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00") + "'";
                dgvExpense.DataSource = expenseView;
                
                ordersviewTableAdapter orV = new ordersviewTableAdapter();
                orV.Fill(DBclass.DS.ordersview);
                DataView ordersView = new DataView(DBclass.DS.ordersview);
                ordersView.RowFilter = "expenseDate <= '" + Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59") + "' and expenseDate >= '" + Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00") + "'";
                dgvOrders.DataSource = ordersView;
                
                this.balanceviewTableAdapter1.Fill(DBclass.DS.balanceview);
                DataView balance = new DataView(DBclass.DS.balanceview);
                //balance.RowFilter = "balanceDate = '" + reportDate.Value.ToString("yyyy-MM-dd") + "'";
                balanceGrid.DataSource = balance;

                




                fakturaViewInitialize();

                ///Change!
                if (!(DBclass.DS.inventorylist.Columns["productName"] is DataColumn))
                    DBclass.DS.inventorylist.Columns.Add("productName", typeof(string));
                
                DataView dvOs = new DataView(DBclass.DS.inventorylist);
                dgvBalanceChange.DataSource = dvOs;

                if (!(DBclass.DS.orders.Columns["sumProduct"] is DataColumn))
                DBclass.DS.orders.Columns.Add("sumProduct", typeof(int));
                productviewTableAdapter prVda = new productviewTableAdapter();
                prVda.Fill(DBclass.DS.productview);
                dgvSpisaniye.DataSource = new DataView(DBclass.DS.productview);
                ///Change end!
                ///

                //MessageBox.Show("This143");
                loadBtn();
                liveChartLoad();
                pieChartLoad();
                balanceSumm();
                realizeSumm();
                Roles("");
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

        private bool Roles(string type)
        {
            bool IsRole = true;
            if (UserValues.role == "manager")
            {
                
                switch (type)
                {
                    case "ostatok":
                        IsRole = false;
                        break;
                    default:
                        настройкиToolStripMenuItem.Visible = false;
                        dgvBalanceChange.Visible = false;
                        btnCreateInventory.Visible = false;
                        label3.Visible = false;
                        lblNumberInv.Visible = false;
                        menuUsers.Visible = false;
                        break;
                }

                
            }
            return IsRole;
        }
        private void hotkeyLibraLoad()
        {
            for (int i = 1; i <= 90; i++)
            {
                Button btn = this.Controls.Find("tar_" + i.ToString(), true).FirstOrDefault() as Button;
                btn.Text = i.ToString();
            }
            
            DataRow[] dt = DBclass.DS.libra.Select("libraId = " + libra.ToString());
            if(dt.Length>0)
            {
                try
                {


                    tar.DeviceInterface = 1;
                    tar.RemoteHost = dt[0]["ipAddress"].ToString();
                    if (tar.Connect() != 0)
                    {
                        MessageBox.Show("Не удается подключиться к весам " + dt[0]["name"].ToString());
                    }
                    else
                    {
                        this.hotkeysLibraTableAdapter1.Fill(DBclass.DS.hotkeysLibra);
                        DataView hDv = new DataView(DBclass.DS.hotkeysLibra);
                        hDv.RowFilter = "libraId = " + libra.ToString();

                        foreach (DataRowView libraRow in hDv)
                        {
                            Button btn = this.Controls.Find("tar_" + libraRow["btnLibraId"], true).FirstOrDefault() as Button;
                            btn.Text = libraRow["prodLibraId"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                   

            }
           
            
        }

        private void loadBtn()
        {
            this.hotkeysTableAdapter1.Fill(DBclass.DS.hotkeys);

            DataView htk = new DataView(DBclass.DS.hotkeys);
            foreach (DataRowView temp in htk)
            {
                string[] hkeys = temp["btnId"].ToString().Split(new char[] {'$'});
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

                Button btn = this.Controls.Find("hot_" +bkey , true).FirstOrDefault() as Button;
                btn.Tag = idh;
                btn.Text = temp["prodId"].ToString();
            }


        }
        private void fakturaViewInitialize()
        {
            DateTime from = DateTime.Parse(reportDate.Value.ToString("yyyy-MM-dd") + " 00:00:00");
            DateTime to = DateTime.Parse(reportDate.Value.ToString("yyyy-MM-dd") + " 23:59:59");
            fakturaviewTableAdapter fviewda = new fakturaviewTableAdapter();
            fviewda.Fill(DBclass.DS.fakturaview, from, to);
            DataView fkview = new DataView(DBclass.DS.fakturaview);
            //fkview.RowFilter = "fakturaDate = '" + reportDate.Value.ToString("yyyy-MM-dd") + "'";
            fkview.Sort = "fakturaId desc";
            dgvFaktura.DataSource = fkview;
            DataView dvRealize = new DataView(DBclass.DS.realizeview);
            dgvFakturaTovar.DataSource = dvRealize;
        }
        
        void scanner_ScannerEvent(object source, ScannerEventArgs e)
        {
            this.Invoke(new SendInfoDel(SendInfo), new object[] { e.GetInfo(), false });
        }

        private void SendInfo(string text, bool isId)
        {
            DataRow[] dr ;
            string barcode = "";
            if (!isId)
            {
                barcode = text;
                if (barcode == null) barcode = "-1";
                dr = DBclass.DS.product.Select("barcode = '" + barcode + "'");
                if (barcode == "-1") barcode = "";
            }
            else
            {
                dr = DBclass.DS.product.Select("productId = " + text + "");
                if (dr.Length > 0)
                    barcode = dr[0]["barcode"].ToString();
            }
            string tname = tabControl1.SelectedTab.Name;
            
            if (dr.Length == 0&&(tname=="tabPrixod"||tname == "tabOstatok"))
                tname = "tabTovar";
            switch(tname)
            {
                case "tabTovar":
                AddProduct(dr, barcode);
                break;
                case "tabPrixod":
                AddPrixod(dr, barcode);
                    break;
                case "tabBack":
                    RealizeBack(dr, barcode);
                break;
                case "tabSpisaniye":
                    DBclass db = new DBclass();
                    commentForm commentF = new commentForm(true);
                    if (commentF.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        db.AddProduct(dr, true, barcode);
                        db.Debt(commentF.comment);
                    }
                break;
                case "tabOstatok":
                    if (Roles("ostatok"))
                    {
                        ChangeBalance((int)dr[0]["productId"]);
                        
                    }
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
            string idf ="";
            if ((idf = Configs.GetConfig("currentFaktura")) != "0")
            {
                idFaktura = int.Parse(idf);
                isPrixod = true;
            }
            if (!isPrixod)
            {
                //if()
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
                    Configs.SetConfig("currentFaktura", idFaktura.ToString());
                    realizeGrid.Columns["colBtnDel"].Visible = true;
                    isPrixod = true;
                    reportDate.Value = DateTime.Now.Date;

                    lblFakturaNumber.Text = "№ Фактуры:" + idFaktura;
                    
                }
                

            }
            if(isPrixod)
            {
                DataSetTpos.fakturaRow faktRow = (DataSetTpos.fakturaRow)DBclass.DS.faktura.Select("fakturaId = "+idFaktura)[0];

                DataView dv = realizeGrid.DataSource as DataView;
                dv.RowFilter = "fakturaId = " + faktRow.fakturaId;
                int curPrice = prRow.price;
                AddRealize addForm = new AddRealize(prRow, faktRow);
                if (addForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (curPrice != prRow.price && prRow.price != 0)
                    {
                        productTableAdapter prda = new productTableAdapter();
                        prda.Update(prRow);
                    }
                    realizeGrid.Columns["colBtnDel"].Visible = true;
                    this.realizeviewTableAdapter1.Fill(DBclass.DS.realizeview, DateTime.Parse(reportDate.Value.ToString("yyyy-MM-dd")));
                    //faktura
                    realizeSumm();
                }

                
            }
            
            
        }
        #endregion

        private void RealizeBack(DataRow[] dr, string barcode)
        {

            DataSetTpos.productRow prRow = (DataSetTpos.productRow)dr[0];
            FakturaOrgsForm orgForm = new FakturaOrgsForm();

            if (!isBack)
            {
                if (orgForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    DataSetTpos.backfakturaRow bfkrow = DBclass.DS.backfaktura.NewbackfakturaRow();
                    bfkrow.providerId = orgForm.activeProviderRow.providerId;
                    bfkrow.fakturaDate = DateTime.Now;
                    backfakturaTableAdapter daFaktura = new backfakturaTableAdapter();
                    DBclass.DS.backfaktura.AddbackfakturaRow(bfkrow);
                    daFaktura.Update(DBclass.DS.backfaktura);
                    daFaktura.Fill(DBclass.DS.backfaktura);
                    idBackFaktura = (DBclass.DS.backfaktura.Rows[0] as DataSetTpos.backfakturaRow).backFakturaId;
                    backGrid.Columns["colBtnDell"].Visible = true;
                    isBack = true;
                }
            }
            if (isBack)
            {
                DataSetTpos.backfakturaRow faktRow = (DataSetTpos.backfakturaRow)DBclass.DS.backfaktura.Rows[0];

                DataView dv = backGrid.DataSource as DataView;
                dv.RowFilter = "backFakturaId = " + faktRow.backFakturaId;
                int curPrice = prRow.price;
                BackRealize addForm = new BackRealize(prRow, faktRow);
                if (addForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (curPrice != prRow.price && prRow.price != 0)
                    {
                        productTableAdapter prda = new productTableAdapter();
                        prda.Update(prRow);
                    }
                    backGrid.Columns["colBtnDell"].Visible = true;
                    backrealizeviewTableAdapter bR = new backrealizeviewTableAdapter();
                    bR.Fill(DBclass.DS.backrealizeview, DateTime.Parse(reportDate.Value.ToString("yyyy-MM-dd")));
                }


            }


        }

        #region FormLoad, Init, Close
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
            fillCombobox();
            tabControl1.TabPages.Remove(tabOtchety);
        }

        private void fillCombobox()
        {
            providerTableAdapter1.Fill(DBclass.DS.provider);
            DataView dv = new DataView(DBclass.DS.provider);
            dv.RowFilter = "";
            foreach (DataRowView dr in dv)
            {
                providerCmbx.Items.Add(dr["orgName"]);
                provCmbx.Items.Add(dr["orgName"]);
            }


            libraTableAdapter1.Fill(DBclass.DS.libra);
            DataView libDv = new DataView(DBclass.DS.libra);
            libDv.RowFilter = "";
            foreach (DataRowView dr in libDv)
            {
                libraCmx.Items.Add(dr["name"]);
            }
        }

        private void InitDataGridViews()
        {
            //Tovar grid init
            dgvTovar.Columns["productId"].HeaderText = "№";
            dgvTovar.Columns["name"].HeaderText = "Товар";
            dgvTovar.Columns["price"].HeaderText = "Цена";
            dgvTovar.Columns["measureId"].Visible = false;
            dgvTovar.Columns["barcode"].HeaderText = "Штрихкод";
            dgvTovar.Columns["providerId"].Visible = false;
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
            cellBtnDel.Visible = false;
            dgvTovar.Columns.Add(cellBtnDel);
            DataGridViewButtonColumn cellBtnPack = new System.Windows.Forms.DataGridViewButtonColumn();
            cellBtnPack.HeaderText = "";
            cellBtnPack.Name = "colBtnPack";
            cellBtnPack.Width = 120;
            dgvTovar.Columns.Add(cellBtnPack);




           

            //Tovar rasxod
            dgvTovarPrixod.Columns["productId"].HeaderText = "№";
            dgvTovarPrixod.Columns["name"].HeaderText = "Товар";
            dgvTovarPrixod.Columns["price"].Visible = false;
            dgvTovarPrixod.Columns["measureId"].Visible = false;
            //dgvTovarPrixod.Columns["barcode"].HeaderText = "Штрихкод";
            dgvTovarPrixod.Columns["barcode"].Visible = false;
            dgvTovarPrixod.Columns["pack"].Visible = false;
            dgvTovarPrixod.Columns["providerId"].Visible = false;
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

            //Tovar vozvrat
            dgvTovarBack.Columns["productId"].HeaderText = "№";
            dgvTovarBack.Columns["name"].HeaderText = "Товар";
            dgvTovarBack.Columns["price"].Visible = false;
            dgvTovarBack.Columns["measureId"].Visible = false;
            dgvTovarBack.Columns["barcode"].Visible = false;
            dgvTovarBack.Columns["pack"].Visible = false;
            dgvTovarBack.Columns["providerId"].Visible = false;
            dgvTovarBack.Columns["status"].Visible = false;
            dgvTovarBack.Columns["productId"].Width = 50;
            dgvTovarBack.Columns["name"].Width = 300;
            dgvTovarBack.Columns["name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvTovarBack.Columns["price"].Width = 90;
            DataGridViewButtonColumn cellBtnback = new System.Windows.Forms.DataGridViewButtonColumn();
            cellBtnback.HeaderText = "";
            cellBtnback.Name = "colBtn";
            cellBtnback.Width = 100;
            dgvTovarBack.Columns.Add(cellBtnback);



            //Info grid
            infoGrid.Columns["Dates"].HeaderText = "Товар";
            infoGrid.Columns["proceed"].HeaderText = "Выручка";
            infoGrid.Columns["proceed"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            infoGrid.Columns["nal"].HeaderText = "Наличные";
            infoGrid.Columns["back"].HeaderText = "Возврат";
            infoGrid.Columns["infoId"].Visible = false;
            infoGrid.Columns["userId"].Visible = false;
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
            realizeGrid.Columns["price"].DisplayIndex = 3;;
            realizeGrid.Columns["fakturaId"].DisplayIndex = 0;
            realizeGrid.Columns["fakturaId"].HeaderText = "№ Фактуры";
            realizeGrid.Columns["fakturaId"].Width = 70;
            realizeGrid.Columns["soldPrice"].DisplayIndex = 6;
            realizeGrid.Columns["soldPrice"].HeaderText = "Цена на продажу";
            realizeGrid.Columns["soldPrice"].Width = 100;
            realizeGrid.Columns["colBtnDel"].DisplayIndex = 5;
            realizeGrid.Columns["fakturaPrice"].HeaderText = "Цена фактуры";
            realizeGrid.Columns["productId"].Visible = false;
            //cellBtn2.DisplayIndex = 5;

            backGrid.Columns["backRealizeId"].Visible = false;
            backGrid.Columns["name"].HeaderText = "Наименование";
            backGrid.Columns["name"].DisplayIndex = 1;
            backGrid.Columns["name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            backGrid.Columns["fakturaDate"].Visible = false;

            backGrid.Columns["count"].HeaderText = "Кол-во";
            backGrid.Columns["count"].DisplayIndex = 2;
            backGrid.Columns["price"].HeaderText = "Цена";
            backGrid.Columns["price"].DisplayIndex = 3;
            backGrid.Columns["backFakturaId"].DisplayIndex = 0;
            backGrid.Columns["backFakturaId"].HeaderText = "№ Фактуры";
            backGrid.Columns["backFakturaId"].Width = 70;
            backGrid.Columns["colBtnDell"].DisplayIndex = 5;
            backGrid.Columns["productId"].Visible = false;

            //Expense grid
            expenseGrid.Columns["name"].HeaderText = "Наименование";
            expenseGrid.Columns["name"].DisplayIndex = 0;
            expenseGrid.Columns["expenseDate"].Visible = false;
            expenseGrid.Columns["count"].HeaderText = "Кол-во";
            expenseGrid.Columns["name"].Width = 200;
            expenseGrid.Columns["pack"].Visible = false;
            expenseGrid.Columns["measureId"].Visible = false;
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
            if (Roles("ostatok"))
            {
                DataGridViewButtonColumn cellBtnBlnc = new System.Windows.Forms.DataGridViewButtonColumn();
                cellBtnBlnc.HeaderText = "";
                cellBtnBlnc.Name = "colBtnBlnc";
                cellBtnBlnc.Width = 100;

                balanceGrid.Columns.Add(cellBtnBlnc);
                balanceGrid.Columns["colBtnBlnc"].DisplayIndex = 12;
            }

            //fakturaTovar
            dgvFakturaTovar.Columns["name"].HeaderText = "Товар";
            dgvFakturaTovar.Columns["fakturaId"].HeaderText = "№ фактуры";
            dgvFakturaTovar.Columns["fakturaDate"].Visible = false;
            dgvFakturaTovar.Columns["realizeId"].Visible = false;
            dgvFakturaTovar.Columns["productId"].Visible = false;
            dgvFakturaTovar.Columns["price"].HeaderText = "Цена";
            dgvFakturaTovar.Columns["count"].HeaderText = "Кол.";
            
            dgvFakturaTovar.Columns["name"].Width = 250;
            //dgvFakturaTovar.Columns["fakturaDate"].Width = 150;
            dgvFakturaTovar.Columns["name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //dgvFaktura
            dgvFaktura.Columns["orgName"].HeaderText = "Поставщик";
            dgvFaktura.Columns["fakturaId"].HeaderText = "№ ";
            dgvFaktura.Columns["fakturaDate"].HeaderText = "Дата";


            dgvFaktura.Columns["phone"].Visible = false;
            dgvFaktura.Columns["isClosed"].Visible = false;
            dgvFaktura.Columns["fakturaId"].Width = 50;
            dgvFaktura.Columns["orgName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvFaktura.Columns["fakturaDate"].Width = 150;

            ///Change!
            dgvSpisaniye.Columns["productId"].HeaderText = "№";
            dgvSpisaniye.Columns["name"].HeaderText = "Товар";
            dgvSpisaniye.Columns["price"].HeaderText = "Цена";
            dgvSpisaniye.Columns["endCount"].HeaderText = "Кол.";
            dgvSpisaniye.Columns["providerId"].Visible = false;
            dgvSpisaniye.Columns["balanceDate"].Visible = false;
            dgvSpisaniye.Columns["barcode"].HeaderText = "штрих-код";
            dgvSpisaniye.Columns["barcode"].Width = 200;
            
            dgvSpisaniye.Columns["productId"].Width = 50;
            dgvSpisaniye.Columns["name"].Width = 215;
            dgvSpisaniye.Columns["name"].AutoSizeMode= DataGridViewAutoSizeColumnMode.Fill;
            dgvSpisaniye.Columns["price"].Width = 70;
            Classes.GridCells.ImageButtonColumn cellBtnSp = new Classes.GridCells.ImageButtonColumn();
            cellBtnSp.HeaderText = "";
            cellBtnSp.Name = "colBtnSpisat";
            cellBtnSp.Width = 100;

            dgvSpisaniye.Columns.Add(cellBtnSp);
            ///Change end!
            ///
            
            dgvExpense.Columns["expenseId"].Width = 70;
            dgvExpense.Columns["expenseId"].HeaderText = "№";
            dgvExpense.Columns["expenseDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvExpense.Columns["expenseDate"].HeaderText = "Время";
            //dgvExpense.Columns["expenseDate"].
            dgvExpense.Columns["Debt"].Visible = false;
            dgvExpense.Columns["Comment"].Visible = false;
            dgvExpense.Columns["off"].Visible = false;
            dgvExpense.Columns["expType"].Visible = false;
            dgvExpense.Columns["terminal"].Visible = false;
            dgvExpense.Columns["contragentId"].Visible = false;
            dgvExpense.Columns["expsum"].Width = 100;
            dgvExpense.Columns["userId"].Visible = false;
            dgvExpense.Columns["charge"].Visible = false;
            dgvExpense.Columns["expsum"].HeaderText = "Сумма";
            dgvExpense.Columns["status"].Visible = false;
            DataGridViewTextBoxColumn dtbx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dtbx.HeaderText = "Тип";
            dtbx.Name = "expTypeStr";
            dtbx.Width = 60;
            dtbx.DisplayIndex = 2;
            dgvExpense.Columns.Add(dtbx);

            DataGridViewButtonColumn dtbx2 = new System.Windows.Forms.DataGridViewButtonColumn();
            dtbx2.HeaderText = "Печать";
            dtbx2.Name = "expPrint";
            dtbx2.Width = 60;
            
            //dtbx2.DisplayIndex = 2;
            dgvExpense.Columns.Add(dtbx2);

            dgvOrders.Columns["productId"].HeaderText = "Код";
            dgvOrders.Columns["productId"].DisplayIndex = 0;
            dgvOrders.Columns["expenseId"].Visible = false;
            dgvOrders.Columns["expenseDate"].Visible = false;
            dgvOrders.Columns["expType"].Visible = false;
            dgvOrders.Columns["name"].HeaderText = "Наименование";
            dgvOrders.Columns["name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvOrders.Columns["comment"].Visible = false ;
            dgvOrders.Columns["cnt"].HeaderText = "Кол-во";
            dgvOrders.Columns["cnt"].Width = 100;
            dgvOrders.Columns["orderSumm"].HeaderText = "Сумма";
            dgvOrders.Columns["orderSumm"].Width = 150;

            //dgvBalanceChange
            dgvBalanceChange.Columns["inventoryListId"].Visible = false;
            dgvBalanceChange.Columns["prodId"].Visible = false;
            dgvBalanceChange.Columns["InventoryId"].Visible = false;
            dgvBalanceChange.Columns["productName"].HeaderText = "Наим.";
            dgvBalanceChange.Columns["productName"].DisplayIndex = 0;
            dgvBalanceChange.Columns["productName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvBalanceChange.Columns["endCount"].Width = 60;
            dgvBalanceChange.Columns["endCount"].HeaderText = "кол.";
            //dgvBalanceChange.Columns["dateChanged"].HeaderText = "Дата";


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
                dbC.triggerExecute("FakturaTrigger",idFaktura);
                idFaktura = -1;
            }
            if (isBack)
            {

                isBack = false;
                DBclass dbC = new DBclass();
                //dbC.triggerExecute("FakturaTrigger", idFaktura);
                idBackFaktura = -1;
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
                for (int i = 0; i < balanceGrid.Rows.Count; ++i)
                {
                    if (balanceGrid.Rows[i].Cells["curEndCount"].Value != DBNull.Value)
                    sum += Convert.ToInt32(balanceGrid.Rows[i].Cells["curEndCount"].Value);
                }
                lblBalanceSum.Text = "" + string.Format("{0:n0}", sum) + " сум";
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
            DataRow[] rows = table.Select("userId = 0");
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

        private void pieChartLoad()
        {
            Func<ChartPoint, string> labelPoint = chartPoint =>
                   string.Format("{0}", chartPoint.Y);

            int i = 0;
            DataView ExpV = (expenseGrid.DataSource) as DataView;
            //ExpV.
            SeriesCollection pS = new SeriesCollection();
            SeriesCollection pS1 = new SeriesCollection();
            foreach (DataRow val in ExpV.ToTable().Select("measureId = 2", "count desc"))
            {
                if (i > 10) 
                { break; }
                if (Convert.ToDouble(val["count"]) > 1)
                    pS.Add( new PieSeries
                    {
                        Title = val["name"].ToString(),
                        Values = new ChartValues<double> { Convert.ToDouble(val["count"]) },
                        PushOut = 10,
                        DataLabels = true,
                        LabelPoint = labelPoint
                    });
                i++;
            }
            i = 0;
            foreach (DataRow val in ExpV.ToTable().Select("measureId = 1", "count desc"))
            {
                if (i > 10)
                { break; }
                if (Convert.ToDouble(val["count"]) > 1)
                    pS1.Add(new PieSeries
                    {
                        Title = val["name"].ToString(),
                        Values = new ChartValues<double> { Convert.ToDouble(val["count"]) },
                        PushOut = 10,//Convert.ToDouble(val["count"]),
                        DataLabels = true,
                        LabelPoint = labelPoint
                    });
                i++;
            }

            pieChart1.Series = pS;
            
            pieChart1.LegendLocation = LegendLocation.Bottom;
            pieChart2.Series = pS1;

            pieChart2.LegendLocation = LegendLocation.Bottom;


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
                    this.realizeviewTableAdapter1.Fill(DBclass.DS.realizeview, DateTime.Parse(reportDate.Value.ToString("yyyy-MM-dd")));
                    var realize = realizeGrid.DataSource as DataView;
                    realize.RowFilter = "fakturaDate = '" + reportDate.Value.ToString("yyyy-MM-dd") + "' AND name like '%" +realizeSearchTxt.Text+ "%'";
                    realize.Sort = "fakturaId desc";
                    realizeGrid.Columns["colBtnDel"].Visible = false;
                    break;

                case "tabBack":
                    this.backrealizeviewTableAdapter1.Fill(DBclass.DS.backrealizeview, DateTime.Parse(reportDate.Value.ToString("yyyy-MM-dd")));
                    var Brealize = backGrid.DataSource as DataView;
                    Brealize.RowFilter = "fakturaDate = '" + reportDate.Value.ToString("yyyy-MM-dd") + "' AND name like '%" + realizeSearchTxt.Text + "%'";
                    backGrid.Columns["colBtnDell"].Visible = false;
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
                case "tabOstatok":
                    this.balanceviewTableAdapter1.Fill(DBclass.DS.balanceview);
                    DataView balance = balanceGrid.DataSource as DataView;
                    //balance.RowFilter = "balanceDate = '" + reportDate.Value.ToString("yyyy-MM-dd") + "'";
                    break;

                case "tabExpense":
                    this.expenseTableAdapter1.FillByDate(DBclass.DS.expense, DateTime.Now.AddDays(-30));
                    DataView expenseView = new DataView(DBclass.DS.expense);
                    expenseView.Sort = "expenseId desc";
                    expenseView.RowFilter = "expenseDate <= '" + Convert.ToDateTime(reportDate.Value.ToString("yyyy-MM-dd") + " 23:59:59") + "' and expenseDate >= '" + Convert.ToDateTime(reportDate.Value.ToString("yyyy-MM-dd") + " 00:00:00") + "'";
                    dgvExpense.DataSource = expenseView;

                   

                    ordersviewTableAdapter orv = new ordersviewTableAdapter();
                    orv.Fill(DBclass.DS.ordersview);
                    DataView ordersView = new DataView(DBclass.DS.ordersview);
                    ordersView.RowFilter = "expenseDate <= '" + Convert.ToDateTime(reportDate.Value.ToString("yyyy-MM-dd") + " 23:59:59") + "' and expenseDate >= '" + Convert.ToDateTime(reportDate.Value.ToString("yyyy-MM-dd") + " 00:00:00") + "'";
                    dgvOrders.DataSource = ordersView;

                    break;
            }
                        
        }

        private void showBtn_Click(object sender, EventArgs e)
        {
            tabControl1_SelectedIndexChanged(tabControl1, new EventArgs());
        }
        private void providerCmbx_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            string cmbtxt = providerCmbx.Text;
            DataView dv = dgvFaktura.DataSource as DataView;
            dv.RowFilter = "orgName like '%" + cmbtxt + "%'";
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
                
                case "tabSpisaniye":
                    DataView sps = dgvSpisaniye.DataSource as DataView;
                    sps.RowFilter = "name like '%" + tbx.Text + "%'";
                    break;
                case "tabOstatok":
                    DataView blnce = balanceGrid.DataSource as DataView;
                    blnce.RowFilter = "name like '%" + tbx.Text + "%'";
                    break;

            }
        }

        private void realizeSearchTxt_valueChanged(object sender, EventArgs e)
        {
            TextBox tbx = sender as TextBox;

            DataView dv = realizeGrid.DataSource as DataView;
            dv.RowFilter = "name like '%" + realizeSearchTxt.Text + "%'";
        }
        private void backSearchTxt_valueChanged(object sender, EventArgs e)
        {
            TextBox tbx = sender as TextBox;

            DataView dv = backGrid.DataSource as DataView;
            dv.RowFilter = "name like '%" + backSearchTxt.Text + "%'";
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
                case "dgvExpense":
                    if (e.RowIndex % 2 == 1) style.BackColor = System.Drawing.Color.FromArgb(192, 230, 214);
                    else
                        style.BackColor = System.Drawing.Color.FromArgb(232, 232, 232);
                    string some = grid.Rows[e.RowIndex].Cells["expType"].Value.ToString();
                    if (grid.Rows[e.RowIndex].Cells["expType"].Value.ToString() == "0")
                    {
                        grid.Rows[e.RowIndex].Cells["expTypeStr"].Value = "Прод.";
                    }
                    else if (grid.Rows[e.RowIndex].Cells["expType"].Value.ToString() == "3")
                    {
                        grid.Rows[e.RowIndex].Cells["expTypeStr"].Value = "Спис.";
                    }
                    else
                    {
                        grid.Rows[e.RowIndex].Cells["expTypeStr"].Value = "Возв.";
                    }
                    grid.Rows[e.RowIndex].Cells["expPrint"].Value = "печ.";
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
                            if (MessageBox.Show("Удалить товар?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                            {
                                dr[0].Delete();
                                this.productTableAdapter1.Update(DBclass.DS.product);
                                this.productTableAdapter1.Fill(DBclass.DS.product);
                            }
                        }
                        else if (dgv.Columns[e.ColumnIndex].Name == "colBtnPack")
                        {
                            DataSetTpos.productRow prRow = (DataSetTpos.productRow)dr[0];
                            packing pck = new packing(prRow);
                            pck.ShowDialog();
                        }

                        
                        
                        break;
                    case "dgvTovarPrixod":
                        DataRow[] drP = DBclass.DS.product.Select("productId = " + dgv.Rows[e.RowIndex].Cells["productId"].Value.ToString());
                        
                        AddPrixod(drP, null);
                        break;
                    case "dgvTovarBack":
                        DataRow[] drB = DBclass.DS.product.Select("productId = " + dgv.Rows[e.RowIndex].Cells["productId"].Value.ToString());

                        RealizeBack(drB, null);
                        break;
                    case "realizeGrid":
                        this.realizeTableAdapter1.FillByID(DBclass.DS.realize, int.Parse(dgv.Rows[e.RowIndex].Cells["realizeId"].Value.ToString()));
                        DataSetTpos.realizeRow[] rls = (DataSetTpos.realizeRow[])DBclass.DS.realize.Select("realizeId=" + dgv.Rows[e.RowIndex].Cells["realizeId"].Value.ToString());
                        DBclass dbC = new DBclass();
                        dbC.calcProc("minus", rls[0].prodId, rls[0].count);
                        
                        rls[0].Delete();
                        
                        this.realizeTableAdapter1.Update(DBclass.DS.realize);
                        this.realizeviewTableAdapter1.Fill(DBclass.DS.realizeview, DateTime.Parse(reportDate.Value.ToString("yyyy-MM-dd")));
                        break;


                    case "backGrid":
                        DataSetTpos.backrealizeRow[] Brls = (DataSetTpos.backrealizeRow[])DBclass.DS.backrealize.Select("backRealizeId=" + dgv.Rows[e.RowIndex].Cells["backRealizeId"].Value.ToString());
                        DBclass BdbC = new DBclass();
                        BdbC.calcProc("minus", Brls[0].prodId, Brls[0].count);

                        Brls[0].Delete();

                        this.backrealizeTableAdapter1.Update(DBclass.DS.backrealize);
                        this.backrealizeviewTableAdapter1.Fill(DBclass.DS.backrealizeview, DateTime.Parse(reportDate.Value.ToString("yyyy-MM-dd")));
                        break;

                    
                        ///Change!
                    case "dgvSpisaniye":
                        if (dgv.Columns[e.ColumnIndex].Name == "colBtnSpisat")
                        {
                            var grid = (DataGridView)sender;
                            commentForm commentF = new commentForm(true);

                            if (grid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0 && commentF.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                int id = (int)grid.Rows[e.RowIndex].Cells["productid"].Value;

                                DBclass db = new DBclass();
                                DataRow[] drProduct = DBclass.DS.product.Select("productId = " + id);
                                if (db.AddProduct(drProduct, false, ""))
                                {
                                    db.Debt(commentF.comment);
                                }
                            }
                            else
                            {
                                 
                            }
                        }
                        break;
                    //Change end!

                    case "dgvExpense":
                        if (dgv.Columns[e.ColumnIndex].Name == "expPrint")
                        {
                            drPrintCol = new List<string[]>();
                            var grid = (DataGridView)sender;
                            if (grid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                            {
                                int id = (int)grid.Rows[e.RowIndex].Cells["expenseId"].Value;
                                DataSetTpos.ordersviewRow[] drsExpense = (DataSetTpos.ordersviewRow[])DBclass.DS.ordersview.Select("expenseId = " + id);
                                //forPrinting()
                                double sum = 0;
                                foreach (DataSetTpos.ordersviewRow dgvRow in drsExpense)
                                {

                                    drPrintCol.Add(new string[] { dgvRow.name, dgvRow.cnt.ToString(), (Math.Round(((double)dgvRow.orderSumm) / (Convert.ToDouble(dgvRow.cnt))/100,0)*100).ToString(), dgvRow.orderSumm.ToString() });
                                    sum += Math.Round(dgvRow.orderSumm);
                                }
                                DataSetTpos.expenseRow[] expRow = (DataSetTpos.expenseRow[])DBclass.DS.expense.Select("expenseId = " + id);
                                if(expRow.Length>0)
                                {
                                    forPrinting(drPrintCol, expRow[0]);
                                }
                                
                            }
                        }
                        break;
                    case "balanceGrid":
                        if (dgv.Columns[e.ColumnIndex].Name == "colBtnBlnc"&&e.RowIndex>-1)
                        {
                            ChangeBalance((int)dgv.Rows[e.RowIndex].Cells["prodId"].Value);


                        }
                        break;
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
                        dvExp.Sort = "expenseId desc";
                        dvExp.RowFilter = "expenseId =" + dgv.Rows[e.RowIndex].Cells["expenseId"].Value.ToString();
                        break;
                }
            }
        }

        private void ChangeBalance(int productId)
        {
            DataSetTpos.productRow[] productRows = (DataSetTpos.productRow[])DBclass.DS.product.Select("productId = " + productId.ToString());
            balanceTableAdapter blncDa = new balanceTableAdapter();
            blncDa.FillByProdId(DBclass.DS.balance, productId);
            DataSetTpos.balanceRow[] blncRows = (DataSetTpos.balanceRow[])DBclass.DS.balance.Select("prodId = " + productId.ToString());
            inventoryTableAdapter invDa = new inventoryTableAdapter();
            DataSetTpos.inventoryDataTable tableInv = invDa.GetLast();
            if (tableInv.Rows.Count > 0)
            {
                DateTime endTime = tableInv[0].InventoryDate.AddDays(7);

                if (endTime >= DateTime.Now && tableInv[0].IsClose == 0)
                {
                    btnCreateInventory.Text = "Закрыть инв-ю.";
                    lblNumberInv.Text = tableInv[0].InventoryId.ToString();
                    if (productRows.Length > 0)
                    {

                        KolForm kolform = new KolForm(productRows[0]);
                        inventorylistTableAdapter invList = new inventorylistTableAdapter();

                        if (kolform.ShowDialog() == DialogResult.OK)
                        {
                            blncRows[0].endCount = kolform.count;
                            //blncRows[0].inventoryId = tableInv[0].InventoryId;
                            DataSetTpos.inventorylistRow[] listRows = (DataSetTpos.inventorylistRow[])DBclass.DS.inventorylist.Select("prodId = " + blncRows[0].prodId + " and inventoryId = " + tableInv[0].InventoryId);
                            DataSetTpos.inventorylistRow listRow;
                            if (listRows.Length > 0)
                                listRow = listRows[0];
                            else
                                listRow = DBclass.DS.inventorylist.NewinventorylistRow();
                            listRow.endCount = kolform.count;
                            listRow.prodId = blncRows[0].prodId;
                            listRow.inventoryId = tableInv[0].InventoryId;
                            listRow["productName"] = productRows[0].name;
                            if (listRows.Length == 0)
                                DBclass.DS.inventorylist.AddinventorylistRow(listRow);



                            balanceviewTableAdapter blncvDa = new balanceviewTableAdapter();

                            blncDa.Update(blncRows[0]);
                            blncvDa.Fill(DBclass.DS.balanceview);



                        }
                        invList.Update(DBclass.DS.inventorylist);
                    }
                }
                else if (tableInv[0].IsClose == 0)
                {
                    invDa.CloseInventory(tableInv[0].InventoryId);
                    btnCreateInventory.Text = "Инвентаризовать";
                }
                else
                {

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
                            case "colBtnPack":
                                dgvCell.Value = "Фасовка";
                                break;
                        }
                        
                        break;
                    case "dgvTovarPrixod":
                        dgvCell.Value = "В приход";
                        break;
                    case "dgvTovarBack":
                        dgvCell.Value = "Возврат";
                        break;
                    case "realizeGrid":
                        dgvCell.Value = "Удалить";
                        break;
                    case "backGrid":
                        dgvCell.Value = "Удалить";
                        break;
                    case "prodDgv":
                        switch (grid.Columns[e.ColumnIndex].Name)
                        {
                            case "colBtn":
                                dgvCell.Value = "в экспорт";
                                break;
                            case "prtBtn":
                                dgvCell.Value = "Печать";
                                break;
                        }
                        break;
					case "dgvSpisaniye":
                        dgvCell.Value = "Списать";
                        break;
                    case "dgvBalanceChange":
                        dgvCell.Value = "Изменить";
                        break;
                    case "balanceGrid":
                        dgvCell.Value = "Изменить";
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
                dbC.triggerExecute("FakturaTrigger",idFaktura);
                Configs.SetConfig("currentFaktura", "0");
                idFaktura = -1;
                MessageBox.Show("Приход закрыт!");
                lblFakturaNumber.Text = "№ Фактуры:0";
                
                //realizeGrid.Columns["colBtnDel"].Visible = false;
            }
            if (isBack)
            {
                isBack = false;

                DBclass dbC = new DBclass();
                //dbC.triggerExecute("FakturaTrigger", idFaktura);
                idBackFaktura = -1;
                MessageBox.Show("Возврат закрыт!");
                backGrid.Columns["colBtnDell"].Visible = false;
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
                case "tabBack":
                    backGrid.Columns["colBtnDell"].DisplayIndex = 4;
                    if (isBack)
                    {
                        backGrid.Columns["colBtnDell"].Visible = true;
                        DataSetTpos.backfakturaRow faktRow = (DataSetTpos.backfakturaRow)DBclass.DS.backfaktura.Rows[0];

                        DataView dv = backGrid.DataSource as DataView;
                        dv.RowFilter = "backFakturaId = " + faktRow.backFakturaId;
                    }

                    break;
                case "tabSpisaniye":
                   
                   break;
                case "tabLibra":
                   //libraCmx.Items.Clear();
                   Dictionary<string, string> libres = new Dictionary<string, string>();
                    this.libraTableAdapter1.Fill(DBclass.DS.libra);
                    DataView lDv = new DataView(DBclass.DS.libra);
                    int i = 1;
                    bool isDisc = false;
                    string tars = "";
                    foreach (DataRowView lDr in lDv)
                    {
                        tar.DeviceInterface = 1;
                        tar.RemoteHost = lDr["ipAddress"].ToString();
                        if (tar.Connect() != 0)
                        {
                            isDisc = true;
                            tars += lDr["name"].ToString() + ", ";
                        }
                        else
                        {
                            //libres.Add(lDr["name"].ToString(), lDr["name"].ToString());
                            libraCmx.Items.Add(lDr["name"].ToString());
                            tar.Disconnect();
                        }
                        if (i == 1)
                        {
                            libra = Convert.ToInt32(lDr["libraId"]);
                        }
                        i++;
                    }

                    if (isDisc == true)
                    {
                        MessageBox.Show("Не удается подключиться к весам " + tars);

                    }
                   hotkeyLibraLoad();
                   break;
                case "tabOstatok":
                    inventoryTableAdapter invDa = new inventoryTableAdapter();
                    object obj = invDa.GetLastId();
                    int lastId = -1;
                    if (obj != null)
                        lastId = (int)obj;
                    inventorylistTableAdapter inlistDa = new inventorylistTableAdapter();
                    inlistDa.Adapter.SelectCommand = new MySql.Data.MySqlClient.MySqlCommand(@"SELECT     inventoryListId, inventoryId, prodId, name as productName, endCount
                                                                    FROM inventorylist
                                                                    join product on product.productId = inventorylist.prodId ", inlistDa.Connection);
                    inlistDa.Adapter.Fill(DBclass.DS.inventorylist);
                    DataView dvOs = new DataView(DBclass.DS.inventorylist);
                    dvOs.RowFilter = "inventoryId = " + lastId;
                    dgvBalanceChange.DataSource = dvOs;
                    break;


            }
            tbxFilter.Focus();
            

        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            //db.updateThread.StopThread();
            this.Close();
            Chart1.Dispose();
        }
        private void menuRasxod_Click(object sender, EventArgs e)
        {
            Program.window_type = 2;
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SendInfo("-1", false);
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
                    if (tbxFilter.Text.Length <= 5 && tbxFilter.Text.Length > 0)
                    {
                        try
                        {
                            SendInfo(Convert.ToInt32(tbxFilter.Text).ToString(), true);
                            tbxFilter.Text = "";
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("нет товара по номеру " + tbxFilter.Text.ToString());
                        }
                    }
                    else
                    {
                        tscanner.End();
                        if (tbxFilter.Text != "" && tbxFilter.Focused)
                            SendInfo(tbxFilter.Text, false);
                        else
                            SendInfo(tscanner.barcode, false);
                        beginBarcode = false;
                        //tscanner.

                        if (st != "")
                            (sender as TextBox).Text = "";
                    }
                }
            }


           
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt = ExportExcel.ToDataTable(dgvTovar, "PC");
            ds.Tables.Add(dt);
            SaveFileDialog spf = new SaveFileDialog();
            spf.Filter = "Файлы Excel|*.xlsx|Файлы Excel 2003|*.xls";
            spf.FileName = "товары на " + DateTime.Now.ToString("dd.MM.yyyy")+ ".xlsx";
            int i = 1;
            if (spf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ExcelClass excel = new ExcelClass(spf.FileName);
                excel.Create("Sheet1");
                excel.ColWidth("A", 20);
                excel.ColWidth("B", 40);
                excel.ColWidth("C", 20);
                excel.ColWidth("D", 20);
                excel.ColWidth("E", 20);

                excel.SetCell("A1", "№", true);
                excel.SetCell("B1", "Наименование", true);
                excel.SetCell("C1", "Ед. изм.", true);
                excel.SetCell("D1", "Штрих-код", true);
                excel.SetCell("E1", "Цена", true);
                
                //excel.SetCell("D1", "Serila Number", true);
                int beginIndex = 2;
                int colCount = 5;
                object[,] objVal = new object[dt.Rows.Count+beginIndex, colCount];
                excel.SetColumnType(4, ExcelClass.ColumnFormat.Numeric, (dt.Rows.Count + beginIndex).ToString());
                foreach (DataRow devc in dt.Rows)
                {
                    i++;
                    int j =  i - beginIndex;
                    //excel.SetCell("A" + i, devc[0].ToString(), null);
                    //excel.SetCell("B" + i, devc[1].ToString(), null);
                    //excel.SetCell("C" + i, devc[3].ToString(), null);
                    //excel.SetCell("D" + i, ((devc[2].ToString() == "1") ? "кг" : "шт"), null);
                    //excel.SetCell("E" + i, devc[5].ToString(), null);

                    objVal[j, 0] = devc[0].ToString();
                    objVal[j, 1] = devc[1].ToString();
                    objVal[j, 2] = ((devc[2].ToString() == "1") ? "кг" : "шт");
                    objVal[j, 3] = devc[3].ToString();
                    objVal[j, 4] = devc[5].ToString();
                }
                
                excel.saveWorkbook(objVal, dt.Rows.Count, beginIndex, colCount);
                excel.Save();
            }
        }

        private void btnExportBalance_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt = ExportExcel.ToDataTable(balanceGrid, "PC");
            ds.Tables.Add(dt);
            SaveFileDialog spf = new SaveFileDialog();
            spf.Filter = "*.xlsx|Файлы Excel";
            spf.FileName = "остаток на " + DateTime.Now.ToString("dd.MM.yyyy") + ".xlsx";
            int i = 1;
            if (spf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ExcelClass excel = new ExcelClass(spf.FileName);
                excel.Create("Sheet1");
                excel.ColWidth("A", 20);
                excel.ColWidth("B", 40);
                excel.ColWidth("C", 20);
                excel.ColWidth("D", 20);

                excel.SetCell("A1", "№", true);
                excel.SetCell("B1", "Наименование", true);
                excel.SetCell("C1", "Кол-во", true);
                excel.SetCell("D1", "Сумма", true);
                //excel.SetCell("D1", "Serila Number", true);
                int beginIndex = 2;
                int colCount = 4;
                object[,] objVal = new object[dt.Rows.Count + beginIndex, colCount];
                
                foreach (DataRow devc in dt.Rows)
                {
                    i++;
                    int j = i - beginIndex;
                    objVal[j, 0] = devc[3].ToString();
                    objVal[j, 1] = devc[6].ToString();
                    objVal[j, 2] = devc[4].ToString();
                    objVal[j, 3] = devc[10].ToString();
                   

                    //excel.SetCell("A" + i, devc[2].ToString(), null);
                    //excel.SetCell("B" + i, devc[5].ToString(), null);
                    //excel.SetCell("C" + i, devc[3].ToString() + ((devc[6].ToString() == "1") ? "кг" : "шт"), null);
                    //excel.SetCell("D" + i, devc[11].ToString(), null);

                }
                excel.saveWorkbook(objVal, dt.Rows.Count, beginIndex, colCount);
                excel.Save();
            }
        }


       

        private void ExportradioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;

            DataView dv = dgvTovar.DataSource as DataView;
            if (rdkgBtn.Checked)
            {
                dv.RowFilter = "measureId = 1";
            }
            else if (rdshtbtn.Checked)
            {
                dv.RowFilter = "measureId = 2";
            }
            else if (allmsrbtn.Checked)
            {
                dv.RowFilter = "";
            }
        }

        private void forPrinting(string name, string price, string barcode)
        {
            string dataHtml = "";
            StreamWriter sw = new StreamWriter(System.IO.Path.GetTempPath() + "\\tempData.htm");
                //summa += decimal.Parse((Math.Round(Double.Parse(sr[1]) * Double.Parse(sr[2]))).ToString());


                dataHtml = "<head></head><body>" +
                        "<table style='font-size: 9px; font-family: Tahoma; width: 100%;'>" +
                                "<tr >" +
                                "<th style=''><h4 style='height: 22px; overflow: hidden;'>" + (name.Length > 30 ? name.Substring(0, 30) : name) + "</h4></th>" +
                                "</tr>" +
                                "<tr>" +
                                    "<th style=''><h1>" + price + "</h1></th>" +
                                "</tr>" +
                                "<tr>" +
                                    "<th style='padding: 20px; '>" + barcode + "</th>" +
                                "</tr>" +
                        "</table>" +
                    "</body>";
            
            sw.Write(dataHtml);
            sw.Close();
            //printing();
            string keyName = @"Software\Microsoft\Internet Explorer\PageSetup";
            using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(keyName, true))
            {
                if (key != null)
                {
                    string old_footer = (string)key.GetValue("footer");
                    string old_header = (string)key.GetValue("header");
                    key.SetValue("footer", "");
                    key.SetValue("header", "");

                    WebBrowser browser = new WebBrowser();
                    browser.DocumentText = dataHtml;
                    browser.DocumentCompleted += browser_DocumentCompleted;
                    browser.Print();
                    if (old_footer != null)
                        key.SetValue("footer", old_footer);
                    if (old_header != null)
                        key.SetValue("header", old_header);
                }
            }

            //PrintClass cl = new PrintClass();
            //cl.Printing();
        }
        List<string[]> drPrintCol;
        private void forPrinting(List<string[]> data, DataSetTpos.expenseRow expRow)
        {
            int price = 0;
            string dataHtml = "";
            int num = 1;
            StreamWriter sw = new StreamWriter(System.IO.Path.GetTempPath() + "\\tempData.htm");
            decimal summa = 0;
            foreach (string[] sr in data)
            {
                dataHtml += "<tr><td>" + sr[0] + "</td><td>" + sr[1] + "</td> <td>" + sr[2] + "</td><td>" + sr[3] + "</td></tr>";
                summa += decimal.Parse((Math.Round(Double.Parse(sr[3]))).ToString());
                num++;
            }
            dataHtml = GenerateHTML(dataHtml, expRow, Convert.ToInt32(summa));
            //string zakaz = "<h4>Номер заказа: " + nomerZakaza + "</h4>";
            //string oficiant = "<h4>Официант: " + lblUser.Text + "</h4>";
            //dataHtml = zakaz+oficiant+"<h4>Официант: " + DateTime.Now.ToString("dd.MM.YYYY HH:mm")+ "</h4>" + dataHtml;
            sw.Write(dataHtml);
            sw.Close();
            //printing();
            string keyName = @"Software\Microsoft\Internet Explorer\PageSetup";
            using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(keyName, true))
            {
                if (key != null)
                {
                    string old_footer = (string)key.GetValue("footer");
                    string old_header = (string)key.GetValue("header");
                    key.SetValue("footer", "");
                    key.SetValue("header", "");

                    WebBrowser browser = new WebBrowser();
                    browser.DocumentText = dataHtml;
                    browser.DocumentCompleted += browser_DocumentCompleted;
                    browser.Print();
                    if (old_footer != null)
                        key.SetValue("footer", old_footer);
                    if (old_header != null)
                        key.SetValue("header", old_header);
                }
            }

            //PrintClass cl = new PrintClass();
            //cl.Printing();
        }

        private string GenerateHTML(string dataHtml, DataSetTpos.expenseRow expRow, int summa)
        {
            string temp = "";
            if (expRow.debt == 0)
            {
                temp = "<tr>" +
                                "<td colspan='1''>Наличные</td>" +
                                "<td colspan='2''>" + (Convert.ToInt32(expRow.expSum) - Convert.ToInt32(expRow.terminal)) + " сум</td>" +
                            "</tr>" +
                            "<tr>" +
                                "<td colspan='1''>Терминал</td>" +
                                "<td colspan='2''>" + Convert.ToInt32(expRow.terminal) + " сум</td>" +
                            "</tr>" +
                            "<tr><td colspan='4'>&nbsp;</td></tr>";
            }
            else
            {
                temp = "";
            }
            string html = "<head></head><body>" +
                    "<table style='font-size: 9px; font-family: Tahoma; width: 100%;'>" +
                        "<thead>" +
                            "<tr><td colspan='3' style=\"text-align:center\"> " + Properties.Settings.Default.orgName + "</td></tr>" +
                            "<tr><td colspan='3' style=\"text-align:center\">Дата: " + expRow.expenseDate.ToString("dd.MM.yyyy HH:mm") + "</td></tr>" +
                            "<tr><td colspan='3' style=\"text-align:right\">Касса: " + UserValues.CurrentUser + "</td></tr>" +
                            "<tr><td colspan='3' style=\"text-align:right\">Счет №: " + expRow.expenseId + "</td></tr>" +
                            "<tr><td colspan='3'></td></tr>" +
                            "<tr><td colspan='3' style='text-align:center; font-size:14px'>" + (expRow.expType == 1 ? "Возврат" : "Покупка") + "</td></tr>" +
                            "<tr>" +

                                "<th style='border-bottom: 1px solid #000;'>Наименование</th>" +
                                "<th style='border-bottom: 1px solid #000;'>Кол.</th>" +
                                "<th style='border-bottom: 1px solid #000;'>Цена</th>" +
                                "<th style='border-bottom: 1px solid #000;'>Сумма</th>" +
                            "</tr>" +
                        "<thead>" +
                        "<tbody>" + dataHtml +
                        "<tbody>" +
                        "<tfoot>" +
                            "<tr><td style='border-top:1px solid #000' colspan='4'> &nbsp;</td></tr>" +
                            temp +
                            "<tr>" +
                                "<th colspan='1'>Итого " + (expRow.debt == 1 ? "долг" : "") + " :</th>" +
                                "<th colspan='2'>" + summa + " сум</td>" +
                            "</tr>" +
                        "</tfoot>" +
                    "</table>" +
                "</body>";
            return html;
        }
        void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser browser = sender as WebBrowser;
            browser.Print();
        }

        private void libraBtn_Click(object sender, EventArgs e)
        {  
            rdshtbtn.Checked = false;
            rdkgBtn.Checked = false;
            allmsrbtn.Checked = false;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt = ExportExcel.ToDataTable(dgvTovar, "PC");
            ds.Tables.Add(dt);
            DataView dv = dgvTovar.DataSource as DataView;
                    
                    string prices = "";
                    int i = 1;
                    if (!tar.Connected)
                            tar.Connect();
                            
                    foreach (DataRow devc in dt.Rows)
                    {
                        
                        
                            prices = devc[5].ToString();
                            dv.RowFilter = "productId = " + devc[0].ToString();
                            tar.Password = 30;
                            tar.PLUNumber = Convert.ToInt32(devc[0]);
                            tar.Price = Convert.ToInt32(prices);
                            tar.ItemCode = Convert.ToInt32(devc[0]);
                            tar.NameFirst = devc[1].ToString();
                            tar.GroupCode = ((Convert.ToInt32(dv[0]["measureId"]) == 1) ? 20 : 21);

                            tar.GoodsType = ((Convert.ToInt32(dv[0]["measureId"]) == 1) ? 0 : 1);
                            tar.Tare = 0;

                            tar.NameSecond = "";
                            tar.PictureNumber = 0;
                            int t = 0;
                            if ((t = tar.SetPLUDataEx()) != 0)
                            {
                                MessageBox.Show(t.ToString());
                                break;
                                tar.Disconnect();
                            }
                        //}

                        i++;
                    }
                

            

/*            SaveFileDialog spf = new SaveFileDialog();
            spf.Filter = "*.txt|";
            spf.FileName = "Для весов" + DateTime.Now.ToString("dd.MM.yyyy") + ".txt";
            int i = 1;
            DataView dv = dgvTovar.DataSource as DataView;
            if (spf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = spf.FileName;
                File.Create(path).Dispose();
                Encoding enc = Encoding.GetEncoding(1251);
                using (TextWriter tw = new StreamWriter(path, false, enc))
                {
                    string prices = "";
                    string tempTxt = "";
                    int num = 1;
                    foreach (DataRow devc in dt.Rows)
                    {
                        prices = devc[5].ToString();
                        dv.RowFilter = "productId = " + devc[0].ToString();
                        i++;
                        tempTxt = num + ";" + devc[1].ToString() + "; ;" + prices + ";0;0;" + ((Convert.ToInt32(dv[0]["measureId"]) == 1) ? "20" : "21") + ";" +devc[0].ToString() + ";1;0; ;01.01.01;" + ((Convert.ToInt32(dv[0]["measureId"]) == 1) ? "0" : "1") + ";0;0;0;01.01.01";

                        tw.WriteLine(tempTxt);
                        dv.RowFilter = "";
                        num++;
                    }
                    tw.Close();
                }
            }*/
        }

        private void provCmbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cmbtxt = provCmbx.FindStringExact(provCmbx.Text);
            DataView dv = dgvSpisaniye.DataSource as DataView;
            dv.RowFilter = "providerId =" + cmbtxt;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            printerSettings printFormm = new printerSettings();
            printFormm.ShowDialog();
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm st = new SettingsForm(null);
            st.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            passForm passform = new passForm();
            if (passform.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.Close();
            }
        }


        private void hotKey_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string[] temp = btn.Name.Split('_');

            using (ProdList prodList = new ProdList(temp[1], btn.Text, (btn.Tag==null?"":btn.Tag.ToString())))
            {
                prodList.ShowDialog();
                string result = prodList.prodName;
                btn.Text = result;
                btn.Tag = prodList.id;
            }

        }

        private void сверкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProvReport pR = new ProvReport();
            pR.ShowDialog();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            users us = new users();
            us.ShowDialog();
        }

        private void menuAdmin_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void splitContainer3_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void button3_Click(object sender, EventArgs e)
        {
            
            Button btn = sender as Button;
            string[] temp = btn.Name.Split('_');
            using (ProdListLibra prodListLibra = new ProdListLibra(temp[1], btn.Text, libra))
            {
                if (!tar.Connected)
                    tar.Connect();
                
                DialogResult result = prodListLibra.ShowDialog();
                if (result == DialogResult.OK)
                {
                    tar.HotkeyValue = prodListLibra.prodId;
                    
                    btn.Text = prodListLibra.prodName;
                }
                else if (result == DialogResult.Cancel)
                {
                    if (prodListLibra.cleared == true)
                        btn.Text = prodListLibra.prodName;
                }
            }

                tar.Password = 30;
                tar.Hotkey = Convert.ToInt32(temp[1]);
                tar.HotkeyType = 13;
                tar.SetHotkeyValue();
                tar.Disconnect();
        }

        private void libraCmx_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            //tar.RemoteHost = lDr["ipAddress"].ToString();
            //tar.DeviceInterface = 1;
            //if (tar.Connect() != 0)
            //{
            //    isDisc = true;
            //    tars += lDr["name"].ToString() + ", ";
            //}
            ComboBox cmbx = sender as ComboBox;
            string name = cmbx.SelectedItem.ToString();
            DataRow[] dt = DBclass.DS.libra.Select("name = '" + name + "'");
            libra = Convert.ToInt32(dt[0]["libraId"]);
            hotkeyLibraLoad();
        }

        private void отчетВExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void отчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dtProguct = DBclass.DS.product;
            


            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Visible = true;
            excel.Workbooks.Add();
            Microsoft.Office.Interop.Excel.Worksheet workSheet = (Microsoft.Office.Interop.Excel.Worksheet)excel.ActiveSheet;

            workSheet.Cells[1, 1] = "Материальный отчет по складу период от " + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + ".";
            workSheet.Cells[5, 1] = "ТМЦ";
            
            int rowExcel = 6;
            workSheet.Cells[4, 2] = "Сальдо на 01.01.17";
            workSheet.Cells[5, 2] = "Кол-во";
            workSheet.Cells[5, 3] = "Цена";
            workSheet.Cells[5, 4] = "Сумма";
            //for (int i = 0; i < dtProguct.Rows.Count; i++)
            //{
            //    workSheet.Cells[rowExcel, 1] = dtProguct.Rows[i].Field<string>("");
            //    workSheet.Cells[rowExcel, 2] = dtProguct.Rows[i].Field<int>("");
            //    workSheet.Cells[rowExcel, 3] = dtProguct.Rows[i].Field<int>("");
            //    workSheet.Cells[rowExcel, 4] = dtProguct.Rows[i].Field<int>("");
            //    ++rowExcel;
            //}

            workSheet.Cells[4, 5] = "Приход";
            workSheet.Cells[5, 5] = "Кол-во";
            workSheet.Cells[5, 6] = "Цена";
            workSheet.Cells[5, 7] = "Сумма";
            //for (int i = 0; i < dtProguct.Rows.Count; i++)
            //{
            //    workSheet.Cells[rowExcel, 1] = dtProguct.Rows[i].Field<string>("");
            //    workSheet.Cells[rowExcel, 2] = dtProguct.Rows[i].Field<int>("");
            //    workSheet.Cells[rowExcel, 3] = dtProguct.Rows[i].Field<int>("");
            //    workSheet.Cells[rowExcel, 4] = dtProguct.Rows[i].Field<int>("");
            //    ++rowExcel;
            //}

            workSheet.Cells[4, 8] = "Возврат";
            workSheet.Cells[5, 8] = "Кол-во";
            workSheet.Cells[5, 9] = "Цена";
            workSheet.Cells[5, 10] = "Сумма";
            //for (int i = 0; i < dtProguct.Rows.Count; i++)
            //{
            //    workSheet.Cells[rowExcel, 1] = dtProguct.Rows[i].Field<string>("");
            //    workSheet.Cells[rowExcel, 2] = dtProguct.Rows[i].Field<int>("");
            //    workSheet.Cells[rowExcel, 3] = dtProguct.Rows[i].Field<int>("");
            //    workSheet.Cells[rowExcel, 4] = dtProguct.Rows[i].Field<int>("");
            //    ++rowExcel;
            //}

            MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand("SELECT p.productId, p.name,  bl.balanceId, bl.balanceDate, bl.endCount, bl.curEndCount  FROM  product as p"
+"left join balancelist as bl  on bl.prodId = p.productId "

+"where bl.balanceDate = '2017-07-19'"
+"order by p.productId asc");


        }

        private void отчетToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void отчетПоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports rport = new Reports(productTableAdapter1.Connection);
            DateSelectForm dsf = new DateSelectForm(true, false);
            if (dsf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                rport.Selling(dsf.beginDate, dsf.endDate);
            }
        }

        private void Reports_click(object sender, EventArgs e)
        {
            Reports rport = new Reports(productTableAdapter1.Connection);
            DateSelectForm dsf = new DateSelectForm(true, false);
            
            ToolStripMenuItem menustrip = sender as ToolStripMenuItem;
            switch (menustrip.Name)
            {
                case "menustripOstatokReport":
                    if (dsf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        rport.Selling(dsf.beginDate, dsf.endDate);
                    }
                    break;
                case "menustripPeriodReport":
                    if (dsf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        rport.PeriodProfid(dsf.beginDate, dsf.endDate);
                    }
                    break;
                case "menustripTodayReport":
                    rport.TodayOrdersReport("now()");
                    break;
                case "menuDateReport":
                    dsf = new DateSelectForm(false, false);
                    if (dsf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        rport.TodayOrdersReport("'"+dsf.beginDate.ToString("yyyy-MM-dd")+"'");
 
                    }    
                    break;
                case "menuKassaDateReport":
                    dsf = new DateSelectForm(false, true);
                    if (dsf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        rport.userID = dsf.SelectCashier.ToString();
                        rport.TodayOrdersReport("'" + dsf.beginDate.ToString("yyyy-MM-dd") + "'");
                        
                    }
                    break;

            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnGetFaktura_Click(object sender, EventArgs e)
        {
            string curfaktura = Configs.GetConfig("currentFaktura");
            if (curfaktura != "0")
            {
                if (MessageBox.Show("Предупреждение", "Закрыть фактуру с номером " + curfaktura, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    Configs.SetConfig("currentFaktura", "0");
                    curfaktura = "0";
                }
            }
            SubForms.GetFakturaForm fakturaForm = new SubForms.GetFakturaForm();
            if (curfaktura=="0"&&fakturaForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.realizeviewTableAdapter1.FillByFaktura(DBclass.DS.realizeview, fakturaForm.fakturaId);
                DataView realize = new DataView(DBclass.DS.realizeview);
                //realize.RowFilter = realize;
                

                realizeGrid.DataSource = realize;

                fakturaTableAdapter daFaktura = new fakturaTableAdapter();
                daFaktura.Fill(DBclass.DS.faktura);
                
                idFaktura = fakturaForm.fakturaId;
                isPrixod = true;
                realizeGrid.Columns["colBtnDel"].Visible = true;
                reportDate.Value = ((DataSetTpos.fakturaRow) DBclass.DS.faktura.Select("fakturaId = " + idFaktura)[0]).fakturaDate;
                realizeSumm();
                lblFakturaNumber.Text = "№ Фактуры:" + idFaktura;
            }

        }

        private void cbxUsersSchet_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataView dvEx = dgvExpense.DataSource as DataView;
            if (cbxUsersSchet.SelectedIndex!= 0&&dvEx.Table.Rows.Count!=0)
            {
                
                //dvEx.RowFilter = "IDUser = " + cbxUsersSchet.SelectedValue;
            }
        }

        private void balanceGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {

            }
        }

        private void btnCreateInventory_Click(object sender, EventArgs e)
        {
            inventoryTableAdapter invDa = new inventoryTableAdapter();
            object obj = invDa.GetLastId();
            int lastId = -1;
            if (obj != null)
                lastId = (int)obj;

            if (lastId == -1)
            {
                if (MessageBox.Show("Начать инвентаризацию?", "Запрос", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {

                    DataSetTpos.inventoryRow invRow = DBclass.DS.inventory.NewinventoryRow();
                    invRow.InventoryDate = DateTime.Now;
                    invRow.IsClose = 0;
                    invRow.userId = UserValues.CurrentUserID;
                    DBclass.DS.inventory.AddinventoryRow(invRow);
                    invDa.Update(DBclass.DS.inventory);

                    lastId = (int)invDa.GetLastId();
                    lblNumberInv.Text = lastId.ToString();
                    btnCreateInventory.Text = "Закрыть инвен-ю";
                    tabControl1_SelectedIndexChanged(tabControl1, new EventArgs());
                    

                }
            }else
            if (MessageBox.Show("Закрыть инвентаризацию?", "Запрос", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                invDa.CloseInventory(lastId);
                btnCreateInventory.Text = "Инвентаризовать";

            }


                //int idInv = 1;
                //DateTime lastInvetory = DateTime.Now.Date.AddDays(7);
                //string InvDate = Configs.GetConfig("LastInventoryDate");
                //if (InvDate == "")
                //{
                //    Configs.SetConfig("BeginInventoryDate", DateTime.Now.Date.ToString());
                //    Configs.SetConfig("LastInventoryDate", lastInvetory.ToString());
                //}
                //else
                //{
                //    lastInvetory = DateTime.Parse(InvDate);
                //}

                //if (DBclass.DS.balancechange.Rows.Count > 0)
                //{
                //    DataSetTpos.balancechangeRow bcRow = DBclass.DS.balancechange.Last<DataSetTpos.balancechangeRow>();
                //    idInv = bcRow.docNumber;

                //    idInv++;

                //    DataSetTpos.balancechangeRow blChangeRow = DBclass.DS.balancechange.NewbalancechangeRow();

                //    Configs.SetConfig("InvNumber", idInv.ToString());




                //}
                //lblNumberInv.Text = idInv.ToString();

            }

        private void dgvSpisaniye_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                SubForms.FormSpisaniye formSpis = new SubForms.FormSpisaniye((int)dgvSpisaniye.Rows[e.RowIndex].Cells["productId"].Value);
                if (formSpis.ShowDialog() == DialogResult.OK)
                {
                    
                }
                //dgvSpisaniye.Rows[e.RowIndex].Cells[]
            }
        }

        private void dgvBalanceChange_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvBalanceChange.Columns["prodId"].Index == e.ColumnIndex&& e.RowIndex>-1)
            {
                //dgvBalanceChange.Rows[e.RowIndex].Cells["colProduct"].Value = 
            }
        }

        private void btnDiscount_Click(object sender, EventArgs e)
        {
            ProdListDiscount pd = new ProdListDiscount();
            pd.ShowDialog();
        }

        private void menuClients_Click(object sender, EventArgs e)
        {
            Debts.ClientsForm clients = new Debts.ClientsForm(false);
            clients.ShowDialog();
        }

        private void menuDebtType_Click(object sender, EventArgs e)
        {
            Debts.DebtTypeForm debttype = new Debts.DebtTypeForm();
            debttype.ShowDialog();
        }

        private void menuDebt_Click(object sender, EventArgs e)
        {
            Debts.DebtForm debtForm = new Debts.DebtForm();
            debtForm.ShowDialog();
            

        }
    }
}
