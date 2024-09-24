using Flash.Helper.MainHelper;
using Spectre.Console;
using Flashcards.ConsoleApp.Controllers;

namespace Flashcards.ConsoleApp.Views;
internal class SelectStackPage
{
    internal static void Show(out string currentWorkingStack)
    {
        Console.Clear();

        MainHelper.DisplayBanner("Select Stack", Color.Green);

        currentWorkingStack = SelectStack();
    }

    private static string SelectStack()
    {
        Console.WriteLine("All the existing stacks");

        StacksController.ShowAllStacks();

        Console.WriteLine("\nInput Name of the Stack you want to work with Or Input 0 to Return to MainMenu");

        string currentWorkingStack = Console.ReadLine();

        if (currentWorkingStack == "0")
        {
            MainMenuPage.Show();
            return string.Empty;  // Return empty stack if user chooses to return
        }

        Console.WriteLine($"Stack Chosen: {currentWorkingStack}");

        return currentWorkingStack;
    }
}
