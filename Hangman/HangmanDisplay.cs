namespace Hangman
{
    class HangmanDisplay
    {
        public static void Display(int numberOfFails)
        {
            switch (numberOfFails)
            {
                case 0:
                    break;
                case 1:
                    Console.WriteLine(@"
                           
                           
                           
                           
                           
                           
                    =========");
                    break;
                case 2:
                    Console.WriteLine(@"
                          +
                          |
                          |
                          |
                          |
                          |
                    =========");
                    break;
                case 3:
                    Console.WriteLine(@"
                      +---+
                          |
                          |
                          |
                          |
                          |
                    =========");
                    break;
                case 4:
                    Console.WriteLine(@"
                      +---+
                      |   |
                          |
                          |
                          |
                          |
                    =========");
                    break;
                case 5:
                    Console.WriteLine(@"
                      +---+
                      |   |
                      O   |
                          |
                          |
                          |
                    =========");
                    break;
                case 6:
                    Console.WriteLine(@"
                      +---+
                      |   |
                      O   |
                      |   |
                          |
                          |
                    =========");
                    break;
                case 7:
                    Console.WriteLine(@"
                      +---+
                      |   |
                      O   |
                     /|   |
                          |
                          |
                    =========");
                    break;
                case 8:
                    Console.WriteLine(@"
                      +---+
                      |   |
                      O   |
                     /|\  |
                          |
                          |
                    =========");
                    break;
                case 9:
                    Console.WriteLine(@"
                      +---+
                      |   |
                      O   |
                     /|\  |
                     /    |
                          |
                    =========");
                    break;
                case 10:
                    Console.WriteLine(@"
                      +---+
                      |   |
                      O   |
                     /|\  |
                     / \  |
                          |
                    =========");
                    break;
                default:
                    throw new Exception("Problem displaying Hangman, check your code!");

            }
        }
    }
}