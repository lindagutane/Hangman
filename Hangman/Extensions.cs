using System.Text;

namespace Hangman
{
    public class Extensions
    {
        public static string AppTitle = "Hangman";
        private static string WordToGuessUpper;
        private static StringBuilder WordToGuessDash = new StringBuilder();
        private static bool Won;
        private static int tries;
        private static string difficulty;

        public static void StartGame()
        {
            Console.WriteLine("Please choose a difficulty level:");
            Console.WriteLine("1) easy");
            Console.WriteLine("2) medium");
            Console.WriteLine("3) hard");

            string level = Console.ReadLine();
            int intLevel = int.Parse(level);

            if (intLevel == 1)
            {
                tries = 10;
                difficulty = "1st";
            }
            if(intLevel == 2)
            {
                tries = 7;
                difficulty = "2nd";
            }
            if (intLevel == 3)
            {
                tries = 5;
                difficulty = "3rd";
            }

            Console.WriteLine($" {difficulty} difficulty level chosen. You can make {tries} mistakes!");

            AddWord();

            GuessWord();

            if (Won)
            {
                Console.WriteLine("You won!");
            }
            else
            {
                Console.WriteLine($"You lost! Correct answer is: {WordToGuessUpper}");
            }

            Console.Write("Press enter to exit game...");
            Console.ReadLine();
        }

        private static void AddWord()
        {
            //Random rnd = new Random();
            //var loadListOfWords = ListOfWords.LoadListOfWords();
            //string wordToGuess = loadListOfWords[rnd.Next(0, loadListOfWords.Count - 1)];
            string wordToGuess = "hidroelektrostacija";
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

                Console.Write("Enter a letter: ");
                input = Console.ReadLine().ToUpper();
                guess = input[0];

                if (!Char.IsLetter(guess))
                {
                    Console.WriteLine($"{guess} is not a letter!");
                    continue;
                }

                if (usedLetters.Contains(guess))
                {
                    Console.WriteLine($"You've already used {guess}!");
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
                            Console.WriteLine($"Used letters: {usedLetters}");
                            Console.WriteLine($"Remaining tries: {tries - numberOfFails} ");

                            HangmanDisplay.Display(numberOfFails);
                        }
                    }
                    Console.WriteLine(WordToGuessDash.ToString());
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
                        Console.WriteLine($"Used letters: {usedLetters}");
                        Console.WriteLine($"Remaining tries: {tries - numberOfFails} ");
                    }
                    
                    HangmanDisplay.Display(numberOfFails);
                }

                if (WordToGuessDash.ToString().Equals(WordToGuessUpper))
                {
                    Won = true;
                }
            }
        }
    }
}
