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
    public partial class DateSelectForm : DesignedForm 
    {
        public DateSelectForm(bool isTwoParam, bool isuser)
        {
            InitializeComponent();
            isUser = isuser;
            if (!isTwoParam)
            {
                isTwoParams = isTwoParam;
                dpEndDate.Visible = false;
                label2.Visible = false;
                if (isUser)
                {
                    lblKassir.Visible = true;
                    cbxCashier.Visible = true;
                    DataSetTposTableAdapters.userTableAdapter uda = new DataSetTposTableAdapters.userTableAdapter();
                    uda.Fill(DBclass.DS.user);
                    cbxCashier.DataSource = DBclass.DS.user;
                    cbxCashier.DisplayMember = "username";
                    cbxCashier.ValueMember = "IDUser";

                    cbxCashier.SelectedValue = (int)DBclass.DS.user.Rows[0]["IDUser"];
                }
            }
             

        }
        bool isUser = false;
        bool isTwoParams = true;
        public DateTime beginDate { get; set; }
        public DateTime endDate { get; set; }

        public int SelectCashier = 0;
        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (isUser)
            {
                SelectCashier = (int)cbxCashier.SelectedValue;
            }
            this.beginDate = dpBeginDate.Value;
            this.endDate = dpEndDate.Value;
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
