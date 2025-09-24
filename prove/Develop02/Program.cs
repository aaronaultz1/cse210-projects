using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks.Dataflow;

class Program
{

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
                Console.WriteLine("__________________________________________________");
                // Display current entry within loop
                e.DisplayEntry();
            }
            // Close journal with last divider
            Console.WriteLine("__________________________________________________");
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
                "What was one thing that made you smile today?",
                "Out of all the emotions you felt today, which one did you feel the strongest?",
                "How did you draw closer to the Savior today?"
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



    static void Main(string[] args)
    {
        Journal journal = new Journal();
        // Ask user to input valid file name
        journal._fileName = journal.SetFileName();
        // Create an entry and add it to the jouranl
        journal.WriteEntryAndAddToJournal();
        // Display the journal contents
        journal.DisplayJournal();
    }
}