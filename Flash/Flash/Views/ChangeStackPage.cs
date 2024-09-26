using Flash.Helper.MainHelper;
using Spectre.Console;

namespace Flashcards.ConsoleApp.Views;
{
    internal class ChangeStackPage
    {
        internal static void Show()
        {
            Console.Clear();

            MainHelper.DisplayBanner("Check Stack", Color.Green);
        }
    }

}