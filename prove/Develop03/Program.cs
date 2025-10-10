using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ExceptionServices;
using System.Threading;

// References
// https://learn.microsoft.com/en-us/dotnet/csharp/how-to/parse-strings-using-split
// https://stackoverflow.com/questions/69424776/how-can-i-access-a-private-variable-in-another-class-in-c-sharp
// https://stackoverflow.com/questions/44041476/how-to-filter-list-of-classes-by-property-name
// https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.firstordefault?view=net-9.0


// Console.Clear();



class Program
{
    static List<Scripture> LoadScriptures(string fileName)
    {
        List<Scripture> scriptureList = new List<Scripture>();
        string[] fileLines = System.IO.File.ReadAllLines(fileName);
        int i = 1;
        foreach (string line in fileLines)
        {
            Scripture scripture = new Scripture();
            string[] entryData = line.Split("|"); // Split scripture data, reference | text

            // Set variables 

            string reference = entryData[0];
            string text = entryData[1];
            int index = i;
            i = i + 1;
            scripture.CreateScripture(reference, text, index);
            scriptureList.Add(scripture);
        }
        return scriptureList;
    }


    static bool DisplayMenu(List<Scripture> scriptureList)
    {
        Console.Clear();
        Console.WriteLine("______SCRIPTURE MASTERY MENU______");
        Console.WriteLine("Please select which scripture you wish to master by entering the index number or type 'quit'");

        foreach (Scripture s in scriptureList)
        {
            s.DisplayScriptureSelection();
        }
        Console.Write("> ");

        // Get length of list
        int listLength = scriptureList.Count;

        // Start loop
        bool inputCheck = true;
        while (inputCheck == true)
        {
            string userInput = Console.ReadLine();
            if (userInput != "quit")
            {
                if (0 < int.Parse(userInput) && int.Parse(userInput) <= listLength)
                {
                    // Cycle through the scripture list to match the user selection integer with the scripture index
                    Scripture selectedScripture = scriptureList.FirstOrDefault(scripture => scripture.GetIndex() == int.Parse(userInput));

                    Challenger challenger = new Challenger();
                    challenger.GetScriptureChallenge(selectedScripture);
                    challenger.PlayChallenge(scriptureList);
                    return true;
                }
                else
                {
                    Console.WriteLine("ERROR. Please enter valid index.");
                    Thread.Sleep(2000);
                    return true;

                }


            }

            else
            {
                return false;
            }

        }
        return true;
    }


    static void Main(string[] args)
    {
        // Initialize scripture list
        string fileName = "scripture_file.txt";
        List<Scripture> scriptureList = LoadScriptures(fileName);
        bool runProgram = true;
        Console.Clear();
        Console.WriteLine("Welcome to Scripture Mastery, made by Aaron Aultz.\nPress any key to continue");
        Console.Write("> ");
        Console.ReadLine();
        // Initialize game loop
        while (runProgram == true)
        {
            runProgram = DisplayMenu(scriptureList);
        }
        

        
    }
}