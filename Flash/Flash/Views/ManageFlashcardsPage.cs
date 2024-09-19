using Flash.Helper.MainHelper;
using Spectre.Console;

namespace Flashcards.ConsoleApp.Views;
internal class ManageFlashcardsPage
{
    internal static void Show()
    {
        Console.Clear();

        MainHelper.DisplayBanner("All Flashcards in All Stacks", Color.Plum1);

        MainHelper.GetShowAllCardsInAllStacks();

        MainHelper.MainMenuReturnComments();
    }
}
