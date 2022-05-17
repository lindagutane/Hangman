using System.Text;

namespace Hangman
{
    public class Extensions
    {
        public static void StartGame()
        {
            Random random = new Random();
            var loadListOfWords = ListOfWords.LoadListOfWords();
            string wordToGuess = loadListOfWords[random.Next(0, loadListOfWords.Count - 1)];
            string wordToGuessUpper = wordToGuess.ToUpper();

            StringBuilder wordToGuessDash = new StringBuilder();

            for (int i = 0; i < wordToGuess.Length; i++)
            {
                wordToGuessDash.Append('-');
            }

            string usedLetters = String.Empty;
            bool won = false;
            int numberOfFails = 0;
            string input = String.Empty;
            char guess;

            while (numberOfFails < 10 && !won)
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

                if (wordToGuessUpper.Contains(guess))
                {
                    for (int j = 0; j < wordToGuessUpper.Length; j++)
                    {
                        if (wordToGuessUpper[j] == guess)
                        {
                            wordToGuessDash[j] = guess;
                        }
                    }
                    Console.WriteLine(wordToGuessDash.ToString());
                }
                else
                {
                    numberOfFails++;
                    usedLetters += guess;
                    Console.WriteLine(wordToGuessDash.ToString());
                    if (numberOfFails < 10)
                    {
                        Console.WriteLine($"Used letters: {usedLetters}");
                    }
                }

                if (wordToGuessDash.ToString().Equals(wordToGuessUpper))
                {
                    won = true;
                }
            }

            if (won)
            {
                Console.WriteLine("You won!");
            }
            else
            {
                Console.WriteLine($"You lost! Correct answer is: {wordToGuessUpper}");
            }
            Console.Write("Press enter to exit game...");
            Console.ReadLine();
        }
    }
}
