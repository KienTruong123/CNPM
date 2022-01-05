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
    public partial class Statistic : Form
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString);
        public Statistic()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            var fdate = dtFrom.Value.Date;
            var tdate = dtTo.Value.Date;

            LoadBill();
            LoadDataEP();
            LoadDataIP();
            calculateIP();
            calculateEP();
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
        private void LoadBill()
        {
            var fdate = dtFrom.Value.Date;
            var tdate = dtTo.Value.Date;

            SqlCommand cmd = new SqlCommand("SELECT * FROM BILL WHERE TYPEID=2 AND STATUS LIKE 'Complete' AND DATE_CLOSED IS NOT NULL AND DATE_CLOSED >= @f AND DATE_CLOSED <= @t", conn);
            SqlParameter p1 = new SqlParameter("@f", fdate);
            SqlParameter p2 = new SqlParameter("@t", tdate);
            SqlParameter[] ps = { p1, p2 };

            cmd.Parameters.AddRange(ps);

            //SqlCommand cmd = new SqlCommand("SELECT * FROM BILL WHERE TYPEID=2 AND STATUS LIKE 'Complete' AND DATE_CREATED >= '"+ dtFrom.Value.Date.ToString("yyyy-MM-dd") + "' AND (DATE_CLOSED IS NOT NULL OR DATE_CLOSED <= '"+ dtTo.Value.Date.ToString("yyyy-MM-dd") + "'", conn);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            gridEB.DataSource = dt;
            
            // GRID 2

            cmd = new SqlCommand("SELECT BILLID,DATE_CREATED,TYPEID FROM BILL WHERE TYPEID=1  AND DATE_CREATED >= @f AND DATE_CREATED <= @t", conn);
            SqlParameter p3 = new SqlParameter("@f", fdate);
            SqlParameter p4 = new SqlParameter("@t", tdate);
            SqlParameter[] ps1 = { p3, p4 };

            cmd.Parameters.AddRange(ps1);

            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);

            gridBill.DataSource = dt;

            adapter.Dispose();
            //LoadData();
        }
        private void LoadDataIP()
        {
            try
            {
                gridDetail.DataSource = null;
                int index = gridBill.SelectedCells[0].RowIndex;
                if (index < 0 || index >= gridBill.RowCount)
                {
                    gridBill.DataSource = null;
                    return;
                }

                DataGridViewRow row = gridBill.Rows[index];
                int billID = int.Parse(row.Cells[0].Value.ToString());

                SqlCommand cmd = new SqlCommand("SELECT * FROM BILL_PRODUCTS WHERE BILLID=" + billID, conn);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                gridDetail.DataSource = dt;

                adapter.Dispose();

            }
            catch (Exception ex)
            {

            }
        }

        private void LoadDataEP()
        {
            try
            {
                gridDEB.DataSource = null;
                int index = gridEB.SelectedCells[0].RowIndex;
                if (index < 0 || index >= gridEB.RowCount)
                {
                    gridEB.DataSource = null;
                    return;
                }

                DataGridViewRow row = gridEB.Rows[index];
                int billID = int.Parse(row.Cells[0].Value.ToString());

                SqlCommand cmd = new SqlCommand("SELECT * FROM BILL_PRODUCTS WHERE BILLID=" + billID, conn);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                gridDEB.DataSource = dt;

                adapter.Dispose();

            }
            catch (Exception ex)
            {

            }
        }

        private void Statistic_Load(object sender, EventArgs e)
        {
            conn.Open();
            LoadBill();

        }

        private void gridBill_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadDataIP();
        }

        private void gridEB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadDataEP();
        }
        private void calculateIP()
        {
            var fdate = dtFrom.Value.Date;
            var tdate = dtTo.Value.Date;

            SqlCommand cmd = new SqlCommand("SELECT ISNULL(SUM(b.PRICE*b.QUANTITY),0) AS TOTAL from BILL_PRODUCTS b, BILL b2 WHERE b2.TYPEID=1 AND b2.DATE_CREATED >= @f AND b2.DATE_CREATED <= @t AND b.BILLID = b2.BILLID", conn);
            SqlParameter p3 = new SqlParameter("@f", fdate);
            SqlParameter p4 = new SqlParameter("@t", tdate);
            SqlParameter[] ps1 = { p3,p4 };

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            cmd.Parameters.AddRange(ps1);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            
            if(dt.Rows.Count > 0)
            {
                lbInvest.Text = int.Parse(dt.Rows[0]["TOTAL"].ToString()).ToString("#,##0");
            }
            else
            {
                lbInvest.Text = "0";
            }
            
            adapter.Dispose();

        }
        private void calculateEP()
        {
            var fdate = dtFrom.Value.Date;
            var tdate = dtTo.Value.Date;

            SqlCommand cmd = new SqlCommand("SELECT ISNULL(SUM(b.PRICE*b.QUANTITY),0) AS TOTAL from BILL_PRODUCTS b, BILL b2 WHERE b2.TYPEID=2 AND b2.STATUS LIKE 'Complete' AND b2.DATE_CLOSED IS NOT NULL AND b2.DATE_CLOSED >= @f AND b2.DATE_CLOSED <= @t AND b.BILLID = b2.BILLID", conn);
            SqlParameter p3 = new SqlParameter("@f", fdate);
            SqlParameter p4 = new SqlParameter("@t", tdate);
            SqlParameter[] ps1 = { p3,p4 };

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            cmd.Parameters.AddRange(ps1);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                lbRevenue.Text = int.Parse(dt.Rows[0]["TOTAL"].ToString()).ToString("#,##0");
            }
            else
            {
                lbRevenue.Text = "0";
            }

            adapter.Dispose();

        }
    }
}
