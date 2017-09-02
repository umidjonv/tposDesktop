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

            FormFaktura faktura = new FormFaktura(prRow);
            if(faktura.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DBclass.DS.provider.AddproviderRow(prRow);
                
                updateProvider();
                FormCloseOK(DBclass.DS.provider.Rows[DBclass.DS.provider.Rows.Count - 1]["providerid"].ToString());
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
        }
    }
}
