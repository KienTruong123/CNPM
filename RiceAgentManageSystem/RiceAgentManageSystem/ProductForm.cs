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
    public partial class ProductForm : Form
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString);
        public ProductForm()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM PRODUCT", conn);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                gridP.DataSource = dt;
            }
            else
            {
                MessageBox.Show("No Data");
            }
            adapter.Dispose();
            //conn.Close();
        }
    }
}
