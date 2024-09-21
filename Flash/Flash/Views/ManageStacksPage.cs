using Flash;
using Flash.Helper.MainHelper;
using Flashcards.ConsoleApp.Controllers;
using Spectre.Console;

namespace Flashcards.ConsoleApp.Views
{
    internal class ManageStacksPage
    {
        internal static void Show(string currentWorkingStack)
        {
            Console.Clear();

            MainHelper.DisplayBanner("Manage Stacks", Color.Green);

            //            StacksController.GetWorkingStackMenu(currentWorkingStack);

        }
    }
}
