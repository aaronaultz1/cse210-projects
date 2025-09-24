using System;
using System.IO;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks.Dataflow;
using System.Collections.Generic;

class Program
{

    static void Line() //Adds a divider to keep everything easy to read and differentiate
    {
        Console.WriteLine("__________________________________________________\n");
    }


    public class Journal
    {
        public string _fileName = "Not Saved";
        public List<Entry> _entries = new List<Entry>();

        public void WriteEntryAndAddToJournal()
        {
            Entry entry = new Entry();
            entry.CreateEntry();
            _entries.Add(entry);
        }

        public string SetFileName()
        {
            Console.WriteLine("""Please enter a valid file name with no spaces, ending in ".txt" """);
            Console.Write("> ");
            return Console.ReadLine();
        }
        public void DisplayJournal()
        {
            Console.WriteLine($"Journal File Name: {_fileName}");
            foreach (Entry e in _entries)
            {
                // Create divider
                Line();
                // Display current entry within loop
                e.DisplayEntry();
            }
            // Close journal with last divider
            Line();
        }
        
        public void OutputLine(StreamWriter writer) //Create a line in the output file
        {
            writer.WriteLine("__________________________________________________\n");
        }
        public void SaveJournalToFile()
        {
            _fileName = SetFileName();

            using (StreamWriter outputFile = new StreamWriter(_fileName))
            {
                outputFile.WriteLine($"Journal File Name: {_fileName}");

                foreach (Entry e in _entries)
                {
                    OutputLine(outputFile);
                    e.OutputEntry(outputFile);
                }
                // Close output journal with last divider
                OutputLine(outputFile);
            }
            
        }
    }

    public class Entry
    {
        public string _date;
        public string _prompt;
        public string _response;

        public void CreateEntry()
        {
            _date = GetDate();
            _prompt = GetRandomPrompt();
            _response = GetResponse(_prompt);
        }

        public void DisplayEntry()
        {
            Console.WriteLine($"Date: {_date}");
            Console.WriteLine($"Prompt: {_prompt}");
            Console.WriteLine($"Response: {_response}");
        }
        public void OutputEntry(StreamWriter writer)
        {
            writer.WriteLine($"Date: {_date}");
            writer.WriteLine($"Prompt: {_prompt}");
            writer.WriteLine($"Response: {_response}");
        }
        public string GetDate()
        {
            //Set time
            DateTime theCurrentTime = DateTime.Now;
            //Set time to string variable
            string _dateText = theCurrentTime.ToShortDateString();


            return _dateText;
        }
        public string GetRandomPrompt()
        {
            List<string> _prompts = new List<string>
            {
                "Who was the most interesting person I interacted with today?",
                "What was the most difficult part of the day?",
                "What was one thing that made me smile today?",
                "Out of all the emotions I felt today, which one did I feel the strongest?",
                "How did I draw closer to the Savior today?",
                "What was the best part of my day?",
                "If I had one thing I could do over today, what would it be?"
            };

            Random random = new Random();

            string _prompt = _prompts[random.Next(_prompts.Count)];


            return _prompt;
        }


        public string GetResponse(string _prompt)
        {
            Console.WriteLine($"Prompt: {_prompt}");
            Console.Write("> ");


            return Console.ReadLine();
        }

        
    }
    

    public void LoadJournal()
    {
        Console.WriteLine("""Please enter the file name you wish to load, ending in ".txt" """);
        Console.Write("> ");
        string filename = Console.ReadLine();

        string[] lines = System.IO.File.ReadAllLines(filename);

        
    }

    static string DisplayMenu()
    {
        Console.Write("Please select one of the following choices\n1. Write\n2. Display\n3. Load\n4. Save\n5. Quit\nWhat would you like to do?\n> ");


        return Console.ReadLine();
    }

    static bool HandleMenu(string userChoice, Journal journal)
    {
        if (userChoice == "1") //Write
        {
            journal.WriteEntryAndAddToJournal();
            Line();
            return true;
        }
        else if (userChoice == "2") //Display
        {
            journal.DisplayJournal();
            return true;
        }
        else if (userChoice == "3") //Load
        {
            return true;
        }
        else if (userChoice == "4") //Save
        {
            journal.SaveJournalToFile();
            return true;
        }
        else if (userChoice == "5") //Quit
        {
            Console.WriteLine("\n\nThanks for using the Journal Program today. Hope to see you soon!");
            return false;
        }
        else
        {
            Console.WriteLine("ERROR. Please enter a valid option.");
            return true;
        }
    }
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool isRunning = true;

        Console.WriteLine("Welcome to the Journal Program, written by Aaron Aultz");

        while (isRunning == true)
        {
            string userChoice = DisplayMenu();

            isRunning = HandleMenu(userChoice, journal);

        }


    }
}