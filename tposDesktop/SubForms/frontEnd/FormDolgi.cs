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
using Classes.Forms;
namespace tposDesktop
{
    public partial class FormDolgi : DesignedForm
    {
        private bool _dragging = false;		
	    private Point _offset;		
    	private Point _start_point = new Point(0, 0);
        public FormDolgi()
        {
            InitializeComponent();
            DBclass db = new DBclass();
            contragentTableAdapter1.Fill(DBclass.DS.contragent);
            DataView dv = new DataView(DBclass.DS.contragent);
            dv.RowFilter = "sums<>0";
            dgvDolgi.DataSource = dv;
        }

        private void FormDolgi_Load(object sender, EventArgs e)
        {
            dgvDolgi.Columns["contragentId"].Visible = false;
            dgvDolgi.Columns["name"].HeaderText = "Должник";
            dgvDolgi.Columns["phone"].HeaderText = "Телефон";
            dgvDolgi.Columns["sums"].HeaderText = "сумма";
            dgvDolgi.Columns["phone"].ReadOnly = true;
            dgvDolgi.Columns["name"].ReadOnly = true;
            dgvDolgi.Columns["sums"].ReadOnly = true;
            dgvDolgi.Columns["phone"].Width = 150;
            dgvDolgi.Columns["name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDolgi.Columns["sums"].Width = 100;
            
            DataGridViewButtonColumn cellBtn = new System.Windows.Forms.DataGridViewButtonColumn();
            cellBtn.HeaderText = "";
            cellBtn.Name = "colBtn";
            cellBtn.Width = 100;
            dgvDolgi.Columns.Add(cellBtn);
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
                int sums = Convert.ToInt32(grid.Rows[e.RowIndex].Cells["sums"].Value);

                DataSetTpos.debtRow debRow = DBclass.DS.debt.NewdebtRow();
                DataSetTposTableAdapters.infoTableAdapter daInfo = new DataSetTposTableAdapters.infoTableAdapter();
                daInfo.Fill(DBclass.DS.info);
                string dat = DateTime.Now.ToString("dd.mm.yyyy");
                DataRow[] drInfo = DBclass.DS.info.Select("Dates='" + Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00") + "'");
                debRow.payDate = DateTime.Now;
                debtPaid dbt = new debtPaid(sums);
                if (dbt.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    int termi = 0;
                    if (dbt.terminal == true)
                    {
                        termi = dbt.paidSumm;
                        drInfo[0]["terminal"] = Convert.ToInt32(drInfo[0]["terminal"]) + termi;
                    }
                    else
                    {
                        drInfo[0]["nal"] = Convert.ToInt32(drInfo[0]["nal"]) + Convert.ToInt32(dbt.paidSumm);
                    }
                    debRow.terminal = termi;
                    drInfo[0]["proceed"] = Convert.ToInt32(drInfo[0]["proceed"]) + Convert.ToInt32(dbt.paidSumm);
                    debRow.summ = Convert.ToInt32(dbt.paidSumm);

                }
                
                //debRow.
                DataRow[] drs = DBclass.DS.contragent.Select("contragentId = " + grid.Rows[e.RowIndex].Cells["contragentId"].Value.ToString());
                if (drs.Length != 0)
                {
                    drs[0]["sums"] = Convert.ToInt32(drs[0]["sums"]) - debRow.summ;
                }
                DBclass.DS.debt.AdddebtRow(debRow);
                daInfo.Update(drInfo[0]);
                DataSetTposTableAdapters.debtTableAdapter daDebt = new DataSetTposTableAdapters.debtTableAdapter();
                daDebt.Update(debRow);
                DataSetTposTableAdapters.contragentTableAdapter daContr = new DataSetTposTableAdapters.contragentTableAdapter();
                daContr.Update(drs);
                contragentTableAdapter1.Fill(DBclass.DS.contragent);
                DataView dv = new DataView(DBclass.DS.contragent);
                dv.RowFilter = "sums<>0";
                dgvDolgi.DataSource = dv;
                //dgvDolgi.Refresh();
                
            }
            //else
            //if (e.RowIndex >= 0)
            //{
            //    dgvDolgi.CurrentCell = dgvDolgi.Rows[e.RowIndex].Cells["terminal"];
            //    dgvDolgi.BeginEdit(true);
            //}

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

        private void dgvDolgi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            { this.Close(); }
        }

        private void tbxFilter_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dgvDolgi.DataSource as DataView;
            if (tbxFilter.Text.Length > 0)
            { dv.RowFilter = "name like '%" + tbxFilter.Text + "%'"; }
            else
            { dv.RowFilter = ""; }
        }

        private void tbxFilter_Leave(object sender, EventArgs e)
        {
            if (tbxFilter.Text == "")
            {
                tbxFilter.Text = "Поиск";
                tbxFilter.ForeColor = Color.Silver;
            }
            
        }

        private void tbxFilter_Enter(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("osk.exe");
            if (tbxFilter.Text == "Поиск")
            {
                tbxFilter.Text = "";
                tbxFilter.ForeColor = Color.Black;
                
            }
        }

        
    }
}
