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
    public partial class users : DesignedForm
    {
        public users()
        {
            InitializeComponent();
            this.userTableAdapter1.Fill(DBclass.DS.user);
            DataView dv = new DataView(DBclass.DS.user);
            dv.RowFilter = "role = 'user'";
            dgvUser.DataSource = dv;
        }

        private void users_Load(object sender, EventArgs e)
        {
            dgvUser.Columns["IDUser"].Visible = false;
            dgvUser.Columns["username"].HeaderText = "Имя пользователя";
            dgvUser.Columns["password"].Visible = false;
            dgvUser.Columns["role"].Visible = false;
            dgvUser.Columns["username"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridViewButtonColumn cellBtn = new System.Windows.Forms.DataGridViewButtonColumn();
            cellBtn.HeaderText = "";
            cellBtn.Name = "colBtn";
            cellBtn.Width = 100;
            dgvUser.Columns.Add(cellBtn);
            DataGridViewButtonColumn cellBtnDel = new System.Windows.Forms.DataGridViewButtonColumn();
            cellBtnDel.HeaderText = "";
            cellBtnDel.Name = "colBtnDel";
            cellBtnDel.Width = 70;
            dgvUser.Columns.Add(cellBtnDel);
        }

        private void dgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            var grid = sender as DataGridView;
            if (grid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                DataGridViewButtonCell dgvCell = (DataGridViewButtonCell)grid.Rows[e.RowIndex].Cells[e.ColumnIndex];
                
                switch (grid.Columns[e.ColumnIndex].Name)
                {
                    case "colBtn":
                        dgvCell.Value = "Изменить";
                        break;
                    case "colBtnDel":
                        dgvCell.Value = "X";
                        break;
                }


            }
        }

        private void dgvTovar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                DataRow[] dr = DBclass.DS.user.Select("IDUser = " + dgv.Rows[e.RowIndex].Cells["IDUser"].Value.ToString());
                if (dgv.Columns[e.ColumnIndex].Name == "colBtn")
                {
                    DataSetTpos.userRow uRow = (DataSetTpos.userRow)dr[0];
                    AddUser adU = new AddUser(uRow);
                    adU.ShowDialog();

                }
                else if (dgv.Columns[e.ColumnIndex].Name == "colBtnDel")
                {
                    if (MessageBox.Show("Удалить пользователя?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        dr[0].Delete();
                        this.userTableAdapter1.Update(DBclass.DS.user);
                        this.userTableAdapter1.Fill(DBclass.DS.user);
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddUser adU = new AddUser();
            adU.ShowDialog();
        }
    }
}
