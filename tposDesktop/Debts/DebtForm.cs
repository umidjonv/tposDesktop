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
namespace tposDesktop.Debts
{
    public partial class DebtForm : DesignedForm
    {
        
        public DebtForm()
        {
            InitializeComponent();
            mainHandler = new Classes.Model.MainHandlerADO();
            lbxDebts.DisplayMember = "detbname";
            lbxDebts.ValueMember = "debtId";
            debtsumsDT = new DataSetDebt.debtsumsDataTable();
            dgvSums.DataSource = new DataView(debtsumsDT);
            //RefreshDebtSum();
        }
        Classes.Model.MainHandlerADO mainHandler;
        public DataSetDebt.clientsRow currentClient;
        double currentAllSum = 0;
        int debtId = 0;
        private void btnClient_Click(object sender, EventArgs e)
        {
            ClientsForm client = new ClientsForm(true);
            if (client.ShowDialog() == DialogResult.OK)
            {
                if (client.selectedClient != null)
                {
                    
                    currentClient = client.selectedClient;
                    lblClient.Text = currentClient.name;
                    lbxDebts.DisplayMember = "debtname";
                    lbxDebts.ValueMember = "debtId";
                    lbxDebts.DataSource = mainHandler.RefreshvDebtsByClient(currentClient.clientId);
                    debtsumsDT.Clear();
                    //dgvSums.DataSource = new DataView(debtsumsDT);



                }

            }
        }
        DataSetDebt.debtsumsDataTable debtsumsDT;
        
        private void lbxDebts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxDebts.SelectedValue != null &&  lbxDebts.SelectedValue.GetType() ==typeof(int))
            {
                debtId = (int)lbxDebts.SelectedValue;
                DataSetDebt.debtsRow dbtRow = mainHandler.GetDebt(debtId);

                RefreshDebtsums((int)lbxDebts.SelectedValue);
                RefreshDebtSum();
            }
        }

        public void RefreshDebtsums(int id)
        {
            debtsumsDT.Clear();
            debtsumsDT = mainHandler.RefreshvDebtsumsByID(id);
            dgvSums.DataSource = new DataView(debtsumsDT);

        }
        DataSetDebt.v_debtsRepaymentDataTable repaymentDT;
        public void RefreshDebtSum()
        {
            
            repaymentDT = mainHandler.RefreshvDebtRepaymentByID(debtId);
            if (repaymentDT.Rows.Count > 0)
            {
                DataSetDebt.v_debtsRepaymentRow repayRow = (DataSetDebt.v_debtsRepaymentRow)repaymentDT.Rows[0];
                currentAllSum = repayRow.sum;
            }
            var sum = repaymentDT.AsEnumerable().Sum(x => x.Field<double>("sumPrixod"));
            

            lblAllSum.Text = (currentAllSum -sum).ToString();
           
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            if (lbxDebts.SelectedValue != null)
            {
                double summaT = Convert.ToDouble(tbxPercentSum.Text);
                double dolg = Convert.ToDouble(lblAllSum.Text);
                double prixodSum = Convert.ToDouble(tbxPercentSum.Text);

                mainHandler.AddDebtSum(prixodSum, (int)lbxDebts.SelectedValue);

                if (summaT == dolg)
                {

                    btnClose_Click(null, null);
                    
                }else
                {
                    RefreshDebtSum();
                    RefreshDebtsums((int)lbxDebts.SelectedValue);

                }
                
                //RefreshDebtsums((int)lbxDebts.SelectedValue);
               



            }
            
        }

        private void dgvSums_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;
            if (grid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                mainHandler.DeleteDebtSum((int)grid.Rows[e.RowIndex].Cells["debtsumsId"].Value);
                RefreshDebtsums((int)lbxDebts.SelectedValue);


            }
        }

        private void DebtForm_Load(object sender, EventArgs e)
        {
            dgvSums.Columns["debtsumsId"].Visible = false;
            dgvSums.Columns["debtId"].Visible = false;
            dgvSums.Columns["sum"].HeaderText = "Сумма";
            dgvSums.Columns["datesum"].HeaderText = "Дата";
            dgvSums.Columns["sum"].HeaderText = "Сумма";
            dgvSums.Columns["datesum"].Width = 200;
            dgvSums.Columns["sum"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridViewButtonColumn cellBtn2 = new System.Windows.Forms.DataGridViewButtonColumn();
            cellBtn2.HeaderText = "";
            cellBtn2.Name = "colDel";
            cellBtn2.Width = 40;
            cellBtn2.DisplayIndex = 2;
            dgvSums.Columns.Add(cellBtn2);
        }

        private void chbClose_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (debtId != 0)
            {
                if (MessageBox.Show("Закрыть долг?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    mainHandler.RefreshDebtsOpens();
                    mainHandler.EditDebts(debtId, 1);
                    lblAllSum.Text = "0";
                    debtId = 0;
                    currentAllSum = 0;
                    lblClient.Text = "---";
                    currentClient = null;
                    lbxDebts.DataSource = mainHandler.RefreshvDebtsByClient(0);
                    tbxPercentSum.Text = "0";
                    debtsumsDT.Clear();
                    //c//hbClose.Checked = false;

                }
            }
        }

        private void tbxPercentSum_TextChanged(object sender, EventArgs e)
        {
            if (tbxPercentSum.Text != "")
            {
                double summaT = Convert.ToDouble(tbxPercentSum.Text);
                double dolg = Convert.ToDouble(lblAllSum.Text);
                if (summaT > dolg && lblAllSum.Text != "0")
                {
                    tbxPercentSum.Text = dolg.ToString();
                }
            }


        }

        private void dgvSchet_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            var grid = (DataGridView)sender;
            if (grid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                DataGridViewButtonCell dgvCell = (DataGridViewButtonCell)grid.Rows[e.RowIndex].Cells[e.ColumnIndex];
                dgvCell.Value = "Удалить";
            }
        }
            }
}
