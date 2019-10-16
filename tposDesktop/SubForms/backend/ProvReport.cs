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
using Classes.DB;

namespace tposDesktop
{
    public partial class ProvReport : DesignedForm
    {
        string beginDate;
        string endDate;
        string name;
        public ProvReport()
        {
            InitializeComponent();
            cbxProvider.DataSource = DBclass.DS.provider;
            cbxProvider.DisplayMember = "orgName";
            cbxProvider.ValueMember = "providerId";

            

        }
        MySql.Data.MySqlClient.MySqlDataAdapter da;
        DataTable table;
        bool initTable = false;
        private void ProvReport_Load(object sender, EventArgs e)
        {
            table = new DataTable();
            da = new MySql.Data.MySqlClient.MySqlDataAdapter();
            DataSetTposTableAdapters.productTableAdapter pda = new DataSetTposTableAdapters.productTableAdapter();

            beginDate = dtpBegin.Value.Date.ToString("YYYY-MM-dd");
            endDate = dtpEnd.Value.Date.ToString("YYYY-MM-dd");

            if (cbxProvider.Items.Count != 0)
            {
                cbxProvider.SelectedIndex = 0;
                da.SelectCommand = new MySql.Data.MySqlClient.MySqlCommand(GetQuery(beginDate, endDate, cbxProvider.SelectedValue.ToString()), pda.Connection);
                table.Clear();
                da.Fill(table);
            }
	
        }

        private void SetColumns()
        {
            dgvProvider.Columns["name"].HeaderText = "Товар";
            dgvProvider.Columns["fakturaDate"].HeaderText = "Дата фактуры";
            dgvProvider.Columns["orgName"].HeaderText = "Поставщик";
            dgvProvider.Columns["name"].Width = 200;
            dgvProvider.Columns["price"].HeaderText = "Цена фактуры";
            dgvProvider.Columns["soldPrice"].HeaderText = "Цена продажи";
            dgvProvider.Columns["endCount"].HeaderText = "Кол.";

            dgvProvider.Columns["providerId"].Visible = false;
            dgvProvider.Columns["realizeId"].Visible = false;
            dgvProvider.Columns["productId"].Visible = false;
            
        }

        private string GetQuery(string bDate, string eDate, string prov)
        {
            string query = "select f.fakturaId as №, f.fakturaDate, f.providerId, prv.orgName, r.realizeId, p.productId, p.name, r.price, r.soldPrice, r.count as endCount " +
                        "from faktura as f left join provider as prv on f.providerId = prv.providerId " +
                        "left join realize as r on f.fakturaId = r.fakturaId " +
                        "left join product as p on r.prodId = p.productId " +
                        "where prv.providerId = '"+prov+"' and (date(f.fakturaDate)>='"+bDate+"' and date(f.fakturaDate)<='"+eDate+"') and p.productId is not null";
            return query;
 
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (da != null&& cbxProvider.Items.Count!=0)
            {
                
                beginDate = dtpBegin.Value.Date.ToString("yyyy-MM-dd");
                endDate = dtpEnd.Value.Date.ToString("yyyy-MM-dd");
                da.SelectCommand.CommandText = GetQuery(beginDate, endDate, cbxProvider.SelectedValue.ToString());
                table.Clear();
                da.Fill(table);
                dgvProvider.DataSource = table;
                if (!initTable)
                {
                    SetColumns();
                    initTable = true;
                }

            }
        }
    }
}
