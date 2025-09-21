using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int number;
        List<int> numbers = new List<int>();
        do
        {
            Console.Write("Enter number: ");
            string userInput = Console.ReadLine();
            number = int.Parse(userInput);
            numbers.Add(number);
        } while (number != 0);

        // Calculate Sum
        int sum = 0;
        foreach (int n in numbers)
        {
            sum = n + sum;

        }
        // Calculate Average
        int avg = sum / numbers.Count;

        // Detect Largest number
        int largeNumber = 0;
        foreach (int n in numbers)
        {
            if (n > largeNumber)
            {
                largeNumber = n;
            }
        }

        // Print results
        Console.WriteLine($"The sum is: {sum}\nThe average is: {avg}\nThe largest number is: {largeNumber}");
    }
}