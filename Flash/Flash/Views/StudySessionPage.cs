using Flash;
using Flash.Helper.MainHelper;
using Flashcards.ConsoleApp.Controllers;
using Flashcards.ConsoleApp.Helper.MainHelper;
using Spectre.Console;
using System.Data.SqlClient;

namespace Flashcards.ConsoleApp.Views
{
    internal class StudySessionPage
    {
        internal static void Show()
        {
            Console.Clear();

            MainHelper.DisplayBanner("Study", Color.Yellow);

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();
                connection.ChangeDatabase("DataBaseFlashCard");


                //see available stacks 
                try
                {
                    string showAllStacks =
                        @"SELECT Stack_Primary_Id, Name
                        FROM Stacks";

                    using (SqlCommand showAllStacksCommand = new SqlCommand(showAllStacks, connection))
                    {
                        // Execute the command and obtain a data reader
                        using (SqlDataReader reader = showAllStacksCommand.ExecuteReader())
                        {
                            // Display the names of all tables
                            Console.WriteLine("Stacks in the 'Stacks' Table:");
                            while (reader.Read())
                            {
                                AnsiConsole.WriteLine($"ID: {reader.GetInt32(0)}, Name: {reader.GetString(1)}");
                            }
                        }
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            int studyStack = StudySessionController.GetSetUpStudyStack();

            StudySessionController.GetCreateStudyTable(studyStack);

            (int correctAnswer, int totalQuestions) = StudySessionController.GetShowFlashcardToStudy(studyStack);

            StudySessionController.GetRecordToStudy(studyStack, correctAnswer, totalQuestions);

            MainHelper.MainMenuReturnComments();
        }

    }
}
