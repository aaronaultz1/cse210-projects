using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter grade percentage: ");
        string userInput = Console.ReadLine();

        int grade = int.Parse(userInput);
        string gradeLetter = "";
        if (grade >= 90)
        {
            gradeLetter = "A";
        }
        else if (grade >= 80)
        {
            gradeLetter = "B";
        }
        else if (grade >= 70)
        {
            gradeLetter = "C";
        }
        else if (grade >= 60)
        {
            gradeLetter = "D";
        }
        else if (grade < 60)
        {
            gradeLetter = "F";
        }

        if (grade >= 70)
        {
            Console.WriteLine($"Grade Letter: {gradeLetter} \nCongradulations! You passed the class.");
        }
        else
        {
            Console.WriteLine($"Grade Letter: {gradeLetter} \nYou can do better, silly!");
        }
    }
}
