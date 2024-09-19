using Flash.Helper.DTO;
using Flash;
using System.Data.SqlClient;
using Flashcards.ConsoleApp.Controllers;
using Flashcards.ConsoleApp.Models;
using Flashcards.ConsoleApp.Views;
using Flash.Helper.MainHelper;
using Spectre.Console;

namespace Flashcards.ConsoleApp.Views;
internal class SelectStackPage
{
    internal static void Show()
    {
        Console.Clear();

        MainHelper.DisplayBanner("Select Stack", Color.Green);






        ShowSelectStackCommands();

        string command = Console.ReadLine();

        ExecuteSelectStackCommands(command);





        ManageStacksPage.Show(currentWorkingStack);

    }

    private static void ShowSelectStackCommands()
    {
        var rows = new List<Text>(){
                new Text("-Type 0 to Return to Main Menu", new Style(Color.Red, Color.Black)),
                new Text("-Type 1 to Check Stack", new Style(Color.Green, Color.Black)),
                new Text("-Type 2 to Create Stack", new Style(Color.Blue, Color.Black)),
                new Text("-Type 3 to Show Stacks", new Style(Color.Purple, Color.Black)),
                };

        AnsiConsole.Write(new Rows(rows));
    }


    private static void ExecuteSelectStackCommands(string command)
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
