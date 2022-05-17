﻿using System.Text;

namespace Hangman
{
    public class ListOfWords
    {
        protected string WordToGuessUpper;
        protected StringBuilder WordToGuessDashed;


        public List<string> LoadListOfWords()
        {
            StreamReader sr = null;
            try
            {
                sr = new StreamReader("Words.txt");
            }
            catch (Exception)
            {
                Console.WriteLine("Cannot load text file with list of words!");
            }

            List<string> ListOfWords = new List<string>();
            string word;
            while ((word = sr.ReadLine()) != null)
            {
                ListOfWords.Add(word);
            }

            return ListOfWords;
        }

        public void AddWord()
        {
            Random rnd = new Random();
            List<string> listOfWords = LoadListOfWords();
            string wordToGuess = listOfWords[rnd.Next(0, listOfWords.Count - 1)];
            WordToGuessUpper = wordToGuess.ToUpper();

            WordToGuessDashed = new StringBuilder();

            for (int i = 0; i < wordToGuess.Length; i++)
            {
                WordToGuessDashed.Append('-');
            }
        }
    }
}