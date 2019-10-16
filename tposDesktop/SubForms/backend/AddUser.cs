using Classes.DB;
using Classes.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tposDesktop
{
    public partial class AddUser : DesignedForm
    {
        bool isAdd = true;
        DataSetTpos.userRow uRow;
        public AddUser()
        {
            isAdd = true;
            InitializeComponent();
        }

        public AddUser(DataSetTpos.userRow userRow)
        {
            uRow = userRow;
            isAdd = false;
            InitializeComponent();
            if(!isAdd)
            {
                lblCaption.Text = "Редактировать";
                btnAdd.Text = "Изменить";
                btnPass.Visible = true;
                lblPass.Visible = false;
                lblRepass.Visible = false;
                tbxPass.Visible = false;
                tbxRepass.Visible = false;
            }
            tbxName.Text = userRow.username;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbxName.Text))
            {

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                DataSetTposTableAdapters.userTableAdapter daUser = new DataSetTposTableAdapters.userTableAdapter();
                if (isAdd)
                {
                    DataSetTpos.userRow uRowN = DBclass.DS.user.NewuserRow();
                    uRowN.username = tbxName.Text;
                    uRowN.password = CalculateMD5Hash(CalculateMD5Hash(tbxPass.Text));
                    uRowN.role = "user";
                    DBclass.DS.user.AdduserRow(uRowN);
                    daUser.Update(uRowN);

                    daUser.Fill(DBclass.DS.user);


                }
                else
                {
                    uRow.username = tbxName.Text;
                    daUser.Update(uRow);
                }



            }
        }

        public string CalculateMD5Hash(string input)
        {

            // step 1, calculate MD5 hash from input

            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }

        private void btnPass_Click(object sender, EventArgs e)
        {
            userPass uPass = new userPass(uRow.IDUser);
            if (uPass.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
