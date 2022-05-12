using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class TestFilterInput
    {
        [TestMethod]
        public void TestActionTestPass1()
        {
            string test = "gender";
            Assert.AreEqual("G", ValidateAnswer(test));
        }

        [TestMethod]
        public void TestActionTestPass2()
        {
            string test = "g";
            Assert.AreEqual("G", ValidateAnswer(test));
        }

        [TestMethod]
        public void TestActionTestPass3()
        {
            string test = "Gender";
            Assert.AreEqual("G", ValidateAnswer(test));
        }

        [TestMethod]
        public void TestActionTestPass4()
        {
            string test = "G";
            Assert.AreEqual("G", ValidateAnswer(test));
        }

        [TestMethod]
        public void TestActionTestPass5()
        {
            string test = "cooking";
            Assert.AreEqual("C", ValidateAnswer(test));
        }

        [TestMethod]
        public void TestActionTestPass6()
        {
            string test = "c";
            Assert.AreEqual("C", ValidateAnswer(test));
        }

        [TestMethod]
        public void TestActionTestPass7()
        {
            string test = "Cooking";
            Assert.AreEqual("C", ValidateAnswer(test));
        }

        [TestMethod]
        public void TestActionTestPass8()
        {
            string test = "C";
            Assert.AreEqual("C", ValidateAnswer(test));
        }
        [TestMethod]
        public void TestActionTestPass9()
        {
            string test = "natural";
            Assert.AreEqual("N", ValidateAnswer(test));
        }

        [TestMethod]
        public void TestActionTestPass10()
        {
            string test = "n";
            Assert.AreEqual("N", ValidateAnswer(test));
        }

        [TestMethod]
        public void TestActionTestPass11()
        {
            string test = "Natural";
            Assert.AreEqual("N", ValidateAnswer(test));
        }

        [TestMethod]
        public void TestActionTestPass12()
        {
            string test = "N";
            Assert.AreEqual("N", ValidateAnswer(test));
        }

        [TestMethod]
        public void TestActionTestPass13()
        {
            string test = "science";
            Assert.AreEqual("S", ValidateAnswer(test));
        }

        [TestMethod]
        public void TestActionTestPass14()
        {
            string test = "s";
            Assert.AreEqual("S", ValidateAnswer(test));
        }

        [TestMethod]
        public void TestActionTestPass15()
        {
            string test = "Science";
            Assert.AreEqual("S", ValidateAnswer(test));
        }

        [TestMethod]
        public void TestActionTestPass16()
        {
            string test = "S";
            Assert.AreEqual("S", ValidateAnswer(test));
        }

        [TestMethod]
        public void TestActionTestPass17()
        {
            string test = "reading";
            Assert.AreEqual("R", ValidateAnswer(test));
        }

        [TestMethod]
        public void TestActionTestPass18()
        {
            string test = "r";
            Assert.AreEqual("R", ValidateAnswer(test));
        }

        [TestMethod]
        public void TestActionTestPass19()
        {
            string test = "Reading";
            Assert.AreEqual("R", ValidateAnswer(test));
        }

        [TestMethod]
        public void TestActionTestPass20()
        {
            string test = "R";
            Assert.AreEqual("R", ValidateAnswer(test));
        }

        [TestMethod]
        public void ValidateValidateAnswerTestFail1()
        {
            string test = "123";
            Assert.AreEqual("Error", ValidateAnswer(test));
        }

        [TestMethod]
        public void ValidateValidateAnswerTestFail2()
        {
            string test = "nein";
            Assert.AreEqual("Error", ValidateAnswer(test));
        }

        [TestMethod]
        public void ValidateValidateAnswerTestFail3()
        {
            string test = "%%";
            Assert.AreEqual("Error", ValidateAnswer(test));
        }

        public static string ValidateAnswer(string cat)
        {
            if (cat == "gender" || cat == "g" || cat == "Gender" || cat == "G") return "G";
            else if (cat == "cooking" || cat == "c" || cat == "Cooking" || cat == "C") return "C";
            else if (cat == "natural" || cat == "n" || cat == "Natural" || cat == "N") return "N";
            else if (cat == "science" || cat == "s" || cat == "Science" || cat == "S") return "S";
            else if (cat == "reading" || cat == "r" || cat == "Reading" || cat == "R") return "R";
            else return "Error";
        }
    }
}
