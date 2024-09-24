using System.Data.SqlClient;
using Flash;
using Flash.Helper.DTO;
using Flash.Helper.MainHelper;
using Flashcards.ConsoleApp.Models;
using Flashcards.ConsoleApp.Views;
using Spectre.Console;

namespace Flashcards.ConsoleApp.Controllers;
public static class StacksController
{

    internal static void ShowAllStacks()
    {
        using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
        {
            connection.Open();
            connection.ChangeDatabase("DataBaseFlashCard");

            try
            {
                List<StacksDto> stacks = new List<StacksDto>();

                string showAllStacks = @"
                    SELECT Stack_Primary_Id, Name
                    FROM Stacks";

                using (SqlCommand command = new SqlCommand(showAllStacks, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                StacksDto stack = new StacksDto
                                {
                                    Stack_Primary_Id = reader.GetInt32(0),
                                    Name = reader.GetString(1)
                                };
                                stacks.Add(stack);
                            }

                            Console.WriteLine("Stacks in the 'Stacks' Table:\n");

                            foreach (var stack in stacks)
                            {
                                Console.WriteLine($"Stack_Primary_Id: {stack.Stack_Primary_Id}, Name: {stack.Name}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No stacks found.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
    internal static int GetCheckStacksTable()
    {
        using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
        {
            connection.Open();
            connection.ChangeDatabase("DataBaseFlashCard");

            // Check if 'Flashcards' table exists
            string checkStacksTableQuery =
                @"SELECT COUNT(*) 
                        FROM INFORMATION_SCHEMA.TABLES 
                        WHERE TABLE_NAME = 'Stacks'";

            using (SqlCommand checkStacksTableCommand = new SqlCommand(checkStacksTableQuery, connection))
            {
                int stacksTableCount = Convert.ToInt32(checkStacksTableCommand.ExecuteScalar());
                return stacksTableCount;
            }
        }
    }
    internal static void GetDeleteStacks()
    {
        Console.Clear();

        MainHelper.DisplayBanner("Manage Stacks", Color.RosyBrown);

        int stacksTableCount = MainHelper.GetCheckStacksTableExists();

        if (stacksTableCount == 0)
        {
            Console.WriteLine("Cannot delete a stack. Stacks Table does not exist.");
            MainHelper.MainMenuReturnComments();
        }
        else
        {
            Console.WriteLine("Stacks Table alreaday exists");
        }

        Console.WriteLine("This is all the stacks in your Stacks Table: ");

        StacksController.ShowAllStacks();

        int stackIdToDelete = MainHelper.GetStackIdToDelete();

        Console.WriteLine($"The stack ID to delete is: {stackIdToDelete}");

        MainHelper.ExecuteDeleteAStack(stackIdToDelete);

        MainHelper.MainMenuReturnComments();
    }
    internal static void CreateStack()
    {

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
