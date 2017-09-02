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
using MySql;
using MySql.Data.MySqlClient;

namespace FirstConfig
{
    public partial class FormSettings : DesignedForm
    {
        public FormSettings()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(tbxServer.Text) && !string.IsNullOrEmpty(tbxDB.Text)) &&
                (!string.IsNullOrEmpty(tbxUser.Text) && !string.IsNullOrEmpty(tbxParol.Text)))
            {
                //
                string connection = "server="+tbxServer.Text+";user id="+tbxUser.Text+";database="+tbxDB.Text+";password="+tbxParol.Text+"";
                MySqlConnection con = new MySqlConnection(connection);
                try
                {
                    con.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //if()
                
            }
            else
            {
                MessageBox.Show("Поля не должны быть пустыми...","Инфо",  MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
