namespace Hangman
{
    public class BaseListOfWords
    {
        public static StreamReader? LoadListOfWords(string file)
        {
            StreamReader? streamReader = null;
            try
            {
                streamReader = new StreamReader(file);
            }
            catch (Exception)
            {
                Console.WriteLine("Cannot load text file with list of words!");
            }

            return streamReader;
        }

        //This is the base method - will be inherited in ListOfWordsFromDatabase and ListOfWordsFromFile class;
        //We get a list of words from the file and from DB, the aim is to gen one random word from this list to play the game
        public static string GetRandomWord(List<string> words)
        {
            Random rnd = new Random();
            return words[rnd.Next(0, words.Count - 1)];

        }
    }
}
