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

        Console.WriteLine("All the existing stacks");

        StacksController.ShowAllStacks();

        Console.WriteLine("\nInput Name of the Stack you want to work with Or Input 0 to Return to MainMenu");
        Console.WriteLine("\nIf you add a Stack Name that doesn't exist, you'll be creating a new Stack under that Name.");

        string currentWorkingStack = Console.ReadLine();

        Console.WriteLine("Stack Chosen");

        Console.WriteLine("Moving to ManageStackPage");

        //Something is wrong here//
    }
}
