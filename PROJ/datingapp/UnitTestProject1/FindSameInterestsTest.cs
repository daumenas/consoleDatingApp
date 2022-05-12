using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace UnitTestProject1
{
    [TestClass]
    public class FindSameInterestsTests
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void ValidateSameInterestsTest1()
        {
            string[] person = new string[7];
            person[0] = "Name";
            person[1] = "29";
            person[2] = "M";
            person[3] = "y";
            person[4] = "y";
            person[5] = "y";
            person[6] = "y";
            Assert.AreEqual(11, FindSameInterests(person));

        }

        [TestMethod]
        public void ValidateSameInterestsTest2()
        {
            string[] person = new string[7];
            person[0] = "Name";
            person[1] = "29";
            person[2] = "M";
            person[3] = "n";
            person[4] = "y";
            person[5] = "y";
            person[6] = "y";

            Assert.AreEqual(12, FindSameInterests(person));
        }

        [TestMethod]
        public void ValidateSameInterestsTest3()
        {
            string[] person = new string[7];
            person[0] = "Name";
            person[1] = "29";
            person[2] = "M";
            person[3] = "n";
            person[4] = "n";
            person[5] = "y";
            person[6] = "y";

            Assert.AreEqual(11, FindSameInterests(person));
        }

        [TestMethod]
        public void ValidateSameInterestsTest4()
        {
            string[] person = new string[7];
            person[0] = "Name";
            person[1] = "29";
            person[2] = "M";
            person[3] = "n";
            person[4] = "n";
            person[5] = "n";
            person[6] = "y";

            Assert.AreEqual(10, FindSameInterests(person));
        }

        [TestMethod]
        public void ValidateSameInterestsTest5()
        {
            string[] person = new string[7];
            person[0] = "Name";
            person[1] = "29";
            person[2] = "M";
            person[3] = "n";
            person[4] = "n";
            person[5] = "n";
            person[6] = "n";

            Assert.AreEqual(10, FindSameInterests(person));
        }

        public static int FindSameInterests(string[] person)
        {
            string[] name = new string[50];
            char[] gender = new char[50];
            int[] age = new int[50];
            char[] cooking = new char[50];
            char[] natural = new char[50];
            char[] science = new char[50];
            char[] reading = new char[50];

            //for new user
            string newName;
            string newAge;
            string newGender, newCooking, newNatural, newScience, newReading;

            int counter = 0;

            var lines = File.ReadLines(@"userData.txt");
            foreach (var line in lines)
            {
                // Process line
                string[] data = line.Split('/');
                name[counter] = data[0].ToString();
                age[counter] = int.Parse(data[1]);
                gender[counter] = data[2].ToCharArray()[0];
                cooking[counter] = data[3].ToCharArray()[0];
                natural[counter] = data[4].ToCharArray()[0];
                science[counter] = data[5].ToCharArray()[0];
                reading[counter] = data[6].ToCharArray()[0];
                counter++;
            }

            int peopleMatched = 0;
            for (int i = 0; i < cooking.Length; i++)
            {
                int numberOfSameInterests = 0;
                if (person[3].ToLower() == cooking[i].ToString().ToLower())
                {
                    numberOfSameInterests++;
                }
                if (person[4].ToLower() == science[i].ToString().ToLower())
                {
                    numberOfSameInterests++;
                }
                if (person[5].ToLower() == natural[i].ToString().ToLower())
                {
                    numberOfSameInterests++;
                }
                if (person[6].ToLower() == reading[i].ToString().ToLower())
                {
                    numberOfSameInterests++;
                }
                if (numberOfSameInterests >= 3)
                {
                    Console.WriteLine("People perfect for you");
                    Console.WriteLine('\n');
                    Console.WriteLine(name[i] + ' ' + age[i] + ' ' + gender[i] + ' ' + "\n");
                    peopleMatched++;
                }
            }
            //cannot find any people matches for user
            if (peopleMatched == 0)
            {
                Console.WriteLine("Cannot find any people perfect for you");
                Console.WriteLine('\n');
            }

            return peopleMatched;
        }
    }
}
