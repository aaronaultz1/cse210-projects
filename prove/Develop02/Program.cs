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
                outputFile.WriteLine(_fileName);

                foreach (Entry e in _entries)
                {
                    outputFile.WriteLine($"{e._date}|{e._prompt}|{e._response}");
                }

            }
            Console.WriteLine($"Journal saved succesfully under {_fileName}");
            Line();
        }

        public Journal LoadJournalFromFile()
        {
            //Get file name
            Console.WriteLine("""Please enter the name of the file that you would like to load, including the ".txt" """);
            Console.Write("> ");
            _fileName = Console.ReadLine();

            //Read File
            string[] fileLines = System.IO.File.ReadAllLines(_fileName);

            //Create new journal instance
            Journal journal = new Journal();

            // Update file name
            journal._fileName = fileLines[0];

            // Set loop factor
            int i = 0;

            foreach (string line in fileLines)
            {
                if (i == 0)
                {
                    i = 1;
                    continue; // Skip first line (file name)
                }
                else
                {
                    Entry entry = new Entry(); // Create new entry instance
                    string[] entryData = line.Split("|"); // Split entry data by divider

                    // Set variables within entry
                    entry._date = entryData[0];
                    entry._prompt = entryData[1];
                    entry._response = entryData[2];

                    // Add entry to journal
                    journal._entries.Add(entry);

                }


            }


            Console.WriteLine($"Journal loaded succesfully from {_fileName}");
            Line();
            return journal;
            
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

    static string DisplayMenu()
    {
        Console.Write("Please select one of the following choices\n1. Write\n2. Display\n3. Load\n4. Save\n5. Quit\nWhat would you like to do?\n> ");


        return Console.ReadLine();
    }

    static void Main(string[] args)
    {
        Journal journal = null; // Create empty journal instance
        bool isRunning = true;

        Console.WriteLine("Welcome to the Journal Program, written by Aaron Aultz");

        while (isRunning == true)
        {
            string userChoice = DisplayMenu();

            if (userChoice == "1") //Write
            {
                if (journal == null)
                {
                    journal = new Journal(); // Create new journal instance if it is the user's first entry
                }
                journal.WriteEntryAndAddToJournal();
                Line();
                
            }
            else if (userChoice == "2") //Display
            {
                journal.DisplayJournal();
                
            }
            else if (userChoice == "3") //Load
            {
                journal = journal.LoadJournalFromFile();
            
            }
            else if (userChoice == "4") //Save
            {
                journal.SaveJournalToFile();
                
            }
            else if (userChoice == "5") //Quit
            {
                Console.WriteLine("\n\nThanks for using the Journal Program today. Hope to see you soon!\n\n");
                isRunning = false;
            }
            else
            {
                Console.WriteLine("ERROR. Please enter a valid option.");
    
            }

        }


    }
}