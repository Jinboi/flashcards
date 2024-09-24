using Flash.Helper.MainHelper;
using Flashcards.ConsoleApp.Controllers;
using Spectre.Console;

namespace Flashcards.ConsoleApp.Views
{
    internal class CheckStackPage
    {
        internal static void Show()
        {
            Console.Clear();

            MainHelper.DisplayBanner("Check Stack", Color.Green);

            CheckStack();
        }

        private static void CheckStack()
        {
            Console.WriteLine("Checking to see if you already have a stack...");

            int stacksTableCount = StacksController.GetCheckStacksTable();

            if (stacksTableCount == 0)
            {
                Console.WriteLine("No stacks found.");
                StacksController.CreateStack(); // Create a new stack
                Console.WriteLine("Stack created successfully. Returning to main menu...");
                MainMenuPage.Show();
            }
            else
            {
                Console.WriteLine("StacksTable already exists.");
                Console.WriteLine("Moving to Select Stack Page...");
                string selectedStack;
                SelectStackPage.Show(out selectedStack); // Update for out parameter handling
                Console.WriteLine($"You selected the stack: {selectedStack}");
            }
        }
    }
}
