using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RiceAgentManageSystem
{
    public partial class LoginForm : Form
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString);
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;
            if (username == null || password == null)
            {
                MessageBox.Show("Please fill in all information");
                clearData();
            }
            else
            {
                string uid = "";

                conn.Open();
                //SqlCommand cmd = new SqlCommand("select * from ACCOUNT where USERNAME = @user AND PASSWORD = @pass ", conn);
                SqlCommand cmd = new SqlCommand("select r.ROLEID from ACCOUNT a,ROLE_ACCOUNT r where a.USERNAME = @user AND a.PASSWORD = @pass " +
                 "AND a.USERNAME = r.USERNAME", conn);
                SqlParameter p1 = new SqlParameter("@user", username);
                SqlParameter p2 = new SqlParameter("@pass", password);
                SqlParameter[] ps = { p1, p2 };

                cmd.Parameters.AddRange(ps);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    uid = dt.Rows[0]["ROLEID"].ToString();

                    if (uid.Equals("1"))
                    {
                        Session.SessionRole = 1;
                        AdminForm f2 = new AdminForm();
                        this.Hide();
                        f2.ShowDialog();
                        this.Close();
                    }
                    else if(uid.Equals("3"))
                    {
                        Session.SessionRole = 3;
                        AccountantForm f3 = new AccountantForm();
                        this.Hide();
                        f3.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("You don't have permission to access this feature.");
                        clearData();
                    }

                }
                else
                {
                    MessageBox.Show("Invalid Username or Password. Please try again");
                    clearData();

                }
                conn.Close();
            }
        }

        private void clearData()
        {
            tbUsername.Text = "";
            tbPassword.Text = "";
        }
    }
}
