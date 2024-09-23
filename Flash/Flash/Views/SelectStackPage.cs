using Flash.Helper.MainHelper;
using Spectre.Console;
using Flashcards.ConsoleApp.Controllers;
using Flashcards.ConsoleApp.Views;

namespace Flashcards.ConsoleApp.Views;
internal class SelectStackPage
{
    internal static void Show()
    {
        Console.Clear();

        MainHelper.DisplayBanner("Select Stack", Color.Green);        

        CheckStack();

        string currentWorkingStack = ChooseStack();

        MoveToManageStacksPage(currentWorkingStack);
    }

    private static void MoveToManageStacksPage(string currentWorkingStack)
    {

        if (string.IsNullOrEmpty(currentWorkingStack) || currentWorkingStack == "0")
        {
            // Go Back to Main Menu if no stack is chosen
            MainMenuPage.Show();
        }
        else
        {
            MainHelper.GetCheckExistingStacks(currentWorkingStack);

            ManageStacksPage.Show(currentWorkingStack);
        }
    }
    private static string ChooseStack()
    {

        Console.WriteLine("All the existing stacks");

        StacksController.ShowAllStacks();

        Console.WriteLine("\nInput Name of the Stack you want to work with Or Input 0 to Return to MainMenu");
        Console.WriteLine("\nIf you add a Stack Name that doesn't exist, you'll be creating a new Stack under that Name.");

        string currentWorkingStack = Console.ReadLine();

        Console.WriteLine("Stack Chosen");

        return currentWorkingStack;

    }
    private static void CheckStack()
    {
        Console.WriteLine("Checking to see if you already have a stack");

        int stacksTableCount = StacksController.GetCheckStacksTable();

        if (stacksTableCount == 0)
        {
            Console.WriteLine("No stacks found.");
            StacksController.CreateStack();
        }
        else
        {
            Console.WriteLine("StacksTable already exists\n");
        }
    }
}

