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
    public partial class FormSpisaniye : DesignedForm
    {
        public FormSpisaniye(int id)
        {
            
            InitializeComponent();
            DataView dvSpis = new DataView(DBclass.DS.ordersview);
            dvSpis.RowFilter = "productId = "+id+" and expType = 3";
            dgvSpisaniye.DataSource = dvSpis;
            
            
        }
        public int fakturaId;
        private void dgvFaktura_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void GetFakturaForm_Load(object sender, EventArgs e)
        {
            dgvSpisaniye.Columns["expenseId"].HeaderText = "№ фактуры";
            dgvSpisaniye.Columns["expenseId"].Visible = false;
            dgvSpisaniye.Columns["productId"].Visible = false;
            dgvSpisaniye.Columns["expType"].Visible = false;
            dgvSpisaniye.Columns["expenseDate"].HeaderText = "Дата";
            dgvSpisaniye.Columns["expenseDate"].Width = 120;
            dgvSpisaniye.Columns["comment"].HeaderText = "Комментарий";
            dgvSpisaniye.Columns["comment"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;



            dgvSpisaniye.Columns["name"].Visible = false;

            dgvSpisaniye.Columns["cnt"].HeaderText = "Кол-во";

            dgvSpisaniye.Columns["orderSumm"].Visible = false;
           
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            
        }

    }
}
