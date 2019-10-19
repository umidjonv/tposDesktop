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
using tposDesktop.DataSetTposTableAdapters;


namespace tposDesktop
{
    public partial class ProdListDiscount : DesignedForm
    {

        DataSetTpos.productDataTable products;
        DataSetTpos.discountproductsDataTable discountpr;
        DataSetTpos.discountsDataTable discounts;

        DataSetTposTableAdapters.discountsTableAdapter discountDA;
        DataSetTposTableAdapters.discountproductsTableAdapter discountpDa;
        DataSetTposTableAdapters.v_discountTableAdapter vdisDa;

        public ProdListDiscount()
        {
            InitializeComponent();

            products = DBclass.DS.product;
            discountpDa = new discountproductsTableAdapter();
            discountpDa.Fill(DBclass.DS.discountproducts);

            discountDA = new discountsTableAdapter();
            discountDA.Fill(DBclass.DS.discounts);

            discountpr = DBclass.DS.discountproducts;
            discounts = DBclass.DS.discounts;

            DataView discount_view = new DataView(discounts);
            DataView discountpr_view = new DataView(discountpr);

            vdisDa = new v_discountTableAdapter();
            vdisDa.Fill(DBclass.DS.v_discount, -1);

            DataView dvDiscount = new DataView(DBclass.DS.v_discount);
            dgvDiscount.DataSource = dvDiscount;
            dvDiscount.RowFilter = "";

            DataView dvDiscounts = new DataView(DBclass.DS.discounts);
            dgvGroup.DataSource = dvDiscounts;
            discounts.TableNewRow += Discounts_TableNewRow;

        }

        private void Discounts_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            DataSetTpos.discountsRow disRow = e.Row as DataSetTpos.discountsRow;
            disRow.barcode = Classes.Generator.barcode_generate(8, 8);
            disRow.percent = 0;
        }

        private void tbx_ValueChanged(object sender, EventArgs e)
        {
            
                    
        }

        private void Form_Load(object sender, EventArgs e)
        {
            dgvGroup.Columns["discountId"].Visible = false;
            dgvGroup.Columns["discountName"].Width = 150;
            dgvGroup.Columns["percent"].Visible = false;
            dgvGroup.Columns["barcode"].Width = 150;
            dgvGroup.Columns["barcode"].ReadOnly = true;
            dgvGroup.Columns["discountName"].ReadOnly = true;
            
            dgvGroup.Columns["discountName"].HeaderText = "Имя скидки";
            dgvGroup.Columns["barcode"].HeaderText = "штрих";

            dgvDiscount.Columns["discountId"].Visible = false;
            dgvDiscount.Columns["discountproductId"].Visible = false;
            dgvDiscount.Columns["productId"].Width = 50;
            dgvDiscount.Columns["discount"].Width = 100;
            dgvDiscount.Columns["productId"].ReadOnly = true;
            dgvDiscount.Columns["name"].ReadOnly = true;
            dgvDiscount.Columns["productId"].HeaderText = "#";
            dgvDiscount.Columns["discount"].HeaderText = "Скидка";
            
            //dgvDiscount.Columns["discount"].DefaultCellStyle =

            dgvDiscount.Columns["name"].HeaderText = "Товар";
            dgvDiscount.Columns["name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DataGridViewButtonColumn cellBtnDel = new System.Windows.Forms.DataGridViewButtonColumn();
            cellBtnDel.HeaderText = "";
            cellBtnDel.Name = "colBtnDel";
            cellBtnDel.Width = 50;
            cellBtnDel.Visible = true;
            
            dgvGroup.Columns.Add(cellBtnDel);


            DataGridViewButtonColumn cellBtn = new System.Windows.Forms.DataGridViewButtonColumn();
            cellBtn.HeaderText = "";
            cellBtn.Name = "colBtn";
            cellBtn.Width = 50;
            cellBtn.Visible = true;
            dgvGroup.Columns.Add(cellBtn);

            //DataGridViewButtonColumn cellDisc = new System.Windows.Forms.DataGridViewButtonColumn();
            //cellDisc.HeaderText = "";
            //cellDisc.Name = "colDisc";
            //cellDisc.Width = 30;
            //cellDisc.Visible = true;
            //dgvDiscount.Columns.Add(cellDisc);

            dgvGroup.Columns["discountName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            if (discounts.Rows.Count > 0)
            {
                dgvGroup.Rows[0].Cells["discountName"].Selected = true;
                dgvGroup_CellClick(dgvGroup, new DataGridViewCellEventArgs(1, 0));

            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataSetTpos.discountsRow disRow = discounts.NewdiscountsRow();
            disRow.discountName = tbxDiscount.Text;
            disRow.barcode = Classes.Generator.barcode_generate(8, 8);
            disRow.percent = 0;
            discounts.AdddiscountsRow(disRow);
            discountDA.Update(disRow);
            
        }
        DataGridViewCell currentDiscountCell;
        DataSetTpos.discountsRow currentRow;
        private void dgvGroup_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currentDiscountCell = (sender as DataGridView).Rows[e.RowIndex].Cells["discountName"];
            currentRow = discounts.FindBydiscountId((int)(sender as DataGridView).Rows[e.RowIndex].Cells["discountId"].Value);
            tbxDiscount.Text = (sender as DataGridView).Rows[e.RowIndex].Cells["discountName"].Value.ToString();

            vdisDa.Fill(DBclass.DS.v_discount, currentRow.discountId);


            var dgv = sender as DataGridView;
            if (dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                switch (dgv.Name)
                {
                    case "dgvGroup":
                        switch (dgv.Columns[e.ColumnIndex].Name)
                        {
                            case "colBtn":
                                ProdList prodlist = new ProdList();
                                if (prodlist.ShowDialog() == DialogResult.OK)
                                {
                                    DataSetTpos.v_discountRow[] vDisRow = (DataSetTpos.v_discountRow[])DBclass.DS.v_discount.Select("productId" + prodlist.id);
                                    if (vDisRow.Length > 0 || vDisRow[0].discountId != currentRow.discountId)
                                    {
                                        DataSetTpos.discountproductsRow dpr = discountpr.NewdiscountproductsRow();
                                        dpr.discount = 0;
                                        dpr.productId = Convert.ToInt32(prodlist.id);
                                        dpr.discountId = currentRow.discountId;
                                        discountpr.AdddiscountproductsRow(dpr);
                                        discountpDa.Update(discountpr);

                                        vdisDa.Fill(DBclass.DS.v_discount, currentRow.discountId);
                                    }

                                }

                                break;
                            case "colBtnDel":
                                if (MessageBox.Show("Вы действительно хотите удалить группу скидок?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                                {
                                    discountpDa.DeleteDiscount(currentRow.discountId);
                                    currentRow.Delete();

                                    discountDA.Update(currentRow);

                                    if (discounts.Rows.Count > 0)
                                    {
                                        dgv.Rows[0].Cells["discountName"].Selected = true;
                                        dgvGroup_CellClick(dgv, new DataGridViewCellEventArgs(1, 0));

                                    }

                                }

                                break;

                        }

                        break;

                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //currentDiscountCell.Value = tbxDiscount.Text;
            currentRow.discountName = tbxDiscount.Text;

            discountDA.Update(currentRow);
        }

        private void dgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            var grid = sender as DataGridView;
            if (grid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                DataGridViewButtonCell dgvCell = (DataGridViewButtonCell)grid.Rows[e.RowIndex].Cells[e.ColumnIndex];
                switch (grid.Name)
                {
                    case "dgvGroup":
                        switch (grid.Columns[e.ColumnIndex].Name)
                        {
                            case "colBtn":
                                dgvCell.Value = "+";
                                break;
                            case "colBtnDel":
                                dgvCell.Value = "X";
                                break;
                            
                        }
                        break;
                    case "dgvDiscount":
                        switch (grid.Columns[e.ColumnIndex].Name)
                        {
                            case "colBtn":
                                dgvCell.Value = "+";
                                break;
                            case "colBtnDel":
                                dgvCell.Value = "X";
                                break;

                        }
                        break;
                    
                }





            }
        }

        private void dgvGroup_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnSaveDiscount_Click(object sender, EventArgs e)
        {

        }

        private void dgvGroup_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            
            //dgvGroup_CellContentClick(sender, e);
        }

        private void dgvDiscount_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataSetTpos.discountproductsRow dprRow = discountpr.FindBydiscountproductId((int)(sender as DataGridView).Rows[e.RowIndex].Cells["discountproductId"].Value);
            if (dprRow != null)
            {
                dprRow.discount = (int)(sender as DataGridView).Rows[e.RowIndex].Cells["discount"].Value;

                discountpDa.Update(dprRow);
            }
        }
    }
}
