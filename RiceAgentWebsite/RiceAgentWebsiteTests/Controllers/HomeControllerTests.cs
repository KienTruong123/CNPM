using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiceAgentWebsite.Controllers;
using RiceAgentWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RiceAgentWebsite.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerTests
    {
        [TestMethod()]
        [DataRow("admin","123456","Index")]
        public void IndexTest(string username, string password, string expected)
        {
            HomeController obj = new HomeController();
            ACCOUNT acc = new ACCOUNT
            {
                USERNAME = username,
                PASSWORD = password
            };
            var result =obj.Login(acc) as ViewResult;
            Assert.AreEqual(expected, result.ViewName);
        }
    }
}