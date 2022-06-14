using System.Data.SQLite;
using Hangman;
using Hangman.Interface;

namespace Hangman.ListOfWords
{
    public class ListOfWordsFromDatabase : BaseListOfWords
    {
        static SQLiteConnection CreateConnection()
        {

            ILogger fileLogger = new FileLogger();   
            List<ILogger> loggers = new List<ILogger>();
            loggers.Add(fileLogger);

            //CheckAllLoggers(loggers);

            SQLiteConnection sqlite_conn;
            // Create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=../../../database.db; Version = 3; New = True; Compress = True; ");
            // Open the connection:
            try
            {
                sqlite_conn.Open();
            }
            catch (Exception)
            {                
               return null;
            }
            return sqlite_conn;
        }

        static void CreateTable(SQLiteConnection connection)
        {

            SQLiteCommand sqlite_cmd;
            string Createsql = "CREATE TABLE GuessingWords (Word varchar(255))";
            sqlite_cmd = connection.CreateCommand();
            sqlite_cmd.CommandText = Createsql;
            sqlite_cmd.ExecuteNonQuery();
                   
        }

        static void InsertData(SQLiteConnection connection)
        {
            SQLiteCommand command;
            command = connection.CreateCommand();

            //clear table
            //SQLiteCommand cmd = new SQLiteCommand("DELETE FROM GuessingWords", connection);
            //cmd.ExecuteNonQuery();

            command.CommandText = "INSERT INTO GuessingWords VALUES ('advantage'); ";
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO GuessingWords VALUES ('attention'); ";
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO GuessingWords VALUES ('channel'); ";
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO GuessingWords VALUES ('college'); ";
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO GuessingWords VALUES ('creative'); ";
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO GuessingWords VALUES ('distinguish'); ";
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO GuessingWords VALUES ('employee'); ";
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO GuessingWords VALUES ('finance'); ";
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO GuessingWords VALUES ('investigate'); ";
            command.ExecuteNonQuery();
        }

        static string ReadData(SQLiteConnection connection)
        {
            SQLiteDataReader dataReader;
            SQLiteCommand command;
            command = connection.CreateCommand();

            try
            {
                command.CommandText = "SELECT Word FROM GuessingWords";
            }
            catch (Exception ex)
            {

            }
            

            dataReader = command.ExecuteReader();

            List<string> words = new List<string>();

            while (dataReader.Read())
            {
                words.Add(dataReader.GetString(0));
                //Console.WriteLine(dataReader.GetString(0));
            }

            connection.Close();

            //Here we use the inherited method to get one word from a list
            return GetRandomWord(words);

        }

        public static string GetRandomWordFromDb()
        {
            SQLiteConnection connection = CreateConnection();

            if(connection == null)
            {
                return null;
            }

            //CreateTable(connection);
            //InsertData(connection);
            return ReadData(connection);

        }        

    }

}