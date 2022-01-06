using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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

            gridBill.DataSource = dt;
            adapter.Dispose();
            LoadData();
        }

        private void Export_Load(object sender, EventArgs e)
        {
            conn.Open();
            LoadBill();
        }

        private void gridBill_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadData();
        }

        private void btnExportBill_Click(object sender, EventArgs e)
        {
            int index = gridDetail.SelectedCells[0].RowIndex;
            DataGridViewRow row = gridDetail.Rows[index];
            int bid = int.Parse(row.Cells[0].Value.ToString());


            //conn.Open();
            SqlCommand cmd = new SqlCommand("update  BILL set STATUS='Delivery' where BILLID=@bid", conn);

            SqlParameter param4 = new SqlParameter("@bid", bid);

            SqlParameter[] parameters = {param4 }; // you may add more params

            cmd.Parameters.AddRange(parameters);
            int rows = cmd.ExecuteNonQuery();

            gridDetail.ClearSelection();
            writeFile(bid);
            MessageBox.Show("Bill has been exported through csv file");
            LoadBill();
        }

        private void writeFile(int bid)
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand(
                    "Select * from BILL_PRODUCTS WHERE BILLID=" + bid, conn);
                SqlDataReader reader = sqlCmd.ExecuteReader();

                string fileName = "EXPORT_BILL.csv";
                StreamWriter sw = new StreamWriter(fileName);
                object[] output = new object[reader.FieldCount];

                for (int i = 0; i < reader.FieldCount; i++)
                    output[i] = reader.GetName(i);

                sw.WriteLine(string.Join(",", output));

                while (reader.Read())
                {
                    reader.GetValues(output);
                    sw.WriteLine(string.Join(",", output));
                }

                sw.Close();
                reader.Close();
            }
            catch(IOException ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void btnClosed_Click(object sender, EventArgs e)
        {

            int index = gridDetail.SelectedCells[0].RowIndex;
            DataGridViewRow row = gridDetail.Rows[index];
            int bid = int.Parse(row.Cells[0].Value.ToString());


            //conn.Open();
            SqlCommand cmd = new SqlCommand("update  BILL set STATUS='Complete', DATE_CLOSED= GETDATE() where BILLID=@bid", conn);

            SqlParameter param4 = new SqlParameter("@bid", bid);

            SqlParameter[] parameters = { param4 }; // you may add more params

            cmd.Parameters.AddRange(parameters);
            int rows = cmd.ExecuteNonQuery();

            gridDetail.ClearSelection();
            LoadBill();
        }
    }
}
