namespace Hangman
{
    public class ListOfWordsFromFile : BaseListOfWords
    {
        public static string GetWord()
        {

            StreamReader streamReader = null;
            List<string> ListOfWords = new List<string>();
            try
            {
                streamReader = new StreamReader("Words.txt");                
                string word;
                while ((word = streamReader?.ReadLine()) != null)
                {
                    ListOfWords.Add(word);
                }

            }
            catch (Exception)
            {
                Console.WriteLine("Cannot load text file with list of words!");
            }
            finally
            {
                streamReader?.Close();
            }         
            
            return GetRandomWord(ListOfWords);
        }

    }
}