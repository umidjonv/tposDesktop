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
namespace tposDesktop
{
    public partial class FakturaOrgsForm : DesignedForm
    {
        public FakturaOrgsForm()
        {
            InitializeComponent();
            DataSetTposTableAdapters.providerTableAdapter daProvider = new DataSetTposTableAdapters.providerTableAdapter();
            
            daProvider.Fill(DBclass.DS.provider);
            dgvFakturaOrg.DataSource = new DataView(DBclass.DS.provider);
        }
        public DataSetTpos.providerRow activeProviderRow;
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (dgvFakturaOrg.SelectedRows.Count > 0)
            {
                FormCloseOK(dgvFakturaOrg.SelectedRows[0].Cells["providerid"].Value.ToString());
            }
            if (dgvFakturaOrg.SelectedCells.Count > 0)
            {
                FormCloseOK(dgvFakturaOrg.Rows[dgvFakturaOrg.SelectedCells[0].RowIndex].Cells["providerid"].Value.ToString());
            }
        }
        private void FormCloseOK(string providerid)
        {
            DataRow[] drs = DBclass.DS.provider.Select("providerid = " + providerid);
            activeProviderRow = (DataSetTpos.providerRow)drs[0];
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataSetTpos.providerRow prRow = DBclass.DS.provider.NewproviderRow();

            FormFaktura faktura = new FormFaktura(prRow, false);
            if(faktura.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DBclass.DS.provider.AddproviderRow(prRow);
                
                updateProvider();
                FormCloseOK(DBclass.DS.provider.Rows[DBclass.DS.provider.Rows.Count - 1]["providerid"].ToString());
            }

        }

        private void btnEdit_Click(DataSetTpos.providerRow providerRow)
        {
            DataSetTpos.providerRow prRow = providerRow;

            FormFaktura faktura = new FormFaktura(prRow, true);
            if (faktura.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //DBclass.DS.provider.AddproviderRow(prRow);

                updateProvider();
                //FormCloseOK(DBclass.DS.provider.Rows[DBclass.DS.provider.Rows.Count - 1]["providerid"].ToString());
            }

        }

        private void updateProvider()
        {
            DataSetTposTableAdapters.providerTableAdapter prda = new DataSetTposTableAdapters.providerTableAdapter();
            prda.Update(DBclass.DS.provider);
            prda.Fill(DBclass.DS.provider);
        }
        private void FakturaOrgsForm_Load(object sender, EventArgs e)
        {
            dgvFakturaOrg.Columns["providerid"].HeaderText = "№";
            dgvFakturaOrg.Columns["orgName"].HeaderText = "Описание";
            dgvFakturaOrg.Columns["phone"].HeaderText = "Тел.";
            dgvFakturaOrg.Columns["orgName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvFakturaOrg.Columns["phone"].Width = 150;
            dgvFakturaOrg.Columns["providerid"].ReadOnly = true;
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dgvFakturaOrg.DataSource as DataView;
            dv.RowFilter = "orgName like '%" + tbxSearch.Text + "%'";

        }
        string orgNameBegin = "";
        string telNumberBegin = "";
        bool endEdit = false;
        private void dgvFakturaOrg_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //if (MessageBox.Show("Сохранить изменение", "Подтверждение...", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            //{
            //    endEdit = true;
            //}
            //else if (dgvFakturaOrg.Columns[e.ColumnIndex].Name == "orgName")
            //{

            //    dgvFakturaOrg.Rows[e.RowIndex].Cells["orgName"].Value = orgNameBegin;
            //}
            //else if (dgvFakturaOrg.Columns[e.ColumnIndex].Name == "phone")
            //{

            //    dgvFakturaOrg.Rows[e.RowIndex].Cells["phone"].Value = telNumberBegin;
            //}
            //orgNameBegin = "";
            //telNumberBegin = "";
        }

        private void dgvFakturaOrg_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            orgNameBegin = dgvFakturaOrg.Rows[e.RowIndex].Cells["orgName"].Value.ToString();
            telNumberBegin = dgvFakturaOrg.Rows[e.RowIndex].Cells["phone"].Value.ToString();
        }

        private void dgvFakturaOrg_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (endEdit)
            {
                if (MessageBox.Show("Сохранить изменение", "Подтверждение...", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    DataSetTposTableAdapters.providerTableAdapter daProvider = new DataSetTposTableAdapters.providerTableAdapter();

                    daProvider.Update(DBclass.DS.provider);

                }
                else if (dgvFakturaOrg.Columns[e.ColumnIndex].Name == "orgName")
                {

                    dgvFakturaOrg.Rows[e.RowIndex].Cells["orgName"].Value = orgNameBegin;
                }
                else if (dgvFakturaOrg.Columns[e.ColumnIndex].Name == "phone")
                {

                    dgvFakturaOrg.Rows[e.RowIndex].Cells["phone"].Value = telNumberBegin;
                }
                orgNameBegin = "";
                telNumberBegin = "";

            }
        }

        private void dgvFakturaOrg_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFakturaOrg.SelectedRows.Count > 0)
            {
                DataSetTpos.providerRow[] prRows = (DataSetTpos.providerRow[])DBclass.DS.provider.Select("providerId =" + dgvFakturaOrg.SelectedRows[0].Cells["providerId"].Value);
                if (prRows.Length > 0)
                {
                    btnEdit_Click(prRows[0]); 
                }
            }
            // 
        }
    }
}
