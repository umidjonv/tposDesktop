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
namespace Classes
{
    public partial class OpenDay :DesignedForm
    {
        public OpenDay()
        {
            InitializeComponent();
        }
        public void OpenDayProcess()
        {
            DBclass db = new DBclass();
            db.OpenDay(this);
        }

        private void OpenDay_Load(object sender, EventArgs e)
        {
            OpenDayProcess();
        }
        private void CloseWindows(object sender, FormClosedEventArgs e)
        {

            if (tposDesktop.Program.backDate == true)
            {

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }
        
    }
}
