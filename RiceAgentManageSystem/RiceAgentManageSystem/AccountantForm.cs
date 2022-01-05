using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RiceAgentManageSystem
{
    public partial class AccountantForm : Form
    {
        public AccountantForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            Import f3 = new Import();
            this.Hide();
            f3.ShowDialog();
            this.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Export f3 = new Export();
            this.Hide();
            f3.ShowDialog();
            this.Close();
        }

        private void btnStatistic_Click(object sender, EventArgs e)
        {
            Statistic f3 = new Statistic();
            this.Hide();
            f3.ShowDialog();
            this.Close();
        }
    }
}
