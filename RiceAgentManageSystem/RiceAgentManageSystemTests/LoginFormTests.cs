using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiceAgentManageSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiceAgentManageSystem.Tests
{
    [TestClass()]
    public class LoginFormTests
    {
        

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