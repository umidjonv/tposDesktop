using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Classes.Forms;
using Classes;
using Classes.DB;
namespace tposDesktop.SubForms
{
    public partial class FormToFilial : DesignedForm
    {
        TextScanner tscanner;
        DataTable table;
        bool beginBarcode = false;
        public FormToFilial()
        {
            InitializeComponent();
            tscanner = new TextScanner();

            table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Kol", typeof(double));
            table.Columns.Add("Ostatok", typeof(string));
            table.Columns.Add("Price", typeof(int));
            table.Columns.Add("Pack", typeof(int));
            dgvTofilial.DataSource = table;
            DataSetTposTableAdapters.balanceTableAdapter bda = new DataSetTposTableAdapters.balanceTableAdapter();
            bda.Fill(DBclass.DS.balance);
            DataSetTposTableAdapters.productviewTableAdapter pda = new DataSetTposTableAdapters.productviewTableAdapter();
            pda.Fill(DBclass.DS.productview);
            lbxTovary.DataSource = new DataView(DBclass.DS.productview);
            lbxTovary.DisplayMember = "name";
            lbxTovary.ValueMember = "productId";
                
        }
        private void FormToFilial_Load(object sender, EventArgs e)
        {
            dgvTofilial.Columns[2].HeaderText = "Товар";
            dgvTofilial.Columns[3].HeaderText = "Кол.";
            dgvTofilial.Columns[4].HeaderText = "Остаток";
            dgvTofilial.Columns[5].HeaderText = "Цена";
            dgvTofilial.Columns["Pack"].Visible = false;
            dgvTofilial.Columns[0].ReadOnly = true;
            dgvTofilial.Columns[2].ReadOnly = true;

            dgvTofilial.Columns[4].ReadOnly = true;
            dgvTofilial.Columns[5].ReadOnly = true;
            dgvTofilial.Columns[1].Width = 75;
            //dgvTofilial.Columns[4].HeaderText = "Остаток";

            dgvTofilial.Columns[2].Width = 200;
            dgvTofilial.Columns[0].DisplayIndex = 5;

            dgvTofilial.Focus();
        }
        Dictionary<int, DataSetTpos.productRow> listProducts = new Dictionary<int, DataSetTpos.productRow>();
        private void dgvTofilial_KeyPress(object sender, KeyPressEventArgs e)
        {
            char key = e.KeyChar;
            decimal dec;
            string st = "";
            if (sender is TextBox)
                st = (sender as TextBox).Text;
            if (tscanner != null && (decimal.TryParse(st, out dec) || st == ""))
            {
                if (char.IsDigit(key))
                {

                    if (!beginBarcode)
                    {
                        tscanner.Start();
                        beginBarcode = true;
                    }
                    tscanner.Symbol(key);
                    
                }
            }
            else
            {
                beginBarcode = false; if (tscanner != null) tscanner.End();
            }
            if (tscanner != null && (e.KeyChar == 13 && beginBarcode))
            {
                tscanner.End();
                DataSetTpos.productviewRow[] prows;
                DataSetTpos.productRow[] pdrows;
                if (sender is TextBox && tbxTovar.Text.Length != 0)
                {
                    if (tbxTovar.Text.Length <= 5)
                    {
                        prows = (DataSetTpos.productviewRow[])DBclass.DS.productview.Select("productId = '" + tbxTovar.Text + "'");
                        pdrows = (DataSetTpos.productRow[])DBclass.DS.product.Select("productId = '" + tbxTovar.Text + "'");
                    }
                    else 
                    {
                        prows = (DataSetTpos.productviewRow[])DBclass.DS.productview.Select("barcode = '" + tbxTovar.Text + "'");
                        pdrows = (DataSetTpos.productRow[])DBclass.DS.product.Select("barcode = '" + tbxTovar.Text + "'");
                    }
                    tbxTovar.Text = "";
                }
                    
                else
                {
                    prows = (DataSetTpos.productviewRow[])DBclass.DS.productview.Select("barcode = '" + tscanner.barcode + "'");
                    pdrows = (DataSetTpos.productRow[])DBclass.DS.product.Select("barcode = '" + tscanner.barcode + "'");
                    tbxTovar.Focus();
                }
                if (prows.Length > 0)
                {

                    DataSetTpos.productviewRow productrow = prows[0];
                    //DataSetTpos.balanceRow[] brows = (DataSetTpos.balanceRow[])DBclass.DS.balance.Select("prodId = " + productrow.productId );

                    table.Select("ID = " + productrow.productId);

                    table.Rows.Add(productrow.productId, productrow.name, 0, productrow.endCount, productrow.price, pdrows[0].pack);
                    dgvTofilial.Refresh();
                    listProducts.Add(pdrows[0].productId, pdrows[0]);
                }
                beginBarcode = false;

                dgvTofilial.Focus();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SaveFileDialog svf = new SaveFileDialog();
            svf.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop, Environment.SpecialFolderOption.None);
            svf.Filter = "Файлы Excel|*.xlsx";
            svf.FileName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop, Environment.SpecialFolderOption.None) + "\\" + DateTime.Now.ToShortDateString() + "filial.xlsx";
            if (svf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (MessageBox.Show("Вы действительно хотите экспортировать список?", "Предупреждение...", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                {
                    ExcelClass excel = new ExcelClass(svf.FileName);

                    excel.Create("Filial");
                    int beginIndex = 4;
                    int colCount = 5;
                    object[,] objVal = new object[table.Rows.Count, colCount];

                    //objVal[0, 0] = "#";
                    //objVal[0, 1] = "Наименование";
                    //objVal[0, 2] = "Производитель";
                    //objVal[0, 3] = "Установлена";
                    //objVal[0, 4] = "Версия";
                    //objVal[0, 5] = "Пользователь";
                    //objVal[0, 6] = "Компьютер";

                    excel.SetSize("A1", false);
                    excel.Merging("A1", "B1");
                    excel.SetCell("A1", tbxFilial.Text, true);
                    excel.SetCell("B2", DateTime.Now.ToString("dd.MM.yyyy HH:mm"), true);
                    //excel.activeSheet.Range("A1:A2").mer
                    excel.SetCell("A3", "ID", true);
                    excel.SetCell("B3", "Товар", true);
                    excel.ColWidth("B", 50);
                    excel.SetCell("C3", "Количество", true);
                    excel.ColWidth("C", 12);
                    excel.SetCell("D3", "Цена", true);
                    excel.ColWidth("D", 12);
                    excel.SetCell("E3", "Сумма", true);
                    excel.ColWidth("E", 12);
                    int i = beginIndex;
                    foreach (DataRow dr in table.Rows)
                    {
                        int id = (int)dr["ID"];

                        DBclass db = new DBclass(true);


                        DataSetTpos.productRow[] product = { listProducts[(int)dr["ID"]] };
                        //DataSetTpos.productRow[] drProduct = (DataSetTpos.productRow[])DBclass.DS.product.Select("productId = " + id);
                        if (Convert.ToInt32(dr["Price"]) != 0 && dr["Kol"].ToString() != "0")
                        {
                            db.AddProduct(product, false, "", (Convert.ToInt32(dr["pack"]) != 0 ? Convert.ToInt32(dr["pack"]) * int.Parse(dr["Kol"].ToString()) : int.Parse(dr["Kol"].ToString())));
                            db.Debt();

                            
                            
                            
                            

                            int j = i - beginIndex;
                            //DataGridViewRow dgvRow = dgvProgram.Rows[i - 1];
                            objVal[j, 0] = dr["ID"].ToString();
                            objVal[j, 1] = dr["Name"].ToString();
                            objVal[j, 2] = dr["Kol"].ToString();
                            objVal[j, 3] = dr["Price"].ToString();
                            objVal[j, 4] = (Convert.ToInt32(dr["Price"]) * int.Parse(dr["Kol"].ToString())).ToString();
                            

                            
                            i++;
                        }

                    }
                    excel.saveWorkbook(objVal, table.Rows.Count,beginIndex, colCount);
                    excel.SetCell("B" + i, "Итого:", true);
                    //excel.SetCell("C" + i, "=SUM(C4:C" + (i-1) + ")", true);
                    //excel.SetCell("D" + i, "=SUM(D4:D" + (i - 1) + ")", true);
                    excel.SetCell("E" + i, "=SUM(E4:E" + (i - 1) + ")", true);

                    excel.activeSheet.Application.Visible = true;
                    excel.SaveOnly();
                    listProducts.Clear();
                    dgvTofilial.Focus();
                    this.Close();
                    

                    
                }
            }
        }

        private void dgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Text_KeyPress);
            if (dgvTofilial.CurrentCell.ColumnIndex == dgvTofilial.Columns["Kol"].Index) //Desired Column
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
            else if(e.KeyChar == 13)
            {
                
            }

        }

        private void dgvTofilial_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvTofilial_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void dgvTofilial_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvTofilial.Rows[e.RowIndex].Cells["colBtnDel"].Value = "X";
                
        }

        private void dgvTofilial_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTofilial.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                dgvTofilial.Rows.Remove(dgvTofilial.Rows[e.RowIndex]); 
            }
        }

        private void tbxTovarName_TextChanged(object sender, EventArgs e)
        {
            if (tbxTovarName.Text.Length > 0)
            {
                lbxTovary.Visible = true;
                (lbxTovary.DataSource as DataView).RowFilter = "name like '%"+tbxTovarName.Text+"%'";
            }
            else
            {
                lbxTovary.Visible = false;
            }
        }

        private void tbxTovarName_Leave(object sender, EventArgs e)
        {
            //lbxTovary.Visible = false;
        }

        private void dgvTofilial_Enter(object sender, EventArgs e)
        {
            lbxTovary.Visible = false;
        }

        private void tbxTovar_Enter(object sender, EventArgs e)
        {
            lbxTovary.Visible = false;
        }

        private void tbxFilial_Enter(object sender, EventArgs e)
        {
            lbxTovary.Visible = false;
        }
        //Dictionary<int, >
        private void lbxTovary_DoubleClick(object sender, EventArgs e)
        {
            if (lbxTovary.SelectedValue != null)
            {
                DataSetTpos.productviewRow[] prows;
                DataSetTpos.productRow[] pdows;

                prows = (DataSetTpos.productviewRow[])DBclass.DS.productview.Select("productId = '" + (int)lbxTovary.SelectedValue + "'");
                pdows = (DataSetTpos.productRow[])DBclass.DS.product.Select("productId = '" + (int)lbxTovary.SelectedValue + "'");


                if (prows.Length > 0)
                {

                    DataSetTpos.productviewRow productrow = prows[0];
                    DataSetTpos.balanceRow[] brows = (DataSetTpos.balanceRow[])DBclass.DS.balance.Select("prodId = " + productrow.productId);
                    DataSetTpos.productRow[] pdrows = (DataSetTpos.productRow[])DBclass.DS.product.Select("productId = " + productrow.productId);
                    table.Select("ID = " + productrow.productId);

                    //table.Rows.Add(productrow.productId, productrow.name, 0, productrow.endCount, productrow.price);
                    table.Rows.Add(productrow.productId, productrow.name, 0, productrow.endCount, productrow.price, pdrows[0].pack);
                    dgvTofilial.Refresh();
                    listProducts.Add(productrow.productId, pdows[0]);
                }
                tbxTovarName.Text = "";
                dgvTofilial.Focus();
            }
        }

        private void tbxTovarName_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void tbxTovarName_KeyDown(object sender, KeyEventArgs e)
        {
            if(lbxTovary.Items.Count>0)
            if (e.KeyCode == Keys.Up)
            {
                if (lbxTovary.SelectedIndex != 0)
                    lbxTovary.SelectedIndex--;
                tbxTovarName.SelectionStart = tbxTovarName.Text.Length -1;// add some logic if length is 0
                tbxTovarName.SelectionLength = 0;
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (lbxTovary.SelectedIndex != (lbxTovary.Items.Count-1))
                    lbxTovary.SelectedIndex++;
                tbxTovarName.SelectionStart = tbxTovarName.Text.Length - 1; // add some logic if length is 0
                tbxTovarName.SelectionLength = 0;
            }
            
        }

        

        
    }
}
