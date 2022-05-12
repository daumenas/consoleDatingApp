using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void ValidateNameTestPass1()
        {
            string test = "name";
            Assert.AreEqual('y', ValidateString(test));
        }

        [TestMethod]
        public void ValidateNameTestPass2()
        {
            string test = "john";
            Assert.AreEqual('y', ValidateString(test));
        }

        [TestMethod]
        public void ValidateNameTestPass3()
        {
            string test = "young";
            Assert.AreEqual('y', ValidateString(test));
        }

        [TestMethod]
        public void ValidateNameTestPass4()
        {
            string test = "kim";
            Assert.AreEqual('y', ValidateString(test));
        }

        [TestMethod]
        public void ValidateNameTestFail1()
        {
            string test = "Yahoo1";
            Assert.AreEqual('n', ValidateString(test));
        }

        [TestMethod]
        public void ValidateNameTestFail2()
        {
            string test = "jordy455555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555";
            Assert.AreEqual('n', ValidateString(test));
        }

        [TestMethod]
        public void ValidateNameTestFail3()
        {
            string test = "12999(";
            Assert.AreEqual('n', ValidateString(test));
        }

        [TestMethod]
        public void ValidateNameTestFail4()
        {
            string test = "call//";
            Assert.AreEqual('n', ValidateString(test));
        }

        public static char ValidateString(string string1)
        {
            List<string> invalidChars = new List<string>() { "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-" };
            // Check for length
            if (string1.Length > 30)
            {
                Console.WriteLine("String too Long");
                return 'n';
            }
            else
            {
                //Iterate your list of invalids and check if input has one
                if (!Regex.IsMatch(string1, @"^[\p{L}]+$"))
                {
                    return 'n';
                }

                return 'y';
            }
        }
    }
}
