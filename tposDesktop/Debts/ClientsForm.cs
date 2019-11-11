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
using Classes.Model;



namespace tposDesktop.Debts
{
    public partial class ClientsForm : DesignedForm
    {
        MainHandlerADO mainhandler;
        public ClientsForm(bool isChoose)
        {
            InitializeComponent();
            mainhandler = new MainHandlerADO();
            if (isChoose)
            { btnGetClient.Visible = true; }
            
            
            
            dgvClients.DataSource = new DataView(mainhandler.RefreshClients());
        }

        private void ClientsForm_Load(object sender, EventArgs e)
        {
            dgvClients.Columns["clientId"].HeaderText = "№";
            dgvClients.Columns["clientId"].Width = 30;
            dgvClients.Columns["name"].HeaderText = "Имя";
            dgvClients.Columns["name"].Width = 70;
            dgvClients.Columns["address"].HeaderText = "Адрес";
            dgvClients.Columns["address"].Visible = false; 
            dgvClients.Columns["passport_num"].HeaderText = "Паспорт";
            
            dgvClients.Columns["phone"].HeaderText = "Тел.";
            dgvClients.Columns["name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbxFIO.Text != "")
            {
                bool isSave = mainhandler.AddClient(tbxFIO.Text, tbxAdress.Text, tbxPassSN.Text + tbxPassNumber.Text, tbxPhone.Text);
                if (!isSave)
                {
                    throw mainhandler.error;
                }
            }

        }
        public int currentClientID = 0;
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(currentClientID!=0)
            {
                mainhandler.GetClient(currentClientID);
                if (tbxFIO.Text != "")
                {
                    bool isSave = mainhandler.EditClient(tbxFIO.Text, tbxAdress.Text, tbxPassSN.Text + tbxPassNumber.Text, tbxPhone.Text);
                    if (!isSave)
                    {
                        throw mainhandler.error;
                    }
                }
            }
            
        }

        private void tbxSearchClient_TextChanged(object sender, EventArgs e)
        {
            //BindingSource source = (BindingSource)dgvClients.DataSource;
            if(tbxSearchClient.Text!= "По имени")
            dgvClients.DataSource = mainhandler.FilteredClients((DataView)dgvClients.DataSource, tbxSearchClient.Text);
        }

        private void dgvClients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            currentClientID = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["clientId"].Value);
            mainhandler.GetClient(currentClientID);

            tbxFIO.Text = dgv.Rows[e.RowIndex].Cells["name"].Value.ToString();
            tbxAdress.Text = dgv.Rows[e.RowIndex].Cells["address"].Value.ToString();
            tbxPassSN.Text = dgv.Rows[e.RowIndex].Cells["passport_num"].Value.ToString().Substring(0,2);
            tbxPassNumber.Text = dgv.Rows[e.RowIndex].Cells["passport_num"].Value.ToString().Substring(2);
            tbxPhone.Text = dgv.Rows[e.RowIndex].Cells["phone"].Value.ToString();
        }
        public DataSetDebt.clientsRow selectedClient;
        private void btnGetClient_Click(object sender, EventArgs e)
        {
            if (currentClientID != 0)
            {
                selectedClient = mainhandler.GetClient(currentClientID);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }


        private void dgvClients_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            dgvClients_CellContentClick(sender, e);
        }

        #region Search TBX
        private void tbxEnter(object sender, EventArgs e)
        {

            TextBox tbx = sender as TextBox;
            if (tbx.Text == "По имени" || tbx.Text == "По цене")
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
                    tbx.Text = "По имени";

                
                tbx.ForeColor = Color.Silver;
            }
        }
        #endregion

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbxFIO.Text = "";
            tbxAdress.Text = "";
            tbxPassNumber.Text = "";
            tbxPassSN.Text = "";
            tbxPhone.Text = "";
           
        }
    }
}
