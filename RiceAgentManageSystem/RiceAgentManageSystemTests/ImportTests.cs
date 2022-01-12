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
    public class ImportTests
    {

        [TestMethod()]
        [DataRow(1, 3,275000,25)]
        public void addBillTest(int bid, int pid, int quantity, int price)
        {
            Import importTests = new Import();
            importTests.addBill(bid, pid,quantity,price);
        }

        [DataTestMethod()]
        [DataRow(1, 3, true)]
        [DataRow(1, 4, false)]
        public void DeleleByIdTest(int bid, int pid, bool expected)
        {
            Import importTests = new Import();
            bool results = importTests.DeleleById(bid, pid);
            Assert.AreEqual(expected, results);
        }

        [TestMethod()]
        [DataRow(1, 2, 10, 100000, true)]
        [DataRow(1, 2, 10, 200000, true)]
        public void updateBillTest(int bid, int pid, int quantity, int price, bool expected)
        {
            Import importTests = new Import();
            bool result = importTests.updateBill(bid, pid, quantity, price);
            Assert.AreEqual(expected, result);
        }

      
    }
}