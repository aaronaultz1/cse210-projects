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