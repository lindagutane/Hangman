namespace Hangman;

public class HangmanDisplay
{

    public static void Display(int numberOfFails)
    {
        string hangman = GetMan(numberOfFails);
        Console.WriteLine(hangman);
    }

    public static string GetMan(int numberOfFails)
    {
        switch (numberOfFails)
        {
            case 0:
                return null;
            case 1:
                return @"
                           
                           
                           
                           
                           
                           
 =========
";
            case 2:
                return @"
 +
 |
 |
 |
 |
 |
 =========
";
            case 3:
                return @"
 +---+
 |
 |
 |
 |
 |
 =========
";
            case 4:
                return @"
 +---+
 |   |
 |
 |
 |
 |
 =========
";
            case 5:
                return @"
 +---+
 |   |
 |   O
 |
 |
 |
 =========
";
            case 6:
                return @"
 +---+
 |   |
 |   O  
 |   |
 |
 |
 =========
";
            case 7:
                return @"
 +---+
 |   |
 |   O 
 |  /|
 |
 |
 =========
";
            case 8:
                return @"
 +---+
 |   |
 |   O                    
 |  /|\                   
 |
 |
 =========
";                    
            case 9:
                return @"
 +---+
 |   |
 |   O                    
 |  /|\                   
 |  / 
 |
 =========
";
            case 10:
                return @"
 +---+
 |   |
 |   O                    
 |  /|\                   
 |  / \
 |
 =========
";
            default:
                throw new Exception("Problem displaying Hangman, check your code!");
        }
    }
}
