using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class TestActionFilterInput
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void ValidatePass1()
        {
            string test = "filter";
            Assert.AreEqual(true, CheckActionFilter(test));
        }

        public void ValidatePass2()
        {
            string test = "Filter";
            Assert.AreEqual(true, CheckActionFilter(test));
        }

        [TestMethod]
        public void ValidateFail()
        {
            string test = "FILTER";
            Assert.AreEqual(false, CheckActionFilter(test));
        }

        [TestMethod]
        public void ValidateFail2()
        {
            string test = "F";
            Assert.AreEqual(false, CheckActionFilter(test));
        }

        [TestMethod]
        public void ValidateFail3()
        {
            string test = "FILTERING";
            Assert.AreEqual(false, CheckActionFilter(test));
        }

        public static bool CheckActionFilter(string action)
        {
            if (action == "filter" || action == "Filter") return true;
            else return false;

        }
    }
}
