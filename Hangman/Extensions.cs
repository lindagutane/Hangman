using System.Text;

namespace Hangman
{
    public class Extensions : ListOfWords
    {
        public void StartGame()
        {
            ListOfWords listOfWords = new ListOfWords();
            listOfWords.AddWord();

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

                if (WordToGuessUpper.Contains(guess))
                {
                    for (int j = 0; j < WordToGuessUpper.Length; j++)
                    {
                        if (WordToGuessUpper[j] == guess)
                        {
                            WordToGuessDashed[j] = guess;
                        }
                    }
                    Console.WriteLine(WordToGuessDashed.ToString());
                }
                else
                {
                    numberOfFails++;
                    usedLetters += guess;
                    Console.WriteLine(WordToGuessDashed.ToString());
                    if (numberOfFails < 10)
                    {
                        Console.WriteLine($"Used letters: {usedLetters}");
                    }
                }

                if (WordToGuessDashed.ToString().Equals(WordToGuessUpper))
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
                Console.WriteLine($"You lost! Correct answer is: {WordToGuessUpper}");
            }
            Console.Write("Press enter to exit game...");
            Console.ReadLine();
        }
    }
}
