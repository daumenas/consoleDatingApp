using System;
using System.Collections.Generic;
using System.IO;

namespace datingapp
{
    class Program
    {
        static void Main(string[] args)
        {
            //for fake data written in txt
            string[] names = new string[20];
            char[] gender=new char[20];
            int[] age = new int[20];
            char[] cooking = new char[20];
            char[] natural = new char[20];
            char[] science = new char[20];
            char[] reading = new char[20];

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
                names[counter] = data[0].ToString();
                age[counter] = int.Parse(data[1]);
                gender[counter] = data[2].ToCharArray()[0];
                cooking[counter] = data[3].ToCharArray()[0];
                natural[counter] = data[4].ToCharArray()[0];
                science[counter] = data[5].ToCharArray()[0];
                reading[counter] = data[6].ToCharArray()[0];
                counter++;
            }

            //asking new user information
            //To Dauma: I haven't done any data validation yet
            Console.WriteLine("Welcome to Dating App!\n");
            Console.WriteLine("Please enter your first name\n");
            while (ValidateString(newName = Console.ReadLine()) != 'y')
            {
                Console.WriteLine("Name contains illegal characters\n");
                Console.WriteLine("Please enter your first name\n");
            }
            //newName = Console.ReadLine();
            Console.WriteLine("Please enter your age\n");
            while (ValidateInteger(newAge = Console.ReadLine()) != 'y')
            {
                Console.WriteLine("Age contains illegal characters\n");
                Console.WriteLine("Please enter yourage\n");
            }
           
            Console.WriteLine("Please specifer your gender. Enter F for female, M for male or O for others\n");
            while (ValidateGender(newGender = Console.ReadLine()) != 'y')
            {
                Console.WriteLine("Gender contains illegal characters\n");
                Console.WriteLine("Please specifer your gender. Enter F for female, M for male or O for others\n");
            }
            Console.WriteLine('\n');
            Console.WriteLine("Please answer the following questions by entering Y for yes or N for no.\n");
            Console.WriteLine("Do you like cooking?\n");
            while (ValidateAnswer(newCooking = Console.ReadLine()) != 'y')
            {
                Console.WriteLine("Answer contains illegal characters\n");
                Console.WriteLine("Please answer the following questions by entering Y for yes or N for no.\n");
            }
            
            Console.WriteLine('\n');
            Console.WriteLine("Do you like science?\n");
            while (ValidateAnswer(newScience = Console.ReadLine()) != 'y')
            {
                Console.WriteLine("Answer contains illegal characters\n");
                Console.WriteLine("Please answer the following questions by entering Y for yes or N for no.\n");
            }
            Console.WriteLine('\n');
            Console.WriteLine("Do you enjoy nature?\n");
            while (ValidateAnswer(newNatural = Console.ReadLine()) != 'y')
            {
                Console.WriteLine("Answer contains illegal characters\n");
                Console.WriteLine("Please answer the following questions by entering Y for yes or N for no.\n");
            }
            Console.WriteLine('\n');
            Console.WriteLine("Do you like reading?\n");
            while (ValidateAnswer(newReading = Console.ReadLine()) != 'y')
            {
                Console.WriteLine("Answer contains illegal characters\n");
                Console.WriteLine("Please answer the following questions by entering Y for yes or N for no.\n");
            }
            Console.WriteLine('\n');
            string[] person = new string[7];
            person[0] = newName;
            person[1] = newAge;
            person[2] = newGender.ToString();
            person[3] = newCooking.ToString();
            person[4] = newScience.ToString();
            person[5] = newNatural.ToString();
            person[6] = newReading.ToString();

            FindSameInterests(person, names, age, gender, cooking, natural, science, reading);







            //showing matching results

            //shut down console
            Console.WriteLine("Press any key to stop.\n");
            Console.ReadKey();
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
            else if (!(!string1.Equals(string1.ToLower())))
            {
                //Check for min 1 uppercase
                Console.WriteLine("Requres at least one uppercase");
                return 'n';
            }
            else
            {
                //Iterate your list of invalids and check if input has one
                foreach (string s in invalidChars)
                {
                    if (string1.Contains(s))
                    {
                        Console.WriteLine("String contains invalid character: " + s);
                        return 'n';
                    }
                }

                return 'y';
            }
        }

        public static char ValidateInteger(string string1)
        {
            long number1 = 0;
            bool canConvert = long.TryParse(string1, out number1);
            if (canConvert && number1 > 19 && number1 < 30)
            {
                return 'y';
            } else
            {
                return 'n';
            }
        }

        public static char ValidateGender(string string1)
        {
            if (string1.Equals("f") || string1.Equals("F") || string1.Equals("m") || string1.Equals("M") || string1.Equals("o") || string1.Equals("O"))
            {
                return 'y';
            }
            else
            {
                return 'n';
            }
        }

        public static char ValidateAnswer(string string1)
        {
            if (string1.Equals("n") || string1.Equals("N") || string1.Equals("y") || string1.Equals("Y") || string1.Equals("Yes") || string1.Equals("No"))
            {
                return 'y';
            } else
            {
                return 'n';
            }
        }

        public static void FindSameInterests(string[] person, string[] name, int[] age, char[] gender, char[] cooking, char[] natural, char[] science, char[] reading)
        {
            for (int i = 0; i < cooking.Length; i++)
            {
                int numberOfSameInterests = 0;
                if (person[3] == cooking[i].ToString())
                {
                    numberOfSameInterests++;
                }
                if (person[4] == science[i].ToString())
                {
                    numberOfSameInterests++;
                }
                if (person[5] == natural[i].ToString())
                {
                    numberOfSameInterests++;
                }
                if (person[6] == reading[i].ToString())
                {
                    numberOfSameInterests++;
                }
                if (numberOfSameInterests >= 3)
                {
                    Console.WriteLine("People perfect for you");
                    Console.WriteLine('\n');
                    Console.WriteLine(name[i] + ' ' + age[i] + ' ' + gender[i] + ' ' + "\n");
                }
            }
        }

    }
}
