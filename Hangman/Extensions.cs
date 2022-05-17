﻿using System.Text;

namespace Hangman
{
    public class Extensions
    {
        private static string WordToGuessUpper;
        private static StringBuilder WordToGuessDash = new StringBuilder();

        public static void StartGame()
        {

            AddWord();

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
                            WordToGuessDash[j] = guess;
                        }
                    }
                    Console.WriteLine(WordToGuessDash.ToString());
                }
                else
                {
                    numberOfFails++;
                    usedLetters += guess;
                    Console.WriteLine(WordToGuessDash.ToString());
                    if (numberOfFails < 10)
                    {
                        Console.WriteLine($"Used letters: {usedLetters}");
                    }
                }

                if (WordToGuessDash.ToString().Equals(WordToGuessUpper))
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

        public static void AddWord()
        {
            Random rnd = new Random();
            var loadListOfWords = ListOfWords.LoadListOfWords();
            string wordToGuess = loadListOfWords[rnd.Next(0, loadListOfWords.Count - 1)];
            WordToGuessUpper = wordToGuess.ToUpper();

            for (int i = 0; i < wordToGuess.Length; i++)
            {
                WordToGuessDash.Append('-');
            }
        }
    }
}
