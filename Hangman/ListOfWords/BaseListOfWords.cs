namespace Hangman
{
    public class BaseListOfWords
    {
        public static List<string> LoadListOfWords(string file)
        {
            StreamReader streamReader = null;
            try
            {
                streamReader = new StreamReader(file);
            }
            catch (Exception)
            {
                Console.WriteLine("Cannot load text file with list of words!");
            }

            List<string> ListOfWords = new List<string>();
            string word;
            while ((word = streamReader.ReadLine()) != null)
            {
                ListOfWords.Add(word);
            }

            return ListOfWords;
        }
    }
}
