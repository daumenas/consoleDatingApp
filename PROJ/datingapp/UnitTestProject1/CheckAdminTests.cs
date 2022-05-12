using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class TestAdminPasswordInput
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void ValidateValidateAnswerTestPass1()
        {
            string test = "123";
            Assert.AreEqual(true, CheckAdminPassword(test));
        }

        [TestMethod]
        public void ValidateValidateAnswerTestFail2()
        {
            string test = "123,";
            Assert.AreEqual(false, CheckAdminPassword(test));
        }

        [TestMethod]
        public void ValidateValidateAnswerTestFail3()
        {
            string test = "1234";
            Assert.AreEqual(false, CheckAdminPassword(test));
        }

        [TestMethod]
        public void ValidateAdminpasswordFail()
        {
            string test = "213123";
            Assert.AreEqual(false, CheckAdminPassword(test));
        }

        public static bool CheckAdminPassword(string adminPassword)
        {
            if (adminPassword == "123") return true;
            else return false;

        }
    }
}
