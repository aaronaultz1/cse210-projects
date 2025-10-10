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