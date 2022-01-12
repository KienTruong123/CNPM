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
    public partial class Import : Form
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString);

        //private int rowBillSelected = 0;
        public Import()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

            conn.Close();
            if(Session.SessionRole == 3)
            {
                AccountantForm f3 = new AccountantForm();
                this.Hide();
                f3.ShowDialog();
            }
            else if(Session.SessionRole == 1)
            {
                AdminForm f3 = new AdminForm();
                this.Hide();
                f3.ShowDialog();
            }
            this.Close();
        }

        private void gridBill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //LoadData();
        }

        private void gridDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Import_Load(object sender, EventArgs e)
        {
            conn.Open();
            LoadBill();
            SetEditingMode(false);
        }

        private void btnCreateBill_Click(object sender, EventArgs e)
        {
            ////conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO BILL(DATE_CREATED,TYPEID) VALUES (GETDATE(),1)", conn);

            int row = cmd.ExecuteNonQuery();
            if (row == 1)
            {
                MessageBox.Show("Add Successfully!");
                LoadBill();
            }

        }
        private void LoadData()
        {
            try
            {
                //////conn.Open();
                int index = gridBill.SelectedCells[0].RowIndex;
                if(index <0 || index >= gridBill.RowCount)
                {
                    MessageBox.Show("Please select a bill first");
                    return;
                }

                DataGridViewRow row = gridBill.Rows[index];
                int billID = int.Parse(row.Cells[0].Value.ToString());
                tbBID.Text = billID.ToString();

                SqlCommand cmd = new SqlCommand("SELECT PRODUCTID,PRICE,QUANTITY FROM BILL_PRODUCTS WHERE BILLID="+billID, conn);

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
        private void LoadBill()
        {
            //conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT BILLID,DATE_CREATED,TYPEID FROM BILL WHERE TYPEID=1", conn);

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
            ////conn.Close();
        }

        private void gridBill_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadData();
            clearDetail();
        }

        private void gridDetail_AllowUserToAddRowsChanged(object sender, EventArgs e)
        {

        }

        private void gridDetail_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //conn.Open();
            int oid = int.Parse(tbOrderID.Text.ToString());
            int price = int.Parse(tbPrice.Text.ToString());
            int quan = int.Parse(tbQuantity.Text.ToString());
            int bid = int.Parse(tbBID.Text.ToString());
            addBill(bid, oid, quan, price); 

            LoadData();
            clearDetail();
            SetEditingMode(false);

            
            //conn.Close();
        }

        public bool addBill(int bid, int pid, int quantity, int price)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO BILL_PRODUCTS(BILLID,PRODUCTID,PRICE,QUANTITY) VALUES (@bid,@oid,@pr,@q)", conn);
            SqlParameter p1 = new SqlParameter("@bid", bid);
            SqlParameter p2 = new SqlParameter("@oid", pid);
            SqlParameter p3 = new SqlParameter("@pr", price);
            SqlParameter p4 = new SqlParameter("@q", quantity);
            SqlParameter[] ps = { p1, p2, p3, p4 };
            cmd.Parameters.AddRange(ps);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            int rows = adapter.Fill(dt);
            conn.Close();
            dt.Dispose();
            return rows==0;
        }



        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int index = gridDetail.SelectedCells[0].RowIndex;
            DataGridViewRow row = gridDetail.Rows[index];
            int pid = int.Parse(row.Cells[0].Value.ToString());
            int quantity = int.Parse(tbQuantity.Text.ToString());
            int price = int.Parse(tbPrice.Text.ToString());
            int bid = int.Parse(tbBID.Text.ToString());
            updateBill(bid, pid, quantity, price);
            gridDetail.ClearSelection();
            LoadData();
            clearDetail();
            SetEditingMode(false);
        }

        public bool updateBill( int bid, int pid, int quantity, int price)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("update  BILL_PRODUCTS set QUANTITY=@q, PRICE=@p where BILLID=@bid AND PRODUCTID= @pid", conn);
            SqlParameter param1 = new SqlParameter("@q", quantity);
            SqlParameter param2 = new SqlParameter("@p", price);
            SqlParameter param4 = new SqlParameter("@pid", pid);
            SqlParameter param5 = new SqlParameter("@bid", bid);
            SqlParameter[] parameters = { param1, param2, param4, param5 }; // you may add more params
            cmd.Parameters.AddRange(parameters);
            int rows = cmd.ExecuteNonQuery();
            conn.Close();
            return rows == 1;
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridDetail.SelectedCells.Count == 0)
            {
                MessageBox.Show("Please select an item first");
                return;
            }
            int index = gridDetail.SelectedCells[0].RowIndex;
            if (index < 0 || index >= gridDetail.RowCount)
            {
                MessageBox.Show("Please select an item first");
                return;
            }
            //conn.Open();

            DataGridViewRow row = gridDetail.Rows[index];
            int pid = int.Parse(row.Cells[0].Value.ToString());
            String name = row.Cells[0].Value.ToString();


            DialogResult result = MessageBox.Show("Do you want to delete item:  " + name + "?", "Connection String", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
            {
                return;
            }

            int bid = int.Parse(tbBID.Text.ToString());
            if (DeleleById(bid, pid))
            {
                gridDetail.ClearSelection();
                LoadData();
                clearDetail();
                SetEditingMode(false);
            }
            else
            {
                MessageBox.Show("Delete Sucessfully!");
            }
            //conn.Close();
        }

        public bool DeleleById(int bid, int pid)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from BILL_PRODUCTS where BILLID = @bid AND PRODUCTID = @pid", conn);
            SqlParameter param1 = new SqlParameter("@bid", bid);
            SqlParameter param2 = new SqlParameter("@pid", pid);
            SqlParameter[] parameters = { param1, param2 };
            cmd.Parameters.AddRange(parameters);
            int rows = cmd.ExecuteNonQuery();
            conn.Close();

            return rows == 1;
        }

        private void gridDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index < 0 || index >= gridDetail.RowCount)
            {
                return;
            }

            DataGridViewRow row = gridDetail.Rows[index];
            int pid = int.Parse(row.Cells[0].Value.ToString());
            int price = int.Parse(row.Cells[1].Value.ToString());
            int quan = int.Parse(row.Cells[2].Value.ToString());

            // update UI
            tbOrderID.Text = pid.ToString();
            tbPrice.Text = price.ToString();
            tbQuantity.Text = quan.ToString();
            SetEditingMode(true);
        }
        private void clearDetail()
        {
            tbOrderID.Text = string.Empty;
            tbPrice.Text = string.Empty;
            tbQuantity.Text = string.Empty;
            SetEditingMode(false);
        }

        private void SetEditingMode(bool enable)
        {
            if (!enable)
            {
                gridDetail.ClearSelection();
            }
            btnAdd.Enabled = !enable;
            //btnClear.Enabled = true;
            btnDelete.Enabled = enable;
            btnUpdate.Enabled = enable;
        }

        private void btnViewProduct_Click(object sender, EventArgs e)
        {
            ProductForm f3 = new ProductForm();
            f3.ShowDialog();
        }
    }
}
