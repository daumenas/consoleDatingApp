using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class TestActionListInput
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void ValidatePass1()
        {
            string test = "List";
            Assert.AreEqual(true, CheckActionList(test));
        }

        public void ValidatePass2()
        {
            string test = "list";
            Assert.AreEqual(true, CheckActionList(test));
        }

        [TestMethod]
        public void ValidateFail()
        {
            string test = "LIST";
            Assert.AreEqual(false, CheckActionList(test));
        }

        [TestMethod]
        public void ValidateFail2()
        {
            string test = "L";
            Assert.AreEqual(false, CheckActionList(test));
        }

        [TestMethod]
        public void ValidateFail3()
        {
            string test = "LISTING";
            Assert.AreEqual(false, CheckActionList(test));
        }

        public static bool CheckActionList(string action)
        {
            if (action == "list" || action == "List") return true;
            else return false;

        }
    }
}
