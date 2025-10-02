using System;
using System.Collections.Generic;

// References
// https://learn.microsoft.com/en-us/dotnet/csharp/how-to/parse-strings-using-split
// https://stackoverflow.com/questions/69424776/how-can-i-access-a-private-variable-in-another-class-in-c-sharp




class Program
{
    public class Scripture
    {
        private string _reference = "";
        private List<string> _words = new List<string>();
        //private string _masteryLevel = "";   //"⭐" 

        public void DisplayScripture()
        {
            Console.WriteLine(_reference);
            foreach (string word in _words)
            {
                Console.Write($"{word} ");
            }
        }

        public void ConstructScripture(string reference, string text)
        {
            // Set reference
            _reference = reference;
            // Parse and create list of words
            List<string> wordsArray = text.Split(' ').ToList();
            // Sycle through parsed list and add each word to the main _words list
            foreach (string word in wordsArray)
            {
                _words.Add(word);
            }

        }


    }



    static void Main(string[] args)
    {
        Scripture test = new Scripture();
        test.ConstructScripture("John 3:16", "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");
        test.DisplayScripture();
    }
}