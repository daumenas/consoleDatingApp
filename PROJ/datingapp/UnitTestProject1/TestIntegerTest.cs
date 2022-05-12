using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class TestIntegerInput
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void ValidateIntegerTestPass1()
        {
            string test = "20";
            Assert.AreEqual('y', ValidateInteger(test));
        }

        [TestMethod]
        public void ValidateIntegerTestPass2()
        {
            string test = "24";
            Assert.AreEqual('y', ValidateInteger(test));
        }

        [TestMethod]
        public void ValidateIntegerTestPass3()
        {
            string test = "25";
            Assert.AreEqual('y', ValidateInteger(test));
        }

        [TestMethod]
        public void ValidateIntegerTestPass4()
        {
            string test = "29";
            Assert.AreEqual('y', ValidateInteger(test));
        }

        [TestMethod]
        public void ValidateIntegerTestFail1()
        {
            string test = "Yahoo1";
            Assert.AreEqual('n', ValidateInteger(test));
        }

        [TestMethod]
        public void ValidateIntegerTestFail2()
        {
            string test = "19";
            Assert.AreEqual('n', ValidateInteger(test));
        }

        [TestMethod]
        public void ValidateIntegerTestFail3()
        {
            string test = "23r";
            Assert.AreEqual('n', ValidateInteger(test));
        }

        [TestMethod]
        public void ValidateIntegerTestFail4()
        {
            string test = "30";
            Assert.AreEqual('n', ValidateInteger(test));
        }

        public static char ValidateInteger(string string1)
        {
            long number1 = 0;
            bool canConvert = long.TryParse(string1, out number1);
            if (canConvert && number1 > 19 && number1 < 30)
            {
                return 'y';
            }
            else
            {
                return 'n';
            }
        }
    }
}
