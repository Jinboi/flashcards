using Flash.Helper.DTO;
using Flash;
using System.Data.SqlClient;
using Flashcards.ConsoleApp.Controllers;
using Flashcards.ConsoleApp.Models;

namespace Flashcards.ConsoleApp.Views;
internal class SelectStackPage
{


    /// <summary>
    /// WAS WORING ON THIS
    /// </summary>
    internal static void Show()
    {
        Console.WriteLine("Checking to see if you already have a stack");

        int stacksTableCount = StacksController.GetCheckStacksTable();

        if (stacksTableCount == 0)
        {
            Console.WriteLine("No stacks found. Moving to CreateStackPage");
            CreateStackPage.Show();
        }
        else
        {
            Console.WriteLine("StacksTable already exists\n");
        }

        Console.WriteLine("All the existing stacks");

        StacksController.ShowAllStacks();

        Console.WriteLine("\nInput Name of the Stack you want to work with Or Input 0 to Return to MainMenu");
        Console.WriteLine("\nIf you add a Stack Name that doesn't exist, you'll be creating a new Stack under that Name.");

        string currentWorkingStack = Console.ReadLine();

        Console.WriteLine("Stack Chosen");

        Console.WriteLine("Moving to ManageStackPage");

        ManageStacksPage.Show(currentWorkingStack);
    }

    private static void ExecuteSelectStackCommands(string command, bool closeApp)
    {
        if (Enum.TryParse(command, out SelectStackCommand menuCommand))
        {
            switch (menuCommand)
            {
                case SelectStackCommand.Exit:
                    MainMenuPage.Show();
                    break;

                case SelectStackCommand.CheckStack:
                    CheckStackPage.Show();
                    break;

                case SelectStackCommand.CreateStack:
                    CreateStackPage.Show();
                    break;

                case SelectStackCommand.ShowStacks:
                    ShowStackPage.Show();
                    break;

                default:
                    Console.WriteLine("\nInvalid Command. Please type a number from 0 to 4.\n");
                    break;
            }
        }
    }
}
