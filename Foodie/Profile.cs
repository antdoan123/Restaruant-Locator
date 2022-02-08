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

namespace Foodie
{
    public partial class Profile : Form
    {
        public Profile()
        {
            InitializeComponent();
            txtUserUp.Text = frmLogin.username;
            txtPassUP.Text = frmLogin.password;
            pictureBox1.ImageLocation = image;
            /*con.Open();
            string login = "SELECT * FROM tbl_users WHERE username='" + txtUserUp.Text + "'and password= '" + txtPassUP.Text + "'";
            cmd = new OleDbCommand(login, con);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                image = dr.GetString(dr.GetOrdinal("profile"));
            }
            con.Close();*/
        }
        public static string image;

    private void txtUserUp_TextChanged(object sender, EventArgs e)
        {
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_users.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                con.Open();
                string login = "SELECT * FROM tbl_users WHERE username='" + txtUserUp.Text + "'and password= '" + txtPassUP.Text + "'";
                cmd = new OleDbCommand(login, con);
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read() == true)
                {
                    string picLoc = dlg.FileName.ToString();
                    pictureBox1.ImageLocation = picLoc;
                    image = picLoc;
                    string register = "Update[tbl_users] set [profile]= '"+picLoc+ "'WHERE username='" + txtUserUp + "'and password= '"+txtPassUP+"'";
                    cmd = new OleDbCommand(register, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                con.Close();

            }
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username, oldpassword, newpassword;
            username = txtUserUp.Text;
            oldpassword = txtPassUP.Text;
            newpassword = txtNewPass.Text;
            con.Open();
            string login = "SELECT * FROM tbl_users WHERE username='" + username + "'and password= '" + oldpassword + "'";
            cmd = new OleDbCommand(login, con);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read() == true)
            {
                login = "Update [tbl_users] set [password]= '" + newpassword + "' WHERE username='"+ username +"'";
                cmd = new OleDbCommand(login, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Password have been changed.", "Sucessfully Updated", MessageBoxButtons.OK);
                oldpassword = newpassword;
            }
            else
            {
                MessageBox.Show("Please enter the correct password.", "Please try again", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string username, oldpassword, newpassword;
            username = txtUserUp.Text;
            oldpassword = txtPassUP.Text;
            newpassword = txtNewPass.Text;
            con.Open();
            string login = "SELECT * FROM tbl_users WHERE username='" + username + "'and password= '" + oldpassword + "'";
            cmd = new OleDbCommand(login, con);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read() == true)
            {
                login = "Delete * FROM tbl_users WHERE username='" + username + "'and password= '" + oldpassword + "'";
                cmd = new OleDbCommand(login, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Account Has Been Deleted.", "Sucessfully Deleted", MessageBoxButtons.OK);
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Please enter the correct password.", "Please try again", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
    }
}
