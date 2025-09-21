using System;
using System.Data.SqlTypes;

class Program
{
    static void Main(string[] args)
    {
        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the program!");
        }


        static string PromptUserName()
        {
            Console.WriteLine("Please enter your name: ");
            return Console.ReadLine();
        }

        static int PromptUserNumber()
        {
            Console.WriteLine("Please enter your favorite number: ");
            int userNumber = int.Parse(Console.ReadLine());
            return userNumber;
        }

        static void PromptUserBirthYear(out int userBirth)
        {
            Console.WriteLine("Please enter the year you were born: ");
            userBirth = int.Parse(Console.ReadLine());
            
        }


        static int SquareNumber(int userNumber)
        {
            return userNumber * userNumber;
        }


        static void DisplayResult(string userName, int userBirth, int square)
        {
            int userAge = 2025 - userBirth; 
            Console.WriteLine($"{userName},\nThe square of your number is {square}\nYou will turn {userAge} this year.");
        }


        static void Main()
        {
            DisplayWelcome();
            string userName = PromptUserName();
            int userNumber = PromptUserNumber();
            int userBirth;
            PromptUserBirthYear(out userBirth);
            int square = SquareNumber(userNumber);
            DisplayResult(userName, userBirth, square);
        }

        Main();
    }
}