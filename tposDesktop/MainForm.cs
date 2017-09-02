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
    public partial class MainForm : Form
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
        private string key_num = "";
        public MainForm()
        {
            InitializeComponent();
            DBclass.DS.orders.Clear();
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            loadBtn();
            this.Icon = tposDesktop.Properties.Resources.mainIcon;
            db = new DBclass();
            db.FillExpense("");
            db.FillProduct();
            productviewTableAdapter prVda = new productviewTableAdapter();
            prVda.Fill(DBclass.DS.productview);

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
            dgvTovar.DataSource = dv;
            dgvExpense.DataSource = dvOr;
            
            dv.RowFilter = " not price = 0";
            dv.Sort = "name asc";
            dgvExpense.EditingControlShowing += dgv_EditingControlShowing;
            dgvTovar.Focus();
            if(UserValues.role == "admin")
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

        }

        private void loadBtn()
        {
            this.hotkeysTableAdapter1.Fill(DBclass.DS.hotkeys);
            DataView htk = new DataView(DBclass.DS.hotkeys);
            foreach (DataRowView temp in htk)
            {
                Button btn = this.Controls.Find("hot_" + temp["btnId"], true).FirstOrDefault() as Button;
                btn.Text = temp["prodId"].ToString();
            }
        }

        private void hotKeyBtn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string prName = btn.Text;
            int n;
            bool isNumeric = int.TryParse(prName, out n);
            DataSetTpos.productRow[] prRows = (DataSetTpos.productRow[])DBclass.DS.product.Select("name like '%" + prName + "%'");
            if (prRows.Length > 0 && isNumeric == false)
            {
                AddProduct(prRows, false, null);
            }
            dgvTovar.Focus();

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
            if(Program.window_type!=1&& Program.window_type!=3)
            Program.window_type = 0;

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            btnDolg.BackgroundImage = Properties.Resources.qarz;
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
            dgvTovar.Columns["price"].Width= 50;
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
            dgvExpense.Columns["packCount"].ValueType = typeof(int);
            dgvExpense.Columns["productName"].Width = 250;
            dgvExpense.Columns["packCount"].Width = 65;
            dgvExpense.Columns["productName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvExpense.Columns["sumProduct"].HeaderText = "Сумма";
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



        }

        private void tbxSearchTovar_TextChanged(object sender, EventArgs e)
        {
            TextBox tbx = sender as TextBox;
           
            try
            {
                DataView dv = dgvTovar.DataSource as DataView;  
                
                if(tbx.Name=="tbxSearchTovar"&& tbx.Text !="По имени")
                {
                    dv.RowFilter = "name like '%" + tbx.Text + "%' and not price = 0";
                }
                else if (tbx.Name == "tbxSearchPrice" && tbx.Text != "По цене")
                {
                    dv.RowFilter = "price+'' like '" + (tbx.Text == "" ? "0" : tbx.Text) + "%' and not price = 0";
 
                }
                
                dv.Sort = "name asc";
            }catch(Exception ex)
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
                if (dgvExpense.Columns[e.ColumnIndex].Name == "colBtnPlus")
                {
                    int i = Int32.Parse(dgvExpense.Rows[e.RowIndex].Cells["packCount"].Value.ToString());
                    i++;
                    dgvExpense.Rows[e.RowIndex].Cells["packCount"].Value = i;
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
                        i--;
                        dgvExpense.Rows[e.RowIndex].Cells["packCount"].Value = i;
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
                    if (barcode.Length == 12)
                    {
                        dr = getProductWithMassa(barcode);
                    }
                }

                if (dr.Length != 0)
                {
                    DataSetTpos.productRow drP = (DataSetTpos.productRow)dr[0];
                    DataRow[] existRows = DBclass.DS.orders.Select("expenseId=-1 and prodId = " + drP.productId);
                    if (existRows.Length > 0)
                    {
                        DataSetTpos.ordersRow ordrow = (DataSetTpos.ordersRow)existRows[0];
                        ordrow.packCount = ordrow.packCount + (drP.pack == 0 ? 1 : drP.pack);
                        DataRow drOrder = ordrow;
                        drOrder["sumProduct"] = ordrow.packCount * drP.price ;//ordrow.AcceptChanges();
                        ordrow.orderSumm = Convert.ToSingle(drOrder["sumProduct"]);
                    }
                    else
                    {
                        DataSetTpos.ordersRow ordrow = DBclass.DS.orders.NewordersRow();



                        ordrow.prodId = drP.productId;
                        if (drP.pack == 0) drP.pack = 1;
                        ordrow.expenseId = -1;
                        int curPrice = drP.price;
                        OrderForm oform = new OrderForm(drP);
                        //oform.ShowDialog();
                        if (oform.DialogResult == System.Windows.Forms.DialogResult.OK)
                        {
                            ordrow.packCount = (float)oform.count;
                            ordrow.orderSumm = oform.sum;
                            DataRow drOrder = ordrow;
                            drOrder["sumProduct"] = oform.sum;//ordrow.packCount * drP.price / (drP.pack == 0 ? 1 : drP.pack);

                            //grid.Rows[e.RowIndex].Cells["sumProduct"].Value = (Convert.ToInt32(grid.Rows[e.RowIndex].Cells["packCount"].Value) * Convert.ToInt32(grid.Rows[e.RowIndex].Cells["productPrice"].Value)).ToString();
                        }
                        else 
                        { 
                            if(drP.price==0)
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
        }

        

        private DataRow[] getProductWithMassa(string barcode)
        {
            int prefix = Int32.Parse(barcode.Substring(0,2));
            if (prefix == 20)
            {
                barcode = barcode.Substring(2);
                string id = barcode.Substring(0, 5);
                string kg = barcode.Remove(0, 5).Substring(0, 5);
                kg = kg.Insert(2, ".");
                //float kgf = Convert.ToSingle(kg);
                DataRow[] dr = DBclass.DS.product.Select("productId = " + Convert.ToInt32(id));
                if (dr.Length != 0)
                {
                    ((DataSetTpos.productRow)dr[0]).pack = Convert.ToSingle(kg);
                }
                return dr;
            }
            else 
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
        private void btnOplata_Click(object sender, EventArgs e)
        {
            if(dgvExpense.Rows.Count!=0 && MessageBox.Show("Произвести оплату?", "Оплата", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {

                drPrintCol = new List<string[]>();


                expenseTableAdapter expDa = new expenseTableAdapter();
                expDa.Adapter.SelectCommand = new MySql.Data.MySqlClient.MySqlCommand("select * from expense order by expenseId desc limit 1", expDa.Connection);
                DataSetTpos.expenseDataTable expTable = new DataSetTpos.expenseDataTable();
                DataSetTpos.expenseRow expRow = expTable.NewexpenseRow();
                double sum = 0;
                foreach (DataGridViewRow dgvRow in dgvExpense.Rows)
                {
                    drPrintCol.Add(new string[] { dgvRow.Cells["ProductName"].Value.ToString(), dgvRow.Cells["packCount"].Value.ToString(), (dgvRow.Cells["productPrice"].Value).ToString() });
                    sum += Math.Round(Double.Parse(dgvRow.Cells["packCount"].Value.ToString()) * Double.Parse(dgvRow.Cells["productPrice"].Value.ToString()));
                }
                expRow.expenseDate = DateTime.Now;
                expRow.debt = (contId != 0) ? 1 : 0;
                expRow.status = (contId != 0) ? 1 : 0;
                expRow.comment = (contId != 0) ? commentDebt : "";
                expRow.expType = vozvrat ? 1 : 0;
                expRow.contragentId = contId;
                
                expRow.expSum = (int)Math.Round(sum);
                if (isTerminal)
                {
                    expRow.terminal = terminalSum != 0 ? terminalSum : expRow.expSum;
                }
                else expRow.terminal = 0;
                expTable.Rows.Add(expRow);
                int expId;
                expDa.Update(expTable);
                expDa.FillLast(expTable);
                if (contId != 0)
                {
                    contragentTableAdapter ctba = new contragentTableAdapter();
                    DataSetTpos.contragentRow[] ctrRow = (DataSetTpos.contragentRow[])DBclass.DS.contragent.Select("contragentId = " + contId);
                    ctrRow[0].sums = ctrRow[0].sums + (int)Math.Round(sum);
                    ctba.Update(ctrRow[0]);
                }
                ordersTableAdapter prDa = new ordersTableAdapter();
                DataSetTpos.ordersRow[] orRows = (DataSetTpos.ordersRow[])DBclass.DS.orders.Select("expenseId = -1");
                foreach (DataSetTpos.ordersRow oneRow in orRows)
                {
                    oneRow.expenseId = (expTable.Rows[0] as DataSetTpos.expenseRow).expenseId;
                }
                expId = Convert.ToInt32((expTable.Rows[0] as DataSetTpos.expenseRow).expenseId);
                prDa.Update(DBclass.DS.orders);
                getPriceTableAdapter getPriceda = new getPriceTableAdapter();
                DBclass dbC = new DBclass();
                if(vozvrat)
                {
                    dbC.triggerExecute("BackTrigger",expId);
                }else
                {
                    dbC.triggerExecute("ExpenseTrigger",expId);
                }



                productviewTableAdapter prVda = new productviewTableAdapter();
                prVda.Fill(DBclass.DS.productview);

                DataView dv = dgvExpense.DataSource as DataView;
                DBclass.DS.orders.Clear();
                lblSum.Text = "0";
                if (Properties.Settings.Default.isPrinter == true)
                {
                    forPrinting(drPrintCol, expTable);
                }
                //dgvExpense.Columns["productName"].Visible = false;
                //dgvExpense.Columns["productPrice"].Visible = false;
                isTerminal = false;
                isNewExpense = true;
                
                commentDebt = "";
                contId = 0;
                
            }
            
        }

        private void dgvExpense_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            
            var grid = (DataGridView)sender;
            if (grid.Columns["prodId"] != null && grid.Rows[e.RowIndex].Cells["prodId"].Value != null)
            {
                DataSetTpos.productRow prRow = DBclass.DS.product.Select("productId = " + grid.Rows[e.RowIndex].Cells["prodId"].Value)[0] as DataSetTpos.productRow ;
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
             if ((grid.Columns[e.ColumnIndex].Name == "packCount" && e.RowIndex >= 0) && grid.Rows[e.RowIndex].Cells["packCount"].Value!=DBNull.Value)
             {
                 int pck;
                 if (Int32.TryParse(grid.Rows[e.RowIndex].Cells["packCount"].Value.ToString(), out pck))
                 {

                     grid.Rows[e.RowIndex].Cells["sumProduct"].Value =Math.Round((Convert.ToInt32(grid.Rows[e.RowIndex].Cells["packCount"].Value) * Convert.ToDouble(grid.Rows[e.RowIndex].Cells["productPrice"].Value))).ToString();
                     sumTable();
                 }
                 else
                 {
                     grid.Rows[e.RowIndex].Cells["packCount"].Value = packCount;
                 }
             }
            
             
        }
        delegate void SetLabel(string str);
        private void SetTBX(string str)
        {
            lblSum.Text = str;
        }
        private void sumTable()
        {
            var sum = DBclass.DS.orders.AsEnumerable().Sum(x => x.Field<int>("sumProduct"));
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
            Program.window_type = 0;
            this.Close();
            
        }

       
        
        

       

        private void btnDolg_Click(object sender, EventArgs e)
        {
            FormDolgi dolgi = new FormDolgi();
            dolgi.ShowDialog();
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

                tscanner.End();
                if(tbxSearchTovar.Text!=""&&tbxSearchTovar.Focused)
                AddToOrders(tbxSearchTovar.Text);
                else
                    AddToOrders(tscanner.barcode);
                
                beginBarcode = false;
                //tscanner.
                curBarcode = "";
                if (st != "")
                    (sender as TextBox).Text = "";
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


        private void forPrinting(List<string[]> data, DataSetTpos.expenseDataTable expTable)
        {
            int price = 0;
            string dataHtml = "";
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

        void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser browser = sender as WebBrowser;
            browser.Print();
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
            if (DBclass.DS.orders.Select("expenseId = -1").Length > 0)
            {
                Contragent commentf = new Contragent();
                if (commentf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    contId = commentf.activeContragentRow != null ? commentf.activeContragentRow.contragentId : 0;
                    commentDebt = "";
                    btnOplata_Click(btnOplata, new EventArgs());
                }
                
                dgvTovar.Focus();
            }
            //else if ()
            //    chb.Checked = false;
            
        }

        private void btnTerminal_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("osk.exe");
            SubForms.TerminalForm terminalF = new SubForms.TerminalForm();
            terminalF.tbxSumma.Text = lblSum.Text;
            if (DBclass.DS.orders.Select("expenseId = -1").Length > 0 && terminalF.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                terminalSum = terminalF.sum != "" ? Convert.ToInt32(terminalF.sum) : 0;
                isTerminal = true;
                btnOplata_Click(btnOplata, new EventArgs());

            }
            else dgvTovar.Focus();
            
        }
        #region Search TBX
        private void tbxEnter(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("osk.exe");
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
                    rowindex = dgvExpense.Rows.Count - 1;
                }
                else
                {
                    rowindex = dgvExpense.CurrentCell.RowIndex;
                }
                float cnt = Convert.ToSingle(dgvExpense.Rows[rowindex].Cells[6].Value);
                float tempor = Convert.ToSingle(dgvExpense.Rows[rowindex].Cells[6].Value);
                if (action != "" && key_num != "")
                {
                    switch (action)
                    {
                        case "+":
                            cnt = cnt + Convert.ToSingle(key_num);
                            break;
                        case "-":
                            cnt = cnt - Convert.ToSingle(key_num);
                            break;
                        case "*":
                            cnt = cnt * (Convert.ToSingle(key_num) == 0 ? 1 : Convert.ToSingle(key_num));
                            break;
                        case "/":
                            cnt = cnt / (Convert.ToSingle(key_num) == 0 ? 1 : Convert.ToSingle(key_num));
                            break;
                    }
                    DataRow[] dr = DBclass.DS.product.Select("productId = " + Convert.ToInt32(dgvExpense.Rows[rowindex].Cells[4].Value));
                    if (dr.Length != 0)
                    {
                        ((DataSetTpos.productRow)dr[0]).pack = Convert.ToSingle(cnt - tempor);
                    }
                    AddProduct(dr, false, "");
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
    }
}
