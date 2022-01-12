using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiceAgentManageSystem;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiceAgentManageSystem.Tests
{
    [TestClass()]
    public class LoginFormTests
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString);

        public void insertSQLCOMMAND(string query)
        {
            try { conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                int row = cmd.ExecuteNonQuery();
            }
            catch { }         
            conn.Close();   
        }

        [DataTestMethod()]
        [DataRow("admin","123456",1)]
        [DataRow("demo","123456",2)]
        [DataRow("staff","123456",3)]
        [DataRow("' or ' = ''", "' or ' = ''", -1)]
        [DataRow("","",-1)]
        public void loginTest(string username, string password, int result)
        {
            LoginForm form = new LoginForm();
            int test_result = form.login(username, password);
            Assert.AreEqual(result, test_result);
        }
    }
}