using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Classes.DB;

namespace tposDesktop
{
    public partial class FormDolgi : Form
    {
        public FormDolgi()
        {
            InitializeComponent();
            DBclass db = new DBclass();
            db.FillExpense();
            DataView dv = new DataView(DBclass.DS.expense);
            dv.RowFilter = "status = 1";
            
            dgvDolgi.DataSource = dv;

        }

        private void FormDolgi_Load(object sender, EventArgs e)
        {
            dgvDolgi.Columns["expenseId"].Visible = false;
           
            dgvDolgi.Columns["debt"].Visible = false;
            
            dgvDolgi.Columns["off"].Visible = false;
            dgvDolgi.Columns["status"].Visible = false;
            dgvDolgi.Columns["expType"].Visible = false;
            dgvDolgi.Columns["comment"].HeaderText = "Комментарий";
            dgvDolgi.Columns["expenseDate"].HeaderText = "Дата";
            dgvDolgi.Columns["terminal"].HeaderText = "Терминал";
            dgvDolgi.Columns["expSum"].HeaderText = "Сумма";
            dgvDolgi.Columns["comment"].ReadOnly = true ;
            dgvDolgi.Columns["expenseDate"].ReadOnly = true ;
            dgvDolgi.Columns["terminal"].ReadOnly = false;
            dgvDolgi.Columns["expSum"].ReadOnly = true;
            dgvDolgi.Columns["expenseDate"].Width = 150;
            dgvDolgi.Columns["comment"].Width = 200;
            dgvDolgi.Columns["comment"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDolgi.Columns["expSum"].Width = 100;
            
            DataGridViewButtonColumn cellBtn = new System.Windows.Forms.DataGridViewButtonColumn();
            cellBtn.HeaderText = "";
            cellBtn.Name = "colBtn";
            cellBtn.Width = 100;
            dgvDolgi.Columns.Add(cellBtn);
            dgvDolgi.EditingControlShowing += dgv_EditingControlShowing;
        }

        

        private void dgvDolgi_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            var grid = sender as DataGridView;
            if (grid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "Оплатить";
            }

        }

        private void dgvDolgi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = sender as DataGridView;
            if (grid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                
                DataSetTpos.debtRow debRow = DBclass.DS.debt.NewdebtRow();
                debRow.expenseId = Convert.ToInt32(grid.Rows[e.RowIndex].Cells["expenseId"].Value);
                debRow.payDate = DateTime.Now;
                debRow.terminal = 0;

                //debRow.
                DBclass.DS.expense.Select("expenseId = " + grid.Rows[e.RowIndex].Cells["expenseId"].Value.ToString())[0]["status"] = 0;
                DBclass.DS.debt.AdddebtRow(debRow);
                DataSetTposTableAdapters.expenseTableAdapter daExp = new DataSetTposTableAdapters.expenseTableAdapter();
                daExp.Update(DBclass.DS.expense);
                DataSetTposTableAdapters.debtTableAdapter daDebt = new DataSetTposTableAdapters.debtTableAdapter();
                daDebt.Update(DBclass.DS.debt);

            }else
            if (e.RowIndex >= 0)
            {
                dgvDolgi.CurrentCell = dgvDolgi.Rows[e.RowIndex].Cells["terminal"];
                dgvDolgi.BeginEdit(true);
            }

        }
        private void dgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Text_KeyPress);
            if (dgvDolgi.CurrentCell.ColumnIndex == dgvDolgi.Columns["terminal"].Index) //Desired Column
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
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dgvDolgi_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
