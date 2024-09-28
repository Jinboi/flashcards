    using Flash;
    using Flash.Helper.MainHelper;
    using Flashcards.ConsoleApp.Controllers;
    using Flashcards.ConsoleApp.Models;
    using Spectre.Console;

    namespace Flashcards.ConsoleApp.Views
    {
        internal class ManageStacksPage
        {
            internal static void Show()
            {
                Console.Clear();

                MainHelper.DisplayBanner("Manage Stacks", Color.Green);

                string currentWorkingStack = "";  // Initial stack is empty

                while (true)
                {
                    Console.Clear();
                    MainHelper.DisplayBanner("Manage Stacks", Color.Green);
                    Console.WriteLine($"Current Stack: {currentWorkingStack}\n");

                    showManageStacksMenu();

                    string command = Console.ReadLine();

                    if (command == "0")  // Allow returning to the main menu if needed
                    {
                        MainMenuPage.Show();
                        break;
                    }

                    ExecuteStackMenuCommand(command, ref currentWorkingStack);
                }
            }

            private static void showManageStacksMenu()
            {
                var rows = new List<Text>()
                {
                    new Text("- Type 0 to Return to Main Menu", new Style(Color.Red, Color.Black)),
                    new Text("- Type 1 to Select Current Stack", new Style(Color.Purple, Color.Black)),
                    new Text("- Type 2 to View All Flashcards in Stack", new Style(Color.Blue, Color.Black)),
                    new Text("- Type 3 to View X amount of cards in stack", new Style(Color.Purple, Color.Black)),
                    new Text("- Type 4 to Create a Flashcard in current stack", new Style(Color.Orange3, Color.Black)),
                    new Text("- Type 5 to Edit a Flashcard", new Style(Color.Red, Color.Black)),
                    new Text("- Type 6 to Delete a Flashcard", new Style(Color.Green, Color.Black)),
                };

                AnsiConsole.Write(new Rows(rows));
            }

            internal static void ExecuteStackMenuCommand(string command, ref string currentWorkingStack)
            {
                if (Enum.TryParse(command, out StackMenuCommand menuCommand))
                {
                    switch (menuCommand)
                    {
                        case StackMenuCommand.Exit:
                            Console.WriteLine("\nReturning to Main Menu...\n");
                            MainMenuPage.Show();
                            break;

                        case StackMenuCommand.SelectStack:
                            Console.WriteLine("Select Current Stack");
                            SelectStackPage.Show(out currentWorkingStack);  // Update `currentWorkingStack` using `out`
                            break;

                        case StackMenuCommand.ViewAllFlashcards:
                            if (!string.IsNullOrEmpty(currentWorkingStack))
                            {
                                Console.WriteLine("View All Flashcards in Stack");
                                FlashcardController.GetViewAllFlashcards(currentWorkingStack);
                            }
                            else
                            {
                                AnsiConsole.Markup("[red]Please select a stack first![/]\n");
                            }
                            break;

                        case StackMenuCommand.ViewXAmountFlashcards:
                            if (!string.IsNullOrEmpty(currentWorkingStack))
                            {
                                Console.WriteLine("View X amount of cards in stack");
                                FlashcardController.GetViewXAmountFlashcards(currentWorkingStack);
                            }
                            else
                            {
                                AnsiConsole.Markup("[red]Please select a stack first![/]\n");
                            }
                            break;

                        case StackMenuCommand.CreateFlashcard:
                            if (!string.IsNullOrEmpty(currentWorkingStack))
                            {
                                Console.WriteLine("Create a Flashcard in current stack");
                                FlashcardController.GetCreateFlashcard(currentWorkingStack);
                            }
                            else
                            {
                                AnsiConsole.Markup("[red]Please select a stack first![/]\n");
                            }
                            break;

                        case StackMenuCommand.EditFlashcard:
                            if (!string.IsNullOrEmpty(currentWorkingStack))
                            {
                                Console.WriteLine("Edit a Flashcard");
                                FlashcardController.GetEditFlashcards(currentWorkingStack);
                            }
                            else
                            {
                                AnsiConsole.Markup("[red]Please select a stack first![/]\n");
                            }
                            break;

                        case StackMenuCommand.DeleteFlashcard:
                            if (!string.IsNullOrEmpty(currentWorkingStack))
                            {
                                Console.WriteLine("Delete a Flashcard");
                                FlashcardController.GetDeleteFlashcards(currentWorkingStack);
                            }
                            else
                            {
                                AnsiConsole.Markup("[red]Please select a stack first![/]\n");
                            }
                            break;

                        default:
                            Console.WriteLine("\nInvalid Command. Please type a number from 0 to 7.\n");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nInvalid Command. Please type a number from 0 to 7.\n");
                }
            }
        }
    }
