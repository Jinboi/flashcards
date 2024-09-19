using Flash;
using Flash.Helper.DTO;

namespace Flashcards.ConsoleApp.Helper.MainHelper;
internal class Renumber
{
    internal static void GetRenumberFlashcards(List<FlashcardDto> flashcards)
    {
        for (int i = 0; i < flashcards.Count; i++)
        {
            flashcards[i].Flashcard_Primary_Id = i + 1;
        }
    }
}
