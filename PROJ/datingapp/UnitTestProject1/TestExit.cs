using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class TestExitInput
    {
        [TestMethod]
        public void TestActionTestPass1()
        {
            string test = "exit";
            Assert.AreEqual(true, ValidateAnswer(test));
        }

        [TestMethod]
        public void TestActionTestPass2()
        {
            string test = "Exit";
            Assert.AreEqual(true, ValidateAnswer(test));
        }

        [TestMethod]
        public void ValidateValidateAnswerTestFail1()
        {
            string test = "yep";
            Assert.AreEqual(false, ValidateAnswer(test));
        }

        [TestMethod]
        public void ValidateValidateAnswerTestFail2()
        {
            string test = "nein";
            Assert.AreEqual(false, ValidateAnswer(test));
        }

        public static bool ValidateAnswer(string action)
        {
            if (action == "exit" || action == "Exit") return true;
            else return false;
        }
    }
}
