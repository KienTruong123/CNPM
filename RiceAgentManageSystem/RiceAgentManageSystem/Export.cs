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
    public partial class Export : Form
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString);

        public Export()
        {
            InitializeComponent();
        }

        private void gridBill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gridDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AccountantForm f3 = new AccountantForm();
            this.Hide();
            f3.ShowDialog();
            this.Close();
        }
        private void LoadData()
        {
            try
            {
                int index = gridBill.SelectedCells[0].RowIndex;
                if (index < 0 || index >= gridBill.RowCount)
                {
                    MessageBox.Show("Please select a bill first");
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
        private void LoadBill()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM BILL WHERE TYPEID=2 AND (STATUS LIKE 'Pending' OR STATUS LIKE 'Delivery')", conn);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                gridBill.DataSource = dt;
            }
            else
            {
                MessageBox.Show("No Data");
            }
            adapter.Dispose();
            LoadData();
        }

        private void Export_Load(object sender, EventArgs e)
        {
            LoadBill();
        }

        private void gridBill_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadData();
        }

        private void btnExportBill_Click(object sender, EventArgs e)
        {

        }
    }
}
