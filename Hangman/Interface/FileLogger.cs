using Hangman.Interface;

namespace Hangman
{
    public class FileLogger : ILogger
    {
        public void Log(string message)
        {
            var lines = new string[] { message };

            File.WriteAllLines("logs.txt", lines);
        }
    }
}
