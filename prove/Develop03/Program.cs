using System;
using System.Collections.Generic;
using System.Dynamic;

// References
// https://learn.microsoft.com/en-us/dotnet/csharp/how-to/parse-strings-using-split
// https://stackoverflow.com/questions/69424776/how-can-i-access-a-private-variable-in-another-class-in-c-sharp


// Console.Clear();

class Program
{
    public class Scripture
    {
        private string _reference = "";
        private string _text = "";
        private List<string> _words = new List<string>();
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
            //Construct Scripture List
            ConstructWordsList(_text);
            
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

        public void DisplayScripture()
        {
            Console.WriteLine(_reference);
            foreach (string word in _words)
            {
                Console.Write($"{word} ");
            }
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




    static void Main(string[] args)
    {
        // Initialize scripture list
        string fileName = "scripture_file.txt";
        List<Scripture> scriptureList = LoadScriptures(fileName);
        foreach (Scripture s in scriptureList)
        {
            s.DisplayScripture();
        }
    }
}