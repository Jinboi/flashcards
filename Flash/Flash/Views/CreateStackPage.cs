using Flash;
using System.Data.SqlClient;
using Flash.Helper.MainHelper;
using Spectre.Console;

namespace Flashcards.ConsoleApp.Views;
internal class CreateStackPage
{
    internal static void Show()
    {
        Console.Clear();

        MainHelper.DisplayBanner("Check StackPage", Color.Green);





        using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
        {
            connection.Open();
            connection.ChangeDatabase("DataBaseFlashCard");

            string createStacksTableQuery = @"
                CREATE TABLE Stacks (
                Stack_Primary_Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
                Name NVARCHAR(50) NOT NULL
                )";

            using (SqlCommand createStacksTableCommand = new SqlCommand(createStacksTableQuery, connection))
            {
                createStacksTableCommand.ExecuteNonQuery();
                Console.WriteLine("Table 'Stacks' created successfully.");
            }
        }
    }
}
