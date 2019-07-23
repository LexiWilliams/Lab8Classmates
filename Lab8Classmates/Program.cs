using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8Classmates
{
    class Program
    {
        static void Main(string[] args)
        {
            bool runAgain = true;
            while (runAgain)
            {
                string[] nameArray = { "Bob", "Billy", "Kay", "Joe", "Ellie", "Benji" };
                string[] hometownArray = { "Nashville", "Houston", "Boston", "Sacramento", "Columbus", "Olympia" };
                string[] favoriteFoodArray = { "pizza", "tacos", "sushi", "pb&j", "spaghetti", "ice cream" };
                string[] petType = { "1 dog", "3 dogs", "1 cat", "no pets", "7 parakeets", "2 bunnies" };

                int studentNumber = GetNumber("Welcome to the July 2019 C# class. Which student would you like to learn about? Enter Name or a number 1-6.", nameArray);
                try
                {
                    int infoType = GetInfoType($"What would you like to know about {nameArray[studentNumber]}? Enter hometown, favorite food, or pets.", studentNumber);
                    PrintInfo(infoType, studentNumber, hometownArray, favoriteFoodArray, petType, nameArray);
                    runAgain = RunAgain("Would you like to ask about another student? y/n");
                }
                catch(IndexOutOfRangeException e)
                {
                    Console.WriteLine("You suck.");
                }
            }
        }


        public static int GetNumber(string message, string[] array1)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine();

            if (int.TryParse(input, out int number))
            {
                if (number - 1 >= 0 && number - 1 < array1.Length)
                {
                    int index = number - 1;
                    return index;
                }
                else
                {
                    Console.WriteLine("That input is not valid");
                    return GetNumber(message, array1);
                }
            }
            else
            {
                foreach (string name in array1)
                {
                    bool check = input.Contains(name);
                    if (check)
                    {
                        int nameLoation = Array.IndexOf(array1, input);
                        return nameLoation;
                    }
                }
                Console.WriteLine("That input is not valid.");
                return GetNumber(message, array1);
            }

        }

        public static int GetInfoType(string message, int number)
        {
            Console.WriteLine(message);
            string whatInfo = Console.ReadLine().ToLower();
            if (whatInfo == "hometown")
            {
                return 1;
            }
            else if (whatInfo == "favorite food")
            {
                return 2;
            }
            else if (whatInfo == "pets")
            {
                return 3;
            }
            else
            {
                Console.WriteLine("That isnt an option.");
                return GetInfoType(message, number);
            }




        }

        public static void PrintInfo(int number, int studentNumber, string[] array1, string[] array2, string[] array3, string[] array4)
        {
            if (number == 1)
            {
                Console.WriteLine($"{array4[studentNumber]}'s hometown is {array1[studentNumber]}.");
            }
            else if (number == 2)
            {
                Console.WriteLine($"{array4[studentNumber]}'s favorite food is {array2[studentNumber]}.");
            }
            else if (number == 3)
            {
                Console.WriteLine($"{array4[studentNumber]} has {array3[studentNumber]}.");
            }
        }

        public static bool RunAgain(string message)
        {
            Console.WriteLine(message);
            string yesNo = Console.ReadLine().ToLower();
            if (yesNo == "y")
            {
                return true;
            }
            if (yesNo == "n")
            {
                Console.WriteLine("Goodbye.");
                return false;
            }
            else
            {
                return RunAgain(message);
            }
        }
    }
}
