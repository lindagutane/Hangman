namespace Hangman
{
    public class ListOfWordsFromFile : BaseListOfWords
    {
        public static string GetWord()
        {
            StreamReader streamReader = LoadListOfWords("Words.txt");

            List<string> ListOfWords = new List<string>();
            string word;
            while ((word = streamReader.ReadLine()) != null)
            {
                ListOfWords.Add(word);
            }

            return GetRandomWord(ListOfWords);
        }

    }
}