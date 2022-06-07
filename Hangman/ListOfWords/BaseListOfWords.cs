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
    }
}
