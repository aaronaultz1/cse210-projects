using System;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        string response;
        do
        {
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 100);
            string userGuess;
            int guessCount = 0;
            do
            {

                Console.Write("What is your guess? ");
                userGuess = Console.ReadLine();
                guessCount = 1 + guessCount;
                if (int.Parse(userGuess) > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else if (int.Parse(userGuess) < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else
                {
                    Console.WriteLine($"You guessed it!\nGuess Count: {guessCount}");

                }
            } while (int.Parse(userGuess) != magicNumber);
            Console.WriteLine("Do you want to play again? (y/n): ");
            response = Console.ReadLine();
        } while (response == "y");
        
        

    }
}