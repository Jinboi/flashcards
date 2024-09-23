using Flash.Helper.DTO;
using Spectre.Console;
using System.Data.SqlClient;
using Flashcards.ConsoleApp.Views;
using Flashcards.ConsoleApp.Helper.MainHelper;

namespace Flash.Helper.MainHelper;
public static class MainHelper
{

    internal static void GetCheckExistingStacks(string currentWorkingStack)
    {
        string checkDuplicatedStackQuery =
            @$"SELECT COUNT(*) 
                    FROM dbo.Stacks 
                    WHERE Name = '{currentWorkingStack}'";

        using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
        {
            connection.Open();
            connection.ChangeDatabase("DataBaseFlashCard");

            using (SqlCommand checkDuplicatedStackCommand = new SqlCommand(checkDuplicatedStackQuery, connection))
            {
                int SameNameStacksCount = Convert.ToInt32(checkDuplicatedStackCommand.ExecuteScalar());
                if (SameNameStacksCount == 0)
                {
                    string insertStackQuery = $"INSERT INTO Stacks (Name) VALUES ('{currentWorkingStack}')";

                    using (SqlCommand insertStackCommand = new SqlCommand(insertStackQuery, connection))
                    {
                        insertStackCommand.ExecuteNonQuery();
                        Console.WriteLine($"Added {currentWorkingStack} to Stacks");
                    }
                }
                else
                {
                    Console.WriteLine($"Did not added {currentWorkingStack} to Stacks as it already exists");
                }
            }
        }
    }


    internal static int GetCheckStacksTableExists()
    {
        using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
        {
            connection.Open();
            connection.ChangeDatabase("DataBaseFlashCard");

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





    internal static void ExecuteDeleteAStack(int stackIdToDelete)
    {
        using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
        {
            connection.Open();
            connection.ChangeDatabase("DataBaseFlashCard");

            string deleteFlashcardsQuery = @"
                DELETE FROM Flashcards 
                WHERE Stack_Primary_Id = @StackId";

            using (SqlCommand deleteFlashcardsCommand = new SqlCommand(deleteFlashcardsQuery, connection))
            {
                deleteFlashcardsCommand.Parameters.AddWithValue("@StackId", stackIdToDelete);
                int flashcardsDeleted = deleteFlashcardsCommand.ExecuteNonQuery();
                Console.WriteLine($"Deleted {flashcardsDeleted} flashcard(s) associated with the stack.");
            }

            string deleteStudyDataQuery =
                @"DELETE FROM Study 
                      WHERE Stack_Primary_Id = @StackId";

            using (SqlCommand deleteStudyDataCommand = new SqlCommand(deleteStudyDataQuery, connection))
            {
                deleteStudyDataCommand.Parameters.AddWithValue("@StackId", stackIdToDelete);
                int studyDataDeleted = deleteStudyDataCommand.ExecuteNonQuery();
                Console.WriteLine($"Deleted {studyDataDeleted} study data record(s) associated with the stack.");
            }

            string deleteStackQuery =
                @"DELETE FROM Stacks 
                      WHERE Stack_Primary_Id = @StackId";

            using (SqlCommand deleteStackCommand = new SqlCommand(deleteStackQuery, connection))
            {
                deleteStackCommand.Parameters.AddWithValue("@StackId", stackIdToDelete);
                int stacksDeleted = deleteStackCommand.ExecuteNonQuery();
                Console.WriteLine($"Deleted stack with Stack_Primary_Id: {stackIdToDelete}");
            }
        }
    }
    internal static void MainMenuReturnComments()
    {
        Console.WriteLine("Press Any Key To Return To MainMenu");
        Console.ReadLine();

        MainMenuPage.Show();
    }


    internal static int GetSelectFlashcardToWorkWith()
    {
        string currentWorkingFlashcardString = Console.ReadLine();
        int currentWorkingFlashcardId;

        if (int.TryParse(currentWorkingFlashcardString, out currentWorkingFlashcardId))
        {

            Console.WriteLine($"Selected Flashcard_Primary_Id: {currentWorkingFlashcardId}");
        }
        else
        {
            Console.WriteLine("Unable to convert the string to an integer.");
        }

        return currentWorkingFlashcardId;
    }


    internal static void GetShowAllCardsInAllStacks()
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();
                connection.ChangeDatabase("DataBaseFlashCard");

                string selectQuery =
                    $@"SELECT Flashcard_Primary_Id , Front, Back, Stack_Primary_Id
                            FROM Flashcards";

                List<FlashcardDto> flashcards = new List<FlashcardDto>();
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                FlashcardDto flashcard = new FlashcardDto
                                {
                                    Flashcard_Primary_Id = reader.GetInt32(0),
                                    Front = reader.GetString(1),
                                    Back = reader.GetString(2),
                                    Stack_Primary_Id = reader.GetInt32(3)
                                };
                                flashcards.Add(flashcard);
                            }

                            GetRenumberFlashcards(flashcards);

                            foreach (var flashcard in flashcards)
                            {
                                Console.WriteLine(@$"
                                    Flashcard_Primary_Id: {flashcard.Flashcard_Primary_Id}, 
                                    Front: {flashcard.Front}, 
                                    Back: {flashcard.Back}, 
                                    Stack_Primary_Id: {flashcard.Stack_Primary_Id}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No flashcards found.");
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
    internal static void DisplayBanner(string figletText, Color figletColor)
    {
        AnsiConsole.Write
            (
                new FigletText(figletText)
                    .LeftJustified()
                    .Color(figletColor)
            );

        var panel = new Panel("What Would You Like to Do?");

        AnsiConsole.Write(
                new Panel(panel)
                    .Header("")
                    .Collapse()
                    .RoundedBorder()
                    .BorderColor(Color.White));
    }
    


    internal static void GetShowStudyHistory()
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();
                connection.ChangeDatabase("DataBaseFlashCard");

                string selectQuery = $@"
                            SELECT Study_Primary_Id , Date, Score, Stack_Primary_Id
                            FROM Study";

                List<StudyDto> studys = new List<StudyDto>();
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                StudyDto study = new StudyDto
                                {
                                    Study_Primary_Id = reader.GetInt32(0),
                                    Date = reader.GetDateTime(1),
                                    Score = reader.GetString(2),
                                    Stack_Primary_Id = reader.GetInt32(3)
                                };
                                studys.Add(study);
                            }

                            GetRenumberStudys(studys);

                            foreach (var study in studys)
                            {
                                Console.WriteLine(@$"
                                    Study_Primary_Id: {study.Study_Primary_Id}, 
                                    Date: {study.Date}, 
                                    Score: {study.Score}, 
                                    Stack_Primary_Id: {study.Stack_Primary_Id}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No flashcards found.");
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }


    internal static int GetStackIdToDelete()
    {
        Console.WriteLine("Enter the Stack_Primary_Id to delete:");
        string stackToDelete = Console.ReadLine();
        int stackIdToDelete = 0;
        try
        {
            int.TryParse(stackToDelete, out stackIdToDelete);
            Console.WriteLine($"Selected Stack_Primary_Id: {stackIdToDelete}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            Console.WriteLine("Unable to convert the string to an integer.");
        }
        return stackIdToDelete;
    }


    internal static void GetRenumberFlashcards(List<FlashcardDto> flashcards)
    {
        for (int i = 0; i < flashcards.Count; i++)
        {
            flashcards[i].Flashcard_Primary_Id = i + 1;
        }
    }
    internal static void GetRenumberStudys(List<StudyDto> studys)
    {
        for (int i = 0; i < studys.Count; i++)
        {
            studys[i].Study_Primary_Id = i + 1;
        }
    }




}
