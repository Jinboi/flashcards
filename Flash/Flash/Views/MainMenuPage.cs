using Flash.Helper.MainHelper;
using Flashcards.ConsoleApp.Controllers;
using Flashcards.ConsoleApp.Models;
using Spectre.Console;

namespace Flashcards.ConsoleApp.Views;
internal class MainMenuPage
{
    internal static void Show()
    {
        Console.Clear();
        bool closeApp = false;
        while (closeApp == false)
        {
            MainHelper.DisplayBanner("MAIN MENU", Color.White);

            ShowMainMenuCommands();

            string command = Console.ReadLine();

            ExecuteMainMenuCommands(command, closeApp);
        }
    }
    private static void ShowMainMenuCommands()
        {
            var rows = new List<Text>(){
                new Text("-Type 0 to Exit", new Style(Color.Red, Color.Black)),
                new Text("-Type 1 to Manage Stacks", new Style(Color.Green, Color.Black)),
                new Text("-Type 2 to Manage Flashcards", new Style(Color.Blue, Color.Black)),
                new Text("-Type 3 to Study", new Style(Color.Purple, Color.Black)),
                new Text("-Type 4 to View Study History", new Style(Color.Orange3, Color.Black)),
                new Text("-Type 5 to Delete a Stack",  new Style(Color.Aqua, Color.Black))
                };

            AnsiConsole.Write(new Rows(rows));
        }
    private static void ExecuteMainMenuCommands(string command, bool closeApp)
    {
        if (Enum.TryParse(command, out MainMenuCommand menuCommand))
        {       
            switch (menuCommand)
            {
                case MainMenuCommand.Exit:
                    Console.WriteLine("\nGoodbye!\n");
                    closeApp = true;
                    Environment.Exit(0);
                    break;

                case MainMenuCommand.ManageStacks:
                    ManageStacksPage.Show();
                    break;

                case MainMenuCommand.ManageFlashcards:
                    ManageFlashcardsPage.Show();
                    break;

                case MainMenuCommand.Study:
                    StudySessionPage.Show();
                    break;

                case MainMenuCommand.ViewStudyHistory:
                    StudySessionHistoryPage.Show();
                    break;

                case MainMenuCommand.DeleteAStack:
                    StacksController.GetDeleteStacks();
                    break;

                default:
                    Console.WriteLine("\nInvalid Command. Please type a number from 0 to 4.\n");
                    break;
            }
        }
    }
}
