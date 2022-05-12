using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class TestValidateAnswerInput
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void ValidateValidateAnswerTestPass1()
        {
            string test = "y";
            Assert.AreEqual('y', ValidateAnswer(test));
        }

        [TestMethod]
        public void ValidateValidateAnswerTestPass2()
        {
            string test = "Y";
            Assert.AreEqual('y', ValidateAnswer(test));
        }

        [TestMethod]
        public void ValidateValidateAnswerTestPass3()
        {
            string test = "no";
            Assert.AreEqual('y', ValidateAnswer(test));
        }

        [TestMethod]
        public void ValidateValidateAnswerTestPass4()
        {
            string test = "No";
            Assert.AreEqual('y', ValidateAnswer(test));
        }


        [TestMethod]
        public void ValidateValidateAnswerTestPass5()
        {
            string test = "n";
            Assert.AreEqual('y', ValidateAnswer(test));
        }


        [TestMethod]
        public void ValidateValidateAnswerTestPass6()
        {
            string test = "N";
            Assert.AreEqual('y', ValidateAnswer(test));
        }

        [TestMethod]
        public void ValidateValidateAnswerTestFail1()
        {
            string test = "yep";
            Assert.AreEqual('n', ValidateAnswer(test));
        }

        [TestMethod]
        public void ValidateValidateAnswerTestFail2()
        {
            string test = "nein";
            Assert.AreEqual('n', ValidateAnswer(test));
        }

        [TestMethod]
        public void ValidateValidateAnswerTestFail3()
        {
            string test = "Nooo";
            Assert.AreEqual('n', ValidateAnswer(test));
        }

        [TestMethod]
        public void ValidateValidateAnswerTestFail4()
        {
            string test = "YES";
            Assert.AreEqual('n', ValidateAnswer(test));
        }

        public static char ValidateAnswer(string string1)
        {
            if (string1.Equals("n") || string1.Equals("N") || string1.Equals("y") || string1.Equals("Y") || string1.Equals("Yes") || string1.Equals("No") || string1.Equals("yes") || string1.Equals("no"))
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
