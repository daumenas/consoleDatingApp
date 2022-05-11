using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace datingapp
{
    class Program
    {
        static void Main(string[] args)
        {
            //for fake data written in txt
            string[] names = new string[20];
            char[] gender = new char[20];
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
                if (newName.Contains(" "))//contains more than one word
                {
                    Console.WriteLine("Name more than one word\n");
                }
                else
                {
                    Console.WriteLine("Name contains illegal characters\n");
                }
                
                Console.WriteLine("Please enter your first name\n");
            }

            if (newName == "admin")
            {
                Console.WriteLine("Welcome to admin mode\n");
                Console.WriteLine("Please enter the password\n");
                while (true)
                {
                    string adminPassword;
                    adminPassword = Console.ReadLine();
                    if(adminPassword == "123") break;
                    Console.WriteLine("Wrong password, please enter again\n");
                }
                Console.WriteLine("Successfully login\n");
                while (true)
                {
                    Console.WriteLine("Choose an action\n");
                    Console.WriteLine("list - to see all the users in the system\n" +
                    "fliter - to filter the users you want to see\n" + 
                    "exit - to exit admin mode");
                    string action = Console.ReadLine();
                    if (action == "list" || action == "List")
                    {
                        ShowAllUsers(names,age,gender,cooking,science,natural,reading);
                    }else if(action == "filter" || action == "Filter")
                    {
                        Console.WriteLine("Choose the category you want to filter (enter gender for g, cooking for c, natural for n, science for s, reading for r)\n");
                        string category = Console.ReadLine();
                        ShowFilter(category, names, age, gender, cooking, science, natural, reading);
                    }else if(action == "exit" || action == "Exit")
                    {
                        Console.Write("Successfully logout\n");
                        break;
                    }
                    else
                    {
                        Console.Write("Wrong action\n");
                    }
                }
                
            }
            else
            {
                Console.WriteLine("Please enter your age\n");
                while (ValidateInteger(newAge = Console.ReadLine()) != 'y')
                {
                    bool isIntString = newAge.All(char.IsDigit);
                    if (isIntString) //contains number
                    {
                        int intAge = int.Parse(newAge);
                        if ((intAge >= 0 && intAge <= 19) || (intAge > 29)) //check age 20~29
                        {
                            Console.WriteLine("This system is only designed for user age between 20~29.\n");
                        }
                    
                    }
                    else
                    {
                        Console.WriteLine("Age contains illegal characters\n");
                    }
                    Console.WriteLine("Please enter your age\n");
                }

                Console.WriteLine("Please specify your gender. Enter F for female, M for male or O for others\n");
                while (ValidateGender(newGender = Console.ReadLine()) != 'y')
                {
                    Console.WriteLine("Gender contains illegal characters\n");
                    Console.WriteLine("Please specify your gender. Enter F for female, M for male or O for others\n");
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

                FindSameInterests(person, names, age, gender, cooking, natural, science, reading); //showing matching results

            }//end admin else
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
            /*else if (!(!string1.Equals(string1.ToLower())))
            {
                //Check for min 1 uppercase
                Console.WriteLine("Requires at least one uppercase");
                return 'n';
            }*/
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
            }
            else
            {
                return 'n';
            }
        }

        public static void FindSameInterests(string[] person, string[] name, int[] age, char[] gender, char[] cooking, char[] natural, char[] science, char[] reading)
        {
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
        }

        public static void ShowAllUsers(string[] name, int[] age, char[] gender, char[] cooking, char[] natural, char[] science, char[] reading)
        {
            Console.WriteLine("Name\tAge\tGender\tCooking\tNatural\tScience\tReading\n");
            for (int i = 0; i < cooking.Length; i++)
            {
                if (name[i] == null) break;
                Console.WriteLine(name[i] + '\t' + age[i] + '\t' + gender[i] + '\t' + cooking[i] + '\t' + natural[i] + '\t' + science[i] + '\t' + reading[i] + '\t' + "\n");
            }
        }

        public static void ShowFilter(string cat, string[] name, int[] age, char[] gender, char[] cooking, char[] natural, char[] science, char[] reading)
        {
            if(cat == "gender" || cat == "g" || cat == "Gender" || cat == "G")
            {
                Console.WriteLine("Please specify the gender you want to filter. Enter F for female, M for male or O for others\n");
                string genderOption;
                while (ValidateGender(genderOption = Console.ReadLine()) != 'y')
                {
                    Console.WriteLine("Gender contains illegal characters\n");
                    Console.WriteLine("Please specify your gender you want to filter. Enter F for female, M for male or O for others\n");
                }
                if (genderOption.Equals("f") || genderOption.Equals("F"))
                {
                    Console.WriteLine("Name\tAge\tGender\tCooking\tNatural\tScience\tReading\n");
                    for (int i = 0; i < cooking.Length; i++)
                    {
                        if(gender[i].Equals('f') || gender[i].Equals('F'))
                        Console.WriteLine(name[i] + '\t' + age[i] + '\t' + gender[i] + '\t' + cooking[i] + '\t' + natural[i] + '\t' + science[i] + '\t' + reading[i] + '\t' + "\n");
                    }
                }else if (genderOption.Equals("m") || genderOption.Equals("M"))
                {
                    Console.WriteLine("Name\tAge\tGender\tCooking\tNatural\tScience\tReading\n");
                    for (int i = 0; i < cooking.Length; i++)
                    {
                        if (gender[i].Equals('m') || gender[i].Equals('M'))
                            Console.WriteLine(name[i] + '\t' + age[i] + '\t' + gender[i] + '\t' + cooking[i] + '\t' + natural[i] + '\t' + science[i] + '\t' + reading[i] + '\t' + "\n");
                    }
                }else if (genderOption.Equals("o") || genderOption.Equals("O"))
                {
                    Console.WriteLine("Name\tAge\tGender\tCooking\tNatural\tScience\tReading\n");
                    for (int i = 0; i < cooking.Length; i++)
                    {
                        if (gender[i].Equals('o') || gender[i].Equals('O'))
                            Console.WriteLine(name[i] + '\t' + age[i] + '\t' + gender[i] + '\t' + cooking[i] + '\t' + natural[i] + '\t' + science[i] + '\t' + reading[i] + '\t' + "\n");
                    }
                }
            }else if(cat == "cooking" || cat == "c" || cat == "Cooking" || cat == "C"){
                Console.WriteLine("Name\tAge\tGender\tCooking\tNatural\tScience\tReading\n");
                for (int i = 0; i < cooking.Length; i++)
                {
                    if (cooking[i].Equals('y') || cooking[i].Equals('Y'))
                        Console.WriteLine(name[i] + '\t' + age[i] + '\t' + gender[i] + '\t' + cooking[i] + '\t' + natural[i] + '\t' + science[i] + '\t' + reading[i] + '\t' + "\n");
                }
            }
            else if (cat == "natural" || cat == "n" || cat == "Natural" || cat == "N")
            {
                Console.WriteLine("Name\tAge\tGender\tCooking\tNatural\tScience\tReading\n");
                for (int i = 0; i < cooking.Length; i++)
                {
                    if (natural[i].Equals('y') || natural[i].Equals('Y'))
                        Console.WriteLine(name[i] + '\t' + age[i] + '\t' + gender[i] + '\t' + cooking[i] + '\t' + natural[i] + '\t' + science[i] + '\t' + reading[i] + '\t' + "\n");
                }

            }
            else if (cat == "science" || cat == "s" || cat == "Science" || cat == "S")
            {
                Console.WriteLine("Name\tAge\tGender\tCooking\tNatural\tScience\tReading\n");
                for (int i = 0; i < cooking.Length; i++)
                {
                    if (science[i].Equals('y') || science[i].Equals('Y'))
                        Console.WriteLine(name[i] + '\t' + age[i] + '\t' + gender[i] + '\t' + cooking[i] + '\t' + natural[i] + '\t' + science[i] + '\t' + reading[i] + '\t' + "\n");
                }

            }
            else if (cat == "reading" || cat == "r" || cat == "Reading" || cat == "R")
            {
                Console.WriteLine("Name\tAge\tGender\tCooking\tNatural\tScience\tReading\n");
                for (int i = 0; i < cooking.Length; i++)
                {
                    if (reading[i].Equals('y') || reading[i].Equals('Y'))
                        Console.WriteLine(name[i] + '\t' + age[i] + '\t' + gender[i] + '\t' + cooking[i] + '\t' + natural[i] + '\t' + science[i] + '\t' + reading[i] + '\t' + "\n");
                }
            }
            else
            {
                Console.WriteLine("Wrong filter category\n");
            }
        }
    }//end Class
}