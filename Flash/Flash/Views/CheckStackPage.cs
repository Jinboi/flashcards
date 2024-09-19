using Flash.Helper.MainHelper;
using Flashcards.ConsoleApp.Controllers;
using Spectre.Console;

namespace Flashcards.ConsoleApp.Views;
internal class CheckStackPage
{
    internal static void Show()
    {
        Console.Clear();

        MainHelper.DisplayBanner("Check StackPage", Color.Green);

        Console.WriteLine("Checking to see if you already have a stack");

        int stacksTableCount = StacksController.GetCheckStacksTable();

        if (stacksTableCount == 0)
        {
            Console.WriteLine("No stacks found.");           
        }
        else
        {
            Console.WriteLine("StacksTable already exists\n");
        }
    }
}
