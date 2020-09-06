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
using Microsoft.Win32;
using System.IO;
using System.Diagnostics;
namespace tposDesktop
{
    public partial class MainFormTouch : Form
    {
        DBclass db;
        Scanner scan;
        DataSetTpos.ordersDataTable order;
        int contId = 0;
        string commentDebt = "";
        int terminalSum = 0;
        bool isNewExpense = true;
        object packCount = 0;
        bool backDate = false;
        private bool actionMath = false;
        private string action = "";
        private int discountId = -1;
        private string key_num = "";
        int ExpenseId = 0;
        private Button activeBtn;
        private int tempExpeId = -1;
        public MainFormTouch()
        {
            InitializeComponent();

            if (Configs.GetConfig("IsPercentAll") != "" && Configs.GetConfig("IsPercentAll") == "True")
            {
                this.chbReb.Text = Configs.GetConfig("PercentAll") + "%";
                this.chbReb.Visible = true;
            }

            DBclass.DS.orders.Clear();
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            loadBtn();
            this.Icon = tposDesktop.Properties.Resources.mainIcon;
            db = new DBclass(true);
            db.FillExpense("");
            db.FillProduct();

            isPrinter = Properties.Settings.Default.isPrinter;
            SetIsPrinter();
            productviewTableAdapter prVda = new productviewTableAdapter();
            prVda.Fill(DBclass.DS.productview);
            /////Initializ LOGS
            //Logs logs = new Logs();
            ///initialize config table and class
            configsTableAdapter cfgDa = new configsTableAdapter();
            cfgDa.Fill(DBclass.DS.configs);
            Configs cfgs = new Configs();

            GetDiscountConfig();

            if (!(DBclass.DS.orders.Columns["sumProduct"] is DataColumn))
                DBclass.DS.orders.Columns.Add("sumProduct", typeof(int));
            DataView dv = new DataView(DBclass.DS.productview);
            DataView bl = new DataView(DBclass.DS.balanceview);
            bl.RowFilter = "balanceDate = '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
            if (bl.Count == 0)
            {

                OpenDay op = new OpenDay();
                if (op.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    backDate = true;
                }

                prVda.Fill(DBclass.DS.productview);


            }
            tbxSearchTovar.Focus();
            DataView dvOr = new DataView(DBclass.DS.orders);
            dvOr.RowFilter = "expenseId = -1";
            dvOr.Sort = "orderId desc";
            dgvTovar.DataSource = dv;
            dgvExpense.DataSource = dvOr;

            dv.RowFilter = " not price = 0";
            dv.Sort = "name asc";
            dgvExpense.EditingControlShowing += dgv_EditingControlShowing;
            dgvTovar.Focus();
            if (UserValues.role == "admin")
            {
                menuAdmin.Visible = true;
            }
            try
            {
                if (Properties.Settings.Default.IsCom)
                {
                    scan = new Scanner();
                    scan.ScannerEvent += scan_ScannerEvent;
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

            changeselTableAdapter chs = new changeselTableAdapter();
            chs.Fill(DBclass.DS.changesel);
            DataSetTpos.changeselDataTable table = new DataSetTpos.changeselDataTable();
            DataRow[] dt = DBclass.DS.changesel.Select("userId = " + UserValues.CurrentUserID + " and endTime is null");
            if (dt.Count() == 0)
            {
                DataSetTpos.changeselRow row = DBclass.DS.changesel.NewchangeselRow();
                row.userId = UserValues.CurrentUserID;
                row.startTime = DateTime.Now;
                DBclass.DS.changesel.AddchangeselRow(row);
                chs.Update(row);
                chs.Fill(DBclass.DS.changesel);
            }

        }

        private void GetDiscountConfig()
        {
            
            string discount_val = Configs.GetConfig("discountVal");
            if (discount_val != "" && discount_val != "0")
            {
                discountId = Convert.ToInt32(discount_val);
                v_discountTableAdapter discountpDa = new v_discountTableAdapter();
                discountpDa.Fill(DBclass.DS.v_discount, discountId);
            }
            else
            {
                chbDiscount.Checked = false;
                chbDiscount.Visible = false;
            }
        }
        private void loadBtn()
        {
            DBclass.DS.hotkeys.Clear();
            this.hotkeysTableAdapter1.Fill(DBclass.DS.hotkeys);
            DataView htk = new DataView(DBclass.DS.hotkeys);
            for (int i = 1; i <= 30; i++)
            {
                Button btn1 = this.Controls.Find("hot_" + i, true).FirstOrDefault() as Button;
                if (btn1 != null)
                    btn1.Tag = null;
                btn1.Text = i.ToString();
            }
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

                // btn = this.Controls.Find("hot_" + temp["btnId"], true).FirstOrDefault() as Button;
                btn.Text = temp["prodId"].ToString();
            }
        }

        private void hotKeyBtn_Click(object sender, EventArgs e)
        {

            Button btn = sender as Button;
            if (btn.Tag != null)
            {
                string prName = btn.Text;
                string btnid = btn.Tag.ToString();
                int n;
                bool isNumeric = int.TryParse(prName, out n);
                DataSetTpos.productRow[] prRows = (DataSetTpos.productRow[])DBclass.DS.product.Select("productId = " + btnid);
                if (prRows.Length > 0 && isNumeric == false)
                {
                    AddProduct(prRows, false, null);
                }
                dgvTovar.Focus();
            }
        }


        BackgroundWorker bgw;

        System.Windows.Forms.Form form;
        public void openday()
        {
            DBclass db = new DBclass();
            bgw = new BackgroundWorker();
            bgw.DoWork += db.bgw_DoWorkOpenDay;
            bgw.RunWorkerAsync();
        }
        BackgroundWorker bgwPrint;
        public void PrintingWork(List<string[]> drPrintCol, DataSetTpos.expenseDataTable expTable)
        {
            bgwPrint = new BackgroundWorker();
            bgwPrint.DoWork += bgwPrint_DoWork;
            bgwPrint.RunWorkerAsync(new object[] { drPrintCol, expTable });
        }

        void bgwPrint_DoWork(object sender, DoWorkEventArgs e)
        {
            List<string[]> drPrintCol = (List<string[]>)(e.Argument as object[])[0];
            DataSetTpos.expenseDataTable expTable = (DataSetTpos.expenseDataTable)(e.Argument as object[])[1];
            forPrinting(drPrintCol, expTable);
        }

        public void Triggering(string triggerName, DataSetTpos.expenseDataTable expTable)
        {
            if (bgw == null)
            {
                bgw = new BackgroundWorker();
                bgw.DoWork += bgw_triggering;
            }

            bgw.RunWorkerAsync(new object[] { triggerName, expTable });


        }

        void bgw_triggering(object sender, DoWorkEventArgs e)
        {
            //Logs.SetLog("--------------------", Logs.LogStatus.Info);
            DataSetTpos.expenseDataTable expTable = (DataSetTpos.expenseDataTable)((object[])e.Argument)[1];
            int expId;
            //DataSetTpos.ordersRow[] orRows = (DataSetTpos.ordersRow[])DBclass.DS.orders.Select("expenseId = " + tempExpeId);
            //foreach (DataSetTpos.ordersRow oneRow in orRows)
            //{
            //    oneRow.expenseId = (expTable.Rows[0] as DataSetTpos.expenseRow).expenseId;
            //    Logs.SetLog("exp:" + oneRow.expenseId + " orders:prodId:" + oneRow.prodId + ", orderSum:" + oneRow.orderSumm + ", cnt:" + oneRow.packCount, Logs.LogStatus.Info);
            //}
            expId = Convert.ToInt32((expTable.Rows[0] as DataSetTpos.expenseRow).expenseId);
            //ExpenseId = expId;
            //Logs.SetLog("updating orders,exp:" + expId, Logs.LogStatus.Info);
            //ordersTableAdapter prDa = new ordersTableAdapter();
            //prDa.Update(DBclass.DS.orders);
            //Logs.SetLog("end update orders,exp:" + expId, Logs.LogStatus.Warning);
            //getPriceTableAdapter getPriceda = new getPriceTableAdapter();
            ////DBclass dbC = new DBclass();
            //foreach (DataSetTpos.ordersRow oneRow in orRows)
            //{
            //            DBclass.DS.orders.RemoveordersRow(oneRow);
            //}
            //this.Invoke(new delDgvRefresh(dgvRefresh));
            DBclass dbC = new DBclass();
            string triggerName = (string)((object[])e.Argument)[0];
            //int expId = (int)((object[])e.Argument)[1];
            dbC.triggerExecute(triggerName, expId);

            //Logs.SetLog("------End Trigger------", Logs.LogStatus.Warning);
        }



        Stack<ProductOne> stBarcode = new Stack<ProductOne>();

        void scan_ScannerEvent(object source, ScannerEventArgs e)
        {

            this.Invoke(new SetLabel(AddToOrders), new object[] { e.GetInfo() });



        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (scan != null)
            {
                scan.isWorked = false;
                scan.rd.ClosePort(scan.port);
            }
            if (Program.window_type != 1 && Program.window_type != 3)
                Program.window_type = 0;

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //btnDolg.BackgroundImage = Properties.Resources.qarz;
            timer.Start();
            // TODO: This line of code loads data into the 'dataSetTpos.orders' table. You can move, or remove it, as needed.
            this.ordersTableAdapter.Fill(this.dataSetTpos.orders);
            dgvTovar.Columns["productId"].HeaderText = "№";
            dgvTovar.Columns["name"].HeaderText = "Товар";
            dgvTovar.Columns["price"].HeaderText = "Цена";
            dgvTovar.Columns["endCount"].HeaderText = "Кол.";
            dgvTovar.Columns["balanceDate"].Visible = false;
            dgvTovar.Columns["providerId"].Visible = false;
            dgvTovar.Columns["barcode"].Visible = false;
            //dgvTovar.Columns["pack"].Visible = false;
            //dgvTovar.Columns["status"].Visible = false;
            //dgvTovar.Columns["balanceT"].Visible = false;
            dgvTovar.Columns["productId"].Width = 40;
            dgvTovar.Columns["name"].Width = 150;
            dgvTovar.Columns["price"].Width = 50;
            dgvTovar.Columns["endCount"].Width = 40;
            Classes.GridCells.ImageButtonColumn cellBtn = new Classes.GridCells.ImageButtonColumn();
            cellBtn.HeaderText = "";
            cellBtn.Name = "colBtn";
            cellBtn.Width = 30;
            //Classes.GridCells.ImageCell cellImg = new Classes.GridCells.ImageCell();
            cellBtn.SetImage(Properties.Resources.add);

            dgvTovar.Columns.Add(cellBtn);

            dgvExpense.Columns["prodId"].Visible = false;
            dgvExpense.Columns["orderId"].Visible = false;
            dgvExpense.Columns["expenseId"].Visible = false;
            dgvExpense.Columns["count"].Visible = false;
            dgvExpense.Columns["packCount"].HeaderText = "Кол.";
            dgvExpense.Columns["packCount"].ValueType = typeof(double);
            dgvExpense.Columns["productName"].ReadOnly = false;
            dgvExpense.Columns["packCount"].ReadOnly = false;
            dgvExpense.Columns["sumProduct"].ReadOnly = false;
            dgvExpense.Columns["productName"].Width = 250;
            dgvExpense.Columns["packCount"].Width = 60;
            dgvExpense.Columns["discount"].HeaderText = "%";
            dgvExpense.Columns["discount"].Visible = false;
            //dgvExpense.Columns["packCount"].CellType = typeof(double);

            dgvExpense.Columns["productName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvExpense.Columns["sumProduct"].HeaderText = "Сумма";
            dgvExpense.Columns["sumProduct"].Width = 70;
            dgvExpense.Columns["orderSumm"].Visible = false;

            DataGridViewButtonColumn cellBtn2 = new System.Windows.Forms.DataGridViewButtonColumn();
            cellBtn2.HeaderText = "";
            cellBtn2.Name = "colBtnMinus";
            cellBtn2.Width = 40;
            cellBtn2.DisplayIndex = 2;
            dgvExpense.Columns.Add(cellBtn2);

            DataGridViewButtonColumn cellBtn3 = new System.Windows.Forms.DataGridViewButtonColumn();
            cellBtn3.HeaderText = "";
            cellBtn3.Name = "colBtnPlus";
            cellBtn3.Width = 40;
            cellBtn3.DisplayIndex = 8;
            dgvExpense.Columns.Add(cellBtn3);


            DataGridViewButtonColumn cellBtnDel = new System.Windows.Forms.DataGridViewButtonColumn();
            cellBtnDel.HeaderText = "";
            cellBtnDel.Name = "colBtnDel";
            cellBtnDel.Width = 40;
            cellBtnDel.DisplayIndex = 11;
            dgvExpense.Columns.Add(cellBtnDel);


            //cellTx.CellType = typeof(int);
            //dgvExpense.Columns.Add(cellTx);
            foreach (DataGridViewColumn column in dgvExpense.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }


            if (backDate == true)
            {
                Program.window_type = 1;
                Program.backDate = false;
                System.Windows.Forms.MessageBox.Show("Проверьте правильность даты на компьютере или обратитесь в службу поддержки");
                this.Close();
            }

            dgvTovar.Focus();

        }

        private void tbxSearchTovar_TextChanged(object sender, EventArgs e)
        {
            TextBox tbx = sender as TextBox;

            try
            {
                DataView dv = dgvTovar.DataSource as DataView;

                if (tbx.Name == "tbxSearchTovar" && tbx.Text != "По имени")
                {
                    dv.RowFilter = "name like '%" + tbx.Text + "%' and not price = 0";
                }
                else if (tbx.Name == "tbxSearchPrice" && tbx.Text != "По цене")
                {
                    dv.RowFilter = "price+'' like '" + (tbx.Text == "" ? "0" : tbx.Text) + "%' and not price = 0";

                }

                dv.Sort = "name asc";
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dgvTovar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;
            if (grid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                AddToOrders((int)grid.Rows[e.RowIndex].Cells["productid"].Value);


            }
        }
        private void dgvExpense_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;
            if (grid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                DataSetTpos.ordersRow[] ordRows;
                if (dgvExpense.Columns[e.ColumnIndex].Name == "colBtnPlus")
                {
                    float i = float.Parse(dgvExpense.Rows[e.RowIndex].Cells["packCount"].Value.ToString());
                    //int i = (int)d;
                    //d = d - i;
                    //d = Math.Round(d, 3);
                    //AddToOrders(int.Parse(dgvExpense.Rows[e.RowIndex].Cells["prodId"].Value.ToString()));
                    ordRows = (DataSetTpos.ordersRow[])DBclass.DS.orders.Select("prodId = " + dgvExpense.Rows[e.RowIndex].Cells["prodId"].Value.ToString());

                    i++;
                    //d =(((double)i)+d);
                    //dgvExpense.Rows[e.RowIndex].Cells["orderSumm"] = double.Parse(dgvExpense.Rows[e.RowIndex].Cells["packCount"].ToString())*
                    dgvExpense.Rows[e.RowIndex].Cells["packCount"].Value = i;
                    ordRows[0]["orderSumm"] = dgvExpense.Rows[e.RowIndex].Cells["sumProduct"].Value;
                    //drOrder["orderSumm"] = ordrow.packCount * drP.price;

                    //i++;
                    //dgvExpense.Rows[e.RowIndex].Cells["packCount"].Value = i;
                }
                else if (dgvExpense.Columns[e.ColumnIndex].Name == "colBtnMinus")
                {
                    if (float.Parse(dgvExpense.Rows[e.RowIndex].Cells["packCount"].Value.ToString()) == 1)
                    {
                        dgvExpense.Rows.RemoveAt(e.RowIndex);
                        sumTable();
                    }
                    else
                    {
                        float i = float.Parse(dgvExpense.Rows[e.RowIndex].Cells["packCount"].Value.ToString());

                        ordRows = (DataSetTpos.ordersRow[])DBclass.DS.orders.Select("prodId = " + dgvExpense.Rows[e.RowIndex].Cells["prodId"].Value.ToString());

                        i--;
                        dgvExpense.Rows[e.RowIndex].Cells["packCount"].Value = i;
                        ordRows[0]["orderSumm"] = dgvExpense.Rows[e.RowIndex].Cells["sumProduct"].Value;
                    }

                }
                else if (dgvExpense.Columns[e.ColumnIndex].Name == "colBtnDel")
                {
                    dgvExpense.Rows.RemoveAt(e.RowIndex);
                    sumTable();
                }


            }
        }

        private void dgvExpenseRow_Click(object sender, DataGridViewCellEventArgs e)
        {
            actionMath = true;
        }
        private void AddToOrders(int id)
        {
            DataRow[] dr = DBclass.DS.product.Select("productId = " + id);
            AddProduct(dr, false, null);
        }

        private void AddToOrders(string barcode)
        {
            if (stBarcode.Count == 0)
            {
                DataRow[] dr = DBclass.DS.product.Select("barcode = '" + barcode + "'");
                AddProduct(dr, true, barcode);
            }
            else
            {
                DataRow[] dr = DBclass.DS.product.Select("barcode = '" + barcode + "'");
                stBarcode.Push(new ProductOne(barcode, dr));

            }

        }

        private int CheckDiscount(int productId)
        {
            DataSetTpos.v_discountRow[] discRows = FindDiscountByproductId(productId);

            if (discRows.Length > 0 && chbDiscount.Checked)
            {
                return discRows[0].discount;
            }
            else
            {
                return 0;
            }
                
        }

        public DataSetTpos.v_discountRow[] FindDiscountByproductId(int productId)
        {
            return (DataSetTpos.v_discountRow[])(DBclass.DS.v_discount.Select("productId =" + productId.ToString()));
        }
        private double GetDiscountSum(int productId, double sum)
        {
            double discountSum = 0;
            //checking discount
            if (discountId != -1)
            {
                int discount = CheckDiscount(productId);
                if (discount != 0)
                {
                    discountSum = sum / 100 * discount;
                }

            }
            return discountSum;
        }

        private void AddProduct(DataRow[] dr, bool isBarcode, string barcode)
        {

            bool next = false;
            do
            {
                if (next)
                {
                    ProductOne po = stBarcode.Pop();
                    barcode = po.barcode;
                    dr = po.drow;
                }
                float kg = -1;
                if (isBarcode && dr.Length == 0)
                {
                    //object[] obj = getProductWithMassa(barcode);
                    //dr = (DataRow[])obj[0];
                    //kg = (float)obj[1];
                    if (barcode.Length >= 12)
                    {
                        dr = getProductWithMassa(barcode);
                    }
                }

                if (dr.Length != 0)
                {
                    

                    DataSetTpos.productRow drP = (DataSetTpos.productRow)dr[0];
                    float discountSum = 0;

                    if (drP.price == 0)
                    {
                        MessageBox.Show("Товара нет на складе. Обратитесь к администратору");
                        return;
                    }
                    //KolForm kolform = new KolForm(drP);
                    //if (kolform.ShowDialog() == DialogResult.OK)
                    //{
                    //    drP.pack = kolform.count;
                    //}
                    //else { return; }

                    DataRow[] existRows = DBclass.DS.orders.Select("expenseId=" + tempExpeId + " and prodId = " + drP.productId);
                    if (existRows.Length > 0)
                    {
                        DataSetTpos.ordersRow ordrow = (DataSetTpos.ordersRow)existRows[0];
                       
                       
                        ordrow.packCount = ordrow.packCount + (drP.pack == 0 ? 1 : drP.pack);
                        
                        if (ordrow.packCount <= 0) ordrow.packCount = 1;

                        DataRow drOrder = ordrow;
                        double summ = ordrow.packCount * drP.price;//ordrow.AcceptChanges();
                        ordrow.discount = (discountId!=-1? CheckDiscount(drP.productId):0);
                        drOrder["sumProduct"] = summ - GetDiscountSum(drP.productId, summ);

                        ordrow.orderSumm = Convert.ToSingle(drOrder["sumProduct"]);
                    }
                    else
                    {
                        DataSetTpos.ordersRow ordrow = DBclass.DS.orders.NewordersRow();



                        ordrow.prodId = drP.productId;
                        if (drP.pack == 0) drP.pack = 1;
                        ordrow.expenseId = tempExpeId;
                        int curPrice = drP.price;
                        //OrderForm oform = new OrderForm(drP);
                        //oform.ShowDialog();
                        if (drP.price != 0)
                        {
                            ordrow.packCount = drP.pack;
                            double summ = Math.Round(drP.price * drP.pack);
                            
                            DataRow drOrder = ordrow;
                            ordrow.discount = (discountId != -1 ? CheckDiscount(drP.productId) : 0);
                            drOrder["sumProduct"] = summ - GetDiscountSum(drP.productId, summ); ;
                            ordrow.orderSumm = Convert.ToSingle(drOrder["sumProduct"]);//ordrow.packCount * drP.price / (drP.pack == 0 ? 1 : drP.pack);

                            //grid.Rows[e.RowIndex].Cells["sumProduct"].Value = (Convert.ToInt32(grid.Rows[e.RowIndex].Cells["packCount"].Value) * Convert.ToInt32(grid.Rows[e.RowIndex].Cells["productPrice"].Value)).ToString();
                        }
                        else
                        {
                            if (drP.price == 0)
                            {
                                MessageBox.Show("Товар на складе отсутствует");
                                drP.RejectChanges();
                            }
                            return;
                        }
                        DBclass.DS.orders.AddordersRow(ordrow);
                        if (curPrice != drP.price && drP.price != 0)
                        {

                            productTableAdapter prda = new productTableAdapter();
                            prda.Update(drP);
                        }

                    }
                    if (isNewExpense)
                    {
                        //dgvExpense.Columns["productName"].Visible = true;
                        //dgvExpense.Columns["productPrice"].Visible = true;
                        isNewExpense = false;
                    }
                    sumTable();
                }
                else if (isBarcode && UserValues.role == "admin")
                {
                    AddForm addForm = new AddForm(barcode);
                    if (addForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        //productTableAdapter daProduct = new productTableAdapter();
                        //daProduct.Fill(DBclass.DS.product);


                    }

                }
                else if (isBarcode && UserValues.role == "user")
                {
                    MessageBox.Show("Нет такого товара на складе. Обратитесь к администратору.");
                }

                next = true;
            } while (stBarcode.Count != 0);
            dgvExpense.Refresh();
            tbxSearchTovar.Text = "";
            tbxSearchTovar.Focus();
        }



        private DataRow[] getProductWithMassa(string barcode)
        {
            int prefix = Int32.Parse(barcode.Substring(0, 2));
            if (prefix == 25 || prefix == 20)
            {
                barcode = barcode.Substring(2);
                string id = barcode.Substring(0, 5);
                string kg = barcode.Remove(0, 5).Substring(0, 5);
                char pnt = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0];
                System.Globalization.NumberFormatInfo numberformat = new System.Globalization.NumberFormatInfo();

                kg = kg.Insert(2, numberformat.CurrencyDecimalSeparator + "");
                //float kgf = Convert.ToSingle(kg);
                DataRow[] dr = DBclass.DS.product.Select("productId = " + Convert.ToInt32(id));
                if (dr.Length != 0)
                {
                    ((DataSetTpos.productRow)dr[0]).pack = float.Parse(kg, numberformat);
                }
                return dr;
            }
            else if (prefix == 21)
            {
                barcode = barcode.Substring(2);
                string id = barcode.Substring(0, 5);
                string sht = barcode.Remove(0, 5).Substring(0, 5);
                //sht = sht.Insert(2, ".");
                //float kgf = Convert.ToSingle(kg); 
                DataRow[] dr = DBclass.DS.product.Select("productId = " + Convert.ToInt32(id));
                if (dr.Length != 0)
                {
                    ((DataSetTpos.productRow)dr[0]).pack = Convert.ToSingle(sht);
                }
                return dr;
            }
            DataRow[] dr1 = { };
            return dr1;
            //new object[] { dr, kgf };
        }
        private void dgvSchet_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            var grid = (DataGridView)sender;
            if (grid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (grid.Name == "dgvTovar")
                {
                    DataGridViewButtonCell dgvCell = (DataGridViewButtonCell)grid.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    dgvCell.Value = "+";

                }
                else
                {
                    DataGridViewButtonCell dgvCell;
                    if (dgvExpense.Columns[e.ColumnIndex].Name == "colBtnPlus")
                    {
                        dgvCell = (DataGridViewButtonCell)grid.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        dgvCell.Value = "+";
                    }
                    else if (dgvExpense.Columns[e.ColumnIndex].Name == "colBtnMinus")
                    {
                        dgvCell = (DataGridViewButtonCell)grid.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        dgvCell.Value = "-";
                    }
                    else if (dgvExpense.Columns[e.ColumnIndex].Name == "colBtnDel")
                    {
                        dgvCell = (DataGridViewButtonCell)grid.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        dgvCell.Value = "Х";
                    }
                }
            }

        }

        List<string[]> drPrintCol;
        bool isTerminal = false;
        delegate void delDgvRefresh();
        public void dgvRefresh()
        {
            dgvExpense.Refresh();
        }

        private void btnOplata_Click(object sender, EventArgs e)
        {
            Oplata();
        }

        public void Oplata(int charge, double debtsum, int debttypeId, double beginSum)
        {
            
            //Logs.SetLog("_____________", Logs.LogStatus.Info);
            drPrintCol = new List<string[]>();

            //Logs.SetLog("Begin expense", Logs.LogStatus.Info);
            expenseTableAdapter expDa = new expenseTableAdapter();
            expDa.Adapter.SelectCommand = new MySql.Data.MySqlClient.MySqlCommand("select * from expense order by expenseId desc limit 1", expDa.Connection);
            DataSetTpos.expenseDataTable expTable = new DataSetTpos.expenseDataTable();
            DataSetTpos.expenseRow expRow = expTable.NewexpenseRow();
            double sum = 0;
            int num = 1;
            foreach (DataGridViewRow dgvRow in dgvExpense.Rows)
            {
                forPrintingNew(num.ToString(), dgvRow.Cells["ProductName"].Value.ToString(), dgvRow.Cells["packCount"].Value.ToString(), (Convert.ToDouble(dgvRow.Cells["productPrice"].Value) - (discountId != -1 ? GetDiscountSum((int)dgvRow.Cells["prodId"].Value, Convert.ToDouble(dgvRow.Cells["productPrice"].Value)) : 0)).ToString(), dgvRow.Cells["orderSumm"].Value.ToString());
                num++;

                sum += Math.Round(Double.Parse(dgvRow.Cells["orderSumm"].Value.ToString()));//Math.Round(Double.Parse(dgvRow.Cells["packCount"].Value.ToString()) * Double.Parse((Convert.ToDouble(dgvRow.Cells["productPrice"].Value) - (discountId != -1 ? GetDiscountSum((int)dgvRow.Cells["prodId"].Value, Convert.ToDouble(dgvRow.Cells["productPrice"].Value)) : 0)).ToString()));

            }

            if (debtsum != 0)
            {
                sum = debtsum;
                this.chbReb.Checked = false;
            }
            var percentPens = Double.Parse(((100 - Double.Parse(Configs.GetConfig("PercentAll"))) / 100).ToString());
            if (this.chbReb.Checked)
            {

                sum = sum * percentPens;
                expRow.charge = int.Parse(Configs.GetConfig("PercentAll")) * -1;
            }
            else if(charge!=0)
            {
                expRow.charge = charge;
            }
            else 
            {
                expRow.charge = 0;
            }

            expRow.expenseDate = DateTime.Now;
            expRow.debt = (contId != 0) ? (int)(debtsum - beginSum) : 0;
            expRow.status = (contId != 0) ? 1 : 0;
            expRow.comment = (contId != 0) ? commentDebt : "";
            expRow.expType = vozvrat ? 1 : 0;
            expRow.contragentId = contId;
            expRow.userID = UserValues.CurrentUserID;

            expRow.expSum = (int)Math.Round(sum);
            if (isTerminal && !vozvrat)
            {
                if (debtsum == 0)
                {
                    expRow.terminal = terminalSum != 0 ? terminalSum : expRow.expSum;
                }
                else
                {
                    expRow.terminal = terminalSum != 0 ? terminalSum : expRow.expSum;
                }
            }
            else expRow.terminal = 0;
            terminalSum = 0;
            expTable.Rows.Add(expRow);


            expDa.Update(expTable);
            expDa.FillLast(expTable);
            DataSetTpos.expenseRow exRow = expTable.Rows[0] as DataSetTpos.expenseRow;
            if (isPrinter)
            {
                EndHtml(exRow.expenseId, exRow.expSum, exRow.terminal, exRow.expType, exRow.debt, exRow.expSum, int.Parse(Configs.GetConfig("PercentAll")));
                //forPrinting(drPrintCol, expTable);

            }
            //swa.Stop();
            //Logs.Write("update expense", Logs.LogStatus.Info);
            if (contId != 0)
            {
                Classes.Model.MainHandlerADO mainHandler = new Classes.Model.MainHandlerADO();
                DataSetDebt.debtsDataTable debtsTable = mainHandler.RefreshDebts();
                mainHandler.AddDebts(exRow.expenseId, contId, debttypeId, (int)(debtsum - beginSum));
                
            }

            //Logs.SetLog("TIME:" + swa.Elapsed, Logs.LogStatus.Info);



            //Logs.Write("Triggeting executed", Logs.LogStatus.Info);

            DataView dv = dgvExpense.DataSource as DataView;
            //Logs.SetLog("Временный:"+tempExpeId, Logs.LogStatus.Info);
            //Logs.SetLog("Сумма:"+lblSum.Text, Logs.LogStatus.Info);

            lblSum.Text = "0";
            chbReb.Checked = false;


            //Logs.SetLog("--------------------", Logs.LogStatus.Info);
            //DataSetTpos.expenseDataTable expTable = (DataSetTpos.expenseDataTable)((object[])e.Argument)[1];
            int expId;
            DataSetTpos.ordersRow[] orRows = (DataSetTpos.ordersRow[])DBclass.DS.orders.Select("expenseId = " + tempExpeId);
            //DataSetTpos.ordersRow[] orderRows = new DataSetTpos.ordersRow[orRows.Length];
            //orRows.CopyTo(orderRows, 0);

            db.updateThread.haveCheck = false;
            foreach (DataSetTpos.ordersRow oneRow in orRows)
            {
                oneRow.expenseId = (expTable.Rows[0] as DataSetTpos.expenseRow).expenseId;
                //Logs.SetLog("exp:" + oneRow.expenseId + " orders:prodId:" + oneRow.prodId + ", orderSum:" + oneRow.orderSumm + ", cnt:" + oneRow.packCount, Logs.LogStatus.Info);
            }
            db.updateThread.AddToExpenseList((expTable.Rows[0] as DataSetTpos.expenseRow).expenseId, orRows, (vozvrat ? 1 : 0));
            db.updateThread.haveCheck = true;
            expId = Convert.ToInt32((expTable.Rows[0] as DataSetTpos.expenseRow).expenseId);
            ExpenseId = expId;
            //Logs.SetLog("updating orders,exp:" + expId, Logs.LogStatus.Info);


            //ordersTableAdapter prDa = new ordersTableAdapter();
            //prDa.Update(DBclass.DS.orders);
            //Logs.SetLog("end update orders,exp:" + expId, Logs.LogStatus.Warning);
            //getPriceTableAdapter getPriceda = new getPriceTableAdapter();

            //if (contId != 1)
            //{
            //    if (vozvrat)
            //    {
            //        //dbC.triggerExecute("BackTrigger", expId);
            //        Triggering("BackTrigger", expTable);
            //    }
            //    else
            //    {
            //        //dbC.triggerExecute("ExpenseTrigger", expId);
            //        Triggering("ExpenseTrigger", expTable);
            //    }
            //}


            foreach (DataSetTpos.ordersRow oneRow in orRows)
            {
                DBclass.DS.orders.RemoveordersRow(oneRow);
            }
            //this.Invoke(new delDgvRefresh(dgvRefresh));
            //Logs.Write("Printing", Logs.LogStatus.Info);

            //dgvExpense.Columns["productName"].Visible = false;
            //dgvExpense.Columns["productPrice"].Visible = false;
            string key = "";
            switch (tempExpeId)
            {
                case -2:
                    key = "btnS_2";
                    break;
                case -3:
                    key = "btnS_3";
                    break;
                case -4:
                    key = "btnS_4";
                    break;
                case -5:
                    key = "btnS_5";
                    break;
            }
            btnSPanel.Controls.RemoveByKey(key);
            btnS_Click(btnS_1, null);
            key_clear_Click(null, null);
            isTerminal = false;
            isNewExpense = true;

            commentDebt = "";
            contId = 0;
            if (vozvrat)
            {
                btnVozvrat_Click(btnVozvrat, new EventArgs());
            }
            menuUpdate_Click(menuUpdate, new EventArgs());
            dgvTovar.Focus();


                
           
        }

        public void Oplata()
        {
            try
            {
                if (dgvExpense.Rows.Count != 0 && MessageBox.Show("Произвести оплату?", "Оплата", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    Oplata(0, 0, 0, 0);
                }
            }
            catch (Exception ex)
            {
                Logs.SetLog("Error:" + ex.Message, Logs.LogStatus.Error);
            }
        }
        
        private void dgvExpense_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            
            var grid = (DataGridView)sender;
            if (grid.Columns["prodId"] != null && grid.Rows[e.RowIndex].Cells["prodId"].Value != null)
            {
                DataSetTpos.productRow prRow = DBclass.DS.product.Select("productId = " + grid.Rows[e.RowIndex].Cells["prodId"].Value)[0] as DataSetTpos.productRow;
                grid.Rows[e.RowIndex].Cells["productName"].Value = prRow.name;
                if (prRow.pack != 0)
                {
                    grid.Rows[e.RowIndex].Cells["productPrice"].Value = Math.Round((double)prRow.price, 2);
                }
                else
                {
                    grid.Rows[e.RowIndex].Cells["productPrice"].Value = prRow.price;
                }

            }
            grid.ClearSelection();
            grid.Rows[e.RowIndex].Cells["productPrice"].Selected = true;
            //grid.Rows.OfType<DataGridViewRow>().Last().Selected = true;
            //grid.Rows[e.RowIndex].
            //grid.CurrentCell = grid.Rows[e.RowIndex].Cells["productPrice"];
        }

        private void dgvExpense_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;
            if ((grid.Columns[e.ColumnIndex].Name == "packCount" && e.RowIndex >= 0) && grid.Rows[e.RowIndex].Cells["packCount"].Value != DBNull.Value)
            {
                double pck;
                
                if (Double.TryParse(grid.Rows[e.RowIndex].Cells["packCount"].Value.ToString(), out pck))
                {

                    grid.Rows[e.RowIndex].Cells["discount"].Value = (chbDiscount.Checked?CheckDiscount((int)grid.Rows[e.RowIndex].Cells["prodId"].Value):0);
                    grid.Rows[e.RowIndex].Cells["sumProduct"].Value = Math.Round((pck) * (Convert.ToDouble(grid.Rows[e.RowIndex].Cells["productPrice"].Value) - GetDiscountSum((int)grid.Rows[e.RowIndex].Cells["prodId"].Value, Convert.ToDouble(grid.Rows[e.RowIndex].Cells["productPrice"].Value)))).ToString();
                    sumTable();
                }
                else
                {
                    grid.Rows[e.RowIndex].Cells["packCount"].Value = packCount;
                }

                
            }
            if ((grid.Columns[e.ColumnIndex].Name == "productPrice" && e.RowIndex >= 0) && grid.Rows[e.RowIndex].Cells["productPrice"].Value != DBNull.Value)
            {
                double pck;

                if (Double.TryParse(grid.Rows[e.RowIndex].Cells["packCount"].Value.ToString(), out pck))
                {

                    grid.Rows[e.RowIndex].Cells["discount"].Value = (chbDiscount.Checked ? CheckDiscount((int)grid.Rows[e.RowIndex].Cells["prodId"].Value) : 0);
                    grid.Rows[e.RowIndex].Cells["sumProduct"].Value = Math.Round((pck) * (Convert.ToDouble(grid.Rows[e.RowIndex].Cells["productPrice"].Value) - GetDiscountSum((int)grid.Rows[e.RowIndex].Cells["prodId"].Value, Convert.ToDouble(grid.Rows[e.RowIndex].Cells["productPrice"].Value)))).ToString();
                    sumTable();
                }
                else
                {
                    grid.Rows[e.RowIndex].Cells["packCount"].Value = packCount;
                }


            }
            if ((grid.Columns[e.ColumnIndex].Name == "sumProduct" && e.RowIndex >= 0) && grid.Rows[e.RowIndex].Cells["sumProduct"].Value != DBNull.Value)
            {
                double sumpr;
                if (Double.TryParse(grid.Rows[e.RowIndex].Cells["sumProduct"].Value.ToString(), out sumpr))
                {
                    grid.Rows[e.RowIndex].Cells["orderSumm"].Value = Double.Parse(grid.Rows[e.RowIndex].Cells["sumProduct"].Value.ToString());
                    sumTable();
                }
            }

            }
        delegate void SetLabel(string str);
        private void SetTBX(string str)
        {
            
            if (this.chbReb.Checked)
                lblSum.Text = (int.Parse(str) * (100 - int.Parse(Configs.GetConfig("PercentAll"))) / 100).ToString("N0");
            else lblSum.Text = int.Parse(str).ToString("N0");
        }
        private void sumTable()
        {
            var sum = DBclass.DS.orders.Select("expenseId = " + tempExpeId).AsEnumerable().Sum(x => x.Field<int>("sumProduct"));
            this.Invoke(new SetLabel(SetTBX), new object[]{ sum.ToString() }); 
        }
        
        private void dgvExpense_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            var grid = (DataGridView)sender;
            if ((grid.Columns[e.ColumnIndex].Name == "packCount" && e.RowIndex >= 0) && grid.Rows[e.RowIndex].Cells["packCount"].Value!=DBNull.Value)
            {
                packCount = grid.Rows[e.RowIndex].Cells["packCount"].Value;
            }
        }
        private void dgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Text_KeyPress);
            if (dgvExpense.CurrentCell.ColumnIndex == dgvExpense.Columns["packCount"].Index) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Text_KeyPress);
                }
            }
        }
        private void Text_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)))//||(char.IsDigit(e.KeyChar)&&e.KeyChar==48))
            {
                e.Handled = true;
            }
            
        }

        private void exitMenu_Click(object sender, EventArgs e)
        {
            if (db.updateThread != null)
            {
                db.updateThread.StopThread();
            }
            //Logs.StopLog();
            Program.window_type = 0;
            this.Close();
        }

       
        
        

       

        private void btnDolg_Click(object sender, EventArgs e)
        {
            //FormDolgi dolgi = new FormDolgi();
            //dolgi.ShowDialog();
        }
        bool vozvrat = false;
        private void btnVozvrat_Click(object sender, EventArgs e)
        {
            if (dgvExpense.Rows.Count != 0)
            {
                btnOplata_Click(btnOplata, new EventArgs());

            }
            if (dgvExpense.Rows.Count == 0)
            {
                if (!vozvrat)
                {

                    this.btnVozvrat.BackgroundImage = (System.Drawing.Image)(Properties.Resources.back);
                    groupBox2.Text = "Возврат товара";
                    vozvrat = true;
                    btnVozvrat.BackColor = Color.Red;

                }
                else
                {

                    this.btnVozvrat.BackgroundImage = (System.Drawing.Image)(Properties.Resources.cart);
                    groupBox2.Text = "Расход товара";
                    vozvrat = false;
                    btnVozvrat.BackColor = Color.Blue;
                }
            }
            dgvTovar.Focus();
        }

        private void dgv_KeyPress(object sender, KeyPressEventArgs e)
        {
            char key = e.KeyChar;
            decimal dec;
            string st = "";
            if (sender is TextBox)
                st = (sender as TextBox).Text;
            if (tscanner != null&&(decimal.TryParse(st, out dec) || st == ""))
            {
                if (char.IsDigit(key))
                {

                    if (!beginBarcode)
                    {
                        tscanner.Start();
                        beginBarcode = true;
                    }
                    tscanner.Symbol(key);
                    //if (Decimal.TryParse(curBarcode))
                    //{

                    //}
                }
            }
            else 
            { 
                beginBarcode = false; if(tscanner!=null)tscanner.End(); 
            }
            if (tscanner != null&&(e.KeyChar == 13 && beginBarcode))
            {
                if (tbxSearchTovar.Text.Length <= 5 && tbxSearchTovar.Text.Length > 0)
                {
                    try
                    {
                        AddToOrders(Convert.ToInt32(tbxSearchTovar.Text.ToString()));
                        tbxSearchTovar.Text = "";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("нет товара по номеру " + tbxSearchTovar.Text.ToString());
                    }
                }
                else
                {
                    
                    tscanner.End();
                    curBarcode = tscanner.barcode;
                    if (tbxSearchTovar.Text != "" && tbxSearchTovar.Focused)
                        AddToOrders(tbxSearchTovar.Text);
                    else
                        AddToOrders(tscanner.barcode);

                    beginBarcode = false;
                    //tscanner.
                    curBarcode = "";
                    if (st != "")
                        (sender as TextBox).Text = "";
                }
            }
            else
            if (e.KeyChar == 43)
            {
                btnOplata_Click(btnOplata, new EventArgs());
            }
            else if (e.KeyChar == 13)
            {
                if (dgvTovar.Rows.Count != 0)
                {
                    AddToOrders((int)dgvTovar.Rows[dgvTovar.CurrentCell.RowIndex].Cells["productid"].Value);
                }    
            }
        }
        string curBarcode = "";
        bool beginBarcode = false;
        TextScanner tscanner;
        private void control_keyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void администраторToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UserValues.role == "admin")
            {
                Program.window_type = 3;
                if (scan != null)
                {
                    scan.isWorked = false;
                    scan.rd.ClosePort(scan.port);
                    
                }
                this.Close();

 
            }
        }

        string dataHtml = "";
        private void forPrintingNew(string sNum, string s0, string s1, string s2, string s3)
        {
            dataHtml += "<tr><td>" + sNum + "</td><td>" + s0 + "</td><td>" + s1 + "</td> <td>" + s2 + "</td> <td>" + s3 + "</td></tr>";

 
        }

        private void EndHtml(int expenseId, int expSum, int terminal, int expType, int debt, int summa, int charge)
        {
            StreamWriter sw = new StreamWriter(System.IO.Path.GetTempPath() + "\\tempData.htm");
            dataHtml = GenerateHTML(dataHtml, expenseId, expSum, terminal, expType, debt, summa, charge);
            sw.Write(dataHtml);
            sw.Close();
            //printing();
            string keyName = @"Software\Microsoft\Internet Explorer\PageSetup";
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyName, true))
            {
                if (key != null)
                {
                    string old_footer = (string)key.GetValue("footer");
                    string old_header = (string)key.GetValue("header");
                    key.SetValue("footer", "");
                    key.SetValue("header", "");

                    WebBrowser browser = new WebBrowser();
                    browser.DocumentCompleted += browser_DocumentCompleted;
                    browser.DocumentText = dataHtml;

                    //browser.Print();
                    if (old_footer != null)
                        key.SetValue("footer", old_footer);
                    if (old_header != null)
                        key.SetValue("header", old_header);
                }
            }
            dataHtml = "";
            //swa.Stop();
            //Logs.SetLog("PrintTime:" + swa.Elapsed.ToString(), Logs.LogStatus.Info);
            //PrintClass cl = new PrintClass();
            
        }
        private void forPrinting(List<string[]> data, DataSetTpos.expenseDataTable expTable)
        {
            Stopwatch swa = new Stopwatch();

            swa.Start();

            // ...

            

            
            int price = 0;
            
            int num = 1;
            StreamWriter sw = new StreamWriter(System.IO.Path.GetTempPath() + "\\tempData.htm");
            decimal summa = 0;
            foreach (string[] sr in data)
            {
                dataHtml += "<tr><td>" + sr[0] + "</td><td>" + sr[1] + "</td> <td>" + (Math.Round(Double.Parse(sr[1]) * Double.Parse(sr[2]))).ToString() + "</td></tr>";
                summa += decimal.Parse((Math.Round(Double.Parse(sr[1]) * Double.Parse(sr[2]))).ToString());
                num++;
            }   
            dataHtml = GenerateHTML(dataHtml, expTable, Convert.ToInt32(summa));
            //string zakaz = "<h4>Номер заказа: " + nomerZakaza + "</h4>";
            //string oficiant = "<h4>Официант: " + lblUser.Text + "</h4>";
            //dataHtml = zakaz+oficiant+"<h4>Официант: " + DateTime.Now.ToString("dd.MM.YYYY HH:mm")+ "</h4>" + dataHtml;
            sw.Write(dataHtml);
            sw.Close();
            //printing();
            string keyName = @"Software\Microsoft\Internet Explorer\PageSetup";
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyName, true))
            {
                if (key != null)
                {
                    string old_footer = (string)key.GetValue("footer");
                    string old_header = (string)key.GetValue("header");
                    key.SetValue("footer", "");
                    key.SetValue("header", "");

                    WebBrowser browser = new WebBrowser();
                    browser.DocumentCompleted += browser_DocumentCompleted;
                    browser.DocumentText = dataHtml;
                    
                    //browser.Print();
                    if (old_footer != null)
                        key.SetValue("footer", old_footer);
                    if (old_header != null)
                        key.SetValue("header", old_header);
                }
            }
            swa.Stop();
            //Logs.SetLog("PrintTime:"+swa.Elapsed.ToString(), Logs.LogStatus.Info);
            //PrintClass cl = new PrintClass();
            //cl.Printing();
        }
        
        void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser browser = sender as WebBrowser;
            browser.Print();
        }
        private string GenerateHTML(string dataHtml, int expenseId, int expSum, int terminal, int expType, int debt, int summa, int charge)
        {
            string temp = "";
            if (debt == 0)
            {
                temp = "<tr>" +
                                "<td colspan='1''>Наличные</td>" +
                                "<td colspan='2''>" + (Convert.ToInt32(expSum) - Convert.ToInt32(terminal)) + " сум</td>" +
                            "</tr>" +
                            "<tr>" +
                                "<td colspan='1''>Терминал</td>" +
                                "<td colspan='2''>" + Convert.ToInt32(terminal) + " сум</td>" +
                            "</tr>" +
                            "<tr><td colspan='4'>&nbsp;</td></tr>";


                string percent = Math.Abs(charge).ToString();// Configs.GetConfig("PercentAll");
                int originalSum = (expSum / (100 - Math.Abs(charge)))*100;
                if (chbReb.Checked)
                {
                    temp += "<tr>" +
                                "<td colspan='1''>Скидка</td>" +
                                "<td colspan='2''>" + originalSum + " => "+expSum+"</td>" +
                            "</tr>"+
                    "<tr>" +
                                "<td colspan='1''>Процент</td>" +
                                "<td colspan='2''>" + percent + " %</td>" +
                            "</tr>";
                            
                }
            }
            else
            {
                temp = "";
            }
            string html = "<head></head><body>" +
                    "<table style='font-size: 9px; font-family: Tahoma; width: 100%;'>" +
                        "<thead>" +
                            "<tr><td colspan='3' style=\"text-align:center\"> " + Properties.Settings.Default.orgName + "</td></tr>" +
                            "<tr><td colspan='3' style=\"text-align:center\">Дата: " + DateTime.Now.ToString("dd.MM.yyyy HH:mm") + "</td></tr>" +
                            "<tr><td colspan='3' style=\"text-align:right\">Касса: " + UserValues.CurrentUser + "</td></tr>" +
                            "<tr><td colspan='3' style=\"text-align:right\">Счет №: " + expenseId + "</td></tr>" +
                            "<tr><td colspan='3'></td></tr>" +
                            "<tr><td colspan='3' style='text-align:center; font-size:14px'>" + (expType == 1 ? "Возврат" : "Покупка") + "</td></tr>" +
                            "<tr>" +
                                "<th style='border-bottom: 1px solid #000;width:10px;' >№</th>" +
                                "<th style='border-bottom: 1px solid #000;'>Наименование</th>" +
                                "<th style='border-bottom: 1px solid #000;'>Кол.</th>" +
                                "<th style='border-bottom: 1px solid #000;'>Цена</th>" +
                                "<th style='border-bottom: 1px solid #000;'>Сумма</th>" +
                            "</tr>" +
                        "<thead>" +
                        "<tbody>" + dataHtml +
                        "<tbody>" +
                        "<tfoot>" +
                            "<tr><td style='border-top:1px solid #000' colspan='5'> &nbsp;</td></tr>" +
                            temp +
                            "<tr>" +
                                "<th colspan='1'>Итого " + (debt == 1 ? "долг" : "") + " :</th>" +
                                "<th colspan='2'>" + summa + " сум</td>" +
                            "</tr>" +
                        "</tfoot>" +
                    "</table>" +
                "</body>";
            return html;
        }

        private string GenerateHTML(string dataHtml, DataSetTpos.expenseDataTable expTable, int summa)
        {
            string temp = "";
            if ((expTable.Rows[0] as DataSetTpos.expenseRow).debt == 0)
            {
                temp = "<tr>" +
                                "<td colspan='1''>Наличные</td>" +
                                "<td colspan='2''>" + (Convert.ToInt32((expTable.Rows[0] as DataSetTpos.expenseRow).expSum) - Convert.ToInt32((expTable.Rows[0] as DataSetTpos.expenseRow).terminal)) + " сум</td>" +
                            "</tr>" +
                            "<tr>" +
                                "<td colspan='1''>Терминал</td>" +
                                "<td colspan='2''>" + Convert.ToInt32((expTable.Rows[0] as DataSetTpos.expenseRow).terminal) + " сум</td>" +
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
                            "<tr><td colspan='3' style=\"text-align:center\">Дата: " + DateTime.Now.ToString("dd.MM.yyyy HH:mm") + "</td></tr>" +
                            "<tr><td colspan='3' style=\"text-align:right\">Касса: " + UserValues.CurrentUser + "</td></tr>" +
                            "<tr><td colspan='3' style=\"text-align:right\">Счет №: " + (expTable.Rows[0] as DataSetTpos.expenseRow).expenseId + "</td></tr>" +
                            "<tr><td colspan='3'></td></tr>" +
                            "<tr><td colspan='3' style='text-align:center; font-size:14px'>" + ((expTable.Rows[0] as DataSetTpos.expenseRow).expType == 1 ? "Возврат" : "Покупка") + "</td></tr>" +
                            "<tr>" +

                                "<th style='border-bottom: 1px solid #000;'>Наименование</th>" +
                                "<th style='border-bottom: 1px solid #000;'>Кол.</th>" +
                                "<th style='border-bottom: 1px solid #000;'>Сумма</th>" +
                            "</tr>" +
                        "<thead>" +
                        "<tbody>" + dataHtml +
                        "<tbody>" +
                        "<tfoot>" +
                            "<tr><td style='border-top:1px solid #000' colspan='4'> &nbsp;</td></tr>" +
                            temp+
                            "<tr>" +
                                "<th colspan='1'>Итого " + ((expTable.Rows[0] as DataSetTpos.expenseRow).debt == 1 ? "долг" : "") + " :</th>"+
                                "<th colspan='2'>" + summa + " сум</td>" +
                            "</tr>" +
                        "</tfoot>"+
                    "</table>" +
                "</body>";
            return html;
        }

        private void menuCloseDay_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Будет выполнена опреация по завершению дня, не закрывайте пожалуйста окно программы пока не выйдет сообщение!");
            db.CloseDay();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            soat.Text = DateTime.Now.ToString("HH:mm");

        }

        private void btnDebt_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (DBclass.DS.orders.Select("expenseId = " + tempExpeId).Length > 0)
            {
                Contragent commentf = new Contragent();
                if (commentf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    contId = commentf.activeContragentRow != null ? commentf.activeContragentRow.contragentId : 0;
                    commentDebt = "";
                    btnOplata_Click(btnOplata, new EventArgs());
                }
                
                
            }
            dgvTovar.Focus();
            //else if ()
            //    chb.Checked = false;
            
        }

        private void btnTerminal_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start("osk.exe");
            System.Globalization.CultureInfo cultur = System.Globalization.CultureInfo.CurrentCulture;
            System.Globalization.NumberFormatInfo nInfo = (System.Globalization.NumberFormatInfo)cultur.NumberFormat.Clone();
            nInfo.NumberGroupSeparator = "";
            SubForms.TerminalForm terminalF = new SubForms.TerminalForm(Convert.ToInt32(Convert.ToDouble(lblSum.Text)).ToString());
            terminalF.tbxSumma.Text = lblSum.Text;
            terminalF.keypad.tbxMain.Text =  Convert.ToInt32(Convert.ToDouble(lblSum.Text)).ToString();
            if (DBclass.DS.orders.Select("expenseId = " + tempExpeId).Length > 0 && terminalF.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                terminalSum = terminalF.sum != "" ? Convert.ToInt32(terminalF.sum) : 0;
                isTerminal = true;
                //btnOplata_Click(btnOplata, new EventArgs());

                
                Oplata();
                dgvTovar.Focus();
            }
            else dgvTovar.Focus();
            
        }

        private void btnDebt_click(object sender, EventArgs e)
        {
            if (lblSum.Text != "")
            {
                tposDesktop.Debts.DebtSaleForm saleForm = new Debts.DebtSaleForm(Convert.ToDouble(lblSum.Text));
                if (saleForm.ShowDialog() == DialogResult.OK)
                {
                    int percent = saleForm.percent;
                    double percentSum = saleForm.percentSum;
                    double beginSum = saleForm.beginSum;
                    double terminalsum = saleForm.terminalSum;
                    if (terminalsum > 0)
                    {
                        terminalSum = (int)terminalsum;
                        isTerminal = true;
                    }
                    contId = saleForm.currentClient.clientId;
                    Oplata(percent, percentSum, saleForm.typeId, beginSum);
                    dgvTovar.Focus();
                }
            }

        }
        #region Search TBX
        private void tbxEnter(object sender, EventArgs e)
        {
            
            TextBox tbx = sender as TextBox;
            if (tbx.Text == "По имени"|| tbx.Text == "По цене")
            {
                tbx.Text = "";
                tbx.ForeColor = Color.Black;
            }
        }


        private void tbxLeave(object sender, EventArgs e)
        {
            
            TextBox tbx = sender as TextBox;
            if (tbx.Text == "")
            {
                if (tbx.Name == "tbxSearchTovar")
                {
                    tbx.Text = "По имени";

                }
                else if (tbx.Name == "tbxSearchPrice")
                {
                    tbx.Text = "По цене";

                }
                tbx.ForeColor = Color.Silver;
            }
        }
        #endregion


        private void mathAction_Click(object sender, EventArgs e)
        {
            Button actBtn = sender as Button;
            action = actBtn.Text;
            lblActionResult.Text = " " + actBtn.Text + " ";
            dgvTovar.Focus();
        }

        private void btnKeypress_Click(object sender, EventArgs e)
        {
            Button numBtn = sender as Button;
            bool chkDot = key_num.Contains('.');
            if (chkDot)
            {
                string temp = key_num;
                temp += numBtn.Text;
                string[] cntDot = temp.Split('.');
                if (cntDot.Length > 2)
                {
                    MessageBox.Show("Невозможно добавить еще точек");
                }
                else
                {
                    key_num = temp;
                    lblNumResult.Text = " " +key_num + " ";
                }
            }
            else
            {
                key_num += numBtn.Text;
                lblNumResult.Text = " " + key_num + " ";
            }
            dgvTovar.Focus();
        }

        private void kewboard_call(object sender, EventArgs e)
        {
        }

        private void key_equal_Click(object sender, EventArgs e)
        {

            int rowindex = 0;
            if (dgvExpense.Rows.Count > 0)
            {
                if (actionMath == false)
                {
                    rowindex = 0;// dgvExpense.Rows.Count - 1;
                }
                else
                {
                    if(dgvExpense.SelectedRows.Count>0)
                    rowindex = dgvExpense.SelectedRows[0].Index;
                    else
                        rowindex = dgvExpense.CurrentCell.RowIndex;

                }
                float cnt = Convert.ToSingle(dgvExpense.Rows[rowindex].Cells["packCount"].Value);
                float tempor = Convert.ToSingle(dgvExpense.Rows[rowindex].Cells["packCount"].Value);
                System.Globalization.NumberFormatInfo numberInfo = new System.Globalization.NumberFormatInfo();
                key_num = key_num.Replace(",", numberInfo.CurrencyDecimalSeparator).Replace(".", numberInfo.CurrencyDecimalSeparator);
                if (action != "" && key_num != "")
                {
                    switch (action)
                    {
                        case "+":
                            cnt = cnt + Convert.ToSingle(key_num, numberInfo);
                            break;
                        case "-":
                            cnt = cnt - Convert.ToSingle(key_num, numberInfo);
                            break;
                        case "*":
                            cnt = cnt * (Convert.ToSingle(key_num, numberInfo) == 0 ? 1 : Convert.ToSingle(key_num, numberInfo));
                            break;
                        case "/":
                            cnt = cnt / (Convert.ToSingle(key_num, numberInfo) == 0 ? 1 : Convert.ToSingle(key_num, numberInfo));
                            break;
                    }
                    DataRow[] dr = DBclass.DS.product.Select("productId = " + Convert.ToInt32(dgvExpense.Rows[rowindex].Cells["prodId"].Value));
                    if (dr.Length != 0)
                    {
                        ((DataSetTpos.productRow)dr[0]).pack = Convert.ToSingle(cnt-tempor, numberInfo);
                        //((DataSetTpos.productRow)dr[0]).pack = ((DataSetTpos.productRow)dr[0]).pack < 0 ? 1 : ((DataSetTpos.productRow)dr[0]).pack; 
                    }
                    //cnt
                    //int i = Int32.Parse(dgvExpense.Rows[e.RowIndex].Cells["packCount"].Value.ToString());
                    //i++;
                    //dgvExpense.Rows[e.RowIndex].Cells["packCount"].Value = i;
                    AddProduct(dr, false, "");
                    cnt = 0;
                    dr[0].RejectChanges();
                }
                //dgvExpense.Rows[rowindex].Cells[8].Value = Math.Round(cnt * prices).ToString();

                //dgvExpense.Rows[rowindex].Cells[5].Value = Math.Round(cnt * prices).ToString();
                //float temp = cnt;
                //dgvExpense.Rows[rowindex].Cells[6].Value = temp;
            }
            
            action = "";
            key_num = "";
            lblNumResult.Text = "";
            lblActionResult.Text = "";
            actionMath = false;
            dgvTovar.Focus();
        }

        private void key_clear_Click(object sender, EventArgs e)
        {
            action = "";
            key_num = "";
            lblNumResult.Text = "";
            lblActionResult.Text = "";
            actionMath = false;
            dgvTovar.Focus();
        }


        private void btnById_Click(object sender, EventArgs e)
        {
            KeyPadForm formKey = new KeyPadForm();
            if (formKey.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (formKey.text.Length <= 5)
                {
                    AddToOrders(int.Parse(formKey.text));
                }
                else
                {
                    AddToOrders(formKey.text);
                }
            }

        }

        private void btnKassa_Click(object sender, EventArgs e)
        {
            Kassa ks = new Kassa(ExpenseId);
            if (ks.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.Close();
            }
            dgvTovar.Focus();
        }

        private void btnSAdd_Click(object sender, EventArgs e)
        {
            String tempBtnS = "";
            String tempBtnSName = "";
            if (btnSPanel.Controls.Count < 5)
            {
                Button tempButton = new Button();

                if (btnSPanel.Controls.Find("btnS_5", true).Length == 0)
                {
                    tempBtnSName = "btnS_5";
                    tempExpeId = -5;
                    tempBtnS = "Счет5";
                }
                if (btnSPanel.Controls.Find("btnS_4", true).Length == 0)
                {
                    tempBtnSName = "btnS_4";
                    tempExpeId = -4;
                    tempBtnS = "Счет4";
                }
                if (btnSPanel.Controls.Find("btnS_3", true).Length == 0)
                {
                    tempBtnSName = "btnS_3";
                    tempExpeId = -3;
                    tempBtnS = "Счет3";
                }
                if (btnSPanel.Controls.Find("btnS_2", true).Length == 0)
                {
                    tempBtnSName = "btnS_2";
                    tempExpeId = -2;
                    tempBtnS = "Счет2";
                }
                foreach (Control ctrl in btnSPanel.Controls)
                {
                    ctrl.BackColor = Color.Yellow;
                }
                tempButton.Text = tempBtnS;
                tempButton.Name = tempBtnSName;
                tempButton.BackColor = Color.FromArgb(255, 128, 128);
                tempButton.Width = 65;
                tempButton.Height = 34;
                tempButton.Font = new System.Drawing.Font(this.Font.FontFamily, 11f);
                // attach event handler for Click event 
                // (assuming ButtonClickHandler is an existing method in the class)
                tempButton.Click += btnS_Click;
                btnSPanel.Controls.Add(tempButton);
                btnS_Click(tempButton, null);
            }
        }

        private void btnS_Click(object sender, EventArgs e)
        {
            //Logs.SetLog("Переход c вр-го счёта:" + tempExpeId, Logs.LogStatus.Info);
            activeBtn = sender as Button;
            if (activeBtn.Name == "btnS_1")
            {
                tempExpeId = -1;
                closeBtnS.Visible = false;
            }
            if (activeBtn.Name == "btnS_2")
            {
                tempExpeId = -2;
                closeBtnS.Visible = true;
            }
            if (activeBtn.Name == "btnS_3")
            {
                tempExpeId = -3;
                closeBtnS.Visible = true;
            }
            if (activeBtn.Name == "btnS_4")
            {
                tempExpeId = -4;
                closeBtnS.Visible = true;
            }
            if (activeBtn.Name == "btnS_5")
            {
                tempExpeId = -5;
                closeBtnS.Visible = true;
            }
            //Logs.SetLog("на вр-ного счёта:" + tempExpeId, Logs.LogStatus.Info);
            DataView dvOr = new DataView(DBclass.DS.orders);
            dvOr.RowFilter = "expenseId = " + tempExpeId;
            dvOr.Sort = "orderId desc";
            DBclass.DS.orders.Select("expenseId = " + tempExpeId);
            dgvExpense.DataSource = dvOr;


            foreach (DataGridViewRow rowDgv in dgvExpense.Rows)
            {
                dgvExpense_RowsAdded(dgvExpense, new DataGridViewRowsAddedEventArgs(rowDgv.Index, 1));
                //rowDgv.Cells[""]
            }
            sumTable();
            foreach (Control ctrl in btnSPanel.Controls)
            {
                ctrl.BackColor = Color.Yellow;
            }

            activeBtn.BackColor = Color.FromArgb(255, 128, 128);
            dgvTovar.Focus();
            //Logs.SetLog(lblSum.Text, Logs.LogStatus.Info);
        }

        private void closeBtnS_Click(object sender, EventArgs e)
        {
            if (tempExpeId != -1)
            {
                string key = "";
                switch (tempExpeId)
                {
                    case -2:
                        key = "btnS_2";
                        break;
                    case -3:
                        key = "btnS_3";
                        break;
                    case -4:
                        key = "btnS_4";
                        break;
                    case -5:
                        key = "btnS_5";
                        break;
                }

                DataSetTpos.ordersRow[] orRows = (DataSetTpos.ordersRow[])DBclass.DS.orders.Select("expenseId = " + tempExpeId);
                foreach (DataSetTpos.ordersRow oneRow in orRows)
                {
                    DBclass.DS.orders.RemoveordersRow(oneRow);
                }
                btnSPanel.Controls.RemoveByKey(key);
                btnS_Click(btnS_1, null);
            }
        }

        private void menuUpdate_Click(object sender, EventArgs e)
        {
            productTableAdapter prDa = new productTableAdapter();
            prDa.Fill(DBclass.DS.product);
            productviewTableAdapter prVda = new productviewTableAdapter();
            prVda.Fill(DBclass.DS.productview);
            dgvTovar.Refresh();
            loadBtn();
            dgvTovar.Focus();
        }

        private void menuLastCheck_Click(object sender, EventArgs e)
        {
            DataSetTpos.expenseDataTable expTable = new DataSetTpos.expenseDataTable();
            DataSetTposTableAdapters.expenseTableAdapter exDa = new expenseTableAdapter();
            exDa.FillLast(expTable);

            DataSetTpos.ordersviewDataTable ordTable = new DataSetTpos.ordersviewDataTable();
            ordersviewTableAdapter ordersvDA = new ordersviewTableAdapter();
            ordersvDA.FillByExpense(ordTable, (expTable.Rows[expTable.Rows.Count-1] as DataSetTpos.expenseRow).expenseId);
            drPrintCol = new List<string[]>();
            foreach (DataSetTpos.ordersviewRow ordRow in ordTable.Select("expenseId = " + (expTable.Rows[expTable.Rows.Count - 1] as DataSetTpos.expenseRow).expenseId))
            {
                double price = Math.Round((double)ordRow.orderSumm/(Convert.ToDouble(ordRow.cnt!=0?ordRow.cnt:1)), 3); 
                drPrintCol.Add(new string[] { ordRow.name, ordRow.cnt.ToString(), price.ToString()});
                //sum += Math.Round(Double.Parse(dgvRow.Cells["packCount"].Value.ToString()) * Double.Parse(dgvRow.Cells["productPrice"].Value.ToString()));
            }
            if (Properties.Settings.Default.isPrinter == true)
            {
                forPrinting(drPrintCol, expTable);

            }

        }

        private void chbReb_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chb = sender as CheckBox;
            switch (chb.Name)
            {
                case "chbReb":
                    if (chb.Checked)
                        chbDiscount.Checked = false;
                    break;
                case "chbDiscount":
                    if (chb.Checked)
                    {
                        chbReb.Checked = false;
                        GetDiscountConfig();
                        if (discountId == -1) chb.Checked = false;
                        dgvExpense.Columns["discount"].Visible = true;
                    }
                    else
                    {
                        dgvExpense.Columns["discount"].Visible = false;
                        discountId = -1;
                    }
                    break;
            }
        }

        private void chbDiscount_CheckedChanged(object sender, EventArgs e)
        {
            GetDiscountConfig();
            if (chbDiscount.Checked)
            { chbReb.Checked = false; }
        }

        private void chbReb_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chbReb.Checked)
            { chbDiscount.Checked = false; }
        }

        private void btnReceipt_Click(object sender, EventArgs e)
        {

            isPrinter = !isPrinter;
            Properties.Settings.Default.isPrinter = isPrinter;
            SetIsPrinter();
        }

        bool isPrinter = false;
        private void SetIsPrinter()
        {
            if (isPrinter)
            {
                btnReceipt.BackgroundImage = global::tposDesktop.Properties.Resources.checked1;
            }
            else
            {
                btnReceipt.BackgroundImage = global::tposDesktop.Properties.Resources.checked2;
            }
        }

        private void tbxSearchTovar_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvTovar.SelectedRows.Count!=0)
            {
                DataGridViewRow dvRow = dgvTovar.SelectedRows[0];
                if (e.KeyCode == Keys.Down)
                {
                    if (dvRow.Index < (dgvTovar.Rows.Count-1))
                    {
                        dgvTovar.CurrentCell = dgvTovar.Rows[dvRow.Index + 1].Cells[0];
                        dgvTovar.Rows[dvRow.Index + 1].Selected = true;
                    }
                }
                else if (e.KeyCode == Keys.Up)
                {
                    if (dvRow.Index > 0)
                    {
                        dgvTovar.CurrentCell = dgvTovar.Rows[dvRow.Index - 1].Cells[0];
                        dgvTovar.Rows[dvRow.Index - 1].Selected = true;
                    }
                }
            }
        }
    }
}
