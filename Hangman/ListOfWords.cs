using System.Text;

namespace Hangman
{
    public class ListOfWords
    {
         public static string AppTitle = "Hangman";

        public static List<string> LoadListOfWords()
        {
            StreamReader streamReader = null;
            try
            {
                streamReader = new StreamReader("Words.txt");
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