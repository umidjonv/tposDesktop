using Classes.DB;
using Classes.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tposDesktop
{
    public partial class Contragent : DesignedForm
    {
        public Contragent()
        {
            InitializeComponent();
            DataSetTposTableAdapters.contragentTableAdapter daProvider = new DataSetTposTableAdapters.contragentTableAdapter();

            daProvider.Fill(DBclass.DS.contragent);
            dgvContagent.DataSource = new DataView(DBclass.DS.contragent);
        }
        public DataSetTpos.contragentRow activeContragentRow;
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (dgvContagent.SelectedRows.Count > 0)
            {
                FormCloseOK(dgvContagent.SelectedRows[0].Cells["contragentId"].Value.ToString());
            }
        }
        private void FormCloseOK(string providerid)
        {
            DataRow[] drs = DBclass.DS.contragent.Select("contragentId = " + providerid);
            activeContragentRow = (DataSetTpos.contragentRow)drs[0];
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataSetTpos.contragentRow prRow = DBclass.DS.contragent.NewcontragentRow();

            ContAdd faktura = new ContAdd(prRow);
            if (faktura.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DBclass.DS.contragent.AddcontragentRow(prRow);

                updateProvider();
                FormCloseOK(DBclass.DS.contragent.Rows[DBclass.DS.contragent.Rows.Count - 1]["contragentId"].ToString());
            }

        }
        private void updateProvider()
        {
            DataSetTposTableAdapters.contragentTableAdapter prda = new DataSetTposTableAdapters.contragentTableAdapter();
            prda.Update(DBclass.DS.contragent);
            prda.Fill(DBclass.DS.contragent);
        }
        private void FakturaOrgsForm_Load(object sender, EventArgs e)
        {
            dgvContagent.Columns["contragentId"].HeaderText = "№";
            dgvContagent.Columns["name"].HeaderText = "Описание";
            dgvContagent.Columns["phone"].HeaderText = "Тел.";
            dgvContagent.Columns["sums"].Visible = false;
            dgvContagent.Columns["name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvContagent.Columns["phone"].Width = 150;
        }

        private void tbxFilter_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dgvContagent.DataSource as DataView;
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
