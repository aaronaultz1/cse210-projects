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

    public class Challenger
    {
        // Unique class variable for which scripture will be challenged
        private Scripture _challenge = new Scripture();
        private int _challengeIndex;
        // Set selected scripture class to a local variable
        public void GetScriptureChallenge(Scripture scripture)
        {
            _challenge = scripture;
            _challengeIndex = scripture.GetIndex();
        }
        public void MasterScripture(List<Scripture> scriptureList)
        {
            foreach (Scripture s in scriptureList)
            {
                if (_challengeIndex == s.GetIndex()) // Find selected scripture
                {
                    s.MarkMastered();
                }
            }
        }
        public void DisplayChallenge()
        {
            _challenge.DisplayScripture();
        }
        
        public void PlayChallenge(List<Scripture> scriptureList)
        {
            Words challengeWords = _challenge.GetWords();


            Console.Clear();
            bool runChallenge = true;
            while (runChallenge == true)
            {
                // First check to see if all words are invisible. If true, end the challenge
                if (challengeWords.CheckListReflectionInvisible() == true)
                {
                    runChallenge = false;
                }
                Console.Clear();
                _challenge.DisplayScripture();
                Console.WriteLine("\nPress ENTER to continue or type 'quit' to return to Mastery Selection");
                Console.Write("> ");

                string userInput = Console.ReadLine();
                if (userInput == "quit")
                {
                    runChallenge = false;
                }
                else
                {
                    challengeWords.UpdateWordsList();
                }
            }
            Console.Clear();
            if (challengeWords.CheckListReflectionInvisible() == true) // If mastered
            {
                MasterScripture(scriptureList);
                Console.WriteLine($"Congradulations! You have mastered {_challenge.GetReference()}");
                Console.WriteLine("\n\nPress ENTER to return to Mastery Selection");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("\n\nReturning to Mastery Selection...");
                Thread.Sleep(2000);
            }

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

        public bool CheckListReflectionInvisible()
        {
            bool allWordsInvisible = true;
            foreach (int number in _visibleListReflection)
            {
                if (number == 0) // if the number is visible
                {
                    allWordsInvisible = false;
                }
            }
            return allWordsInvisible;
        }
        public void UpdateWordsList()
        {
            EraseWords(); // Set 5 words to invisible
            int index = 0;
            foreach (int number in _visibleListReflection)
            {

                if (number == 1) // Erase word
                {
                    // set word according to index
                    string word = _words[index];
                    // Create Char array
                    char[] letters = word.ToCharArray();

                    for (int i = 0; i < letters.Length; i++)
                    {
                        if (letters[i] != ':' && letters[i] != ',' && letters[i] != '.' && letters[i] != ';' && letters[i] != '!' && letters[i] != '?' && letters[i] != '-') // Don't erase specified punctuation
                        {
                            letters[i] = '_'; // replace letter with underscore
                        }

                    }
                    _words[index] = new string(letters);
                }
                index++; // update list index
            }

        }

        public void EraseWords() // Adjusts visibleListReflection
        {
            int count = 0;
            int repeatCount = 8; // Erase 8 random words
            int indexVisibleCount = 0; // Counts how many words are visible
            foreach (int n in _visibleListReflection)
            {
                if (n == 0)
                {
                    indexVisibleCount++;
                }
            }
            if (indexVisibleCount <= repeatCount) // If there are less or the same amount of numbers visible than there are numbers being turned invisble
            {
                for (int index = 0; index < _visibleListReflection.Count; index++) // Set remaining visible words to invisible
                {

                    if (_visibleListReflection[index] == 0)
                    {
                        _visibleListReflection[index] = 1;
                    }
                }
            }
            else // Randomly remove words as normal
            {
                do
                {
                    Random random = new Random();
                    int randomNumber = random.Next(_visibleListReflection.Count); // Get random index from list   

                    if (_visibleListReflection[randomNumber] == 0)
                    {
                        _visibleListReflection[randomNumber] = 1; // mark invisible
                        count++; // Update count upon successful erase
                    }
                } while (count < repeatCount);
            }
        }
        public void DisplayWords()
        {
            foreach (string w in _words)
            {
                Console.Write($"{w} ");
            }
            Console.WriteLine("\n");

        }
    }

    public class Scripture
    {
        private string _reference = "";
        private string _text = "";
        private int _index;        
        private Words _words = new Words();

        private string _masteryLevel = "UNMASTERED"; 

        public void MarkMastered()
        {
            _masteryLevel = "MASTERED";
        }
        public void CreateScripture(string reference, string text, int index)
        {
            // Set reference
            _reference = reference;
            // Set text
            _text = text;
            // Set index
            _index = index;
            // Loads scripture text into words class
            _words.CreateWords(_text);

        }
        public string GetReference()
        {
            return _reference;
        }
        public int GetIndex()
        {
            return _index;
        }
        public Words GetWords()
        {
            return _words;
        }

        public string GetMasteryLevel()
        {
            return _masteryLevel;
        }

        public void DisplayScriptureSelection()
        {
            Console.Write($"{_index}) ");
            Console.WriteLine($"{_reference} [{_masteryLevel}]");
        }
        public void DisplayScripture()
        {
            Console.WriteLine(_reference);
            _words.DisplayWords();
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
        Console.WriteLine("Please select which scripture you wish to master by \nentering the index number or type 'quit'");

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