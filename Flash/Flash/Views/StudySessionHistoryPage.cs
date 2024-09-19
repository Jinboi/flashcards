using Flash.Helper.MainHelper;
using Spectre.Console;


namespace Flashcards.ConsoleApp.Views
{
    internal class StudySessionHistoryPage
    {
        internal static void Show()
        {
            Console.Clear();

            MainHelper.DisplayBanner("View Study Session Data", Color.Orange3);

            MainHelper.GetShowStudyHistory();

            MainHelper.MainMenuReturnComments();
        }
    }
}
