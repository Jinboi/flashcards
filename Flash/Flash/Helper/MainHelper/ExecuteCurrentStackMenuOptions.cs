namespace Flash.Helper.MainHelper;

internal class ExecuteCurrentStackMenuOptions
{
    internal static void ProcessStackMenuCommand(string command, string currentWorkingStack)
    {
        if (Enum.TryParse(command, out StackMenuCommand menuCommand))
        {
            switch (menuCommand)
            {
                case StackMenuCommand.Exit:
                    Console.WriteLine("\nGoodbye!\n");
                    GameEngine.ViewMainMenu();
                    break;

                case StackMenuCommand.ChangeStack:
                    Console.WriteLine("Change Current Stack");
                    GameEngine.GetManageStacks();
                    break;

                case StackMenuCommand.ViewAllFlashcards:
                    Console.WriteLine("View All Flashcards in Stack");
                    ManageStacksController.GetViewAllFlashcards(currentWorkingStack);
                    break;

                case StackMenuCommand.ViewXAmountFlashcards:
                    Console.WriteLine("View X amount of cards in stack");
                    ManageStacksController.GetViewXAmountFlashcards(currentWorkingStack);
                    break;

                case StackMenuCommand.CreateFlashcard:
                    Console.WriteLine("Create a Flashcard in current stack");
                    ManageStacksController.GetCreateFlashcard(currentWorkingStack);
                    break;

                case StackMenuCommand.EditFlashcard:
                    Console.WriteLine("Edit a Flashcard");
                    ManageStacksController.GetEditFlashcards(currentWorkingStack);
                    break;

                case StackMenuCommand.DeleteFlashcard:
                    Console.WriteLine("Delete a Flashcard");
                    ManageStacksController.GetDeleteFlashcards(currentWorkingStack);
                    break;

                default:
                    Console.WriteLine("\nInvalid Command. Please type a number from 0 to 6.\n");
                    break;
            }
        }
        else
        {
            Console.WriteLine("\nInvalid Command. Please type a number from 0 to 6.\n");
        }
    }
}
