using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using Classes;
using Classes.DB;
namespace tposDesktop
{
    public partial class FormLogin : Form
    {
        DBclass dbclass;
        Language lang;
        public FormLogin()
        {
            InitializeComponent();
            lang = Program.Lang;
            int w = this.Size.Width;
            int h = this.Size.Height;
            tbxLogin.Location = new Point(w / 2-tbxLogin.Width/2, tbxLogin.Location.Y);
            tbxPass.Location = new Point(w / 2 - tbxPass.Width / 2, tbxPass.Location.Y);
            btnLogin.Location = new Point(w / 2 - btnLogin.Width / 2, btnLogin.Location.Y);
            dbclass = new DBclass();
            dbclass.Fill("user");
            tbxLogin.Text = lang.Value("Login");
            tbxPass.Text = lang.Value("Pass");
            lblErr.Text = lang.Value("Err_Login");


        }

        public void LoadForm(object sender, EventArgs e)
        {
            
 
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

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            //lblPassError.Visible = false;
            DataTable table = DBclass.DS.Tables["user"];
            string hash = CalculateMD5Hash(CalculateMD5Hash(tbxPass.Text));
            DataRow[] rows = table.Select("password='" + hash+"'");
            if (rows.Length != 0)
            {
                foreach (DataRow dr in rows)
                {
                    string role = dr["role"].ToString();

                    Program.window_type = 2;
                    UserValues.CurrentUserID = Convert.ToInt32(dr["IDUser"]);
                    UserValues.CurrentUser = dr["username"].ToString();
                    UserValues.role = role;
                    //MessageBox.Show(UserValues.CurrentUser+":"+role);
                    
                    //Program.oldWindow_type = 3;
                    //Program.onClose = true;
                    this.Close();
                    return;

                }


            }
            else
            {
                lblErr.Visible = true;
                lblErr.Text = lang.Value("Err_Login");

            }

        }

        private void tbxEnter(object sender, EventArgs e)
        {
            lblErr.Visible = false;
            TextBox tbx = sender as TextBox;
            if (lang.Value("Login") == tbx.Text || lang.Value("Pass") == tbx.Text)
            {
                tbx.Text = "";
                tbx.ForeColor = Color.Black;
                if (lang.Value("Pass") == tbx.Text)
                {
                    tbx.PasswordChar = '0';
                }
            }
        }

        private void tbxLeave(object sender, EventArgs e)
        {
            
            TextBox tbx = sender as TextBox;
            if (tbx.Text == "")
            {
                if (tbx.Name == "tbxLogin")
                {
                    tbx.Text = lang.Value("Login");
                    
                }
                else if (tbx.Name == "tbxPass")
                {
                    tbx.Text = lang.Value("Pass");
                    
                }
                tbx.ForeColor = Color.Silver;
            }
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(Program.window_type!=2)
            Program.window_type = 0;
        }

        private void tbxPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                buttonLogin_Click(null, null);
            }
        }
    }
}
