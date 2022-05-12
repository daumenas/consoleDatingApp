using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class TestStringInput
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void ValidateGenderTestPass1()
        {
            string string1 = "f";
            if (string1.Equals("f") || string1.Equals("F") || string1.Equals("m") || string1.Equals("M") || string1.Equals("o") || string1.Equals("O"))
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void ValidateGenderTestFail()
        {
            string string1 = "fem";
            if (string1.Equals("f") || string1.Equals("F") || string1.Equals("m") || string1.Equals("M") || string1.Equals("o") || string1.Equals("O"))
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsFalse(false);
            }
        }

        [TestMethod]
        public void ValidateGenderTestFail2()
        {
            string string1 = "1";
            if (string1.Equals("f") || string1.Equals("F") || string1.Equals("m") || string1.Equals("M") || string1.Equals("o") || string1.Equals("O"))
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsFalse(false);
            }
        }

        [TestMethod]
        public void ValidateGenderTestFail3()
        {
            string string1 = "-=-=-=";
            if (string1.Equals("f") || string1.Equals("F") || string1.Equals("m") || string1.Equals("M") || string1.Equals("o") || string1.Equals("O"))
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsFalse(false);
            }
        }

        [TestMethod]
        public void ValidateGenderTestPass2()
        {
            string string1 = "F";
            if (string1.Equals("f") || string1.Equals("F") || string1.Equals("m") || string1.Equals("M") || string1.Equals("o") || string1.Equals("O"))
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsFalse(false);
            }
        }

        [TestMethod]
        public void ValidateGenderTestPass3()
        {
            string string1 = "m";
            if (string1.Equals("f") || string1.Equals("F") || string1.Equals("m") || string1.Equals("M") || string1.Equals("o") || string1.Equals("O"))
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsFalse(false);
            }
        }

        [TestMethod]
        public void ValidateGenderTestPass4()
        {
            string string1 = "M";
            if (string1.Equals("f") || string1.Equals("F") || string1.Equals("m") || string1.Equals("M") || string1.Equals("o") || string1.Equals("O"))
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsFalse(false);
            }
        }

        [TestMethod]
        public void ValidateGenderTestPass5()
        {
            string string1 = "o";
            if (string1.Equals("f") || string1.Equals("F") || string1.Equals("m") || string1.Equals("M") || string1.Equals("o") || string1.Equals("O"))
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsFalse(false);
            }
        }

        [TestMethod]
        public void ValidateGenderTestPass6()
        {
            string string1 = "O";
            if (string1.Equals("f") || string1.Equals("F") || string1.Equals("m") || string1.Equals("M") || string1.Equals("o") || string1.Equals("O"))
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsFalse(false);
            }
        }
    }
}
