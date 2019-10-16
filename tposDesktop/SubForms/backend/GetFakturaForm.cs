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
using Classes.DB;
namespace tposDesktop.SubForms
{
    public partial class GetFakturaForm : DesignedForm
    {
        public GetFakturaForm()
        {
            InitializeComponent();
            DataSetTposTableAdapters.fakturaviewTableAdapter fkView = new DataSetTposTableAdapters.fakturaviewTableAdapter();
            fkView.Fill(DBclass.DS.fakturaview, DateTime.Now.AddYears(-3), DateTime.Now);
            DataView dvF = new DataView(DBclass.DS.fakturaview);
            dvF.RowFilter = "isClosed = 0";
            dvF.Sort = "fakturaId desc";
            dgvFaktura.DataSource = dvF;

            //DBclass.DS.fakturaview
            
        }
        public int fakturaId;
        private void dgvFaktura_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            fakturaId = (int)(sender as DataGridView).Rows[e.RowIndex].Cells["fakturaId"].Value;
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void GetFakturaForm_Load(object sender, EventArgs e)
        {
            dgvFaktura.Columns["fakturaId"].HeaderText = "№ фактуры";
            dgvFaktura.Columns["fakturaDate"].HeaderText = "Дата";
            dgvFaktura.Columns["orgName"].HeaderText = "Поставщик";
            dgvFaktura.Columns["orgName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvFaktura.Columns["phone"].Visible = false;
            dgvFaktura.Columns["isClosed"].Visible = false;
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dgvFaktura.DataSource as DataView;
            dv.RowFilter = "orgName like '%" + tbxSearch.Text + "%'";
        }

    }
}
