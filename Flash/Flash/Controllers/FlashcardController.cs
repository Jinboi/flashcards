using Flash.Helper.MainHelper;
using Flash.Helper.SubManageStacksHelper;
using Spectre.Console;

namespace Flashcards.ConsoleApp.Controllers;
internal class FlashcardController
{
    internal static void GetCreateFlashcard(string currentWorkingStack)
    {
        int flashcardsTableCount = ManageStacksService.GetCheckFlashcardsTableExists();

        if (flashcardsTableCount == 0)
        {
            ManageStacksService.GetCreateFlashcardsTable();
        }
        else
        {
            Console.WriteLine("Flashcards Table alreaday exists");
        }

        ManageStacksService.GetCreateAFlashcard(currentWorkingStack);

        MainHelper.MainMenuReturnComments();
    }

    internal static void GetDeleteFlashcards(string currentWorkingStack)
    {
        Console.WriteLine($"Current Stack: {currentWorkingStack}\n");

        GetViewAllFlashcards(currentWorkingStack);

        Console.WriteLine("What to delete?");

        int currentWorkingFlashcardId = MainHelper.GetSelectFlashcardToWorkWith();

        ManageStacksService.GetDeleteSelectedFlashcard(currentWorkingFlashcardId);

        MainHelper.MainMenuReturnComments();
    }

    public static void GetEditFlashcards(string currentWorkingStack)
    {
        Console.WriteLine($"Current Stack: {currentWorkingStack}\n");

        GetViewAllFlashcards(currentWorkingStack);

        Console.WriteLine("What to edit?");

        int currentWorkingFlashcardId = MainHelper.GetSelectFlashcardToWorkWith();

        ManageStacksService.GetShowFlashcardsInCurrentStack(currentWorkingFlashcardId);

        ManageStacksService.GetEditFlashcardsInCurrentStack(currentWorkingFlashcardId);

        MainHelper.MainMenuReturnComments();
    }

    internal static void GetViewAllFlashcards(string currentWorkingStack)
    {
        Console.WriteLine($"{currentWorkingStack}");

        ManageStacksService.GetViewAllFlashcardsMethod(currentWorkingStack);

        MainHelper.MainMenuReturnComments();
    }

    internal static void GetViewXAmountFlashcards(string currentWorkingStack)
    {
        Console.WriteLine($"{currentWorkingStack}");

        Console.WriteLine($"What is your X amount?");

        string xAmountString = Console.ReadLine();

        int xAmount = ManageStacksService.GetSelectXAmount(xAmountString);

        ManageStacksService.GetViewXAmountFlashcardsMethod(currentWorkingStack, xAmount);

        MainHelper.MainMenuReturnComments();
    }



}
