using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgrammingCSharp
{
    internal class CheckNumber
    {
        public static void PrintEvenOdd(int limit, string choice)
        {
            if (limit < 0)
            {
                Console.WriteLine($" Print bilangan 1 - {limit} : ");
                Console.WriteLine(" Input limit tidak valid!!!");
                MainMenu.CheckNumberMenu();
            }

            List<int> numberList = new List<int>();

            if (choice.ToLower() == "odd")
            {
                for (int i = 1; i <= limit; i += 2)
                {
                    numberList.Add(i);
                }

                Console.WriteLine($" Print number 1 - {limit} : ");

                foreach (int i in numberList)
                {
                    Console.Write($"{i}, ");
                }

                MainMenu.CheckNumberMenu();
            }
            else if (choice.ToLower() == "even")
            {
                for (int i = 2; i <= limit; i += 2)
                {
                    numberList.Add(i);
                }

                Console.WriteLine($" Print number 1 - {limit} : ");

                foreach (int i in numberList)
                {
                    Console.Write($"{i}, ");
                }

                MainMenu.CheckNumberMenu();
            }
            else
            {
                Console.WriteLine(" Invalid input (please choose Odd or Even)!");
                MainMenu.CheckNumberMenu();
            }
        }

        public static string EvenOddCheck(int number)
        {
            if (number < 0)
            {
                Console.WriteLine(" Invalid input (numbers cannot be negative)!");
                MainMenu.CheckNumberMenu();
            }

            if (number % 2 == 1)
            {
                return " Odd";
            }
            else
            {
                return " Even";
            }
        }
    }
}
