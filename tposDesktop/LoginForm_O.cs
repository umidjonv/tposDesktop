using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using Classes.DB;
using System.Windows.Forms;

namespace tposDesktop
{
    public partial class LoginForm_O : Form
    {
        
        public LoginForm_O()
        {
            InitializeComponent();
            int w = this.Size.Width;
            int h = this.Size.Height;
            label1.Location = new Point(w/2-175, label1.Location.Y);
            label2.Location = new Point(w / 2 - 175, label2.Location.Y);
            tbxLogin.Location = new Point(w / 2 - 175, tbxLogin.Location.Y);
            tbxPass.Location = new Point(w / 2 - 175, tbxPass.Location.Y);
            lblPassError.Location = new Point(w / 2 - 175, lblPassError.Location.Y);
            btnEnter.Location = new Point(w / 2 - 175, btnEnter.Location.Y);
            btn1.Location = new Point(w / 2 - 175, btn1.Location.Y);
            btn2.Location = new Point(w / 2 - 80, btn2.Location.Y);
            btn3.Location = new Point(w / 2 + 15, btn3.Location.Y);
            btn4.Location = new Point(w / 2 - 175, btn4.Location.Y);
            btn5.Location = new Point(w / 2 - 80, btn5.Location.Y);
            btn6.Location = new Point(w / 2 + 15, btn6.Location.Y);
            btn7.Location = new Point(w / 2 - 175, btn7.Location.Y);
            btn8.Location = new Point(w / 2 - 80, btn8.Location.Y);
            btn9.Location = new Point(w / 2 + 15, btn9.Location.Y);
            btn0.Location = new Point(w / 2 - 80, btn0.Location.Y);
            btnDel.Location = new Point(w / 2 + 15, btnDel.Location.Y);

            DBclass DB = new Classes.DB.DBclass(new string[] {"users"});
            tbxPass.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            lblPassError.Visible = false;
            DataTable table = DBclass.DS.Tables["users"];
            string hash = CalculateMD5Hash(tbxPass.Text);
            DataRow[] rows = table.Select("role=1");
            if (rows.Length != 0)
            {
                foreach (DataRow dr in rows)
                {
                    string pas = dr["password"].ToString();
                    if (pas == hash)
                    {
                        Program.window_type = 1;
                        UserValues.CurrentUserID = Convert.ToInt32(dr["employee_id"]);
                        UserValues.CurrentUser = dr["name"].ToString();
                        

                        Program.oldWindow_type = 3;
                        Program.onClose = true;
                        return;
                    }
                }
                

            }

            lblPassError.Visible = true;
            
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

        private void tbxPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void tbxPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(null, null);
 
            }

        }

        private void tbxPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_num(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            tbxPass.Text += btn.Text;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (tbxPass.Text.Length > 0)
            {
                tbxPass.Text = tbxPass.Text.Remove(tbxPass.Text.Length - 1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.onClose = true;
            Program.window_type = 0;
        }

    }
}
