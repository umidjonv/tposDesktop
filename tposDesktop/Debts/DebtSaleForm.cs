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
    public partial class DebtSaleForm : DesignedForm
    {
        public DebtSaleForm(double sum)
        {
            
            InitializeComponent();
            actualSum = sum;
            lblActualSum.Text =  sum.ToString();
            mainHandler = new Classes.Model.MainHandlerADO();
            cbxKredit.DisplayMember = "typename";
            cbxKredit.ValueMember = "debttypeId";
            cbxKredit.DataSource = mainHandler.RefreshDebttypes();
            SetPercents();

            //Classes.DB.DBDebt.DS.debttypes

        }
        Classes.Model.MainHandlerADO mainHandler;
        public DataSetDebt.clientsRow currentClient;
        public double actualSum = 0;
        public double percentSum = 0;
        public int percent = 0;
        public int typeId = 0;
        public double beginSum = 0;
        public double terminalSum = 0;
        private void showBtn_Click(object sender, EventArgs e)
        {
            ClientsForm client = new ClientsForm(true);
            if (client.ShowDialog() == DialogResult.OK)
            {
                if (client.selectedClient != null)
                {
                    currentClient = client.selectedClient;
                    lblClient.Text = currentClient.name;
                }
                
            }
        }
        int curDebttypeID = 0;
        private void cbxKredit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxKredit.SelectedValue != null)
            {
                curDebttypeID = (int)(cbxKredit.SelectedValue);

                SetPercents();
            }
        }
        public void SetPercents()
        {
            DataSetDebt.debttypesRow dtRow = mainHandler.GetDebttype(curDebttypeID);

            tbxPercent.Text = dtRow.percent.ToString();
            tbxPeriod.Text = dtRow.period.ToString();
            percentSum = actualSum + Math.Round(actualSum / 100 * (double)dtRow.percent);
            percent = dtRow.percent;
            lblOneMonthSum.Text = ((percentSum - beginSum) / (double)(dtRow.period)).ToString();
            typeId = curDebttypeID;
            lblPercentSum.Text = percentSum.ToString();

        }
        private void btnSale_Click(object sender, EventArgs e)
        {
            if (currentClient != null && percentSum != 0)
            {
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void tbxBeginSum_TextChanged(object sender, EventArgs e)
        {

            if (tbxBeginSum.Text == "")
            {
                beginSum = 0;
            }
            else
            { beginSum = Convert.ToDouble(tbxBeginSum.Text); }
                
                if (beginSum > percentSum)
                {
                    beginSum = percentSum;
                    tbxBeginSum.Text = percentSum.ToString();
                }
                SetPercents();
            
               

        }

        private void btnTerminal1_Click(object sender, EventArgs e)
        {
            if (currentClient != null && percentSum != 0)
            {

                
                //System.Diagnostics.Process.Start("osk.exe");
                System.Globalization.CultureInfo cultur = System.Globalization.CultureInfo.CurrentCulture;
                System.Globalization.NumberFormatInfo nInfo = (System.Globalization.NumberFormatInfo)cultur.NumberFormat.Clone();
                nInfo.NumberGroupSeparator = "";
                SubForms.TerminalForm terminalF = new SubForms.TerminalForm(Convert.ToInt32(Convert.ToDouble(beginSum)).ToString());
                terminalF.tbxSumma.Text = tbxBeginSum.Text;
                terminalF.keypad.tbxMain.Text = Convert.ToInt32(Convert.ToDouble(tbxBeginSum.Text)).ToString();
                if (terminalF.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    terminalSum = terminalF.sum != "" ? Convert.ToInt32(terminalF.sum) : 0;
                    this.DialogResult = DialogResult.OK;
                    this.Close();

                    //btnOplata_Click(btnOplata, new EventArgs());



                }
                
            }

        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();

        }
    }
}
