using System;
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
            int newAge;
            char newGender, newCooking, newNatural, newScience, newReading;

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
            newName = Console.ReadLine();
            Console.WriteLine("Please enter your age\n");
            newAge = Console.Read();
            Console.WriteLine("Please specifer your gender. Enter F for female, M for male or O for others\n");
            newGender = Console.ReadKey().KeyChar;
            Console.WriteLine('\n');
            Console.WriteLine("Please answer the following questions by entering Y for yes or N for no.\n");
            Console.WriteLine("Do you like cooking?\n");
            newCooking = Console.ReadKey().KeyChar;
            Console.WriteLine('\n');
            Console.WriteLine("Do you like science?\n");
            newScience = Console.ReadKey().KeyChar;
            Console.WriteLine('\n');
            Console.WriteLine("Do you enjoy natural?\n");
            newNatural = Console.ReadKey().KeyChar;
            Console.WriteLine('\n');
            Console.WriteLine("Do you like reading?\n");
            newReading = Console.ReadKey().KeyChar;
            Console.WriteLine('\n');

            //showing matching results

            //shut down console
            Console.WriteLine("Press any key to stop.\n");
            Console.ReadKey();
        }
       
    }
}
