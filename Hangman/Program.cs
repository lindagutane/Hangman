using Hangman;
using Hangman.ListOfWords;
using System.Data.SQLite;

Console.ForegroundColor = ConsoleColor.Green;
Console.BackgroundColor = ConsoleColor.Black;
Console.Clear();

Console.Title = PlayHangman.AppTitle;

PlayHangman playHangman = new PlayHangman();

playHangman.StartGame();