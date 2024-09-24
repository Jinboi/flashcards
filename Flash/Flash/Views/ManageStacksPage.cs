using Flash;
using Flash.Helper.MainHelper;
using Flashcards.ConsoleApp.Controllers;
using Flashcards.ConsoleApp.Models;
using Spectre.Console;

namespace Flashcards.ConsoleApp.Views
{
    internal class ManageStacksPage
    {
        internal static void Show()
        {
            Console.Clear();

            MainHelper.DisplayBanner("Manage Stacks", Color.Green);

            string currentWorkingStack = "";

            Console.WriteLine($"Current Stack: {currentWorkingStack}\n");

            showManageStacksMenu();

            string command = Console.ReadLine();

            ExecuteStackMenuCommand(command, ref currentWorkingStack);
        }

        private static void showManageStacksMenu()
        {
            var rows = new List<Text>(){
                new Text("-Type 0 to Return to Main Menu", new Style(Color.Red, Color.Black)),
                new Text("-Type 1 to Select Current Stack", new Style(Color.Purple, Color.Black)),
                new Text("-Type 2 to Change Current Stack", new Style(Color.Green, Color.Black)),
                new Text("-Type 3 to View All Flashcards in Stack", new Style(Color.Blue, Color.Black)),
                new Text("-Type 4 to View X amount of cards in stack", new Style(Color.Purple, Color.Black)),
                new Text("-Type 5 to Create a Flashcard in current stack", new Style(Color.Orange3, Color.Black)),
                new Text("-Type 6 to Edit a Flashcard", new Style(Color.Red, Color.Black)),
                new Text("-Type 7 to Delete a Flashcard", new Style(Color.Green, Color.Black)),

            };

            AnsiConsole.Write(new Rows(rows));
        }

        internal static void ExecuteStackMenuCommand(string command, ref string currentWorkingStack)
        {
            if (Enum.TryParse(command, out StackMenuCommand menuCommand))
            {
                switch (menuCommand)
                {
                    case StackMenuCommand.Exit:
                        Console.WriteLine("\nGoodbye!\n");
                        MainMenuPage.Show();
                        break;

                    case StackMenuCommand.SelectStack:
                        Console.WriteLine("Select Current Stack");
                        SelectStackPage.Show(out currentWorkingStack);  // Pass currentWorkingStack as out
                        break;

                    case StackMenuCommand.ChangeStack:
                        Console.WriteLine("Change Current Stack");
                        SelectStackPage.Show(out currentWorkingStack);  // Pass currentWorkingStack as out
                        break;

                    case StackMenuCommand.ViewAllFlashcards:
                        Console.WriteLine("View All Flashcards in Stack");
                        FlashcardController.GetViewAllFlashcards(currentWorkingStack);
                        break;

                    case StackMenuCommand.ViewXAmountFlashcards:
                        Console.WriteLine("View X amount of cards in stack");
                        FlashcardController.GetViewXAmountFlashcards(currentWorkingStack);
                        break;

                    case StackMenuCommand.CreateFlashcard:
                        Console.WriteLine("Create a Flashcard in current stack");
                        FlashcardController.GetCreateFlashcard(currentWorkingStack);
                        break;

                    case StackMenuCommand.EditFlashcard:
                        Console.WriteLine("Edit a Flashcard");
                        FlashcardController.GetEditFlashcards(currentWorkingStack);
                        break;

                    case StackMenuCommand.DeleteFlashcard:
                        Console.WriteLine("Delete a Flashcard");
                        FlashcardController.GetDeleteFlashcards(currentWorkingStack);
                        break;

                    default:
                        Console.WriteLine("\nInvalid Command. Please type a number from 0 to 7.\n");
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nInvalid Command. Please type a number from 0 to 7.\n");
            }
        }
    }
}

