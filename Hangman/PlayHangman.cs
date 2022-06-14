using System.Text;
using Hangman.Interface;
using Hangman.ListOfWords;

namespace Hangman
{
    public class PlayHangman
    {
        public static string AppTitle = "Hangman";
        private static string WordToGuessUpper;
        private static StringBuilder WordToGuessDash = new StringBuilder();
        private static bool Won;
        private static int tries;
        private static string difficulty;
        private const int MAX_GUESSES = 10;

        public void StartGame()
        {
            int intLevel = ChooseLevel();

            Level levelEasy = Level.Easy;
            Level levelMedium = Level.Medium;
            Level levelHard = Level.Hard;

            if (intLevel == (int)levelEasy)
            {
                tries = 10;
                difficulty = levelEasy.ToString();
            }
            if (intLevel == (int)levelMedium)
            {
                tries = 7;
                difficulty = levelMedium.ToString();
            }
            if (intLevel == (int)levelHard)
            {
                tries = 5;
                difficulty = levelHard.ToString();
            }

            Console.WriteLine($"Difficulty level chosen: {difficulty}");
            Console.WriteLine($"You can make {tries} mistakes!");

            AddWord();

            GuessWord();

            if (Won)
            {
                WinnerText(intLevel);
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"You lost! Correct answer is: {WordToGuessUpper}");
                HangmanDisplay.Display(10);
            }

            Console.Write("Press enter to exit game...");
            Console.ReadLine();
        }

        private static int ChooseLevel()
        {
            Console.WriteLine("   --==Welcome to HANGMAN==--");
            Console.WriteLine("");
            Console.WriteLine("   SELECT A DIFFICULTY LEVEL");
            Console.WriteLine("   ---------------------------------");
            Console.WriteLine("    1. Easy");
            Console.WriteLine("    2. Medium");
            Console.WriteLine("    3. Hard");
            Console.WriteLine("   ---------------------------------");

            Console.Write("Enter Your Choice => ");
            string level = Console.ReadLine();
            int intLevel = int.Parse(level);
            Console.WriteLine("");
            return intLevel;
        }

        private static void AddWord()
        {

            string wordToGuess = ListOfWordsFromDatabase.GetRandomWordFromDb();        

            if (string.IsNullOrEmpty(wordToGuess))
            {
                Console.WriteLine("Guessing word is taken from file!");
                wordToGuess = ListOfWordsFromFile.GetWord();
            }                     
            //string wordToGuess = "KaKis";
            WordToGuessUpper = wordToGuess.ToUpper();

            for (int i = 0; i < wordToGuess.Length; i++)
            {
                WordToGuessDash.Append('-');
            }
        }

        private static void GuessWord()
        {
            string usedLetters = String.Empty;
            int numberOfFails = 0;
            string input = String.Empty;
            char guess;

            while (numberOfFails < tries && !Won)
            {

                Console.Write("ENTER A LETTER => ");
                input = Console.ReadLine().ToUpper();
                guess = input[0];

                //izveido metodi validate input 
                //un tad metodi izsauc try catch blokā un validē inputu tādā veidā 

                try
                {
                    ValidateInput(guess, usedLetters);
                }
                catch (InvalidInputException)
                {
                    continue;
                }

                if (WordToGuessUpper.Contains(guess))
                {
                    for (int j = 0; j < WordToGuessUpper.Length; j++)
                    {
                        if (WordToGuessUpper[j] == guess)
                        {
                            WordToGuessDash[j] = guess;
                            Console.Clear();
                            Console.WriteLine(WordToGuessDash.ToString());
                            Console.WriteLine("");
                            Console.WriteLine($"Wrong letters: {usedLetters}");
                            Console.WriteLine($"Remaining tries: {tries - numberOfFails} ");

                            HangmanDisplay.Display(MAX_GUESSES - tries + numberOfFails);
                        }
                    }
                    
                }
                else
                {
                    numberOfFails++;
                    usedLetters += guess;
                    Console.WriteLine(WordToGuessDash.ToString());
                    if (numberOfFails < tries)
                    {
                        Console.Clear();
                        Console.WriteLine(WordToGuessDash.ToString());
                        Console.WriteLine("");
                        Console.WriteLine($"Wrong letters: {usedLetters}");
                        Console.WriteLine($"Remaining tries: {tries - numberOfFails} ");
                    }

                    HangmanDisplay.Display(MAX_GUESSES - tries + numberOfFails);
                }

                if (WordToGuessDash.ToString().Equals(WordToGuessUpper))
                {
                    Won = true;
                }
            }
        }

        private static void ValidateInput(char input, String usedLetters)
        {
            if (Char.IsWhiteSpace(input))
            {
                throw new InvalidInputException($"Please, enter a letter!");
            }

            if (!Char.IsLetter(input))
            {
                throw new InvalidInputException($"{input} is not a letter!");
            }

            if (usedLetters.Contains(input))
            {
                throw new InvalidInputException($"You've already used {input}!");
            }
        }

        private static void WinnerText(int intLevel)
        {
            ILogger fileLogger = new FileLogger();
            ILogger consoleLogger = new ConsoleLogger();

            List<ILogger> loggers = new List<ILogger>();
            loggers.Add(consoleLogger);
            loggers.Add(fileLogger);

            CheckAllLoggers(loggers);

            void CheckAllLoggers(List<ILogger> loggers)
            {
                foreach (var logger in loggers)
                {
                    if (intLevel == (int)Level.Easy)
                    {
                        logger.Log("");
                        logger.Log("   **************");
                        logger.Log("   ***YOU WON!***");
                        logger.Log("   **************");
                        logger.Log("");
                    }
                    if (intLevel == (int)Level.Medium)
                    {
                        logger.Log($"You won the {Level.Medium} difficulty, yey!");
                    }
                    if (intLevel == (int)Level.Hard)
                    {
                        logger.Log("You won the HARDEST game EVER!");
                    }
                }
            }
        }
    }
}
