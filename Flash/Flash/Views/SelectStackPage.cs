using Flash.Helper.MainHelper;
using Spectre.Console;
using Flashcards.ConsoleApp.Controllers;

namespace Flashcards.ConsoleApp.Views
{
    internal class SelectStackPage
    {
        internal static void Show(out string currentWorkingStack)
        {
            Console.Clear();

            MainHelper.DisplayBanner("Select Stack", Color.Green);

            currentWorkingStack = SelectStack();
        }

        internal static string SelectStack()
        {
            Console.WriteLine("All the existing stacks:");

            StacksController.ShowAllStacks();  // Display available stacks

            Console.WriteLine("\nInput the **name** of the stack you want to work with or input '0' to return to Main Menu.");

            string selectedStack = Console.ReadLine();

            if (selectedStack == "0")
            {
                MainMenuPage.Show();
                return string.Empty;  // Return empty stack if the user chooses to return
            }

            Console.WriteLine($"Stack Chosen: {selectedStack}");

            return selectedStack;
        }
    }
}
