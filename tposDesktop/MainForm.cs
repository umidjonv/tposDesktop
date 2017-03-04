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
    public partial class MainForm : Form
    {
        DBclass db;
        Scanner scan;
        DataSetTpos.ordersDataTable order;
        string commentDebt = null;
        int terminalSum = 0;
        bool isNewExpense = true;
        object packCount = 0;
        public MainForm()
        {
            InitializeComponent();
            this.Icon = tposDesktop.Properties.Resources.mainIcon;
            db = new DBclass();
            db.FillExpense();
            db.FillProduct();
            if (!(DBclass.DS.orders.Columns["sumProduct"] is DataColumn))
            DBclass.DS.orders.Columns.Add("sumProduct", typeof(int));
            DataView dv = new DataView(DBclass.DS.product);
            
            DataView dvOr = new DataView(DBclass.DS.orders);
            dvOr.RowFilter = "expenseId = -1";
            dgvTovar.DataSource = dv;
            dgvExpense.DataSource = dvOr;
            
            dv.RowFilter = tbxSearchTovar.Text;
            dgvExpense.EditingControlShowing += dgv_EditingControlShowing;
            if(UserValues.role == "admin")
            {
                menuAdmin.Visible = true;
            }
            try
            {
                scan = new Scanner();
                scan.ScannerEvent += scan_ScannerEvent;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        

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
            // TODO: This line of code loads data into the 'dataSetTpos.orders' table. You can move, or remove it, as needed.
            this.ordersTableAdapter.Fill(this.dataSetTpos.orders);
            dgvTovar.Columns["productId"].HeaderText = "№";
            dgvTovar.Columns["name"].HeaderText = "Товар";
            dgvTovar.Columns["price"].HeaderText = "Цена";
            dgvTovar.Columns["measureId"].Visible = false;
            dgvTovar.Columns["barcode"].Visible = false;
            dgvTovar.Columns["pack"].Visible = false;
            dgvTovar.Columns["status"].Visible = false;
            dgvTovar.Columns["productId"].Width = 50;
            dgvTovar.Columns["name"].Width = 200;
            dgvTovar.Columns["price"].Width= 90;
            Classes.GridCells.ImageButtonColumn cellBtn = new Classes.GridCells.ImageButtonColumn();
            cellBtn.HeaderText = "";
            cellBtn.Name = "colBtn";
            cellBtn.Width = 40;
            //Classes.GridCells.ImageCell cellImg = new Classes.GridCells.ImageCell();
            cellBtn.SetImage(Properties.Resources.add);

            dgvTovar.Columns.Add(cellBtn);

            dgvExpense.Columns["prodId"].Visible = false;
            dgvExpense.Columns["orderId"].Visible = false;
            dgvExpense.Columns["expenseId"].Visible = false;
            dgvExpense.Columns["count"].Visible = false;
            dgvExpense.Columns["packCount"].HeaderText = "Кол.";
            dgvExpense.Columns["packCount"].ValueType = typeof(int);
            dgvExpense.Columns["productName"].Width = 200;
            dgvExpense.Columns["packCount"].Width = 50;
            dgvExpense.Columns["productName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvExpense.Columns["sumProduct"].HeaderText = "Сумма";

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
            cellBtnDel.DisplayIndex = 10;
            dgvExpense.Columns.Add(cellBtnDel);
            //cellTx.CellType = typeof(int);
            //dgvExpense.Columns.Add(cellTx);
        }

        private void tbxSearchTovar_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dgvTovar.DataSource as DataView;
            dv.RowFilter = "name like '%" + tbxSearchTovar.Text+"%'";
            
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
                    if (Int32.Parse(dgvExpense.Rows[e.RowIndex].Cells["packCount"].Value.ToString()) == 1)
                    {
                        dgvExpense.Rows.RemoveAt(e.RowIndex);
                        sumTable();
                    }
                    else
                    { 
                        int i = Int32.Parse(dgvExpense.Rows[e.RowIndex].Cells["packCount"].Value.ToString());
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
        private void AddToOrders(int id)
        {
            DataRow[] dr = DBclass.DS.product.Select("productId = " + id);
            AddProduct(dr, false, null);
        }

        private void AddToOrders(string barcode)
        {
            DataRow[] dr = DBclass.DS.product.Select("barcode = '" + barcode+"'");
            AddProduct(dr, true, barcode);

        }
        private void AddProduct(DataRow[] dr, bool isBarcode, string barcode)
        {
            if (dr.Length != 0)
            {
                DataSetTpos.productRow drP = (DataSetTpos.productRow)dr[0];
                DataRow[] existRows = DBclass.DS.orders.Select("expenseId=-1 and prodId = " + drP.productId);
                if (existRows.Length > 0)
                {
                    DataSetTpos.ordersRow ordrow = (DataSetTpos.ordersRow)existRows[0];
                    ordrow.packCount = ordrow.packCount + (drP.pack == 0 ? 1 : drP.pack);
                    //ordrow.AcceptChanges();
                }
                else
                {
                    DataSetTpos.ordersRow ordrow = DBclass.DS.orders.NewordersRow();



                    ordrow.prodId = drP.productId;
                    ordrow.expenseId = -1;
                    OrderForm oform = new OrderForm(drP.pack, drP.price.ToString());
                    if (oform.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        ordrow.packCount = oform.count;
                        DataRow drOrder = ordrow;
                        drOrder["sumProduct"] = ordrow.packCount * drP.price/(drP.pack==0?1:drP.pack);

                        //grid.Rows[e.RowIndex].Cells["sumProduct"].Value = (Convert.ToInt32(grid.Rows[e.RowIndex].Cells["packCount"].Value) * Convert.ToInt32(grid.Rows[e.RowIndex].Cells["productPrice"].Value)).ToString();
                    }
                    else { return; }
                    DBclass.DS.orders.AddordersRow(ordrow);
                }
                if (isNewExpense)
                {
                    //dgvExpense.Columns["productName"].Visible = true;
                    //dgvExpense.Columns["productPrice"].Visible = true;
                    isNewExpense = false;
                }
                sumTable();
            }
            else if (isBarcode&& UserValues.role=="admin")
            {
                AddForm addForm = new AddForm(barcode);
                if (addForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    productTableAdapter daProduct = new productTableAdapter();
                    daProduct.Fill(DBclass.DS.product);

                     
                }
 
            }
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
                }
            }
            
        }
        
        private void btnOplata_Click(object sender, EventArgs e)
        {
            if(dgvExpense.Rows.Count!=0 && MessageBox.Show("Произвести оплату?", "Оплата", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                expenseTableAdapter expDa = new expenseTableAdapter();
                expDa.Adapter.SelectCommand = new MySql.Data.MySqlClient.MySqlCommand("select * from expense order by expenseId desc limit 1", expDa.Connection);
                DataSetTpos.expenseDataTable expTable = new DataSetTpos.expenseDataTable();
                DataSetTpos.expenseRow expRow = expTable.NewexpenseRow();
                float sum = 0;
                foreach (DataGridViewRow dgvRow in dgvExpense.Rows)
                {
                    sum += (float)dgvRow.Cells["packCount"].Value * (int)dgvRow.Cells["productPrice"].Value;
                }
                expRow.expenseDate = DateTime.Now;
                expRow.debt = chbDolg.Checked ? 1 : 0;
                expRow.status = chbDolg.Checked ? 1 : 0;
                expRow.comment = chbDolg.Checked ? commentDebt : "";
                expRow.expType = vozvrat ? 1 : 0;
                
                expRow.expSum = (int)sum;

                if (chbTerminal.Checked)
                {
                    expRow.terminal = tbxTerminal.Text != "" ? Convert.ToInt32(tbxTerminal.Text) : expRow.expSum;
                }
                else expRow.terminal = 0;
                expTable.Rows.Add(expRow);

                expDa.Update(expTable);
                expDa.FillLast(expTable);
                ordersTableAdapter prDa = new ordersTableAdapter();
                DataSetTpos.ordersRow[] orRows = (DataSetTpos.ordersRow[])DBclass.DS.orders.Select("expenseId = -1");
                foreach (DataSetTpos.ordersRow oneRow in orRows)
                {
                    oneRow.expenseId = (expTable.Rows[0] as DataSetTpos.expenseRow).expenseId;
                }
                prDa.Update(DBclass.DS.orders);

                DataView dv = dgvExpense.DataSource as DataView;

                lblSum.Text = "0";

                //dgvExpense.Columns["productName"].Visible = false;
                //dgvExpense.Columns["productPrice"].Visible = false;
                isNewExpense = true;
                chbDolg.Checked = false;
                commentDebt = "";
                chbTerminal.Checked = false;
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
                    grid.Rows[e.RowIndex].Cells["productPrice"].Value = prRow.price/prRow.pack; 
                }
                else
                {
                    grid.Rows[e.RowIndex].Cells["productPrice"].Value = prRow.price; 
                }

            }
        }

        private void dgvExpense_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
             var grid = (DataGridView)sender;
             if ((grid.Columns[e.ColumnIndex].Name == "packCount" && e.RowIndex >= 0) && grid.Rows[e.RowIndex].Cells["packCount"].Value!=DBNull.Value)
             {
                 int pck;
                 if (Int32.TryParse(grid.Rows[e.RowIndex].Cells["packCount"].Value.ToString(), out pck))
                 {
                     grid.Rows[e.RowIndex].Cells["sumProduct"].Value = (Convert.ToInt32(grid.Rows[e.RowIndex].Cells["packCount"].Value) * Convert.ToInt32(grid.Rows[e.RowIndex].Cells["productPrice"].Value)).ToString();
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
            if ((!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))||(char.IsDigit(e.KeyChar)&&e.KeyChar==48))
            {
                e.Handled = true;
            }
            
        }

        private void exitMenu_Click(object sender, EventArgs e)
        {
            Program.window_type = 0;
            this.Close();
            
        }

       
        
        private void chbDolg_CheckedChanged_1(object sender, EventArgs e)
        {
            CheckBox chb = sender as CheckBox;
            if (chb.Checked && DBclass.DS.orders.Select("expenseId = -1").Length > 0)
            {
                commentForm commentf = new commentForm();
                if (commentf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    commentDebt = commentf.comment;
                }
                else chbDolg.Checked = false;
            }
            else if (chb.Checked)
                chb.Checked = false;
            
        }

        private void chbTerminal_CheckedChanged(object sender, EventArgs e)
        {
            if (chbTerminal.Checked && DBclass.DS.orders.Select("expenseId = -1").Length > 0)
            {
                tbxTerminal.Visible = true;
            }
            else if (chbTerminal.Checked)
            { chbTerminal.Checked = false; }
            else
            { tbxTerminal.Visible = false; }
        }

        private void btnDolg_Click(object sender, EventArgs e)
        {
            FormDolgi dolgi = new FormDolgi();
            dolgi.ShowDialog();
        }
        bool vozvrat = false;
        private void btnVozvrat_Click(object sender, EventArgs e)
        {
            if(!vozvrat)
            {
                this.btnVozvrat.BackgroundImage = (System.Drawing.Image)(Properties.Resources.back);
                groupBox2.Text = "Возврат товара";
                vozvrat = true;
            }else
            {
                this.btnVozvrat.BackgroundImage = (System.Drawing.Image)(Properties.Resources.cart);
                groupBox2.Text = "Расход товара";
                vozvrat = false;
            }
            
        }

        private void dgvExpense_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnOplata_Click(btnOplata, new EventArgs());
            }
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
        
    }
}
