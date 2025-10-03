using System;
using System.Collections.Generic;
using System.Dynamic;

// References
// https://learn.microsoft.com/en-us/dotnet/csharp/how-to/parse-strings-using-split
// https://stackoverflow.com/questions/69424776/how-can-i-access-a-private-variable-in-another-class-in-c-sharp
// https://stackoverflow.com/questions/44041476/how-to-filter-list-of-classes-by-property-name
// https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.firstordefault?view=net-9.0


// Console.Clear();

class Program
{
    public class Challenger
    {
        // Unique class variable for which scripture will be challenged
        private Scripture challenger;

        // Set selected scripture class to a local variable
        public void GetScriptureChallenge(Scripture scripture)
        {
            Scripture challenger = scripture;
        }

        public void DisplayChallenge(Scripture challenger)
        {
            challenger.DisplayScripture();
        }
        public void PlayChallenge()
        {

        }

    }

    public class Words
    {
        private List<string> _words = new List<string>();
        private List<int> _visibleListReflection = new List<int>();

        public void CreateWords(string text)
        {
            ConstructWordsList(text); // update _words list
            ConstructListReflection(); // update _visibibleListReflection list

        }
        public void ConstructWordsList(string text)
        {

            // Parse and create list of words
            List<string> wordsArray = text.Split(' ').ToList();
            // Sycle through parsed list and add each word to the main _words list
            foreach (string word in wordsArray)
            {
                _words.Add(word);
            }

        }
        public void ConstructListReflection()
        {
            foreach (string w in _words)
            {
                _visibleListReflection.Add(0);
            }
        }

        public void UpdateWordsList()
        {
            foreach (int number in _visibleListReflection)
            {
                if (number == 1) // Erase word
                {
                    // set word according to index
                    string word = _words[number];
                    // Create Char array
                    char[] letters = word.ToCharArray();

                    for (int i = 0; i < letters.Length; i++)
                    {
                        if (letters[i] != ',' && letters[i] != '.' && letters[i] != ';' && letters[i] != '!' && letters[i] != '?' && letters[i] != '-') // Don't erase specified punctuation
                        {
                            letters[i] = '_'; // replace letter with underscore
                        }

                    }
                    _words[number] = new string(letters);
                }
            }
            
        }

        public void EraseWords()
        {
            int count = 0;
            int repeatCount = 5;

            do
            {
                Random random = new Random();
                int randomNumber = _visibleListReflection[random.Next(_visibleListReflection.Count)]; // Get random index from list   

                if (_visibleListReflection[randomNumber] == 0)
                {
                    _visibleListReflection[randomNumber] = 1; // mark invisible
                    count++; // Update count upon successful erase
                }
            } while (count < repeatCount);


        }
        public void DisplayWords()
        {
            foreach (string w in _words)
            {
                Console.Write(w);
            }
            Console.WriteLine("\n");

        }
    }

    public class Scripture
    {
        private string _reference = "";
        private string _text = "";
        
        private int _index;

        //private string _masteryLevel = "";   //"⭐" 

        public void CreateScripture(string reference, string text, int index)
        {
            // Set reference
            _reference = reference;
            // Set text
            _text = text;
            // Set index
            _index = index;

        }
        public int GetIndex()
        {
            return _index;
        }
        


        public void DisplayScriptureSelection()
        {
            Console.Write($"{_index}) ");
            Console.WriteLine(_reference);
        }
        public void DisplayScripture()
        {

            Console.Write($"{_index}) ");
            Console.WriteLine(_reference);
            Console.WriteLine(_text);
            Console.WriteLine("\n");
        }
    }

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
            scriptureList.Add(scripture);
            i = i + 1;
            scripture.CreateScripture(reference, text, index);
            scriptureList.Add(scripture);
        }
        return scriptureList;
    }

    static void DisplayMenu(string fileName)
    {
        Console.WriteLine("Please select which scripture you wish to master by entering the index number");
        List<Scripture> scriptureList = LoadScriptures(fileName);
        foreach (Scripture s in scriptureList)
        {
            s.DisplayScriptureSelection();
        }
        Console.Write("> ");

        // Get length of list
        int listLength = scriptureList.Count;

        // Start loop
        bool inputCheck = true;
        while (inputCheck)
        {
            string userInput = Console.ReadLine();
            int userSelection = int.Parse(userInput);
            if (0 < userSelection && userSelection <= listLength)
            {
                // Cycle through the scripture list to match the user selection integer with the scripture index
                Scripture selectedScripture = scriptureList.FirstOrDefault(scripture => scripture.GetIndex() == userSelection);
        
                Challenger challenger = new Challenger();
                challenger.GetScriptureChallenge(selectedScripture);
            }
        }

    }


    static void Main(string[] args)
    {
        // Initialize scripture list
        string fileName = "scripture_file.txt";
        DisplayMenu(fileName);
    }
}