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
    public partial class StaffManage : Form
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString);
        public StaffManage()
        {
            InitializeComponent();
        }

        private void gridDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("INSERT INTO ACCOUNT VALUES (@u,@p) INSERT INTO ROLE_ACCOUNT VALUES (@u,3)  INSERT INTO STAFF VALUES (@u,@n,@ph)", conn);

            SqlParameter p1 = new SqlParameter("@u", tbSID.Text.ToString());
            SqlParameter p2 = new SqlParameter("@p", tbPass.Text.ToString());
            SqlParameter p3 = new SqlParameter("@n", tbName.Text.ToString());
            SqlParameter p4 = new SqlParameter("@ph", tbPhone.Text.ToString());
            SqlParameter[] ps = { p1, p2, p3, p4 };

            cmd.Parameters.AddRange(ps);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            LoadData();
            clearDetail();
            SetEditingMode(false);

            dt.Dispose();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int index = gridDetail.SelectedCells[0].RowIndex;
            DataGridViewRow row = gridDetail.Rows[index];
            string u = row.Cells[1].Value.ToString();


            //conn.Open();
            SqlCommand cmd = new SqlCommand("update STAFF set FULLNAME = @n, PHONE= @ph WHERE USERNAME = @u  update ACCOUNT set PASSWORD = @p WHERE USERNAME =@u", conn);

            SqlParameter p1 = new SqlParameter("@u", u);
            SqlParameter p2 = new SqlParameter("@p", tbPass.Text.ToString());
            SqlParameter p3 = new SqlParameter("@n", tbName.Text.ToString());
            SqlParameter p4 = new SqlParameter("@ph", tbPhone.Text.ToString());

            SqlParameter[] ps = { p1, p2, p3, p4 };

            cmd.Parameters.AddRange(ps);
            int rows = cmd.ExecuteNonQuery();

            gridDetail.ClearSelection();
            LoadData();
            clearDetail();
            SetEditingMode(false);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            conn.Close();
            if (Session.SessionRole == 3)
            {
                AccountantForm f3 = new AccountantForm();
                this.Hide();
                f3.ShowDialog();
            }
            else if (Session.SessionRole == 1)
            {
                AdminForm f3 = new AdminForm();
                this.Hide();
                f3.ShowDialog();
            }
            this.Close();
        }

        private void StaffManage_Load(object sender, EventArgs e)
        {
            conn.Open();
            LoadData();
        }

        private void gridDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow row = gridDetail.Rows[index];
            string u = row.Cells[1].Value.ToString();
            string p = row.Cells[2].Value.ToString();
            string f = row.Cells[3].Value.ToString();
            string h = row.Cells[4].Value.ToString();

            // update UI
            tbSID.Text = u;
            tbPass.Text = p;
            tbName.Text = f;
            tbPhone.Text = h;
            SetEditingMode(true);
        }

        private void LoadData()
        {
            try
            {

                SqlCommand cmd = new SqlCommand("SELECT s.STAFFID, s.USERNAME, a.PASSWORD, s.FULLNAME, s.PHONE FROM ACCOUNT a, STAFF s, ROLE_ACCOUNT r " +
                    "WHERE a.USERNAME = r.USERNAME AND a.USERNAME = s.USERNAME AND r.ROLEID=3", conn);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                gridDetail.DataSource = dt;

                adapter.Dispose();
                //conn.Close();
            }
            catch (Exception ex)
            {

            }
        }

        private void clearDetail()
        {
            tbName.Text = string.Empty;
            tbPass.Text = string.Empty;
            tbSID.Text = string.Empty;
            tbPhone.Text = string.Empty;
            SetEditingMode(false);
        }

        private void SetEditingMode(bool enable)
        {
            if (!enable)
            {
                gridDetail.ClearSelection();
            }
            btnAdd.Enabled = !enable;
            btnUpdate.Enabled = enable;
        }
    }
}
