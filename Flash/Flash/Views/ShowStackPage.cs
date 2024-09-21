using Flash.Helper.MainHelper;
using Flashcards.ConsoleApp.Controllers;
using Spectre.Console;

namespace Flashcards.ConsoleApp.Views;
internal class ShowStackPage
{
    internal static void Show()
    {
        Console.Clear();

        MainHelper.DisplayBanner("Show Stack", Color.Green);

        int stacksTableCount = StacksController.GetCheckStacksTable();

        if (stacksTableCount == 0)
        {
            Console.WriteLine("No stacks found.");
            Console.WriteLine("Moving to Main Menu");
            MainMenuPage.Show();            
        }
        else
        {
            Console.WriteLine("StacksTable already exists\n");
        }

        

        Console.WriteLine("Moving to ManageStackPage");

    }
}
