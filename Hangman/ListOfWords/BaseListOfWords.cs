namespace Hangman
{
    public class BaseListOfWords
    {
        //This is the base method - will be inherited in ListOfWordsFromDatabase and ListOfWordsFromFile class;
        //We get a list of words from the file and from DB, the aim is to gen one random word from this list to play the game
        public static string GetRandomWord(List<string> words)
        {
            try
            {
                Random rnd = new Random();
                return words[rnd.Next(0, words.Count - 1)];
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Problem with a guessing word selection occured!");
                throw ex;
            }

        }
    }
}
