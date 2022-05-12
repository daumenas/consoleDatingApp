using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class TestGenderTests
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void ValidatePass1()
        {
            string test = "f";
            Assert.AreEqual("F", CheckGender(test));
        }

        public void ValidatePass2()
        {
            string test = "F";
            Assert.AreEqual("F", CheckGender(test));
        }
        public void ValidatePass3()
        {
            string test = "m";
            Assert.AreEqual("M", CheckGender(test));
        }

        public void ValidatePass4()
        {
            string test = "M";
            Assert.AreEqual("M", CheckGender(test));
        }

        [TestMethod]
        public void ValidateOther()
        {
            string test = "asd";
            Assert.AreEqual("O", CheckGender(test));
        }

        [TestMethod]
        public void ValidateOther2()
        {
            string test = "other";
            Assert.AreEqual("O", CheckGender(test));
        }

        [TestMethod]
        public void ValidateOther3()
        {
            string test = "nope";
            Assert.AreEqual("O", CheckGender(test));
        }

        public static string CheckGender(string gender)
        {
            if (gender.Equals("f") || gender.Equals("F")) return "F";
            else if (gender.Equals("m") || gender.Equals("M")) return "M";
            else return "O";

        }
    }
}
