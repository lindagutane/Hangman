namespace Hangman
{
    public class ListOfWordsFromFile : BaseListOfWords
    {
        public void UseListOfWords()
        {
            LoadListOfWords("Words.txt");   
        }
    }
}