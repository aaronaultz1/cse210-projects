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