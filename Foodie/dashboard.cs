using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Runtime.InteropServices;

namespace Foodie
{
    public partial class dashboard : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (int nLeftRect,
            int nTopRect,
            int RightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
            );

        public dashboard()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }

        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_users.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            /*using (OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_users.mdb")) ;
            using (OleDbCommand Command = new OleDbCommand(" SELECT * from tbl_users where ", con))
            {
                con.Open();
                OleDbDataReader DB_Reader = Command.ExecuteReader();

                if (DB_Reader.HasRows)
                {
                    DB_Reader.Read();
                    labUser.Text = DB_Reader["username"].ToString();
                }
                con.Close();
            }
            */
            labUser.Text = frmLogin.username;
        }
        
        private void dashboard_Load(object sender, EventArgs e)
        {
            
        }

        private void labUser_Click(object sender, EventArgs e)
        {

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            openChild(new home());
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            var exit = MessageBox.Show("Are you sure you want to sign out?", "Application Exit", MessageBoxButtons.YesNo);
            if(exit == DialogResult.Yes)
            {
                new frmLogin().Show();
                this.Hide();
            }
        }

        private Form activeForm = null;
        private void openChild(Form child)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = child;
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Dock = DockStyle.Fill;
            panelChild.Controls.Add(child);
            panelChild.Tag = child;
            child.BringToFront();
            child.Show();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            openChild(new Profile());
        }

        private void btnFood_Click(object sender, EventArgs e)
        {
            openChild(new food());
        }
    }
}
