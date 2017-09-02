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
using tposDesktop.DataSetTposTableAdapters;

namespace tposDesktop
{
    public partial class passForm : DesignedForm
    {
        DBclass dbclass;
        public passForm()
        {
            InitializeComponent();
            dbclass = new DBclass();
            try
            {
                this.userTableAdapter1.Fill(DBclass.DS.user);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Нет подключения к Базе данных, " + ex.Message);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DataTable table = DBclass.DS.user;
            string hash = CalculateMD5Hash(CalculateMD5Hash(tbxOldPass.Text));
            DataRow[] rows = table.Select("username='" + UserValues.CurrentUser + "' and password='" + hash + "' and role='" + UserValues.role + "'");
            if (rows.Length != 0)
            {
                if (tbxNewPass.Text == tbxNewRePass.Text)
                {
                    DataSetTpos.userRow userRow = (DataSetTpos.userRow)rows[0];
                    userRow.password = CalculateMD5Hash(CalculateMD5Hash(tbxNewPass.Text));
                    userTableAdapter utba = new userTableAdapter();
                    utba.Update(userRow);
                    Program.window_type = 1;
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                    return;

                }
                else
                {
                    lblErr.Text = "Пароли несоответствуют.";
                    lblErr.Visible = true;
                }
            }
            else
            {
                lblErr.Text = "Пароль несоотвествует текущему.";
                lblErr.Visible = true;
            }
        }

        private void fa_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
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


    }
}
